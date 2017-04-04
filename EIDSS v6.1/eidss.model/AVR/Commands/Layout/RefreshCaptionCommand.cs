namespace eidss.model.Avr.Commands.Layout
{
    public class RefreshCaptionCommand : Command
    {
        private readonly string m_Caption;
        

        public RefreshCaptionCommand(object sender, string caption)
            : base(sender)
        {
            
            m_Caption = caption;
        }


        public string Caption
        {
            get { return m_Caption; }
        }
    }
}