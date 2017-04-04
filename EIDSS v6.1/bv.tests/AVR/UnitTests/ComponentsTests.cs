using System;
using System.Data;
using System.Globalization;
using bv.common.Configuration;
using bv.common.win;
using bv.model.BLToolkit;
using bv.tests.AVR.Helpers;
using bv.tests.AVR.IntegrationTests;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using DevExpress.XtraPivotGrid;
using EIDSS;
using eidss.avr;
using eidss.avr.ChartForm;
using eidss.avr.db.Common;
using eidss.avr.PivotComponents;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using eidss.model.Core.CultureInfo;
using eidss.model.WindowsService.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ComponentsTests
    {
        private IDisposable m_PresenterTransaction;

        
        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { });
            return c;
        }
        [TestInitialize]
        public void MyTestInitialize()
        {
            EIDSS_LookupCacheHelper.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(StructureMapContainerInit(), new BaseForm());
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            m_PresenterTransaction.Dispose();
        }


        [TestMethod]
        public void AvrTableToTableTest()
        {
            var originalTable = DataHelper.GenerateTestTable();
            var avrTable = new AvrDataTable(originalTable);
            AccessTests.RemoveCopyColumns(avrTable);
            var finalTable = avrTable.ToDataTable();
            BinarySerializerTests.AssertTablesAreEqual(originalTable, finalTable);
        }

        [TestMethod]
        public void UpdatePivotCaptionTest()
        {
            using (var pivotGridControl = new AvrPivotGrid())
            {
                var dataTable = new AvrDataTable(DataHelper.GenerateTestTable());

                pivotGridControl.SetDataSourceAndCreateFields(dataTable);
                Assert.AreEqual("sflHC_PatientAge_Caption", pivotGridControl.Fields[0].Caption);
                Assert.AreEqual("sflHC_PatientDOB_Caption", pivotGridControl.Fields[2].Caption);
                Assert.AreEqual("sflHC_CaseID_Caption", pivotGridControl.Fields[4].Caption);
            }
        }

        [TestMethod]
        public void UpdatePivotDataTest()
        {
            using (var pivotGridControl = new AvrPivotGrid())
            {
                var dataTable = new AvrDataTable(DataHelper.GenerateTestTable());
                Assert.AreEqual(6, dataTable.Columns.Count);
                

                pivotGridControl.SetDataSourceAndCreateFields(dataTable);

                Assert.AreEqual(dataTable.Columns.Count, pivotGridControl.Fields.Count);
            }
        }

        

        #region chart tests

        [TestMethod]
        public void ChartTitleTest()
        {
            var mediator = new ChartPlaceHolder {ChartName = "xxx"};
            Assert.AreEqual("xxx", mediator.ChartControl.Titles[0].Text);
        }

        [TestMethod]
        public void EmptyChartTitleTest()
        {
            using (new CultureInfoTransaction(CultureInfo.GetCultureInfo("en-US")))
            {
                var mediator = new ChartPlaceHolder {ChartName = string.Empty};
                Assert.AreEqual("[Untitled]", mediator.ChartControl.Titles[0].Text);
            }
        }

        public static DataTable GenerateChartTestTable()
        {
            var dataTable = new DataTable("testTable");
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

        [TestMethod]
        public void PivotFormatDateTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                object dateQuarter = new DateTime(2009, 5, 10).ToObject(PivotGroupInterval.DateQuarter);
                Assert.AreEqual(2, dateQuarter);
                dateQuarter = new DateTime(2009, 11, 10).ToObject(PivotGroupInterval.DateQuarter);
                Assert.AreEqual(4, dateQuarter);
                dateQuarter = new DateTime(2009, 2, 10).ToObject(PivotGroupInterval.DateQuarter);
                Assert.AreEqual(1, dateQuarter);
                dateQuarter = new DateTime(2009, 8, 10).ToObject(PivotGroupInterval.DateQuarter);
                Assert.AreEqual(3, dateQuarter);

                object dateYear = new DateTime(2009, 5, 10).ToObject(PivotGroupInterval.DateYear);
                Assert.AreEqual(2009, dateYear);

                object dateMonth = new DateTime(2009, 5, 10).ToObject(PivotGroupInterval.DateMonth);
                Assert.AreEqual("May", dateMonth);
                object dateWeekOfYear = new DateTime(2009, 1, 1).ToObject(PivotGroupInterval.DateWeekOfYear);
                Assert.AreEqual(1, dateWeekOfYear);
                dateWeekOfYear = new DateTime(2009, 1, 4).ToObject(PivotGroupInterval.DateWeekOfYear);
                Assert.AreEqual(1, dateWeekOfYear);
                dateWeekOfYear = new DateTime(2009, 1, 5).ToObject(PivotGroupInterval.DateWeekOfYear);
                Assert.AreEqual(2, dateWeekOfYear);
                dateWeekOfYear = new DateTime(2009, 1, 11).ToObject(PivotGroupInterval.DateWeekOfYear);
                Assert.AreEqual(2, dateWeekOfYear);
                dateWeekOfYear = new DateTime(2006, 1, 8).ToObject(PivotGroupInterval.DateWeekOfYear);
                Assert.AreEqual(1, dateWeekOfYear);
                object dateWeekOfMonth = new DateTime(2009, 7, 20).ToObject(PivotGroupInterval.DateWeekOfMonth);
                Assert.AreEqual(4, dateWeekOfMonth);
                dateWeekOfMonth = new DateTime(2009, 7, 19).ToObject(PivotGroupInterval.DateWeekOfMonth);
                Assert.AreEqual(3, dateWeekOfMonth);
                dateWeekOfMonth = new DateTime(2009, 3, 1).ToObject(PivotGroupInterval.DateWeekOfMonth);
                Assert.AreEqual(1, dateWeekOfMonth);
                dateWeekOfMonth = new DateTime(2009, 3, 2).ToObject(PivotGroupInterval.DateWeekOfMonth);
                Assert.AreEqual(1, dateWeekOfMonth);
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

        [TestMethod]
        public void PivotTruncateDateTest()
        {
            var date1 = new DateTime(2014, 02, 10, 2, 3, 4, 5);
            Assert.AreEqual(new DateTime(2014, 1, 1), date1.TruncateToFirstDateInInterval(PivotGroupInterval.DateYear));
            Assert.AreEqual(new DateTime(2014, 1, 1), date1.TruncateToFirstDateInInterval(PivotGroupInterval.DateQuarter));
            Assert.AreEqual(new DateTime(2014, 2, 1), date1.TruncateToFirstDateInInterval(PivotGroupInterval.DateMonth));
            Assert.AreEqual(new DateTime(2014, 2, 10), date1.TruncateToFirstDateInInterval(PivotGroupInterval.Date));
            Assert.AreEqual(new DateTime(2014, 2, 10), date1.TruncateToFirstDateInInterval(PivotGroupInterval.DateDay));
            Assert.AreEqual(new DateTime(2014, 2, 10), date1.TruncateToFirstDateInInterval(PivotGroupInterval.DateDayOfWeek));
            Assert.AreEqual(new DateTime(2014, 2, 10), date1.TruncateToFirstDateInInterval(PivotGroupInterval.DateDayOfYear));

            var date2 = new DateTime(2013, 12, 25, 2, 3, 4, 5);
            Assert.AreEqual(new DateTime(2013, 1, 1), date2.TruncateToFirstDateInInterval(PivotGroupInterval.DateYear));
            Assert.AreEqual(new DateTime(2013, 10, 1), date2.TruncateToFirstDateInInterval(PivotGroupInterval.DateQuarter));
            Assert.AreEqual(new DateTime(2013, 12, 1), date2.TruncateToFirstDateInInterval(PivotGroupInterval.DateMonth));
            Assert.AreEqual(new DateTime(2013, 12, 25), date2.TruncateToFirstDateInInterval(PivotGroupInterval.Date));
            Assert.AreEqual(new DateTime(2013, 12, 25), date2.TruncateToFirstDateInInterval(PivotGroupInterval.DateDay));
            Assert.AreEqual(new DateTime(2013, 12, 25), date2.TruncateToFirstDateInInterval(PivotGroupInterval.DateDayOfWeek));
            Assert.AreEqual(new DateTime(2013, 12, 25), date2.TruncateToFirstDateInInterval(PivotGroupInterval.DateDayOfYear));


            var date3 = new DateTime(2014, 01, 03, 2, 3, 4, 5);
            Assert.AreEqual(new DateTime(2013, 12, 30), date3.TruncateToFirstDateInInterval(PivotGroupInterval.DateWeekOfMonth));
            Assert.AreEqual(new DateTime(2013, 12, 30), date3.TruncateToFirstDateInInterval(PivotGroupInterval.DateWeekOfYear));

            var date4 = new DateTime(2014, 01, 05, 2, 3, 4, 5);
            Assert.AreEqual(new DateTime(2013, 12, 30), date4.TruncateToFirstDateInInterval(PivotGroupInterval.DateWeekOfMonth));
            Assert.AreEqual(new DateTime(2013, 12, 30), date4.TruncateToFirstDateInInterval(PivotGroupInterval.DateWeekOfYear));

            var date5 = new DateTime(2014, 01, 06, 2, 3, 4, 5);
            Assert.AreEqual(new DateTime(2014, 01, 06), date5.TruncateToFirstDateInInterval(PivotGroupInterval.DateWeekOfMonth));
            Assert.AreEqual(new DateTime(2014, 01, 06), date5.TruncateToFirstDateInInterval(PivotGroupInterval.DateWeekOfYear));

        }

        #endregion
    }
}