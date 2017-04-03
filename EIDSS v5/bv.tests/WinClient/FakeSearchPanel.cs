using System;
using bv.model.Model.Core;
using bv.winclient.SearchPanel;

namespace bv.tests.WinClient
{
    public class FakeSearchPanel : BaseSearchPanel
    {
        public void RaiseTestSearch()
        {
            RaiseSearch();
        }

        FilterParams m_Parameters  = new FilterParams();
        public override FilterParams Parameters
        {
            get { return m_Parameters; }
            set { m_Parameters = value; }
        }
    }
}