using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Core
{
    public class VisibilityFeatures
    {
        public bool IsPersonIDBeforeName { get; set; }
        public bool IsHumanCaseSampleMainTestVisible { get; set; }
        public bool IsHerdEpiControlMeasuresVisible { get; set; }
        public bool IsLastNameBeforeFirstName { get; set; }
        public bool IsOnlyHouseUseInAddress { get; set; }
    }
}
