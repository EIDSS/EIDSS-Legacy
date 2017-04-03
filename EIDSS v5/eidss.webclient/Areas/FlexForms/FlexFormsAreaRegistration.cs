using System.Web.Mvc;

namespace eidss.webclient.Areas.FlexForms
{
    public class FlexFormsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FlexForms";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "FlexForms",
                "FlexForms/{controller}/{action}",
                new { action = "Index" }
            );
        }
    }
}
