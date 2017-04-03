using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

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

            FlexFactory.CreateLimTestReport(TestResultSubreport, csId, typeId);

            ((TestResultAmendmentHistoryReport) AmendmentHistorySubreport.ReportSource).SetParameters(manager, lang, id);

            DataAdapter = null;

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