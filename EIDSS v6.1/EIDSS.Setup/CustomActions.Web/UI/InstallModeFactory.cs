namespace CustomActions.UI
{
  using Microsoft.Deployment.WindowsInstaller;

  public static class InstallModeFactory
  {
    internal static InstallMode GetInstallMode(Session session)
    {
      if (IsFirstInstallation(session))
      {
        return new FirstInstallationMode(session);
      }

      if (IsUpgrade(session))
      {
        return new UpgradeMode(session);
      }

      if (IsChange(session))
      {
        return new ChangeMode(session);
      }

      if (IsRemoveOrRepair(session))
      {
        return new RepairOrRemoveMode(session);
      }

      throw new InstallerException("Unknown install mode!");
    }
    internal static DialogsChain GetDialogsChain(Session session)
    {
      if (IsFirstInstallation(session))
      {
        return new FirstInstallationDialogsChain(session, new FirstInstallationMode(session));
      }

      if (IsUpgrade(session))
      {
        return new ChangeDialogsChain(session, new UpgradeMode(session));
      }

      if (IsChange(session))
      {
        return new ChangeDialogsChain(session, new ChangeMode(session));
      }

      if (IsRemoveOrRepair(session))
      {
        return new RepairOrRemoveDialogsChain(session, new RepairOrRemoveMode(session));
      }

      throw new InstallerException("Unknown install mode!");
    }

    private static bool IsUpgrade(Session session)
    {
      return session.EvaluateCondition("WIX_UPGRADE_DETECTED");
    }

    private static bool IsFirstInstallation(Session session)
    {
      return session.EvaluateCondition("NOT (Installed OR WIX_UPGRADE_DETECTED)");
    }

    private static bool IsChange(Session session)
    {
      return session.EvaluateCondition("WixUI_InstallMode= \"Change\" Or Installed And Not (WIX_UPGRADE_DETECTED Or WixUI_InstallMode = \"Repair\" Or REINSTALL Or WixUI_InstallMode = \"Remove\" Or REMOVE~=\"ALL\")");
    }

    private static bool IsRemoveOrRepair(Session session)
    {
      return session.EvaluateCondition("WixUI_InstallMode = \"Repair\" Or REINSTALL Or WixUI_InstallMode = \"Remove\" Or REMOVE~=\"ALL\"");
    }
  }
}