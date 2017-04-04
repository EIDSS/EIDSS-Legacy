using System.Windows.Forms;
using bv.common.Core;
using bv.winclient.Core;
using eidss.model.Avr.Export;
using eidss.model.Resources;

namespace eidss.avr.BaseComponents
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
                while (dialog.FileName.Contains(";"))
                {
                    ErrorForm.ShowWarning("errInvalidFileName", "Invalid file name");
                    isOk = dialog.ShowDialog() == DialogResult.OK;    
                }
                fileName = isOk ? dialog.FileName : string.Empty;
                return isOk;
            }
        }
    }
}