using System.Data;
using System.Drawing;
using bv.common.win;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using EIDSS.RAM;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.Views;
using EIDSS.Tests.RAM.Helpers;
using EIDSS.Tests.RAM.Helpers.Fake;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;
namespace EIDSS.Tests.RAM.IntegrationTests
{
    [TestFixture]
    public class PrintTests : BaseTests
    {
        [SetUp]
        public void SetUp()
        {
            PresenterFactory.Init(new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
            
        }

        [Test]
        public void ChartPrintTest()
        {
            Mockery mocks = new Mockery();
            IChartView chartView = DataHelper.GetView<IChartView>(mocks);
            Expect.Once.On(chartView).EventAdd("ChangeOrientation", Is.Anything);
            ChartPresenter presenter = DataHelper.GetPresenter<ChartPresenter>(chartView);

            ChartControl chartControl = new ChartControl();
            PrintingSystem printingSystem = new PrintingSystem();
            Expect.Once.On(chartView).Method("RaiseSendCommand");
            Expect.AtLeastOnce.On(chartView).GetProperty("ChartControl").Will(Return.Value(chartControl));
            Expect.Once.On(chartView).GetProperty("PrintingSystem").Will(Return.Value(printingSystem));
            PrintCommand command = new PrintCommand(this, PrintType.Grid);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Unprecessed, command.State);

            command = new PrintCommand(this, PrintType.Chart);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Processed, command.State);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ReportPrintTest()
        {
            Mockery mocks = new Mockery();
            IPivotReportView reportView = DataHelper.GetView<IPivotReportView>(mocks);
            PivotReportPresenter presenter = DataHelper.GetPresenter<PivotReportPresenter>(reportView);

            PrintingSystem printingSystem = new PrintingSystem();
            Expect.Once.On(reportView).Method("RaiseSendCommand");
            Expect.Once.On(reportView).GetProperty("PrintingSystem").Will(Return.Value(printingSystem));
            PrintCommand command = new PrintCommand(this, PrintType.Chart);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Unprecessed, command.State);

            command = new PrintCommand(this, PrintType.Grid);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Processed, command.State);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void MapPrintTest()
        {
            Mockery mocks = new Mockery();

            IMapView mapView = DataHelper.GetView<IMapView>(mocks);
            Expect.Once.On(mapView).EventAdd("InitAdmUnit", Is.Anything);
            Expect.Once.On(mapView).EventAdd("RefreshMap", Is.Anything);
            MapPresenter presenter = DataHelper.GetPresenter<MapPresenter>(mapView);

            Expect.Once.On(mapView).Method("GetMapImage").Will(Return.Value(new Bitmap(100,100)));
            Expect.Once.On(mapView).Method("UpdateMap");
            //Expect.Once.On(mapView).Method("BindAdmUnitComboBox");
            Expect.AtLeastOnce.On(mapView).GetProperty("AdmUnitValue").Will(Return.Value("RayonID"));
            Expect.AtLeastOnce.On(mapView).GetProperty("PrintingSystem").Will(Return.Value(new PrintingSystem()));
            Expect.AtLeastOnce.On(mapView).GetProperty("MapName").Will(Return.Value("xxx"));
            Expect.AtLeastOnce.On(mapView).GetProperty("FilterText").Will(Return.Value("[yyy]"));
            LayoutDetailDataSet detailDataSet = new LayoutDetailDataSet();
            detailDataSet.Layout.AddLayoutRow(1, "aa", "dd", 2, 3, 4, "", "", false, 5, "", 6, "", 7, 8, false, false,
                                              false, false, false, false, false, false, false, false, 9, new byte[0], 10,
                                              "", 11, 12, 13, 14, 15, 16, 17, 18, "", "", "", false, false);
            Expect.AtLeastOnce.On(mapView).GetProperty("baseDataSet").Will(Return.Value(detailDataSet));
            PrintCommand command = new PrintCommand(this, PrintType.Chart);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Unprecessed, command.State);

            PresenterFactory.SharedPresenter.SharedModel.GetAvailableMapFieldViewCallback =
                delegate { return new DataView(new DataTable("test")); };
            PresenterFactory.SharedPresenter.SharedModel.GetMapDataTableCallback =
                delegate { return new DataTable("test"); };
            PresenterFactory.SharedPresenter.SharedModel.GetDenominatorDataViewCallback =
                delegate { return new DataView(new DataTable("test")); };
            command = new PrintCommand(this, PrintType.Map);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Processed, command.State);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}