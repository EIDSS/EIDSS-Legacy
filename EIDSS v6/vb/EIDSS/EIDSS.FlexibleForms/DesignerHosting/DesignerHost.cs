using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;

namespace EIDSS.FlexibleForms.DesignerHosting
{
    public sealed partial class DesignerHost : XtraScrollableControl /*Panel*/ /*XtraUserControl*/
    {
        #region Delegates

        public delegate void SelectionChangedDelegate(object sender /*,EventArgs e*/);
        public delegate void RightClickDelegate(object sender /*,EventArgs e*/);

        #endregion

        //private GridBand _ActiveBand;
        private readonly List<ParameterHost> m_ActiveParameters=new List<ParameterHost>();

        private Point m_Anchor;
        private int m_Hittest;
        private bool m_IsDesignMode = true;
        private Control m_Moved;
        private Rectangle m_Oldsize;

        public int DisplayRectangleLeftStart { get; set; }
        public int DisplayRectangleTopStart { get; set; }

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd,
            int msg,
            int wParam,
            int lParam
            );


        public DesignerHost()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        public bool IsDesignMode
        {
            set
            {
                m_IsDesignMode = value;
                ClearActive();
                SetDesignMode(this, m_IsDesignMode);
            }
            get { return m_IsDesignMode; }
        }

        /// <summary>
        /// Выставляет у указанного контрола и его потомков
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        private void SetDesignMode(Control control, bool value)
        {
            if (control is ParameterHost) ((ParameterHost)control).IsDesignMode = value;
            foreach (Control ctl in control.Controls)
            {
                SetDesignMode(ctl, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<ParameterHost> GetSelectedParameterHosts()
        {
            return new List<ParameterHost>(m_ActiveParameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public ParameterHost GetSelectedParameterHost(int index)
        {
            return m_ActiveParameters[index];
        }

        /// <summary>
        /// Получает количество выбранных компонент
        /// </summary>
        /// <returns></returns>
        public int SelectedParameterHostsCount()
        {
            return GetSelectedParameterHosts().Count;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSelectedParameterHosts(List<ParameterHost> value)
        {
            //if (value == _ActiveParameter) return;
            //if (value != null && (parameter is ParameterHost) == false) return;
            ClearActive();
            if (value != null)
            {
                foreach (ParameterHost p in value)
                    p.ShowSelected(true);
                m_ActiveParameters.AddRange(value);
            }
            if (SelectionChanged != null) SelectionChanged(this);
            //ActiveParameter.Paint+=new PaintEventHandler(DesignerHost_ParameterPaint);
            //((Control)_ActiveParameter).Invalidate();
        }

        public event SelectionChangedDelegate SelectionChanged;
        public event RightClickDelegate RightClick;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public void Add(Control ctl)
        {
            ctl.Visible = true;
            var ph = ctl as ParameterHost;
            if (ph != null) ph.IsDesignMode = IsDesignMode;
            Controls.Add(ctl);
            ctl.BringToFront();
            ctl.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (DesignMode) return;
            if (!m_IsDesignMode) return;
            if (ReadOnly) return;

            if (m.Msg == 0x215 /*WM_CAPTURECHANGED*/)
            {
                bool handle = false;
                if (m.LParam.ToInt32() != 0 && m_Moved != null)
                {
                    Control ctl = FromHandle(m.LParam);
                    while (ctl != null)
                    {
                        if (ctl is ParameterHost) break;
                        ctl = ctl.Parent;
                    }
                    if (ctl != null && ctl.Handle == m_Moved.Handle)
                        //if (m.LParam != this.Handle)
                    {
                        //moved = null;
                        handle = true;
                        Capture = true;
                    }
                    /*                    else
                                        {
                                            moved = null;
                                        }*/
                }
                if (!handle)
                {
                    HandleResize();
                    m_Moved = null;
                }
            }
            if (m.Msg == 0x0210 /*WM_PARENTNOTIFY*/)
            {
                if(m.WParam.ToInt32() == 0x0201/*WM_LBUTTONDOWN*/)
                {
                    var coord = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                    var location = new Point(0, 0);
                    var child = GetControl(this, coord, ref location, null);
                        /*= GetChildAtPoint(coord);
                    while(child!=null)
                    {
                        coord.Offset(-child.Location.X ,-child.Location.Y );
                        Control temp = child.GetChildAtPoint(coord);
                        if (temp == null) break;
                        child = temp;
                    }*/
                    if (child != null)
                    {
                        m_Anchor = coord; // new Point(coord.X - child.Left, coord.Y - child.Top);
                        //this.PointToScreen(coord);
                        //child.poin
                        m_Hittest = ParameterHost.GetHitTest(child, location);
                        //int hittest=FFParameter.GetHitTest(child, anchor);
                        //if ( hittest<10 || hittest>17 )
                        {
                            Capture = true;
                            m_Moved = child;
                            m_Oldsize = m_Moved.Bounds;
                            m_Moved.BringToFront();
                        }
                        //anchor = moved.PointToClient(this.PointToScreen(coord));
                    }
                }
                if (m.WParam.ToInt32() == 0x0204/*WM_RBUTTONDOWN*/)
                {
                    if (RightClick != null)
                        RightClick(this);
                }
            }

            if (m.Msg == 0x0202) //WM_LBUTTONUP
            {
                HandleResize();
                m_Moved = null;
            }

            if (m.Msg == 0x0204) //*WM_RBUTTONDOWN
            {
                if (RightClick != null)
                    RightClick(this);
            }

            if (m.Msg == 0x0084) //WM_NCHITTEST
            {
                m.Result = new IntPtr(13); //HTSIZE;
                //Point p = new Point(m.LParam.ToInt32());
                var p = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                p = PointToClient(p);
                var child = GetChildAtPoint(p);
                if (child != null)
                {
                    //m.Result = new System.IntPtr(GetHitTest(child,p));
                    m.Result = new IntPtr(13);
                }
                else base.WndProc(ref m);
            }
        }

        private /*static*/ Control GetControl(Control parent, Point coord, ref Point pos, ParameterHost moveable)
        {
            bool ignored = ((moveable != null) && moveable.IsManagedControl(parent));

            Control child = parent.GetChildAtPoint(coord);
            if (
                ignored ||
                child == null || child.Created == false
                /*||
                ((moveable!=null) &&(child==((IDesignerObject)moveable).GetNotManagedControl()))*/
                )
            {
                if (moveable == null) return null;
                moveable.BringToFront();
                CalculateActive(parent, moveable, coord);
                if (ignored) return null;
                Point screen = parent.PointToScreen(coord);
                screen.Offset(-parent.ClientRectangle.X, -parent.ClientRectangle.Y);
                int ht = SendMessage(parent.Handle, 0x0084/*WM_NCHITTEST*/, 0, ((screen.Y) << 16) + screen.X);
                if (ht == 6/*HTHSCROL*/ || ht == 7/*HTVSCROLL*/)return null;
                //Control ctl=((IDesignerObject)moveable).GetNotManagedControl();
                //if (ctl != parent) return moveable;
                return moveable;
            }

            coord.Offset(-child.Location.X, -child.Location.Y);
            if (child is ParameterHost)
            {
                moveable = (ParameterHost) child;
                pos = coord;
            }
            return GetControl(child, coord, ref pos, moveable);
        }

        private void DesignerHost_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_Moved == null) return;
            if (e.Button != MouseButtons.Left) return;
            //Invalidate(moved);

            //Rectangle client = ClientRectangle;
            //client = moved.Parent.ClientRectangle;

            Rectangle next = m_Oldsize;
            if (m_Hittest >= 10 && m_Hittest <= 17)
            {
                //resize;
                int top = m_Oldsize.Top, left = m_Oldsize.Left, bottom = m_Oldsize.Bottom, right = m_Oldsize.Right;
                AnchorStyles sizeable = AnchorStyles.None;
                if (m_Hittest == 10 || m_Hittest == 13 || m_Hittest == 16)
                {
                    //if (Right - Left - e.X + anchor.X > moved.MinimumSize.Width)
                    //Left += e.X - anchor.X;
                    //else Left = Right - moved.MinimumSize.Width;
                    left = Math.Min(m_Oldsize.Right - m_Moved.MinimumSize.Width, m_Oldsize.Left + e.X - m_Anchor.X);
                    //next.X += e.X - anchor.X;
                    //next.Width -= e.X - anchor.X ;
                    sizeable |= AnchorStyles.Left;
                }
                if (m_Hittest == 11 || m_Hittest == 17 || m_Hittest == 14)
                {
                    /*if (Right + e.X - anchor.X - Left > moved.MinimumSize.Width)
                        Right += e.X - anchor.X;
                    else
                        Right = Left + moved.MinimumSize.Width;*/
                    right = Math.Max(m_Oldsize.Left + m_Moved.MinimumSize.Width, m_Oldsize.Right + e.X - m_Anchor.X);
                    //next.Width += e.X - anchor.X;
                    sizeable |= AnchorStyles.Right;
                }
                if (m_Hittest == 12 || m_Hittest == 13 || m_Hittest == 14)
                {
                    /*if (Bottom - Top - e.Y + anchor.Y > moved.MinimumSize.Height)
                        Top += e.Y - anchor.Y;
                    else
                        Top = Bottom - moved.MinimumSize.Height;*/
                    top = Math.Min(m_Oldsize.Bottom - m_Moved.MinimumSize.Height, m_Oldsize.Top + e.Y - m_Anchor.Y);
                    //next.Y += e.Y - anchor.Y;
                    //next.Height -= e.Y - anchor.Y;
                    sizeable |= AnchorStyles.Top;
                }
                if (m_Hittest == 15 || m_Hittest == 16 || m_Hittest == 17)
                {
                    /*if (Bottom - Top + e.Y - anchor.Y > moved.MinimumSize.Height)
                        Bottom += e.Y - anchor.Y;
                    else
                        Bottom = Top + moved.MinimumSize.Height;*/
                    bottom = Math.Max(m_Oldsize.Top + m_Moved.MaximumSize.Height, m_Oldsize.Bottom + e.Y - m_Anchor.Y);
                    //next.Height += e.Y - anchor.Y;
                    sizeable |= AnchorStyles.Bottom;
                }
                left = Math.Max(AutoScrollPosition.X, left);
                top = Math.Max(AutoScrollPosition.Y, top);
                next = new Rectangle(left, top, right - left, bottom - top);
                Glue(ref next, m_Moved, true, sizeable);
                //next.Intersect(client);
            }
            else
            {
                next.X = m_Oldsize.X + e.X - m_Anchor.X;
                next.Y = m_Oldsize.Y + e.Y - m_Anchor.Y;

                //Rectangle copy = next;
                Glue(ref next, m_Moved, false,
                     AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                //if(Math.Abs(copy.Left-))
                if (next.Left < AutoScrollPosition.X) next.X = AutoScrollPosition.X;
                //if (next.Bottom > client.Bottom) next.Y = client.Bottom - next.Height;
                if (next.Top < AutoScrollPosition.Y) next.Y = AutoScrollPosition.Y;
                //if (next.Right > client.Right) next.X = client.Right - next.Width;*/
            }
            m_Moved.Bounds = next;
            //moved.Invalidate(true);
            m_Moved.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="ctl"></param>
        /// <param name="resize"></param>
        /// <param name="sizeable"></param>
        private void Glue(ref Rectangle r, Control ctl, bool resize, AnchorStyles sizeable)
        {
            //System.Diagnostics.Trace.Write("\r\n");
            //System.Diagnostics.Trace.Write(r);

            if ((ModifierKeys & Keys.Alt) == Keys.Alt) return;
            const int diff = 10;
            int topDelta = diff;
            int leftDelta = diff;
            int rightDelta = diff;
            int bottomDelta = diff;
            int top = r.Top;
            int left = r.Left;
            int right = r.Right;
            int bottom = r.Bottom;
            List<Rectangle> list = new List<Rectangle>();
            Point start = GetControlLocation(m_Moved.Parent);
            start = new Point(-start.X, -start.Y);
            GetAllObjects(this, m_Moved, start, ref list);

            //foreach (Control c in list/*ctl.Parent.Controls*/)
            foreach (Rectangle st in list)
            {
                if (((sizeable & AnchorStyles.Top) == AnchorStyles.Top) && Math.Abs(st.Top - r.Top) < topDelta)
                {
                    top = st.Top;
                    topDelta = Math.Abs(st.Top - r.Top);
                }
                if (((sizeable & AnchorStyles.Left) == AnchorStyles.Left) && Math.Abs(st.Left - r.Left) < leftDelta)
                {
                    left = st.Left;
                    leftDelta = Math.Abs(st.Left - r.Left);
                }
                if (((sizeable & AnchorStyles.Bottom) == AnchorStyles.Bottom) &&
                    Math.Abs(st.Bottom - r.Bottom) < bottomDelta)
                {
                    bottom = st.Bottom;
                    bottomDelta = Math.Abs(st.Bottom - r.Bottom);
                }
                if (((sizeable & AnchorStyles.Right) == AnchorStyles.Right) && Math.Abs(st.Right - r.Right) < rightDelta)
                {
                    right = st.Right;
                    rightDelta = Math.Abs(st.Right - r.Right);
                }
            }
            if (resize)
                r = new Rectangle(left, top, right - left, bottom - top);
            else
            {
                if (Math.Abs(topDelta) > Math.Abs(bottomDelta))
                    top = bottom - r.Height;
                if (Math.Abs(leftDelta) > Math.Abs(rightDelta))
                    left = right - r.Width;
                r.Location = new Point(left, top);
            }
            //System.Diagnostics.Trace.Write(r);
        }

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    return;
        //    /*if (!isDesignMode) return;
        //    Draw(this);*/
        //    /*
        //    foreach (Control c in Controls)
        //    {
        //        //if (c is ParameterHost)
        //        {
        //            Rectangle r = c.Bounds;
        //            r.Inflate(1, 1);
        //            ControlPaint.DrawFocusRectangle(e.Graphics, r);
        //        }
        //    }
        //    */
        //}

        /*
        private void Invalidate(Control c)
        {
            Rectangle r = c.Bounds;
            r.Inflate(1, 1);
            Invalidate(r);
        }*/

        private void HandleResize()
        {
            if (m_Moved == null) return;
            Control parent = m_Moved.Parent;
            while (parent != null)
            {
                if (parent is ParameterHost)
                {
                    ((ParameterHost) parent).DoResize();
                    break;
                }
                parent = parent.Parent;
            }
        }

        private Point GetControlLocation(Control ctl)
        {
            var p = new Point(0, 0);
            //Control =ctl;
            while (ctl != this && ctl != null)
            {
                p.Offset(ctl.Location);
                ctl = ctl.Parent;
            }
            return p;
        }

        private void GetAllObjects(Control ctl, Control exclude, Point parent, ref List<Rectangle> list)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c == exclude) continue;
                if (c is ParameterHost /*&&c!=exclude*/)
                {
                    Rectangle r = c.Bounds;
                    r.Offset(parent);
                    list.Add(r);
                }
                Point p = parent;
                p.Offset(c.Location);
                GetAllObjects(c, exclude, p, ref list);
            }
        }

        private void CalculateActive(Control parent, Control moveable, Point coord)
        {
            if (moveable == null) return;
            var host = (ParameterHost)moveable;
            List<ParameterHost> p = null;
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                p = GetSelectedParameterHosts();
            }
            if (p == null) p = new List<ParameterHost>();
            if(p.Contains(host))
                p.Remove(host);
            else
                p.Add(host);
            SetSelectedParameterHosts(p);
        }

/*
        private void DesignerHost_ParameterPaint(object sender, PaintEventArgs e)
        {
            Rectangle r = ((Control)sender).ClientRectangle;
            Rectangle inner = r;
            inner.Inflate(-3, -3);
            //ControlPaint.DrawFocusRectangle(e.Graphics, r);
            //r.Inflate(-3, -3);
            //ControlPaint.DrawFocusRectangle(e.Graphics, r,Color.Blue ,Color.Bisque );
            //ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedOuter       );
            //ControlPaint.DrawBorder(e.Graphics, r, Color.Black , ButtonBorderStyle.Dashed      ); 
            //ControlPaint.DrawGrabHandle(e.Graphics, r,true,true);
            //ControlPaint.DrawLockedFrame(e.Graphics, r, true);
            //ControlPaint.
            //inner = new Rectangle(10, 10, r.Width - 20, r.Height - 20);
            ControlPaint.DrawSelectionFrame(e.Graphics, true, r, inner, Color.White);
        }
*/

//        private void DesignerHost_CustomDrawBandHeader(object sender, BandHeaderCustomDrawEventArgs e)
//        {
////            if (e.Band != _ActiveBand) return;
//            //A brush to fill the band's background in the normal state
//            //Brush brush = new LinearGradientBrush(e.Bounds, Color.Wheat, Color.Chocolate, 70);
//            //A brush to fill the background when the band is pressed
//            //Brush brushPressed = new LinearGradientBrush(e.Bounds,
//            //Color.WhiteSmoke, Color.Gray, 70);
//            Rectangle r = e.Bounds;
//            //Draw a 3D border
//            //ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.SunkenOuter );
//            //r.Inflate(-2, -2);
//            e.Graphics.FillRectangle(SystemBrushes.Highlight, r);
//            /*r.Inflate(-2, 0);
//            //Draw the band's caption with a shadowed effect
//            e.Appearance.DrawString(e.Cache, e.Band.Caption, new Rectangle(r.X + 1, r.Y + 1,
//              r.Width, r.Height));*/


//            e.Appearance.DrawString(e.Cache, e.Band.Caption, new Rectangle(r.X + 5, r.Y, r.Width, r.Height),
//                                    SystemBrushes.HighlightText);

//            //e.Appearance.DrawString(e.Cache, e.Band.Caption, r, Brushes.Black);
//            //Prevent default painting
//            e.Handled = true;
//            //System.Diagnostics.Trace.Write(e.Band);
//        }

        private void DesignerHost_MouseDown(object sender, MouseEventArgs e)
        {
            ClearActive();
            if (SelectionChanged != null) SelectionChanged(this);
        }

        public void ClearActive()
        {
            /*
            if (_ActiveBand != null)
            {
                _ActiveBand.View.GridControl.Invalidate();
                _ActiveBand.View.CustomDrawBandHeader -= DesignerHost_CustomDrawBandHeader;
                _ActiveBand = null;
            }
            */
            //if (_ActiveParameters != null)
            {
                foreach(ParameterHost p in m_ActiveParameters)
                    p.ShowSelected(false);
                //((Control)_ActiveParameter).Invalidate();
                //ActiveParameter.Paint -= new PaintEventHandler(DesignerHost_ParameterPaint);
                m_ActiveParameters.Clear();
                Focus();
            }
        }

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}