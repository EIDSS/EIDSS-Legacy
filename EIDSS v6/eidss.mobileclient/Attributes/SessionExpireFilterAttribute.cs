using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eidss.mobileclient.Attributes
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["UserContext"] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new HttpStatusCodeResult(403); 
                }
                else
                {
                    filterContext.Result = new RedirectResult("/index.htm");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}