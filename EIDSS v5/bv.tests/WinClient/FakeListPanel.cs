using System;
using bv.model.Model.Core;
using bv.tests.Schema;
using bv.winclient.BasePanel;

namespace bv.tests.WinClient
{
    public class FakeListPanel : BaseListPanel<ListPanelItem>
    {
        protected override ISearchPanel CreateSearchPanel()
        {
            return new FakeSearchPanel();
        }
    }
}