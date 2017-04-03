using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using eidss.winclient.Reports;

namespace EIDSS.Reports.Parameterized.Human.IQ.Reports
{
    [CanWorkWithArchive]
    public partial class ComparativeIQReport : BaseReport
    {
        public ComparativeIQReport()
        {
            InitializeComponent();
        }

        public void SetParameters
            (DbManagerProxy manager, ComparativeSurrogateModel model)
        {
            // TODO: [ivan] delete this assignment when Iraq statistics will be filled in the DataBase
            model.Counter = 1;
            //
            Utils.CheckNotNullOrEmpty(model.Language, "model.Language");
            SetLanguage(manager, model);

            ReportDateCell.Text = DateTime.Now.ToString("dd/MM/yyyy");

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year1, model.StartMonth.HasValue ? model.StartMonth.Value : 1, 1),
                model.UseArchive);

            BindHeader(model.Year1, model.Year2, model.StartMonth, model.EndMonth);

            BindYearCells(model.Year1, model.Year2);

            SetBindingFormats(model.Counter);

            Action<SqlConnection> action = (connection =>
            {
                spRepHumComparativeTableAdapter1.Connection = connection;
                spRepHumComparativeTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
                spRepHumComparativeTableAdapter1.CommandTimeout = CommandTimeout;
                comparativeDataSet1.EnforceConstraints = false;

                spRepHumComparativeTableAdapter1.Fill(comparativeDataSet1.spRepHumIQComparative, model.Language,
                    model.Year1, model.Year2,
                    model.StartMonth, model.EndMonth,
                    model.Region1Id, model.Rayon1Id,
                    model.Region2Id, model.Rayon2Id,
                    model.Counter);
            });
            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                comparativeDataSet1.spRepHumIQComparative,
                model.Mode,
                new[] {"strDisease"});
            comparativeDataSet1.spRepHumIQComparative.DefaultView.Sort = "intRowNumber";
        }

        private void BindHeader(int firstYear, int secondYear, int? startMonth, int? endMonth)
        {
            string monthRange = string.Empty;
            if (startMonth.HasValue && endMonth.HasValue)
            {
                List<ItemWrapper> monthCollection = FilterHelper.GetWinMonthList();
                monthRange = string.Format("{0} - {1}", monthCollection[startMonth.Value - 1], monthCollection[endMonth.Value - 1]);
            }
            HeaderLabel.Text = string.Format(HeaderLabel.Text, monthRange, firstYear, secondYear);
        }

        private void BindYearCells(int firstYear, int secondYear)
        {
            Y1Cell1.Text = Y1Cell2.Text = firstYear.ToString();
            Y2Cell1.Text = Y2Cell2.Text = secondYear.ToString();
        }

        private void SetBindingFormats(int counter)
        {
            bool isInt = counter == 1;
            SetBindingFormatString(isInt, new[]
            {
                Unit1Year2, PersentCell1, Unit2Year2, PersentCell2
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
                        : "{0:0.0000}";
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
            double result;
            if (double.TryParse(cell.Text, out result))
            {
                string formattedResult = (100 * result).ToString("F");
                string plusPrefix = (double.Parse(formattedResult) > 0)
                    ? "+"
                    : string.Empty;

                cell.Text = plusPrefix + formattedResult;
            }
            else
            {
                cell.Text = string.Empty;
            }
        }
    }
}