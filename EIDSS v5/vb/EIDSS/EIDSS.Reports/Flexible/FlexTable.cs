using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Flexible
{
    public class FlexTable : XRTable
    {
        private XRTableRow m_HeaderRow;
        private XRTableRow m_InnerRow;

        private XRTableCell m_HeaderCell;

        public FlexTable()
        {
            InitializeComponents();
        }

        public XRTableRow HeaderRow
        {
            get { return m_HeaderRow; }
        }

        public XRTableRow InnerRow
        {
            get { return m_InnerRow; }
        }

        public XRTableCell HeaderCell
        {
            get { return m_HeaderCell; }
        }

        private void InitializeComponents()
        {
           BeginInit();

            m_HeaderRow = new XRTableRow();
            m_HeaderCell = new XRTableCell();
            m_InnerRow = new XRTableRow();

            Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
            LocationFloat = new PointFloat(0, 0);
            Rows.AddRange(new XRTableRow[] {m_HeaderRow, m_InnerRow});
            StylePriority.UseBorders = false;

            m_HeaderRow.Height = 20;
            m_HeaderRow.Cells.Add(m_HeaderCell);

            m_HeaderRow.Name = "HeaderRow";
            m_HeaderCell.Name = "HeaderCell";
            m_InnerRow.Name = "InnerRow";
            m_InnerRow.Height = 0;
            // Note: No need to call EndInit() here. It should be called by FlexFactory
        }
    }
}