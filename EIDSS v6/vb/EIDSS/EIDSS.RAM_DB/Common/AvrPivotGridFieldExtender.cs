using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using DevExpress.XtraPivotGrid;
using EIDSS;
using eidss.avr.db.DBService.DataSource;
using eidss.model.Avr.Chart;
using eidss.model.AVR.Db;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.View;
using eidss.model.Core;
using eidss.model.WindowsService.Serialization;

namespace eidss.avr.db.Common
{
    public static class AvrPivotGridFieldExtender
    {
        private const string CountryNameAttribute = "strCountryName";

        public static void OnSetIsHiddenFilterField(this IAvrPivotGridField field, bool value)
        {
            field.Area = (value)
                ? PivotArea.FilterArea
                : PivotArea.RowArea;
            field.AllowedAreas = (value)
                ? PivotGridAllowedAreas.FilterArea
                : PivotGridAllowedAreas.All ^ PivotGridAllowedAreas.FilterArea;
        }

        public static CustomSummaryType GetDefaultSummaryType(this IAvrPivotGridField field)
        {
            CustomSummaryType summaryType = Configuration.GetDefaultSummaryTypeFor(field.FieldName, field.SearchFieldDataType);
            return summaryType;
        }

        public static string GetOriginalName(this IAvrPivotGridField field)
        {
            return AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(field.FieldName);
        }

        public static long GetFieldId(this IAvrPivotGridField field)
        {
            return AvrPivotGridFieldHelper.GetIdFromFieldName(field.FieldName);
        }

        public static void UpdateGroupInterval(this IAvrPivotGridField field)
        {
            if (field.IsHiddenFilterField)
            {
                return;
            }

            if (field.IsDateTimeField)
            {
                field.GroupInterval = field.PrivateGroupInterval.HasValue
                    ? field.PrivateGroupInterval.Value
                    : field.DefaultGroupInterval;
            }
        }

        public static string GetSelectedDateFieldAlias(this IAvrPivotGridField field)
        {
            string dateFullFieldName = (field == null ||
                                        String.IsNullOrEmpty(field.DateSearchFieldAlias) ||
                                        !field.DateLayoutSearchFieldId.HasValue)
                ? null
                : AvrPivotGridFieldHelper.CreateFieldName(field.DateSearchFieldAlias, field.DateLayoutSearchFieldId.Value);
            return dateFullFieldName;
        }

        public static string GetSelectedAdmFieldAlias(this IAvrPivotGridField field)
        {
            string dateFullFieldName = (field == null ||
                                        String.IsNullOrEmpty(field.UnitSearchFieldAlias) ||
                                        !field.UnitLayoutSearchFieldId.HasValue)
                ? null
                : AvrPivotGridFieldHelper.CreateFieldName(field.UnitSearchFieldAlias, field.UnitLayoutSearchFieldId.Value);
            return dateFullFieldName;
        }

        #region Related Fields

        public static IEnumerable<object> AddMissedDates(this IAvrPivotGridField field)
        {
            var values = new List<object>();
            if (field.IsDateTimeField && field.DiapasonStartDate.HasValue && field.DiapasonEndDate.HasValue)
            {
                DateTime startDate = field.DiapasonStartDate.Value.TruncateToFirstDateInInterval(field.GroupInterval);
                DateTime endDate = field.DiapasonEndDate.Value;

                while (startDate <= endDate)
                {
                    values.Add(startDate);
                    switch (field.GroupInterval)
                    {
                        case PivotGroupInterval.Date:
                        case PivotGroupInterval.DateDay:
                        case PivotGroupInterval.DateDayOfWeek:
                        case PivotGroupInterval.DateDayOfYear:
                            startDate = startDate.AddDays(1);
                            break;
                        case PivotGroupInterval.DateMonth:
                            startDate = startDate.AddMonths(1);
                            break;
                        case PivotGroupInterval.DateQuarter:
                            startDate = startDate.AddMonths(3);
                            break;
                        case PivotGroupInterval.DateYear:
                            startDate = startDate.AddYears(1);
                            break;
                        case PivotGroupInterval.DateWeekOfMonth:
                        case PivotGroupInterval.DateWeekOfYear:
                            startDate = startDate.AddDays(7);
                            break;
                    }
                }
            }
            return values;
        }

        public static IEnumerable<object> AddMissedReferencies
            (this IAvrPivotGridField field, IEnumerable<FieldValuePair> fieldValuesCortege)
        {
            string tableName = field.LookupTableName;
            string columnName = field.LookupAttributeName;
            if (field.IsDateTimeField || String.IsNullOrEmpty(tableName) || String.IsNullOrEmpty(columnName))
            {
                return new List<object>();
            }

            string filter = GetRowFilter(fieldValuesCortege, field);

            DataView lookup = LookupCache.Get(tableName);

            var newFilter = CreateExtraLookupFilter(filter, tableName, lookup);

            lookup.RowFilter = newFilter;

            var values = new List<object>();
            if (!lookup.Table.Columns.Contains(columnName))
            {
                if (columnName == "strRegionExtendedName")
                {
                    columnName = "strExtendedRegionName";
                }
                if (!lookup.Table.Columns.Contains(columnName))
                {
                    throw new AvrException(field.GetMissedValuesErrorMessage());
                }
            }
            foreach (DataRowView row in lookup)
            {
                values.Add(row[columnName]);
            }

            return values;
        }

    

        public static string GetMissedValuesErrorMessage(this IAvrPivotGridField field)
        {
            string errMsg = String.Format(
                "Cannot add missed reference values for field '{0}'. Could not find column '{1}' in lookup table '{2}'",
                field.GetOriginalName(), field.LookupAttributeName, field.LookupTableName);

            return errMsg;
        }

        public static string GetRowFilter(IEnumerable<FieldValuePair> fieldValuesCortege, IAvrPivotGridField field)
        {
            var filterBuilder = new StringBuilder();
            bool needInsertAndInFilter = false;
            List<IAvrPivotGridField> related = field.GetRelatedFieldChain();
            foreach (FieldValuePair pair in fieldValuesCortege)
            {
                if (pair.Field == field)
                {
                    break;
                }
                if (related.Contains(pair.Field))
                {
                    string attributeName = pair.Field.LookupAttributeName;
                    if (!String.IsNullOrEmpty(attributeName))
                    {
                        string value = Utils.Str(pair.Value).Replace("'", "''");
                        // when filter contains strCountryName we should remove HASC from Country Name 

                        if (attributeName == CountryNameAttribute)
                        {
                            value = Regex.Replace(value, " (.*)", "");
                        }

                        if (needInsertAndInFilter)
                        {
                            filterBuilder.Append(" AND ");
                        }
                        needInsertAndInFilter = true;

                        if (Utils.IsEmpty(value))
                        {
                            filterBuilder.AppendFormat("({0} is NULL)", attributeName);
                        }
                        else
                        {
                            filterBuilder.AppendFormat(pair.Field.IsNumeric
                                ? "({0} = {1})"
                                : "({0} = '{1}')",
                                attributeName, value);
                        }
                    }
                }
            }

            string rowFilter = String.IsNullOrEmpty(filterBuilder.ToString())
                ? null
                : filterBuilder.ToString();
            return rowFilter;
        }

        public static string CreateExtraLookupFilter(string oldFilter, string tableName, DataView lookup)
        {
            var filterMembers = new List<string>();

            if (!string.IsNullOrEmpty(oldFilter))
            {
                filterMembers.Add(oldFilter);
            }
            if ((string.IsNullOrEmpty(oldFilter) || !oldFilter.Contains(CountryNameAttribute)) &&
                (tableName == LookupTables.Region.ToString() ||
                 tableName == LookupTables.Rayon.ToString() ||
                 tableName == LookupTables.Settlement.ToString()))
            {
                filterMembers.Add("idfsCountry=" + EidssSiteContext.Instance.CountryID);
            }

            if (lookup.Table.Columns.Contains("intRowStatus"))
            {
                filterMembers.Add("intRowStatus = 0");
            }
            DataColumn keyColumn = lookup.Table.PrimaryKey[0];
            if (keyColumn != null && !string.IsNullOrEmpty(keyColumn.ColumnName))
            {
                filterMembers.Add(string.Format("{0} <> {1}", keyColumn.ColumnName, LookupCache.EmptyLineKey));
            }
            string filter = null;
            if (filterMembers.Count > 0)
            {
                if (filterMembers.Count == 1)
                {
                    filter = filterMembers[0];
                }
                else
                {
                    var filterBuilder = new StringBuilder();
                    filterBuilder.AppendFormat("({0})", filterMembers[0]);
                    for (int i = 1; i < filterMembers.Count; i++)
                    {
                        filterBuilder.AppendFormat(" AND ({0})", filterMembers[i]);
                    }
                    filter = filterBuilder.ToString();
                }
            }

            return String.IsNullOrEmpty(filter)
                ? null
                : filter;

        }

        public static List<IAvrPivotGridField> GetRelatedFieldChain(this IAvrPivotGridField field)
        {
            var fieldChain = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField related in field.RelatedFields)
            {
                fieldChain.AddRange(related.GetRelatedFieldChain());
                fieldChain.Add(related);
            }
            var result = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField related in fieldChain)
            {
                if (!result.Contains(related))
                {
                    result.Add(related);
                }
            }
            return result;
        }

        public static List<IAvrPivotGridField> GetRelatedFields(this IAvrPivotGridField field)
        {
            if (field.AllPivotFields == null || field.AllPivotFields.Count == 0)
            {
                throw new AvrDataException(String.Format("AllPivotFields is not initialized for field '{0}'", field.FieldName));
            }

            List<string> relatedFieldsName = GetRelatedFieldAliasByName(field.GetOriginalName());

            var relatedFields = new List<IAvrPivotGridField>();
            foreach (string name in relatedFieldsName)
            {
                IAvrPivotGridField relatedField =
                    field.AllPivotFields.FirstOrDefault(f => f.GetOriginalName() == name && !f.IsHiddenFilterField);
                if (relatedField != null)
                {
                    relatedFields.Add(relatedField);
                }
            }
            return relatedFields;
        }

        public static List<string> GetRelatedFieldAliasByName(string name)
        {
            DataView lookupInfo = GetSearchFieldLookupInfoByName(name);
            var relatedFieldsName = new List<string>();
            foreach (DataRowView row in lookupInfo)
            {
                relatedFieldsName.Add(Utils.Str(row["strRelatedFieldAlias"]));
            }
            return relatedFieldsName;
        }

        private static DataView GetSearchFieldLookupInfoByName(string name)
        {
            Utils.CheckNotNullOrEmpty(name, "name");

            string originalName = AvrPivotGridFieldHelper.GetOriginalNameFromCopyForFilterName(name);
            string filter = String.Format("strFieldAlias = '{0}'", originalName);
            DataView searchFields = LookupCache.Get(LookupTables.SearchFieldLookupInfo);
            if (searchFields == null)
            {
                throw new AvrException(
                    "Could not load lookup SearchFieldLookupInfo. Check that Database contains spAsSearchFieldLookupInfoSelectLookup");
            }
            searchFields.RowFilter = filter;
            return searchFields;
        }

        #endregion

        #region Save Field to Data Row

        public static void SaveSearchFieldToTable
            (this IAvrPivotGridField field, LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldTable)
        {
            LayoutDetailDataSet.LayoutSearchFieldRow row = field.GetLayoutSearchFieldRow(searchFieldTable);

            field.SaveSearchFieldToRow(row);
        }

        public static LayoutDetailDataSet.LayoutSearchFieldRow GetLayoutSearchFieldRow
            (this IAvrPivotGridField field, LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldTable)
        {
            string filter = String.Format("{0}='{1}' AND {2}={3} ",
                searchFieldTable.strSearchFieldAliasColumn.ColumnName, field.GetOriginalName(),
                searchFieldTable.idfLayoutSearchFieldColumn, field.GetFieldId());
            DataRow[] rows = searchFieldTable.Select(filter);
            if (rows.Length == 0)
            {
                throw new AvrException(String.Format("Could not find Aggregate row for field {0}.", field.GetOriginalName()));
            }
            if (rows.Length > 1)
            {
                throw new AvrException(String.Format("Multiple Aggregate rows for field {0} found.", field.GetOriginalName()));
            }

            var row = (LayoutDetailDataSet.LayoutSearchFieldRow) rows[0];
            return row;
        }

        public static void SaveSearchFieldToRow(this IAvrPivotGridField field, LayoutDetailDataSet.LayoutSearchFieldRow row)
        {
            row.intFieldCollectionIndex = field.Index;
            row.intPivotGridAreaType = (int) field.Area;
            row.intFieldPivotGridAreaIndex = field.AreaIndex;
            row.blnVisible = field.Visible;

            row.SetstrFieldFilterValuesNull();

            row.intFieldColumnWidth = field.Visible
                ? field.Width
                : AvrView.DefaultFieldWidth;

            if (field.Precision.HasValue)
            {
                row.intPrecision = field.Precision.Value;
            }
            else
            {
                row.SetintPrecisionNull();
            }

            row.idfsAggregateFunction = field.AggregateFunctionId;
            if (field.UnitLayoutSearchFieldId.HasValue)
            {
                row.idfUnitLayoutSearchField = field.UnitLayoutSearchFieldId.Value;
            }
            else
            {
                row.SetidfUnitLayoutSearchFieldNull();
            }
            row.strUnitSearchFieldAlias = field.UnitSearchFieldAlias;
            if (field.DateLayoutSearchFieldId.HasValue)
            {
                row.idfDateLayoutSearchField = field.DateLayoutSearchFieldId.Value;
            }
            else
            {
                row.SetidfDateLayoutSearchFieldNull();
            }
            row.strDateSearchFieldAlias = field.DateSearchFieldAlias;

            if (!field.IsHiddenFilterField)
            {
                var filterFalues = (AvrPivotGridFieldFilterValues) field.FilterValues;
                if (!filterFalues.IsDefaultValue)
                {
                    string xml = filterFalues.Serialize();
                    row.strFieldFilterValues = CompressEndEncodeString(xml);
                }

                if (field.PrivateGroupInterval.HasValue)
                {
                    DBGroupInterval dbGroupInterval = GroupIntervalHelper.GetDBGroupInterval(field.PrivateGroupInterval.Value);
                    row.idfsGroupDate = (long) dbGroupInterval;
                }
                else
                {
                    row.SetidfsGroupDateNull();
                }

                row.blnSortAcsending = (field.SortOrder == PivotSortOrder.Ascending);

                row.blnShowMissedValue = field.AddMissedValues;

                if (field.DiapasonStartDate.HasValue)
                {
                    row.datDiapasonStartDate = field.DiapasonStartDate.Value;
                }
                else
                {
                    row.SetdatDiapasonStartDateNull();
                }

                if (field.DiapasonEndDate.HasValue)
                {
                    row.datDiapasonEndDate = field.DiapasonEndDate.Value;
                }
                else
                {
                    row.SetdatDiapasonEndDateNull();
                }
            }
            else
            {
                row.SetstrFieldFilterValuesNull();

                row.blnShowMissedValue = false;

                row.SetdatDiapasonStartDateNull();
                row.SetdatDiapasonEndDateNull();
            }
        }

        #endregion

        #region Load Field from Data Row

        public static void LoadSearchFieldFromRow(this IAvrPivotGridField field, LayoutDetailDataSet.LayoutSearchFieldRow row)
        {
            field.AddMissedValues = row.blnShowMissedValue;
            field.DiapasonStartDate = row.IsdatDiapasonStartDateNull()
                ? (DateTime?) null
                : row.datDiapasonStartDate;
            field.DiapasonEndDate = row.IsdatDiapasonEndDateNull()
                ? (DateTime?) null
                : row.datDiapasonEndDate;

            field.Index = row.intFieldCollectionIndex;
            field.Area = (PivotArea) row.intPivotGridAreaType;
            field.AreaIndex = row.intFieldPivotGridAreaIndex;
            field.Visible = row.blnVisible;
            field.Width = field.Visible
                ? row.intFieldColumnWidth
                : AvrView.DefaultFieldWidth;
            field.SortOrder = row.blnSortAcsending ? PivotSortOrder.Ascending : PivotSortOrder.Descending;

            if (!row.IsidfsGroupDateNull())
            {
                field.PrivateGroupInterval = GroupIntervalHelper.GetGroupInterval(row.idfsGroupDate);
            }
            if (!row.IsstrFieldFilterValuesNull() && !String.IsNullOrEmpty(row.strFieldFilterValues))
            {
                string xml = UncompressEndDecodeString(row.strFieldFilterValues);
                if (!String.IsNullOrEmpty(xml))
                {
                    AvrPivotGridFieldFilterValues values = AvrPivotGridFieldFilterValues.Deserialize(xml);
                    values.CopyPropertiesTo(field.FilterValues);
                }
            }
            if (!row.IsidfsAggregateFunctionNull() && !row.IsintPrecisionNull())
            {
                var summaryType = (CustomSummaryType) row.idfsAggregateFunction;
                if (!field.PrecisionDictionary.ContainsKey(summaryType))
                {
                    field.PrecisionDictionary.Add(summaryType, row.intPrecision);
                }
                field.Precision = row.intPrecision;
            }
        }

        public static void LoadSearchFieldExstraFromRow(this IAvrPivotGridField field, LayoutDetailDataSet.LayoutSearchFieldRow row)
        {
            field.AggregateFunctionId = row.idfsAggregateFunction;
            if (!row.IsstrUnitSearchFieldAliasNull())
            {
                field.UnitSearchFieldAlias = row.strUnitSearchFieldAlias;
            }
            if (!row.IsidfUnitLayoutSearchFieldNull())
            {
                field.UnitLayoutSearchFieldId = row.idfUnitLayoutSearchField;
            }
            if (!row.IsstrDateSearchFieldAliasNull())
            {
                field.DateSearchFieldAlias = row.strDateSearchFieldAlias;
            }
            if (!row.IsidfDateLayoutSearchFieldNull())
            {
                field.DateLayoutSearchFieldId = row.idfDateLayoutSearchField;
            }

            field.AllowMissedReferenceValues = row.blnAllowMissedReferenceValues;
            field.LookupTableName = row.strLookupTable;

            if (!row.IsidfsReferenceTypeNull())
            {
                field.ReferenceTypeId = row.idfsReferenceType;
            }
            if (!row.IsidfsGISReferenceTypeNull())
            {
                field.GisReferenceTypeId = row.idfsGISReferenceType;
            }

            // note: workaroung because of wrong DB data
            string attribute = row.strLookupAttribute;
            if (attribute == "strExtendedRegionName")
            {
                attribute = "strRegionExtendedName";
            }
            if (attribute == "strExtendedRayonName")
            {
                attribute = "strRayonExtendedName";
            }
            if (attribute == "strExtendedSettlementName")
            {
                attribute = "strSettlementExtendedName";
            }
            field.LookupAttributeName = attribute;

            field.CustomSummaryType = AvrPivotGridHelper.ParseSummaryType(row.idfsAggregateFunction);

            //

            field.UpdateImageIndex();
        }

        #endregion

        public static void CreatePivotGridFieldCopy(this IAvrPivotGridField sourceField, IAvrPivotGridField destField, string fieldName)
        {
            destField.Name = "field" + fieldName;
            destField.FieldName = fieldName;
            destField.Caption = sourceField.Caption;
            destField.IsHiddenFilterField = sourceField.IsHiddenFilterField;
            destField.Visible = sourceField.Visible;
            destField.SearchFieldDataType = sourceField.SearchFieldDataType;
            destField.DefaultGroupInterval = sourceField.DefaultGroupInterval;
            destField.CustomSummaryType = sourceField.CustomSummaryType;
            destField.SummaryType = sourceField.SummaryType;

            destField.Width = sourceField.Width;
            destField.AllowedAreas = sourceField.AllowedAreas;
            destField.Area = sourceField.Area;
            if (sourceField.AreaIndex >= 0)
            {
                destField.AreaIndex = sourceField.AreaIndex + 1;
            }
            destField.SortOrder = sourceField.SortOrder;
            destField.AddMissedValues = false;
            destField.DiapasonStartDate = null;
            destField.DiapasonEndDate = null;
            destField.Precision = sourceField.Precision;

            destField.AggregateFunctionId = sourceField.AggregateFunctionId;
            destField.UnitLayoutSearchFieldId = sourceField.UnitLayoutSearchFieldId;
            destField.UnitSearchFieldAlias = sourceField.UnitSearchFieldAlias;
            destField.DateLayoutSearchFieldId = sourceField.DateLayoutSearchFieldId;
            destField.DateSearchFieldAlias = sourceField.DateSearchFieldAlias;

            if (sourceField.IsDateTimeField)
            {
                destField.GroupInterval = sourceField.DefaultGroupInterval;
            }
            else
            {
                destField.AddMissedValues = sourceField.AddMissedValues;
            }
            destField.UpdateImageIndex();

            destField.AllowMissedReferenceValues = sourceField.AllowMissedReferenceValues;
            destField.LookupTableName = sourceField.LookupTableName;
            destField.GisReferenceTypeId = sourceField.GisReferenceTypeId;
            destField.ReferenceTypeId = sourceField.ReferenceTypeId;

            destField.LookupAttributeName = sourceField.LookupAttributeName;

            destField.AllPivotFields = sourceField.AllPivotFields;
        }

        public static string CompressEndEncodeString(string uncompressed)
        {
            try
            {
                byte[] compressedBytes = BinaryCompressor.ZipString(uncompressed);
                string compressedString = Convert.ToBase64String(compressedBytes);
                return compressedString;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return string.Empty;
            }
        }

        public static string UncompressEndDecodeString(string compressed)
        {
            try
            {
                byte[] encodedData = Convert.FromBase64String(compressed);
                string uncompressed = BinaryCompressor.UnzipString(encodedData);
                return uncompressed;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return string.Empty;
            }
        }
    }
}