using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using DevExpress.Utils.Localization.Internal;
using DevExpress.Web.ASPxTreeList.Localization;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;

namespace eidss.avr.mweb.Utils.Localization
{
    public class XtraTreeViewLocalizer : ASPxTreeListLocalizer
    {
        public static void Activate()
        {
            var localizer = new XtraTreeViewLocalizer();
            var provider =
                new DefaultActiveLocalizerProvider<ASPxTreeListStringId>(localizer);
            SetActiveLocalizerProvider(provider);
        }
        public override string GetLocalizedString(ASPxTreeListStringId id)
        {
            bv.common.Core.Utils.CollectUsedResource("ASPxTreeListStringId." + id.ToString());
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
            {
                return base.GetLocalizedString(id);
            }
            return XtraStrings.Get("ASPxTreeListStringId." + id.ToString(), base.GetLocalizedString(id));
        }
        public string GetDefLocalizedString(ASPxTreeListStringId id)
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