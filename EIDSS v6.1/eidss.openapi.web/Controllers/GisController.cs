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
    /// <summary>Geographical REST service for EIDSS Open API</summary>
    [EidssFilterAction]
    public class GisController : ApiController
    {
        /// <summary>Get country list</summary>
        /// <remarks>HTTP GET verb <br/>
        /// http://hostname/api/Gis/ <br/>
        /// http://hostname/api/json/Gis/ <br/>
        /// http://hostname/api/xml/Gis/ <br/>
        /// </remarks>
        /// <returns>Country list</returns>
        /// <example><code>
        /// URL:
        /// (GET) http://eidss.hostname.org/api/Gis/ 
        /// (GET) http://eidss.hostname.org/api/json/Gis/ 
        /// (GET) http://eidss.hostname.org/api/xml/Gis/ 
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
        /// var response = client.GetAsync("api/Gis/").Result;
        /// if (response.IsSuccessStatusCode)
        /// {
        ///     // get country list
        ///     var list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Reference&gt;&gt;().Result;
        ///     foreach (var p in list) {
        ///         Console.WriteLine("{0}", p.name);
        ///     }
        /// }
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
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.GisReference)]
        public IEnumerable<GisReference> Get()
        {
            return ReferenceBll.GetCountryList();
        }

        /// <summary>Get region list for country</summary>
        /// <remarks>HTTP GET verb <br/>
        /// http://hostname/api/Gis/{country} <br/>
        /// http://hostname/api/json/Gis/{country} <br/>
        /// http://hostname/api/xml/Gis/{country} <br/>
        /// </remarks>
        /// <param name="country">Identifier of country</param>
        /// <returns>Region list</returns>
        /// <example><code>
        /// URL:
        /// (GET) http://eidss.hostname.org/api/Gis/780000000 
        /// (GET) http://eidss.hostname.org/api/json/Gis/780000000 
        /// (GET) http://eidss.hostname.org/api/xml/Gis/780000000 
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
        /// var response = client.GetAsync("api/Gis").Result;
        /// if (response.IsSuccessStatusCode)
        /// {
        ///     // get country list
        ///     var list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Reference&gt;&gt;().Result;
        ///     foreach (var p in list) {
        ///         Console.WriteLine("{0}", p.name);
        ///     }
        ///     var countryGeorgia = list.Single(c => c.name == "Georgia").id;
        ///     // get region list for Georgia
        ///     response = client.GetAsync(string.Format("api/Gis/{0}", countryGeorgia)).Result;
        ///     if (response.IsSuccessStatusCode)
        ///     {
        ///         list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Reference&gt;&gt;().Result;
        ///         foreach (var p in list) {
        ///             Console.WriteLine("{0}", p.name);
        ///         }
        ///     }
        ///     else
        ///         Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        /// }
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
        /// <exception cref="OpenApiErrorCode.M0003">Country with specified id is not found</exception>
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.GisReference)]
        public IEnumerable<GisReference> Get(long country)
        {
            if (ReferenceBll.GetCountryList().SingleOrDefault(c => c.RecordID == country) == null)
                throw new ObjectNotFoundException(country);
            return ReferenceBll.GetRegionList(country);
        }

        /// <summary>Get rayon list for country and region</summary>
        /// <remarks>HTTP GET verb <br/>
        /// http://hostname/api/Gis/{country}/{region} <br/>
        /// http://hostname/api/json/Gis/{country}/{region} <br/>
        /// http://hostname/api/xml/Gis/{country}/{region} <br/>
        /// </remarks>
        /// <param name="country">Identifier of country</param>
        /// <param name="region">Identifier of region</param>
        /// <returns>Rayon list</returns>
        /// <example><code>
        /// URL:
        /// (GET) http://eidss.hostname.org/api/Gis/780000000/37030000000 
        /// (GET) http://eidss.hostname.org/api/json/Gis/780000000/37030000000 
        /// (GET) http://eidss.hostname.org/api/xml/Gis/780000000/37030000000 
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
        /// var response = client.GetAsync("api/Gis").Result;
        /// if (response.IsSuccessStatusCode)
        /// {
        ///     // get country list
        ///     var list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Reference&gt;&gt;().Result;
        ///     foreach (var p in list) {
        ///         Console.WriteLine("{0}", p.name);
        ///     }
        ///     var countryGeorgia = list.Single(c => c.name == "Georgia").id;
        ///     // get region list for Georgia
        ///     response = client.GetAsync(string.Format("api/Gis/{0}", countryGeorgia)).Result;
        ///     if (response.IsSuccessStatusCode)
        ///     {
        ///         list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Reference&gt;&gt;().Result;
        ///         foreach (var p in list) {
        ///             Console.WriteLine("{0}", p.name);
        ///         }
        ///         var regionAdjara = list.Single(c => c.name == "Adjara").id;
        ///         // get rayon list for Georgia and Adjara
        ///         response = client.GetAsync(string.Format("api/Gis/{0}/{1}", countryGeorgia, regionAdjara)).Result;
        ///         if (response.IsSuccessStatusCode)
        ///         {
        ///             list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Reference&gt;&gt;().Result;
        ///             foreach (var p in list) {
        ///                 Console.WriteLine("{0}", p.name);
        ///             }
        ///         }
        ///         else
        ///             Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        ///     }
        ///     else
        ///         Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        /// }
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
        /// <exception cref="OpenApiErrorCode.M0003">Country with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Region with specified id is not found</exception>
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.GisReference)]
        public IEnumerable<GisReference> Get(long country, long region)
        {
            if (ReferenceBll.GetCountryList().SingleOrDefault(c => c.RecordID == country) == null)
                throw new ObjectNotFoundException(country);
            if (ReferenceBll.GetRegionList(country).SingleOrDefault(c => c.RecordID == region) == null)
                throw new ObjectNotFoundException(region);
            return ReferenceBll.GetRayonList(region);
        }

        /// <summary>Get settlement list for country, region and rayon</summary>
        /// <remarks>HTTP GET verb <br/>
        /// http://hostname/api/Gis/{country}/{region}/{rayon} <br/>
        /// http://hostname/api/json/Gis/{country}/{region}/{rayon} <br/>
        /// http://hostname/api/xml/Gis/{country}/{region}/{rayon} <br/>
        /// </remarks>
        /// <param name="country">Identifier of country</param>
        /// <param name="region">Identifier of region</param>
        /// <param name="rayon">Identifier of rayon</param>
        /// <returns>Settlement list</returns>
        /// <example><code>
        /// URL:
        /// (GET) http://eidss.hostname.org/api/Gis/780000000/37030000000/1343010000000 
        /// (GET) http://eidss.hostname.org/api/json/Gis/780000000/37030000000/1343010000000 
        /// (GET) http://eidss.hostname.org/api/xml/Gis/780000000/37030000000/1343010000000 
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
        /// var response = client.GetAsync("api/Gis").Result;
        /// if (response.IsSuccessStatusCode)
        /// {
        ///     // get country list
        ///     var list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Reference&gt;&gt;().Result;
        ///     foreach (var p in list) {
        ///         Console.WriteLine("{0}", p.name);
        ///     }
        ///     var countryGeorgia = list.Single(c => c.name == "Georgia").id;
        ///     // get region list for Georgia
        ///     response = client.GetAsync(string.Format("api/Gis/{0}", countryGeorgia)).Result;
        ///     if (response.IsSuccessStatusCode)
        ///     {
        ///         list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Reference&gt;&gt;().Result;
        ///         foreach (var p in list) {
        ///             Console.WriteLine("{0}", p.name);
        ///         }
        ///         var regionAdjara = list.Single(c => c.name == "Adjara").id;
        ///         // get rayon list for Georgia and Adjara
        ///         response = client.GetAsync(string.Format("api/Gis/{0}/{1}", countryGeorgia, regionAdjara)).Result;
        ///         if (response.IsSuccessStatusCode)
        ///         {
        ///             list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Reference&gt;&gt;().Result;
        ///             foreach (var p in list) {
        ///                 Console.WriteLine("{0}", p.name);
        ///             }
        ///             var rayonBatumi = list.Single(c => c.name == "Batumi").id;
        ///             // get settlement list for Georgia, Adjara and Batumi
        ///             response = client.GetAsync(string.Format("api/Gis/{0}/{1}/{2}", countryGeorgia, regionAdjara, rayonBatumi)).Result;
        ///             if (response.IsSuccessStatusCode)
        ///             {
        ///                 list = response.Content.ReadAsAsync&lt;IEnumerable&lt;Reference&gt;&gt;().Result;
        ///                 foreach (var p in list) {
        ///                     Console.WriteLine("{0}", p.name);
        ///                 }
        ///             }
        ///             else
        ///                 Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        ///         }
        ///         else
        ///             Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        ///     }
        ///     else
        ///         Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        /// }
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
        /// <exception cref="OpenApiErrorCode.M0003">Country with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Region with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Rayon with specified id is not found</exception>
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.GisReference)]
        public IEnumerable<GisReference> Get(long country, long region, long rayon)
        {
            if (ReferenceBll.GetCountryList().SingleOrDefault(c => c.RecordID == country) == null)
                throw new ObjectNotFoundException(country);
            if (ReferenceBll.GetRegionList(country).SingleOrDefault(c => c.RecordID == region) == null)
                throw new ObjectNotFoundException(region);
            if (ReferenceBll.GetRayonList(region).SingleOrDefault(c => c.RecordID == rayon) == null)
                throw new ObjectNotFoundException(rayon);
            return ReferenceBll.GetSettlementList(rayon);
        }
    }
}
