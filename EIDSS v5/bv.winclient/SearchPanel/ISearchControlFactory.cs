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
        LookUpEdit CreateLookUpEdit(List<object> items, object currentValue);
        LookUpEdit CreateLookUpEdit(IObject obj, string lookupName, object currentValue, bool bBinding);
    }
}
