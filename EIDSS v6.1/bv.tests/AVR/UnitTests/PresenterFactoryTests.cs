using System;
using bv.common.Core;
using bv.common.win;
using bv.tests.AVR.UnitTests.Presenters;
using eidss.avr;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.ChartForm;
using eidss.avr.db.Interfaces;
using eidss.avr.LayoutForm;
using eidss.avr.MapForm;
using eidss.avr.PivotComponents;
using eidss.avr.PivotForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using StructureMap;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class PresenterFactoryTests
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
            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(StructureMapContainerInit(),new BaseForm());
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            m_PresenterTransaction.Dispose();

            MemoryManager.Flush();
        }

        [TestMethod]
        public void CreateMapPresenterTest()
        {
            var mocks = new Mockery();
            var mapView = mocks.NewMock<IMapView>();
            Expect.Once.On(mapView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(mapView).SetProperty("DBService");

            BaseAvrPresenter avrPresenter = PresenterFactory.SharedPresenter[mapView];
            Console.WriteLine(avrPresenter);
            Assert.IsTrue(avrPresenter is MapPresenter);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreateChartPresenterTest()
        {
            var mocks = new Mockery();
            var chartView = mocks.NewMock<IChartView>();
            Expect.Once.On(chartView).EventAdd("SendCommand", Is.Anything);

            Expect.Once.On(chartView).SetProperty("DBService");

            BaseAvrPresenter avrPresenter = PresenterFactory.SharedPresenter[chartView];
            Console.WriteLine(avrPresenter);
            Assert.IsTrue(avrPresenter is ChartPresenter);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreatePivotPresenterTest()
        {
            var mocks = new Mockery();
            IPivotDetailView pivotView = PivotPresenterReportTests.GetPivotView(mocks);
            //Expect.Once.On(pivotView).EventAdd("SendCommand", Is.Anything);
            //  Expect.Once.On(pivotView).SetProperty("DBService");

            BaseAvrPresenter avrPresenter = PresenterFactory.SharedPresenter[pivotView];
            Console.WriteLine(avrPresenter);
            Assert.IsTrue(avrPresenter is PivotDetailPresenter);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreateLayoutDetailPresenterTest()
        {
            var mocks = new Mockery();
            var layoutDetailView = mocks.NewMock<ILayoutDetailView>();
            Expect.Once.On(layoutDetailView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(layoutDetailView).SetProperty("DBService");
         

            BaseAvrPresenter avrPresenter = PresenterFactory.SharedPresenter[layoutDetailView];
            Console.WriteLine(avrPresenter);
            var detailPresenter = avrPresenter as LayoutDetailPresenter;
            Assert.IsNotNull(detailPresenter);
            Assert.IsNotNull(detailPresenter.LayoutDbService);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreateRamPivotGridPresenterTest()
        {
            var mocks = new Mockery();
            var pivotGridView = mocks.NewMock<IAvrPivotGridView>();
            Expect.Once.On(pivotGridView).EventAdd("SendCommand", Is.Anything);

            BaseAvrPresenter avrPresenter = PresenterFactory.SharedPresenter[pivotGridView];
            Console.WriteLine(avrPresenter);
            Assert.IsTrue(avrPresenter is AvrPivotGridPresenter);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void CreateBaseLayoutPresenterTest()
        {
            try
            {
                var mocks = new Mockery();
                var view = mocks.NewMock<IBaseAvrView>();
                Expect.Once.On(view).EventAdd("SendCommand", Is.Anything);

                BaseAvrPresenter avrPresenter = PresenterFactory.SharedPresenter[view];
                Assert.IsNotNull(avrPresenter);
                mocks.VerifyAllExpectationsHaveBeenMet();
            }
            catch (NotSupportedException)
            {
                Console.WriteLine(@"Test ok");
            }
        }
    }
}