using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.Factory;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.IQ;
using EIDSS.Reports.BaseControls.Report;
using AgeSexTable =
    EIDSS.Reports.Parameterized.Human.IQ.DataSet.WeeklyByAgeGroupAndSexDataSet.spRepHumWeeklyDiseasesByAgeGroupAndSexDataTable;
using AgeSexRow = EIDSS.Reports.Parameterized.Human.IQ.DataSet.WeeklyByAgeGroupAndSexDataSet.spRepHumWeeklyDiseasesByAgeGroupAndSexRow;

namespace EIDSS.Reports.Parameterized.Human.IQ.Reports
{
    [CanWorkWithArchive]
    public sealed partial class DiseasesByAgeGroupAndSexReport : BaseIntervalReport
    {
        public DiseasesByAgeGroupAndSexReport()
        {
            InitializeComponent();
            HideBaseHeader();
        }

        public void SetParameters
            ( SituationOnInfectiousDiseasesSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
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

            base.SetParameters(model, manager,archiveManager);

            ReportDateCell.Text = DateTime.Now.ToString(SituationOnInfectiousDiseasesSurrogateModel.DateFormat);

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;

                m_Adapter.Fill(m_DataSet.spRepHumWeeklyDiseasesByAgeGroupAndSex,
                    model.Language,
                    model.StartDate.ToString("s"),
                    model.EndDate.ToString("s"),
                    model.RegionId,
                    model.UserId);
            });
            FillDataTableWithArchive(action, BeforeMergeWithArchive,
                 manager, archiveManager,
                m_DataSet.spRepHumWeeklyDiseasesByAgeGroupAndSex,
                model.Mode,
                new[] {"idfsBaseReference", "strDiagnosis"},
                new string[0]);

            m_DataSet.spRepHumWeeklyDiseasesByAgeGroupAndSex.DefaultView.Sort = "intOrder";
                // todo: [ivan] check is there need to swithc RTL in IQ report?
            ReportRtlHelper.SetRTL(this);
        }

        private void BeforeMergeWithArchive(DataTable sourceData, DataTable archiveData)
        {
            var source = (AgeSexTable) sourceData;
            var archive = (AgeSexTable) archiveData;

            List<AgeSexRow> rowsToRemove =
                Enumerable.Where(archive, row => source.FindByidfsBaseReference(row.idfsBaseReference) == null).ToList();

            archive.BeginLoadData();
            foreach (AgeSexRow row in rowsToRemove)
            {
                archive.Rows.Remove(row);
            }
            archive.EndLoadData();
        }
    }
}