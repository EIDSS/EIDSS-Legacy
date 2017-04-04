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
    /// <summary>Organization Person REST service for EIDSS Open API</summary>
    [EidssFilterAction]
    public class OrganizationPersonController : ApiController
    {
        /// <summary>Create new Organization Person</summary>
        /// <remarks>HTTP POST verb <br/>
        /// http://hostname/api/Organization/{idCase}/Person [value in the body] <br/>
        /// http://hostname/api/json/Organization/{idCase}/Person [value in the body] <br/>
        /// http://hostname/api/xml/Organization/{idCase}/Person [value in the body] <br/>
        /// </remarks>
        /// <param name="idOrg">Organization identifier</param>
        /// <param name="value">Organization Person for create</param>
        /// <returns>Created Organization Person</returns>
        /// <example><code>
        /// (POST) http://eidss.hostname.org/api/Organization/123457890/Person [data in the body] 
        /// (POST) http://eidss.hostname.org/api/json/Organization/123457890/Person [data in the body] 
        /// (POST) http://eidss.hostname.org/api/xml/Organization/123457890/Person [data in the body] 
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
        public Person Post(long idOrg, [FromBody]Person value)
        {
            return OrganizationPersonBll.Create(idOrg, value);
        }

        /// <summary>Delete Organization Person by it's identifier</summary>
        /// <remarks>HTTP DELETE verb <br/>
        /// http://hostname/api/Organization/{idCase}/Person/{id} <br/>
        /// http://hostname/api/json/Organization/{idCase}/Person/{id} <br/>
        /// http://hostname/api/xml/Organization/{idCase}/Person/{id} <br/>
        /// </remarks>
        /// <param name="idOrg">Identifier of Organization</param>
        /// <param name="id">Identifier of Organization Person</param>
        /// <example><code>
        /// (DELETE) http://eidss.hostname.org/api/Organization/123457890/Person/1122334455 
        /// (DELETE) http://eidss.hostname.org/api/json/Organization/123457890/Person/1122334455
        /// (DELETE) http://eidss.hostname.org/api/xml/Organization/123457890/Person/1122334455
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
        /// <exception cref="OpenApiErrorCode.M0003">Organization with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Organization Person with specified id is not found</exception>
        [EidssBasicAuthorize(UpdatePermission = EIDSSPermissionObject.Organization)]
        public void Delete(long idOrg, long id)
        {
            OrganizationPersonBll.Delete(idOrg, id);
        }


        [HttpGet]
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.Organization)]
        public IEnumerable<Person> List(long idCase)
        {
            return OrganizationBll.Select(idCase).Persons;
        }

    }
}
