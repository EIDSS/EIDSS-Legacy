using System;

namespace eidss.model.Reports.Common
{
    public class BaseIntervalLocationModel : BaseIntervalModel
    {
        public BaseIntervalLocationModel
            (string language, DateTime startDate, DateTime endDate,
                long? regionId, long? rayonId, long? settlementId, string location, bool useArchive)
            : base(language, startDate, endDate, useArchive)
        {
            RegionId = regionId;
            RayonId = rayonId;
            SettlementId = settlementId;
            Location = location;
        }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public long? SettlementId { get; set; }

        public string Location { get; set; }

        public string GetInterval()
        {
            return base.StartDate.ToShortDateString() + " - " + base.EndDate.ToShortDateString();
        }
    }
}