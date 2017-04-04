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
    public class VetCaseTestBll
    {
        public static eidss.openapi.contract.Test Create(long vcid, eidss.openapi.contract.Test tin)
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

                var tst = CaseTest.Accessor.Instance(null).Create(manager, vc, vc.idfCase);
                tst = CaseTestConverter.Instance.ToModel(manager, tst, tin);
                vc.CaseTests.Add(tst);

                acc.Post(manager, vc);

                return CaseTestConverter.Instance.ToContract(manager, tst);
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

                var tst = vc.CaseTests.SingleOrDefault(c => c.idfTesting == id);
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
