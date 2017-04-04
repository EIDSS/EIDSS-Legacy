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
    public class HumanCaseTestBll
    {
        public static eidss.openapi.contract.Test Create(long hcid, eidss.openapi.contract.Test tin)
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

                var tst = CaseTest.Accessor.Instance(null).Create(manager, hc, hc.idfCase);
                tst = CaseTestConverter.Instance.ToModel(manager, tst, tin);
                hc.CaseTests.Add(tst);

                acc.Post(manager, hc);

                return CaseTestConverter.Instance.ToContract(manager, tst);
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

                var tst = hc.CaseTests.SingleOrDefault(c => c.idfTesting == id);
                if (tst == null)
                {
                    throw new ObjectNotFoundException(id);
                }
                tst.MarkToDelete();

                acc.Post(manager, hc);
            }
        }
    }
}
