using System;
using System.Web;
using System.Web.Mvc;
using bv.common.Resources;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.web.common.Utils;

namespace eidss.webclient.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult ObjectExpired()
        {
            ViewData["Description"] = EidssMessages.Get("Error_ObjectExpired");
            ViewData["Title"] = EidssMessages.Get("Error_Custom");
            ViewData["SessionExpired"] = true;

            return View("Error");
        }

        public ActionResult HttpError()
        {
            Exception ex = null;

            ViewData["SessionExpired"] = false;
            try
            {
                ex = (Exception)HttpContext.Application[Request.UserHostAddress];                
                ViewData["Description"] = ex.Message;
            }
            catch
            {
                ViewData["Description"] = EidssMessages.Get("Error_Unknown");
            }

            if (ex != null)
            {
                if (ex is ObjectNotFoundException)
                {                    
                    ViewData["Description"] = EidssMessages.Get("Error_ObjectExpired");
                }
                else if (ex is DbModelException)
                {

                    DbModelException ex1 = ex as DbModelException;
                   // ViewData["Description"] = ex.Message;
                    //if (ex1 != null)
                    //{
                    //    ViewData["Description"] = ex1.Message;
                    //}
                    if (string.IsNullOrEmpty(ex1.MessageId))
                        ViewData["Description"] = ex1.Message;
                    else
                    {
                        string err = EidssMessages.Get(ex1.MessageId);
                        if (string.IsNullOrEmpty(err))
                        {
                            err = BvMessages.Get(ex1.MessageId, ex1.Message);
                        }
                        ViewData["Description"] = err;

                    }
                }
                else
                {
                    if (EidssUserContext.User == null || Session == null || String.IsNullOrEmpty(EidssUserContext.User.FullName))
                    {
                        ViewData["Description"] = EidssMessages.Get("SessionExpired");
                        ViewData["SessionExpired"] = true;
                    }
                    else
                        ViewData["Description"] = ex.Message;
                }
            }
            else
            {
                ViewData["Description"] = EidssMessages.Get("Error_Custom"); 
            }

            ViewData["Title"] = EidssMessages.Get("Error_Custom"); 

            return View("Error");
        }

        public ActionResult Http404()
        {
            ViewData["SessionExpired"] = false;
            ViewData["Title"] = EidssMessages.Get("Error_Custom"); 
            ViewData["Description"] = EidssMessages.Get("Error_PageNotFound");            
            return View();
        }

        // (optional) Redirect to home when /Error is navigated to directly  
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        //public ActionResult Test()
        //{
        //    return View();
        //}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Test(string confirmButton)
        {
            throw new DbModelException("msgid",new ApplicationException());
        }  
    }  
}
