using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Lim.TestResult
{
    [NullableAdapters]
    public sealed partial class TestResultReport : BaseDocumentReport
    {
        public TestResultReport()
        {
            InitializeComponent();
        }

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            long id = (GetLongParameter(parameters, "@ObjID"));
            long csId = (GetLongParameter(parameters, "@CSObjID"));
            long typeId = (GetLongParameter(parameters, "@TypeID"));
            // Note: workaround to fix _bug 568
            cellBaseSite.DataBindings.Clear();
            if (m_BaseDataSet.sprepGetBaseParameters.Count > 0)
            {
                cellBaseSite.Text = m_BaseDataSet.sprepGetBaseParameters[0][m_BaseDataSet.sprepGetBaseParameters.SiteNameColumn].ToString();
                cellBaseCountry.DataBindings.Clear();
                cellBaseCountry.Text =
                    m_BaseDataSet.sprepGetBaseParameters[0][m_BaseDataSet.sprepGetBaseParameters.CountryNameColumn].ToString();
                cellLanguage.DataBindings.Clear();
                cellLanguage.Text =
                    m_BaseDataSet.sprepGetBaseParameters[0][m_BaseDataSet.sprepGetBaseParameters.LanguageNameColumn].ToString();
            }

            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
            m_Adapter.CommandTimeout = CommandTimeout;
            m_DataSet.EnforceConstraints = false;
            m_Adapter.Fill(m_DataSet.TestResult, lang, id);

            FillBarcode();

            FlexFactory.CreateLimTestReport(TestResultSubreport, csId, typeId);

            ((TestResultAmendmentHistoryReport)AmendmentHistorySubreport.ReportSource).SetParameters( lang, id, manager, archiveManager);

            ReportRtlHelper.SetRTL(this);
            ReportRebinder.RebindDateAndFontForReport();
        }

        private void FillBarcode()
        {
            if (m_DataSet.TestResult.Count > 0)
            {
                TestResultDataSet.TestResultRow row = m_DataSet.TestResult[0];

                BatchBarcodeCell.Text = row.IsstrBatchBarcodeNull()
                    ? string.Empty
                    : m_BarCode.Code128(row.strBatchBarcode);
                SampleBarcodeCell.Text = row.IsstrSampleIDNull()
                    ? string.Empty
                    : m_BarCode.Code128(row.strSampleID);
            }
        }

        private void BatchBarcodeCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (BatchBarcodeCell.Text == "**")
            {
                BatchBarcodeCell.Text = string.Empty;
            }
        }
    }
}