using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Address
    /// </summary>
    public class Address 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// Country<br/>
        /// Reference type: Country<br/>
        /// Reference number: 19000001
        /// </summary>
        public GisReference Country { get; set; }

        /// <summary>
        /// Region<br/>
        /// Reference type: Region<br/>
        /// Reference number: 19000002
        /// </summary>
        public GisReference Region { get; set; }

        /// <summary>
        /// Rayon<br/>
        /// Reference type: Rayon<br/>
        /// Reference number: 19000003
        /// </summary>
        public GisReference Rayon { get; set; }

        /// <summary>
        /// Settlement<br/>
        /// Reference type: Settlement<br/>
        /// Reference number: 19000004
        /// </summary>
        public GisReference Settlement { get; set; }

        /// <summary>
        /// Postal code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Street Name
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Apartment
        /// </summary>
        public string Apartment { get; set; }

        /// <summary>
        /// Building
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// House
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Foreign address
        /// </summary>
        public string ForeignAddress { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double? Longitude { get; set; }
    }
}