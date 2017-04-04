using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using DevExpress.Utils.Localization.Internal;
using DevExpress.Web.Localization;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;

namespace eidss.avr.mweb.Utils.Localization
{
    public class XtraASPxperienceLocalizer : ASPxperienceLocalizer
    {

        public static void Activate()
        {
            var localizer = new XtraASPxperienceLocalizer();
            var provider =
                new DefaultActiveLocalizerProvider<ASPxperienceStringId>(localizer);
            SetActiveLocalizerProvider(provider);
        }

        public override string GetLocalizedString(ASPxperienceStringId id)
        {
            bv.common.Core.Utils.CollectUsedResource("ASPxperienceStringId." + id.ToString());
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
            {
                return base.GetLocalizedString(id);
            }
            return XtraStrings.Get("ASPxperienceStringId." + id.ToString(), base.GetLocalizedString(id));
        }
        public string GetDefLocalizedString(ASPxperienceStringId id)
        {
            return base.GetLocalizedString(id);
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