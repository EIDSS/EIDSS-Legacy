using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Core;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.AVR.Helpers.Fake;
using bv.tests.common;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class ExportReportTests : BaseReportTests
    {
        private ChartPresenter m_ChartPresenter;
        private ChartForm m_ChartForm;
        private PivotReportForm m_ReportView;
        private PivotReportPresenter m_ReportPresenter;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            PresenterFactory.Init(new BaseForm());

            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
            m_ReportView = new PivotReportForm();
            m_ChartForm = new ChartForm();
            m_ChartPresenter = new ChartPresenter(PresenterFactory.SharedPresenter, m_ChartForm);
            m_ReportPresenter = new PivotReportPresenter(PresenterFactory.SharedPresenter, m_ReportView);
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();

            m_ChartForm.Dispose();
            m_ReportView.Dispose();
        }

        [TestMethod]
        public void ChartExportToTest()
        {
            TestChartExport(m_ChartPresenter, ExportType.Image, "jpg");
            TestChartExport(m_ChartPresenter, ExportType.Html, "html");
            TestChartExport(m_ChartPresenter, ExportType.XLS, "xls");
            TestChartExport(m_ChartPresenter, ExportType.PDF, "pdf");
        }

        [TestMethod]
        public void GridExportToTest()
        {
            TestReportExport(m_ReportPresenter, ExportType.RTF, "rtf");
            TestReportExport(m_ReportPresenter, ExportType.Html, "html");
            TestReportExport(m_ReportPresenter, ExportType.XLS, "xls");
            TestReportExport(m_ReportPresenter, ExportType.PDF, "pdf");
        }

        [TestMethod]
        public void GetExportDelegateTest()
        {
            Assert.IsNotNull(m_ReportView.GetExportDelegate(ExportType.PDF));
            Assert.IsNotNull(m_ReportView.GetExportDelegate(ExportType.XLS));
            Assert.IsNotNull(m_ReportView.GetExportDelegate(ExportType.RTF));
            Assert.IsNotNull(m_ReportView.GetExportDelegate(ExportType.Html));
        }

        [TestMethod]
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

        [TestMethod]
        public void GridExportCommandTest()
        {
            var presenter = DataHelper.GetPresenter<PivotReportPresenter>(m_ReportView);
            var command = new ExportCommand(this, ExportObject.Chart, ExportType.PDF);
            presenter.Process(command);
            Assert.AreEqual(CommandState.Unprecessed, command.State);

            TestReportCommandExport(presenter, ExportType.PDF, "pdf");
            TestReportCommandExport(presenter, ExportType.XLS, "xls");
            TestReportCommandExport(presenter, ExportType.RTF, "rtf");
            TestReportCommandExport(presenter, ExportType.Html, "html");
        }

        private void TestReportCommandExport(PivotReportPresenter presenter, ExportType exportType, string ext)
        {
            var command = new ExportCommand(this, ExportObject.Report, exportType);
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
