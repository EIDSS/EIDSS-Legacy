using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.common.Core
{
    public class MenuActionWeb:MenuActionBase
    {
        public MenuActionWeb(IMenuActionManager manager, IMenuAction parent, string resourceKey, int order, bool showInToolbar = false) : base(manager, parent, resourceKey, order, showInToolbar)
        {

        }

        public override bool IsCategory
        {
            get
            {
                return base.IsCategory || string.IsNullOrEmpty(ActionUrl);
            }
        }
    }
}
