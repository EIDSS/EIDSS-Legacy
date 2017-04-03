using System.Web.Mvc;

namespace eidss.webclient.Areas.VetCaseSamples
{
    public class VetCaseSamplesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VetCaseSamples";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VetCaseSamples_default",
                "VetCaseSamples/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
