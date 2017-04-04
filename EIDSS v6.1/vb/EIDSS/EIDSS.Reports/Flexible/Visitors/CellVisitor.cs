using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using eidss.model.Model.Report;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class CellVisitor : FlexNodeVisitor
    {
        private readonly List<int> m_WidthCollection = new List<int>();

        public List<int> WidthCollection
        {
            get { return m_WidthCollection; }
        }

        public override void Visit(FlexNodeReport node)
        {
            if ((node.Count == 0) && (node.AssignedControl != null))
                m_WidthCollection.Add(((XRControl)node.AssignedControl).Width);
        }
    }
}