using System;
using System.Threading;
using bv.common.Core;
using bv.model.Model.Core;

namespace eidss.model.Core.CultureInfo
{
    public class CultureInfoTransaction : IDisposable
    {
        private readonly System.Globalization.CultureInfo m_OldCultureInfo;
        private readonly string m_OldCurrentLanguage;

        public CultureInfoTransaction(System.Globalization.CultureInfo cultureInfo)
        {
            Utils.CheckNotNull(cultureInfo, "cultureInfo");

            m_OldCultureInfo = (System.Globalization.CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            EidssSiteContext.Instance.UpdateDateTimeFormat(m_OldCultureInfo);
            m_OldCurrentLanguage = ModelUserContext.CurrentLanguage;

            var clone = (System.Globalization.CultureInfo) cultureInfo.Clone();
            EidssSiteContext.Instance.UpdateDateTimeFormat(clone);

            Thread.CurrentThread.CurrentCulture = clone;
            Thread.CurrentThread.CurrentUICulture = clone;

            ModelUserContext.CurrentLanguage = Localizer.GetLanguageID(cultureInfo);
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = m_OldCultureInfo;
            Thread.CurrentThread.CurrentUICulture = m_OldCultureInfo;
            ModelUserContext.CurrentLanguage = m_OldCurrentLanguage;
        }
    }
}