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
    [NullableAdapters]
    public partial class WhoMeaslesRubellaReport : BaseDateReport
    {
        public WhoMeaslesRubellaReport()
        {
            InitializeComponent();
        }

        public void SetParameters(WhoMeaslesRubellaModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

            BindDateTime(model);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_WhoAdapter.Connection = connection;
                m_WhoAdapter.Transaction = transaction;
                m_WhoAdapter.CommandTimeout = CommandTimeout;
                m_WhoDataSet.EnforceConstraints = false;

                m_WhoAdapter.Fill(m_WhoDataSet.spRepHumWhoMeaslesRubella,
                    model.Language, model.Year, model.Month, model.DiagnosisId);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_WhoDataSet.spRepHumWhoMeaslesRubella,
                model.Mode,
                new[] {"strCaseID"});

            m_WhoDataSet.spRepHumWhoMeaslesRubella.DefaultView.Sort = "datDateOfRashOnset, strCaseID";
        }

        private void BindDateTime(WhoMeaslesRubellaModel model)
        {
            this.RebindDateAndFont(model.Language);

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

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