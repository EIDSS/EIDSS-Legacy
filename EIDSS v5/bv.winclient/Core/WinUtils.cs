using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources;
using bv.winclient.Localization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Localizer = bv.common.Core.Localizer;


namespace bv.winclient.Core
{
    public class WinUtils
    {
        private static readonly Graphics m_Graphics;

        static WinUtils()
        {
            var label = new Label();
            m_Graphics = label.CreateGraphics();
        }

        public static SizeF MeasureString(String text, Font font, int width)
        {
            return m_Graphics.MeasureString(text, font, width);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string AppPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static bool ConfirmMessage(string msg, string caption)
        {
            return MessageForm.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes);
        }
        public static bool ConfirmMessage(string msg)
        {
            return MessageForm.Show(msg, BvMessages.Get("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool ConfirmDelete()
        {
            return ConfirmMessage(BvMessages.Get("msgDeleteRecordPrompt", "The record will be deleted. Delete record?"), BvMessages.Get("Delete Record", null));
        }

        public static bool ConfirmLookupClear()
        {
            return ConfirmMessage(BvMessages.Get("msgConfirmClearLookup"), BvMessages.Get("Confirmation"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool ConfirmCancel(Form owner)
        {
            if (owner != null)
            {
                owner.Activate();
                owner.BringToFront();
            }
            return ConfirmMessage(BvMessages.Get("msgCancelPrompt", "Do you want to cancel all the changes and close the form?"), BvMessages.Get("Confirmation", null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool ConfirmSave()
        {
            return ConfirmMessage(BvMessages.Get("msgSavePrompt", "Do you want to save changes?"), BvMessages.Get("Confirmation", null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool ConfirmOk()
        {
            return ConfirmMessage(BvMessages.Get("msgOKPrompt", "Do you want to save changes and close the form?"), BvMessages.Get("Confirmation", null));
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SwitchInputLanguage()
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.TwoLetterISOLanguageName == Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName)
                {
                    InputLanguage.CurrentInputLanguage = lang;
                    return;
                }
            }
        }

        private static readonly Regex ControlLanguageRegExp = new Regex("\\[(?<lng>.*)\\]", RegexOptions.IgnoreCase);
        private static string GetLanguageTag(Control c)
        {
            if (c != null && (c.Tag) is string)
            {
                Match m = ControlLanguageRegExp.Match(Convert.ToString(c.Tag));
                if (m.Success)
                    return m.Result("${lng}");
            }
            return null;
        }
        public static void SetControlLanguage(Control c, ref string lastInputLanguage)
        {
            lastInputLanguage = Localizer.GetLanguageID(InputLanguage.CurrentInputLanguage.Culture);
            string s = GetLanguageTag(c);
            if (!string.IsNullOrEmpty(s))
                SystemLanguages.SwitchInputLanguage(s);
        }
        public static string GetControlLanguage(Control c)
        {
            string lang = GetLanguageTag(c);
            if (!string.IsNullOrEmpty(lang))
            {
                string Res = "";
                if (lang == "def")
                    lang = BaseSettings.DefaultLanguage;
                if (Localizer.SupportedLanguages.ContainsKey(lang))
                    Res = Convert.ToString(Localizer.SupportedLanguages[lang]);
                if (Res != "")
                {
                    foreach (InputLanguage language in InputLanguage.InstalledInputLanguages)
                    {
                        if (language.Culture.Name == Res)
                        {
                            return language.Culture.TwoLetterISOLanguageName;
                        }
                    }
                }
            }
            return "";
            //return InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName;
        }

        public static bool HasControlAssignedLanguage(Control c)
        {
            if (c.Tag != null)
            {
                System.Text.RegularExpressions.Match m = ControlLanguageRegExp.Match(Convert.ToString(c.Tag));
                return m.Success;
            }
            return false;
        }
        public static void AddClearButton(ButtonEdit ctl)
        {
            foreach (EditorButton button in ctl.Properties.Buttons)
            {
                if (button.Kind == ButtonPredefines.Delete)
                {
                    return;
                }
            }
            ctl.ButtonClick += ClearButtonClick;
            var btn = new EditorButton(ButtonPredefines.Delete, BvMessages.Get("btnClear", "Clear the field contents"));

            ctl.Properties.Buttons.Add(btn);
        }

        public static void AddClearButtons(Control container)
        {
            foreach (Control ctl in container.Controls)
            {
                if ((ctl) is ButtonEdit)
                {
                    AddClearButton((ButtonEdit)ctl);
                }
            }
        }
        private static void ClearButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                ((BaseEdit)sender).EditValue = null;
            }
        }

        private const int START_FRAME = 4;
        public static bool IsComponentInDesignMode(IComponent component)
        {

            //' if all is simple
            if (!(component.Site == null))
            {
                return component.Site.DesignMode;
            }

            //' not so simple...
            Type sm_Interface_Match = typeof(IDesignerHost);

            StackTrace stack = new StackTrace();
            int frameCount = stack.FrameCount - 1;
            //' look up in stack trace for type that implements interface IDesignerHost

            for (int frame = START_FRAME; frame <= frameCount; frame++)
            {
                Type typeFromStack = stack.GetFrame(frame).GetMethod().DeclaringType;
                if (sm_Interface_Match.IsAssignableFrom(typeFromStack))
                {
                    return true;
                }
            }

            //' small stack trace or IDesignerHost absence is not characteristic of designers
            return false;
        }
        public static bool CheckMandatoryField(string fieldName, object value)
        {
            if (Utils.IsEmpty(value))
            {
                ErrorForm.ShowWarningFormat("ErrMandatoryFieldRequired", "The field '{0}' is mandatory. You must enter data to this field before form saving", fieldName);
                return false;
            }
            return true;
        }
        public static bool CompareDates(object lessDate, object moreDate, string errMsg)
        {
            if (Utils.IsEmpty(lessDate) || Utils.IsEmpty(moreDate))
                return true;
            if (((DateTime)lessDate).Date > ((DateTime)moreDate).Date)
            {
                ErrorForm.ShowWarning(errMsg);
                return false;
            }
            return true;
        }
        public static bool CompareDates(object lessDate, object moreDate)
        {
            if (Utils.IsEmpty(lessDate) || Utils.IsEmpty(moreDate))
                return true;
            if (((DateTime)lessDate).Date > ((DateTime)moreDate).Date)
                return false;
            return true;
        }

        public static bool ValidateDateInRange(object date, object startDate, object endDate)
        {
            if (Utils.IsEmpty(date))
                return true;
            if ((!Utils.IsEmpty(startDate) && ((DateTime)date).Date < ((DateTime)startDate).Date) ||
                (!Utils.IsEmpty(endDate) && ((DateTime)date).Date > ((DateTime)endDate).Date))
            {
                return false;
            }
            return true;
        }

        public static void SetClearTooltip(BaseEdit ctl)
        {
            var tooltip = BvMessages.Get("msgClearControl", "Press Ctrl-Del to clear value.");
            if (ctl.ToolTip == null || !ctl.ToolTip.Contains(tooltip))
            {    
                ctl.ToolTip = tooltip;
                ctl.ToolTipIconType = ToolTipIconType.None;
            }

        }
    }
}
