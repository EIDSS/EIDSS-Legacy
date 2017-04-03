using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using BLToolkit.Data;
using bv.common;
using bv.common.AUM;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources.TranslationTool;
using bv.common.db.Core;
using bv.common.Diagnostics;
using bv.common.win;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;
using DevExpress.XtraBars;
using EIDSS;
using eidss.main.Autolock;
using eidss.main.Login;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.remoting;
using eidss.winclient;
using eidss.winclient.Security;
using ErrorForm = bv.winclient.Core.ErrorForm;
using MessageForm = bv.winclient.Core.MessageForm;
using SiteType = eidss.model.Enums.SiteType;
using Splash = bv.winclient.Core.Splash;
using Timer = System.Timers.Timer;

namespace eidss.main
{
    public partial class MainForm : BvForm, IMainForm
    {
        private static RemoteEventManager m_Server;
        // commented because these fields are never used"
        internal Timer TimerUpdateListener { get; set; }
        internal Timer TimerExit { get; set; }
        internal bool m_Loaded;

        private UpdateMessenger UpdateMessenger { get; set; }

        private const string AppCode = "e";

        public MainForm()
        {
            InitializeComponent();
            BaseFormManager.Init(this);
            BaseFormManager.MainBarManager = barManager1;
            MenuActionManager.Instance = new MenuActionManager(this, barManager1, tbToolbar, EidssUserContext.User) { ItemsStorage = EidssMenu.Instance };
            WindowState = FormWindowState.Maximized;
            Text = WinClientContext.ApplicationCaption;
            ToolTipController.InitTooltipController();
            DefaultBarAndDockingController1.InitBarAppearance();
            tbToolbar.Appearance.InitAppearance();
            Dbg.Debug("Application thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
            DefaultLookAndFeel1.LookAndFeel.SkinName = BaseSettings.SkinName; // "SkinsTest_Money Twins";
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //AUM
            UpdateMessenger = new UpdateMessenger(new ConnectionCredentials());
            TimerUpdateListener = UpdateMessenger.CreateTimerListener();
            TimerUpdateListener.SynchronizingObject = this;
            TimerUpdateListener.Elapsed += TimerUpdateListener_Elapsed;
            TimerExit = UpdateMessenger.CreateTimerExit();
            TimerExit.SynchronizingObject = this;
            TimerExit.Elapsed += TimerExit_Elapsed;
        }

        void TimerExit_Elapsed(object sender, EventArgs e)
        {
            //немедленно завершаем приложение, потому что время на его завершение пользователем истекло
            ExitApp(true);
        }

        void TimerUpdateListener_Elapsed(object sender, EventArgs e)
        {
            if (!UpdateMessenger.CanConnect())
            {
                //if there is no connection, let's check updates more rarely
                TimerUpdateListener.Interval = 100 * 1000;
                return;
            }
            //Restore default listen interval if connection exists
            TimerUpdateListener.Interval = UpdateMessenger.ListenInterval;
            //обновим, что данный экземпляр EIDSS ещё живёт
            UpdateMessenger.CreateRunningApps(ModelUserContext.ClientID, AppCode);
            //проверяем не начался ли апдейт
            //апдейт можно игнорировать, если соблюдаются те же бизнес-правила, что и для старта приложения

            if (!UpdateMessenger.CanRunApplication(ModelUserContext.ClientID, AppCode))
            {
                //отключаем один таймер и включаем другой, который через 10 минут принудительно выключит приложение
                TimerUpdateListener.Enabled = false;
                TimerExit.Enabled = true;
                ErrorForm.ShowMessageDirect(EidssMessages.Get("ApplicationMustBeClosed"));
            }
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private static bool m_AskForExit = true;

        private static bool m_WasExit;

        public static void ExitApp(bool forceExit)
        {
            //delete record from journal
            if (!(m_WasExit) && BaseFormManager.MainForm != null)
            {
                ((MainForm)BaseFormManager.MainForm).UpdateMessenger.DeleteRunningApps(ModelUserContext.ClientID, AppCode);
            }

            //SecurityLog.WriteToEventLogWindows(BvMessages.Get("SecurityLog_EIDSS_finished_successfully"), , EventLogEntryType.Information)
            if (!(m_WasExit))
            {
                SecurityLog.WriteToEventLogDB(EidssUserContext.User.ID, SecurityAuditEvent.ProcessStop, true,
                                              "EIDSS is stopped", null, "EIDSS is stopped",
                                              SecurityAuditProcessType.Eidss);
                m_WasExit = true;
            }

            m_AskForExit = false;
            if (forceExit)
            {
                Application.Exit();
            }
        }

        #region Actions registration

        private MenuActionManager m_MenuManager;
        private MenuAction m_LanguageMenu;

        public void RegisterActions()
        {
            if (m_MenuManager == null)
            {
                m_MenuManager = MenuActionManager.Instance;
            }
            m_MenuManager.Clear();
            m_MenuManager.LoadAssemblyActions(WinUtils.AppPath() + "\\bvwin_common.dll");
            string[] files = Directory.GetFiles((WinUtils.AppPath()), "eidss*.dll");
            foreach (string file in files)
            {
                m_MenuManager.LoadAssemblyActions(file);
            }
            m_MenuManager.LoadAssemblyActions(WinUtils.AppPath() + "\\eidss.main.exe");

            RegisterDefaultActions();
            m_MenuManager.DisplayActions();
        }

        public void RegisterDefaultActions()
        {

            new MenuAction(ChangeUser, m_MenuManager, m_MenuManager.File, "MenuChangeUser", 100, false,
                           (int)MenuIconsSmall.SwitchUser);
            if (BaseFormManager.ArchiveMode || EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanReadArchivedData)))
            {
                var archiveConnectionCredentials = new ConnectionCredentials(null, "Archive");
                if (BaseFormManager.ArchiveMode || archiveConnectionCredentials.IsCorrect)
                    new MenuAction(ConnectToArchive, m_MenuManager, m_MenuManager.File, "MenuConnectToArchive", 101) { IsCheckBoxAction = true };
            }
            new MenuAction(m_MenuManager, m_MenuManager.File, "MenuSeparator", 103);
            new MenuAction(CloseForm, m_MenuManager, m_MenuManager.File, "MenuExit", 104, false,
                           (int)MenuIconsSmall.Exit);
            new MenuAction(HelpContext, m_MenuManager, m_MenuManager.Help, "MenuContents", 1000, false,
                           (int)MenuIconsSmall.Help, (int)MenuIconsSmall.Help) { BeginGroup = true };
            new MenuAction(HelpContext, m_MenuManager, m_MenuManager.System, "MenuHelp", 100410, true,
                           (int)MenuIcons.Help, (int)MenuIcons.Help)
                {
                    ShowInMenu = false
                };
            new MenuAction(About, m_MenuManager, m_MenuManager.Help, "MenuHelpAbout", 100010); //

            if (BaseForm.ReplicationNeeded)
            {
                new MenuAction(ReplicationRequested, m_MenuManager, m_MenuManager.System, "MenuRequestReplication",
                               900, false, (int) MenuIconsSmall.ReplicateData, -1)
                    {
                        SelectPermission = PermissionHelper.ExecutePermission(EIDSSPermissionObject.ReplicateData)
                    };
            }
            new MenuAction(m_MenuManager, m_MenuManager.System, "MenuReferencies", 950, false, (int)MenuIconsSmall.References) { BeginGroup = true };
            new MenuAction(m_MenuManager, m_MenuManager.System, "MenuAdministration", 970) { BeginGroup = true };
            //Toolbar menu
            m_LanguageMenu = new MenuAction(m_MenuManager, m_MenuManager.System, "MenuLanguage", 100400, true) { BeginGroup = true };

            foreach (var lang in Localizer.SupportedLanguages)
            {
                if (lang.Key == Localizer.lngEn)
                {
                    new MenuAction(SetEnglishLanguage, m_MenuManager, m_LanguageMenu, "MenuEnglish",
                                                     900, false, (int)MenuIconsSmall.English, (int)MenuIcons.English)
                                          {
                                              Caption = Localizer.GetMenuLanguageName(Localizer.lngEn)
                                          };
                }
                else if (lang.Key == Localizer.lngRu)
                {
                    new MenuAction(SetRussianLanguage, m_MenuManager, m_LanguageMenu, "MenuRussian",
                                                     925, false, (int)MenuIconsSmall.Russian, (int)MenuIcons.Russian)
                                          {
                                              Caption = Localizer.GetMenuLanguageName(Localizer.lngRu)
                                          };
                }
                else if (lang.Key == Localizer.lngGe)
                {
                    new MenuAction(SetGeorgianLanguage, m_MenuManager, m_LanguageMenu, "MenuGeorgian",
                                                     915, false, (int)MenuIconsSmall.Georgian, (int)MenuIcons.Georgian)
                                          {
                                              Caption = Localizer.GetMenuLanguageName(Localizer.lngGe)
                                          };
                }
                else if (lang.Key == Localizer.lngAzLat)
                {
                    new MenuAction(SetAzeriLanguageLat, m_MenuManager, m_LanguageMenu, "MenuAzeriLat", 910,
                                   false, (int)MenuIconsSmall.Azery, (int)MenuIcons.Azery)
                        {
                            Caption = Localizer.GetMenuLanguageName(Localizer.lngAzLat)
                        };
                }
                else if (lang.Key == Localizer.lngKz)
                {
                    new MenuAction(SetKazakhLanguage, m_MenuManager, m_LanguageMenu, "MenuKazakh", 920,
                                   false, (int)MenuIconsSmall.Kazakhstan, (int)MenuIcons.Kazakhstan)
                        {
                            Caption = Localizer.GetMenuLanguageName(Localizer.lngKz)
                        };
                }
                else if (lang.Key == Localizer.lngUk)
                {
                    new MenuAction(SetUkrainianLanguage, m_MenuManager, m_LanguageMenu,
                                   "MenuUkrainian", 930, false, (int)MenuIconsSmall.Ukrainian,
                                   (int)MenuIcons.Ukrainian)
                        {
                            Caption = Localizer.GetMenuLanguageName(Localizer.lngUk)
                        };
                }
                else if (lang.Key == Localizer.lngAr)
                {
                    new MenuAction(SetArmenianLanguage, m_MenuManager, m_LanguageMenu, "MenuArmenian",
                                   905, false, (int)MenuIconsSmall.Armenian, (int)MenuIcons.Armenian)
                        {
                            Caption = Localizer.GetMenuLanguageName(Localizer.lngAr)
                        };
                }
                else if (lang.Key == Localizer.lngIraq)
                {
                    new MenuAction(SetIraqLanguage, m_MenuManager, m_LanguageMenu, "MenuIraq",
                                   901, false, (int)MenuIconsSmall.Iraq, (int)MenuIcons.Iraq)
                    {
                        Caption = Localizer.GetMenuLanguageName(Localizer.lngIraq)
                    };
                }
                else if (lang.Key == Localizer.lngVietnam)
                {
                    new MenuAction(SetVietnamLanguage, m_MenuManager, m_LanguageMenu, "MenuVietnam",
                                   901, false, -1, -1)
                    {
                        Caption = Localizer.GetMenuLanguageName(Localizer.lngVietnam)
                    };
                }
                else if (lang.Key == Localizer.lngLaos)
                {
                    new MenuAction(SetLaosLanguage, m_MenuManager, m_LanguageMenu, "MenuLaos",
                                   901, false, -1, -1)
                    {
                        Caption = Localizer.GetMenuLanguageName(Localizer.lngLaos)
                    };
                }
            }

            new MenuAction(RunEpiInfo, MenuActionManager.Instance, MenuActionManager.Instance.Reports,
                            "MenuLaunchEpiInfo", 1000000, false, (int)MenuIconsSmall.EpiInfo)
                {
                    Name = "btnEpiInfo",
                    BeginGroup = true,
                };

            WinMenuReportRegistrator.RegisterAllStandartReports(m_MenuManager, EidssSiteContext.ReportFactory);
        }



        #endregion

        #region Default action handlers
        private void RunEpiInfo()
        {
            if (!String.IsNullOrEmpty(BaseSettings.EpiInfoPath) && File.Exists(BaseSettings.EpiInfoPath))
            {
                try
                {
                    var pi = new ProcessStartInfo(BaseSettings.EpiInfoPath);
                    var epiInfoDir = Path.GetDirectoryName(BaseSettings.EpiInfoPath);
                    if (epiInfoDir != null)
                        pi.WorkingDirectory = epiInfoDir;
                    Process.Start(pi);
                }
                catch (Exception e)
                {
                    ErrorForm.ShowError("errEpiInfoLaunch", "Error during launching Epi Info.", e);
                }
            }
            else
            {
                ErrorForm.ShowWarningFormat("msgInvalidEpiInfoPath", "Wrong path to EPI Info in configuration file <{0}>.", BaseSettings.EpiInfoPath);
            }
        }

        private static IDictionary<string, bool> m_StoredUserPermissions;

        private void ConnectToArchive(MenuAction action)
        {
            if (!BaseFormManager.CloseAll(true))
                return;
            //bool archiveConnection = false;
            if (action.MenuItem != null && action.MenuItem is BarCheckItem)
            {
                if (!BaseFormManager.ArchiveMode)
                {
                    if (!ConnectToArchiveDatabase())
                        ConnectToStanadardDatabase();
                }
                else
                {
                    ConnectToStanadardDatabase();
                }
            }

            ReloadMenu();
            MenuAction a = MenuActionManager.Instance.FindAction("MenuConnectToArchive");
            if (a != null && a.MenuItem != null && a.MenuItem is BarCheckItem)
            {
                (a.MenuItem as BarCheckItem).Checked = BaseFormManager.ArchiveMode;
            }
        }
        private void ConnectToStanadardDatabase()
        {
            var credentials = new ConnectionCredentials();
            ConnectionManager.DefaultInstance.SetCredentials();
            DbManagerFactory.SetSqlFactory(credentials.ConnectionString);
            BaseFormManager.ArchiveMode = false;
            if (m_StoredUserPermissions != null)
                EidssUserContext.User.Permissions = m_StoredUserPermissions;

        }

        private bool ConnectToArchiveDatabase()
        {
            try
            {
                if (m_StoredUserPermissions == null)
                    m_StoredUserPermissions = EidssUserContext.User.Permissions;
                var credentials = new ConnectionCredentials(null, "Archive");
                ConnectionManager.DefaultInstance.SetCredentials(null, null, null, null, null, "Archive");
                DbManagerFactory.SetSqlFactory(credentials.ConnectionString);
                if (credentials.IsCorrect)
                {
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        if (!manager.TestConnection())
                        {
                            ErrorForm.ShowError("errArchiveConnectionError");
                            return false;
                        }
                    }
                }
                else
                {
                    ErrorForm.ShowError("errArchiveConnectionError");
                    return false;

                }

                var readOnlyPermissions = new Dictionary<string, bool>();
                foreach (string key in m_StoredUserPermissions.Keys)
                {
                    if (key.StartsWith(EIDSSPermissionObject.HumanCaseDeduplication.ToString())
                        || key.StartsWith(EIDSSPermissionObject.NotificationSubscription.ToString())
                        )
                        continue;
                    readOnlyPermissions.Add(key, key.EndsWith(".Select") ? m_StoredUserPermissions[key] : false);
                }
                EidssUserContext.User.Permissions = readOnlyPermissions;
                BaseFormManager.ArchiveMode = true;
                return true;

            }
            catch (Exception e)
            {

                if (!SqlExceptionHandler.Handle(e))
                {
                    ErrorForm.ShowError("errArchiveConnectionError", e);
                }
                return false;
            }

        }
        private void ChangeUser()
        {
            if (
                MessageForm.Show(EidssMessages.Get("mbSureToSwitchUser"),
                                 EidssMessages.Get("msgMessage"),
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.Yes)
            {
                //if (BaseForm.SaveAllOpenedForms == true)
                //{
                Login();
                //}
            }
        }

        private void UserChanged()
        {
            sbiUser.Caption = EidssUserContext.User.FullName;
            sbiOrganization.Caption = EidssSiteContext.Instance.OrganizationName;
        }

        private void CloseForm()
        {
            Close();
        }

        private void HelpContext()
        {
            Help2.ShowHelp(this, WinClientContext.GetHelpFileNameSpace(), Help2.HomePage);
        }

        /*private void HelpIndex()
        {
            Help2.ShowHelp(this, WinClientContext.GetHelpFileNameSpace(), HelpNavigator.Index);
        }

        private void HelpSearch()
        {
            Help2.ShowHelp(this, WinClientContext.GetHelpFileNameSpace(), HelpNavigator.Find);
        }*/

        private void About()
        {
            AboutForm.ShowMe();
        }

        private void SetEnglishLanguage()
        {
            ResetLanguage(Localizer.lngEn);
        }

        private void SetRussianLanguage()
        {
            ResetLanguage(Localizer.lngRu);
        }

        private void SetGeorgianLanguage()
        {
            ResetLanguage(Localizer.lngGe);
        }

        private void SetKazakhLanguage()
        {
            ResetLanguage(Localizer.lngKz);
        }

        private void SetUkrainianLanguage()
        {
            ResetLanguage(Localizer.lngUk);
        }

        private void SetArmenianLanguage()
        {
            ResetLanguage(Localizer.lngAr);
        }

        private void SetAzeriLanguageLat()
        {
            ResetLanguage(Localizer.lngAzLat);
        }
        private void SetIraqLanguage()
        {
            ResetLanguage(Localizer.lngIraq);
        }

        private void SetLaosLanguage()
        {
            ResetLanguage(Localizer.lngLaos);
        }

        private void SetVietnamLanguage()
        {
            ResetLanguage(Localizer.lngVietnam);
        }

        private bool ReloadMenu()
        {
            m_LangageInitialized = false;
            ResetLanguage(ModelUserContext.CurrentLanguage);

            try
            {
                WinClientContext.SiteCaption = "( " + EidssSiteContext.Instance.SiteType + " - " +
                                               EidssSiteContext.Instance.SiteID + ") " +
                                               EidssSiteContext.Instance.SiteABR;
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError(
                    EidssMessages.Get("errSiteNotDefined",
                                      "EIDSS site is not defined. Please reinstall the application with correct Site ID"),
                    ex);
                ExitApp(true);
                return false;
            }
            return true;
        }

        private bool Login()
        {
            if (!BaseFormManager.CloseAll(true))
                return true;
            if (m_ActivityMonitor != null)
            {
                m_ActivityMonitor.Enabled = false;
            }
            var manager = new EidssSecurityManager();
            manager.LogOut();
            Visible = false;
            if (!LoginForm.DefaultLogin())
            {
                ExitApp(true);
                return false;
            }

            //reset connection
            UpdateMessenger.SetConnection((SqlConnection)ConnectionManager.CreateNew().Connection);

            //check for can run application
            if (!UpdateMessenger.CanRunApplication(ModelUserContext.ClientID, AppCode))
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("ApplicationMustBeClosed"));
                ExitApp(true);
                return false;
            }

            if (m_Server == null)
            {
                try
                {
                    RemotingServer.Init();
                    RemoteEventManager.Singleton.MainForm = this;
                    m_Server = RemoteEventManager.Singleton;
                }
                catch (Exception)
                {
                    ErrorForm.ShowMessageDirect(EidssMessages.Get("errRemotingSockeError",
                                                                  "Unable to start server for communication with EIDSS Client Agent. Please check that no EIDSS application is started in other Windows session or ask adminisrtators to correct TCP port used by EIDSS. If you see this message, you will be not able to open EIDSS form directly from EIDSS Client Agent. Other EIDSS functionality is not changed."));
                }
            }
            CommonResourcesCache.Reset();
            EIDSS_LookupCacheHelper.Init();
            BaseForm.ReplicationNeeded = EidssSiteContext.Instance.RealSiteType != SiteType.CDR;
            CustomCultureHelper.CurrentCountry = EidssSiteContext.Instance.CountryID;
            if (EidssSiteContext.Instance.CountryID == (long)Country.Azerbaijan)
            {
                BackgroundImageStore = Properties.Resources.EIDSS_AZ_Background;
                Appearance.BackColor = Color.White;
            }
            else if (EidssSiteContext.Instance.CountryID == (long)Country.Iraq)
            {
                BackgroundImageStore = Properties.Resources.EIDSS_IQ_Background;
                Appearance.BackColor = Color.White;
                //Appearance.BackColor =Color.FromArgb(96,199,242);
            }
            //eidss.model.Core.EidssSiteContext.Instance.CountryID = EIDSS.model.Core.EidssSiteContext.Instance.CountryID;
            Splash.ShowSplash();
            if (!ReloadMenu())
                return false;
            Visible = true;
            InitAutoLogoutMonitor();

            if (BaseSettings.ScanFormsMode)
                MessageBox.Show("Change config setting 'ScanFormsMode' to false!!", "ScanFormsMode = true!!");

            return true;
        }

        private void ReplicationRequested()
        {
            var rc = new ForcedReplicationClient() { RoutineJobName = "Dummy" };//RoutineJobName is mandatory for replication starting
            rc.StartReplication();
        }

        #endregion

        private void Timer1_Elapsed(Object sender, ElapsedEventArgs e)
        {
            sbiDate.Caption = DateTime.Now.ToShortDateString();
            sbiTime.Caption = DateTime.Now.ToShortTimeString();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            //foreach (Control ctl in Controls)
            //{
            //    if (ctl is IApplicationForm && ctl.Visible)
            //    {
            //        (ctl as IApplicationForm).Activate();
            //        return;
            //    }
            //}
            //Dbg.Debug("Main form is Activated at {0:F}", DateTime.Now);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_AskForExit &&
                WinUtils.ConfirmMessage(EidssMessages.Get("msgCloseApp", "Close application?"),
                                        EidssMessages.Get("lbCloseAppCaption", "Close Application")) == false)
            {
                e.Cancel = true;
            }
            if (e.Cancel == false)
            {
                if (!BaseFormManager.CloseAll(true))
                {
                    e.Cancel = true;
                }
            }
            if (e.Cancel == false)
            {
                ExitApp(false);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.Control)
            {
                if (e.KeyCode == Keys.E)
                {
                    SetEnglishLanguage();
                }
                else if (e.KeyCode == Keys.R)
                {
                    SetRussianLanguage();
                }
                else if (e.KeyCode == Keys.G)
                {
                    SetGeorgianLanguage();
                }
                else if (e.KeyCode == Keys.K)
                {
                    SetKazakhLanguage();
                }
                else if (e.KeyCode == Keys.U)
                {
                    if (Localizer.SupportedLanguages.ContainsKey(Localizer.lngUk))
                    {
                        SetUkrainianLanguage();
                    }
                }
                else if (e.KeyCode == Keys.A)
                {
                    if (Localizer.SupportedLanguages.ContainsKey(Localizer.lngAzLat))
                    {
                        SetAzeriLanguageLat();
                    }
                    else
                    {
                        SetArmenianLanguage();
                    }
                }
                else if (e.KeyCode == Keys.I)
                {
                    if (Localizer.SupportedLanguages.ContainsKey(Localizer.lngIraq))
                    {
                        SetIraqLanguage();
                    }
                }
                else if (e.KeyCode == Keys.L)
                {
                    if (Localizer.SupportedLanguages.ContainsKey(Localizer.lngLaos))
                    {
                        SetLaosLanguage();
                    }
                }
                else if (e.KeyCode == Keys.V)
                {
                    if (Localizer.SupportedLanguages.ContainsKey(Localizer.lngVietnam))
                    {
                        SetVietnamLanguage();
                    }
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                ShowHelp();
                //    if (BaseFormManager.CurrentForm == null)
                //    {
                //        HelpContext();
                //    }
                //    else 
                //    {
                //        BaseFormManager.CurrentForm.ShowHelp();
                //    }
                e.Handled = true;
            }
        }

        private new void  ShowHelp()
        {

            foreach (Control ctl in Controls)
            {
                if (Controls.GetChildIndex(ctl) == 0)
                {
                    if (ctl is ILayout && (ctl as ILayout).ParentBasePanel != null)
                    {
                        ((IApplicationForm)(ctl as ILayout).ParentBasePanel).ShowHelp();
                        return;
                    }
                    else if (ctl is IListFormsContainer)
                    {
                        ((IApplicationForm)((ctl as IListFormsContainer).ListPanels[0])).ShowHelp();
                        return;
                    }
                }
            }
            HelpContext();
        }

        private bool m_LangageInitialized;
        private string GetCaption(string baseName)
        {
            var suffix = Config.GetSetting("CaptionSuffix");
            if (String.IsNullOrEmpty(suffix))
                return baseName;
            return String.Format("{0} - {1}", baseName, suffix);
        }

        public void ResetLanguage(string langID)
        {
            if (Localizer.SupportedLanguages.ContainsKey(langID) == false)
            {
                return;
            }
            if (m_LangageInitialized && ModelUserContext.CurrentLanguage == langID)
            {
                return;
            }
            if (!BaseFormManager.CloseNonListForms(true))
                return;
            //if (BaseForm.SaveAllOpenedForms == false)
            //{
            //    return;
            //}
            Cursor = Cursors.WaitCursor;
            try
            {
                Enabled = false;
                //BaseForm.SetEnabled(false);
                SuspendLayout();
                ModelUserContext.CurrentLanguage = langID;
                //Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName
                if (LookupCache.Language != langID)
                {
                    LookupCache.Reload();
                }
                EidssSiteContext.Instance.Clear();
                if (m_LangageInitialized)
                {
                    EidssEventLog.Instance.CreateEvent(EventType.ClientUILanguageChanged, null, null);
                }
                m_LangageInitialized = true;
                langID = CustomCultureHelper.GetCustomCultureName(langID);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(langID);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(langID);
                WinClientContext.InitFont();
                CommonResourcesCache.Reset();
                ToolTipController.InitTooltipController();
                DefaultBarAndDockingController1.InitBarAppearance();
                tbToolbar.Appearance.InitAppearance();
                tbMenu.Appearance.InitAppearance();
                tbStatusbar.Appearance.InitAppearance();
                this.Appearance.InitAppearance();
                WinClientContext.ApplicationCaption = EidssMessages.Get("EIDSS_Caption",
                                                                        "Electronic Integrated Disease Surveillance System");
                Text = GetCaption(WinClientContext.ApplicationCaption);
                sbiUser.Caption = EidssUserContext.User.FullName;
                sbiOrganization.Caption = EidssSiteContext.Instance.OrganizationName;
                sbiSite.Caption = (EidssSiteContext.Instance.SiteType + @"-" + EidssSiteContext.Instance.SiteCode);
                sbiCountry.Caption = EidssSiteContext.Instance.CountryName;
                var resources = new ResourceManager(typeof(MainForm));
                sbiCountryLabel.Caption = resources.GetString("sbiCountryLabel.Caption");
                sbiCountryLabel.Description = resources.GetString("sbiCountryLabel.Description");
                sbiCountryLabel.Hint = resources.GetString("sbiCountryLabel.Hint");
                sbiSiteLable.Caption = resources.GetString("sbiSiteLable.Caption");
                sbiSiteLable.Description = resources.GetString("sbiSiteLable.Description");
                sbiSiteLable.Hint = resources.GetString("sbiSiteLable.Hint");
                sbiOrganizationLable.Caption = resources.GetString("sbiOrganizationLable.Caption");
                sbiOrganizationLable.Description = resources.GetString("sbiOrganizationLable.Description");
                sbiOrganizationLable.Hint = resources.GetString("sbiOrganizationLable.Hint");
                sbiUserLabel.Caption = resources.GetString("sbiUserLabel.Caption");
                sbiUserLabel.Description = resources.GetString("sbiUserLabel.Description");
                sbiUserLabel.Hint = resources.GetString("sbiUserLabel.Hint");

                RegisterActions();
                BaseFormManager.ResetLanguage();
                EidssSiteContext.ReportFactory.ResetLanguage();
                WinUtils.SwitchInputLanguage();
                BasicSyndromicSurveillanceListItem.Init();
            }
            catch (Exception ex)
            {
                Dbg.Debug(ex.ToString());
            }
            finally
            {
                if (m_LanguageMenu.ToolbarItem != null && m_LanguageMenu.MenuItem != null)
                {
                    if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = (int)MenuIcons.English;
                        m_LanguageMenu.MenuItem.ImageIndex = (int)MenuIconsSmall.English;
                    }
                    else if (ModelUserContext.CurrentLanguage == Localizer.lngRu)
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = (int)MenuIcons.Russian;
                        m_LanguageMenu.MenuItem.ImageIndex = (int)MenuIconsSmall.Russian;
                    }
                    else if (ModelUserContext.CurrentLanguage == Localizer.lngAzLat)
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = (int)MenuIcons.Azery;
                        m_LanguageMenu.MenuItem.ImageIndex = (int)MenuIconsSmall.Azery;
                    }
                    else if (ModelUserContext.CurrentLanguage == Localizer.lngGe)
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = (int)MenuIcons.Georgian;
                        m_LanguageMenu.MenuItem.ImageIndex = (int)MenuIconsSmall.Georgian;
                    }
                    else if (ModelUserContext.CurrentLanguage == Localizer.lngKz)
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = (int)MenuIcons.Kazakhstan;
                        m_LanguageMenu.MenuItem.ImageIndex = (int)MenuIconsSmall.Kazakhstan;
                    }
                    else if (ModelUserContext.CurrentLanguage == Localizer.lngAr)
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = (int)MenuIcons.Armenian;
                        m_LanguageMenu.MenuItem.ImageIndex = (int)MenuIconsSmall.Armenian;
                    }
                    else if (ModelUserContext.CurrentLanguage == Localizer.lngUk)
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = (int)MenuIcons.Ukrainian;
                        m_LanguageMenu.MenuItem.ImageIndex = (int)MenuIconsSmall.Ukrainian;
                    }
                    else if (ModelUserContext.CurrentLanguage == Localizer.lngIraq)
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = (int)MenuIcons.Iraq;
                        m_LanguageMenu.MenuItem.ImageIndex = (int)MenuIconsSmall.Iraq;
                    }
                    else if (ModelUserContext.CurrentLanguage == Localizer.lngLaos)
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = -1;
                        m_LanguageMenu.MenuItem.ImageIndex = -1;
                    }
                    else if (ModelUserContext.CurrentLanguage == Localizer.lngVietnam)
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = -1;
                        m_LanguageMenu.MenuItem.ImageIndex = -1;
                    }
                    else
                    {
                        m_LanguageMenu.ToolbarItem.LargeImageIndex = (int)MenuIcons.English;
                        m_LanguageMenu.MenuItem.ImageIndex = (int)MenuIconsSmall.English;
                    }
                    m_LanguageMenu.ToolbarItem.Hint = Localizer.GetLanguageName(ModelUserContext.CurrentLanguage);
                }
                Enabled = true;
                //BaseForm.SetEnabled(true);
                Cursor = Cursors.Default;
                ResumeLayout();
            }
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Splash.HideSplash();
                Dbg.Debug("Main form is shown at {0:F}", DateTime.Now);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            //set record from journal
            UpdateMessenger.CreateRunningApps(ModelUserContext.ClientID, AppCode);
            //TODO нужна ли эта проверка, если подключение к той же БД, что EIDSS
            //if (UpdateMessenger.WasConnected)
            //{
            TimerUpdateListener.Enabled = true;
            //}
            if (Login() == false)
            {
                return;
            }

            //string commands = Microsoft.VisualBasic.Interaction.Command();
            //Dbg.Debug("eidss is started with command line: {0}", commands);
            //if (!Utils.IsEmpty(commands))
            //{
            //    string[] args = commands.Split(' '.ToString().ToCharArray());
            //    foreach (string cmd in args)
            //    {
            //        switch (cmd.Substring(0, 2))
            //        {
            //            case "\\e":
            //                try
            //                {
            //                    Nullable<long> eventID = Utils.ToNullableLong(cmd.Substring(2));
            //                    if (eventID.HasValue)
            //                    {
            //                        EventList.ShowEventDetail(System.Convert.ToInt32(eventID));
            //                    }
            //                }
            //                catch (Exception)
            //                {
            //                    ErrorForm.ShowError(new EIDSSErrorMessage("errFailToOpenEventDetail", "Fail to open EIDSS notification details."));
            //                }
            //                break;
            //        }
            //    }
            //}


            m_Loaded = true;
        }

        /*
        private static void CheckHelpRegistration()
        {
#if !DEBUG
			try
			{
				Splash.HideSplash();
                Dbg.Debug("checking help registration: {0}", WinClientContext.HelpNames[Localizer.lngEn]);
                if (!bv.tools.MSHelp2Support.Help2.IsRegistered(WinClientContext.HelpNames[Localizer.lngEn]))
				{
                    Dbg.Debug("Help is not registerd", WinClientContext.HelpNames[Localizer.lngEn]);
					ProcessStartInfo pi = new ProcessStartInfo(WinUtils.AppPath() + "\\ehReg.bat");
					if (System.IO.File.Exists(pi.FileName))
					{
						Dbg.Debug("run help registration bat file {0}", pi.FileName);
						pi.UseShellExecute = false;
						pi.RedirectStandardOutput = true;
						pi.CreateNoWindow = true;
						pi.WorkingDirectory = WinUtils.AppPath();
						using (Process p = Process.Start(pi))
						{
							p.WaitForExit();
							string s = p.StandardOutput.ReadToEnd();
							Dbg.Debug(s);
						}
						
					}
				}
			}
			catch (Exception ex)
			{
				Dbg.Debug("help registration check error: {0}", ex.ToString());
			}
			finally
			{
				Splash.ShowSplash();
			}
#endif
        }
        */

        void IMainForm.RefreshLayout()
        {
            m_LangageInitialized = false;
            ResetLanguage(ModelUserContext.CurrentLanguage);
        }

        #region Application Locking

        private ActivityMonitor m_ActivityMonitor;

        public void InitAutoLogoutMonitor()
        {
            if (m_ActivityMonitor == null)
            {
                m_ActivityMonitor = new ActivityMonitor { MaxMinutesIdle = GetLockTimeout() };

                m_ActivityMonitor.Idle += App_Idle;
            }
            m_ActivityMonitor.Enabled = true;
        }

        private double GetLockTimeout()
        {
            try
            {
                using (DbManager manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    DataTable dt = manager.SetSpCommand("spSecurityPolicy_List",
                                                        manager.Parameter("LangID", ModelUserContext.CurrentLanguage)
                        ).ExecuteDataTable();
                    double timeout = 15;
                    if (dt.Rows[0]["intInactivityTimeout"] != DBNull.Value)
                        timeout = Convert.ToDouble(dt.Rows[0]["intInactivityTimeout"]);
                    return timeout;
                }
            }
            catch
            {
                return 15;
            }
        }

        public delegate void AsyncCall();

        private AutoLockForm m_AutoLockForm;

        public void App_Idle(object sender, EventArgs e)
        {
            m_ActivityMonitor.Enabled = false;

            m_AutoLockForm = new AutoLockForm();

            DialogResult result = m_AutoLockForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                AsyncCall dlLogin = CallLogin;
                dlLogin.BeginInvoke(null, null);
            }

            if (result == DialogResult.OK)
            {
                m_ActivityMonitor.Enabled = true;
            }
            m_AutoLockForm.Dispose();
            m_AutoLockForm = null;

            if (m_LastRemoteEventId != null && (DateTime.Now - m_LastRemoteEventRequestDate).TotalSeconds < 100)
            {
                ShowEventDetail(m_LastRemoteEventId);
            }
            m_LastRemoteEventId = null;
        }

        public void CallLogin()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(CallLogin));
                return;
            }

            if (Login())
            {
                m_ActivityMonitor.Enabled = true;
            }
        }

        private object m_LastRemoteEventId;
        private DateTime m_LastRemoteEventRequestDate;

        public void ShowEventDetail(object eventId)
        {
            if (m_AutoLockForm != null)
            {
                m_LastRemoteEventId = eventId;
                m_LastRemoteEventRequestDate = DateTime.Now;
                m_AutoLockForm.Activate();
            }
            else
            {
                m_LastRemoteEventId = null;
                EventLogListPanel.ShowEventDetail(eventId);
            }
        }

        #endregion

        //This is the attempt to reduce form flickering during resizing
        private const int WM_CREATE = 0x1;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WM_CREATE)
            {
                this.CreateParams.ExStyle |= 0x02000000;
            }
            base.WndProc(ref m);
        }

    }
}
