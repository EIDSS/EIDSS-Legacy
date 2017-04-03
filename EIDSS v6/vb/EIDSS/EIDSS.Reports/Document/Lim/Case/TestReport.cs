using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Lim.Case
{
    public sealed partial class TestReport : BaseDocumentReport
    {
        private readonly FlexTestReportContainer m_SubreportContainer;

        public TestReport()
        {
            InitializeComponent();

            var location = new Point(0, xrTable1.Height + xrTable2.Height + 8);

            m_SubreportContainer = new FlexTestReportContainer(DetailTest, xrTable1.Size, location);
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            string id = GetStringParameter(parameters, "@ObjID");
            bool isHuman = bool.Parse(GetStringParameter(parameters, "@IsHuman"));
            string sampleIdHeader = isHuman
                ? EidssMessages.Get(@"HumanSampleID")
                : EidssMessages.Get(@"lblFieldSampleID");
            xrTableCell4.Text = sampleIdHeader + xrTableCell4.Text;

            sp_rep_LIM_CaseTestsTableAdapter1.Connection = (SqlConnection) manager.Connection;
            sp_rep_LIM_CaseTestsTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            sp_rep_LIM_CaseTestsTableAdapter1.CommandTimeout = CommandTimeout;

            caseTestDataSet1.EnforceConstraints = false;
            sp_rep_LIM_CaseTestsTableAdapter1.Fill(caseTestDataSet1.spRepLimCaseTests, long.Parse(id), lang);

            testValidationReport1.SetParameters(manager, lang, id);

            var observationDeterminants = new Dictionary<long, long>();
            foreach (CaseTestDataSet.spRepLimCaseTestsRow row in caseTestDataSet1.spRepLimCaseTests)
            {
                if (!row.IsidfTestObservationNull() && !row.IsidfsTestTypeNull())
                {
                    if (!observationDeterminants.ContainsKey(row.idfTestObservation))
                    {
                        observationDeterminants.Add(row.idfTestObservation, row.idfsTestType);
                    }
                }
            }

            m_SubreportContainer.SetObservations(observationDeterminants);
        }

        private void xrTableCell4_BeforePrint(object sender, PrintEventArgs e)
        {
            m_SubreportContainer.BeforePrintNextReport();
        }
    }
}