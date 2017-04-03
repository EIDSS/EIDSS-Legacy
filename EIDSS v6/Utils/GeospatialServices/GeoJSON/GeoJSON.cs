using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.SqlServer.Types;
using System.Globalization;
using System.IO;

namespace GeospatialServices.GeoJSON
{
    public class GeoJSON
    {

        public static List<object> JsonToFeatureObjects(string json)
        {
            List<object> featureObjects = new List<object>();
            Dictionary<string, object> result = (Dictionary<string, object>)JSON.JsonDecode(json);

            if (result != null)
            {
                if (result.ContainsKey("type"))
                {
                    if ((string)result["type"] == "FeatureCollection")
                    {
                        featureObjects = (List<object>)result["features"];
                    }
                    else
                    {
                        //featureObjects = (List<object>)result;
                        throw new NotImplementedException();
                    }
                }
            }
            return featureObjects;
        }

        public static SqlGeometry JSONToGeometry(string json)
        {
            SqlGeometry Feature = null;
            int srid = 4326;
            string wkt = GeoJSONToWkt(json, out srid);
            if (wkt != string.Empty)
            {
                System.Data.SqlTypes.SqlChars wkbGeometry = new System.Data.SqlTypes.SqlChars(wkt.ToString());
                Feature = SqlGeometry.STGeomFromText(wkbGeometry, srid);
            }
            return Feature;
        }

        public static Dictionary<string, object> JSONToProperties(string json)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            List<object> featureObjects = JsonToFeatureObjects(json);
            foreach (Dictionary<string, object> featureObject in featureObjects)
            {
                if ((string)featureObject["type"] != "Feature")
                    throw new FormatException("Feature object type is not Feature");

                properties = (Dictionary<string, object>)featureObject["properties"];
            }
            return properties;
        }

        /// <list type="table">
        /// <listheader><term>Geometry </term><description>WKT Representation</description></listheader>
        /// <item><term>A Point</term>
        /// <description>POINT(15 20)<br/> Note that point coordinates are specified with no separating comma.</description></item>
        /// <item><term>A LineString with four points:</term>
        /// <description>LINESTRING(0 0, 10 10, 20 25, 50 60)</description></item>
        /// <item><term>A Polygon with one exterior ring and one interior ring:</term>
        /// <description>POLYGON((0 0,10 0,10 10,0 10,0 0),(5 5,7 5,7 7,5 7, 5 5))</description></item>
        /// <item><term>A MultiPoint with three Point values:</term>
        /// <description>MULTIPOINT(0 0, 20 20, 60 60)</description></item>
        /// <item><term>A MultiLineString with two LineString values:</term>
        /// <description>MULTILINESTRING((10 10, 20 20), (15 15, 30 15))</description></item>
        /// <item><term>A MultiPolygon with two Polygon values:</term>
        /// <description>MULTIPOLYGON(((0 0,10 0,10 10,0 10,0 0)),((5 5,7 5,7 7,5 7, 5 5)))</description></item>
        /// <item><term>A GeometryCollection consisting of two Point values and one LineString:</term>
        /// <description>GEOMETRYCOLLECTION(POINT(10 10), POINT(30 30), LINESTRING(15 15, 20 20))</description></item>
        /// </list>
        public static string GeoJSONToWkt(string json, out int srid)
        {
            srid = 4326;
            StringWriter sw = new StringWriter();
            List<object> featureObjects = JsonToFeatureObjects(json);
            foreach (Dictionary<string, object> featureObject in featureObjects)
            {
                if ((string)featureObject["type"] != "Feature")
                    throw new FormatException("Feature object type is not Feature");

                if (featureObject.ContainsKey("crs"))
                {
                    Dictionary<string, object> crs = featureObject["crs"] as Dictionary<string, object>;
                    if ((string)crs["type"] == "name")
                    {
                        Dictionary<string, object> properties = crs["properties"] as Dictionary<string, object>;
                        string crsName = (string)properties["name"];
                        srid = Convert.ToInt32(crsName.Replace("epsg:", ""));           //TODO: replace with OGC CRS URNs
                    }
                    else
                        throw new NotSupportedException("crs type link not supported");
                }

                Dictionary<string, object> geometry = (Dictionary<string, object>)featureObject["geometry"];

                if ((string)geometry["type"] == "Point")
                {
                    sw.Write("POINT (");
                    List<object> coordinate = (List<object>)geometry["coordinates"];
                    sw.Write(coordinate[0]);
                    sw.Write(" ");
                    sw.Write(coordinate[1]);
                    sw.Write(")");
                }

                if ((string)geometry["type"] == "LineString")
                {
                    sw.Write("LINESTRING (");
                    List<object> coordinates = (List<object>)geometry["coordinates"];
                    for (int i = 0; i < coordinates.Count; i++)
                    {
                        List<object> coordinate = (List<object>)coordinates[i];
                        if (i > 0)
                            sw.Write(", ");
                        sw.Write(coordinate[0]);
                        sw.Write(" ");
                        sw.Write(coordinate[1]);
                    }
                    sw.Write(")");
                }

                if ((string)geometry["type"] == "Polygon")
                {
                    sw.Write("POLYGON (");
                    List<object> coordinates = (List<object>)geometry["coordinates"];
                    foreach (List<object> ring in coordinates)
                    {
                        sw.Write("(");
                        for (int i = 0; i < ring.Count; i++)
                        {
                            List<object> coordinate = (List<object>)ring[i];
                            if( i > 0)
                                sw.Write(", ");
                            sw.Write(coordinate[0]);
                            sw.Write(" ");
                            sw.Write(coordinate[1]);
                        }
                        sw.Write(")");
                    }
                    sw.Write(" )");
                }
            }
            return sw.ToString();
        }

        public static string DataSetToJSON(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return "";

            string geometryColumn = DiscoverGeometryColumn(ds.Tables[0].Rows[0]);

            List<object> featureObjects = new List<object>();

            foreach (System.Data.DataRow fdr in ds.Tables[0].Rows)
            {
                Dictionary<string, object> featureObject = new Dictionary<string, object>();
                featureObject.Add("type", "Feature");
                Dictionary<string, object> geometry = null;
                if (geometryColumn != null)
                {
                    var sqlGeometry = (SqlGeometry)fdr[geometryColumn];
                    if (sqlGeometry != null && !sqlGeometry.IsNull)
                    {
                        geometry = GeometryToJson(sqlGeometry);
                        Dictionary<string, object> crs = GetCrs((int) sqlGeometry.STSrid);
                        featureObject.Add("crs", crs);
                    }
                }
                Dictionary<string, object> properties = GetProperties(fdr);
                featureObject.Add("geometry", geometry);
                featureObject.Add("properties", properties);
                featureObjects.Add(featureObject);
            }
            Dictionary<string, object> featureCollection = new Dictionary<string, object>();
            featureCollection.Add("type", "FeatureCollection");
            featureCollection.Add("features", featureObjects);
            string json = JSON.JsonEncode(featureCollection);
            return json;
        }

        //private static Dictionary<string, object> GeometryToJson(System.Data.DataRow fdr, string geometryColumn)
        //{
        //    if (geometryColumn == null)
        //        return null;

        //    Microsoft.SqlServer.Types.SqlGeometry geometry = (Microsoft.SqlServer.Types.SqlGeometry)fdr[geometryColumn];

        //    return GeometryToJson(geometry);
        //}

        public static string SqlGeometryToJSON(SqlGeometry sqlGeometry)
        {
            List<object> featureObjects = new List<object>();
            Dictionary<string, object> featureObject = new Dictionary<string, object>();
            featureObject.Add("type", "Feature");
            Dictionary<string, object> geometry = GeometryToJson(sqlGeometry);
            Dictionary<string, object> properties = null;
            featureObject.Add("geometry", geometry);
            featureObject.Add("properties", properties);
            Dictionary<string, object> crs = GetCrs((int)sqlGeometry.STSrid);
            featureObject.Add("crs", crs);            
            featureObjects.Add(featureObject);
            Dictionary<string, object> featureCollection = new Dictionary<string, object>();
            featureCollection.Add("type", "FeatureCollection");
            featureCollection.Add("features", featureObjects);
            string json = JSON.JsonEncode(featureCollection);
            return json;
        }

        private static Dictionary<string, object> GeometryToJson(Microsoft.SqlServer.Types.SqlGeometry geometry)
        {
            if ((string)geometry.STGeometryType() == "Point")
            {
                return PointToJson(geometry);
            }
            if ((string)geometry.STGeometryType() == "LineString")
            {
                return LineStringToJson(geometry);
            }
            if ((string)geometry.STGeometryType() == "Polygon")
            {
                return PolygonToJson(geometry);
            }
            if ((string)geometry.STGeometryType() == "MultiPolygon")
            {
                return MultiPolygonToJson(geometry);
            }
            string a = (string)geometry.STGeometryType();
            return null;
        }

        private static Dictionary<string, object> GetCrs(int srid)
        {
            Dictionary<string, object> crs = new Dictionary<string, object>();
            crs.Add("type", "name");
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("name", string.Format("epsg:{0}", srid));                // TODO: Use OGC CRS URNs
            crs.Add("properties", properties);
            return crs;
        }

        public static Dictionary<string, object> PointToJson(Microsoft.SqlServer.Types.SqlGeometry point)
        {
            Dictionary<string, object> geometry = new Dictionary<string, object>();
            geometry.Add("type", "Point");
            List<object> coordinates = new List<object>();
            coordinates.Add(Convert.ToDouble(point.STX.Value));
            coordinates.Add(Convert.ToDouble(point.STY.Value));
            geometry.Add("coordinates", coordinates);
            return geometry;
        }

        public static Dictionary<string, object> LineStringToJson(Microsoft.SqlServer.Types.SqlGeometry lineString)
        {
            Dictionary<string, object> geometry = new Dictionary<string, object>();
            geometry.Add("type", "LineString");
            List<object> coordinates = new List<object>();
            int points = (int)lineString.STNumPoints();
            for (int i = 1; i <= points; i++)
            {
                List<object> coordinate = new List<object>();
                coordinate.Add(Convert.ToDouble(lineString.STPointN(i).STX.Value));
                coordinate.Add(Convert.ToDouble(lineString.STPointN(i).STY.Value));
                coordinates.Add(coordinate);
            }
            geometry.Add("coordinates", coordinates);
            return geometry;
        }

        public static Dictionary<string, object> PolygonToJson(Microsoft.SqlServer.Types.SqlGeometry polygon)
        {
            Dictionary<string, object> geometry = new Dictionary<string, object>();
            geometry.Add("type", "Polygon");
            List<object> coordinates = new List<object>();
            // exterior ring
            int expoints = (int)polygon.STExteriorRing().STNumPoints();
            List<object> ring = new List<object>();
            for (int j = 1; j <= expoints; j++)
            {
                List<object> coordinate = new List<object>();
                coordinate.Add(Convert.ToDouble(polygon.STPointN(j).STX.Value));
                coordinate.Add(Convert.ToDouble(polygon.STPointN(j).STY.Value));
                ring.Add(coordinate);
            }
            coordinates.Add(ring);

            // interior rings           
            int rings = (int)polygon.STNumInteriorRing();
            for (int i = 1; i <= rings; i++)
            {
                ring = new List<object>();
                int inpoints = (int)polygon.STInteriorRingN(i).STNumPoints();
                List<object> inring = new List<object>();
                for (int j = 1; j <= inpoints; j++)
                {
                    List<object> coordinate = new List<object>();
                    coordinate.Add(Convert.ToDouble(polygon.STInteriorRingN(i).STPointN(j).STX.Value));
                    coordinate.Add(Convert.ToDouble(polygon.STInteriorRingN(i).STPointN(j).STY.Value));
                    ring.Add(coordinate);
                }
                coordinates.Add(ring);
            }
            geometry.Add("coordinates", coordinates);
            return geometry;
        }

        public static Dictionary<string, object> MultiPolygonToJson(Microsoft.SqlServer.Types.SqlGeometry multipolygon)
        {
            Dictionary<string, object> geometry = new Dictionary<string, object>();
            geometry.Add("type", "MultiPolygon");

            List<object> polygons = new List<object>();
            int geometries = (int)multipolygon.STNumGeometries();
            for (int k = 1; k <= geometries; k++)
            {
                Microsoft.SqlServer.Types.SqlGeometry polygon = multipolygon.STGeometryN(k);
                List<object> coordinates = new List<object>();
                // exterior ring
                int expoints = (int)polygon.STExteriorRing().STNumPoints();
                List<object> ring = new List<object>();
                for (int j = 1; j <= expoints; j++)
                {
                    List<object> coordinate = new List<object>();
                    coordinate.Add(Convert.ToDouble(polygon.STPointN(j).STX.Value));
                    coordinate.Add(Convert.ToDouble(polygon.STPointN(j).STY.Value));
                    ring.Add(coordinate);
                }
                coordinates.Add(ring);

                // interior rings
                ring = new List<object>();
                int rings = (int)polygon.STNumInteriorRing();
                for (int i = 1; i <= rings; i++)
                {
                    int inpoints = (int)polygon.STInteriorRingN(i).STNumPoints();
                    List<object> inring = new List<object>();
                    for (int j = 1; j <= inpoints; j++)
                    {
                        List<object> coordinate = new List<object>();
                        coordinate.Add(Convert.ToDouble(polygon.STInteriorRingN(i).STPointN(j).STX.Value));
                        coordinate.Add(Convert.ToDouble(polygon.STInteriorRingN(i).STPointN(j).STY.Value));
                        ring.Add(coordinate);
                    }
                    coordinates.Add(ring);
                }
                polygons.Add(coordinates);
            }
            geometry.Add("coordinates", polygons);
            return geometry;
        }

        private static Dictionary<string, object> GetProperties(System.Data.DataRow fdr)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            foreach (System.Data.DataColumn columnSpec in fdr.Table.Columns)
            {
                switch (fdr[columnSpec.ColumnName].GetType().FullName)
                {
                    case "Microsoft.SqlServer.Types.SqlGeometry":
                        // filter out all geometry 
                        break;
                    case "Microsoft.SqlServer.Types.SqlGeography":
                        // filter out all geography
                        break;
                    case "System.Byte[]":
                        // filter out byte arrays (WKB or images)
                        break;
                    case "System.String":
                        // trim off white space
                        properties.Add(columnSpec.ColumnName, fdr[columnSpec.ColumnName].ToString().Trim());
                        break;
                    case "System.DateTime":
                        // might want to convert to UTC
                        // info.AddValue(columnSpec.ColumnName, System.TimeZone.CurrentTimeZone.ToUniversalTime(fdr[columnSpec.ColumnName]));
                        DateTime dt = (DateTime)fdr[columnSpec.ColumnName];
                        properties.Add(columnSpec.ColumnName, dt.ToString("s"));
                        break;
                    default:
                        if (fdr[columnSpec.ColumnName] == DBNull.Value)
                            properties.Add(columnSpec.ColumnName, null);
                        else
                            properties.Add(columnSpec.ColumnName, Convert.ToDouble(fdr[columnSpec.ColumnName]));
                        break;
                }
            }
            return properties;
        }

        private static string DiscoverGeometryColumn(System.Data.DataRow fdr)
        {
            string geometryColumn = null;
            // TODO: behaviour is to find the first spatial column either geometry, 
            // geography, wkb or wkt.
            foreach (System.Data.DataColumn columnSpec in fdr.Table.Columns)
            {
                switch (fdr[columnSpec.ColumnName].GetType().FullName)
                {
                    case "Microsoft.SqlServer.Types.SqlGeometry":
                        geometryColumn = columnSpec.ColumnName;
                        break;
                    case "System.Byte[]":
                        geometryColumn = columnSpec.ColumnName;
                        break;
                }
            }
            return geometryColumn;
        }
    }
}
