using System;
using System.Data.SqlClient;
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
            }
            return null;
        }

        public static Geometry GetGeomById(SqlConnection conn, string tableName, long id)
        {
            string strSQL = "SELECT g.geomShape.STAsBinary() FROM " + tableName + " g WHERE idfsGeoObject='" + id + "'";

            using (var command = new SqlCommand(strSQL, conn))
            {
                object wkb = command.ExecuteScalar();
                return wkb != null && wkb != DBNull.Value
                           ? SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse((byte[]) wkb)
                           : null;
            }
        }
    }
    }