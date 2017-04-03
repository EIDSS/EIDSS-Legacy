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
    public class VetCaseTestValidationBll
    {
        public static eidss.openapi.contract.TestInterpretation Create(long vcid, eidss.openapi.contract.TestInterpretation tin)
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

                var tsv = CaseTestValidation.Accessor.Instance(null).CreateNewT(manager, vc);
                tsv = CaseTestValidationConverter.Instance.ToModel(manager, tsv, tin);
                vc.CaseTestValidations.Add(tsv);

                acc.Post(manager, vc);

                return CaseTestValidationConverter.Instance.ToContract(manager, tsv);
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

                var tsv = vc.CaseTestValidations.SingleOrDefault(c => c.idfTestValidation == id);
                if (tsv == null)
                {
                    throw new ObjectNotFoundException(id);
                }
                tsv.MarkToDelete();

                acc.Post(manager, vc);
            }
        }
    }
}
