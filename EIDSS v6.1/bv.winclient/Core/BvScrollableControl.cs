using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using bv.common.Core;
using ScrollOrientation = System.Windows.Forms.ScrollOrientation;
using VScrollBar = DevExpress.XtraEditors.VScrollBar;

namespace bv.winclient.Core
{
    public partial class BvScrollableControl : XtraScrollableControl
    {
        public VScrollBar m_VScroll;
        private XtraScrollableControl m_Container;
        public BvScrollableControl()
        {
            WindowsFormsSettings.SmartMouseWheelProcessing = true;
            InitializeComponent();
            if (Localizer.IsRtl)
            {
                Margin = new Padding(0);
                Padding = new Padding(0);
                m_VScroll = new VScrollBar
                    {
                        RightToLeft = RightToLeft.No,
                        Dock = DockStyle.Left,
                        SmallChange = 5,
                        Parent = this
                    };
                VerticalScroll.Visible = false;
                m_Container = new XtraScrollableControl();
                m_Container.Parent = this;
                m_Container.Location = new Point(0, 0);
                m_Container.ClientSize = ClientSize; 
                //m_Container.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                m_VScroll.Scroll += ScrollVertically;
                //ParentChanged += SetParent;
                Resize += ResizeMe;
                //m_VScroll.GotFocus += ScrollGotFocus;
                //m_VScroll.MouseUp += ScrollGotFocus;
                m_Container.MouseWheel += OnMouseWheel;
                //m_VScroll.MouseWheel += OnMouseWheel;
                MouseWheel += OnMouseWheel;
            }
            //else
            //{
            //    m_Container.Visible = false;
            //    m_VScroll.Visible = false;
            //}
        }
        public int ClientWidth
        {
            get { return Localizer.IsRtl ? m_Container.ClientSize.Width : ClientSize.Width; }
        }
        private void ScrollGotFocus(object sender, EventArgs e)
        {
            m_Container.Select();
        }


        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (!m_VScroll.Visible)
                return;
            //Control control = sender as Control;// NEW LINE
            //if (control.Bounds.Contains(e.Location)) return; //NEW LINE
            DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            int scrollValue = m_VScroll.Value;
            if (e.Delta < 0)
            {
                int delta = m_VScroll.Value + m_VScroll.SmallChange;
                m_VScroll.Value = Math.Min(delta, m_VScroll.Maximum - m_VScroll.LargeChange + 1);
            }
            else
                if (scrollValue < m_VScroll.SmallChange)
                    m_VScroll.Value = 0;
                else
                    m_VScroll.Value -= m_VScroll.SmallChange;
            ScrollVertically(m_VScroll, new ScrollEventArgs(ScrollEventType.ThumbPosition, scrollValue, m_VScroll.Value, ScrollOrientation.VerticalScroll));

        }

        private void SetParent(object sender, EventArgs e)
        {
            AutoScroll = false;
            //m_VScroll.Parent = Parent;
            //Parent.MouseWheel += OnMouseWheel;
        }

        private void ResizeMe(object sender, EventArgs e)
        {
            if (!m_Initialized)
                return;
            var showScroll = ClientSize.Height < m_Container.Height;
            m_VScroll.LargeChange = ClientSize.Height;
            m_VScroll.Maximum = m_Container.Height;// -m_VScroll.LargeChange + 1;
            m_VScroll.Visible = showScroll;
            m_Container.Left = showScroll ? m_VScroll.Width : 0;
            m_Container.Width = showScroll ? Width - m_VScroll.Width : Width;
        }

        private void ScrollVertically(object sender, ScrollEventArgs e)
        {
            SuspendLayout();
            m_Container.SuspendLayout();
            Point p = m_Container.Location;
            p.Y = 0 - e.NewValue;
            m_Container.Location = p;
            m_Container.ResumeLayout();
            ResumeLayout();
            //VerticalScroll.Value = e.NewValue;
        }

        private bool m_Initialized;
        public void Init()
        {
            if (Localizer.IsRtl)
            {
                int bottom = 0;
                m_Container.ClientSize = new Size(ClientSize.Width, ClientSize.Height);
                foreach (Control ctl in Controls.Cast<Control>().ToList())
                {
                    if (ctl == m_VScroll || ctl == m_Container)
                        continue;
                    if (bottom < ctl.Top + ctl.Height)
                    {
                        bottom = ctl.Top + ctl.Height;
                    }
                    ctl.Parent = m_Container;
                }
                m_Container.ClientSize = new Size(ClientSize.Width,
                                                  bottom + m_Container.Margin.Top + m_Container.Margin.Bottom +
                                                  m_Container.Padding.Top + m_Container.Padding.Bottom + 4);
                m_VScroll.Value = 0;
                //ResizeMe(this, EventArgs.Empty);
            }
            m_Initialized = true;
        }
        //internal bool IsCaptured = false;
        //ScrollBarViewInfoWithHandlerBase m_CapturedScrollBar = null;
        //protected internal ScrollBarViewInfoWithHandlerBase CapturedScrollBar
        //{
        //    get { return m_CapturedScrollBar; }
        //    set
        //    {
        //        if (value == m_CapturedScrollBar) return;
        //        m_CapturedScrollBar = value;
        //    }
        //}

        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);
        //    OnScrollAction(ScrollNotifyAction.MouseMove);
        //}
        //internal void OnScrollAction(ScrollNotifyAction action)
        //{
        //    m_VScroll.OnAction(action);
        //}
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    OnScrollAction(ScrollNotifyAction.MouseMove);
        //    if (Capture && CapturedScrollBar != null) CapturedScrollBar.OnMouseMove(e);
        //    base.OnMouseMove(e);
        //}
        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    if (IsCaptured)
        //    {
        //        ResetCapture();
        //        if (CapturedScrollBar != null)
        //        {
        //            CapturedScrollBar.OnMouseUp(e);
        //            CapturedScrollBar.OnLostCapture();
        //            return;
        //        }
        //    }
        //    base.OnMouseUp(e);
        //}
        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    ResetCapture();
        //    base.OnMouseDown(e);
        //}
        //void ResetCapture()
        //{
        //    if (!IsCaptured) return;
        //    IsCaptured = false;
        //    Capture = false;
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    if (Localizer.IsRtl)
        //    {
        //        using (GraphicsCache cache = new GraphicsCache(e))
        //        {
        //            StyleObjectInfoArgs args = new StyleObjectInfoArgs();
        //            args.SetAppearance(new AppearanceObject(Appearance, DefaultAppearance));
        //            args.Bounds = ClientRectangle;
        //            ObjectPainter.DrawObject(cache, Painter, args);
        //        }
        //        base.RaisePaintEvent(this, e);
        //    }
        //    else
        //    {
        //        base.OnPaint(e);
        //    }
        //}

        private void ScrollDown(int pos)
        {
            //pos passed in should be positive
            using (Control c = new Control() { Parent = this, Height = 1, Top = this.ClientSize.Height + pos })
            {
                ScrollControlIntoView(c);
            }
        }
        private void ScrollUp(int pos)
        {
            //pos passed in should be negative
            using (Control c = new Control() { Parent = this, Height = 1, Top = pos })
            {
                ScrollControlIntoView(c);
            }
        }

    }
    //public partial class BvScrollableControl : DevExpress.XtraEditors.XtraScrollableControl
    //{
    //    public BvScrollableControl()
    //    {
    //        InitializeComponent();
    //    }

    //    protected VScrollBarViewInfoWithHandler m_VScroll;
    //    protected override VScrollBarViewInfoWithHandler CreateVScrollBar()
    //    {
    //        m_VScroll = base.CreateVScrollBar();
    //        return m_VScroll;
    //    }
    //    protected override void SyncScrollbars()
    //    {
    //        base.SyncScrollbars();
    //        if (IsHandleCreated && RightToLeft == RightToLeft.Yes)
    //        {
    //            m_VScroll.Bounds = new Rectangle(new Point(0, 0), m_VScroll.Bounds.Size);
    //            m_VScroll.Invalidate();

    //        }
    //    }
    //}
    //public class BvVScrollBarViewInfoWithHandler : VScrollBarViewInfoWithHandler
    //{
    //    public BvVScrollBarViewInfoWithHandler(XtraScrollableControl owner)
    //        : base(owner)
    //    {

    //    }
    //    public override RightToLeft RightToLeft
    //    {
    //        get
    //        {
    //            return Localizer.IsRtl? RightToLeft.Yes : RightToLeft.No;
    //        }
    //    }

    //}
}
