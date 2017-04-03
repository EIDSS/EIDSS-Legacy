using System.Web.Mvc;

namespace eidss.webclient.Areas.ContactedPerson
{
    public class ContactedPersonAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ContactedPerson";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ContactedPerson_default",
                "ContactedPerson/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
