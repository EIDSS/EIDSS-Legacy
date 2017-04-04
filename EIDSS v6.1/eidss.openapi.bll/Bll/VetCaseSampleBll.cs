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
    public class VetCaseSampleBll
    {
        public static eidss.openapi.contract.Sample Create(long hcid, eidss.openapi.contract.Sample sin)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);
                var vc = acc.SelectDetailT(manager, hcid);
                if (vc == null)
                {
                    throw new ObjectNotFoundException(hcid);
                }

                vc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                var smp = VetCaseSample.Accessor.Instance(null).Create(manager, vc, null, null, null, null, null, null);
                smp = VetCaseSampleConverter.Instance.ToModel(manager, smp, sin);
                vc.Samples.Add(smp);

                acc.Post(manager, vc);

                return VetCaseSampleConverter.Instance.ToContract(manager, smp);
            }
        }

        public static void Delete(long hcid, long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);
                var vc = acc.SelectDetailT(manager, hcid);
                if (vc == null)
                {
                    throw new ObjectNotFoundException(hcid);
                }

                vc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                var smp = vc.Samples.SingleOrDefault(c => c.idfMaterial == id);
                if (smp == null)
                {
                    throw new ObjectNotFoundException(id);
                }
                smp.MarkToDelete();

                acc.Post(manager, vc);
            }
        }
    }
}
