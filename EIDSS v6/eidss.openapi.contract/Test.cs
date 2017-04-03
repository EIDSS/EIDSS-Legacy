using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Laboratory test
    /// </summary>
    public class Test 
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
        /// The name of the diagnostic test performed on the sample. Plus function allows to add names of the test to the drop down list.<br/>
        /// Reference number: 19000097<br/>
        /// Reference type: Test Name
        /// </summary>
        public Reference TestName { get; set; }

        /// <summary>
        /// Allows to track the status of laboratory testing results in real-time.  Auto populated when the batch is closed.<br/>
        /// Reference number: 19000001<br/>
        /// Reference type: Test Status
        /// </summary>
        public Reference TestStatus { get; set; }

        /// <summary>
        /// The result of the test performed on the sample.<br/>
        /// Reference number: 19000096<br/>
        /// Reference type: Test Result
        /// </summary>
        public Reference TestResult { get; set; }

        /// <summary>
        /// Category of the test.<br/>
        /// Reference number: 19000095<br/>
        /// Reference type: Test Category
        /// </summary>
        public Reference TestCategory { get; set; }

        /// <summary>
        /// Current diagnosis at the time of sample receipt by the laboratory auto populated from initial diagnosis or changed diagnosis if apply.<br/>
        /// Reference number: 19000019<br/>
        /// Reference type: Diagnosis
        /// </summary>
        public Diagnosis Diagnosis { get; set; }

        /// <summary>
        /// ID number to track "batch workload" in a laboratory. Use to track easily work and pending results. Auto populated when a new batch is created. The same as Batch ID.
        /// </summary>
        public string TestRunID { get; set; }

        /// <summary>
        /// Result Date
        /// </summary>
        public DateTime? ResultDate { get; set; }
    }
}