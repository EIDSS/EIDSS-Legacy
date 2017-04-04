using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public sealed partial class ExternalComparativeReport : BaseReport
    {
        private int m_LineCounter;

        public ExternalComparativeReport()
        {
            InitializeComponent();
        }

        public void SetParameters(ExternalComparativeSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "model.Language");

            m_LineCounter = 0;
            SetLanguage(model, manager);

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year1, 1, 1), model.UseArchive);

            ExternalComparativeDataSet.spRepHumExternalComparativeDataTable table = comparativeDataSet1.spRepHumExternalComparative;
            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                spRepHumExternalComparativeTableAdapter.Connection = connection;
                spRepHumExternalComparativeTableAdapter.Transaction = transaction;
                spRepHumExternalComparativeTableAdapter.CommandTimeout = CommandTimeout;
                comparativeDataSet1.EnforceConstraints = false;

                spRepHumExternalComparativeTableAdapter.Fill(table, model.Language,
                    model.Year1, model.Year2, model.EndMonth,
                    model.RegionId, model.RayonId);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                table,
                model.Mode,
                new[] {"intRowNumber", "strDisease"});
            table.DefaultView.Sort = "intRowNumber";

            BindHeaderCells(model);

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

                row.strTotal_Growth = GetTotalGrowth(row.intTotal_Abs_Y1, row.intTotal_Abs_Y2);

                row.strChildren_Growth = GetTotalGrowth(row.intChildren_Abs_Y1, row.intChildren_Abs_Y2);
            }
        }

        private void BindHeaderCells(ExternalComparativeSurrogateModel model)
        {
//            string admUnitName = string.Empty;
//            if (table.Rows.Count > 0)
//            {
//                var dataRow = (ExternalComparativeDataSet.spRepHumExternalComparativeRow) table.Rows[0];
//                admUnitName = dataRow.strAdministrativeUnit;
//            }

            string location = AddressModel.GetLocation(model.Language,
                EidssMessages.Get("strReportRepublic"),
                model.RegionId, model.RegionName,
                model.RayonId, model.RayonName, true);

            string years = string.Format("{0} - {1}", model.Year2, model.Year1);
            int monthQuantity = model.EndMonth ?? 12;
            HeaderCell.Text = string.Format(HeaderCell.Text, monthQuantity, years, location);

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

        private static string GetTotalGrowth(int t1, int t2)
        {
            string strTotalGrowth;
            if (t1 == 0 || t2 == 0)
            {
                var cases = EidssMessages.Get("strCases", "case(s)");
                // a)
                string sign = string.Empty;
                // b)
                if (t2 > 0)
                {
                    sign = "-";
                }
                // c)
                else if (t1 > 0)
                {
                    sign = "+";
                }
                strTotalGrowth = string.Format("{0}{1} {2}", sign, Math.Max(t1, t2), cases);
            }
            else
            {
                //d)
                if (t1 == t2)
                {
                    strTotalGrowth = "0.00 %";
                }
                //e)
                else if (t2 < t1 && t1 < 2 * t2)
                {
                    strTotalGrowth = string.Format("+{0:0.00} %", 100 * (t1 - t2) / t2);
                }
                //f)
                else if (t2 < 2 * t1 && t1 < t2)
                {
                    strTotalGrowth = string.Format("-{0:0.00} %", 100 * (t2 - t1) / t2);
                }
                //g)
                else if (t1 >= 2 * t2)
                {
                    strTotalGrowth = string.Format("x{0:0.00}", t1 / t2);
                }
                //g)
                else if (2 * t1 <= t2)
                {
                    strTotalGrowth = string.Format("÷{0:0.00}", t2 / t1);
                }
                else
                {
                    strTotalGrowth = "Error. unsupported case.";
                }
            }

            return strTotalGrowth;
        }
    }
}