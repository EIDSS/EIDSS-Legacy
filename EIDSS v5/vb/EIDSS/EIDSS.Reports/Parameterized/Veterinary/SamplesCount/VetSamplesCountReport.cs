using System;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Veterinary.SamplesCount
{
    public sealed partial class VetSamplesCountReport : BaseYearReport
    {
        public VetSamplesCountReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseYearModel model)
        {
            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
                                                {
                                                    vetSamplesCountDataSet1.EnforceConstraints = false;
                                                    sp_rep_VET_YearSampleCountReportTableAdapter1.Connection = connection;
                                                    sp_rep_VET_YearSampleCountReportTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
                                                    sp_rep_VET_YearSampleCountReportTableAdapter1.CommandTimeout = CommandTimeout;

                                                    sp_rep_VET_YearSampleCountReportTableAdapter1.Fill(
                                                        vetSamplesCountDataSet1.spRepVetYearSampleCountReport,
                                                        model.Language, model.Year);
                                                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     vetSamplesCountDataSet1.spRepVetYearSampleCountReport,
                                     model.UseArchive,
                                     new[] { "Disease", "Region", "Species" });

            vetSamplesCountDataSet1.spRepVetYearSampleCountReport.DefaultView.Sort = "Disease, Region, Species";

            DetailReport.DataAdapter = null;
        }
    }
}