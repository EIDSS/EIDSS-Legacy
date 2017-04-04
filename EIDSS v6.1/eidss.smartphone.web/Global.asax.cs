using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using System.Web.Security;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Resources;
using eidss.web.common.Utils;
using MvcContrib.UI.InputBuilder;
using MvcContrib;
using eidss.smartphone.web.Utils;
using System.Web.Http;

namespace eidss.smartphone.web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class DateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var date = value.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);
            return date;
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        #region Routes
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Content/{*pathInfo}");

            routes.MapRoute(
                "Start",
                "",
                new { controller = "Home", action = "Index" }
            ).RouteHandler = new SingleCultureMvcRouteHandler();

            routes.MapRoute(
                "Login",
                "Account/ReLogin",
                new { controller = "Account", action = "ReLogin" }
            ).RouteHandler = new SingleCultureMvcRouteHandler();

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                "Errors",
                "Error/{page}",
                    new { controller = "Error", action = "Http404" }
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            foreach (Route r in routes)
            {
                if (r.RouteHandler is SingleCultureMvcRouteHandler || r.RouteHandler is StopRoutingHandler || r.RouteHandler is System.Web.Http.WebHost.HttpControllerRouteHandler)
                    continue;


                r.RouteHandler = new MultiCultureMvcRouteHandler();
                r.Url = "{culture}/" + r.Url;
                //Adding default culture 
                if (r.Defaults == null)
                {
                    r.Defaults = new RouteValueDictionary();
                }

                //Adding constraint for culture param
                if (r.Constraints == null)
                {
                    r.Constraints = new RouteValueDictionary();
                }
                if (!r.Constraints.Contains(typeof(CultureConstraint)))
                    r.Constraints.Add("culture", new CultureConstraint(Cultures.Available));

            }

        }

        #endregion
        protected void Application_Start()
        {
            var connectionCredentials = new ConnectionCredentials();
            DbManagerFactory.SetSqlFactory(connectionCredentials.ConnectionString);
            EidssUserContext.Init();
            CustomCultureHelper.CurrentCountry = EidssSiteContext.Instance.CountryID;
            LookupCacheListener.Cleanup();
            LookupCacheListener.Listen();
            Localizer.MenuMessages = EidssMenu.Instance;

            AreaRegistration.RegisterAllAreas(); 
            
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            InputBuilder.BootStrap();

         
            
            //ModelBinders.Binders.Add(typeof(DateTime), new DateTimeBinder());

            //RequiredValidator.FieldCaptions = EidssFields.Instance;
        }

        protected void Application_End()
        {
            LookupCacheListener.Stop();
        }
        /*protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            var connectionCredentials = new ConnectionCredentials();
            DbManagerFactory.SetSqlFactory(connectionCredentials.ConnectionString);
            EidssUserContext.Init();
            CustomCultureHelper.CurrentCountry = EidssSiteContext.Instance.CountryID;
            LookupCacheListener.Cleanup();
            LookupCacheListener.Listen();
            Localizer.MenuMessages = EidssMenu.Instance;
            RequiredValidator.FieldCaptions = EidssFields.Instance;
        }*/

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("protected void Application_BeginRequest();");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            Application[HttpContext.Current.Request.UserHostAddress] = ex;
            HttpContext.Current.ClearError();
            ProcessError(ex);
        }

        private void ProcessError(Exception ex)
        {
            var error = ex as HttpException;
            int statusCode = error == null ? 500 : error.GetHttpCode();

            string culture = Cultures.GetCulture(ModelUserContext.CurrentLanguage);

            switch (statusCode)
            {
                case 404:
                    Response.Redirect("~/" + culture + "/Error/Http404");
                    break;
                default: Response.Redirect("~/" + culture + "/Error/HttpError");
                    break;
            }
        }

        #region session handlers
        //protected void Session_Start()
        //{
        //    // Redirect mobile users to the mobile home page
        //    HttpRequest httpRequest = HttpContext.Current.Request;
        //    if (httpRequest.Browser.IsMobileDevice)
        //    {
        //        string redirectTo = Config.GetSetting("MobileWebAndroidPath");
        //        if (!string.IsNullOrEmpty(redirectTo))
        //        {
        //            HttpContext.Current.Response.Redirect(redirectTo);
        //            return;
        //        }
        //    }

        //    var ms = new ModelStorage(Session.SessionID);
        //    Session["ModelStorage"] = ms;
        //}

        //protected void Session_End()
        //{
        //    var ms = Session["ModelStorage"] as ModelStorage;
        //    if (ms != null)
        //    {
        //        Session.Remove("ModelStorage");
        //        ms.Dispose();
        //    }
        //}
        #endregion

    }
}