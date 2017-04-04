using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class AssignmentLabDiagnosticReportNew : BaseReport
    {
        public AssignmentLabDiagnosticReportNew()
        {
            InitializeComponent();
        }

        public void SetParameters(AssignmentLabDiagnosticModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetLanguage(model, manager);

            HeaderCaseIDBarcodeCell.Text = string.Format("*{0}*", model.CaseId);
            HeaderCaseIDCell.Text = model.CaseId;
            HeaderCaseIDBarcodeCell.Text = m_BarCode.Code128(model.CaseId);
            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;
                m_Adapter.Fill(
                    m_DataSet.AssignmentDiagnostic,
                    model.Language,
                    model.CaseId,
                    model.SentTo ?? 0,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_DataSet.AssignmentDiagnostic,
                model.Mode, new[] {"strSampleId"});

            ReportRtlHelper.SetRTL(this);
        }
    }
}