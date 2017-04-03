using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.ActiveSurveillance
{
    public sealed partial class ActiveSurveillanceReport : BaseYearReport
    {
        public ActiveSurveillanceReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseYearModel model)
        {
            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
                {
                    activeSurveillanceDataSet.EnforceConstraints = false;
                    spRepVetActiveSurveillanceReportTableAdapter.Connection = connection;
                    spRepVetActiveSurveillanceReportTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
                    spRepVetActiveSurveillanceReportTableAdapter.CommandTimeout = CommandTimeout;

                    spRepVetActiveSurveillanceReportTableAdapter.Fill(activeSurveillanceDataSet.spRepVetActiveSurveillanceReport,model.Language, model.Year);
                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     activeSurveillanceDataSet.spRepVetActiveSurveillanceReport,
                                     model.Mode,
                                     new[] {"idfsDiagnosis", "idfsSpeciesType"});

            activeSurveillanceDataSet.spRepVetActiveSurveillanceReport.DefaultView.Sort = "strDiagnosis, strSpeciesType";

            DetailReport.DataAdapter = null;
            DataAdapter = null;
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