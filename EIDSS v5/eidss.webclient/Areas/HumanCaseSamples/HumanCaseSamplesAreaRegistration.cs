using System.Web.Mvc;

namespace eidss.webclient.Areas.HumanCaseSamples
{
    public class HumanCaseSamplesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HumanCaseSamples";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HumanCaseSamples_default",
                "HumanCaseSamples/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
