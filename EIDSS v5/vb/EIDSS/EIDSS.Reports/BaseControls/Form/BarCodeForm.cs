using System.Windows.Forms;
using DevExpress.XtraEditors;
using bv.common.Core;
using bv.common.win;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Form
{
    internal partial class BarCodeForm : BvForm
    {
        public BarCodeForm()
        {
            using (CreateDialog())
            {
                InitializeComponent();
            }
        }

        public BarCodeForm(NumberingObject type, long? objectId)
        {
            using (CreateDialog())
            {
                InitializeComponent();
                baseBarcodeKeeper1.SetObject(type, objectId);
            }
        }

        public static void Register(Control parentControl)
        {
            var ma = new MenuAction(PrintUniversalBarcodes, MenuActionManager.Instance, MenuActionManager.Instance.Reports,
                                    "MenuUniversalBarcodes", 100000, false, (int) MenuIconsSmall.PrintBarcode);
            string permission = PermissionHelper.ExecutePermission(EIDSSPermissionObject.Barcode);
            ma.SelectPermission = permission;
        }

        public static void PrintUniversalBarcodes()
        {
            var form = new BarCodeForm();
            form.ShowDialog();
        }

        public static WaitDialog CreateDialog()
        {
            string title = EidssMessages.Get("msgPleaseWait");
            string caption = EidssMessages.Get("msgBarcodeInitializing");
            return new WaitDialog(caption, title);
        }
    }
}