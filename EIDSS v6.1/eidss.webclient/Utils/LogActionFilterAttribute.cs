using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using bv.common.Configuration;

namespace eidss.webclient.Utils
{
    public class LogActionFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(filterContext);
        }

        private List<Tuple<string, string>> IgnoreActions = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("Account", "Heartbeat"),
                new Tuple<string, string>("Search", "GetLookupSourceNew"),
                new Tuple<string, string>("Statics", "Index"),
                new Tuple<string, string>("System", "SelectGeneric"),
                new Tuple<string, string>("System", "_GridBinding"),
                //new Tuple<string, string>("System", "SetValue"),
                new Tuple<string, string>("SystemCached", "SelectOrganizations"),
            };

        private static object gLock = new object();
        private void Log(ActionExecutingContext filterContext)
        {
            try
            {
                string path = Config.GetSetting("ErrorLogPath");
                if (!String.IsNullOrEmpty(path))
                {
                    if (!Directory.Exists(path))
                    {
                        try
                        {
                            Directory.CreateDirectory(path);
                        }
                        catch
                        {
                            return;
                        }
                    }

                    if (filterContext.IsChildAction)
                        return;

                    var controllerName = filterContext.RouteData.Values["controller"].ToString();
                    var actionName = filterContext.RouteData.Values["action"].ToString();
                    var culture = filterContext.RouteData.Values["culture"];

                    foreach (var a in IgnoreActions)
                    {
                        if (a.Item1 == controllerName && a.Item2 == actionName)
                            return;
                    }

                    var method = filterContext.HttpContext.Request.HttpMethod;

                    var session = "";
                    if (filterContext.HttpContext.Session != null)
                        session = filterContext.HttpContext.Session.SessionID;
                    else if (filterContext.HttpContext.Request.Params["ClientID"] != null)
                    {
                        session = filterContext.HttpContext.Request.Params["ClientID"];
                        if (session.Contains(",")) 
                            session = session.Substring(session.LastIndexOf(",") + 1);
                    }

                    var runFrom = filterContext.HttpContext.Request.Params["RunFrom"] == null ? "" : filterContext.HttpContext.Request.Params["RunFrom"];

                    var user = "";
                    try{ user = eidss.model.Core.EidssUserContext.User == null ? "" : eidss.model.Core.EidssUserContext.User.LoginName; }
                    catch(Exception){}

                    var referer = filterContext.HttpContext.Request.UrlReferrer == null ? "" : filterContext.HttpContext.Request.UrlReferrer.PathAndQuery;

                    var sbPars = new StringBuilder();
                    filterContext.HttpContext.Request.QueryString.AllKeys.Aggregate(sbPars, 
                        (s, c) => s.Append(s.Length == 0 ? "" : "&").Append(c).Append("=").Append(filterContext.HttpContext.Request.QueryString[c]));
                    filterContext.HttpContext.Request.Form.AllKeys.Aggregate(sbPars, 
                        (s, c) => s.Append(s.Length == 0 ? "" : "&").Append(c).Append("=").Append(filterContext.HttpContext.Request.Form[c]));

                    var message = String.Format("{0:yyyy-MM-ddTHH:mm:ss.ffffff}\t{1}-{2}-{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",
                        DateTime.Now, controllerName, actionName, method, culture, runFrom, referer, session, user, sbPars.ToString());

                    string filename = String.Format("ActionLog{0}{1}{2}.txt", DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Year);

                    lock (gLock)
                    {
                        using (StreamWriter stream = File.AppendText(Path.Combine(path, filename)))
                        {
                            stream.WriteLine(message);
                            stream.Flush();
                        }
                    }
                }
            }
            catch
            {
            }

        }
    }
}