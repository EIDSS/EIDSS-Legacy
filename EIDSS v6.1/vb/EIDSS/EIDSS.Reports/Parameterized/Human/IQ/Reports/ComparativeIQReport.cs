using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.IQ.Reports
{
    public sealed partial class ComparativeIQReport : BaseReport
    {
        public ComparativeIQReport()
        {
            InitializeComponent();
        }

        public void SetParameters
            (ComparativeSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNullOrEmpty(model.Language, "model.Language");
            SetLanguage(model, manager);

            ReportDateCell.Text = DateTime.Now.ToString("dd/MM/yyyy");

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year1, model.StartMonth.HasValue ? model.StartMonth.Value : 1, 1),
                model.UseArchive);

            BindHeader(model);

            BindYearCells(model.Year1, model.Year2);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                spRepHumComparativeTableAdapter1.Connection = connection;
                spRepHumComparativeTableAdapter1.Transaction = transaction;
                spRepHumComparativeTableAdapter1.CommandTimeout = CommandTimeout;
                comparativeDataSet1.EnforceConstraints = false;

                spRepHumComparativeTableAdapter1.Fill(comparativeDataSet1.spRepHumIQComparative, model.Language,
                    model.Year1, model.Year2,
                    model.StartMonth, model.EndMonth,
                    model.Region1Id, model.Rayon1Id,
                    model.Region2Id, model.Rayon2Id,
                    model.SiteId,
                    model.UserId);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                comparativeDataSet1.spRepHumIQComparative,
                model.Mode,
                new[] {"strDisease"});
            comparativeDataSet1.spRepHumIQComparative.DefaultView.Sort = "intRowNumber";

            // todo: [ivan] check is there need to swithc RTL in IQ report?
            // RtlHelper.SetRTL(this);
        }

        private void BindHeader(ComparativeSurrogateModel model)
        {
            string period;
            string years = string.Format("{0} - {1}", model.Year1, model.Year2);

            if (model.StartMonth.HasValue)
            {
                string startMonth = FilterHelper.GetMonthName(model.StartMonth.Value);
                if (model.EndMonth.HasValue && model.StartMonth != model.EndMonth)
                {
                    period = model.StartMonth == 1 && model.EndMonth == 12
                        ? years
                        : string.Format("{0} - {1} {2} {3}",
                            startMonth, FilterHelper.GetMonthName(model.EndMonth.Value), LabelOf.Text, years);
                }
                else
                {
                    period = string.Format("{0} {1} {2}", startMonth, LabelOf.Text, years);
                }
            }
            else
            {
                period = years;
            }

            HeaderLabel.Text = string.Format(HeaderLabel.Text, period);
        }

        private void BindYearCells(int firstYear, int secondYear)
        {
            Y1Cell1.Text = Y1Cell2.Text = firstYear.ToString();
            Y2Cell1.Text = Y2Cell2.Text = secondYear.ToString();
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