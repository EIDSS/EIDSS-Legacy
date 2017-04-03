using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Laboratory test
    /// </summary>
    public class PensideTest 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// A unique number of the parent record
        /// </summary>
        public long SampleRecordID { get; set; }

        /// <summary>
        /// A locally assigned number used to uniquely identify the animal that sample/s were collected from for pen-side testing.
        /// </summary>
        public long AnimalRecordID { get; set; }

        /// <summary>
        /// The name of the pen-side test used for diagnosis.<br/>
        /// Reference number: 19000104<br/>
        /// Reference type: Penside Test Name
        /// </summary>
        public Reference PensideTestName { get; set; }

        /// <summary>
        /// Results of the pen-side test that was used.<br/>
        /// Reference number: 19000105<br/>
        /// Reference type: Penside Test Result
        /// </summary>
        public Reference PensideTestResult { get; set; }

        /// <summary>
        /// A locally assigned number to identify the sample collected for pen-side testing.
        /// </summary>
        public string FieldSampleID { get; set; }
    }
}