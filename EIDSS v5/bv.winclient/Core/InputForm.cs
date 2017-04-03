using System.Windows.Forms;
using bv.common.Resources;
using bv.winclient.Layout;
using bv.winclient.BasePanel;

namespace bv.winclient.Core
{
	public partial class InputForm
	{
        private void Init()
        {
            btnOk.Text = BvMessages.Get("strOK_Id");
			btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnCancel.Text = BvMessages.Get("strCancel_Id");
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            LayoutCorrector.ApplySystemFont(this);
            if (BaseFormManager.MainForm != null)
                this.Icon = BaseFormManager.MainForm.Icon;
        }

		public InputForm()
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            Init();
			// Add any initialization after the InitializeComponent() call.
		}
		public InputForm(string prompt, string caption)
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            Init();
            lbMessage.Text = prompt;
			this.Text = caption;
		}
		public static string Input(string prompt, string caption, Form owner)
		{
			using (InputForm frm = new InputForm(prompt, caption))
			{
				frm.StartPosition = FormStartPosition.CenterParent;
				if (frm.ShowDialog(owner) == System.Windows.Forms.DialogResult.OK)
				{
					return frm.txtInput.Text;
				}
				return "";
			}
			
		}
		
	}
}
