using System;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class TableApplyWidthVisitor : FlexNodeVisitor
    {
        private readonly double m_Scale;

        public TableApplyWidthVisitor(double scale)
        {
            if (scale <= 0)
                throw new ArgumentException(@"Should be a positive number", "scale");
            m_Scale = scale;
        }

        public override void Visit(FlexNode node)
        {
            if (!(node.AssignedControl is FlexTable))
                return;

            var table = (FlexTable) node.AssignedControl;
            table.SuspendLayout();
            table.WidthF = (float) (table.WidthF / m_Scale);
            table.ResumeLayout();
        }
    }
}