using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Document.Lim.Transfer
{
    [NullableAdapters]
    public sealed partial class TransferReport : BaseDocumentReport
    {
        public TransferReport()
        {
            InitializeComponent();
        }

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            long id = (GetLongParameter(parameters, "@ObjID"));

            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
            m_Adapter.CommandTimeout = CommandTimeout;
            m_TransferDataSet.EnforceConstraints = false;
            m_Adapter.Fill(m_TransferDataSet.Transfer, id, lang);

            foreach (TransferDataSet.TransferRow row in m_TransferDataSet.Transfer)
            {
                if (!row.IsSourceLabIDBarcodeNull())
                {
                    row.SourceLabIDBarcode = m_BarCode.Code128(row.SourceLabIDBarcode);
                }
                if (!row.IsTransferOutBarcodeNull())
                {
                    row.TransferOutBarcode = m_BarCode.Code128(row.TransferOutBarcode);
                }
            }

            ReportRtlHelper.SetRTL(this);
        }
    }
}