using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Parameterized.Veterinary.TestType
{
    [NullableAdapters]
    public sealed partial class VetTestTypeReport : BaseYearReport
    {
        public VetTestTypeReport()
        {
            InitializeComponent();
        }

        public override void SetParameters( BaseYearModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                vetTestTypeDataSet1.EnforceConstraints = false;
                sp_rep_VET_YearTestTypeReportTableAdapter1.Connection = connection;
                sp_rep_VET_YearTestTypeReportTableAdapter1.Transaction = transaction;
                sp_rep_VET_YearTestTypeReportTableAdapter1.CommandTimeout = CommandTimeout;
                sp_rep_VET_YearTestTypeReportTableAdapter1.Fill(
                    vetTestTypeDataSet1.spRepVetSamplesReportbySampleTypesWithinRegions,
                    model.Language, model.Year);
            });

            FillDataTableWithArchive(action,
              manager, archiveManager,
                vetTestTypeDataSet1.spRepVetSamplesReportbySampleTypesWithinRegions,
                model.Mode,
                new[] {"Disease", "Region", "SampleType", "TestType"});

            vetTestTypeDataSet1.spRepVetSamplesReportbySampleTypesWithinRegions.DefaultView.Sort = "Disease, Region, SampleType, TestType";

            ReportRtlHelper.SetRTL(this);
        }
    }
}