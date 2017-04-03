using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.win;
using eidss.model.Resources;

namespace EIDSS.RAM.Presenters.RamForm
{
    public class RamFormPresenter : RelatedObjectPresenter
    {
        private const string DropFunctionFormat =
            @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT')) 
                DROP FUNCTION [dbo].[{0}] ";

        private const string DropViewFormat =
            @"IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[{0}]'))
                DROP VIEW [dbo].[{0}]";

        private readonly IRamFormView m_FormView;
        private readonly BaseRamDbService m_DbService;

        public RamFormPresenter(SharedPresenter sharedPresenter, IRamFormView view)
            : base(sharedPresenter, view)
        {
            m_FormView = view;
            m_DbService = new BaseRamDbService();
            m_FormView.DBService = m_DbService;

            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        public override void Process(Command cmd)
        {
        }

        #region Executing query

        public void ExecQuery(long queryId, bool isArchive)
        {
            ExecQuery(m_DbService, m_SharedPresenter, queryId, isArchive);
        }

        public static void ExecQuery(BaseRamDbService dbService, SharedPresenter sharedPresenter, long queryId, bool isArchive)
        {
            DataTable result; 
            if (queryId > 0)
            { 
                // we should clear QueryResult before executing new QUery
                sharedPresenter.SharedModel.QueryResult = null;

                string queryString = QueryProcessor.GetQueryText(queryId);
                string queryFunctionName = isArchive
                                               ? QueryProcessor.GetQueryFunctionName(queryId)
                                               : string.Empty;

                result = GetQueryResult(dbService, queryString, queryFunctionName, isArchive);
                
                QueryProcessor.SetCopyPropertyForColumnsIfNeeded(result);
                QueryProcessor.TranslateTableFields(result, queryId);
                QueryProcessor.SetNullForForbiddenTableFields(result, queryId);
            }
            else
            {
                result = new DataTable();
            }
            QueryProcessor.RemoveNotExistingColumns(result, queryId);
            sharedPresenter.SharedModel.QueryResult = result;
        }

        public static DataTable GetQueryResult(BaseRamDbService dbService, string queryString, string queryFunctionName, bool isArchive)
        {
            Utils.CheckNotNullOrEmpty(queryString, "queryString");
            Trace.WriteLine(Trace.Kind.Info, "PivotForm_DB.GetDataTable(): Updating pivot with query {0}",
                            queryString);

            try
            {
                DataTable defaultData = GetDefaultQueryResult(dbService, queryString);

                if (isArchive)
                {
                    

                    var connectionCredentials = new ConnectionCredentials(null, "Archive");
                    string connectionString = connectionCredentials.CreateConnectionString();
                    DataTable archiveData = GetArchiveQueryResult(dbService, connectionString, queryString, queryFunctionName);
                    if (archiveData != null)
                    {
                        defaultData.Merge(archiveData);
                    }
                }
                foreach (DataColumn column in defaultData.Columns)
                {
                    column.AllowDBNull = true;
                }

                return defaultData;
            }
            catch (OutOfMemoryException)
            {
                //!
                ErrorForm.ShowMessage("msgQueryResultIsTooBig");
                return new DataTable();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                throw new RamDbException(string.Format("Error while executing query :'{0}'", queryString), ex);
            }
        }

        private static DataTable GetDefaultQueryResult(BaseRamDbService dbService, string queryString)
        {
            DataTable mainData;
            string title = EidssMessages.Get("msgPleaseWait");
            string message = EidssMessages.Get("msgAvrExecutingQuery");
            using (new WaitDialog(message, title))
            {
                {
                    mainData = dbService.GetInnerQueryResult(queryString);
                }
            }
            return mainData;
        }

        private static DataTable GetArchiveQueryResult(BaseRamDbService dbService, string archiveConnectionString, string queryString, string queryFunctionName)
        {
            if (Utils.IsEmpty(archiveConnectionString))
            {
                ErrorForm.ShowWarning("msgArchiveConnectionNotConfigured");
                return null;
            }

            DataTable archiveData;
            try
            {
                string title = EidssMessages.Get("msgPleaseWait");
                string message = EidssMessages.Get("msgAvrExecutingArchiveQuery");
                using (new WaitDialog(message, title))
                {
                    
                    if (!queryFunctionName.StartsWith("fn"))
                    {
                        throw new RamException(string.Format("Query function {0} should starts with 'fn'", queryFunctionName));
                    }
                    string queryViewName = "vw" + queryFunctionName.Remove(0, 2);
                    var dropFunctionText = string.Format(DropFunctionFormat, queryFunctionName);
                    var dropViewText = string.Format(DropViewFormat, queryViewName);
                    var createFunctionText = dbService.GetQueryFunctionText(queryFunctionName);
                    var createViewText = dbService.GetQueryFunctionText(queryViewName);
                    using (var archiveConnection = new SqlConnection(archiveConnectionString))
                    {
                        dbService.ExecuteNonQuery(dropViewText, archiveConnection);
                        dbService.ExecuteNonQuery(createViewText, archiveConnection);
                        dbService.ExecuteNonQuery(dropFunctionText, archiveConnection);
                        dbService.ExecuteNonQuery(createFunctionText, archiveConnection);

                        archiveData = dbService.GetInnerQueryResult(queryString, archiveConnection);
                    }
                }
            }
            catch (SqlException ex)
            {
                archiveData = null;
                Trace.WriteLine(ex);
                //!
                ErrorForm.ShowMessage("msgErrorExecutingArchiveQuery");
            }
            return archiveData;
        }

        #endregion

        private void SharedModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = (SharedProperty) (Enum.Parse(typeof (SharedProperty), e.PropertyName));
            switch (property)
            {
                case SharedProperty.AtLeastOneFieldVisible:
                    bool visible = m_SharedPresenter.SharedModel.AtLeastOneFieldVisible;
                    m_FormView.OnPivotFieldVisibleChanged(new LayoutFieldVisibleChanged(visible));
                    break;
                case SharedProperty.ControlsView:
                    PivotSelectionEventArgs args = m_SharedPresenter.SharedModel.ControlsView;
                    m_FormView.OnPivotSelected(args);
                    break;
            }
        }
    }
}
