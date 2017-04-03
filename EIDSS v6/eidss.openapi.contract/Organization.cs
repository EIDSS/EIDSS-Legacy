using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Organization
    /// </summary>
    public class Organization 
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
        /// Abbreviation on Local Language
        /// </summary>
        public string LocalAbbreviation { get; set; }

        /// <summary>
        /// Local Organization Name
        /// </summary>
        public string LocalOrganizationName { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Unique Organization ID
        /// </summary>
        public string UniqueOrganizationID { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// List of Persons
        /// </summary>
        public List<Person> Persons { get; set; }
    }
}