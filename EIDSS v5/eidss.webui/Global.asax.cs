using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using bv.common.Configuration;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.webui.Utils;

namespace eidss.webui
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            AreaRegistration.RegisterAllAreas();
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            EidssUserContext.Init();

          //  Bus.AddMessageHandler(typeof(LogAllMessagesObserver));

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
          //  InputBuilder.BootStrap();
        }

        protected void Session_Start()
        {
            var ms = new ModelStorage(Session.SessionID);
            Session["ModelStorage"] = ms;

            EidssUserContext context = EidssUserContext.Instance as EidssUserContext;
            var target = new EidssSecurityManager();
            const string Organizaton = "NCDC&PH";
            const string Admin = "test_admin";
            const string AdminPassword = "test";
            int result = target.LogIn(Organizaton, Admin, AdminPassword);
        }
    }
}