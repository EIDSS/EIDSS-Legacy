using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eidss.model.Resources;

namespace eidss.openapi.bll.Exceptions
{
    public class ModelValidationException : OpenApiException
    {
        private string ValidationMessage { get; set; }
        public ModelValidationException(string strId, object[] pars)
        {
            ValidationMessage = 
                pars == null 
                ? EidssMessages.Get(strId) 
                : string.Format(EidssMessages.Get(strId), pars);
        }

        public override string ErrorCode
        {
            get { return OpenApiErrorCode.M0001.ToString(); }
        }
        public override string Message
        {
            get { return string.Format(EidssMessages.Get("msgOpenApiModelValidation"), ValidationMessage); }
        }
    }
}
