using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eidss.openapi.bll.Exceptions
{
    public abstract class OpenApiException : ApplicationException
    {
        public abstract string ErrorCode { get; }
    }
}
