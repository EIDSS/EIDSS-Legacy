using System.Collections.Generic;
using System.Windows.Forms;

namespace eidss.avr.QueryBuilder
{
    public class ChildQueryObjectList
    {
        private readonly List<QuerySearchObjectInfo> m_List;
        private Control m_ParentControl;
        private int m_Left;
        private int m_Top;
        private int m_Width = 464;
        private int m_Height = 320;
        private int m_TabIndex;

        public ChildQueryObjectList()
        {
            m_List = new List<QuerySearchObjectInfo>();
            m_ParentControl = null;
        }

        public ChildQueryObjectList(Control aParentControl)
        {
            m_List = new List<QuerySearchObjectInfo>();
            m_ParentControl = aParentControl;
        }

        public ChildQueryObjectList(Control aParentControl, int aLeft, int aTop, int aWidth, int aHeight, int aTabIndex)
        {
            m_List = new List<QuerySearchObjectInfo>();
            m_ParentControl = aParentControl;
            m_Left = aLeft;
            m_Top = aTop;
            m_Width = aWidth;
            m_Height = aHeight;
            m_TabIndex = aTabIndex;
        }

        private void SetParentControl(Control ctrl)
        {
            foreach (var qso in m_List)
            {
                if ((m_ParentControl != null) && (m_ParentControl.Controls.Contains(qso)))
                {
                    m_ParentControl.Controls.Remove(qso);
                }
                if (ctrl != null)
                {
                    ctrl.Controls.Add(qso);
                }
            }
        }

        public Control ParentControl
        {
            get { return m_ParentControl; }
            set
            {
                if (m_ParentControl == value)
                {
                    return;
                }
                SetParentControl(value);
                m_ParentControl = value;
            }
        }

        private void SetLeft(int aLeft)
        {
            m_List.ForEach(qso => qso.Left = aLeft);
        }

        public int Left
        {
            get { return m_Left; }
            set
            {
                if (m_Left == value)
                {
                    return;
                }
                SetLeft(value);
                m_Left = value;
            }
        }

        private void SetTop(int aTop)
        {
            m_List.ForEach(qso => qso.Top = aTop);
        }

        public int Top
        {
            get { return m_Top; }
            set
            {
                if (m_Top == value)
                {
                    return;
                }
                SetTop(value);
                m_Top = value;
            }
        }

        private void SetWidth(int aWidth)
        {
            m_List.ForEach(qso => qso.Width = aWidth);
        }

        public int Width
        {
            get { return m_Width; }
            set
            {
                if (m_Width == value)
                {
                    return;
                }
                SetWidth(value);
                m_Width = value;
            }
        }

        private void SetHeight(int aHeight)
        {
            m_List.ForEach(qso => qso.Height = aHeight);
        }

        public int Height
        {
            get { return m_Height; }
            set
            {
                if (m_Height == value)
                {
                    return;
                }
                SetHeight(value);
                m_Height = value;
            }
        }

        private void SetTabIndex(int aTabIndex)
        {
            m_List.ForEach(qso => qso.TabIndex = aTabIndex);
        }

        public int TabIndex
        {
            get { return m_TabIndex; }
            set
            {
                if (m_TabIndex == value)
                {
                    return;
                }
                SetTabIndex(value);
                m_TabIndex = value;
            }
        }

        public int Count
        {
            get
            {
                if (m_List == null)
                {
                    return 0;
                }
                return m_List.Count;
            }
        }

        public QuerySearchObjectInfo Item(long aSearchObject)
        {
            return m_List.Find(qso => qso.SearchObject == aSearchObject);
        }

        public QuerySearchObjectInfo Item(int aOrder)
        {
            return m_List.Find(qso => qso.Order == aOrder);
        }

        public bool Contains(long aSearchObject)
        {
            return m_List.Exists(qso => qso.SearchObject == aSearchObject);
        }

        public bool Contains(QuerySearchObjectInfo qsoInfo)
        {
            return m_List.Contains(qsoInfo);
        }

        public QuerySearchObjectInfo Add(QuerySearchObjectInfo qsoInfo)
        {
            var qsoInfoEx = Item(qsoInfo.SearchObject);
            if (qsoInfoEx != null)
            {
                return qsoInfoEx;
            }
            bool orderOk = (qsoInfo.Order > 0) && (qsoInfo.Order <= m_List.Count);
            if (orderOk)
            {
                orderOk = false;
                foreach (var qso in m_List)
                {
                    if ((qsoInfo.Order == qso.Order))
                        orderOk = true;
                    if (orderOk)
                        qso.Order = qso.Order + 1;
                }
            }
            if ((orderOk == false) && (qsoInfo.Order != m_List.Count + 1))
            {
                qsoInfo.Order = m_List.Count + 1;
            }
            qsoInfo.Visible = false;
            if (m_ParentControl != null)
            {
                m_ParentControl.Controls.Add(qsoInfo);
            }
            //qsoInfo.Parent = m_ParentControl;

            //qsoInfo.Left = m_Left;
            //qsoInfo.Top = m_Top;
            //qsoInfo.Width = m_Width;
            //qsoInfo.Height = m_Height;
            qsoInfo.TabIndex = m_TabIndex;
            //qsoInfo.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            qsoInfo.Dock = DockStyle.Fill;
            m_List.Add(qsoInfo);

            //SetSearchObjectVisible(qsoInfo);

            return qsoInfo;
        }

        public QuerySearchObjectInfo Add(long aSearchObject)
        {
            QuerySearchObjectInfo qsoInfo = Item(aSearchObject);
            if (qsoInfo != null)
            {
                return qsoInfo;
            }

            qsoInfo = new QuerySearchObjectInfo(aSearchObject, m_List.Count + 1) { Name = string.Format("qso{0}", aSearchObject) };
            return Add(qsoInfo);
        }

        public QuerySearchObjectInfo Add(long aSearchObject, int aOrder)
        {
            QuerySearchObjectInfo qsoInfo = Item(aSearchObject);
            if (qsoInfo != null)
            {
                return qsoInfo;
            }

            qsoInfo = new QuerySearchObjectInfo(aSearchObject, aOrder) { Name = string.Format("qso{0}", aSearchObject) };
            return Add(qsoInfo);
        }

        public void Remove(QuerySearchObjectInfo qsoInfo)
        {
            if (Contains(qsoInfo) == false)
            {
                return;
            }
            if (m_ParentControl != null)
            {
                m_ParentControl.Controls.Remove(qsoInfo);
                qsoInfo.Parent = null;
            }
            foreach (var qso in m_List)
            {
                if ((qso.Order > qsoInfo.Order))
                {
                    qso.Order = qso.Order - 1;
                }
            }
            m_List.Remove(qsoInfo);
        }

        public void Remove(long aSearchObject)
        {
            if (Contains(aSearchObject) == false)
            {
                return;
            }
            QuerySearchObjectInfo qsoInfo = Item(aSearchObject);
            Remove(qsoInfo);
        }

        public void Clear()
        {
            for (int i = m_List.Count - 1; i >= 0; i--)
            {
                Remove(m_List[i]);
            }
        }

        public void SetSearchObjectVisible(QuerySearchObjectInfo qsoInfo)
        {
            if (Contains(qsoInfo) == false)
                return;
            m_List.ForEach(qso => qso.Visible = (qso == qsoInfo));
        }

        public void SetSearchObjectVisible(long aSearchObject)
        {
            if (Contains(aSearchObject) == false)
            {
                return;
            }
            QuerySearchObjectInfo qsoInfo = Item(aSearchObject);
            SetSearchObjectVisible(qsoInfo);
        }

        public void SetAllSearchObjectsInVisible()
        {
            m_List.ForEach(qso => qso.Visible = false);
        }
    }
}