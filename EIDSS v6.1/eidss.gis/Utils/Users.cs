using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using bv.common.db.Core;
using eidss.gis.Data;

namespace eidss.gis.Utils
{
    static class Users
    {
        private static readonly string m_ConnectionString = ConnectionManager.DefaultInstance.ConnectionString;

        static public string GetUserName(long id)
        {
            object result;
            using (var conn = new SqlConnection(m_ConnectionString))
            {
                var strSQL = string.Format("SELECT TOP 1 strAccountName FROM tstUserTable WHERE idfUserID = {0}", id);
                conn.Open();
                result=SqlExecHelper.SqlExecScalar(conn, strSQL);
                conn.Close();
            }

            return result.ToString();
        }
    }
}
