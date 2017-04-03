namespace eidss.model.Avr.Export
{
    public interface IExportStrategy
    {
        bool ExportDialogOk(string defaultExt, string filter, out string fileName);
    }
}