using eidss.model.Model.Report;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class LevelVisitor : FlexNodeVisitor
    {
        private int m_MaxLevel = -1;
        private int m_MinLevel = int.MaxValue;

        public int MaxLevel
        {
            get { return m_MaxLevel; }
        }

        public int MinLevel
        {
            get { return m_MinLevel; }
        }

        public override void Visit(FlexNodeReport node)
        {
            if (node.Level > m_MaxLevel)
            {
                m_MaxLevel = node.Level;
            }
            if (node.Level < m_MinLevel)
            {
                m_MinLevel = node.Level;
            }
        }
    }
}