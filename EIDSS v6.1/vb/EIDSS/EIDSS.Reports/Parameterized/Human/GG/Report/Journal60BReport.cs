using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class Journal60BReport : BaseIntervalReport
    {
        public Journal60BReport()
        {
            InitializeComponent();
        }

        public void SetParameters(Hum60BJournalModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetParameters((BaseIntervalModel)model, manager, archiveManager);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                spRepJournal60BTableAdapter1.Connection = connection;
                spRepJournal60BTableAdapter1.Transaction = transaction;
                spRepJournal60BTableAdapter1.CommandTimeout = CommandTimeout;

                journal60BDataSet1.EnforceConstraints = false;

                spRepJournal60BTableAdapter1.Fill(
                    journal60BDataSet1.spRepJournal60B,
                    model.Language,
                    model.StartDate,
                    model.EndDate,
                    model.Diagnosis,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
                manager, archiveManager,
                journal60BDataSet1.spRepJournal60B,
                model.Mode,
                new[] {"strCaseId"});

            journal60BDataSet1.spRepJournal60B.DefaultView.Sort = "datEntredDate";
        }
    }
}