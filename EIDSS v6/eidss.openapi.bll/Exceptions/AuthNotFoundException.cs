using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bv.common.Resources;
using eidss.model.Resources;

namespace eidss.openapi.bll.Exceptions
{
    public class AuthNotFoundException : OpenApiException
    {
        public AuthNotFoundException()
        {
        }

        public override string ErrorCode
        {
            get { return OpenApiErrorCode.A0002.ToString(); }
        }
        public override string Message
        {
            get { return string.Format(BvMessages.Get("ErrUserNotFound")); }
        }
    }
}
