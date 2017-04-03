using System;
using bv.model.Model.Core;

namespace bv.winclient.SearchPanel
{
    public class SearchPanelEventArgs : EventArgs
    {
        public SearchPanelEventArgs()
        {
        }

        public SearchPanelEventArgs(FilterParams parametres)
        {
            Parametres = parametres;
        }

        public FilterParams Parametres { get; set; }
    }
}