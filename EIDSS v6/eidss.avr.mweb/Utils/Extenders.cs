using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}