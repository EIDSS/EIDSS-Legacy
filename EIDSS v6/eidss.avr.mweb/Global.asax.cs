using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using DevExpress.Web.Mvc;
using EIDSS;
using eidss.avr.mweb.Utils;
using eidss.avr.mweb.Utils.Localization;
using eidss.model.Core;
using eidss.model.Resources;
using MvcContrib;
using MvcContrib.UI.InputBuilder;
using eidss.web.common.Utils;

namespace eidss.avr.mweb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");
            routes.IgnoreRoute("Content/{*pathInfo}");
            //routes.IgnoreRoute("Content/Images/{*pathInfo}");

            routes.MapRoute(
                "Start",
                "",
                new {controller = "Account", action = "Login"}
                ).RouteHandler = new SingleCultureMvcRouteHandler();

            routes.MapRoute(
                "Login",
                "Account/Login",
                new {controller = "Account", action = "Login"}
                ).RouteHandler = new SingleCultureMvcRouteHandler();

            routes.MapRoute(
                "Report",
                "Account/Layout",
                new { controller = "Account", action = "Layout" }
                ).RouteHandler = new SingleCultureMvcRouteHandler();

            routes.MapRoute(
                "Error",
                "Error/HttpError",
                new { controller = "Error", action = "HttpError" }
                );

            routes.MapRoute(
                "Errors",
                "Error/{page}",
                new { controller = "Error", action = "Http404" }
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Account", action = "Login", id = UrlParameter.Optional} // Parameter defaults
                );

            AreaRegistration.RegisterAllAreas();

            foreach (Route r in routes)
            {
                if (r.RouteHandler is SingleCultureMvcRouteHandler || r.RouteHandler is StopRoutingHandler)
                {
                    continue;
                }

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
                if (!r.Constraints.Contains(typeof (CultureConstraint)))
                {
                    r.Constraints.Add("culture", new CultureConstraint(Cultures.Available));
                }
            }
        }

        protected void Application_Start()
        {
            var connectionCredentials = new ConnectionCredentials();
            DbManagerFactory.SetSqlFactory(connectionCredentials.ConnectionString);
            EidssUserContext.Init();
            CustomCultureHelper.CurrentCountry = EidssSiteContext.Instance.CountryID;

            EIDSS_LookupCacheHelper.Init();
            LookupCacheListener.Cleanup();
            LookupCacheListener.Listen();

            ClassLoader.Init("eidss_db.dll", bv.common.Core.Utils.GetDesktopExecutingPath());

            //AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            InputBuilder.BootStrap();

            BaseFieldValidator.FieldCaptions = EidssFields.Instance;

            ModelBinders.Binders.DefaultBinder = new DevExpressEditorsBinder();

            SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
            XtraWebLocalizer.Activate();
        }

        protected void Application_End()
        {
            LookupCacheListener.Stop();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
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
                default:
                    Response.Redirect("~/" + culture + "/Error/HttpError");
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
                        stream.Write("{0} {1}\r\n {2}\r\n", DateTime.Now.ToString("MM/dd/yyyy hh:mm"), ex.Message, ex.StackTrace);
                        stream.WriteLine("--------------------------------------------------\r\n");
                        stream.Flush();
                    }
                }
                catch
                {
                    // todo: process error
                }
            }
        }
        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            DevExpressHelper.Theme = GeneralSettings.Theme;
        }


        #region session handlers
        protected void Session_Start()
        {
            var ms = new ModelStorage(Session.SessionID);
            Session["ModelStorage"] = ms;
        }

        protected void Session_End()
        {
            var ms = Session["ModelStorage"] as ModelStorage;
            if (ms != null)
            {
                Session.Remove("ModelStorage");
                ms.Dispose();
            }
        }
        #endregion
    }
}