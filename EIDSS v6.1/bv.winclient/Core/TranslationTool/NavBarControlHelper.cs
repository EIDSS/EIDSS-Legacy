using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;

namespace bv.winclient.Core.TranslationTool
{
    public class NavBarControlHelper
    {
        public static Rectangle GetHeaderBound(NavBarControl navBar)
        {
            FieldInfo fi = typeof(NavBarControl).GetField("viewInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fi != null)
            {
                var vi = fi.GetValue(navBar) as NavigationPaneViewInfo;
                if (vi != null)
                {
                    return vi.HeaderBounds;
                }
            }
            return Rectangle.Empty;
        }

        public static Rectangle GetGroupHeaderBound(NavBarControl navBar, NavBarGroup group)
        {
            if(navBar==null || !navBar.Groups.Contains(group))
                return Rectangle.Empty;
            var barInfo = navBar.GetViewInfo();
            var groupInfo = barInfo.GetGroupInfo(group);
            if (groupInfo == null)
            {
                barInfo.Calc(navBar.Bounds);
                groupInfo = barInfo.GetGroupInfo(group);
            }
            return groupInfo.CaptionBounds;
        }
    }
}
