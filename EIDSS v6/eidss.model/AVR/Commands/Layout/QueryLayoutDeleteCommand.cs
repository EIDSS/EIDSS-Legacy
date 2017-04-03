using eidss.model.Avr.Tree;

namespace eidss.model.Avr.Commands.Layout
{
    public class QueryLayoutDeleteCommand : Command
    {
        private readonly long m_ObjectId;
        private readonly AvrTreeElementType m_ObjectType;

        public QueryLayoutDeleteCommand(object sender, long objectId, AvrTreeElementType objectType) : base(sender)
        {
            m_ObjectId = objectId;
            m_ObjectType = objectType;
        }

        public long ObjectId
        {
            get { return m_ObjectId; }
        }

        public AvrTreeElementType ObjectType
        {
            get { return m_ObjectType; }
        }
    }
}