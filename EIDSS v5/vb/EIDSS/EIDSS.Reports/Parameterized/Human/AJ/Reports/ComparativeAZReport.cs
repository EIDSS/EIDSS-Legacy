using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class ComparativeAZReport : BaseReport
    {
        public ComparativeAZReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, ComparativeSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            SetLanguage(manager, model.Language);

            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            DateTimeLabel.Text = rebinder.ToDateTimeString(DateTime.Now);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year1, model.StartMonth.HasValue ? model.StartMonth.Value : 1, 1),
                                       model.UseArchive);

            BindHeader(model);

            BindYearCells(model);

            SetBindingFormats(model.Counter);

            Action<SqlConnection> action = (connection =>
                {
                    spRepHumComparativeTableAdapter1.Connection = connection;
                    spRepHumComparativeTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
                    spRepHumComparativeTableAdapter1.CommandTimeout = CommandTimeout;

                    comparativeDataSet1.EnforceConstraints = false;

                    spRepHumComparativeTableAdapter1.Fill(comparativeDataSet1.spRepHumComparative,
                                                          model.Language,
                                                          model.Year1, model.Year2, model.StartMonth, model.EndMonth,
                                                          model.Region1Id, model.Rayon1Id,
                                                          model.Region2Id, model.Rayon2Id,
                                                          model.OrganizationCHE, model.Counter);
                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     comparativeDataSet1.spRepHumComparative,
                                     model.UseArchive,
                                     new[] {"intRowNumber", "strDisease", "strICD10"});
            comparativeDataSet1.spRepHumComparative.DefaultView.Sort = "intOrder";
        }

        private void BindHeader(ComparativeSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");
            string monthRange = string.Empty;
            if (model.StartMonth.HasValue && model.EndMonth.HasValue)
            {
                List<ItemWrapper> monthCollection = BaseDateKeeper.CreateMonthCollection();
                monthRange = string.Format("{0} - {1}",
                                           monthCollection[model.StartMonth.Value - 1], monthCollection[model.EndMonth.Value - 1]);
            }
            HeaderLabel.Text = string.Format(HeaderLabel.Text, monthRange, model.Year2, model.Year1);
        }

        private void BindYearCells(ComparativeSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");
            Y2Cell1.Text = Y2Cell2.Text = Y2Cell4.Text = Y2Cell5.Text = model.Year2.ToString();
            Y1Cell1.Text = Y1Cell2.Text = Y1Cell4.Text = Y1Cell5.Text = model.Year1.ToString();
        }

        private void SetBindingFormats(int counter)
        {
            SetBindingFormatString(counter == 0, new[]
                {
                    TotalY2Cell1, TotalY2Cell2, TotalY2Cell4, TotalY2Cell5,
                    TotalY1Cell1, TotalY1Cell2, TotalY1Cell4, TotalY1Cell5
                });
        }

        private static void SetBindingFormatString(bool isInt, IEnumerable<XRTableCell> cells)
        {
            foreach (XRTableCell cell in cells)
            {
                foreach (XRBinding dataBinding in cell.DataBindings)
                {
                    dataBinding.FormatString = isInt
                                                   ? string.Empty
                                                   : "{0:0.00}";
                }
            }
        }

        private void PercentCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!(sender is XRTableCell))
            {
                return;
            }

            var cell = ((XRTableCell) sender);
            int percentIndex = DetailRow.Cells.IndexOf(cell);
            if (percentIndex >= 2)
            {
                double year1Value;
                double year2Value;
                if (double.TryParse(DetailRow.Cells[percentIndex - 2].Text, out year2Value) &&
                    double.TryParse(DetailRow.Cells[percentIndex - 1].Text, out year1Value))
                {
                    double result = 0;
                    if (year1Value != 0)
                    {
                        result = (100 * (year2Value - year1Value) / year1Value);
                    }
                    string plusPrefix = (result > 0)
                                            ? "+"
                                            : string.Empty;

                    cell.Text = plusPrefix + result.ToString("0.00");
                    return;
                }
            }
            cell.Text = string.Empty;
        }
    }
}