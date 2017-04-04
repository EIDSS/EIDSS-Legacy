using System.Drawing;
using System.ComponentModel;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using bv.common.Resources;

namespace bv.winclient.Core
{
    public class MessageForm
    {
        public static IWin32Window ParentWindowHandle { get; set; }
        public static DialogResult Show(string text)
        {
            //return XtraMessageBox.Show(InsertCrlf(text), BvMessages.Get("Warning"));
            return Show(InsertCrlf(text), BvMessages.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption)
        {
            //return XtraMessageBox.Show(InsertCrlf(text), caption);
            return Show(InsertCrlf(text), caption, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            //return XtraMessageBox.Show(InsertCrlf(text), caption, buttons);
            return Show(InsertCrlf(text), caption, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(InsertCrlf(text), caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            WaitDialog.Hide();
            DialogResult res;
            if (ParentWindowHandle == null)
                res = XtraMessageBox.Show(InsertCrlf(text), caption, buttons, icon, defaultButton);
            else
            {
                res = XtraMessageBox.Show(ParentWindowHandle, InsertCrlf(text), caption, buttons, icon, defaultButton);
                ParentWindowHandle = null;
            }
            WaitDialog.Restore();
            return res;
        }

        public static void ShowOptionalWarning(string text, string showNextTimeOptionName, string checkBoxText = null)
        {
            WaitDialog.Hide();
            var messageForm = new BvOptionalWarning();
            var options = new BvOptionalWarningArgs(text, showNextTimeOptionName, checkBoxText);
            messageForm.ShowForm(options);
            WaitDialog.Restore();
        }
        private const int MaxTextLength = 100;
        private const int Delta = 10;
        private static string InsertCrlf(string text)
        {
            if (text.Length < MaxTextLength)
                return text;
            var s = new StringBuilder();
            int len = 0;
            int leftChars = text.Length;
            foreach (var ch in text)
            {
                len++;
                leftChars--;
                if (len < MaxTextLength || leftChars < Delta || !char.IsWhiteSpace(ch))
                {
                    s.Append(ch);
                }
                else
                {
                    len = 0;
                    s.Append("\n");
                }
            }
            return s.ToString();
        }

    }
}
