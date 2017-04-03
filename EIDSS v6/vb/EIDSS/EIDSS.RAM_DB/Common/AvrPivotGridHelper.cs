using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using DevExpress.Data.Filtering;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraPivotGrid;
using EIDSS;
using eidss.avr.db.DBService.DataSource;
using EIDSS.Enums;
using eidss.model.AVR.Db;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.View;
using eidss.model.Enums;
using eidss.model.Resources;
using ReflectionHelper = eidss.model.Helpers.ReflectionHelper;

namespace eidss.avr.db.Common
{
    public class AvrPivotGridHelper
    {
        private const string IdColumnName = "Id";
        private const string AliasColumnName = "Alias";
        private const string CaptionColumnName = "Caption";
        private const string OrderColumnName = "Order";

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

        public static List<T> CreateFields<T>(DataTable data) where T : IAvrPivotGridField, new()
        {
            var list = new List<T>();
            foreach (DataColumn column in data.Columns)
            {
                bool isCopy = column.ExtendedProperties.ContainsKey(QueryHelper.CopySuffix);

                var field = new T
                {
                    Name = "field" + column.ColumnName,
                    FieldName = column.ColumnName,
                    Caption = column.Caption,
                    IsHiddenFilterField = isCopy,
                    Visible = isCopy,
                };

                field.SearchFieldDataType = GetSearchFieldType(field.GetOriginalName());
                field.UpdateImageIndex();
                if (field.SearchFieldDataType == typeof (DateTime))
                {
                    field.CellFormat.FormatType = FormatType.DateTime;
                }
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
            }
            return result;
        }

        internal static Type GetSearchFieldType(string fieldName)
        {
            if ((m_FieldDataTypes == null) || (!m_FieldDataTypes.ContainsKey(fieldName)))
            {
                DataTable lookupTable = QueryLookupHelper.GetQueryLookupTable();
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
                IAvrPivotGridField field = avrFields.FirstOrDefault(f => f.GetFieldId() == row.idfLayoutSearchField);
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
                IAvrPivotGridField field = avrFields.FirstOrDefault(f => f.GetFieldId() == row.idfLayoutSearchField);
                if (field != null)
                {
                    field.LoadSearchFieldExstraFromRow(row);
                    field.AllPivotFields = avrFields.ToList();

                    PivotSummaryType summaryType = field.CustomSummaryType == CustomSummaryType.Count
                        ? PivotSummaryType.Count
                        : PivotSummaryType.Custom;
                    field.SummaryType = summaryType;
                }
            }
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
            IEnumerable<IGrouping<string, IAvrPivotGridField>> grouppedField = avrFields.GroupBy(f => f.GetOriginalName());
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
            List<string> originalFieldNames = fields.Select(field => field.GetOriginalName()).ToList();
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
                string filter = String.Format("{0}='{1}'", searchFieldTable.strSearchFieldAliasColumn.ColumnName, field.GetOriginalName());
                if (searchFieldTable.Select(filter).Length == 0)
                {
                    length++;
                }
            }
            List<long> ids = BaseDbService.NewListIntID(length);
            int count = 0;
            foreach (IAvrPivotGridField field in fields)
            {
                string filter = String.Format("{0}='{1}'", searchFieldTable.strSearchFieldAliasColumn.ColumnName, field.GetOriginalName());
                if (searchFieldTable.Select(filter).Length == 0)
                {
                    AddNewLayoutSearchFieldRow(searchFieldTable, idflQuery, idflLayout,
                        field.GetOriginalName(), (long) field.CustomSummaryType, ids[count]);
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
            return GetCulumnField(fields, @"sflHC_PatientSex");
        }

        public static IAvrPivotGridField GetAgeGroupField(IEnumerable<IAvrPivotGridField> fields)
        {
            return GetCulumnField(fields, @"sflHCAG_AgeGroup");
        }

        private static IAvrPivotGridField GetCulumnField(IEnumerable<IAvrPivotGridField> fields, string fieldAlias)
        {
            IAvrPivotGridField genderField =
                fields.ToList().SingleOrDefault(
                    field =>
                        field.Visible &&
                        field.Area == PivotArea.ColumnArea &&
                        field.FieldName.Contains(fieldAlias));

            return genderField;
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

        public static DataTable GetPreparedDataSource
            (LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldTable,
                long queryId, long layoutId, DataTable queryResult, bool isNewObject)
        {
            if (queryResult == null)
            {
                return null;
            }

            FillNewLayoutSearchFields(layoutSearchFieldTable, queryId, layoutId, queryResult, isNewObject);

            DeleteColumnsMissingInLayoutSearchFieldTable(layoutSearchFieldTable, queryResult, isNewObject);

            CreateCopiedColumnsAndAjustColumnNames(layoutSearchFieldTable, queryResult);

            queryResult.AcceptChanges();

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
                long queryId, long layoutId, DataTable newDataSource, bool isNewObject)
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
            foreach (DataColumn column in newDataSource.Columns)
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
                DataTable newDataSource, bool isNewObject)
        {
            if (!isNewObject)
            {
                List<LayoutDetailDataSet.LayoutSearchFieldRow> rows =
                    layoutSearchFieldTable.Rows.Cast<LayoutDetailDataSet.LayoutSearchFieldRow>().ToList();
                List<DataColumn> dataColumns = newDataSource.Columns.Cast<DataColumn>().ToList();

                foreach (DataColumn column in dataColumns)
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
            (LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldTable, DataTable newDataSource)
        {
            try
            {
                newDataSource.BeginInit();
                newDataSource.BeginLoadData();
                List<DataColumn> dataColumns = newDataSource.Columns.Cast<DataColumn>().ToList();
                List<LayoutDetailDataSet.LayoutSearchFieldRow> rows =
                    layoutSearchFieldTable.Rows.Cast<LayoutDetailDataSet.LayoutSearchFieldRow>().ToList();
                foreach (DataColumn column in dataColumns)
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
                            CreateDataSourceColumnCopy(newDataSource,
                                column.ColumnName,
                                row.strSearchFieldAlias,
                                caption,
                                row.idfLayoutSearchField);
                        }
                        rowCounter++;
                    }
                }
            }
            finally
            {
                newDataSource.EndLoadData();
                newDataSource.EndInit();
            }
        }

        public static DataColumn CreateDataSourceColumnCopy
            (DataTable dataSource, string fullFieldName, string originalFieldName, string fieldCaption, long idfLayoutSearchField)
        {
            DataColumn sourceColumn = dataSource.Columns[fullFieldName];
            DataColumn destColumn = ReflectionHelper.CreateAndCopyProperties(sourceColumn);

            destColumn.ColumnName = AvrPivotGridFieldHelper.CreateFieldName(originalFieldName, idfLayoutSearchField);
            destColumn.Caption = fieldCaption;

            dataSource.Columns.Add(destColumn);

            int destIndex = dataSource.Columns.IndexOf(destColumn);
            int sourceIndex = dataSource.Columns.IndexOf(sourceColumn);

            //var sw = new Stopwatch();
            //sw.Start();
            foreach (DataRow row in dataSource.Rows)
            {
                row.BeginEdit();
                row[destIndex] = row[sourceIndex];
            }
            //long msAdd = sw.ElapsedMilliseconds;

            return destColumn;
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

            foreach (IAvrPivotGridField field in avrFields)
            {
                if (field.Visible &&
                    field.Area == PivotArea.ColumnArea &&
                    field.SearchFieldDataType == typeof (DateTime))
                {
                    DataRow dr = dataTable.NewRow();
                    dr[IdColumnName] = AvrPivotGridFieldHelper.GetIdFromFieldName(field.FieldName);
                    dr[AliasColumnName] = field.FieldName;
                    dr[CaptionColumnName] = field.Caption;
                    dataTable.Rows.Add(dr);
                }
            }
            dataTable.EndLoadData();
            dataTable.AcceptChanges();
            return new DataView(dataTable, "", string.Format("{0}, {1}", CaptionColumnName, AliasColumnName), DataViewRowState.CurrentRows);
        }

        public static DataView GetAdministrativeUnitView(long queryId, List<IAvrPivotGridField> allFields)
        {
            DataView dvMapFieldList = GetMapFiledView(queryId);

            DataTable dataTable = CreateListDataTable("AdmUnitList");

            var colOrder = new DataColumn(OrderColumnName, typeof (int));
            dataTable.Columns.Add(colOrder);

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
            countryRow[OrderColumnName] = -1;
            dataTable.Rows.Add(countryRow);

            dataTable.EndLoadData();
            dataTable.AcceptChanges();
            return new DataView(dataTable, "", string.Format("{0}, {1}, {2}", OrderColumnName, CaptionColumnName, AliasColumnName),
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
            var colId = new DataColumn(IdColumnName, typeof (long));
            dataTable.Columns.Add(colId);
            var colAlias = new DataColumn(AliasColumnName, typeof (string));
            dataTable.Columns.Add(colAlias);
            var colCaption = new DataColumn(CaptionColumnName, typeof (string));
            dataTable.Columns.Add(colCaption);
            dataTable.PrimaryKey = new[] {colAlias};
            return dataTable;
        }

        public static IEnumerable<IAvrPivotGridField> GetFieldsInRow(List<IAvrPivotGridField> fields, string originalFieldName)
        {
            Utils.CheckNotNullOrEmpty(originalFieldName, "originalFieldName");

            List<IAvrPivotGridField> found = fields.FindAll(field => (field.Visible) &&
                                                                     (field.AreaIndex >= 0) &&
                                                                     (field.Area == PivotArea.RowArea) &&
                                                                     (field.GetOriginalName() == originalFieldName));

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
            newRow.idfLayoutSearchField = idfLayoutSearchField;

            newRow.SetidfsGroupDateNull();

            newRow.blnShowMissedValue = false;
            newRow.SetdatDiapasonStartDateNull();
            newRow.SetdatDiapasonEndDateNull();

            //todo: [ivan] possible performance issue
            FillMissedReferenceAttribues(newRow, originalFieldName);

            newRow.SetintPrecisionNull();

            newRow.intFieldColumnWidth = AvrView.DefaultFieldWidth;

            newRow.intFieldCollectionIndex = 0;
            newRow.intPivotGridAreaType = 0;
            newRow.intFieldPivotGridAreaIndex = 0;
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
            }
        }

        private static DataView GetSearchFieldRowByName(string name)
        {
            Utils.CheckNotNullOrEmpty(name, "name");

            string originalName = AvrPivotGridFieldHelper.GetOriginalNameFromCopyForFilterName(name);
            DataView searchFields = LookupCache.Get(LookupTables.SearchField);
            if (searchFields == null)
            {
                throw new AvrException("Could not load lookup SearchField. Check taht Database contains spAsSearchFieldSelectLookup");
            }
            searchFields.RowFilter = String.Format("strSearchFieldAlias = '{0}'", originalName);
            return searchFields;
        }

        #endregion

        #region   Add Missed Values

        public static void AddMissedValuesInRowColumnArea(AvrPivotGridData dataSource, IList<IAvrPivotGridField> avrFields)
        {
            if (dataSource == null)
            {
                return;
            }
            try
            {
                dataSource.BeginLoadData();
                List<IAvrPivotGridField> baseFields = GetFieldCollectionFromArea(avrFields, PivotArea.RowArea);
                baseFields.AddRange(GetFieldCollectionFromArea(avrFields, PivotArea.ColumnArea));
                List<IAvrPivotGridField> cortegeFields = AddRelatedFields(baseFields);

                var fieldsAndFieldCopy = new Dictionary<IAvrPivotGridField, List<IAvrPivotGridField>>();
                foreach (IAvrPivotGridField field in cortegeFields)
                {
                    IAvrPivotGridField originalField = field;
                    List<IAvrPivotGridField> fieldCopy =
                        avrFields.Where(f => f.GetOriginalName() == originalField.GetOriginalName() && f != originalField).ToList();
                    fieldsAndFieldCopy.Add(field, fieldCopy);
                }

                var cortege = new FieldValueCollection(fieldsAndFieldCopy);

                if (cortege.AddMissedValues)
                {
                    AddMissedValuesForFields(dataSource, cortege, dataSource.Rows, 0);
                }
            }
            finally
            {
                dataSource.EndLoadData();
            }
        }

        public static void AddMissedValuesForFields
            (AvrPivotGridData dataSource, FieldValueCollection fieldValuesCortege, IEnumerable<DataRow> dataRows, int fieldIndex)
        {
            if (fieldIndex < fieldValuesCortege.Count)
            {
                IAvrPivotGridField field = fieldValuesCortege[fieldIndex].Field;

                var valuesDictionary = new Dictionary<object, List<DataRow>>();

                bool isDateTimeField = field.IsDateTimeField;
                foreach (DataRow row in dataRows)
                {
                    object fieldValue = row[field.FieldName];
                    if (isDateTimeField && fieldValue is DateTime)
                    {
                        var currentDate = (DateTime) row[field.FieldName];
                        fieldValue = currentDate.TruncateToFirstDateInInterval(field.GroupInterval);
                    }
                    if (!valuesDictionary.ContainsKey(fieldValue))
                    {
                        valuesDictionary.Add(fieldValue, new List<DataRow>());
                    }
                    valuesDictionary[fieldValue].Add(row);
                }
                bool isNonCountryFieldRelated = (field.GisReferenceTypeId != (long) GisReferenceType.Country &&
                                                 fieldValuesCortege[fieldIndex].IsRelated);
                if (field.AddMissedValues || isNonCountryFieldRelated)
                {
                    IEnumerable<object> missedValues;
                    try
                    {
                        missedValues = isDateTimeField
                            ? field.AddMissedDates()
                            : field.AddMissedReferencies(fieldValuesCortege);
                    }
                    catch (Exception ex)
                    {
                        throw new AvrException(field.GetMissedValuesErrorMessage(), ex);
                    }

                    foreach (object missedValue in missedValues)
                    {
                        if (!valuesDictionary.ContainsKey(missedValue))
                        {
                            valuesDictionary.Add(missedValue, new List<DataRow>());
                        }
                    }
                }
                if (valuesDictionary.Count == 0)
                {
                    //var childCortege = new FieldValueCollection(fieldValuesCortege, true);
//                    var childCortege = new FieldValueCollection(fieldValuesCortege, false);
                    for (int i = fieldIndex; i < fieldValuesCortege.Count; i++)
                    {
                        fieldValuesCortege[i].Value = null;
                    }
                    AddMissedValuesForFields(dataSource, fieldValuesCortege, new List<DataRow>(), fieldValuesCortege.Count);
                }
                foreach (KeyValuePair<object, List<DataRow>> pair in valuesDictionary)
                {
//                    var childCortege = new FieldValueCollection(fieldValuesCortege, false);
                    fieldValuesCortege[fieldIndex].Value = pair.Key;
                    AddMissedValuesForFields(dataSource, fieldValuesCortege, pair.Value, fieldIndex + 1);
                }
            }
            else
            {
                DataRow row = dataSource.NewRow();
                foreach (FieldValuePair pair in fieldValuesCortege)
                {
                    row[pair.Field.FieldName] = pair.Value ?? DBNull.Value;
                    if (!pair.Field.IsDateTimeField)
                    {
                        foreach (IAvrPivotGridField copy in pair.FieldCopy)
                        {
                            row[copy.FieldName] = pair.Value ?? DBNull.Value;
                        }
                    }
                }
                dataSource.AddRow(row);
            }
        }

        public static List<IAvrPivotGridField> AddRelatedFields(IEnumerable<IAvrPivotGridField> baseFields)
        {
            List<IAvrPivotGridField> allFields = baseFields.ToList();

            //for fields with missing value remove all their copies without missing values
            var removeFields = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in allFields.Where(f => f.AddMissedValues && !f.IsDateTimeField))
            {
                IAvrPivotGridField originalField = field;
                removeFields.AddRange(
                    allFields.Where(f => !f.AddMissedValues && f != originalField && f.GetOriginalName() == originalField.GetOriginalName()));
            }
            foreach (IAvrPivotGridField field in removeFields)
            {
                allFields.Remove(field);
            }

            //for fields remove all their copies except first one
            var distinctFields = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in allFields)
            {
                IAvrPivotGridField originalField = field;
                if (originalField.IsDateTimeField || distinctFields.All(f => f.GetOriginalName() != originalField.GetOriginalName()))
                {
                    distinctFields.Add(originalField);
                }
            }
            allFields = distinctFields;

            // remove all field copies that can be found in related chains
            removeFields = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in allFields)
            {
                removeFields.AddRange(field.GetRelatedFieldChain().Where(allFields.Contains));
            }
            foreach (IAvrPivotGridField field in removeFields)
            {
                allFields.Remove(field);
            }

            var cortegeFields = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in allFields)
            {
                cortegeFields.AddRange(field.GetRelatedFieldChain());
                cortegeFields.Add(field);
            }

            return cortegeFields;
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

            DataColumn destColumn = CreateDataSourceColumnCopy(pivotData.RealPivotData, sourceField.FieldName,
                sourceField.GetOriginalName(), sourceField.Caption,
                destRow.idfLayoutSearchField);

            var copy = new T();

            sourceField.CreatePivotGridFieldCopy(copy, destColumn.ColumnName);

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
            if (sourceField.GetFieldId() < 0)
            {
                throw new AvrException(String.Format("Field {0} doesn't has Id", sourceField.FieldName));
            }
            LayoutDetailDataSet.LayoutSearchFieldRow sourceRow =
                layoutDataset.LayoutSearchField.FindByidfLayoutSearchField(sourceField.GetFieldId());
            if (sourceRow == null)
            {
                throw new AvrException(String.Format("LayoutSearchField information not found for field {0} with ID {1}",
                    sourceField.FieldName, sourceField.GetFieldId()));
            }
            return sourceRow;
        }

        public static void DeleteFieldCopy(IAvrPivotGridField sourceField, LayoutDetailDataSet layoutDataset, AvrPivotGridData pivotData)
        {
            DataColumn sourceColumn = pivotData.RealPivotData.Columns[sourceField.FieldName];
            pivotData.RealPivotData.Columns.Remove(sourceColumn);

            // clear Unit, Denoninator, Date and other fields here
            string originalName = sourceField.GetOriginalName();
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
                layoutDataset.LayoutSearchField.FindByidfLayoutSearchField(sourceField.GetFieldId());
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
            int count = avrFields.Count(f => f.GetOriginalName() == field.GetOriginalName());
            return count > 2;
        }

        #endregion
    }
}