using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class ShouldProcessAsTableVisitor : FlexNodeVisitor
    {
        public override void Visit(FlexNode node)
        {
            if (node.IsRoot)
            {
                return;
            }
            FlexNode parentNode = node.ParentNode;
            if (parentNode.ProcessAsTable)
            {
                node.ProcessAsTable = true;
            }
        }
    }
}