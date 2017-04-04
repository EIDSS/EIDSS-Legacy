using System;
using System.Collections.Generic;
using eidss.model.Enums;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class DToChangedDSurrogateModel : BaseDateModel
    {
        public DToChangedDSurrogateModel()
        {
        }

        public DToChangedDSurrogateModel
            (string language,
                int year, int? month,
                long? regionId, long? rayonId, long? settlementId, string location,
                string[] initialDiagnosesId, string[] finalDiagnosesId,
                int concordance,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups,
                bool useArchive)
            : base(language, year, month, useArchive)
        {
            RegionId = regionId;
            RayonId = rayonId;
            SettlementId = settlementId;
            Location = location;

            InitialDiagnoses = new MultipleDiagnosisModel(initialDiagnosesId, (int) HACode.Human);
            FinalDiagnoses = new MultipleDiagnosisModel(finalDiagnosesId, (int) HACode.Human);

            Concordance = concordance;

            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public long? RegionId { get; set; }
        public long? RayonId { get; set; }
        public long? SettlementId { get; set; }
        public string Location { get; set; }

        public MultipleDiagnosisModel InitialDiagnoses { get; set; }
        public MultipleDiagnosisModel FinalDiagnoses { get; set; }

        public int Concordance { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, Location = {1}, Initial Diagnosis={2}Final Diagnosis={3}",
                base.ToString(), Location, InitialDiagnoses, FinalDiagnoses);
        }
    }
}