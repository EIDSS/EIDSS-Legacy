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
    /// <summary>Organization REST service for EIDSS Open API</summary>
    [EidssFilterAction]
    public class OrganizationController : ApiController
    {
        /// <summary>Create new Organization</summary>
        /// <remarks>HTTP POST verb<br/>
        /// http://hostname/api/Organization [value in the body] <br/>
        /// http://hostname/api/json/Organization [value in the body] <br/>
        /// http://hostname/api/xml/Organization [value in the body] <br/>
        /// </remarks>
        /// <param name="value">Organization for create</param>
        /// <returns>Created Organization</returns>
        /// <example><code>
        /// (POST) http://eidss.hostname.org/api/Organization [data in the body] 
        /// (POST) http://eidss.hostname.org/api/json/Organization [data in the body] 
        /// (POST) http://eidss.hostname.org/api/xml/Organization [data in the body] 
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
        [EidssBasicAuthorize(InsertPermission = EIDSSPermissionObject.Organization)]
        public Organization Post([FromBody]Organization value)
        {
            return OrganizationBll.Create(value);
        }

        /// <summary>Update existing Organization</summary>
        /// <remarks>HTTP PUT verb<br/>
        /// http://hostname/api/Organization/{id} [value in the body] <br/>
        /// http://hostname/api/json/Organization/{id} [value in the body] <br/>
        /// http://hostname/api/xml/Organization/{id} [value in the body] <br/>
        /// </remarks>
        /// <param name="id">Identifier of Organization</param>
        /// <param name="value">Updating Organization</param>
        /// <returns>Updated Organization</returns>
        /// <example><code>
        /// (PUT) http://eidss.hostname.org/api/Organization/123457890 [data in the body] 
        /// (PUT) http://eidss.hostname.org/api/json/Organization/123457890 [data in the body] 
        /// (PUT) http://eidss.hostname.org/api/xml/Organization/123457890 [data in the body] 
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
        /// <exception cref="OpenApiErrorCode.M0003">Organization with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        [EidssBasicAuthorize(UpdatePermission = EIDSSPermissionObject.Organization)]
        public Organization Put(long id, [FromBody]Organization value)
        {
            return OrganizationBll.Update(id, value);
        }

        /// <summary>Delete Organization by it's identifier</summary>
        /// <remarks>HTTP DELETE verb<br/>
        /// http://hostname/api/Organization/{id} <br/>
        /// http://hostname/api/json/Organization/{id} <br/>
        /// http://hostname/api/xml/Organization/{id} <br/>
        /// </remarks>
        /// <param name="id">Identifier of Organization</param>
        /// <example><code>
        /// (DELETE) http://eidss.hostname.org/api/Organization/123457890 
        /// (DELETE) http://eidss.hostname.org/api/json/Organization/123457890 
        /// (DELETE) http://eidss.hostname.org/api/xml/Organization/123457890 
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
        /// var response = client.DeleteAsync("api/Organization/12687690000000").Result;
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
        /// <exception cref="OpenApiErrorCode.M0003">Organization with specified id is not found</exception>
        [EidssBasicAuthorize(DeletePermission = EIDSSPermissionObject.Organization)]
        public void Delete(long id)
        {
            OrganizationBll.Delete(id);
        }

        /// <summary>Get Organization by it's identifier</summary>
        /// <remarks>HTTP GET verb<br/>
        /// http://hostname/api/Organization/{id} <br/>
        /// http://hostname/api/json/Organization/{id} <br/>
        /// http://hostname/api/xml/Organization/{id} <br/>
        /// </remarks>
        /// <param name="id">Identifier of Organization</param>
        /// <returns>Organization</returns>
        /// <example><code>
        /// (GET) http://eidss.hostname.org/api/Organization/123457890 
        /// (GET) http://eidss.hostname.org/api/json/Organization/123457890 
        /// (GET) http://eidss.hostname.org/api/xml/Organization/123457890 
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
        /// var response = client.GetAsync("api/Organization/12687690000000").Result;
        /// if (response.IsSuccessStatusCode) {
        ///     var hc = response.Content.ReadAsAsync&lt;Organization&gt;().Result;
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
        /// <exception cref="OpenApiErrorCode.M0003">Organization with specified id is not found</exception>
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.Organization)]
        public Organization Get(long id)
        {
            return OrganizationBll.Select(id);
        }


        /// <summary>Get list of brief information of Organization</summary>
        /// <remarks>HTTP GET verb <br/>
        /// http://hostname/api/Organization/list?filter={...} <br/>
        /// http://hostname/api/json/Organization/list?filter={...} <br/>
        /// http://hostname/api/xml/Organization/list?filter={...} <br/>
        /// </remarks>
        /// <param name="filter">Filter</param>
        /// <returns>List of brief information of Organization</returns>
        /// <example><code>
        /// (GET) http://eidss.hostname.org/api/Organization/list?filter={...}
        /// (GET) http://eidss.hostname.org/api/json/Organization/list?filter={...}
        /// (GET) http://eidss.hostname.org/api/xml/Organization/list?filter={...}
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
        /// var filter = new OrganizationListFilter() { };
        /// var serializer = new JavaScriptSerializer();
        /// var filterJson = string.Format("?filter={0}", serializer.Serialize(filter));
        /// 
        /// HttpResponseMessage response = client.GetAsync("api/Organization/list" + filterJson).Result;
        /// if (response.IsSuccessStatusCode) {
        ///     var list = response.Content.ReadAsAsync&lt;IEnumerable&lt;OrganizationListItem&gt;&gt;().Result;
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
        [BindJson(typeof(OrganizationListFilter), "filter")]
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.Organization)]
        public IEnumerable<OrganizationListItem> List(OrganizationListFilter filter)
        {
            return OrganizationBll.Select(filter);
        }

    }
}
