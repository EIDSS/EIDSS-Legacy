using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Person
    /// </summary>
    public class Person 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string PersonFirstName { get; set; }

        /// <summary>
        /// Second name
        /// </summary>
        public string PersonMiddleName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string PersonLastName { get; set; }
    }
}