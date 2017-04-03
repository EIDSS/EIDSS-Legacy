#region Using

using System;
using System.Data;
using bv.common.Core;
using bv.common.win;
using EIDSS.RAM;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.RAM_DB.Views;
using EIDSS.Tests.RAM.Helpers;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

#endregion

namespace EIDSS.Tests.RAM.UnitTests.Presenters
{
    [TestFixture]
    public class InitializingPresentersTests
    {
        private PivotPresenter m_PivotPresenter;
        private MapPresenter m_MapPresenter;
        private ChartPresenter m_ChartPresenter;
        private PivotReportPresenter m_PivotReportPresenter;
        private RamPivotGridPresenter m_PivotGridPresenter;
        private LayoutInfoPresenter m_LayoutInfoPresenter;
        private QueryInfoPresenter m_QueryInfoPresenter;
        private LayoutDetailPresenter m_LayoutDetailPresenter;

        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        [Test]
        public void InitPresentersAdnViewsTest()
        {
            InitPresentersAdnViews();
        }

        [Test]
        public void NotAssignPivotGridTest()
        {
            try
            {
                InitPresentersAdnViews();

                Mockery mocks = new Mockery();

                IPivotView pivotView = PivotPresenterTests.GetPivotView(mocks);

                m_PivotPresenter = DataHelper.GetPresenter<PivotPresenter>(pivotView);
                m_PivotPresenter.GetMapDataTable("xxx");

                mocks.VerifyAllExpectationsHaveBeenMet();
            }
            catch (RamException ex)
            {
                Assert.AreEqual("PivotFields is not initialized.", ex.Message);
            }
        }

        private void InitPresentersAdnViews()
        {
            PresenterFactory.Init(new BaseForm());

            Mockery mocks = new Mockery();

            IChartView chartView = DataHelper.GetView<IChartView>(mocks);
            Expect.Once.On(chartView).EventAdd("ChangeOrientation", Is.Anything);
            m_ChartPresenter = DataHelper.GetPresenter<ChartPresenter>(chartView);
            Assert.IsNotNull(m_ChartPresenter);

            IPivotView pivotView = PivotPresenterTests.GetPivotView(mocks);
            m_PivotPresenter = DataHelper.GetPresenter<PivotPresenter>(pivotView);
            Assert.IsNotNull(m_PivotPresenter);

            IPivotReportView pivotReportView = DataHelper.GetView<IPivotReportView>(mocks);
            m_PivotReportPresenter = DataHelper.GetPresenter<PivotReportPresenter>(pivotReportView);
            Assert.IsNotNull(m_PivotReportPresenter);

            IMapView mapView = DataHelper.GetView<IMapView>(mocks);
            Expect.Once.On(mapView).EventAdd("InitAdmUnit", Is.Anything);
            Expect.Once.On(mapView).EventAdd("RefreshMap", Is.Anything);
            m_MapPresenter = DataHelper.GetPresenter<MapPresenter>(mapView);
            Assert.IsNotNull(m_MapPresenter);

            ILayoutInfoView layoutInfoView = DataHelper.GetView<ILayoutInfoView>(mocks);
            Expect.Once.On(layoutInfoView).EventAdd("LayoutSelecting", Is.Anything);
            Expect.Once.On(layoutInfoView).EventAdd("LayoutSelected", Is.Anything);
            m_LayoutInfoPresenter = DataHelper.GetPresenter<LayoutInfoPresenter>(layoutInfoView);
            Assert.IsNotNull(m_LayoutInfoPresenter);

            IQueryInfoView queryInfoView = DataHelper.GetView<IQueryInfoView>(mocks);
            m_QueryInfoPresenter = DataHelper.GetPresenter<QueryInfoPresenter>(queryInfoView);
            Assert.IsNotNull(m_QueryInfoPresenter);

            ILayoutDetailView layoutDetailView = DataHelper.GetView<ILayoutDetailView>(mocks);
            Expect.Once.On(layoutDetailView).EventAdd("CopyLayoutCreating", Is.Anything);
            m_LayoutDetailPresenter = DataHelper.GetPresenter<LayoutDetailPresenter>(layoutDetailView);
            Assert.IsNotNull(m_LayoutDetailPresenter);

            IRamPivotGridView pivotGridView = mocks.NewMock<IRamPivotGridView>();
            Expect.Once.On(pivotGridView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(pivotGridView).EventAdd("FieldVisibleChanged", Is.Anything);
            //   Expect.Once.On(pivotGridView).GetProperty("Fields");
            m_PivotGridPresenter = PresenterFactory.SharedPresenter[pivotGridView] as RamPivotGridPresenter;
            Assert.IsNotNull(m_PivotGridPresenter);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}