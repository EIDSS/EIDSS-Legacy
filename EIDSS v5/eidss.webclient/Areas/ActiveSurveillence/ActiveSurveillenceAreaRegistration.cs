using System.Web.Mvc;

namespace eidss.webclient.Areas.ActiveSurveillence
{
    public class ActiveSurveillenceAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ActiveSurveillence";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ActiveSurveillence_default",
                "ActiveSurveillence/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
