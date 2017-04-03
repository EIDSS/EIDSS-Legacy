using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace eidss.openapi.web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Gis",
                routeTemplate: "api/gis/{country}/{region}/{rayon}",
                defaults: new { controller = "gis", country = RouteParameter.Optional, region = RouteParameter.Optional, rayon = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GisExt",
                routeTemplate: "api/{ext}/gis/{country}/{region}/{rayon}",
                defaults: new { controller = "gis", country = RouteParameter.Optional, region = RouteParameter.Optional, rayon = RouteParameter.Optional, ext = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "ApiList",
                routeTemplate: "api/{controller}/list",
                defaults: new { action = "List" }
            );
            config.Routes.MapHttpRoute(
                name: "ApiListExt",
                routeTemplate: "api/{ext}/{controller}/list",
                defaults: new { action = "List", ext = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultOrganizationPersonApi",
                routeTemplate: "api/Organization/{idOrg}/Person/{id}",
                defaults: new { controller = "OrganizationPerson", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiOrganizationPersonExt",
                routeTemplate: "api/{ext}/Organization/{idOrg}/Person/{id}",
                defaults: new { controller = "OrganizationPerson", id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiOrganizationPersonListExt",
                routeTemplate: "api/{ext}/Organization/{idOrg}/Persons",
                defaults: new { controller = "OrganizationPerson", action = "List", ext = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultHumanCaseSampleApi",
                routeTemplate: "api/HumanCase/{idCase}/Sample/{id}",
                defaults: new { controller = "HumanCaseSample", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiHumanCaseSampleExt",
                routeTemplate: "api/{ext}/HumanCase/{idCase}/Sample/{id}",
                defaults: new { controller = "HumanCaseSample", id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiHumanCaseSampleListExt",
                routeTemplate: "api/{ext}/HumanCase/{idCase}/Samples",
                defaults: new { controller = "HumanCaseSample", action = "List", ext = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultHumanCaseTestApi",
                routeTemplate: "api/HumanCase/{idCase}/Test/{id}",
                defaults: new { controller = "HumanCaseTest", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiHumanCaseTestExt",
                routeTemplate: "api/{ext}/HumanCase/{idCase}/Test/{id}",
                defaults: new { controller = "HumanCaseTest", id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiHumanCaseTestListExt",
                routeTemplate: "api/{ext}/HumanCase/{idCase}/Tests",
                defaults: new { controller = "HumanCaseTest", action = "List", ext = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultHumanCaseTestInterpretationApi",
                routeTemplate: "api/HumanCase/{idCase}/TestInterpretation/{id}",
                defaults: new { controller = "HumanCaseTestInterpretation", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiHumanCaseTestInterpretationExt",
                routeTemplate: "api/{ext}/HumanCase/{idCase}/TestInterpretation/{id}",
                defaults: new { controller = "HumanCaseTestInterpretation", id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiHumanCaseTestInterpretationListExt",
                routeTemplate: "api/{ext}/HumanCase/{idCase}/TestInterpretations",
                defaults: new { controller = "HumanCaseTestInterpretation", action = "List", ext = RouteParameter.Optional }
            );



            config.Routes.MapHttpRoute(
                name: "DefaultVetCaseSampleApi",
                routeTemplate: "api/VetCase/{idCase}/Sample/{id}",
                defaults: new { controller = "VetCaseSample", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiVetCaseSampleExt",
                routeTemplate: "api/{ext}/VetCase/{idCase}/Sample/{id}",
                defaults: new { controller = "VetCaseSample", id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiVetCaseSampleListExt",
                routeTemplate: "api/{ext}/VetCase/{idCase}/Samples",
                defaults: new { controller = "VetCaseSample", action = "List", ext = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultVetCaseTestApi",
                routeTemplate: "api/VetCase/{idCase}/Test/{id}",
                defaults: new { controller = "VetCaseTest", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiVetCaseTestExt",
                routeTemplate: "api/{ext}/VetCase/{idCase}/Test/{id}",
                defaults: new { controller = "VetCaseTest", id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiVetnCaseTestListExt",
                routeTemplate: "api/{ext}/VetCase/{idCase}/Tests",
                defaults: new { controller = "VetCaseTest", action = "List", ext = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultVetCaseTestInterpretationApi",
                routeTemplate: "api/VetCase/{idCase}/TestInterpretation/{id}",
                defaults: new { controller = "VetCaseTestInterpretation", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiVetCaseTestInterpretationExt",
                routeTemplate: "api/{ext}/VetCase/{idCase}/TestInterpretation/{id}",
                defaults: new { controller = "VetCaseTestInterpretation", id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiVetnCaseTestInterpretationListExt",
                routeTemplate: "api/{ext}/VetCase/{idCase}/TestInterpretations",
                defaults: new { controller = "VetCaseTestInterpretation", action = "List", ext = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultVetCasePensideTestApi",
                routeTemplate: "api/VetCase/{idCase}/PensideTest/{id}",
                defaults: new { controller = "VetCasePensideTest", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiVetCasePensideTestExt",
                routeTemplate: "api/{ext}/VetCase/{idCase}/PensideTest/{id}",
                defaults: new { controller = "VetCasePensideTest", id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiVetnCasePensideTestListExt",
                routeTemplate: "api/{ext}/VetCase/{idCase}/PensideTests",
                defaults: new { controller = "VetCasePensideTest", action = "List", ext = RouteParameter.Optional }
            );



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiExt",
                routeTemplate: "api/{ext}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");
            config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "text/xml");

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            //config.EnableSystemDiagnosticsTracing();
        }
    }
}
