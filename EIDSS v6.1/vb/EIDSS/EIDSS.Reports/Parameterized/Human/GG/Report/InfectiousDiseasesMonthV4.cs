using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.DataSet;
using EIDSS.Reports.Parameterized.Human.GG.DataSet.InfectiousAddressHeaderDataSetTableAdapters;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class InfectiousDiseasesMonthV4 : BaseIntervalReport
    {
        public InfectiousDiseasesMonthV4()
        {
            InitializeComponent();
            tableCustomHeader.Top = tableBaseHeader.Top;
        }

        public bool ShowGlobalHeader
        {
            get { return ReportHeader.Visible; }
            set { InfectiousDiseasesHelper.AjustHeaders(ReportHeader, tableBaseHeader, tableCustomHeader, GroupFooter, ReportFooter, value); }
        }

        public void SetParameters(MonthInfectiousDiseaseModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetParameters((IntermediateInfectiousDiseaseSurrogateModel)model, manager, archiveManager);

            string strMonth = (infectiousDiseaseDataSet1.spRepHumMonthlyInfectiousDisease.Count > 0)
                ? infectiousDiseaseDataSet1.spRepHumMonthlyInfectiousDisease[0].strMonth
                : string.Empty;
            cellReportedPeriod.Text = string.Format(cellReportedPeriod.Text, model.Year, strMonth);
        }

        public void SetParameters(IntermediateInfectiousDiseaseSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetParameters((BaseIntervalModel)model, manager, archiveManager);

            infectiousDiseaseDataSet1.EnforceConstraints = false;
            Action<SqlConnection, SqlTransaction> action1 = ((connection, transaction) =>
            {
                spRepHumMonthlyInfectiousDiseaseFatalTableAdapter1.Connection = connection;
                spRepHumMonthlyInfectiousDiseaseFatalTableAdapter1.Transaction = transaction;
                spRepHumMonthlyInfectiousDiseaseFatalTableAdapter1.CommandTimeout = CommandTimeout;

                spRepHumMonthlyInfectiousDiseaseFatalTableAdapter1.Fill(
                    infectiousDiseaseDataSet1.spRepHumMonthlyInfectiousDiseaseFatal,
                    model.Language,
                    model.StartDate,
                    model.EndDate,
                    model.RegionId,
                    model.RayonId,
                    model.SiteId
                    );
            });
            FillDataTableWithArchive(action1,
                manager, archiveManager,
                infectiousDiseaseDataSet1.spRepHumMonthlyInfectiousDiseaseFatal,
                model.Mode,
                new[] {"strKeyField"});

            Action<SqlConnection, SqlTransaction> action2 = ((connection, transaction) =>
            {
                spRepHumMonthlyInfectiousDiseaseTableAdapter1.Connection = connection;
                spRepHumMonthlyInfectiousDiseaseTableAdapter1.Transaction = transaction;
                spRepHumMonthlyInfectiousDiseaseTableAdapter1.CommandTimeout = CommandTimeout;

                spRepHumMonthlyInfectiousDiseaseTableAdapter1.Fill(
                    infectiousDiseaseDataSet1.spRepHumMonthlyInfectiousDisease,
                    model.Language,
                    model.StartDate,
                    model.EndDate,
                    model.RegionId,
                    model.RayonId,
                    model.SiteId);
            });
            FillDataTableWithArchive(action2,
               manager, archiveManager,
                infectiousDiseaseDataSet1.spRepHumMonthlyInfectiousDisease,
                model.Mode,
                new[] {"strDiseaseName"});
            infectiousDiseaseDataSet1.spRepHumMonthlyInfectiousDisease.DefaultView.Sort = "intOrder";

            SetLocation(manager, model, cellLocation);
        }

        internal static void SetLocation(DbManagerProxy manager, IntermediateInfectiousDiseaseSurrogateModel model, XRLabel cell)
        {
            var headerDataSet = new InfectiousAddressHeaderDataSet();
            var headerAddressAdapter = new spRepHumInfectiousAddressHeaderTableAdapter
            {Connection = (SqlConnection) manager.Connection};
            headerAddressAdapter.Fill(headerDataSet.spRepHumInfectiousAddressHeader, model.Language,
                model.RegionId, model.RayonId);

            if (headerDataSet.spRepHumInfectiousAddressHeader.Count == 0)
            {
                throw new ApplicationException("spRepHumInfectiousAddressHeader returns no rows");
            }
            cell.DataBindings.Clear();
            cell.Text = headerDataSet.spRepHumInfectiousAddressHeader[0].strLocation;
        }

        private void CellBeforePrint(object sender, PrintEventArgs e)
        {
            InfectiousDiseasesHelper.CellBeforePrint(sender, e);
        }

        private void CellMainTotalBeforePrint(object sender, PrintEventArgs e)
        {
            InfectiousDiseasesHelper.CellTotalBeforePrint(sender, e);
        }

        private void SpecifyDiseaseCell_BeforePrint(object sender, PrintEventArgs e)
        {
            SpecifyDiseaseCell.Text = string.Format("{0} {1}", SpecifyDiseaseHiddenLabel.Text, SpecifyDiseaseCell.Text);
        }
    }
}