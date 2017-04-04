using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.openapi.bll.Converters;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.bll.Bll
{
    public class HumanCaseSampleBll
    {
        public static eidss.openapi.contract.Sample Create(long hcid, eidss.openapi.contract.Sample sin)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, hcid);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(hcid);
                }

                hc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                var smp = HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null);
                smp = HumanCaseSampleConverter.Instance.ToModel(manager, smp, sin);
                hc.Samples.Add(smp);

                acc.Post(manager, hc);

                return HumanCaseSampleConverter.Instance.ToContract(manager, smp);
            }
        }

        public static void Delete(long hcid, long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, hcid);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(hcid);
                }

                hc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                var smp = hc.Samples.SingleOrDefault(c => c.idfMaterial == id);
                if (smp == null)
                {
                    throw new ObjectNotFoundException(id);
                }
                smp.MarkToDelete();

                acc.Post(manager, hc);
            }
        }
    }
}
