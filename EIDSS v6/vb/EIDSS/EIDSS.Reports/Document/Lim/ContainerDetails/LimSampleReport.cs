using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Lim.ContainerDetails
{
    public sealed partial class LimSampleReport : BaseDocumentReport
    {
        public LimSampleReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);
            long caseId = (GetLongParameter(parameters, "@ObjID"));

            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
            m_Adapter.CommandTimeout = CommandTimeout;
            m_DataSet.EnforceConstraints = false;

            m_Adapter.Fill(m_DataSet.ContainerDetails, lang, caseId);

            DataAdapter = null;
            DetailReport.DataAdapter = null;
        }
    }
}