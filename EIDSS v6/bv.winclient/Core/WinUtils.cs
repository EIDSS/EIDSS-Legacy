using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources;
using bv.winclient.Localization;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Localizer = bv.common.Core.Localizer;

namespace bv.winclient.Core
{
    public class WinUtils
    {
        private const int StartFrame = 4;
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
        /// </summary>
        /// <returns></returns>
        public static string AppPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        /// <summary>
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static bool ConfirmMessage(string msg, string caption)
        {
            return MessageForm.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes);
        }

        public static bool ConfirmMessage(IWin32Window owner, string msg, string caption)
        {
            MessageForm.ParentWindowHandle = owner;
            return MessageForm.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes);
        }

        public static DialogResult ConfirmMessage3Buttons(IWin32Window owner, string msg, string caption)
        {
            MessageForm.ParentWindowHandle = owner;
            return MessageForm.Show(msg, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static bool ConfirmMessage(IWin32Window owner, string msg)
        {
            MessageForm.ParentWindowHandle = owner;
            return
                MessageForm.Show(msg, BvMessages.Get("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes);
        }

        public static bool ConfirmMessage(string msg)
        {
            return
                MessageForm.Show(msg, BvMessages.Get("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static bool ConfirmDelete()
        {
            return ConfirmMessage(BvMessages.Get("msgDeleteRecordPrompt", "The record will be deleted. Delete record?"),
                BvMessages.Get("Delete Record"));
        }

        public static bool ConfirmLookupClear()
        {
            return ConfirmMessage(BvMessages.Get("msgConfirmClearLookup"), BvMessages.Get("Confirmation"));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static bool ConfirmCancel(Form owner)
        {
            if (owner != null)
            {
                owner.Activate();
                owner.BringToFront();
            }
            return ConfirmMessage(BvMessages.Get("msgCancelPrompt", "Do you want to cancel all the changes and close the form?"),
                BvMessages.Get("Confirmation"));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static bool ConfirmSave()
        {
            return ConfirmMessage(BvMessages.Get("msgSavePrompt", "Do you want to save changes?"), BvMessages.Get("Confirmation"));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static bool ConfirmOk()
        {
            return ConfirmMessage(BvMessages.Get("msgOKPrompt", "Do you want to save changes and close the form?"),
                BvMessages.Get("Confirmation"));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static DialogResult ConfirmSaveForTranslationTool()
        {
            return
                MessageForm.Show(
                    BvMessages.Get("msgSaveTranslationToolPrompt", "Do you want to save changes and close the form?")
                    , BvMessages.Get("Confirmation")
                    , MessageBoxButtons.YesNoCancel
                    , MessageBoxIcon.Question);
        }

        /// <summary>
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

        private static readonly Regex m_ControlLanguageRegExp = new Regex("\\[(?<lng>.*)\\]", RegexOptions.IgnoreCase);

        private static string GetLanguageTag(Control c)
        {
            if (c != null && (c.Tag) is string)
            {
                Match m = m_ControlLanguageRegExp.Match(Convert.ToString(c.Tag));
                if (m.Success)
                {
                    return m.Result("${lng}");
                }
            }
            return null;
        }

        public static void SetControlLanguage(Control c, out string lastInputLanguage)
        {
            lastInputLanguage = Localizer.GetLanguageID(InputLanguage.CurrentInputLanguage.Culture);
            string s = GetLanguageTag(c);
            if (!String.IsNullOrEmpty(s))
            {
                SystemLanguages.SwitchInputLanguage(s);
            }
        }

        public static void SetControlLanguageEn(Control c)
        {
            string s = GetLanguageTag(c);
            if (!String.IsNullOrEmpty(s))
            {
                SystemLanguages.SwitchInputLanguage(s);
            }
        }

        public static string GetControlLanguage(Control c)
        {
            string lang = GetLanguageTag(c);
            if (!String.IsNullOrEmpty(lang))
            {
                string res = "";
                if (lang == "def")
                {
                    lang = BaseSettings.DefaultLanguage;
                }
                if (Localizer.SupportedLanguages.ContainsKey(lang))
                {
                    res = Convert.ToString(Localizer.SupportedLanguages[lang]);
                }
                if (res != "")
                {
                    foreach (InputLanguage language in InputLanguage.InstalledInputLanguages)
                    {
                        if (language.Culture.Name == res)
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
                Match m = m_ControlLanguageRegExp.Match(Convert.ToString(c.Tag));
                return m.Success;
            }
            return false;
        }

        public static void RemoveClearButton(LookUpEdit lookUpEdit)
        {
            int index = -1;
            foreach (EditorButton button in lookUpEdit.Properties.Buttons)
            {
                if (button.Kind == ButtonPredefines.Delete)
                {
                    index = button.Index;
                    break;
                }
            }
            if (index > 0)
            {
                lookUpEdit.Properties.Buttons.RemoveAt(index);
            }
        }

        public static void AddClearButton(ButtonEdit ctl)
        {
            IEnumerable<EditorButton> buttons = ctl.Properties.Buttons.Cast<EditorButton>();
            if (buttons.All(button => button.Kind != ButtonPredefines.Delete))
            {
                ctl.ButtonClick += ClearButtonClick;
                var btn = new EditorButton(ButtonPredefines.Delete, BvMessages.Get("btnClear", "Clear the field contents"));

                ctl.Properties.Buttons.Add(btn);
            }
           
        }

        public static void AddClearButtons(Control container)
        {
            foreach (Control ctl in container.Controls)
            {
                if ((ctl) is ButtonEdit)
                {
                    AddClearButton((ButtonEdit) ctl);
                }
            }
        }

        private static void ClearButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                ((BaseEdit) sender).EditValue = null;
            }
        }

        

        public static bool IsComponentInDesignMode(IComponent component)
        {
            if (component == null)
            {
                return false;
            }

            //' if all is simple
            if (component.Site != null)
            {
                return component.Site.DesignMode;
            }

            //' not so simple...
            Type smInterfaceMatch = typeof (IDesignerHost);

            var stack = new StackTrace();
            int frameCount = stack.FrameCount - 1;
            //' look up in stack trace for type that implements interface IDesignerHost

            for (int frame = StartFrame; frame <= frameCount; frame++)
            {
                Type typeFromStack = stack.GetFrame(frame).GetMethod().DeclaringType;
                if (smInterfaceMatch.IsAssignableFrom(typeFromStack))
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
                ErrorForm.ShowWarningFormat("ErrMandatoryFieldRequired",
                    "The field '{0}' is mandatory. You must enter data to this field before form saving", fieldName);
                return false;
            }
            return true;
        }

        public static bool ValidateDateInRange(object date, object startDate, object endDate)
        {
            if (Utils.IsEmpty(date))
            {
                return true;
            }
            if ((!Utils.IsEmpty(startDate) && ((DateTime) date).Date < ((DateTime) startDate).Date) ||
                (!Utils.IsEmpty(endDate) && ((DateTime) date).Date > ((DateTime) endDate).Date))
            {
                return false;
            }
            return true;
        }

        public static void SetClearTooltip(BaseEdit ctl)
        {
            string tooltip = BvMessages.Get("msgClearControl", "Press Ctrl-Del to clear value.");
            if (ctl.ToolTip == null || !ctl.ToolTip.Contains(tooltip))
            {
                ctl.ToolTip = tooltip;
                ctl.ToolTipIconType = ToolTipIconType.None;
            }
        }

        public static Point GetAbsoluteLocation(Control parent, Point location)
        {
            return parent == null
                ? location
                : GetAbsoluteLocation(parent.Parent, new Point(parent.Left + location.X, parent.Top + location.Y));
        }
    }
}