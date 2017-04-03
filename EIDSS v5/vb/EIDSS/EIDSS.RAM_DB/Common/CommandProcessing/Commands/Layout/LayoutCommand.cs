namespace EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout
{
    public class LayoutCommand : Command
    {
        private readonly LayoutOperation m_Operation;

        public LayoutCommand(object sender, LayoutOperation operation) : base(sender)
        {
            m_Operation = operation;
        }

        public LayoutOperation Operation
        {
            get { return m_Operation; }
        }
    }
}