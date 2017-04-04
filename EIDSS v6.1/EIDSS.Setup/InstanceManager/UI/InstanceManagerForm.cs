using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using InstanceManager.MsiLauncher;

namespace InstanceManager.UI
{
  internal partial class InstanceManagerForm : WizardPage
  {
    private readonly InstanceManager m_instanceManager = InstanceManager.ClassInstance;
    private List<RadioButton> m_instanceSelectors;
    private string m_selectedInstance;
    internal InstanceManagerForm(Page pageType)
    {
      InitializeComponent();
      NonGeneratedInitializeComponent(pageType);
    }

    private void NonGeneratedInitializeComponent(Page pageType)
    {
      InstanceSelectorsBox.SuspendLayout();
      SuspendLayout();

      InitInstanceSelectorButton(pageType);

      ResizePage();

      InstanceSelectorsBox.ResumeLayout();
      InstanceSelectorsBox.PerformLayout();
      ResumeLayout(false);
    }

    private void InitInstanceSelectorButton(Page pageType)
    {
      switch (pageType)
      {
        case Page.UpgradeManagerForm:
          InitUpgradableControls();
          break;
        case Page.MaintainManagerForm:
          InitMaintainableControls();
          break;
        default:
          throw new InstanceManagerException("Inappropriate page type: {0}", pageType);
      }
    }

    private void InitMaintainableControls()
    {
      if (m_instanceManager.AnyMaintainable)
      {
        InitInstanceSelectorButton(m_instanceManager.Maintainable);
        AcceptButton = MaintainButton;
        MaintainButton.Visible = true;
        MaintainButton.Enabled = true;
      }
    }

    private void InitUpgradableControls()
    {
      if (m_instanceManager.AnyUpgradable)
      {
        InitInstanceSelectorButton(m_instanceManager.Upgradable);
        AcceptButton = UpgradeButton;
        UpgradeButton.Visible = true;
        UpgradeButton.Enabled = true;
      }
    }

    private void InitInstanceSelectorButton(IList<Instance> instances)
    {
      var buttonsCount = instances.Count();
      m_instanceSelectors = new List<RadioButton>(buttonsCount);
      var yPos = 20;
      for (var i = 0; i < buttonsCount; ++i, yPos += 40)
      {
        var radioButton = new RadioButton
                            {
                              AutoSize = true,
                              AutoCheck = true,
                              Checked = false,
                              Location = new Point(20, yPos),
                              Name = instances[i].Name,
                              TabIndex = i + 1,
                              TabStop = true,
                              Text = instances[i].ProductName,
                              UseVisualStyleBackColor = true
                            };

        radioButton.CheckedChanged += InstanceSelector_CheckedChanged;
        InstanceSelectorsBox.Controls.Add(radioButton);
        m_instanceSelectors.Add(radioButton);
      }
      m_instanceSelectors.First().Checked = true;
    }

    private void ResizePage()
    {
      InstanceSelectorsBox.Height = null != m_instanceSelectors ? m_instanceSelectors.Last().Bottom + 10 : 0;
      UpgradeButton.Top = InstanceSelectorsBox.Bottom + 20;
      MaintainButton.Top = InstanceSelectorsBox.Bottom + 20;
      ClientSize = new Size(ClientSize.Width, MaintainButton.Bottom + 20);

      MaximumSize = new Size(Width, Bottom);
      MinimumSize = new Size(Width, Bottom);
    }

    private void UpgradeButton_Click(object sender, EventArgs e)
    {
      Commander.ClassInstance.Run(UpgradeInstalledInstance.CommandId,
                                  m_instanceManager.Upgradable.Find(
                                    x => x.Name.Equals(m_selectedInstance, StringComparison.OrdinalIgnoreCase)));
      ClosePage();
    }

    private void MaintainButton_Click(object sender, EventArgs e)
    {
      Commander.ClassInstance.Run(ManageInstalledInstance.CommandId,
                                  m_instanceManager.Maintainable.Find(
                                    x => x.Name.Equals(m_selectedInstance, StringComparison.OrdinalIgnoreCase)));
      ClosePage();
    }

    private void InstanceSelector_CheckedChanged(object sender, EventArgs e)
    {
      var instanceButton = sender as RadioButton;
      if (null != instanceButton && instanceButton.Checked)
      {
        m_selectedInstance = instanceButton.Name;
      }
    }
  }
}
