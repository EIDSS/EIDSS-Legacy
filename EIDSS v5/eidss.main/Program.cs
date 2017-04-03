using System;
using System.Reflection;
using System.Windows.Forms;
using bv.common;
using bv.common.Diagnostics;
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
                EidssUserContext.Init(() => 0);
                ClassLoader.Init("bv_common.dll", null);
                ClassLoader.Init("bvwin_common.dll", null);
                ClassLoader.Init("bv.common.dll", null);
                ClassLoader.Init("bv.winclient.dll", null);
                ClassLoader.Init("eidss*.dll", null);
                Localizer.MenuMessages = EidssMenu.Instance;
                WinClientContext.ApplicationCaption = EidssMessages.Get("EIDSS_Caption", "Electronic Integrated Disease Surveillance System");
                WinClientContext.Init();
                if (!string.IsNullOrEmpty(BaseSettings.SkinAssembly) && File.Exists(BaseSettings.SkinAssembly))
                    DevExpress.Skins.SkinManager.Default.RegisterAssembly(
                                                    Assembly.LoadFrom(BaseSettings.SkinAssembly));
                else
                    DevExpress.UserSkins.BonusSkins.Register();
                Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(False)
                DevExpress.Skins.SkinManager.EnableFormSkins();
                Application.DoEvents();
                Splash.ShowSplash();
                //BV.common.db.Core.ConnectionManager.DefaultInstance.ConfigFilesToSave = new string[] {"EIDSS_ClientAgent.exe.config"};
                string appdir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                WinClientContext.HelpNames.Add(Localizer.lngEn, "ms-help://BV.EIDSS.4.0.EN");
                WinClientContext.HelpNames.Add(Localizer.lngRu, "ms-help://BV.EIDSS.4.0.RU");
                WinClientContext.HelpNames.Add(Localizer.lngGe, "ms-help://BV.EIDSS.4.0.KA");
                WinClientContext.HelpNames.Add(Localizer.lngKz, "ms-help://BV.EIDSS.4.0.KK");
                WinClientContext.HelpNames.Add(Localizer.lngUzCyr, "ms-help://BV.EIDSS.4.0.UZ-CYRL");
                WinClientContext.HelpNames.Add(Localizer.lngUzLat, "ms-help://BV.EIDSS.4.0.UZ-LATN");
                //WinClientContext.HelpNames(Localizer.lngAzCyr) = "ms-help://BV.EIDSS.4.0.AZ-CYRL"
                WinClientContext.HelpNames.Add(Localizer.lngAzLat, "ms-help://BV.EIDSS.4.0.AZ-LATN");
                WinClientContext.HelpNames.Add(Localizer.lngUk, "ms-help://BV.EIDSS.4.0.UA");
                WinClientContext.HelpNames.Add(Localizer.lngAr, "ms-help://BV.EIDSS.4.0.HY");

                WinClientContext.HelpFiles.Add(Localizer.lngEn, "EIDSS_Help_EN.HxS");
                WinClientContext.HelpFiles.Add(Localizer.lngRu, "EIDSS_Help_RU.HxS");
                WinClientContext.HelpFiles.Add(Localizer.lngGe, "EIDSS_Help_KA.HxS");
                WinClientContext.HelpFiles.Add(Localizer.lngKz, "EIDSS_Help_KK.HxS");
                WinClientContext.HelpFiles.Add(Localizer.lngUzCyr, "EIDSS_Help_UZ-CYRL.HxS");
                WinClientContext.HelpFiles.Add(Localizer.lngUzLat, "EIDSS_Help_UZ-LATN.HxS");
                //WinClientContext.HelpFiles(Localizer.lngAzCyr) = "EIDSS_Help_AZ-CYRL.HxS"
                WinClientContext.HelpFiles.Add(Localizer.lngAzLat, "EIDSS_Help_AZ-LATN.HxS");
                WinClientContext.HelpFiles.Add(Localizer.lngUk, "EIDSS_Help_UA.HxS");
                WinClientContext.HelpFiles.Add(Localizer.lngAr, "EIDSS_Help_HY.HxS");
                //DevXLocalizer.ForceResourceAdding();
                DevXLocalizer.Init();
                WinClientContext.FieldCaptions = EidssFields.Instance;
                BaseFieldValidator.FieldCaptions = EidssFields.Instance;
                ErrorForm.Messages = EidssMessages.Instance;
                BaseActionPanel.Messages = EidssMessages.Instance;
                ErrorMessage.Messages = EidssMessages.Instance;
                bv.common.win.BaseForm.EventLog = EIDSS.EIDSS_EventLog.Instance;
                bv.common.win.BaseDetailForm.cancelMode = bv.common.win.BaseDetailForm.CancelCloseMode.CallPost;
                //CheckHelpRegistration();
                //LayoutHelper.Init();
                Application.EnableVisualStyles();
                //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                //Application.SetCompatibleTextRenderingDefault(false);

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
