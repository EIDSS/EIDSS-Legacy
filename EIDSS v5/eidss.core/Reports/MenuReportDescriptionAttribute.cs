using System;
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
            m_SubMenu = subMenu;
            m_Caption = caption;
            m_Order = order;
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

        public EIDSSPermissionObject Permission { get; set; }
    }
}