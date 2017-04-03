using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace bv.winclient.Localization
{
    public class SystemLanguages
    {
        public static void InitSupportedLanguages()
        {
            var supportedLanguages = new Dictionary<string, string>();
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                switch (lang.Culture.TwoLetterISOLanguageName)
                {
                    case "uz":
                        if (lang.Culture.Name.IndexOf("Cyrl", System.StringComparison.Ordinal) > 0)
                        {
                            supportedLanguages[Localizer.lngUzCyr] = lang.Culture.Name;
                        }
                        else
                        {
                            supportedLanguages[Localizer.lngUzLat] = lang.Culture.Name;
                        }
                        break;
                    case "az":
                        supportedLanguages[Localizer.lngAzLat] = lang.Culture.Name;
                        break;
                    case "en":
                    case "ru":
                    case "ka":
                    case "kk":
                        supportedLanguages[lang.Culture.TwoLetterISOLanguageName] = lang.Culture.Name;
                        break;
                }
            }
            Localizer.SupportedLanguages = supportedLanguages;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Switches the system keyboard input language to the value passed as parameter
        /// </summary>
        /// <param name="langID">
        ///     one the language ID defined by the GlabalSettings.lngXXX properties
        /// </param>
        /// <remarks>
        ///     The one the languages defined by the GlabalSettings.lngXXX properties should be passed as parameter
        ///     (currently supported values are 'en', 'ru', 'ka', 'kk', 'uz-L', 'uz-C').
        ///     If 'def' value is passed as parameter the default application language defined by
        ///     <i>GlobalSettings.DefaultLanguage</i> will be selected
        /// </remarks>
        /// <history>
        ///     [Mike]	03.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static void SwitchInputLanguage(string langID)
        {
            if (string.IsNullOrEmpty(langID))
            {
                return;
            }
            if (langID == "def")
            {
                langID = BaseSettings.DefaultLanguage;
            }
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.Name == Localizer.SupportedLanguages[langID])
                {
                    InputLanguage.CurrentInputLanguage = lang;
                    return;
                }
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Switches the system keyboard input language to the value defined by current culture of application thread.
        /// </summary>
        /// <history>
        ///     [Mike]	03.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
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

        public static RepositoryItemTextEdit SetEnglishTextEditor(GridColumn column)
        {
            var edit = new RepositoryItemTextEdit();
            column.ColumnEdit = edit;
            edit.Mask.SetEnglishEditorMask();
            return edit;
        }
    }
}