using System;
using System.Threading;
using bv.common.Core;

namespace eidss.model.Core.CultureInfo
{
    public class CultureInfoTransaction : IDisposable
    {
        private readonly System.Globalization.CultureInfo m_OldCultureInfo;
        private readonly string      m_OldCurrentLanguage;

        public CultureInfoTransaction(System.Globalization.CultureInfo cultureInfo)
        {
            Utils.CheckNotNull(cultureInfo, "cultureInfo");

            m_OldCultureInfo = Thread.CurrentThread.CurrentCulture;
            m_OldCurrentLanguage = bv.model.Model.Core.ModelUserContext.CurrentLanguage;

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            bv.model.Model.Core.ModelUserContext.CurrentLanguage = Localizer.GetLanguageID(cultureInfo);
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = m_OldCultureInfo;
            Thread.CurrentThread.CurrentUICulture = m_OldCultureInfo;
            bv.model.Model.Core.ModelUserContext.CurrentLanguage = m_OldCurrentLanguage;
        }
    }
}