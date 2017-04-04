using System;
using System.Data;
using bv.common.Core;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.AVR.Helpers.Fake;
using bv.tests.common;
using DevExpress.XtraPivotGrid;
using eidss.avr;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.Common;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.PivotForm;
using eidss.model.Avr.Chart;
using eidss.model.Avr.Pivot;
using eidss.model.WindowsService.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;

namespace bv.tests.AVR.UnitTests.Presenters
{
    [TestClass]
    public class PivotPresenterReportTests : BaseReportTests
    {
        private IDisposable m_PresenterTransaction;
        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(m_Container, new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            m_PresenterTransaction.Dispose();
            base.TestCleanup();
        }

       

        [TestMethod]
        public void PivotPresenterConvertValueToIntTest()
        {
            ConvertToIntAssert(0, null);
            ConvertToIntAssert(0, 0.1f);
            ConvertToIntAssert(1, 0.51f);
            ConvertToIntAssert(1, 0.51m);
            ConvertToIntAssert(1, 0.51d);
            ConvertToIntAssert(0, 0.49m);
            ConvertToIntAssert(10001, 10000.59m);
            ConvertToIntAssert(10000, 10000L);
            ConvertToIntAssert(10000, 10000);
        }

        [TestMethod]
        public void PivotPresenterGetGroupIntervalTypeTest()
        {
            Assert.AreEqual(PivotGroupInterval.DateYear, GroupIntervalHelper.GetGroupInterval(-1));
            Assert.AreEqual(PivotGroupInterval.DateMonth,
                GroupIntervalHelper.GetGroupInterval((long) DBGroupInterval.gitDateMonth));
            Assert.AreEqual(PivotGroupInterval.DateDayOfWeek,
                GroupIntervalHelper.GetGroupInterval((long) DBGroupInterval.gitDateDayOfWeek));
            Assert.AreEqual(PivotGroupInterval.DateYear, GroupIntervalHelper.GetGroupInterval(DBNull.Value));
            Assert.AreEqual(PivotGroupInterval.DateYear, GroupIntervalHelper.GetGroupInterval(null));
        }

        [TestMethod]
        public void PivotPresenterConvertGroupIntervalTypeTest()
        {
            Assert.AreEqual(DBGroupInterval.gitDateMonth, GroupIntervalHelper.GetDBGroupInterval(PivotGroupInterval.DateMonth));
            Assert.AreEqual(DBGroupInterval.gitDate, GroupIntervalHelper.GetDBGroupInterval(PivotGroupInterval.Date));
            Assert.AreEqual(DBGroupInterval.gitDateYear, GroupIntervalHelper.GetDBGroupInterval(PivotGroupInterval.DateYear));
            Assert.AreEqual(DBGroupInterval.gitDateDayOfWeek, GroupIntervalHelper.GetDBGroupInterval(PivotGroupInterval.DateDayOfWeek));
        }

        [TestMethod]
        public void PivotPresenterLayoutXmlTest()
        {
            var mocks = new Mockery();
            DataSet dataSet = GetPivotDataSet();
            PivotDetailPresenter pivotDetailPresenter = GetAndCheckPivotPresenter(mocks, dataSet);

            Assert.AreEqual("xxx", pivotDetailPresenter.SettingsXml);
            pivotDetailPresenter.SettingsXml = "yyy";
            Assert.AreEqual("yyy", pivotDetailPresenter.SettingsXml);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void PivotPresenterNullDatasetTest()
        {
            try
            {
                var mocks = new Mockery();
                PivotDetailPresenter pivotDetailPresenter = GetAndCheckPivotPresenter(mocks, null);

                pivotDetailPresenter.SettingsXml = "yyy";

                mocks.VerifyAllExpectationsHaveBeenMet();
            }
            catch (AvrException ex)
            {
                Assert.AreEqual("Dataset of view pivotDetailView is not initialized", ex.Message);
            }
        }

        private static DataSet GetPivotDataSet()
        {
            var dataSet = new LayoutDetailDataSet {EnforceConstraints = false};
            LayoutDetailDataSet.LayoutRow row = dataSet.Layout.NewLayoutRow();

            row.idflLayout = 1;
            row.idflQuery = 1;
            row.idfPerson = 1;

            row.strPivotGridSettings = "xxx";
            row.blbPivotGridSettings = BinaryCompressor.ZipString(row.strPivotGridSettings);
            row.strLayoutName = Guid.NewGuid().ToString();
            row.strDefaultLayoutName = Guid.NewGuid().ToString();
            dataSet.Layout.AddLayoutRow(row);
            dataSet.AcceptChanges();
            return dataSet;
        }

        private static PivotDetailPresenter GetAndCheckPivotPresenter(Mockery mocks, DataSet dataSet)
        {
            IPivotDetailView pivotView;

            return GetAndCheckPivotPresenter(mocks, dataSet, out pivotView);
        }

        internal static PivotDetailPresenter GetAndCheckPivotPresenter
            (Mockery mocks, DataSet dataSet,out IPivotDetailView pivotView)
        {
            pivotView = GetPivotView(mocks);

            Expect.AtLeastOnce.On(pivotView).GetProperty("baseDataSet").Will(Return.Value(dataSet));

            var pivotPresenter = DataHelper.GetPresenter<PivotDetailPresenter>(pivotView);
            Assert.IsNotNull(pivotPresenter);
            return pivotPresenter;
        }

        internal static IPivotDetailView GetPivotView(Mockery mocks)
        {
            var pivotView = DataHelper.GetView<IPivotDetailView>(mocks);
            return pivotView;
        }

        private static void ConvertToIntAssert(object expected, object actual)
        {
            int value = ValueConverter.ConvertValueToInt(actual);
            Assert.AreEqual(expected, value);
        }
    }
}