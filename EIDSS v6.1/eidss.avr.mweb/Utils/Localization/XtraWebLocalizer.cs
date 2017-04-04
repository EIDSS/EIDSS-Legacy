using System;
using DevExpress.Web.Localization;
using DevExpress.Web.ASPxTreeList.Localization;
using bv.common.Diagnostics;
using bv.common.Resources;

namespace eidss.avr.mweb.Utils.Localization
{
    public class XtraWebLocalizer
    {
        public static void Activate()
        {
            XtraPivotGridLocalizer.Activate();
            XtraTreeViewLocalizer.Activate();
            XtraGridLocalizer.Activate();
            XtraASPxperienceLocalizer.Activate();
            XtraEditorsLocalizer.Activate();
        }
        public static void ForceResourceAdding()
        {
            Activate();
            string tmp;
            string tmpOriginal;
            BaseStringsStorage.ForceAbsentResourceAdding = true;
            foreach (string s in Enum.GetNames(typeof(ASPxGridViewStringId)))
            {
                tmp = (string)(XtraStrings.Get("ASPxGridViewStringId." + s, XtraGridLocalizer.Active.GetLocalizedString((ASPxGridViewStringId)(Enum.Parse(typeof(ASPxGridViewStringId), s)))));
                tmpOriginal = ((XtraGridLocalizer)XtraGridLocalizer.Active).GetDefLocalizedString((ASPxGridViewStringId)(Enum.Parse(typeof(ASPxGridViewStringId), s)));
                if (tmpOriginal != tmp)
                {
                    Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "ASPxGridViewStringId." + s, tmpOriginal, tmp);
                }
            }
            foreach (string s in Enum.GetNames(typeof(ASPxTreeListStringId)))
            {
                tmp = (string)(XtraStrings.Get("ASPxTreeListStringId." + s, XtraTreeViewLocalizer.Active.GetLocalizedString((ASPxTreeListStringId)(Enum.Parse(typeof(ASPxTreeListStringId), s)))));
                tmpOriginal = ((XtraTreeViewLocalizer)ASPxTreeListLocalizer.Active).GetDefLocalizedString((ASPxTreeListStringId)(Enum.Parse(typeof(ASPxTreeListStringId), s)));
                if (tmpOriginal != tmp)
                {
                    Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "ASPxTreeListStringId." + s, tmpOriginal, tmp);
                }
            }
            foreach (string s in Enum.GetNames(typeof(ASPxperienceStringId)))
            {
                tmp = (string)(XtraStrings.Get("ASPxperienceStringId." + s, XtraASPxperienceLocalizer.Active.GetLocalizedString((ASPxperienceStringId)(Enum.Parse(typeof(ASPxperienceStringId), s)))));
                tmpOriginal = ((XtraASPxperienceLocalizer)XtraASPxperienceLocalizer.Active).GetDefLocalizedString((ASPxperienceStringId)(Enum.Parse(typeof(ASPxperienceStringId), s)));
                if (tmpOriginal != tmp)
                {
                    Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "ASPxperienceStringId." + s, tmpOriginal, tmp);
                }
            }
            foreach (string s in Enum.GetNames(typeof(ASPxEditorsStringId)))
            {
                tmp = (string)(XtraStrings.Get("ASPxEditorsStringId." + s, XtraEditorsLocalizer.Active.GetLocalizedString((ASPxEditorsStringId)(Enum.Parse(typeof(ASPxEditorsStringId), s)))));
                tmpOriginal = ((XtraEditorsLocalizer)XtraEditorsLocalizer.Active).GetDefLocalizedString((ASPxEditorsStringId)(Enum.Parse(typeof(ASPxEditorsStringId), s)));
                if (tmpOriginal != tmp)
                {
                    Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "ASPxEditorsStringId." + s, tmpOriginal, tmp);
                }
            }
            BaseStringsStorage.ForceAbsentResourceAdding = false;
        }
    }
}