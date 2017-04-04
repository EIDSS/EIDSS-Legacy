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
    public class OrganizationPersonBll
    {
        public static eidss.openapi.contract.Person Create(long hcid, eidss.openapi.contract.Person sin)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = Organization.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, hcid);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(hcid);
                }

                hc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                var smp = OrganizationsPerson.Accessor.Instance(null).CreateNewT(manager, hc);
                smp = OrganizationPersonConverter.Instance.ToModel(manager, smp, sin);
                hc.Persons.Add(smp);

                acc.Post(manager, hc);

                return OrganizationPersonConverter.Instance.ToContract(manager, smp);
            }
        }

        public static void Delete(long hcid, long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = Organization.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, hcid);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(hcid);
                }

                hc.Validation += (sender, args) =>
                {
                    throw new ModelValidationException(args.MessageId, args.Pars);
                };

                var smp = hc.Persons.SingleOrDefault(c => c.idfPerson == id);
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
