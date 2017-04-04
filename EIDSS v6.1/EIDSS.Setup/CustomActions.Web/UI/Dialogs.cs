namespace CustomActions.UI
{
  using System;
  using System.Collections.Generic;


  internal sealed class Dialogs
  {
    internal const string MaintenanceTypeDlg = "MaintenanceTypeDlg";
    internal const string CustomCustomizeDlg = "CustomCustomizeDlg";
    internal const string AvrSvcSettingsDlg = "AvrSvcSettingsDlg";
    internal const string DbSettingsDlg = "DbSettingsDlg";
    internal const string ArchiveDbSettingsDlg = "ArchiveDbSettingsDlg";
    internal const string ServiceAccountDlg = "ServiceAccountDlg";
    internal const string SharedWebsitePortDlg = "SharedWebsitePortDlg";
    internal const string ReportsSvcSettingsDlg = "ReportsSvcSettingsDlg";
    internal const string WebSettingsDlg = "WebSettingsDlg";
    internal const string MobileDlg = "MobileDlg";
    internal const string SmartphoneDlg = "SmartphoneDlg";
    internal const string OpenApiDlg = "OpenAPIDlg";
    internal const string LogPathsDlg = "LogPathsDlg";
    internal const string WebAppSettingsDlg = "WebAppSettingsDlg";
    internal const string VerifyReadyDlg = "VerifyReadyDlg";
    internal const string DbSettingsForAvrDlg = "DbSettingsForAVRDlg";
    internal const string GisMapsFolderDlg = "GisMapsFolderDlg";
    internal const string AppPoolSettingsDlg = "AppPoolSettingsDlg";

    private readonly Dictionary<string, IDialog> m_installerDialogs = new Dictionary<string, IDialog>();

    private Dialogs()
    {
      AddDialog(MaintenanceTypeDlg);
      AddDialog(CustomCustomizeDlg);
      AddDialog(AvrSvcSettingsDlg);
      AddDialog(DbSettingsDlg);
      AddDialog(ArchiveDbSettingsDlg);
      AddDialog(ServiceAccountDlg);
      AddDialog(SharedWebsitePortDlg);
      AddDialog(ReportsSvcSettingsDlg);
      AddDialog(WebSettingsDlg);
      AddDialog(MobileDlg);
      AddDialog(SmartphoneDlg);
      AddDialog(OpenApiDlg);
      AddDialog(LogPathsDlg);
      AddDialog(WebAppSettingsDlg);
      AddDialog(VerifyReadyDlg);
      AddDialog(DbSettingsForAvrDlg);
      AddDialog(GisMapsFolderDlg);
      AddDialog(AppPoolSettingsDlg);
    }

    public IDialog this[string dialog]
    {
      get { return m_installerDialogs[dialog]; }
    }

    private void AddDialog(string dialog)
    {
      m_installerDialogs.Add(dialog, new Dialog(dialog, MakeBackProperty(dialog), MakeNextProperty(dialog)));
    }

    private static string MakeBackProperty(string dialogName)
    {
      return dialogName + @"Back";
    }

    private static string MakeNextProperty(string dialogName)
    {
      return dialogName + @"Next";
    }

    #region Singleton

    private static readonly Lazy<Dialogs> s_lazy = new Lazy<Dialogs>(() => new Dialogs());

    public static Dialogs Instance
    {
      get { return s_lazy.Value; }
    }

    #endregion

    #region Nested type: Dialog

    private class Dialog : IDialog
    {
      internal Dialog(string name, string backProperty, string nextProperty)
      {
        Name = name;
        BackProperty = backProperty;
        NextProperty = nextProperty;
      }

      #region IDialog Members

      public string Name { get; private set; }
      public string BackProperty { get; private set; }
      public string NextProperty { get; private set; }

      #endregion

      public override string ToString()
      {
        return Name;
      }
    }

    #endregion
  }
}