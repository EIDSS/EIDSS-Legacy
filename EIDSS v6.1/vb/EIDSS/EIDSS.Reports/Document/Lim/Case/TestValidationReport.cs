using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Lim.Case
{
    [NullableAdapters]
    public sealed partial class TestValidationReport : XtraReport
    {
        private const string RuleInID = "10104001";

        public TestValidationReport()
        {
            InitializeComponent();
        }

        public void SetParameters(string lang, long id, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            sp_rep_LIM_CaseTestsValidationTableAdapter1.Connection = (SqlConnection) manager.Connection;
            sp_rep_LIM_CaseTestsValidationTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            sp_rep_LIM_CaseTestsValidationTableAdapter1.CommandTimeout = BaseReport.CommandTimeout;
            testValidationDataSet1.EnforceConstraints = false;

            sp_rep_LIM_CaseTestsValidationTableAdapter1.Fill(testValidationDataSet1.spRepLimCaseTestsValidation, id, lang);

            Detail.Visible = (testValidationDataSet1.spRepLimCaseTestsValidation.Rows.Count > 0);
        }

        private void cellRule_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = (sender as XRTableCell);
            if (cell != null)
            {
                cell.Text = (cell.Text == RuleInID) ? lblRuleIn.Text : lblRuleOut.Text;
            }
        }
    }
}