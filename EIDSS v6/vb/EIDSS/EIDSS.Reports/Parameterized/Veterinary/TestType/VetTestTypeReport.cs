using System;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Veterinary.TestType
{
    public sealed partial class VetTestTypeReport : BaseYearReport
    {
        public VetTestTypeReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseYearModel model)
        {
            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
                {
                    vetTestTypeDataSet1.EnforceConstraints = false;
                    sp_rep_VET_YearTestTypeReportTableAdapter1.Connection = connection;
                    sp_rep_VET_YearTestTypeReportTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
                    sp_rep_VET_YearTestTypeReportTableAdapter1.CommandTimeout = CommandTimeout;
                    sp_rep_VET_YearTestTypeReportTableAdapter1.Fill(
                        vetTestTypeDataSet1.spRepVetSamplesReportbySampleTypesWithinRegions,
                        model.Language, model.Year);
                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     vetTestTypeDataSet1.spRepVetSamplesReportbySampleTypesWithinRegions,
                                     model.Mode,
                                     new[] {"Disease", "Region", "SampleType", "TestType"});

            vetTestTypeDataSet1.spRepVetSamplesReportbySampleTypesWithinRegions.DefaultView.Sort = "Disease, Region, SampleType, TestType";

            DetailReport.DataAdapter = null;
        }
    }
}