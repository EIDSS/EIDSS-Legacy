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
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public partial class VetSummaryReport : BaseIntervalReport
    {
        private bool m_IsRegionPrint = true;

        public VetSummaryReport()
        {
            InitializeComponent();
        }

        public void SetParameters(VetSummaryModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

            BindHeader(model);

            VetSummaryDataSet.spRepVetSummaryAZDataTable sourceTable = m_SummaryDataSet.spRepVetSummaryAZ;

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_SummaryAdapter.Connection = connection;
                m_SummaryAdapter.Transaction = transaction;
                m_SummaryAdapter.CommandTimeout = CommandTimeout;

                m_SummaryDataSet.EnforceConstraints = false;

                m_SummaryAdapter.Fill(sourceTable, model);
            });
            var ignoreName = new List<string> {"intRegionOrder", "intSubcolumnCount"};

            FillDataTableWithArchive(action,
                ReportArchiveHelper.RemoveAndAddColumnToArchive,
                manager, archiveManager,
                sourceTable,
                model.Mode,
                new[] {"strRegion", "strRayon"},
                ignoreName.ToArray());
            sourceTable.DefaultView.Sort = "intRegionOrder, strRegion, strRayon";

            CreateDynamicTable(sourceTable, model);
        }

        private void BindHeader(VetSummaryModel model)
        {
            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);
            ReportNameCell.Text = string.Format(ReportNameCell.Text,
                ReportRebinder.ToDateString(model.StartDate),
                ReportRebinder.ToDateString(model.EndDate));
            DiagnosisNameCell.Text = String.Format(DiagnosisNameCell.Text, model.DiagnosisName);
            SurveillanceTypeCell.Text = String.Format(SurveillanceTypeCell.Text, model.SurveillanceTypeName);
            DynamicDiseaseHeaderCell.Text = model.ActionMethodName;
        }

        private void CreateDynamicTable(VetSummaryDataSet.spRepVetSummaryAZDataTable sourceTable, VetSummaryModel model)
        {
            if (sourceTable == null || sourceTable.Count == 0)
            {
                return;
            }

            try
            {
                ((ISupportInitialize) (HeaderDynamicTable)).BeginInit();
                ((ISupportInitialize) (DetailDynamicTable)).BeginInit();
                ((ISupportInitialize) (SubtotalDynamicTable)).BeginInit();
                ((ISupportInitialize) (TotalDynamicTable)).BeginInit();

                var resources = new ComponentResourceManager(typeof (VetSummaryReport));

                bool hideSecondDetail = false;
                if (model.SurveillanceType == VetSummarySurveillanceType.PassiveSurveillanceIndex)
                {
                    DynamicFirstHeaderCell.Text = PassiveFirstLabel.Text;
                    DynamicSecondHeaderCell.Text = PassiveSecondLabel.Text;
                }
                else if (model.SurveillanceType == VetSummarySurveillanceType.AggregateActionsIndex &&
                    sourceTable[0].intSubcolumnCount == 1)
                {
                    hideSecondDetail = true;
                    DynamicFirstHeaderCell.Text = AggregateFirstLabel.Text;
                }

                for (int speciesNum = 1; speciesNum <= model.TakeLimitedCheckedItems.Count; speciesNum++)
                {
                    string suffix = string.Format("_{0}", speciesNum);

                    CreateSpeciesHeader(resources, suffix);

                    CreateSpeciesSubcolumnHeader(resources, suffix);

                    CreateDetailSubcolumn(resources, DetailDynamicTableRow, SummaryRunning.None, suffix,
                        "DynamicFirstDetailCell", "DynamicSecondDetailCell");
                    CreateDetailSubcolumn(resources, SubtotalDynamicTableRow, SummaryRunning.Group, suffix,
                        "DynamicTotalSubtotalCell", "DynamicChildrenSubtotalCell");
                    CreateDetailSubcolumn(resources, TotalDynamicTableRow, SummaryRunning.Report, suffix,
                        "DynamicTotalTotalCell", "DynamicChildrenTotalCell");
                }

                float totalWidth = DynamicDiseaseHeaderCell.WidthF;

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

                float subtotalWidth = width;
                if (hideSecondDetail)
                {
                    subtotalWidth *= 2;
                }

                for (int i = SubtotalDynamicTableRow.Cells.Count-1; i >0 ; i--)
                {
                    SubtotalDynamicTableRow.Cells[i].WidthF = subtotalWidth;
                    TotalDynamicTableRow.Cells[i].WidthF = subtotalWidth;
                    if (hideSecondDetail && i % 2 == 0)
                    {
                        SubtotalDynamicTableRow.Cells.RemoveAt(i);
                        TotalDynamicTableRow.Cells.RemoveAt(i);
                    }

                }
                for (int i = DynamicBottomTableRow.Cells.Count - 1; i > 1; i--)
                {
                    DynamicBottomTableRow.Cells[i].WidthF = subtotalWidth;
                    DetailDynamicTableRow.Cells[i].WidthF = subtotalWidth;
                    if (hideSecondDetail && i % 2 == 1)
                    {
                        DynamicBottomTableRow.Cells.RemoveAt(i);
                        DetailDynamicTableRow.Cells.RemoveAt(i);
                    }
                }

                for (int i = 2; i < DynamicMiddleTableRow.Cells.Count; i++)
                {
                    DynamicMiddleTableRow.Cells[i].WidthF = 2 * width;
                }

                for (int i = 2; i < DynamicTopTableRow.Cells.Count; i++)
                {
                    DynamicTopTableRow.Cells[i].WidthF = 2 * width;
                }

                DynamicDiseaseHeaderCell.WidthF = totalWidth;

                if (model.SurveillanceType != VetSummarySurveillanceType.AggregateActionsIndex)
                {
                    HeaderDynamicTable.Rows.Remove(DynamicTopTableRow);
                    RegionHeaderCell.Borders |= BorderSide.Top;
                    RayonHeaderCell.Borders |= BorderSide.Top;
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
            var firstCell = new XRTableCell {Name = "FirstSubcolumn" + suffix};
            resources.ApplyResources(firstCell, "DynamicFirstHeaderCell");
            firstCell.Text = DynamicFirstHeaderCell.Text;
            firstCell.Angle = DynamicFirstHeaderCell.Angle;

            var secondCell = new XRTableCell {Name = "SecondSubcolumn" + suffix};
            resources.ApplyResources(secondCell, "DynamicSecondHeaderCell");
            secondCell.Text = DynamicSecondHeaderCell.Text;
            secondCell.Angle = DynamicSecondHeaderCell.Angle;
            

            DynamicBottomTableRow.Cells.AddRange(new[]
            {
                firstCell,
                secondCell
            });
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