using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Laboratory sample
    /// </summary>
    public class Sample 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// A unique number of the parent record
        /// </summary>
        public long? HumanCaseRecordID { get; set; }

        /// <summary>
        /// A unique number of the parent record
        /// </summary>
        public long? SpeciesRecordID { get; set; }

        /// <summary>
        /// A unique number of the parent record
        /// </summary>
        public long? AnimalRecordID { get; set; }

        /// <summary>
        /// The condition of the sample as accepted by the laboratory upon receipt.<br/>
        /// Reference number: 19000110<br/>
        /// Reference type: Accession Condition
        /// </summary>
        public Reference ConditionReceived { get; set; }

        /// <summary>
        /// Type of the sample that was collected from the patients. A drop down list includes a list of sample types to choose. Sample types for multiple samples  for the same patient can be entered .<br/>
        /// Reference number: 19000087<br/>
        /// Reference type: Sample Type
        /// </summary>
        public Reference SampleType { get; set; }

        /// <summary>
        /// Status of the sample.<br/>
        /// Reference number: 19000015<br/>
        /// Reference type: Sample Status
        /// </summary>
        public Reference Status { get; set; }

        /// <summary>
        /// Name of the Institution where the sample was collected.<br/>
        /// Reference type: Organization Reference
        /// </summary>
        public OrganizationReference CollectedByInstitution { get; set; }

        /// <summary>
        /// Organization where the object was sent to.<br/>
        /// Reference type: Organization Reference
        /// </summary>
        public OrganizationReference SentToOrganization { get; set; }

        /// <summary>
        /// Name of the Officer at the Institution that sent the sample to the laboratory.<br/>
        /// Reference type: Person Reference
        /// </summary>
        public PersonReference CollectedByOfficer { get; set; }

        /// <summary>
        /// The date the sample was registered in the Laboratory. Today's Date is auto populated fist time, but gives an opportunity to change manually during first entry. After saving upon initial entry, program does not allow to changed it. 
        /// </summary>
        public DateTime? AccessionDate { get; set; }

        /// <summary>
        /// Dates the each sample was taken from the patient.
        /// </summary>
        public DateTime? CollectionDate { get; set; }

        /// <summary>
        /// Dates when patient's each specimen was sent to the laboratory.
        /// </summary>
        public DateTime? SentDate { get; set; }

        /// <summary>
        /// The unique identification number that was given to the sample at the institution where the sample was collected, e.g. hospital or clinic.
        /// </summary>
        public string LocalSampleID { get; set; }

        /// <summary>
        /// Lab Sample ID
        /// </summary>
        public string LabSampleID { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; set; }
    }
}