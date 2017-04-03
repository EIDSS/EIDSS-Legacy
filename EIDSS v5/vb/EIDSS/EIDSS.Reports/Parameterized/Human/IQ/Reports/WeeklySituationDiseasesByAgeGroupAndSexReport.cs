using System;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using eidss.model.Reports.IQ;

namespace EIDSS.Reports.Parameterized.Human.IQ.Reports
{
    public partial class WeeklySituationDiseasesByAgeGroupAndSexReport : BaseIntervalReport
    {
        public WeeklySituationDiseasesByAgeGroupAndSexReport()
        {
            InitializeComponent();
        }

        internal void SetParameters
            (DbManagerProxy manager, WeeklySituationDiseasesModel model)
        {
            WeekHeaderCell.Text = string.Format(WeekHeaderCell.Text, model.WeekText);
            YearHeaderCell.Text = string.Format(YearHeaderCell.Text, model.Year);
            RegionHeaderCell.Text = string.Format(RegionHeaderCell.Text, model.RegionFilter.RegionId);

            SetParameters(manager, (BaseIntervalModel) model);

            ReportDateCell.Text = DateTime.Now.ToString("dd/MM/yyyy");

            Action<SqlConnection> action = (connection =>
                {
                    m_Adapter.Connection = connection;
                    m_Adapter.Transaction = (SqlTransaction)manager.Transaction;
                    m_Adapter.CommandTimeout = CommandTimeout;

                    m_DataSet.EnforceConstraints = false;

                    m_Adapter.Fill(m_DataSet.spRepHumWeeklyDiseasesByAgeGroupAndSex,
                                   model.Language, model.StartDate.ToString("s"), model.EndDate.ToString("s"),
                                   model.RegionFilter.RegionId);
                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     m_DataSet.spRepHumWeeklyDiseasesByAgeGroupAndSex,
                                     model.UseArchive,
                                     new[] {"strDiagnosis"});

            m_DataSet.spRepHumWeeklyDiseasesByAgeGroupAndSex.DefaultView.Sort = "intOrder";
        }
    }
}