namespace EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout
{
    

    public class PrintCommand : Command
    {
        private readonly PrintType m_PrintType;

        public PrintCommand(object sender, PrintType printType) : base(sender)
        {
            m_PrintType = printType;
        }

        public PrintType PrintType
        {
            get { return m_PrintType; }
        }
    }
}