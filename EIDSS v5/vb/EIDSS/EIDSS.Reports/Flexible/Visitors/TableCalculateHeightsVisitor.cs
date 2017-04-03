using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraReports.UI;
using EIDSS.FlexibleForms.Helpers.ReportHelper;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;
using bv.winclient.Core;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class TableCalculateHeightsVisitor : FlexNodeVisitor
    {
        private readonly double m_Scale;
        private readonly Dictionary<int, float> m_HeaderHeights = new Dictionary<int, float>();
        private readonly Dictionary<int, float> m_InnerHeights = new Dictionary<int, float>();

        public TableCalculateHeightsVisitor(double scale)
        {
            if (scale <= 0)
                throw new ArgumentException(@"Should be a positive number", "scale");
            m_Scale = scale;
        }

        public Dictionary<int, float> HeaderHeights
        {
            get { return m_HeaderHeights; }
        }

        public Dictionary<int, float> InnerHeights
        {
            get { return m_InnerHeights; }
        }

        public override void Visit(FlexNode node)
        {
            if (!(node.AssignedControl is FlexTable))
                return;

            var table = (FlexTable) node.AssignedControl;

            SizeF headerSize = WinUtils.MeasureString(table.HeaderCell.Text, table.HeaderCell.Font,
                                             (int) (table.Width / m_Scale) - 2 * ReportSettings.Padding);
            float height = ((int)headerSize.Height == 0) ? 0 : headerSize.Height + ReportSettings.DeltaRowHeight;
            UpdateHeightsDictionary(m_HeaderHeights, node.Level, height);

            float innerHeight = 0;
            foreach (XRTableCell cell in table.InnerRow.Cells)
            {
                SizeF cellSize = WinUtils.MeasureString(cell.Text, cell.Font,
                                               (int) (cell.Width / m_Scale) - 2 * ReportSettings.Padding);
                float currentHeight = cellSize.Height + ReportSettings.DeltaRowHeight;
                if (innerHeight < currentHeight)
                {
                    innerHeight = currentHeight;
                }
            }
            UpdateHeightsDictionary(m_InnerHeights, node.Level, innerHeight);
        }

        private static void UpdateHeightsDictionary(IDictionary<int, float> heighs, int key, float size)
        {
            if (!heighs.ContainsKey(key))
            {
                heighs.Add(key, 0);
            }
            if (size > heighs[key])
            {
                heighs[key] = size;
            }
        }
    }
}