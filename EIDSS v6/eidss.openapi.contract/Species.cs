using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Herd
    /// </summary>
    public class Species 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// A unique number of the parent record
        /// </summary>
        public long HerdRecordID { get; set; }

        /// <summary>
        /// Total  number of animals belonging to a single species within a single herd that were dead at the time of the report.
        /// </summary>
        public int? NumberOfDeadAnimals { get; set; }

        /// <summary>
        /// Number of animals of the same species in the herd that are ill at the time of the report.
        /// </summary>
        public int? NumberOfSickAnimals { get; set; }

        /// <summary>
        /// Total number of animals that are in the herd of the same species either living or dead at the time of the report.
        /// </summary>
        public int? TotalNumberOfAnimals { get; set; }

        /// <summary>
        /// The name of the group with which the animal is associated (e.g. cattle, pig, goat).<br/>
        /// Reference type: Species List<br/>
        /// Reference number: 19000086
        /// </summary>
        public Reference AnimalSpecies { get; set; }

        /// <summary>
        /// The actual or best estimated calendar date when disease was evident in the group of animals.
        /// </summary>
        public DateTime? StartOfSigns { get; set; }

        /// <summary>
        /// Text value entered by user to capture additional information about a group of animals of the same species (e.g. breed).
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Age of the specified specie in weeks
        /// </summary>
        public string AvgAge { get; set; }
    }
}