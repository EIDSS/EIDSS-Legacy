using System.Windows.Forms;

namespace EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout
{
    public class ReportViewCommand : Command
    {
        private readonly Control m_NewParent;
        private readonly int m_BottonAnchor;

        public ReportViewCommand(object sender) : base(sender)
        {
        }

        public ReportViewCommand(object sender, Control newParent, int bottonAnchor) : base(sender)
        {
            m_NewParent = newParent;
            m_BottonAnchor = bottonAnchor;
        }

        public Control NewParent
        {
            get { return m_NewParent; }
        }

        public int BottonAnchor
        {
            get { return m_BottonAnchor; }
        }
    }
}