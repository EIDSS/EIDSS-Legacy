using eidss.model.Model.Report;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class ShouldProcessAsTableVisitor : FlexNodeVisitor
    {
        public override void Visit(FlexNodeReport node)
        {
            if (node.IsRoot)
            {
                return;
            }
            var parentNode = (FlexNodeReport)node.ParentNode;
            if (parentNode.ProcessAsTable)
            {
                node.ProcessAsTable = true;
            }
        }
    }
}