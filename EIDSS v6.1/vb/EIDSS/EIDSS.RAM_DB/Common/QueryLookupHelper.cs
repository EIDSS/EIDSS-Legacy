using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Objects;
using EIDSS;
using EIDSS.Enums;
using eidss.model.AVR.DataBase;

namespace eidss.avr.db.Common
{
    public static class QueryLookupHelper
    {
        private static readonly object m_SyncRoot = new object();
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


        public static bool HasQueryArchiveLayouts()
        {
            lock (m_SyncRoot)
            {
                LookupTableInfo layoutLookup = LookupCache.LookupTables[LookupTables.Layout.ToString()];
                DataTable layouts = LookupCache.Fill(layoutLookup);
                if (layouts == null)
                {
                    throw new AvrException("Could not load layout Lookup");
                }
                return layouts.Rows.Cast<DataRow>()
                    .Any(row => row["blnUseArchivedData"] is bool && ((bool) row["blnUseArchivedData"]));
            }
        }
        

        public static DataTable GetQuerySearchFieldLookupTable()
        {
            lock (m_SyncRoot)
            {
                LookupTableInfo lookupTable = LookupCache.LookupTables[LookupTables.QuerySearchField.ToString()];
                DataTable result = LookupCache.Fill(lookupTable);
                if (result == null)
                {
                    throw new AvrException("Could not load QuerySearchField Lookup");
                }
                return result.Copy();
            }
        }

        public static DataTable GetSearchFieldLookupTable()
        {
            lock (m_SyncRoot)
            {
                LookupTableInfo lookupTable = LookupCache.LookupTables[LookupTables.SearchField.ToString()];
                DataTable result = LookupCache.Fill(lookupTable);
                if (result == null)
                {
                    throw new AvrException("Could not load SearchField Lookup");
                }
                // todo: [ivan] possible performance issue. this is try to make method thread-safe
                return result.Copy();
            }
        }
        
        public static DataTable GetQueryPersonalDataGroupTable()
        {
            lock (m_SyncRoot)
            {
                LookupTableInfo lookupTable = LookupCache.LookupTables[LookupTables.QuerySearchFieldPersonalDataGroup.ToString()];

                DataTable result = LookupCache.Fill(lookupTable);
                if (result == null)
                {
                    throw new AvrException("Could not load QuerySearchFieldPersonalDataGroup Lookup");
                }
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