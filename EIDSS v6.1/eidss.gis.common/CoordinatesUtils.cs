using System;
using System.Data;
using System.Data.SqlClient;
using DotSpatial.Projections;
using eidss.gis.common.Data;
using GIS_V4.Common;
using SharpMap.Geometries;
using GIS_V4;
using System.Globalization;

namespace eidss.gis.common
{
    public static class CoordinatesUtils
    {
        /// <summary>
        /// Returns geographical coordinates for the settlement
        /// </summary>
        /// <param name="connectionString">Connection string of EIDSS DB</param>
        /// <param name="settlementID">Id of the settlement (idfsGeoObject)</param>
        /// <param name="x">Longitude of the settlement</param>
        /// <param name="y">Latitude of the settlement</param>
        /// <returns>True if settlement found, else - False</returns>
        public static bool GetSettlementCoordinates(string connectionString, long settlementID, out double x,
                                                     out double y)
        {
            x=y=0;
            var z=0;
            return GetSettlementCoordinates(connectionString, settlementID, out x, out y, out z);            
        }
        
        /// <summary>
        /// Returns geographical coordinates and elevation for the settlement
        /// </summary>
        /// <param name="connectionString">Connection string of EIDSS DB</param>
        /// <param name="settlementID">Id of the settlement (idfsGeoObject)</param>
        /// <param name="x">Longitude of the settlement</param>
        /// <param name="y">Latitude of the settlement</param>
        /// <param name="z">Settlement elevation</param>
        /// <returns>True if settlement found, else - False</returns>
        public static bool GetSettlementCoordinates(string connectionString, long settlementID, out double x,
                                                     out double y, out int z)
        {
            x=y=z=0;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string fastQuery =
                    string.Format("SELECT geomShape.STX, geomShape.STY, intElevation FROM gisWKBSettlement WHERE idfsGeoObject={0}",
                                  settlementID);
                using(var cmd=new SqlCommand(fastQuery, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        x = reader.GetDouble(0);
                        y = reader.GetDouble(1);

                        if (!reader.IsDBNull(2))
                        {
                            z=reader.GetInt32(2);
                        }
                                               
                                                
                        //Geoms in DB in spherical mercator. Transform to wgs
                        var projectedPoint = GeometryTransform.TransformPoint(new Point(x, y), 
                                                       CoordinateSystems.SphericalMercatorCS,
                                                       CoordinateSystems.WGS84);
                        x = projectedPoint.X;
                        y = projectedPoint.Y;
                        return true;
                    }
                    return false;
                }
            }
        }

        /// <summary>
        ///   Get table using IDs in the table
        /// </summary>
        /// <param name="dataTable"> Data table </param>
        /// <param name="connection"> Connection string </param>
        /// <returns> Returns table name or string.Empty </returns>
        public static string GetWKBTableName(DataTable dataTable, string connection)
        {
            string result = string.Empty;
            if (dataTable.Rows.Count > 0)
            {
                object objId = dataTable.Rows[0]["id"];
                if (objId.ToString() == string.Empty)
                {
                    return string.Empty;
                }
                var id = (long) objId;
                var sqlConnection = new SqlConnection(connection);

                sqlConnection.Open();
                var sqlCommand1 =
                    new SqlCommand("SELECT idfsGeoObject FROM gisWKBRegion WHERE (idfsGeoObject = " + id + ")",
                                   sqlConnection);
                SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
                if (sqlDataReader1.HasRows)
                {
                    result = "gisWKBRegion";
                }
                sqlConnection.Close();

                if (result == string.Empty)
                {
                    sqlConnection.Open();
                    var sqlCommand2 =
                        new SqlCommand("SELECT idfsGeoObject FROM gisWKBDistrict WHERE (idfsGeoObject = " + id + ")",
                                       sqlConnection);
                    SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                    if (sqlDataReader2.HasRows)
                    {
                        result = "gisWKBDistrict";
                    }
                    sqlConnection.Close();
                }

                if (result == string.Empty)
                {
                    sqlConnection.Open();
                    var sqlCommand2 =
                        new SqlCommand("SELECT idfsGeoObject FROM gisWKBRayon WHERE (idfsGeoObject = " + id + ")",
                                       sqlConnection);
                    SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                    if (sqlDataReader2.HasRows)
                    {
                        result = "gisWKBRayon";
                    }
                    sqlConnection.Close();
                }

                if (result == string.Empty)
                {
                    sqlConnection.Open();
                    var sqlCommand3 =
                        new SqlCommand("SELECT idfsGeoObject FROM gisWKBSettlement WHERE (idfsGeoObject = " + id + ")",
                                       sqlConnection);
                    SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
                    if (sqlDataReader3.HasRows)
                    {
                        result = "gisWKBSettlement";
                    }
                    sqlConnection.Close();
                }
            }

            return result;
        }

        /// <summary>
        /// Returns coordinate of settlement or centroid of region/district
        /// </summary>
        /// <param name="connection">Connection string</param>
        /// <param name="id">Id of administrative unit (settlement, region or district)</param>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <returns>True, if admin unit exists</returns>
        public static bool GetAdminUnitCoordinates(string connection, long id, out double x, out double y)
        {
            x = 0;
            y = 0;
            var result = false;
            
            try
            {
                string tblName = string.Empty;
                var sqlConnection = new SqlConnection(connection);

                sqlConnection.Open();
                var sqlCommand1 =
                    new SqlCommand("SELECT idfsGeoObject FROM gisWKBRegion WHERE (idfsGeoObject = " + id + ")",
                                   sqlConnection);
                SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
                if (sqlDataReader1.HasRows)
                    tblName = "gisWKBRegion";
                sqlConnection.Close();

                if (tblName == string.Empty)
                {
                    sqlConnection.Open();
                    var sqlCommand2 =
                        new SqlCommand("SELECT idfsGeoObject FROM gisWKBRayon WHERE (idfsGeoObject = " + id + ")",
                                       sqlConnection);
                    SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                    if (sqlDataReader2.HasRows)
                        tblName = "gisWKBRayon";
                    sqlConnection.Close();
                }

                if (tblName == string.Empty)
                {
                    sqlConnection.Open();
                    var sqlCommand3 =
                        new SqlCommand("SELECT idfsGeoObject FROM gisWKBSettlement WHERE (idfsGeoObject = " + id + ")",
                                       sqlConnection);
                    SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
                    if (sqlDataReader3.HasRows)
                        tblName = "gisWKBSettlement";
                    sqlConnection.Close();
                }

                //tblName equal to one of the table names or string.Empry
                sqlConnection.Open();
                switch (tblName)
                {
                    case "gisWKBSettlement":
                        //settlements
                        result = GetSettlementCoordinates(connection, id, out x, out y);
                        break;
                    case "gisWKBRayon":
                    case "gisWKBRegion":
                        //regions & districts
                        var point = Extents.GetGeomById(sqlConnection, tblName, id).GetBoundingBox().GetCentroid();
                        //Geoms in DB in spherical mercator. Transform to wgs
                        var projectedPoint = GeometryTransform.TransformPoint(point,
                                                       CoordinateSystems.SphericalMercatorCS,
                                                       CoordinateSystems.WGS84);
                        x = projectedPoint.X;
                        y = projectedPoint.Y;
                        break;
                    default:
                        break;
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



            return result;
        }

        /// <summary>
        /// Return geographical coordinates for country, region or district 
        /// </summary>
        /// <param name="connectionString">Connection string of EIDSS DB</param>
        /// <param name="x">Longitude / out</param>
        /// <param name="y">Latitude / out</param>
        /// <param name="region">Region ID</param>
        /// <param name="rayon">Rayon ID</param>
        /// <param name="settlement">Settlement ID</param>
        /// <returns>True if found, else - False</returns>
        public static bool GetRegionCoordinates(string connectionString, out double x,
                                                     out double y, long? region, long? rayon, long? settlement)
        {
            x = y = 0;
            Point lPoint;
            Geometry geom = null;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (region != null && region != 0) { geom = Extents.GetGeomById(connection, "gisWKBRegion", region.Value); }
                if (rayon != null && rayon != 0) { geom = Extents.GetGeomById(connection, "gisWKBRayon", rayon.Value); }
                if (settlement != null && settlement != 0) { geom = Extents.GetGeomById(connection, "gisWKBSettlement", settlement.Value); }

            }

            if (geom != null)
            {
                lPoint = geom.GetBoundingBox().GetCentroid();
                if (lPoint != null)
                {
                    //Geoms in DB in spherical mercator. Transform to wgs
                    var projectedPoint = GeometryTransform.TransformPoint(lPoint,
                                                   CoordinateSystems.SphericalMercatorCS,
                                                   CoordinateSystems.WGS84);
                    x = projectedPoint.X;
                    y = projectedPoint.Y;
                    return true;
                }
            }                 
            return false;
        }
        /// <summary>
        /// Return relative geographical coordinates for settlement and distance/azimuth
        /// </summary>
        /// <param name="connectionString">Connection string of EIDSS DB</param>
        /// <param name="settlementID">Id of settlement (idfsGeoObject)</param>
        /// <param name="azimuth">Angel in </param>
        /// <param name="distance">Distance in meters</param>
        /// <param name="x">Longitude of relative point</param>
        /// <param name="y">Latitude of relative point</param>
        /// <returns>True if settlement found, else - False</returns>
        public static bool GetRelativeCoordinates(string connectionString, long settlementID,
                                                    double azimuth, double distance,
                                                    out double x, out double y)
        {
            x = y = 0;
            double x0, y0;
            const double r = 6371000;

            double azRad = azimuth * Math.PI / 180;
            try
            {
                if (GetSettlementCoordinates(connectionString, settlementID, out x0, out y0))
                {
                    double betta = (distance * 180) / (r * Math.PI);

                    x = x0 + betta * Math.Sin(azRad) / Math.Cos(y0 * Math.PI / 180);
                    y = y0 + betta * Math.Cos(azRad);

                    if (x <= 180 && x > -180 && y <= 90 && y >= -90)
                        return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CoordToAdm(out long? country, out long? region, out long? district, string connectionString, double lat, double lon)
        {
            country = null;
            region = null;
            district = null;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        var projectedPoint = GeometryTransform.TransformPoint(new Point(lon, lat),
                                                                              CoordinateSystems.WGS84,
                                                                              CoordinateSystems.SphericalMercatorCS);

                        //find district from gisWKB... table
                        var tblName = "gisWKBRayon";
                        cmd.CommandText =
                            string.Format(new NumberFormatInfo() { NumberDecimalSeparator = "." },
                                "SELECT TOP 1 idfsGeoObject FROM (SELECT idfsGeoObject, geomShape.STArea() as area FROM {0} WHERE  geomShape.STContains(geometry::STGeomFromText('POINT({1} {2})', 3857))=1) as tbl ORDER BY area",
                                //"SELECT idfsGeoObject FROM {0} WHERE  geomShape.STContains(geometry::STGeomFromText('POINT({1} {2})', 3857))=1",
                                tblName, projectedPoint.X, projectedPoint.Y);
                        district = (long?) cmd.ExecuteScalar();

                        if (district!=null)
                        {
                            //find region and country from gis... tables
                            tblName = "gisRayon";
                            cmd.CommandText =
                                string.Format(
                                    "SELECT idfsRegion FROM {0} WHERE idfsRayon={1}", tblName, district);
                            region = (long?)cmd.ExecuteScalar();
                            
                            cmd.CommandText =
                                string.Format(
                                    "SELECT idfsCountry FROM {0} WHERE idfsRayon={1}", tblName, district);
                            country = (long?)cmd.ExecuteScalar();
                        }
                        else
                        {
                            //find region from gisWKB... table
                            tblName = "gisWKBRegion";
                            cmd.CommandText =
                                string.Format(new NumberFormatInfo() { NumberDecimalSeparator = "." },
                                    "SELECT TOP 1 idfsGeoObject FROM (SELECT idfsGeoObject, geomShape.STArea() as area FROM {0} WHERE  geomShape.STContains(geometry::STGeomFromText('POINT({1} {2})', 3857))=1) as tbl ORDER BY area",
                                    tblName, projectedPoint.X, projectedPoint.Y);
                            region = (long?)cmd.ExecuteScalar();

                            if (region!=null)
                            {
                                //find country from gis... table
                                tblName = "gisRegion";
                                cmd.CommandText =
                                    string.Format(
                                        "SELECT idfsCountry FROM {0} WHERE idfsRegion={1}", tblName, region);
                                region = (long?)cmd.ExecuteScalar();
                            }
                            else
                            {
                                //find country from gisWKB... table
                                tblName = "gisWKBCountry";
                                cmd.CommandText =
                                    string.Format(new NumberFormatInfo() { NumberDecimalSeparator = "." },
                                        "SELECT TOP 1 idfsGeoObject FROM (SELECT idfsGeoObject, geomShape.STArea() as area FROM {0} WHERE  geomShape.STContains(geometry::STGeomFromText('POINT({1} {2})', 3857))=1) as tbl ORDER BY area",
                                        tblName, projectedPoint.X, projectedPoint.Y);
                                country = (long?)cmd.ExecuteScalar();
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check of finding a point in a given polygon 
        /// </summary>
        /// <param name="connectionString">Connection string of EIDSS DB</param>
        /// <param name="x">Longitude of the point</param>
        /// <param name="y">Latitude of the point</param>
        /// <param name="admId">Id of country, region or rayon</param>
        /// <returns>True, if adm polygon contain point - x,y</returns>
        public static bool IsPointInside(string connectionString, double x, double y, long admId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(var cmd=new SqlCommand())
                {
                    //get type
                    cmd.CommandText = string.Format("SELECT idfsGISReferenceType FROM gisBaseReference WHERE idfsGISBaseReference={0}",
                                  admId);
                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                        return false;

                    var type = (long) result;


                    //Geoms in DB in spherical mercator. Input cooeds need to reproject!
                    var projectedPoint = GeometryTransform.TransformPoint(new Point(x, y), 
                                                   CoordinateSystems.WGS84,
                                                   CoordinateSystems.SphericalMercatorCS);

                    //create query
                    var fastQuery =
                        String.Format(new NumberFormatInfo() { NumberDecimalSeparator = "." },
                            "SELECT idfsGeoObject FROM TABLE_NAME WHERE idfsGeoObject={0} AND geomShape.STContains(geometry::STGeomFromText('POINT({1} {2})', 3857))",
                            admId, projectedPoint.X, projectedPoint.Y);

                    switch (type)
                    {
                        case (long)GisDbType.RftCountry:
                            cmd.CommandText = fastQuery.Replace("TABLE_NAME", "gisWKBCountry");
                            break;
                        case (long)GisDbType.RftRegion:
                            cmd.CommandText = fastQuery.Replace("TABLE_NAME", "gisWKBRegion");
                            break;
                        case (long)GisDbType.RftRayon:
                            cmd.CommandText = fastQuery.Replace("TABLE_NAME", "gisWKBRayon");
                            break;
                        default:
                            return false;
                    }
                    
                    result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                }

            }
        }

        #region For web infotool

        private static long GetGeoId(string connectionString, string lTable, double lon, double lat)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText =
                string.Format(
                    "SELECT idfsGeoObject FROM {0} WHERE  geomShape.STContains(geometry::STGeomFromText('POINT({1} {2})', 3857))=1",
                    lTable, lon, lat);
            if (lTable == "gisWKBSettlement")
            {
                cmd.CommandText =
                    string.Format(
                        "SELECT TOP 1 idfsGeoObject FROM {0} WHERE geomShape.STDistance(geometry::STGeomFromText('POINT({1} {2})', 3857)) < 1000",
                        lTable, lon, lat);
            }
            long idfGeo = 0;
            try
            {
                idfGeo = long.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception) { }

            return idfGeo;
        }

        private static string GetGeoName(string connectionString, string strLang, string lTable, double plon, double plat)
        {
            string lon = plon.ToString().Replace(',', '.');
            string lat = plat.ToString().Replace(',', '.'); 

            var connection = new SqlConnection(connectionString);
            connection.Open();
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = string.Format("SELECT idfsGeoObject FROM {0} WHERE  geomShape.STContains(geometry::STGeomFromText('POINT({1} {2})', 3857))=1", lTable, lon, lat);
            if (lTable == "gisWKBSettlement") { cmd.CommandText = string.Format("SELECT TOP 1 idfsGeoObject FROM {0} WHERE geomShape.STDistance(geometry::STGeomFromText('POINT({1} {2})', 3857)) < 1000", lTable, lon, lat); }
            var idfGeo = (long?)cmd.ExecuteScalar();
            
            if (idfGeo == null) { return ""; }
            
            var cmd1 = new SqlCommand();
            cmd1.Connection = connection;
            cmd1.CommandText = string.Format("SELECT strTextString Name FROM gisStringNameTranslation WHERE idfsGISBaseReference={0} and idfsLanguage=dbo.fnGetLanguageCode('{1}')", idfGeo, strLang);

            var result = (string)cmd1.ExecuteScalar();
            
            return result;
        }

        private static string GetStatValue(object pdata)
        {
            if (pdata != null)
            {
                double varArea = 0;
                try { varArea = double.Parse(pdata.ToString()); }
                catch (Exception) { }
                return varArea.ToString("#.##");
            }
            return "No data";
        }

        public static string GetWebPointInfo1(string connectionString, string strLng,  double lon, double lat, string[] mInfoRegion, string[] mInfoRayon, ref string mInfoSettlement)
        {
            //var fds = new FeatureDataSet();
            DataTable tbl;
            var lPoint = new Point(lon, lat);
            var projectedPoint = GeometryTransform.TransformPoint(lPoint, CoordinateSystems.WGS84,
                                                                  CoordinateSystems.SphericalMercatorCS);
            //var connectionString = ConnectionManager.DefaultInstance.ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);

            string lRegion = null;
            long id = 0;
            lRegion = GetGeoName(connectionString, strLng, "gisWKBRegion", projectedPoint.X, projectedPoint.Y) + "  ";
            if (lRegion == null)
            {
                return "";
            }
            else
            {
                mInfoRegion[0] = lRegion;
                //// Region
                id = GetGeoId(connectionString, "gisWKBRegion", projectedPoint.X, projectedPoint.Y);
                tbl = SqlExecHelper.SqlExecTable(sqlConnection,
                    string.Format("SELECT * FROM dbo.fn_GetRegionStatInfo(dbo.fnGetLanguageCode('{0}'), {1})", strLng, id));
                tbl.Columns.Add("varPopDens", Type.GetType("System.Double"));
                foreach (DataRow row in tbl.Rows)
                {
                    if (row["varPopulation"] is DBNull || row["varArea"] is DBNull) continue;

                    double population = (double)row["varPopulation"];
                    double area = (double)row["varArea"];

                    if (area != 0) row["varPopDens"] = population / area;
                    else row["varPopDens"] = null;

                    mInfoRegion[1] = GetStatValue(row["varArea"]);
                    mInfoRegion[2] = GetStatValue(row["varPopulation"]);
                    mInfoRegion[3] = GetStatValue(row["varPopDens"]);
                }
            }

            mInfoRayon[0] = GetGeoName(connectionString, strLng, "gisWKBRayon", projectedPoint.X, projectedPoint.Y) + "  ";
            id = GetGeoId(connectionString, "gisWKBRayon", projectedPoint.X, projectedPoint.Y);
            tbl = SqlExecHelper.SqlExecTable(sqlConnection, string.Format("SELECT * FROM dbo.fn_GetRayonStatInfo(dbo.fnGetLanguageCode('{0}'), {1})", strLng, id));
            tbl.Columns.Add("varPopDens", Type.GetType("System.Double"));
            foreach (DataRow row in tbl.Rows)
            {
                if (row["varPopulation"] is DBNull || row["varArea"] is DBNull) continue;
                double population = (double)row["varPopulation"];
                double area = (double)row["varArea"];
                //double density;
                if (area != 0) row["varPopDens"] = population / area;
                else row["varPopDens"] = null;

                mInfoRayon[1] = GetStatValue(row["varArea"]);
                mInfoRayon[2] = GetStatValue(row["varPopulation"]);
                mInfoRayon[3] = GetStatValue(row["varPopDens"]);
            }


            mInfoSettlement = GetGeoName(connectionString, strLng, "gisWKBSettlement", projectedPoint.X, projectedPoint.Y);


            /*
            varArea
            varPopulation
            varPopDens                                     
             */

            return "";
        }

        #endregion


        #region Deprecated functions
        //internal static bool GetSettlementCoordinates(string connectionString, long settlementID, out double x,
        //                                             out double y)
        //{
        //    x = 0;
        //    y = 0;

        //    using (MsSql dataSource = new MsSql(connectionString, "gisWKBSettlement", "blbWKBGeometry", "idfsGeoObject"))
        //    {
        //        Geometry geometry = dataSource.GetGeometryByID(settlementID);
        //        if (geometry != null)
        //        {
        //            x = geometry.GetBoundingBox().GetCentroid().X;
        //            y = geometry.GetBoundingBox().GetCentroid().Y;
        //            return true;
        //        }
        //        return false;
        //    }
        //}
        #endregion
    }
}
