using System;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Uni.EventLog
{
    public sealed partial class EventLogReport : BaseIntervalReport
    {
        public EventLogReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseIntervalModel model)
        {
            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
                                                {
                                                    eventLogDataSet1.EnforceConstraints = false;
                                                    
                                                    sp_rep_UNI_EventLogTableAdapter1.Connection = connection;
                                                    sp_rep_UNI_EventLogTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
                                                    sp_rep_UNI_EventLogTableAdapter1.CommandTimeout = CommandTimeout;
                                                    
                                                    sp_rep_UNI_EventLogTableAdapter1.Fill(eventLogDataSet1.spRepUniEventLog,
                                                                                          model.Language,
                                                                                          model.StartDate.ToString("s"),
                                                                                          model.EndDate.ToString("s"));
                                                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     eventLogDataSet1.spRepUniEventLog,
                                     model.UseArchive);

            eventLogDataSet1.spRepUniEventLog.DefaultView.Sort = "datEventDatatime DESC";
        }
    }
}