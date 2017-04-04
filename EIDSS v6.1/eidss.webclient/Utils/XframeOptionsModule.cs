using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.webclient.Utils
{
    public class XframeOptionsModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += this.OnPreSendRequestHeaders;
        }
        private void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Request.Path.StartsWith("/Help/") &&
                    (HttpContext.Current.Request.CurrentExecutionFilePathExtension == ".html" || HttpContext.Current.Request.CurrentExecutionFilePathExtension == ".htm"))
                {
                    return;
                }

                HttpContext.Current.Response.AddHeader("X-Frame-Options", "Deny");
            }
        }

    }
}