using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using bv.common.Configuration;

namespace eidss.avr.mweb.Utils
{
    public static partial class Extenders
    {
        private static readonly int m_HeartbeatSeconds = Config.GetIntSetting("HeartbeatSeconds", 10);

        public static MvcHtmlString Heartbeat(this HtmlHelper htmlHelper)
        {
            return new MvcHtmlString(
                @"
                    <script type='text/javascript'>
                        setHeartbeat('" + m_HeartbeatSeconds * 1000 + @"');
                    </script>
                ");
        }

        public static MvcHtmlString IncludeVersionedJs(this HtmlHelper helper, string filename)
        {
            string versionCode = VersionCode();
            var path = "/s/" + versionCode + UrlHelper.GenerateContentUrl(filename, helper.ViewContext.HttpContext);
            return MvcHtmlString.Create("<script type='text/javascript' src='" + path + "'></script>");
        }
        public static MvcHtmlString IncludeVersionedCss(this HtmlHelper helper, string filename)
        {
            string versionCode = VersionCode();
            var path = "/s/" + versionCode + UrlHelper.GenerateContentUrl(filename, helper.ViewContext.HttpContext);
            return MvcHtmlString.Create("<link href='" + path + "' rel='stylesheet' type='text/css' />");
        }

        public static string VersionCode()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionCode = string.Format("{0}-{1}-{2}-{3}", version.Major, version.Minor, version.Build, version.Revision);
            return versionCode;
        }

    }
}