using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using bv.model.Model.Core;

namespace bv.winclient.SearchPanel
{
    interface ISearchControlFactory
    {
        LookUpEdit CreateLookUpEdit(List<object> items, object currentValue, bool bSorting = true);
        LookUpEdit CreateLookUpEdit(IObject obj, string lookupName, List<Tuple<string, string>> columns, object currentValue, bool bBinding);
    }
}
