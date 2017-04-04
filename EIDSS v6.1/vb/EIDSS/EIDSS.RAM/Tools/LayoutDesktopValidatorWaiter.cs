using System.Threading;
using System.Windows.Forms;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Pivot;

namespace eidss.avr.Tools
{
    public class LayoutDesktopValidatorWaiter : LayoutBaseValidatorWaiter
    {
        protected const int WaitTimeout = 100;

        public LayoutDesktopValidatorWaiter(IAvrInvokable invokable)
            : base(new LayoutDesktopValidator(invokable))
        {
        }

        public override bool NeedWait
        {
            get { return true; }
        }

        public override void Wait()
        {
            Thread.Sleep(WaitTimeout);
            var desktopValidator = ((LayoutDesktopValidator) Validator);
            if (desktopValidator.GetAndResetInvokeFlag())
            {
                Application.DoEvents();
            }
        }
    }
}