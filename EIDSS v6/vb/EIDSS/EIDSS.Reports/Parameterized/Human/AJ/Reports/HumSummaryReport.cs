using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public partial class HumSummaryReport : BaseIntervalReport
    {
        private bool m_IsRegionPrint = true;

        public HumSummaryReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, SummaryByRayonDiagnosisModel model)
        {
            base.SetParameters(manager, model);

            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            DateTimeCell.Text = rebinder.ToDateTimeString(DateTime.Now);

            SummaryDataSet.spRepHumSummaryRayonDiseaseAgeDataTable sourceTable = m_SummaryDataSet.spRepHumSummaryRayonDiseaseAge;
            Action<SqlConnection> action = (connection =>
            {
                m_SummaryAdapter.Connection = connection;
                m_SummaryAdapter.Transaction = (SqlTransaction) manager.Transaction;
                m_SummaryAdapter.CommandTimeout = CommandTimeout;

                m_SummaryDataSet.EnforceConstraints = false;

                string diagnosisXml = FilterHelper.GetXmlFromList(model.TakeLimitedCheckedItems);
                m_SummaryAdapter.Fill(sourceTable, model.Language,
                    model.StartDate, model.EndDate, diagnosisXml);
            });
            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                sourceTable,
                model.Mode,
                new[] {"strRegion", "strRayon"});

            sourceTable.DefaultView.Sort = "intRegionOrder, strRegion, strRayon";
            if (sourceTable.Rows.Count > 0)
            {
                var firstRow = ((SummaryDataSet.spRepHumSummaryRayonDiseaseAgeRow) sourceTable.Rows[0]);

                if (!firstRow.IsblnIsTransportCHENull() && firstRow.blnIsTransportCHE)
                {
                    HeaderLabal.Text = HeaderTransportLabal.Text;
                }
            }
            HeaderLabal.Text = string.Format(HeaderLabal.Text, rebinder.ToDateString(model.StartDate), rebinder.ToDateString(model.EndDate));

            const int nonDynamicColumnCount = 6;
            const int columnsPerOneDiagnosis = 3;
            int dynamicColumnCount = sourceTable.Columns.Count - nonDynamicColumnCount;
            int extraDiagnosisCount = (dynamicColumnCount / columnsPerOneDiagnosis) - 1;

            AddHeaderCells(extraDiagnosisCount);
            AddCells(DetailDynamicTable, DetailDynamicTableRow, SummaryRunning.None, extraDiagnosisCount,
                "DynamicTotalDetailCell", "DynamicChildrenDetailCell");
            AddCells(SubtotalDynamicTable, SubtotalDynamicTableRow, SummaryRunning.Group, extraDiagnosisCount,
                "DynamicTotalSubtotalCell", "DynamicChildrenSubtotalCell");
            AddCells(TotalDynamicTable, TotalDynamicTableRow, SummaryRunning.Report, extraDiagnosisCount,
                "DynamicTotalTotalCell", "DynamicChildrenTotalCell");
            DataAdapter = null;
        }

        private void AddHeaderCells(int diagnosisCount)
        {
            try
            {
                ((ISupportInitialize) (HeaderDynamicTable)).BeginInit();
                var resources = new ComponentResourceManager(typeof (HumSummaryReport));

                for (int i = 0; i < diagnosisCount; i++)
                {
                    int columnIndex = i + 2;

                    var diseaseCell = new XRTableCell();
                    DynamicTopTableRow.Cells.Add(diseaseCell);

                    diseaseCell.DataBindings.Add(new XRBinding("Text", null, "spRepHumSummaryRayonDiseaseAge.strDiagnosis_" + columnIndex));
                    diseaseCell.Name = "DynamicDiseaseHeaderCell" + columnIndex;
                    diseaseCell.StylePriority.UseBorders = false;
                    diseaseCell.StylePriority.UseTextAlignment = false;
                    resources.ApplyResources(diseaseCell, "DynamicDiseaseHeaderCell");

                    var totalCell = new XRTableCell();
                    var childrenCell = new XRTableCell();
                    DynamicBottomTableRow.Cells.AddRange(new[]
                    {
                        totalCell,
                        childrenCell
                    });
                    totalCell.Name = "DynamicTotalHeaderCell" + columnIndex;
                    resources.ApplyResources(totalCell, "DynamicTotalHeaderCell");

                    childrenCell.Name = "Dynamic017HeaderCell" + columnIndex;
                    resources.ApplyResources(childrenCell, "Dynamic017HeaderCell");
                }

                float topCellWidth = DynamicDiseaseHeaderCell.WidthF / (DynamicTopTableRow.Cells.Count - 2);
                float bottomCellWidth = DynamicDiseaseHeaderCell.WidthF / (DynamicBottomTableRow.Cells.Count - 2);
                for (int i = 2; i < DynamicTopTableRow.Cells.Count; i++)
                {
                    DynamicTopTableRow.Cells[i].WidthF = topCellWidth;
                }
                for (int i = 2; i < DynamicBottomTableRow.Cells.Count; i++)
                {
                    DynamicBottomTableRow.Cells[i].WidthF = bottomCellWidth;
                }
            }
            finally
            {
                ((ISupportInitialize) (HeaderDynamicTable)).EndInit();
            }
        }

        private static void AddCells
            (XRTable table, XRTableRow row, SummaryRunning summary, int diagnosisCount,
                string totalCellName, string childrenCellName)
        {
            try
            {
                ((ISupportInitialize) (table)).BeginInit();
                var resources = new ComponentResourceManager(typeof (HumSummaryReport));

                for (int i = 0; i < diagnosisCount; i++)
                {
                    int columnIndex = i + 2;
                    var childrenCell = new XRTableCell();
                    var totalCell = new XRTableCell();
                    row.Cells.AddRange(new[]
                    {
                        totalCell,
                        childrenCell
                    });

                    totalCell.DataBindings.Add(new XRBinding("Text", null, "spRepHumSummaryRayonDiseaseAge.intFirstSubcolumn_" + columnIndex));
                    totalCell.Name = totalCellName + columnIndex;
                    if (summary != SummaryRunning.None)
                    {
                        totalCell.Summary = new XRSummary {Running = summary};
                    }
                    resources.ApplyResources(totalCell, totalCellName);

                    childrenCell.DataBindings.Add(new XRBinding("Text", null,
                        "spRepHumSummaryRayonDiseaseAge.intSecondSubcolumn_" + columnIndex));
                    childrenCell.Name = childrenCellName + columnIndex;
                    childrenCell.StylePriority.UseBorders = false;
                    childrenCell.StylePriority.UseTextAlignment = false;
                    if (summary != SummaryRunning.None)
                    {
                        childrenCell.Summary = new XRSummary {Running = summary};
                    }
                    resources.ApplyResources(childrenCell, childrenCellName);
                }

                float cellWidth = (summary == SummaryRunning.None)
                    ? (row.WidthF - row.Cells[0].WidthF - row.Cells[1].WidthF) / (row.Cells.Count - 2)
                    : (row.WidthF - row.Cells[0].WidthF) / (row.Cells.Count - 1);
                int startPosition = (summary == SummaryRunning.None) ? 2 : 1;
                for (int i = startPosition; i < row.Cells.Count; i++)
                {
                    row.Cells[i].WidthF = cellWidth;
                }
            }
            finally
            {
                ((ISupportInitialize) (table)).EndInit();
            }
        }

        private void RegionGroupCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!m_IsRegionPrint)
            {
                RegionDetailCell.Text = string.Empty;
                RegionDetailCell.Borders = BorderSide.Left | BorderSide.Right;
            }
            else
            {
                RegionDetailCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
            }
            m_IsRegionPrint = false;
        }

        private void SubtotalCell_BeforePrint(object sender, PrintEventArgs e)
        {
            m_IsRegionPrint = true;
        }
    }
}