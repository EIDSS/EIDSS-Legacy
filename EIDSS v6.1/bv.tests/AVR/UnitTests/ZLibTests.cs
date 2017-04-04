using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.common;
using eidss.avr;
using eidss.avr.db.Common;
using eidss.avr.PivotComponents;
using eidss.model.AVR.SourceData;
using eidss.model.WindowsService.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ZLibTests : BaseReportTests
    {
        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void ZlibLayoutTest()
        {
            string streamXml;
            using (PresenterFactory.BeginSharedPresenterTransaction(m_Container, new BaseForm()))
            {
                using (var pivotGrid = new AvrPivotGrid())
                {
                    var dataTable = new AvrDataTable(DataHelper.GenerateTestTable());
                    pivotGrid.SetDataSourceAndCreateFields(dataTable);

                    streamXml = ViewReportTests.GetLayoutXml(pivotGrid);
                }
            }

            byte[] bytes = BinaryCompressor.ZipString(streamXml);

            string uncompressed = BinaryCompressor.UnzipString(bytes);

            Assert.AreEqual(streamXml, uncompressed);
        }

        [TestMethod]
        public void ZlibCompressDecompressTest()
        {
            const string xml = @"<AvrPivotGridFieldFilterValues>
  <DeferFilterString />
  <ShowBlanks>false</ShowBlanks>
  <FilterType>Included</FilterType>
  <Values>
    <anyType xmlns:q1=""http://www.w3.org/2001/XMLSchema"" d3p1:type=""q1:string"" xmlns:d3p1=""http://www.w3.org/2001/XMLSchema-instance"">Botulism</anyType>
    <anyType xmlns:q2=""http://www.w3.org/2001/XMLSchema"" d3p1:type=""q2:string"" xmlns:d3p1=""http://www.w3.org/2001/XMLSchema-instance"">Anthrax - Pulmonary</anyType>
  </Values>
</AvrPivotGridFieldFilterValues>";

            string compressed = AvrPivotGridFieldExtender.CompressEndEncodeString(xml);
            string uncompressed = AvrPivotGridFieldExtender.UncompressEndDecodeString(compressed);

            Assert.AreEqual(xml, uncompressed);
        }
    }
}