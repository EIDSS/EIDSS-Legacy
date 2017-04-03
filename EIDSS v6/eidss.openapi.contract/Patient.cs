using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Patient
    /// </summary>
    public class Patient 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// A unique number of the root record. Root record contains information about the particular object. When there is a need to link a case to the same root object (e.g. same patient) information is copied from the root object to the new object created for this case.
        /// </summary>
        public long RootRecordID { get; set; }

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
        /// Number of building or house where the patient resides.
        /// </summary>
        public Address PatientCurrentResidence { get; set; }

        /// <summary>
        /// Address of the patient's current employer or school if patient is a student.
        /// </summary>
        public Address PatientEmployer { get; set; }

        /// <summary>
        /// Permanent Residence
        /// </summary>
        public Address PermanentResidence { get; set; }

        /// <summary>
        /// Phone number of the patient’s residence.
        /// </summary>
        public string PatientPhoneNumber { get; set; }

        /// <summary>
        /// Phone number of patient's registered or permanent residence if applicable 
        /// </summary>
        public string PermanentResidencePhoneNumber { get; set; }

        /// <summary>
        /// Male or Female gender of the patient.<br/>
        /// Reference type: Human Gender<br/>
        /// Reference number: 19000043
        /// </summary>
        public Reference Sex { get; set; }

        /// <summary>
        /// Nationality or citizenship of the patient that is notified as a case of disease.<br/>
        /// Reference number: 19000054<br/>
        /// Reference type: Nationality List
        /// </summary>
        public Reference NationalityCitizenship { get; set; }

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
        /// Patient’s current age, calculated automatically upon entry of DOB (calculated from Date of Symptom Onset, if it is blank, than - Notification Date, if it is blank, than – Date Entered). If DOB is unknown, user can enter the age of the patient manually to the field.
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Patient’s age type (days, months, years), populated automatically when DOB is entered.<br/>
        /// Reference type: Human Age Type<br/>
        /// Reference number: 19000042
        /// </summary>
        public Reference AgeType { get; set; }

        /// <summary>
        /// Patient’s date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Date of patient's death.
        /// </summary>
        public DateTime? DateOfDeath { get; set; }

        /// <summary>
        /// Name of the facility for patient’s current employer, children’s facility and school if patient is a student.
        /// </summary>
        public string EmployerName { get; set; }

        /// <summary>
        /// Phone number for patient’s current employer, children’s facility and school.
        /// </summary>
        public string EmployerPhoneNumber { get; set; }
    }
}