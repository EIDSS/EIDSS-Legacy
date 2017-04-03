using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using bv.common.Configuration;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.openapi.bll.Bll;
using eidss.openapi.contract;
using eidss.openapi.bll.Exceptions;
using log4net;

namespace eidss.openapi.web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var connectionCredentials = new ConnectionCredentials();
            DbManagerFactory.SetSqlFactory(connectionCredentials.ConnectionString);
            EidssUserContext.Init();

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}