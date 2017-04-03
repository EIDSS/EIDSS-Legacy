using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DotSpatial.Projections;
using bv.winclient.Core;
using eidss.gis.Properties;
using eidss.gis.Utils;
using GIS_V4.Common;
using SharpMap.Geometries;
using Point = SharpMap.Geometries.Point;

namespace eidss.gis.Forms
{
    public partial class SetCaseMapForm : BvForm
    {
        public SetCaseMapForm()
        {
            InitializeComponent();

            //debug! Profile map load
            mapControl.m_mapImage.MapRefreshed += m_mapImage_MapRefreshed;
            mapControl.m_mapImage.SizeChanged += m_mapImage_SizeChanged;

            mapControl.m_mapImage.Cursor = Cursors.Cross;
            //IApplicationForm initialization
            Sizable = true;
            HelpTopicId = "";

        }

        #region Debug! Profile map load 
        
        void m_mapImage_SizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now + "Raw sizechanged"+ mapControl.m_mapImage.Size.ToString());

        }

        void m_mapImage_MapRefreshed(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now + "Raw refreshed");
        }

        #endregion

        void okButton_Click(object sender, EventArgs e)
        {
            if (mapControl.InputTool.Point != null && mapControl.InputTool.Point.X != 0 && mapControl.InputTool.Point.Y != 0)
            {
                Point point = mapControl.InputTool.Point;

                //reproject if need
                if (mapControl.MapSpatRef != CoordinateSystems.WGS84)
                    point = GeometryTransform.TransformPoint(point, mapControl.MapSpatRef, CoordinateSystems.WGS84);
                
                //generate case change event
                OnCase(point.X, point.Y);
            }

            Close();
        }

        //TODO: find ButtonBehaivor  
        void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public BoundingBox InitAdminBBox { get; set; }
        public Point InitWgsPoint { get; set; }
        
     
        #region Events defenition

        public delegate void OnCaseEvenHandler(double? x, double? y);

        public event OnCaseEvenHandler OnCase;

        #endregion

        #region EIDSS IApplicationForm Members

        public override string Caption
        {
            get { return Resources.gis_SetCaseMapForm_Caption; }
        }

        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            using (new TemporaryWaitCursor())
            {
                //create ok/cancel buttons
                var okButton = new BarButtonItem(mapControl.barManager, Resources.gis_SetCaseMapForm_Ok);// "OK");
                okButton.ItemClick += okButton_Click;
                okButton.Border = BorderStyles.Default;
                okButton.Appearance.Font = new Font(okButton.Appearance.Font, FontStyle.Bold);
                
                var cancelButton = new BarButtonItem(mapControl.barManager, Resources.gis_SetCaseMapForm_Cancel);
                cancelButton.ItemClick += cancelButton_Click;
                cancelButton.Border = BorderStyles.Default;
                cancelButton.Appearance.Font = new Font(cancelButton.Appearance.Font, FontStyle.Bold);
               
                mapControl.barManager.Bars["StatusBar"].AddItem(okButton).BeginGroup = true;
                mapControl.barManager.Bars["StatusBar"].AddItem(cancelButton);

                //IT IS UGLY HACK!
                mapControl.RemoveUglyButton();

                //set default tool
                mapControl.InputTool.IsActive = true;

                //init map
                mapControl.MapSpatRef = CoordinateSystems.SphericalMercatorCS;
                DateTime start = DateTime.Now;
                mapControl.LoadMap(MapProjectsStorage.DefaultMapPath);
                mapControl.MapSelector.UpdateValue(MapProjectsStorage.DefaultMapName);
                Debug.WriteLine("Loaded:" + (DateTime.Now - start).TotalMilliseconds);
                Debug.WriteLine("Loaded:" + DateTime.Now);

                //set case point, if exists
                if ( InitWgsPoint != null)
                {
                    var point = InitWgsPoint.Clone();

                    if (mapControl.MapSpatRef != CoordinateSystems.WGS84)
                        point = GeometryTransform.TransformPoint(point, CoordinateSystems.WGS84, mapControl.MapSpatRef);

                    mapControl.InputTool.Point = point;
                }

                //zoom to box
                if (InitAdminBBox != null)
                {
                    var adminBox = InitAdminBBox.Clone();
                    //reproject if need. NotNeed!!!!
                    if (mapControl.MapSpatRef != CoordinateSystems.WGS84)
                        adminBox = GeometryTransform.TransformBox(adminBox, CoordinateSystems.WGS84,
                                                                  mapControl.MapSpatRef);
                    mapControl.Map.ZoomToBox(adminBox);
                }

            }
        }

    }
}
