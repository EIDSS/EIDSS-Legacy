using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public partial class ExternalComparativeReport : BaseReport
    {
        private int m_LineCounter;

        public ExternalComparativeReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, ExternalComparativeSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "model.Language");

            m_LineCounter = 0;
            SetLanguage(manager, model);

            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            DateTimeCell.Text = rebinder.ToDateTimeString(DateTime.Now);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year1, 1, 1), model.UseArchive);

            ExternalComparativeDataSet.spRepHumExternalComparativeDataTable table = comparativeDataSet1.spRepHumExternalComparative;
            Action<SqlConnection> action = (connection =>
            {
                spRepHumExternalComparativeTableAdapter.Connection = connection;
                spRepHumExternalComparativeTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
                spRepHumExternalComparativeTableAdapter.CommandTimeout = CommandTimeout;
                comparativeDataSet1.EnforceConstraints = false;

                spRepHumExternalComparativeTableAdapter.Fill(table, model.Language,
                    model.Year1, model.Year2,
                    model.StartMonth, model.EndMonth,
                    model.RegionId, model.RayonId);
            });
            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                table,
                model.Mode,
                new[] {"intRowNumber", "strDisease"});
            table.DefaultView.Sort = "intRowNumber";

            BindHeaderCells(model, table);

            foreach (ExternalComparativeDataSet.spRepHumExternalComparativeRow row in table.Rows)
            {
                if (row.IsintTotal_Abs_Y1Null())
                {
                    row.intTotal_Abs_Y1 = 0;
                }
                if (row.IsintTotal_Abs_Y2Null())
                {
                    row.intTotal_Abs_Y2 = 0;
                }
                if (row.IsintChildren_Abs_Y1Null())
                {
                    row.intChildren_Abs_Y1 = 0;
                }
                if (row.IsintChildren_Abs_Y2Null())
                {
                    row.intChildren_Abs_Y2 = 0;
                }
                if (row.IsintChildren_Abs_Y2Null())
                {
                    row.intChildren_Abs_Y2 = 0;
                }
                if (row.IsintStatisticsForFirstYearNull())
                {
                    row.intStatisticsForFirstYear = 0;
                }
                if (row.IsintStatisticsForSecondYearNull())
                {
                    row.intStatisticsForSecondYear = 0;
                }
                if (row.IsintStatistics17ForFirstYearNull())
                {
                    row.intStatistics17ForFirstYear = 0;
                }
                if (row.IsintStatistics17ForSecondYearNull())
                {
                    row.intStatistics17ForSecondYear = 0;
                }

                if (row.IsdblChildren_By100000_Y1Null())
                {
                    row.dblChildren_By100000_Y1 = 0;
                }
                if (row.IsdblChildren_By100000_Y2Null())
                {
                    row.dblChildren_By100000_Y2 = 0;
                }
                if (row.IsdblTotal_By100000_Y1Null())
                {
                    row.dblTotal_By100000_Y1 = 0;
                }
                if (row.IsdblTotal_By100000_Y2Null())
                {
                    row.dblTotal_By100000_Y2 = 0;
                }
                if (row.IsintChildren_Abs_Y1Null())
                {
                    row.intChildren_Abs_Y1 = 0;
                }
                if (row.IsintChildren_Abs_Y2Null())
                {
                    row.intChildren_Abs_Y2 = 0;
                }
                if (row.IsintTotal_Abs_Y1Null())
                {
                    row.intTotal_Abs_Y1 = 0;
                }
                if (row.IsintTotal_Abs_Y2Null())
                {
                    row.intTotal_Abs_Y2 = 0;
                }

                row.strTotal_Growth = GetTotalGrowth(row.intTotal_Abs_Y1, row.intTotal_Abs_Y2, row.intStatisticsForFirstYear,
                    row.intStatisticsForSecondYear);

                row.strChildren_Growth = GetTotalGrowth(row.intChildren_Abs_Y1, row.intChildren_Abs_Y2, row.intStatistics17ForFirstYear,
                    row.intStatistics17ForSecondYear);
//                
//                if (row.intTotal_Abs_Y1 > 0 || row.intTotal_Abs_Y2 > 0)
//                {
//
//                    row.strTotal_Growth = row.intTotal_Abs_Y1 == 0 || row.intTotal_Abs_Y2 == 0 ||
//                        row.intStatisticsForFirstYear == 0 ||row.intStatisticsForSecondYear == 0
//                        ? "0.00"
//                        : GetTotalGrowth(row.intTotal_Abs_Y1, row.intTotal_Abs_Y2);
//                }
//                row.strChildren_Growth = row.intChildren_Abs_Y1Null() || row.IsintChildren_Abs_Y2Null()
//                                             ? "0.00 %"
//                                             : GetTotalGrowth(row.intChildren_Abs_Y1, row.intChildren_Abs_Y2);
//               
            }
        }

        private void BindHeaderCells
            (ExternalComparativeSurrogateModel model,
                ExternalComparativeDataSet.spRepHumExternalComparativeDataTable table)
        {
            string admUnitName = string.Empty;
            if (table.Rows.Count > 0)
            {
                var dataRow = (ExternalComparativeDataSet.spRepHumExternalComparativeRow) table.Rows[0];
                admUnitName = dataRow.strAdministrativeUnit;
            }

            string years = string.Format("{0}-{1}", model.Year2, model.Year1);
            int monthQuantity = (model.StartMonth.HasValue && model.EndMonth.HasValue)
                ? model.EndMonth.Value - model.StartMonth.Value + 1
                : 12;
            HeaderCell.Text = string.Format(HeaderCell.Text, monthQuantity, years, admUnitName);

            Header12MonthYear1Cell.Text = string.Format(Header12MonthYear1Cell.Text, monthQuantity, model.Year2);
            Header12MonthYear2Cell.Text = string.Format(Header12MonthYear2Cell.Text, monthQuantity, model.Year1);
        }

        private void DiseaseCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (comparativeDataSet1.spRepHumExternalComparative.Rows.Count > m_LineCounter)
            {
                var row = (ExternalComparativeDataSet.spRepHumExternalComparativeRow)
                    comparativeDataSet1.spRepHumExternalComparative.Rows[m_LineCounter];
                DiseaseCell.TextAlignment = (row.blnIsSubdisease)
                    ? TextAlignment.MiddleRight
                    : TextAlignment.MiddleLeft;
                m_LineCounter++;
            }
        }

        private static string GetTotalGrowth(int t1, int t2, int stat1, int stat2)
        {
            string strTotalGrowth = "0";

            if (t1 > 0 && t2 == 0)
            {
                strTotalGrowth = t1.ToString();
            }
            if (t1 == 0 && t2 > 0)
            {
                strTotalGrowth = t2.ToString();
            }

            if (t1 > 0 && t2 > 0 && stat1 > 0 && stat2 > 0)
            {
                double result = ((t1 * 100000.00 / stat1) * 100.00 /
                                 (t2 * 100000.00 / stat2) - 100.00);
                strTotalGrowth = result > 100
                    ? (result / 100.00).ToString("0.00")
                    : result.ToString("0.00");
            }
            return strTotalGrowth;
        }
    }
}