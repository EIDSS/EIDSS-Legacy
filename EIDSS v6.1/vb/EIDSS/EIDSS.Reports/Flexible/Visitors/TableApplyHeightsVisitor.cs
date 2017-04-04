using System;
using System.Collections.Generic;
using System.Linq;
using bv.common.Core;
using eidss.model.Model.Report;

namespace EIDSS.Reports.Flexible.Visitors
{
    public class TableApplyHeightsVisitor : FlexNodeVisitor
    {
        private readonly Dictionary<int, float> m_HeaderHeight;
        private readonly Dictionary<int, float> m_InnerHeight;

        public TableApplyHeightsVisitor(Dictionary<int, float> headerHeight, Dictionary<int, float> innerHeight)
        {
            Utils.CheckNotNull(headerHeight, "headerHeight");
            Utils.CheckNotNull(innerHeight, "innerHeight");

            m_HeaderHeight = headerHeight;
            m_InnerHeight = innerHeight;
        }

        public override void Visit(FlexNodeReport node)
        {
            if (!(node.AssignedControl is FlexTable))
            {
                return;
            }

            if ((!m_HeaderHeight.ContainsKey(node.Level)) || (!m_InnerHeight.ContainsKey(node.Level)))
            {
                throw new ApplicationException("Dictionary of Height does not contain value for node of level " + node.Level);
            }

            var table = (FlexTable) node.AssignedControl;

            table.HeaderRow.HeightF = m_HeaderHeight[node.Level];

            var allHeaders = m_HeaderHeight.Where(pair => pair.Key > node.Level).Sum(pair => pair.Value);
            var maxLevel = m_InnerHeight.Keys.Max();
            table.InnerRow.HeightF = allHeaders + m_InnerHeight[maxLevel];

            table.HeightF = table.HeaderRow.HeightF + table.InnerRow.HeightF;
        }
    }
}