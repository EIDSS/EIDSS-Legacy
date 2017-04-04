using System;
using System.Data;
using System.Windows.Forms;
using GIS_V4.Data.Providers;
using GIS_V4.Forms;
using bv.common;
using DotSpatial.Projections;
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
using GIS_V4.Common;
using GIS_V4.Tools;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Geometries;
using GeometryProvider = GIS_V4.Data.Providers.GeometryProvider;

namespace eidss.gis.Tools
{
    public class MtCircleWithCenterBufZone : ControllerMapTool
    {
        public MtCircleWithCenterBufZone()
        {
            var temp = Resources.CircleWithCross;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_MtCircleWithCenterBufZone_Caption;
            m_ToolTipText = Resources.gis_MtCircleWithCenterBufZone_ToolTipText;
            
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
                        ((EidssMapControl)(m_MapImage.Parent)).MapLoaded += MtCircleWithCenterBufZone_MapLoaded;

                //if (m_MapImage.Parent != null)
                //    if (m_MapImage.Parent is AvrMapControl)
                //        ((AvrMapControl)(m_MapImage.Parent)).GettingMapSettings += MtIndependentCircleBufferZoneGettingMapSettings;
            }
        }

        void MtCircleWithCenterBufZone_MapLoaded(string mapName)
        {
            IsActive = IsEnabled = false;
        }

        void Layers_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            IsActive = IsEnabled = false;
        }

        protected override void OnToolActivated()
        {
            //switch (PivotalType)
            //{
            //    case PivotLayerType.Settlements:
            //        m_PivotalProvider = new EidssSqlServer2008(SystemLayerNames.Settlements);
            //        LoadTranslations();
            //        break;
            //    case PivotLayerType.AvrPoints:
            //        m_PivotalProvider = Content.AVRLayer.DataSource;;
            //        break;
            //    default:
            //        m_PivotalProvider = null;
            //        break;
            //}

            LoadTranslations();
            MapImage.Cursor = Cursors.Cross;
            MapImage.MouseDown += MapImage_MouseDown;
        }

        void MapImage_MouseDown(Point worldPos, MouseEventArgs e)
        {
            switch (PivotalType)
            {
                case PivotLayerType.Settlements:
                    m_PivotalProvider = new EidssSqlServer2008(SystemLayerNames.Settlements);                    
                    break;
                case PivotLayerType.AvrPoints:
                    if (Content.AVRLayer != null)
                        m_PivotalProvider = Content.AVRLayer.DataSource;
                    break;
                default:
                    m_PivotalProvider = null;
                    break;
            }

            string strName;
            var nearestPoint = GetNearestPoint(worldPos, out strName);
            if (nearestPoint == null) return;
            //show form
            var frm = new CircleBufZone {ZoneName = strName};
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (m_PivotalProvider == null) return;

                var projectedCenter = nearestPoint;
                //var projectedCenter = GeometryTransform.TransformGeometry(nearestPoint, CoordinateSystems.WGS84,
                //                                                          CoordinateSystems.SphericalMercatorCS);
                var projectedBufGeom = GIS_V4.Utils.GeometryUtils.CreateBuffer(projectedCenter, frm.Radius);
                //var geom = GeometryTransform.TransformGeometry(projectedBufGeom, CoordinateSystems.SphericalMercatorCS,
                //                                               CoordinateSystems.WGS84);
                //var center = GeometryTransform.TransformGeometry(projectedCenter, CoordinateSystems.SphericalMercatorCS,
                //                                               CoordinateSystems.WGS84);
                if (m_TargetLayerGuid == Guid.Empty) return;

                var eidssUserBufZoneLayer = (EidssUserBufZoneLayer)UserDbLayersManager.GetUserLayer(m_TargetLayerGuid);

                if (eidssUserBufZoneLayer == null) return;

                var userBufZone = new EidssUserBufZoneLayer.UserBufZone
                {
                    Geometry = projectedBufGeom, //geom,
                    Description = frm.Description,
                    Name = frm.ZoneName,
                    Center = projectedCenter, //center,
                    Radius = frm.Radius
                };

                eidssUserBufZoneLayer.AddNewZone(userBufZone);

                MapImage.Refresh();
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
                m_Translation = TranslationCache.GetTranslation(ConnectionString, (long) GisDbType.RftSettlement, EidssUserContext.CurrentLanguage);
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError(ex);
            }

        }

        private Point GetNearestPoint(Point worldPos, out string name)
        {
            name = string.Empty;

            if (m_PivotalProvider != null)
            {
                var fds = new FeatureDataSet();
                var area = GIS_V4.Utils.GeometryUtils.PointToArea(worldPos, 3, MapImage.Map.PixelWidth);

                //area = GeometryTransform.TransformGeometry(area, CoordinateSystems.SphericalMercatorCS, CoordinateSystems.WGS84);

                m_PivotalProvider.Open();

                switch (PivotalType)
                {
                    case PivotLayerType.Settlements:
                        ((EidssSqlServer2008)m_PivotalProvider).ExecuteIntersectionQuery(area.GetBoundingBox(), fds);
                        break;
                    case PivotLayerType.AvrPoints:
                        if (m_PivotalProvider is GeometryProvider)
                        {
                            area = GeometryTransform.TransformGeometry(area, CoordinateSystems.SphericalMercatorCS, CoordinateSystems.WGS84);
                            ((GeometryProvider)m_PivotalProvider).ExecuteIntersectionQuery(area.GetBoundingBox(), fds);
                        }
                        else if (m_PivotalProvider is EventDataProvider)
                            ((EventDataProvider)m_PivotalProvider).ExecuteIntersectionQuery(area.GetBoundingBox(), fds);
                        break;
                }
                
                m_PivotalProvider.Close();

                if (fds.Tables.Count <= 0) return null;
                if (fds.Tables[0].Rows.Count <= 0) return null;
                
                //dt = fds.Tables[0];
                //if (dt.Rows.Count <= 0) return null;
                //dr = dt.Rows[0];
                
                Point point;

                if (m_PivotalProvider is EidssSqlServer2008 && /*((EidssSqlServer2008)m_pivotalProvider).GetGeometryByID((long)dr["idfsGeoObject"])*/fds.Tables[0][0].Geometry is Point)
                {
                    point = (Point) fds.Tables[0][0].Geometry; //(Point) ((EidssSqlServer2008) m_pivotalProvider).GetGeometryByID((long) dr["idfsGeoObject"]);
                    name = m_Translation.Rows.Find(fds.Tables[0][0]["idfsGeoObject"])["Name"].ToString(); //m_Translation.Rows.Find(dr["idfsGeoObject"])["Name"].ToString();
                }
                else if (m_PivotalProvider is EventDataProvider)
                {
                    //use AVR info as a name: name = ...
                    //point = new Point((double) fds.Tables[0][0]["x"], (double) fds.Tables[0][0]["y"]); //new Point((double) dr["x"], (double) dr["y"]);
                    if (fds.Tables[0][0].Geometry is Point) point = (Point)fds.Tables[0][0].Geometry;
                    else return null;
                }
                else if (m_PivotalProvider is GeometryProvider)
                {
                    point = new Point((double)fds.Tables[0][0]["x"], (double)fds.Tables[0][0]["y"]); //new Point((double) dr["x"], (double) dr["y"]);
                    point = (Point)GeometryTransform.TransformGeometry(point, CoordinateSystems.WGS84, CoordinateSystems.SphericalMercatorCS);
                }
                else return null;

                return point;
            }

            return null;
        }
        
        #endregion

        #region Public

        public string ConnectionString { get; set; }

        public PivotLayerType PivotalType { get; set; }

        //public MapContent Content { get; set; }

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
                    IsEnabled = (PivotalType == PivotLayerType.AvrPoints || PivotalType == PivotLayerType.Settlements);
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
