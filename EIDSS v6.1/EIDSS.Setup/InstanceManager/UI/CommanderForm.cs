using System;
using InstanceManager.MsiLauncher;

namespace InstanceManager.UI
{
  internal partial class CommanderForm : WizardPage
  {
    private readonly InstanceManager m_instanceManager = InstanceManager.ClassInstance;

    internal CommanderForm()
    {
      InitializeComponent();
      NonGeneratedInitializeComponent();
    }

    private void NonGeneratedInitializeComponent()
    {
      SuspendLayout();
      if (!m_instanceManager.AnyFree)
      {
        InstallButton.Enabled = false;
      }
      if (!m_instanceManager.AnyUpgradable)
      {
        UpgradeButton.Enabled = false;
      }
      if (!m_instanceManager.AnyMaintainable)
      {
        ManageButton.Enabled = false;
      }
      ResumeLayout(false);
    }

    private void InstallButton_Click(object sender, EventArgs e)
    {
      Commander.ClassInstance.Run(InstallFreeInstance.CommandId);
      ClosePage();
    }

    private void UpgradeButton_Click(object sender, EventArgs e)
    {
      if (1 == m_instanceManager.UpgradableCount)
      {
        Commander.ClassInstance.Run(UpgradeInstalledInstance.CommandId, m_instanceManager.Upgradable[0]);
        ClosePage();
      }
      else
      {
        LoadNextPage(Page.UpgradeManagerForm);
      }
    }

    private void ManageButton_Click(object sender, EventArgs e)
    {
      if (1 == m_instanceManager.MaintainableCount)
      {
        Commander.ClassInstance.Run(ManageInstalledInstance.CommandId, m_instanceManager.Maintainable[0]);
        ClosePage();
      }
      else
      {
        LoadNextPage(Page.MaintainManagerForm);
      }
    }
  }
}
