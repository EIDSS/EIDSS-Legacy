using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.mobileclient.Utils;
using eidss.model.Core;
using eidss.model.Resources;

namespace eidss.mobileclient
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        #region Helpers

        /*class Cultures
        {
            public static string[] Available = new string[] { "en", "ru", "en-US", "ru-RU", "ka-GE", "uk-UA", "az-Latn-AZ", "kk-KZ" };
        }*/

        class CultureConstraint : IRouteConstraint
        {
            private string[] _values;

            public CultureConstraint(params string[] values)
            {
                _values = values;
            }
            private bool ValueExists(string value)
            {
                return _values.Any(s => String.Equals(value, s, StringComparison.InvariantCultureIgnoreCase));
            }

            public bool Match(HttpContextBase httpContext, Route route, string parameterName,
                                RouteValueDictionary values, RouteDirection routeDirection)
            {
                // Get the value called "parameterName" from the 
                // RouteValueDictionary called "value"
                string value = values[parameterName].ToString();
                // Return true is the list of allowed values contains 
                // this value.
                return ValueExists(value);
            }

        }

        class MultiCultureMvcRouteHandler : MvcRouteHandler
        {
            protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                var culture = requestContext.RouteData.Values["culture"].ToString();
                var ci = new CultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
                return base.GetHttpHandler(requestContext);
            }
        }

        class SingleCultureMvcRouteHandler : MvcRouteHandler { }

        #endregion

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Start",
                "",
                new { controller = "Home", action = "Index" }
            ).RouteHandler = new SingleCultureMvcRouteHandler();

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            foreach (Route r in routes)
            {
                if (!(r.RouteHandler is SingleCultureMvcRouteHandler))
                {
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
                    r.Constraints.Add("culture", new CultureConstraint(Localizer.SupportedLanguages.Values.ToArray()));
                }
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            var connectionCredentials = new ConnectionCredentials();
            DbManagerFactory.SetSqlFactory(connectionCredentials.ConnectionString);
            EidssUserContext.Init(() => 2);
            LookupCacheListener.Cleanup();
            LookupCacheListener.Listen();
            Localizer.MenuMessages = EidssMenu.Instance;

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            var ms = new ModelStorage(Session.SessionID);
            Session["ModelStorage"] = ms;
        }

        protected void Session_End(object sender, EventArgs e)
        {
            var ms = Session["ModelStorage"] as ModelStorage;
            if (ms != null)
            {
                Session.Remove("ModelStorage");
                ms.Dispose();
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            Application[HttpContext.Current.Request.UserHostAddress] = ex;
            LogError(ex);
            HttpContext.Current.ClearError();
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

                string filename = String.Format("ErrorLog_mobile_{0}{1}{2}.txt", DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Year);
                try
                {
                    using (StreamWriter stream = File.AppendText(Path.Combine(path, filename)))
                    {
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
    }
}
