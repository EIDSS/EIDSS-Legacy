using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eidss.model.Resources;

namespace eidss.openapi.bll.Exceptions
{
    public class ReferenceNotFoundException : OpenApiException
    {
        private long IdNotFound { get; set; }
        private string RefName { get; set; }
        public ReferenceNotFoundException(long id, string name)
        {
            IdNotFound = id;
            RefName = name;
        }

        public override string ErrorCode
        {
            get { return OpenApiErrorCode.M0002.ToString(); }
        }
        public override string Message
        {
            get { return string.Format(EidssMessages.Get("msgOpenApiRefNotFound"), IdNotFound, RefName); }
        }
    }
}
