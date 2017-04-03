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
        public static DialogResult Show(string  text)
        {
            return XtraMessageBox.Show(InsertCrlf(text), BvMessages.Get("Warning"));
        }
            
        public static DialogResult Show(string  text, string caption)
        {
            return XtraMessageBox.Show(InsertCrlf(text), caption);
        }
        public static DialogResult Show(string  text, string caption, MessageBoxButtons buttons)
        {
            return XtraMessageBox.Show(InsertCrlf(text), caption, buttons);
        }

        public static DialogResult Show(string  text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return XtraMessageBox.Show(InsertCrlf(text), caption, buttons, icon);
        }

        public static DialogResult Show(string  text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon,MessageBoxDefaultButton defaultButton)
        {
            return XtraMessageBox.Show(InsertCrlf(text), caption, buttons, icon, defaultButton);
        }

        private const int MaxTextLength = 100;
        private const int Delta = 10;
        private static string InsertCrlf(string text)
        {
            if (text.Length < MaxTextLength)
                return text;
            var s=new StringBuilder();
            int len = 0;
            int leftChars = text.Length;
            foreach (var ch in text)
            {
                len++;
                leftChars--;
                if(len < MaxTextLength || leftChars< Delta || !char.IsWhiteSpace(ch))
                {
                    s.Append(ch);
                }
                else
                {
                    len = 0;
                    s.Append("\r\n");
                }
            }
            return s.ToString();
        }

    }
}
