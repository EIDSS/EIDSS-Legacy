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
    public class PatientBll
    {
        public static eidss.openapi.contract.Patient Select(long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = eidss.model.Schema.Patient.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, id);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(id);
                }

                return PatientConverter.Instance.ToContract(manager, hc);
            }
        }

        public static List<eidss.openapi.contract.PatientListItem> Select(eidss.openapi.contract.PatientListFilter filter)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = eidss.model.Schema.PatientListItem.Accessor.Instance(null);
                var fp = FilterAutoBuilder.BuildFilter(filter, PatientListFilterConverter.Instance);
                var hcs = acc.SelectListT(manager, fp);

                return PatientListItemConverter.Instance.ToContract(manager, hcs);
            }
        }

    }
}