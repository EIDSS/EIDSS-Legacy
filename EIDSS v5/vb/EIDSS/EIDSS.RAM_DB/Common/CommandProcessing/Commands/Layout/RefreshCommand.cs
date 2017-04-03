namespace EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout
{
    public class RefreshCommand : Command
    {
        private readonly RefreshType m_RefreshType;

        public RefreshCommand(object sender, RefreshType printType)
            : base(sender)
        {
            m_RefreshType = printType;
        }

        public RefreshType RefreshType
        {
            get { return m_RefreshType; }
        }
    }
}