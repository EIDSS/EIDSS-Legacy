using System.Threading;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
using DevExpress.XtraPrinting.Localization;


namespace bv.winclient.Localization
{
	public class XtraPrintingLocalizer : PreviewLocalizer
	{
		
		
		public override string GetLocalizedString(PreviewStringId id)
		{
			string localized = base.GetLocalizedString(id);
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
			{
				return localized;
			}
			return XtraStrings.Get("PreviewStringId." + id.ToString(), localized);
		}
		public string GetDefLocalizedString(PreviewStringId id)
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
