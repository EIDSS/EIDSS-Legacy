using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public class GridMetaItem
    {
        public string Name { get; protected set; }
        public string LabelId { get; protected set; }
        public string Format { get; protected set; }
        public bool Visible { get; protected set; }
        public bool Sortable { get; protected set; }
        public ListSortDirection? DefaultSort { get; protected set; }

        public GridMetaItem(
            string name,
            string labelId,
            string format,
            bool visible,
            bool sortable,
            ListSortDirection? defaultSort
            )
        {
            Name = name;
            LabelId = labelId;
            Visible = visible;
            Format = format;
            Sortable = sortable;
            DefaultSort = defaultSort;
        }
    }
}
