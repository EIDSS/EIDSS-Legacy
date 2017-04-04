using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports.AberrationAnalisys;
using EIDSS.Reports.AberrationAnalysis;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Reports
{
    public sealed partial class ILIAberrationReport : AberrationReport
    {
        public ILIAberrationReport()
        {
            InitializeComponent();
        }

        public void SetParameters(ILISyndromicAberrationModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

            cellTimeInterval.Text = model.GetInterval();
            cellLocation.Text = model.Location;
            cellAge.Text = model.AgeGroupText;
            cellHospital.Text = model.HospitalText;

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_aberrationDataTableAdapter1.Connection = connection;
                m_aberrationDataTableAdapter1.Transaction = transaction;
                m_aberrationDataSet1.EnforceConstraints = false;

                m_aberrationDataTableAdapter1.FillILISyndrom(m_aberrationDataSet1.AberrationData, model.Language,
                    model.StartDate.ToString("s"), model.EndDate.ToString("s"),
                    model.AgeGroup,
                    model.RegionId, model.RayonId,
                    model.Hospital);
            });

            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_aberrationDataSet1.AberrationData,
                model.Mode,
                new[] {"date"});

            SetLabel();

            AberrationAlgorithm.Calculate(m_aberrationDataSet1.AberrationData,
                model.Baseline, model.Lag, model.Threshold);

            ReportRtlHelper.SetRTL(this);
        }
    }
}