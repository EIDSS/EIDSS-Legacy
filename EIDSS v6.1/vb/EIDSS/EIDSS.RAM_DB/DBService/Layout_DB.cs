using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Text;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Enums;
using bv.model.Model.Core;
using eidss.avr.db.Common;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.db.DBService.DataSource.LayoutDetailDataSetTableAdapters;
using eidss.model.Avr.Chart;
using eidss.model.AVR.DataBase;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.WindowsService.Serialization;

namespace eidss.avr.db.DBService
{
    public abstract class Layout_DB : BaseAvrDbService
    {
        private long m_QueryID = -1;

        protected Layout_DB()
        {
            ObjectName = @"AsLayout";
        }

        public bool IsDetailsLoaded { get; private set; }

        public override AvrTreeElementType ElementType
        {
            get { return AvrTreeElementType.Layout; }
        }

        public void SetQueryID(long queryId)
        {
            m_QueryID = queryId;
        }

        #region Get Detail

        public override DataSet GetDetail(object id)
        {
            long correctedId = CorrectId(id, -1);

            var dataSet = new LayoutDetailDataSet {EnforceConstraints = false};

            var connection = (SqlConnection) ConnectionManager.DefaultInstance.Connection;
            using (var layoutAdapter = new LayoutAdapter())
            {
                layoutAdapter.Connection = connection;
                layoutAdapter.Fill(dataSet.Layout, ModelUserContext.CurrentLanguage, correctedId, CurrentEmpoyeeId);
            }

            using (var searchFieldAdapter = new LayoutSearchFieldAdapter())
            {
                searchFieldAdapter.Connection = connection;
                searchFieldAdapter.Fill(dataSet.LayoutSearchField, ModelUserContext.CurrentLanguage, correctedId);
            }

            // idfLayoutSearchField == idfUnitLayoutSearchField means that Adm Unit = country
            foreach (var row in dataSet.LayoutSearchField)
            {
                if (!row.IsidfUnitLayoutSearchFieldNull() && row.idfLayoutSearchField == row.idfUnitLayoutSearchField)
                {
                    row.idfUnitLayoutSearchField = -1;
                    row.strUnitSearchFieldAlias = string.Empty;
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
                if (layoutRow.IsblbPivotGridSettingsNull() || layoutRow.blbPivotGridSettings.Length == 0)
                {
                    layoutRow.strPivotGridSettings = string.Empty;
                }
                else
                {
                    try
                    {
                        if (layoutRow.intPivotGridXmlVersion == (int) PivotGridXmlVersion.Version5 ||
                            layoutRow.intPivotGridXmlVersion == (int) PivotGridXmlVersion.Version6)
                        {
                            layoutRow.strPivotGridSettings = BinaryCompressor.UnzipString(layoutRow.blbPivotGridSettings);
                        }
                        else
                        {
                            layoutRow.strPivotGridSettings = BinarySerializer.DeserializeToString(layoutRow.blbPivotGridSettings);
                        }
                    }
                    catch (Exception ex)
                    {
                        layoutRow.strPivotGridSettings = string.Empty;
                        Trace.WriteLine(ex);
                    }
                }
                m_ID = id;
            }

            IsDetailsLoaded = true;
            AcceptChanges(dataSet);
            return dataSet;
        }

        public static string GetFilterExpression(object id)
        {
            string filter = null;
            long correctedId = CorrectId(id, -1);
            if (correctedId > 0)
            {
                var dataSet = new LayoutDetailDataSet {EnforceConstraints = false};
                var connection = (SqlConnection) ConnectionManager.DefaultInstance.Connection;
                using (var layoutAdapter = new LayoutAdapter())
                {
                    layoutAdapter.Connection = connection;
                    layoutAdapter.Fill(dataSet.Layout, ModelUserContext.CurrentLanguage, correctedId, CurrentEmpoyeeId);
                }
                if (dataSet.Layout.Rows.Count > 0)
                {
                    var layoutRow = (LayoutDetailDataSet.LayoutRow) dataSet.Layout.Rows[0];
                    if (!layoutRow.IsblbPivotGridSettingsNull() && 
                        layoutRow.blbPivotGridSettings.Length > 0 &&
                        layoutRow.blnApplyPivotGridFilter)
                    {
                        try
                        {
                            filter = layoutRow.intPivotGridXmlVersion == (int) PivotGridXmlVersion.Version5 ||
                                     layoutRow.intPivotGridXmlVersion == (int) PivotGridXmlVersion.Version6
                                ? BinaryCompressor.UnzipString(layoutRow.blbPivotGridSettings)
                                : BinarySerializer.DeserializeToString(layoutRow.blbPivotGridSettings);
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex);
                        }
                    }
                }
            }

            return filter;
        }

        private static long? CurrentEmpoyeeId
        {
            get
            {
                long? employeeId = (EidssUserContext.User == null ||
                                    EidssUserContext.User.EmployeeID == null ||
                                    EidssUserContext.User.EmployeeID is DBNull)
                    ? (long?) null
                    : (long) EidssUserContext.User.EmployeeID;
                return employeeId;
            }
        }

        private LayoutDetailDataSet.LayoutRow GetNewLayoutRow(LayoutDetailDataSet dataSet)
        {
            Utils.CheckNotNull(dataSet, "dataSet");

            LayoutDetailDataSet.LayoutRow layoutRow = dataSet.Layout.NewLayoutRow();

            layoutRow.blnReadOnly = false;
            layoutRow.blnShareLayout = false;
            layoutRow.blnShowDataInPivotGrid = false;
            layoutRow.blnShowColGrandTotals = false;
            layoutRow.blnShowColsTotals = false;
            layoutRow.blnShowForSingleTotals = false;
            layoutRow.blnShowRowGrandTotals = false;
            layoutRow.blnShowRowsTotals = false;
            layoutRow.blnApplyPivotGridFilter = false;

            layoutRow.blnCompactPivotGrid = false;
            layoutRow.blnFreezeRowHeaders = false;
            layoutRow.blnUseArchivedData = false;
            layoutRow.blnShowMissedValuesInPivotGrid = false;
            

            layoutRow.strDefaultLayoutName = string.Empty;
            layoutRow.strDescription = string.Empty;
            layoutRow.strLayoutName = string.Empty;

            List<long> idList = NewListIntID(2);

            layoutRow.idflLayout = idList[0];
            m_ID = layoutRow.idflLayout;
            layoutRow.idflDescription = idList[1];

            layoutRow.idfsDefaultGroupDate = (long) DBGroupInterval.gitDateYear;

            layoutRow.intPivotGridXmlVersion = (int) PivotGridXmlVersion.Version7;
            layoutRow.intGisLayerPosition = 0;

            layoutRow.strPivotGridSettings = string.Empty;
            layoutRow.blbPivotGridSettings = new byte[0];

            layoutRow.strGisLayerGeneralSettings = string.Empty;
            layoutRow.blbGisLayerGeneralSettings = new byte[0];

            layoutRow.strGisMapGeneralSettings = string.Empty;
            layoutRow.blbGisMapGeneralSettings = new byte[0];

            if (CurrentEmpoyeeId.HasValue)
            {
                layoutRow.idfPerson = CurrentEmpoyeeId.Value;
            }
            else
            {
                layoutRow.SetidfPersonNull();
            }

            return layoutRow;
        }

        #endregion

        #region Post 

        public override bool PostDetail(DataSet dataSet, int postType, IDbTransaction transaction = null)
        {
            LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldData;
            LayoutDetailDataSet.LayoutDataTable layoutTable = GetLayoutTableFromDataSet(dataSet, out layoutSearchFieldData);

            try
            {
                PrepareLayoutBeforePost(layoutTable);

                PostLayoutInDB(transaction, layoutTable, layoutSearchFieldData);
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.PostError, ex);
                return false;
            }
            return true;
        }

        protected abstract void PrepareLayoutBeforePost(LayoutDetailDataSet.LayoutDataTable layoutTable);

        private void PostLayoutInDB
            (IDbTransaction transaction, LayoutDetailDataSet.LayoutDataTable layoutTable,
                LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldData)
        {
            if (m_QueryID < 0)
            {
                throw new AvrDbException("Query ID is not set when Layout Post");
            }

            var layoutRow = (LayoutDetailDataSet.LayoutRow) layoutTable.Rows[0];

            using (IDbCommand cmd = CreateSPCommand("spAsLayoutPost", transaction))
            {
                AddLayoutCommandParams(cmd, layoutTable, layoutRow);
                ExecCommand(cmd, cmd.Connection, transaction);
            }

            using (IDbCommand cmd = CreateSPCommand("spAsLayoutSearchFieldPost", transaction))
            {
                string xml = GetLayoutSearchFieldXml(layoutSearchFieldData);

                AddAndCheckParam(cmd, "LangID", ModelUserContext.CurrentLanguage);
                AddAndCheckParam(cmd, layoutTable.idflLayoutColumn, layoutRow.idflLayout);
                AddAndCheckParam(cmd, "LayoutSearchFieldXml", xml, ParameterDirection.Input);

                ExecCommand(cmd, cmd.Connection, transaction);
            }

            LookupCache.NotifyChange("Layout", transaction, ID);
        }

        private static LayoutDetailDataSet.LayoutDataTable GetLayoutTableFromDataSet
            (DataSet dataSet, out LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldData)
        {
            Utils.CheckNotNull(dataSet, "dataSet");
            if (!(dataSet is LayoutDetailDataSet))
            {
                throw new ArgumentException(string.Format("dataset must be of type {0}", typeof (LayoutDetailDataSet)));
            }
            var layoutDataSet = (LayoutDetailDataSet) dataSet;
            LayoutDetailDataSet.LayoutDataTable layoutTable = layoutDataSet.Layout;
            if (layoutTable.Count == 0)
            {
                throw new AvrDbException("Table Layout doesn't contains any row");
            }
            searchFieldData = layoutDataSet.LayoutSearchField;
            return layoutTable;
        }

        private void AddLayoutCommandParams
            (IDbCommand cmd,
                LayoutDetailDataSet.LayoutDataTable layoutTable,
                LayoutDetailDataSet.LayoutRow layoutRow)
        {
            Utils.CheckNotNull(cmd, "cmd");
            Utils.CheckNotNull(layoutTable, "layoutTable");
            Utils.CheckNotNull(layoutRow, "layoutRow");

            AddAndCheckParam(cmd, "@strLanguage", ModelUserContext.CurrentLanguage);
            AddAndCheckParam(cmd, layoutTable.blnApplyPivotGridFilterColumn, layoutRow.blnApplyPivotGridFilter ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnReadOnlyColumn, layoutRow.blnReadOnly ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShareLayoutColumn, layoutRow.blnShareLayout ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowDataInPivotGridColumn, layoutRow.blnShowDataInPivotGrid ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowColGrandTotalsColumn, layoutRow.blnShowColGrandTotals ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowColsTotalsColumn, layoutRow.blnShowColsTotals ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowForSingleTotalsColumn, layoutRow.blnShowForSingleTotals ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowRowGrandTotalsColumn, layoutRow.blnShowRowGrandTotals ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowRowsTotalsColumn, layoutRow.blnShowRowsTotals ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.idflLayoutColumn, layoutRow.idflLayout);
            AddAndCheckParam(cmd, layoutTable.idflLayoutFolderColumn,
                layoutRow.IsidflLayoutFolderNull() ? DBNull.Value : (object) layoutRow.idflLayoutFolder);
            //AddAndCheckParam(cmd, layoutTable.idflMapNameColumn, layoutRow.idflMapName);
            AddAndCheckParam(cmd, layoutTable.idflDescriptionColumn, layoutRow.idflDescription);
            AddAndCheckParam(cmd, layoutTable.idflQueryColumn, m_QueryID);
            AddAndCheckParam(cmd, layoutTable.idfsDefaultGroupDateColumn, layoutRow.idfsDefaultGroupDate);

            if (CurrentEmpoyeeId.HasValue)
            {
                layoutRow.idfPerson = CurrentEmpoyeeId.Value;
            }
            else
            {
                layoutRow.SetidfPersonNull();
            }
            AddAndCheckParam(cmd, layoutTable.idfPersonColumn, layoutRow.IsidfPersonNull() ? DBNull.Value : (object) layoutRow.idfPerson);

            AddAndCheckParam(cmd, layoutTable.blbPivotGridSettingsColumn, layoutRow.blbPivotGridSettings);
            AddAndCheckParam(cmd, layoutTable.strDefaultLayoutNameColumn, layoutRow.strDefaultLayoutName);
            AddAndCheckParam(cmd, layoutTable.strDescriptionColumn, layoutRow.strDescription);
            AddAndCheckParam(cmd, layoutTable.strLayoutNameColumn, layoutRow.strLayoutName);

            AddAndCheckParam(cmd, layoutTable.blnShowMissedValuesInPivotGridColumn, layoutRow.blnShowMissedValuesInPivotGrid ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.intPivotGridXmlVersionColumn, (int) PivotGridXmlVersion.Version7);
            AddAndCheckParam(cmd, layoutTable.blnCompactPivotGridColumn, layoutRow.blnCompactPivotGrid ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnFreezeRowHeadersColumn, layoutRow.blnFreezeRowHeaders ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnUseArchivedDataColumn, layoutRow.blnUseArchivedData ? 1 : 0);

        }

        private static string GetLayoutSearchFieldXml(LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldTable)
        {
            var xmlBuilder = new StringBuilder();
            xmlBuilder.AppendLine(@"<ItemList>");

            foreach (LayoutDetailDataSet.LayoutSearchFieldRow row in searchFieldTable.Rows)
            {
                // fix if no aggregate function set
                if (row.IsidfsAggregateFunctionNull())
                {
                    row.idfsAggregateFunction = (long)CustomSummaryType.Count;
                }
                // fix if no basic count function set
                if (row.IsidfsBasicCountFunctionNull())
                {
                    row.idfsBasicCountFunction = (long)CustomSummaryType.DistinctCount;
                }

                xmlBuilder.Append(@"<Item ");

                AppendParameter(xmlBuilder, searchFieldTable.idfLayoutSearchFieldColumn, row.idfLayoutSearchField);
                AppendParameter(xmlBuilder, searchFieldTable.idfsAggregateFunctionColumn, row.idfsAggregateFunction);
                AppendParameter(xmlBuilder, searchFieldTable.idfsBasicCountFunctionColumn, row.idfsBasicCountFunction);
                AppendParameter(xmlBuilder, searchFieldTable.strSearchFieldAliasColumn, row.strSearchFieldAlias);
                AppendParameter(xmlBuilder, searchFieldTable.strOriginalFieldENCaptionColumn, row.strOriginalFieldENCaption);
                AppendParameter(xmlBuilder, searchFieldTable.strOriginalFieldCaptionColumn, row.strOriginalFieldCaption);
                AppendParameter(xmlBuilder, searchFieldTable.strNewFieldENCaptionColumn, row.strNewFieldENCaption);
                AppendParameter(xmlBuilder, searchFieldTable.strNewFieldCaptionColumn, row.strNewFieldCaption);

                object idfsGroup = row.IsidfsGroupDateNull() || row.idfsGroupDate < 0
                    ? DBNull.Value
                    : (object) row.idfsGroupDate;
                AppendParameter(xmlBuilder, searchFieldTable.idfsGroupDateColumn, idfsGroup);

                AppendParameter(xmlBuilder, searchFieldTable.blnShowMissedValueColumn, row.blnShowMissedValue ? 1 : 0);

                object datDiapasonStartDate = row.IsdatDiapasonStartDateNull()
                    ? DBNull.Value
                    : (object) row.datDiapasonStartDate.ToString("yyyy-MM-dd");
                AppendParameter(xmlBuilder, searchFieldTable.datDiapasonStartDateColumn, datDiapasonStartDate);
                object datDiapasonEndDate = row.IsdatDiapasonEndDateNull()
                    ? DBNull.Value
                    : (object) row.datDiapasonEndDate.ToString("yyyy-MM-dd");

                AppendParameter(xmlBuilder, searchFieldTable.datDiapasonEndDateColumn, datDiapasonEndDate);

                object intPrecision = row.IsintPrecisionNull()
                    ? DBNull.Value
                    : (object) row.intPrecision;
                AppendParameter(xmlBuilder, searchFieldTable.intPrecisionColumn, intPrecision);

                AppendParameter(xmlBuilder, searchFieldTable.intFieldCollectionIndexColumn, row.intFieldCollectionIndex);
                AppendParameter(xmlBuilder, searchFieldTable.intPivotGridAreaTypeColumn, row.intPivotGridAreaType);
                AppendParameter(xmlBuilder, searchFieldTable.intFieldPivotGridAreaIndexColumn, row.intFieldPivotGridAreaIndex);
                AppendParameter(xmlBuilder, searchFieldTable.blnVisibleColumn, row.blnVisible ? 1 : 0);
                AppendParameter(xmlBuilder, searchFieldTable.blnHiddenFilterFieldColumn, row.blnHiddenFilterField ? 1 : 0);
                AppendParameter(xmlBuilder, searchFieldTable.intFieldColumnWidthColumn, row.intFieldColumnWidth);
                AppendParameter(xmlBuilder, searchFieldTable.blnSortAcsendingColumn, row.blnSortAcsending ? 1 : 0);


                object idfUnit = DBNull.Value;
                if (!row.IsidfUnitLayoutSearchFieldNull())
                {
                    idfUnit = row.idfUnitLayoutSearchField < 0
                       ? row.idfLayoutSearchField
                       : (object)row.idfUnitLayoutSearchField;
                }
                AppendParameter(xmlBuilder, searchFieldTable.idfUnitLayoutSearchFieldColumn, idfUnit);

                object idfDate = row.IsidfDateLayoutSearchFieldNull() || row.idfDateLayoutSearchField < 0
                    ? DBNull.Value
                    : (object) row.idfDateLayoutSearchField;
                AppendParameter(xmlBuilder, searchFieldTable.idfDateLayoutSearchFieldColumn, idfDate);

                object filter = row.IsstrFieldFilterValuesNull() || string.IsNullOrEmpty(row.strFieldFilterValues)
                    ? DBNull.Value
                    : (object) row.strFieldFilterValues;
                AppendParameter(xmlBuilder, searchFieldTable.strFieldFilterValuesColumn, filter);

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

        #endregion

        #region Create Copy

        public Dictionary<long, long> CreateCopyLayout(LayoutDetailDataSet dataSet)
        {
            Utils.CheckNotNull(dataSet, "dataSet");

            m_IsNewObject = true;
            var layoutRow = (LayoutDetailDataSet.LayoutRow) dataSet.Layout.Rows[0];

            dataSet.Layout.idflLayoutColumn.ReadOnly = false;

            int counter = 2;
            List<long> idList = NewListIntID(counter + dataSet.LayoutSearchField.Rows.Count);
            var changedIds = new Dictionary<long, long>
            {
                {layoutRow.idflLayout, idList[0]},
                {layoutRow.idflDescription, idList[1]}
            };
            layoutRow.idflLayout = idList[0];
            m_ID = layoutRow.idflLayout;
            layoutRow.idflDescription = idList[1];
            layoutRow.blnReadOnly = false;
            dataSet.Layout.idflLayoutColumn.ReadOnly = true;

            foreach (LayoutDetailDataSet.LayoutSearchFieldRow row in dataSet.LayoutSearchField.Rows)
            {
                long oldId = row.idfLayoutSearchField;
                row.idfLayoutSearchField = idList[counter];
                changedIds.Add(oldId, row.idfLayoutSearchField);
                counter++;
            }
            foreach (LayoutDetailDataSet.LayoutSearchFieldRow row in dataSet.LayoutSearchField.Rows)
            {
                if (!row.IsidfDateLayoutSearchFieldNull() && row.idfDateLayoutSearchField > 0)
                {
                    row.idfDateLayoutSearchField = changedIds[row.idfDateLayoutSearchField];
                }
                if (!row.IsidfUnitLayoutSearchFieldNull() && row.idfUnitLayoutSearchField > 0)
                {
                    row.idfUnitLayoutSearchField = changedIds[row.idfUnitLayoutSearchField];
                }
            }

            return changedIds;
        }

        #endregion

        #region Publish Unpublish

        protected override long Unpublish(long publishedId, IDbTransaction transaction)
        {
            long id;
            using (IDbCommand cmd = CreateSPCommand("spAsLayoutUnpublish", transaction))
            {
                AddAndCheckParam(cmd, "@idfsLayout", publishedId);
                AddTypedParam(cmd, "@idflLayout", SqlDbType.BigInt, ParameterDirection.Output);
                ExecCommand(cmd, cmd.Connection, transaction);
                id = (long) GetParamValue(cmd, "@idflLayout");
            }

            AfterPublishUnpublish(EventType.AVRLayoutUnpublishedLocal, id, publishedId, transaction);
            return id;
        }

        protected override long Publish(long id, IDbTransaction transaction)
        {
            long publishedId;
            Dictionary<long, long> changedIds = PublishInDB(id, transaction, out publishedId);

            AvrBinarySettings settings = GetLayoutGlobalBinarySettings(publishedId, transaction);

            if (!settings.AreAllBinariesEmpty)
            {
                settings.ReplaceIds(changedIds, settings.IsOldVersion);
                PostLayoutGlobalBinarySettings(publishedId, settings, transaction);
            }

            List<string> languages = GetViewGlobalLanguages(id, transaction);
            foreach (string lang in languages)
            {
                AvrBinarySettings viewSettings = GetViewGlobalBinarySettings(publishedId, lang, transaction);
                if (!viewSettings.AreAllBinariesEmpty)
                {
                    viewSettings.ReplaceIds(changedIds);
                    PostGlobalViewBinarySettings(publishedId, lang, viewSettings, transaction);
                }
            }

            AfterPublishUnpublish(EventType.AVRLayoutPublishedLocal, id, publishedId, transaction);

            return publishedId;
        }

        private Dictionary<long, long> PublishInDB(long id, IDbTransaction transaction, out long publishedId)
        {
            var changedIds = new Dictionary<long, long>();
            using (IDbCommand cmd = CreateSPCommand("spAsLayoutPublish", transaction))
            {
                AddAndCheckParam(cmd, "@idflLayout", id);
                publishedId = -1;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var oldId = (long) reader["idfOld"];
                        var newId = (long) reader["idfNew"];
                        changedIds.Add(oldId, newId);
                        if (publishedId < 0)
                        {
                            publishedId = newId;
                        }
                    }
                }
            }
            return changedIds;
        }

        protected void PostLayoutGlobalBinarySettings(long publishedId, AvrBinarySettings settings, IDbTransaction transaction)
        {
            using (IDbCommand cmd = CreateSPCommand("spAsGlobalLayoutBinaryPost", transaction))
            {
                AddAndCheckParam(cmd, "@idfsLayout", publishedId);
                AddAndCheckParam(cmd, "@blbChartGeneralSettings", settings.ChartSettings);
                AddAndCheckParam(cmd, "@blbGisLayerGeneralSettings", settings.GisLayerSettings);
                AddAndCheckParam(cmd, "@blbGisMapGeneralSettings", settings.GisMapSettings);
                AddAndCheckParam(cmd, "@blbPivotGridSettings", settings.MainSettings);
                ExecCommand(cmd, cmd.Connection, transaction);
            }
        }

        private AvrBinarySettings GetViewGlobalBinarySettings(object layoutId, string lang, IDbTransaction transaction = null)
        {
            var settings = new AvrBinarySettings();
            using (IDbCommand cmd = CreateSPCommand("spAsGlobalViewBinarySelect", transaction))
            {
                AddAndCheckParam(cmd, "@idfsLayout", layoutId);
                AddAndCheckParam(cmd, "@LangID", lang);
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader["blbChartLocalSettings"] is byte[])
                        {
                            settings.ChartSettings = (byte[]) reader["blbChartLocalSettings"];
                        }
                        if (reader["blbGisLayerLocalSettings"] is byte[])
                        {
                            settings.GisLayerSettings = (byte[]) reader["blbGisLayerLocalSettings"];
                        }
                        if (reader["blbGisMapLocalSettings"] is byte[])
                        {
                            settings.GisMapSettings = (byte[]) reader["blbGisMapLocalSettings"];
                        }
                        if (reader["blbViewSettings"] is byte[])
                        {
                            settings.MainSettings = (byte[]) reader["blbViewSettings"];
                        }
                    }
                }
            }
            return settings;
        }

        protected void PostGlobalViewBinarySettings(long publishedId, string lang, AvrBinarySettings settings, IDbTransaction transaction)
        {
            using (IDbCommand cmd = CreateSPCommand("spAsGlobalViewBinaryPost", transaction))
            {
                AddAndCheckParam(cmd, "@idfsLayout", publishedId);
                AddAndCheckParam(cmd, "@LangID", lang);
                AddAndCheckParam(cmd, "@blbChartLocalSettings", settings.ChartSettings);
                AddAndCheckParam(cmd, "@blbGisLayerLocalSettings", settings.GisLayerSettings);
                AddAndCheckParam(cmd, "@blbGisMapLocalSettings", settings.GisMapSettings);
                AddAndCheckParam(cmd, "@blbViewSettings", settings.MainSettings);
                ExecCommand(cmd, cmd.Connection, transaction);
            }
        }

        public List<string> GetViewLanguages(long id, IDbTransaction transaction)
        {
            return GetViewLanguages(id, false, transaction);
        }

        public List<string> GetViewGlobalLanguages(long id, IDbTransaction transaction)
        {
            return GetViewLanguages(id, false, transaction);
        }

        private List<string> GetViewLanguages(long id, bool isGlobal = false, IDbTransaction transaction = null)
        {
            var result = new List<string>();
            string spName = isGlobal ? "spAsGlobalViewSelectLookup" : "spAsViewSelectLookup";
            string paramName = isGlobal ? "@idfsLayout" : "@idflLayout";

            using (IDbCommand cmd = CreateSPCommand(spName, transaction))
            {
                AddAndCheckParam(cmd, paramName, id);
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(Utils.Str(reader["strLanguage"]));
                    }
                }
            }
            return result;
        }

        #endregion
    }
}