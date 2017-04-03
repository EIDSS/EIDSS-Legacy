using System;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Veterinary.SamplesType
{
    public sealed partial class VetSamplesTypeReport : BaseYearReport
    {
        public VetSamplesTypeReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseYearModel model)
        {
            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
                {
                    vetSamplesTypeDataSet1.EnforceConstraints = false;
                    sp_rep_VET_YearSampleTypeReportTableAdapter1.Connection = connection;
                    sp_rep_VET_YearSampleTypeReportTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;

                    sp_rep_VET_YearSampleTypeReportTableAdapter1.Fill(
                        vetSamplesTypeDataSet1.spRepVetYearSampleReportBySampleType,
                        model.Language, model.Year);
                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     vetSamplesTypeDataSet1.spRepVetYearSampleReportBySampleType,
                                     model.UseArchive,
                                     new[] {"Disease", "Region", "SampleType"});

            vetSamplesTypeDataSet1.spRepVetYearSampleReportBySampleType.DefaultView.Sort = "Disease, Region, SampleType";

            DetailReport.DataAdapter = null;
        }
    }
}