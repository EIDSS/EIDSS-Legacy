using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.model.Model.Core;
using DevExpress.XtraEditors;

namespace bv.winclient.SearchPanel
{
    public class LinkedContent
    {
        public List<LinkedItem> m_LinkedItems = new List<LinkedItem>();

        public void Add(SearchPanelMetaItem item, params BaseEdit[] control)
        {
            m_LinkedItems.Add(new LinkedItem() { Controls = control.ToList(), MetaItem = item });
        }
    }

    public class LinkedItem
    {
        public SearchPanelMetaItem MetaItem { get; set; }
        public List<BaseEdit> Controls { get; set; }
    }

}
