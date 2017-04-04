using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using bv.winclient.Core;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Model;
using eidss.model.Model.Report;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class ReportVisitor : FlexNodeVisitor
    {
        private const int MaxSubreportHeight = 700;
        public Dictionary<int, int> LevelFont { get; set; }

        public override void Visit(FlexNodeReport node)
        {
            // create subreport for root node and for non-leaf node 
            if (node.IsRoot)
            {
                var report = new FlexReport();
                node.AssignedControl = report;
            }
            else
            {
                if ((node.Count != 0) && (!(node.DataItem is FlexTableItem)))
                {
                    var childReport = new FlexReport();
                    node.AssignedControl = childReport;
                    if (node.DataItem is FlexLabelItem)
                    {
                        var labelItem = ((FlexLabelItem) node.DataItem);
                        childReport.Text = labelItem.Text;

                        childReport.Font = new Font(CurrentFontName,
                            labelItem.FontSize + ReportSettings.DeltaFontSize - GetDeltaFontForNode(node),
                            (FontStyle) labelItem.FontStyle | FontStyle.Bold);
                    }
                    MakeControlsLink(node);
                }
                else
                {
                    if (node.DataItem is FlexTableItem)
                    {
                        var parentControl = (XRControl) ((FlexNodeReport) node.ParentNode).AssignedControl;

                        if (TableVisitor.IsNodeHasTableParent(node) && !(parentControl is FlexTable))
                        {
                            throw new ApplicationException("Non-root table node should have parent of type XRTableRow");
                        }
                        var table = new FlexTable();

                        var tableItem = ((FlexTableItem) node.DataItem);
                        if (!TableVisitor.IsNodeHasTableParent(node))
                        {
                            var childReport = new FlexReport();
                            node.AssignedControl = childReport;
                            childReport.Text = string.Empty;
                            MakeControlsLink(node);
                            parentControl = childReport.HeaderBand;
                        }
                        else
                        {
                            table.Borders = BorderSide.Right | BorderSide.Bottom;
                            var parentTable = ((FlexTable) parentControl);

                            parentControl = CreateParentCell(parentTable, node);
                            table.Height = parentControl.Height;
                        }

                        table.HeaderCell.Text = tableItem.Text;
                        // Note: uncomment for debug 
                        //table.HeaderCell.Text = string.Format("({0}) {1}", node.DataItem.Width, tableItem.Text);
                        table.HeaderCell.Font = new Font(CurrentFontName,
                            WinClientContext.CurrentFont.Size,
                            FontStyle.Regular);

                        table.Width = node.DataItem.Width;

                        parentControl.Controls.Add(table);

                        node.AssignedControl = table;
                    }
                    else if (node.DataItem is FlexLabelItem)
                    {
                        var nd = (FlexNodeReport) node.ParentNode;
                        var label = nd.AssignedControl is FlexTable
                            ? CreateParentCell((FlexTable) nd.AssignedControl, node)
                            : new XRLabel();

                        var labelItem = (FlexLabelItem) node.DataItem;

                        label.Padding = new PaddingInfo(ReportSettings.Padding, ReportSettings.Padding, 0, 0, 100F);
                        label.Text = labelItem.Text;

                        // Note: uncomment for debug 
                        // label.Text = string.Format("({0}) {1}", node.DataItem.Width, labelItem.Text);
                        label.Font = new Font(CurrentFontName,
                            labelItem.FontSize - GetDeltaFontForNode(node),
                            (FontStyle) labelItem.FontStyle);
                        label.ForeColor = labelItem.Color;
                        if (labelItem.IsParameterValue)
                        {
                            label.Borders = BorderSide.Bottom;
                            string toMeasure = string.IsNullOrEmpty(label.Text) ? "X" : label.Text;
                            SizeF size = WinUtils.MeasureString(toMeasure, label.Font, labelItem.Width);
                            if (labelItem.Height > size.Height)
                            {
                                labelItem.Height = (int) size.Height;
                            }
                        }
                        //Note: [ivan] uncomment for debug 
                        //label.Borders = BorderSide.All;
                        //
                        node.AssignedControl = label;
                        if (!(((FlexNodeReport) node.ParentNode).AssignedControl is FlexTable))
                        {
                            MakeControlsLink(node);
                        }
                    }
                }
            }
        }

        private static XRTableCell CreateParentCell(FlexTable parentTable, FlexNodeBase node)
        {
            var parentCell = new XRTableCell();
            parentCell.StylePriority.UseBorders = false;
            parentCell.Width = node.DataItem.Width;

            var parentRow = parentTable.InnerRow;

            var levelVisitor = new LevelVisitor();
            ((FlexNodeReport) node.ParentNode).AcceptForward(levelVisitor);

            parentRow.Cells.Add(parentCell);
            return parentCell;
        }

        private int GetDeltaFontForNode(FlexNodeBase node)
        {
            return (LevelFont != null) && (LevelFont.ContainsKey(node.Level))
                ? LevelFont[node.Level]
                : 0;
        }

        private static void MakeControlsLink(FlexNodeReport node)
        {
            if (!node.IsRoot && node.DataItem != null)
            {
                var nd = (FlexNodeReport) node.ParentNode;
                var parentControl = (XRControl) nd.AssignedControl;
                if (nd.AssignedControl is FlexReport)
                {
                    var parentReport = ((FlexReport) nd.AssignedControl);
                    parentControl = parentReport.DetailBand;
                }

                // Calculate delta for summary height of subreports below. 
                //it needs because real subreport height not equal to corresponding node.DataItem.Height
                int delta = 0;
                foreach (var subreport in parentControl.Controls.OfType<XRSubreport>())
                {
                    var otherChild = node.ParentNode.ChildList.SingleOrDefault(
                            n => ((XRControl) ((FlexNodeReport) n).AssignedControl) == subreport.ReportSource);
                    if (otherChild != null)
                    {
                        delta += subreport.Height - otherChild.DataItem.Height;
                    }
                }

                if (node.AssignedControl is FlexReport)
                {
                    var childReport = (FlexReport) node.AssignedControl;
                    childReport.Width = node.DataItem.Width;
                    var currentSubreport = new XRSubreport
                    {
                        Location = new Point(node.DataItem.Left, node.DataItem.Top + delta),
                        Size = new Size(node.DataItem.Width, Math.Min(MaxSubreportHeight, node.DataItem.Height)),
                        ReportSource = childReport
                    };

                    parentControl.Controls.Add(currentSubreport);
                }
                else
                {
                    var ctrl = (XRControl) node.AssignedControl;
                    ctrl.Left = node.DataItem.Left;
                    ctrl.Top = node.DataItem.Top + delta;

                    ctrl.Width = node.DataItem.Width;
                    ctrl.Height = node.DataItem.Height;

                    parentControl.Controls.Add(ctrl);
                }
            }
        }
    }
}