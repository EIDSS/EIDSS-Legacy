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
using eidss.avr.db.DBService.DataSource;
using eidss.avr.db.DBService.DataSource.LayoutDetailDataSetTableAdapters;
using eidss.model.Avr.Chart;
using eidss.model.AVR.Db;
using eidss.model.Avr.Pivot;
using eidss.model.Core;
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

            //  throw new AvrDataException("TEST");

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
                layoutRow.strPivotGridSettings = layoutRow.IsblbPivotGridSettingsNull() || layoutRow.blbPivotGridSettings.Length == 0
                    ? string.Empty
                    : BinaryCompressor.UnzipString(layoutRow.blbPivotGridSettings);
                m_ID = id;
            }

            IsDetailsLoaded = true;
            AcceptChanges(dataSet);
            return dataSet;
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

            layoutRow.blnApplyPivotGridFilter = false;
            layoutRow.blnReadOnly = false;
            layoutRow.blnShareLayout = false;
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

            layoutRow.intPivotGridXmlVersion = (int) PivotGridXmlVersion.Version6;
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

        #region Post Detail

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
                AddCommandParams(cmd, layoutTable, layoutRow);
                cmd.ExecuteNonQuery();
            }

            using (IDbCommand cmd = CreateSPCommand("spAsLayoutSearchFieldPost", transaction))
            {
                string xml = GetLayoutSearchFieldXml(layoutSearchFieldData);

                AddAndCheckParam(cmd, "LangID", ModelUserContext.CurrentLanguage);
                AddAndCheckParam(cmd, layoutTable.idflLayoutColumn, layoutRow.idflLayout);
                AddAndCheckParam(cmd, "LayoutSearchFieldXml", xml, ParameterDirection.Input);

                cmd.ExecuteNonQuery();
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

        private void AddCommandParams
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
            AddAndCheckParam(cmd, layoutTable.idfPersonColumn, layoutRow.idfPerson);

            AddAndCheckParam(cmd, layoutTable.blbPivotGridSettingsColumn, layoutRow.blbPivotGridSettings);
            AddAndCheckParam(cmd, layoutTable.strDefaultLayoutNameColumn, layoutRow.strDefaultLayoutName);
            AddAndCheckParam(cmd, layoutTable.strDescriptionColumn, layoutRow.strDescription);
            AddAndCheckParam(cmd, layoutTable.strLayoutNameColumn, layoutRow.strLayoutName);

            AddAndCheckParam(cmd, layoutTable.blnShowMissedValuesInPivotGridColumn, layoutRow.blnShowMissedValuesInPivotGrid ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.intPivotGridXmlVersionColumn, (int) PivotGridXmlVersion.Version6);
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
                    row.idfsAggregateFunction = 10004002 /*CustomSummaryType.Count*/;
                }
                xmlBuilder.Append(@"<Item ");

                AppendParameter(xmlBuilder, searchFieldTable.idfLayoutSearchFieldColumn, row.idfLayoutSearchField);
                AppendParameter(xmlBuilder, searchFieldTable.idfsAggregateFunctionColumn, row.idfsAggregateFunction);
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
                    : (object)row.datDiapasonEndDate.ToString("yyyy-MM-dd"); ;
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

                object idfUnit = row.IsidfUnitLayoutSearchFieldNull() || row.idfUnitLayoutSearchField < 0
                    ? DBNull.Value
                    : (object) row.idfUnitLayoutSearchField;
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

            layoutRow.idflLayout = idList[0];
            m_ID = layoutRow.idflLayout;
            layoutRow.idflDescription = idList[1];
            layoutRow.blnReadOnly = false;
            dataSet.Layout.idflLayoutColumn.ReadOnly = true;

            var changedIds = new Dictionary<long, long>();

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
    }
}