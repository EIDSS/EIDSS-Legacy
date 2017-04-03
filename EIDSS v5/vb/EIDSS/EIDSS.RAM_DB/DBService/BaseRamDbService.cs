using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using DevExpress.Charts.Native;
using Ionic.Zlib;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.model.Model.Core;

namespace EIDSS.RAM_DB.DBService
{
    public class BaseRamDbService : BaseDbService
    {
        private long m_QueryID = -1;
        private int m_CommandTimeout;

        public BaseRamDbService()
        {
            UseDatasetCopyInPost = false;
            m_CommandTimeout = Config.GetIntSetting("AvrCommandTimeout", 1200);
        }

        public long QueryID
        {
            get { return m_QueryID; }
            set { m_QueryID = value; }
        }

        public override DataSet GetDetail(object id)
        {
            var ds = new DataSet();
            m_ID = id;
            return (ds);
        }

        public override bool PostDetail(DataSet dataSet, int PostType, IDbTransaction transaction)
        {
            return true;
        }

        public override void AcceptChanges(DataSet ds)
        {
            // this method shoul duplicate base method bu WITHOUT line m_IsNewObject = false
            foreach (DataTable table in ds.Tables)
            {
                if (!SkipAcceptChanges(table))
                {
                    table.AcceptChanges();
                }
            }
            RaiseAcceptChangesEvent(ds);
        }

        internal void ChangeIdForNewObject(long newId)
        {
            m_ID = m_IsNewObject
                       ? newId
                       : CorrectId(m_ID, newId);
        }

        internal static long CorrectId(object id, long defaultId)
        {
            if (Utils.IsEmpty(id) || (!(id is long)) || ((long) id <= 0))
            {
                id = defaultId;
            }
            return (long) id;
        }

        public string GetQueryFunctionText(string spName)
        {
            IDbCommand cmd = CreateCommand("spAsGetFunctionText", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            AddAndCheckParam(cmd, "@name", spName);
            string functionText = Utils.Str(cmd.ExecuteScalar());
            return functionText;
        }

        public void ExecuteNonQuery(string sql, IDbConnection connection)
        {
            if (connection == null)
            {
                connection = Connection;
            }
            lock (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                IDbCommand cmd = CreateCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetInnerQueryResult(string queryString, IDbConnection conn = null)
        {
            var dataTable = new DataTable();
            var dataSet = new DataSet("result");
            dataSet.Tables.Add(dataTable);
            dataSet.EnforceConstraints = false;

            // if connection not specified we should use default Connection
            if (conn == null)
            {
                conn = Connection;
            }
            lock (conn)
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                // Set IsolationLevel ReadUncommitted for optimization
                using (IDbTransaction transaction = conn.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        IDbCommand cmd = CreateCommand(queryString, conn, transaction);
                        cmd.CommandTimeout = m_CommandTimeout;
                        AddAndCheckParam(cmd, "@LangID", ModelUserContext.CurrentLanguage);

                        DbDataAdapter queryAdapter = CreateAdapter(cmd);
                        
                        queryAdapter.Fill(dataTable);
                        dataTable.Constraints.Clear();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return dataTable;
        }

        #region Helper Methods

        public static string UncompressString(byte[] compressed)
        {
            try
            {
              //  throw new ApplicationException("test");
                if (compressed.Length == 0)
                {
                    return string.Empty;
                }

                string uncompressed = ZlibStream.UncompressString(compressed);
                // if it contains old format value (xml)
                if (uncompressed.Length == 0 || uncompressed[0] == '<')
                {
                    return uncompressed;
                }
                // if it contains new format value (base64 string)
                byte[] encodedDataAsBytes = Convert.FromBase64String(uncompressed);
                return Encoding.Unicode.GetString(encodedDataAsBytes);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return string.Empty;
            }
        }

        public static byte[] CompressString(string uncompressed)
        {
            try
            {
                byte[] encodedBytes = Encoding.Unicode.GetBytes(uncompressed);
                string encodedString = Convert.ToBase64String(encodedBytes);
                byte[] compressedBytes = ZlibStream.CompressString(encodedString);
                return compressedBytes;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return new byte[0];
            }
        }

        public void AddAndCheckParam(IDbCommand cmd, DataColumn paramColumn, object paramValue)
        {
            Utils.CheckNotNullOrEmpty(paramColumn.ColumnName, "paramColumn.ColumnName");
            AddAndCheckParam(cmd, string.Format("@{0}", paramColumn.ColumnName), paramValue);
        }

        public void AddAndCheckParam(IDbCommand cmd, string paramName, object paramValue)
        {
            AddAndCheckParam(cmd, paramName, paramValue, ParameterDirection.Input);
        }

        public void AddAndCheckParam(IDbCommand cmd, string paramName, object paramValue, ParameterDirection direction)
        {
            Utils.CheckNotNull(cmd, "cmd");
            Utils.CheckNotNullOrEmpty(paramName, "paramName");
            Utils.CheckNotNull(paramValue, "paramValue");

            AddParam(cmd, paramName, paramValue, ref m_Error, direction);

            if (m_Error != null)
            {
                throw new RamDbException(m_Error.Text);
            }
        }

        #endregion
    }
}
