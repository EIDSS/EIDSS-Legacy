using System;
using System.Collections.Generic;

namespace bv.model.Model.Core
{
    public interface ISearchPanel
    {
        FilterParams Parameters { get;  }
        event EventHandler Search;
    }
}