using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Core;
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

        public BarCodeForm(NumberingObject type, IList<long> idList)
        {
            using (CreateDialog())
            {
                InitializeComponent();
                baseBarcodeKeeper1.SetObject(type, idList);
            }
        }

        public BarCodeForm(IList<SampleBarcodeDTO> samples)
        {
            using (CreateDialog())
            {
                InitializeComponent();
                baseBarcodeKeeper1.SetObject(samples);
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