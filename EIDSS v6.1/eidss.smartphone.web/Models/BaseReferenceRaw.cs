using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.model.Schema.Smartphone;

namespace eidss.smartphone.web.Models
{
    public class BaseReferenceRaw
    {
        public long id { get; set; }
        public long tp { get; set; }
        public int ha { get; set; }
        public string df { get; set; }
        public int rs { get; set; }
        public int rd { get; set; }
        public long? f1 { get; set; }
        public long? f2 { get; set; }

        public static IEnumerable<BaseReferenceRaw> GetList(long type)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                if (type == (long)BaseReferenceType.rftDiagnosis)
                {
                    return SmphDiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager)
                        .Select(c => new BaseReferenceRaw() { id = c.id, df = c.df, ha = c.ha.HasValue ? c.ha.Value : 0, tp = c.tp, rs = c.rs, rd = c.rd });
                }
                else if (type == (long)BaseReferenceType.rftInstitutionName)
                {
                    return SmphOrganizationLookup.Accessor.Instance(null).SelectLookupList(manager)
                        .Select(c => new BaseReferenceRaw() { id = c.id, df = c.df, ha = c.ha.HasValue ? c.ha.Value : 0, tp = c.tp, rs = c.rs, rd = 0, f1 = c.idfsRegion, f2 = c.idfsRayon });
                }
                else if (type == (long)BaseReferenceType.rftCaseClassification)
                {
                    return SmphCaseClassificationLookup.Accessor.Instance(null).SelectLookupList(manager)
                        .Select(c => new BaseReferenceRaw() { id = c.id, df = c.df, ha = c.ha.HasValue ? c.ha.Value : 0, tp = c.tp, rs = c.rs, rd = c.rd, f1 = c.f1 ? 1 : 0, f2 = c.f2 ? 1 : 0 });
                }
                else if (type == (long)BaseReferenceType.rftAnimalAgeList)
                {
                    return SmphAnimalAgeLookup.Accessor.Instance(null).SelectLookupList(manager)
                        .Select(c => new BaseReferenceRaw() { id = c.id, df = c.df, ha = c.ha.HasValue ? c.ha.Value : 0, tp = c.tp, rs = c.rs, rd = c.rd, f1 = c.f1, f2 = 0 });
                }
                else if (type == (long)BaseReferenceType.rftSampleType + 10000)
                {
                    return SampleTypeForDiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager, null)
                        .Where(c => c.idfsDiagnosis != 0)
                        .Select(c => new BaseReferenceRaw() { id = c.idfsReference, df = c.name, ha = c.intHACode.HasValue ? c.intHACode.Value : 0, tp = (long)BaseReferenceType.rftSampleType, rs = c.intRowStatus, rd = 0, f1 = c.idfsDiagnosis, f2 = 0 });
                }
                else
                {
                    return SmphBaseReferenceLookup.Accessor.Instance(null).SelectLookupList(manager, type)
                        .Where(c => c.id != 10042004L && c.id != 50815490000000L)   // HumanAgeType.Weeks && CaseReportType.Both
                        .Select(c => new BaseReferenceRaw() { id = c.id, df = c.df, ha = c.ha.HasValue ? c.ha.Value : 0, tp = c.tp, rs = c.rs, rd = c.rd });
                }
            }
        }
    }
}