using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using bv.common.Configuration;
using bv.common.Resources;

namespace bv.winclient.Core
{
    public class BvOptionalWarningArgs:XtraMessageBoxArgs
    {
        public BvOptionalWarningArgs(string text, string showNextTimeOptionName, string checkBoxText)
            : base(null, text, BvMessages.Get("Warning"), new[] { DialogResult.OK }, GetIcon(MessageBoxIcon.Warning), (int)MessageBoxDefaultButton.Button1)
        {
            ShowNextTimeOptionName = showNextTimeOptionName;
            CheckBoxText = checkBoxText;
        }
        public static Icon GetIcon(MessageBoxIcon msgIcon)
        {
            MethodInfo xtraMessageBoxInfo = typeof(XtraMessageBox).GetMethod("MessageBoxIconToIcon", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            object icon = xtraMessageBoxInfo.Invoke(null, new object[] { msgIcon });
            return (Icon)icon;
        }
        public string ShowNextTimeOptionName { get; set; }
        public string CheckBoxText { get; set; }
    }
    class BvOptionalWarning : XtraMessageBoxForm 
    {
        protected override void OnShown(EventArgs e)
        {
            if (ShowNextTimeCheckBox)
            {
                ShowNextTime();
            }
            base.OnShown(e);
        }
        private CheckEdit m_ChkShowNextTime;
        private string m_ShowNextTimeOptionName;
        private string m_checkBoxText;
        private bool ShowNextTimeCheckBox
        {
            get
            {
                return !string.IsNullOrEmpty(m_ShowNextTimeOptionName) &&
                       Config.GetBoolSetting(m_ShowNextTimeOptionName, true);
            }
        }
        public DialogResult ShowForm(BvOptionalWarningArgs messageArgs)
        {
            m_ShowNextTimeOptionName = messageArgs.ShowNextTimeOptionName;
            m_checkBoxText = messageArgs.CheckBoxText;
            return ShowMessageBoxDialog(messageArgs);
        }


        void ShowNextTime()
        {
            m_ChkShowNextTime = new CheckEdit
                {
                    Checked = false,
                    Text =
                        string.IsNullOrEmpty(m_checkBoxText) ? BvMessages.Get("DoNotShowMessageNextTime") : m_checkBoxText
                };
            m_ChkShowNextTime.Properties.AutoWidth = true;
            m_ChkShowNextTime.Properties.AutoHeight = true;
            Height += m_ChkShowNextTime.Height+8;
            m_ChkShowNextTime.Location = new Point(12, Buttons[0].Top);
            Buttons[0].Top += m_ChkShowNextTime.Height + 10;

            Controls.Add(m_ChkShowNextTime);
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (m_ChkShowNextTime != null)
            {
                if (m_ChkShowNextTime.Checked)
                {
                    AppConfigWriter.Instance.SetItem(m_ShowNextTimeOptionName, "false");
                    AppConfigWriter.Instance.Save();
                    Config.ReloadSettings();
                }
            }
            base.OnClosing(e);
        }

    }
}
