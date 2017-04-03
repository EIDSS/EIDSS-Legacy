using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public partial class WhoMeaslesRubellaReport : BaseDateReport
    {
        public WhoMeaslesRubellaReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, WhoMeaslesRubellaModel model)
        {
            base.SetParameters(manager, model);

            BindDateTime(model);

            Action<SqlConnection> action = (connection =>
            {
                m_WhoAdapter.Connection = connection;
                m_WhoAdapter.Transaction = (SqlTransaction) manager.Transaction;
                m_WhoAdapter.CommandTimeout = CommandTimeout;
                m_WhoDataSet.EnforceConstraints = false;

                m_WhoAdapter.Fill(m_WhoDataSet.spRepHumWhoMeaslesRubella,
                    model.Language, model.Year, model.Month, model.DiagnosisId);
            });
            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                m_WhoDataSet.spRepHumWhoMeaslesRubella,
                model.Mode,
                new[] {"strCaseID"});

            m_WhoDataSet.spRepHumWhoMeaslesRubella.DefaultView.Sort = "datDateOfRashOnset, strCaseID";

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }

        private void BindDateTime(WhoMeaslesRubellaModel model)
        {
            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            rebinder.RebindDateAndFontForReport();
            DateTimeCell.Text = rebinder.ToDateTimeString(DateTime.Now);

            if (model.DiagnosisId.HasValue)
            {
                switch (model.DiagnosisId.Value)
                {
                    case WhoMeaslesRubellaModel.MeaslesId:
                        ReportHeaderCell.Text = MeaslesHeaderLabel.Text;
                        break;
                    case WhoMeaslesRubellaModel.RubellaId:
                        ReportHeaderCell.Text = RubellaHeaderLabel.Text;
                        break;
                }
            }
            if (model.Month.HasValue)
            {
                string monthYear = string.Format("{0} {1}", FilterHelper.GetMonthName(model.Month), model.Year);
                ReportHeaderCell.Text = string.Format(ReportHeaderCell.Text, monthYear);
            }
            else
            {
                ReportHeaderCell.Text = string.Format(ReportHeaderCell.Text, model.Year);
            }
        }
    }
}