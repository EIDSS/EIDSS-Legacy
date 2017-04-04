using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class LabTestingTesultsReportNew : BaseReport
    {
        public LabTestingTesultsReportNew()
        {
            InitializeComponent();
        }

        public void SetParameters(LabTestingTesultsModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetLanguage(model, manager);

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;
                m_Adapter.Fill(
                    m_DataSet.LabTestingResult,
                    model.Language,
                    model.SampleId ?? string.Empty,
                    model.LabDepartmentId,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_DataSet.LabTestingResult,
                model.Mode, new[] {"strSampleId"});

            FillBarcode();

            ReportRtlHelper.SetRTL(this);
        }

        private void FillBarcode()
        {
            if (m_DataSet.LabTestingResult.Count > 0)
            {
                LabTestingResultDataSet.LabTestingResultRow row = m_DataSet.LabTestingResult[0];

                HeaderCaseIDBarcodeCell.Text = row.IsstrCaseIdNull()
                    ? string.Empty
                    : m_BarCode.Code128(row.strCaseId);
            }
        }
    }
}