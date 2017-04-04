using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public class TypeMismatchException : BvModelException
    {
        private string m_field;
        private Type m_type;
        public TypeMismatchException(string field, Type type)
            : base()
        {
            m_field = field;
            m_type = type;
        }
    }
}
