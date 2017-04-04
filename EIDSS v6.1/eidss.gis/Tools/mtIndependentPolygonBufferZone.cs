using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GIS_V4.Forms;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.gis.Data;
using eidss.gis.Forms;
using eidss.gis.Layers;
using eidss.gis.Properties;
using eidss.gis.Tools.ToolForms;
using GIS_V4.Tools;
using SharpMap.Geometries;
using Point = SharpMap.Geometries.Point;

namespace eidss.gis.Tools
{
    public class MtIndependentPolygonBufferZone : ControllerMapTool
    {
        public MtIndependentPolygonBufferZone()
        {
            var temp = Resources.Polygon;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_MtIndependentPolygonBufferZone_Caption;
            m_ToolTipText = Resources.m_MtIndependentPolygonBufferZone_ToolTipText;

            IsEnabled = false;
        }

        #region Private
        private enum ToolPhase
        {
            None,
            WaitFirst,
            Continue
        }

        private ToolPhase m_ToolPhase;
        private readonly List<Point> m_Vertices = new List<Point>();
        private readonly List<System.Drawing.Point> m_Points = new List<System.Drawing.Point>();
        private System.Drawing.Point m_LastMousePosition = System.Drawing.Point.Empty;

        private void DrawPolygon()
        {
            if (m_Points.Count < 2) return;
            var graph = MapImage.CreateGraphics();
            graph.DrawLines(new Pen(Color.Black), m_Points.ToArray());
        }

        private void DrawTerminalSegments(System.Drawing.Point prevPoint, System.Drawing.Point curPoint)
        {
            if (m_Points.Count == 2)
            {
                var graph = MapImage.CreateGraphics();
                graph.DrawLine(new Pen(Color.Black), m_Points[0], m_Points[1]);
            }

            if (curPoint != System.Drawing.Point.Empty)
            {
                ControlPaint.DrawReversibleLine(MapImage.PointToScreen(curPoint), MapImage.PointToScreen(m_Points[0]),
                                                Color.Black);
                if (m_Points.Count > 1)
                    ControlPaint.DrawReversibleLine(MapImage.PointToScreen(curPoint),
                                                    MapImage.PointToScreen(m_Points[m_Points.Count - 1]), Color.Black);
            }

            if (prevPoint != System.Drawing.Point.Empty)
            {
                ControlPaint.DrawReversibleLine(MapImage.PointToScreen(prevPoint), MapImage.PointToScreen(m_Points[0]),
                                                Color.Black);
                if (m_Points.Count > 1)
                    ControlPaint.DrawReversibleLine(MapImage.PointToScreen(prevPoint),
                                                    MapImage.PointToScreen(m_Points[m_Points.Count - 1]), Color.Black);
            }



        }

        #endregion

        protected override void OnToolActivated()
        {
            MapImage.Cursor = Cursors.Cross;
            m_ToolPhase = ToolPhase.WaitFirst;
            MapImage.MouseDown += MapImage_MouseDown;
            MapImage.MouseMove += MapImage_MouseMove;
            MapImage.MouseDoubleClick += MapImage_MouseDoubleClick;
        }

        void MtIndependentPolygonBufferZoneGettingMapSettings()
        {
            IsActive = IsEnabled = false;
        }

        void MtIndependentPolygonBufferZone_MapLoaded(string mapName)
        {
            IsActive = IsEnabled = false;
        }

        void Layers_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            IsActive = IsEnabled = false;
        }

        void MapImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (m_ToolPhase == ToolPhase.WaitFirst) return;
            //if (DataProvider == null) NoDataProvider();

            //compleate polygon
            if (m_Vertices.Count < 3) return;

            m_Vertices.Add(m_Vertices[0]);

            var linearRing = new LinearRing(m_Vertices);
            Geometry polygon = new Polygon(linearRing);
            //polygon = GeometryTransform.TransformGeometry(polygon, CoordinateSystems.SphericalMercatorCS,
            //                                                      CoordinateSystems.WGS84);
            m_ToolPhase = ToolPhase.WaitFirst;

            var connectionString = ConnectionManager.DefaultInstance.ConnectionString;
            var connection = new SqlConnection(connectionString);

            var valid = SqlExecHelper.SqlGeometryValidation(connection, polygon);

            if (!valid)
            {
                MessageForm.Show(Resources.gis_MtIndependentPolygonBufferZone_CheckValidityMsg);
            }
            else
            {

                //show form
                var frm = new PolygonBufZone();
                //frm.ZoneLayer = string.Empty;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (m_TargetLayerGuid == Guid.Empty) return;

                    var eidssUserBufZoneLayer =
                        (EidssUserBufZoneLayer) UserDbLayersManager.GetUserLayer(m_TargetLayerGuid);

                    if (eidssUserBufZoneLayer == null) return;


                    var userBufZone = new EidssUserBufZoneLayer.UserBufZone
                                            {
                                                Geometry = polygon,
                                                Description = frm.Description,
                                                Name = frm.ZoneName,
                                                //Center = new Point(0, 0)
                                            };

                    eidssUserBufZoneLayer.AddNewZone(userBufZone);

                }
            }
            MapImage.Refresh();
            
            m_Vertices.Clear();
            m_Points.Clear();
            m_LastMousePosition = System.Drawing.Point.Empty;            
        }

        void MapImage_MouseMove(Point worldPos, MouseEventArgs e)
        {
            if (m_ToolPhase == ToolPhase.WaitFirst) return;
            System.Drawing.Point p = e.Location; 
            DrawTerminalSegments(m_LastMousePosition, p);
            m_LastMousePosition = p;            
        }

        void MapImage_MouseDown(Point worldPos, MouseEventArgs e)
        {
            if (m_ToolPhase == ToolPhase.WaitFirst)
            {
                //put first point
                m_Vertices.Add(worldPos);
                m_Points.Add(e.Location);
                DrawPolygon();
                m_ToolPhase = ToolPhase.Continue;
            }
            else
            {
                //put next point
                m_Vertices.Add(worldPos);
                m_Points.Add(e.Location);
                DrawPolygon();
            }
        }

        protected override void OnToolDeactivated()
        {
            m_Vertices.Clear();
            m_Points.Clear();
            m_ToolPhase = ToolPhase.None;
            MapImage.MouseDown -= MapImage_MouseDown;
            MapImage.MouseMove -= MapImage_MouseMove;
            MapImage.MouseDoubleClick -= MapImage_MouseDoubleClick;
            MapImage.Cursor = Cursors.Default;
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
                m_TargetLayerGuid = ((EidssUserBufZoneLayer) layer).LayerDbGuid;
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
                        ((EidssMapControl)(m_MapImage.Parent)).MapLoaded += MtIndependentPolygonBufferZone_MapLoaded;

                //if (m_MapImage.Parent != null)
                //    if (m_MapImage.Parent is AvrMapControl)
                //        ((AvrMapControl)(m_MapImage.Parent)).GettingMapSettings += MtIndependentPolygonBufferZoneGettingMapSettings;
            }
        }
    }
}
