using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Avr.Tree;

namespace eidss.model.Schema
{
    public partial class AvrQueryLookup
    {
        public static explicit operator AvrTreeElement(AvrQueryLookup query)
        {
            var treeElement = new AvrTreeElement(query.idflQuery,
                null,
                query.idfsGlobalQuery,
                AvrTreeElementType.Query,
                query.idflQuery,
                query.DefQueryName,
                query.QueryName,
                query.strDescription,
                query.blnReadOnly);
            return treeElement;
        }

        public static AvrQueryLookup GetAvrQueryLookupById(long queryId)
        {
            AvrQueryLookup foundQuery;
            LookupManager.AddObject("Query", null, Accessor.Instance(null).GetType(), "SelectLookupList");
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                Accessor accessor = Accessor.Instance(null);
                List<AvrQueryLookup> lookup = accessor.SelectLookupList(manager, queryId);
                foundQuery = lookup.SingleOrDefault();
            }
            return foundQuery;
        }
    }
}