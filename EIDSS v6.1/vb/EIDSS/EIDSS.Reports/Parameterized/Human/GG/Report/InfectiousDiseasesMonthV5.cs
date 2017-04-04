using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.DataSet;
using EIDSS.Reports.Parameterized.Human.GG.DataSet.InfectiousAddressHeaderDataSetTableAdapters;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class InfectiousDiseasesMonthV5 : BaseIntervalReport
    {
        private const int MaxCountPerPage = 37;
        private string m_Na = "N/A";
        private int m_CellCounter;

        public InfectiousDiseasesMonthV5()
        {
            InitializeComponent();
            tableCustomHeader.Top = tableBaseHeader.Top;
        }

        public bool ShowGlobalHeader
        {
            get { return ReportHeader.Visible; }
            set { InfectiousDiseasesHelper.AjustHeaders(ReportHeader, tableBaseHeader, tableCustomHeader, GroupFooter, ReportFooter, value); }
        }

        public void SetParameters(MonthInfectiousDiseaseModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            BindDateCells(model.Year, model.Month);

            SetParameters((IntermediateInfectiousDiseaseSurrogateModel) model, manager, archiveManager, model.AddSignature);
        }

        public void SetParameters
            (IntermediateInfectiousDiseaseSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager,
                bool addSignature = false)
        {
            SetParameters((BaseIntervalModel) model, manager, archiveManager);

            SetLocalizableRowsVisible(model.Language);

            if (!addSignature)
            {
                ChiefFooterCell.DataBindings.Clear();
            }

            InfectiousDiseaseHeaderDataSet.EnforceConstraints = false;
            SpRepHumMonthlyInfectiousDiseaseNewHeaderTableAdapter.Connection = (SqlConnection) manager.Connection;
            SpRepHumMonthlyInfectiousDiseaseNewHeaderTableAdapter.CommandTimeout = CommandTimeout;
            SpRepHumMonthlyInfectiousDiseaseNewHeaderTableAdapter.Transaction = (SqlTransaction) manager.Transaction;

            SpRepHumMonthlyInfectiousDiseaseNewHeaderTableAdapter.Fill(
                InfectiousDiseaseHeaderDataSet.spRepHumMonthlyInfectiousDiseaseNewHeader,
                model.Language,
                model.RegionId,
                model.RayonId,
                model.SiteId,
                model.UserId);
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
            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                SpRepHumMonthlyInfectiousDiseaseNewTableAdapter.Connection = connection;
                SpRepHumMonthlyInfectiousDiseaseNewTableAdapter.CommandTimeout = CommandTimeout;
                SpRepHumMonthlyInfectiousDiseaseNewTableAdapter.Transaction = transaction;

                SpRepHumMonthlyInfectiousDiseaseNewTableAdapter.Fill(
                    InfectiousDiseaseDataSet.spRepHumMonthlyInfectiousDiseaseNew,
                    model.Language,
                    model.StartDate,
                    model.EndDate,
                    model.RegionId,
                    model.RayonId,
                    model.SiteId);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                InfectiousDiseaseDataSet.spRepHumMonthlyInfectiousDiseaseNew,
                model.Mode,
                new[] {"strDiseaseName"});
            InfectiousDiseaseDataSet.spRepHumMonthlyInfectiousDiseaseNew.DefaultView.Sort = "intOrder";

            foreach (
                InfectiousDiseaseMonthNewDataSet.spRepHumMonthlyInfectiousDiseaseNewRow original in
                    InfectiousDiseaseDataSet.spRepHumMonthlyInfectiousDiseaseNew)
            {
                InfectiousDiseaseMonthStringDataSet.TableRow dest = StringDataSet.Table.NewTableRow();
                dest.idfsBaseReference = original.idfsBaseReference;
                dest.strDiseaseName = original.strDiseaseName;
                dest.strICD10 = original.strICD10;
                dest.intAge_0_1 = ConvertOrdinaryCellValue(original.intAge_0_1);
                dest.intAge_1_4 = ConvertOrdinaryCellValue(original.intAge_1_4);
                dest.intAge_5_14 = ConvertOrdinaryCellValue(original.intAge_5_14);
                dest.intAge_15_19 = ConvertOrdinaryCellValue(original.intAge_15_19);
                dest.intAge_20_29 = ConvertOrdinaryCellValue(original.intAge_20_29);
                dest.intAge_30_59 = ConvertOrdinaryCellValue(original.intAge_30_59);
                dest.intAge_60_more = ConvertOrdinaryCellValue(original.intAge_60_more);
                dest.intTotal = original.intTotal.ToString();

                dest.intLabTested = original.IsintLabTestedNull() ? m_Na : ConvertOrdinaryCellValue(original.intLabTested);
                dest.intLabConfirmed = original.IsintLabConfirmedNull() ? m_Na : ConvertOrdinaryCellValue(original.intLabConfirmed);
                dest.intTotalConfirmed = original.IsintTotalConfirmedNull() ? m_Na : ConvertOrdinaryCellValue(original.intTotalConfirmed);

                dest.intOrder = original.intOrder;
                StringDataSet.Table.AddTableRow(dest);
            }

            StringDataSet.Table.DefaultView.Sort = "intOrder";

            SetLocation(manager, model, cellLocation);
        }

        private string ConvertOrdinaryCellValue(double value)
        {
            return Math.Abs(value) < 0.0000001
                ? " "
                : value.ToString();
        }

        private void BindDateCells(int year, int? month)
        {
            YearFooterCell.Text = DateTime.Now.Year.ToString();
            List<ItemWrapper> monthCollection = FilterHelper.GetWinMonthList();
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
            CellLineBeforePrint(sender);
        }

        private void CellLabBeforePrint(object sender, PrintEventArgs e)
        {
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