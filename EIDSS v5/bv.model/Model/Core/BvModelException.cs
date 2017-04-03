using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public class BvModelException : ApplicationException
    {
        public BvModelException()
            : base()
        {
        }

        public BvModelException(string message) : base(message)
        {
        }

        public BvModelException(string msg, Exception inner)
            : base(msg, inner)
        {
        }

    }


}
