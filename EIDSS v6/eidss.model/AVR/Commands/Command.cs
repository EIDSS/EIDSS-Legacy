namespace eidss.model.Avr.Commands
{
    public class Command
    {
        private CommandState m_State = CommandState.Unprocessed;
        private readonly object m_Sender;

        public Command(object sender)
        {
            m_Sender = sender;
        }

        public CommandState State
        {
            get { return m_State; }
            set { m_State = value; }
        }

        public object Sender
        {
            get { return m_Sender; }
        }
    }
}