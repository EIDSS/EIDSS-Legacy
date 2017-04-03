using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Text;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.DBService.DataSource.LayoutDetailDataSetTableAdapters;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.RAM_DB.DBService.Models;
using Ionic.Zlib;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.model.Model.Core;
using eidss.model.Core;

namespace EIDSS.RAM_DB.DBService
{
    public class Layout_DB : BaseRamDbService
    {
        private readonly SharedModel m_SharedModel;

        private Layout_DB()
        {
            ObjectName = @"AsLayout";
        }

        public Layout_DB(SharedModel sharedModel) : this()
        {
            m_SharedModel = sharedModel;
        }

        public override DataSet GetDetail(object id)
        {
            EidssUserContext.CheckUserLoggedIn();

            long correctedId = CorrectId(id, -1);
            Trace.WriteLine(Trace.Kind.Info, "Layout_DB.GetDetail() with id {0}", Utils.Str(id));

            var dataSet = new LayoutDetailDataSet {EnforceConstraints = false};

            var layoutAdapter = new LayoutAdapter
                                    {
                                        Connection = (SqlConnection) ConnectionManager.DefaultInstance.Connection
                                    };
            layoutAdapter.Fill(dataSet.Layout, ModelUserContext.CurrentLanguage, correctedId, (long) EidssUserContext.User.ID);
            var aggregateAdapter = new AggregateAdapter
                                       {
                                           Connection = (SqlConnection) ConnectionManager.DefaultInstance.Connection
                                       };
            aggregateAdapter.Fill(dataSet.Aggregate, ModelUserContext.CurrentLanguage, correctedId);

            // if only predefined layout must be shown, and layout is loaded but it is not predefined, hide it by emulating empty layout 
            if (!m_SharedModel.ShowAllItems && dataSet.Layout.Rows.Count > 0)
            {
                var layoutRow = (LayoutDetailDataSet.LayoutRow) dataSet.Layout.Rows[0];
                if (!layoutRow.blnReadOnly)
                {
                    dataSet.Layout.Clear();
                }
            }
            m_IsNewObject = (dataSet.Layout.Rows.Count == 0);
            if (m_IsNewObject)
            {
                LayoutDetailDataSet.LayoutRow layoutRow = GetNewLayoutRow(dataSet);
                dataSet.Layout.AddLayoutRow(layoutRow);
                m_ID = layoutRow.idflLayout;
            }
            else
            {
                var layoutRow = (LayoutDetailDataSet.LayoutRow) dataSet.Layout.Rows[0];
                if (!layoutRow.IsblbZippedBasicXmlNull())
                {
                    layoutRow.strBasicXml = UncompressString(layoutRow.blbZippedBasicXml);
                }
                if (!layoutRow.IsblbGisLayerSettingsNull())
                {
                    layoutRow.strGisLayerSettings = UncompressString(layoutRow.blbGisLayerSettings);
                }
                if (!layoutRow.IsblbGisZippedMapSettingsNull())
                {
                    layoutRow.strGisMapSettings = UncompressString(layoutRow.blbGisZippedMapSettings);
                }
                m_ID = id;
            }
            AcceptChanges(dataSet);
            return dataSet;
        }

       

        public override bool PostDetail(DataSet dataSet, int postType, IDbTransaction transaction)
        {
            Utils.CheckNotNull(dataSet, "dataSet");
            if (!(dataSet is LayoutDetailDataSet))
            {
                throw new ArgumentException(string.Format("dataset must be of type {0}", typeof (LayoutDetailDataSet)));
            }

            Trace.WriteLine(Trace.Kind.Info, "Layout_DB.PostDetail()");
            m_SharedModel.MapHasChanges = false;
            var layoutDataSet = (LayoutDetailDataSet) dataSet;
            try
            {
                LayoutDetailDataSet.LayoutDataTable layoutTable = layoutDataSet.Layout;
                if (layoutTable.Count == 0)
                {
                    throw new RamDbException("Table Layout doesn't contains any row");
                }

                var layoutRow = (LayoutDetailDataSet.LayoutRow) layoutTable.Rows[0];

                if (m_IsNewObject)
                {
                    if (m_SharedModel.SelectedFolderId < 0)
                    {
                        layoutRow.SetidflLayoutFolderNull();
                    }
                    else
                    {
                        layoutRow.idflLayoutFolder = m_SharedModel.SelectedFolderId;
                    }
                }

                if (!layoutRow.IsstrBasicXmlNull())
                {
                    layoutRow.blbZippedBasicXml = CompressString(layoutRow.strBasicXml);
                }
                if (!layoutRow.IsstrGisLayerSettingsNull())
                {
                    layoutRow.blbGisLayerSettings = CompressString(layoutRow.strGisLayerSettings);
                }
                if (!layoutRow.IsstrGisMapSettingsNull())
                {
                    layoutRow.blbGisZippedMapSettings = CompressString(layoutRow.strGisMapSettings);
                }

                using (IDbCommand cmd = CreateSPCommand("spAsLayoutPost", transaction))
                {
                    AddCommandParams(cmd, layoutTable, layoutRow);
                    cmd.ExecuteNonQuery();
                }

                using (IDbCommand cmd = CreateSPCommand("spAsLayoutAggregatePost", transaction))
                {
                    AddAndCheckParam(cmd, "@LangID", ModelUserContext.CurrentLanguage);
                    AddAndCheckParam(cmd, layoutTable.idflLayoutColumn, layoutRow.idflLayout);
                    string xml = GetAggregateSearchFieldXml(layoutDataSet.Aggregate);
                    AddAndCheckParam(cmd, "AggregateSearchFieldXml", xml, ParameterDirection.Input);

                    cmd.ExecuteNonQuery();
                }

                m_IsNewObject = false;
                LookupCache.NotifyChange("Layout", transaction, ID);
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.PostError, ex);
                throw;
            }
            return true;
        }

        public void Publish()
        {
            lock (Connection)
            {
                try
                {
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    using (IDbTransaction transaction = Connection.BeginTransaction())
                    {
                        try
                        {
                            object publishedLayoutID;
                            using (IDbCommand cmd = CreateSPCommand("spAsLayoutPublish", transaction))
                            {
                                AddAndCheckParam(cmd, "@idflLayout", ID);
                                AddTypedParam(cmd, "@idfsPublishedLayout", SqlDbType.BigInt, ParameterDirection.Output);
                                cmd.ExecuteNonQuery();
                                publishedLayoutID = GetParamValue(cmd, "@idfsPublishedLayout");
                            }
                            LookupCache.NotifyChange("Layout", transaction);
                            if (publishedLayoutID != null)
                            {
                                EIDSS_EventLog.Instance.CreateProcessedEvent(EventType.AVRLayoutUpdate,
                                                                             publishedLayoutID, 0,
                                                                             EidssUserContext.User.ID,
                                                                             transaction);
                            }
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                finally
                {
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                }
            }
        }

        public Dictionary<long, long> CreateCopyLayout(LayoutDetailDataSet dataSet)
        {
            Utils.CheckNotNull(dataSet, "dataSet");

            m_IsNewObject = true;
            var layoutRow = (LayoutDetailDataSet.LayoutRow) dataSet.Layout.Rows[0];

            dataSet.Layout.idflLayoutColumn.ReadOnly = false;
            dataSet.Layout.idflChartNameColumn.ReadOnly = false;
            dataSet.Layout.idflMapNameColumn.ReadOnly = false;

            List<long> idList = NewListIntID(5 + dataSet.Aggregate.Rows.Count);

            layoutRow.idflChartName = idList[0];
            layoutRow.idflLayout = idList[1];
            m_ID = layoutRow.idflLayout;
            layoutRow.idflMapName = idList[2];
            layoutRow.idflPivotName = idList[3];
            layoutRow.idflDescription = idList[4];
            layoutRow.blnReadOnly = false;

            dataSet.Layout.idflLayoutColumn.ReadOnly = true;
            dataSet.Layout.idflChartNameColumn.ReadOnly = true;
            dataSet.Layout.idflMapNameColumn.ReadOnly = true;

            var changedIds = new Dictionary<long, long>();
            int counter = 5;
            foreach (LayoutDetailDataSet.AggregateRow row in dataSet.Aggregate.Rows)
            {
                long oldId = row.idfLayoutSearchField;
                row.idfLayoutSearchField = idList[counter];
                changedIds.Add(oldId, row.idfLayoutSearchField);
                counter++;
            }
            foreach (LayoutDetailDataSet.AggregateRow row in dataSet.Aggregate.Rows)
            {
                if (!row.IsidfDateQuerySearchFieldNull() && row.idfDateQuerySearchField > 0)
                {
                    row.idfDateQuerySearchField = changedIds[row.idfDateQuerySearchField];
                }
                if (!row.IsidfDenominatorQuerySearchFieldNull() && row.idfDenominatorQuerySearchField > 0)
                {
                    row.idfDenominatorQuerySearchField = changedIds[row.idfDenominatorQuerySearchField];
                }
                if (!row.IsidfUnitQuerySearchFieldNull() && row.idfUnitQuerySearchField > 0)
                {
                    row.idfUnitQuerySearchField = changedIds[row.idfUnitQuerySearchField];
                }
            }

            return changedIds;
        }

        private static string GetAggregateSearchFieldXml(LayoutDetailDataSet.AggregateDataTable aggregate)
        {
            var xmlBuilder = new StringBuilder();
            xmlBuilder.AppendLine(@"<ItemList>");

            foreach (LayoutDetailDataSet.AggregateRow row in aggregate.Rows)
            {
                // fix if no aggregate function set
                if (row.IsidfsAggregateFunctionNull())
                {
                    row.idfsAggregateFunction = 10004002 /*CustomSummaryType.Count*/;
                }
                xmlBuilder.Append(@"<Item ");

                AppendParameter(xmlBuilder, aggregate.idfLayoutSearchFieldColumn, row.idfLayoutSearchField);
                AppendParameter(xmlBuilder, aggregate.idfsAggregateFunctionColumn, row.idfsAggregateFunction);
                AppendParameter(xmlBuilder, aggregate.SearchFieldAliasColumn, row.SearchFieldAlias);
                AppendParameter(xmlBuilder, aggregate.strOriginalFieldENCaptionColumn, row.strOriginalFieldENCaption);
                AppendParameter(xmlBuilder, aggregate.strOriginalFieldCaptionColumn, row.strOriginalFieldCaption);
                AppendParameter(xmlBuilder, aggregate.strNewFieldENCaptionColumn, row.strNewFieldENCaption);
                AppendParameter(xmlBuilder, aggregate.strNewFieldCaptionColumn, row.strNewFieldCaption);

                object idfUnit = row.IsidfUnitQuerySearchFieldNull() || row.idfUnitQuerySearchField < 0
                                     ? DBNull.Value
                                     : (object) row.idfUnitQuerySearchField;
                AppendParameter(xmlBuilder, aggregate.idfUnitQuerySearchFieldColumn, idfUnit);
                object idfDen = row.IsidfDenominatorQuerySearchFieldNull() || row.idfDenominatorQuerySearchField < 0
                                    ? DBNull.Value
                                    : (object) row.idfDenominatorQuerySearchField;
                AppendParameter(xmlBuilder, aggregate.idfDenominatorQuerySearchFieldColumn, idfDen);
                object idfDate = row.IsidfDateQuerySearchFieldNull() || row.idfDateQuerySearchField < 0
                                     ? DBNull.Value
                                     : (object) row.idfDateQuerySearchField;
                AppendParameter(xmlBuilder, aggregate.idfDateQuerySearchFieldColumn, idfDate);

                xmlBuilder.Append(@" />");
                xmlBuilder.AppendLine();
            }

            xmlBuilder.Append(@"</ItemList>");
            return xmlBuilder.ToString();
        }

        private static void AppendParameter(StringBuilder xmlBuilder, object name, object id)
        {
            xmlBuilder.AppendFormat(@" {0}=""{1}""", name, SecurityElement.Escape(Utils.Str(id)));
        }

        private LayoutDetailDataSet.LayoutRow GetNewLayoutRow(LayoutDetailDataSet dataSet)
        {
            Utils.CheckNotNull(dataSet, "dataSet");

            LayoutDetailDataSet.LayoutRow layoutRow = dataSet.Layout.NewLayoutRow();

            layoutRow.blnApplyFilter = false;
            layoutRow.blnPivotAxis = false;
            layoutRow.blnReadOnly = false;
            layoutRow.blnShareLayout = false;
            layoutRow.blnShowColGrandTotals = false;
            layoutRow.blnShowColsTotals = false;
            layoutRow.blnShowForSingleTotals = false;
            layoutRow.blnShowRowGrandTotals = false;
            layoutRow.blnShowRowsTotals = false;
            layoutRow.blnShowXLabels = false;
            layoutRow.blnShowPointLabels = false;

            List<long> idList = NewListIntID(5);

            layoutRow.idflChartName = idList[0];
            layoutRow.idflLayout = idList[1];
            m_ID = layoutRow.idflLayout;

            layoutRow.idflMapName = idList[2];
            layoutRow.idflPivotName = idList[3];
            layoutRow.idflDescription = idList[4];
            layoutRow.idflQuery = QueryID;
            layoutRow.idfsChartType = (long) DBChartType.chrBar;
            layoutRow.idfsGroupInterval = (long) DBGroupInterval.gitDate;

            EidssUserContext.CheckUserLoggedIn();
            layoutRow.idfUserID = (long) EidssUserContext.User.ID;

            layoutRow.strBasicXml = string.Empty;
            layoutRow.blbZippedBasicXml = new byte[0];
            layoutRow.strChartName = string.Empty;
            layoutRow.strDefaultLayoutName = string.Empty;
            layoutRow.strDescription = string.Empty;
            layoutRow.strLayoutName = string.Empty;
            layoutRow.strMapName = string.Empty;

            layoutRow.strGisLayerSettings = string.Empty;
            layoutRow.blbGisLayerSettings = new byte[0];
            layoutRow.strGisMapSettings = string.Empty;
            layoutRow.blbGisZippedMapSettings = new byte[0];
            layoutRow.intGisLayerPosition = 0;

            return layoutRow;
        }

        private void AddCommandParams
            (IDbCommand cmd,
             LayoutDetailDataSet.LayoutDataTable layoutTable,
             LayoutDetailDataSet.LayoutRow layoutRow)
        {
            Utils.CheckNotNull(cmd, "cmd");
            Utils.CheckNotNull(layoutTable, "layoutTable");
            Utils.CheckNotNull(layoutRow, "layoutRow");

            AddAndCheckParam(cmd, "@strLanguage", ModelUserContext.CurrentLanguage);
            AddAndCheckParam(cmd, layoutTable.blnApplyFilterColumn, layoutRow.blnApplyFilter);
            AddAndCheckParam(cmd, layoutTable.blnPivotAxisColumn, layoutRow.blnPivotAxis);
            AddAndCheckParam(cmd, layoutTable.blnReadOnlyColumn, layoutRow.blnReadOnly);
            AddAndCheckParam(cmd, layoutTable.blnShareLayoutColumn, layoutRow.blnShareLayout);
            AddAndCheckParam(cmd, layoutTable.blnShowColGrandTotalsColumn, layoutRow.blnShowColGrandTotals);
            AddAndCheckParam(cmd, layoutTable.blnShowColsTotalsColumn, layoutRow.blnShowColsTotals);
            AddAndCheckParam(cmd, layoutTable.blnShowForSingleTotalsColumn, layoutRow.blnShowForSingleTotals);
            AddAndCheckParam(cmd, layoutTable.blnShowRowGrandTotalsColumn, layoutRow.blnShowRowGrandTotals);
            AddAndCheckParam(cmd, layoutTable.blnShowRowsTotalsColumn, layoutRow.blnShowRowsTotals);
            AddAndCheckParam(cmd, layoutTable.blnShowXLabelsColumn, layoutRow.blnShowXLabels);
            AddAndCheckParam(cmd, layoutTable.blnShowPointLabelsColumn, layoutRow.blnShowPointLabels);
            AddAndCheckParam(cmd, layoutTable.idflChartNameColumn, layoutRow.idflChartName);
            AddAndCheckParam(cmd, layoutTable.idflPivotNameColumn, layoutRow.idflPivotName);
            AddAndCheckParam(cmd, layoutTable.idflLayoutColumn, layoutRow.idflLayout);
            AddAndCheckParam(cmd, layoutTable.idflLayoutFolderColumn,
                             layoutRow.IsidflLayoutFolderNull() ? DBNull.Value : (object) layoutRow.idflLayoutFolder);
            AddAndCheckParam(cmd, layoutTable.idflMapNameColumn, layoutRow.idflMapName);
            AddAndCheckParam(cmd, layoutTable.idflDescriptionColumn, layoutRow.idflDescription);
            AddAndCheckParam(cmd, layoutTable.idflQueryColumn, layoutRow.idflQuery);
            AddAndCheckParam(cmd, layoutTable.idfsChartTypeColumn, layoutRow.idfsChartType);
            AddAndCheckParam(cmd, layoutTable.idfsGroupIntervalColumn, layoutRow.idfsGroupInterval);

            EidssUserContext.CheckUserLoggedIn();
            layoutRow.idfUserID = (long) EidssUserContext.User.ID;
            AddAndCheckParam(cmd, layoutTable.idfUserIDColumn, layoutRow.idfUserID);

            AddAndCheckParam(cmd, layoutTable.blbZippedBasicXmlColumn, layoutRow.blbZippedBasicXml);
            AddAndCheckParam(cmd, layoutTable.strChartNameColumn, layoutRow.strChartName);
            AddAndCheckParam(cmd, layoutTable.strDefaultLayoutNameColumn, layoutRow.strDefaultLayoutName);
            AddAndCheckParam(cmd, layoutTable.strDescriptionColumn, layoutRow.strDescription);
            AddAndCheckParam(cmd, layoutTable.strLayoutNameColumn, layoutRow.strLayoutName);
            AddAndCheckParam(cmd, layoutTable.strPivotNameColumn, layoutRow.strPivotName);
            AddAndCheckParam(cmd, layoutTable.strMapNameColumn, layoutRow.strMapName);

            AddAndCheckParam(cmd, layoutTable.blbZippedBasicXmlColumn, layoutRow.blbZippedBasicXml);

            AddAndCheckParam(cmd, layoutTable.blbGisLayerSettingsColumn,
                             layoutRow.IsblbGisLayerSettingsNull()
                                 ? new byte[0]
                                 : layoutRow.blbGisLayerSettings);
            AddAndCheckParam(cmd, layoutTable.blbGisZippedMapSettingsColumn,
                             layoutRow.IsblbGisZippedMapSettingsNull()
                                 ? new byte[0]
                                 : layoutRow.blbGisZippedMapSettings);
            AddAndCheckParam(cmd, layoutTable.intGisLayerPositionColumn,
                             layoutRow.IsintGisLayerPositionNull()
                                 ? DBNull.Value
                                 : (object) layoutRow.intGisLayerPosition);
        }
    }
}
