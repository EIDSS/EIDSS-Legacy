using System;
using System.Data;
using System.Drawing;
using bv.winclient.Core;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Model.Report;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class TableVisitor : FlexNodeVisitor
    {
        private int? m_TableMaxWidth;

        public int? TableMaxWidth
        {
            get { return m_TableMaxWidth; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(@"Should be a positive number", "value");
                m_TableMaxWidth = value;
            }
        }

        public string TableHeader { get; set; }

        public override void Visit(FlexNodeReport node)
        {
            if (!(node.DataItem is FlexTableItem))
                return;
            if (IsNodeHasTableParent(node))
                return;

            ((FlexTable) (node.AssignedControl)).HeaderCell.Text = TableHeader;

            var cellVisitor = new CellVisitor();
            node.AcceptForward(cellVisitor);

            FlexReport parentReport = GetParentReport((XRControl)node.AssignedControl);

            var dataSet = new DataSet(@"MainDataSet");
            DataTable dataTable = ((FlexTableItem) node.DataItem).BodyData ?? new DataTable();
            dataTable.TableName = @"MainDataTable";
            dataSet.Tables.Add(dataTable);
            parentReport.DataMember = dataTable.TableName;
            parentReport.DataSource = dataSet;

            XRTable parentTable = CreateTable(parentReport);
            XRTableRow parentRow = CreateRow(parentTable);

            int count = Math.Min(dataTable.Columns.Count, cellVisitor.WidthCollection.Count);
            for (int index = 0; index < count; index++)
            {
                int width = cellVisitor.WidthCollection[index];
                DataColumn column = dataTable.Columns[index];
                column.ColumnName = @"Column" + column.ColumnName;

                XRTableCell cell = CreateCell(parentRow, width);
                string bindingName = string.Format(@"{0}.{1}", dataTable.TableName, column.ColumnName);
                cell.DataBindings.Add(new XRBinding("Text", dataSet, bindingName));
            }

            int maxWidth = TableMaxWidth.HasValue
                               ? TableMaxWidth.Value
                               : parentReport.PageWidth - parentReport.Margins.Left - parentReport.Margins.Right;

            double scale = (double) node.DataItem.Width / maxWidth;

            // Note: commented because tables in aggregate reports should have widht equal page width
//            if (scale < 1)
//            {
//                scale = 1;
//            }

            node.AcceptForward(new TableApplyWidthVisitor(scale));

            var heightsVisitor = new TableCalculateHeightsVisitor(scale);
            node.AcceptForward(heightsVisitor);
            var tableApplyHeightsVisitor =
                new TableApplyHeightsVisitor(heightsVisitor.HeaderHeights, heightsVisitor.InnerHeights);
            node.AcceptForward(tableApplyHeightsVisitor);

            parentTable.Width = (int) (parentTable.Width / scale);
            foreach (XRControl control in parentReport.HeaderBand.Controls)
            {
                if (control is XRTable)
                    control.Width = parentTable.Width;
            }

            parentTable.EndInit();
        }

        private static XRTable CreateTable(FlexReport parentReport)
        {
            var parentTable = new XRTable();
            parentTable.BeginInit();

            parentTable.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
            parentTable.Location = new Point(0, 0);
            parentTable.Width = parentReport.Width;
            parentTable.StylePriority.UseBorders = false;
            parentReport.DetailBand.Controls.Add(parentTable);
            parentReport.DetailBand.Height = 0;
            parentReport.HeaderBand.Height = 0;
            return parentTable;
        }

        private static XRTableRow CreateRow(XRTable parentTable)
        {
            var parentRow = new XRTableRow();
            parentTable.Rows.Add(parentRow);
            parentRow.Name = @"parentRow";
            return parentRow;
        }

        private static XRTableCell CreateCell(XRTableRow parentRow, int width)
        {
            var cell = new XRTableCell
                           {
                               Font = new Font(CurrentFontName,
                                               ReportSettings.DefaultFontSize,
                                               FontStyle.Regular),
                               Padding = new PaddingInfo(ReportSettings.Padding, ReportSettings.Padding, 0, 0, 100F),
                               Width = width,
                               Text = width.ToString()
                           };

            cell.StylePriority.UseBorders = false;
            parentRow.Cells.Add(cell);
            return cell;
        }

        private static FlexReport GetParentReport(XRControl control)
        {
            if (control == null)
                return null;
            if (control is FlexReport)
                return (FlexReport) control;
            return GetParentReport(control.Parent);
        }

        internal static bool IsNodeHasTableParent(FlexNodeReport node)
        {
            var parentNode = node.ParentNode;
            while (parentNode != null && !(parentNode.DataItem is FlexTableItem))
            {
                parentNode = parentNode.ParentNode;
            }
            return parentNode != null;
        }
    }
}