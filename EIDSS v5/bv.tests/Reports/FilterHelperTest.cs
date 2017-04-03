using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.common;
using eidss.model.Core.CultureInfo;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace bv.tests.Reports
{
    [TestClass]
    public class FilterHelperTest
    {
        [TestMethod]
        public void GetDefaultLocationTest()
        {
            BaseReportTests.InitDBAndLogin();
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                long? regionId;
                long? rayonId;
                FilterHelper.GetDefaultLocation(out regionId, out rayonId);
                Assert.IsNotNull(regionId);
                Assert.IsNotNull(rayonId);
            }
        }

        [TestMethod]
        public void GetHumanDiagnosisListTest()
        {
            BaseReportTests.InitDBAndLogin();
            List<SelectListItemSurrogate> humanDiagnosisList = FilterHelper.GetHumanDiagnosisList("en");
            Assert.IsNotNull(humanDiagnosisList);
            Assert.IsTrue(humanDiagnosisList.Count > 0, "Diagnosis lookup is empty");
            Assert.IsTrue(humanDiagnosisList.Exists(c => c.Text == "Botulism"), "Botulism diagnosis not found");
        }

        [TestMethod]
        public void GetGetKzFilterListTest()
        {
            BaseReportTests.InitDBAndLogin();
            foreach (ReportFilterType filter in Enum.GetValues(typeof (ReportFilterType)))
            {
                if (filter != ReportFilterType.None)
                {
                    List<SelectListItemSurrogate> list = FilterHelper.GetKzFilterList("en", filter);
                    Assert.IsNotNull(list);
                    Assert.IsTrue(list.Count > 0, string.Format("Lookup {0} is empty", filter));
                }
            }
        }

        [TestMethod]
        public void GetAllRayonsTest()
        {
            BaseReportTests.InitDBAndLogin();
            List<SelectListItemSurrogate> rayons = FilterHelper.GetAllRayons("en");
            Assert.IsNotNull(rayons);
            Assert.IsTrue(rayons.Count > 0, "Rayon lookup is empty");
            Assert.IsTrue(rayons.Exists(c => c.Text == "Gagra"), "Rayon Gagra not found");
        }

        [TestMethod]
        public void GetAllRegionsTest()
        {
            BaseReportTests.InitDBAndLogin();
            List<SelectListItemSurrogate> regions = FilterHelper.GetAllRegions("en");
            Assert.IsNotNull(regions);
            Assert.IsTrue(regions.Count > 0, "Region lookup is empty");
            Assert.IsTrue(regions.Exists(c => c.Text == "Abkhazia"), "Region Abkhazia not found");
        }

        [TestMethod]
        public void SupportedLanguagesTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                AssertListItem(FilterHelper.GetSupportedLanguages, "English (English)");
            }
        }

        [TestMethod]
        public void ExportFormatsListTest()
        {
            AssertListItem(FilterHelper.GetExportFormats, 4, "Pdf");
        }

        [TestMethod]
        public void PageSizeListTest()
        {
            AssertListItem(FilterHelper.GetPageSizeList, 2, "A4");
        }

        [TestMethod]
        public void PeriodTypeCollectionTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                AssertListItem(() => FilterHelper.GetPeriodTypeList(0), 4, "Month");
            }
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
            {
                AssertListItem(() => FilterHelper.GetPeriodTypeList(0), 4, "Месяц");
            }
        }

        [TestMethod]
        public void CounterCollectionTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                AssertListItem(() => FilterHelper.GetCounterList(0), 4, "Absolute number");
            }
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
            {
                AssertListItem(() => FilterHelper.GetCounterList(0), 4, "Абсолютное число");
            }
        }

        [TestMethod]
        public void CreateHalfYearCollectionTest()
        {
            AssertListItem(() => FilterHelper.GetHalfYearList(1), 2, "I");
        }

        [TestMethod]
        public void CreateQuarterCollectionTest()
        {
            AssertListItem(() => FilterHelper.GetQuarterList(1), 4, "1");
        }

        [TestMethod]
        public void MonthListTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                AssertListItem(() => FilterHelper.GetMonthList(0), 12, "January");
            }
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
            {
                AssertListItem(() => FilterHelper.GetMonthList(0), 12, "Январь");
            }
        }

        [TestMethod]
        public void GetRayonIdTest()
        {
            long? rayonId = FilterHelper.GetRayonIdFromComplexId("123__456");
            Assert.IsNotNull(rayonId);
            Assert.AreEqual(456, rayonId);
        }

        [TestMethod]
        public void GetRegionIdTest()
        {
            long? regionId = FilterHelper.GetRegionIdFromComplexId("123__456");
            Assert.IsNotNull(regionId);
            Assert.AreEqual(123, regionId);
        }

        private static List<SelectListItemSurrogate> AssertListItem(Func<List<SelectListItemSurrogate>> getList, string itemText)
        {
            List<SelectListItemSurrogate> list = getList();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Exists(m => m.Text == itemText));
            return list;
        }

        private static List<SelectListItemSurrogate> AssertListItem(Func<List<SelectListItemSurrogate>> getList, int count, string itemText)
        {
            List<SelectListItemSurrogate> list = AssertListItem(getList, itemText);
            Assert.AreEqual(count, list.Count);
            return list;
        }
    }
}