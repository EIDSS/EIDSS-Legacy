using System;
using System.Windows.Forms;
using GIS_V4.Forms;
using eidss.gis.Data;
using eidss.gis.Forms;
using eidss.gis.Layers;
using eidss.gis.Properties;
using eidss.gis.Tools.ToolForms;
using GIS_V4.Tools;
using SharpMap.Geometries;

namespace eidss.gis.Tools
{
    public class MtIndependentCircleBufferZone : ControllerMapTool
    {
        public MtIndependentCircleBufferZone()
        {
            var temp = Resources.Circle;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_MtIndependentCircleBufferZone_Caption;
            m_ToolTipText = Resources.gis_MtIndependentCircleBufferZone_ToolTipText;

            IsEnabled = false;
        }

        protected override void OnToolActivated()
        {
            MapImage.Cursor = Cursors.Cross;
            MapImage.MouseDown +=MapImage_MouseDown;
        }

        void MtIndependentCircleBufferZoneGettingMapSettings()
        {
            IsActive = IsEnabled = false;
        }

        void MtIndependentCircleBufferZone_MapLoaded(string mapName)
        {
            IsActive = IsEnabled = false;
        }

        void Layers_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            IsActive = IsEnabled = false;
        }

        protected override void OnToolDeactivated()
        {
            MapImage.MouseDown -= MapImage_MouseDown;
            MapImage.Cursor = Cursors.Default;
        }

        void MapImage_MouseDown(Point worldPos, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                var circleBufZone = new CircleBufZone();
                if (circleBufZone.ShowDialog()==DialogResult.OK)
                {
                    if (m_TargetLayerGuid==Guid.Empty) return;
                    
                    var projectedCenter = worldPos;
                    var projectedBufGeom = GIS_V4.Utils.GeometryUtils.CreateBuffer(projectedCenter, circleBufZone.Radius);
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
                        Description = circleBufZone.Description,
                        Name = circleBufZone.ZoneName,
                        Center = projectedCenter, //center,
                        Radius = circleBufZone.Radius
                    };

                    eidssUserBufZoneLayer.AddNewZone(userBufZone);

                    MapImage.Refresh();
                }
                circleBufZone.Dispose();
            }
        }

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
                    IsEnabled = (UserDbLayersManager.GetLayerMetadata(m_TargetLayerGuid).m_PivotalLayer ==
                                 PivotLayerType.None);
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

        private Guid m_TargetLayerGuid=Guid.Empty;

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
                        ((EidssMapControl)(m_MapImage.Parent)).MapLoaded += MtIndependentCircleBufferZone_MapLoaded;

                //if (m_MapImage.Parent != null)
                //    if (m_MapImage.Parent is AvrMapControl)
                //        ((AvrMapControl)(m_MapImage.Parent)).GettingMapSettings += MtIndependentCircleBufferZoneGettingMapSettings;
            }
        }
    }
}
