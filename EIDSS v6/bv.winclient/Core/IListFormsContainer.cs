using System.Collections.Generic;
using bv.winclient.BasePanel;

namespace bv.winclient.Core
{
    public interface IListFormsContainer
    {
        List<IBaseListPanel> ListPanels { get; }
    }
}