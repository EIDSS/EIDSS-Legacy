using System;
using System.Collections.Generic;

namespace bv.winclient.Core
{
    public class LabelControlList
    {
        public LabelControlList(int left, int top)
        {
            Left = left;
            Top = top;
        }
        public LabelControlList()
        {
            Left = 0;
            Top = 0;
        }

        private readonly List<LabelControlPair> m_List = new List<LabelControlPair>();
        public int Top { get; set; }
        public int Left { get; set; }
        public List<LabelControlColumn> m_Columns = new List<LabelControlColumn>();
        public List<LabelControlColumn> Columns { get { return m_Columns; } }

        private void ResetColumns()
        {
            while (m_Columns.Count > ColumnsCount)
            {
                m_Columns.RemoveAt(m_Columns.Count - 1);
            }
            for (int i = m_Columns.Count; i < m_ColumnsCount; i++)
            {
                var col = new LabelControlColumn
                    {
                        ControlWidth = m_ControlWidth,
                        LabelWidth = m_CaptionWidth,
                        Left = GetWidth(),
                    };
                col.Changed += UpdateLayout;
                m_Columns.Add(col);
            }
        }

        private int GetWidth()
        {
            int i = m_Columns.Count - 1;
            if (i >= 0)
                return m_Columns[i].Left + m_Columns[i].LabelWidth + m_Columns[i].ControlWidth + m_ColumnsDistance;
            return 0;
        }
        public void Add(LabelControlPair pair)
        {
            m_List.Add(pair);
            if (m_CaptionWidth < pair.CaptionWidth)
            {
                m_CaptionWidth = pair.CaptionWidth;
            }
            if (m_ControlWidth < pair.ControlWidth)
            {
                m_ControlWidth = pair.ControlWidth;
            }
            if (pair.LabelHeight > m_LineHeight)
                pair.LabelHeight = m_LineHeight;
            m_LayoutUpdated = false;
        }
        public void Remove(int index)
        {
            if (index >= 0 && index < m_List.Count)
            {
                m_List.RemoveAt(index);
                m_LayoutUpdated = false;
            }
        }
        public void Clear()
        {
            m_List.Clear();
            m_LayoutUpdated = false;
        }
        public void ForceUpdate()
        {
            m_LayoutUpdated = false;
        }
        public LabelControlPair Item(int index)
        {
            return (m_List[index]);
        }

        private bool m_AutoSizeControls;
        public bool AutoSizeControls
        {
            get { return m_AutoSizeControls; }
            set
            {
                m_AutoSizeControls = value;
                m_LayoutUpdated = false;
            }
        }

        private int m_CaptionWidth;

        public int CaptionWidth
        {
            get
            {
                return m_CaptionWidth;
            }
            set
            {
                m_CaptionWidth = value;
                m_LayoutUpdated = false;
            }
        }

        private int m_ControlWidth;
        public int ControlWidth
        {
            get
            {
                return m_ControlWidth;
            }
            set
            {
                m_ControlWidth = value;
                m_LayoutUpdated = false;
            }
        }
        private int m_ColumnsCount = 1;
        public int ColumnsCount
        {
            get
            {
                return m_ColumnsCount;
            }
            set
            {
                m_ColumnsCount = value;
                ResetColumns();
                m_LayoutUpdated = false;
            }
        }
        private int m_LineHeight = 28;
        public int LineHeight
        {
            get
            {
                return m_LineHeight;
            }
            set
            {
                m_LineHeight = value;
                foreach (var pair in m_List)
                {
                    pair.LabelHeight = m_LineHeight;
                }
                m_LayoutUpdated = false;
            }
        }

        private int m_ColumnsDistance = 8;
        public int ColumnsDistance
        {
            get
            {
                return m_ColumnsDistance;
            }
            set
            {
                m_ColumnsDistance = value;
                m_LayoutUpdated = false;
            }
        }
        private int m_ControlCount;
        private void CalcVisibleControlsCount()
        {
            m_ControlCount = 0;
            foreach (LabelControlPair pair in m_List)
            {
                if (pair.Visible)
                {
                    m_ControlCount++;
                }
            }
        }
        private bool m_LayoutUpdated;
        public void UpdateLayout()
        {
            if (m_LayoutUpdated)
            {
                return;
            }
            m_LayoutUpdated = true;
            ResetColumns();
            CalcVisibleControlsCount();
            int ctlInColumnQty = Convert.ToInt32(Math.Ceiling((double)m_ControlCount / m_ColumnsCount));
            //LabelControlPair.m_XDistance = ColumnsDistance;
            if (Top + Item(0).TopOffset < 0)
                Top = -Item(0).TopOffset;
            int y = Top;
            int i = 0;
            for (int j = 0; j <= ctlInColumnQty - 1; j++)
            {
                int x = Left;
                int q = 0;
                while ((i < m_List.Count) && (q < m_ColumnsCount))
                {
                    if (Item(i).Visible)
                    {
                        if (AutoSizeControls)
                            Item(i).Arrange(x, y, CaptionWidth, ControlWidth);
                        else
                            Item(i).Arrange(m_Columns[q].Left, y, m_Columns[q].LabelWidth, m_Columns[q].ControlWidth);
                        x += CaptionWidth + ControlWidth + ColumnsDistance;
                        q++;
                    }
                    i++;
                }
                y += m_LineHeight;
            }
        }
        private void Control_VisibleChanged(object sender, System.EventArgs e)
        {
            m_LayoutUpdated = false;
        }

    }
}
