using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using EIDSS.Reports.Factory;
using bv.model.BLToolkit;
using bv.winclient.Core;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.IQ;
using EIDSS.Reports.BaseControls.Report;
using DistrictsTable = EIDSS.Reports.Parameterized.Human.IQ.DataSet.WeeklyByDistricsDataSet.spRepHumWeeklyDiseasesByDistricsDataTable;
using DistrictRow = EIDSS.Reports.Parameterized.Human.IQ.DataSet.WeeklyByDistricsDataSet.spRepHumWeeklyDiseasesByDistricsRow;

namespace EIDSS.Reports.Parameterized.Human.IQ.Reports
{
    [CanWorkWithArchive]
    public partial class DiseasesByDistrictsReport : BaseIntervalReport
    {
        private const string IdColumnName = "idfsDiagnosisOrReportDiagnosisGroup_";
        private const string DiagnosisColumnName = "strDiagnosisOrReportDiagnosisGroup_";
        private const string ValueColumnName = "intFirstSubcolumn_";

        public DiseasesByDistrictsReport()
        {
            InitializeComponent();
            HideBaseHeader();
        }

        public void SetParameters(SituationOnInfectiousDiseasesSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (model.StartDate.Year < 2000)
            {
                model.StartDate = new DateTime(2000, 01, 01);
                model.EndDate = new DateTime(2000, 01, 02);
                model.PeriodNumber = 1;
            }
            RegionHeaderCell.Text = string.Format(RegionHeaderCell.Text, model.RegionName);
            string yearFormat = model.PeriodType == eidss.model.Enums.StatisticPeriodType.Month
                ? YearForMonthHeaderCell.Text
                : YearHeaderCell.Text;
            YearHeaderCell.Text = string.Format(yearFormat, model.Year);
            WeekHeaderCell.Text = model.PeriodHeaderText;

            SetParameters( (BaseIntervalModel)model, manager, archiveManager);

            ReportDateCell.Text = DateTime.Now.ToString("dd/MM/yyyy");

            DistrictsTable sourceTable = m_DataSet.spRepHumWeeklyDiseasesByDistrics;
              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;
                m_DataSet.EnforceConstraints = false;

                m_Adapter.Fill(sourceTable, model.Language,
                    model.StartDate.ToString("s"),
                    model.EndDate.ToString("s"),
                    model.RegionId,
                    model.UserId);
            });
           

            FillDataTableWithArchive(action,
                BeforeMergeWithArchive,
                 manager, archiveManager,
                sourceTable,
                model.Mode,
                new[] {"idfsRayon"},
                new[] { "intCountReportColumns" });

            int extraCount = sourceTable.Count > 0
               ? sourceTable[0].intCountReportColumns-1
               : 0;

            AddCells(HeaderDynamicTable, HeaderDynamicRow,
                "DynamicDiseaseHeaderCell", "spRepHumWeeklyDiseasesByDistrics." + DiagnosisColumnName,
                extraCount);
            AddCells(DetailDynamicTable, DetailDynamicRow,
                "DynamicTotalDetailCell", "spRepHumWeeklyDiseasesByDistrics." + ValueColumnName,
                extraCount);

            sourceTable.DefaultView.Sort = "strRayon";

            // todo: [ivan] check is there need to swithc RTL in IQ report?
            ReportRtlHelper.SetRTL(this);
        }

        private void BeforeMergeWithArchive(DataTable sourceData, DataTable archiveData)
        {
            var source = (DistrictsTable) sourceData;
            var archive = (DistrictsTable) archiveData;

            if (source.Count == 0 || archive.Count == 0)
            {
                return;
            }

            DistrictRow sourceFirstRow = source[0];
            DistrictRow archiveFirstRow = archive[0];
            int sourceCount = sourceFirstRow.intCountReportColumns;
            int archiveCount = archiveFirstRow.intCountReportColumns;
            if (sourceCount <= 0)
            {
                return;
            }

            var columnsToRemove = new List<DataColumn>();
            for (int i = 1; i < archiveCount+1; i++)
            {
                var id = (long) archiveFirstRow[IdColumnName + i];

                bool isSourceContainsId = false;
                for (int j = 1; j < sourceCount+1; j++)
                {
                    if (id == (long) sourceFirstRow[IdColumnName + j])
                    {
                        isSourceContainsId = true;
                    }
                }
                if (!isSourceContainsId)
                {
                    columnsToRemove.Add(archive.Columns[IdColumnName + i]);
                    columnsToRemove.Add(archive.Columns[DiagnosisColumnName + i]);
                    columnsToRemove.Add(archive.Columns[ValueColumnName + i]);
                }
            }
            archive.BeginInit();
            foreach (var column in columnsToRemove)
            {
                archive.Columns.Remove(column);
            }
            

            for (int i = 1; i < sourceCount+1; i++)
            {
                if (!archive.Columns.Contains(IdColumnName + i))
                {
                    archive.Columns.Add(IdColumnName + i, typeof (long));
                }
                if (!archive.Columns.Contains(DiagnosisColumnName + i))
                {
                    archive.Columns.Add(DiagnosisColumnName + i, typeof(string));
                }
                if (!archive.Columns.Contains(ValueColumnName + i))
                {
                    archive.Columns.Add(ValueColumnName + i, typeof(long));
                }
            }
            archive.EndInit();
        }

        private static void AddCells(XRTable table, XRTableRow row, string cellName, string cellBinding, int count)
        {
            if (count <= 0)
            {
                return;
            }
            try
            {
                ((ISupportInitialize) (table)).BeginInit();
                var resources = new ComponentResourceManager(typeof (DiseasesByDistrictsReport));

                for (int i = 0; i < count; i++)
                {
                    int columnIndex = i + 2;

                    var diseaseCell = new XRTableCell();
                    row.Cells.Add(diseaseCell);

                    diseaseCell.DataBindings.Add(new XRBinding("Text", null, cellBinding + columnIndex));
                    diseaseCell.Name = cellName + columnIndex;
                    diseaseCell.StylePriority.UseBorders = false;
                    diseaseCell.StylePriority.UseTextAlignment = false;
                    resources.ApplyResources(diseaseCell, cellName);
                }

                float topCellWidth = (table.WidthF - row.Cells[0].WidthF) / (count + 1);
                for (int i = 1; i < row.Cells.Count; i++)
                {
                    row.Cells[i].WidthF = topCellWidth;
                }
            }
            finally
            {
                ((ISupportInitialize) (table)).EndInit();
            }
        }
    }
}