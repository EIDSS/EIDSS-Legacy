using System;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class FromYearToYearModel : BaseModel
    {
        public FromYearToYearModel()
        {
            Year1 = DateTime.Now.Year - 1;
            Year2 = DateTime.Now.Year;
        }

        [LocalizedDisplayName("Year1")]
        public int Year1 { get; set; }

        [LocalizedDisplayName("Year2")]
        public int Year2 { get; set; }
        public override string ToString()
        {
            return base.ToString() + string.Format(" Year1={0}, Year2={1}", Year1, Year2);
        }
    }
}