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
    /// <summary>Human Case Sample REST service for EIDSS Open API</summary>
    [EidssFilterAction]
    public class HumanCaseSampleController : ApiController
    {
        /// <summary>Create new Human Case Sample</summary>
        /// <remarks>HTTP POST verb <br/>
        /// http://hostname/api/HumanCase/{idCase}/Sample [value in the body] <br/>
        /// http://hostname/api/json/HumanCase/{idCase}/Sample [value in the body] <br/>
        /// http://hostname/api/xml/HumanCase/{idCase}/Sample [value in the body] <br/>
        /// </remarks>
        /// <param name="idCase">Human Case identifier</param>
        /// <param name="value">Human Case Sample for create</param>
        /// <returns>Created Human Case Sample</returns>
        /// <example><code>
        /// (POST) http://eidss.hostname.org/api/HumanCase/123457890/Sample [data in the body] 
        /// (POST) http://eidss.hostname.org/api/json/HumanCase/123457890/Sample [data in the body] 
        /// (POST) http://eidss.hostname.org/api/xml/HumanCase/123457890/Sample [data in the body] 
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
        public Sample Post(long idCase, [FromBody]Sample value)
        {
            return HumanCaseSampleBll.Create(idCase, value);
        }

        /// <summary>Delete Human Case Sample by it's identifier</summary>
        /// <remarks>HTTP DELETE verb <br/>
        /// http://hostname/api/HumanCase/{idCase}/Sample/{id} <br/>
        /// http://hostname/api/json/HumanCase/{idCase}/Sample/{id} <br/>
        /// http://hostname/api/xml/HumanCase/{idCase}/Sample/{id} <br/>
        /// </remarks>
        /// <param name="idCase">Identifier of Human Case</param>
        /// <param name="id">Identifier of Human Case Sample</param>
        /// <example><code>
        /// (DELETE) http://eidss.hostname.org/api/HumanCase/123457890/Sample/1122334455 
        /// (DELETE) http://eidss.hostname.org/api/json/HumanCase/123457890/Sample/1122334455
        /// (DELETE) http://eidss.hostname.org/api/xml/HumanCase/123457890/Sample/1122334455
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
        /// <exception cref="OpenApiErrorCode.M0003">Human Case with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Human Case Sample with specified id is not found</exception>
        [EidssBasicAuthorize(UpdatePermission = EIDSSPermissionObject.HumanCase)]
        public void Delete(long idCase, long id)
        {
            HumanCaseSampleBll.Delete(idCase, id);
        }


        [HttpGet]
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.HumanCase)]
        public IEnumerable<Sample> List(long idCase)
        {
            return HumanCaseBll.Select(idCase).Samples;
        }

    }
}
