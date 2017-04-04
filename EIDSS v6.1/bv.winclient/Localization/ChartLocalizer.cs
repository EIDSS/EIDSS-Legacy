using System.Threading;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
using DevExpress.XtraCharts.Localization;


namespace bv.winclient.Localization
{
	public class XtraChartLocalizer : ChartLocalizer
	{
		
		
		public override string GetLocalizedString(ChartStringId id)
		{
            Utils.CollectUsedResource("ChartStringId." + id.ToString());
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
			{
				return base.GetLocalizedString(id);
			}
			return XtraStrings.Get("ChartStringId." + id.ToString(), base.GetLocalizedString(id));
		}
		public string GetDefLocalizedString(ChartStringId id)
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
