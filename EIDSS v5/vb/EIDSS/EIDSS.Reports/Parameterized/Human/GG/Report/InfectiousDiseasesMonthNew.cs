using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.DataSet;
using EIDSS.Reports.Parameterized.Human.GG.DataSet.InfectiousAddressHeaderDataSetTableAdapters;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    public sealed partial class InfectiousDiseasesMonthNew : BaseIntervalReport
    {
        private const int MaxCountPerPage = 37;
        private string m_Na = "N/A";
        private int m_CellCounter;

        public InfectiousDiseasesMonthNew()
        {
            InitializeComponent();
            tableCustomHeader.Top = tableBaseHeader.Top;
        }

        public bool ShowGlobalHeader
        {
            get { return ReportHeader.Visible; }
            set { InfectiousDiseasesHelper.AjustHeaders(ReportHeader, tableBaseHeader, tableCustomHeader, ReportFooter, value); }
        }

        public void SetParameters(DbManagerProxy manager, MonthInfectiousDiseaseModel model)
        {
            BindDateCells(model.Year, model.Month);

            SetParameters(manager, (IntermediateInfectiousDiseaseSurrogateModel) model, model.AddSignature);
        }

        public void SetParameters(DbManagerProxy manager, IntermediateInfectiousDiseaseSurrogateModel model, bool addSignature = false)
        {
            SetParameters(manager, (BaseIntervalModel) model);

            SetLocalizableRowsVisible(model.Language);

            if (!addSignature)
            {
                ChiefFooterCell.DataBindings.Clear();
            }

            InfectiousDiseaseHeaderDataSet.EnforceConstraints = false;
            SpRepHumMonthlyInfectiousDiseaseNewHeaderTableAdapter.Connection = (SqlConnection) manager.Connection;
            SpRepHumMonthlyInfectiousDiseaseNewHeaderTableAdapter.CommandTimeout = CommandTimeout;
            SpRepHumMonthlyInfectiousDiseaseNewHeaderTableAdapter.Transaction = (SqlTransaction)manager.Transaction;

            SpRepHumMonthlyInfectiousDiseaseNewHeaderTableAdapter.Fill(
                InfectiousDiseaseHeaderDataSet.spRepHumMonthlyInfectiousDiseaseNewHeader, model.Language,
                model.RegionId, model.RayonId);
            DataRowCollection rows = InfectiousDiseaseHeaderDataSet.spRepHumMonthlyInfectiousDiseaseNewHeader.Rows;
            if (rows.Count > 0)
            {
                var row = (InfectiousDiseaseMonthNewHeaderDataSet.spRepHumMonthlyInfectiousDiseaseNewHeaderRow) rows[0];
                if (!row.IsstrNANull())
                {
                    m_Na = row.strNA;
                }
            }

            InfectiousDiseaseDataSet.EnforceConstraints = false;
            Action<SqlConnection> action = (connection =>
                {
                    SpRepHumMonthlyInfectiousDiseaseNewTableAdapter.Connection = connection;
                    SpRepHumMonthlyInfectiousDiseaseNewTableAdapter.CommandTimeout = CommandTimeout;
                    SpRepHumMonthlyInfectiousDiseaseNewTableAdapter.Transaction = (SqlTransaction)manager.Transaction;

                    SpRepHumMonthlyInfectiousDiseaseNewTableAdapter.Fill(
                        InfectiousDiseaseDataSet.spRepHumMonthlyInfectiousDiseaseNew,
                        model.Language,
                        model.StartDate,
                        model.EndDate,
                        model.RegionId,
                        model.RayonId);
                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     InfectiousDiseaseDataSet.spRepHumMonthlyInfectiousDiseaseNew,
                                     model.UseArchive,
                                     new[] {"strDiseaseName"});
            InfectiousDiseaseDataSet.spRepHumMonthlyInfectiousDiseaseNew.DefaultView.Sort = "intOrder";

            SetLocation(manager, model, cellLocation);
            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }

        private void BindDateCells(int year, int? month)
        {
            YearFooterCell.Text = DateTime.Now.Year.ToString();
            List<ItemWrapper> monthCollection = BaseDateKeeper.CreateMonthCollection();
            MonthFooterCell.Text = monthCollection[DateTime.Now.Month - 1].ToString();
            DayFooterCell.Text = DateTime.Now.Day.ToString("00");

            string strMonth = (month.HasValue)
                                  ? monthCollection[month.Value - 1].ToString()
                                  : string.Empty;
            cellReportedPeriod.Text = string.Format(cellReportedPeriod.Text, year, strMonth);
        }

        private void SetLocalizableRowsVisible(string lang)
        {
            EnTableRow1.Visible = (lang == Localizer.lngEn);
            EnTableRow2.Visible = (lang == Localizer.lngEn);
            GgTableRow1.Visible = (lang == Localizer.lngGe);
            GgTableRow2.Visible = (lang == Localizer.lngGe);
        }

        internal static void SetLocation
            (DbManagerProxy manager, IntermediateInfectiousDiseaseSurrogateModel model, XRLabel cell)
        {
            var headerDataSet = new InfectiousAddressHeaderDataSet();
            var headerAddressAdapter = new spRepHumInfectiousAddressHeaderTableAdapter
                {Connection = (SqlConnection) manager.Connection};
            headerAddressAdapter.Fill(headerDataSet.spRepHumInfectiousAddressHeader, model.Language,
                                      model.RegionId, model.RayonId);

            if (headerDataSet.spRepHumInfectiousAddressHeader.Count == 0)
            {
                throw new ApplicationException("spRepHumInfectiousAddressHeader returns no rows");
            }
            cell.DataBindings.Clear();
            cell.Text = headerDataSet.spRepHumInfectiousAddressHeader[0].strLocation;
        }

        private void CellBeforePrint(object sender, PrintEventArgs e)
        {
            InfectiousDiseasesHelper.CellBeforePrint(sender, e);
            CellLineBeforePrint(sender);
        }

        private void CellTotalBeforePrint(object sender, PrintEventArgs e)
        {
            if (string.IsNullOrEmpty(cellTotal.Text))
            {
                cellTotal.Text = "0";
            }
            CellLineBeforePrint(sender);
        }

        private void CellLabBeforePrint(object sender, PrintEventArgs e)
        {
            if (!(sender is XRTableCell))
            {
                return;
            }
            var cell = (XRTableCell) sender;

            if (string.IsNullOrEmpty(cell.Text))
            {
                cell.Text = m_Na;
            }
            else if (cell.Text == "0")
            {
                cell.Text = string.Empty;
            }
            CellLineBeforePrint(sender);
        }

        private void NumberingCellBeforePrint(object sender, PrintEventArgs e)
        {
            m_CellCounter++;
            CellLineBeforePrint(sender);
        }

        private void CellLineBeforePrint(object sender)
        {
            if (!(sender is XRTableCell))
            {
                return;
            }

            var cell = (XRTableCell) sender;

            cell.Borders = m_CellCounter == MaxCountPerPage
                               ? BorderSide.All
                               : BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
        }
    }
}