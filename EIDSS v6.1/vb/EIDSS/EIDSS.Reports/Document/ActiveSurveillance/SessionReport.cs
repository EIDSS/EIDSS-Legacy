using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Document.ActiveSurveillance
{
    [NullableAdapters]
    public sealed partial class SessionReport : BaseDocumentReport
    {
        public SessionReport()
        {
            InitializeComponent();
        }

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            long id = GetLongParameter(parameters, "@ObjID");

            m_SessionAdapter.Connection = (SqlConnection) manager.Connection;
            m_SessionAdapter.Transaction = (SqlTransaction) manager.Transaction;
            m_SessionAdapter.CommandTimeout = CommandTimeout;

            m_SessionReportDataSet.EnforceConstraints = false;
            m_SessionAdapter.Fill(m_SessionReportDataSet.Session, id, lang);

            var diagnosisReport = (SessionDiagnosisReport) m_DiagnosisSubreport.ReportSource;
            diagnosisReport.SetParameters(lang, id, manager, archiveManager);

            var farmReport = (SessionFarmReport) m_FarmSubreport.ReportSource;
            farmReport.SetParameters(lang, id, manager, archiveManager);

            var summaryReport = (SessionSummaryReport) m_SummarySubreport.ReportSource;
            summaryReport.SetParameters(lang, id, manager, archiveManager);

            var actionsReport = (SessionActionsReport) m_ActionsSubreport.ReportSource;
            actionsReport.SetParameters(lang, id, manager, archiveManager);

            var casesReport = (SessionCasesReport) m_CasesSubreport.ReportSource;
            casesReport.SetParameters(lang, id, manager, archiveManager);

            ReportRtlHelper.SetRTL(this);
        }
    }
}