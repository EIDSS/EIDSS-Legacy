using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.ActiveSurveillance
{
    public sealed partial class SessionReport : BaseDocumentReport
    {
        public SessionReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            long id = GetLongParameter(parameters, "@ObjID");

            m_SessionAdapter.Connection = (SqlConnection) manager.Connection;
            m_SessionAdapter.Transaction = (SqlTransaction) manager.Transaction;
            m_SessionAdapter.CommandTimeout = CommandTimeout;

            m_SessionReportDataSet.EnforceConstraints = false;
            m_SessionAdapter.Fill(m_SessionReportDataSet.Session, id, lang);

            var subreport = new SessionFarmReport();
            m_FarmSubreport.ReportSource = subreport;
            subreport.SetParameters(manager, lang, id);
        }
    }
}