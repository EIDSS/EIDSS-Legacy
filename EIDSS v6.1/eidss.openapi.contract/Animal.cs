using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Herd
    /// </summary>
    public class Animal 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// A unique number of the parent record
        /// </summary>
        public long SpeciesRecordID { get; set; }

        /// <summary>
        /// Species-defined age groups appear from drop-down menu in the form.  User selects appropriate range to capture animal's age.<br/>
        /// Reference type: Animal Age<br/>
        /// Reference number: 19000005
        /// </summary>
        public Reference Age { get; set; }

        /// <summary>
        /// Gender of the sick animal.  User selects from Female, Male, Neutered/Castrate or Unknown.<br/>
        /// Reference type: Animal Sex<br/>
        /// Reference number: 19000007
        /// </summary>
        public Reference Sex { get; set; }

        /// <summary>
        /// The animal's condition at the time of examination.  The user selects from At Risk, Dead, Destroyed, Examined, Sick, or Slaughtered.<br/>
        /// Reference type: Animal/Bird Status<br/>
        /// Reference number: 19000006
        /// </summary>
        public Reference Status { get; set; }

    }
}