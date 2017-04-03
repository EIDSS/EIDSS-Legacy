using System.Collections.Generic;
using System.Data;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Objects;
using EIDSS.Enums;

namespace EIDSS.RAM_DB.Common
{
    public static class QueryLookupHelper
    {
        public const string ColumnAlias = "FieldAlias";
        private const string ColumnFieldType = "idfsSearchFieldType";
        private const string ColumnParamType = "idfsParameterType";

        public static Dictionary<string, SearchFieldType> GetFieldTypes()
        {
            DataTable lookupTable = GetQueryLookupTable();
            return GetFieldTypes(lookupTable);
        }

        public static Dictionary<string, SearchFieldType> GetFieldTypes(DataTable lookupTable)
        {
            CheckColumnExists(lookupTable, ColumnAlias);
            CheckColumnExists(lookupTable, ColumnFieldType);
            CheckColumnExists(lookupTable, ColumnParamType);

            var fieldTypes = new Dictionary<string, SearchFieldType>();
            foreach (DataRow row in lookupTable.Rows)
            {
                long searchFieldType;
                if (!long.TryParse(row[ColumnFieldType].ToString(), out searchFieldType))
                {
                    continue;
                }

                string key = row[ColumnAlias].ToString();
                if (fieldTypes.ContainsKey(key))
                {
                    continue;
                }

                SearchFieldType value;
                if ((SearchFieldType) searchFieldType != SearchFieldType.FFField)
                {
                    value = (SearchFieldType) searchFieldType;
                    fieldTypes.Add(key, value);
                    continue;
                }

                long parameterType;
                if (!long.TryParse(row[ColumnParamType].ToString(), out parameterType))
                {
                    continue;
                }

                switch ((ParameterType) parameterType)
                {
                    case ParameterType.Numeric:
                    case ParameterType.NumericNatural:
                    case ParameterType.NumericPositive:
                    case ParameterType.NumericInteger:
                    case ParameterType.Months:
                        value = SearchFieldType.Integer;
                        break;
                    case ParameterType.Boolean:
                        value = SearchFieldType.Bit;
                        break;
                    case ParameterType.Date:
                    case ParameterType.DateTime:
                        value = SearchFieldType.Date;
                        break;
                    default:
                        value = SearchFieldType.String;
                        break;
                }
                fieldTypes.Add(key, value);
            }
            return fieldTypes;
        }

        public static DataTable GetQueryLookupTable()
        {
            LookupTableInfo lookupTable = LookupCache.LookupTables[LookupTables.QuerySearchField.ToString()];
            return LookupCache.Fill(lookupTable);
        }

        public static DataTable GetQueryPersonalDataGroupTable()
        {
            LookupTableInfo lookupTable = LookupCache.LookupTables[LookupTables.QuerySearchFieldPersonalDataGroup.ToString()];
            return LookupCache.Fill(lookupTable);
        }

        

        private static void CheckColumnExists(DataTable dataTable, string alias)
        {
            if (!dataTable.Columns.Contains(alias))
            {
                throw new RamDbException(string.Format("Column {0} not found in Query lookup table", alias));
            }
        }
    }
}