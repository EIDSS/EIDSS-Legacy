using System;
using System.Collections.Specialized;
using System.Configuration;
using DevExpress.Data.PivotGrid;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary;
using NUnit.Framework;
using GlobalSettings=bv.common.GlobalSettings;


namespace EIDSS.Tests.RAM.UnitTests
{
    [TestFixture]
    public class ConfigurationTests  :BaseTests
    {
        [Test]
        public void ThrowExceptionOnErrorTest()
        {
            Assert.IsTrue(GlobalSettings.ThrowExceptionOnError);
        }

        [Test]
        public void PivotSummaryTypeParserBadValueTest()
        {
            CustomSummaryType type = PivotPresenter.ParseSummaryType(0);
            Assert.AreEqual(CustomSummaryType.Max, type);
        }

        [Test]
        public void PivotSummaryTypeParserTest()
        {
            CustomSummaryType type = PivotPresenter.ParseSummaryType(10004002);
            Assert.AreEqual(CustomSummaryType.Count, type);
        }

        [Test]
        public void PivotVasueTypeSummaryTypeConfigTest()
        {
            NameValueCollection section =
                (NameValueCollection) ConfigurationManager.GetSection("PivotValueTypeSummaryTypeSection");


            string intType = section["System.Int32"];
            Assert.IsNotNull(intType);
            Console.WriteLine(intType);
            PivotSummaryType type = (PivotSummaryType)Enum.Parse(typeof(PivotSummaryType), intType);
            Assert.AreEqual(PivotSummaryType.Sum, type);


            string longType = section["System.Int64"];
            Assert.IsNotNull(intType);
            Console.WriteLine(intType);
            type = (PivotSummaryType)Enum.Parse(typeof(PivotSummaryType), longType);
            Assert.AreEqual(PivotSummaryType.Sum, type);


            string stringType = section["System.String"];
            Assert.IsNotNull(stringType);
            Console.WriteLine(stringType);
            type = (PivotSummaryType) Enum.Parse(typeof (PivotSummaryType), stringType);
            Assert.AreEqual(PivotSummaryType.Count, type);

            string dateType = section["System.DateTime"];
            Assert.IsNotNull(dateType);
            Console.WriteLine(dateType);
            type = (PivotSummaryType) Enum.Parse(typeof (PivotSummaryType), dateType);
            Assert.AreEqual(PivotSummaryType.Max, type);

            string def = section["Default"];
            Assert.IsNotNull(def);
            Console.WriteLine(def);
            type = (PivotSummaryType) Enum.Parse(typeof (PivotSummaryType), def);
            Assert.AreEqual(PivotSummaryType.Count, type);
        }
    }
}