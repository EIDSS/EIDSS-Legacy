using System;
using System.Reflection;
using System.Windows.Forms;
using bv.common;
using bv.common.Diagnostics;
using bv.common.Resources;
using bv.common.Resources.TranslationTool;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using bv.winclient.Core;
using bv.common.Core;
using eidss.model.Resources;
using eidss.model.Core;
using eidss.model.Enums;
using bv.winclient.Localization;
using bv.model.BLToolkit;
using bv.common.Configuration;
using System.IO;
using bv.winclient.ActionPanel;


namespace eidss.main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Config.DefaultGlobalConfigFileName = Constants.GlobalEidssConfigName;
            bool showMessage = true;
            if (!OneInstanceApp.Run(true, ref showMessage))
            {
                if (showMessage)
                    ErrorForm.ShowMessage("msgEIDSSRunning", "You can\'t run multiple EIDSS instances simultaneously. Other instance of EIDSS is running already");
                return;
            }

            //Application.SetCompatibleTextRenderingDefault(False)

            var eh = new UnhandledExceptionHandler();
            // Adds the event handler to the event.
            Application.ThreadException += eh.OnThreadException;
            try
            {
                DbManagerFactory.SetSqlFactory(new ConnectionCredentials().ConnectionString);
                EidssUserContext.Init(
                    () =>
                        EidssSiteContext.Instance.SiteType != SiteType.CDR &&
                        WinUtils.ConfirmMessage(BvMessages.Get("msgReplicationPrompt","Start the replication to transfer data on other sites?"),
                                                BvMessages.Get("msgREplicationPromptCaption", "Confirm Replication")),
                    () =>
                        {
                            EidssEventLog.Instance.CheckNotificationService();
                            EidssEventLog.Instance.StartReplication();
                        }
                    );
                ClassLoader.Init("bv_common.dll", null);
                ClassLoader.Init("bvwin_common.dll", null);
                ClassLoader.Init("bv.common.dll", null);
                ClassLoader.Init("bv.winclient.dll", null);
                ClassLoader.Init("eidss*.dll", null);
                Localizer.MenuMessages = EidssMenu.Instance;
                TranslationToolHelper.TranslationsDir = Path.Combine(Application.StartupPath,
                                                                     TranslationToolHelper.TranslationsDirectoryName);
                WinClientContext.ApplicationCaption = EidssMessages.Get("EIDSS_Caption", "Electronic Integrated Disease Surveillance System");
                WinClientContext.Init();
                //DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.eidssmoneyskin).Assembly);
                if (!string.IsNullOrEmpty(BaseSettings.SkinAssembly) && File.Exists(BaseSettings.SkinAssembly))
                    DevExpress.Skins.SkinManager.Default.RegisterAssembly(
                        Assembly.LoadFrom(BaseSettings.SkinAssembly));
                else
                    DevExpress.Skins.SkinManager.Default.RegisterAssembly(
                        typeof(DevExpress.UserSkins.eidssskin).Assembly);
                //DevExpress.UserSkins.BonusSkins.Register();
                Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(False)
                DevExpress.Skins.SkinManager.EnableFormSkins();
                Application.DoEvents();
                Splash.ShowSplash();
                //BV.common.db.Core.ConnectionManager.DefaultInstance.ConfigFilesToSave = new string[] {"EIDSS_ClientAgent.exe.config"};

                //string appdir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                //var defHelpName = Config.GetSetting("HelpUrl", "file:///" + appdir.Replace("\\", "/") + "/WebHelp_EIDSS_with_Search/");

                var defHelpName = Config.GetSetting("HelpUrl");
                WinClientContext.HelpNames.Add(Localizer.lngEn, Config.GetSetting("HelpUrl." + Localizer.lngEn, defHelpName));
                WinClientContext.HelpNames.Add(Localizer.lngRu, Config.GetSetting("HelpUrl." + Localizer.lngRu, defHelpName));
                WinClientContext.HelpNames.Add(Localizer.lngGe, Config.GetSetting("HelpUrl." + Localizer.lngGe, defHelpName));
                WinClientContext.HelpNames.Add(Localizer.lngKz, Config.GetSetting("HelpUrl." + Localizer.lngKz, defHelpName));
                WinClientContext.HelpNames.Add(Localizer.lngUzCyr, Config.GetSetting("HelpUrl." + Localizer.lngUzCyr, defHelpName));
                WinClientContext.HelpNames.Add(Localizer.lngUzLat, Config.GetSetting("HelpUrl." + Localizer.lngUzLat, defHelpName));
                WinClientContext.HelpNames.Add(Localizer.lngAzLat, Config.GetSetting("HelpUrl." + Localizer.lngAzLat, defHelpName));
                WinClientContext.HelpNames.Add(Localizer.lngUk, Config.GetSetting("HelpUrl." + Localizer.lngUk, defHelpName));
                WinClientContext.HelpNames.Add(Localizer.lngAr, Config.GetSetting("HelpUrl." + Localizer.lngAr, defHelpName));

                //DevXLocalizer.ForceResourceAdding();
                DevXLocalizer.Init();
                WinClientContext.FieldCaptions = EidssFields.Instance;
                BaseFieldValidator.FieldCaptions = EidssFields.Instance;
                ErrorForm.Messages = EidssMessages.Instance;
                BaseActionPanel.Messages = EidssMessages.Instance;
                ErrorMessage.Messages = EidssMessages.Instance;
                BvLookupColumnInfo.Messages = EidssMessages.Instance;
                bv.common.win.BaseValidator.Messages = EidssMessages.Instance;
                bv.common.win.BaseForm.EventLog = EidssEventLog.Instance;
                bv.common.win.BaseDetailForm.cancelMode = bv.common.win.BaseDetailForm.CancelCloseMode.CallPost;
                //CheckHelpRegistration();
                //LayoutHelper.Init();
                Application.EnableVisualStyles();
                //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                //Application.SetCompatibleTextRenderingDefault(false);

                ActionLocker.ShowWaitDialog = WaitDialog.ShowWaitDialog;
                ActionLocker.CloseWaitDialog = WaitDialog.CloseWaitDialog;

                Application.Idle += ApplicationOnIdle;

                SecurityLog.WriteToEventLogDB(null, SecurityAuditEvent.ProcessStart, true, null, null, "EIDSS is started", SecurityAuditProcessType.Eidss);
                Dbg.Debug("EIDSS is started with ClientID {0}", ModelUserContext.ClientID);
                Application.Run(new MainForm());

            }
            catch (Exception ex)
            {
                MessageForm.Show(ex.ToString(), "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MainForm.ExitApp(true);
            }
        }

        private static void ApplicationOnIdle(object sender, EventArgs eventArgs)
        {
            try
            {
                if (EidssUserContext.User != null && EidssUserContext.User.IsAuthenticated)
                {
                    LookupManager.ClearAndReloadOnIdle();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
