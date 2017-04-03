using System.Threading;
using bv.common.Resources;
using DevExpress.XtraEditors.Controls;


namespace bv.winclient.Localization
{
    public class EditorsLocalizer : DevExpress.XtraEditors.Controls.Localizer
	{
		
		
		public override string GetLocalizedString(StringId id)
		{
			//If (Localizer.Language = Localizer.lngEn) Then
			//    Return MyBase.GetLocalizedString(id)
			//End If
			return XtraStrings.Get("StringId." + id.ToString(), base.GetLocalizedString(id));
		}
		public string GetDefLocalizedString(StringId id)
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
