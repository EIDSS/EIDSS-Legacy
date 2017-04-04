using System.Collections.Generic;

namespace bv.model.Model.Core
{
    public interface IObjectMeta
    {
        int? MaxSize(string name);
        bool RequiredByField(string name, IObject obj);
        bool RequiredByProperty(string name, IObject obj);
        List<SearchPanelMetaItem> SearchPanelMeta { get; }
        List<GridMetaItem> GridMeta { get; }
        List<ActionMetaItem> Actions { get; }
        string DetailPanel { get; }
        string HelpIdWin { get; }
        string HelpIdWeb { get; }
        string HelpIdHh { get; }
    }

}
