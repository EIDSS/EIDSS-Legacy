using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Configuration;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace bv.winclient.Localization
{
    public class SystemLanguages
    {
        public static void InitSupportedLanguages()
        {
            Dictionary<string,string> SupportedLanguages = new Dictionary<string, string>();
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                switch (lang.Culture.TwoLetterISOLanguageName)
                {
                    case "uz":
                        if (lang.Culture.Name.IndexOf("Cyrl") > 0)
                        {
                            SupportedLanguages[Localizer.lngUzCyr] = lang.Culture.Name;
                        }
                        else
                        {
                            SupportedLanguages[Localizer.lngUzLat] = lang.Culture.Name;
                        }
                        break;
                    case "az":
                        SupportedLanguages[Localizer.lngAzLat] = lang.Culture.Name;
                        break;
                    case "en":
                    case "ru":
                    case "ka":
                    case "kk":
                        SupportedLanguages[lang.Culture.TwoLetterISOLanguageName] = lang.Culture.Name;
                        break;
                }
            }
            Localizer.SupportedLanguages = SupportedLanguages;
        }
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Switches the system keyboard input language to the value passed as parameter
    /// </summary>
    /// <param name="LangID">
    /// one the language ID defined by the GlabalSettings.lngXXX properties
    /// </param>
    /// <remarks>
    /// The one the languages defined by the GlabalSettings.lngXXX properties should be passed as parameter
    /// (currently supported values are 'en', 'ru', 'ka', 'kk', 'uz-L', 'uz-C').
    /// If 'def' value is passed as parameter the default application language defined by <i>GlobalSettings.DefaultLanguage</i> will be selected
    /// </remarks>
    /// <history>
    /// 	[Mike]	03.04.2006	Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public static void SwitchInputLanguage(string LangID)
    {
        if (string.IsNullOrEmpty(LangID))
        {
            return;
        }
        if (LangID == "def")
        {
            LangID = BaseSettings.DefaultLanguage;
        }
        foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
        {
            if (lang.Culture.Name == Localizer.SupportedLanguages[LangID])
            {
                InputLanguage.CurrentInputLanguage = lang;
                return;
            }
        }
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Switches the system keyboard input language to the value defined by current culture of application thread.
    /// </summary>
    /// <history>
    /// 	[Mike]	03.04.2006	Created
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