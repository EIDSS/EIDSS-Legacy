using System;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;

namespace eidss.model.Reports.IQ
{
    [Serializable]
    public class WeeklySituationDiseasesModel : BaseYearModel
    {
        public WeeklySituationDiseasesModel()
        {
            RegionFilter = new RegionModel();
        }

        public WeeklySituationDiseasesModel(string language, int year, DateTime startDate, string weekText, long? regionId, bool useArchive)
            : base(language, year, useArchive)
        {
            WeekText = weekText;
            RegionFilter = new RegionModel(regionId);
            StartDate = startDate;
        }

        [LocalizedDisplayName("__Week")]
        public string WeekText { get; set; }

        public RegionModel RegionFilter { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate
        {
            get { return StartDate.AddDays(7); }
        }

        public static explicit operator BaseIntervalModel(WeeklySituationDiseasesModel model)
        {
            Utils.CheckNotNull(model, "model");

            var result = new BaseIntervalModel(model.Language, model.StartDate, model.EndDate, model.UseArchive)
                {
                    ExportFormat = model.ExportFormat,
                    IsOpenInNewWindow = model.IsOpenInNewWindow
                };

            return result;
        }
    }
}