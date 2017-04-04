using eidss.avr.BaseComponents.Views;
using eidss.avr.db.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using bv.common.Core;
using bv.common.win;
using bv.tests.AVR.Helpers;
using eidss.avr;
using eidss.avr.ChartForm;

using eidss.avr.LayoutForm;
using eidss.avr.MapForm;
using eidss.avr.PivotComponents;
using eidss.avr.PivotForm;
using eidss.avr.ViewForm;
using StructureMap;

namespace bv.tests.AVR.UnitTests.Presenters
{
    [TestClass]
    public class InitializingPresentersTests
    {
        private PivotDetailPresenter m_PivotDetailPresenter;
        private MapPresenter m_MapPresenter;
        private ChartPresenter m_ChartPresenter;

        private AvrPivotGridPresenter m_PivotGridPresenter;
        
        
        private LayoutDetailPresenter m_LayoutDetailPresenter;
        private PivotInfoPresenter m_PivotInfoPresenter;
        private ViewDetailPresenter m_ViewDetailPresenter;

        [TestCleanup]
        public void TearDown()
        {
            MemoryManager.Flush();
        }

        [TestMethod]
        public void InitPresentersAndViewsTest()
        {
            InitPresentersAndViews();
        }

        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { });
            return c;
        }
        private void InitPresentersAndViews()
        {

            using (PresenterFactory.BeginSharedPresenterTransaction(StructureMapContainerInit(),new BaseForm()))
            {


                var mocks = new Mockery();

                var chartView = DataHelper.GetView<IChartView>(mocks);

                m_ChartPresenter = DataHelper.GetPresenter<ChartPresenter>(chartView);
                Assert.IsNotNull(m_ChartPresenter);

                IPivotDetailView pivotView = PivotPresenterReportTests.GetPivotView(mocks);
                m_PivotDetailPresenter = DataHelper.GetPresenter<PivotDetailPresenter>(pivotView);
                Assert.IsNotNull(m_PivotDetailPresenter);

                var mapView = DataHelper.GetView<IMapView>(mocks);
                m_MapPresenter = DataHelper.GetPresenter<MapPresenter>(mapView);
                Assert.IsNotNull(m_MapPresenter);

                var layoutInfoView = DataHelper.GetView<IPivotInfoDetailView>(mocks);
                m_PivotInfoPresenter = DataHelper.GetPresenter<PivotInfoPresenter>(layoutInfoView);
                Assert.IsNotNull(m_PivotInfoPresenter);

                var viewDetailView = DataHelper.GetView<IViewDetailView>(mocks);
                m_ViewDetailPresenter = DataHelper.GetPresenter<ViewDetailPresenter>(viewDetailView);
                Assert.IsNotNull(m_ViewDetailPresenter);



                var layoutDetailView = DataHelper.GetView<ILayoutDetailView>(mocks);
             
                m_LayoutDetailPresenter = DataHelper.GetPresenter<LayoutDetailPresenter>(layoutDetailView);
                Assert.IsNotNull(m_LayoutDetailPresenter);

                var pivotGridView = mocks.NewMock<IAvrPivotGridView>();
                Expect.Once.On(pivotGridView).EventAdd("SendCommand", Is.Anything);
                m_PivotGridPresenter = PresenterFactory.SharedPresenter[pivotGridView] as AvrPivotGridPresenter;
                Assert.IsNotNull(m_PivotGridPresenter);


                mocks.VerifyAllExpectationsHaveBeenMet();
            }
        }
    }
}