using System;
using System.Reflection;
using bv.common.Core;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Reports;

namespace eidss.winclient
{
    public class WinMenuReportRegistrator : BaseMenuReportRegistrator
    {
        private readonly MenuActionManager m_MenuManager;
        private readonly IReportFactory m_ReportFactory;

        protected WinMenuReportRegistrator(IReportFactory reportFactory, MenuActionManager menuManager)
        {
            Utils.CheckNotNull(reportFactory, "reportFactory");
            Utils.CheckNotNull(menuManager, "menuManager");

            m_ReportFactory = reportFactory;
            m_MenuManager = menuManager;
        }

        public static void RegisterAllReports(IReportFactory reportFactory, MenuActionManager menuManager)
        {
            var reportRegistrator = new WinMenuReportRegistrator(reportFactory, menuManager);
            reportRegistrator.RegisterAllReports();
        }

        protected override void RegisterReport(IMenuAction category, MenuReportDescriptionAttribute attribute, MethodInfo info)
        {
            var reportHandler = (MenuAction.Handler) Delegate.CreateDelegate(typeof (MenuAction.Handler), m_ReportFactory, info);
            new MenuAction(reportHandler, m_MenuManager, category, attribute.Caption, attribute.Order);
        }

        protected override IMenuAction RegisterSubMenu(string resourceKey, EIDSSPermissionObject permission, int order)
        {
            return new MenuAction(m_MenuManager, m_MenuManager.Reports, resourceKey, order)
                {
                    SelectPermission = PermissionHelper.SelectPermission(permission)
                };
        }
    }
}