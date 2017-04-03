namespace EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout
{
    public delegate void ExportDelegate(string filename);

    public class ExportCommand : Command
    {
        private readonly ExportType m_ExportType;
        private readonly ExportObject m_ExportObject;

        public ExportCommand(object sender, ExportObject exportObject, ExportType exportType) : base(sender)
        {
            m_ExportType = exportType;
            m_ExportObject = exportObject;
        }

        public ExportType ExportType
        {
            get { return m_ExportType; }
        }

        public ExportObject ExportObject
        {
            get { return m_ExportObject; }
        }
    }
}