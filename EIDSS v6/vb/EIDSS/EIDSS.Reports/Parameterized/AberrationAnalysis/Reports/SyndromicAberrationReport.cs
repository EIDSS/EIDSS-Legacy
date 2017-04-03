using System;
using System.Data.SqlClient;
using bv.common.Resources;
using bv.model.BLToolkit;
using eidss.model.Reports.AberrationAnalisys;
using EIDSS.Reports.AberrationAnalysis;

namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Reports
{
    public partial class SyndromicAberrationReport : AberrationReport
    {
        public SyndromicAberrationReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, SyndromicAberrationModel model)
        {
            base.SetParameters(manager,  model);

            cellNotificationType.Text = model.NotifTypeText;
            cellSite.Text = model.SiteText;
            cellTimeInterval.Text = model.GetInterval();
            cellLocation.Text = model.Location;
            cellGender.Text = model.GenderText;
            cellAge.Text = model.AgeText;
            cellHospital.Text = model.HospitalText;

            Action<SqlConnection> action = (connection =>
            {
                m_aberrationDataTableAdapter1.Connection = connection;
                m_aberrationDataSet1.EnforceConstraints = false;

                m_aberrationDataTableAdapter1.FillSyndrom(m_aberrationDataSet1.AberrationData, model.Language,
                    model.StartDate.ToString("s"), model.EndDate.ToString("s"),
                    model.TimeIntervalId,
                    model.RegionId, model.RayonId, model.SettlementId,
                    model.Site,
                    model.Gender, model.StartAge, model.EndAge,
                    model.NotifType, model.Hospital,
                    model.DateFilter[0], model.DateFilter[1], model.DateFilter[2]);
            });

            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                m_aberrationDataSet1.AberrationData,
                model.Mode,
                new[] {"date"});

            SetLabel();

            AberrationAlgorithm.Calculate(m_aberrationDataSet1.AberrationData,
                model.Baseline, model.Lag, model.Threshold);
        }
    }
}