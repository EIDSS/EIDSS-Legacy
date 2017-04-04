namespace CustomActions.UI
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.Deployment.WindowsInstaller;

  internal abstract class DialogsChain
  {
    private readonly Session m_session;
    protected readonly InstallMode m_installMode;
    private readonly IList<IDialog> m_dialogs = new List<IDialog>();

    internal DialogsChain(Session session, InstallMode installMode)
    {
      m_session = session;
      m_installMode = installMode;
    }

    internal void BuildChain()
    {
      FillChain();

      BuildFirtsDialogNavigation();
      BuildMiddleDialogsNavigation();
      BuildLastDialogNavigation();
    }

    protected abstract void FillChain();

    private void BuildFirtsDialogNavigation()
    {
      if (m_dialogs.Count > 1)
      {
        m_session[m_dialogs[0].NextProperty] = m_dialogs[1].Name;
      }
    }

    private void BuildMiddleDialogsNavigation()
    {
      if (m_dialogs.Count <= 2)
      {
        return;
      }

      for (var i = 1; i < m_dialogs.Count - 1; ++i)
      {
        m_session[m_dialogs[i].BackProperty] = m_dialogs[i - 1].Name;
        m_session[m_dialogs[i].NextProperty] = m_dialogs[i + 1].Name;
      }
    }

    private void BuildLastDialogNavigation()
    {
      if (m_dialogs.Count > 1)
      {
        m_session[m_dialogs.Last().BackProperty] = m_dialogs[m_dialogs.Count - 2].Name;
      }
    }

    protected void AddDialog(string dialog)
    {
      m_dialogs.Add(Dialogs.Instance[dialog]);
    }

    protected void AddDialog(string dialog, Func<bool> isRequiredFunc)
    {
      if (isRequiredFunc())
      {
        AddDialog(dialog);
      }
    }
  }
}