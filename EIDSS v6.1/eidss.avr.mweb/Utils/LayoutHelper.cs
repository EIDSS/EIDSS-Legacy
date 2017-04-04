using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.db.Core;
using bv.common.Enums;
using DevExpress.Data.Filtering;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraRichEdit.API.Layout;
using EIDSS;
using eidss.avr.db.Common;
using eidss.avr.db.Complexity;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.mweb.Models;
using EIDSS.Enums;
using eidss.model.Avr.Chart;
using eidss.model.AVR.DataBase;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.SourceData;
using eidss.model.Resources;

namespace eidss.avr.mweb.Utils
{
    public class LayoutHelper
    {
        public LayoutHelper(LayoutDetailDataSet dataSet)
        {
            m_DataSet = dataSet;
        }

        #region Properties

        private readonly LayoutDetailDataSet m_DataSet;

        public LayoutDetailDataSet LayoutDataSet
        {
            get { return m_DataSet; }
        }

        public LayoutDetailDataSet.LayoutDataTable LayoutTable
        {
            get { return LayoutDataSet.Layout; }
        }

        public LayoutDetailDataSet.LayoutRow LayoutRow
        {
            get
            {
                if (LayoutTable.Count == 0)
                {
                    throw new AvrDbException("Table Layout of BaseDataSet is empty");
                }

                return (LayoutDetailDataSet.LayoutRow) LayoutDataSet.Layout.Rows[0];
            }
        }

        public string SettingsXml
        {
            get
            {
                string basicXml = LayoutRow.IsstrPivotGridSettingsNull()
                    ? String.Empty
                    : LayoutRow.strPivotGridSettings;

                return basicXml;
            }
            set { LayoutRow.strPivotGridSettings = value; }
        }

        public LayoutDetailDataSet.LayoutSearchFieldDataTable LayoutSearchFieldTable
        {
            get { return m_DataSet.LayoutSearchField; }
        }

        private static DataView m_SearchFieldLookup;
        private static object m_lockObject = new object();

        public static DataView SearchFieldLookup
        {
            get
            {
                lock (m_lockObject)
                {
                    if (m_SearchFieldLookup == null)
                    {
                        m_SearchFieldLookup =
                            QueryHelper.CreateSearchFieldsLookupView(LookupCache.Get(LookupTables.SearchField));
                    }
                    return m_SearchFieldLookup;
                }
            }
        }

        #endregion

        #region Load Pivot data from DB

        public LayoutValidateResult LoadPivotFromDB(AvrPivotGridData model, IList<IAvrPivotGridField> avrFields,bool isNewObject)
        {
            if ((PivotGridXmlVersion) LayoutRow.intPivotGridXmlVersion == PivotGridXmlVersion.Version5)
            {
                throw new AvrDbException("Layout has version 5 format. It's not supported.");
            }

            if (!isNewObject)
            {
                AvrPivotGridHelper.LoadSearchFieldsVersionSixFromDB(avrFields, LayoutSearchFieldTable, LayoutRow.idfsDefaultGroupDate);

                LoadPivotFilterVersionSixFromDB();
            }

            AvrPivotGridHelper.LoadExstraSearchFieldsProperties(avrFields, LayoutSearchFieldTable);

            AvrPivotGridHelper.SwapOriginalAndCopiedFieldsIfReversed(avrFields);

           

            var result = new LayoutValidateResult();
            LayoutBaseValidator validator = LayoutPivotGridHelper.CreateLayoutComplexityValidator();
            if (LayoutRow.blnShowMissedValuesInPivotGrid)
            {
                result =AvrPivotGridHelper.AddMissedValuesAndValidateComplexity(model, avrFields,  validator);
            }
            if (!result.IsCancelOrUserDialogCancel())
            {
                result = AvrPivotGridHelper.FillEmptyValuesAndValidateComplexity(model, avrFields,  validator);
            }
            return result;
            
           
        }

        private void LoadPivotFilterVersionSixFromDB()
        {
            try
            {
                if (!string.IsNullOrEmpty(SettingsXml))
                {
                    CriteriaOperator criteria = CriteriaOperator.Parse(SettingsXml);
                    SetFilterCriteriaForGrid(criteria);
                }
            }
            catch (Exception ex)
            {
                SetFilterCriteriaForGrid(null);
                string msg = EidssMessages.Get("errCannotRestoreAvrFilterFromDb", "Pivot Grid filter can't be restored from Database");
                throw new AvrDbException(msg, ex);
            }
        }

        private void SetFilterCriteriaForGrid(CriteriaOperator criteria)
        {
            // todo: [ivan] implement filters for web
            //m_PivotView.PivotGridView.Criteria = criteria;
        }

        #endregion

        public void FillCustomSummaryTypes()
        {
            var summaryTypes = new Dictionary<string, CustomSummaryType>();
            foreach (LayoutDetailDataSet.LayoutSearchFieldRow row in m_DataSet.LayoutSearchField)
            {
                string fieldName = AvrPivotGridFieldHelper.CreateFieldName(row.strSearchFieldAlias,
                    row.idfLayoutSearchField);
                CustomSummaryType summary = row.IsidfsAggregateFunctionNull()
                    ? CustomSummaryType.Undefined
                    : (CustomSummaryType) row.idfsAggregateFunction;
                summaryTypes.Add(fieldName, summary);
            }
        }

        public bool SaveData(AvrPivotSettings settings)
        {
            List<IAvrPivotGridField> fields = settings.Fields.Cast<IAvrPivotGridField>().ToList();
            AvrPivotGridHelper.PrepareLayoutSearchFieldsBeforePost(fields,
                LayoutDataSet.LayoutSearchField, settings.QueryId, settings.LayoutId);
            var db = new WebLayoutDB();
            db.SetQueryID(settings.QueryId);
            LayoutRow.idfsDefaultGroupDate = settings.DefaultGroupInterval;
            LayoutRow.blnShowColsTotals = settings.ShowColumnTotals;
            LayoutRow.blnShowRowsTotals = settings.ShowRowTotals;
            LayoutRow.blnShowColGrandTotals = settings.ShowColumnGrandTotals;
            LayoutRow.blnShowRowGrandTotals = settings.ShowRowGrandTotals;
            LayoutRow.blnShowForSingleTotals = settings.ShowTotalsForSingleValues;
            LayoutRow.blnShowMissedValuesInPivotGrid = settings.ShowMissedValues;
            LayoutRow.blnApplyPivotGridFilter = settings.ApplyFilter;
            LayoutRow.blnCompactPivotGrid = settings.CompactLayout;
            LayoutRow.blnFreezeRowHeaders = settings.FreezeRowHeaders;
            LayoutRow.blnUseArchivedData = settings.UseArchiveData;
            LayoutRow.strPivotGridSettings = settings.FilterCriteriaString;
            LayoutRow.blnShowDataInPivotGrid = settings.ShowDataInPivot;
            return db.PostDetail(m_DataSet, (int) PostType.FinalPosting);
        }

        public void InitAvrPivotSettings(AvrPivotSettings pivotSettings)
        {
            if (LayoutRow != null)
            {
                pivotSettings.DefaultGroupInterval = LayoutRow.idfsDefaultGroupDate;

                pivotSettings.ShowColumnGrandTotals = LayoutRow.blnShowColGrandTotals;
                pivotSettings.ShowColumnTotals = LayoutRow.blnShowColsTotals;
                pivotSettings.ShowRowGrandTotals = LayoutRow.blnShowRowGrandTotals;
                pivotSettings.ShowRowTotals = LayoutRow.blnShowRowsTotals;
                pivotSettings.ShowTotalsForSingleValues = LayoutRow.blnShowForSingleTotals;

                pivotSettings.ShowMissedValues = LayoutRow.blnShowMissedValuesInPivotGrid;
                pivotSettings.ShowMissedValuesSaved = LayoutRow.blnShowMissedValuesInPivotGrid;
                pivotSettings.ApplyFilter = LayoutRow.blnApplyPivotGridFilter;
                pivotSettings.CompactLayout = LayoutRow.blnCompactPivotGrid;
                pivotSettings.FreezeRowHeaders = LayoutRow.blnFreezeRowHeaders;
                pivotSettings.FilterCriteriaString = LayoutRow.strPivotGridSettings;
                pivotSettings.UseArchiveData = LayoutRow.blnUseArchivedData;
                pivotSettings.IsPublished = LayoutRow.blnReadOnly;
                pivotSettings.ShowDataInPivot = LayoutRow.blnShowDataInPivotGrid;

                pivotSettings.IsSingleSearchObject = !LayoutRow.IsblnSingleSearchObjectNull() && LayoutRow.blnSingleSearchObject;
            }
            else
            {
                pivotSettings.DefaultGroupInterval = (long) DBGroupInterval.gitDateYear;
                pivotSettings.ShowDataInPivot = true;
            }
            pivotSettings.LayoutDataset = LayoutDataSet;
        }

        public static DataView GetAggregateFunctionsView()
        {
            DataView dataView = LookupCache.Get(LookupTables.AggregateFunction.ToString());
            dataView.RowFilter = "blnPivotGridFunction=1";
            return dataView;
        }

        public static DataView GetBascicCountFunctionsView()
        {
            DataView dataView = AggrFunctionLookupHelper.GetLookupTable(AggregateFunctionTarget.Basic);
            return dataView;
        }

        public void PrepareWebFields(AvrPivotSettings pivotSettings)
        {
            //fill lookups for pivot header
            pivotSettings.Intervals = GroupIntervalHelper.GetGroupIntervalLookup();
            pivotSettings.AggregateFuncions = GetAggregateFunctionsView();
            foreach (WebPivotGridField webField in pivotSettings.Fields)
            {
                if (webField.IsHiddenFilterField)
                {
                    webField.Visible = true;
                    //We set webField.Tag = true for all hidden fields
                    //to override PivotGridField.CanShowInPrefilter property that operates correctly with original propertied only.
                    webField.Tag = true;
                    webField.SearchFieldType = GetSearchFieldType(webField);
                    //SetLookupValues(webField);
                }

                if (webField.IsDateTimeField && webField.GroupInterval == PivotGroupInterval.Default)
                {
                    webField.DefaultGroupInterval = GroupIntervalHelper.GetGroupInterval(pivotSettings.DefaultGroupInterval);
                }

//                PivotSummaryType summaryType = webField.CustomSummaryType == CustomSummaryType.Count
//                   ? PivotSummaryType.Count
//                   : PivotSummaryType.Custom;
//                webField.SummaryType = summaryType;
            }
        }

//        public static void UpdateSummaryType
//            (Dictionary<string, CustomSummaryType> summaryTypes, IAvrPivotGridField field)
//        {
//            CustomSummaryType summaryTypeType =
//                summaryTypes.ContainsKey(
//                    field.FieldName)
//                    ? summaryTypes[field.FieldName]
//                    : field.GetDefaultSummaryType();
//            if (!summaryTypes.ContainsKey(field.FieldName))
//            {
//                summaryTypes.Add(
//                    field.FieldName, summaryTypeType);
//            }
//            else
//                summaryTypes[field.FieldName] = summaryTypeType;
//            PivotSummaryType summaryType = summaryTypeType == CustomSummaryType.Count
//                                               ? PivotSummaryType.Count
//                                               : PivotSummaryType.Custom;
//            field.CustomSummaryType = summaryTypeType;
//            field.SummaryType = summaryType;
//            
//            
//        }

        private static SearchFieldType GetSearchFieldType(WebPivotGridField webField)
        {
            string fieldName = webField.Name;
            //DataView view = null;
            DataRow fieldRow;
            bool isLookup;
            int pos = fieldName.IndexOf("__", StringComparison.Ordinal);
            if (pos > 0)
            {
                string[] fieldParts = webField.OriginalFieldName.Split(new[] {"__"}, StringSplitOptions.RemoveEmptyEntries);
                int i = SearchFieldLookup.Find(fieldParts[0]);
                DataRow paramRow = LookupCache.GetLookupRow(webField.OriginalFieldName, LookupTables.ParameterForFFType.ToString());
                object referenceType = paramRow["idfsReferenceType"];
                isLookup = !bv.common.Core.Utils.IsEmpty(referenceType);
                fieldRow = SearchFieldLookup[i].Row;
            }
            else
            {
                int i = SearchFieldLookup.Find(webField.OriginalFieldName);
                fieldRow = SearchFieldLookup[i].Row;
                isLookup = IsLookupField(fieldRow);
            }
            if (isLookup)
            {
                return SearchFieldType.ID;
            }
            return (SearchFieldType) fieldRow["idfsSearchFieldType"];
        }

        //private static DataView GetLookupForWebField(WebPivotGridField webField)
        //{
        //    string fieldName = webField.Name;
        //    DataView view = null;
        //    DataRow fieldRow;
        //    DataRow paramRow = null;
        //    bool isLookup;
        //    string lookupFieldName = "name";
        //    int pos = fieldName.IndexOf("__", StringComparison.Ordinal);
        //    if (pos > 0)
        //    {
        //        string[] fieldParts = webField.OriginalFieldName.Split(new[] { "__" }, StringSplitOptions.RemoveEmptyEntries);
        //        int i = SearchFieldLookup.Find(fieldParts[0]);
        //        paramRow = LookupCache.GetLookupRow(webField.OriginalFieldName, LookupTables.ParameterForFFType.ToString());
        //        object referenceType = paramRow["idfsReferenceType"];
        //        isLookup = !bv.common.Core.Utils.IsEmpty(referenceType);
        //        fieldRow = SearchFieldLookup[i].Row;
        //    }
        //    else
        //    {
        //        int i = SearchFieldLookup.Find(webField.OriginalFieldName);
        //        fieldRow = SearchFieldLookup[i].Row;
        //        isLookup = IsLookupField(fieldRow);
        //    }
        //    if (isLookup)
        //    {
        //        //FF lookup
        //        if (paramRow != null)
        //        {
        //            object referenceType = paramRow["idfsReferenceType"];
        //            object paramType = paramRow["idfsParameterType"];
        //            if (referenceType.Equals((long)model.Enums.BaseReferenceType.rftParametersFixedPresetValue))
        //            {
        //                view = LookupCache.Get(LookupTables.ParametersFixedPresetValue);
        //                view.RowFilter =
        //                    string.Format("idfsParameterType = {0} and idfsParameterFixedPresetValue <> {1} ",
        //                                  paramType, LookupCache.EmptyLineKey);
        //                lookupFieldName = "NationalName";
        //            }
        //            else
        //            {
        //                view = LookupCache.Get((BaseReferenceType)referenceType);
        //            }

        //        }
        //        //usual lookup
        //        else
        //        {
        //            string referenceType = LookupCache.GetLookupValue(fieldRow["idfsSearchField"],
        //                                                              LookupTables.SearchField, "idfsReferenceType");
        //            string gisReferenceType = LookupCache.GetLookupValue(fieldRow["idfsSearchField"],
        //                                                                 LookupTables.SearchField, "idfsGISReferenceType");
        //            string lookupType = LookupCache.GetLookupValue(fieldRow["idfsSearchField"], LookupTables.SearchField,
        //                                                           "strLookupTable");
        //            lookupFieldName = LookupCache.GetLookupValue(fieldRow["idfsSearchField"], LookupTables.SearchField,
        //                                                           "strLookupAttribute");
        //            if (!bv.common.Core.Utils.IsEmpty(lookupType) && !lookupType.StartsWith("rft"))
        //            {
        //                view = LookupCache.Get(lookupType);
        //            }
        //            else if (!bv.common.Core.Utils.IsEmpty(referenceType))
        //            {
        //                view = LookupCache.Get((BaseReferenceType)(bv.common.Core.Utils.ToLong(referenceType)));
        //            }
        //            else if (!bv.common.Core.Utils.IsEmpty(gisReferenceType))
        //            {
        //                view = LookupCache.Get((GisRefereneceType)bv.common.Core.Utils.ToLong(gisReferenceType));
        //            }
        //        }
        //    }
        //    if (view != null)
        //    {
        //        if (string.IsNullOrEmpty(lookupFieldName))
        //            lookupFieldName = "name";
        //        if (lookupFieldName == "strRegionExtendedName")
        //            lookupFieldName = "strExtendedRegionName";
        //        view.Sort = bv.common.Core.Utils.Str(lookupFieldName);
        //    }
        //    return view;
        //}
        protected static bool IsLookupField(DataRow searchFieldRow, bool isFlexibleFormField = false)
        {
            if (isFlexibleFormField)
            {
                return (!bv.common.Core.Utils.IsEmpty(searchFieldRow["idfsReferenceType"]));
            }
            return !bv.common.Core.Utils.IsEmpty(searchFieldRow["idfsReferenceType"]) |
                   !bv.common.Core.Utils.IsEmpty(searchFieldRow["idfsGISReferenceType"]) |
                   !bv.common.Core.Utils.IsEmpty(searchFieldRow["strLookupTable"]);
        }

        //private static void SetLookupValues(WebPivotGridField webField)
        //{
        //    var view = GetLookupForWebField(webField);
        //    if (view != null)
        //        webField.FilterValues.SetValues(GetLookupValues(view), PivotFilterType.Included, false);
        //}

        //private static IList<object> GetLookupValues(DataView view)
        //{
        //    var list = new List<object>();
        //    foreach (DataRowView row in view)
        //    {
        //        list.Add(bv.common.Core.Utils.Str(row[view.Sort]));
        //    }
        //    return list;
        //}
    }
}