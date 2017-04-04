using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using DevExpress.XtraTab;

namespace bv.winclient.Core.TranslationTool
{
    public class ControlDesignerProxy : Panel
    {
        readonly Timer m_Wriggler = new Timer();

        public ControlDesignerProxy()
        {
            m_Wriggler.Tick += TickHandler;
            m_Wriggler.Interval = 500;
            m_Wriggler.Enabled = true;
        }
        protected override void Dispose(bool disposing)
        {
            m_HostControl = null;
            base.Dispose(disposing);
        }


        private Control m_HostControl;
        public Control HostControl
        {
            get
            {
                return m_HostControl;
            }
            set
            {
                if (m_HostControl != null)
                {
                    SizeChanged -= OnThisSizeChanged;
                    LocationChanged -= OnThisLocation;
                    Parent = null;
                }

                m_HostControl = value;
                if (m_HostControl == null || m_HostControl.IsDisposed)
                    return;
                if (m_HostControl is XtraTabControl)
                {
                    IXtraTab iTab = (XtraTabControl)m_HostControl;
                    var bounds = iTab.ViewInfo.HeaderInfo.Bounds;
                    bounds.Location.Offset(2, 2);
                    Location = m_HostControl.Parent.PointToClient(m_HostControl.PointToScreen(bounds.Location));
                    Size = new Size(bounds.Size.Width - 4, bounds.Size.Height - 2);
                }
                else if (m_HostControl is NavBarControl)
                {
                    var bar = m_HostControl as NavBarControl;
                    Rectangle bounds = NavBarControlHelper.GetHeaderBound(bar);
                    if (bounds == Rectangle.Empty)
                    {
                        bounds = NavBarControlHelper.GetGroupHeaderBound(bar, bar.Groups[0]);

                    }
                    if (bounds != Rectangle.Empty)
                    {
                        Location = m_HostControl.Parent.PointToClient(m_HostControl.PointToScreen(bounds.Location));
                        Size = new Size(bounds.Size.Width, bounds.Size.Height);
                    }
                    for (int i = 1; i < bar.Groups.Count; i++)
                    {
                        bounds = NavBarControlHelper.GetGroupHeaderBound(bar, bar.Groups[i]);
                        var groupProxy = new ControlDesignerProxy();
                        groupProxy.m_HostControl = m_HostControl;
                        groupProxy.Location = m_HostControl.Parent.PointToClient(m_HostControl.PointToScreen(bounds.Location));
                        groupProxy.Size = new Size(bounds.Size.Width, bounds.Size.Height);
                        groupProxy.Parent = m_HostControl.Parent;
                        groupProxy.BringToFront();
                        groupProxy.SizeChanged += OnThisSizeChanged;
                        groupProxy.LocationChanged += OnThisLocation;
                        if (RelatedProxy == null)
                            RelatedProxy = new List<ControlDesignerProxy>();
                        RelatedProxy.Add(groupProxy);
                    }
                }
                else
                {
                    Location = m_HostControl.Location;
                    Size = m_HostControl.Size;

                }
                Parent = m_HostControl.Parent;
                BringToFront();
                SizeChanged += OnThisSizeChanged;
                LocationChanged += OnThisLocation;
            }
        }

        private void OnThisLocation(object sender, EventArgs e)
        {
            if (m_HostControl != null)
            {
                if (m_HostControl is PopupContainerEdit && TranslationToolHelperWinClient.IsLookupControl(m_HostControl.Parent))
                    m_HostControl.Parent.Location = Location;
                else
                    m_HostControl.Location = Location;
            }
        }

        private void OnThisSizeChanged(object sender, EventArgs e)
        {
            if (m_HostControl != null)
            {
                if (m_HostControl is PopupContainerEdit && TranslationToolHelperWinClient.IsLookupControl(m_HostControl.Parent))
                    m_HostControl.Parent.Size = Size;
                else m_HostControl.Size = Size;
            }
        }

        protected void TickHandler(object sender, EventArgs e)
        {
            InvalidateEx();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT 
                return cp;
            }
        }

        protected void InvalidateEx()
        {
            if (Parent == null)
                return;
            var rc = new Rectangle(Location, Size);
            Parent.Invalidate(rc, true);

        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
        }

        public bool Selected { get; set; }

        public List<ControlDesignerProxy> RelatedProxy { get; private set; }


    }
}
