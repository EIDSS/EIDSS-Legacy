namespace eidss.model.Avr.Pivot
{
    public abstract class LayoutBaseValidatorWaiter
    {
        protected LayoutBaseValidatorWaiter(LayoutBaseValidator validator)
        {
            Validator = validator;
        }

        public LayoutBaseValidator Validator { get; private set; }
      
        public abstract bool NeedWait { get; }
        public abstract void Wait();
    }
}