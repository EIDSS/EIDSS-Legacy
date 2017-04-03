using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Laboratory test interpretation
    /// </summary>
    public class TestInterpretation 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// A unique number of the parent record
        /// </summary>
        public long TestRecordID { get; set; }

        /// <summary>
        /// This fields indicates if the selected test rule in or rule out a diagnosis.<br/>
        /// Reference number: 19000106<br/>
        /// Reference type: Rule In Value for Test Validation
        /// </summary>
        public Reference RuleInRuleOut { get; set; }

        /// <summary>
        /// Interpreted By<br/>
        /// Reference type: Person Reference
        /// </summary>
        public PersonReference InterpretedBy { get; set; }

        /// <summary>
        /// This field indicates who validates a test.<br/>
        /// Reference type: Person Reference
        /// </summary>
        public PersonReference ValidateBy { get; set; }

        /// <summary>
        /// Comments related to rule in or rule out attribute
        /// </summary>
        public string RuleInRuleOutComments { get; set; }

        /// <summary>
        /// Comments related to validation indicator
        /// </summary>
        public string ValidationComments { get; set; }

        /// <summary>
        /// Interpretation Date
        /// </summary>
        public DateTime? InterpretationDate { get; set; }

        /// <summary>
        /// Date when test result has been validated
        /// </summary>
        public DateTime? ValidationDate { get; set; }

        /// <summary>
        /// This field indicates whether a test has been validated
        /// </summary>
        public bool? Validated { get; set; }
    }
}