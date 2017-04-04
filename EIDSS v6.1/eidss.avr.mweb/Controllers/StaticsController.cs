using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eidss.webclient.Controllers
{
    public class StaticsController : Controller
    {
        private HttpResponseBase _response;
        private HttpRequestBase _request;

        public StaticsController()
        {
        }

        public StaticsController(HttpResponseBase response, HttpRequestBase request)
        {
            _response = response;
            _request = request;
        }

        public ActionResult Index(string staticResourceVersion, string path)
        {
            _response = base.Response;
            _request = base.Request;

            if (!IsAllowed(path))
                return new HttpStatusCodeResult(404);

            //if (!_request.IsLocal)
            //{
                _response.Cache.SetCacheability(HttpCacheability.Public);
                _response.Cache.SetExpires(DateTime.Now.AddYears(1));
            //}

            return File(Server.MapPath("~/" + path), GetContentType(path));
        }

        private bool IsAllowed(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;
            var lowerPath = path.ToLowerInvariant();
            //if (!lowerPath.StartsWith("img/") && !lowerPath.StartsWith("scripts/") && !lowerPath.StartsWith("css/"))
            //    return false;
            if (!lowerPath.EndsWith(".png") && !lowerPath.EndsWith(".css") && !lowerPath.EndsWith(".js"))
                return false;
            if (lowerPath.Contains(".."))
                return false;
            return true;
        }

        private static string GetContentType(string path)
        {
            var extension = Path.GetExtension(path);
            switch (extension)
            {
                case ".js":
                    return "text/javascript";
                case ".css":
                    return "text/css";
                case ".png":
                    return "image/png";
            }
            return null;
        }

    }

}
