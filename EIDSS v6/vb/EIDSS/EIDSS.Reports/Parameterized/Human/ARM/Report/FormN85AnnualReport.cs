using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Human.ARM.Report
{
    public sealed partial class FormN85AnnualReport : BaseYearReport
    {
        public FormN85AnnualReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseYearModel model)
        {
            const string keyField = "strDisease";

            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
                {
                    formN85AnnualFirstDataSet.EnforceConstraints = false;
                    spRepHumFormN85AnnualFirstTableAdapter.Connection = connection;
                    spRepHumFormN85AnnualFirstTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
                    spRepHumFormN85AnnualFirstTableAdapter.CommandTimeout = CommandTimeout;

                    spRepHumFormN85AnnualFirstTableAdapter.Fill(
                        formN85AnnualFirstDataSet.spRepHumFormN85AnnualFirst,
                        model.Language, model.Year);
                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     formN85AnnualFirstDataSet.spRepHumFormN85AnnualFirst,
                                     model.Mode,
                                     new[] {keyField});
            formN85AnnualFirstDataSet.spRepHumFormN85AnnualFirst.DefaultView.Sort = keyField;

            action = (connection =>
                {
                    formN85AnnualSecondDataSet.EnforceConstraints = false;
                    spRepHumFormN85AnnualSecondTableAdapter.Connection = connection;
                    spRepHumFormN85AnnualSecondTableAdapter.CommandTimeout = CommandTimeout;
                    spRepHumFormN85AnnualSecondTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
                    spRepHumFormN85AnnualSecondTableAdapter.Fill(
                        formN85AnnualSecondDataSet.spRepHumFormN85AnnualSecond,
                        model.Language, model.Year);
                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     formN85AnnualSecondDataSet.spRepHumFormN85AnnualSecond,
                                     model.Mode,
                                     new[] {keyField});
            formN85AnnualSecondDataSet.spRepHumFormN85AnnualSecond.DefaultView.Sort = keyField;

            action = (connection =>
                {
                    formN85AnnualThirdDataSet.EnforceConstraints = false;
                    spRepHumFormN85AnnualThirdTableAdapter.Connection = connection;
                    spRepHumFormN85AnnualThirdTableAdapter.CommandTimeout = CommandTimeout;
                    spRepHumFormN85AnnualThirdTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
                    spRepHumFormN85AnnualThirdTableAdapter.Fill(formN85AnnualThirdDataSet.spRepHumFormN85AnnualThird,
                          model.Language, model.Year);
                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     formN85AnnualThirdDataSet.spRepHumFormN85AnnualThird,
                                     model.Mode,
                                     new[] {keyField});
            formN85AnnualThirdDataSet.spRepHumFormN85AnnualThird.DefaultView.Sort = keyField;

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }

        private void Cell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!(sender is XRTableCell))
            {
                return;
            }

            var cell = (XRTableCell) sender;
            if (cell.Text == "0")
            {
                cell.Text = string.Empty;
            }
        }
    }
}