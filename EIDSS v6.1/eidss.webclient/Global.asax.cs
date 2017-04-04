using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using System.Configuration;
using System.Web.Security;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources.TranslationTool;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using eidss.gis.common;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Resources;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using MvcContrib.UI.InputBuilder;
using MvcContrib;
using System.IO;
using System.Reflection;

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

            routes.MapRoute(
                "Statics",
                "s/{staticResourceVersion}/{*path}",
                new { controller = "Statics", action = "Index" }
            ).RouteHandler = new SingleCultureMvcRouteHandler();

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

        #region Bundles
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/system").Include(
                //"~/Scripts/WidgetsFacades/DateFacade.js",
                "~/Scripts/jquery-1.9.1.min.js",
                "~/Scripts/jquery.form.js",
                //"~/Scripts/Kendo/min/kendo.web.min.js",

                //"~/Scripts/Kendo/min/kendo.core.min.js",
                "~/Scripts/Kendo/dbg/kendo.core.js",

                "~/Scripts/Kendo/min/kendo.router.min.js",
                "~/Scripts/Kendo/min/kendo.data.odata.min.js",
                "~/Scripts/Kendo/min/kendo.data.xml.min.js",
                "~/Scripts/Kendo/min/kendo.data.min.js",
                "~/Scripts/Kendo/min/kendo.binder.min.js",
                "~/Scripts/Kendo/min/kendo.fx.min.js",
                "~/Scripts/Kendo/min/kendo.view.min.js",
                "~/Scripts/Kendo/min/kendo.data.signalr.min.js",
                "~/Scripts/Kendo/min/kendo.validator.min.js",
                "~/Scripts/Kendo/min/kendo.userevents.min.js",
                "~/Scripts/Kendo/min/kendo.draganddrop.min.js",
                "~/Scripts/Kendo/min/kendo.mobile.scroller.min.js",
                "~/Scripts/Kendo/min/kendo.groupable.min.js",
                "~/Scripts/Kendo/min/kendo.reorderable.min.js",
                "~/Scripts/Kendo/min/kendo.resizable.min.js",
                "~/Scripts/Kendo/min/kendo.sortable.min.js",
                "~/Scripts/Kendo/min/kendo.selectable.min.js",
                "~/Scripts/Kendo/min/kendo.button.min.js",
                "~/Scripts/Kendo/min/kendo.pager.min.js",
                //"~/Scripts/Kendo/min/kendo.popup.min.js",
                "~/Scripts/Kendo/dbg/kendo.popup.js",

                "~/Scripts/Kendo/min/kendo.notification.min.js",
                "~/Scripts/Kendo/min/kendo.tooltip.min.js",
                "~/Scripts/Kendo/min/kendo.list.min.js",

                //"~/Scripts/Kendo/min/kendo.calendar.min.js",
                "~/Scripts/Kendo/dbg/kendo.calendar.js",
                //"~/Scripts/Kendo/min/kendo.datepicker.min.js",
                "~/Scripts/Kendo/dbg/kendo.datepicker.js",

                "~/Scripts/Kendo/min/kendo.autocomplete.min.js",
                "~/Scripts/Kendo/min/kendo.dropdownlist.min.js",
                "~/Scripts/Kendo/min/kendo.combobox.min.js",
                "~/Scripts/Kendo/min/kendo.multiselect.min.js",
                "~/Scripts/Kendo/min/kendo.slider.min.js",
                "~/Scripts/Kendo/min/kendo.colorpicker.min.js",
                "~/Scripts/Kendo/min/kendo.numerictextbox.min.js",
                "~/Scripts/Kendo/min/kendo.filtermenu.min.js",
                "~/Scripts/Kendo/min/kendo.menu.min.js",

                "~/Scripts/Kendo/min/kendo.columnmenu.min.js",
                "~/Scripts/Kendo/min/kendo.editable.min.js",
                "~/Scripts/Kendo/min/kendo.window.min.js",
                //"kendo.mobile.view.js","kendo.mobile.loader.js","kendo.mobile.pane.js","kendo.mobile.application.js","kendo.mobile.popover.js","kendo.mobile.shim.js","kendo.mobile.actionsheet.js",
                "~/Scripts/Kendo/min/kendo.grid.min.js",
                "~/Scripts/Kendo/min/kendo.listview.min.js",
                "~/Scripts/Kendo/min/kendo.upload.min.js",
                "~/Scripts/Kendo/min/kendo.imagebrowser.min.js",
                //"editor/main.js","editor/dom.js","editor/serializer.js","editor/range.js","editor/system.js","editor/inlineformat.js","editor/formatblock.js","editor/linebreak.js","editor/lists.js","editor/link.js","editor/image.js","editor/components.js","editor/indent.js","editor/viewhtml.js","editor/formatting.js","editor/toolbar.js","editor/tables.js",
                "~/Scripts/Kendo/min/kendo.maskedtextbox.min.js",
                "~/Scripts/Kendo/min/kendo.panelbar.min.js",
                "~/Scripts/Kendo/min/kendo.progressbar.min.js",
                "~/Scripts/Kendo/min/kendo.tabstrip.min.js",
                "~/Scripts/Kendo/min/kendo.timepicker.min.js",
                "~/Scripts/Kendo/min/kendo.datetimepicker.min.js",
                "~/Scripts/Kendo/min/kendo.treeview.min.js",
                "~/Scripts/Kendo/min/kendo.splitter.min.js",
                "~/Scripts/Kendo/min/kendo.scheduler.view.min.js",
                "~/Scripts/Kendo/min/kendo.scheduler.dayview.min.js",
                "~/Scripts/Kendo/min/kendo.scheduler.agendaview.min.js",
                "~/Scripts/Kendo/min/kendo.scheduler.monthview.min.js",
                "~/Scripts/Kendo/min/kendo.scheduler.recurrence.min.js",
                "~/Scripts/Kendo/min/kendo.scheduler.min.js",

                "~/Scripts/Kendo/min/kendo.aspnetmvc.min.js"
                ));

             

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionCode = string.Format("-{0}-{1}-{2}-{3}", version.Major, version.Minor, version.Build, version.Revision);
            bundles.Add(new ScriptBundle("~/bundles/EIDSS" + versionCode).Include(
                "~/Scripts/WidgetsFacades/WindowFacade.js",
                "~/Scripts/WidgetsFacades/GlobalizationFacade.js",
                "~/Scripts/WidgetsFacades/GridFacade.js",
                "~/Scripts/WidgetsFacades/ComboboxFacade.js",
                "~/Scripts/WidgetsFacades/DatePickerFacade.js",
                "~/Scripts/WidgetsFacades/ValidatorFacade.js",
                "~/Scripts/WidgetsFacades/CommonWidgetsFacade.js",
                "~/Scripts/WidgetsFacades/NumericTextBoxFacade.js",
                "~/Scripts/WidgetsFacades/TabStripFacade.js",
                "~/Scripts/EIDSS/DefaultPage.js",
                "~/Scripts/EIDSS/TwinkleTextBox.js",
                "~/Scripts/EIDSS/ActionsPanelScripts.js",
                "~/Scripts/EIDSS/Config.js",
                "~/Scripts/EIDSS/Dialogs.js",
                "~/Scripts/EIDSS/Actions.js",
                "~/Scripts/EIDSS/Common.js",
                "~/Scripts/EIDSS/BvUrls.js",
                "~/Scripts/EIDSS/BvGrid.js",
                "~/Scripts/EIDSS/CustomActions.js",
                "~/Scripts/EIDSS/SearchPanel.js",
                "~/Scripts/EIDSS/ListForm.js",
                "~/Scripts/EIDSS/DetailPage.js",
                "~/Scripts/EIDSS/Notification.js",
                "~/Scripts/EIDSS/Map.js",
                "~/Scripts/EIDSS/BvComboBox.js",
                "~/Scripts/EIDSS/SearchPicker.js",
                "~/Scripts/EIDSS/FfGrid.js",
                "~/Scripts/EIDSS/FormRefresher.js",
                "~/Scripts/EIDSS/PaperForm.js",
                "~/Scripts/EIDSS/FlexForms.js",
                "~/Scripts/EIDSS/PopupMenu.js",
                "~/Scripts/EIDSS/BvCheckedComboBox.js",
                "~/Scripts/EIDSS/Address.js",
                "~/Scripts/EIDSS/AggregateCase.js",
                "~/Scripts/EIDSS/AggregateSummary.js",
                "~/Scripts/EIDSS/ASCampaign.js",
                "~/Scripts/EIDSS/ASSession.js",
                "~/Scripts/EIDSS/Organization.js",
                "~/Scripts/EIDSS/Sample.js",
                "~/Scripts/EIDSS/Farm.js",
                "~/Scripts/EIDSS/VetCase.js",
                "~/Scripts/EIDSS/Person.js",
                "~/Scripts/EIDSS/GeoLocation.js",
                "~/Scripts/EIDSS/Outbreak.js",
                "~/Scripts/EIDSS/Employee.js",
                "~/Scripts/EIDSS/HumanCase.js",
                "~/Scripts/EIDSS/HumanAntimicrobialTherapy.js",
                "~/Scripts/EIDSS/Patient.js",
                "~/Scripts/EIDSS/Laboratory.js",
                "~/Scripts/EIDSS/VsSession.js"
                ));
        }
        #endregion

        protected void Application_Start()
        {
            RegisterBundles(BundleTable.Bundles);
            TranslationToolHelper.SetDefaultTranslationPath();
            var connectionCredentials = new ConnectionCredentials();
            DbManagerFactory.SetSqlFactory(connectionCredentials.ConnectionString);
            EidssUserContext.Init();
            CustomCultureHelper.CurrentCountry = EidssSiteContext.Instance.CountryID;
            LookupCacheListener.Cleanup();
            LookupCacheListener.Listen();
            Localizer.MenuMessages = EidssMenu.Instance;

            Bus.AddMessageHandler(typeof(LogAllMessagesObserver));

            var bLogging = Config.GetBoolSetting("IsActionLogging");
            if (bLogging)
                GlobalFilters.Filters.Add(new LogActionFilterAttribute());

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

        /*protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("protected void Application_BeginRequest();");
        }*/

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
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
                default: Response.Redirect("~/" + culture + "/Error/HttpError");
                    break;
            }
        }

        private void LogErrorInternal(Exception ex)
        {
            LogError.Log("ErrorLog", ex, stream =>
            {
                if (ex is DbModelException)
                {
                    IObject o = (ex as DbModelException).Obj;
                    if (o != null && o is eidss.model.Schema.Patient)
                    {
                        eidss.model.Schema.Patient p = o as eidss.model.Schema.Patient;
                        stream.WriteLine(String.Format("Patient: idfCurrentResidenceAddress = {0}, CurrentResidenceAddress.idfGeoLocation = {1}",
                            p.idfCurrentResidenceAddress.HasValue ? p.idfCurrentResidenceAddress.Value.ToString() : "null",
                            p.CurrentResidenceAddress == null ? "null" : p.CurrentResidenceAddress.idfGeoLocation.ToString()
                            ));
                        stream.WriteLine(String.Format("Patient: idfRegistrationAddress = {0}, RegistrationAddress.idfGeoLocation = {1}",
                            p.idfRegistrationAddress.HasValue ? p.idfRegistrationAddress.Value.ToString() : "null",
                            p.RegistrationAddress == null ? "null" : p.RegistrationAddress.idfGeoLocation.ToString()
                            ));
                        stream.WriteLine(String.Format("Patient: idfEmployerAddress = {0}, EmployerAddress.idfGeoLocation = {1}",
                            p.idfEmployerAddress.HasValue ? p.idfEmployerAddress.Value.ToString() : "null",
                            p.EmployerAddress == null ? "null" : p.EmployerAddress.idfGeoLocation.ToString()
                            ));
                    }
                }
            });
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

            //var ms = new ModelStorage(ModelUserContext.ClientID);
        }

        protected void Session_End()
        {
            //ModelStorage.Remove(ModelUserContext.ClientID);
        }
        #endregion
    }
}
