using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eidss.model.Resources;

namespace eidss.openapi.bll.Exceptions
{
    public class ObjectNotFoundException : OpenApiException
    {
        private long IdNotFound { get; set; }
        public ObjectNotFoundException(long id)
        {
            IdNotFound = id;
        }

        public override string ErrorCode
        {
            get { return OpenApiErrorCode.M0003.ToString(); }
        }
        public override string Message
        {
            get { return string.Format(EidssMessages.Get("msgOpenApiObjNotFound"), IdNotFound); }
        }
    }
}
