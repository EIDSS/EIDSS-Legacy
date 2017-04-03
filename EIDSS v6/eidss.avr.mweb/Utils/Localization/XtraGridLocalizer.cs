using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using DevExpress.Utils.Localization.Internal;
using DevExpress.Web.ASPxGridView.Localization;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;

namespace eidss.avr.mweb.Utils.Localization
{
    public class XtraGridLocalizer : ASPxGridViewLocalizer
    {
        public static void Activate()
        {
            var localizer = new XtraGridLocalizer();
            var provider =
                new DefaultActiveLocalizerProvider<ASPxGridViewStringId>(localizer);
            SetActiveLocalizerProvider(provider);
        }
        public override string GetLocalizedString(ASPxGridViewStringId id)
        {
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
            {
                return base.GetLocalizedString(id);
            }
            return XtraStrings.Get("ASPxGridViewStringId." + id.ToString(), base.GetLocalizedString(id));
        }
        public string GetDefLocalizedString(ASPxGridViewStringId id)
        {
            string s = base.GetLocalizedString(id);
            return s;
        }

        public override string Language
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name;
            }
        }
    }
}