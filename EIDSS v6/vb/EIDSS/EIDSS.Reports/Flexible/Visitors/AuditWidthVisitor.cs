using System;
using System.Text;
using EIDSS.FlexibleForms.Helpers.ReportHelper.DataItems;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class AuditWidthVisitor : FlexNodeVisitor
    {
        private readonly StringBuilder m_ErrorMessageBuilder = new StringBuilder();

        public int LevelToVisit { get; set; }

        public string ErrorMessage
        {
            get { return m_ErrorMessageBuilder.ToString(); }
        }

        public override void Visit(FlexNode node)
        {
            if (node.Level != LevelToVisit)
            {
                return;
            }
            if ((node.ParentNode == null) || (!(node.ParentNode.DataItem is FlexTableItem)))
            {
                return;
            }

            int width = 0;
            foreach (FlexNode child in node.ParentNode.ChildList)
            {
                if (child.DataItem != null)
                {
                    width += child.DataItem.Width;
                }
            }
            if (node.ParentNode.DataItem.Width != width)
            {
                m_ErrorMessageBuilder.AppendFormat(
                    "Incorrect width of Flexible form node {0}. Expected {1} but got {2}{3}",
                    ((FlexTableItem) node.ParentNode.DataItem).Text, width, node.ParentNode.DataItem.Width,
                    Environment.NewLine);
                node.ParentNode.DataItem.Width = width;
            }
        }
    }
}