using System.Data;
using System.Drawing;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.AVR.Helpers.Fake;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using EIDSS.RAM;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using bv.tests.common;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class PrintReportTests:BaseReportTests 
    {
       

      
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
        public void ChartPrintTest()
        {
            var mocks = new Mockery();
            var chartView = DataHelper.GetView<IChartView>(mocks);
            Expect.Once.On(chartView).EventAdd("ChangeOrientation", Is.Anything);
            var presenter = DataHelper.GetPresenter<ChartPresenter>(chartView);

            var chartControl = new ChartControl();
            var printingSystem = new PrintingSystem();
            Expect.Once.On(chartView).Method("RaiseSendCommand");
            Expect.AtLeastOnce.On(chartView).GetProperty("ChartControl").Will(Return.Value(chartControl));
            Expect.Once.On(chartView).GetProperty("PrintingSystem").Will(Return.Value(printingSystem));
            var command = new PrintCommand(this, PrintType.Grid);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Unprecessed, command.State);

            command = new PrintCommand(this, PrintType.Chart);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Processed, command.State);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void ReportPrintTest()
        {
            var mocks = new Mockery();
            var reportView = DataHelper.GetView<IPivotReportView>(mocks);
            var presenter = DataHelper.GetPresenter<PivotReportPresenter>(reportView);

            var printingSystem = new PrintingSystem();
            Expect.Once.On(reportView).Method("RaiseSendCommand");
            Expect.Once.On(reportView).GetProperty("PrintingSystem").Will(Return.Value(printingSystem));
            var command = new PrintCommand(this, PrintType.Chart);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Unprecessed, command.State);

            command = new PrintCommand(this, PrintType.Grid);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Processed, command.State);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void MapPrintTest()
        {
            var mocks = new Mockery();

            var mapView = DataHelper.GetView<IMapView>(mocks);
            Expect.Once.On(mapView).EventAdd("InitAdmUnit", Is.Anything);
            Expect.Once.On(mapView).EventAdd("RefreshMap", Is.Anything);
            var presenter = DataHelper.GetPresenter<MapPresenter>(mapView);

            Expect.Once.On(mapView).Method("GetMapImage").Will(Return.Value(new Bitmap(100, 100)));
            Expect.Once.On(mapView).Method("UpdateMap");
            //Expect.Once.On(mapView).Method("BindAdmUnitComboBox");
            Expect.AtLeastOnce.On(mapView).GetProperty("AdmUnitValue").Will(Return.Value("RayonID"));
            Expect.AtLeastOnce.On(mapView).GetProperty("PrintingSystem").Will(Return.Value(new PrintingSystem()));
            Expect.AtLeastOnce.On(mapView).GetProperty("MapName").Will(Return.Value("xxx"));
            Expect.AtLeastOnce.On(mapView).GetProperty("FilterText").Will(Return.Value("[yyy]"));
            var detailDataSet = new LayoutDetailDataSet();
            
            detailDataSet.Layout.AddLayoutRow(1, "aa", "dd", 2, "xx", 3, "descr", 4, 5, 6, "basicxml", new byte[0],
                false, 5, "mapname", 6, "chartname", 7, "gi", 8, "charttype", true, true, true,true,true,true,true,true,true,true, null, new byte[0], null, new byte[0], 1);
            Expect.AtLeastOnce.On(mapView).GetProperty("baseDataSet").Will(Return.Value(detailDataSet));
            var command = new PrintCommand(this, PrintType.Chart);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Unprecessed, command.State);

            PresenterFactory.SharedPresenter.SharedModel.GetAvailableMapFieldViewCallback =
                delegate { return new DataView(new DataTable("test")); };
         //   bool isSingle;
            PresenterFactory.SharedPresenter.SharedModel.GetMapDataTableCallback = GetTestMapDataTableHandler;
//                delegate  { return new DataTable("test"); };
            PresenterFactory.SharedPresenter.SharedModel.GetDenominatorDataViewCallback =
                delegate { return new DataView(new DataTable("test")); };
            command = new PrintCommand(this, PrintType.Map);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Processed, command.State);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        public DataTable GetTestMapDataTableHandler(string fieldName, out  bool isSingle)
        {
            isSingle = true;
            return new DataTable("test"); 
        }
    }
}
