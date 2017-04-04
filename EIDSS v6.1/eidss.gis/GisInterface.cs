using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using DotSpatial.Projections;
using GIS_V4.Common;
using GIS_V4.Data.Providers;
using GIS_V4.Forms;
using GIS_V4.Layers;
using GIS_V4.Rendering;
using GIS_V4.Serializers;
using GIS_V4.Utils;
using Ionic.Zlib;
using SharpMap.Geometries;
using SharpMap.Rendering.Thematics;
using SharpMap.Styles;
using bv.common;
using bv.common.Configuration;
using bv.common.Diagnostics;
using bv.common.db.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.gis.Properties;
using eidss.gis.Utils;
using eidss.gis.common;
using eidss.gis.Forms;
using eidss.model.WindowsService.Serialization;
using Point = SharpMap.Geometries.Point;

namespace eidss.gis
{
    //public enum StyleType
    //{
    //    Gradient,
    //    RuleBased,
    //    BarChart
    //}

    //public class AvrLayerStyle
    //{
    //    GeometryType2 GeometryType { get; set; }
    //    StyleType StyleType { get; set; }
    //}

    /// <summary>
    /// Public GIS functions for EIDSS desktop client
    /// </summary>
    public class GisInterface
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetMapName(string fileName)
        {
            var result = string.Empty;
            var xmlDoc = new XmlDocument();
            try
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        xmlDoc.Load(fileName);
                    }
                    catch (Exception)
                    {
                        xmlDoc.Load(MapProjectsStorage.DefaultMapPath);
                    }
                }
                else
                {
                    xmlDoc.Load(MapProjectsStorage.DefaultMapPath);
                }
                
                var mapNode = xmlDoc.SelectSingleNode("Map");
                var nameNode = mapNode.SelectSingleNode("MapName");
                if (nameNode != null) result = nameNode.InnerText;
                return result;
            }
            catch (Exception ex)
            {
                throw new MapDeserializationException(Resources.gis_MapProjectsStorage_GetMapNameError + ex.Message, ex);
            }
        }

        /// <summary>
        /// Get coordinates of the settlement
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
        /// Get coordinates of the settlement
        /// </summary>
        /// <param name="settlementID">settlement id</param>
        /// <param name="x">x or Longitude in Geo coordinates</param>
        /// <param name="y">y or Latitude in Geo coordinates</param>
        /// <param name="z">Elevation</param>
        /// <returns></returns>
        public static bool GetSettlementCoordinates(long settlementID, out double x, out double y, out int z)
        {
            string connectionString = ConnectionManager.DefaultInstance.ConnectionString;
            return CoordinatesUtils.GetSettlementCoordinates(connectionString, settlementID, out x, out y, out z);
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
                var screenSize = Screen.GetWorkingArea(new System.Drawing.Point(0, 0));
                if (mapForm.Height > screenSize.Height)
                    mapForm.Height = screenSize.Height;
                if (mapForm.Width > screenSize.Width)
                    mapForm.Width = screenSize.Width;
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
                    else if (settlementID != 0)
                    {
                        double _x, _y;
                        GetSettlementCoordinates(settlementID, out _x, out _y);
                        mapForm.InitWgsPoint = new Point(_x, _y);
                    }
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

        public static Bitmap GetPrintMap
            (long countryId, long regionId, long rayonId, long settlementId, decimal x, decimal y)
        {
            var setCaseMapControl = new SetCaseMapControl();
            setCaseMapControl.MapSpatRef = CoordinateSystems.SphericalMercatorCS;
            
            Point initWgsPoint;

            if (x != 0 && y != 0) initWgsPoint = new Point((double) x, (double) y);
            else initWgsPoint = null;


            if (initWgsPoint != null)
            {
                var point = initWgsPoint.Clone();

                if (setCaseMapControl.MapSpatRef != CoordinateSystems.WGS84)
                    point = GeometryTransform.TransformPoint(point, CoordinateSystems.WGS84,
                                                             setCaseMapControl.MapSpatRef);

                setCaseMapControl.InputTool.Point = point;
            }
            else
            {
                double _x, _y;
                if (GetSettlementCoordinates(settlementId, out _x, out _y))
                {
                    initWgsPoint = new Point(_x, _y);
                    var point = initWgsPoint.Clone();

                    if (setCaseMapControl.MapSpatRef != CoordinateSystems.WGS84)
                        point = GeometryTransform.TransformPoint(point, CoordinateSystems.WGS84,
                                                                 setCaseMapControl.MapSpatRef);

                    setCaseMapControl.InputTool.Point = point;
                }
            }

            var defPath = string.IsNullOrEmpty(BaseSettings.DefaultMapProject)
                ? MapProjectsStorage.DefaultMapPath
                : BaseSettings.DefaultMapProject;

            setCaseMapControl.LoadMap(defPath);//MapProjectsStorage.DefaultMapPath);

            // get min WGS-extent
            var extent = Extents.GetMinimalExtent(ConnectionManager.DefaultInstance.ConnectionString,
                                                  countryId == 0 ? null : (long?) countryId,
                                                  regionId == 0 ? null : (long?) regionId,
                                                  rayonId == 0 ? null : (long?) rayonId,
                                                  settlementId == 0 ? null : (long?) settlementId);
            var extentPrj = GeometryTransform.TransformBox(extent, CoordinateSystems.WGS84,
                                                           CoordinateSystems.SphericalMercatorCS);
            
            var k = extentPrj.Width / extentPrj.Height;

            const double w = 180;
            var h = w / k;

            setCaseMapControl.Width=(int) (w*10);
            setCaseMapControl.Height = (int) (h * 10);

            setCaseMapControl.ZoomToBox(extentPrj);

            setCaseMapControl.InputTool.TemporaryLayerName = "Vet. Case Location";
            setCaseMapControl.InputTool.TemporaryLayerStyle.MarkerType = MarkerTypes.Cross;
            var result = setCaseMapControl.m_mapImage.GetMapImage(w, h, 300);

            //setCaseMapControl.Dispose();
            
            return result;
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

        #region Methods for AVR Web Mapping

        private static void CheckTableColumnExists(DataTable table, string columnName)
        {
            if (!table.Columns.Contains(columnName))
            {
                throw new Exception(string.Format("Table {0} dosn't have column {1}", table.TableName, columnName));
            }
        }

        public static string UncompressString(byte[] compressed)
        {
            try
            {
                //  throw new ApplicationException("test");
                if (compressed == null || compressed.Length == 0)
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
                return System.Text.Encoding.Unicode.GetString(encodedDataAsBytes);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return string.Empty;
            }
        }

        //private static XmlDocument GetXmlMapSettings(long layoutId, string language)
        //{
        //    using (var con = (SqlConnection) ConnectionManager.DefaultInstance.Connection)
        //    {
        //        using (var cmd = new SqlCommand("spAsMapSettingsSelectDetail", con))
        //        {
        //            var ds = new DataSet();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@LangID", SqlDbType.NVarChar, 50).Value = language;
        //            cmd.Parameters.Add("@LayoutID", SqlDbType.BigInt).Value = layoutId;
        //            var adapter = new SqlDataAdapter {SelectCommand = cmd};
        //            adapter.Fill(ds);
        //            ds.EnforceConstraints = false;
        //            string xmlMapSettings=string.Empty;
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                var row = ds.Tables[0].Rows[0];
        //                if (!bv.common.Core.Utils.IsEmpty(row["blbGisLayerGeneralSettings"]))
        //                {
        //                    var xmlMapSettingsZip = (byte[])row["blbGisLayerGeneralSettings"];
        //                    xmlMapSettings = UncompressString(xmlMapSettingsZip);
        //                }
        //            }

        //        }
        //    }
        //}

        public static DataSet AddStyleColumns(DataSet dataSet, long layoutId)//, long langId)
        {
            if (dataSet == null)
            {
                throw new Exception("AVR Map DataSet can't be NULL.");
            }

            if (dataSet.Tables.Count != 2)
            {
                throw new Exception("Map DataSet should have 2 tables.");
            }

            var data = dataSet.Tables[0];
            var dictionary = dataSet.Tables[1];

            CheckTableColumnExists(data, "id");
            CheckTableColumnExists(data, "x");
            CheckTableColumnExists(data, "y");

            CheckTableColumnExists(dictionary, "ColumnName");
            CheckTableColumnExists(dictionary, "ColumnDescription");
            CheckTableColumnExists(dictionary, "blnIsGradient");
            CheckTableColumnExists(dictionary, "blnIsChart");

            data.Columns.Add("avr_gis_icon_id", Type.GetType("System.Int64"));
            data.Columns.Add("avr_gis_color", Type.GetType("System.String"));
            data.Columns.Add("avr_gis_bar_style", Type.GetType("System.String"));

            #region Get Lang/Layout settings

            

            #endregion

            #region TMP Theme Generator

            //if (layerSettings != null)
            //{
            //            //eventGroup =
            //            //    GIS_V4.Serializers.LayerSerializers.LayerGroupSerializer.Instance.Deserialize(
            //            //        settings.LayerSettings.GetElementById("AVR_Group"));

            //            LayerGroup tmpGroup;
            //            tmpGroup =
            //                GIS_V4.Serializers.LayerSerializers.LayerGroupSerializer.Instance.Deserialize(
            //                    (XmlElement) layerSettings.ChildNodes[0]);

            //            foreach (var lyr in tmpGroup.Layers)
            //            {
            //                if (lyr is GIS_V4.Layers.LabelLayer) continue;
            //                if (lyr is EventLayer)
            //                {
            //                    View_DB. 






            //                    foreach (var _lyr in eventGroup.Layers)
            //                    {
            //                        if (_lyr is GIS_V4.Layers.LabelLayer) continue;
            //                        if (_lyr is EventLayer)
            //                        {
            //                            if (lyr.Tag.ToString() == "event_gradient" &
            //                                _lyr.Tag.ToString() == "event_gradient")
            //                            {
            //                                if (ThemeIsCompatible(((EventLayer) lyr).Theme, (EventLayer) _lyr))
            //                                {
            //                                    ((EventLayer) _lyr).Theme = ((EventLayer) lyr).Theme;
            //                                    _lyr.LayerName = lyr.LayerName;
            //                                    _lyr.Enabled = lyr.Enabled;
            //                                    _lyr.MaxVisible = lyr.MaxVisible;
            //                                    _lyr.MinVisible = lyr.MinVisible;
            //                                    _lyr.Transparency = lyr.Transparency;
            //                                }
            //                                else
            //                                {
            //                                    MessageForm.Show(
            //                                        "Previously saved settings can’t be applied to Gradient layer. Probably you have already changed gradient field of the AVR layer. Default settings will be applied.",
            //                                        "Uncompatible Gradient Layer Settings", MessageBoxButtons.OK,
            //                                        MessageBoxIcon.Warning);
            //                                }
            //                            }
            //                            if (lyr.Tag.ToString() == "event_chart" & _lyr.Tag.ToString() == "event_chart")
            //                            {
            //                                if (ThemeIsCompatible(((EventLayer) lyr).Theme, (EventLayer) _lyr))
            //                                {
            //                                    ((EventLayer) _lyr).Theme = ((EventLayer) lyr).Theme;
            //                                    _lyr.LayerName = lyr.LayerName;
            //                                    _lyr.Enabled = lyr.Enabled;
            //                                    _lyr.MaxVisible = lyr.MaxVisible;
            //                                    _lyr.MinVisible = lyr.MinVisible;
            //                                    _lyr.Transparency = lyr.Transparency;
            //                                }
            //                                else
            //                                {
            //                                    MessageForm.Show(
            //                                        "Previously saved settings can’t be applied to Chart layer. Probably you have already changed the list of chart fields of the AVR layer. Default settings will be applied.",
            //                                        "Uncompatible Chart Layer Settings", MessageBoxButtons.OK,
            //                                        MessageBoxIcon.Warning);
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }

            #endregion

            return dataSet;
        }

        /// <summary>
        /// Return image for specific Id and Hex Color
        /// </summary>
        /// <param name="symbolId">Symbol Id</param>
        /// <param name="hexColor">Symbol color as a hex string</param>
        /// <returns>Image as a byte array</returns>
        public static byte[] GetSymbolImage(long symbolId, string hexColor = "")
        {
            var connectionString = ConnectionManager.DefaultInstance.ConnectionString;
            var symbolSet = new SymbolSet(connectionString);
            var ms = new MemoryStream();
            var img = symbolSet.GetImage(symbolId);
            
            if (img == null)
            {
                img = new Bitmap(16, 16);
                //((Bitmap)img).MakeTransparent(Color.White);
                var g = Graphics.FromImage(img);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                Color color;
                try
                {
                    color = hexColor == "" ? Color.Green : ColorTranslator.FromHtml(hexColor);
                }
                catch (Exception ex)
                {
                    color = Color.Green;
                    Trace.WriteLine(ex);
                }

                var rect = new Rectangle(0, 0, 15, 15);
                switch (symbolId)
                {
                    case 0:
                        g.FillEllipse(new SolidBrush(color), rect);
                        g.DrawEllipse(new Pen(Color.Black, 1), rect);
                        break;
                    case 1:
                        var pntArrey = new PointF[3];
                        pntArrey[0] = new PointF(0, 14);
                        pntArrey[1] = new PointF(7f, 0);
                        pntArrey[2] = new PointF(14, 14);
                        g.FillPolygon(new SolidBrush(color), pntArrey);
                        g.DrawPolygon(new Pen(Color.Black, 1), pntArrey);
                        break;
                    default:
                        g.FillRectangle(new SolidBrush(color), rect);
                        g.DrawRectangle(new Pen(Color.Black, 1), rect);
                        break;
                }
                g.Dispose();
            }
            //img.Save(@"C:/test.png", ImageFormat.Png);    
            img.Save(ms,ImageFormat.Png);
            
            symbolSet.Dispose();

            return ms.ToArray();
        }

        private static ITheme ReplaceColumnName(EventLayer layerSerialized)
        {
            if (layerSerialized.Theme == null)
            {
                // nothing to replace
                return layerSerialized.Theme;
            }
            else if (layerSerialized.Theme is GIS_V4.Rendering.GradientTheme)
            {
                var input = ((GIS_V4.Rendering.GradientTheme)layerSerialized.Theme).ColumnName;

                const string pattern = @"gisBegin_[\s\S\d\D\w\W]*_gisEnd";
                const string replacement = "";

                var rgx = new Regex(pattern);

                ((GIS_V4.Rendering.GradientTheme)layerSerialized.Theme).ColumnName = rgx.Replace(input, replacement);
            }
            else if (layerSerialized.Theme is GraduatedTheme)
            {
                var input = ((GraduatedTheme)layerSerialized.Theme).FieldName;

                const string pattern = @"gisBegin_[\s\S\d\D\w\W]*_gisEnd";
                const string replacement = "";

                var rgx = new Regex(pattern);

                ((GraduatedTheme)layerSerialized.Theme).FieldName = rgx.Replace(input, replacement);

                // redefine rules
                const string pattern_c = @"gisBegin_";
                const string pattern_c2 = @"_gisEnd[^\]]*";
                var rgx_c = new Regex(pattern_c);
                var rgx_c2 = new Regex(pattern_c2);

                foreach (var rule in ((GraduatedTheme)layerSerialized.Theme).Rules)
                {
                    rule.Condition = rgx_c.Replace(rule.Condition, "");
                    rule.Condition = rgx_c2.Replace(rule.Condition, "");
                }
            }
            else if (((EventLayer)layerSerialized).Theme is RuleBasedTheme)
            {

            }
            else
            {

            }

            return layerSerialized.Theme;

        }

        public static void GetAvrStyles
            (long layoutId, out string gradLayerName, out ITheme gradLayerTheme, out string chartLayerName,
             out ITheme chartLayerTheme)
        {
            gradLayerTheme = null;
            chartLayerTheme = null;
            gradLayerName = chartLayerName = string.Empty;


            #region Get layer settings

            const string TasLayout = "tasLayout";
            byte[] GisLayerLocalSettingsZip;
            string GisLayerLocalSettingsXml;
            XmlDocument xmlSetting = null;

            try
            {
                var ds = new DataSet();
                //IDbCommand cmd = CreateSPCommand("spAsMapSettingsSelectDetail");

                var cmd = new SqlCommand("spAsMapSettingsSelectDetail",
                                         (SqlConnection) ConnectionManager.DefaultInstance.Connection)
                    {
                        CommandTimeout = 300,
                        CommandType = CommandType.StoredProcedure
                    };

                cmd.Parameters.Add(new SqlParameter("@LangID", ModelUserContext.CurrentLanguage));
                cmd.Parameters.Add(new SqlParameter("@LayoutID", layoutId));

                DbDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds, TasLayout);
                ds.EnforceConstraints = false;
                if (ds.Tables[TasLayout].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[TasLayout].Rows[0];
                    if (bv.common.Core.Utils.IsEmpty(row["blbGisLayerGeneralSettings"])) return;
                    GisLayerLocalSettingsZip = (byte[]) row["blbGisLayerGeneralSettings"];
                    GisLayerLocalSettingsXml = BinaryCompressor.UnzipString(GisLayerLocalSettingsZip);
                    xmlSetting = new XmlDocument();
                    xmlSetting.LoadXml(GisLayerLocalSettingsXml);
                    ds.EnforceConstraints = true;
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug(ex.ToString());
                return;
            }

            #endregion

            if (xmlSetting == null) return;

            var tmpGroup =
                GIS_V4.Serializers.LayerSerializers.LayerGroupSerializer.Instance.Deserialize(
                    (XmlElement) xmlSetting.ChildNodes[0]);

            foreach (var layer in tmpGroup.Layers)
            {
                if (layer is LabelLayer) { continue; }
                ((EventLayer)layer).Theme = ReplaceColumnName((EventLayer)layer);

                if ((string) layer.Tag == "event_gradient")
                {
                    gradLayerName = layer.LayerName;
                    gradLayerTheme = ((VectorLayer) layer).Theme;
                }
                if ((string) layer.Tag == "event_chart")
                {
                    chartLayerName = layer.LayerName;
                    chartLayerTheme = ((VectorLayer) layer).Theme;
                }
            }
        }

        #endregion

        

    }

}
