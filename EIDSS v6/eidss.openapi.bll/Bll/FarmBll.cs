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
    public class FarmBll
    {
        public static eidss.openapi.contract.Farm Select(long id)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = eidss.model.Schema.FarmRoot.Accessor.Instance(null);
                var hc = acc.SelectDetailT(manager, id);
                if (hc == null)
                {
                    throw new ObjectNotFoundException(id);
                }

                return FarmRootConverter.Instance.ToContract(manager, hc);
            }
        }

        public static List<eidss.openapi.contract.FarmListItem> Select(eidss.openapi.contract.FarmListFilter filter)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = eidss.model.Schema.FarmListItem.Accessor.Instance(null);
                var fp = FilterAutoBuilder.BuildFilter(filter, FarmListFilterConverter.Instance);
                var hcs = acc.SelectListT(manager, fp);

                return FarmListItemConverter.Instance.ToContract(manager, hcs);
            }
        }

    }
}