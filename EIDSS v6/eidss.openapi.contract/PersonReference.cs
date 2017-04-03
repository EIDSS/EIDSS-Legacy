using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>PersonReference class</summary>
    public class PersonReference 
    {
        /// <summary>A unique number of the record</summary>
        public long RecordID { get; set; }

        /// <summary>Name of the reference value (in the language, specified in login)</summary>
        public string Name { get; set; }

        /// <summary>A unique number of the parent record</summary>
        public long OrganizationRecordID { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}