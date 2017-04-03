using System.Collections;
using System.Windows.Forms;

namespace EIDSS.RAM.QueryBuilder
{
    public class ChildQueryObjectList
    {
        private readonly ArrayList m_List;
        private Control m_ParentControl;
        private int m_Left;
        private int m_Top;
        private int m_Width = 464;
        private int m_Height = 320;
        private int m_TabIndex;

        public ChildQueryObjectList()
        {
            m_List = new ArrayList();
            m_ParentControl = null;
        }

        public ChildQueryObjectList(Control aParentControl)
        {
            m_List = new ArrayList();
            m_ParentControl = aParentControl;
        }

        public ChildQueryObjectList(Control aParentControl, int aLeft, int aTop, int aWidth, int aHeight, int aTabIndex)
        {
            m_List = new ArrayList();
            m_ParentControl = aParentControl;
            m_Left = aLeft;
            m_Top = aTop;
            m_Width = aWidth;
            m_Height = aHeight;
            m_TabIndex = aTabIndex;
        }

        private void SetParentControl(Control ctrl)
        {
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    var qsoInfo = (QuerySearchObjectInfo) qso;
                    if ((m_ParentControl != null) && (m_ParentControl.Controls.Contains(qsoInfo)))
                    {
                        m_ParentControl.Controls.Remove(qsoInfo);
                    }
                    if (ctrl != null)
                    {
                        ctrl.Controls.Add(qsoInfo);
                    }
                    qsoInfo.Parent = ctrl;
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
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    var qsoInfo = (QuerySearchObjectInfo) qso;
                    qsoInfo.Left = aLeft;
                }
            }
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
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    var qsoInfo = (QuerySearchObjectInfo) qso;
                    qsoInfo.Top = aTop;
                }
            }
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
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    var qsoInfo = (QuerySearchObjectInfo) qso;
                    qsoInfo.Width = aWidth;
                }
            }
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
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    var qsoInfo = (QuerySearchObjectInfo) qso;
                    qsoInfo.Height = aHeight;
                }
            }
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
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    var qsoInfo = (QuerySearchObjectInfo) qso;
                    qsoInfo.TabIndex = aTabIndex;
                }
            }
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
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    var qsoInfo = (QuerySearchObjectInfo) qso;
                    if (qsoInfo.SearchObject == aSearchObject)
                    {
                        return qsoInfo;
                    }
                }
            }
            return null;
        }

        public QuerySearchObjectInfo Item(int aOrder)
        {
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    var qsoInfo = (QuerySearchObjectInfo) qso;
                    if (qsoInfo.Order == aOrder)
                    {
                        return qsoInfo;
                    }
                }
            }
            return null;
        }

        public bool Contains(long aSearchObject)
        {
            QuerySearchObjectInfo qsoInfo = Item(aSearchObject);
            if (qsoInfo != null)
            {
                return true;
            }
            return false;
        }

        public bool Contains(QuerySearchObjectInfo qsoInfo)
        {
            return m_List.Contains(qsoInfo);
        }

        public QuerySearchObjectInfo Add(QuerySearchObjectInfo qsoInfo)
        {
            QuerySearchObjectInfo qsoInfoEx = Item(qsoInfo.SearchObject);
            if (qsoInfoEx != null)
            {
                return qsoInfoEx;
            }
            bool orderOk = (qsoInfo.Order > 0) && (qsoInfo.Order <= m_List.Count);
            if (orderOk)
            {
                orderOk = false;
                foreach (object qso in m_List)
                {
                    if (qso is QuerySearchObjectInfo)
                    {
                        qsoInfoEx = qso as QuerySearchObjectInfo;
                        if ((qsoInfo.Order == qsoInfoEx.Order))
                        {
                            orderOk = true;
                        }
                        if (orderOk)
                        {
                            qsoInfoEx.Order = qsoInfoEx.Order + 1;
                        }
                    }
                }
            }
            if ((orderOk == false) && (qsoInfo.Order != m_List.Count + 1))
            {
                qsoInfo.Order = m_List.Count + 1;
            }

            if (m_ParentControl != null)
            {
                m_ParentControl.Controls.Add(qsoInfo);
            }
            qsoInfo.Parent = m_ParentControl;

            //qsoInfo.Left = m_Left;
            //qsoInfo.Top = m_Top;
            //qsoInfo.Width = m_Width;
            //qsoInfo.Height = m_Height;
            qsoInfo.TabIndex = m_TabIndex;
            //qsoInfo.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            qsoInfo.Dock = DockStyle.Fill;
            m_List.Add(qsoInfo);

            SetSearchObjectVisible(qsoInfo);

            return qsoInfo;
        }

        public QuerySearchObjectInfo Add(long aSearchObject)
        {
            QuerySearchObjectInfo qsoInfo = Item(aSearchObject);
            if (qsoInfo != null)
            {
                return qsoInfo;
            }

            qsoInfo = new QuerySearchObjectInfo(aSearchObject, m_List.Count + 1)
                          {Name = string.Format("qso{0}", aSearchObject)};
            return Add(qsoInfo);
        }

        public QuerySearchObjectInfo Add(long aSearchObject, int aOrder)
        {
            QuerySearchObjectInfo qsoInfo = Item(aSearchObject);
            if (qsoInfo != null)
            {
                return qsoInfo;
            }

            qsoInfo = new QuerySearchObjectInfo(aSearchObject, aOrder) {Name = string.Format("qso{0}", aSearchObject)};
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
            QuerySearchObjectInfo qsoInfoEx;
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    qsoInfoEx = qso as QuerySearchObjectInfo;
                    if ((qsoInfoEx.Order > qsoInfo.Order))
                    {
                        qsoInfoEx.Order = qsoInfoEx.Order - 1;
                    }
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
                object qso = m_List[i];
                if (qso is QuerySearchObjectInfo)
                {
                    var qsoInfo = qso as QuerySearchObjectInfo;
                    Remove(qsoInfo);
                }
            }
        }

        public void SetSearchObjectVisible(QuerySearchObjectInfo qsoInfo)
        {
            if (Contains(qsoInfo) == false)
            {
                return;
            }
            QuerySearchObjectInfo qsoInfoEx;
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    qsoInfoEx = qso as QuerySearchObjectInfo;
                    qsoInfoEx.Visible = false;
                }
            }
            qsoInfo.Visible = true;
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
            QuerySearchObjectInfo qsoInfo;
            foreach (object qso in m_List)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    qsoInfo = qso as QuerySearchObjectInfo;
                    qsoInfo.Visible = false;
                }
            }
        }
    }
}