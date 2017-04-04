using System.Data;
using bv.common.Core;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Schema;

namespace eidss.model.Model.Report
{
    public class FlexTableItem : FlexItem
    {
        public DataTable BodyData { get; set; }

        public string Text { get; private set; }
        
        internal FlexTableItem(SectionTemplate row)
            : base(row)
        {
            Height = row.Height;
            Width = row.intWidth ?? 100;
            Top = row.intTop ?? 0;
            Left = row.intLeft ?? 0;
            Order = row.intOrder ?? 0;
            LinkedObject = row;

            Text = Utils.IsEmpty(row.NationalName) ? row.DefaultName : row.NationalName;
        }
    }
}
