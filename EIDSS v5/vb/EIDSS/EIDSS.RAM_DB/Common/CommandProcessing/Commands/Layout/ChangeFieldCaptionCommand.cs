namespace EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout
{
    public class ChangeFieldCaptionCommand : Command
    {
        private readonly string m_FieldName;

        public ChangeFieldCaptionCommand(object sender, string fieldName) : base(sender)
        {
            m_FieldName = fieldName;
        }

        public string FieldName
        {
            get { return m_FieldName; }
        }
    }
}