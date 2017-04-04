using EIDSS.RAM_DB.DBService.Models.Export;

namespace EIDSS.Tests.RAM.Helpers.Fake
{
    public class FakeExportDialogStrategy : IExportStrategy
    {
        public bool ExportDialogOk(string defaultExt, string filter, out string fileName)
        {
            fileName = "file." + defaultExt;
            return true;
        }
    }
}