using System;
using bv.common.Core;
using eidss.model.Enums;

namespace eidss.model.Reports
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class MenuReportDescriptionAttribute : Attribute
    {
        private readonly string m_Caption;
        private readonly int m_Order;
        private readonly ReportSubMenu m_SubMenu;

        public MenuReportDescriptionAttribute(ReportSubMenu subMenu, string caption, int order)
        {
            PermissionObjects = new EIDSSPermissionObject[0];
            PermissionActions = new[] {PermissionHelper.Select};
            switch (subMenu)
            {
                case ReportSubMenu.Aberration:
                    SmallIconIndex = (int) MenuIconsSmall.AberrationReport;
                    break;
                case ReportSubMenu.Human:
                case ReportSubMenu.HumanGGOldRevision:
                case ReportSubMenu.Zoonotic:
                case ReportSubMenu.Simplified:
                    SmallIconIndex = (int) MenuIconsSmall.HumanReport;
                    break;
                case ReportSubMenu.Lab:
                    SmallIconIndex = (int) MenuIconsSmall.LabReport;
                    break;
                case ReportSubMenu.Vet:
                    SmallIconIndex = (int) MenuIconsSmall.VetReport;
                    break;
                case ReportSubMenu.Admin:
                    SmallIconIndex = (int) MenuIconsSmall.AdminReport;
                    break;
                default:
                    SmallIconIndex = -1;
                    break;
            }

            m_SubMenu = subMenu;
            m_Caption = caption;
            m_Order = order;
        }

          public MenuReportDescriptionAttribute(ReportSubMenu subMenu, string caption, int order, int smallIconIndex) : 
              this(subMenu,caption, order)
        {
            SmallIconIndex = smallIconIndex;
        }

        public string Caption
        {
            get { return m_Caption; }
        }

        public int Order
        {
            get { return m_Order; }
        }

        public ReportSubMenu SubMenu
        {
            get { return m_SubMenu; }
        }

        public int SmallIconIndex { get; set; }

        public EIDSSPermissionObject[] PermissionObjects { get; set; }
        public string[] PermissionActions { get; set; }
    }
}