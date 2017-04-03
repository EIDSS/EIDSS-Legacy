using System.Web.Mvc;

namespace eidss.webclient.Areas.HerdEpi
{
    public class HerdEpiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HerdEpi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HerdEpi_default",
                "HerdEpi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
