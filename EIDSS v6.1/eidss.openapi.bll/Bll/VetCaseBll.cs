using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.openapi.contract;
using eidss.openapi.bll.Converters;
using eidss.openapi.bll.Exceptions;
using VetCase = eidss.model.Schema.VetCase;
using VetCaseListItem = eidss.model.Schema.VetCaseListItem;

namespace eidss.openapi.bll.Bll
{
    public class VetCaseBll
    {
        public static eidss.openapi.contract.VetCase Create(eidss.openapi.contract.VetCase vcin)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);
                var haCode = (int)HACode.None;
                if (vcin.CaseType != null)
                {
                    if (vcin.CaseType.RecordID == (long)CaseTypeEnum.Livestock)
                        haCode = (int) HACode.Livestock;
                    else if (vcin.CaseType.RecordID == (long)CaseTypeEnum.Avian)
                        haCode = (int)HACode.Avian;
                }
                var vc = acc.CreateNewT(manager, null, haCode);
                vc.Farm.Address.Region = null;
                vc = VetCaseConverter.Instance.ToModel(manager, vc, vcin);

                if (vc.CaseProgressStatus == null)
                {
                    vc.CaseProgressStatus = vc.CaseProgressStatusLookup.SingleOrDefault(c => c.idfsBaseReference == (long)CaseStatusEnum.InProgress);
                }

                vc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                acc.Post(manager, vc);

                return VetCaseConverter.Instance.ToContract(manager, vc);
            }
        }

        public static eidss.openapi.contract.VetCase Update(long id, eidss.openapi.contract.VetCase vcin)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);
                var vc = acc.SelectDetailT(manager, id);
                if (vc == null)
                {
                    throw new ObjectNotFoundException(id);
                }

                vc = VetCaseConverter.Instance.ToModel(manager, vc, vcin);

                vc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                acc.Post(manager, vc);

                return VetCaseConverter.Instance.ToContract(manager, vc);
            }
        }

        public static eidss.openapi.contract.VetCase Select(long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);
                var vc = acc.SelectDetailT(manager, id);
                if (vc == null)
                {
                    throw new ObjectNotFoundException(id);
                }

                return VetCaseConverter.Instance.ToContract(manager, vc);
            }
        }

        public static void Delete(long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);
                var vc = acc.SelectDetailT(manager, id);
                if (vc == null)
                {
                    throw new ObjectNotFoundException(id);
                }

                vc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };
                vc.MarkToDelete();
                acc.Post(manager, vc);
            }
        }

        public static List<eidss.openapi.contract.VetCaseListItem> Select(eidss.openapi.contract.VetCaseListFilter filter)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCaseListItem.Accessor.Instance(null);
                var fp = FilterAutoBuilder.BuildFilter(filter, VetCaseListFilterConverter.Instance);
                var vcs = acc.SelectListT(manager, fp);

                return VetCaseListItemConverter.Instance.ToContract(manager, vcs);
            }
        }

    }
}