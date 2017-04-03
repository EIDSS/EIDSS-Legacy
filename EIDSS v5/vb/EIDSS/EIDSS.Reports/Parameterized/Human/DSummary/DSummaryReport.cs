using System;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Human.DSummary
{
    public sealed partial class DSummaryReport : BaseIntervalReport
    {
        public DSummaryReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseIntervalModel model)
        {
            base.SetParameters(manager, model);

            Action<SqlConnection> fillTableAction = (connection =>
                {
                    sp_rep_HUM_SummaryOfInfectionDiseasesTableAdapter1.Connection = connection;
                    sp_rep_HUM_SummaryOfInfectionDiseasesTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
                    sp_rep_HUM_SummaryOfInfectionDiseasesTableAdapter1.CommandTimeout = CommandTimeout;
                    dSummaryDataSet1.EnforceConstraints = false;

                    sp_rep_HUM_SummaryOfInfectionDiseasesTableAdapter1.Fill(
                        dSummaryDataSet1.spRepHumSummaryOfInfectionDiseases,
                        model.Language,
                        model.StartDate.ToString("s"),
                        model.EndDate.ToString("s"));
                });

            FillDataTableWithArchive(fillTableAction,
                                     (SqlConnection) manager.Connection,
                                     dSummaryDataSet1.spRepHumSummaryOfInfectionDiseases,
                                     model.UseArchive);

            dSummaryDataSet1.spRepHumSummaryOfInfectionDiseases.DefaultView.Sort = "ReportedDate";
        }
    }
}