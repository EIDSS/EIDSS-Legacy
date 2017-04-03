using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.win;
using bv.tests.AVR.Helpers;
using DevExpress.XtraCharts;
using DevExpress.XtraPivotGrid;
using EIDSS;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.Reports.BaseControls.Transaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Core.CultureInfo;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ComponentsTests
    {
        [TestInitialize]
        public void TestFixtureSetUp()
        {
            EIDSS_LookupCacheHelper.Init();
            PresenterFactory.Init(new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ResetReportDataCallback = () => { };
        }

        [TestCleanup]
        public void TearDown()
        {
            MemoryManager.Flush();
        }

        [TestMethod]
        public void UpdatePivotCaptionTest()
        {
            using (var pivotGridControl = new RamPivotGrid())
            {
                DataTable dataTable = DataHelper.GenerateTestTable();

                pivotGridControl.DataSourceWithFields = dataTable;
                Assert.AreEqual("sflHC_PatientAge_Caption", pivotGridControl.Fields[0].Caption);
                Assert.AreEqual("sflHC_PatientDOB_Caption", pivotGridControl.Fields[1].Caption);
                Assert.AreEqual("sflHC_CaseID_Caption", pivotGridControl.Fields[2].Caption);
            }
        }

        [TestMethod]
        public void UpdatePivotDataTest()
        {
            using (var pivotGridControl = new RamPivotGrid())
            {
                DataTable dataTable = DataHelper.GenerateTestTable();

                pivotGridControl.DataSourceWithFields = dataTable;

                Assert.AreEqual(3, pivotGridControl.Fields.Count);
            }
        }

        [TestMethod]
        public void PivotFilteredDataSourceTest()
        {
            using (var pivotGrid = new RamPivotGrid())
            {
                DataTable dataTable = DataHelper.GenerateTestTable();
                pivotGrid.DataSourceWithFields = dataTable;
                Assert.AreEqual(3, pivotGrid.Fields.Count);
                pivotGrid.Fields[0].Visible = true;
                pivotGrid.Fields[1].Visible = false;
                pivotGrid.Fields[2].Visible = false;
                DataTable filteredDataSource = pivotGrid.GetFilteredDataSource("Layout");
                Assert.AreEqual(1, filteredDataSource.Columns.Count);
            }

        }

        #region chart tests

        [TestMethod]
        public void ConstructorChartControlMediatorTest()
        {
            var parent = new Control();
            var mediator = new ChartControlMediator(parent);
            Assert.AreEqual(1, parent.Controls.Count);
            Assert.IsTrue(parent.Controls[0] is ChartControl);
            Assert.AreEqual(mediator.ChartControl, parent.Controls[0]);
        }

        [TestMethod]
        public void ChartTitleTest()
        {
            var mediator = new ChartControlMediator(new Control()) { ChartName = "xxx" };
            Assert.AreEqual("xxx", mediator.ChartControl.Titles[0].Text);
            mediator.ChartFilter = "yyy";
            Assert.AreEqual("yyy", mediator.ChartControl.Titles[1].Text);
        }

        [TestMethod]
        public void EmptyChartTitleTest()
        {
            using (new CultureInfoTransaction(CultureInfo.GetCultureInfo("en-US")))
            {
                var mediator = new ChartControlMediator(new Control()) { ChartName = string.Empty };
                Assert.AreEqual("[Untitled]", mediator.ChartControl.Titles[0].Text);
            }
        }

        public static DataTable GenerateChartTestTable()
        {
            var dataTable = new DataTable("testTable");
            dataTable.Columns.Add(DataHelper.GenerateColumn("Series", typeof(string)));
            dataTable.Columns.Add(DataHelper.GenerateColumn("Arguments", typeof(string)));
            dataTable.Columns.Add(DataHelper.GenerateColumn("Values", typeof(int)));
            for (int i = 0; i < 10; i++)
            {
                DataRow workRow = dataTable.NewRow();
                workRow[0] = "series1";
                workRow[1] = "name_" + i;
                workRow[2] = i;
                dataTable.Rows.Add(workRow);
            }
            return dataTable;
        }

        #endregion

        #region calendar tests

        [TestMethod]
        public void PivotFormatDateTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                object dateQuarter = new DateTime(2009, 5, 10).ToString(PivotGroupInterval.DateQuarter);
                Assert.AreEqual(2, dateQuarter);
                dateQuarter = new DateTime(2009, 11, 10).ToString(PivotGroupInterval.DateQuarter);
                Assert.AreEqual(4, dateQuarter);
                dateQuarter = new DateTime(2009, 2, 10).ToString(PivotGroupInterval.DateQuarter);
                Assert.AreEqual(1, dateQuarter);
                dateQuarter = new DateTime(2009, 8, 10).ToString(PivotGroupInterval.DateQuarter);
                Assert.AreEqual(3, dateQuarter);

                object dateYear = new DateTime(2009, 5, 10).ToString(PivotGroupInterval.DateYear);
                Assert.AreEqual(2009, dateYear);

                object dateMonth = new DateTime(2009, 5, 10).ToString(PivotGroupInterval.DateMonth);
                Assert.AreEqual("May", dateMonth);
                object dateWeekOfYear = new DateTime(2009, 1, 1).ToString(PivotGroupInterval.DateWeekOfYear);
                Assert.AreEqual(1, dateWeekOfYear);
                dateWeekOfYear = new DateTime(2009, 1, 4).ToString(PivotGroupInterval.DateWeekOfYear);
                Assert.AreEqual(1, dateWeekOfYear);
                dateWeekOfYear = new DateTime(2009, 1, 5).ToString(PivotGroupInterval.DateWeekOfYear);
                Assert.AreEqual(2, dateWeekOfYear);
                dateWeekOfYear = new DateTime(2009, 1, 11).ToString(PivotGroupInterval.DateWeekOfYear);
                Assert.AreEqual(2, dateWeekOfYear);
                dateWeekOfYear = new DateTime(2006, 1, 8).ToString(PivotGroupInterval.DateWeekOfYear);
                Assert.AreEqual(1, dateWeekOfYear);
                object dateWeekOfMonth = new DateTime(2009, 7, 20).ToString(PivotGroupInterval.DateWeekOfMonth);
                Assert.AreEqual(4, dateWeekOfMonth);
                dateWeekOfMonth = new DateTime(2009, 7, 19).ToString(PivotGroupInterval.DateWeekOfMonth);
                Assert.AreEqual(3, dateWeekOfMonth);
                dateWeekOfMonth = new DateTime(2009, 3, 1).ToString(PivotGroupInterval.DateWeekOfMonth);
                Assert.AreEqual(1, dateWeekOfMonth);
                dateWeekOfMonth = new DateTime(2009, 3, 2).ToString(PivotGroupInterval.DateWeekOfMonth);
                Assert.AreEqual(2, dateWeekOfMonth);
            }
        }

        [TestMethod]
        public void PivotIsDateTest()
        {
            Assert.IsFalse(PivotGroupInterval.Alphabetical.IsDate());
            Assert.IsFalse(PivotGroupInterval.Custom.IsDate());
            Assert.IsTrue(PivotGroupInterval.Date.IsDate());
            Assert.IsTrue(PivotGroupInterval.DateDay.IsDate());
            Assert.IsTrue(PivotGroupInterval.DateDayOfWeek.IsDate());
            Assert.IsTrue(PivotGroupInterval.DateDayOfYear.IsDate());
            Assert.IsTrue(PivotGroupInterval.DateYear.IsDate());
            Assert.IsFalse(PivotGroupInterval.DayAge.IsDate());
            Assert.IsFalse(PivotGroupInterval.Default.IsDate());
        }

        #endregion
    }
}
