using System.Web.Mvc;

namespace eidss.webclient.Areas.ActionPanel
{
    public class ActionPanelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ActionPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ActionPanel_default",
                "ActionPanel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
