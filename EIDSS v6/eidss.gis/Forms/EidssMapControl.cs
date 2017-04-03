using System;
using System.ComponentModel;
using System.Data.SqlClient;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using GIS_V4.Layers;
using SharpMap.Styles;
using bv.common.db.Core;
using bv.winclient.Core;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DotSpatial.Projections;
using eidss.gis.Data.Providers;
using eidss.gis.Layers;
using eidss.gis.Serializers;
using eidss.gis.Tools;
using eidss.gis.Utils;
using eidss.model.Core;
using eidss.model.Resources;
using GIS_V4.Common;
using GIS_V4.Forms;
using GIS_V4.Tools;
using SharpMap.Geometries;

namespace eidss.gis.Forms
{
    public class EidssMapControl:MapControl
    {
        #region Tools
        
        protected MtFixedExtent mtFixedExtent = new MtFixedExtent();
        private MapBarButton buttonFixedExtent = new MapBarButton();

        private MtInfo mtInfo = new MtInfo();
        private MapBarButton buttonInfo = new MapBarButton();
        
        private MtAddDbLayer mtAddDbLayer = new MtAddDbLayer();
        private MapBarButton buttonAddDbLayer = new MapBarButton();

        private MapSelector m_MapSelector;
        private GeoSearch m_GeoSearch;

        public MapSelector MapSelector
        {
            get { return m_MapSelector; }
        }

        #endregion

        #region Vars
        private Object lockObj = new Object();
        protected bool m_ErrorFormShowed;
        private MtZoneLayerSelector m_ZlyrSelector = null;

        #endregion

        #region Admin Mask

        private LayerGroup m_MaskGroup;
        private VectorLayer m_CountryMask, m_RegionMask, m_DistrictMask;
        
        private void InitAdminMask()
        {
            // Admin mask
            m_MaskGroup = new LayerGroup("Administrative Unit Mask");

            m_CountryMask = new EidssSystemDbLayer("Country Mask");
            m_CountryMask.DataSource = new EidssSqlServer2008(SystemLayerNames.Countries);

            m_RegionMask = new EidssSystemDbLayer("Regional Mask");
            m_RegionMask.DataSource = new EidssSqlServer2008(SystemLayerNames.Regions);

            m_DistrictMask = new EidssSystemDbLayer("District Mask");
            m_DistrictMask.DataSource = new EidssSqlServer2008(SystemLayerNames.Rayons);

            m_MaskGroup.Layers.Add(m_CountryMask);
            m_MaskGroup.Layers.Add(m_RegionMask);
           
        }

        #endregion

        public EidssMapControl()
        {
            //Tool-bar reset wholerow flag
            barManager.Bars["Tools"].OptionsBar.UseWholeRow = false;

            //Add Fix Extent button
            InitFixedExtentTool();

            InitInfo();

            //Add Db layer tool 
            InitAddDbLayerTool();

            //Set URLs for our local cache tile server
            UpdateLocalTilecacheUrl();

            //remove cs label from Status Bar
            CoordSysBarVisible = false;

            //activate def tool
            if (DefaultTool is ControllerMapTool)
                (DefaultTool as ControllerMapTool).IsActive = true;

            // connect symbol set
            var strConnection = ConnectionManager.DefaultInstance.ConnectionString;
            SymbolGallery = new SymbolSet(strConnection);
            
            //InitAdminMask();
            
            EidssMapSerializer.Instance.LayerDeserializationExceptionEvent += Instance_LayerDeserializationExceptionEvent;
        }

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            EidssMapSerializer.Instance.LayerDeserializationExceptionEvent -= Instance_LayerDeserializationExceptionEvent;
            
            if (m_ZlyrSelector != null)
            {
                m_ZlyrSelector.Dispose();
                m_ZlyrSelector = null;
            }

            if (m_MapSelector != null)
            {
                m_MapSelector.Dispose();
                m_MapSelector = null;
            }
            if (m_mapImage != null && !m_mapImage.IsDisposed)
            {
                m_mapImage.Dispose(); //Crash where! 
                m_mapImage = null;
            }
            if (m_MapContent != null)
            {
                m_MapContent.Map = null;
            }

            base.Dispose(disposing);
        }

        private void InitInfo()
        {
            mtInfo.Content = m_MapContent;
            mtInfo.MapImage = m_mapImage;
            mtInfo.ConnectionString = ConnectionManager.DefaultInstance.ConnectionString;
            buttonInfo.MapTool = mtInfo;
            buttonInfo.Name = "buttonInfo";
            barManager.Bars["Tools"].LinksPersistInfo.Insert(3, new LinkPersistInfo(buttonInfo));
            mtInfo.LoadTranslations();
        }

        private void InitFixedExtentTool()
        {
            using(var conn = new SqlConnection(ConnectionManager.DefaultInstance.ConnectionString))
            {
                conn.Open();
                var countryBox = common.Extents.GetGeomById(conn, SystemLayerNames.Countries,
                                                         EidssSiteContext.Instance.CountryID).GetBoundingBox();
                //Not need after reproject
                //countryBox = GeometryTransform.TransformBox(countryBox, CoordinateSystems.WGS84,
                //                               CoordinateSystems.SphericalMercatorCS);
                mtFixedExtent.Extent = countryBox;
            }
           
            mtFixedExtent.MapImage = m_mapImage;
            buttonFixedExtent.MapTool = mtFixedExtent;
            buttonFixedExtent.Name = "buttonFixedExtent";

            barManager.Bars["Tools"].LinksPersistInfo.Insert(2, new LinkPersistInfo(buttonFixedExtent));
        }

        private void InitAddDbLayerTool()
        {
            mtAddDbLayer.MapImage = m_mapImage;
            mtAddDbLayer.MapContent = m_MapContent;

            buttonAddDbLayer.MapTool = mtAddDbLayer;
            buttonAddDbLayer.Name = "buttonAddDbLayer";

            barManager.Bars["Add layers"].LinksPersistInfo.Insert(0, new LinkPersistInfo(buttonAddDbLayer));
        }

        private void UpdateLocalTilecacheUrl()
        {
            //TODO[enikulin]: Impliment GetGlobalSiteOptions
            var baseUrl = "http://map.eidss.ge:8087"; //EidssSiteContext.Instance.GetSiteOption("GisTileUrl");
            string mapUrl = string.Format("{0}/{1}", baseUrl, "base");
            string labelUrl = string.Format("{0}/{1}", baseUrl, EidssUserContext.CurrentLanguage);

            mtAddLocalTiledLayer.LayersUrls.Add(labelUrl, "Local cache labels");
            mtAddLocalTiledLayer.LayersUrls.Add(mapUrl, "Local cache");
        }

        public delegate void LoadEventHandler(string mapName);
        //public delegate void BeforeLoadEventHandler(string mapName, CancelEventArgs e);
        public event LoadEventHandler MapLoaded;
        public event LoadEventHandler BeforeMapLoaded;

        public void OnBeforeMapLoad(string mapName)
        {
            var handler = BeforeMapLoaded;
            if (handler != null)
            {
                handler(mapName);
            }
        }


        public delegate void MapChangeHandler(CancelEventArgs e);

        public event MapChangeHandler MapChanging;

        public void OnMapChanging(CancelEventArgs e)
        {
            var handler = MapChanging;
            if (handler != null)
            {
                handler(e);
            }
        }

        public void OnMapLoad(string mapName)
        {
            if (MapLoaded != null) MapLoaded(mapName);
        }

        public override void LoadMap(string mapName)
        {
            m_ErrorFormShowed = false;
            m_mapImage.Map = EidssMapSerializer.Instance.DeserializeFromFile(mapName);
            m_mapImage.Map.Size = m_mapImage.Size;
            m_mapImage.Map.ZoomToBox(mtFixedExtent.Extent);
            TranslateToc(mapName);
            RefreshContent();

            // connect symbol set
            var strConnection = ConnectionManager.DefaultInstance.ConnectionString;
            SymbolGallery = new SymbolSet(strConnection);

            UseDynamicData();

            OnMapLoad(mapName);
        }
     
        void Instance_LayerDeserializationExceptionEvent(string layerName, string type, Exception ex)
        {
            lock (lockObj)
           {
            if (!m_ErrorFormShowed)
            {
                m_ErrorFormShowed = true;
                var message = EidssMessages.GetForCurrentLang("gis_LayerCantBeLoaded",
                                                              "One or more layers can't be loaded!");
                //ErrorForm.ShowError(message, ex); //TODO [enikulin]: NEED REQURES!
            }
           }
        }

        public void InitMapProjectToolBar()
        {
            #region Create GeoSearch bar

            var geoSearchBar = new Bar(barManager, "GeoSearch");
            geoSearchBar.OptionsBar.AllowDelete = false;
            geoSearchBar.OptionsBar.AllowQuickCustomization = false;
            geoSearchBar.OptionsBar.DisableClose = true;
            geoSearchBar.OptionsBar.DisableCustomization = true;
            geoSearchBar.DockStyle = BarDockStyle.Top;
            geoSearchBar.CanDockStyle = BarCanDockStyle.Top;
            geoSearchBar.OptionsBar.BarState = BarState.Expanded;
            geoSearchBar.Visible = true;
            geoSearchBar.DockRow = 0;
            geoSearchBar.DockCol = 3;
            geoSearchBar.ApplyDockRowCol();
            
            //create MapSelectorTool
            var beGeoSearch = new RepositoryItemButtonEdit();
            //beGeoSearch.Buttons[0].ToolTip = "Search for administrative unit";
            beGeoSearch.Buttons[0].Kind = ButtonPredefines.Glyph;
            beGeoSearch.Buttons[0].Caption = EidssMessages.GetForCurrentLang("gis_Geosearch_Button_Text", "Search"); //"Search";

            var toolTipTitle = new ToolTipTitleItem();
            toolTipTitle.Text = EidssMessages.GetForCurrentLang("gis_Geosearch_Tooltip", "Search for administrative unit");
            var superToolTip = new SuperToolTip();
            superToolTip.Items.Add(toolTipTitle);

            var beiGeoSearch = new BarEditItem(barManager, beGeoSearch)
                {
                    SmallWithoutTextWidth = 130,
                    SmallWithTextWidth = 130,
                    Width = 130,
                    SuperTip = superToolTip
                };
            

            m_GeoSearch = new GeoSearch {MapControl = m_mapImage, ControlForVisualize = beiGeoSearch};

            geoSearchBar.AddItem(beiGeoSearch);
            beiGeoSearch.Visibility = BarItemVisibility.Always;

            beGeoSearch.ButtonClick += beGeoSearch_ButtonClick;
            

            #endregion


            //create map projects bar
            var mapsBar = new Bar(barManager, "MapProjects");
            mapsBar.OptionsBar.AllowDelete = false;
            mapsBar.OptionsBar.AllowQuickCustomization = false;
            mapsBar.OptionsBar.DisableClose = true;
            mapsBar.OptionsBar.DisableCustomization = true;
            mapsBar.DockStyle = BarDockStyle.Top;
            mapsBar.CanDockStyle = BarCanDockStyle.Top;
            mapsBar.OptionsBar.BarState = BarState.Expanded;
            mapsBar.Visible = true;
            mapsBar.DockRow = 0;
            mapsBar.DockCol = 0;
            mapsBar.ApplyDockRowCol();
            
            //create New project tool
            var mbb = new MapBarButton();
            CommandMapTool mTool = new MtNewMap() { MapImage = m_mapImage };
            mbb.MapTool = mTool;
            mapsBar.AddItem(mbb);

            //create Open map tool
            mbb = new MapBarButton();
            mTool = new MtOpenMap() { MapImage = m_mapImage };
            mbb.MapTool = mTool;
            mapsBar.AddItem(mbb);

            //create Save map tool
            mbb = new MapBarButton();
            mTool = new MtSaveMap() { MapImage = m_mapImage };
            mbb.MapTool = mTool;
            mapsBar.AddItem(mbb);

            //create Save Map As tool
            mbb = new MapBarButton();
            mTool = new MtSaveMapAs() { MapImage = m_mapImage };
            mbb.MapTool = mTool;
            mapsBar.AddItem(mbb);

            //create ExportTool
            mbb = new MapBarButton();
            mTool = new MtExportMap { MapImage = m_mapImage };
            mbb.MapTool = mTool;
            mapsBar.AddItem(mbb);

            //create ImportTool
            mbb = new MapBarButton();
            mTool = new MtImportMap { MapImage = m_mapImage };
            mbb.MapTool = mTool;
            mapsBar.AddItem(mbb);

            //create ExportImage Tool
            mbb = new MapBarButton();
            mTool = new MtExportAsImage { MapImage = m_mapImage };
            mbb.MapTool = mTool;
            mapsBar.AddItem(mbb);

            //create Admin filter Tool
            mbb = new MapBarButton();
            mTool = new MtAdminMask() { MapImage = m_mapImage };
            mbb.MapTool = mTool;
            mapsBar.AddItem(mbb);

            //create MapSelectorTool
            var cmb = new RepositoryItemComboBox();
            var bei = new BarEditItem(barManager, cmb);
            bei.SmallWithoutTextWidth = 118;
            bei.SmallWithTextWidth = 118;
            bei.Width = 118;

            if (m_MapSelector != null)
            {
                m_MapSelector.Dispose();
            }
            m_MapSelector = new MapSelector { MapControl = m_mapImage, ControlForVisualize = bei };
            m_MapSelector.MapChanging += m_MapSelector_MapChanging;

            mapsBar.AddItem(bei);
            bei.Visibility = BarItemVisibility.Never;
        }

        void beGeoSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var be = sender as ButtonEdit;
            if (be != null)
                m_GeoSearch.NewSearch(be.Text);
        }

        void m_MapSelector_MapChanging(CancelEventArgs e)
        {
            OnMapChanging(e);
        }

        public void InitLightMapProjectToolBar()
        {
            #region Create GeoSearch bar

            var geoSearchBar = new Bar(barManager, "GeoSearch");
            geoSearchBar.OptionsBar.AllowDelete = false;
            geoSearchBar.OptionsBar.AllowQuickCustomization = false;
            geoSearchBar.OptionsBar.DisableClose = true;
            geoSearchBar.OptionsBar.DisableCustomization = true;
            geoSearchBar.DockStyle = BarDockStyle.Top;
            geoSearchBar.CanDockStyle = BarCanDockStyle.Top;
            geoSearchBar.OptionsBar.BarState = BarState.Expanded;
            geoSearchBar.Visible = true;
            geoSearchBar.DockRow = 0;
            geoSearchBar.DockCol = 3;
            geoSearchBar.ApplyDockRowCol();

            //create MapSelectorTool
            var beGeoSearch = new RepositoryItemButtonEdit();
            //beGeoSearch.Buttons[0].ToolTip = "Search for administrative unit";
            beGeoSearch.Buttons[0].Kind = ButtonPredefines.Glyph;
            beGeoSearch.Buttons[0].Caption = "Search";

            var toolTipTitle = new ToolTipTitleItem();
            toolTipTitle.Text = EidssMessages.GetForCurrentLang("gis_Geosearch_Tooltip", "Search for administrative unit");
                //"Search for administrative unit";
            var superToolTip = new SuperToolTip();
            superToolTip.Items.Add(toolTipTitle);

            var beiGeoSearch = new BarEditItem(barManager, beGeoSearch)
            {
                SmallWithoutTextWidth = 130,
                SmallWithTextWidth = 130,
                Width = 130,
                SuperTip = superToolTip
            };


            m_GeoSearch = new GeoSearch { MapControl = m_mapImage, ControlForVisualize = beiGeoSearch };

            geoSearchBar.AddItem(beiGeoSearch);
            beiGeoSearch.Visibility = BarItemVisibility.Always;

            beGeoSearch.ButtonClick += beGeoSearch_ButtonClick;


            #endregion

            //create map projects bar
            var mapsBar = new Bar(barManager, "MapProjects");
            mapsBar.OptionsBar.AllowDelete = false;
            mapsBar.OptionsBar.AllowQuickCustomization = false;
            mapsBar.OptionsBar.DisableClose = true;
            mapsBar.OptionsBar.DisableCustomization = true;

            mapsBar.DockStyle = BarDockStyle.Top;
            mapsBar.CanDockStyle = BarCanDockStyle.Top;
            mapsBar.OptionsBar.BarState = BarState.Expanded;
            mapsBar.Visible = true;
            mapsBar.DockRow = 0;
            mapsBar.DockCol = 0;
            mapsBar.ApplyDockRowCol();
            
            //create ExportImage Tool
            var mbb = new MapBarButton();
            var mTool = new MtExportAsImage { MapImage = m_mapImage };
            mbb.MapTool = mTool;
            mapsBar.AddItem(mbb);

            //create Admin filter Tool
            mbb = new MapBarButton();
            var mTool1 = new MtAdminMask() { MapImage = m_mapImage };
            mbb.MapTool = mTool1;
            mapsBar.AddItem(mbb);

            //create MapSelectorTool
            var cmb = new RepositoryItemComboBox();
            var bei = new BarEditItem(barManager, cmb);
            bei.SmallWithoutTextWidth = 118;
            bei.SmallWithTextWidth = 118;
            bei.Width = 118;

            if (m_MapSelector != null)
            {
                m_MapSelector.Dispose();
            }
            m_MapSelector = new MapSelector { MapControl = m_mapImage, ControlForVisualize = bei, Content = m_MapContent };
            m_MapSelector.MapChanging += m_MapSelector_MapChanging;

            mapsBar.AddItem(bei);
        }

        
        public void InitBufZonesToolBar()
        {
            //create map projects bar
            var mapsBar = new Bar(barManager, "BufferZones");
            mapsBar.OptionsBar.AllowDelete = false;
            mapsBar.OptionsBar.AllowQuickCustomization = false;
            mapsBar.OptionsBar.DisableClose = true;
            mapsBar.OptionsBar.DisableCustomization = true;

            mapsBar.DockStyle = BarDockStyle.Top;
            mapsBar.CanDockStyle = BarCanDockStyle.Top;
            mapsBar.OptionsBar.BarState = BarState.Expanded;
            mapsBar.Visible = true;
            mapsBar.DockRow = 0;
            mapsBar.DockCol = 4;
            mapsBar.ApplyDockRowCol();


            //create AddBufZonesLayer tool
            var mbb = new MapBarButton();
            CommandMapTool mCommandTool = new MtAddBufZonesLayer { MapImage = m_mapImage};
            mbb.MapTool = mCommandTool;
            mapsBar.AddItem(mbb);

            //create MapSelectorTool
            var cmb = new RepositoryItemComboBox();
            var bei = new BarEditItem(barManager, cmb) { SmallWithoutTextWidth = 90, SmallWithTextWidth = 90, Width = 90};

            if (m_ZlyrSelector != null)
            {
                m_ZlyrSelector.Dispose();
            }
            m_ZlyrSelector = new MtZoneLayerSelector { ControlForVisualize = bei, MapControl = m_mapImage, AddBufZoneLayer = (MtAddBufZonesLayer)mCommandTool };
            mapsBar.AddItem(bei);

            //create CircleWithCenterBufZone tool
            mbb = new MapBarButton();
            ControllerMapTool mControllerTool = new MtCircleWithCenterBufZone
                                                    {
                                                        MapImage = m_mapImage,
                                                        ConnectionString =
                                                            ConnectionManager.DefaultInstance.ConnectionString,
                                                        ZoneLayerSelector = m_ZlyrSelector,
                                                        Content = m_MapContent
                                                    };
            mbb.MapTool = mControllerTool;
            mapsBar.AddItem(mbb);

            //create IndependentCircleBufferZone tool
            mbb = new MapBarButton();
            mControllerTool = new MtIndependentCircleBufferZone { MapImage = m_mapImage, ZoneLayerSelector = m_ZlyrSelector, Content = m_MapContent };
            mbb.MapTool = mControllerTool;
            mapsBar.AddItem(mbb);

            //create PolygonBufferZone tool
            mbb = new MapBarButton();
            mControllerTool = new MtPolygonBufferZone
                                  {
                                      MapImage = m_mapImage,
                                      ZoneLayerSelector = m_ZlyrSelector,
                                      Content = m_MapContent,
                                      ConnectionString =
                                          ConnectionManager.DefaultInstance.ConnectionString
                                  };
            mbb.MapTool = mControllerTool;
            mapsBar.AddItem(mbb);

            //create IndependentPolygonBufferZone tool
            mbb = new MapBarButton();
            mControllerTool = new MtIndependentPolygonBufferZone { MapImage = m_mapImage, ZoneLayerSelector = m_ZlyrSelector,  Content = m_MapContent};
            mbb.MapTool = mControllerTool;
            mapsBar.AddItem(mbb);

            //create RemoveBufZones tool
            mbb = new MapBarButton();
            mControllerTool = new MtSelectBufZones { MapImage = m_mapImage, ZoneLayerSelector = m_ZlyrSelector, Content = m_MapContent};
            mbb.MapTool = mControllerTool;
            mapsBar.AddItem(mbb);

            //var mapSelector = new MapSelector { MapControl = m_mapImage, ControlForVisualize = bei };

            

        }

        /// <summary>
        /// Zoom map control to specified extent
        /// </summary>
        /// <param name="box">Extent</param>
        public void ZoomToBox(BoundingBox box)
        {
            Map.ZoomToBox(box);
        }

        protected void TranslateToc(string newMapPath)
        {
            var mapPath = newMapPath.Replace("\\\\", "\\");

            if (mapPath == MapProjectsStorage.DefaultMapPath) //translate only default map
                foreach (var layer in m_mapImage.Map.Layers)
                    layer.LayerName = MapProjectsStorage.TranslateLayerName(layer.LayerName);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EidssMapControl));
            ((System.ComponentModel.ISupportInitialize)(this.m_mapImage)).BeginInit();
            this.SuspendLayout();
            // 
            // m_MapContent
            // 
            this.m_MapContent.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("m_MapContent.Appearance.Font")));
            this.m_MapContent.Appearance.Options.UseFont = true;
            // 
            // EidssMapControl
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "EidssMapControl";
            ((System.ComponentModel.ISupportInitialize)(this.m_mapImage)).EndInit();
            this.ResumeLayout(false);

        }

    }
}
