using System.Web.Mvc;

namespace eidss.webui.Areas.Address
{
    public class AddressAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Address";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Address_default",
                "Address/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
