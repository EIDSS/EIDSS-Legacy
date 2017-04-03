using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public class GridModelEditableItem
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public string ClientTemplate { get; set; }
        public int? Width { get; set; }
    }
}
