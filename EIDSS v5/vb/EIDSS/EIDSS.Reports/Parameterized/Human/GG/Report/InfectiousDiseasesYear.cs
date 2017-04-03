using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
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
            set
            {
                InfectiousDiseasesHelper.AjustHeaders(ReportHeader, tableBaseHeader, tableCustomHeader, ReportFooter,value);
            }
        }

        public void SetParameters(DbManagerProxy manager, AnnualInfectiousDiseaseModel model)
        {
            SetParameters(manager, (IntermediateInfectiousDiseaseSurrogateModel)model);

            cellReportedPeriod.Text = string.Format(cellReportedPeriod.Text, model.Year);
        }

        public void SetParameters(DbManagerProxy manager, IntermediateInfectiousDiseaseSurrogateModel model)
        {
            SetParameters(manager, (BaseIntervalModel) model);

            const string sortField = "intOrder";
            const string keyField = "strDiseaseName";

            Action<SqlConnection> action = (connection =>
                {
                    spRepHumInfectiousDiseaseTableAdapter1.Connection = connection;
                    spRepHumInfectiousDiseaseTableAdapter1.CommandTimeout = CommandTimeout;
                    spRepHumInfectiousDiseaseTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
                    infectiousDiseaseDataSet1.EnforceConstraints = false;
                    spRepHumInfectiousDiseaseTableAdapter1.Fill(infectiousDiseaseDataSet1.spRepHumAnnualInfectiousDisease,
                                                                model.Language,
                                                                model.StartDate,
                                                                model.EndDate,
                                                                model.RegionId,
                                                                model.RayonId);
                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     infectiousDiseaseDataSet1.spRepHumAnnualInfectiousDisease,
                                     model.UseArchive,
                                     new[] {keyField});

            infectiousDiseaseDataSet1.spRepHumAnnualInfectiousDisease.DefaultView.Sort = sortField;

            InfectiousDiseasesMonth.SetLocation(manager, model, cellLocation);
            DetailReport.DataAdapter = null;
            DataAdapter = null;
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