using System;
using System.Data;
using System.Drawing;
using System.IO;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.common;
using bv.tests.Reports;
using eidss.avr;
using eidss.avr.ChartForm;
using eidss.model.Avr.Chart;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.ServiceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class ExportChartToJpgTests : BaseReportTests
    {
        private IDisposable m_PresenterTransaction;
        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(m_Container,new BaseForm());
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            m_PresenterTransaction.Dispose();
            base.TestCleanup();
        }

        [TestMethod]
        public void ChartDirectExportToTest()
        {
            var export = ExportToJpgBytes(-1, 1000, 750);
            Assert.IsNotNull(export);
            Assert.IsNotNull(export.JpgBytes);
            ExportTests.AssertJpeg(export.JpgBytes);
            File.WriteAllBytes("file.jpg", export.JpgBytes);
            DataHelper.CheckAndDeleteFile("jpg");
        }

        public ChartExportDTO ExportToJpgBytes(long viewId, int width, int height)
        {
            using (var chartForm = new ChartDetailForm())
            {
                chartForm.Size = new Size(width, height);
                chartForm.DataSource = CreateChartData();
                object id = viewId;
                chartForm.LoadData(ref id);
                chartForm.ChartControlSize = new Size(width, height);

               ChartExportDTO export = chartForm.ExportToJpgBytes(new byte[0], DBChartType.chrBar);
                return export;
            }
        }

        public static DataTable CreateChartData()
        {
            var result = new DataTable("Data");

            result.Columns.Add("sflHC_PatientCRRegion_51765120000000__CFC29F394CCBFD1B4645DB0CCF753BEA", typeof (string));
            result.Columns[0].Caption = "Human Case - Patient Current Residence - Region";

            result.Columns.Add("sflHC_CaseID_51764660000000__559ED732EC26A38FFE236A7B60D3A666", typeof (int));
            result.Columns[1].Caption = "Human Case - Case ID Total";

            result.Columns.Add("AggregateColumn12:34:27.5350356", typeof (double));
            result.Columns[2].Caption = "Cumulative Percent";

            result.Rows.Add("Abkhazia (GGAB00)", 4, 4);
            result.Rows.Add("Adjara (GGAJ00)", 8, 12);
            result.Rows.Add("Guria (GGGU00)", 7, 19);
            result.Rows.Add("Imereti (GGIM00)", 5, 24);
            result.Rows.Add("Kakheti (GGKA00)", 9, 33);
            result.Rows.Add("Kvemo-Kartli (GGKK00)", 7, 40);
            result.Rows.Add("Mtskheta-Mtianeti (GGMM00)", 6, 46);
            result.Rows.Add("Other (GGOT00)", 7, 53);
            result.Rows.Add("Racha-Lechkhumi (GGRK00)", 7, 60);
            result.Rows.Add("Samegrelo-Zemo Svaneti (GGSZ00)", 8, 68);
            result.Rows.Add("Samtskhe-Javakheti (GGSJ00)", 10, 78);
            result.Rows.Add("Shida Kartli (GGSD00)", 13, 91);
            result.Rows.Add("Tbilisi (GGTB00)", 9, 100);

            return result;
        }
    }
}