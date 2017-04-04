using System.Data;
using bv.common.win;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM.Layout;
using EIDSS.Tests.RAM.Helpers;
using Ionic.Zlib;
using NUnit.Framework;

namespace EIDSS.Tests.RAM.UnitTests
{
    [TestFixture]
    public class ZLIbTests
    {
        [TestFixtureSetUp]
        public  void FixtureSetUp()
        {
           // base.FixtureSetUp();

            PresenterFactory.Init(new BaseForm());
            
        }
        [Test]
        public void ZlibLayoutTest()
        {

            RamPivotGrid pivotGrid = new RamPivotGrid();
            DataTable dataTable = DataHelper.GenerateTestTable();
            pivotGrid.DataSource = dataTable;

            string streamXml = ViewTests.GetLayoutXml(pivotGrid);

            byte[] bytes = ZlibStream.CompressString(streamXml);

            string uncompressed = ZlibStream.UncompressString(bytes);

            Assert.AreEqual(streamXml, uncompressed);
        }
    }
}