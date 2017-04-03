using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SharpMap.Geometries;
using bv.common.db.Core;

namespace eidss.gis.Data
{
    public static class SqlExecHelper
    {

        static public object SqlExecScalar(SqlConnection conn, string sql, SqlTransaction trans = null)
        {
            using(var tmpCommand = conn.CreateCommand())
            {
                tmpCommand.CommandText = sql;
                tmpCommand.Transaction = trans;
                return tmpCommand.ExecuteScalar();
            }
        }

        static public void SqlExecNonQuery(SqlConnection conn, string sql, SqlTransaction trans = null)
        {
            using (var tmpCommand = conn.CreateCommand())
            {
                tmpCommand.CommandText = sql;
                tmpCommand.Transaction = trans;
                tmpCommand.ExecuteNonQuery();
            }
        }

        static public SqlDataReader SqlExecReader(SqlConnection conn, string sql, SqlTransaction trans = null)
        {
            using(var tmpCommand = conn.CreateCommand())
            {
                tmpCommand.CommandText = sql;
                tmpCommand.Transaction = trans;
                return tmpCommand.ExecuteReader();
            }
        }

        static public DataTable SqlExecTable(SqlConnection conn, string sql, SqlTransaction trans = null)
        {
            using(var tmpCommand = conn.CreateCommand())
            {
                tmpCommand.CommandText = sql;
                tmpCommand.Transaction = trans;
                
                DataSet ds = new DataSet();
                
                using(var adapter = new SqlDataAdapter(tmpCommand))
                {
                    adapter.Fill(ds);
                }

                if(ds.Tables.Count>0)
                    return ds.Tables[0];
                else
                    return null;
            }
        }

        static public DataTable SqlExecSp(SqlConnection conn, string spName, Dictionary<string, object> spParams = null, SqlTransaction trans = null)
        {
            using(var tmpCommand = conn.CreateCommand())
            {
                tmpCommand.CommandText = spName;
                tmpCommand.CommandType = CommandType.StoredProcedure;
                tmpCommand.Transaction = trans;
                
                if(spParams!=null)
                    foreach (var spParam in spParams)
                    {
                        var param = tmpCommand.CreateParameter();
                        param.ParameterName = spParam.Key;
                        param.Value = spParam.Value;
                        tmpCommand.Parameters.Add(param);
                    }

                var ds = new DataSet();
                using(var adapter = new SqlDataAdapter(tmpCommand))
                {
                    adapter.Fill(ds);
                }
                if(ds.Tables.Count>0)
                    return ds.Tables[0];
                else
                    return null;
            }
        }

        static public bool SqlGeometryValidation(SqlConnection conn, Geometry geometry)
        {
            var sql = string.Format("SELECT geometry::STGeomFromText('{0}', 0).STIsValid();", geometry.AsText());
            conn.Open();
            var valid = (bool)SqlExecScalar(conn, sql);
            conn.Close();
            return valid;
        }

    }
}
