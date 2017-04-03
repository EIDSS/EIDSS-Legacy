using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.winclient.Reports;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseReport : XtraReport
    {
        private ReportRebinder m_ReportRebinder;

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
            get { return Config.GetIntSetting("ReportsCommandTimeout", 120); }
        }

        public static bool CanReportWorkWithArchive(Type reportType)
        {
            Utils.CheckNotNull(reportType, "reportType");
            object[] attributes = reportType.GetCustomAttributes(typeof (CanWorkWithArchiveAttribute), true);
            return attributes.Length > 0;
        }

        protected void SetLanguage(DbManagerProxy manager, BaseModel model)
        {
            SetLanguage(manager, model.Language, model.OrganizationId, model.SiteId);
        }

        protected void SetLanguage(DbManagerProxy manager, string lang, long? organizationId, long? siteId)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            cellLanguage.Text = lang;

            ReportRebinder = ReportRebinder.GetDateRebinder(lang, this);
            ReportRebinder.RebindDateAndFontForReport();

            AccessRigths.Process();

            cellDate.Text = ReportRebinder.ToDateString(DateTime.Now);
            cellTime.Text = ReportRebinder.ToTimeString(DateTime.Now);

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
            (Action<SqlConnection> fillTableAction, SqlConnection connection, DataTable dataSource, ReportArchiveMode mode,
                string[] keyName = null, string[] ignoreName = null,
                Dictionary<string, Func<double, double, double>> functionDictionary = null)
        {
            FillDataTableWithArchive(fillTableAction, (table, dataTable) => { },
                connection, dataSource, mode, keyName, ignoreName, functionDictionary);
        }

        public static void FillDataTableWithArchive
            (Action<SqlConnection> fillTableAction, Action<DataTable, DataTable> beforeMergeWithArchive,
                SqlConnection connection, DataTable dataSource, ReportArchiveMode mode, string[] keyName, string[] ignoreName,
                Dictionary<string, Func<double, double, double>> functionDictionary)
        {
            SqlConnection archiveConnection;

            switch (mode)
            {
                case ReportArchiveMode.ActualOnly:
                    fillTableAction(connection);
                    break;
                case ReportArchiveMode.ArchiveOnly:
                    if (ArchiveDataHelper.TryCreateArchiveConnection(out archiveConnection))
                    {
                        using (archiveConnection)
                        {
                            fillTableAction(archiveConnection);
                        }
                    }
                    break;
                case ReportArchiveMode.ActualWithArchive:
                    DataTable archiveData = dataSource.Clone();

                    if (ArchiveDataHelper.TryCreateArchiveConnection(out archiveConnection))
                    {
                        using (archiveConnection)
                        {
                            fillTableAction(archiveConnection);
                        }
                        archiveData = dataSource.Copy();
                    }

                    fillTableAction(connection);

                    beforeMergeWithArchive(dataSource, archiveData);
                    ArchiveDataHelper.MergeWithArchive(dataSource, archiveData,
                        keyName, ignoreName,
                        functionDictionary ?? new Dictionary<string, Func<double, double, double>>());
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
    }
}