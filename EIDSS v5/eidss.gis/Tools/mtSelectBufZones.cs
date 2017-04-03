using System;
using System.Drawing;
using System.Windows.Forms;
using GIS_V4.Forms;
using eidss.gis.Data;
using eidss.gis.Forms;
using eidss.gis.Layers;
using eidss.gis.Properties;
using eidss.gis.Tools.ToolForms;
using eidss.model.Resources;
using GIS_V4.Tools;
using SharpMap.Data;
using SharpMap.Geometries;
using SharpMap.Rendering;
using bv.winclient.Core;

namespace eidss.gis.Tools
{
    public class MtSelectBufZones : ControllerMapTool
    {
        public MtSelectBufZones()
        {
            var temp = Resources._24_gis_cursor;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_MtSelectBufZones_Caption;
            m_ToolTipText = Resources.gis_MtSelectBufZones_ToolTipText;

            IsEnabled = false;
        }

        private bool m_IsMoveMode, m_IsShifting;
        private SharpMap.Geometries.Point m_ShiftBeginPnt;
        
        void m_MapImage_OnActiveToolChanged(MapTool maptool)
        {
            //Check new tool
            //o	Pan map
            //o	Country extent
            //o	Information tool
            //o	Zoom in map
            //o	Zoom out map
            //o	Zoom in/out map
            // - tools compatible with buf zone editing

            
        }

        void mi_Prop_Click(object sender, EventArgs e)
        {
            #region Apply movement or not

            //m_SelectedFeature = null;
            
            if (m_IsMoveMode)
            {
                if (ApplyMovement(false)==DialogResult.Cancel) return;
            }

            #endregion

            var userLayer = UserDbLayersManager.GetUserLayer(m_TargetLayerGuid);
            var lyr = (EidssUserBufZoneLayer) userLayer;
            var zone = lyr.FeatureRowToStruct(m_SelectedFeature);
            if (zone.Radius>0)
            {
                var frm = new CircleBufZone();
                frm.ZoneName = zone.Name;
                frm.Description = zone.Description;
                frm.Radius = zone.Radius;
                if (frm.ShowDialog()==DialogResult.OK)
                {
                    zone.Name = frm.ZoneName;
                    zone.Description = frm.Description;
                    zone.Radius = frm.Radius;

                    var projectedCenter = zone.Center;// GeometryTransform.TransformGeometry(zone.Center, CoordinateSystems.WGS84,
                                         //                                     CoordinateSystems.SphericalMercatorCS);
                    var projectedBufGeom = GIS_V4.Utils.GeometryUtils.CreateBuffer(projectedCenter, zone.Radius);
                    var geom = projectedBufGeom;//GeometryTransform.TransformGeometry(projectedBufGeom, CoordinateSystems.SphericalMercatorCS,
                               //                                    CoordinateSystems.WGS84);
                    
                    zone.Geometry = geom;

                    lyr.UpdateZone(zone);

                    m_SelectedFeature = null;
                }
            }
            else
            {
                var frm = new PolygonBufZone();
                frm.ZoneName = zone.Name;
                frm.Description = zone.Description;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    zone.Name = frm.ZoneName;
                    zone.Description = frm.Description;
                    lyr.UpdateZone(zone);

                    m_SelectedFeature = null;
                }
            }
            m_MapImage.Refresh();
        }

        void mi_Del_Click(object sender, EventArgs e)
        {
            if (m_SelectedFeature != null) DeleteSelected();
            m_IsMoveMode = false;
            UnsubscribeApplyEvents();
        }
        
        private EidssUserBufZoneLayer.UserBufZone m_BufZoneBeforeEdit;
        private EidssUserBufZoneLayer m_BufZoneLayer;
        private EidssUserDbLayer m_BufZoneUserLayer;
        private Geometry m_GeomBeforeEdit;

        private Guid m_LastMovedTargetLayerGuid;
        void mi_Move_Click(object sender, EventArgs e)
        {
            m_IsMoveMode = true;
            
            m_LastMovedTargetLayerGuid = m_TargetLayerGuid;
            m_MiMove.Visible = false;
            m_MiApplyMovement.Visible = true;
            m_MiCancelMovement.Visible = true;

            m_BufZoneUserLayer = UserDbLayersManager.GetUserLayer(m_TargetLayerGuid);
            m_BufZoneLayer = (EidssUserBufZoneLayer)m_BufZoneUserLayer;
            m_BufZoneBeforeEdit = m_BufZoneLayer.FeatureRowToStruct(m_SelectedFeature);

            var wkb = m_SelectedFeature.Geometry.AsBinary();//.AsText();
            m_GeomBeforeEdit = Geometry.GeomFromWKB(wkb);

            SubscribeApplyEvents();

            MapImage.RefreshFromCache();
        }

        private void SubscribeApplyEvents()
        {
            m_MapImage.CommandToolPress += m_MapImage_CommandToolPress;

            m_MapImage.ActiveToolChanging += m_MapImage_ActiveToolChanging;

            if (m_Content != null) m_Content.LayerSelecting += m_Content_LayerSelecting;

            //m_MapImage.Map.Layers.ListChanged += Layers_ListChanged;

            var findForm = m_MapImage.FindForm();
            if (findForm != null)
            {
                findForm.FormClosing += MtSelectBufZones_FormClosing;
            }

            if (m_MapImage.Parent != null)
                if (m_MapImage.Parent is EidssMapControl)
                    ((EidssMapControl)(m_MapImage.Parent)).MapChanging += MtSelectBufZones_MapChanging;

            if (m_MapImage.Parent != null)
                if (m_MapImage.Parent is AvrMapControl)
                    ((AvrMapControl)(m_MapImage.Parent)).LeavingMap += MtSelectBufZones_LeavingMap;

            //if (m_MapImage.Parent != null)
            //    if (m_MapImage.Parent is EidssMapControl)
            //        ((EidssMapControl)(m_MapImage.Parent)).BeforeMapLoaded += MtSelectBufZones_BeforeMapLoaded;

            //if (m_MapImage.Parent != null)
            //    if (m_MapImage.Parent is EidssMapControl)
            //        ((EidssMapControl)(m_MapImage.Parent)).MapLoaded += MtSelectBufZones_OnLoadMap;
        }

        void MtSelectBufZones_LeavingMap(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ApplyMovement(true) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                UnsubscribeApplyEvents();
            }
        }

        void m_MapImage_ActiveToolChanging(MapTool oldtool, MapTool newtool, System.ComponentModel.CancelEventArgs e)
        {
            if (!(newtool is mtZoomIn || newtool is mtZoomOut || newtool is mtZoomTool || newtool is mtPan || newtool is MtInfo || newtool is MtSelectBufZones))
            {
                if (ApplyMovement(true) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    UnsubscribeApplyEvents();
                }
            }
        }

        private void UnsubscribeApplyEvents()
        {
            m_MapImage.CommandToolPress -= m_MapImage_CommandToolPress;

            m_MapImage.ActiveToolChanging -= m_MapImage_ActiveToolChanging;

            if (m_Content != null) m_Content.LayerSelecting -= m_Content_LayerSelecting;

            //m_MapImage.Map.Layers.ListChanged -= Layers_ListChanged;

            var findForm = m_MapImage.FindForm();
            if (findForm != null)
            {
                findForm.FormClosing -= MtSelectBufZones_FormClosing;
            }

            if (m_MapImage.Parent != null)
                if (m_MapImage.Parent is EidssMapControl)
                    ((EidssMapControl)(m_MapImage.Parent)).MapChanging -= MtSelectBufZones_MapChanging;

            if (m_MapImage.Parent != null)
                if (m_MapImage.Parent is AvrMapControl)
                    ((AvrMapControl)(m_MapImage.Parent)).LeavingMap -= MtSelectBufZones_LeavingMap;

            //if (m_MapImage.Parent != null)
            //    if (m_MapImage.Parent is EidssMapControl)
            //        ((EidssMapControl)(m_MapImage.Parent)).MapLoaded -= MtSelectBufZones_OnLoadMap;
        }

        private ContextMenu m_CMenu;
        private bool m_FirstActivation = true;

        private MenuItem m_MiProp, m_MiDel, m_MiMove, m_MiApplyMovement, m_MiCancelMovement;
        
        protected override void OnToolActivated()
        {
            MapImage.Cursor = Cursors.Cross;
            MapImage.MouseDown += MapImage_MouseDown;

            if (m_FirstActivation)
            {
                m_MapImage.CreateGraphics();

                MapImage.MapRefreshed += MapImage_MapRefreshed;

                m_CMenu = new ContextMenu();
                m_MiProp = new MenuItem(Resources.m_MtSelectBufZones_BZProperties);
                m_MiDel = new MenuItem(Resources.gis_MtSelectBufZones_BZDelete);
                m_MiMove = new MenuItem(Resources.gis_MtSelectBufZones_BZMove);
                m_MiApplyMovement = new MenuItem(Resources.gis_MtSelectBufZones_BZApply);
                m_MiCancelMovement = new MenuItem(Resources.gis_MtSelectBufZones_BZCancel);

                m_CMenu.MenuItems.Add(m_MiProp);
                m_CMenu.MenuItems.Add(m_MiDel);
                m_CMenu.MenuItems.Add(m_MiMove);
                m_CMenu.MenuItems.Add(m_MiApplyMovement);
                m_CMenu.MenuItems.Add(m_MiCancelMovement);

                m_MiApplyMovement.Visible = false;
                m_MiCancelMovement.Visible = false;

                if (UserDbLayersManager.GetLayerMetadata(m_TargetLayerGuid).m_PivotalLayer != PivotLayerType.None || m_IsMoveMode)
                    m_MiMove.Visible = false;

                //MapImage.ContextMenu = m_CMenu;
                m_MiDel.Click += mi_Del_Click;
                m_MiProp.Click += mi_Prop_Click;
                m_MiMove.Click += mi_Move_Click;
                m_MiApplyMovement.Click += miApplyMovement_Click;
                m_MiCancelMovement.Click += miCancelMovement_Click;

                m_MapImage.MouseMove += m_MapImage_MouseMove;
                m_MapImage.MouseUp += m_MapImage_MouseUp;
                
                m_MapImage.OnActiveToolChanged += m_MapImage_OnActiveToolChanged;
            }
            m_FirstActivation = false;
        }

        void m_MapImage_CommandToolPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is eidss.gis.Tools.MtFixedExtent) return;
            e.Cancel = ApplyMovement(true) == DialogResult.Cancel;
        }

        void MtSelectBufZones_OnLoadMap(string mapName)
        {
            //m_MapImage.Map.Layers.ListChanged += Layers_ListChanged;

            m_SelectedFeature = null;
            IsActive = IsEnabled = false;
            //if (!m_IsMoveMode) return;

            //var dialogResult = MessageBox.Show(Resources.gis_MtSelectBufZones_BZApplyWarning, "",
            //                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialogResult == DialogResult.No)
            //{
            //    UndoMovement(true);
            //}

            //m_IsMoveMode = false;
            //m_MapImage.CommandToolPress -= m_MapImage_CommandToolPress;

            //m_MiMove.Visible = true;
            //m_MiApplyMovement.Visible = false;
            //m_MiCancelMovement.Visible = false;
            //m_GeomBeforeEdit = null;
            
            
            //MapImage.RefreshFromCache();
        }

        void MtSelectBufZones_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_IsMoveMode) return;

            if (ApplyMovement(true) == DialogResult.Cancel) e.Cancel = true;
        }

        private void UndoMovement(bool clearSelection)
        {
            m_IsMoveMode = false;
            //m_MapImage.CommandToolPress -= m_MapImage_CommandToolPress;

            m_MiMove.Visible = true;
            m_MiApplyMovement.Visible = false;
            m_MiCancelMovement.Visible = false;
            
            if (m_GeomBeforeEdit != null)
            {
                m_BufZoneBeforeEdit.Geometry = m_GeomBeforeEdit;
                if (m_BufZoneBeforeEdit.Radius > 0)
                    m_BufZoneBeforeEdit.Center = ((Polygon) m_GeomBeforeEdit).Centroid;
            }

            m_BufZoneLayer.UpdateZone(m_BufZoneBeforeEdit);
            
            if (clearSelection) m_SelectedFeature = null;
            else
            {
                m_SelectedFeature.Geometry = m_GeomBeforeEdit;
                if (m_BufZoneBeforeEdit.Radius > 0)
                {
                    m_SelectedFeature["dblCenterX"] = m_BufZoneBeforeEdit.Center.X;
                    m_SelectedFeature["dblCenterY"] = m_BufZoneBeforeEdit.Center.Y;
                }
            }
            
                
            m_GeomBeforeEdit = null;

            UnsubscribeApplyEvents();
            m_MapImage.Refresh();
        }

        void m_MapImage_MouseUp(SharpMap.Geometries.Point worldPos, MouseEventArgs imagePos)
        {
            if (m_IsShifting && m_IsMoveMode && imagePos.Button==MouseButtons.Left)
            {
                //stop shifting
                m_IsShifting = false;
                //save last shift-position into buffer zone
                
                var zone = m_BufZoneLayer.FeatureRowToStruct(m_SelectedFeature);

                var deltaX = worldPos.X - m_ShiftBeginPnt.X;
                var deltaY = worldPos.Y - m_ShiftBeginPnt.Y;

                if (zone.Radius>0)
                {
                    //circle
                    zone.Center.X = zone.Center.X + deltaX;
                    zone.Center.Y = zone.Center.Y + deltaY;
                                        
                    zone.Geometry = GIS_V4.Utils.GeometryUtils.CreateBuffer(zone.Center, zone.Radius);

                    m_BufZoneLayer.UpdateZone(zone);

                    m_SelectedFeature.Geometry = zone.Geometry;
                    m_SelectedFeature["dblCenterX"] = zone.Center.X;
                    m_SelectedFeature["dblCenterY"] = zone.Center.Y;
                }
                else
                {
                    //polygon
                    if (m_SelectedFeature.Geometry is Polygon)
                    {
                        var geom = (Polygon)m_SelectedFeature.Geometry; 
                        
                        //foreach (var vertex in geom.ExteriorRing.Vertices)
                        //{
                        //    vertex.X = vertex.X + deltaX;
                        //    vertex.Y = vertex.Y + deltaY;
                        //}
                        zone.Geometry = new Polygon(geom.ExteriorRing);

                        m_SelectedFeature.Geometry = zone.Geometry;
                        m_BufZoneLayer.UpdateZone(zone);
                    }
                }
              
                MapImage.Refresh();
            }
        }

        private SharpMap.Geometries.Point m_LastShiftPnt;
        
        void m_MapImage_MouseMove(SharpMap.Geometries.Point worldPos, MouseEventArgs imagePos)
        {
            if (m_IsShifting && m_IsMoveMode)
            {
                var deltaX = worldPos.X - m_LastShiftPnt.X;
                var deltaY = worldPos.Y - m_LastShiftPnt.Y;

                if (m_SelectedFeature.Geometry is Polygon)
                {
                    var geom = (Polygon)m_SelectedFeature.Geometry; 

                    foreach (var vertex in geom.ExteriorRing.Vertices)
                    {
                        vertex.X = vertex.X + deltaX;
                        vertex.Y = vertex.Y + deltaY;
                    }
                }

                m_LastShiftPnt = new SharpMap.Geometries.Point(worldPos.X,worldPos.Y);
 
                MapImage.RefreshFromCache();
            }
        }

        void miCancelMovement_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Resources.gis_MtSelectBufZones_BZCancelWarning, "",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                UndoMovement(true);
            }
        }

        private DialogResult ApplyMovement(bool clearSelection)
        {
            var dialogResult = MessageBox.Show(Resources.gis_MtSelectBufZones_BZApplyWarning, "",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                m_IsMoveMode = false;
                
                //apply changes
                m_MiMove.Visible = true;
                m_MiApplyMovement.Visible = false;
                m_MiCancelMovement.Visible = false;

                if (UserDbLayersManager.GetLayerMetadata(m_TargetLayerGuid).m_PivotalLayer != PivotLayerType.None || m_IsMoveMode)
                    m_MiMove.Visible = false;

                if (clearSelection) m_SelectedFeature = null;

                m_GeomBeforeEdit = null;
                MapImage.RefreshFromCache();
                UnsubscribeApplyEvents();
            }
            else if (dialogResult == DialogResult.No)
            {
                m_IsMoveMode = false;
                UndoMovement(clearSelection);
            }

            return dialogResult;
        }

        void miApplyMovement_Click(object sender, EventArgs e)
        {
            ApplyMovement(true);
        }

        void MapImage_MapRefreshed(object sender, EventArgs e)
        {
             DrawSelected();
        }

        private void DrawSelected()
        {
            if (m_SelectedFeature != null)
            {
                var g = m_MapImage.CreateGraphics();
                var projectedGeom = m_SelectedFeature.Geometry;//GeometryTransform.TransformGeometry(m_SelectedFeature.Geometry,
                                                                        //CoordinateSystems.WGS84,
                                                                        //CoordinateSystems.SphericalMercatorCS);

                Color fillColor, outlineColor;

                if (m_IsMoveMode)
                {
                    fillColor = Color.FromArgb(128, Color.Orange);
                    outlineColor = Color.GreenYellow;
                }
                else
                {
                    fillColor = Color.Transparent;
                    outlineColor = Color.Aqua;
                }

                
                if (projectedGeom is Polygon)
                {
                    VectorRenderer.DrawPolygon(g, (Polygon) projectedGeom, new SolidBrush(fillColor),
                                               new Pen(outlineColor, 3), false, m_MapImage.Map);
                }
                else if (projectedGeom is MultiPolygon)
                {
                    VectorRenderer.DrawMultiPolygon(g, (MultiPolygon) projectedGeom, new SolidBrush(Color.Transparent),
                                                    new Pen(Color.Aqua, 3), false, m_MapImage.Map);
                }
                g.Dispose();
            }
        }

        void MapImage_MouseDown(SharpMap.Geometries.Point worldPos, MouseEventArgs e)
        {
            if (m_TargetLayerGuid == Guid.Empty) return;
            
            if (!m_IsMoveMode)
            {
                var area = GIS_V4.Utils.GeometryUtils.PointToArea(worldPos, 3, MapImage.Map.PixelWidth);
                var fds = new FeatureDataSet();
                var zoneLayer = UserDbLayersManager.GetUserLayer(m_TargetLayerGuid);
                zoneLayer.DataSource.ExecuteIntersectionQuery(area.GetBoundingBox(), fds);

                if (fds.Tables.Count <= 0)
                {
                    m_SelectedFeature = null;
                    return;
                }

                if (fds.Tables[0].Rows.Count <= 0)
                {
                    m_SelectedFeature = null;
                    return;
                }

                m_SelectedFeature = fds.Tables[0][0];

                MapImage.RefreshFromCache();
            }
            else
            {
                //tool in move mode
                if (e.Button == MouseButtons.Left)
                {
                    //start shifting on mouse move
                    m_IsShifting = true;
                    m_ShiftBeginPnt = worldPos;
                    m_LastShiftPnt = new SharpMap.Geometries.Point(worldPos.X, worldPos.Y);
                }
            }

            if (m_SelectedFeature != null && e.Button == MouseButtons.Right)
                if (m_SelectedFeature.Geometry.GetBoundingBox().Contains(worldPos))
                    m_CMenu.Show(MapImage, e.Location);
        }

        private FeatureDataRow m_SelectedFeature;
        
        protected override void OnToolDeactivated()
        {
            MapImage.MouseDown -= MapImage_MouseDown;
            MapImage.Cursor = Cursors.Default;
        }

        private MtZoneLayerSelector m_ZoneLayerSelector;

        public MtZoneLayerSelector ZoneLayerSelector
        {
            get { return m_ZoneLayerSelector; }
            set
            {
                if (m_ZoneLayerSelector != null) m_ZoneLayerSelector.OnItemSelect -= m_ZoneLayerSelector_OnItemSelect;
                m_ZoneLayerSelector = value;
                m_ZoneLayerSelector.OnItemSelect += m_ZoneLayerSelector_OnItemSelect;
            }
        }

        void m_ZoneLayerSelector_OnItemSelect(System.Collections.Generic.KeyValuePair<Guid, string> e)
        {
            m_TargetLayerGuid = e.Key;

            IsEnabled = true;
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

        void m_Content_LayerSelecting(System.ComponentModel.CancelEventArgs e)
        {
            if (ApplyMovement(true) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                UnsubscribeApplyEvents();
            }
        }

        void m_Content_LayerSelected(SharpMap.Layers.ILayer layer)
        {
            if (layer is EidssUserBufZoneLayer)
            {
                m_TargetLayerGuid = ((EidssUserBufZoneLayer)layer).LayerDbGuid;
                if (m_TargetLayerGuid != Guid.Empty)
                {
                    IsEnabled = true;
                    if (IsActive)
                    {
                        IsActive = false;
                        IsActive = true;
                    }
                    if (m_MiMove != null)
                        if (UserDbLayersManager.GetLayerMetadata(m_TargetLayerGuid).m_PivotalLayer != PivotLayerType.None || m_IsMoveMode)
                            m_MiMove.Visible = false;
                        else m_MiMove.Visible = true;
                    
                }
            }
            else
            {
                IsActive = IsEnabled = false;
            }


        }

        private Guid m_TargetLayerGuid = Guid.Empty;

        private void DeleteSelected()
        {
            var msg = EidssMessages.GetForCurrentLang("gis_Message_DelZone", "Would you like to delete selected buffer zone?");
            var caption = EidssMessages.GetForCurrentLang("gis_Caption_DelZone", "Delete buffer zone");
            
            if (MessageForm.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                if (m_SelectedFeature != null)
                {
                    //MapImage.Cursor = Cursors.WaitCursor;
                    if (!m_IsMoveMode)
                        ((EidssUserBufZoneLayer)UserDbLayersManager.GetUserLayer(m_TargetLayerGuid)).DeleteZone(
                            (long)m_SelectedFeature["idfsGeoObject"]);
                    else
                        ((EidssUserBufZoneLayer) UserDbLayersManager.GetUserLayer(m_LastMovedTargetLayerGuid)).DeleteZone(
                            (long) m_SelectedFeature["idfsGeoObject"]);

                    m_SelectedFeature = null;
                    
                    if (m_IsMoveMode)
                    {
                        m_MiApplyMovement.Visible = false;
                        m_MiCancelMovement.Visible = false;
                        m_MiMove.Visible = true;
                    }

                    if (UserDbLayersManager.GetLayerMetadata(m_TargetLayerGuid).m_PivotalLayer != PivotLayerType.None)
                        m_MiMove.Visible = false;

                    m_IsMoveMode = false;
                    m_MapImage.CommandToolPress -= m_MapImage_CommandToolPress;

                    //MapImage.Cursor = Cursors.Default;
                    MapImage.Refresh();
                }
            }
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

                if (m_MapImage.Parent != null)
                    if (m_MapImage.Parent is EidssMapControl)
                        ((EidssMapControl)(m_MapImage.Parent)).MapLoaded += MtSelectBufZones_OnLoadMap;

                //if (m_MapImage.Parent != null)
                //    if (m_MapImage.Parent is AvrMapControl)
                //        ((AvrMapControl)(m_MapImage.Parent)).BeforeEventLayerAdd += new AvrMapControl.MapSettingsHandler(MtSelectBufZones_BeforeEventLayerAdd);
                
                //if (m_MapImage.Parent != null)
                //    if (m_MapImage.Parent is AvrMapControl)
                //        ((AvrMapControl)(m_MapImage.Parent)).AfterEventLayerAdd += MtSelectBufZonesAfterEventLayerAdd;
            }
        }

        void MtSelectBufZones_MapChanging(System.ComponentModel.CancelEventArgs e)
        {
            if (ApplyMovement(true) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                UnsubscribeApplyEvents();
            }
        }
    }
}
