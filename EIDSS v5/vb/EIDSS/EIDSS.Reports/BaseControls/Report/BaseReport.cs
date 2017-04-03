using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Enums;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseReport : XtraReport
    {
        private ReportRebinder m_ReportRebinder;

        public BaseReport()
        {
            AccessRigths = new AccessRigthsRebinder(this);
            InitializeComponent();
        }

        [Browsable(true)]
        [DefaultValue(false)]
        //todo [Ivan] Need to be refactored. Should be taken from BaseModel.CanWorkWithArchive
        public bool CanWorkWithArchive { get; set; }

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
        public  static int CommandTimeout
        {
            get { return Config.GetIntSetting("ReportsCommandTimeout", 120); }
        }

        public byte[] ExportToBytes(ReportExportType exportType)
        {
            using (var stream = new MemoryStream())
            {
                switch (exportType)
                {
                    case ReportExportType.Xlsx:
                        ExportToXlsx(stream);
                        break;
                    case ReportExportType.Jpeg:
                        ExportToImage(stream, ImageFormat.Jpeg);
                        break;
                    case ReportExportType.Pdf:
                        ExportToPdf(stream);
                        break;
                    case ReportExportType.Rtf:
                        ExportToRtf(stream);
                        break;
                    default:
                        throw new ArgumentException(string.Format("Unsupported export type {0}", exportType));
                }
                stream.Flush();
                return stream.ToArray();
            }
        }

        protected void SetLanguage(DbManagerProxy manager, string lang, long? organizationId = null)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            cellLanguage.Text = lang;

            ReportRebinder = ReportRebinder.GetDateRebinder(lang, this);
            ReportRebinder.RebindDateAndFontForReport();

            AccessRigths.Process();

            cellDate.Text = ReportRebinder.ToDateString(DateTime.Now);
            cellTime.Text = ReportRebinder.ToTimeString(DateTime.Now);

            sp_rep_BaseParametersTableAdapter.Connection = (SqlConnection) manager.Connection;
            sp_rep_BaseParametersTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
            sp_rep_BaseParametersTableAdapter.CommandTimeout = CommandTimeout;

            sp_rep_BaseParametersTableAdapter.Fill(baseDataSet1.sprepGetBaseParameters, lang, organizationId);
            if (baseDataSet1.sprepGetBaseParameters.Count > 0)
            {
                baseDataSet1.sprepGetBaseParameters[0].strDateFormat = ReportRebinder.DestFormatNational;
            }
        }

        protected void AjustLeftHeaderHeight(int delta)
        {
            tableBaseInnerHeader.Height = cellBaseLeftHeader.Height + delta;
        }

        #region Fill Data with Archive methods

        public static void FillDataTableWithArchive
            (Action<SqlConnection> fillTableAction, SqlConnection connection, DataTable dataSource, bool useArchive, string[] keyName = null)
        {
            FillDataTableWithArchive(fillTableAction, (table, dataTable) => { },
                connection, dataSource, useArchive, keyName);
        }

        public static void FillDataTableWithArchive
            (Action<SqlConnection> fillTableAction, Action<DataTable, DataTable> beforeMergeWithArchive,
                SqlConnection connection, DataTable dataSource, bool useArchive, string[] keyName = null)
        {
            DataTable archiveData = dataSource.Clone();

            if (useArchive)
            {
                SqlConnection archiveConnection;
                if (ArchiveDataHelper.TryCreateArchiveConnection(out archiveConnection))
                {
                    using (archiveConnection)
                    {
                        fillTableAction(archiveConnection);
                    }
                    archiveData = dataSource.Copy();
                }
            }

            fillTableAction(connection);

            if (useArchive)
            {
                beforeMergeWithArchive(dataSource, archiveData);
                ArchiveDataHelper.MergeWithArchive(dataSource, keyName, archiveData);
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