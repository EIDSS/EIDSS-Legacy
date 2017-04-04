using System.Windows.Forms;
using EIDSS.Reports.Barcode.Designer;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Tests.Barcode
{
    public partial class BarcodeTestForm : Form
    {
        public BarcodeTestForm()
        {
            InitializeComponent();

            BaseBarcodeReport report = new BaseBarcodeReport();
            const long index = (long) NumberingObject.HumanAggregateCase;

            report.GetNewBarcode(index, 1);

            DesignController controller = new DesignController(index, report);
            controller.SwowInDesigner(this);
        }
    }
}