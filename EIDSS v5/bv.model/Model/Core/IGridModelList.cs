using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public interface IGridModelList
    {
        long ListKey { get; }
        List<string> Keys { get; }
        List<string> Columns { get; }
        List<string> Hiddens { get; }
        Dictionary<string, string> Labels { get; }
        Dictionary<string, ActionMetaItem> Actions { get; }
    }
}
