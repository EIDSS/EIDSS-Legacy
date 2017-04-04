using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources.TranslationTool;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using DevExpress.Web.Mvc;
using EIDSS;
using eidss.avr.mweb.Utils;
using eidss.avr.mweb.Utils.Localization;
using eidss.gis.common;
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
                "Statics",
                "s/{staticResourceVersion}/{*path}",
                new { controller = "Statics", action = "Index" }
            ).RouteHandler = new SingleCultureMvcRouteHandler();

            routes.MapRoute(
                "Start",
                "",
                new { controller = "Account", action = "Login" }
                ).RouteHandler = new SingleCultureMvcRouteHandler();

            routes.MapRoute(
                "Login",
                "Account/Login",
                new { controller = "Account", action = "Login" }
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
                new { controller = "Account", action = "Login", id = UrlParameter.Optional } // Parameter defaults
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
                if (!r.Constraints.Contains(typeof(CultureConstraint)))
                {
                    r.Constraints.Add("culture", new CultureConstraint(Cultures.Available));
                }
            }
        }

        
        public static void ExtractEmbeddedDll(string dllName)
        {
            // Get the byte[] of the DLL
            byte[] ba;
            var resource = "eidss.avr.mweb." + dllName;
            var curAsm = Assembly.GetExecutingAssembly();
            using (var stm = curAsm.GetManifestResourceStream(resource))
            {
                if (stm != null)
                {
                    ba = new byte[(int)stm.Length];
                    stm.Read(ba, 0, (int)stm.Length);
                }
                else
                {
                    return;
                }
            }

            var fileOk = false;
            string location;

            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                // Get the hash value of the Embedded DLL
                var fileHash = BitConverter.ToString(sha1.ComputeHash(ba)).Replace("-", string.Empty);

                // The full path of the DLL that will be saved
                var assembly = Assembly.GetExecutingAssembly();
                location = Path.GetDirectoryName(assembly.Location);

                // Check if the DLL is already existed or not?
                if (File.Exists(location))
                {
                    // Get the file hash value of the existed DLL
                    var bb = File.ReadAllBytes(location);
                    var fileHash2 = BitConverter.ToString(sha1.ComputeHash(bb)).Replace("-", string.Empty);

                    // Compare the existed DLL with the Embedded DLL
                    fileOk = fileHash == fileHash2;
                }
            }

            // Create the file on disk
            if (fileOk)
            {
                return;
            }
            if (location != null)
            {
                File.WriteAllBytes(location, ba);
            }
        }

        protected void Application_Start()
        {
            var connectionCredentials = new ConnectionCredentials();
            TranslationToolHelper.SetDefaultTranslationPath();
            DbManagerFactory.SetSqlFactory(connectionCredentials.ConnectionString);
            EidssUserContext.Init();
            CustomCultureHelper.CurrentCountry = EidssSiteContext.Instance.CountryID;

            EIDSS_LookupCacheHelper.Init();
            LookupCacheListener.Cleanup();
            LookupCacheListener.Listen();
            Localizer.MenuMessages = EidssMenu.Instance;

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
            bv.common.Core.Utils.SaveUsedXtraResource();
            LookupCacheListener.Stop();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Application[HttpContext.Current.Request.UserHostAddress] = ex;
            LogErrorInternal(ex);
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

        private void LogErrorInternal(Exception ex)
        {
            LogError.Log("ErrorLog_avr_", ex);
        }
        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            DevExpressHelper.Theme = GeneralSettings.Theme;
        }


        #region session handlers
        protected void Session_Start()
        {
            /*var ms = new ModelStorage(Session.SessionID);
            Session["ModelStorage"] = ms;*/
        }

        protected void Session_End()
        {
            bv.common.Core.Utils.SaveUsedXtraResource();
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