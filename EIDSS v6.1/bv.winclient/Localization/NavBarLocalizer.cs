using System.Threading;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
using DevExpress.XtraNavBar;


namespace bv.winclient.Localization
{
	public class XtraNavBarLocalizer : NavBarLocalizer
	{
		
		
		public override string GetLocalizedString(NavBarStringId id)
		{
            Utils.CollectUsedResource("NavBarStringId." + id.ToString());
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
			{
				return base.GetLocalizedString(id);
			}
			return XtraStrings.Get("NavBarStringId." + id.ToString(), base.GetLocalizedString(id));
		}
		public string GetDefLocalizedString(NavBarStringId id)
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
