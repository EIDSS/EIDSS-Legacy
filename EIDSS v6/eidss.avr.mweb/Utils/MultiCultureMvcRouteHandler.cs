using System.Web;
using System.Web.Mvc;

using System.Globalization;
using System.Web.Routing;
using System.Threading;

namespace eidss.avr.mweb.Utils
{
    public class MultiCultureMvcRouteHandler : MvcRouteHandler
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
}