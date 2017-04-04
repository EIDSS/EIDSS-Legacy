using System.Data;
using eidss.avr.db.CacheReceiver;
using eidss.model.Avr.View;
using eidss.model.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class AvrViewSerializerTests

    {
        [TestMethod]
        public void EmptyColumnBandViewSerializeTest()
        {
            var view = new AvrView(-1, "layoutName", -1);
            string viewXml = AvrViewSerializer.Serialize(view);
            Assert.IsNotNull(viewXml);

            var bandSerializer = new EidssSerializer<AvrViewBand>();
            var band = new AvrViewBand();
            string bandXml = bandSerializer.Serialize(band);
            Assert.IsNotNull(bandXml);

            var colSerializer = new EidssSerializer<AvrViewColumn>();
            var column = new AvrViewColumn();
            column.FieldType = typeof (string);
            string columnXml = colSerializer.Serialize(column);
            Assert.IsNotNull(columnXml);

            AvrViewColumn newColumn = colSerializer.Deserialize(columnXml);
            Assert.AreEqual(column.FieldType, newColumn.FieldType);
        }

        [TestMethod]
        public void FullViewSerializeTest()
        {
            AvrView avrView = AvrViewSerializer.Deserialize(SerializedViewStub.ViewXml);
            Assert.IsNotNull(avrView);

            string viewXmlNew = AvrViewSerializer.Serialize(avrView);
            Assert.AreEqual(SerializedViewStub.ViewXml, viewXmlNew);

            DataTable dataTable = DataTableSerializer.Deserialize(SerializedViewStub.DataXml);
            Assert.IsNotNull(dataTable);

            string dataXmlNew = DataTableSerializer.Serialize(dataTable);
            Assert.AreEqual(SerializedViewStub.DataXml, dataXmlNew);
        }
    }
}