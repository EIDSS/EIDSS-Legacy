using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bv.common.Resources;
using eidss.model.Resources;

namespace eidss.openapi.bll.Exceptions
{
    public class AuthEmptyException : OpenApiException
    {
        public AuthEmptyException()
        {
        }

        public override string ErrorCode
        {
            get { return OpenApiErrorCode.A0001.ToString(); }
        }
        public override string Message
        {
            get { return string.Format(BvMessages.Get("ErrEmptyUserLogin")); }
        }
    }
}
