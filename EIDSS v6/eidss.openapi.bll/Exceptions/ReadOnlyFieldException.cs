using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eidss.model.Resources;

namespace eidss.openapi.bll.Exceptions
{
    public class ReadOnlyFieldException : OpenApiException
    {
        private string FieldName { get; set; }
        public ReadOnlyFieldException(string name)
        {
            FieldName = name;
        }

        public override string ErrorCode
        {
            get { return OpenApiErrorCode.M0004.ToString(); }
        }
        public override string Message
        {
            get { return string.Format(EidssMessages.Get("msgOpenApiReadOnlyField"), FieldName); }
        }
    }
}
