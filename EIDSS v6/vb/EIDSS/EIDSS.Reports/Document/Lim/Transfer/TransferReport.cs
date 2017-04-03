using System.Collections.Generic;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;

namespace EIDSS.Reports.Document.Lim.Transfer
{
    public sealed partial class TransferReport : BaseDocumentReport
    {
        public TransferReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            long id = (GetLongParameter(parameters, "@ObjID"));

            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
            m_Adapter.CommandTimeout = CommandTimeout;
            m_TransferDataSet.EnforceConstraints = false;
            m_Adapter.Fill(m_TransferDataSet.Transfer, id, lang);

            DataAdapter = null;
        }
    }
}