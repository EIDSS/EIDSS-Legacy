using System.Collections.Generic;
using System.Web;
using System.Configuration;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.Core;
using System;
using System.Linq;
using System.Threading;
using eidss.web.common.Utils;

namespace eidss.webclient.Utils
{
    public static class MenuHelper
    {
        private static string getMenuCacheKey()
        {
            return String.Format("{1}Menu{0}", EidssUserContext.Instance.CurrentUser.EmployeeID.ToString(), Thread.CurrentThread.CurrentCulture.ToString());
        }
        private static string getIconMenuCacheKey()
        {
            return String.Format("{1}MenuIcon{0}", EidssUserContext.Instance.CurrentUser.EmployeeID.ToString(), Thread.CurrentThread.CurrentCulture.ToString());
        }
        public static void ClearMenuCache()
        {
            HttpContext.Current.Session.Remove(getMenuCacheKey());
            HttpContext.Current.Session.Remove(getIconMenuCacheKey());
        }

        private static void BuildMenuList(MenuCategory cat, IMenuAction item)
        {
            if (item.IsCategory)
            {
                if (item.Items.Count > 0)
                {
                    var menuItem = PermissionParser.CreateMenuFolder(item);
                    cat.Items.Add(menuItem);
                    item.Items.OrderBy(c => c.Order).ToList().ForEach(c => BuildMenuList(menuItem, c));
                }
            }
            else
            {
                string culture = Thread.CurrentThread.CurrentCulture.ToString();
                var menuItem = PermissionParser.CreateMenuItem(item, culture);
                cat.Items.Add(menuItem);
            }
        }
        private static void BuildMenuList(MenuItem folder, IMenuAction item)
        {
            if (item.IsCategory)
            {
                if (item.Items.Count > 0)
                {
                    var menuItem = PermissionParser.CreateMenuFolder(item);
                    folder.Items.Add(menuItem);
                    item.Items.OrderBy(c => c.Order).ToList().ForEach(c => BuildMenuList(menuItem, c));
                }
            }
            else
            {
                string culture = Thread.CurrentThread.CurrentCulture.ToString();
                var menuItem = PermissionParser.CreateMenuItem(item, culture);
                folder.Items.Add(menuItem);
            }
        }

        public static List<MenuCategory> GetMenu()
        {
            var cachekey = getMenuCacheKey();

            var menu = HttpContext.Current.Session[cachekey] as List<MenuCategory>;

            if (menu == null)
            {
                menu = MenuCategory.GetMenuList(
                    EidssUserContext.Instance as EidssUserContext,
                    HttpRuntime.AppDomainAppPath + ConfigurationManager.AppSettings["MenuFilePath"]);

                var menuReport = menu.Find(c => c.IsReport);
                if (menuReport != null)
                {
                    menuReport.IsActive = true;
                    var actionManager = new MenuActionManagerWeb();
                    WebMenuReportRegistrator.RegisterAllPaperForms(actionManager);
                    WebMenuReportRegistrator.RegisterAllStandartReports(actionManager);
                    WebMenuReportRegistrator.RegisterAllAvrReports(actionManager);
                    WebMenuReportRegistrator.RegisterBarcodeReport(actionManager);
                    actionManager.Reports.Items.OrderBy(c => c.Order).ToList().ForEach(c => BuildMenuList(menuReport, c));
                }

                if (!BaseSettings.TranslationMode)
                    HttpContext.Current.Session.Add(cachekey, menu);                
            }

            var m_ConnectionCredentials = new ConnectionCredentials(null, "Archive");
            if (m_ConnectionCredentials.IsCorrect && EidssUserContext.Instance.CanDo("CanReadArchivedData.Execute"))
            {
                var menucopy = new List<MenuCategory>(menu);
                string culture = Thread.CurrentThread.CurrentCulture.ToString();
                var titleDatabase = Translator.GetMenuName("MenuDatabase", "Database");
                if (!EidssUserContext.Instance.IsArchiveMode)
                {
                    var titleArchive = Translator.GetMenuName("MenuArchive", "Connect to archive data");
                    menucopy.Add(new MenuCategory(titleDatabase, true, new List<MenuItem>()
                    { 
                        new MenuItem(titleArchive, String.Format("/{0}{1}", culture, "/Account/Archive"), "")
                    }));
                }
                else
                {
                    var titleActual = Translator.GetMenuName("MenuActual", "Connect to actual data");
                    menucopy.Add(new MenuCategory(titleDatabase, true, new List<MenuItem>()
                    { 
                        new MenuItem(titleActual, String.Format("/{0}{1}", culture, "/Account/Actual"), "")
                    }));
                }
                return menucopy;
            }

            return menu;
        }

        public static List<MenuItem> GetIconMenu()
        {
            string cachekey = getIconMenuCacheKey();

            List<MenuItem> menu = HttpContext.Current.Session[cachekey] as List<MenuItem>;

            if (menu == null)
            {
                menu = MenuItem.GetIconMenu(
                    eidss.model.Core.EidssUserContext.Instance as EidssUserContext,
                    HttpRuntime.AppDomainAppPath + ConfigurationManager.AppSettings["IconMenuFilePath"]);

                HttpContext.Current.Session.Add(cachekey, menu);
            }


            return menu;
        }
    }   
}