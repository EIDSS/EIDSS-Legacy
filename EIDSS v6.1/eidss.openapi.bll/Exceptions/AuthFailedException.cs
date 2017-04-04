using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bv.common.Resources;
using eidss.model.Resources;

namespace eidss.openapi.bll.Exceptions
{
    public class AuthFailedException : OpenApiException
    {
        public AuthFailedException()
        {
        }

        public override string ErrorCode
        {
            get { return OpenApiErrorCode.A0008.ToString(); }
        }
        public override string Message
        {
            get { return string.Format(EidssMessages.Get("msgOpenApiLoginGeneral")); }
        }
    }
}
