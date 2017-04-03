using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using eidss.model.Reports.AberrationAnalisys;
using bv.model.BLToolkit;
using EIDSS.Reports.AberrationAnalysis;
using System.Data.SqlClient;

namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Reports
{
    public partial class ILIAberrationReport : EIDSS.Reports.Parameterized.AberrationAnalysis.Reports.AberrationReport
    {
        public ILIAberrationReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, ILISyndromicAberrationModel model)
        {
            base.SetParameters(manager, model);

            cellTimeInterval.Text = model.GetInterval();
            cellLocation.Text = model.Location;
            cellAge.Text = model.AgeGroupText;
            cellHospital.Text = model.HospitalText;

            Action<SqlConnection> action = (connection =>
            {
                m_aberrationDataTableAdapter1.Connection = connection;
                m_aberrationDataSet1.EnforceConstraints = false;

                m_aberrationDataTableAdapter1.FillILISyndrom(m_aberrationDataSet1.AberrationData, model.Language,
                    model.StartDate.ToString("s"), model.EndDate.ToString("s"),
                    model.AgeGroup,
                    model.RegionId, model.RayonId,
                    model.Hospital);
            });

            FillDataTableWithArchive(action,
                (SqlConnection)manager.Connection,
                m_aberrationDataSet1.AberrationData,
                model.Mode,
                new[] { "date" });

            SetLabel();

            AberrationAlgorithm.Calculate(m_aberrationDataSet1.AberrationData,
                model.Baseline, model.Lag, model.Threshold);
        }
    }
}
