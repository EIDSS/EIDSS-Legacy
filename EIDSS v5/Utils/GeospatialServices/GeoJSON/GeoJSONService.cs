using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Types;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Text.RegularExpressions;

namespace GeospatialServices.GeoJSON
{
    public class GeoJSONService
    {
        /// <summary>
        /// Executes a database query given a GeoJSON input and returns a GeoJSON output.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="connection"></param>
        /// <param name="provider"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string DatabaseRequest(string json, string connection, string provider, string sql)
        {
            string result = null;
            SqlGeometry sqlGeom = GeospatialServices.GeoJSON.GeoJSON.JSONToGeometry(json);
            Dictionary<string, object> parameters = GeospatialServices.GeoJSON.GeoJSON.JSONToProperties(json);

            System.Data.DataSet ds = new DataSet();
            try
            {
                DbProviderFactory f = DbProviderFactories.GetFactory(provider);
                DbConnection dbConnection = f.CreateConnection();
                dbConnection.ConnectionString = connection;
                DbCommand command = f.CreateCommand();
                command.CommandText = sql;
                command.Connection = dbConnection;

                if (command.CommandText.Contains("@wkt"))
                {
                    DbParameter dbSqlGeometryParameter = command.CreateParameter();
                    dbSqlGeometryParameter.ParameterName = "@wkt";
                    dbSqlGeometryParameter.Value = sqlGeom.ToString();
                    command.Parameters.Add(dbSqlGeometryParameter);
                }

                if (command.CommandText.Contains("@srid"))
                {
                    DbParameter dbSridParameter = command.CreateParameter();
                    dbSridParameter.ParameterName = "@srid";
                    dbSridParameter.Value = sqlGeom.STSrid;
                    command.Parameters.Add(dbSridParameter);
                }

                foreach (KeyValuePair<string, object> item in parameters)
                {
                    // sanitise the key value pairs
                    if (!Regex.IsMatch(item.Key, @"^[a-zA-Z_'.\s]{1,50}$"))
                        throw new ArgumentException("Invalid Key value provided in GeoJSON");

                    if ( item.Value is string)
                    {
                        if (!Regex.IsMatch((string)item.Value, @"^[a-zA-Z_'.\s]{1,80}$"))
                            throw new ArgumentException("Invalid Value value provided in GeoJSON");
                    }

                    if (command.CommandText.Contains("@" + item.Key))
                    {
                        DbParameter dbParameter = command.CreateParameter();
                        dbParameter.ParameterName = "@" + item.Key;
                        dbParameter.Value = item.Value;
                        command.Parameters.Add(dbParameter);
                    }
                }

                DbDataAdapter da = f.CreateDataAdapter();
                da.SelectCommand = command;
                da.Fill(ds);
                dbConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }

            result = GeospatialServices.GeoJSON.GeoJSON.DataSetToJSON(ds);

            return result;
        }


        /// <summary>
        /// Method handles geo-processing requests that do not need to execute in SQL Server.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string GeoprocessingRequest(string method, string json)
        {
            string result = null;
            SqlGeometry sqlGeom = GeospatialServices.GeoJSON.GeoJSON.JSONToGeometry(json);
            Dictionary<string, object> parameters = GeospatialServices.GeoJSON.GeoJSON.JSONToProperties(json);

            if (method == "buffer")
            {
                double bufferSize = Convert.ToDouble(parameters["BufferSize"]);
                result = GeospatialServices.GeoJSON.GeoJSON.SqlGeometryToJSON(sqlGeom.STBuffer(bufferSize));
            }
            return result;
        }
    }
}
