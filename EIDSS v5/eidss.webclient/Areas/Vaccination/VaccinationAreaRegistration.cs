using System.Web.Mvc;

namespace eidss.webclient.Areas.Vaccination
{
    public class VaccinationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Vaccination";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Vaccination_default",
                "Vaccination/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
