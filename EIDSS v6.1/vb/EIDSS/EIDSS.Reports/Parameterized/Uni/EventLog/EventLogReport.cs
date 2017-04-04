using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Parameterized.Uni.EventLog
{
    public sealed partial class EventLogReport : BaseIntervalReport
    {
        public EventLogReport()
        {
            InitializeComponent();
        }

        public override void SetParameters( BaseIntervalModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                eventLogDataSet1.EnforceConstraints = false;

                sp_rep_UNI_EventLogTableAdapter1.Connection = connection;
                sp_rep_UNI_EventLogTableAdapter1.Transaction = transaction;
                sp_rep_UNI_EventLogTableAdapter1.CommandTimeout = CommandTimeout;

                sp_rep_UNI_EventLogTableAdapter1.Fill(eventLogDataSet1.spRepUniEventLog,
                    model.Language,
                    model.StartDate.ToString("s"),
                    model.EndDate.ToString("s"));
            });

            FillDataTableWithArchive(action,
                 manager, archiveManager,
                eventLogDataSet1.spRepUniEventLog,
                model.Mode);

            eventLogDataSet1.spRepUniEventLog.DefaultView.Sort = "datEventDatatime DESC";

            ReportRtlHelper.SetRTL(this);
        }
    }
}