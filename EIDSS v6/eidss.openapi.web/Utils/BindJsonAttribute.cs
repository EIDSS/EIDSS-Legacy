using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace eidss.openapi.web.Utils
{
    public class BindJsonAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        Type _type;
        string _queryStringKey;
        public BindJsonAttribute(Type type, string queryStringKey)
        {
            _type = type;
            _queryStringKey = queryStringKey;
        }
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var json = actionContext.Request.RequestUri.ParseQueryString()[_queryStringKey];
            actionContext.ActionArguments[_queryStringKey] = JsonConvert.DeserializeObject(json, _type);
        }
    }
}