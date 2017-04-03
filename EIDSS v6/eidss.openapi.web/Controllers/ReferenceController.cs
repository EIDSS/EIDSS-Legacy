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
    /// <summary>Reference REST service for EIDSS Open API</summary>
    [EidssFilterAction]
    public class ReferenceController : ApiController
    {
        /// <summary>Get list of reference with specified type</summary>
        /// <remarks>HTTP GET verb <br/>
        /// http://hostname/api/Reference/{id} <br/>
        /// http://hostname/json/api/Reference/{id} <br/>
        /// http://hostname/xml/api/Reference/{id} <br/>
        /// </remarks>
        /// <param name="id">Type of reference</param>
        /// <returns>List of reference</returns>
        /// <example><code>
        /// URL:
        /// (GET) http://eidss.hostname.org/api/Reference/123457890 
        /// (GET) http://eidss.hostname.org/json/api/Reference/123457890 
        /// (GET) http://eidss.hostname.org/xml/api/Reference/123457890 
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
        /// <exception cref="OpenApiErrorCode.M0003">Reference with specified id is not found</exception>
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.Reference)]
        public IEnumerable<Reference> Get(long id)
        {
            return ReferenceBll.GetList(id);
        }
    }
}
