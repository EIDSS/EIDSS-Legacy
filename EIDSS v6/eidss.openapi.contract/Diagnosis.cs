using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Diagnosis
    /// </summary>
    public class Diagnosis 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// Name of the reference value (in the language, specified in login)
        /// </summary>
        public string DiagnosisName { get; set; }

        /// <summary>
        /// ICD-10 Code
        /// </summary>
        public string IDC10Code { get; set; }

        /// <summary>
        /// Identification of the record's accessory to human, veterinary or vector modules, bit mask of:<br/>
        /// • 2 (Human)<br/>
        /// • 32 (Livestock)<br/>
        /// • 64 (Avian)<br/>
        /// • 128 (Vector)<br/>
        /// </summary>
        public int AccessoryCode { get; set; }

        /// <summary>
        /// Identification of the case-based or aggregate diagnosis
        /// </summary>
        public bool Aggregate { get; set; }

        public override string ToString()
        {
            return DiagnosisName;
        }
    }
}