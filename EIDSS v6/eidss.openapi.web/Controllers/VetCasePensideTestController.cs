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
    /// <summary>Vet Case PensideTest REST service for EIDSS Open API</summary>
    [EidssFilterAction]
    public class VetCasePensideTestController : ApiController
    {
        /// <summary>Create new Vet Case PensideTest</summary>
        /// <remarks>HTTP POST verb <br/>
        /// http://hostname/api/VetCase/{idCase}/PensideTest [value in the body] <br/>
        /// http://hostname/api/json/VetCase/{idCase}/PensideTest [value in the body] <br/>
        /// http://hostname/api/xml/VetCase/{idCase}/PensideTest [value in the body] <br/>
        /// </remarks>
        /// <param name="idCase">Vet Case identifier</param>
        /// <param name="value">Vet Case PensideTest for create</param>
        /// <returns>Created Vet Case PensideTest</returns>
        /// <example><code>
        /// (POST) http://eidss.hostname.org/api/VetCase/123457890/PensideTest [data in the body] 
        /// (POST) http://eidss.hostname.org/api/json/VetCase/123457890/PensideTest [data in the body] 
        /// (POST) http://eidss.hostname.org/api/xml/VetCase/123457890/PensideTest [data in the body] 
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
        public PensideTest Post(long idCase, [FromBody]PensideTest value)
        {
            return VetCasePensideTestBll.Create(idCase, value);
        }

        /// <summary>Delete Vet Case PensideTest by it's identifier</summary>
        /// <remarks>HTTP DELETE verb <br/>
        /// http://hostname/api/VetCase/{idCase}/PensideTest/{id} <br/>
        /// http://hostname/api/json/VetCase/{idCase}/PensideTest/{id} <br/>
        /// http://hostname/api/xml/VetCase/{idCase}/PensideTest/{id} <br/>
        /// </remarks>
        /// <param name="idCase">Identifier of Vet Case</param>
        /// <param name="id">Identifier of Vet Case PensideTest</param>
        /// <example><code>
        /// (DELETE) http://eidss.hostname.org/api/VetCase/123457890/PensideTest/1122334455 
        /// (DELETE) http://eidss.hostname.org/api/json/VetCase/123457890/PensideTest/1122334455
        /// (DELETE) http://eidss.hostname.org/api/xml/VetCase/123457890/PensideTest/1122334455
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
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case PensideTest with specified id is not found</exception>
        [EidssBasicAuthorize(UpdatePermission = EIDSSPermissionObject.VetCase)]
        public void Delete(long idCase, long id)
        {
            VetCasePensideTestBll.Delete(idCase, id);
        }


        [HttpGet]
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.VetCase)]
        public IEnumerable<PensideTest> List(long idCase)
        {
            return VetCaseBll.Select(idCase).PensideTests;
        }

    }
}
