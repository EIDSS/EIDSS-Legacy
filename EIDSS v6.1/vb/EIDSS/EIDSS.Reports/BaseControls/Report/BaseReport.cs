using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.winclient.Reports;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseReport : XtraReport
    {
        private ReportRebinder m_ReportRebinder;
        protected ClsBarCode m_BarCode = new ClsBarCode();

        public BaseReport()
        {
            AccessRigths = new AccessRigthsRebinder(this);
            InitializeComponent();
            PaperKind = PaperKind.A4;
        }

        [Browsable(true)]
        [DefaultValue(false)]
        public bool CanWorkWithArchive
        {
            get { return CanReportWorkWithArchive(GetType()); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AccessRigthsRebinder AccessRigths { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReportRebinder ReportRebinder
        {
            get
            {
                if (m_ReportRebinder == null)
                {
                    throw new InvalidOperationException("Language is not initialized. Use SetLanguage() before getting this property");
                }
                return m_ReportRebinder;
            }

            private set { m_ReportRebinder = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public XtraReport ChildReport { get; set; }

        [Browsable(false)]
        public static int CommandTimeout
        {
            get { return Config.GetIntSetting("ReportsCommandTimeout", 600); }
        }

        [Browsable(false)]
        protected int DeltaYear
        {
            get { return ModelUserContext.CurrentLanguage == Localizer.lngThai ? 543 : 0; }
        }

        public static bool CanReportWorkWithArchive(Type reportType)
        {
            Utils.CheckNotNull(reportType, "reportType");
            object[] attributes = reportType.GetCustomAttributes(typeof (CanWorkWithArchiveAttribute), true);
            return attributes.Length > 0;
        }

        public void SetLanguage(BaseModel model, DbManagerProxy manager)
        {
            SetLanguage(model.Language, model.PrintDate, model.OrganizationId, model.SiteId, manager);
        }

        protected void SetLanguage(string lang, DateTime printDate, long? organizationId, long? siteId, DbManagerProxy manager)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            cellLanguage.Text = lang;

            ReportRebinder = this.GetDateRebinder(lang);
            ReportRebinder.RebindDateAndFontForReport();

            AccessRigths.Process();

            cellDate.Text = ReportRebinder.ToDateString(printDate);
            cellTime.Text = ReportRebinder.ToTimeString(printDate);

            if (organizationId <= 0)
            {
                organizationId = null;
            }
            m_BaseAdapter.Connection = (SqlConnection) manager.Connection;
            m_BaseAdapter.Transaction = (SqlTransaction) manager.Transaction;
            m_BaseAdapter.CommandTimeout = CommandTimeout;

            m_BaseAdapter.Fill(m_BaseDataSet.sprepGetBaseParameters, lang, organizationId, siteId);
            if (m_BaseDataSet.sprepGetBaseParameters.Count > 0)
            {
                m_BaseDataSet.sprepGetBaseParameters[0].strDateFormat = ReportRebinder.DestFormatNational;
            }

            ReportRtlHelper.SetRTL(this);
        }

        protected void AjustLeftHeaderHeight(int delta)
        {
            tableBaseInnerHeader.Height = cellBaseLeftHeader.Height + delta;
        }

        protected void HideBaseHeader()
        {
            ReportHeader.Controls.Remove(tableBaseHeader);
        }

        #region Fill Data with Archive methods

        public static void FillDataTableWithArchive
            (Action<SqlConnection, SqlTransaction> fillTableAction,
                DbManagerProxy manager, DbManagerProxy archiveManager,
                DataTable dataSource, ReportArchiveMode mode,
                string[] keyName = null, string[] ignoreName = null,
                Dictionary<string, NumAggregateHandler> numFunctions = null,
                Dictionary<string, StrAggregateHanler> strFunctions = null)
        {
            FillDataTableWithArchive(fillTableAction, (table, dataTable) => { },
                manager, archiveManager,
                dataSource, mode, keyName, ignoreName, numFunctions, strFunctions);
        }

        public static void FillDataTableWithArchive
            (Action<SqlConnection, SqlTransaction> fillTableAction, Action<DataTable, DataTable> beforeMergeWithArchive,
                DbManagerProxy manager, DbManagerProxy archiveManager,
                DataTable dataSource, ReportArchiveMode mode, string[] keyName, string[] ignoreName,
                Dictionary<string, NumAggregateHandler> numFunctions = null,
                Dictionary<string, StrAggregateHanler> strFunctions = null)
        {
            if (numFunctions == null)
            {
                numFunctions = new Dictionary<string, NumAggregateHandler>();
            }
            if (strFunctions == null)
            {
                strFunctions = new Dictionary<string, StrAggregateHanler>();
            }
            if (mode != ReportArchiveMode.ActualOnly)
            {
                if (archiveManager == null)
                {
                    throw new ArgumentNullException("archiveManager");
                }
                if (archiveManager.Connection == null)
                {
                    throw new ArgumentException("archiveManager.Connection is NULL");
                }
            }

            switch (mode)
            {
                case ReportArchiveMode.ActualOnly:
                    fillTableAction((SqlConnection) manager.Connection, (SqlTransaction) manager.Transaction);
                    break;
                case ReportArchiveMode.ArchiveOnly:
                    fillTableAction((SqlConnection) archiveManager.Connection, (SqlTransaction) archiveManager.Transaction);
                    break;
                case ReportArchiveMode.ActualWithArchive:
                    fillTableAction((SqlConnection) archiveManager.Connection, (SqlTransaction) archiveManager.Transaction);
                    var archiveData = dataSource.Copy();

                    fillTableAction((SqlConnection) manager.Connection, (SqlTransaction) manager.Transaction);

                    beforeMergeWithArchive(dataSource, archiveData);
                    ArchiveDataHelper.MergeWithArchive(dataSource, archiveData, keyName, ignoreName, numFunctions, strFunctions);
                    break;
            }
            dataSource.AcceptChanges();
        }

        protected void ShowWarningIfDataInArchive(DbManagerProxy manager, DateTime startDate, bool useArchive)
        {
            if (CanWorkWithArchive && !useArchive)
            {
                ArchiveDataHelper.ShowWarningIfDataInArchive(manager, startDate);
            }
        }

        #endregion

        #region Helper methods

        internal static void RemoveCellsExcept(XRTable table, XRTableRow row, IList<XRTableCell> toLeave = null)
        {
            var toDelete = new List<XRTableCell>();
            var widthDictionary = new Dictionary<XRTableCell, float>();
            foreach (XRTableCell cell in row.Cells)
            {
                if (toLeave != null && toLeave.Contains(cell))
                {
                    widthDictionary.Add(cell, cell.WidthF);
                }
                else
                {
                    toDelete.Add(cell);
                }
            }
            if (toDelete.Count > 0)
            {
                ((ISupportInitialize) (table)).BeginInit();

                foreach (XRTableCell cell in toDelete)
                {
                    row.Cells.Remove(cell);
                }
                XRTableCell lastCell = widthDictionary.Keys.Last();
                foreach (KeyValuePair<XRTableCell, float> pair in widthDictionary)
                {
                    if (pair.Key != lastCell)
                    {
                        pair.Key.WidthF = pair.Value;
                    }
                }
                ((ISupportInitialize) (table)).EndInit();
            }
        }

        internal static void RemoveCells(XRTable table, XRTableRow row, IEnumerable<XRTableCell> toDelete)
        {
            if (toDelete != null)
            {
                ((ISupportInitialize) (table)).BeginInit();
                foreach (XRTableCell cell in toDelete)
                {
                    row.Cells.Remove(cell);
                }
                ((ISupportInitialize) (table)).EndInit();
            }
        }

        #endregion
    }
}