using eidss.model.Avr.Pivot;

namespace eidss.avr.db.Complexity
{
    public class LayoutSilentValidatorWaiter : LayoutBaseValidatorWaiter
    {
        public LayoutSilentValidatorWaiter() : base(new LayoutSilentValidator())
        {
        }

        public override bool NeedWait
        {
            get { return false; }
        }

        public override void Wait()
        {
        }
    }
}