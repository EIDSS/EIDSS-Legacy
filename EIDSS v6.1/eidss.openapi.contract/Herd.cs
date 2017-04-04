using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Herd
    /// </summary>
    public class Herd 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// A unique number of the parent record
        /// </summary>
        public long FarmRecordID { get; set; }

        /// <summary>
        /// Total  number of animals belonging to a single species within a single herd that were dead at the time of the report.
        /// </summary>
        public int? NumberOfDeadAnimals { get; set; }

        /// <summary>
        /// Total number of sick animals at the time of report, regardless of species that are in the herd.
        /// </summary>
        public int? NumberOfSickAnimals { get; set; }

        /// <summary>
        /// Total number of animals, regardless of species, assigned to the herd.  This number includes all animals living and dead so it should not exceed the number sick and dead in the herd.
        /// </summary>
        public int? TotalNumberOfAnimals { get; set; }
    }
}