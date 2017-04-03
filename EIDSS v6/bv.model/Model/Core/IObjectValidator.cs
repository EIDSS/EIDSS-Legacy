using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;

namespace bv.model.Model.Core
{
    public interface IObjectValidator
    {
        bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false);
    }
}
