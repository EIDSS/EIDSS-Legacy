using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Document.VectorSurveillance
{
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

            m_SessionAdapter.Fill(m_SessionReportDataSet.spRepVSSession, id, lang);

            ReportRtlHelper.SetRTL(this);
        }
    }
}