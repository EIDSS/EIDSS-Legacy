using System.Threading;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
using DevExpress.XtraGrid.Localization;


namespace bv.winclient.Localization
{
	public class XtraGridLocalizer : GridLocalizer
	{
		
		
		public override string GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id)
		{
            Utils.CollectUsedResource("GridStringId." + id.ToString());
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn && id != GridStringId.FindControlClearButton)
			{
				return base.GetLocalizedString(id);
			}
			return XtraStrings.Get("GridStringId." + id.ToString(), base.GetLocalizedString(id));
		}
		public string GetDefLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id)
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
