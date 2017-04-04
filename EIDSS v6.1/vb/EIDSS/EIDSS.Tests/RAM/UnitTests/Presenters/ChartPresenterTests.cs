#region Using

using System;
using bv.common.win;
using DevExpress.XtraCharts;
using EIDSS.RAM;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.RAM_DB.Views;
using EIDSS.Tests.RAM.Helpers;
using EIDSS.Tests.RAM.Helpers.Fake;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

#endregion

namespace EIDSS.Tests.RAM.UnitTests.Presenters
{
    [TestFixture]
 
    public class ChartPresenterTests
    {
        [SetUp]
        public void SetUp()
        {
            PresenterFactory.Init(new BaseForm());
            
            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
        }

        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        [Test]
        public void ChartPresenterGetChartTypeTest()
        {
            Assert.AreEqual(ViewType.Line, ChartPresenter.GetChartType(-1));
            Assert.AreEqual(ViewType.Bar, ChartPresenter.GetChartType((long)DBChartType.chrBar));
            Assert.AreEqual(ViewType.Line, ChartPresenter.GetChartType(DBNull.Value));
            Assert.AreEqual(ViewType.Line, ChartPresenter.GetChartType(null));
        }

        [Test]
        public void ChartPresenterExportTest()
        {
            Mockery mocks = new Mockery();
            IChartView chartView = DataHelper.GetView<IChartView>(mocks);
            Expect.Once.On(chartView).EventAdd("ChangeOrientation", Is.Anything);
            ChartPresenter presenter = DataHelper.GetPresenter<ChartPresenter>(chartView);

            ChartControl chartControl = new ChartControl();
            Expect.AtLeastOnce.On(chartView).Method("RaiseSendCommand");
            Expect.AtLeastOnce.On(chartView).GetProperty("ChartControl").Will(Return.Value(chartControl));
            ExportCommand command = new ExportCommand(this, ExportObject.Report, ExportType.PDF);
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
            ExportCommand command = new ExportCommand(this, ExportObject.Chart, exportType);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Processed, command.State);
            DataHelper.CheckAndDeleteFile(ext);
        }
    }
}