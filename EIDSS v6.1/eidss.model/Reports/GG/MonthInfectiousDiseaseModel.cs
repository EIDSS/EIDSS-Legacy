using System;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class MonthInfectiousDiseaseModel : VersionedDateModel
    {
        public MonthInfectiousDiseaseModel()
        {
            RayonFilter = new RayonModel();
            IsMonthMandatory = true;
            IsCurrentMonthSelected = false;
        }

        public MonthInfectiousDiseaseModel(string language, int year, int? month, bool addSignature, bool useArchive)
            : base(language, year, month, useArchive)
        {
            AddSignature = addSignature;
        }

        [LocalizedDisplayName("AddSignature")]
        public bool AddSignature { get; set; }

        public RayonModel RayonFilter { get; set; }

        public static explicit operator IntermediateInfectiousDiseaseSurrogateModel(MonthInfectiousDiseaseModel model)
        {
            Utils.CheckNotNull(model, "model");

            int intMonth = model.Month.HasValue ? model.Month.Value : 1;
            var startDate = new DateTime(model.Year, intMonth, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            AddressModel address = model.RayonFilter == null
                                       ? new AddressModel()
                                       : new AddressModel(model.RayonFilter.RegionId, model.RayonFilter.RayonId);
            var result = new IntermediateInfectiousDiseaseSurrogateModel(model.Language, startDate, endDate,
                                                                         address.RegionId, address.RayonId, address.RegionName,
                                                                         address.RayonName,
                                                                         model.OrganizationId, model.ForbiddenGroups,
                                                                         model.UseArchive)
                {
                    ExportFormat = model.ExportFormat,
                    IsOpenInNewWindow = model.IsOpenInNewWindow,
                    UserId = model.UserId,
                    IsArchiveMode = model.IsArchiveMode,
                };

            return result;
        }
    }
}