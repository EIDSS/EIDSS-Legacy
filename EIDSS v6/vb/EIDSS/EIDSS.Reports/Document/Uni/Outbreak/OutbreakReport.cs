using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Uni.Outbreak
{
    public sealed partial class OutbreakReport : BaseDocumentReport
    {
        public OutbreakReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            string id = GetStringParameter(parameters, "@ObjID");
            OutbreakDataSet.EnforceConstraints = false;

            OutbreakNotesAdapter.Connection = (SqlConnection) manager.Connection;
            OutbreakNotesAdapter.Transaction = (SqlTransaction) manager.Transaction;
            OutbreakNotesAdapter.CommandTimeout = CommandTimeout;
            OutbreakNotesAdapter.Fill(OutbreakDataSet.OutbreakNotesReport, lang, long.Parse(id));

            OutBreakDataSet.OutbreakReportDataTable dataTable = OutbreakDataSet.OutbreakReport;
            OutbreakAdapter.Connection = (SqlConnection) manager.Connection;
            OutbreakAdapter.Transaction = (SqlTransaction) manager.Transaction;
            OutbreakAdapter.CommandTimeout = CommandTimeout;
            OutbreakAdapter.Fill(dataTable, lang, long.Parse(id));

            int total = dataTable.Count;
            if ((dataTable.Count == 1) && dataTable[0].IsidfCaseSessionNull())
            {
                DetailOutbreak.Visible = false;
                total = 0;
            }
            int confirmed = dataTable.Sum(row => row.IsblnConfirmedNull() ? 0:row.blnConfirmed);
            RelatedReportsCell.Text = string.Format(RelatedReportsCell.Text, total, confirmed);

            FillOutbreakDates(dataTable);

            FillCalculatedSourceOfDateAddress(dataTable);
            FillCalculatedAddress(dataTable);
        }

        private void FillOutbreakDates(OutBreakDataSet.OutbreakReportDataTable dataTable)
        {
            if (dataTable.Count > 0)
            {
                OutBreakDataSet.OutbreakReportRow row = dataTable[0];
                if (!(row.IsdatOutbreakStartDateNull() || row.IsdatOutbreakFinishDateNull()))
                {
                    OutbreakDateCell.Text = string.Format("{0} - {1}",
                        ReportRebinder.ToDateString(row.datOutbreakStartDate),
                        ReportRebinder.ToDateString(row.datOutbreakFinishDate));
                }
            }
        }

        private static void FillCalculatedSourceOfDateAddress(OutBreakDataSet.OutbreakReportDataTable dataTable)
        {
            dataTable.BeginLoadData();
            foreach (OutBreakDataSet.OutbreakReportRow row in dataTable)
            {
                if (!row.IsidfsSourceOfCaseSessionDateNull())
                {
                    string value = SourceOfCaseSessionDateMapper.Map((SourceOfCaseSessionDate) row.idfsSourceOfCaseSessionDate);
                    row.strCaseSessionCalculatedSourceOfDate = value;
                }
            }
            dataTable.EndLoadData();
        }

        private static void FillCalculatedAddress(OutBreakDataSet.OutbreakReportDataTable dataTable)
        {
            dataTable.BeginLoadData();
            foreach (OutBreakDataSet.OutbreakReportRow row in dataTable)
            {
                row.strCaseSessionCalculatedAddress = row.strCaseSessionAddress;
                if (!row.IsstrCaseSessionTypeNull())
                {
                    if (row.idfsCaseSessionType == (int) CaseType.Human)
                    {
                        if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Human_CurrentResidence_Details))
                        {
                            row.strCaseSessionCalculatedAddress = row.strCaseSessionAddressDenyRightsDetailed;
                        }
                        if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Human_CurrentResidence_Settlement))
                        {
                            row.strCaseSessionCalculatedAddress = row.strCaseSessionAddressDenyRightsSettlement;
                        }
                    }
                    if (row.idfsCaseSessionType == (int) CaseType.Avian || row.idfsCaseSessionType == (int) CaseType.Livestock)
                    {
                        if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Vet_Farm_Details))
                        {
                            row.strCaseSessionCalculatedAddress = row.strCaseSessionAddressDenyRightsDetailed;
                        }
                        if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Vet_Farm_Settlement))
                        {
                            row.strCaseSessionCalculatedAddress = row.strCaseSessionAddressDenyRightsSettlement;
                        }
                    }
                }
            }
            dataTable.EndLoadData();
        }
    }
}