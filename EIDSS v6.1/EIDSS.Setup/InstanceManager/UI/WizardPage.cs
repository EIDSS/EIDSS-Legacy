using System.Windows.Forms;

namespace InstanceManager.UI
{
  internal class WizardPage : Form
  {
    internal Page NextForm { get; private set; }

    internal void ClosePage()
    {
      NextForm = Page.Empty;
      Close();
    }

    protected void LoadNextPage(Page formName)
    {
      NextForm = formName;
      Close();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
      {
        Close();
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }
  }
}