using System.Web.Mvc;

namespace eidss.webclient.Areas.Freezer
{
    public class FreezerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Freezer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Freezer_default",
                "Freezer/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
