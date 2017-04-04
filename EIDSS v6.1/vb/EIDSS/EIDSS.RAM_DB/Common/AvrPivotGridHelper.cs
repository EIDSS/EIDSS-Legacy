using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using DevExpress.Data.Filtering;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.Complexity;
using eidss.avr.db.DBService.DataSource;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.View;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.SourceData;
using eidss.model.Enums;
using eidss.model.Resources;
using EIDSS;
using EIDSS.Enums;

namespace eidss.avr.db.Common
{
    public static class AvrPivotGridHelper
    {
        private const string IdColumnName = "Id";
        private const string AliasColumnName = "Alias";
        private const string CaptionColumnName = "Caption";
        private const string OrderColumnName = "Order";

        private const string AgeGroupFieldName = "sflHCAG_AgeGroup";
        private const string PatientSexFieldName = "sflHC_PatientSex";

        private static Dictionary<string, Type> m_FieldDataTypes;

        public static string GetCorrectFilter(CriteriaOperator criteria)
        {
            if (Utils.IsEmpty(criteria))
            {
                return null;
            }
            string filter = criteria.LegacyToString();
            if (!Utils.IsEmpty(filter))
            {
                int ind = filter.IndexOf(" ?", StringComparison.InvariantCulture);
                while (ind >= 0)
                {
                    string substrFilter = filter.Substring(0, ind);
                    if (substrFilter.EndsWith("] =") || substrFilter.EndsWith("] <=") || substrFilter.EndsWith("] >=") ||
                        substrFilter.EndsWith("] <>") || substrFilter.EndsWith("] >") || substrFilter.EndsWith("] <"))
                    {
                        int bracketInd = substrFilter.LastIndexOf("[", StringComparison.InvariantCulture);
                        if (bracketInd >= 0)
                        {
                            substrFilter = substrFilter.Substring(0, bracketInd) + "1 = 1";
                        }
                    }
                    if (filter.Length > ind + 2)
                    {
                        filter = substrFilter + filter.Substring(ind + 2);
                        ind = filter.IndexOf(" ?", substrFilter.Length, StringComparison.InvariantCulture);
                    }
                    else
                    {
                        filter = substrFilter;
                        ind = -1;
                    }
                }
            }
            return filter;
        }

        #region Create search fields

        public static List<T> CreateFields<T>(AvrDataTable data) where T : IAvrPivotGridField, new()
        {
            var list = new List<T>();
            foreach (AvrDataColumn column in data.Columns)
            {
                bool isCopy = column.ExtendedProperties.ContainsKey(QueryHelper.CopySuffix);

                var field = new T
                {
                    Name = "field" + column.ColumnName,
                    FieldName = column.ColumnName,
                    Caption = column.Caption,
                    Ordinal = column.Ordinal,
                    IsHiddenFilterField = isCopy,
                    Visible = isCopy
                };

                field.SearchFieldDataType = GetSearchFieldType(field.OriginalFieldName);
                field.UpdateImageIndex();
                field.UseNativeFormat = DefaultBoolean.False;

                list.Add(field);
            }

            return list;
        }

        internal static Dictionary<string, Type> GetSearchFieldDataTypes(DataTable lookupTable)
        {
            var result = new Dictionary<string, Type>();
            foreach (KeyValuePair<string, SearchFieldType> pair in QueryLookupHelper.GetFieldTypes(lookupTable))
            {
                Type value;
                switch (pair.Value)
                {
                    case SearchFieldType.Bit:
                        value = typeof (bool);
                        break;
                    case SearchFieldType.Date:
                        value = typeof (DateTime);
                        break;
                    case SearchFieldType.Float:
                        value = typeof (float);
                        break;
                    case SearchFieldType.ID:
                    case SearchFieldType.Integer:
                        value = typeof (long);
                        break;
                    default:
                        value = typeof (string);
                        break;
                }
                result.Add(pair.Key, value);
                result.Add(pair.Key + QueryHelper.CopySuffix, value);
                result.Add(pair.Key + QueryHelper.GisSuffix, value);
                result.Add(pair.Key + QueryHelper.GisSuffix + QueryHelper.CopySuffix, value);
            }
            return result;
        }

        internal static Type GetSearchFieldType(string fieldName)
        {
            if ((m_FieldDataTypes == null) || (!m_FieldDataTypes.ContainsKey(fieldName)))
            {
                DataTable lookupTable = QueryLookupHelper.GetQuerySearchFieldLookupTable();
                m_FieldDataTypes = GetSearchFieldDataTypes(lookupTable);
            }
            if (!m_FieldDataTypes.ContainsKey(fieldName))
            {
                throw new AvrException("Cannot load type for field " + fieldName);
            }
            return m_FieldDataTypes[fieldName];
        }

        #endregion

        #region Load Search Fields from DB

        public static IEnumerable<LayoutDetailDataSet.LayoutSearchFieldRow> GetSortedLayoutSearchFieldRows
            (LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldDataTable)
        {
            List<LayoutDetailDataSet.LayoutSearchFieldRow> rowList =
                searchFieldDataTable.Rows.Cast<LayoutDetailDataSet.LayoutSearchFieldRow>().ToList();
            rowList.Sort((firstRow, secondRow) =>
            {
                int firstIndex = 10000 * firstRow.intPivotGridAreaType + firstRow.intFieldPivotGridAreaIndex;
                int secondIndex = 10000 * secondRow.intPivotGridAreaType + secondRow.intFieldPivotGridAreaIndex;
                return firstIndex.CompareTo(secondIndex);
            });
            return rowList;
        }

        public static void LoadSearchFieldsVersionSixFromDB
            (IList<IAvrPivotGridField> avrFields, LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldDataTable,
                long defaultGroupIntervalId)
        {
            IEnumerable<LayoutDetailDataSet.LayoutSearchFieldRow> rowList = GetSortedLayoutSearchFieldRows(searchFieldDataTable);
            foreach (LayoutDetailDataSet.LayoutSearchFieldRow row in rowList)
            {
                IAvrPivotGridField field = avrFields.FirstOrDefault(f => f.FieldId == row.idfLayoutSearchField);
                if (field != null)
                {
                    field.DefaultGroupInterval = GroupIntervalHelper.GetGroupInterval(defaultGroupIntervalId);
                    field.LoadSearchFieldFromRow(row);
                }
            }
        }

        public static void LoadExstraSearchFieldsProperties
            (IList<IAvrPivotGridField> avrFields, LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldDataTable)
        {
            IEnumerable<LayoutDetailDataSet.LayoutSearchFieldRow> rowList = GetSortedLayoutSearchFieldRows(searchFieldDataTable);

            foreach (LayoutDetailDataSet.LayoutSearchFieldRow row in rowList)
            {
                IAvrPivotGridField field = avrFields.FirstOrDefault(f => f.FieldId == row.idfLayoutSearchField);
                if (field != null)
                {
                    field.LoadSearchFieldExstraFromRow(row);
                    field.AllPivotFields = avrFields.ToList();
                    field.FieldNamesDictionary = GetFieldNamesDictionary(field.AllPivotFields);

                    PivotSummaryType summaryType = field.CustomSummaryType == CustomSummaryType.Count
                        ? PivotSummaryType.Count
                        : PivotSummaryType.Custom;
                    field.SummaryType = summaryType;
                    // todo[ivan] uncomment and implement if custom sorting need to be implemented, delete otherwise
//                    if (field.OriginalFieldName == AgeGroupFieldName)
//                    {
//                        field.SortMode = PivotSortMode.Custom;
//                    }
                }
            }
        }

        public static Dictionary<string, List<IAvrPivotGridField>> GetFieldNamesDictionary(List<IAvrPivotGridField> allPivotFields)
        {
            var fieldsDictionary = new Dictionary<string, List<IAvrPivotGridField>>();
            foreach (IAvrPivotGridField field in allPivotFields)
            {
                string name = field.OriginalFieldName;
                if (!fieldsDictionary.ContainsKey(name))
                {
                    fieldsDictionary.Add(name, new List<IAvrPivotGridField>());
                }
                fieldsDictionary[name].Add(field);
            }
            return fieldsDictionary;
        }

        public static void SwapOriginalAndCopiedFieldsIfReversed(IEnumerable<IAvrPivotGridField> avrFields)
        {
            Dictionary<IAvrPivotGridField, IAvrPivotGridField> fieldsAndCopies = GetFieldsAndCopiesConsideringArea(avrFields);

            // in case original and copied fields have been swapped in the migration process from v4
            foreach (KeyValuePair<IAvrPivotGridField, IAvrPivotGridField> pair in fieldsAndCopies)
            {
                IAvrPivotGridField origin = pair.Key;
                IAvrPivotGridField copy = pair.Value;

                PivotArea newArea = origin.Area;
                bool newVisible = origin.Visible;
                int newIndex = origin.AreaIndex;
                bool isSwap = false;

                if (origin.Area == PivotArea.FilterArea)
                {
                    if (copy.Area == PivotArea.FilterArea)
                    {
                        isSwap = (copy.AllowedAreas != (copy.AllowedAreas & PivotGridAllowedAreas.FilterArea));
                        newVisible = false;
                    }
                    else
                    {
                        isSwap = true;
                        newArea = copy.Area;
                        newVisible = copy.Visible;
                        newIndex = copy.AreaIndex;
                    }
                }

                IAvrPivotGridField originToProcess = isSwap ? copy : origin;
                IAvrPivotGridField copyToProcess = isSwap ? origin : copy;

                originToProcess.IsHiddenFilterField = false;
                originToProcess.Area = (newArea == PivotArea.FilterArea) ? PivotArea.RowArea : newArea;
                originToProcess.AreaIndex = newIndex;
                originToProcess.Visible = newVisible;

                copyToProcess.Visible = true;
                copyToProcess.IsHiddenFilterField = true;
                copyToProcess.GroupInterval = PivotGroupInterval.Default;
            }
        }

        public static Dictionary<IAvrPivotGridField, IAvrPivotGridField> GetFieldsAndCopiesConsideringArea
            (IEnumerable<IAvrPivotGridField> avrFields)
        {
            var fieldsAndCopies = new Dictionary<IAvrPivotGridField, IAvrPivotGridField>();
            IEnumerable<IGrouping<string, IAvrPivotGridField>> grouppedField = avrFields.GroupBy(f => f.OriginalFieldName);
            foreach (IGrouping<string, IAvrPivotGridField> fields in grouppedField)
            {
                IAvrPivotGridField fieldCopy;
                fieldCopy = fields.FirstOrDefault(f => f.Area == PivotArea.FilterArea &&
                                                       f.AllowedAreas == (f.AllowedAreas & PivotGridAllowedAreas.FilterArea))
                            ?? (fields.FirstOrDefault(f => f.Area == PivotArea.FilterArea)
                                ?? (fields.FirstOrDefault(f => !f.Visible)
                                    ?? fields.FirstOrDefault(f => f.IsHiddenFilterField)));

                if (fieldCopy != null)
                {
                    foreach (IAvrPivotGridField field in fields)
                    {
                        if (field != fieldCopy)
                        {
                            fieldsAndCopies.Add(field, fieldCopy);
                        }
                    }
                }
            }

            return fieldsAndCopies;
        }

        #endregion

        #region Save Search Fields to DB

        public static void PrepareLayoutSearchFieldsBeforePost
            (IList<IAvrPivotGridField> fields,
                LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldTable, long idflQuery, long idflLayout)
        {
            RemoveNonExistingLayoutSearchFieldRows(fields, searchFieldTable);

            // just in case when no LayoutSearchFieldRow exists for some field
            AddMissingLayoutSearchFieldRows(fields, searchFieldTable, idflQuery, idflLayout);

            UpdateLayoutSearchFieldRows(fields, searchFieldTable);
        }

        private static void RemoveNonExistingLayoutSearchFieldRows
            (IEnumerable<IAvrPivotGridField> fields, LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldTable)
        {
            List<string> originalFieldNames = fields.Select(field => field.OriginalFieldName).ToList();
            IEnumerable<LayoutDetailDataSet.LayoutSearchFieldRow> allRows =
                searchFieldTable.Rows.Cast<LayoutDetailDataSet.LayoutSearchFieldRow>();
            List<LayoutDetailDataSet.LayoutSearchFieldRow> rowsToRemove =
                allRows.Where(r => !originalFieldNames.Contains(r.strSearchFieldAlias)).ToList();
            foreach (LayoutDetailDataSet.LayoutSearchFieldRow row in rowsToRemove)
            {
                searchFieldTable.RemoveLayoutSearchFieldRow(row);
            }
        }

        private static void AddMissingLayoutSearchFieldRows
            (IList<IAvrPivotGridField> fields,
                LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldTable, long idflQuery, long idflLayout)
        {
            int length = 0;
            foreach (IAvrPivotGridField field in fields)
            {
                string filter = String.Format("{0}='{1}'", searchFieldTable.strSearchFieldAliasColumn.ColumnName, field.OriginalFieldName);
                if (searchFieldTable.Select(filter).Length == 0)
                {
                    length++;
                }
            }
            List<long> ids = BaseDbService.NewListIntID(length);
            int count = 0;
            foreach (IAvrPivotGridField field in fields)
            {
                string filter = String.Format("{0}='{1}'", searchFieldTable.strSearchFieldAliasColumn.ColumnName, field.OriginalFieldName);
                if (searchFieldTable.Select(filter).Length == 0)
                {
                    AddNewLayoutSearchFieldRow(searchFieldTable, idflQuery, idflLayout,
                        field.OriginalFieldName, (long) field.CustomSummaryType, ids[count]);
                    count++;
                }
            }
        }

        private static void UpdateLayoutSearchFieldRows
            (IEnumerable<IAvrPivotGridField> fields, LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldTable)
        {
            searchFieldTable.BeginLoadData();
            foreach (IAvrPivotGridField field in fields)
            {
                field.SaveSearchFieldToTable(searchFieldTable);
            }
            searchFieldTable.EndLoadData();
        }

        #endregion

        #region Get Search Fields by condition

        public static List<IAvrPivotGridField> GetFieldCollectionFromArea
            (IEnumerable<IAvrPivotGridField> allFields, PivotArea pivotArea)
        {
            var dataField = new SortedDictionary<int, IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in allFields)
            {
                if ((field.Visible) && (field.Area == pivotArea))
                {
                    dataField.Add(field.AreaIndex, field);
                }
            }
            var fields = new List<IAvrPivotGridField>(dataField.Values);
            fields.Sort((f1, f2) => f1.AreaIndex.CompareTo(f2.AreaIndex));
            return fields;
        }

        public static IAvrPivotGridField GetGenderField(IEnumerable<IAvrPivotGridField> fields)
        {
            return GetField(fields, PatientSexFieldName);
        }

        public static IAvrPivotGridField GetAgeGroupField(IEnumerable<IAvrPivotGridField> fields)
        {
            return GetField(fields, AgeGroupFieldName);
        }

        private static IAvrPivotGridField GetField(IEnumerable<IAvrPivotGridField> fields, string fieldAlias)
        {
            IAvrPivotGridField foundField =
                fields.ToList().SingleOrDefault(
                    field =>
                        field.Visible &&
                        (field.Area == PivotArea.ColumnArea || field.Area == PivotArea.RowArea) &&
                        field.FieldName.Contains(fieldAlias));

            return foundField;
        }

        #endregion

        #region Process Search Field Summary

        public static bool TryGetDefaultSummaryTypeFor(string name, out CustomSummaryType result)
        {
            DataView searchFields = GetSearchFieldRowByName(name);
            if (searchFields.Count > 0)
            {
                object idAggrFunction = searchFields[0]["idfsDefaultAggregateFunction"];
                if (idAggrFunction is long)
                {
                    result = (CustomSummaryType) idAggrFunction;
                    return true;
                }
            }
            result = CustomSummaryType.Undefined;
            return false;
        }

        public static Dictionary<string, CustomSummaryType> GetNameSummaryTypeDictionary
            (LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldTable)
        {
            var dictionary = new Dictionary<string, CustomSummaryType>();
            foreach (LayoutDetailDataSet.LayoutSearchFieldRow row in layoutSearchFieldTable.Rows)
            {
                string key = AvrPivotGridFieldHelper.CreateFieldName(row.strSearchFieldAlias, row.idfLayoutSearchField);
                if (!dictionary.ContainsKey(key))
                {
                    CustomSummaryType value = ParseSummaryType(row.idfsAggregateFunction);
                    dictionary.Add(key, value);
                }
            }
            return dictionary;
        }

        public static CustomSummaryType ParseSummaryType(long value)
        {
            IEnumerable<CustomSummaryType> allEnumValues =
                Enum.GetValues(typeof (CustomSummaryType)).Cast<CustomSummaryType>();

            CustomSummaryType result = allEnumValues.Any(current => current == (CustomSummaryType) value)
                ? (CustomSummaryType) value
                : CustomSummaryType.Max;

            return result;
        }

        #endregion

        #region Prepare Pivot Data Source

        public static AvrDataTable GetPreparedDataSource
            (LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldTable,
                long queryId, long layoutId, AvrDataTable queryResult, bool isNewObject)
        {
            if (queryResult == null)
            {
                return null;
            }

            FillNewLayoutSearchFields(layoutSearchFieldTable, queryId, layoutId, queryResult, isNewObject);

            DeleteColumnsMissingInLayoutSearchFieldTable(layoutSearchFieldTable, queryResult, isNewObject);

            CreateCopiedColumnsAndAjustColumnNames(layoutSearchFieldTable, queryResult);

            return queryResult;
        }

        /// <summary>
        ///     method generates LayoutSearchFieldRow for each column in the Data Source that hasn't aggregate information
        /// </summary>
        /// <param name="layoutSearchFieldTable"></param>
        /// <param name="queryId"></param>
        /// <param name="layoutId"></param>
        /// <param name="newDataSource"></param>
        /// <param name="isNewObject"></param>
        public static void FillNewLayoutSearchFields
            (LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldTable,
                long queryId, long layoutId, AvrDataTable newDataSource, bool isNewObject)
        {
            List<LayoutDetailDataSet.LayoutSearchFieldRow> rows =
                layoutSearchFieldTable.Rows.Cast<LayoutDetailDataSet.LayoutSearchFieldRow>()
                    .OrderBy(row => row.idfLayoutSearchField)
                    .ToList();

            // If LayoutSearchFieldTable doesn't contain row with Search Field that corresponds to one of QueryResult column, 
            // we should create corresponding LayoutSearchField row

            List<long> idList = null;
            if (isNewObject)
            {
                idList = BaseDbService.NewListIntID(newDataSource.Columns.Count);
            }

            int count = 0;
            foreach (AvrDataColumn column in newDataSource.Columns)
            {
                string columnName = column.ColumnName;
                // process original fields, not copied fields in filter
                // we think than each column has a copy 
                if (AvrPivotGridFieldHelper.GetIsCopyForFilter(columnName))
                {
                    continue;
                }

                List<LayoutDetailDataSet.LayoutSearchFieldRow> foundRows = rows.FindAll(row => (row.strSearchFieldAlias == columnName));
                if (foundRows.Count < 2)
                {
                    CustomSummaryType summaryType = (foundRows.Count == 0)
                        ? Configuration.GetDefaultSummaryTypeFor(columnName, column.DataType)
                        : (CustomSummaryType) foundRows[0].idfsAggregateFunction;

                    string copyColumnName = columnName + QueryHelper.CopySuffix;
                    if (isNewObject && idList != null)
                    {
                        if (foundRows.Count == 0)
                        {
                            AddNewLayoutSearchFieldRow(layoutSearchFieldTable, queryId, layoutId, columnName, (long) summaryType,
                                idList[count]);
                            count++;
                        }
                        LayoutDetailDataSet.LayoutSearchFieldRow copyRow =
                            AddNewLayoutSearchFieldRow(layoutSearchFieldTable, queryId, layoutId, copyColumnName, (long) summaryType,
                                idList[count]);
                        copyRow.blnHiddenFilterField = true;
                        count++;
                    }
                    else
                    {
                        if (foundRows.Count == 0)
                        {
                            AddNewLayoutSearchFieldRow(layoutSearchFieldTable, queryId, layoutId, columnName, (long) summaryType);
                        }
                        LayoutDetailDataSet.LayoutSearchFieldRow copyRow =
                            AddNewLayoutSearchFieldRow(layoutSearchFieldTable, queryId, layoutId, copyColumnName, (long) summaryType);
                        copyRow.blnHiddenFilterField = true;
                    }
                }
                else
                {
                    // second row corresponding to the copied column, so we should change strSearchFieldAlias according to copied column name
                    foundRows[1].strSearchFieldAlias = columnName + QueryHelper.CopySuffix;
                    foundRows[0].blnHiddenFilterField = false;
                    foundRows[1].blnHiddenFilterField = true;
                }
            }
        }

        /// <summary>
        ///     If Current object is NOT new, Method deletes all columns in the Data Source that hasn't corresponding rows in
        ///     AggregateTable
        /// </summary>
        /// <param name="layoutSearchFieldTable"> </param>
        /// <param name="newDataSource"> </param>
        /// <param name="isNewObject"> </param>
        private static void DeleteColumnsMissingInLayoutSearchFieldTable
            (LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldTable,
                AvrDataTable newDataSource, bool isNewObject)
        {
            if (!isNewObject)
            {
                List<LayoutDetailDataSet.LayoutSearchFieldRow> rows =
                    layoutSearchFieldTable.Rows.Cast<LayoutDetailDataSet.LayoutSearchFieldRow>().ToList();
                List<AvrDataColumn> dataColumns = newDataSource.Columns.ToList();

                foreach (AvrDataColumn column in dataColumns)
                {
                    string columnName = column.ExtendedProperties.ContainsKey(QueryHelper.CopySuffix)
                        ? AvrPivotGridFieldHelper.GetOriginalNameFromCopyForFilterName(column.ColumnName)
                        : column.ColumnName;
                    LayoutDetailDataSet.LayoutSearchFieldRow foundRow = rows.Find(row => (row.strSearchFieldAlias == columnName));
                    if (foundRow == null)
                    {
                        newDataSource.Columns.Remove(column);
                    }
                }
            }
        }

        /// <summary>
        ///     If LayoutSearchFieldTable contains multiple rows with the same strSearchFieldAlias, method creates corresponding
        ///     columns.
        ///     Also
        ///     method appends Column Name with corresponding idfLayoutSearchField for each column
        /// </summary>
        /// <param name="layoutSearchFieldTable"> </param>
        /// <param name="newDataSource"> </param>
        private static void CreateCopiedColumnsAndAjustColumnNames
            (LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldTable, AvrDataTable newDataSource)
        {
            List<AvrDataColumn> dataColumns = newDataSource.Columns.ToList();
            List<LayoutDetailDataSet.LayoutSearchFieldRow> rows =
                layoutSearchFieldTable.Rows.Cast<LayoutDetailDataSet.LayoutSearchFieldRow>().ToList();
            foreach (AvrDataColumn column in dataColumns)
            {
                string originalName = column.ColumnName;
                List<LayoutDetailDataSet.LayoutSearchFieldRow> foundRows = rows.FindAll(row => (row.strSearchFieldAlias == originalName));

                int rowCounter = 0;
                foreach (LayoutDetailDataSet.LayoutSearchFieldRow row in foundRows)
                {
                    CheckLayoutSearchFieldRowTranslations(row);
                    if (column.ExtendedProperties.ContainsKey(QueryHelper.CopySuffix))
                    {
                        row.strSearchFieldAlias = AvrPivotGridFieldHelper.GetOriginalNameFromCopyForFilterName(originalName);
                    }
                    string caption = row.IsstrNewFieldCaptionNull() || Utils.IsEmpty(row.strNewFieldCaption)
                        ? row.strOriginalFieldCaption
                        : row.strNewFieldCaption;
                    if (rowCounter == 0)
                    {
                        // change name so it shall contain idfLayoutSearchField
                        column.ColumnName = AvrPivotGridFieldHelper.CreateFieldName(row.strSearchFieldAlias, row.idfLayoutSearchField);
                        column.Caption = caption;
                    }
                    else
                    {
                        // create copy of column with new idfLayoutSearchField
                        // name of new column shall contain new id
                        string copyColumnName = AvrPivotGridFieldHelper.CreateFieldName(row.strSearchFieldAlias, row.idfLayoutSearchField);
                        var copyColumn = newDataSource.AddCopyColumn(column.ColumnName, copyColumnName);
                        copyColumn.Caption = caption;
                    }
                    rowCounter++;
                }
            }
        }

        private static void CheckLayoutSearchFieldRowTranslations(LayoutDetailDataSet.LayoutSearchFieldRow row)
        {
            string msg = EidssMessages.Get("msgEmptyRow", "One of rows has empty translation {0}");
            if (row.IsstrOriginalFieldENCaptionNull() || row.IsstrOriginalFieldCaptionNull())
            {
                throw new AvrDbException(String.Format(msg, row.strSearchFieldAlias));
            }
        }

        #endregion

        #region Administrative Unit & Statistic date field processing

        public static DataView GetStatisticDateView(IEnumerable<IAvrPivotGridField> avrFields)
        {
            DataTable dataTable = CreateListDataTable("DateFieldList");
            dataTable.BeginLoadData();
            IEnumerable<IAvrPivotGridField> dateFields
                = avrFields.Where(f => f.Visible &&
                                       (f.Area == PivotArea.ColumnArea || f.Area == PivotArea.RowArea) &&
                                       f.IsDateTimeField);

            foreach (IAvrPivotGridField field in dateFields)
            {
                DataRow dr = dataTable.NewRow();
                dr[IdColumnName] = AvrPivotGridFieldHelper.GetIdFromFieldName(field.FieldName);
                dr[AliasColumnName] = field.FieldName;
                dr[CaptionColumnName] = field.Caption;
                dr[OrderColumnName] = field.AreaIndex - 1000 * (int) field.Area;
                dataTable.Rows.Add(dr);
            }
            dataTable.EndLoadData();
            dataTable.AcceptChanges();
            return new DataView(dataTable, "", OrderColumnName, DataViewRowState.CurrentRows);
        }

        public static DataView GetAdministrativeUnitView(long queryId, List<IAvrPivotGridField> allFields)
        {
            DataView dvMapFieldList = GetMapFiledView(queryId);

            DataTable dataTable = CreateListDataTable("AdmUnitList");

            dataTable.BeginLoadData();

            foreach (DataRowView r in dvMapFieldList)
            {
                IEnumerable<IAvrPivotGridField> rowFields = GetFieldsInRow(allFields, Utils.Str(r["FieldAlias"]));
                foreach (IAvrPivotGridField field in rowFields)
                {
                    DataRow dr = dataTable.NewRow();
                    dr[IdColumnName] = AvrPivotGridFieldHelper.GetIdFromFieldName(field.FieldName);
                    dr[AliasColumnName] = field.FieldName;
                    dr[CaptionColumnName] = field.Caption;
                    dr[OrderColumnName] = r["intIncidenceDisplayOrder"];
                    dataTable.Rows.Add(dr);
                }
            }

            DataRow countryRow = dataTable.NewRow();
            countryRow[IdColumnName] = -1;
            countryRow[AliasColumnName] = AvrPivotGridFieldHelper.VirtualCountryFieldName;
            countryRow[CaptionColumnName] = EidssMessages.Get("strCountry", "Country");
            countryRow[OrderColumnName] = 100;
            dataTable.Rows.Add(countryRow);

            dataTable.EndLoadData();
            dataTable.AcceptChanges();
            return new DataView(dataTable, "", String.Format("{0}, {1}, {2}", OrderColumnName, CaptionColumnName, AliasColumnName),
                DataViewRowState.CurrentRows);
        }

        public static DataView GetMapFiledView(long queryId, bool isMap = false)
        {
            string key = LookupTables.QuerySearchField.ToString();
            DataTable dtMapFieldList = LookupCache.Fill(LookupCache.LookupTables[key]);

            string field = isMap ? "intMapDisplayOrder" : "intIncidenceDisplayOrder";
            string filter = String.Format("idflQuery = {0} and {1} is not null", queryId, field);
            string sort = String.Format("{0}, FieldCaption", field);
            var dvMapFieldList = new DataView(dtMapFieldList, filter, sort, DataViewRowState.CurrentRows);
            return dvMapFieldList;
        }

        public static DataTable CreateListDataTable(string tableName)
        {
            var dataTable = new DataTable(tableName);
            dataTable.BeginInit();
            var colId = new DataColumn(IdColumnName, typeof (long));
            dataTable.Columns.Add(colId);
            var colAlias = new DataColumn(AliasColumnName, typeof (string));
            dataTable.Columns.Add(colAlias);
            var colCaption = new DataColumn(CaptionColumnName, typeof (string));
            dataTable.Columns.Add(colCaption);
            var colOrder = new DataColumn(OrderColumnName, typeof (int));
            dataTable.Columns.Add(colOrder);
            dataTable.PrimaryKey = new[] {colAlias};
            dataTable.EndInit();

            return dataTable;
        }

        public static IEnumerable<IAvrPivotGridField> GetFieldsInRow(List<IAvrPivotGridField> fields, string originalFieldName)
        {
            Utils.CheckNotNullOrEmpty(originalFieldName, "originalFieldName");

            List<IAvrPivotGridField> found = fields.FindAll(field => (field.Visible) &&
                                                                     (field.AreaIndex >= 0) &&
                                                                     (field.Area == PivotArea.RowArea) &&
                                                                     (field.OriginalFieldName == originalFieldName));

            return found;
        }

        #endregion

        #region Add Search Field Row

        public static LayoutDetailDataSet.LayoutSearchFieldRow AddNewLayoutSearchFieldRow
            (LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldTable,
                long queryId,
                long layoutId,
                string originalFieldName,
                long aggregateFunctionId)
        {
            return AddNewLayoutSearchFieldRow(layoutSearchFieldTable, queryId, layoutId,
                originalFieldName, aggregateFunctionId, BaseDbService.NewIntID());
        }

        public static LayoutDetailDataSet.LayoutSearchFieldRow AddNewLayoutSearchFieldRow
            (LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldTable, long queryId, long layoutId, string originalFieldName,
                long aggregateFunctionId, long idfLayoutSearchField)
        {
            LayoutDetailDataSet.LayoutSearchFieldRow newRow = searchFieldTable.NewLayoutSearchFieldRow();

            newRow.idflLayout = layoutId;
            newRow.strSearchFieldAlias = originalFieldName;
            newRow.idfsAggregateFunction = aggregateFunctionId;
            newRow.idfsBasicCountFunction = (long) CustomSummaryType.DistinctCount;
            newRow.idfLayoutSearchField = idfLayoutSearchField;

            newRow.SetidfsGroupDateNull();

            newRow.blnShowMissedValue = false;
            newRow.SetdatDiapasonStartDateNull();
            newRow.SetdatDiapasonEndDateNull();

            FillMissedReferenceAttribues(newRow, originalFieldName);

            newRow.SetintPrecisionNull();

            newRow.intFieldColumnWidth = AvrView.DefaultFieldWidth;

            newRow.intFieldCollectionIndex = 0;
            newRow.intPivotGridAreaType = 0;
            newRow.intFieldPivotGridAreaIndex = -1;
            newRow.blnVisible = false;
            newRow.blnHiddenFilterField = false;
            newRow.intFieldColumnWidth = AvrView.DefaultFieldWidth;
            newRow.blnSortAcsending = true;

            KeyValuePair<string, string> translations = QueryProcessor.GetTranslations(queryId, originalFieldName);
            newRow.strOriginalFieldENCaption = translations.Key;
            newRow.strOriginalFieldCaption = translations.Value;

            searchFieldTable.AddLayoutSearchFieldRow(newRow);
            return newRow;
        }

        private static void FillMissedReferenceAttribues(LayoutDetailDataSet.LayoutSearchFieldRow newRow, string name)
        {
            newRow.blnAllowMissedReferenceValues = false;
            newRow.strLookupTable = String.Empty;
            newRow.strLookupAttribute = String.Empty;

            DataView searchFields = GetSearchFieldRowByName(name);
            if (searchFields.Count > 0)
            {
                DataRowView row = searchFields[0];
                object flag = row["blnAllowMissedReferenceValues"];
                if (flag is bool)
                {
                    newRow.blnAllowMissedReferenceValues = (bool) flag;
                }
                newRow.strLookupTable = Utils.Str(row["strLookupTable"]);
                if (row["idfsReferenceType"] is long)
                {
                    newRow.idfsReferenceType = (long) row["idfsReferenceType"];
                }
                if (row["idfsGISReferenceType"] is long)
                {
                    newRow.idfsGISReferenceType = (long) row["idfsGISReferenceType"];
                }
                newRow.strLookupAttribute = Utils.Str(row["strLookupAttribute"]);
                if (row["intHACode"] is int)
                {
                    newRow.intHACode = (int) row["intHACode"];
                }
            }
        }

        private static DataView GetSearchFieldRowByName(string name)
        {
            Utils.CheckNotNullOrEmpty(name, "name");

            string originalName = AvrPivotGridFieldHelper.GetOriginalNameFromCopyForFilterName(name);

            DataTable searchFieldsTable = QueryLookupHelper.GetSearchFieldLookupTable();
            DataView searchFields = searchFieldsTable.DefaultView;
            searchFields.RowFilter = String.Format("strSearchFieldAlias = '{0}'", originalName);
            return searchFields;
        }

        #endregion

        #region   Add Missed Values

        public static LayoutValidateResult AddMissedValuesAndValidateComplexity
            (AvrPivotGridData dataSource, IList<IAvrPivotGridField> allFields, LayoutBaseValidator validator)
        {
            if (dataSource == null)
            {
                return new LayoutValidateResult();
            }

            List<IAvrPivotGridField> visibleFields = GetFieldCollectionFromArea(allFields, PivotArea.RowArea);
            visibleFields.AddRange(GetFieldCollectionFromArea(allFields, PivotArea.ColumnArea));

            List<IAvrPivotGridField> cortegeFields = AddRelatedFields(visibleFields);

            Dictionary<IAvrPivotGridField, List<IAvrPivotGridField>> fieldsAndFieldCopy
                = GetFieldCopyDictionary(allFields, cortegeFields);

            var cortege = new AvrFieldValueCollection(fieldsAndFieldCopy);

            if (cortege.AddMissedValues)
            {
                Dictionary<IAvrPivotGridField, AvrDataColumn> columns = GetColumnDictionary(dataSource, allFields);
                List<int> allRowIndexes;
                List<AvrDataRowBase> allDataRows = GetRowsDictionary(dataSource, out allRowIndexes);

                int dataFieldCount = GetFieldCollectionFromArea(allFields, PivotArea.DataArea).Count;

                return AddMissedValuesForFields(dataSource, cortege, columns, allDataRows, allRowIndexes, validator, dataFieldCount);
            }
            return new LayoutValidateResult();
        }

        public static IEnumerable<AvrFieldValueCollection> GetMissingValuesForFields
            (AvrPivotGridData dataSource, AvrFieldValueCollection fieldValuesCortege,
                Dictionary<IAvrPivotGridField, AvrDataColumn> columns, IList<AvrDataRowBase> rows, IList<int> rowIndexes, int fieldIndex)
        {
            if (fieldIndex < fieldValuesCortege.Count)
            {
                AvrFieldValuePair fieldValuePair = fieldValuesCortege[fieldIndex];
                IAvrPivotGridField field = fieldValuePair.Field;

                IDictionary<object, AvrMissedValue> valuesDictionary = GetExistingValuesDictionary(fieldValuePair, columns, rows, rowIndexes);

                bool isNonCountryFieldRelated =
                    (field.GisReferenceTypeId != (long) GisReferenceType.Country && fieldValuePair.IsRelated);
                if (field.AddMissedValues || isNonCountryFieldRelated /* || field.IsHiddenFilterField && field.IsDateTimeField*/)
                {
                    IList<AvrMissedValue> missedValues;
                    try
                    {
                        missedValues = field.IsDateTimeField
                            ? AddMissedDates(fieldValuePair)
                            : field.AddMissedReferencies(fieldValuesCortege);
                    }
                    catch (Exception ex)
                    {
                        throw new AvrException(field.GetMissedValuesErrorMessage(), ex);
                    }

                    foreach (AvrMissedValue missedValue in missedValues)
                    {
                        if (valuesDictionary.ContainsKey(missedValue.FieldValue))
                        {
                            if (missedValue.LinkedFieldValues.Count > 0 &&
                                valuesDictionary[missedValue.FieldValue].LinkedFieldValues.Count == 0)
                            {
                                valuesDictionary[missedValue.FieldValue].LinkedFieldValues = missedValue.LinkedFieldValues;
                            }
                        }
                        else
                        {
                            if (!missedValue.IsHistorical)
                            {
                                valuesDictionary.Add(missedValue.FieldValue, missedValue);
                            }
                        }
                    }
                }
                if (valuesDictionary.Count == 0)
                {
                    for (int i = fieldIndex; i < fieldValuesCortege.Count; i++)
                    {
                        fieldValuesCortege[i].Value = null;
                    }
                    foreach (AvrFieldValueCollection val in
                        GetMissingValuesForFields(dataSource, fieldValuesCortege, columns, new List<AvrDataRowBase>(), new List<int>(),
                            fieldValuesCortege.Count))
                    {
                        yield return val;
                    }
                }

                foreach (AvrMissedValue missedValue in valuesDictionary.Values)
                {
                    fieldValuePair.Value = missedValue.FieldValue;
                    fieldValuePair.LinkedFieldValues.Clear();
                    foreach (KeyValuePair<string, object> pair in missedValue.LinkedFieldValues)
                    {
                        if (field.FieldNamesDictionary.ContainsKey(pair.Key))
                        {
                            foreach (IAvrPivotGridField linkedField in field.FieldNamesDictionary[pair.Key])
                            {
                                fieldValuePair.LinkedFieldValues.Add(linkedField, pair.Value);
                            }
                        }
                    }

                    foreach (AvrFieldValueCollection val in
                        GetMissingValuesForFields(dataSource, fieldValuesCortege, columns, missedValue.FilteredRows,
                            missedValue.FilteredIndexes, fieldIndex + 1))
                    {
                        yield return val;
                    }
                }
            }
            else
            {
                yield return fieldValuesCortege;
            }
        }

        private static LayoutValidateResult AddMissedValuesForFields
            (AvrPivotGridData dataSource, AvrFieldValueCollection fieldValuesCortege,
                Dictionary<IAvrPivotGridField, AvrDataColumn> columns, IList<AvrDataRowBase> rows, IList<int> rowIndexes,
                LayoutBaseValidator validator, int dataFieldCount)
        {
            dataFieldCount = Math.Max(1, dataFieldCount);
            int step = BaseSettings.AvrWarningCellCountLimit / (10 * dataFieldCount);
            int counter = 0;

            var complexity = new LayoutMissedValuesComplexity();

            foreach (AvrFieldValueCollection collection in
                GetMissingValuesForFields(dataSource, fieldValuesCortege, columns, rows, rowIndexes, 0))
            {
                counter++;
                complexity.SetCelllCount(counter * dataFieldCount);
                if (counter % step == 0)
                {
                    LayoutValidateResult result = validator.Validate(complexity);
                    if (!result.IsOk())
                    {
                        if (!result.IsUserDialogOk())
                        {
                            return result;
                        }
                        validator.IgnoreValidationWarnings = true;
                    }
                }

                AvrDataRow row = dataSource.NewRow();
                foreach (AvrFieldValuePair pair in collection)
                {
                    row.SetValue(pair.Field.Ordinal, pair.Value ?? AvrDataRowBase.DbNullValue);
                    foreach (KeyValuePair<IAvrPivotGridField, object> linkedPair in pair.LinkedFieldValues)
                    {
                        row.SetValue(linkedPair.Key.Ordinal, linkedPair.Value ?? AvrDataRowBase.DbNullValue);
                    }
                }
                dataSource.ThreadSafeAddRow(row);
            }
            return validator.Validate(complexity);
        }

        private static IDictionary<object, AvrMissedValue> GetExistingValuesDictionary
            (AvrFieldValuePair fieldValuePair,
                IDictionary<IAvrPivotGridField, AvrDataColumn> columns, IList<AvrDataRowBase> rows, IList<int> rowIndexes)
        {
            PivotGroupInterval minInterval = GetMinPivotGroupInterval(fieldValuePair);
            bool isDateTimeField = fieldValuePair.Field.IsDateTimeField;
            var valuesDictionary = new Dictionary<object, AvrMissedValue>();
            AvrDataColumn column = columns[fieldValuePair.Field];
            for (int i = 0; i < rows.Count; i++)
            {
                AvrDataRowBase row = rows[i];

                object fieldValue = row[column.Ordinal];

                if (isDateTimeField && fieldValue is DateTime)
                {
                    fieldValue = TruncateDateValue(minInterval, (DateTime) fieldValue);
                }
                AvrMissedValue foundMissedValue;

                if (!valuesDictionary.TryGetValue(fieldValue, out foundMissedValue))
                {
                    foundMissedValue = new AvrMissedValue(fieldValue);
                    valuesDictionary.Add(fieldValue, foundMissedValue);
                }
                foundMissedValue.FilteredRows.Add(row);
                foundMissedValue.FilteredIndexes.Add(rowIndexes[i]);
            }
            return valuesDictionary;
        }

        public static List<IAvrPivotGridField> AddRelatedFields(IList<IAvrPivotGridField> visibleFields)
        {
            List<IAvrPivotGridField> fields = visibleFields.ToList();

            //for fields with missing value remove all their copies without missing values
            var removeFields = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in fields.Where(f => f.AddMissedValues))
                //foreach (IAvrPivotGridField field in fields.Where(f => f.AddMissedValues && !f.IsDateTimeField))
            {
                IAvrPivotGridField originalField = field;
                removeFields.AddRange(
                    fields.Where(f => !f.AddMissedValues && f != originalField && f.OriginalFieldName == originalField.OriginalFieldName));
            }
            foreach (IAvrPivotGridField field in removeFields)
            {
                fields.Remove(field);
            }
            //remove all linked fields 
            removeFields = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in fields)
            {
                removeFields.AddRange(field.LinkedFields);
            }
            foreach (IAvrPivotGridField field in removeFields)
            {
                fields.Remove(field);
            }

            //for fields remove all their copies except first one
            fields = GetDistinctFields(fields);

            // remove all field copies that can be found in related chains
            removeFields = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in fields)
            {
                removeFields.AddRange(field.GetRelatedFieldChain().Where(fields.Contains));
            }
            foreach (IAvrPivotGridField field in removeFields)
            {
                fields.Remove(field);
            }

            var cortegeFields = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in fields)
            {
                cortegeFields.AddRange(field.GetRelatedFieldChain());
                cortegeFields.Add(field);
            }

            return cortegeFields;
        }

        private static List<IAvrPivotGridField> GetDistinctFields(IEnumerable<IAvrPivotGridField> fields)
        {
            var distinctFields = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in fields)
            {
                IAvrPivotGridField originalField = field;
                if (distinctFields.All(f => f.OriginalFieldName != originalField.OriginalFieldName))
                {
                    distinctFields.Add(originalField);
                }
            }
            return distinctFields;
        }

        private static Dictionary<IAvrPivotGridField, List<IAvrPivotGridField>> GetFieldCopyDictionary
            (IList<IAvrPivotGridField> allFields, IEnumerable<IAvrPivotGridField> cortegeFields)
        {
            var fieldsAndFieldCopy = new Dictionary<IAvrPivotGridField, List<IAvrPivotGridField>>();
            foreach (IAvrPivotGridField field in cortegeFields)
            {
                IAvrPivotGridField originalField = field;
                List<IAvrPivotGridField> fieldCopy =
                    allFields.Where(
                        f => f.OriginalFieldName == originalField.OriginalFieldName && f != originalField).ToList();
                fieldsAndFieldCopy.Add(field, fieldCopy);
            }
            return fieldsAndFieldCopy;
        }

        private static IList<AvrMissedValue> AddMissedDates(AvrFieldValuePair pair)
        {
            List<AvrMissedValue> values = pair.Field.AddMissedDates();
            var fieldGroupping = new Dictionary<PivotGroupInterval, IAvrPivotGridField>();
            foreach (IAvrPivotGridField copy in pair.FieldCopy)
            {
                if (!fieldGroupping.ContainsKey(copy.GroupInterval))
                {
                    fieldGroupping.Add(copy.GroupInterval, copy);
                }
            }
            foreach (IAvrPivotGridField copy in fieldGroupping.Values)
            {
                values.AddRange(copy.AddMissedDates());
            }
            values = values.Distinct(AvrMissedValue.FieldValueComparer).ToList();

            return values;
        }

        public static DateTime TruncateDateValue(PivotGroupInterval minInterval, DateTime value)
        {
            //todo: [ivan] modify to support other date interval (it needs for proper layout complexity calculations)
            DateTime result = minInterval == PivotGroupInterval.DateYear ||
                              minInterval == PivotGroupInterval.DateQuarter ||
                              minInterval == PivotGroupInterval.DateMonth
                ? value.TruncateToFirstDateInInterval(minInterval)
                : value.Date;

            return result;
        }

        private static PivotGroupInterval GetMinPivotGroupInterval(AvrFieldValuePair pair)
        {
            PivotGroupInterval minInterval = pair.Field.GroupInterval;
            foreach (IAvrPivotGridField copy in pair.FieldCopy)
            {
                if (!copy.IsHiddenFilterField && minInterval > copy.GroupInterval)
                {
                    minInterval = copy.GroupInterval;
                }
            }
            return minInterval;
        }

        #endregion

        #region   Fill Empty Values

        public static LayoutValidateResult FillEmptyValuesAndValidateComplexity
            (AvrPivotGridData dataSource, IList<IAvrPivotGridField> allFields, LayoutBaseValidator validator)
        {
            if (dataSource == null)
            {
                return new LayoutValidateResult();
            }

            List<int> allRowIndexes;
            List<AvrDataRowBase> allDataRows = GetRowsDictionary(dataSource, out allRowIndexes);
            if (allDataRows.Count == 0)
            {
                return new LayoutValidateResult();
            }

            AvrFieldValueCollection rowCortege = GetCortegeFromArea(allFields, PivotArea.RowArea);
            AvrFieldValueCollection colCortege = GetCortegeFromArea(allFields, PivotArea.ColumnArea);

            int dataCount = GetFieldCollectionFromArea(allFields, PivotArea.DataArea).Count;
            var complexity = new LayoutEmptyValuesComplexity(dataSource.RowsCount, rowCortege.Count, colCortege.Count, dataCount);

            Dictionary<IAvrPivotGridField, AvrDataColumn> columns = GetColumnDictionary(dataSource, allFields);

            if (rowCortege.Count == 0)
            {
                complexity.ColCount = GetExistingValuesForFields(dataSource, columns, colCortege, allDataRows, allRowIndexes, 0).Count();
                complexity.RowCount = 1;
                return validator.Validate(complexity);
            }
            if (colCortege.Count == 0)
            {
                complexity.ColCount = 1;
                complexity.RowCount = GetExistingValuesForFields(dataSource, columns, rowCortege, allDataRows, allRowIndexes, 0).Count();
                return validator.Validate(complexity);
            }

            var colFieldValuesList = new List<AvrFieldValueCollectionWithRowsWrapper>();
            foreach (AvrFieldValueCollectionWithRowsWrapper colValues in 
                GetExistingValuesForFields(dataSource, columns, colCortege, allDataRows, allRowIndexes, 0))
            {
                var newCollection = new AvrFieldValueCollection(colValues.Collection, true);
                var newCollectionWrapper =
                    new AvrFieldValueCollectionWithRowsWrapper(newCollection, colValues.RowList, colValues.RowIndexesList);
                colFieldValuesList.Add(newCollectionWrapper);
            }
            complexity.ColCount = colFieldValuesList.Count;
            int step = Math.Max(1, BaseSettings.AvrWarningCellCountLimit / (10 * Math.Max(1, complexity.ColCount)));

            AvrColumnRowIntersectionFinder intersectionFinder = new AvrColumnRowIntersectionFinder(dataSource);

            foreach (AvrFieldValueCollectionWithRowsWrapper rowValues in
                GetExistingValuesForFields(dataSource, columns, rowCortege, allDataRows, allRowIndexes, 0))
            {
                complexity.RowCount++;
                if (complexity.RowCount % step == 0)
                {
                    LayoutValidateResult result = validator.Validate(complexity);
                    if (!result.IsOk())
                    {
                        if (!result.IsUserDialogOk())
                        {
                            intersectionFinder.KillAll();
                            return result;
                        }
                        validator.IgnoreValidationWarnings = true;
                    }
                }

                var rowValuesCollection = new AvrFieldValueCollection(rowValues.Collection, true);
                var rowValuesCopy =
                    new AvrFieldValueCollectionWithRowsWrapper(rowValuesCollection, rowValues.RowList, rowValues.RowIndexesList);

                intersectionFinder.Enqueue(new AvrColumnRowIntersectionPair(colFieldValuesList, rowValuesCopy));
            }
            intersectionFinder.WaitAll();
            return validator.Validate(complexity);
        }

        private static AvrFieldValueCollection GetCortegeFromArea(IList<IAvrPivotGridField> allFields, PivotArea area)
        {
            List<IAvrPivotGridField> fieldsFromArea = GetFieldCollectionFromArea(allFields, area);
            fieldsFromArea = GetDistinctFields(fieldsFromArea);
            Dictionary<IAvrPivotGridField, List<IAvrPivotGridField>> fieldsDict = GetFieldCopyDictionary(allFields, fieldsFromArea);
            var cortege = new AvrFieldValueCollection(fieldsDict);
            return cortege;
        }

        public static IEnumerable<AvrFieldValueCollectionWithRowsWrapper> GetExistingValuesForFields
            (AvrPivotGridData dataSource, Dictionary<IAvrPivotGridField, AvrDataColumn> columns,
                AvrFieldValueCollection fieldValuesCortege, IList<AvrDataRowBase> rows, IList<int> rowIndexes, int fieldIndex)
        {
            if (fieldIndex < fieldValuesCortege.Count)
            {
                AvrFieldValuePair fieldValuePair = fieldValuesCortege[fieldIndex];

                IDictionary<object, AvrMissedValue> valuesDictionary = GetExistingValuesDictionary(fieldValuePair, columns, rows, rowIndexes);

                if (valuesDictionary.Count == 0)
                {
                    for (int i = fieldIndex; i < fieldValuesCortege.Count; i++)
                    {
                        fieldValuesCortege[i].Value = null;
                    }
                    IEnumerable<AvrFieldValueCollectionWithRowsWrapper> recoursiveValues =
                        GetExistingValuesForFields(dataSource, columns, fieldValuesCortege, new List<AvrDataRowBase>(), new List<int>(),
                            fieldValuesCortege.Count);
                    foreach (AvrFieldValueCollectionWithRowsWrapper recoursiveValue in recoursiveValues)
                    {
                        yield return recoursiveValue;
                    }
                }

                foreach (AvrMissedValue existingValue in valuesDictionary.Values)
                {
                    fieldValuePair.Value = existingValue.FieldValue;
                    IEnumerable<AvrFieldValueCollectionWithRowsWrapper> recoursiveValues =
                        GetExistingValuesForFields(dataSource, columns, fieldValuesCortege,
                            existingValue.FilteredRows, existingValue.FilteredIndexes, fieldIndex + 1);
                    foreach (AvrFieldValueCollectionWithRowsWrapper recoursiveValue in recoursiveValues)
                    {
                        yield return recoursiveValue;
                    }
                }
            }
            else
            {
                yield return new AvrFieldValueCollectionWithRowsWrapper(fieldValuesCortege, rows, rowIndexes);
            }
        }

        private static Dictionary<IAvrPivotGridField, AvrDataColumn> GetColumnDictionary
            (AvrPivotGridData dataSource, IEnumerable<IAvrPivotGridField> allFields)
        {
            var columnDictionary = new Dictionary<IAvrPivotGridField, AvrDataColumn>();

            foreach (IAvrPivotGridField field in allFields)
            {
                AvrDataColumn column = dataSource.Columns.First(c => c.ColumnName == field.FieldName);
                columnDictionary.Add(field, column);
            }
            return columnDictionary;
        }

        public static List<AvrDataRowBase> GetRowsDictionary(AvrPivotGridData dataSource, out List<int> rowIndexes)
        {
            List<AvrDataRowBase> allDataRows = dataSource.Rows.ToList();

            rowIndexes = new List<int>(allDataRows.Count);
            for (int i = 0; i < allDataRows.Count; i++)
            {
                rowIndexes.Add(i);
            }
            return allDataRows;
        }

        /// <summary>
        ///     Remove Function Operators from Clause.
        /// </summary>
        /// <param name="criteria"> </param>
        public static void RemoveFunctionOperators(GroupOperator criteria)
        {
            var toRemove = new List<CriteriaOperator>();
            foreach (CriteriaOperator operand in criteria.Operands)
            {
                if (operand is FunctionOperator)
                {
                    toRemove.Add(operand);
                }
                else
                {
                    var groupOperator = operand as GroupOperator;
                    if (!ReferenceEquals(groupOperator, null))
                    {
                        RemoveFunctionOperators(groupOperator);
                    }
                }
            }
            foreach (CriteriaOperator operand in toRemove)
            {
                criteria.Operands.Remove(operand);
            }
        }

        #endregion

        #region Create/delete Field Copy

        public static T CreateFieldCopy<T>
            (IAvrPivotGridField sourceField, LayoutDetailDataSet layoutDataset, AvrPivotGridData pivotData, long queryId, long layoutId)
            where T : IAvrPivotGridField, new()
        {
            Utils.CheckNotNull(sourceField, "sourceField");

            LayoutDetailDataSet.LayoutSearchFieldRow destRow = CreateLayoutSearchFieldInformationCopy(sourceField,
                layoutDataset,
                queryId, layoutId);

            string copyColumnName = AvrPivotGridFieldHelper.CreateFieldName(sourceField.OriginalFieldName, destRow.idfLayoutSearchField);
            pivotData.RealPivotData.AddCopyColumn(sourceField.FieldName, copyColumnName);
            pivotData.ClonedPivotData.AddCopyColumn(sourceField.FieldName, copyColumnName);

            var copy = new T();

            sourceField.CreatePivotGridFieldCopy(copy, copyColumnName);

            var allFields = new List<IAvrPivotGridField>();
            allFields.AddRange(sourceField.AllPivotFields);
            allFields.Add(copy);
            foreach (IAvrPivotGridField field in allFields)
            {
                field.AllPivotFields.Add(copy);
            }

            return copy;
        }

        private static LayoutDetailDataSet.LayoutSearchFieldRow CreateLayoutSearchFieldInformationCopy
            (IAvrPivotGridField sourceField, LayoutDetailDataSet layoutDataset, long queryId, long layoutId)
        {
            LayoutDetailDataSet.LayoutSearchFieldRow sourceRow = GetLayoutSearchFieldRowByField(sourceField, layoutDataset);

            LayoutDetailDataSet.LayoutSearchFieldRow destRow =
                AddNewLayoutSearchFieldRow(layoutDataset.LayoutSearchField, queryId,
                    layoutId,
                    sourceRow.strSearchFieldAlias, (long) sourceField.GetDefaultSummaryType());

            destRow.strNewFieldCaption = sourceRow.strNewFieldCaption;
            destRow.strNewFieldENCaption = sourceRow.strNewFieldENCaption;
            if (!sourceRow.IsidfUnitLayoutSearchFieldNull() && !sourceRow.IsstrUnitSearchFieldAliasNull())
            {
                destRow.strUnitSearchFieldAlias = sourceRow.strUnitSearchFieldAlias;
                destRow.idfUnitLayoutSearchField = sourceRow.idfUnitLayoutSearchField;
            }
            if (!sourceRow.IsidfDateLayoutSearchFieldNull() && !sourceRow.IsstrDateSearchFieldAliasNull())
            {
                destRow.strDateSearchFieldAlias = sourceRow.strDateSearchFieldAlias;
                destRow.idfDateLayoutSearchField = sourceRow.idfDateLayoutSearchField;
            }

            destRow.strLookupAttribute = sourceRow.strLookupAttribute;
            destRow.strLookupTable = sourceRow.strLookupTable;
            destRow.intHACode = sourceRow.intHACode;

            if (!sourceRow.IsidfsReferenceTypeNull())
            {
                destRow.idfsReferenceType = sourceRow.idfsReferenceType;
            }
            if (!sourceRow.IsidfsGISReferenceTypeNull())
            {
                destRow.idfsGISReferenceType = sourceRow.idfsGISReferenceType;
            }
            if (sourceRow.IsblnAllowMissedReferenceValuesNull())
            {
                destRow.blnAllowMissedReferenceValues = sourceRow.blnAllowMissedReferenceValues;
            }

            return destRow;
        }

        public static LayoutDetailDataSet.LayoutSearchFieldRow GetLayoutSearchFieldRowByField
            (IAvrPivotGridField sourceField, LayoutDetailDataSet layoutDataset)
        {
            Utils.CheckNotNull(sourceField, "sourceField");
            if (sourceField.FieldId < 0)
            {
                throw new AvrException(String.Format("Field {0} doesn't has Id", sourceField.FieldName));
            }
            LayoutDetailDataSet.LayoutSearchFieldRow sourceRow =
                layoutDataset.LayoutSearchField.FindByidfLayoutSearchField(sourceField.FieldId);
            if (sourceRow == null)
            {
                throw new AvrException(String.Format("LayoutSearchField information not found for field {0} with ID {1}",
                    sourceField.FieldName, sourceField.FieldId));
            }
            return sourceRow;
        }

        public static void DeleteFieldCopy(IAvrPivotGridField sourceField, LayoutDetailDataSet layoutDataset, AvrPivotGridData pivotData)
        {
            AvrDataColumn sourceColumn = pivotData.RealPivotData.Columns[sourceField.FieldName];
            pivotData.RealPivotData.Columns.Remove(sourceColumn);
            AvrDataColumn sourceClonedColumn = pivotData.ClonedPivotData.Columns[sourceField.FieldName];
            pivotData.ClonedPivotData.Columns.Remove(sourceClonedColumn);

            // clear Unit, Denoninator, Date and other fields here
            string originalName = sourceField.OriginalFieldName;
            List<LayoutDetailDataSet.LayoutSearchFieldRow> rows =
                layoutDataset.LayoutSearchField.Rows.Cast<LayoutDetailDataSet.LayoutSearchFieldRow>().ToList();

            List<LayoutDetailDataSet.LayoutSearchFieldRow> unitRows =
                rows.FindAll(uRow => (!uRow.IsstrUnitSearchFieldAliasNull() && uRow.strUnitSearchFieldAlias == originalName));
            foreach (LayoutDetailDataSet.LayoutSearchFieldRow uRow in unitRows)
            {
                uRow.SetstrUnitSearchFieldAliasNull();
                uRow.SetidfUnitLayoutSearchFieldNull();
            }
            List<LayoutDetailDataSet.LayoutSearchFieldRow> dateRows =
                rows.FindAll(dateRow => (!dateRow.IsstrDateSearchFieldAliasNull() && dateRow.strDateSearchFieldAlias == originalName));

            foreach (LayoutDetailDataSet.LayoutSearchFieldRow dateRow in dateRows)
            {
                dateRow.SetstrDateSearchFieldAliasNull();
                dateRow.SetidfDateLayoutSearchFieldNull();
            }

            // remove corresponding aggregate row
            LayoutDetailDataSet.LayoutSearchFieldRow row =
                layoutDataset.LayoutSearchField.FindByidfLayoutSearchField(sourceField.FieldId);
            layoutDataset.LayoutSearchField.RemoveLayoutSearchFieldRow(row);

            //remove field in fieldlist for each field
            var allFields = new List<IAvrPivotGridField>();
            allFields.AddRange(sourceField.AllPivotFields);
            foreach (IAvrPivotGridField field in allFields)
            {
                field.AllPivotFields.Remove(sourceField);
            }
        }

        public static bool EnableDeleteField(IAvrPivotGridField field, IEnumerable<IAvrPivotGridField> avrFields)
        {
            if (field == null)
            {
                return false;
            }
            int count = avrFields.Count(f => f.OriginalFieldName == field.OriginalFieldName);
            return count > 2;
        }

        #endregion
    }
}