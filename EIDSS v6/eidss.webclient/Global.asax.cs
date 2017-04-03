using System;
using System.Globalization;
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
using eidss.webclient.Utils;
using MvcContrib.UI.InputBuilder;
using MvcContrib;
using System.IO;

namespace eidss.webclient
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
            //routes.IgnoreRoute("Content/Images/{*pathInfo}");

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

            //AreaRegistration.RegisterAllAreas();

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
            /*
            routes.MapRoute(
                "Translation", // Route name
                "Account/Translation/{id}", // URL with parameters
                new { controller = "Account", action = "UpdateTranslation", id = UrlParameter.Optional } // Parameter defaults
            );
            */
            routes.MapRoute(
                "VetCase", // Route name
                "VetCase/{action}/{type}/{id}", // URL with parameters
                new { controller = "VetCase", action = "Details", type = "", id = "" } // Parameter defaults
            );
            
            foreach (Route r in routes)
            {
                if (r.RouteHandler is SingleCultureMvcRouteHandler || r.RouteHandler is StopRoutingHandler)
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

            Bus.AddMessageHandler(typeof(LogAllMessagesObserver));

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            InputBuilder.BootStrap();

            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeBinder());

            RequiredValidator.FieldCaptions = EidssFields.Instance;
        }

        protected void Application_End()
        {
            LookupCacheListener.Stop();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("protected void Application_BeginRequest();");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            Application[HttpContext.Current.Request.UserHostAddress] = ex;
            LogError(ex);
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

        private void LogError(Exception ex)
        {
            string path = Config.GetSetting("ErrorLogPath");
            if (!String.IsNullOrEmpty(path))
            {
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        return;
                    }
                }

                string filename = String.Format("ErrorLog{0}{1}{2}.txt", DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Year);
                try
                {
                    using (StreamWriter stream = File.AppendText(Path.Combine(path, filename)))
                    {
                        //var connectionCredentials = new ConnectionCredentials();
                        //stream.WriteLine("ConnectionString: " + connectionCredentials.ConnectionString);
                        stream.Write(String.Format("{0} {1}\r\n {2}\r\n", DateTime.Now.ToString("MM/dd/yyyy hh:mm"), ex.Message, ex.StackTrace));
                        stream.WriteLine("--------------------------------------------------\r\n");
                        stream.Flush();
                    }
                }
                catch
                {
                }
            }
        }

        #region session handlers
        protected void Session_Start()
        {
            // Redirect mobile users to the mobile home page
            HttpRequest httpRequest = HttpContext.Current.Request;
            if (httpRequest.Browser.IsMobileDevice)
            {
                string redirectTo = Config.GetSetting("MobileWebEidssPath");
                if (!string.IsNullOrEmpty(redirectTo))
                {
                    HttpContext.Current.Response.Redirect(redirectTo);
                    return;
                }
            }

            var ms = new ModelStorage(Session.SessionID);
            //Session["ModelStorage"] = ms;
        }

        protected void Session_End()
        {
            ModelStorage.Remove(Session.SessionID);

            /*var ms = Session["ModelStorage"] as ModelStorage;
            if (ms != null)
            {
                Session.Remove("ModelStorage");
                ms.Dispose();
            }*/
        }
        #endregion
    }
}
