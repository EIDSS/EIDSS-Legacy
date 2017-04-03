using System.Data.SqlClient;
using System.Windows.Forms;
using bv.common.db.Core;
using EIDSS.GISControl;
using EIDSS.GISControl.MapForms;
using NUnit.Framework;
using NUnit.Extensions.Forms;
using EIDSS.GISControl.Common;
using System.Data;

namespace EIDSS.Tests.GIS
{
    [TestFixture]
    public class GISControlTestWithEIDSS : BaseTests
    {
        #region Private methods

        private static void frm_OnCase(double? x, double? y)
        {
            //MessageBox.Show("X = " + x + "; Y = " + y);
        }

        private void SetCasePoint()
        {
        }

        #endregion

        #region Auto tests

        [Test]
        public void RAM_GisControlTest()
        {
            GisTestForm gisTestForm = new GisTestForm();
            gisTestForm.CloseAfterUse = true;
            gisTestForm.ShowDialog();
        }

        [Test]
        public void ShowCustomMapForm_Test()
        {
            CustomizeMapForm frm = new CustomizeMapForm();
            frm.Show();
            frm.Close();
        }
        
        [Test]
        public void SetCaseLocation_FormTest()
        {
            ExpectModal("SetCaseMapForm", SetCaseFormHandler);
            GISFactory.SetCaseLocation(780000000, 37020000000, 3290000000, 55670000000, 0, 0, frm_OnCase);
        }


        

        #region SetCaseLocation_FormTest routine
        private Timer timer = new Timer();

        public void SetCaseFormHandler()
        {
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, System.EventArgs e)
        {
            timer.Stop();

            //full extent
            Mouse.UseOn("mapControl1");
            Mouse.Click(135, 20);
            ////zoom in
            //Mouse.Click(160, 20);
            //Mouse.Hover(200, 50);
            //Mouse.Press(MouseButtons.Left, 200, 50);
            //Mouse.Release(MouseButtons.Left, 250, 100);

            //close
            Mouse.UseOn("okButton");
            Mouse.Click(3, 3);
            ControlTester controlTester = new ControlTester("okButton", "SetCaseMapForm");
            controlTester.FireEvent("Click");
        }
        #endregion

        #endregion

        #region Manual tests
        [Test]
        [Ignore("This is a manual test which shouldn't be run automatically")]
        public void RAM_GisControlTest_Manual()
        {
            GisTestForm gisTestForm = new GisTestForm();
            gisTestForm.CloseAfterUse = false;
            gisTestForm.ShowDialog();
        }

        [Test]
        [Ignore("This is a manual test which shouldn't be run automatically")]
        public void ShowSetCaseForm()
        {
            SetCaseMapForm frm = new SetCaseMapForm();
            frm.OnCase += frm_OnCase;
            //frm.SetCaseLocation(2360000000, 0, 0, 0, 60, 40);
            //frm.SetCaseLocation(2360000000, 0, 0, 0, null, null);
            // frm.SetCaseLocation(780000000, 0, 0, 43.6, 42.1);
            frm.SetCaseLocation(780000000, 37040000000, 3370000000, null, 41, 43);
        }

        [Test]
        [Ignore("This is a manual test which shouldn't be run automatically")]
        public void GisFactoryForm()
        {
            GISFactory.SetCaseLocation(780000000, 37020000000, 3290000000, 55670000000, 0, 0, frm_OnCase);
        }

        [Test]
        [Ignore("This is a manual test which shouldn't be run automatically")]
        public void MapCustomization_ManualFormTest()
        {
            GISFactory.ShowMapCustomization();
        }

        [Test]
        [Ignore("This is a manual test which shouldn't be run automatically")]
        public void GetSettlementCoord_ManualTest()
        {
            double x, y;
            GISFactory.GetSettlementCoordinates(55700000000, out x, out y);
        }

        [Test]
        [Ignore("This is a manual test which shouldn't be run automatically")]
        public void GetRelativeCoord_ManualTest()
        {
            double x, y;
            GISFactory.GetRelativeCoordinates(55700000000, 135, 50000, out x, out y);
        }

        [Test]
        [Ignore("This is a manual test which shouldn't be run automatically")]
        public void IsPointInside_ManualTest()
        {
            bool b = GISFactory.IsPointInside(41.485, 42.671, 3270000000);
        }

        #endregion
    }
}
