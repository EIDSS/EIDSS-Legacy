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

namespace eidss.openapi.bll.Bll
{
    public class OrganizationBll
    {
        public static eidss.openapi.contract.Organization Create(eidss.openapi.contract.Organization hcin)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = eidss.model.Schema.Organization.Accessor.Instance(null);
                var hc = acc.CreateNewT(manager, null);
                hc = OrganizationConverter.Instance.ToModel(manager, hc, hcin);

                hc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                acc.Post(manager, hc);

                return OrganizationConverter.Instance.ToContract(manager, hc);
            }
        }

        public static eidss.openapi.contract.Organization Update(long id, eidss.openapi.contract.Organization hcin)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = eidss.model.Schema.Organization.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, id);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(id);
                }

                hc = OrganizationConverter.Instance.ToModel(manager, hc, hcin);

                hc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                acc.Post(manager, hc);

                return OrganizationConverter.Instance.ToContract(manager, hc);
            }
        }

        public static eidss.openapi.contract.Organization Select(long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = eidss.model.Schema.Organization.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, id);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(id);
                }

                return OrganizationConverter.Instance.ToContract(manager, hc);
            }
        }

        public static void Delete(long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = eidss.model.Schema.Organization.Accessor.Instance(null);
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

        public static List<eidss.openapi.contract.OrganizationListItem> Select(eidss.openapi.contract.OrganizationListFilter filter)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = eidss.model.Schema.OrganizationListItem.Accessor.Instance(null);
                var fp = FilterAutoBuilder.BuildFilter(filter, OrganizationListFilterConverter.Instance);
                var hcs = acc.SelectListT(manager, fp);

                return OrganizationListItemConverter.Instance.ToContract(manager, hcs);
            }
        }

    }
}