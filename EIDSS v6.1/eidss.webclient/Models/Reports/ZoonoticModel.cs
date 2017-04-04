using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class ZoonoticModel : BaseYearModel
    {
        public ZoonoticModel()
        {
            Address = new AddressModel();
            DiagnosisModel = new DiagnosisOrGroupModel();
            DiagnosisModel.SetDiagnoses(DiagnosisList);
        }
       
        public AddressModel Address { get; set; }

        [LocalizedDisplayName("DiagnosisName")]
        public long? DiagnosisId { get; set; }

        public string DiagnosisName
        {
            get
            {
                if (DiagnosisId.HasValue)
                {
                    SelectListItemSurrogate found = DiagnosisList.Find(d => d.Value == DiagnosisId.Value.ToString());
                    return found == null
                        ? string.Empty
                        : found.Text;
                }
                return string.Empty;
            }
        }

        public List<SelectListItemSurrogate> DiagnosisList
        {
            get
            {
                return FilterHelper.GetZoonoticDiagnosisOrGroupList(Localizer.CurrentCultureLanguageID, true);
            }
        }

        public static explicit operator ZoonoticSurrogateModel(ZoonoticModel model)
        {
            AddressModel address = model.Address ?? new AddressModel();

            var result = new ZoonoticSurrogateModel(model.Language, model.Year,
                address.RegionId, address.RayonId,
                address.RegionName, address.RayonName,
                model.DiagnosisId, model.DiagnosisName,
                model.OrganizationId, model.ForbiddenGroups, model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }

        public DiagnosisOrGroupModel DiagnosisModel { get; set; }
    }
}