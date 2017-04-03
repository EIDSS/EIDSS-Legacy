using System.Data;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM_DB.DBService;
using Ionic.Zlib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.common;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ZLibReportTests :BaseReportTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            PresenterFactory.Init(new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ResetReportDataCallback = () => { };
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void ZlibLayoutTest()
        {
            string streamXml;
            using (var pivotGrid = new RamPivotGrid())
            {
                DataTable dataTable = DataHelper.GenerateTestTable();
                pivotGrid.DataSourceWithFields = dataTable;

                streamXml = ViewReportTests.GetLayoutXml(pivotGrid);
            }

            byte[] bytes = BaseRamDbService.CompressString(streamXml);

            string uncompressed = BaseRamDbService.UncompressString(bytes);

            Assert.AreEqual(streamXml, uncompressed);
        }
    }
}
