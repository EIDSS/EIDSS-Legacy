using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Parameterized.Veterinary.SamplesType
{
    [NullableAdapters]
    public sealed partial class VetSamplesTypeReport : BaseYearReport
    {
        public VetSamplesTypeReport()
        {
            InitializeComponent();
        }

        public override void SetParameters( BaseYearModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                vetSamplesTypeDataSet1.EnforceConstraints = false;
                sp_rep_VET_YearSampleTypeReportTableAdapter1.Connection = connection;
                sp_rep_VET_YearSampleTypeReportTableAdapter1.Transaction = transaction;

                sp_rep_VET_YearSampleTypeReportTableAdapter1.Fill(
                    vetSamplesTypeDataSet1.spRepVetYearSampleReportBySampleType,
                    model.Language, model.Year);
            });

            FillDataTableWithArchive(action,
               manager, archiveManager,
                vetSamplesTypeDataSet1.spRepVetYearSampleReportBySampleType,
                model.Mode,
                new[] {"Disease", "Region", "SampleType"});

            vetSamplesTypeDataSet1.spRepVetYearSampleReportBySampleType.DefaultView.Sort = "Disease, Region, SampleType";

            ReportRtlHelper.SetRTL(this);
        }
    }
}