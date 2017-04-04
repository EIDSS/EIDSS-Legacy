using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InstanceManager.UI
{
  internal class SimpleFormsWizard : IDisposable
  {
    private readonly Dictionary<Page, WizardPage> m_wizardPages = new Dictionary<Page, WizardPage>();

    internal SimpleFormsWizard()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      RegisterWizardPage(Page.CommanderForm, new CommanderForm());
      RegisterWizardPage(Page.UpgradeManagerForm, new InstanceManagerForm(Page.UpgradeManagerForm));
      RegisterWizardPage(Page.MaintainManagerForm, new InstanceManagerForm(Page.MaintainManagerForm));
    }

    private void RegisterWizardPage(Page formName, WizardPage form)
    {
      m_wizardPages.Add(formName, form);
    }

    internal void Run()
    {
      var currentForm = LoadNextForm(Page.CommanderForm);
      while (Page.Empty != currentForm.NextForm)
      {
        currentForm = LoadNextForm(currentForm.NextForm);
      }
    }

    private WizardPage LoadNextForm(Page nextPage)
    {
      var page = GetPage(nextPage);
      Application.Run(page);
      return page;
    }

    private WizardPage GetPage(Page formName)
    {
      return m_wizardPages[formName];
    }

    private bool m_isDisposed;
    public void Dispose()
    {
      if (m_isDisposed)
      {
        return;
      }

      foreach (var wizardPage in m_wizardPages)
      {
        wizardPage.Value.Dispose();
      }
      m_isDisposed = true;
    }
  }
}