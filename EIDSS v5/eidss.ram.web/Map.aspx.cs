using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BruTile.PreDefined;
using BruTile.Web;
using DevExpress.Web.ASPxCallback;
using DevExpress.Web.ASPxEditors;
using DevExpress.XtraPivotGrid;
using DotSpatial.Projections;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Components;
using GIS_V4.Common;
using GIS_V4.Data.Providers;
using GIS_V4.Layers;
using GeospatialServices.GeoJSON;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.SqlServer.Types;
using SharpMap.Converters.WellKnownBinary;
using SharpMap.Data;
using SharpMap.Geometries;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using eidss.gis;
using eidss.gis.Forms;
using eidss.gis.common;
using eidss.ram.web.Components;
using eidss.ram.web.Components.Export;
using Point = SharpMap.Geometries.Point;

namespace eidss.ram.web
{
    public partial class Map : BasePage
    {
        public string json;
        public bool map_issingle = true;
        public string m_map_type = "";
        public string m_map_url = ConfigurationManager.AppSettings["MapLocalUrl"] + "/base";

        public string m_map_url_label = ConfigurationManager.AppSettings["MapLocalUrl"] + '/' +
                                        CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        private WebMapExporter m_MapExporter;

        public WebRamFormView WebRamForm
        {
            get
            {
                if (Session[WebRamFormView.SessionObjectName] == null)
                {
                    Session[WebRamFormView.SessionObjectName] = new WebRamFormView(this, PivotGrid, false);
                }
                return (WebRamFormView) Session[WebRamFormView.SessionObjectName];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RamPivotGrid winPivotGrid = WebRamForm.WinPivotGrid;
            PivotGrid.CreateWebPivotGridFrom(winPivotGrid);

            if (!IsPostBack && !Page.IsCallback)
            {
                PivotGrid.Criteria = (WebRamForm.IsMapCriteriaChanged)
                                         ? WebRamForm.MapCriteria
                                         : winPivotGrid.Criteria;
                FilterCaption.Text = PivotGrid.FriendlyCriteriaString;
                if (string.IsNullOrEmpty(CaptionTextBox.Text))
                {
                    CaptionTextBox.Text = WebRamForm.MapName;
                }

                SetHeader();
                InitAdmUnitItems();
                InitDataFieldItems();
            }

            PivotGrid.AggregateTable = WebRamForm.AggregateTable;
            PivotGrid.DenominatorIndexes = PivotPresenter.GetIndexesDictionary(WebRamForm.AggregateTable,
                                                                               PivotGrid.Fields);
            //
            PivotGrid.DataSource = WebRamForm.PivotPreparedDataSource;
            PivotGrid.NameSummaryTypeDictionary = WebRamForm.PreparedNameSummaryTypeDictionary;

            m_MapExporter = new WebMapExporter(this);

            // it needs to save or export
            if (!string.IsNullOrEmpty(Request.QueryString["gisData"]))
            {
                
                int pageIndex;
                if (int.TryParse(Utils.Str(Request.QueryString["PivotGridPageIndex"]), out pageIndex))
                {
                    PivotGrid.OptionsPager.PageIndex = pageIndex;
                }
                MapHiddenField.Value = Request.QueryString["gisData"];
                SaveExport(false);
            }
            // page loads first time and no need to export
            else if (!IsPostBack && !Page.IsCallback)
            {
                buttonApply_Click(this, EventArgs.Empty);
            }
        }

        private void SetHeader()
        {
            if (Master != null)
            {
                string queryPath = string.Format("{0}->{1}", "AVR", WebRamForm.QueryName);
                string layoutPath = string.Format("{0}->{1}", queryPath, WebRamForm.LayoutName);
                var master = ((SiteMaster)Master);
                master.QueryPathText = queryPath;
                master.LayoutHeaderText = layoutPath;
                if (!Utils.IsEmpty(Session[WebRamFormView.LayoutWarning]))
                {
                    master.LayoutWarningText = Session[WebRamFormView.LayoutWarning].ToString();
                }

            }
        }

        #region Binding

        private void InitDataFieldItems()
        {
            DataField.Items.Clear();
            foreach (WebPivotGridField field in GetAllFieldsInData())
            {
                DataField.Items.Add(new ListEditItem(field.Caption, field.FieldName));
            }
            if (DataField.Items.Count > 0)
            {
                DataField.SelectedIndex = 0;
            }
        }

        private void InitAdmUnitItems()
        {
            DataView dvMapFieldList = PivotPresenter.GetMapFiledView(WebRamForm.QueryId, true);

            AdministrativeUnit.Items.Clear();
            foreach (DataRowView r in dvMapFieldList)
            {
                IEnumerable<WebPivotGridField> fields = GetFieldsInRow(Utils.Str(r["FieldAlias"]));
                foreach (WebPivotGridField field in fields)
                {
                    AdministrativeUnit.Items.Add(new ListEditItem(field.Caption, field.FieldName));
                }
            }
            if (AdministrativeUnit.Items.Count > 0)
            {
                AdministrativeUnit.SelectedIndex = 0;
            }
        }

        private IEnumerable<WebPivotGridField> GetFieldsInRow(string originalFieldName)
        {
            Utils.CheckNotNullOrEmpty(originalFieldName, "originalFieldName");

            List<WebPivotGridField> fields = PivotGrid.WebFields.ToList();
            List<WebPivotGridField> found = fields.FindAll(field => (field.Visible) &&
                                                                    (field.AreaIndex >= 0) &&
                                                                    (field.Area == PivotArea.RowArea) &&
                                                                    (field.OriginalName == originalFieldName));

            return found;
        }

        private IEnumerable<WebPivotGridField> GetAllFieldsInData()
        {
            List<WebPivotGridField> fields = PivotGrid.WebFields.ToList();
            List<WebPivotGridField> found = fields.FindAll(field => (field.Visible) &&
                                                                    (field.AreaIndex >= 0) &&
                                                                    (field.Area == PivotArea.DataArea));
            IOrderedEnumerable<WebPivotGridField> sorted = found.OrderBy(field => field.AreaIndex);
            return sorted;
        }

        #endregion

        #region Handlers

        protected void PivotGrid_PrefilterCriteriaChanged(object sender, EventArgs e)
        {
            WebRamForm.MapCriteria = PivotGrid.Criteria;
            WebRamForm.WinPivotGrid.Criteria = PivotGrid.Criteria;
        }

        protected void cbControl_Callback(object source, CallbackEventArgs e)
        {
            if (IsCallback)
            {
                cbControl.JSProperties["cpNeedChangeFilterCaptionText"] = true;
                cbControl.JSProperties["cpFilterCaptionText"] = PivotGrid.FriendlyCriteriaString;
            }
            else
            {
                cbControl.JSProperties["cpNeedChangeFilterCaptionText"] = false;
            }
        }



        protected void buttonApply_Click(object sender, EventArgs e)
        {
            bool isSingle;
            DataTable gisData = GetGisData(out isSingle);

            bool hasData = gisData.Rows.Count != 0;
            buttonOpen.Enabled = hasData;
            buttonSaveAs.Enabled = hasData;
            shp_export.Enabled = hasData;

            PivotGridPageIndex.Value = PivotGrid.OptionsPager.PageIndex.ToString();
            ShowDataOnMap(gisData, isSingle);
        }

        protected void buttonOpen_Click(object sender, EventArgs e)
        {
            SaveExport(false);
        }

        protected void buttonSaveAs_Click(object sender, EventArgs e)
        {
            SaveExport(true);
        }

        private void SaveExport(bool saveAs)
        {
            bool isSingle;
            DataTable gisData = GetGisData(out isSingle);

            m_MapExporter.ImageToExport = GetGisImage(gisData);
            m_MapExporter.Export(WebExportFormat.Jpeg,
                                 PivotGrid.DataSource.TableName,
                                 new List<string> {CaptionTextBox.Text, FilterCaption.Text},
                                 saveAs);
        }

        #endregion

        #region GIS methods

        private Bitmap GetGisImage(DataTable gisData)
        {
            int localLayer;
            float x1;
            float x2;
            float y1;
            float y2;
            try
            {
                var reg = new Regex(@"([-\.0-9]+);([-\.0-9]+);([-\.0-9]+);([-\.0-9]+);([0-1])", RegexOptions.IgnoreCase);
                MatchCollection mc = reg.Matches(MapHiddenField.Value);
                Match match = mc[0];
                x1 = float.Parse(match.Groups[1].ToString(), CultureInfo.InvariantCulture);
                y1 = float.Parse(match.Groups[2].ToString(), CultureInfo.InvariantCulture);
                x2 = float.Parse(match.Groups[3].ToString(), CultureInfo.InvariantCulture);
                y2 = float.Parse(match.Groups[4].ToString(), CultureInfo.InvariantCulture);
                localLayer = int.Parse(match.Groups[5].ToString());
                // Console.WriteLine(mc.Count.ToString());
            }
            catch (Exception ex)
            {
                var errorImage = new Bitmap(1024, 768);
                Graphics graphics = Graphics.FromImage(errorImage);
                var font = new Font(BaseSettings.SystemFontName, 24);
                graphics.DrawString(ex.ToString(), font, Brushes.Black,
                                    new RectangleF(8, 8, errorImage.Width, errorImage.Height));
                return errorImage;
            }

            var mapControl = new AvrMapControl(true);

            // LOCAL LAYER
            if (localLayer > 0)
            {
                mapControl.mtAddLocalTiledLayer.LayersUrls.Clear();
                // Todo: move URL to config
                mapControl.mtAddLocalTiledLayer.LayersUrls.Add(m_map_url_label, "Cache map labels");
                mapControl.mtAddLocalTiledLayer.LayersUrls.Add(m_map_url, "Cache map");
                foreach (KeyValuePair<string, string> pair in mapControl.mtAddLocalTiledLayer.LayersUrls)
                {
                    //create layer and data source
                    var ds = new TmsTileSource(pair.Key, new SphericalMercatorInvertedWorldSchema());
                    var llayer = new TileLayer(ds, pair.Value, new Color(), false);
                    mapControl.Map.Layers.Insert(0, llayer);
                }
            }
            // OSM LAYER
            var layer = new TileLayer(new OsmTileSource(), "OSM Layer");
            mapControl.MapSpatRef = CoordinateSystems.SphericalMercatorCS;
            mapControl.Map.Layers.Insert(0, layer);

            // INIT EXTENT
            Point point1 = GeometryTransform.TransformPoint(new Point(x1, y1), CoordinateSystems.WGS84,
                                                            CoordinateSystems.SphericalMercatorCS);
            Point point2 = GeometryTransform.TransformPoint(new Point(x2, y2), CoordinateSystems.WGS84,
                                                            CoordinateSystems.SphericalMercatorCS);
            var bbox = new BoundingBox(point1.X, point1.Y, point2.X, point2.Y);
            mapControl.AddEventLayer("Title", "Layer", gisData, map_issingle, null);
            mapControl.ZoomToBox(bbox);
            mapControl.RefreshMap();

            // GET BMP
            Bitmap image = mapControl.GetMapImage(297, 210, 300);
            return image;
        }

        private DataTable GetGisData(out bool isSingle)
        {
            
            isSingle = true;
            DataTable mapTable;
            if (AdministrativeUnit.SelectedItem != null && AdministrativeUnit.SelectedItem.Value != null)
            {
                string idFieldName = AdministrativeUnit.SelectedItem.Value.ToString();
                PivotGrid.DataSelectedIndex = GetDataAreaIndex(WebRamForm.WinPivotGrid);
                mapTable = PivotPresenter.GetWebMapDataTable(PivotGrid, idFieldName, out isSingle);
            }
            else
            {
                mapTable = PivotPresenter.GetMapDataTable();
            }
            mapTable.TableName = WebRamForm.LayoutName;

            map_issingle = isSingle;

            return mapTable;
        }

     
        private int GetDataAreaIndex(RamPivotGrid winPivotGrid)
        {
            if (DataField.SelectedItem != null && DataField.SelectedItem.Value != null)
            {
                string fieldName = DataField.SelectedItem.Value.ToString();
                PivotGridField dataField = winPivotGrid.Fields[fieldName];
                if (dataField != null)
                {
                    return dataField.AreaIndex;
                }
            }
            return 0;
        }

        private void ShowDataOnMap(DataTable gisData, bool isSingle)
        {
            if (gisData.Rows.Count == 0)
            {
                m_map_type = "blank";
                return;
            }
            bool isRegion = false;
            string connectionString = ConnectionManager.DefaultInstance.ConnectionString;
            string lTableName = CoordinatesUtils.GetWKBTableName(gisData, connectionString);

            switch (lTableName)
            {
                case "gisWKBSettlement":
                    break;
                case "gisWKBRayon":
                case "gisWKBRegion":
                    isRegion = true;
                    break;
            }

            if (isSingle) {m_map_type = isRegion ? "avr_poly" : "avr_point";}
            else {m_map_type = isRegion ? "avr_pie" : "avr_marker";}
            if (m_map_type == "avr_marker") {gisData = GisInterface.TransposeDataTable(gisData, connectionString);}

            var column = new DataColumn {DataType = typeof (SqlGeometry), ColumnName = "geom"};
            gisData.Columns.Add(column);

            for (int i = 0; i < gisData.Rows.Count; i++)
            {
                Geometry feature;
                const int srid = 4326;

                long id = 0;
                if (gisData.Rows[i]["id"].ToString() != "")
                {
                    id = Int64.Parse(gisData.Rows[i]["id"].ToString());
                }
                if (m_map_type == "avr_poly")
                {
                    using (var sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        feature = Extents.GetGeomById(sqlConnection, lTableName, id);
                        if (feature != null)
                        {
                            feature = GeometryTransform.TransformGeometry(feature,
                                                                          CoordinateSystems.SphericalMercatorCS,
                                                                          CoordinateSystems.WGS84);
                        }
                    }
                }
                else
                {
                    double y;
                    double x;
                    if (id > 0)
                    {
                        CoordinatesUtils.GetAdminUnitCoordinates(connectionString, id, out x, out y);
                        gisData.Rows[i]["x"] = x;
                        gisData.Rows[i]["y"] = y;
                    }
                    else
                    {
                        x = Convert.ToDouble(gisData.Rows[i]["x"].ToString());
                        y = Convert.ToDouble(gisData.Rows[i]["y"].ToString());
                    }
                    feature = new Point(x, y);
                }

                if (feature != null)
                {
                    var wktGeometry = new SqlChars(feature.AsText());
                    gisData.Rows[i]["geom"] = SqlGeometry.STGeomFromText(wktGeometry, srid);

                    if (gisData.Rows[i]["geom"] == null)
                    {
                       // int aa = 1;
                    }
                }
            }
            var ds = new DataSet();
            ds.Tables.Add(gisData);

            json = GeoJSON.DataSetToJSON(ds);
            json = json.Replace("\\r\\n", " ");
        }

        #endregion

        protected void shp_export_Click(object sender, EventArgs e)
        {
            string connectionString = ConnectionManager.DefaultInstance.ConnectionString;
            string lShpPath = Server.MapPath("./tmp");
            string lShpName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());

            bool isSingle;

            var fds = new FeatureDataSet();
            DataTable data = GetGisData(out isSingle);
            if (data.Rows.Count == 0) {return;}
            var opts = new List<string>();

            var avrLayer = new EventLayer("User shape");

            string dataType = CoordinatesUtils.GetWKBTableName(data, connectionString);

            if (isSingle)
            {
                //single event type
                if (dataType != string.Empty)
                {
                    //use administrative
                    avrLayer.DataSource = new EventDataProvider(connectionString, CoordinatesUtils.GetWKBTableName(data, connectionString),
                                                                "geomShape",
                                                                "idfsGeoObject", data) {SRID = 3857};

                    ((EventDataProvider) avrLayer.DataSource).EventTable = data;
                    ((EventDataProvider) avrLayer.DataSource).EventIdColumn = "id";
                }
                else
                {
                    //use coordinates
                    var fdt = new FeatureDataTable();

                    foreach (DataColumn column in data.Columns)
                    {
                        fdt.Columns.Add(column.ColumnName, column.DataType);
                    }
                    fdt.Columns.Add("sharpmap_tempgeometry", typeof (byte[]));

                    foreach (DataRow dr in data.Rows)
                    {
                        FeatureDataRow newFeatureDataRow = fdt.NewRow();

                        foreach (DataColumn column in data.Columns)
                        {
                            string columnName = column.ColumnName;
                            newFeatureDataRow[columnName] = dr[columnName];
                        }

                        if (dr["x"] is double && dr["y"] is double)
                        {
                            var casePoint = new Point((double) dr["x"], (double) dr["y"]);
                            newFeatureDataRow.Geometry = casePoint;
                            newFeatureDataRow["sharpmap_tempgeometry"] =
                                GeometryToWKB.Write(newFeatureDataRow.Geometry);
                            fdt.AddRow(newFeatureDataRow);
                        }
                    }

                    avrLayer.DataSource = new GeometryProvider(fdt);
                }
            }

            //Проверка существования папки.
            if (!System.IO.Directory.Exists(lShpPath)) {System.IO.Directory.CreateDirectory(lShpPath);}

            BoundingBox boundingBoxMerc = avrLayer.DataSource.GetExtents();
//            BoundingBox boundingBox = GeometryTransform.TransformBox(boundingBoxMerc, CoordinateSystems.SphericalMercatorCS,
//                                                                     CoordinateSystems.WGS84);
            avrLayer.DataSource.ExecuteIntersectionQuery(boundingBoxMerc, fds);

            Ogr.ExportToOgr("ESRI Shapefile", lShpPath, lShpName + ".shp", fds.Tables[0], 4326, opts);
            ZipFile zipFile = ZipFile.Create(lShpPath + '\\' + lShpName + ".zip");
            zipFile.BeginUpdate();
            zipFile.Add(lShpPath + '\\' + lShpName + ".shp", lShpName + ".shp");
            zipFile.Add(lShpPath + '\\' + lShpName + ".shx", lShpName + ".shx");
            zipFile.Add(lShpPath + '\\' + lShpName + ".dbf", lShpName + ".dbf");
            zipFile.CommitUpdate();
            zipFile.Close();

            Response.AppendHeader("content-disposition", "attachment; filename=" + lShpName + ".zip");
            Response.ContentType = "application/zip";
            Response.WriteFile(lShpPath + '\\' + lShpName + ".zip");
        }
    }
}
