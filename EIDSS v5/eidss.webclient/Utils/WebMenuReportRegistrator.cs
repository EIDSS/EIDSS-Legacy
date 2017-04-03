using System.Reflection;
using bv.common.Core;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;

namespace eidss.webclient.Utils
{
    public class WebMenuReportRegistrator : BaseMenuReportRegistrator
    {
        private readonly MenuManagerBase m_MenuManager;

        protected WebMenuReportRegistrator(MenuManagerBase menuManager)
        {
            bv.common.Core.Utils.CheckNotNull(menuManager, "menuManager");
            m_MenuManager = menuManager;
        }

        public static void RegisterAllReports(MenuManagerBase menuManager)
        {
            var registrator = new WebMenuReportRegistrator(menuManager);
            registrator.RegisterAllReports();
        }

        protected override void RegisterReport(IMenuAction category, MenuReportDescriptionAttribute attribute, MethodInfo info)
        {
            // show reports if not archive mode on the web
            if (!ModelUserContext.Instance.IsArchiveMode)
            {
                new MenuActionWeb(m_MenuManager, category, attribute.Caption, attribute.Order)
                {
                    ActionUrl = string.Format("/Report/{0}", info.Name)
                };
            }

        }

        protected override IMenuAction RegisterSubMenu(string resourceKey, EIDSSPermissionObject permission, int order)
        {
            return new MenuActionWeb(m_MenuManager, m_MenuManager.Reports, resourceKey, order)
                {
                    SelectPermission = PermissionHelper.SelectPermission(permission)
                };
        }
    }
}