using System.Collections.Generic;
using System.Data;
using bv.common.db.Core;
using bv.common.Objects;
using EIDSS;
using EIDSS.Enums;
using eidss.model.AVR.Db;

namespace eidss.avr.db.Common
{
    public static class QueryLookupHelper
    {
        private const string ColumnFieldType = "idfsSearchFieldType";
        private const string ColumnParamType = "idfsParameterType";

      

        public static Dictionary<string, SearchFieldType> GetFieldTypes(DataTable lookupTable)
        {
            CheckColumnExists(lookupTable, QueryHelper.ColumnAlias);
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

                string key = row[QueryHelper.ColumnAlias].ToString();
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

        static readonly object m_SyncRoot = new object();
        public static DataTable GetQueryLookupTable()
        {
            lock (m_SyncRoot)
            {
                LookupTableInfo lookupTable = LookupCache.LookupTables[LookupTables.QuerySearchField.ToString()];
                DataTable result = LookupCache.Fill(lookupTable);
                // todo: [ivan] possible performance issue. this is try to make method thread-safe
                //return result;
                return result.Copy();
            }
        }

        public static DataTable GetQueryPersonalDataGroupTable()
        {
            lock (m_SyncRoot)
            {
                LookupTableInfo lookupTable = LookupCache.LookupTables[LookupTables.QuerySearchFieldPersonalDataGroup.ToString()];
                DataTable result = LookupCache.Fill(lookupTable);
                // todo: [ivan] possible performance issue. this is try to make method thread-safe
                return result.Copy();
            }
        }

        private static void CheckColumnExists(DataTable dataTable, string alias)
        {
            if (!dataTable.Columns.Contains(alias))
            {
                throw new AvrDbException(string.Format("Column {0} not found in Query lookup table", alias));
            }
        }
    }
}