using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Flexible
{
    public class FlexTable : XRTable
    {
        public FlexTable()
        {
            InitializeComponents();
        }

        public XRTableRow HeaderRow { get; private set; }

        public XRTableRow InnerRow { get; private set; }

        public XRTableCell HeaderCell { get; private set; }

        private void InitializeComponents()
        {
            BeginInit();

            HeaderRow = new XRTableRow();
            HeaderCell = new XRTableCell();
            InnerRow = new XRTableRow();

            Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
            LocationFloat = new PointFloat(0, 0);
            Rows.AddRange(new[] {HeaderRow, InnerRow});
            StylePriority.UseBorders = false;

            HeaderRow.Height = 20;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderRow.Name = "HeaderRow";
            HeaderCell.Name = "HeaderCell";
            InnerRow.Name = "InnerRow";
            InnerRow.Height = 0;
            // Note: No need to call EndInit() here. It should be called by FlexFactory
        }
    }
}