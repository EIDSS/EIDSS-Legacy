using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public sealed partial class AssignmentLabDiagnosticReport : BaseSampleReport
    {
        public AssignmentLabDiagnosticReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, LabCaseModel model)
        {
            base.SetParameters(manager, model);
            HeaderCaseIDBarcodeCell.Text = string.Format("*{0}*", model.CaseId);
            HeaderCaseIDCell.Text = model.CaseId;

            Action<SqlConnection> action = (connection =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;
                m_Adapter.Fill(
                    m_DataSet.AssignmentDiagnostic,
                    model.Language,
                    model.CaseId,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                m_DataSet.AssignmentDiagnostic,
                model.Mode, new[] {"strSampleId"});

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}