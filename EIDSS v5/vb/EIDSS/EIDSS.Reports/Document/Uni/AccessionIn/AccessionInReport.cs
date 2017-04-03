using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Uni.AccessionIn
{
    public sealed partial class AccessionInReport : BaseDocumentReport
    {
        public AccessionInReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);
            long caseId = (GetLongParameter(parameters, "@ObjID"));

            spRepLimLabSampleReceiveTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepLimLabSampleReceiveTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
            spRepLimLabSampleReceiveTableAdapter1.CommandTimeout = CommandTimeout;

            accessionInDataSet1.EnforceConstraints = false;
            spRepLimLabSampleReceiveTableAdapter1.Fill(accessionInDataSet1.spRepLimLabSampleReceive, caseId, lang);

            AccessionType type = AccessionType.Unknown;

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
        }
    }
}