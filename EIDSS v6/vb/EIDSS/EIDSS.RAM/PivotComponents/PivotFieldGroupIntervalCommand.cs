using DevExpress.XtraPivotGrid;
using eidss.avr.db.Common;
using eidss.model.Avr.Commands;

namespace eidss.avr.PivotComponents
{
    public class PivotFieldGroupIntervalCommand : Command
    {
        private readonly IAvrPivotGridField m_Field;
        private readonly PivotGroupInterval? m_GroupInterval;

        
        public PivotFieldGroupIntervalCommand(object sender, IAvrPivotGridField field, PivotGroupInterval? groupInterval) : base(sender)
        {
            m_Field = field;
            m_GroupInterval = groupInterval;
        }

        public IAvrPivotGridField Field
        {
            get { return m_Field; }
        }

        public PivotGroupInterval? GroupInterval
        {
            get { return m_GroupInterval; }
        }
    }
}