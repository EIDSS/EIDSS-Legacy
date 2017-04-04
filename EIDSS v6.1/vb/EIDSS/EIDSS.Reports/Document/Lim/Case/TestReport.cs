using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Lim.Case
{
    [NullableAdapters]
    public sealed partial class TestReport : BaseDocumentReport
    {
        private readonly FlexTestReportContainer m_TestSubreportContainer;
        private readonly TestHistoryReportContainer m_HistorySubreportContainer;

        public TestReport()
        {
            InitializeComponent();

            const int deltaHeight = 8;
            var flexLocation = new Point(0, DetailTable.Top + DetailTable.Height + deltaHeight);
            var historyLocation = new Point(0, flexLocation.Y + DetailTable.Height + deltaHeight);

            m_TestSubreportContainer = new FlexTestReportContainer(DetailTest, DetailTable.Size, flexLocation);
            m_HistorySubreportContainer = new TestHistoryReportContainer(DetailTest, DetailTable.Size, historyLocation);
        }

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            long id = GetLongParameter(parameters, "@ObjID");
            bool isHuman = bool.Parse(GetStringParameter(parameters, "@IsHuman"));
            VetHeaderTable.Top = HumanHeaderTable.Top;
            xrLabel3.Top = HumanHeaderTable.Bottom;
            ReportHeaderTest.Height = HumanHeaderTable.Height;

            HumanHeaderTable.Visible = isHuman;
            VetHeaderTable.Visible = !isHuman;

            string sampleIdHeader = isHuman
                ? EidssMessages.Get(@"HumanSampleID")
                : EidssMessages.Get(@"lblFieldSampleID");
            xrTableCell4.Text = sampleIdHeader + xrTableCell4.Text;

            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
            m_Adapter.CommandTimeout = CommandTimeout;

            m_DataSet.EnforceConstraints = false;
            m_Adapter.Fill(m_DataSet.CaseTests, id, lang);

            ((TestValidationReport)xrSubreport1.ReportSource).SetParameters( lang, id, manager, archiveManager);

            var observationDeterminants = new List<KeyValuePair<long, long>>();
            var tests = new List<long>();
            foreach (CaseTestDataSet.CaseTestsRow row in m_DataSet.CaseTests)
            {
                KeyValuePair<long, long> observation = row.IsidfTestObservationNull() || row.IsidfsTestNameNull()
                    ? new KeyValuePair<long, long>()
                    : new KeyValuePair<long, long>(row.idfTestObservation, row.idfsTestName);

                observationDeterminants.Add(observation);
                tests.Add(row.idfTest);
            }

            FillBarcode();

            m_TestSubreportContainer.SetObservations(observationDeterminants);
            m_HistorySubreportContainer.SetIdList( lang, tests, manager, archiveManager);

            ReportRtlHelper.SetRTL(this);
            ReportRebinder.RebindDateAndFontForReport();
        }

        private void FillBarcode()
        {
            if (m_DataSet.CaseTests.Count > 0)
            {
                CaseTestDataSet.CaseTestsRow row = m_DataSet.CaseTests[0];

                HumanBarcodeCell.Text = row.IsstrHumCaseIdNull()
                    ? string.Empty
                    : m_BarCode.Code128(row.strHumCaseId);
                VetBarcodeCell.Text = row.IsstrVetCaseIdNull()
                    ? string.Empty
                    : m_BarCode.Code128(row.strVetCaseId);
            }
        }

        private void xrTableCell4_BeforePrint(object sender, PrintEventArgs e)
        {
            if (m_DataSet.CaseTests.Count > m_TestSubreportContainer.Index)
            {
                CaseTestDataSet.CaseTestsRow row = m_DataSet.CaseTests[m_TestSubreportContainer.Index];
                ExternalOrganizationTable.Visible = !row.IsstrExternalDataTestResultReceivedNull() ||
                                                    !row.IsstrExternalEmployeeNull() ||
                                                    !row.IsstrExternalLaboratoryNull();

                if (ExternalOrganizationTable.Visible)
                {
                    m_TestSubreportContainer.HideNextReport();
                }
                else
                {
                    m_TestSubreportContainer.BeforePrintNextReport();
                }
            }
            m_HistorySubreportContainer.BeforePrintNextReport();
        }
    }
}