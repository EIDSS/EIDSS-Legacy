using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using eidss.openapi.bll.Exceptions;
using log4net;

namespace eidss.openapi.web.Utils
{
    public class EidssFilterActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Logger.Instance.LogStart(actionContext.Request.RequestUri.OriginalString, actionContext.Request.Method.Method);
            Logger.Instance.LogInfo(actionContext.Request.RequestUri.OriginalString, actionContext.Request.Method.Method, 
                actionContext.Request.ToString(), actionContext.ActionArguments.Aggregate("", (r, i) => r += "[" + i.Key + ":" + i.Value + "]"));
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                string errCode;
                if (actionExecutedContext.Exception is OpenApiException)
                {
                    errCode = (actionExecutedContext.Exception as OpenApiException).ErrorCode;
                }
                else
                {
                    errCode = OpenApiErrorCode.G0001.ToString();
                }
                var errMes = actionExecutedContext.Exception.Message;
                actionExecutedContext.Response.ReasonPhrase = errCode;
                actionExecutedContext.Response.Headers.Add("ErrorCode", errCode);
                actionExecutedContext.Response.Headers.Add("ErrorMessage", errMes);
                Logger.Instance.LogError(actionExecutedContext.Request.RequestUri.OriginalString, actionExecutedContext.Request.Method.Method, errCode, actionExecutedContext.Exception);
            }
            Logger.Instance.LogInfoReturn(actionExecutedContext.Request.RequestUri.OriginalString, actionExecutedContext.Request.Method.Method,
                actionExecutedContext.Response.ToString(), actionExecutedContext.Response.Content == null ? "" : actionExecutedContext.Response.Content.ReadAsStringAsync().Result);
            Logger.Instance.LogFinish(actionExecutedContext.Request.RequestUri.OriginalString, actionExecutedContext.Request.Method.Method);
        }
    }
}