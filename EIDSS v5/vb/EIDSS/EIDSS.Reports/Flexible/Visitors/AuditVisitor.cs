using System;
using EIDSS.FlexibleForms.Helpers.ReportHelper.DataItems;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class AuditVisitor : FlexNodeVisitor
    {
        public override void Visit(FlexNode node)
        {
            if (node.IsRoot)
                return;
            FlexNode parentNode = node.ParentNode;
            while (parentNode != null)
            {
                if (node == parentNode)
                    throw new ApplicationException("Circular reference detected in the tree.");
                parentNode = parentNode.ParentNode;
            }

            if (node.DataItem == null)
                throw new ApplicationException("Non-root node should have DataItem.");

            if (node.Count != 0 && !((node.DataItem is FlexLabelItem) || (node.DataItem is FlexTableItem)))
            {
                string message = string.Format("node {0} of type {1} should not have children.",
                                               node, node.DataItem.GetType());
                throw new ApplicationException(message);
            }
        }
    }
}