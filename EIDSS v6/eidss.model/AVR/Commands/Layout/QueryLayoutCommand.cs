namespace eidss.model.Avr.Commands.Layout
{
    public class QueryLayoutCommand : Command
    {
        private readonly QueryLayoutOperation m_Operation;

        public QueryLayoutCommand(object sender, QueryLayoutOperation operation) : base(sender)
        {
            m_Operation = operation;
        }

        public QueryLayoutOperation Operation
        {
            get { return m_Operation; }
        }
    }
}