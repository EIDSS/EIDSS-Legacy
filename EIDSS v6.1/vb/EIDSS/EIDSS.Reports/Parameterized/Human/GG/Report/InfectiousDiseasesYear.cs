using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class InfectiousDiseasesYear : BaseIntervalReport
    {
        public InfectiousDiseasesYear()
        {
            InitializeComponent();
            tableCustomHeader.Top = tableBaseHeader.Top;
        }

        public bool ShowGlobalHeader
        {
            get { return ReportHeader.Visible; }
            set { InfectiousDiseasesHelper.AjustHeaders(ReportHeader, tableBaseHeader, tableCustomHeader,GroupFooter, ReportFooter, value); }
        }

        public void SetParameters(AnnualInfectiousDiseaseModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetParameters( (IntermediateInfectiousDiseaseSurrogateModel)model, manager, archiveManager);

            cellReportedPeriod.Text = string.Format(cellReportedPeriod.Text, model.Year);
        }

        public void SetParameters(IntermediateInfectiousDiseaseSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetParameters((BaseIntervalModel)model, manager, archiveManager);

            const string sortField = "intOrder";
            const string keyField = "strDiseaseName";

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                spRepHumInfectiousDiseaseTableAdapter1.Connection = connection;
                spRepHumInfectiousDiseaseTableAdapter1.CommandTimeout = CommandTimeout;
                spRepHumInfectiousDiseaseTableAdapter1.Transaction = transaction;
                infectiousDiseaseDataSet1.EnforceConstraints = false;
                spRepHumInfectiousDiseaseTableAdapter1.Fill(infectiousDiseaseDataSet1.spRepHumAnnualInfectiousDisease,
                    model.Language,
                    model.StartDate,
                    model.EndDate,
                    model.RegionId,
                    model.RayonId,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
               manager, archiveManager,
                infectiousDiseaseDataSet1.spRepHumAnnualInfectiousDisease,
                model.Mode,
                new[] {keyField});

            infectiousDiseaseDataSet1.spRepHumAnnualInfectiousDisease.DefaultView.Sort = sortField;

            InfectiousDiseasesMonthV4.SetLocation(manager, model, cellLocation);
        }

        private void CellBeforePrint(object sender, PrintEventArgs e)
        {
            InfectiousDiseasesHelper.CellBeforePrint(sender, e);
        }

        private void CellMainTotalBeforePrint(object sender, PrintEventArgs e)
        {
            InfectiousDiseasesHelper.CellTotalBeforePrint(sender, e);
        }
    }
}