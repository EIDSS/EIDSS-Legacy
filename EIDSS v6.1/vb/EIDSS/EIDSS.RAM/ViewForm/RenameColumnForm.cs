using System.Drawing;
using System.Windows.Forms;
using bv.common.Resources;
using bv.winclient.BasePanel;
using bv.winclient.Layout;

namespace eidss.avr.ViewForm
{
    public partial class RenameColumnForm
    {
        private void Init()
        {
            btnOk.Text = BvMessages.Get("strOK_Id");
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.Text = BvMessages.Get("strCancel_Id");
            btnCancel.DialogResult = DialogResult.Cancel;
            LayoutCorrector.ApplySystemFont(this);
            LayoutCorrector.SetStyleController(txtInput, LayoutCorrector.MandatoryStyleController);
            if (BaseFormManager.MainForm != null)
            {
                Icon = BaseFormManager.MainForm.Icon;
            }
        }

        public RenameColumnForm()
        {
            InitializeComponent();
            Init();
        }

        public RenameColumnForm(string prompt, string caption, string reference, string labelReference)
        {
            InitializeComponent();
            Init();
            lbInput.Text = prompt;
            lbReference.Text = labelReference;
            txtReference.Text = reference;
            Text = caption;
        }

        public static string Input(string prompt, string caption, string reference, string labelReference, string value, Point formLocation)
        {
            using (var frm = new RenameColumnForm(prompt, caption, reference, labelReference))
            {
                frm.StartPosition = FormStartPosition.Manual;
                if (frm.Width + formLocation.X > Screen.PrimaryScreen.WorkingArea.Width)
                    formLocation.X = Screen.PrimaryScreen.WorkingArea.Width - frm.Width;
                if (frm.Height + formLocation.Y > Screen.PrimaryScreen.WorkingArea.Height)
                    formLocation.Y = Screen.PrimaryScreen.WorkingArea.Height - frm.Height;
                frm.Location = formLocation;
                frm.txtInput.Text = value;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    return frm.txtInput.Text;
                }
                return value;
            }
        }
    }
}