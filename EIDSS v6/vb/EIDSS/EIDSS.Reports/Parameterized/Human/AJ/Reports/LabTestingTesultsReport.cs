using System;
using System.Data.SqlClient;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public sealed partial class LabTestingTesultsReport : BaseSampleReport
    {
        public LabTestingTesultsReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, VetLabSampleModel model)
        {
            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;
                m_Adapter.Fill(
                    m_DataSet.LabTestingResult,
                    model.Language,
                    model.SampleId,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                m_DataSet.LabTestingResult,
                model.Mode, new[] {"strSampleId"});

            if (m_DataSet.LabTestingResult.Count > 0)
            {
                LabTestingResultDataSet.LabTestingResultRow row = m_DataSet.LabTestingResult[0];
                if (row.IsstrCaseIdNull() || Utils.IsEmpty(row.strCaseId))
                {
                    HeaderCaseIDBarcodeCell.DataBindings.Clear();
                }
            }

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}