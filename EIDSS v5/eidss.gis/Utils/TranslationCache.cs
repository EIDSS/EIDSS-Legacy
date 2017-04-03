using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using bv.common.Core;
using eidss.gis.common;
using eidss.gis.Data;

namespace eidss.gis.Utils
{
    public class TranslationCache
    {
        /// <summary>
        /// Cache dictionary
        /// Key - string value= langId+GISReferenceType.ToString();
        /// </summary>
        private static readonly Dictionary<string, DataTable> m_TranlationTablesCache=new Dictionary<string, DataTable>();
        

        /// <summary>
        /// Load translation table from DB
        /// </summary>
        /// <param name="connString">DB Conn Str</param>
        /// <param name="gisReferenceType">GisReference type </param>
        /// <param name="langId">Lang Id</param>
        /// <returns></returns>
        private static DataTable LoadTranslation(string connString, long gisReferenceType, string langId)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var spParams = new Dictionary<string, object> {{"@LangID", langId}, {"@type", gisReferenceType}};
                var table = SqlExecHelper.SqlExecSp(connection, "spGisLocalizedLabels", spParams);
                table.PrimaryKey = new[]{table.Columns[0]};
                return table;
            }
        }


        /// <summary>
        /// Return translation table from cache and load it if had not been loaded previously
        /// </summary>
        /// <param name="connString">DB Conn Str</param>
        /// <param name="gisReferenceType">GisReference type</param>
        /// <param name="langId">Lang Id</param>
        /// <returns></returns>
        public static DataTable GetTranslation(string connString, long gisReferenceType, string langId)
        {
            var cacheKey = langId + gisReferenceType;

            if (!m_TranlationTablesCache.ContainsKey(cacheKey))
                lock (m_TranlationTablesCache) //load new translation table from db
                {
                    if(!m_TranlationTablesCache.ContainsKey(cacheKey))
                    {
                        DataTable translationTable = LoadTranslation(connString, gisReferenceType, langId);
                        m_TranlationTablesCache.Add(cacheKey, translationTable);
                    }
                }
                
            return m_TranlationTablesCache[cacheKey];
        }


        /// <summary>
        /// Clear cache for settlement tables only
        /// </summary>
        public static void ClearSettlementsCache()
        {
            string settlementCode = GisDbType.RftSettlement.ToString();

            foreach (KeyValuePair<string, DataTable> keyValuePair in m_TranlationTablesCache)
            {
                if(keyValuePair.Key.IndexOf(settlementCode)>=0)
                {
                    m_TranlationTablesCache.Remove(keyValuePair.Key);
                }
            } 
        }

        /// <summary>
        /// Cleare translation tables cache
        /// </summary>
        public static void ClearCache()
        {
            m_TranlationTablesCache.Clear();
            MemoryManager.Flush();
        }

        /// <summary>
        /// Get system code for language
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="connString">DB comm str</param>
        /// <returns></returns>
        public static long GetLanguageCode(string lang, string connString)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var id=(long)SqlExecHelper.SqlExecScalar(connection, string.Format("select dbo.fnGetLanguageCode('{0}')", lang));
                return id;
            }
        }
    }
}
