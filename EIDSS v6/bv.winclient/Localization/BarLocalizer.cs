using bv.model.Model.Core;
using bv.winclient.Core;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using System.Diagnostics;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Configuration;
using bv.common.Resources;
using DevExpress.XtraBars.Localization;
using System.Threading;


namespace bv.winclient.Localization
{
	public class XtraBarLocalizer : BarLocalizer
	{
		
		
		public override string GetLocalizedString(DevExpress.XtraBars.Localization.BarString id)
		{
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
			{
				return base.GetLocalizedString(id);
			}
			return XtraStrings.Get("BarString." + id.ToString(), base.GetLocalizedString(id));
		}
		public string GetDefLocalizedString(DevExpress.XtraBars.Localization.BarString id)
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
