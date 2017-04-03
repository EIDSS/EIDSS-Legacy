namespace EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout
{
    public class QueryCommand : Command
    {
        private readonly QueryOperation m_Operation;

        public QueryCommand(object sender, QueryOperation operation) : base(sender)
        {
            m_Operation = operation;
        }

        public QueryOperation Operation
        {
            get { return m_Operation; }
        }
    }
}