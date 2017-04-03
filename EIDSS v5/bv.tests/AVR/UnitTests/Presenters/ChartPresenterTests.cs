using System;
using bv.common.Core;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.AVR.Helpers.Fake;
using DevExpress.XtraCharts;
using EIDSS.RAM;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.RAM_DB.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;

namespace bv.tests.AVR.UnitTests.Presenters
{
    [TestClass]
    public class ChartPresenterTests
    {
        [TestInitialize]
        public void SetUp()
        {
            PresenterFactory.Init(new BaseForm());

            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
        }

        [TestCleanup]
        public void TearDown()
        {
            MemoryManager.Flush();
        }

        [TestMethod]
        public void ChartPresenterGetChartTypeTest()
        {
            Assert.AreEqual(ViewType.Line, ChartPresenter.GetChartType(-1));
            Assert.AreEqual(ViewType.Bar, ChartPresenter.GetChartType((long) DBChartType.chrBar));
            Assert.AreEqual(ViewType.Line, ChartPresenter.GetChartType(DBNull.Value));
            Assert.AreEqual(ViewType.Line, ChartPresenter.GetChartType(null));
        }

        [TestMethod]
        public void ChartPresenterExportTest()
        {
            var mocks = new Mockery();
            var chartView = DataHelper.GetView<IChartView>(mocks);
            Expect.Once.On(chartView).EventAdd("ChangeOrientation", Is.Anything);
            var presenter = DataHelper.GetPresenter<ChartPresenter>(chartView);

            var chartControl = new ChartControl();
            Expect.AtLeastOnce.On(chartView).Method("RaiseSendCommand");
            Expect.AtLeastOnce.On(chartView).GetProperty("ChartControl").Will(Return.Value(chartControl));
            var command = new ExportCommand(this, ExportObject.Report, ExportType.PDF);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Unprecessed, command.State);

            CheckExportChart(presenter, ExportType.PDF, "pdf");
            CheckExportChart(presenter, ExportType.XLS, "xls");
            CheckExportChart(presenter, ExportType.Image, "jpg");
            CheckExportChart(presenter, ExportType.Html, "html");

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void CheckExportChart(ChartPresenter presenter, ExportType exportType, string ext)
        {
            var command = new ExportCommand(this, ExportObject.Chart, exportType);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Processed, command.State);
            DataHelper.CheckAndDeleteFile(ext);
        }
    }
}