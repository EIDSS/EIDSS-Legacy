using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using DotSpatial.Projections;
using GIS_V4.Common;
using SharpMap.Geometries;

namespace eidss.gis.common
{
    public static class Extents
    {

        public static BoundingBox GetMinimalExtent(string connectionString, long? countryCode, long? regionCode, long? districtCode, long? settlementCode)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Geometry geom=null;
                if (districtCode != null)
                    geom = GetGeomById(connection, "gisWKBRayon", districtCode.Value);
                else if (regionCode != null)
                    geom = GetGeomById(connection, "gisWKBRegion", regionCode.Value);
                else if (countryCode != null)
                    geom = GetGeomById(connection, "gisWKBCountry", countryCode.Value);
                //else if (settlementCode != null)
                //    geom = GetGeomById(connection, "gisWKBSettlement", settlementCode.Value);

                if (geom != null)
                {
                    //Geoms in DB in spherical mercator. Transform to wgs
                    var bbox=geom.GetBoundingBox();
                    //if (bbox.Width < 1) bbox = bbox.Grow(10);
                    
                    bbox = GeometryTransform.TransformBox(bbox, CoordinateSystems.SphericalMercatorCS, CoordinateSystems.WGS84);
                    
                    return bbox;
                }
                connection.Close();
            }
            return null;
        }

        public static Geometry GetGeomById(SqlConnection conn, string tableName, long id, BoundingBox bBox = null)
        {
            if (bBox == null)
            {
                string strSQL = "SELECT g.geomShape.STAsBinary() FROM " + tableName + " g WHERE idfsGeoObject='" + id +
                                "'";

                using (var command = new SqlCommand(strSQL, conn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    object wkb = command.ExecuteScalar();
                    if (conn.State == ConnectionState.Open) conn.Close();

                    return wkb != null && wkb != DBNull.Value
                        ? SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse((byte[]) wkb)
                        : null;

                }
            }
            else
            {
                var bboxWhere =
                    string.Format(
                        "geomShape.MakeValid().STIntersects(geometry::STGeomFromText('POLYGON (({0} {1}, {2} {1}, {2} {3}, {0} {3}, {0} {1}))',3857)) = 1",
                        Convert.ToInt32(bBox.Left), Convert.ToInt32(bBox.Bottom), Convert.ToInt32(bBox.Right),
                        Convert.ToInt32(bBox.Top));

                string strSQL = "SELECT g.geomShape.STAsBinary() FROM " + tableName + " g WHERE idfsGeoObject='" + id +
                                "' AND " + bboxWhere;

                using (var command = new SqlCommand(strSQL, conn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    object wkb = command.ExecuteScalar();
                    if (conn.State == ConnectionState.Open) conn.Close();

                    return wkb != null && wkb != DBNull.Value
                        ? SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse((byte[])wkb)
                        : null;

                }
            }
        }

        public static string GetWktById(SqlConnection conn, string tableName, long id)
        {
            tableName = tableName + "Ready";

            string strSQL = "SELECT g.wktShape_4326 FROM " + tableName + " g WHERE idfsGeoObject='" + id + "' AND Ratio = 0";

            using (var command = new SqlCommand(strSQL, conn))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                object wkt = command.ExecuteScalar();
                if (conn.State == ConnectionState.Open) conn.Close();

                return wkt != null && wkt != DBNull.Value
                           //? SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse((byte[])wkb)
                           ? wkt.ToString()
                           : null;

            }
        }
    }
    }