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
    /// <summary>Human Case REST service for EIDSS Open API</summary>
    [EidssFilterAction]
    public class HumanCaseController : ApiController
    {
        /// <summary>Create new Human Case</summary>
        /// <remarks>HTTP POST verb<br/>
        /// http://hostname/api/HumanCase [value in the body] <br/>
        /// http://hostname/api/json/HumanCase [value in the body] <br/>
        /// http://hostname/api/xml/HumanCase [value in the body] <br/>
        /// </remarks>
        /// <param name="value">Human Case for create</param>
        /// <returns>Created Human Case</returns>
        /// <example><code>
        /// (POST) http://eidss.hostname.org/api/HumanCase [data in the body] 
        /// (POST) http://eidss.hostname.org/api/json/HumanCase [data in the body] 
        /// (POST) http://eidss.hostname.org/api/xml/HumanCase [data in the body] 
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
        [EidssBasicAuthorize(InsertPermission = EIDSSPermissionObject.HumanCase)]
        public HumanCase Post([FromBody]HumanCase value)
        {
            return HumanCaseBll.Create(value);
        }

        /// <summary>Update existing Human Case</summary>
        /// <remarks>HTTP PUT verb<br/>
        /// http://hostname/api/HumanCase/{id} [value in the body] <br/>
        /// http://hostname/api/json/HumanCase/{id} [value in the body] <br/>
        /// http://hostname/api/xml/HumanCase/{id} [value in the body] <br/>
        /// </remarks>
        /// <param name="id">Identifier of Human Case</param>
        /// <param name="value">Updating Human Case</param>
        /// <returns>Updated Human Case</returns>
        /// <example><code>
        /// (PUT) http://eidss.hostname.org/api/HumanCase/123457890 [data in the body] 
        /// (PUT) http://eidss.hostname.org/api/json/HumanCase/123457890 [data in the body] 
        /// (PUT) http://eidss.hostname.org/api/xml/HumanCase/123457890 [data in the body] 
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
        /// <exception cref="OpenApiErrorCode.M0003">Human Case with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        [EidssBasicAuthorize(UpdatePermission = EIDSSPermissionObject.HumanCase)]
        public HumanCase Put(long id, [FromBody]HumanCase value)
        {
            return HumanCaseBll.Update(id, value);
        }

        /// <summary>Delete Human Case by it's identifier</summary>
        /// <remarks>HTTP DELETE verb<br/>
        /// http://hostname/api/HumanCase/{id} <br/>
        /// http://hostname/api/json/HumanCase/{id} <br/>
        /// http://hostname/api/xml/HumanCase/{id} <br/>
        /// </remarks>
        /// <param name="id">Identifier of Human Case</param>
        /// <example><code>
        /// (DELETE) http://eidss.hostname.org/api/HumanCase/123457890 
        /// (DELETE) http://eidss.hostname.org/api/json/HumanCase/123457890 
        /// (DELETE) http://eidss.hostname.org/api/xml/HumanCase/123457890 
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
        /// var response = client.DeleteAsync("api/HumanCase/12687690000000").Result;
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
        /// <exception cref="OpenApiErrorCode.M0003">Human Case with specified id is not found</exception>
        [EidssBasicAuthorize(DeletePermission = EIDSSPermissionObject.HumanCase)]
        public void Delete(long id)
        {
            HumanCaseBll.Delete(id);
        }

        /// <summary>Get Human Case by it's identifier</summary>
        /// <remarks>HTTP GET verb<br/>
        /// http://hostname/api/HumanCase/{id} <br/>
        /// http://hostname/api/json/HumanCase/{id} <br/>
        /// http://hostname/api/xml/HumanCase/{id} <br/>
        /// </remarks>
        /// <param name="id">Identifier of Human Case</param>
        /// <returns>Human Case</returns>
        /// <example><code>
        /// (GET) http://eidss.hostname.org/api/HumanCase/123457890 
        /// (GET) http://eidss.hostname.org/api/json/HumanCase/123457890 
        /// (GET) http://eidss.hostname.org/api/xml/HumanCase/123457890 
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
        /// var response = client.GetAsync("api/HumanCase/12687690000000").Result;
        /// if (response.IsSuccessStatusCode) {
        ///     var hc = response.Content.ReadAsAsync&lt;HumanCase&gt;().Result;
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
        /// <exception cref="OpenApiErrorCode.M0003">Human Case with specified id is not found</exception>
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.HumanCase)]
        public HumanCase Get(long id)
        {
            return HumanCaseBll.Select(id);
        }


        /// <summary>Get list of brief information of Human Case</summary>
        /// <remarks>HTTP GET verb <br/>
        /// http://hostname/api/HumanCase/list?filter={...} <br/>
        /// http://hostname/api/json/HumanCase/list?filter={...} <br/>
        /// http://hostname/api/xml/HumanCase/list?filter={...} <br/>
        /// </remarks>
        /// <param name="filter">Filter</param>
        /// <returns>List of brief information of Human Case</returns>
        /// <example><code>
        /// (GET) http://eidss.hostname.org/api/HumanCase/list?filter={...}
        /// (GET) http://eidss.hostname.org/api/json/HumanCase/list?filter={...}
        /// (GET) http://eidss.hostname.org/api/xml/HumanCase/list?filter={...}
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
        /// var filter = new HumanCaseListFilter() { CaseID = "HGETBTB0130005" };
        /// var serializer = new JavaScriptSerializer();
        /// var filterJson = string.Format("?filter={0}", serializer.Serialize(filter));
        /// 
        /// HttpResponseMessage response = client.GetAsync("api/HumanCase/list" + filterJson).Result;
        /// if (response.IsSuccessStatusCode) {
        ///     var list = response.Content.ReadAsAsync&lt;IEnumerable&lt;HumanCaseListItem&gt;&gt;().Result;
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
        [BindJson(typeof(HumanCaseListFilter), "filter")]
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.HumanCase)]
        public IEnumerable<HumanCaseListItem> List(HumanCaseListFilter filter)
        {
            return HumanCaseBll.Select(filter);
        }

    }
}

/*
{
 ""Diagnosis"":{""RecordID"":" + ActiveSheet.Range("b4").Text + "},
 ""InitialCaseClassification"":{""RecordID"":" + ActiveSheet.Range("b9").Text + "},
 ""Patient"":
    {
        ""PatientLastName"":""" + ActiveSheet.Range("b5").Text + """,
        ""PatientPersonalIDType"":{""RecordID"":" + ActiveSheet.Range("b10").Text + "},
        ""PatientCurrentResidence"":
            {
                ""Country"":{""RecordID"":" + ActiveSheet.Range("b6").Text + "},
                ""Region"":{""RecordID"":" + ActiveSheet.Range("b7").Text + "},
                ""Rayon"":{""RecordID"":" + ActiveSheet.Range("b8").Text + "}
            }
    }
}
*/

//{""Diagnosis"":{""RecordID"":" + ActiveSheet.Range("b4").Text + "},""InitialCaseClassification"":{""RecordID"":" + ActiveSheet.Range("b9").Text + "},""Patient"":{""PatientLastName"":""" + ActiveSheet.Range("b5").Text + """,""PatientPersonalIDType"":{""RecordID"":" + ActiveSheet.Range("b10").Text + "},""PatientCurrentResidence"":{""Country"":{""RecordID"":" + ActiveSheet.Range("b6").Text + "},""Region"":{""RecordID"":" + ActiveSheet.Range("b7").Text + "},""Rayon"":{""RecordID"":" + ActiveSheet.Range("b8").Text + "}}}}