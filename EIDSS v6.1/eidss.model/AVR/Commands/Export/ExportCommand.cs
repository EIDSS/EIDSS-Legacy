using System.Data;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Export;

namespace eidss.avr.db.Common.CommandProcessing.Commands.Export
{
    public delegate void ExportDelegate(string filename);
    public delegate void ExportDataTableDelegate(string filename, DataTable dataSource);

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