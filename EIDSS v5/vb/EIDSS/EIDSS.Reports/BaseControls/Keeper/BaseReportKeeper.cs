using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using EIDSS.Reports.BaseControls.Form;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.BaseControls.Transaction;
using EIDSS.Reports.OperationContext;
using bv.common;
using bv.common.Core;
using bv.common.win;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core.CultureInfo;
using eidss.model.Resources;
using ErrorForm = bv.winclient.Core.ErrorForm;
using StandardError = bv.common.Enums.StandardError;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseReportKeeper : UserControl
    {
        private readonly IContextKeeper m_ContextKeeper;
        private readonly LanguageProcessor m_LanguageProcessor;
        private readonly ScreenSaver m_ScreenSaver;

        protected bool m_HasLoad;
        protected int m_ReportMargin;
        protected Dictionary<string, string> m_Parameters;
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (BaseReportKeeper));
        private WaitDialog m_FirstReportRenderWait;
        private DbManagerProxy m_DbManager;

        public BaseReportKeeper()
            : this(new Dictionary<string, string>())
        {
        }

        public BaseReportKeeper(Dictionary<string, string> parameters)
        {
            Utils.CheckNotNull(parameters, "parameters");
            LayoutCorrector.Reset();

            m_ContextKeeper = new ContextKeeper();
            string title = EidssMessages.Get("msgPleaseWait");
            string caption = EidssMessages.Get("msgReportInitializing");
            using (new WaitDialog(caption, title))
            {
                InitializeComponent();

                LayoutCorrector.SetStyleController(cbLanguage, LayoutCorrector.MandatoryStyleController);

                m_ScreenSaver = new ScreenSaver(this, reportView1);

                m_LanguageProcessor = new LanguageProcessor(this);

                InitLanguages();

                m_Parameters = parameters;
            }

        }

       
        [Browsable(true)]
        public int HeaderHeight
        {
            get { return grcTop.Height; }
            set { grcTop.Height = value; }
        }



        [Browsable(false)]
        public IContextKeeper ContextKeeper
        {
            get { return m_ContextKeeper; }
        }

        [Browsable(false)]
        public CultureInfoEx CurrentCulture
        {
            get { return m_LanguageProcessor.CurrentCulture; }
            set { m_LanguageProcessor.CurrentCulture = value; }
        }

        [Browsable(false)]
        public bool UseArchive
        {
            get { return ceUseArchiveData.CheckState == CheckState.Checked; }
        }

        [Browsable(false)]
        protected bool IsResourceLoading { get; set; }

        public void ReloadReportIfFormLoaded(Control sender = null)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }
            if (ContextKeeper.ContainsContext(ContextValue.ReportFormLoading) ||
                ContextKeeper.ContainsContext(ContextValue.ReportLoading) ||
                ContextKeeper.ContainsContext(ContextValue.ReportFilterLoading))
            {
                return;
            }


            if (sender == null)
            {
                ReloadReport(false);
            }
            else
            {
                using (new DisableControlTransaction(sender, ContextKeeper))
                {
                    ReloadReport(false);
                }
            }
        }

        public void ReloadReport(bool isLanguageChanged)
        {
            if (!m_HasLoad || ContextKeeper.ContainsContext(ContextValue.ReportLoading) || WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }
            
            using (ContextKeeper.CreateNewContext(ContextValue.ReportLoading))
            {
                using (new CultureInfoTransaction(CurrentCulture.CultureInfo))
                {
                    try
                    {
                        InitMessageRendering();

                        // set "screensaver" to prevent flicking of report view control during report generation
                        m_ScreenSaver.Screen = (reportView1.Report == null)
                                                   ? m_ScreenSaver.DefaultScreen
                                                   : reportView1;

                        Application.DoEvents();

                        if (isLanguageChanged)
                        {
                            ApplyResources();
                            Application.DoEvents();
                        }
                        if (m_DbManager != null)
                        {
                            m_DbManager.Dispose();
                        }
                        m_DbManager = DbManagerFactory.Factory.Create(ModelUserContext.Instance);

                        BaseReport report = GenerateReport(m_DbManager);
                        reportView1.Report = report;
                        SetUseArchiveDataVisibility(report.CanWorkWithArchive);

                        reportView1.Report.AfterPrint += Report_AfterPrint;
                        // statr timer which shows report if AfterPrint will not fire automatically
                        ShowReportTimer.Start();

                        ApplyPageSettings();

                        if (ContextKeeper.ContainsContext(ContextValue.ReportFirstLoading))
                        {
                            ActiveControl = reportView1;
                        }

                    }
                    catch (SqlException ex)
                    {
                        CreateErrorReport(ex, false);
                        if (!SqlExceptionHandler.Handle(ex))
                        {
                            ErrorForm.ShowError(StandardError.DatabaseError, ex);
                        }
                    }
                    catch (Exception ex)
                    {
                        CreateErrorReport(ex, false);
                        string description = SqlExceptionHandler.GetExceptionDescription(ex);
                        if (string.IsNullOrEmpty(description))
                        {
                            ErrorForm.ShowError(ex);
                        }
                        else
                        {
                            ErrorForm.ShowError(description, description, ex);
                        }
                    }
                }
            }
        }

        private void CreateErrorReport(Exception ex, bool printException)
        {
            Trace.WriteLine(ex);
            reportView1.Report = printException
                                     ? new ErrorReport(ex)
                                     : new ErrorReport();
            Report_AfterPrint(this, EventArgs.Empty);
        }

        protected void ApplyLookupResources(LookUpEdit lookup, List<ItemWrapper> dataSource, int? parameter, string caption)
        {
            int index = -1;
            if (parameter.HasValue)
            {
                index = parameter.Value - 1;
            }

            BindLookup(lookup, dataSource, caption);

            if (index != -1)
            {
                lookup.ItemIndex = index;
                lookup.EditValue = dataSource[index];
            }
            else
            {
                lookup.EditValue = null;
            }
        }

        protected void BindLookup(LookUpEdit lookup, List<ItemWrapper> collection, string caption)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.Columns.Add(new LookUpColumnInfo("NativeName", caption, 200, FormatType.None, "", true, HorzAlignment.Near));

            lookup.Properties.DataSource = collection;
        }

        private void SetUseArchiveDataVisibility(bool canWorkWithArchive)
        {
            ceUseArchiveData.Visible = canWorkWithArchive && ArchiveDataHelper.ShowUseArchiveDataCheckbox;
        }

        private void ApplyPageSettings()
        {
            XtraPageSettingsBase pageSettings = reportView1.Report.PrintingSystem.PageSettings;
            Margins margins = reportView1.Report.Margins;
            pageSettings.RightMargin = margins.Right;
            pageSettings.LeftMargin = margins.Left;
            pageSettings.TopMargin = margins.Top;
            pageSettings.BottomMargin = margins.Bottom;
        }

        private void Report_AfterPrint(object sender, EventArgs e)
        {
            reportView1.Visible = true;
            m_ScreenSaver.Screen = null;
            DisposeMessageRendering();
            if (m_DbManager != null)
            {
                m_DbManager.Dispose();
            }
            ShowReportTimer.Stop();
        }

        private void ShowReportTimer_Tick(object sender, EventArgs e)
        {
            Report_AfterPrint(sender, e);
        }

        private void InitMessageRendering()
        {
            if ((reportView1.Report == null) && (m_FirstReportRenderWait == null))
            {
                string title = EidssMessages.Get("msgPleaseWait");
                string caption = EidssMessages.Get("msgReportRendering");

                if (m_FirstReportRenderWait != null)
                {
                    m_FirstReportRenderWait.Caption = caption;
                }
                else
                {
                    m_FirstReportRenderWait = new WaitDialog(caption, title);
                }
            }
        }

        private void DisposeMessageRendering()
        {
            if (m_FirstReportRenderWait != null)
            {
                m_FirstReportRenderWait.Dispose();
                m_FirstReportRenderWait = null;
            }
        }

        protected virtual void ApplyResources()
        {
            reportView1.ApplyResources();
            if (ParentForm is IReportForm)
            {
                ((IReportForm) ParentForm).ApplyResources();
            }

            int height = HeaderHeight;
            m_Resources.ApplyResources(grcTop, "grcTop");
            HeaderHeight = height;

            ceUseArchiveData.Properties.Caption = m_Resources.GetString("ceUseArchiveData.Properties.Caption");
            //m_Resources.ApplyResources(ceUseArchiveData, "ceUseArchiveData");
            m_Resources.ApplyResources(lblLanguage, "lblLanguage");
            m_Resources.ApplyResources(cbLanguage, "cbLanguage");
            m_Resources.ApplyResources(pnlSettings, "pnlSettings");
            m_Resources.ApplyResources(reportView1, "reportView1");

            LayoutCorrector.ApplySystemFont(this);
        }

        protected virtual BaseReport GenerateReport(DbManagerProxy manager)
        {
            return new BaseReport();
        }

        private void ceUseArchiveData_CheckedChanged(object sender, EventArgs e)
        {
            using (new DisableControlTransaction(ceUseArchiveData, ContextKeeper))
            {
                ReloadReport(false);
            }
        }

        private void cbLanguage_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportLoading))
            {
                e.Cancel = true;
            }
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (new DisableControlTransaction(cbLanguage, ContextKeeper))
            {
                CurrentCulture = (CultureInfoEx) cbLanguage.EditValue;
                ReloadReport(true);
            }
        }

        private void InitLanguages()
        {
            m_LanguageProcessor.InitLanguages();
            cbLanguage.Properties.Columns.Clear();
            string caption = lblLanguage.Text;
            cbLanguage.Properties.Columns.Add(new LookUpColumnInfo("NativeName", caption, 200, FormatType.None,
                                                                   "", true, HorzAlignment.Near));
            cbLanguage.Properties.DataSource = m_LanguageProcessor.LanguageItems;
            cbLanguage.EditValue = CurrentCulture;
        }
    }
}