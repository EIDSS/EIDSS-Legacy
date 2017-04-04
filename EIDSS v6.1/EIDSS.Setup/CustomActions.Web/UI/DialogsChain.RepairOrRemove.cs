namespace CustomActions.UI
{
  using Microsoft.Deployment.WindowsInstaller;

  internal sealed class RepairOrRemoveDialogsChain : DialogsChain
  {
    public RepairOrRemoveDialogsChain(Session session, InstallMode installMode)
      : base(session, installMode)
    {
    }

    protected override void FillChain()
    {
      AddDialog(Dialogs.MaintenanceTypeDlg);
      AddDialog(Dialogs.VerifyReadyDlg);
    }
  }
}