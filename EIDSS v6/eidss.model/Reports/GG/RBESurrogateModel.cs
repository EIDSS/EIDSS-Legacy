using System;
using bv.common.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class RBESurrogateModel : BaseYearQuarterModel
    {
        public RBESurrogateModel()
        {
        }

        public RBESurrogateModel
            (string language, int year, QuartersModel quarters, string[] regions, string[] rayons, bool addSignature, bool useArchive)
            : base(language, year, quarters, useArchive)
        {
            Regions = regions ?? new string[0];
            Rayons = rayons ?? new string[0];
            AddSignature = addSignature;
        }

        public string[] Regions { get; set; }

        public string[] Rayons { get; set; }

        public bool AddSignature { get; set; }

        public static explicit operator BaseIntervalModel(RBESurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");
            var result = new BaseIntervalModel(model.Language, model.StartDate1, model.EndDate1, model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow,
                OrganizationId = model.OrganizationId,
                ForbiddenGroups = model.ForbiddenGroups,
                UserId = model.UserId,
                IsArchiveMode = model.IsArchiveMode,
            };

            return result;
        }
    }
}