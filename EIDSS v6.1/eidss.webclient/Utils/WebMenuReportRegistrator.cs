using System.Linq;
using System.Reflection;
using bv.common.Core;
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

        #region Paper Forms

        public static void RegisterAllPaperForms(MenuManagerBase menuManager)
        {
            var registrator = new WebMenuReportRegistrator(menuManager);
            var menu1 = registrator.RegisterSubMenu("MenuPaperForms", EIDSSPermissionObject.Report, 950);
            menu1.SmallIconIndex = (int) MenuIconsSmall.Reports;

            new MenuActionWeb(menuManager, menu1, "btGeneralCaseInvestigationForm", 1)
            {
                ActionUrl = "/Report/GeneralCaseInvestigationForm"
            };
            new MenuActionWeb(menuManager, menu1, "btAvianDiseaseOutbreaksForm", 2)
            {
                ActionUrl = "/Report/AvianDiseaseOutbreaksForm"
            };
            new MenuActionWeb(menuManager, menu1, "btLivestockDiseaseOutbreaksForm", 3)
            {
                ActionUrl = "/Report/LivestockDiseaseOutbreaksForm"
            };
        }

        #endregion

        #region Standart Reports

        public static void RegisterAllStandartReports(MenuManagerBase menuManager)
        {
            var registrator = new WebMenuReportRegistrator(menuManager);
            registrator.RegisterAllStandartReports();
        }

        public static void RegisterBarcodeReport(MenuManagerBase menuManager)
        {
            new MenuActionWeb(menuManager, menuManager.Reports, "MenuUniversalBarcodes", 1150)
            {
                ActionUrl = string.Format("/Report/PrintBarcodes")
            };
        }

        protected override void RegisterStandartReport(IMenuAction category, MenuReportDescriptionAttribute attribute, MethodInfo info)
        {
            var customAttribute = (MenuReportCustomizationAttribute)
                info.GetCustomAttributes(typeof (MenuReportCustomizationAttribute), true).FirstOrDefault();

            if (customAttribute != null && !customAttribute.AbsentInWeb)
            {
                new MenuActionWeb(m_MenuManager, category, attribute.Caption, attribute.Order)
                {
                    ActionUrl = string.Format("/Report/{0}", info.Name)
                };
            }
        }

        protected override IMenuAction RegisterSubMenu(string resourceKey, EIDSSPermissionObject permission, int order)
        {
            return RegisterSubMenu(m_MenuManager.Reports, resourceKey, permission, order);
        }

        protected override IMenuAction RegisterSubMenu
            (IMenuAction category, string resourceKey, EIDSSPermissionObject permission, int order)
        {
            return new MenuActionWeb(m_MenuManager, category, resourceKey, order)
            {
                SelectPermission = PermissionHelper.SelectPermission(permission)
            };
        }

        #endregion

        #region AVR reports

        protected override IMenuAction AddAvrMenuAction
            (IMenuAction parent, string name, long queryId, long layoutId, int order, bool hasAction)
        {
            var result = new MenuActionWeb(m_MenuManager, parent, name, order);
            if (hasAction)
            {
                result.ActionUrl = string.Format("/Account/LaunchAVRReport?queryId={0}&layoutId={1}", queryId, layoutId);
            }
            return result;
        }

        public static IMenuAction RegisterAllAvrReports(MenuManagerBase menuManager)
        {
            var registrator = new WebMenuReportRegistrator(menuManager);
            return registrator.RegisterAllAvrReports();
        }

//        protected override IMenuAction AddAvrMenuAction(IMenuAction parent, int order, long id, string name, bool hasAction)
//        {
//            MenuAction.ActionHandler actionHandler = hasAction ? m_AvrActionHandler : null;
//            var child = new MenuAction(actionHandler, m_MenuManager, parent, name, order)
//            {
//                Name = "btnStandardReport" + id,
//                Caption = name,
//                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AVRReport)
//            };
//            ret

        #endregion
    }
}