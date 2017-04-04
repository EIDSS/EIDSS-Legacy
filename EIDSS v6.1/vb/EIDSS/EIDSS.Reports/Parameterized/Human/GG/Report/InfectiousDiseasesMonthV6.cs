using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
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
    public sealed partial class InfectiousDiseasesMonthV6 : BaseIntervalReport
    {
        private const int MaxCountPerPage = 37;
        private string m_Na = "N/A";
        private int m_CellCounter;
        private bool m_ShowGlobalHeader;

        public InfectiousDiseasesMonthV6()
        {
            InitializeComponent();
            tableCustomHeader.Top = tableBaseHeader.Top;
        }

        public bool ShowGlobalHeader
        {
            get { return m_ShowGlobalHeader; }
            set
            {
                m_ShowGlobalHeader = value;
                InfectiousDiseasesHelper.AjustHeaders(ReportHeader, tableBaseHeader, tableCustomHeader, GroupFooter, ReportFooter, value);
                if (!value)
                {
                    RemoveCells(CustomHeaderTable, CustomHeaderFirstRow, new[] {xrTableCell51, xrTableCell50, xrTableCell42});
                    RemoveCells(CustomHeaderTable, CustomHeaderSecondRow, new[] {xrTableCell63, xrTableCell64, xrTableCell65});
                    RemoveCells(DetailTable, DetailRow, new[] {cellLabTested, cellLabConfirmed, cellTotalConfirmed});
                }
            }
        }

        public void SetParameters( MonthInfectiousDiseaseModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            BindDateCells(model.Year, model.Month);

            SetParameters( (IntermediateInfectiousDiseaseSurrogateModel) model, manager, archiveManager, model.AddSignature);
        }

        public void SetParameters( IntermediateInfectiousDiseaseSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager, bool addSignature = false)
        {
            SetParameters((BaseIntervalModel)model, manager, archiveManager);

            PrintDateTimeLabel.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

            PageFooter.Visible = !ShowGlobalHeader;

            SetLocalizableRowsVisible(model.Language);

            if (!addSignature)
            {
                ChiefFooterCell.DataBindings.Clear();
            }

            m_HeaderDataSet.EnforceConstraints = false;
            m_HeaderAdapter.Connection = (SqlConnection) manager.Connection;
            m_HeaderAdapter.CommandTimeout = CommandTimeout;
            m_HeaderAdapter.Transaction = (SqlTransaction) manager.Transaction;

            m_HeaderAdapter.Fill(
                m_HeaderDataSet.MonthlyHeaderV6,
                model.Language,
                model.RegionId,
                model.RayonId,
                model.SiteId,
                model.UserId);

            if (m_HeaderDataSet.MonthlyHeaderV6.Count > 0)
            {
                InfectiousDiseaseMonthHeaderV6DataSet.MonthlyHeaderV6Row row = m_HeaderDataSet.MonthlyHeaderV6[0];
                if (!row.IsstrNANull())
                {
                    m_Na = row.strNA;
                }
            }
            long customReportType = ShowGlobalHeader ? 10290038 : 10290037;
            m_DataSet.EnforceConstraints = false;
              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.CommandTimeout = CommandTimeout;
                m_Adapter.Transaction = transaction;

                m_Adapter.Fill(
                    m_DataSet.MonthlyV6,
                    model.Language,
                    customReportType,
                    model.StartDate,
                    model.EndDate,
                    model.RegionId,
                    model.RayonId,
                    model.SiteId);
            });
            FillDataTableWithArchive(action,
                BeforeMergeWithArchive,
                manager, archiveManager,
                m_DataSet.MonthlyV6,
                model.Mode,
                new[] { "idfsBaseReference" },
                new []{"intOrder", "strDiseaseName", "strICD10"});
            m_DataSet.MonthlyV6.DefaultView.Sort = "intOrder";

            SetLocation(manager, model, cellLocation);
        }

        private void BeforeMergeWithArchive(DataTable sourceData, DataTable archiveData)
        {
            var source = (InfectiousDiseaseMonthV6DataSet.MonthlyV6DataTable) sourceData;
            var archive = (InfectiousDiseaseMonthV6DataSet.MonthlyV6DataTable) archiveData;

            List<InfectiousDiseaseMonthV6DataSet.MonthlyV6Row> rowsToRemove =
                Enumerable.Where(archive, row => source.FindByidfsBaseReference(row.idfsBaseReference) == null).ToList();

            archive.BeginLoadData();
            foreach (InfectiousDiseaseMonthV6DataSet.MonthlyV6Row row in rowsToRemove)
            {
                archive.Rows.Remove(row);
            }
            archive.EndLoadData();
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

        private void PrintDateTimeLabel_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            e.Cancel = e.PageIndex + 1 < e.PageCount;
        }
    }
}