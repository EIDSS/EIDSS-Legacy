using System.Collections.Generic;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class CellVisitor : FlexNodeVisitor
    {
        private readonly List<int> m_WidthCollection = new List<int>();

        public List<int> WidthCollection
        {
            get { return m_WidthCollection; }
        }

        public override void Visit(FlexNode node)
        {
            if ((node.Count == 0) && (node.AssignedControl != null))
                m_WidthCollection.Add(node.AssignedControl.Width);
        }
    }
}