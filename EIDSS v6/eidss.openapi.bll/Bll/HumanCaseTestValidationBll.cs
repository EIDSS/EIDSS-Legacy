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
    public class HumanCaseTestValidationBll
    {
        public static eidss.openapi.contract.TestInterpretation Create(long hcid, eidss.openapi.contract.TestInterpretation tin)
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

                var tsv = CaseTestValidation.Accessor.Instance(null).CreateNewT(manager, hc);
                tsv = CaseTestValidationConverter.Instance.ToModel(manager, tsv, tin);
                hc.CaseTestValidations.Add(tsv);

                acc.Post(manager, hc);

                return CaseTestValidationConverter.Instance.ToContract(manager, tsv);
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

                var tsv = hc.CaseTestValidations.SingleOrDefault(c => c.idfTestValidation == id);
                if (tsv == null)
                {
                    throw new ObjectNotFoundException(id);
                }
                tsv.MarkToDelete();

                acc.Post(manager, hc);
            }
        }
    }
}
