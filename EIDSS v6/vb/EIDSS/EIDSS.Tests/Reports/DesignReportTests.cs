using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.Barcode.Designer;
using EIDSS.Reports.BaseControls.Report;
using NUnit.Framework;

namespace EIDSS.Tests.Reports
{
    [TestFixture]
    public class DesignReportTests : BaseTests
    {
        [Test]
        public void DesignLayoutTest()
        {
            BaseBarcodeReport report = new BaseBarcodeReport();
            string layout = DesignController.GetLayout(report);
            XtraReport newReport = DesignController.GetReport(layout);
            string newLayout = DesignController.GetLayout(newReport);

            Assert.AreEqual(layout.Length, newLayout.Length);

            List<string> layoutLines = new List<string>(layout.Split('\n'));
            layoutLines.Sort();
            List<string> newLayoutLines = new List<string>(newLayout.Split('\n'));
            newLayoutLines.Sort();

            Assert.AreEqual(layoutLines.Count, newLayoutLines.Count);

            for (int i = 0; i < layoutLines.Count; i++)
            {
                Assert.AreEqual(layoutLines[i], newLayoutLines[i]);
            }
        }

        [Test]
        public void DesignDbAdapterSaveGetTest()
        {
            DesignDbAdapter adapter = new DesignDbAdapter(10057020);
            adapter.SaveBarcodeLayout("test");
            string layout = adapter.GetBarcodeLayout();

            Assert.AreEqual("test", layout);
        }

        [Test]
        public void DesignDbAdapterDoubleSaveTest()
        {
            DesignDbAdapter adapter = new DesignDbAdapter(10057020);
            adapter.SaveBarcodeLayout("test");
            adapter.SaveBarcodeLayout("new");
            string layout = adapter.GetBarcodeLayout();

            Assert.AreEqual("new", layout);
        }

        [Test]
        public void DesignDbAdapterDeleteTest()
        {
            DesignDbAdapter adapter = new DesignDbAdapter(10057020);
            adapter.SaveBarcodeLayout("test");
            adapter.DeleteBarcodeLayout();
            string layout = adapter.GetBarcodeLayout();
            Assert.IsTrue(string.IsNullOrEmpty(layout));
        }
    }
}