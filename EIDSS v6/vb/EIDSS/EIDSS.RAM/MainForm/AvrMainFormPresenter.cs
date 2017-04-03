using System;
using System.Data;
using System.Data.SqlClient;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.avr.BaseComponents;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Export;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Commands.Refresh;
using eidss.model.AVR.Db;
using eidss.model.Avr.Export;
using eidss.model.Resources;
using eidss.winclient.Reports;

namespace eidss.avr.MainForm
{
    public sealed class AvrMainFormPresenter : RelatedObjectPresenter
    {
        private readonly IAvrMainFormView m_FormView;

        public AvrMainFormPresenter(SharedPresenter sharedPresenter, IAvrMainFormView view)
            : base(sharedPresenter, view)
        {
            m_FormView = view;

            m_FormView.DBService = new BaseAvrDbService();
        }

        public override void Process(Command cmd)
        {
            if (cmd is QueryLayoutCloseCommand)
            {
                m_FormView.CloseQueryLayoutStart();
                cmd.State = CommandState.Processed;
            }
            else if (cmd is QueryLayoutDeleteCommand)
            {
                var deleteCommand = (cmd as QueryLayoutDeleteCommand);
                m_FormView.DeleteQueryLayoutStart(deleteCommand);
                cmd.State = CommandState.Processed;
            }
            else if (cmd is ExecQueryCommand)
            {
                long queryId = m_SharedPresenter.SharedModel.SelectedQueryId;
                InvalidateQuery(queryId);
                ExecQuery(queryId);
                cmd.State = CommandState.Processed;
            }
        }

        public void ExportQueryLineListToExcelOrAccess(long queryId, ExportType exportType)
        {
            if (exportType == ExportType.Mdb)
            {
                if (BaseSettings.UseAvrCache)
                {
                    ExportTo("mdb", EidssMessages.Get("msgFilterAccess", "MS Access database|*.mdb"),
                        s =>
                        {
                            AvrAccessExportResult result = AccessExporter.ExportAnyCPU(queryId, s);
                            if (!result.IsOk)
                            {
                                throw new AvrException(result.ErrorMessage + result.ExceptionString);
                            }
                        });
                    
                }
                else
                {
                    ErrorForm.ShowError(EidssMessages.Get("msgCannotExportAvrServiceNotAccessable"));
                }
            }
            else
            {
                DataTable sourceTable = (queryId == m_SharedPresenter.SharedModel.SelectedQueryId)
                    ? m_SharedPresenter.GetQueryResultCopy()
                    : ExecQueryInternal(queryId, ModelUserContext.CurrentLanguage, SharedPresenter.SharedModel.UseArchiveData);

                DataTable destTable = QueryHelper.GetTableWithoutCopiedColumns(sourceTable);

                switch (exportType)
                {
                    case ExportType.Xls:
                        ExportTo("xls", EidssMessages.Get("msgFilterExcel", "Excel documents|*.xls"),
                            s => NpoiExcelWrapper.QueryLineListToExcel(s, destTable, exportType));
                        break;
                    case ExportType.Xlsx:
                        ExportTo("xlsx", EidssMessages.Get("msgFilterExcelXLSX", "Excel documents|*.xlsx"),
                            s => NpoiExcelWrapper.QueryLineListToExcel(s, destTable, exportType));
                        break;

                    default:
                        throw new AvrException(String.Format("Not supported export format {0}", exportType));
                }
            }
        }

        #region Check Avr Service

        #endregion

        #region Executing query

        public void ExecQuery(long queryId)
        {
            ExecQueryForPresenter(m_SharedPresenter, queryId);
        }

        public static void ExecQueryForPresenter(SharedPresenter sharedPresenter, long queryId)
        {
            // we should clear QueryResult before executing new QUery
            sharedPresenter.SetQueryResult(null);

            DataTable result = ExecQueryInternal(queryId, ModelUserContext.CurrentLanguage, sharedPresenter.SharedModel.UseArchiveData);

            sharedPresenter.SetQueryResult(result);

            sharedPresenter.SharedModel.QueryRefreshDateTime = UpdateQueryRefreshDateTime(queryId);
        }

        public static DataTable ExecQueryInternal
            (long queryId, string lang, bool isArchive, Func<long, string, bool, DataTable> queryExecutor = null)
        {
            try
            {
                isArchive &= ArchiveDataHelper.ShowUseArchiveDataCheckbox;
                DataTable result;
                if (queryId > 0)
                {
                    if (queryExecutor == null)
                    {
                        if (BaseSettings.UseAvrCache)
                        {
                            using (var wrapper = new ServiceClientWrapper())
                            {
                                result = WinCheckAvrServiceAccessability(wrapper)
                                    ? GetAvrServiceQueryResult(wrapper, queryId, isArchive)
                                    : new DataTable();
                            }
                        }
                        else
                        {
                            result = GetQueryResult(queryId, isArchive);
                        }
                    }
                    else
                    {
                        result = queryExecutor(queryId, lang, isArchive);
                    }

                    result.TableName = QueryProcessor.GetQueryName(queryId);

                    QueryProcessor.SetCopyPropertyForColumnsIfNeeded(result);
                    QueryProcessor.TranslateTableFields(result, queryId);
                    QueryProcessor.SetNullForForbiddenTableFields(result, queryId);
                }
                else
                {
                    result = new DataTable();
                }
                QueryProcessor.RemoveNotExistingColumns(result, queryId);
                return result;
            }
            catch (OutOfMemoryException ex)
            {
                Trace.WriteLine(ex);
                ErrorForm.ShowMessage("msgQueryResultIsTooBig", null);
                return new DataTable();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                throw new AvrDbException(String.Format("Error while executing query with id '{0}'", queryId), ex);
            }
        }

        public static DataTable GetQueryResult(long queryId, bool isArchive)
        {
            string queryString;
            DataTable defaultData;
            using (CreateExecutingQueryDialog())
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                {
                    queryString = QueryHelper.GetQueryText(manager, queryId, true);

                    defaultData = QueryHelper.GetInnerQueryResult(manager, queryString);
                }
            }

            if (isArchive)
            {
                try
                {
                    if (DbManagerFactory.Factory[DatabaseType.Archive] == null)
                    {
                        DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
                    }

                    using (CreateExecutingArchiveQueryDialog())
                    {
                        using (DbManagerProxy archiveManager = DbManagerFactory.Factory[DatabaseType.Archive].Create())
                        {
                            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                            {
                                QueryHelper.DropAndCreateArchiveQuery(manager, archiveManager, queryId);
                            }
                            DataTable archiveData = QueryHelper.GetInnerQueryResult(archiveManager, queryString);
                            defaultData.Merge(archiveData);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Trace.WriteLine(ex);
                    ErrorForm.ShowMessage("msgErrorExecutingArchiveQuery", null);
                }
            }
            foreach (DataColumn column in defaultData.Columns)
            {
                column.AllowDBNull = true;
            }
            return defaultData;
        }

        private static WaitDialog CreateExecutingQueryDialog()
        {
            string message = EidssMessages.Get("msgAvrExecutingQuery");
            return new WaitDialog(message, m_WaitTitle);
        }

        private static WaitDialog CreateExecutingArchiveQueryDialog()
        {
            string message = EidssMessages.Get("msgAvrExecutingArchiveQuery");
            return new WaitDialog(message, m_WaitTitle);
        }

        internal static DataTable GetAvrServiceQueryResult(ServiceClientWrapper wrapper, long queryId, bool isArchive)
        {
            try
            {
                using (CreateAvrServiceReceiveQueryDialog())
                {
                    var receiver = new AvrCacheReceiver(wrapper);

                    CachedQueryResult result = receiver.GetCachedQueryTable(queryId, ModelUserContext.CurrentLanguage, isArchive);
                    return result.QueryTable;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(EidssMessages.Get("msgAvrServiceError"), ex);
                return new DataTable();
            }
        }

        internal static DateTime UpdateQueryRefreshDateTime(long queryId)
        {
            try
            {
                if (BaseSettings.UseAvrCache)
                {
                    using (var wrapper = new ServiceClientWrapper())
                    {
                        return wrapper.GetQueryRefreshDateTime(queryId, ModelUserContext.CurrentLanguage);
                    }
                }
                return DateTime.Now;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return DateTime.Now;
            }
        }

        public static void InvalidateQuery(long queryId)
        {
            if (BaseSettings.UseAvrCache && queryId > 0)
            {
                using (var wrapper = new ServiceClientWrapper())
                {
                    if (WinCheckAvrServiceAccessability(wrapper))
                    {
                        wrapper.InvalidateQueryCache(queryId);
                    }
                }
            }
        }

        #endregion
    }
}