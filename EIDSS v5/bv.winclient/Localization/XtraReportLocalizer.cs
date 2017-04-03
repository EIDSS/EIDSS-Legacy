using System.Threading;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
using DevExpress.XtraReports.Localization;


namespace bv.winclient.Localization
{
	public class XtraReportLocalizer : ReportLocalizer
	{
		
		
		public override string GetLocalizedString(ReportStringId id)
		{
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
			{
				return base.GetLocalizedString(id);
			}
			return XtraStrings.Get("ReportStringId." + id.ToString(), base.GetLocalizedString(id));
		}
		public string GetDefLocalizedString(ReportStringId id)
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
