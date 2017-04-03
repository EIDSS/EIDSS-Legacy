#region Using

using System;
using bv.common.Core;
using bv.common.win;
using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Views;
using EIDSS.Tests.RAM.Helpers;
using EIDSS.Tests.RAM.Helpers.Fake;
using NUnit.Framework;

#endregion

namespace EIDSS.Tests.RAM.IntegrationTests
{
    [TestFixture]
  
    public class ExportTests
    {
        private ChartPresenter m_ChartPresenter;
        private IPivotReportView m_ReportView;
        private PivotReportPresenter m_ReportPresenter;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            PresenterFactory.Init(new BaseForm());
            
            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
            m_ReportView = new PivotReportForm();
            m_ChartPresenter = new ChartPresenter(PresenterFactory.SharedPresenter,new ChartForm());
            m_ReportPresenter = new PivotReportPresenter(PresenterFactory.SharedPresenter, m_ReportView);
        }

        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        [Test]
        public void ChartExportToTest()
        {
            TestChartExport(m_ChartPresenter, ExportType.Image, "jpg");
            TestChartExport(m_ChartPresenter, ExportType.Html, "html");
            TestChartExport(m_ChartPresenter, ExportType.XLS, "xls");
            TestChartExport(m_ChartPresenter, ExportType.PDF, "pdf");
        }

        [Test]
        public void GridExportToTest()
        {
            TestReportExport(m_ReportPresenter, ExportType.RTF, "rtf");
            TestReportExport(m_ReportPresenter, ExportType.Html, "html");
            TestReportExport(m_ReportPresenter, ExportType.XLS, "xls");
            TestReportExport(m_ReportPresenter, ExportType.PDF, "pdf");
        }

        [Test]
        public void GetExportDelegateTest()
        {
            Assert.IsNotNull(m_ReportView.GetExportDelegate(ExportType.PDF));
            Assert.IsNotNull(m_ReportView.GetExportDelegate(ExportType.XLS));
            Assert.IsNotNull(m_ReportView.GetExportDelegate(ExportType.RTF));
            Assert.IsNotNull(m_ReportView.GetExportDelegate(ExportType.Html));
        }

        [Test]
        public void GetExportDelegateFailTest()
        {
            try
            {
                Assert.IsNotNull(m_ReportView.GetExportDelegate(ExportType.Image));
            }
            catch (RamException ex)
            {
                Assert.AreEqual("Not supported export type: Image", ex.Message);
            }
        }

        [Test]
        public void GridExportCommandTest()
        {
            PivotReportPresenter presenter = DataHelper.GetPresenter<PivotReportPresenter>(m_ReportView);
            ExportCommand command = new ExportCommand(this, ExportObject.Chart, ExportType.PDF);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Unprecessed, command.State);

            TestReportCommandExport(presenter, ExportType.PDF, "pdf");
            TestReportCommandExport(presenter, ExportType.XLS, "xls");
            TestReportCommandExport(presenter, ExportType.RTF, "rtf");
            TestReportCommandExport(presenter, ExportType.Html, "html");
            

        }

        private void TestReportCommandExport(PivotReportPresenter presenter, ExportType exportType, string ext)
        {
            ExportCommand command = new ExportCommand(this, ExportObject.Report, exportType);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Processed, command.State);
            DataHelper.CheckAndDeleteFile(ext);
        }

        private static void TestChartExport(ChartPresenter presenter, ExportType exportType, string ext)
        {
            presenter.ExportChart(exportType);
            DataHelper.CheckAndDeleteFile(ext);
        }

        private static void TestReportExport(PivotReportPresenter presenter, ExportType exportType, string ext)
        {
            presenter.ExportGrid(exportType);
            DataHelper.CheckAndDeleteFile(ext);
        }
    }
}