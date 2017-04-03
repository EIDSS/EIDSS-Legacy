using System.Web.Mvc;

namespace eidss.webclient.Areas.Sample
{
    public class LabSampleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Sample";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Sample_default",
                "Sample/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
