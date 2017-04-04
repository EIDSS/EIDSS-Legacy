using System;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class IntermediateInfectiousDiseaseModel : BaseIntervalModel
    {
        

        public IntermediateInfectiousDiseaseModel()
        {
            Address = new AddressModel();
        }

        public IntermediateInfectiousDiseaseModel(string lang, DateTime startDate, DateTime endDate, AddressModel address, bool useArchive)
            : base(lang, startDate, endDate, useArchive)
        {
            Address = address;
        }

        public AddressModel Address { get; set; }

        public static explicit operator IntermediateInfectiousDiseaseSurrogateModel(IntermediateInfectiousDiseaseModel model)
        {
            var result = new IntermediateInfectiousDiseaseSurrogateModel(model.Language, model.StartDate, model.EndDate,
                                                                         model.Address.RegionId, model.Address.RayonId, 
                                                                         model.Address.RegionName, model.Address.RayonName,
                                                                         model.OrganizationId, model.ForbiddenGroups,
                                                                         model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}
