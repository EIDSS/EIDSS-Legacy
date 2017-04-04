using System;
using DevExpress.XtraReports.UI;
using eidss.model.Model.Report;

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

        public override void Visit(FlexNodeReport node)
        {
            if (!(node.AssignedControl is FlexTable))
                return;

            var table = (FlexTable) node.AssignedControl;
            table.SuspendLayout();
            
            table.WidthF = (float) (table.WidthF / m_Scale);
            table.HeaderCell.WidthF = table.WidthF;

            foreach (XRTableCell cell in table.InnerRow.Cells)
            {
                cell.WidthF = (float)(cell.WidthF / m_Scale);
            }
            table.ResumeLayout();
        }
    }
}