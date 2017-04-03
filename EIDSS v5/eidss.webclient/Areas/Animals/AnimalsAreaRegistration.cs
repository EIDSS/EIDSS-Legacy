using System.Web.Mvc;

namespace eidss.webclient.Areas.Animals
{
    public class AnimalsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Animals";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Animals_default",
                "Animals/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
