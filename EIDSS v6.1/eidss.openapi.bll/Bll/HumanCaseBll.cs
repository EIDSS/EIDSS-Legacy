using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.openapi.contract;
using eidss.openapi.bll.Converters;
using eidss.openapi.bll.Exceptions;
using HumanCase = eidss.model.Schema.HumanCase;
using HumanCaseListItem = eidss.model.Schema.HumanCaseListItem;

namespace eidss.openapi.bll.Bll
{
    public class HumanCaseBll
    {
        public static eidss.openapi.contract.HumanCase Create(eidss.openapi.contract.HumanCase hcin)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                var hc = acc.CreateNewT(manager, null);
                hc.Patient.CurrentResidenceAddress.Region = null;
                hc.Patient.RegistrationAddress.Region = null;
                hc.Patient.EmployerAddress.Region = null;
                //hc.PointGeoLocation.Country = hc.Patient.CurrentResidenceAddress.Country;
                hc = HumanCaseConverter.Instance.ToModel(manager, hc, hcin);

                hc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                acc.Post(manager, hc);

                return HumanCaseConverter.Instance.ToContract(manager, hc);
            }
        }

        public static eidss.openapi.contract.HumanCase Update(long id, eidss.openapi.contract.HumanCase hcin)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, id);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(id);
                }

                hc = HumanCaseConverter.Instance.ToModel(manager, hc, hcin);

                hc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                acc.Post(manager, hc);

                return HumanCaseConverter.Instance.ToContract(manager, hc);
            }
        }

        public static eidss.openapi.contract.HumanCase Select(long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, id);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(id);
                }

                return HumanCaseConverter.Instance.ToContract(manager, hc);
            }
        }

        public static void Delete(long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, id);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(id);
                }

                hc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };
                hc.MarkToDelete();
                acc.Post(manager, hc);
            }
        }

        public static List<eidss.openapi.contract.HumanCaseListItem> Select(eidss.openapi.contract.HumanCaseListFilter filter)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCaseListItem.Accessor.Instance(null);
                var fp = FilterAutoBuilder.BuildFilter(filter, HumanCaseListFilterConverter.Instance);
                var hcs = acc.SelectListT(manager, fp);

                return HumanCaseListItemConverter.Instance.ToContract(manager, hcs);
            }
        }

    }
}