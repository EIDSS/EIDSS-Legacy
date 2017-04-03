using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Lim.ContainerDetails
{
    public sealed partial class ContainerDetailsReport : BaseDocumentReport
    {
        public ContainerDetailsReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);
            long caseId = (GetLongParameter(parameters, "@ObjID"));

            sp_rep_LIM_ContainerLocationTableAdapter1.Connection = (SqlConnection) manager.Connection;
            sp_rep_LIM_ContainerLocationTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            sp_rep_LIM_ContainerLocationTableAdapter1.CommandTimeout = CommandTimeout;
            containerDataSet1.EnforceConstraints = false;

            sp_rep_LIM_ContainerLocationTableAdapter1.Fill(containerDataSet1.spRepLimContainerLocation, lang, caseId);
        }
    }
}