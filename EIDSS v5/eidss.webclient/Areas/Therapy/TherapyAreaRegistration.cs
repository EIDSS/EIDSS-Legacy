using System.Web.Mvc;

namespace eidss.webclient.Areas.Therapy
{
    public class TherapyAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Therapy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Therapy_default",
                "Therapy/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
