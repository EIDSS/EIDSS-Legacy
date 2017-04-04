using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Parameterized.ActiveSurveillance
{
    [NullableAdapters]
    public sealed partial class ActiveSurveillanceReport : BaseYearReport
    {
        public ActiveSurveillanceReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(BaseYearModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                activeSurveillanceDataSet.EnforceConstraints = false;
                spRepVetActiveSurveillanceReportTableAdapter.Connection = connection;
                spRepVetActiveSurveillanceReportTableAdapter.Transaction = transaction;
                spRepVetActiveSurveillanceReportTableAdapter.CommandTimeout = CommandTimeout;

                spRepVetActiveSurveillanceReportTableAdapter.Fill(activeSurveillanceDataSet.spRepVetActiveSurveillanceReport, model.Language,
                    model.Year);
            });

            FillDataTableWithArchive(action,
                manager, archiveManager,
                activeSurveillanceDataSet.spRepVetActiveSurveillanceReport,
                model.Mode,
                new[] {"idfsDiagnosis", "idfsSpeciesType"});

            activeSurveillanceDataSet.spRepVetActiveSurveillanceReport.DefaultView.Sort = "strDiagnosis, strSpeciesType";

            ReportRtlHelper.SetRTL(this);
        }

        private void PlannedCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (string.IsNullOrEmpty(PlannedCell.Text))
            {
                PlannedCell.Text = "0";
            }
        }

        private void SampledCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (string.IsNullOrEmpty(SampledCell.Text))
            {
                SampledCell.Text = "0";
            }
        }
    }
}