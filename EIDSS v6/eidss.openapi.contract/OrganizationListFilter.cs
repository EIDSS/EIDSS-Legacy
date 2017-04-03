using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Organization
    /// </summary>
    public class OrganizationListFilter 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// Identification of the record's accessory to human, veterinary or vector modules
        /// </summary>
        public int? AccessoryCode { get; set; }

        /// <summary>
        /// Abbreviation
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Organization Name
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Unique Organization ID
        /// </summary>
        public string UniqueOrganizationID { get; set; }
    }
}