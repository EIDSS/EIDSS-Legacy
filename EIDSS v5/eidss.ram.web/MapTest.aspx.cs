using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using BruTile.Web;
using eidss.gis.Forms;
using eidss.ram.web.Components;
using eidss.ram.web.Components.Export;
using Microsoft.SqlServer.Types;
using eidss.gis.common;
using SharpMap.Geometries;
using Point = SharpMap.Geometries.Point;
using DotSpatial.Projections;
using GIS_V4.Common;
using GIS_V4.Forms;
using GIS_V4.Layers;
using GIS_V4.Serializers;
using GIS_V4.Serializers.ThemeSerializers;
using GIS_V4.Tools.Implemented;
using GIS_V4.Tools;

namespace eidss.ram.web
{
    public partial class MapTest : BasePage
    {
        public string json;
        public string m_map_type = "";
        public string m_conn_str = "server=(local)\\MSSQLSERVER_R2; Initial Catalog=eidss; Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SetData("avr_pie");


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SetData("avr_marker");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SetData("avr_poly");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SetData("avr_point");
        }

        public void SetData(string map_type)
        {
            DataTable gisData = new DataTable();
            gisData = eidss.gis.common.AvrMapEmulator.GetAvrMapTable(true, true, false);

            eidss.gis.Forms.AvrMapControl lmapControl = new AvrMapControl(true);
            TileLayer layer = new TileLayer(new OsmTileSource(), "OSM Layer");
            lmapControl.MapSpatRef = CoordinateSystems.SphericalMercatorCS;
            lmapControl.Map.Layers.Insert(0, layer);
            Point lPoint = GeometryTransform.TransformPoint(new Point(0, 0), CoordinateSystems.WGS84,
                                                            CoordinateSystems.SphericalMercatorCS);
            Point lPoint2 = GeometryTransform.TransformPoint(new Point(50, 60), CoordinateSystems.WGS84,
                                                             CoordinateSystems.SphericalMercatorCS);
            BoundingBox bbox = new BoundingBox(lPoint.X, lPoint.Y, lPoint2.X, lPoint2.Y);
            lmapControl.AddEventLayer("Title", "Layer", gisData, false, m_conn_str);
            lmapControl.ZoomToBox(bbox);
            lmapControl.RefreshMap();
            System.Drawing.Bitmap lBitmap = lmapControl.GetMapImage(297, 210, 300);
            lBitmap.Save(@"C:\Temp\AVR.bmp");

            switch (map_type)
            {
                case "avr_pie":
                    m_map_type = "avr_pie";
                    gisData = eidss.gis.common.AvrMapEmulator.GetAvrMapTable(false, true, true);
                    break;

                case "avr_marker":
                    m_map_type = "avr_marker";
                    gisData = eidss.gis.common.AvrMapEmulator.GetAvrMapTable(true, true, true);
                    break;
                case "avr_poly":
                    m_map_type = "avr_poly";
                    gisData = eidss.gis.common.AvrMapEmulator.GetAvrMapTable(true, true, false);
                    break;
                case "avr_point":
                    m_map_type = "avr_point";
                    gisData = eidss.gis.common.AvrMapEmulator.GetAvrMapTable(false, true, true);
                    break;
            }

            DataColumn column;
            column = new DataColumn();
            column.DataType = typeof(Microsoft.SqlServer.Types.SqlGeometry);
            column.ColumnName = "geom";
            gisData.Columns.Add(column);

            for (int i = 0; i < gisData.Rows.Count; i++)
            {
                SharpMap.Geometries.Geometry Feature = null;
                int srid = 4326;

                double X, Y;
                long ID = 0;
                if (gisData.Rows[i]["id"].ToString() != "")  {ID = Int64.Parse(gisData.Rows[i]["id"].ToString());}                
                if (m_map_type == "avr_poly")
                {
                    string l_table_name = eidss.gis.common.CoordinatesUtils.GetWKBTableName(gisData, m_conn_str);
                    var sqlConnection = new SqlConnection(m_conn_str);
                    sqlConnection.Open();
                    Feature = eidss.gis.common.Extents.GetGeomById(sqlConnection, l_table_name, ID);
                }
                else
                {
                    if (ID > 0)
                    {
                        eidss.gis.common.CoordinatesUtils.GetAdminUnitCoordinates(m_conn_str, ID, out X, out Y);
                        gisData.Rows[i]["x"] = X;
                        gisData.Rows[i]["y"] = Y;
                    }
                    else
                    {
                        X = Convert.ToDouble(gisData.Rows[i]["x"].ToString());
                        Y = Convert.ToDouble(gisData.Rows[i]["y"].ToString());
                    }
                    Feature = new SharpMap.Geometries.Point(X, Y);
                }

                System.Data.SqlTypes.SqlChars wktGeometry = new System.Data.SqlTypes.SqlChars(Feature.AsText());
                gisData.Rows[i]["geom"] = SqlGeometry.STGeomFromText(wktGeometry, srid);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(gisData);
            json = GeospatialServices.GeoJSON.GeoJSON.DataSetToJSON(ds);
        }
    }
}