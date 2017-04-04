using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Reports.TH;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Parameterized.Human.TH.DataSets;

namespace EIDSS.Reports.Parameterized.Human.TH.Reports
{
    public sealed partial class NumberOfCasesDeathsMorbidityMortalityTHReport : BaseIntervalReport
    {
        private int m_Counter;

        public NumberOfCasesDeathsMorbidityMortalityTHReport()
        {
            InitializeComponent();
            HideBaseHeader();
        }

        public void SetParameters(NumberOfCasesDeathsMorbidityMortalityTHModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            base.SetParameters( model, manager, archiveManager);
            m_Counter = 0;

            BindHeder(model);
            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_DataSet.EnforceConstraints = false;

                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_Adapter.Fill(m_DataSet.NumberOfCasesTable,
                    model.Language,
                    model.StartDate,
                    model.EndDate,
                    model.Diagnoses.ToXml(),
                    model.Regions.ToXml(),
                    model.Zones.ToXml(),
                    model.Provinces.ToXml(),
                    model.CaseClassification);
            });

            FillDataTableWithArchive(action,
               manager, archiveManager,
                m_DataSet.NumberOfCasesTable,
                model.Mode,
                new[] {"idfReportingArea"},
                new[] { "intPopulation", "blnIsTotalOrSubtotal", "intOrder", "intOrderTotal" });

            m_DataSet.NumberOfCasesTable.DefaultView.Sort = "intOrderTotal, intOrder";

            ReportRtlHelper.SetRTL(this);
        }

        private void BindHeder(NumberOfCasesDeathsMorbidityMortalityTHModel model)
        {
            string date = (model.StartDate == model.EndDate)
                ? ReportRebinder.ToDateString(model.StartDate)
                : ReportRebinder.ToDateString(model.StartDate) + " - " + ReportRebinder.ToDateString(model.EndDate);
            HeaderCell2.Text = string.Format(HeaderCell2.Text, date);

            if (model.Diagnoses.CheckedItems.Length == 0)
            {
                HeaderRow3.Visible = false;
            }
            else
            {
                HeaderCell3.Text = string.Format(HeaderCell3.Text, model.Diagnoses);
            }
        }

        private void ReportingAreaCell_BeforePrint(object sender, PrintEventArgs e)
        {
            FormatCellAlignment(sender as XRTableCell);
            FormatCellFont(sender as XRTableCell);
        }

        private void CasesCell_BeforePrint(object sender, PrintEventArgs e)
        {
            FormatCellFont(sender as XRTableCell);
        }

        private void MorbidityRateCell_BeforePrint(object sender, PrintEventArgs e)
        {
            FormatCellFont(sender as XRTableCell);
            NumberOfCasesDeathsMorbidityMortalityTHDataSet.NumberOfCasesTableRow row = m_DataSet.NumberOfCasesTable[m_Counter];
            if (!row.IsintPopulationNull())
            {
                MorbidityRateCell.Text = (row.intCases * 100000.0 / row.intPopulation).ToString("0.00");
            }
        }

        private void DeathsCell_BeforePrint(object sender, PrintEventArgs e)
        {
            FormatCellFont(sender as XRTableCell);
        }

        private void CFRCell_BeforePrint(object sender, PrintEventArgs e)
        {
            FormatCellFont(sender as XRTableCell);
            NumberOfCasesDeathsMorbidityMortalityTHDataSet.NumberOfCasesTableRow row = m_DataSet.NumberOfCasesTable[m_Counter];
            if (row.intCases != 0)
            {
                CFRCell.Text = ((double) row.intDeath / row.intCases).ToString("P1");
            }
        }

        private void MortalityRateCell_BeforePrint(object sender, PrintEventArgs e)
        {
            FormatCellFont(sender as XRTableCell);
            NumberOfCasesDeathsMorbidityMortalityTHDataSet.NumberOfCasesTableRow row = m_DataSet.NumberOfCasesTable[m_Counter];
            if (!row.IsintPopulationNull())
            {
                MortalityRateCell.Text = (row.intDeath * 100000.0 / row.intPopulation).ToString("0.00");
            }
        }

        private void PopulationCell_BeforePrint(object sender, PrintEventArgs e)
        {
            FormatCellFont(sender as XRTableCell);
        }

        private void PopulationCell_AfterPrint(object sender, EventArgs e)
        {
            m_Counter++;
        }

        private void FormatCellFont(XRTableCell cell)
        {
            if (cell == null)
            {
                return;
            }
            NumberOfCasesDeathsMorbidityMortalityTHDataSet.NumberOfCasesTableRow row = m_DataSet.NumberOfCasesTable[m_Counter];

            FontStyle fontStyle = row.blnIsTotalOrSubtotal
                ? FontStyle.Bold
                : FontStyle.Regular;
            cell.Font = new Font(cell.Font, fontStyle);
        }

        private void FormatCellAlignment(XRTableCell cell)
        {
            if (cell == null)
            {
                return;
            }
            NumberOfCasesDeathsMorbidityMortalityTHDataSet.NumberOfCasesTableRow row = m_DataSet.NumberOfCasesTable[m_Counter];

            cell.TextAlignment = row.blnIsTotalOrSubtotal
                ? TextAlignment.MiddleCenter
                : TextAlignment.MiddleLeft;
        }
    }
}