
using System.Threading;
using DevExpress.Utils.Localization.Internal;
using DevExpress.XtraPivotGrid.Localization;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;

namespace eidss.avr.mweb.Utils.Localization
{
    public class XtraPivotGridLocalizer : PivotGridLocalizer
    {
        public static void Activate()
        {
            var localizer = new XtraPivotGridLocalizer();
            var provider =
                new DefaultActiveLocalizerProvider<PivotGridStringId>(localizer);
            SetActiveLocalizerProvider(provider);
        }

        public override string GetLocalizedString(PivotGridStringId id)
        {
            bv.common.Core.Utils.CollectUsedResource("PivotGridStringId." + id.ToString());
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
            {
                return base.GetLocalizedString(id);
            }
            return XtraStrings.Get("PivotGridStringId." + id.ToString(), base.GetLocalizedString(id));
        }
        public string GetDefLocalizedString(PivotGridStringId id)
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