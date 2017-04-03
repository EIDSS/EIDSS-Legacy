#region Using

using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using bv.common;
using bv.common.win;
using DevExpress.XtraCharts;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.Reports.BaseControls.Transaction;
using EIDSS.Tests.RAM.Helpers;
using NUnit.Framework;

#endregion

namespace EIDSS.Tests.RAM.UnitTests
{
    [TestFixture]
    public class ComponentsTests
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            PresenterFactory.Init(new BaseForm());
            
        }

        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        [Test]
        public void UpdatePivotCaptionTest()
        {
            RamPivotGrid pivotGridControl = new RamPivotGrid();
            DataTable dataTable = DataHelper.GenerateTestTable();

            pivotGridControl.DataSource = dataTable;
            Assert.AreEqual("column1_Caption", pivotGridControl.Fields[0].Caption);
            Assert.AreEqual("column2_Caption", pivotGridControl.Fields[1].Caption);
            Assert.AreEqual("column3_Caption", pivotGridControl.Fields[2].Caption);
        }

        [Test]
        public void UpdatePivotDataTest()
        {
            RamPivotGrid pivotGridControl = new RamPivotGrid();
            DataTable dataTable = DataHelper.GenerateTestTable();
            
            pivotGridControl.DataSource = dataTable;

            Assert.AreEqual(3, pivotGridControl.Fields.Count);
        }

        [Test]
        public void PivotFilteredDataSourceTest()
        {
            RamPivotGrid pivotGrid = new RamPivotGrid();
            DataTable dataTable = DataHelper.GenerateTestTable();
            pivotGrid.DataSource = dataTable;
            Assert.AreEqual(3, pivotGrid.Fields.Count);
            pivotGrid.Fields[0].Visible = true;
            pivotGrid.Fields[1].Visible = false;
            pivotGrid.Fields[2].Visible = false;
            DataTable filteredDataSource = pivotGrid.GetFilteredDataSource("Layout");
            Assert.AreEqual(1, filteredDataSource.Columns.Count);
        }
       

        #region chart tests

        [Test]
        public void ConstructorChartControlMediatorTest()
        {
            Control parent = new Control();
            ChartControlMediator mediator = new ChartControlMediator(parent);
            Assert.AreEqual(1, parent.Controls.Count);
            Assert.IsTrue(parent.Controls[0] is ChartControl);
            Assert.AreEqual(mediator.ChartControl, parent.Controls[0]);
        }

        [Test]
        public void ChartTitleTest()
        {
            ChartControlMediator mediator = new ChartControlMediator(new Control());
            mediator.ChartName = "xxx";
            Assert.AreEqual("xxx", mediator.ChartControl.Titles[0].Text);
            mediator.ChartFilter = "yyy";
            Assert.AreEqual("yyy", mediator.ChartControl.Titles[1].Text);
        }

        [Test]
        public void EmptyChartTitleTest()
        {
            ChartControlMediator mediator = new ChartControlMediator(new Control());
            mediator.ChartName = string.Empty;
            Assert.AreEqual("[Untitled]", mediator.ChartControl.Titles[0].Text);
        }

     

        public static DataTable GenerateChartTestTable()
        {
            DataTable dataTable = new DataTable("testTable");
            dataTable.Columns.Add(DataHelper.GenerateColumn("Series", typeof (string)));
            dataTable.Columns.Add(DataHelper.GenerateColumn("Arguments", typeof (string)));
            dataTable.Columns.Add(DataHelper.GenerateColumn("Values", typeof (int)));
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

        [Test]
        public void PivotFormatDateTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                object dateQuarter = CalendarHelper.FormatDate(PivotGroupInterval.DateQuarter, new DateTime(2009, 5, 10));
                Assert.AreEqual(2, dateQuarter);
                dateQuarter = CalendarHelper.FormatDate(PivotGroupInterval.DateQuarter, new DateTime(2009, 11, 10));
                Assert.AreEqual(4, dateQuarter);
                dateQuarter = CalendarHelper.FormatDate(PivotGroupInterval.DateQuarter, new DateTime(2009, 2, 10));
                Assert.AreEqual(1, dateQuarter);
                dateQuarter = CalendarHelper.FormatDate(PivotGroupInterval.DateQuarter, new DateTime(2009, 8, 10));
                Assert.AreEqual(3, dateQuarter);

                object dateYear = CalendarHelper.FormatDate(PivotGroupInterval.DateYear, new DateTime(2009, 5, 10));
                Assert.AreEqual(2009, dateYear);

                object dateMonth = CalendarHelper.FormatDate(PivotGroupInterval.DateMonth, new DateTime(2009, 5, 10));
                Assert.AreEqual("May", dateMonth);
                object dateWeekOfYear = CalendarHelper.FormatDate(PivotGroupInterval.DateWeekOfYear,
                                                                  new DateTime(2009, 1, 1));
                Assert.AreEqual(1, dateWeekOfYear);
                dateWeekOfYear = CalendarHelper.FormatDate(PivotGroupInterval.DateWeekOfYear, new DateTime(2009, 1, 4));
                Assert.AreEqual(1, dateWeekOfYear);
                dateWeekOfYear = CalendarHelper.FormatDate(PivotGroupInterval.DateWeekOfYear, new DateTime(2009, 1, 5));
                Assert.AreEqual(2, dateWeekOfYear);
                dateWeekOfYear = CalendarHelper.FormatDate(PivotGroupInterval.DateWeekOfYear, new DateTime(2009, 1, 11));
                Assert.AreEqual(2, dateWeekOfYear);
                dateWeekOfYear = CalendarHelper.FormatDate(PivotGroupInterval.DateWeekOfYear, new DateTime(2006, 1, 8));
                Assert.AreEqual(1, dateWeekOfYear);
                object dateWeekOfMonth = CalendarHelper.FormatDate(PivotGroupInterval.DateWeekOfMonth,
                                                                   new DateTime(2009, 7, 20));
                Assert.AreEqual(4, dateWeekOfMonth);
                dateWeekOfMonth = CalendarHelper.FormatDate(PivotGroupInterval.DateWeekOfMonth,
                                                            new DateTime(2009, 7, 19));
                Assert.AreEqual(3, dateWeekOfMonth);
                dateWeekOfMonth = CalendarHelper.FormatDate(PivotGroupInterval.DateWeekOfMonth, new DateTime(2009, 3, 1));
                Assert.AreEqual(1, dateWeekOfMonth);
                dateWeekOfMonth = CalendarHelper.FormatDate(PivotGroupInterval.DateWeekOfMonth, new DateTime(2009, 3, 2));
                Assert.AreEqual(2, dateWeekOfMonth);
            }
        }

        [Test]
        public void PivotIsDateTest()
        {
            Assert.IsFalse(CalendarHelper.IsDate(PivotGroupInterval.Alphabetical));
            Assert.IsFalse(CalendarHelper.IsDate(PivotGroupInterval.Custom));
            Assert.IsTrue(CalendarHelper.IsDate(PivotGroupInterval.Date));
            Assert.IsTrue(CalendarHelper.IsDate(PivotGroupInterval.DateDay));
            Assert.IsTrue(CalendarHelper.IsDate(PivotGroupInterval.DateDayOfWeek));
            Assert.IsTrue(CalendarHelper.IsDate(PivotGroupInterval.DateDayOfYear));
            Assert.IsTrue(CalendarHelper.IsDate(PivotGroupInterval.DateYear));
            Assert.IsFalse(CalendarHelper.IsDate(PivotGroupInterval.DayAge));
            Assert.IsFalse(CalendarHelper.IsDate(PivotGroupInterval.Default));
        }

        #endregion
    }
}