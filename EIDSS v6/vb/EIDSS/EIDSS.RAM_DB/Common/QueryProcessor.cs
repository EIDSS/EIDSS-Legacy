using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.model.BLToolkit;
using eidss.model.AVR.Db;
using eidss.model.Avr.Pivot;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.avr.db.Common
{
    public static class QueryProcessor
    {
        private const string CopySuffix = QueryHelper.CopySuffix;
        private const string AliasColumnName = QueryHelper.ColumnAlias;

        private const string CaptionColumnName = "FieldCaption";
        private const string EnCaptionColumnName = "FieldENCaption";
        private const string QueryIdColumnName = "idflQuery";
        private const string PersonalDataGroupIdColumnName = "idfPersonalDataGroup";

        public static void TranslateTableFields(DataTable dataTable, long queryId)
        {
            Utils.CheckNotNull(dataTable, "dataTable");

            Dictionary<string, string> translations = GetTranslations(queryId);
            Dictionary<string, string> copy = translations.ToDictionary(pair => pair.Key + CopySuffix, pair => pair.Value);
            foreach (KeyValuePair<string, string> pair in copy)
            {
                translations.Add(pair.Key, pair.Value);
            }

            dataTable.BeginLoadData();
            foreach (DataColumn column in dataTable.Columns)
            {
                if (translations.ContainsKey(column.ColumnName))
                {
                    column.Caption = translations[column.ColumnName];
                }
                else
                {
                    Trace.WriteLine(Trace.Kind.Error, "Translation of field {0} not found", column.ColumnName);
                }
            }
            dataTable.EndLoadData();
            dataTable.AcceptChanges();
        }

        public static DataTable RemoveNotExistingColumns(DataTable dataTable, long queryId)
        {
            Utils.CheckNotNull(dataTable, "dataTable");

            string rowFilter = String.Format("idflQuery = {0} and blnShow = 1 ", queryId);
            var dataView = new DataView(
                QueryLookupHelper.GetQueryLookupTable(),
                rowFilter,
                QueryHelper.ColumnAlias,
                DataViewRowState.CurrentRows);

            var aliases = new List<string>();
            foreach (DataRowView row in dataView)
            {
                string alias = Utils.Str(row[QueryHelper.ColumnAlias]);
                aliases.Add(alias);
                aliases.Add(alias + CopySuffix);
            }
            var columnsToRemove = new List<DataColumn>();
            foreach (DataColumn column in dataTable.Columns)
            {
                if (!aliases.Contains(column.ColumnName))
                {
                    columnsToRemove.Add(column);
                }
            }

            dataTable.Constraints.Clear();
            foreach (DataColumn column in columnsToRemove)
            {
                dataTable.Columns.Remove(column);
            }
            return dataTable;
        }

        public static void SetNullForForbiddenTableFields(DataTable dataTable, long queryId)
        {
            Utils.CheckNotNull(dataTable, "dataTable");

            Dictionary<PersonalDataGroup, List<string>> groups = GetPersonalDataGroups(queryId);

            var forbiddenColumn = new List<string>();
            foreach (KeyValuePair<PersonalDataGroup, List<string>> group in groups)
            {
                if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(@group.Key))
                {
                    foreach (string columnName in @group.Value)
                    {
                        if (dataTable.Columns.Contains(columnName) && !forbiddenColumn.Contains(columnName))
                        {
                            forbiddenColumn.Add(columnName);
                        }
                        string copyColumnName = columnName + CopySuffix;
                        if (dataTable.Columns.Contains(copyColumnName) && !forbiddenColumn.Contains(copyColumnName))
                        {
                            forbiddenColumn.Add(copyColumnName);
                        }
                    }
                }
            }
            if (forbiddenColumn.Count > 0)
            {
                dataTable.Constraints.Clear();
                foreach (string columnName in forbiddenColumn)
                {
                    dataTable.Columns[columnName].ReadOnly = false;
                }
                dataTable.BeginLoadData();

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (string columnName in forbiddenColumn)
                    {
                        row[columnName] = DBNull.Value;
                    }
                }

                dataTable.EndLoadData();
                dataTable.AcceptChanges();
            }
        }

        public static void SetCopyPropertyForColumnsIfNeeded(DataTable dataTable)
        {
            Utils.CheckNotNull(dataTable, "dataTable");

            foreach (DataColumn column in dataTable.Columns)
            {
                if (AvrPivotGridFieldHelper.GetIsCopyForFilter(column.ColumnName) &&
                    !column.ExtendedProperties.ContainsKey(CopySuffix))
                {
                    column.ExtendedProperties[CopySuffix] = true;
                }
            }
        }

        public static KeyValuePair<string, string> GetTranslations(long queryId, string alias)
        {
            DataTable dataTable = QueryLookupHelper.GetQueryLookupTable();

            CheckColumnExists(dataTable, AliasColumnName);
            CheckColumnExists(dataTable, CaptionColumnName);
            // for copied fields we should get original field alias
            if (alias.Length > CopySuffix.Length && alias.Substring(alias.Length - CopySuffix.Length) == CopySuffix)
            {
                alias = alias.Substring(0, alias.Length - CopySuffix.Length);
            }
            string rowFilter = String.Format("{0} = {1} and {2} = '{3}' and blnShow = 1 ",
                                             QueryIdColumnName, queryId, AliasColumnName, alias);
            
            var dataView = new DataView(dataTable,rowFilter,CaptionColumnName,DataViewRowState.CurrentRows);

            if (dataView.Count == 0)
            {
                // hope it will fix 9224. if query search field didn't found - maybe cache didn't refreshes
                LookupCache.NotifyChange("QuerySearchField");
                dataView = new DataView(dataTable, rowFilter, CaptionColumnName, DataViewRowState.CurrentRows);
                if (dataView.Count == 0)
                {
                    // if field still not fouynd - return with no translation. It bad practice, I know, but it's better than failed GAT
                    return new KeyValuePair<string, string>(alias, alias);
                }
            }

            string key = dataView[0][EnCaptionColumnName].ToString();
            string value = dataView[0][CaptionColumnName].ToString();
            return new KeyValuePair<string, string>(key, value);
        }

        public static Dictionary<string, string> GetTranslations(long queryId)
        {
            var translations = new Dictionary<string, string>();

            DataTable dataTable = QueryLookupHelper.GetQueryLookupTable();

            CheckColumnExists(dataTable, AliasColumnName);
            CheckColumnExists(dataTable, QueryIdColumnName);
            CheckColumnExists(dataTable, CaptionColumnName);

            string rowFilter = String.Format("{0} = {1} and blnShow = 1 ", QueryIdColumnName, queryId);
            var dataView = new DataView(
                dataTable,
                rowFilter,
                EnCaptionColumnName,
                DataViewRowState.CurrentRows);

            foreach (DataRowView row in dataView)
            {
                string msg = EidssMessages.Get("msgEmptyRow", "One of rows has empty translation {0}");

                if (Utils.IsEmpty(row[AliasColumnName]))
                {
                    throw new AvrDbException(String.Format(msg, AliasColumnName));
                }
                if (Utils.IsEmpty(row[CaptionColumnName]))
                {
                    throw new AvrDbException(String.Format(msg, CaptionColumnName));
                }

                string key = row[AliasColumnName].ToString();
                string value = row[CaptionColumnName].ToString();
                if (translations.ContainsKey(key))
                {
                    throw new AvrDbException(String.Format("Dublicate row with {0} = '{1}' in table of translations",
                        AliasColumnName, key));
                }
                translations.Add(key, value);
            }

            return translations;
        }

        public static Dictionary<PersonalDataGroup, List<string>> GetPersonalDataGroups(long queryId)
        {
            var groups = new Dictionary<PersonalDataGroup, List<string>>();

            DataTable dataTable = QueryLookupHelper.GetQueryPersonalDataGroupTable();
            if (dataTable == null)
            {
                throw new AvrDbException("Cannot get Personal Data Group from Database");
            }

            CheckColumnExists(dataTable, AliasColumnName);
            CheckColumnExists(dataTable, QueryIdColumnName);
            CheckColumnExists(dataTable, PersonalDataGroupIdColumnName);

            string rowFilter = String.Format("{0} = {1} and blnShow = 1 ", QueryIdColumnName, queryId);
            var dataView = new DataView(
                dataTable,
                rowFilter,
                PersonalDataGroupIdColumnName,
                DataViewRowState.CurrentRows);

            foreach (DataRowView row in dataView)
            {
                var key = (PersonalDataGroup) (long) row[PersonalDataGroupIdColumnName];

                List<string> values;
                if (!groups.TryGetValue(key, out values))
                {
                    values = new List<string>();
                    groups.Add(key, values);
                }
                values.Add(row[AliasColumnName].ToString());
            }

            return groups;
        }

        public static string GetQueryName(long queryId)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                AvrQueryLookup.Accessor accessor = AvrQueryLookup.Accessor.Instance(null);
                List<AvrQueryLookup> lookup = accessor.SelectLookupList(manager, queryId);
                AvrQueryLookup query = lookup.SingleOrDefault();
                return query == null
                    ? "NO_QUERY_FOUND_WITH_ID_" + queryId
                    : query.QueryName;
            }
        }

        private static void CheckColumnExists(DataTable dataTable, string alias)
        {
            Utils.CheckNotNull(dataTable, "dataTable");
            Utils.CheckNotNullOrEmpty(alias, "alias");

            if (!dataTable.Columns.Contains(alias))
            {
                throw new AvrDbException(String.Format("Column {0} not found in table of translations", alias));
            }
        }
    }
}