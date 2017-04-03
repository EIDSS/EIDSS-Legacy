using System.Windows.Forms;
using bv.common.Core;

namespace EIDSS.RAM_DB.DBService.Models.Export
{
    public class ExportDialogStrategy : IExportStrategy
    {
        public bool ExportDialogOk(string defaultExt, string filter, out string fileName)
        {
            Utils.CheckNotNullOrEmpty(defaultExt, "defaultExt");
            Utils.CheckNotNullOrEmpty(filter, "filter");

            using (var dialog = new SaveFileDialog())
            {
                dialog.DefaultExt = defaultExt;
                dialog.Filter = filter;
                bool isOk = dialog.ShowDialog() == DialogResult.OK;
                fileName = isOk ? dialog.FileName : string.Empty;
                return isOk;
            }
        }
    }
}