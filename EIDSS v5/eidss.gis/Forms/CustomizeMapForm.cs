using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using bv.model.Model.Core;
using DevExpress.XtraEditors;
using bv.winclient.Core;
using eidss.gis.Properties;
using eidss.gis.Tools;
using eidss.gis.Utils;
using GIS_V4.Common;
using bv.winclient.BasePanel;
using GIS_V4.Tools;

namespace eidss.gis.Forms
{
    public partial class CustomizeMapForm : BvForm 
    {
        public CustomizeMapForm()
        {
            InitializeComponent();

            //init toolbars
            mapControl.InitBufZonesToolBar();
            mapControl.InitMapProjectToolBar();

            
            //add SaveMap Tool to Project panel
            var mbb = new MapBarButton();
            var mTool = new MtSaveMap { MapImage = mapControl.m_mapImage };
            mbb.MapTool = mTool;
            mapControl.barManager.Bars["MapProjects"].AddItem(mbb);

            
            //TODO[enikulin]: add user rights

            //Debug! Profile map load
            mapControl.m_mapImage.MapRefreshed += m_mapImage_MapRefreshed;
            mapControl.m_mapImage.SizeChanged += m_mapImage_SizeChanged;
            //IApplicationForm initialization
            Sizable = true;
            HelpTopicId = "MapsConfiguration";
        }


        #region Debug! Profile map load
        void m_mapImage_SizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now + "Raw sizechanged" + mapControl.m_mapImage.Size.ToString());

        }

        void m_mapImage_MapRefreshed(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now + "Raw refreshed");
        }
        #endregion


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            using (new TemporaryWaitCursor())
            {
                //load map 
                mapControl.MapSpatRef = CoordinateSystems.SphericalMercatorCS;

                DateTime start = DateTime.Now;
                mapControl.LoadMap(MapProjectsStorage.DefaultMapPath);
                Debug.WriteLine("Loaded:" + (DateTime.Now - start).TotalMilliseconds);
                Debug.WriteLine("Loaded:" + DateTime.Now);
                mapControl.MapSelector.UpdateValue(MapProjectsStorage.DefaultMapName);

                //mapControl.Refresh();
            }
            
        }
       

        #region IApplicationForm Members

        public override string Caption
        {
            get { return Resources.gis_CustomizeMapForm_Caption; }
        }

        #endregion


      
    }
}
