using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GIS_V4.Forms;
using bv.common.Configuration;
using bv.common.db.Core;
using eidss.gis.common;
using eidss.gis.Forms;
using bv.common.win;
using SharpMap.Geometries;

namespace eidss.gis
{
    /// <summary>
    /// Public GIS functions for EIDSS desktop client
    /// </summary>
    public class GisInterface
    {
        /// <summary>
        /// Get coordinates of settlement
        /// </summary>
        /// <param name="settlementID">settlement id</param>
        /// <param name="x">x or Longitude in Geo coordinates</param>
        /// <param name="y">y or Latitude in Geo coordinates</param>
        /// <returns>true if settlement exists</returns>
        public static bool GetSettlementCoordinates(long settlementID, out double x, out double y)
        {
            string connectionString = ConnectionManager.DefaultInstance.ConnectionString;
            return CoordinatesUtils.GetSettlementCoordinates(connectionString, settlementID, out x, out y);
        }

        /// <summary>
        /// Get coordinates of administrative unit
        /// </summary>
        /// <param name="id">Administrative unit ID</param>
        /// <param name="x">out X</param>
        /// <param name="y">out Y</param>
        /// <returns>True if exists</returns>
        public static bool GetAdminUnitCoordinates(long id, out double x, out double y)
        {
            string connectionString = ConnectionManager.DefaultInstance.ConnectionString;
            return CoordinatesUtils.GetAdminUnitCoordinates(connectionString, id, out x, out y);
        }

        /// <summary>
        /// Get relative coordinates
        /// </summary>
        /// <param name="settlementID">settlement id</param>
        /// <param name="azimuth">Azimuth from North direction in decimal degree</param>
        /// <param name="distance">Distance in kilometers</param>
        /// <param name="x">x or Longitude in Geo coordinates</param>
        /// <param name="y">y or Latitude in Geo coordinates</param>
        /// <returns></returns>
        public static bool GetRelativeCoordinates(long settlementID, double azimuth, double distance, out double x, out double y)
        {
            string connectionString = ConnectionManager.DefaultInstance.ConnectionString;
            return CoordinatesUtils.GetRelativeCoordinates(connectionString, settlementID, azimuth, distance * 1000, out x, out y);
        }


        /// <summary>
        /// Show form for set case location 
        /// </summary>
        /// <param name="countryID">Id of country for auto zoom</param>
        /// <param name="regionID">Id of region for auto zoom</param>
        /// <param name="rayonID">Id of rayon for auto zoom</param>
        /// <param name="settlementID">Id of settlement for auto zoom</param>
        /// <param name="x">longitude, if case already has coordinates</param>
        /// <param name="y">latitude, if case already has coordinates</param>
        /// <param name="onCaseHandler"></param>
        public static void SetCaseLocation(long countryID, long regionID, long rayonID, long settlementID, decimal x,
                                           decimal y, SetCaseMapForm.OnCaseEvenHandler onCaseHandler)
        {
            bv.common.Core.Utils.CheckNotNull(onCaseHandler, "onCaseHandler");

            try
            {
                var mapForm = new SetCaseMapForm();
                using (new TemporaryWaitCursor())
                {
                    mapForm.OnCase += onCaseHandler;
                    mapForm.InitAdminBBox = Extents.GetMinimalExtent(ConnectionManager.DefaultInstance.ConnectionString,
                                                                     countryID == 0 ? null : (long?) countryID,
                                                                     regionID == 0 ? null : (long?) regionID,
                                                                     rayonID == 0 ? null : (long?) rayonID,
                                                                     settlementID == 0 ? null : (long?) settlementID);
                    if (x != 0 && y != 0)
                        mapForm.InitWgsPoint = new Point((double) x, (double) y);
                    else
                        mapForm.InitWgsPoint = null;
                }
                mapForm.ShowDialog();
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                    throw;
                ErrorForm.ShowError(ex);
            }
        }

        private static string GetWKBTableName(DataTable dataTable, string connection)
        {
            try
            {
                var objId = dataTable.Rows[0]["id"];

                if (objId.ToString() == string.Empty) return string.Empty;

                long id;
                if (!long.TryParse(objId.ToString(), out id)) return string.Empty;

                var sqlConnection = new SqlConnection(connection);

                var sql = "SELECT idfsGISReferenceType FROM gisBaseReference WHERE (idfsGISBaseReference = " + id + ")";

                sqlConnection.Open();
                var sqlCommand = new SqlCommand(sql, sqlConnection);
                var tId = sqlCommand.ExecuteScalar();
                sqlConnection.Close();

                long idType;
                if (!long.TryParse(tId.ToString(), out idType)) return string.Empty;

                switch (idType)
                {
                    case 19000004:
                        return "gisWKBSettlement";
                    case 19000003:
                        return "gisWKBRegion";
                    case 19000002:
                        return "gisWKBRayon";
                    default:
                        return string.Empty;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable TransposeDataTable(DataTable data, string connection)
        {
            var trData = new DataTable();

            trData.Columns.Add("id", typeof(long));
            trData.Columns.Add("x", typeof(double));
            trData.Columns.Add("y", typeof(double));
            trData.Columns.Add("human", typeof(double));
            trData.Columns.Add("vet", typeof(double));
            trData.Columns.Add("vector", typeof(double));
            trData.Columns.Add("avian", typeof(double));
            trData.Columns.Add("livestock", typeof(double));
            trData.Columns.Add("info", typeof(string));

            if (GetWKBTableName(data, connection) == string.Empty)
            {
                #region (x,y)-based
                var dataAsEnum = data.AsEnumerable();
                var query = from d in dataAsEnum
                            group d by (((double)d["x"]).ToString("F4") + ((double)d["y"]).ToString("F4"))
                                into caseCroup
                                select new { id = caseCroup.Key, data = caseCroup };

                foreach (var cases in query)
                {
                    double hum = 0, vet = 0, vector = 0, avian = 0, livestock = 0;
                    string info = string.Empty;
                    double x = 0, y = 0;
                    foreach (var d in cases.data)
                    {
                        info = d["info"].ToString();
                        x = (double)d["x"];
                        y = (double)d["y"];

                        var type = (MapControl.CaseType)d["type"];
                        switch (type)
                        {
                            case MapControl.CaseType.Hyman:
                                hum = (double)d["value"];
                                break;
                            case MapControl.CaseType.Vet:
                                vet = (double)d["value"];
                                break;
                            case MapControl.CaseType.Vector:
                                vector = (double)d["value"];
                                break;
                            case MapControl.CaseType.Avian:
                                avian = (double)d["value"];
                                break;
                            case MapControl.CaseType.Livestock:
                                livestock = (double)d["value"];
                                break;
                            default:
                                break;
                        }
                    }
                    trData.Rows.Add(null, x, y, hum, vet, vector, avian, livestock, info);
                }
                #endregion
            }
            else
            {
                #region admin-based

                var dataAsEnum = data.AsEnumerable();
                var query = from d in dataAsEnum
                            group d by d["id"]
                                into caseCroup
                                select new { id = caseCroup.Key, data = caseCroup };

                foreach (var cases in query)
                {
                    double hum = 0, vet = 0, vector = 0, avian = 0, livestock = 0;
                    string info = string.Empty;
                    foreach (var d in cases.data)
                    {
                        info = d["info"].ToString();
                        var type = (MapControl.CaseType)d["type"];
                        switch (type)
                        {
                            case MapControl.CaseType.Hyman:
                                hum = (double)d["value"];
                                break;
                            case MapControl.CaseType.Vet:
                                vet = (double)d["value"];
                                break;
                            case MapControl.CaseType.Vector:
                                vector = (double)d["value"];
                                break;
                            case MapControl.CaseType.Avian:
                                avian = (double)d["value"];
                                break;
                            case MapControl.CaseType.Livestock:
                                livestock = (double)d["value"];
                                break;
                            default:
                                break;
                        }
                    }
                    trData.Rows.Add(cases.id, null, null, hum, vet, vector, avian, livestock, info);
                }
                #endregion
            }
            return trData;
        }

    }

}
