using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    public class Login 
    {
        /// <summary>
        /// User organization name
        /// </summary>
        public string organization { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string user { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Language:<br/>
        /// • "en"<br/>
        /// • "ru"<br/>
        /// • "ka"<br/>
        /// • "kk"<br/>
        /// • "uz-C"<br/>
        /// • "uz-L"<br/>
        /// • "az-L"<br/>
        /// • "hy"<br/>
        /// • "uk"<br/>
        /// • "ar"<br/>
        /// • "vi"<br/>
        /// • "lo"<br/>
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// External system name (optional):<br/>
        /// • "HMIS"<br/>
        /// • "e-TB"<br/>
        /// </summary>
        public string externalSystem { get; set; }
    }
}