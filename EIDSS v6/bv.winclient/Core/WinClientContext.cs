using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Core;
using bv.model.Model.Core;
using bv.common.Configuration;
using System.Drawing;
using System.Threading;
using bv.common.Resources;
using bv.common.Diagnostics;

namespace bv.winclient.Core
{
    public class WinClientContext
    {
        public static void Init()
        {
            if (!string.IsNullOrEmpty(BaseSettings.DefaultLanguage))
            {
                if (Localizer.SupportedLanguages.ContainsKey(BaseSettings.DefaultLanguage))
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(CustomCultureHelper.GetCustomCultureName(BaseSettings.DefaultLanguage));
                }
            }
            ModelUserContext.CurrentLanguage = BaseSettings.DefaultLanguage;
            InitFont();

           
        }
        public static void InitFont()
        {
            if ((ModelUserContext.CurrentLanguage == Localizer.lngGe || ModelUserContext.CurrentLanguage == Localizer.lngAr) && !Utils.IsEmpty(BaseSettings.GGSystemFontName))
            {
                m_DefaultFontFamily = BaseSettings.GGSystemFontName;
                m_DefaultFontSize = BaseSettings.GGSystemFontSize;
            }
            else
            {
                m_DefaultFontFamily = BaseSettings.SystemFontName;
                m_DefaultFontSize = BaseSettings.SystemFontSize;
            }
            if (m_CurrentFont == null || m_CurrentFont.FontFamily.Name != m_DefaultFontFamily || !m_CurrentFont.Size.Equals(m_DefaultFontSize))
            {
                m_CurrentFont = new Font(m_DefaultFontFamily, m_DefaultFontSize);
                m_CurrentBoldFont = new Font(m_DefaultFontFamily, m_DefaultFontSize, FontStyle.Bold);

            }
        }

       

        private static Font m_CurrentFont;
        private static Font m_CurrentBoldFont;
        private static string m_DefaultFontFamily;
        private static float m_DefaultFontSize = 8.25F;
        public static Font CurrentFont
        {
            get
            {
                if (m_CurrentFont == null)
                {
                    InitFont();
                }
                return m_CurrentFont;
            }
        }
        public static Font CurrentBoldFont
        {
            get
            {
                if (m_CurrentBoldFont == null)
                {
                    InitFont();
                }
                return m_CurrentBoldFont;
            }
        }

        private static readonly Dictionary<string, string> m_HelpNames = new Dictionary<string, string>();
        public static Dictionary<string, string> HelpNames { get { return m_HelpNames; } }
        public static string ApplicationCaption { get; set; }
        public static string SiteCaption { get; set; }
        public static string GetHelpFileNameSpace()
        {
            if (WinClientContext.HelpNames.ContainsKey(ModelUserContext.CurrentLanguage))
            {
                return HelpNames[ModelUserContext.CurrentLanguage];
            }
            return Config.GetSetting("HelpUrl");
        }
        public static BaseStringsStorage FieldCaptions { get; set; }
    }
}
