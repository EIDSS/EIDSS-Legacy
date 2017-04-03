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

            sp_Rep_LIM_SampleTransferFormTableAdapter1.Connection = (SqlConnection) manager.Connection;
            sp_Rep_LIM_SampleTransferFormTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            sp_Rep_LIM_SampleTransferFormTableAdapter1.CommandTimeout = CommandTimeout;
            transferDataSet1.EnforceConstraints = false;
            sp_Rep_LIM_SampleTransferFormTableAdapter1.Fill(transferDataSet1.spRepLimSampleTransferForm, id, lang);
        }
    }
}