using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Parameterized.Veterinary.Situation
{
    [NullableAdapters]
    public sealed partial class VetSituationReport : BaseYearReport
    {
        public VetSituationReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(BaseYearModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                vetSituationDataSet1.EnforceConstraints = false;
                sp_rep_VET_YearlyVeterinarySituationTableAdapter1.Connection = connection;
                sp_rep_VET_YearlyVeterinarySituationTableAdapter1.Transaction = transaction;
                sp_rep_VET_YearlyVeterinarySituationTableAdapter1.CommandTimeout = CommandTimeout;

                sp_rep_VET_YearlyVeterinarySituationTableAdapter1.Fill(
                    vetSituationDataSet1.spRepVetYearlyVeterinarySituation,
                    model.Language, model.Year);
            });

            FillDataTableWithArchive(action,
               manager, archiveManager,
                vetSituationDataSet1.spRepVetYearlyVeterinarySituation,
                model.Mode,
                new[] {"Disease"});

            vetSituationDataSet1.spRepVetYearlyVeterinarySituation.DefaultView.Sort = "Disease";

            ReportRtlHelper.SetRTL(this);
        }
    }
}