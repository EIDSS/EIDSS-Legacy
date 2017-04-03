using System.Threading;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
using DevExpress.XtraPivotGrid.Localization;


namespace bv.winclient.Localization
{
	public class XtraPivotGridLocalizer : PivotGridLocalizer
	{
		
		
		
		public override string GetLocalizedString(PivotGridStringId id)
		{
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
