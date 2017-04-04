using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public class PermissionException : BvModelException
    {
        public string ObjectName { get; protected set; }
        public string ActionName { get; protected set; }
        public PermissionException(string obj, string action)
            : base()
        {
            ObjectName = obj;
            ActionName = action;
        }
    }
}
