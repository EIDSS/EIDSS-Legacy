using System;
using eidss.avr.db.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class AvrAccessSerializerTests
    {
        [TestMethod]
        public void ErrorAccessResultSerializeTest()
        {
            var source = new AvrAccessExportResult("xxx", new InvalidOperationException("yyy").ToString());
            string xml = source.Serialize();
            AvrAccessExportResult result = AvrAccessExportResult.Deserialize(xml);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("xxx", result.ErrorMessage);
            Assert.IsTrue(string.IsNullOrEmpty(result.ResultFilePath));
            Assert.AreEqual(source.ExceptionString, result.ExceptionString);

            string resultXml = result.Serialize();
            Assert.IsNotNull(resultXml);
            Assert.AreEqual(xml, resultXml);
        }

        [TestMethod]
        public void SuccessAccessResultSerializeTest()
        {
            var source = new AvrAccessExportResult(1, "en","xxx");
            string xml = source.Serialize();
            AvrAccessExportResult result = AvrAccessExportResult.Deserialize(xml);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual("xxx", result.ResultFilePath);
            Assert.AreEqual(1, result.QueryId);
            Assert.IsTrue(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.IsTrue(string.IsNullOrEmpty(result.ExceptionString));

            string resultXml = result.Serialize();
            Assert.IsNotNull(resultXml);
            Assert.AreEqual(xml, resultXml);
        }
    }
}