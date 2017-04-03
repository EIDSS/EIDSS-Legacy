using System;
using System.Data;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.RAM_DB.Views;
using Ionic.Zlib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using bv.common.Core;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.AVR.Helpers.Fake;
using bv.tests.common;

namespace bv.tests.AVR.UnitTests.Presenters
{
    [TestClass]
    public class PivotPresenterReportTests : BaseReportTests
    {
        private static readonly string[] m_Regions = new[]
                                                         {
                                                             "Adjara (GGAJ00)", "Guria (GGGU00)", "Kakheti (GGKA00)",
                                                             "Shida Kartli (GGSD00)", "Tbilisi (GGTB00)"
                                                         };

        private static readonly long[] m_RegionsId = new[]
                                                         {
                                                             37030000000, 37040000000, 37060000000, 37100000000,
                                                             37130000000
                                                         };

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            PresenterFactory.Init(new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
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
            Assert.AreEqual(PivotGroupInterval.Date, PivotPresenter.GetGroupInterval(-1));
            Assert.AreEqual(PivotGroupInterval.DateMonth,
                            PivotPresenter.GetGroupInterval((long)DBGroupInterval.gitDateMonth));
            Assert.AreEqual(PivotGroupInterval.Date, PivotPresenter.GetGroupInterval(DBNull.Value));
            Assert.AreEqual(PivotGroupInterval.Date, PivotPresenter.GetGroupInterval(null));
        }

        [TestMethod]
        public void PivotPresenterLayoutXmlTest()
        {
            var mocks = new Mockery();
            DataSet dataSet = GetPivotDataSet();
            PivotPresenter pivotPresenter = GetAndCheckPivotPresenter(mocks, dataSet);

            Assert.AreEqual("xxx", pivotPresenter.LayoutXml);
            pivotPresenter.LayoutXml = "yyy";
            Assert.AreEqual("yyy", pivotPresenter.LayoutXml);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void PivotPresenterNullDatasetTest()
        {
            try
            {
                var mocks = new Mockery();
                PivotPresenter pivotPresenter = GetAndCheckPivotPresenter(mocks, null);

                pivotPresenter.LayoutXml = "yyy";

                mocks.VerifyAllExpectationsHaveBeenMet();
            }
            catch (RamException ex)
            {
                Assert.AreEqual("Dataset of view pivotView is not initialized", ex.Message);
            }
        }

        private static DataSet GetPivotDataSet()
        {
            var dataSet = new LayoutDetailDataSet { EnforceConstraints = false };
            LayoutDetailDataSet.LayoutRow row = dataSet.Layout.NewLayoutRow();

            row.idflLayout = 1;
            row.idflQuery = 1;
            row.idfUserID = 1;

            row.strBasicXml = "xxx";
            row.blbZippedBasicXml = BaseRamDbService.CompressString(row.strBasicXml);
            row.strLayoutName = Guid.NewGuid().ToString();
            row.strDefaultLayoutName = Guid.NewGuid().ToString();
            dataSet.Layout.AddLayoutRow(row);
            dataSet.AcceptChanges();
            return dataSet;
        }

        private static PivotPresenter GetAndCheckPivotPresenter(Mockery mocks, DataSet dataSet)
        {
            IPivotView pivotView;

            return GetAndCheckPivotPresenter(mocks, dataSet, out pivotView);
        }

        internal static PivotPresenter GetAndCheckPivotPresenter
            (Mockery mocks, DataSet dataSet,
             out IPivotView pivotView)
        {
            pivotView = GetPivotView(mocks);

            Expect.AtLeastOnce.On(pivotView).GetProperty("baseDataSet").Will(Return.Value(dataSet));

            var pivotPresenter = DataHelper.GetPresenter<PivotPresenter>(pivotView);
            Assert.IsNotNull(pivotPresenter);
            return pivotPresenter;
        }

        internal static IPivotView GetPivotView(Mockery mocks)
        {
            var pivotView = DataHelper.GetView<IPivotView>(mocks);
            Expect.Once.On(pivotView).EventAdd("PivotSelected", Is.Anything);
            Expect.Once.On(pivotView).EventAdd("PivotDataLoaded", Is.Anything);
            Expect.Once.On(pivotView).EventAdd("InitAdmUnit", Is.Anything);
            Expect.Once.On(pivotView).EventAdd("InitDenominator", Is.Anything);
            Expect.Once.On(pivotView).EventAdd("InitStatDate", Is.Anything);

            return pivotView;
        }

        private static void ConvertToIntAssert(object expected, object actual)
        {
            int value = PivotPresenter.ConvertValueToInt(actual);
            Assert.AreEqual(expected, value);
        }
    }
}
