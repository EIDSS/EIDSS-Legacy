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

namespace EIDSS.Reports.Parameterized.Human.IQ.Reports
{
    public partial class ComparativeIQReport : BaseReport
    {
        public ComparativeIQReport()
        {
            InitializeComponent();
        }

        public void SetParameters
            (DbManagerProxy manager, string lang, int firstYear, int secondYear, int? startMonth, int? endMonth,
             long? firstRegionID, long? firstRayonID, long? secondRegionID, long? secondRayonID, int counter, bool useArchive)
        {
            // TODO: [ivan] delete this assignment when Iraq statistics will be filled in the DataBase
            counter = 1;
            //
            Utils.CheckNotNullOrEmpty(lang, "lang");
            SetLanguage(manager, lang);

            ReportDateCell.Text = DateTime.Now.ToString("dd/MM/yyyy");

            ShowWarningIfDataInArchive(manager, new DateTime(firstYear, startMonth.HasValue ? startMonth.Value : 1, 1), useArchive);

            BindHeader(firstYear, secondYear, startMonth, endMonth);

            BindYearCells(firstYear, secondYear);

            SetBindingFormats(counter);

            Action<SqlConnection> action = (connection =>
                                                {
                                                    spRepHumComparativeTableAdapter1.Connection = connection;
                                                    spRepHumComparativeTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
                                                    spRepHumComparativeTableAdapter1.CommandTimeout = CommandTimeout;
                                                    comparativeDataSet1.EnforceConstraints = false;

                                                    spRepHumComparativeTableAdapter1.Fill(comparativeDataSet1.spRepHumIQComparative, lang,
                                                                                          firstYear, secondYear, startMonth, endMonth,
                                                                                          firstRegionID, firstRayonID, secondRegionID,
                                                                                          secondRayonID, counter);
                                                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     comparativeDataSet1.spRepHumIQComparative,
                                     useArchive,
                                     new[] {"strDisease"});
            comparativeDataSet1.spRepHumIQComparative.DefaultView.Sort = "intRowNumber";
        }

        private void BindHeader(int firstYear, int secondYear, int? startMonth, int? endMonth)
        {
            string monthRange = string.Empty;
            if (startMonth.HasValue && endMonth.HasValue)
            {
                List<ItemWrapper> monthCollection = BaseDateKeeper.CreateMonthCollection();
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
                string formattedResult = (100*result).ToString("F");
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