using System;
using System.Collections.Specialized;
using System.Configuration;
using DevExpress.Data.PivotGrid;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Configuration;
using bv.common.Core;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void IsCalledFromUnitTest()
        {
            bool isInTest = Utils.IsCalledFromUnitTest();
            Assert.IsTrue(isInTest);
        }

        [TestMethod]
        public void ThrowExceptionOnErrorTest()
        {
            Assert.IsTrue(BaseSettings.ThrowExceptionOnError);
        }

        [TestMethod]
        public void PivotSummaryTypeParserBadValueTest()
        {
            CustomSummaryType type = PivotPresenter.ParseSummaryType(0);
            Assert.AreEqual(CustomSummaryType.Max, type);
        }

        [TestMethod]
        public void PivotSummaryTypeParserTest()
        {
            CustomSummaryType type = PivotPresenter.ParseSummaryType(10004002);
            Assert.AreEqual(CustomSummaryType.Count, type);
        }

        [TestMethod]
        public void PivotVasueTypeSummaryTypeConfigTest()
        {
            var section = (NameValueCollection)ConfigurationManager.GetSection("PivotValueTypeSummaryTypeSection");

            Assert.IsNotNull(section, "PivotValueTypeSummaryTypeSection not found");
            string intType = section["System.Int32"];
            Assert.IsNotNull(intType);
            Console.WriteLine(intType);
            var type = (PivotSummaryType)Enum.Parse(typeof(PivotSummaryType), intType);
            Assert.AreEqual(PivotSummaryType.Sum, type);

            string longType = section["System.Int64"];
            Assert.IsNotNull(intType);
            Console.WriteLine(intType);
            type = (PivotSummaryType)Enum.Parse(typeof(PivotSummaryType), longType);
            Assert.AreEqual(PivotSummaryType.Sum, type);

            string stringType = section["System.String"];
            Assert.IsNotNull(stringType);
            Console.WriteLine(stringType);
            type = (PivotSummaryType)Enum.Parse(typeof(PivotSummaryType), stringType);
            Assert.AreEqual(PivotSummaryType.Count, type);

            string dateType = section["System.DateTime"];
            Assert.IsNotNull(dateType);
            Console.WriteLine(dateType);
            type = (PivotSummaryType)Enum.Parse(typeof(PivotSummaryType), dateType);
            Assert.AreEqual(PivotSummaryType.Max, type);

            string def = section["Default"];
            Assert.IsNotNull(def);
            Console.WriteLine(def);
            type = (PivotSummaryType)Enum.Parse(typeof(PivotSummaryType), def);
            Assert.AreEqual(PivotSummaryType.Count, type);
        }

        [TestMethod]
        public void PivotFieldSummaryTypeeConfigTest()
        {
            var section = (NameValueCollection)ConfigurationManager.GetSection("PivotFieldSummaryTypeSection");

            Assert.IsNotNull(section, "PivotFieldSummaryTypeSection not found");
            string testFieldType = section["test_field"];
            Assert.IsNotNull(testFieldType);
            Console.WriteLine(testFieldType);
            var type = (PivotSummaryType)Enum.Parse(typeof(PivotSummaryType), testFieldType);
            Assert.AreEqual(PivotSummaryType.Max, type);
        }
    }
}
