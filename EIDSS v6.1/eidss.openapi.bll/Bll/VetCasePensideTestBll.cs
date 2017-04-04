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
    public class VetCasePensideTestBll
    {
        public static eidss.openapi.contract.PensideTest Create(long vcid, eidss.openapi.contract.PensideTest tin)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);
                var vc = acc.SelectDetailT(manager, vcid);
                if (vc == null)
                {
                    throw new ObjectNotFoundException(vcid);
                }

                vc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                var tst = PensideTest.Accessor.Instance(null).CreateNewT(manager, vc);
                vc.PensideTests.Add(tst);

                acc.Post(manager, vc);

                return PensideTestConverter.Instance.ToContract(manager, tst);
            }
        }

        public static void Delete(long vcid, long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);
                var vc = acc.SelectDetailT(manager, vcid);
                if (vc == null)
                {
                    throw new ObjectNotFoundException(vcid);
                }

                vc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                var tst = vc.PensideTests.SingleOrDefault(c => c.idfPensideTest == id);
                if (tst == null)
                {
                    throw new ObjectNotFoundException(id);
                }
                tst.MarkToDelete();

                acc.Post(manager, vc);
            }
        }
    }
}
