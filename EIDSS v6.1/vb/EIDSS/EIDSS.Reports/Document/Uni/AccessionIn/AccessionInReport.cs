using System.Collections.Generic;
using System.Data.SqlClient;
using EIDSS.Reports.Factory;
using bv.model.BLToolkit;
using bv.winclient.Core;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Uni.AccessionIn
{
    public sealed partial class AccessionInReport : BaseDocumentReport
    {
        public AccessionInReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);
            long caseId = (GetLongParameter(parameters, "@ObjID"));

            spRepLimLabSampleReceiveTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepLimLabSampleReceiveTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            spRepLimLabSampleReceiveTableAdapter1.CommandTimeout = CommandTimeout;

            accessionInDataSet1.EnforceConstraints = false;
            spRepLimLabSampleReceiveTableAdapter1.Fill(accessionInDataSet1.spRepLimLabSampleReceive, caseId, lang);

            var type = AccessionType.Unknown;

            if (accessionInDataSet1.spRepLimLabSampleReceive.Rows.Count > 0)
            {
                type = (AccessionType)
                    ((AccessionInDataSet.spRepLimLabSampleReceiveRow)
                        (accessionInDataSet1.spRepLimLabSampleReceive.Rows[0])).intCaseType;
            }

            ReportHeaderHumanAccessionIn.Visible = (type == AccessionType.Human);
            DetailHuman.Visible = (type == AccessionType.Human);
            ReportHeaderVetAccessionIn.Visible = (type == AccessionType.Vet);
            DetailVet.Visible = (type == AccessionType.Vet);
            ReportHeaderAsAccessionIn.Visible = (type == AccessionType.ActiveSurveillance);
            DetailAS.Visible = (type == AccessionType.ActiveSurveillance);

            ReportRtlHelper.SetRTL(this);
        }
    }
}