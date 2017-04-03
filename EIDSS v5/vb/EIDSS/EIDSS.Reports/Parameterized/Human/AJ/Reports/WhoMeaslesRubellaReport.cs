using System;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class WhoMeaslesRubellaReport : BaseDateReport
    {
        public WhoMeaslesRubellaReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseDateModel model)
        {
            base.SetParameters(manager, model);

            BindDateTime(model);

            Action<SqlConnection> action = (connection =>
                                                {
                                                    m_WhoAdapter.Connection = connection;
                                                    m_WhoAdapter.Transaction = (SqlTransaction)manager.Transaction;
                                                    m_WhoAdapter.CommandTimeout = CommandTimeout;
                                                    m_WhoDataSet.EnforceConstraints = false;

                                                    m_WhoAdapter.Fill(m_WhoDataSet.spRepHumWhoMeaslesRubella, 
                                                        model.Language, model.Year, model.Month);
                                                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     m_WhoDataSet.spRepHumWhoMeaslesRubella,
                                     model.UseArchive,
                                     new[] { "strCaseID" });

            m_WhoDataSet.spRepHumWhoMeaslesRubella.DefaultView.Sort = "datDateOfRashOnset, strCaseID";

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }

        private void BindDateTime(BaseDateModel model)
        {
            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            rebinder.RebindDateAndFontForReport();
            DateTimeCell.Text = rebinder.ToDateTimeString(DateTime.Now);

            if (model.Month.HasValue)
            {
                string monthYear = string.Format("{0} {1}", GetMonthName(model.Month), model.Year);
                ReportHeaderCell.Text = string.Format(ReportHeaderCell.Text, monthYear);
            }
            else
            {
                ReportHeaderCell.Text = string.Format(ReportHeaderCell.Text, model.Year);
            }
        }
    }
}