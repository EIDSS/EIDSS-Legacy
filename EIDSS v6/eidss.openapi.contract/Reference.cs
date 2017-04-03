using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>Reference class</summary>
    public class Reference 
    {
        /// <summary>A unique number of the record</summary>
        public long RecordID { get; set; }

        /// <summary>Name of the reference value (in the language, specified in login)</summary>
        public string Name { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}