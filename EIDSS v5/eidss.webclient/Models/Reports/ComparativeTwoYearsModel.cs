using System;
using System.Collections.Generic;
using System.Threading;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class ComparativeTwoYearsModel : BaseModel
    {
        public ComparativeTwoYearsModel()
        {
            Address = new AddressModel();

            YearModel = new FromYearToYearModel();
        }

        [LocalizedDisplayName("Counter")]
        public int Counter { get; set; }

        public FromYearToYearModel YearModel { get; set; }

        public AddressModel Address { get; set; }

        [LocalizedDisplayName("OrganizationLabel")]
        public long? OrganizationCHE { get; set; }

        public string OrganizationCHEName
        {
            get
            {
                return !OrganizationCHE.HasValue
                           ? string.Empty
                           : FilterHelper.GetVetOrganizationName(OrganizationCHE.Value,
                                                                 Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
            }
        }

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
            get { return FilterHelper.GetHumanDiagnosisList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName); }
        }

        public List<SelectListItemSurrogate> CounterList
        {
            get { return FilterHelper.GetCounterList(0); }
        }

        public List<SelectListItemSurrogate> OrganizationList
        {
            get { return FilterHelper.GetHumOrganizationList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName); }
        }

        public static explicit operator ComparativeTwoYearsSurrogateModel(ComparativeTwoYearsModel model)
        {
            AddressModel address = model.Address ?? new AddressModel();
            var result = new ComparativeTwoYearsSurrogateModel(model.Language, 
                                                               model.YearModel.Year1, model.YearModel.Year2,
                                                               model.Counter,
                                                               model.DiagnosisId, model.DiagnosisName,
                                                               address.RegionId, address.RayonId,
                                                               address.RegionName, address.RayonName,
                                                               model.OrganizationCHE, model.OrganizationCHEName,
                                                               model.UseArchive)
                {
                    ExportFormat = model.ExportFormat,
                    IsOpenInNewWindow = model.IsOpenInNewWindow
                };

            return result;
        }
    }
}