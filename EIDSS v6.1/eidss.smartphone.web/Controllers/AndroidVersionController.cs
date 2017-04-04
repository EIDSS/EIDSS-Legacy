using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace eidss.smartphone.web.Controllers
{
    public class AndroidVersionController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            // M mm rrr bbb -> 6.0.72.16 -> 6 00 072 016 -> 600072016
            string versionCode = string.Format("{0}{1:00}{2:000}{3:000}", version.Major, version.Minor, version.Build, version.Revision);
            return new HttpResponseMessage()
            {
                Content = new StringContent(versionCode)
            };
        }

    }
}
