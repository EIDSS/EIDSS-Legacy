using eidss.avr.db.Common;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Layout;

namespace eidss.avr.PivotComponents
{
    public class PivotFieldCommand : Command
    {
        private readonly IAvrPivotGridField m_Field;
        private readonly PivotFieldOperation m_FieldOperation;

        public PivotFieldCommand(object sender, IAvrPivotGridField field, PivotFieldOperation fieldOperation)
            : base(sender)
        {
            m_Field = field;
            m_FieldOperation = fieldOperation;
        }

        public IAvrPivotGridField Field
        {
            get { return m_Field; }
        }

        public PivotFieldOperation FieldOperation
        {
            get { return m_FieldOperation; }
        }
    }
}