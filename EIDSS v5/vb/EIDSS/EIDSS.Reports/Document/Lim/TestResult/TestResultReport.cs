using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;
using bv.model.BLToolkit;

namespace EIDSS.Reports.Document.Lim.TestResult
{
    public sealed partial class TestResultReport : BaseDocumentReport
    {
        public TestResultReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            long id = (GetLongParameter(parameters, "@ObjID"));
            long csId = (GetLongParameter(parameters, "@CSObjID"));
            long typeId = (GetLongParameter(parameters, "@TypeID"));
            // Note: workaround to fix _bug 568
            cellBaseSite.DataBindings.Clear();
            if (baseDataSet1.sprepGetBaseParameters.Count > 0)
            {
                cellBaseSite.Text =baseDataSet1.sprepGetBaseParameters[0][baseDataSet1.sprepGetBaseParameters.SiteNameColumn].ToString();
                cellBaseCountry.DataBindings.Clear();
                cellBaseCountry.Text =baseDataSet1.sprepGetBaseParameters[0][baseDataSet1.sprepGetBaseParameters.CountryNameColumn].ToString();
                cellLanguage.DataBindings.Clear();
                cellLanguage.Text =baseDataSet1.sprepGetBaseParameters[0][baseDataSet1.sprepGetBaseParameters.LanguageNameColumn].ToString();
            }

            sp_rep_LIM_TestResultsTableAdapter1.Connection = (SqlConnection) manager.Connection;
            sp_rep_LIM_TestResultsTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            sp_rep_LIM_TestResultsTableAdapter1.CommandTimeout = CommandTimeout;
            testResultDataSet1.EnforceConstraints = false;
            sp_rep_LIM_TestResultsTableAdapter1.Fill(testResultDataSet1.spRepLimTestResults, lang, id);

            FlexFactory.CreateLimTestReport(TestResultSubreport, csId, typeId);
        }

        private void cellPatientName_BeforePrint(object sender, PrintEventArgs e)
        {
            cellPatientName.Text = (lblCaseType.Text == @"10012001" /*"cstRoutineHumanCaseReport"*/)
                                       ? lblPatientName.Text
                                       : lblAnimalName.Text;
        }

        private void cellPatientValue_BeforePrint(object sender, PrintEventArgs e)
        {
            cellPatientValue.Text = (lblCaseType.Text == @"10012001" /*"cstRoutineHumanCaseReport"*/)
                                        ? lblPatientValue.Text
                                        : lblAnimalValue.Text;
        }

        private void xrTableCell39_BeforePrint(object sender, PrintEventArgs e)
        {
            if (string.IsNullOrEmpty(lblCaseType.Text))
            {
                xrTableCell39.Text = lblSessionId.Text;
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