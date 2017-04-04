using System.Collections.Generic;
using bv.common.Resources;

namespace bv.common.Core
{
    public interface IMenuActionManager
    {
        List<IMenuAction> MenuItems { get; }
        IMenuAction RegisterAction(IMenuAction a, IMenuAction parent = null);
        void PrepareActions();
        BaseStringsStorage ItemsStorage { get; set; }
    }
}
