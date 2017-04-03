using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class DToChangedDModel : BaseDateModel
    {
        public DToChangedDModel()
        {
            Address = new AddressModel();
            InitialDiagnoses = new MultipleDiagnosisModel();
            FinalDiagnoses = new MultipleDiagnosisModel();
        }

        public DToChangedDModel
            (string language, int year, int? month,
                AddressModel address,
                string[] initialDiagnosesId, string[] finalDiagnosesId,
                int concordance,
                bool useArchive)
            : base(language, year, month, useArchive)

        {
            Address = address;

            InitialDiagnoses = new MultipleDiagnosisModel(initialDiagnosesId, (int) HACode.Human);
            FinalDiagnoses = new MultipleDiagnosisModel(finalDiagnosesId, (int) HACode.Human);

            Concordance = concordance;
        }

        public AddressModel Address { get; set; }

        public string InitialDiagnosesList { get; set; }
        public string FinalDiagnosesList { get; set; }

        [LocalizedDisplayName("InitialDiagnosisName")]
        public MultipleDiagnosisModel InitialDiagnoses { get; set; }

        [LocalizedDisplayName("FinalDiagnosisName")]
        public MultipleDiagnosisModel FinalDiagnoses { get; set; }

        public List<SelectListItemSurrogate> DiagnosisList
        {
            get { return FilterHelper.GetHumanDiagnosisList(Localizer.CurrentCultureLanguageID); }
        }

        [LocalizedDisplayName("repConcordance")]
        public int Concordance { get; set; }

        public static explicit operator DToChangedDSurrogateModel(DToChangedDModel model)
        {
            string location = AddressModel.GetLocation(model.Language,
                model.Address.RegionId, model.Address.RegionName,
                model.Address.RayonId, model.Address.RayonName,
                model.Address.SettlementName);

            var result = new DToChangedDSurrogateModel(model.Language, model.Year, model.Month,
                model.Address.RegionId, model.Address.RayonId,
                model.Address.SettlementId,
                location,
                model.InitialDiagnoses.CheckedItems,
                model.FinalDiagnoses.CheckedItems,
                model.Concordance,
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