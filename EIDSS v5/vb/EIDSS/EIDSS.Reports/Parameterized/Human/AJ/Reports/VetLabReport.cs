using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
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

        public void SetParameters(DbManagerProxy manager, VetLabSurrogateModel model)
        {
            SetLanguage(manager, model.Language);

            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            DateTimeLabel.Text = rebinder.ToDateTimeString(DateTime.Now);
            PeriodCell.Text = model.Header;
            OrganizationCell.Text = model.OrganizationEnteredByName;
            if (string.IsNullOrEmpty(model.OrganizationEnteredByName))
            {
                OrganizationPrefixCell.Text = string.Empty;
            }

            locationCell.Text = LocationHelper.GetLocation(model.Language,
                                                           baseDataSet1.sprepGetBaseParameters[0].CountryName,
                                                           model.RegionId, model.RegionName,
                                                           model.RayonId, model.RayonName);
            m_DiagnosisCounter = 1;

            Action<SqlConnection> action = (connection =>
                {
                    m_DataAdapter.Connection = connection;
                    m_DataAdapter.Transaction = (SqlTransaction)manager.Transaction;
                    m_DataAdapter.CommandTimeout = CommandTimeout;

                    m_DataSet.EnforceConstraints = false;

                    m_DataAdapter.Fill(m_DataSet.spRepVetLabReportAZ, model.Language,
                                       model.StartDate.ToString("s"), model.EndDate.ToString("s"),
                                       model.RegionId, model.RayonId, model.OrganizationEnteredById);
                });
            FillDataTableWithArchive(action, BeforeMergeWithArchive,
                                     (SqlConnection) manager.Connection,
                                     m_DataSet.spRepVetLabReportAZ,
                                     model.UseArchive,
                                     new[] {"strDiagnosisSpeciesKey", "strOIECode"});

            m_DataSet.spRepVetLabReportAZ.DefaultView.Sort = "DiagniosisOrder, strDiagnosisName, SpeciesOrder, strSpecies";

            IEnumerable<DataColumn> columns = m_DataSet.spRepVetLabReportAZ.Columns.Cast<DataColumn>();

            int testCount = columns.Count(c => c.ColumnName.Contains(TestCountPrefix));

            AddCells(testCount - 1);
        }

        private void BeforeMergeWithArchive(DataTable sourceData, DataTable archiveData)
        {
            RemoveTestColumnsIfEmpty(sourceData);
            RemoveTestColumnsIfEmpty(archiveData);

            List<string> sourceCaptions = SetTestNameCaptions(sourceData);
            List<string> archiveCaptions = SetTestNameCaptions(archiveData);

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

        internal static List<string> SetTestNameCaptions(DataTable data)
        {
            var result = new List<string>();
            if (data.Rows.Count > 0)
            {
                IEnumerable<DataColumn> testColumns = data.Columns
                                                          .Cast<DataColumn>()
                                                          .Where(c => c.ColumnName.Contains(TestNamePrefix));
                foreach (DataColumn column in testColumns)
                {
                    column.ReadOnly = false;
                    object firstValue = data.Rows[0][column];
                    if (!Utils.IsEmpty(firstValue))
                    {
                        column.Caption = firstValue.ToString();
                        if (result.Contains(column.Caption))
                        {
                            throw new ApplicationException(string.Format("Duplicate test name {0}", column.Caption));
                        }
                        result.Add(column.Caption);
                    }
                }
            }
            return result;
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

                string tempTestColumnName = TempPrefix + TestNamePrefix + (i + 1).ToString();
                string tempCountColumnName = TempPrefix + TestCountPrefix + (i + 1).ToString();
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
            var archiveRow = archiveData.Rows.Cast<VetLabReportDataSet.spRepVetLabReportAZRow>().FirstOrDefault(r => r.strDiagnosisSpeciesKey == "1_1");
            var sourceRow = sourceData.Rows.Cast<VetLabReportDataSet.spRepVetLabReportAZRow>().FirstOrDefault(r => r.strDiagnosisSpeciesKey == "1_1");
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

                var resources = new ComponentResourceManager(typeof (VetLabReport));

                float cellWidth = TestCountCell_1.WidthF * (float) Math.Pow(14.0 / 15, testCount - 1) / 2;

                TestCountCell_1.WidthF = cellWidth;
                TestCountCell_1.DataBindings.Clear();
                TestCountCell_1.DataBindings.Add(CreateTestCountBinding(testCount + 1));

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

                    var testNameCell = new XRTableCell();
                    HeaderDataRow2.InsertCell(testNameCell, HeaderDataRow2.Cells.Count - 2);

                    resources.ApplyResources(testCountCell, TestCountCell_1.Name);
                    testNameCell.WidthF = cellWidth;
                    testNameCell.Angle = 90;
                    testNameCell.DataBindings.Add(CreateTestNameBinding(columnIndex));
                }
            }
            finally
            {
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