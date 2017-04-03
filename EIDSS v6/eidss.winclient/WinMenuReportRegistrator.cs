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
        private readonly MenuAction.ActionHandler m_AvrActionHandler;

        protected WinMenuReportRegistrator
            (MenuActionManager menuManager, IReportFactory reportFactory, MenuAction.ActionHandler avrActionHandler)
        {
            Utils.CheckNotNull(menuManager, "menuManager");

            m_ReportFactory = reportFactory;
            m_MenuManager = menuManager;
            m_AvrActionHandler = avrActionHandler;
        }

        #region Standart Reports

        public static void RegisterAllStandartReports(MenuActionManager menuManager, IReportFactory reportFactory)
        {
            var reportRegistrator = new WinMenuReportRegistrator(menuManager, reportFactory, null);
            reportRegistrator.RegisterAllStandartReports();
        }

        protected override void RegisterStandartReport(IMenuAction category, MenuReportDescriptionAttribute attribute, MethodInfo info)
        {
            var reportHandler = (MenuAction.Handler) Delegate.CreateDelegate(typeof (MenuAction.Handler), m_ReportFactory, info);
            var action = new MenuAction(reportHandler, m_MenuManager, category, attribute.Caption, attribute.Order);
            action.SmallIconIndex = attribute.SmallIconIndex;
        }

        protected override IMenuAction RegisterSubMenu(string resourceKey, EIDSSPermissionObject permission, int order)
        {
            return RegisterSubMenu(m_MenuManager.Reports, resourceKey, permission, order);
        }

        protected override IMenuAction RegisterSubMenu
            (IMenuAction category, string resourceKey, EIDSSPermissionObject permission, int order)
        {
            return new MenuAction(m_MenuManager, category, resourceKey, order)
            {
                SelectPermission = PermissionHelper.SelectPermission(permission)
            };
        }

        #endregion

        #region AVR reports

        public static IMenuAction RegisterAllAvrReports
            (MenuActionManager menuManager, MenuAction.ActionHandler avrActionHandler)
        {
            var reportRegistrator = new WinMenuReportRegistrator(menuManager, null, avrActionHandler);
            return reportRegistrator.RegisterAllAvrReports();
        }

        protected override IMenuAction AddAvrMenuAction(IMenuAction parent, string name, long queryId, long layoutId, int order, bool hasAction)
        {
            MenuAction.ActionHandler actionHandler = hasAction ? m_AvrActionHandler : null;
            var child = new MenuAction(actionHandler, m_MenuManager, parent, name, order)
            {
                Name = string.Format("btnStandardReport_{0}_{1}_{2}", +queryId, layoutId,  Guid.NewGuid().ToString().Substring(0, 4)),
                Caption = name,
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AVRReport)
            };
            return child;
        }

        #endregion
    }
}