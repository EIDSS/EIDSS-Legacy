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
        public LabelControlPair Item(int Index)
        {
            return (m_List[Index]);
        }
        private int m_CaptionWidth = 0;

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

        private int m_ControlWidth = 0;
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
                m_LayoutUpdated = false;
            }
        }
        private int m_LineHeight = 24;
        public int LineHeight
        {
            get
            {
                return m_LineHeight;
            }
            set
            {
                m_LineHeight = value;
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
        private void CalcVisibleControlsCont()
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
        private bool m_LayoutUpdated = false;
        public void UpdateLayout1()
        {
            if (m_LayoutUpdated)
            {
                return;
            }
            m_LayoutUpdated = true;
            CalcVisibleControlsCont();
            int ctlInColumnQty = Convert.ToInt32(Math.Ceiling((double)m_ControlCount / m_ColumnsCount));
            //LabelControlPair.m_XDistance = ColumnsDistance;
            int x = Left;
            int y = Top;
            for (int i = 0; i <= m_List.Count - 1; i++)
            {
                y = Top;
                int j = 0;
                bool updated = false;
                while (j < ctlInColumnQty && i < m_List.Count)
                {
                    if (Item(i).Visible)
                    {
                        Item(i).Arrange(x, y, CaptionWidth, ControlWidth);
                        y += m_LineHeight;
                        j++;
                    }
                    updated = true;
                    i++;
                }
                if (updated)
                {
                    i--;
                }
                x += CaptionWidth + ControlWidth + ColumnsDistance;
            }
        }
        public void UpdateLayout()
        {
            if (m_LayoutUpdated)
            {
                return;
            }
            m_LayoutUpdated = true;
            CalcVisibleControlsCont();
            int ctlInColumnQty = Convert.ToInt32(Math.Ceiling((double)m_ControlCount / m_ColumnsCount));
            //LabelControlPair.m_XDistance = ColumnsDistance;
            int x = Left;
            int y = Top;
            int i = 0;
            for (int j = 0; j <= ctlInColumnQty - 1; j++)
            {
                x = Left;
                int q = 0;
                while ((i < m_List.Count) && (q < m_ColumnsCount))
                {
                    if (Item(i).Visible)
                    {
                        Item(i).Arrange(x, y, CaptionWidth, ControlWidth);
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
