using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Human.ARM.Report
{
    public sealed partial class FormN85MonthlyReport : BaseDateReport
    {
        public FormN85MonthlyReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseDateModel model)
        {
            base.SetParameters(manager, model);

            const string keyField = "strDisease";

            Action<SqlConnection> main = (connection =>
                {
                    formN85MontlyDataSet.EnforceConstraints = false;
                    spRepHumFormN85MonthlyTableAdapter.Connection = connection;
                    spRepHumFormN85MonthlyTableAdapter.CommandTimeout = CommandTimeout;
                    spRepHumFormN85MonthlyTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
                    spRepHumFormN85MonthlyTableAdapter.Fill(
                        formN85MontlyDataSet.spRepHumFormN85Monthly, model.Language, model.Year, model.Month);
                });
            FillDataTableWithArchive(main,
                                     (SqlConnection) manager.Connection,
                                     formN85MontlyDataSet.spRepHumFormN85Monthly,
                                     model.Mode,
                                     new[] {keyField});
            formN85MontlyDataSet.spRepHumFormN85Monthly.DefaultView.Sort = keyField;

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