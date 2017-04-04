using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eidss.model.Resources;

namespace eidss.openapi.bll.Exceptions
{
    public class WrongFormatException : OpenApiException
    {
        private string FieldName { get; set; }
        public WrongFormatException(string name)
        {
            FieldName = name;
        }

        public override string ErrorCode
        {
            get { return OpenApiErrorCode.D0001.ToString(); }
        }
        public override string Message
        {
            get { return string.Format(EidssMessages.Get("msgOpenApiWrongFormat"), FieldName); }
        }
    }
}
