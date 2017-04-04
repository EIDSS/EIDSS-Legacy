using System;
using bv.model.Model.Core;
using bv.tests.Schema;
using bv.winclient.BasePanel;

namespace bv.tests.WinClient
{
    public class FakeListPanel : BaseListPanel<ListPanelItem>
    {
        public override ISearchPanel CreateSearchPanel(bv.winclient.ActionPanel.ActionPanel panel, Func<SearchPanelMetaItem, SearchPanelMetaItem> item, Func<IObject, IObject> adjustObject)
        {
            var ret = new FakeSearchPanel();
            ret.Search += SearchPanel_Search;
            return ret;
        }
    }
}