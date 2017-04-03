using System;
using eidss.model.Core;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class BaseYearModel : BaseModel
    {

        public BaseYearModel()
        {
            Year = DateTime.Now.Year;
        }


        public BaseYearModel(string language, int year, bool useArchive) : base(language, useArchive)
        {
            Year = year;
        }

        [LocalizedDisplayName("YearForAggr")]
        public int Year { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Year={0}", Year);
        }
    }
}