using System;
using bv.common.Core;
using eidss.model.Core;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class BaseIntervalModel : BaseModel
    {
        public BaseIntervalModel()
        {
            StartDate = DateTime.Now.AddMonths(-1);
            EndDate = DateTime.Now;
        }

        public BaseIntervalModel(string lang, DateTime startDate, DateTime endDate, bool useArchive) : base(lang, useArchive)
        {
            Utils.CheckNotNull(startDate, "startDate");
            Utils.CheckNotNull(endDate, "endDate");

            StartDate = startDate;
            EndDate = endDate;
        }

        [LocalizedDisplayName("datStartDate")]
        public DateTime StartDate { get; set; }

        [LocalizedDisplayName("datEndDate")]
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Start={0}, End={1}", StartDate, EndDate);
        }
    }
}