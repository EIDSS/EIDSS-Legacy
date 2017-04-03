using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Avr.Tree;

namespace eidss.model.Schema
{
    public partial class AvrLayoutLookup
    {
        public static explicit operator AvrTreeElement(AvrLayoutLookup layout)
        {
            var treeElement = new AvrTreeElement(layout.idflLayout,
                layout.idflFolder ?? layout.idflQuery,
                layout.idfsGlobalLayout,
                AvrTreeElementType.Layout,
                layout.idflQuery,
                layout.strDefaultLayoutName,
                layout.strLayoutName,
                layout.strDescription,
                layout.blnReadOnly,
                layout.blnShareLayout,
                layout.strDescriptionEnglish,
                layout.idflDescription
                );
            return treeElement;
        }

        public static AvrLayoutLookup GetAvrLayoutLookupById(long layoutId)
        {
            AvrLayoutLookup foundLayout;
            LookupManager.AddObject("Layout", null, Accessor.Instance(null).GetType(), "SelectLookupList");
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                Accessor accessor = Accessor.Instance(null);
                List<AvrLayoutLookup> lookup = accessor.SelectLookupList(manager, layoutId, null);
                foundLayout = lookup.SingleOrDefault();
            }
            return foundLayout;
        }
    }
}