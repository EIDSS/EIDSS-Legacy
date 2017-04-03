using System;
using System.Data;
using System.Windows.Forms;
using GIS_V4.Forms;
using bv.common;
using bv.winclient.Core;
using eidss.gis.Forms;
using eidss.gis.common;
using eidss.gis.Data;
using eidss.gis.Data.Providers;
using eidss.gis.Layers;
using eidss.gis.Properties;
using eidss.gis.Tools.ToolForms;
using eidss.gis.Utils;
using eidss.model.Core;
using GIS_V4.Tools;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Geometries;

namespace eidss.gis.Tools
{
    public class MtPolygonBufferZone : ControllerMapTool
    {
        public MtPolygonBufferZone()
        {
            var temp = Resources.PolygonWithCross;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_MtPolygonBufferZone_Caption;
            m_ToolTipText = Resources.gis_MtPolygonBufferZone_ToolTipText;

            ////TMP!!!!!!!!!!!!!!!!! Remove after zone layer create/select functionality is done
            //PivotalType = PivotLayerType.Regions;

            IsEnabled = false;
        }

        public override MapImage MapImage
        {
            get
            {
                return base.MapImage;
            }
            set
            {
                base.MapImage = value;


                m_MapImage.Map.Layers.ListChanged += Layers_ListChanged;

                if (m_MapImage.Parent != null)
                    if (m_MapImage.Parent is EidssMapControl)
                        ((EidssMapControl)(m_MapImage.Parent)).MapLoaded += MtPolygonBufferZone_MapLoaded;

                //if (m_MapImage.Parent != null)
                //    if (m_MapImage.Parent is AvrMapControl)
                //        ((AvrMapControl)(m_MapImage.Parent)).GettingMapSettings += MtIndependentCircleBufferZoneGettingMapSettings;
            }
        }

        void MtPolygonBufferZone_MapLoaded(string mapName)
        {
            IsActive = IsEnabled = false;
        }

        void Layers_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            IsActive = IsEnabled = false;
        }

        protected override void OnToolActivated()
        {
            switch (PivotalType)
            {
                case PivotLayerType.Districts:
                    m_PivotalProvider = new EidssSqlServer2008(SystemLayerNames.Rayons);
                    LoadTranslations();
                    break;
                case PivotLayerType.Regions:
                    m_PivotalProvider = new EidssSqlServer2008(SystemLayerNames.Regions);
                    LoadTranslations();
                    break;
                default:
                    m_PivotalProvider = null;
                    break;
            }
            
            MapImage.Cursor = Cursors.Cross;
            MapImage.MouseDown += MapImage_MouseDown;
        }

        void MapImage_MouseDown(Point worldPos, MouseEventArgs e)
        {
            string strName;

            var geom = GetArealGeom(worldPos, out strName);
            if (geom == null) return;
            //show form
            PolygonBufZone frm = new PolygonBufZone {ZoneName = strName};
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (m_PivotalProvider == null) return;

                if (m_TargetLayerGuid == Guid.Empty) return;

                var eidssUserBufZoneLayer = (EidssUserBufZoneLayer)UserDbLayersManager.GetUserLayer(m_TargetLayerGuid);

                if (eidssUserBufZoneLayer == null) return;

                var userBufZone = new EidssUserBufZoneLayer.UserBufZone
                {
                    Geometry = geom,
                    Description = frm.Description,
                    Name = frm.ZoneName,
                    Center = new Point(0, 0)
                };

                eidssUserBufZoneLayer.AddNewZone(userBufZone);

                MapImage.Refresh();

                //UserDbFeature userDbFeature = new UserDbFeature(frm.Name, frm.Description, geom);
                //DataProvider.AddUserFeature(userDbFeature);
                //MapImage.Refresh();
            }
            
        }

        protected override void OnToolDeactivated()
        {
            MapImage.Cursor = Cursors.Default;
            MapImage.MouseDown -= MapImage_MouseDown;
        }

        #region Private

        private DataTable m_Translation;
        private IProvider m_PivotalProvider;

        private void LoadTranslations()
        {
            try
            {
                switch (PivotalType)
                {
                    case PivotLayerType.Districts:
                        m_Translation = TranslationCache.GetTranslation(ConnectionString, (long)GisDbType.RftRayon,
                                                                        EidssUserContext.CurrentLanguage);
                        break;
                    case PivotLayerType.Regions:
                        m_Translation = TranslationCache.GetTranslation(ConnectionString, (long) GisDbType.RftRegion,
                                                                        EidssUserContext.CurrentLanguage);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError(ex);
            }

        }

        private Geometry GetArealGeom(Point worldPos, out string name)
        {
            name = string.Empty;
                
            if (m_PivotalProvider != null)
            {
                var area = GIS_V4.Utils.GeometryUtils.PointToArea(worldPos, 3, MapImage.Map.PixelWidth);
                //area = GeometryTransform.TransformGeometry(area, CoordinateSystems.SphericalMercatorCS, CoordinateSystems.WGS84);

                var fds = new FeatureDataSet();
                m_PivotalProvider.Open();
                m_PivotalProvider.ExecuteIntersectionQuery(area.GetBoundingBox(), fds);
                m_PivotalProvider.Close();
                
                if (fds.Tables.Count <= 0) return null;
                if (fds.Tables[0].Rows.Count <= 0) return null;

                //DataTable dt = fds.Tables[0];
                //if (dt.Rows.Count < 1) return null;
                //DataRow dr = dt.Rows[0];

                var geometry = fds.Tables[0][0].Geometry;//((EidssSqlServer2008)m_PivotalProvider).GetGeometryByID((long)dr["idfsGeoObject"]);
                var key = fds.Tables[0][0]["idfsGeoObject"];
                name = m_Translation.Rows.Find(key)["Name"].ToString();

                //if (m_pivotal == "Regions")
                //    Name = m_RegionsTranslation.Rows.Find(dr["idfsGeoObject"])["Name"].ToString();
                //else if (m_pivotal == "Rayons")
                //    Name = m_RayonsTranslation.Rows.Find(dr["idfsGeoObject"])["Name"].ToString();

                return geometry;
            }

            return null;
        }

        #endregion

        #region Public

        public string ConnectionString { get; set; }

        public PivotLayerType PivotalType { get; set; }

        #endregion

        private MtZoneLayerSelector m_ZoneLayerSelector;

        public MtZoneLayerSelector ZoneLayerSelector
        {
            get { return m_ZoneLayerSelector; }
            set
            {
                //if (m_ZoneLayerSelector != null) m_ZoneLayerSelector.OnItemSelect -= m_ZoneLayerSelector_OnItemSelect;
                m_ZoneLayerSelector = value;
                //m_ZoneLayerSelector.OnItemSelect += m_ZoneLayerSelector_OnItemSelect;
            }
        }

        private MapContent m_Content;
        public MapContent Content
        {
            get { return m_Content; }
            set
            {
                if (m_Content != null) m_Content.LayerSelected -= m_Content_LayerSelected;
                m_Content = value;
                m_Content.LayerSelected += m_Content_LayerSelected;
            }
        }

        void m_Content_LayerSelected(SharpMap.Layers.ILayer layer)
        {
            if (layer is EidssUserBufZoneLayer)
            {
                m_TargetLayerGuid = ((EidssUserBufZoneLayer)layer).LayerDbGuid;
                if (m_TargetLayerGuid != Guid.Empty)
                {
                    PivotalType = UserDbLayersManager.GetLayerMetadata(m_TargetLayerGuid).m_PivotalLayer;
                    IsEnabled = (PivotalType == PivotLayerType.Districts || PivotalType == PivotLayerType.Regions);
                    if (IsActive)
                    {
                        IsActive = false;
                        IsActive = true;
                    }
                    if (!IsEnabled) IsActive = false;
                }
            }
            else
            {
                IsActive = IsEnabled = false;
            }


        }

        private Guid m_TargetLayerGuid = Guid.Empty;
    }
}
