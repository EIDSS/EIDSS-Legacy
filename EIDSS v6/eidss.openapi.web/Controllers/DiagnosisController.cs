using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eidss.model.Enums;
using eidss.openapi.bll.Bll;
using eidss.openapi.contract;
using eidss.openapi.bll.Exceptions;
using eidss.openapi.web.Utils;

namespace eidss.openapi.web.Controllers
{
    /// <summary>Diagnosis REST service for EIDSS Open API</summary>
    [EidssFilterAction]
    public class DiagnosisController : ApiController
    {
        /// <summary>Get list of diagnosis with specified type</summary>
        /// <returns>List of diagnosis</returns>
        /// <remarks>HTTP GET verb <br/>
        /// http://hostname/api/Diagnosis <br/>
        /// http://hostname/api/json/Diagnosis <br/>
        /// http://hostname/api/xml/Diagnosis <br/>
        /// </remarks>
        /// <example><code>
        /// URL:
        /// (GET) http://eidss.hostname.org/api/Diagnosis
        /// (GET) http://eidss.hostname.org/api/json/Diagnosis
        /// (GET) http://eidss.hostname.org/api/xml/Diagnosis
        /// </code></example>
        /// <example><code>
        /// // C#
        /// var organization = "organization";
        /// var username = "username";
        /// var language = "en";
        /// var externalSystem = ""; // optional
        /// var password = "password";
        /// var authInfo = string.Format("{0}@{1}@{2}@{3}:{4}", organization, username, language, externalSystem, password);
        /// var client = new HttpClient() { BaseAddress = new Uri("http://eidss.hostname.org/") };
        /// var basic = string.Format("Basic {0}", Convert.ToBase64String(Encoding.Default.GetBytes(authInfo)));
        /// client.DefaultRequestHeaders.Add("Authorization", basic);
        /// 
        /// var response = client.GetAsync("api/Diagnosis").Result;
        /// if (response.IsSuccessStatusCode) {
        ///     var list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Diagnosis&gt;&gt;().Result
        ///         .Where(c => !c.isAggregate &amp;&amp; (c.HACode &amp; 2) != 0);
        ///     foreach (var p in list)
        ///         Console.WriteLine("{0}", p.name);
        ///     }
        /// else
        ///     Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        /// </code></example>
        /// <exception cref="OpenApiErrorCode.A0001">User login can't be empty</exception>
        /// <exception cref="OpenApiErrorCode.A0002">User with such login/password is not found</exception>
        /// <exception cref="OpenApiErrorCode.A0003">The database version is absent or in incorrect format</exception>
        /// <exception cref="OpenApiErrorCode.A0004">Login is locked</exception>
        /// <exception cref="OpenApiErrorCode.A0005">Password is expired</exception>
        /// <exception cref="OpenApiErrorCode.A0006">Language is not supported</exception>
        /// <exception cref="OpenApiErrorCode.A0007">External system is not supported</exception>
        /// <exception cref="OpenApiErrorCode.A0008">Login is failed (general login error)</exception>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.Reference)]
        public IEnumerable<Diagnosis> Get()
        {
            return ReferenceBll.GetDignosisList();
        }
    }
}
