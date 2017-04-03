using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing.Printing;
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
    public partial class VetSummaryReport : BaseIntervalReport
    {
        private bool m_IsRegionPrint = true;

        public VetSummaryReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, SummaryByRayonDiagnosisModel model)
        {
            base.SetParameters(manager, model);

            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            DateTimeCell.Text = rebinder.ToDateTimeString(DateTime.Now);
            HeaderLabal.Text = string.Format(HeaderLabal.Text, rebinder.ToDateString(model.StartDate), rebinder.ToDateString(model.EndDate));

            VetSummaryDataSet.spRepVetSummaryAZDataTable sourceTable = m_SummaryDataSet.spRepVetSummaryAZ;
            List<string> diagnosisItems = model.TakeLimitedCheckedItems;
            Action<SqlConnection> action = (connection =>
            {
                m_SummaryAdapter.Connection = connection;
                m_SummaryAdapter.Transaction = (SqlTransaction) manager.Transaction;
                m_SummaryAdapter.CommandTimeout = CommandTimeout;

                m_SummaryDataSet.EnforceConstraints = false;
                string diagnosisXml = FilterHelper.GetXmlFromList(diagnosisItems);
                m_SummaryAdapter.Fill(sourceTable, model.Language,
                    model.StartDate, model.EndDate, diagnosisXml);
            });
            var ignoreName = new List<string> {"intRegionOrder"};
            for (int i = 0; i < diagnosisItems.Count; i++)
            {
                ignoreName.Add("intSpeciesCount_" + (i + 1));
            }
            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                sourceTable,
                model.Mode,
                new[] {"strRegion", "strRayon"}, ignoreName.ToArray());
            sourceTable.DefaultView.Sort = "intRegionOrder, strRegion, strRayon";

            if (sourceTable.Count > 0)
            {
                List<int> speciesCounts = GetSpeciesCounts(sourceTable[0]);

                CreateDinymicTable(speciesCounts);
            }
            DataAdapter = null;
        }

        private List<int> GetSpeciesCounts(VetSummaryDataSet.spRepVetSummaryAZRow firstRow)
        {
            var result = new List<int>();
            if (!firstRow.IsintDiagnosisCountNull())
            {
                for (int i = 0; i < firstRow.intDiagnosisCount; i++)
                {
                    string columnName = "intSpeciesCount_" + (i + 1);
                    if (!firstRow.Table.Columns.Contains(columnName))
                    {
                        throw new ApplicationException(string.Format("Could not find column '{0}' in report data source", columnName));
                    }
                    if (!(firstRow[columnName] is int))
                    {
                        throw new ApplicationException(string.Format("Column '{0}' in report data source should have int values", columnName));
                    }
                    result.Add((int) firstRow[columnName]);
                }
            }
            return result;
        }

        private void CreateDinymicTable(IList<int> speciesCounts)
        {
            try
            {
                ((ISupportInitialize) (HeaderDynamicTable)).BeginInit();
                ((ISupportInitialize) (DetailDynamicTable)).BeginInit();
                ((ISupportInitialize) (SubtotalDynamicTable)).BeginInit();
                ((ISupportInitialize) (TotalDynamicTable)).BeginInit();

                var resources = new ComponentResourceManager(typeof (VetSummaryReport));

                int diagnosisNum = 0;

                foreach (int speciesCount in speciesCounts)
                {
                    diagnosisNum++;

                    CreateDiseaseHeader(resources, diagnosisNum);

                    for (int speciesNum = 1; speciesNum <= speciesCount; speciesNum++)
                    {
                        string suffix = string.Format("_{0}_{1}", diagnosisNum, speciesNum);

                        CreateSpeciesHeader(resources, suffix);

                        CreateSpeciesSubcolumnHeader(resources, suffix);

                        CreateDetailSubcolumn(resources, DetailDynamicTableRow, SummaryRunning.None, suffix,
                            "DynamicFirstDetailCell", "DynamicSecondDetailCell");
                        CreateDetailSubcolumn(resources, SubtotalDynamicTableRow, SummaryRunning.Group, suffix,
                            "DynamicTotalSubtotalCell", "DynamicChildrenSubtotalCell");
                        CreateDetailSubcolumn(resources, TotalDynamicTableRow, SummaryRunning.Report, suffix,
                            "DynamicTotalTotalCell", "DynamicChildrenTotalCell");
                    }
                }

                float totalWidth = DynamicDiseaseHeaderCell.WidthF;

                DynamicTopTableRow.Cells.Remove(DynamicDiseaseHeaderCell);
                DynamicMiddleTableRow.Cells.Remove(DynamicSpeciesHeaderCell);
                DynamicBottomTableRow.Cells.Remove(DynamicFirstHeaderCell);
                DynamicBottomTableRow.Cells.Remove(DynamicSecondHeaderCell);

                DetailDynamicTableRow.Cells.Remove(DynamicFirstDetailCell);
                DetailDynamicTableRow.Cells.Remove(DynamicSecondDetailCell);

                SubtotalDynamicTableRow.Cells.Remove(DynamicTotalSubtotalCell);
                SubtotalDynamicTableRow.Cells.Remove(DynamicChildrenSubtotalCell);

                TotalDynamicTableRow.Cells.Remove(DynamicTotalTotalCell);
                TotalDynamicTableRow.Cells.Remove(DynamicChildrenTotalCell);

                float width = totalWidth / (DynamicBottomTableRow.Cells.Count - 2);

                for (int i = 1; i < SubtotalDynamicTableRow.Cells.Count; i++)
                {
                    SubtotalDynamicTableRow.Cells[i].WidthF = width;
                    TotalDynamicTableRow.Cells[i].WidthF = width;
                }

                for (int i = 2; i < DynamicBottomTableRow.Cells.Count; i++)
                {
                    DynamicBottomTableRow.Cells[i].WidthF = width;
                    DetailDynamicTableRow.Cells[i].WidthF = width;
                }

                for (int i = 2; i < DynamicMiddleTableRow.Cells.Count; i++)
                {
                    DynamicMiddleTableRow.Cells[i].WidthF = 2 * width;
                }

                for (int i = 2; i < DynamicTopTableRow.Cells.Count; i++)
                {
                    DynamicTopTableRow.Cells[i].WidthF = 2 * width * speciesCounts[i - 2];
                }
            }
            finally
            {
                ((ISupportInitialize) (TotalDynamicTable)).EndInit();
                ((ISupportInitialize) (SubtotalDynamicTable)).EndInit();
                ((ISupportInitialize) (DetailDynamicTable)).EndInit();
                ((ISupportInitialize) (HeaderDynamicTable)).EndInit();
            }
        }

        private void CreateDiseaseHeader(ComponentResourceManager resources, int diagnosisNum)
        {
            var diseaseCell = new XRTableCell();
            DynamicTopTableRow.Cells.Add(diseaseCell);
            resources.ApplyResources(diseaseCell, "DynamicDiseaseHeaderCell");
            diseaseCell.DataBindings.Add(new XRBinding("Text", null, "spRepVetSummaryAZ.strDiagnosis_" + diagnosisNum));
            diseaseCell.Name = "DynamicDiseaseHeaderCell_" + diagnosisNum;
            diseaseCell.StylePriority.UseBorders = false;
            diseaseCell.StylePriority.UseTextAlignment = false;
        }

        private void CreateSpeciesHeader(ComponentResourceManager resources, string suffix)
        {
            var speciesCell = new XRTableCell();
            DynamicMiddleTableRow.Cells.Add(speciesCell);
            resources.ApplyResources(speciesCell, "DynamicSpeciesHeaderCell");
            string speciesMember = "spRepVetSummaryAZ.strSpecies" + suffix;
            speciesCell.DataBindings.Add(new XRBinding("Text", null, speciesMember));
            speciesCell.Name = "DynamicSpeciesHeaderCell" + suffix;
        }

        private void CreateSpeciesSubcolumnHeader(ComponentResourceManager resources, string suffix)
        {
            var firstCell = new XRTableCell();
            var secondCell = new XRTableCell();
            DynamicBottomTableRow.Cells.AddRange(new[]
            {
                firstCell,
                secondCell
            });
            resources.ApplyResources(firstCell, "DynamicFirstHeaderCell");
            firstCell.Name = "FirstSubcolumn" + suffix;

            resources.ApplyResources(secondCell, "DynamicSecondHeaderCell");
            secondCell.Name = "SecondSubcolumn" + suffix;
        }

        private static void CreateDetailSubcolumn
            (ComponentResourceManager resources, XRTableRow row, SummaryRunning summary, string suffix,
                string firstCellName, string secondCellName)
        {
            var firstCell = new XRTableCell();
            var secondCell = new XRTableCell();

            row.Cells.AddRange(new[]
            {
                firstCell,
                secondCell
            });

            firstCell.DataBindings.Add(new XRBinding("Text", null, "spRepVetSummaryAZ.intFirstSubcolumn" + suffix));
            resources.ApplyResources(firstCell, firstCellName);
            firstCell.Name = firstCellName + suffix;
            if (summary != SummaryRunning.None)
            {
                firstCell.Summary = new XRSummary {Running = summary};
            }

            secondCell.DataBindings.Add(new XRBinding("Text", null, "spRepVetSummaryAZ.intSecondSubcolumn" + suffix));
            resources.ApplyResources(secondCell, secondCellName);
            secondCell.Name = secondCellName + suffix;
            secondCell.StylePriority.UseBorders = false;
            secondCell.StylePriority.UseTextAlignment = false;
            if (summary != SummaryRunning.None)
            {
                secondCell.Summary = new XRSummary {Running = summary};
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