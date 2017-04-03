namespace EIDSS.RAM_DB.DBService.Models.Export
{
    public interface IExportStrategy
    {
        bool ExportDialogOk(string defaultExt, string filter, out string fileName);
    }
}