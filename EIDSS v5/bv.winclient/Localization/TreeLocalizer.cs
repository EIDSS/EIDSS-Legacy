using System.Threading;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
using DevExpress.XtraTreeList.Localization;


namespace bv.winclient.Localization
{
	public class XtraTreeLocalizer : TreeListLocalizer
	{
		
		
		public override string GetLocalizedString(DevExpress.XtraTreeList.Localization.TreeListStringId id)
		{
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
			{
				return base.GetLocalizedString(id);
			}
			return XtraStrings.Get("TreeListStringId." + id.ToString(), base.GetLocalizedString(id));
		}
		public string GetDefLocalizedString(DevExpress.XtraTreeList.Localization.TreeListStringId id)
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
