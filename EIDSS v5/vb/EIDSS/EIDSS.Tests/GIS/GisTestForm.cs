using System;
using System.Drawing;
using bv.common.db.Core;
using bv.common.win;
using DevExpress.XtraEditors;
using System.Drawing.Imaging;
using EIDSS.GISControl.Common;
using System.Windows.Forms;

namespace EIDSS.Tests.GIS
{
    public partial class GisTestForm : XtraForm
    {
        public GisTestForm()
        {
            InitializeComponent();
        }

        private bool m_closeAfterUse;
        public bool CloseAfterUse
        {
            get { return m_closeAfterUse; }
            set { m_closeAfterUse = value; }
        }

        private void GisTestForm_Load(object sender, EventArgs e)
        {
            //mapControl1.ConnectionString = ConnectionManager.DefaultInstance.ConnectionString;
            mapControl1.Init(ConnectionManager.DefaultInstance.ConnectionString);

            mapControl1.UpdateEventMap("Title", "RAM_Data",
                                       GISControlTestInfo.GetRegionalEvents(
                                           ConnectionManager.DefaultInstance.ConnectionString, 50, 150),m_mapSettings);
            mapControl1.UpdateEventMap("Title", "RAM_Data",
                                       GISControlTestInfo.GetDistrictEvents(
                                           ConnectionManager.DefaultInstance.ConnectionString, 50, 150), m_mapSettings);
            mapControl1.UpdateEventMap("AVR: Settlement Events", "RAM_Data",
                                       GISControlTestInfo.GetSttEvents(
                                           ConnectionManager.DefaultInstance.ConnectionString, 50, 500), m_mapSettings);
            mapControl1.UpdateEventMap("AVR: Case Data", "RAM_Data",
                                       GISControlTestInfo.GetCaseEvents(), m_mapSettings);

            //mapControl1.UpdateCaseMap("Title", "Case_Data", GISControlTestInfo.GetCaseEvents(), m_mapSettings);

            Bitmap bitmap = mapControl1.GetMapImage(297, 210);
            
            //mapControl1.ExportMap(@"c:\map.png", 297, 210, ImageFormat.Png);

            mapControl1.OnMapSettingsChanged += new EIDSS.GISControl.MapControl.MapSettingsChangeHandler(mapControl1_OnMapSettingsChanged);

            if (m_closeAfterUse) Close();
            
        }

        void mapControl1_OnMapSettingsChanged()
        {
            MessageBox.Show("Changed");
        }

        

        private void mapControl1_Load(object sender, EventArgs e)
        {

        }

        private void mapControl1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            mapControl1.UpdateEventMap("AVR: Settlement Events", "RAM_Data",
                                       GISControlTestInfo.GetSttEvents(
                                           ConnectionManager.DefaultInstance.ConnectionString, 50, 500),m_mapSettings);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            mapControl1.UpdateEventMap("Title", "RAM_Data",
                                       GISControlTestInfo.GetDistrictEvents(
                                           ConnectionManager.DefaultInstance.ConnectionString, 50, 150),m_mapSettings);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            mapControl1.UpdateEventMap("Title", "RAM_Data",
                                       GISControlTestInfo.GetRegionalEvents(
                                           ConnectionManager.DefaultInstance.ConnectionString, 50, 150),m_mapSettings);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            mapControl1.UpdateEventMap("AVR: Case Data", "RAM_Data",
                                       GISControlTestInfo.GetCaseEvents(), m_mapSettings);

            //mapControl1.UpdateCaseMap("Title", "Case_Data", GISControlTestInfo.GetCaseEvents(),m_mapSettings);
        }

        private EventLayerSettings m_mapSettings;
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            
            
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            m_mapSettings = mapControl1.MapSettings;
        }

        private void panelControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}