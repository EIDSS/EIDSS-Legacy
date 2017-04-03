using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using EIDSS.Reports.Barcode.Designer;
using EIDSS.Reports.BaseControls.Form;

namespace EIDSS.Tests
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-ru");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-ru");
            //Application.Run(new BarcodeTestForm());

            DesignDbAdapter adapter = new DesignDbAdapter((long) NumberingObject.Specimen);
            adapter.DeleteBarcodeLayout();

            Application.Run(new BarCodeForm(NumberingObject.Specimen, null));
        }
    }
}