using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Parameterized.Veterinary.SamplesCount
{
    [NullableAdapters]
    public sealed partial class VetSamplesCountReport : BaseYearReport
    {
        public VetSamplesCountReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(BaseYearModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                vetSamplesCountDataSet1.EnforceConstraints = false;
                sp_rep_VET_YearSampleCountReportTableAdapter1.Connection = connection;
                sp_rep_VET_YearSampleCountReportTableAdapter1.Transaction = transaction;
                sp_rep_VET_YearSampleCountReportTableAdapter1.CommandTimeout = CommandTimeout;

                sp_rep_VET_YearSampleCountReportTableAdapter1.Fill(
                    vetSamplesCountDataSet1.spRepVetYearSampleCountReport,
                    model.Language, model.Year);
            });

            FillDataTableWithArchive(action,
                manager, archiveManager,
                vetSamplesCountDataSet1.spRepVetYearSampleCountReport,
                model.Mode,
                new[] {"Disease", "Region", "Species"});

            vetSamplesCountDataSet1.spRepVetYearSampleCountReport.DefaultView.Sort = "Disease, Region, Species";

            ReportRtlHelper.SetRTL(this);
        }
    }
}