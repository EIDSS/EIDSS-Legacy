using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Core.TranslationTool;
using bv.winclient.Layout;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using eidss.model.Core.CultureInfo;
using eidss.model.Helpers;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls.Form;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.BaseControls.Transaction;
using eidss.winclient.Reports;
using Localizer = bv.common.Core.Localizer;
using Trace = bv.common.Trace;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseReportKeeper : BvXtraUserControl
    {
        private readonly IContextKeeper m_ContextKeeper;
        private readonly LanguageProcessor m_LanguageProcessor;
        private readonly ScreenSaver m_ScreenSaver;
        private bool m_FirstLoad = true;

        protected bool m_HasLoad;

        private static Dictionary<string, string> m_ReportNameDictionary;
        protected Dictionary<string, string> m_Parameters;
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (BaseReportKeeper));
        private WaitDialog m_FirstReportRenderWait;
        private DbManagerProxy m_Manager;
        private DbManagerProxy m_ArchiveManager;
        private readonly string m_ReportAlias;

        public BaseReportKeeper()
            : this(new Dictionary<string, string>())
        {
        }

        public BaseReportKeeper(Dictionary<string, string> parameters)
        {
            Utils.CheckNotNull(parameters, "parameters");
            m_Parameters = parameters;

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
                m_ReportAlias = GetCurrentReportAlias();
                if (!WinUtils.IsComponentInDesignMode(this))
                {
                    ArchiveSqlHelper.InitSqlFactory();
                }
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        public Type ReportType { get; protected set; }

        [Browsable(false)]
        protected bool IsResourceLoading { get; set; }

        [Browsable(false)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected internal bool ReloadReportOnLanguageChanged { get; set; }

        private static Dictionary<string, string> ReportNameDictionary
        {
            get
            {
                if (m_ReportNameDictionary == null)
                {
                    m_ReportNameDictionary = new Dictionary<string, string>();
                    foreach (MethodInfo info in typeof (IReportFactory).GetMethods())
                    {
                        var attribute = (MenuReportDescriptionAttribute)
                            info.GetCustomAttributes(typeof (MenuReportDescriptionAttribute), true).FirstOrDefault();

                        if (attribute != null)
                        {
                            m_ReportNameDictionary.Add(info.Name, attribute.Caption);
                        }
                    }
                }
                return m_ReportNameDictionary;
            }
        }

        protected internal void ReloadReportIfFormLoaded(Control sender = null)
        {
            if (!m_HasLoad ||
                WinUtils.IsComponentInDesignMode(this) ||
                ContextKeeper.ContainsContext(ContextValue.ReportFormLoading) ||
                ContextKeeper.ContainsContext(ContextValue.ReportLoading) ||
                ContextKeeper.ContainsContext(ContextValue.ReportFilterLoading))
            {
                return;
            }

            DisableControlAndReloadReport(sender);
        }

        private void DisableControlAndReloadReport(Control sender)
        {
            if (sender == null)
            {
                ReloadReport();
            }
            else
            {
                using (new DisableControlTransaction(sender, ContextKeeper))
                {
                    ReloadReport();
                }
            }
        }

        private void ReloadReport()
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportLoading))
            {
                bool cultureNotChanged = ModelUserContext.CurrentLanguage == Localizer.GetLanguageID(CurrentCulture.CultureInfo);

                using (new CultureInfoTransaction(CurrentCulture.CultureInfo))
                {
                    try
                    {
                        InitMessageRendering();

                        // set "screensaver" to prevent flicking of report view control during report generation
                        if (!m_FirstLoad)
                        {
                            m_ScreenSaver.Screen = (reportView1.Report == null)
                                ? m_ScreenSaver.DefaultScreen
                                : reportView1;
                        }

                        m_FirstLoad = false;
                        reportView1.ApplyResources();
                        pnlSettings.Enabled = false;
                        Application.DoEvents();

                        if (ValidateMandatoryFields())
                        {
                            int maxAttempts = Math.Max(1, BaseSettings.DeadlockAttemptsCount);
                            for (int attempt = 0; attempt < maxAttempts; attempt++)
                            {
                                try
                                {
                                    if (m_Manager != null)
                                    {
                                        m_Manager.Dispose();
                                    }
                                    m_Manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance);

                                    if (m_ArchiveManager != null)
                                    {
                                        m_ArchiveManager.Dispose();
                                    }
                                    
                                    m_ArchiveManager = DbManagerFactory.Factory[DatabaseType.Archive].Create();

                                    BaseReport report = GenerateReport(m_Manager, m_ArchiveManager);
                                    report.SetAdaptersNull();
                                    reportView1.SetReport(report, cultureNotChanged);
                                    reportView1.Report.AfterPrint += Report_AfterPrint;

                                    break;
                                }
                                catch (SqlException ex)
                                {
                                    if (ex.Number != 1205 || attempt == maxAttempts - 1) //deadlock
                                    {
                                        throw;
                                    }
                                    Thread.Sleep(BaseSettings.DeadlockDelay);
                                }
                            }

                            // start timer which shows report if AfterPrint will not fire automatically
                            ShowReportTimer.Start();

                            ApplyPageSettings();
                        }
                        else
                        {
                            Report_AfterPrint(this, EventArgs.Empty);
                        }

                        var translationView = Parent as ITranslationView;
                        if (translationView != null)
                        {
                            if (translationView.DCManager != null)
                            {
                                translationView.DCManager.ApplyResources();
                            }
                            else
                            {
                                DesignControlManager.Create(translationView);
                            }
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
                        if (String.IsNullOrEmpty(description))
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

        protected virtual BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            return new BaseReport();
        }

        protected object CreateReportObject()
        {
            object reportObject = Activator.CreateInstance(ReportType, 0, null, null, CurrentCulture.CultureInfo);
            return reportObject;
        }

        private void CreateErrorReport(Exception ex, bool printException)
        {
            Trace.WriteLine(ex);
            ErrorReport errorReport = printException
                ? new ErrorReport(ex)
                : new ErrorReport();
            reportView1.SetReport(errorReport, false);
            Report_AfterPrint(this, EventArgs.Empty);
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
            if (!m_HasLoad || WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }
          
            CurrentCulture = (CultureInfoEx) cbLanguage.EditValue;
            using (new CultureInfoTransaction(CurrentCulture.CultureInfo))
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    ApplyResources(manager);
                }
                Application.DoEvents();
            }

            if (ReloadReportOnLanguageChanged && ValidateMandatoryFields(true))
            {
                ReloadReportIfFormLoaded(sender as Control);
            }
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            if (ValidateMandatoryFields(true) && CheckBusinessRules(true))
            {
                ReloadReportIfFormLoaded(sender as Control);
            }
        }

        protected virtual bool CheckBusinessRules(bool printException)
        {
            return true;
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
            pnlSettings.Enabled = true;
            reportView1.Visible = true;
            m_ScreenSaver.Screen = null;
            reportView1.Focus();
            DisposeMessageRendering();
            if (m_Manager != null)
            {
                m_Manager.Dispose();
            }
            if (m_ArchiveManager != null)
            {
                m_ArchiveManager.Dispose();
            }
            ShowReportTimer.Stop();
        }

        private void ShowReportTimer_Tick(object sender, EventArgs e)
        {
            Report_AfterPrint(sender, e);
        }

        private void InitMessageRendering()
        {
            if (m_FirstReportRenderWait == null)
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

        protected internal virtual void ApplyResources(DbManagerProxy manager)
        {
            var reportForm = ParentForm as IReportForm;
            if (reportForm != null)
            {
                reportForm.ApplyResources();

                reportForm.Text = String.Format("{0} - {1}", reportForm.Text, EidssMenu.Get(m_ReportAlias, m_ReportAlias));
            }

            grcTop.Text = m_Resources.GetString("grcTop.Text");
            ceUseArchiveData.Properties.Caption = m_Resources.GetString("ceUseArchiveData.Properties.Caption");
            m_Resources.ApplyResources(lblLanguage, "lblLanguage");
            GenerateReportButton.Text = m_Resources.GetString("GenerateReportButton.Text");

            LayoutCorrector.ApplySystemFont(this);

            SetUseArchiveDataVisibility(BaseReport.CanReportWorkWithArchive(ReportType));
        }

        private static string GetCurrentReportAlias()
        {
            var stack = new StackTrace();
            int frameCount = stack.FrameCount - 1;
            for (int frame = 3; frame <= frameCount; frame++)
            {
                string methodName = stack.GetFrame(frame).GetMethod().Name;
                if (ReportNameDictionary.ContainsKey(methodName))
                {
                    return ReportNameDictionary[methodName];
                }
            }
            return String.Empty;
        }

        private void InitLanguages()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }
            m_LanguageProcessor.InitLanguages();
            cbLanguage.Properties.Columns.Clear();
            string caption = lblLanguage.Text;
            cbLanguage.Properties.Columns.Add(new LookUpColumnInfo("NativeName", caption, 200, FormatType.None,
                "", true, HorzAlignment.Near));
            cbLanguage.Properties.DataSource = m_LanguageProcessor.LanguageItems;
            cbLanguage.EditValue = CurrentCulture;
        }

        protected bool ValidateMandatoryFields(bool showMessage = false)
        {
            bool isValidated = ValidateMandatoryFields(this);
            if (showMessage && !isValidated)
            {
                ErrorForm.ShowWarningFormat("ErrAllMandatoryFieldsRequired", "You must enter data in all mandatory fields.");
            }
            return isValidated;
        }

        private static bool ValidateMandatoryFields(Control parentControl)
        {
            if (parentControl == null)
            {
                return true;
            }

            var parentEdit = parentControl as BaseEdit;
            if (parentEdit != null &&
                parentEdit.Visible &&
                parentEdit.StyleController is MandatoryStyleController &&
                Utils.IsEmpty(parentEdit.Text))
            {
                return false;
            }

            IEnumerable<Control> childControls = parentControl.Controls.Cast<Control>();
            return childControls.All(ValidateMandatoryFields);
        }

        #region Month  and year lookup helper methods

        protected void CorrectSpinEditRange(object sender, SpinEdit fromSpinEdit, SpinEdit toSpinEdit)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }
            if (toSpinEdit.Value < fromSpinEdit.Value)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
                {
                    if (sender == toSpinEdit)
                    {
                        fromSpinEdit.EditValue = toSpinEdit.EditValue;
                    }
                    else
                    {
                        toSpinEdit.EditValue = fromSpinEdit.EditValue;
                    }
                }
            }
        }

        public void CorrectLookupRange(LookUpEdit startLookUp, LookUpEdit endLookUp, MonthLookupEnum lookupEnum)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }
            if (startLookUp.EditValue != null && endLookUp.EditValue != null)
            {
                var startMonth = ((ItemWrapper) (startLookUp.EditValue));
                var endMonth = ((ItemWrapper) (endLookUp.EditValue));
                if (endMonth.Number < startMonth.Number)
                {
                    using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
                    {
                        switch (lookupEnum)
                        {
                            case MonthLookupEnum.Start:
                                endLookUp.EditValue = startLookUp.EditValue;
                                break;
                            case MonthLookupEnum.End:
                                startLookUp.EditValue = endLookUp.EditValue;
                                break;
                            // nothing to do for MonthLookupEnum.None
                        }
                    }
                }
            }
            else
            {
                FillNullLookUpValue(startLookUp, endLookUp);
                FillNullLookUpValue(endLookUp, startLookUp);
            }
        }

        private void FillNullLookUpValue(LookUpEdit startLookUp, LookUpEdit endLookUp)
        {
            if (startLookUp.EditValue != null && endLookUp.EditValue == null)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
                {
                    endLookUp.EditValue = startLookUp.EditValue;
                }
            }
        }

        protected void ClearLookUpButtonClick(object sender, ButtonPressedEventArgs e, params LookUpEdit [] lookUps)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }
            if (e.Button.Kind == ButtonPredefines.Delete && sender is LookUpEdit)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
                {
                    foreach (var lookUpEdit in lookUps)
                    {
                        lookUpEdit.EditValue = null;
                    }
                }
            }
        }

        #endregion
    }
}