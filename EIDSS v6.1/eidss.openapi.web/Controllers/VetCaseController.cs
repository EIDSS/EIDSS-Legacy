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
    /// <summary>Vet Case REST service for EIDSS Open API</summary>
    [EidssFilterAction]
    public class VetCaseController : ApiController
    {
        /// <summary>Create new Vet Case</summary>
        /// <remarks>HTTP POST verb<br/>
        /// http://hostname/api/VetCase [value in the body] <br/>
        /// http://hostname/api/json/VetCase [value in the body] <br/>
        /// http://hostname/api/xml/VetCase [value in the body] <br/>
        /// </remarks>
        /// <param name="value">Vet Case for create</param>
        /// <returns>Created Vet Case</returns>
        /// <example><code>
        /// (POST) http://eidss.hostname.org/api/VetCase [data in the body] 
        /// (POST) http://eidss.hostname.org/api/json/VetCase [data in the body] 
        /// (POST) http://eidss.hostname.org/api/xml/VetCase [data in the body] 
        /// </code></example>
        /// <example><code>
        /// // C#
        /// // TODO
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
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        [EidssBasicAuthorize(InsertPermission = EIDSSPermissionObject.VetCase)]
        public VetCase Post([FromBody]VetCase value)
        {
            return VetCaseBll.Create(value);
        }

        /// <summary>Update existing Vet Case</summary>
        /// <remarks>HTTP PUT verb<br/>
        /// http://hostname/api/VetCase/{id} [value in the body] <br/>
        /// http://hostname/api/json/VetCase/{id} [value in the body] <br/>
        /// http://hostname/api/xml/VetCase/{id} [value in the body] <br/>
        /// </remarks>
        /// <param name="id">Identifier of Vet Case</param>
        /// <param name="value">Updating Vet Case</param>
        /// <returns>Updated Vet Case</returns>
        /// <example><code>
        /// (PUT) http://eidss.hostname.org/api/VetCase/123457890 [data in the body] 
        /// (PUT) http://eidss.hostname.org/api/json/VetCase/123457890 [data in the body] 
        /// (PUT) http://eidss.hostname.org/api/xml/VetCase/123457890 [data in the body] 
        /// </code></example>
        /// <example><code>
        /// // C#
        /// // TODO
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
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        [EidssBasicAuthorize(UpdatePermission = EIDSSPermissionObject.VetCase)]
        public VetCase Put(long id, [FromBody]VetCase value)
        {
            return VetCaseBll.Update(id, value);
        }

        /// <summary>Delete Vet Case by it's identifier</summary>
        /// <remarks>HTTP DELETE verb<br/>
        /// http://hostname/api/VetCase/{id} <br/>
        /// http://hostname/api/json/VetCase/{id} <br/>
        /// http://hostname/api/xml/VetCase/{id} <br/>
        /// </remarks>
        /// <param name="id">Identifier of Vet Case</param>
        /// <example><code>
        /// (DELETE) http://eidss.hostname.org/api/VetCase/123457890 
        /// (DELETE) http://eidss.hostname.org/api/json/VetCase/123457890 
        /// (DELETE) http://eidss.hostname.org/api/xml/VetCase/123457890 
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
        /// var response = client.DeleteAsync("api/VetCase/12687690000000").Result;
        /// if (response.IsSuccessStatusCode)
        ///     Console.WriteLine("Deleted");
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
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case with specified id is not found</exception>
        [EidssBasicAuthorize(DeletePermission = EIDSSPermissionObject.VetCase)]
        public void Delete(long id)
        {
            VetCaseBll.Delete(id);
        }

        /// <summary>Get Vet Case by it's identifier</summary>
        /// <remarks>HTTP GET verb<br/>
        /// http://hostname/api/VetCase/{id} <br/>
        /// http://hostname/api/json/VetCase/{id} <br/>
        /// http://hostname/api/xml/VetCase/{id} <br/>
        /// </remarks>
        /// <param name="id">Identifier of Vet Case</param>
        /// <returns>Vet Case</returns>
        /// <example><code>
        /// (GET) http://eidss.hostname.org/api/VetCase/123457890 
        /// (GET) http://eidss.hostname.org/api/json/VetCase/123457890 
        /// (GET) http://eidss.hostname.org/api/xml/VetCase/123457890 
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
        /// var response = client.GetAsync("api/VetCase/12687690000000").Result;
        /// if (response.IsSuccessStatusCode) {
        ///     var hc = response.Content.ReadAsAsync&lt;VetCase&gt;().Result;
        ///     Console.WriteLine("{0}", hc.CaseID);
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
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case with specified id is not found</exception>
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.VetCase)]
        public VetCase Get(long id)
        {
            // http://localhost:64763/api/xml/VetCase/51887520000000
            return VetCaseBll.Select(id);
        }


        /// <summary>Get list of brief information of Vet Case</summary>
        /// <remarks>HTTP GET verb <br/>
        /// http://hostname/api/VetCase/list?filter={...} <br/>
        /// http://hostname/api/json/VetCase/list?filter={...} <br/>
        /// http://hostname/api/xml/VetCase/list?filter={...} <br/>
        /// </remarks>
        /// <param name="filter">Filter</param>
        /// <returns>List of brief information of Vet Case</returns>
        /// <example><code>
        /// (GET) http://eidss.hostname.org/api/VetCase/list?filter={...}
        /// (GET) http://eidss.hostname.org/api/json/VetCase/list?filter={...}
        /// (GET) http://eidss.hostname.org/api/xml/VetCase/list?filter={...}
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
        /// var filter = new VetCaseListFilter() { CaseID = "HGETBTB0130005" };
        /// var serializer = new JavaScriptSerializer();
        /// var filterJson = string.Format("?filter={0}", serializer.Serialize(filter));
        /// 
        /// HttpResponseMessage response = client.GetAsync("api/VetCase/list" + filterJson).Result;
        /// if (response.IsSuccessStatusCode) {
        ///     var list = response.Content.ReadAsAsync&lt;IEnumerable&lt;VetCaseListItem&gt;&gt;().Result;
        ///     foreach (var p in list)
        ///         Console.WriteLine("{0}", p.CaseID);
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
        [HttpGet]
        [BindJson(typeof(VetCaseListFilter), "filter")]
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.VetCase)]
        public IEnumerable<VetCaseListItem> List(VetCaseListFilter filter)
        {
            return VetCaseBll.Select(filter);
        }

    }
}
