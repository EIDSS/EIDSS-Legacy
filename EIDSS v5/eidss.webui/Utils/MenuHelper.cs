using System.Collections.Generic;
using System.Web;
using System.Configuration;

namespace eidss.webui.Utils
{
    public static class MenuHelper
    {
        public static List<MenuCategory> GetMenu()
        {
            return MenuCategory.GetMenuList(
                null, //current user context
                HttpRuntime.AppDomainAppPath + ConfigurationManager.AppSettings["MenuFilePath"]);
        }
    }
}