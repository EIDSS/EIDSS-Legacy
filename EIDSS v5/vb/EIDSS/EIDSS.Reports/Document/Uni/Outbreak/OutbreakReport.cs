using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Enums;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Uni.Outbreak
{
    public sealed partial class OutbreakReport : BaseDocumentReport
    {
        private int m_LineCounter;

        public OutbreakReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);
            m_LineCounter = 0;

            string id = GetStringParameter(parameters, "@ObjID");
            OutbreakDataSet.EnforceConstraints = false;

            OutbreakNotesAdapter.Connection = (SqlConnection) manager.Connection;
            OutbreakNotesAdapter.Transaction = (SqlTransaction) manager.Transaction;
            OutbreakNotesAdapter.CommandTimeout = CommandTimeout;
            OutbreakNotesAdapter.Fill(OutbreakDataSet.spRepUniOutbreakNotesReport, lang, long.Parse(id));

            OutBreakDataSet.spRepUniOutbreakReportDataTable dataSource = OutbreakDataSet.spRepUniOutbreakReport;
            OutbreakReportAdapter.Connection = (SqlConnection) manager.Connection;
            OutbreakReportAdapter.Transaction = (SqlTransaction) manager.Transaction;
            OutbreakReportAdapter.CommandTimeout = CommandTimeout;
            OutbreakReportAdapter.Fill(dataSource, lang, long.Parse(id));

            if ((dataSource.Rows.Count == 1) && (dataSource.Rows[0]["CaseId"] is DBNull))
            {
                Detail1.Visible = false;
            }

            int total = dataSource.Count;
            int confirmed = dataSource.Sum(row => row.Confirmed);
            RelatedReportsCell.Text = string.Format(RelatedReportsCell.Text, total, confirmed);

            if (dataSource.Count > 0)
            {
                var row = ((OutBreakDataSet.spRepUniOutbreakReportRow) dataSource.Rows[0]);
                if (!(row.IsdatStartDateNull() || row.IsdatFinishDateNull()))
                {
                    OutbreakDateCell.Text = string.Format("{0} - {1}",
                        ReportRebinder.ToDateString(row.datStartDate),
                        ReportRebinder.ToDateString(row.datFinishDate));
                }
            }
        }

        private void LocationCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (m_LineCounter < 0 || m_LineCounter >= OutbreakDataSet.spRepUniOutbreakReport.Rows.Count)
            {
                return;
            }
            var dataRow = (OutBreakDataSet.spRepUniOutbreakReportRow) OutbreakDataSet.spRepUniOutbreakReport.Rows[m_LineCounter];
            if (dataRow.idfsCaseType == (int) CaseType.Human)
            {
                if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Human_CurrentResidence_Details))
                {
                    LocationCell.Text = dataRow.LocationDenyRightsDetailed;
                }
                if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Human_CurrentResidence_Settlement))
                {
                    LocationCell.Text = dataRow.LocationDenyRightsSettlement;
                }
            }
            else
            {
                if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Vet_Farm_Details))
                {
                    LocationCell.Text = dataRow.LocationDenyRightsDetailed;
                }
                if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Vet_Farm_Settlement))
                {
                    LocationCell.Text = dataRow.LocationDenyRightsSettlement;
                }
            }
            m_LineCounter++;
        }
    }
}