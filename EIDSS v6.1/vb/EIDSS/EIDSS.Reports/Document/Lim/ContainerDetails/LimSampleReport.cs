using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Document.Lim.ContainerDetails
{
    [NullableAdapters]
    public sealed partial class LimSampleReport : BaseDocumentReport
    {
        public LimSampleReport()
        {
            InitializeComponent();
        }

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);
            long caseId = (GetLongParameter(parameters, "@ObjID"));

            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
            m_Adapter.CommandTimeout = CommandTimeout;
            m_DataSet.EnforceConstraints = false;

            m_Adapter.Fill(m_DataSet.ContainerDetails, lang, caseId);
            FillBarcode();

            ReportRtlHelper.SetRTL(this);
        }

        private void FillBarcode()
        {
            if (m_DataSet.ContainerDetails.Count > 0)
            {
                SampleDataSet.ContainerDetailsRow row = m_DataSet.ContainerDetails[0];

                BarcodeCell.Text = row.IsstrLabSampleIDNull()
                    ? string.Empty
                    : m_BarCode.Code128(row.strLabSampleID);
            }
        }
    }
}