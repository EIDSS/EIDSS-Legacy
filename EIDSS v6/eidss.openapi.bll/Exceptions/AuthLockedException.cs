using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bv.common.Resources;
using eidss.model.Resources;

namespace eidss.openapi.bll.Exceptions
{
    public class AuthLockedException : OpenApiException
    {
        public int LockInMinutes { get; protected set; }
        public AuthLockedException(int lockInMinutes)
        {
            LockInMinutes = lockInMinutes;
        }

        public override string ErrorCode
        {
            get { return OpenApiErrorCode.A0004.ToString(); }
        }
        public override string Message
        {
            get { return string.Format(BvMessages.Get("ErrLoginIsLocked"), LockInMinutes); }
        }
    }
}
