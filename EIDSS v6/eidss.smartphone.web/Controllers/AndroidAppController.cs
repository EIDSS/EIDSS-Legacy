using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace eidss.smartphone.web.Controllers
{
    public class AndroidAppController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string localFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Android/EIDSS.apk");
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "EIDSS.apk";
            return response;
        }
    }
}
