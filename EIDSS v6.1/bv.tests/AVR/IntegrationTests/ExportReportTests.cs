using System;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.AVR.Helpers.Fake;
using bv.tests.common;
using eidss.avr;
using eidss.avr.ChartForm;
using eidss.model.Avr.Commands.Export;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class ExportReportTests : BaseReportTests
    {
        private ChartPresenter m_ChartPresenter;
        private ChartDetailPanel m_ChartForm;
        private IDisposable m_PresenterTransaction;

       
        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();

            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(m_Container,new BaseForm());

            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();

            m_ChartForm = new ChartDetailPanel();
            m_ChartPresenter = new ChartPresenter(PresenterFactory.SharedPresenter, m_ChartForm);
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            m_ChartForm.Dispose();
            m_PresenterTransaction.Dispose();
            base.TestCleanup();
        }

        [TestMethod]
        public void ChartExportToTest()
        {
            TestChartExport(m_ChartPresenter, ExportType.Image, "jpg");
            TestChartExport(m_ChartPresenter, ExportType.Html, "html");
            TestChartExport(m_ChartPresenter, ExportType.Xls, "xls");
            TestChartExport(m_ChartPresenter, ExportType.Pdf, "pdf");
        }

        private static void TestChartExport(ChartPresenter presenter, ExportType exportType, string ext)
        {
            presenter.ExportChart(exportType);
            DataHelper.CheckAndDeleteFile(ext);
        }
    }
}