using System;
using bv.common.Diagnostics;
using bv.common.Resources;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraCharts.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraNavBar;
using DevExpress.XtraPivotGrid.Localization;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraReports.Localization;
using DevExpress.XtraTreeList.Localization;
//using bv.common.Localization;


namespace bv.winclient.Localization
{
	public class DevXLocalizer
	{
		
		public static void Init()
		{
			GridLocalizer.Active = new XtraGridLocalizer();
			ChartLocalizer.Active = new XtraChartLocalizer();
            Localizer.Active = new EditorsLocalizer();
			BarLocalizer.Active = new XtraBarLocalizer();
			NavBarLocalizer.Active = new XtraNavBarLocalizer();
			TreeListLocalizer.Active = new XtraTreeLocalizer();
			PivotGridLocalizer.Active = new XtraPivotGridLocalizer();
			ReportLocalizer.Active = new XtraReportLocalizer();
			PreviewLocalizer.Active = new XtraPrintingLocalizer();
            
		}
		public static void ForceResourceAdding()
		{
			Init();
			string tmp;
			string tmpOriginal;
		    BaseStringsStorage.ForceAbsentResourceAdding = true;
			foreach (string s in Enum.GetNames(typeof(GridStringId)))
			{
				tmp = (string) (XtraStrings.Get("GridStringId." + s, GridLocalizer.Active.GetLocalizedString((GridStringId) (Enum.Parse(typeof(GridStringId), s)))));
				tmpOriginal = ((XtraGridLocalizer) GridLocalizer.Active).GetDefLocalizedString((GridStringId) (Enum.Parse(typeof(GridStringId), s)));
				if (tmpOriginal != tmp)
				{
					Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "GridStringId." + s, tmpOriginal, tmp);
				}
			}
			foreach (string s in Enum.GetNames(typeof(StringId)))
			{
				tmp = (string) (XtraStrings.Get("StringId." + s, Localizer.Active.GetLocalizedString((StringId) (Enum.Parse(typeof(StringId), s)))));
				tmpOriginal = ((EditorsLocalizer) Localizer.Active).GetDefLocalizedString((StringId) (Enum.Parse(typeof(StringId), s)));
				if (tmpOriginal != tmp)
				{
					Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "StringId." + s, tmpOriginal, tmp);
				}
			}
			foreach (string s in Enum.GetNames(typeof(BarString)))
			{
				tmp = (string) (XtraStrings.Get("BarString." + s, BarLocalizer.Active.GetLocalizedString((BarString) (Enum.Parse(typeof(BarString), s)))));
				tmpOriginal = ((XtraBarLocalizer) BarLocalizer.Active).GetDefLocalizedString((BarString) (Enum.Parse(typeof(BarString), s)));
				if (tmpOriginal != tmp)
				{
					Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "BarString." + s, tmpOriginal, tmp);
				}
			}
			foreach (string s in Enum.GetNames(typeof(NavBarStringId)))
			{
				tmp = (string) (XtraStrings.Get("NavBarStringId." + s, NavBarLocalizer.Active.GetLocalizedString((NavBarStringId) (Enum.Parse(typeof(NavBarStringId), s)))));
				tmpOriginal = ((XtraNavBarLocalizer) NavBarLocalizer.Active).GetDefLocalizedString((NavBarStringId) (Enum.Parse(typeof(NavBarStringId), s)));
				if (tmpOriginal != tmp)
				{
					Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "NavBarStringId." + s, tmpOriginal, tmp);
				}
			}
			foreach (string s in Enum.GetNames(typeof(TreeListStringId)))
			{
				tmp = (string) (XtraStrings.Get("TreeListStringId." + s, TreeListLocalizer.Active.GetLocalizedString((TreeListStringId) (Enum.Parse(typeof(TreeListStringId), s)))));
				tmpOriginal = ((XtraTreeLocalizer) TreeListLocalizer.Active).GetDefLocalizedString((TreeListStringId) (Enum.Parse(typeof(TreeListStringId), s)));
				if (tmpOriginal != tmp)
				{
					Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "TreeListStringId." + s, tmpOriginal, tmp);
				}
			}
			foreach (string s in Enum.GetNames(typeof(PivotGridStringId)))
			{
				tmp = (string) (XtraStrings.Get("PivotGridStringId." + s, XtraPivotGridLocalizer.Active.GetLocalizedString((PivotGridStringId) (Enum.Parse(typeof(PivotGridStringId), s)))));
				tmpOriginal = ((XtraPivotGridLocalizer) PivotGridLocalizer.Active).GetDefLocalizedString((PivotGridStringId) (Enum.Parse(typeof(PivotGridStringId), s)));
				if (tmpOriginal != tmp)
				{
					Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "PivotGridStringId." + s, tmpOriginal, tmp);
				}
			}
			foreach (string s in Enum.GetNames(typeof(ChartStringId)))
			{
				tmp = (string) (XtraStrings.Get("ChartStringId." + s, XtraChartLocalizer.Active.GetLocalizedString((ChartStringId) (Enum.Parse(typeof(ChartStringId), s)))));
				tmpOriginal = ((XtraChartLocalizer) ChartLocalizer.Active).GetDefLocalizedString((ChartStringId) (Enum.Parse(typeof(ChartStringId), s)));
				if (tmpOriginal != tmp)
				{
					Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "ChartStringId." + s, tmpOriginal, tmp);
				}
			}
			foreach (string s in Enum.GetNames(typeof(ReportStringId)))
			{
				tmp = (string) (XtraStrings.Get("ReportStringId." + s, XtraReportLocalizer.Active.GetLocalizedString((ReportStringId) (Enum.Parse(typeof(ReportStringId), s)))));
				tmpOriginal = ((XtraReportLocalizer) ReportLocalizer.Active).GetDefLocalizedString((ReportStringId) (Enum.Parse(typeof(ReportStringId), s)));
				if (tmpOriginal != tmp)
				{
					Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "ReportStringId." + s, tmpOriginal, tmp);
				}
			}
			foreach (string s in Enum.GetNames(typeof(PreviewStringId)))
			{
				tmp = (string) (XtraStrings.Get("PreviewStringId." + s, XtraPrintingLocalizer.Active.GetLocalizedString((PreviewStringId) (Enum.Parse(typeof(PreviewStringId), s)))));
				tmpOriginal = ((XtraPrintingLocalizer) PreviewLocalizer.Active).GetDefLocalizedString((PreviewStringId) (Enum.Parse(typeof(PreviewStringId), s)));
				if (tmpOriginal != tmp)
				{
					Dbg.Debug("Resource {0} is different: original - <{1}>, our - <{2}>", "PreviewStringId." + s, tmpOriginal, tmp);
				}
            }
            BaseStringsStorage.ForceAbsentResourceAdding = false;
		}
		
	}
	
}
