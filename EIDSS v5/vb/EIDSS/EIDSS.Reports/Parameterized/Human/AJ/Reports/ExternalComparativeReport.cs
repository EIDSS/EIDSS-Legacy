using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
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
            SetLanguage(manager, model.Language);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year1, 1, 1), model.UseArchive);

            ExternalComparativeDataSet.spRepHumExternalComparativeDataTable table = comparativeDataSet1.spRepHumExternalComparative;
            Action<SqlConnection> action = (connection =>
                {
                    spRepHumExternalComparativeTableAdapter.Connection = connection;
                    spRepHumExternalComparativeTableAdapter.Transaction = (SqlTransaction)manager.Transaction;
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
                                     model.UseArchive,
                                     new[] {"intRowNumber", "strDisease"});
            table.DefaultView.Sort = "intRowNumber";

            BindHeaderCells(model, table);

            foreach (ExternalComparativeDataSet.spRepHumExternalComparativeRow row in table.Rows)
            {
                row.strTotal_Growth = row.IsintTotal_Abs_Y1Null() || row.IsintTotal_Abs_Y2Null()
                                          ? "0.00 %"
                                          : GetTotalGrowth(row.intTotal_Abs_Y1, row.intTotal_Abs_Y2);
                row.strChildren_Growth = row.IsintChildren_Abs_Y1Null() || row.IsintChildren_Abs_Y2Null()
                                             ? "0.00 %"
                                             : GetTotalGrowth(row.intChildren_Abs_Y1, row.intChildren_Abs_Y2);
              
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

        private static string GetTotalGrowth(double totalY1, double totalY2)
        {
            string strTotalGrowth = string.Empty;
            if (totalY1 > 0 && totalY2 > 0)
            {
                if (totalY2 >= 2 * totalY1)
                {
                    strTotalGrowth = 'x' + (totalY2 / totalY1).ToString("0.00");
                }
                else if (totalY1 >= 2 * totalY2)
                {
                    strTotalGrowth = 'x' + (totalY1 / totalY2).ToString("0.00");
                }
                else
                {
                    double total = ((totalY2 - totalY1) / totalY1);
                    if (Math.Abs(total) > 0.01)
                    {
                        strTotalGrowth = total.ToString("0.00 %");
                    }
                    else
                    {
                        strTotalGrowth = "0.00 %";
                    }
                    
                }
            }
            return strTotalGrowth;
        }
    }
}