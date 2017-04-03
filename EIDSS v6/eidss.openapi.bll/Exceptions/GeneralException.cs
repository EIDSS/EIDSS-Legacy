using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eidss.model.Resources;

namespace eidss.openapi.bll.Exceptions
{
    public class GeneralException : OpenApiException
    {
        public GeneralException()
        {
        }

        public override string ErrorCode
        {
            get { return OpenApiErrorCode.G0001.ToString(); }
        }
        public override string Message
        {
            get { return string.Format(EidssMessages.Get("msgOpenApiGeneral")); }
        }
    }
}
