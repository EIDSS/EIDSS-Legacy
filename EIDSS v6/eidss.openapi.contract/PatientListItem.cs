using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Short description of Patient
    /// </summary>
    public class PatientListItem 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string PatientFirstName { get; set; }

        /// <summary>
        /// Second name
        /// </summary>
        public string PatientMiddleName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string PatientLastName { get; set; }

        /// <summary>
        /// Patient Personal ID Type<br/>
        /// Reference type: Person ID Type<br/>
        /// Reference number: 19000148
        /// </summary>
        public Reference PatientPersonalIDType { get; set; }

        /// <summary>
        /// Personal ID
        /// </summary>
        public string PersonalID { get; set; }

        /// <summary>
        /// Patient’s date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Country<br/>
        /// Reference type: Country<br/>
        /// Reference number: 19000001
        /// </summary>
        public GisReference CurrentResidenceCountry { get; set; }

        /// <summary>
        /// Region<br/>
        /// Reference type: Region<br/>
        /// Reference number: 19000002
        /// </summary>
        public GisReference CurrentResidenceRegion { get; set; }

        /// <summary>
        /// Rayon<br/>
        /// Reference type: Rayon<br/>
        /// Reference number: 19000003
        /// </summary>
        public GisReference CurrentResidenceRayon { get; set; }

    }
}