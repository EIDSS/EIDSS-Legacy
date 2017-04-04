using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class VetLabReport : BaseReport
    {
        private const string TestNamePrefix = "strTestName_";
        private const string TestCountPrefix = "intTest_";
        private const string TempPrefix = "TEMP_";
        private bool m_IsFirstRow = true;
        private bool m_IsPrintGroup = true;
        private int m_DiagnosisCounter;

        public VetLabReport()
        {
            InitializeComponent();
        }

        public void SetParameters(VetLabSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetLanguage(model, manager);

            DateCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);
            ForDateCell.Text = model.Header;

            string location = AddressModel.GetLocation(model.Language,
                m_BaseDataSet.sprepGetBaseParameters[0].CountryName,
                model.RegionId, model.RegionName,
                model.RayonId, model.RayonName);
            if (string.IsNullOrEmpty(model.OrganizationEnteredByName))
            {
                SentByCell.Text = location;
            }
            else
            {
                SentByCell.Text = model.RegionId.HasValue
                    ? string.Format("{0} ({1})", model.OrganizationEnteredByName, location)
                    : model.OrganizationEnteredByName;
            }

            m_DiagnosisCounter = 1;

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_DataAdapter.Connection = connection;
                m_DataAdapter.Transaction = transaction;
                m_DataAdapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;

                m_DataAdapter.Fill(m_DataSet.spRepVetLabReportAZ, model.Language,
                    model.StartDate.ToString("s"), model.EndDate.ToString("s"),
                    model.RegionId, model.RayonId, model.OrganizationEnteredById, model.UserId);
            });
            FillDataTableWithArchive(action, BeforeMergeWithArchive,
                manager, archiveManager,
                m_DataSet.spRepVetLabReportAZ,
                model.Mode,
                new[] {"strDiagnosisSpeciesKey", "strOIECode"},
                new string[0]);

            m_DataSet.spRepVetLabReportAZ.DefaultView.Sort = "DiagniosisOrder, strDiagnosisName, SpeciesOrder, strSpecies";

            IEnumerable<DataColumn> columns = m_DataSet.spRepVetLabReportAZ.Columns.Cast<DataColumn>();

            int testCount = columns.Count(c => c.ColumnName.Contains(TestCountPrefix));

            AddCells(testCount - 1);

            if (m_DataSet.spRepVetLabReportAZ.FirstOrDefault(r => r.idfsDiagnosis < 0) == null)
            {
                RowNumberCell.Text = 1.ToString();
            }
        }

        private void BeforeMergeWithArchive(DataTable sourceData, DataTable archiveData)
        {
            RemoveTestColumnsIfEmpty(sourceData);
            RemoveTestColumnsIfEmpty(archiveData);

            List<string> sourceCaptions = ReportArchiveHelper.GetCaptionsAndAssignToColumns(sourceData, TestNamePrefix);
            List<string> archiveCaptions = ReportArchiveHelper.GetCaptionsAndAssignToColumns(archiveData, TestNamePrefix);

            MergeCaptions(sourceCaptions, archiveCaptions);

            AddMissingColumns(sourceData, sourceCaptions);
            AddMissingColumns(archiveData, sourceCaptions);

            RemoveEmptyRowsIfRealDataExists(archiveData, sourceData);
        }

        internal static void RemoveTestColumnsIfEmpty(DataTable data)
        {
            if (data.Rows.Count == 0)
            {
                List<DataColumn> testColumns = data.Columns
                    .Cast<DataColumn>()
                    .Where(c => c.ColumnName.Contains(TestNamePrefix) || c.ColumnName.Contains(TestCountPrefix))
                    .ToList();

                foreach (DataColumn column in testColumns)
                {
                    data.Columns.Remove(column);
                }
            }
        }

        private static void MergeCaptions(List<string> sourceCaptions, IEnumerable<string> archiveCaptions)
        {
            foreach (string caption in archiveCaptions)
            {
                if (!sourceCaptions.Contains(caption))
                {
                    sourceCaptions.Add(caption);
                }
            }
            sourceCaptions.Sort();
        }

        internal static void AddMissingColumns(DataTable data, List<string> sourceCaptions)
        {
            var columnList = new List<DataColumn>();
            for (int i = 0; i < sourceCaptions.Count; i++)
            {
                string caption = sourceCaptions[i];
                DataColumn testNameColumn = data.Columns
                    .Cast<DataColumn>()
                    .FirstOrDefault(c => c.Caption == caption);

                string tempTestColumnName = TempPrefix + TestNamePrefix + (i + 1);
                string tempCountColumnName = TempPrefix + TestCountPrefix + (i + 1);
                DataColumn testCountColumn;
                if (testNameColumn != null)
                {
                    string oldCountColumnName = testNameColumn.ColumnName.Replace(TestNamePrefix, TestCountPrefix);
                    testCountColumn = data.Columns[oldCountColumnName];

                    testNameColumn.ColumnName = tempTestColumnName;
                    testCountColumn.ColumnName = tempCountColumnName;
                }
                else
                {
                    testNameColumn = data.Columns.Add(tempTestColumnName, typeof (String));
                    testNameColumn.Caption = caption;
                    testCountColumn = data.Columns.Add(tempCountColumnName, typeof (Int32));
                    foreach (DataRow row in data.Rows)
                    {
                        row[testNameColumn] = caption;
                    }
                }
                columnList.Add(testNameColumn);
                columnList.Add(testCountColumn);
            }
            for (int i = columnList.Count - 1; i >= 0; i--)
            {
                DataColumn column = columnList[i];
                column.ColumnName = column.ColumnName.Replace(TempPrefix, string.Empty);
                column.SetOrdinal(data.Columns.Count - columnList.Count + i);
            }
        }

        private void RemoveEmptyRowsIfRealDataExists(DataTable archiveData, DataTable sourceData)
        {
            VetLabReportDataSet.spRepVetLabReportAZRow archiveRow =
                archiveData.Rows.Cast<VetLabReportDataSet.spRepVetLabReportAZRow>().FirstOrDefault(r => r.strDiagnosisSpeciesKey == "1_1");
            VetLabReportDataSet.spRepVetLabReportAZRow sourceRow =
                sourceData.Rows.Cast<VetLabReportDataSet.spRepVetLabReportAZRow>().FirstOrDefault(r => r.strDiagnosisSpeciesKey == "1_1");
            if (archiveRow == null && sourceRow != null)
            {
                sourceData.Rows.Remove(sourceRow);
            }
            if (archiveRow != null && sourceRow == null)
            {
                archiveData.Rows.Remove(archiveRow);
            }
        }

        private void AddCells(int testCount)
        {
            if (testCount <= 0)
            {
                return;
            }

            try
            {
                ((ISupportInitialize) (DetailsDataTable)).BeginInit();
                ((ISupportInitialize) (HeaderDataTable)).BeginInit();
                ((ISupportInitialize) (FooterDataTable)).BeginInit();

                var resources = new ComponentResourceManager(typeof (VetLabReport));

                float cellWidth = TestCountCell_1.WidthF * (float) Math.Pow(14.0 / 15, testCount - 1) / 2;

                TestCountCell_1.WidthF = cellWidth;
                TestCountCell_1.DataBindings.Clear();
                TestCountCell_1.DataBindings.Add(CreateTestCountBinding(testCount + 1));

                TestCountTotalCell_1.WidthF = cellWidth;
                TestCountTotalCell_1.DataBindings.Clear();
                TestCountTotalCell_1.DataBindings.Add(CreateTestCountBinding(testCount + 1));
                TestCountTotalCell_1.Summary.Running = SummaryRunning.Report;

                TestNameHeaderCell_1.WidthF = cellWidth;
                TestNameHeaderCell_1.DataBindings.Clear();
                TestNameHeaderCell_1.DataBindings.Add(CreateTestNameBinding(testCount + 1));

                TestsConductedHeaderCell.WidthF = cellWidth * (testCount + 1);

                for (int i = 0; i < testCount; i++)
                {
                    int columnIndex = i + 1;

                    var testCountCell = new XRTableCell();
                    DetailsDataRow.InsertCell(testCountCell, DetailsDataRow.Cells.Count - 2);
                    resources.ApplyResources(testCountCell, TestCountCell_1.Name);
                    testCountCell.WidthF = cellWidth;
                    testCountCell.DataBindings.Add(CreateTestCountBinding(columnIndex));

                    var testCountTotalCell = new XRTableCell();
                    FooterDataRow.InsertCell(testCountTotalCell, FooterDataRow.Cells.Count - 2);
//                    testCountTotalCell.Text = columnIndex.ToString();
                    resources.ApplyResources(testCountTotalCell, TestCountTotalCell_1.Name);
                    testCountTotalCell.WidthF = cellWidth;
                    testCountTotalCell.DataBindings.Add(CreateTestCountBinding(columnIndex));
                    testCountTotalCell.Summary.Running = SummaryRunning.Report;

                    var testNameCell = new XRTableCell();
                    HeaderDataRow2.InsertCell(testNameCell, HeaderDataRow2.Cells.Count - 2);
                    resources.ApplyResources(testNameCell, TestCountCell_1.Name);
                    testNameCell.WidthF = cellWidth;
                    testNameCell.Angle = 90;
                    testNameCell.DataBindings.Add(CreateTestNameBinding(columnIndex));
                }
            }
            finally
            {
                ((ISupportInitialize) (FooterDataTable)).EndInit();
                ((ISupportInitialize) (HeaderDataTable)).EndInit();
                ((ISupportInitialize) (DetailsDataTable)).EndInit();
            }
        }

        private static XRBinding CreateTestCountBinding(int columnIndex)
        {
            return new XRBinding("Text", null, "spRepVetLabReportAZ." + TestCountPrefix + columnIndex);
        }

        private static XRBinding CreateTestNameBinding(int columnIndex)
        {
            return new XRBinding("Text", null, "spRepVetLabReportAZ." + TestNamePrefix + columnIndex);
        }

        private void GroupFooterDiagnosis_BeforePrint(object sender, PrintEventArgs e)
        {
            m_IsPrintGroup = true;

            m_DiagnosisCounter++;
            RowNumberCell.Text = m_DiagnosisCounter.ToString();
        }

        private void RowNumberCell_BeforePrint(object sender, PrintEventArgs e)
        {
            AjustGroupBorders(RowNumberCell, m_IsPrintGroup);
            AjustGroupBorders(DiseaseCell, m_IsPrintGroup);
            AjustGroupBorders(OIECell, m_IsPrintGroup);

            m_IsPrintGroup = false;

            AjustNonGroupBorders(SpeciesCell);
        }

        private void AjustNonGroupBorders(XRTableCell firstNonGroupCell)
        {
            if (!m_IsFirstRow)
            {
                XRTableCellCollection cells = firstNonGroupCell.Row.Cells;
                for (int i = cells.IndexOf(firstNonGroupCell); i < cells.Count; i++)
                {
                    cells[i].Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
                }
            }
            m_IsFirstRow = false;
        }

        private void AjustGroupBorders(XRTableCell cell, bool isPrinted)
        {
            if (!isPrinted)
            {
                cell.Text = string.Empty;
                cell.Borders = BorderSide.Left | BorderSide.Right;
            }
            else
            {
                cell.Borders = m_DiagnosisCounter > 1
                    ? BorderSide.Left | BorderSide.Top | BorderSide.Right
                    : BorderSide.Left | BorderSide.Right;
            }
        }
    }
}