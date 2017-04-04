
using System.Threading;
using DevExpress.Utils.Localization.Internal;
using DevExpress.Web.Localization;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;

namespace eidss.avr.mweb.Utils.Localization
{
    public class XtraEditorsLocalizer : ASPxEditorsLocalizer
    {
        public static void Activate()
        {
            var localizer = new XtraEditorsLocalizer();
            var provider =
                new DefaultActiveLocalizerProvider<ASPxEditorsStringId>(localizer);
            SetActiveLocalizerProvider(provider);
        }

        public override string GetLocalizedString(ASPxEditorsStringId id)
        {
            bv.common.Core.Utils.CollectUsedResource("ASPxEditorsStringId." + id.ToString());
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
            {
                return base.GetLocalizedString(id);
            }
            return XtraStrings.Get("ASPxEditorsStringId." + id.ToString(), base.GetLocalizedString(id));
        }
        public string GetDefLocalizedString(ASPxEditorsStringId id)
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