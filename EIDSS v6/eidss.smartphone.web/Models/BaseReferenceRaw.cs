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

        public static IEnumerable<BaseReferenceRaw> GetList(long type)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                if (type == (long)BaseReferenceType.rftDiagnosis)
                {
                    return SmphDiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager)
                        .Select(c => new BaseReferenceRaw() { id = c.id, df = c.df, ha = c.ha.HasValue ? c.ha.Value : 0, tp = c.tp });
/*                    return
                        manager.SetCommand(@"
select idfsBaseReference as id, idfsReferenceType as tp, intHACode as ha, strDefault as df 
from trtBaseReference 
inner join trtDiagnosis
on trtDiagnosis.idfsDiagnosis = trtBaseReference.idfsBaseReference
where trtBaseReference.intRowStatus = 0 and idfsReferenceType = @idfsReferenceType
and trtDiagnosis.idfsUsingType = " + (long)DiagnosisUsingTypeEnum.StandardCase
                            , manager.Parameter("@idfsReferenceType", type))
                            .ExecuteList<BaseReferenceRaw>();*/
                }
                else
                {
                    return SmphBaseReferenceLookup.Accessor.Instance(null).SelectLookupList(manager, type)
                        .Select(c => new BaseReferenceRaw() { id = c.id, df = c.df, ha = c.ha.HasValue ? c.ha.Value : 0, tp = c.tp });
/*                    return
                        manager.SetCommand(@"
select idfsBaseReference as id, idfsReferenceType as tp, intHACode as ha, strDefault  as df
from trtBaseReference 
where intRowStatus = 0 and idfsReferenceType = @idfsReferenceType"
                            , manager.Parameter("@idfsReferenceType", type))
                            .ExecuteList<BaseReferenceRaw>();*/
                }
            }
        }
    }
}