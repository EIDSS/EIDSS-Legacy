using bv.common.Core;
using eidss.model.Avr.View;

namespace eidss.model.Avr.Commands.Layout
{
    public class PivotGridDataLoadedCommand : Command
    {
        private readonly AvrPivotViewModel m_Model;

        public PivotGridDataLoadedCommand(object sender, AvrPivotViewModel model)
            : base(sender)
        {
            Utils.CheckNotNull(model, "model");

            m_Model = model;
        }

        public AvrPivotViewModel Model
        {
            get { return m_Model; }
        }
    }
}