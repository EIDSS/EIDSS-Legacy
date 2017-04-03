using System;
using bv.common.Core;
using bv.common.win;
using bv.tests.AVR.UnitTests.Presenters;
using EIDSS.RAM;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.RAM_DB.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class PresenterFactoryTests
    {
        [TestInitialize]
        public void SetUp()
        {
            PresenterFactory.Init(new BaseForm());
        }

        [TestCleanup]
        public void TearDown()
        {
            MemoryManager.Flush();
        }

        [TestMethod]
        public void CreateMapPresenterTest()
        {
            var mocks = new Mockery();
            var mapView = mocks.NewMock<IMapView>();
            Expect.Once.On(mapView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(mapView).SetProperty("DBService");
            Expect.Once.On(mapView).EventAdd("InitAdmUnit", Is.Anything);
            Expect.Once.On(mapView).EventAdd("RefreshMap", Is.Anything);

            BaseRamPresenter ramPresenter = PresenterFactory.SharedPresenter[mapView];
            Console.WriteLine(ramPresenter);
            Assert.IsTrue(ramPresenter is MapPresenter);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreateChartPresenterTest()
        {
            var mocks = new Mockery();
            var chartView = mocks.NewMock<IChartView>();
            Expect.Once.On(chartView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(chartView).EventAdd("ChangeOrientation", Is.Anything);
            Expect.Once.On(chartView).SetProperty("DBService");

            BaseRamPresenter ramPresenter = PresenterFactory.SharedPresenter[chartView];
            Console.WriteLine(ramPresenter);
            Assert.IsTrue(ramPresenter is ChartPresenter);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreatePivotPresenterTest()
        {
            var mocks = new Mockery();
            IPivotView pivotView = PivotPresenterReportTests.GetPivotView(mocks);
            //Expect.Once.On(pivotView).EventAdd("SendCommand", Is.Anything);
            //  Expect.Once.On(pivotView).SetProperty("DBService");

            BaseRamPresenter ramPresenter = PresenterFactory.SharedPresenter[pivotView];
            Console.WriteLine(ramPresenter);
            Assert.IsTrue(ramPresenter is PivotPresenter);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreateLayoutInfoPresenterTest()
        {
            var mocks = new Mockery();
            var layoutInfoView = mocks.NewMock<ILayoutInfoView>();
            Expect.Once.On(layoutInfoView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(layoutInfoView).EventAdd("LayoutSelecting", Is.Anything);
            Expect.Once.On(layoutInfoView).EventAdd("LayoutSelected", Is.Anything);
            Expect.Once.On(layoutInfoView).SetProperty("DBService");

            BaseRamPresenter ramPresenter = PresenterFactory.SharedPresenter[layoutInfoView];
            Console.WriteLine(ramPresenter);
            Assert.IsTrue(ramPresenter is LayoutInfoPresenter);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreateLayoutDetailPresenterTest()
        {
            var mocks = new Mockery();
            var layoutDetailView = mocks.NewMock<ILayoutDetailView>();
            Expect.Once.On(layoutDetailView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(layoutDetailView).SetProperty("DBService");
            Expect.Once.On(layoutDetailView).EventAdd("CopyLayoutCreating", Is.Anything);

            BaseRamPresenter ramPresenter = PresenterFactory.SharedPresenter[layoutDetailView];
            Console.WriteLine(ramPresenter);
            var detailPresenter = ramPresenter as LayoutDetailPresenter;
            Assert.IsNotNull(detailPresenter);
            Assert.IsNotNull(detailPresenter.LayoutDbService);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreateQueryInfoPresenterTest()
        {
            var mocks = new Mockery();
            var queryInfoView = mocks.NewMock<IQueryInfoView>();
            Expect.Once.On(queryInfoView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(queryInfoView).SetProperty("DBService");

            BaseRamPresenter ramPresenter = PresenterFactory.SharedPresenter[queryInfoView];
            Console.WriteLine(ramPresenter);

            var infoPresenter = (ramPresenter as QueryInfoPresenter);
            Assert.IsNotNull(infoPresenter);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreateRamPivotGridPresenterTest()
        {
            var mocks = new Mockery();
            var pivotGridView = mocks.NewMock<IRamPivotGridView>();
            Expect.Once.On(pivotGridView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(pivotGridView).EventAdd("FieldVisibleChanged", Is.Anything);
            //   Expect.Once.On(pivotGridView).GetProperty("Fields");

            BaseRamPresenter ramPresenter = PresenterFactory.SharedPresenter[pivotGridView];
            Console.WriteLine(ramPresenter);
            Assert.IsTrue(ramPresenter is RamPivotGridPresenter);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreatePivotReportPresenterTest()
        {
            var mocks = new Mockery();
            var pivotReportView = mocks.NewMock<IPivotReportView>();
            Expect.Once.On(pivotReportView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(pivotReportView).SetProperty("DBService");

            BaseRamPresenter ramPresenter = PresenterFactory.SharedPresenter[pivotReportView];
            Console.WriteLine(ramPresenter);
            Assert.IsTrue(ramPresenter is PivotReportPresenter);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreateBaseLayoutPresenterTest()
        {
            try
            {
                var mocks = new Mockery();
                var view = mocks.NewMock<IView>();
                Expect.Once.On(view).EventAdd("SendCommand", Is.Anything);

                BaseRamPresenter ramPresenter = PresenterFactory.SharedPresenter[view];
                Assert.IsNotNull(ramPresenter);
                mocks.VerifyAllExpectationsHaveBeenMet();
            }
            catch (NotSupportedException)
            {
                Console.WriteLine(@"Test ok");
            }
        }
    }
}