using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eidss.Web
{
    public class FieldNameAttribute : Attribute
    {
        private string _fieldName;

        public FieldNameAttribute(string fieldName)
        {
            _fieldName = fieldName;
        }

        public string FieldName
        {
            get { return _fieldName; }
        }
    }
}