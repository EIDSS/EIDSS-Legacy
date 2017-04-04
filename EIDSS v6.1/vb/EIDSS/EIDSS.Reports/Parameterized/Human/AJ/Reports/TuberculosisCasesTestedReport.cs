using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public sealed partial class TuberculosisCasesTestedReport : BaseReport
    {
        private readonly Dictionary<XRTableCell, IList<XRTableCell>> m_HeaderCellDictionary;

        public TuberculosisCasesTestedReport()
        {
            InitializeComponent();

            m_HeaderCellDictionary = CreateHeaderCellDictionary();
        }

        public void SetParameters(TuberculosisSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            if (model.YearCheckedItems == null || model.YearCheckedItems.Length == 0)
            {
                model.YearCheckedItems = new[] {"2000"};
            }
            ShowWarningIfDataInArchive(manager, new DateTime(model.MinYear, 1, 1), model.UseArchive);

            SetLanguage(model, manager);

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);
            SetHeaderYears(model);
            RemoveUnusedCells(model);

            TuberculosisCasesTestedDataSet.TuberculosisTableDataTable table = m_DataSet.TuberculosisTable;

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;

                m_Adapter.Fill(table,
                    model.Language,
                    model.YearsToXml(), model.StartMonth, model.EndMonth,
                    model.DiagnosisId,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
                 manager, archiveManager,
                table,
                model.Mode,
                new[] {"idfsRayon"},
                new[] {"blnIsTransportCHE", "intRegionOrder"});

            CalculatePercent(table);

            string diagnosis = TuberculosisLabel.Text;
            if (table.Count > 0 && model.DiagnosisId.HasValue)
            {
                diagnosis = table[0].strDiagnosisName;
            }
            BindReportHeader(model, diagnosis);

            ReportRtlHelper.SetRTL(this);
        }

        private void CalculatePercent(IEnumerable<TuberculosisCasesTestedDataSet.TuberculosisTableRow> table)
        {
            const int diagnosisCount = 5;
            var totalTested = new int[diagnosisCount];
            var totalNumber = new int[diagnosisCount];

            foreach (TuberculosisCasesTestedDataSet.TuberculosisTableRow row in table)
            {
                if (row.IsintNumberOfCases_1Null() || row.intNumberOfCases_1 == 0)
                {
                    row.SetintPercentRegistered_1Null();
                }
                else
                {
                    row.intPercentRegistered_1 = (double) row.intTestedForHIV_1 / row.intNumberOfCases_1;
                    totalTested[0] += row.intTestedForHIV_1;
                    totalNumber[0] += row.intNumberOfCases_1;
                }
                if (row.IsintNumberOfCases_2Null() || row.intNumberOfCases_2 == 0)
                {
                    row.SetintPercentRegistered_2Null();
                }
                else
                {
                    row.intPercentRegistered_2 = (double) row.intTestedForHIV_2 / row.intNumberOfCases_2;
                    totalTested[1] += row.intTestedForHIV_2;
                    totalNumber[1] += row.intNumberOfCases_2;
                }
                if (row.IsintNumberOfCases_3Null() || row.intNumberOfCases_3 == 0)
                {
                    row.SetintPercentRegistered_3Null();
                }
                else
                {
                    row.intPercentRegistered_3 = (double) row.intTestedForHIV_3 / row.intNumberOfCases_3;
                    totalTested[2] += row.intTestedForHIV_3;
                    totalNumber[2] += row.intNumberOfCases_3;
                }
                if (row.IsintNumberOfCases_4Null() || row.intNumberOfCases_4 == 0)
                {
                    row.SetintPercentRegistered_4Null();
                }
                else
                {
                    row.intPercentRegistered_4 = (double) row.intTestedForHIV_4 / row.intNumberOfCases_4;
                    totalTested[3] += row.intTestedForHIV_4;
                    totalNumber[3] += row.intNumberOfCases_4;
                }
                if (row.IsintNumberOfCases_5Null() || row.intNumberOfCases_5 == 0)
                {
                    row.SetintPercentRegistered_5Null();
                }
                else
                {
                    row.intPercentRegistered_5 = (double) row.intTestedForHIV_5 / row.intNumberOfCases_5;
                    totalTested[4] += row.intTestedForHIV_5;
                    totalNumber[4] += row.intNumberOfCases_5;
                }
            }
            if (totalNumber[0] != 0)
            {
                TotalPercentCell1.Text = string.Format("{0:P2}", (double) totalTested[0] / totalNumber[0]);
            }
            if (totalNumber[1] != 0)
            {
                TotalPercentCell2.Text = string.Format("{0:P2}", (double)totalTested[1] / totalNumber[1]);
            }
            if (totalNumber[2] != 0)
            {
                TotalPercentCell3.Text = string.Format("{0:P2}", (double)totalTested[2] / totalNumber[2]);
            }
            if (totalNumber[3] != 0)
            {
                TotalPercentCell4.Text = string.Format("{0:P2}", (double)totalTested[3] / totalNumber[3]);
            }
            if (totalNumber[4] != 0)
            {
                TotalPercentCell5.Text = string.Format("{0:P2}", (double)totalTested[4] / totalNumber[4]);
            }
        }

        private void BindReportHeader(TuberculosisSurrogateModel model, string diagnosis)
        {
            Utils.CheckNotNull(model, "model");

            string monthRange = string.Empty;
            if (model.StartMonth.HasValue && model.EndMonth.HasValue)
            {
                List<ItemWrapper> monthCollection = FilterHelper.GetWinMonthList();
                monthRange = model.StartMonth == model.EndMonth
                    ? monthCollection[model.StartMonth.Value - 1].ToString()
                    : string.Format("{0} - {1}", monthCollection[model.StartMonth.Value - 1], monthCollection[model.EndMonth.Value - 1]);
            }

            FirstHeaderCell.Text = string.Format(FirstHeaderCell.Text, diagnosis);
            SecondHeaderCell.Text = string.Format(SecondHeaderCell.Text, model.YearsToString(), monthRange);
        }

        private void SetHeaderYears(TuberculosisSurrogateModel model)
        {
            XRTableCell[] headerCells = m_HeaderCellDictionary.Keys.ToArray();
            int realYearsCount = Math.Min(headerCells.Length, model.YearCheckedItems.Length);
            for (int i = 0; i < realYearsCount; i++)
            {
                headerCells[realYearsCount - i - 1].Text = model.YearCheckedItems[i];
            }
        }

        private void RemoveUnusedCells(TuberculosisSurrogateModel model)
        {
            HeaderTable.BeginInit();
            DetailTable.BeginInit();
            for (int i = m_HeaderCellDictionary.Count - 1; i >= model.YearCheckedItems.Length; i--)
            {
                KeyValuePair<XRTableCell, IList<XRTableCell>> pair = m_HeaderCellDictionary.ElementAt(i);

                foreach (XRTableCell dependedCell in pair.Value)
                {
                    if (dependedCell.Row != null)
                    {
                        dependedCell.Row.Cells.Remove(dependedCell);
                    }
                }
                XRTableCell keyCell = pair.Key;
                if (keyCell.Row != null)
                {
                    keyCell.Row.Cells.Remove(keyCell);
                }
            }

            DetailTable.EndInit();
            HeaderTable.EndInit();
        }

        private Dictionary<XRTableCell, IList<XRTableCell>> CreateHeaderCellDictionary()
        {
            var headerCellDictionary = new Dictionary<XRTableCell, IList<XRTableCell>>
            {
                {
                    HeaderYearCell1, new List<XRTableCell>
                    {
                        HeaderCasesCell1,
                        HeaderTestedCell1,
                        HeaderPercentCell1,
                        CasesCell1,
                        TestedCell1,
                        PercentCell1,
                        TotalCasesCell1,
                        TotalTestedCell1,
                        TotalPercentCell1
                    }
                },
                {
                    HeaderYearCell2, new List<XRTableCell>
                    {
                        HeaderCasesCell2,
                        HeaderTestedCell2,
                        HeaderPercentCell2,
                        CasesCell2,
                        TestedCell2,
                        PercentCell2,
                        TotalCasesCell2,
                        TotalTestedCell2,
                        TotalPercentCell2,
                    }
                },
                {
                    HeaderYearCell3, new List<XRTableCell>
                    {
                        HeaderCasesCell3,
                        HeaderTestedCell3,
                        HeaderPercentCell3,
                        CasesCell3,
                        TestedCell3,
                        PercentCell3,
                        TotalCasesCell3,
                        TotalTestedCell3,
                        TotalPercentCell3,
                    }
                },
                {
                    HeaderYearCell4, new List<XRTableCell>
                    {
                        HeaderCasesCell4,
                        HeaderTestedCell4,
                        HeaderPercentCell4,
                        CasesCell4,
                        TestedCell4,
                        PercentCell4,
                        TotalCasesCell4,
                        TotalTestedCell4,
                        TotalPercentCell4,
                    }
                },
                {
                    HeaderYearCell5, new List<XRTableCell>
                    {
                        HeaderCasesCell5,
                        HeaderTestedCell5,
                        HeaderPercentCell5,
                        CasesCell5,
                        TestedCell5,
                        PercentCell5,
                        TotalCasesCell5,
                        TotalTestedCell5,
                        TotalPercentCell5,
                    }
                }
            };
            return headerCellDictionary;
        }

        //        private void TotalPercentCell_SummaryReset(object sender, EventArgs e)
        //        {
        //            int n = int.Parse(((XRTableCell) sender).Tag.ToString());
        //            m_TotalTested[n] = 0;
        //            m_TotalNumber[n] = 0;
        //        }
        //
        //        private void TotalPercentCell_SummaryRowChanged(object sender, EventArgs e)
        //        {
        //            int n = int.Parse(((XRTableCell) sender).Tag.ToString());
        //            m_TotalTested[n] += Convert.ToInt32(GetCurrentColumnValue(String.Format("intTestedForHIV_{0}", n + 1)));
        //            m_TotalNumber[n] += Convert.ToInt32(GetCurrentColumnValue(String.Format("intNumberOfCases_{0}", n + 1)));
        //        }
        //
        //        private void TotalPercentCell_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        //        {
        //            int n = int.Parse(((XRTableCell) sender).Tag.ToString());
        //            e.Result = m_TotalNumber[n] == 0
        //                ? (object) ""
        //                : (double) m_TotalTested[n] / m_TotalNumber[n];
        //            e.Handled = true;
        //        }

        //        private void PercentCell_BeforePrint(object sender, PrintEventArgs e)
        //        {
        //            if (string.IsNullOrEmpty(((XRTableCell) sender).Text))
        //            {
        //                ((XRTableCell) sender).Text = "";
        //            }
        //        }
    }
}