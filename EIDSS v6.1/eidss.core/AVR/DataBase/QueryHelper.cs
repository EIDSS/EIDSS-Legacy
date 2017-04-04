using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using BLToolkit.Data;

namespace eidss.model.AVR.DataBase
{
    public static class QueryHelper
    {
        public const string ColumnAlias = "FieldAlias";
        public const string ColumnGisReferenceType = "idfsGISReferenceType";
        public const string CopySuffix = "_Copy";
        public const string GisSuffix = "_ShortGISName";
        private static readonly int m_CommandTimeout;

        static QueryHelper()
        {
            m_CommandTimeout = Config.GetIntSetting("AvrCommandTimeout", 2400);
        }

        public static T GetInnerQueryResult<T>(DbManagerProxy manager, string queryString, string lang, Func<DbManager, T> commandExecutor)
        {
            Utils.CheckNotNull(manager, "manager");
            Utils.CheckNotNull(lang, "lang");
            Utils.CheckNotNullOrEmpty(queryString, "queryString");
            Utils.CheckNotNull(commandExecutor, "commandExecutor");

            int oldTimeout = manager.CommandTimeout;
            try
            {
                manager.CommandTimeout = m_CommandTimeout;
                manager.BeginTransaction(IsolationLevel.ReadUncommitted);
                DbManager command = manager.SetCommand(queryString,
                    manager.Parameter("LangID", lang));
                T result = commandExecutor(command);

                manager.CommitTransaction();
                return result;
            }
            catch (Exception)
            {
                manager.RollbackTransaction();
                throw;
            }
            finally
            {
                manager.CommandTimeout = oldTimeout;
            }
        }

        public static void DropAndCreateArchiveQuery(DbManagerProxy manager, DbManagerProxy archiveManager, long queryId)
        {
            Utils.CheckNotNull(manager, "manager");
            Utils.CheckNotNull(archiveManager, "archiveManager");
            if (manager.Connection.Database == archiveManager.Connection.Database)
            {
                return;
            }

            const string dropFunctionFormat =
                @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT')) 
                DROP FUNCTION [dbo].[{0}] ";

            const string dropViewFormat =
                @"IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[{0}]'))
                DROP VIEW [dbo].[{0}]";

            List<string> queryFunctionNames = GetSubQueryFunctionName(manager, queryId);
            queryFunctionNames.Add(GetQueryFunctionName(manager, queryId));

            foreach (string queryFunctionName in queryFunctionNames)
            {
                if (!queryFunctionName.StartsWith("fn"))
                {
                    throw new AvrDbException(string.Format("Query function {0} should starts with 'fn'", queryFunctionName));
                }
                string queryViewName = "vw" + queryFunctionName.Remove(0, 2);
                string dropFunctionText = string.Format(dropFunctionFormat, queryFunctionName);
                string dropViewText = string.Format(dropViewFormat, queryViewName);
                string createFunctionText = GetQueryFunctionText(manager, queryFunctionName);
                string createViewText = GetQueryFunctionText(manager, queryViewName);

                archiveManager.SetCommand(dropViewText).ExecuteNonQuery();
                archiveManager.SetCommand(createViewText).ExecuteNonQuery();
                archiveManager.SetCommand(dropFunctionText).ExecuteNonQuery();
                if (!string.IsNullOrEmpty(createFunctionText))
                {
                    archiveManager.SetCommand(createFunctionText).ExecuteNonQuery();
                }
            }
        }

        public static string GetQueryText(DbManagerProxy manager, long queryId, bool createFieldsCopy)
        {
            Utils.CheckNotNull(manager, "manager");

            string queryText = "SELECT 0 ";
            if (queryId > 0)
            {
                DataTable translations = GetQueryFieldTranslationLookup(manager, queryId, Localizer.lngEn);
                var fieldList = new StringBuilder();
                if (translations.Rows.Count == 0)
                {
                    fieldList.Append("*");
                }
                else
                {
                    string comma = String.Empty;
                    foreach (DataRow row in translations.Rows)
                    {
                        string alias = Utils.Str(row[ColumnAlias]);

                        if (createFieldsCopy)
                        {
                            fieldList.AppendFormat(" {0}[{1}], [{1}] as [{1}{2}]", comma, alias, CopySuffix);
                        }
                        else
                        {
                            fieldList.AppendFormat(" {0}[{1}]", comma, alias);
                        }
                        if (!Utils.IsEmpty(row[ColumnGisReferenceType]))
                        {
                            fieldList.AppendFormat(" ,[{0}{1}] as [{0}{1}]", alias, GisSuffix);
                        }
                        comma = ", ";
                    }
                }

                string functionName = GetQueryFunctionName(manager, queryId);
                queryText = String.Format("select {0} from {1}(@LangID) ", fieldList, functionName);
            }
            return queryText;
        }

        public static string GetQueryFunctionName(DbManagerProxy manager, long queryId)
        {
            Utils.CheckNotNull(manager, "manager");

            DbManager command = manager.SetCommand(@"SELECT [strFunctionName]  FROM [dbo].[tasQuery] where [idflQuery] = @idflQuery",
                manager.Parameter("idflQuery", queryId));
            var functionName = command.ExecuteScalar<string>();
            return functionName;
        }

        public static List<string> GetSubQueryFunctionName(DbManagerProxy manager, long queryId)
        {
            Utils.CheckNotNull(manager, "manager");

            //  return  new List<string>();
            DbManager command = manager.SetSpCommand("spAsSubQuerySelectLookup",
                manager.Parameter("LangID", Localizer.DefaultLanguage),
                manager.Parameter("ID", queryId));
            DataTable table = command.ExecuteDataTable();
            var result = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                result.Add(Utils.Str(row["strSubQueryFunctionName"]));
            }
            return result;
        }

        public static DataTable GetQueryFieldTranslationLookup(DbManagerProxy manager, long queryId, string lang)
        {
            Utils.CheckNotNull(manager, "manager");
            Utils.CheckNotNullOrEmpty(lang, "lang");

            DbManager command = manager.SetSpCommand("spAsQuerySearchFieldSelectLookup",
                manager.Parameter("LangID", lang),
                manager.Parameter("QueryID", queryId));
            return command.ExecuteDataTable();
        }

        public static string GetQueryFunctionText(DbManagerProxy manager, string spName)
        {
            Utils.CheckNotNull(manager, "manager");
            Utils.CheckNotNullOrEmpty(spName, "spName");

            DbManager command = manager.SetSpCommand("spAsGetFunctionText", manager.Parameter("name", spName));
            var functionText = command.ExecuteScalar<string>();
            return functionText;
        }

        /// <summary>
        /// </summary>
        /// <param name="originalView"></param>
        /// It is assumed that originalView is SearchField lookup taken from LookupCache
        /// <returns></returns>
        public static DataView CreateSearchFieldsLookupView(DataView originalView)
        {
            DataTable table = originalView.Table.Copy();
            table.PrimaryKey = new DataColumn[0]; //new[] { table.Columns["idfsSearchField"], table.Columns["strSearchFieldAlias"] };
            DataTable copyTable = table.Copy();
            table.BeginLoadData();
            foreach (DataRow row in copyTable.Rows)
            {
                row["strSearchFieldAlias"] = row["strSearchFieldAlias"] + CopySuffix;
                table.ImportRow(row);
            }
            table.EndLoadData();
            var view = new DataView(table) {Sort = "strSearchFieldAlias"};
            return view;
        }
    }
}