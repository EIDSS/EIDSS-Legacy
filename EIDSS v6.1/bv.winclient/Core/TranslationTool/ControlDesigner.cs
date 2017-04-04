using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.winclient.BasePanel;

namespace bv.winclient.Core.TranslationTool
{
    public class ControlDesigner
    {
        /// <summary>
        /// Контрол, над которым проводятся операции движения, изменения размера, смены отображаемого текста
        /// </summary>
        private DesignElement DesignType { get; set; }
        /// <summary>
        /// Окно редактирования заголовков
        /// </summary>
        public MemoEdit CaptionEditor { get; set; }
        private const int SelectionWidth = 2;
        private const int MinSize = 5;
        internal string InitialText { get; set; }
        internal Point InitialLocation { get; set; }
        internal Size InitialSize { get; set; }
        public UndoControlState StoredUndoState { get; set; }
        /// <summary>
        /// Связь с редактируемым столбцом
        /// </summary>
        internal object EditedObject { get; set; }

        #region Constructor
        /// <summary>
        /// Links designer with entire control
        /// All DesignElement flags are applied to entire control
        /// </summary>
        public ControlDesigner(Control ctl, string caption = null)
        {
            Dbg.Assert(ctl != null, "Control designer can't be  initialized without parent control");
            ProcessedControl = ctl;
            DesignType = DesignElement.All;
            InitBehavior(Point.Empty, Size.Empty, caption);
        }

        public ControlDesigner(Control ctl, DesignElement designType, ControlEdge resizeType = ControlEdge.All, string caption = null)
        {
            Dbg.Assert(ctl != null, "Control designer can't be  initialized without parent control");
            ProcessedControl = ctl;
            if (RealControl != null)
            {
                switch (RealControl.Dock)
                {
                    case DockStyle.Top:
                        if ((resizeType & ControlEdge.Bottom) != 0)
                            ResizeEdges = ControlEdge.Bottom;
                        break;
                    case DockStyle.Bottom:
                        if ((resizeType & ControlEdge.Top) != 0)
                            ResizeEdges = ControlEdge.Top;
                        break;
                    case DockStyle.Left:
                        if ((resizeType & ControlEdge.Right) != 0)
                            ResizeEdges = ControlEdge.Right;
                        break;
                    case DockStyle.Right:
                        if ((resizeType & ControlEdge.Left) != 0)
                            ResizeEdges = ControlEdge.Left;
                        break;
                    case DockStyle.Fill:
                        ResizeEdges = ControlEdge.None;
                        break;
                    default:
                        ResizeEdges = resizeType;
                        break;
                }
                if (RealControl.Dock != DockStyle.None)
                    designType = ~DesignElement.Moving & designType;
            }
            DesignType = designType;
            InitBehavior(Point.Empty, Size.Empty, caption);
        }

        /// <summary>
        /// Links designer with control
        /// Only DesignElement.Caption will be applied control and 
        /// Text araea will be drawn in the passed rectangle
        /// </summary>
        public ControlDesigner(Control ctl, Point elemLocation, Size elemSize, string caption, object editedObject)
        {
            Dbg.Assert(ctl != null, "Control designer can't be  initialized without parent control");
            ProcessedControl = ctl;
            DesignType = DesignElement.Caption;
            EditedObject = editedObject;
            InitBehavior(elemLocation, elemSize, caption);
        }

        /// <summary>
        /// Завершение работы с контролом
        /// </summary>
        /// <param name="save"></param>
        public void Release(bool save = true)
        {
            if (save)
            {
                RaiseSaveEvent(new ControlDesignerEventArgs { ForceEditorClosing = false });
            }
            else
            {
                ProcessedControl.SuspendLayout();
                ProcessedControl.SetBounds(InitialLocation.X, InitialLocation.Y, InitialSize.Width, InitialSize.Height);
                ProcessedControl.ResumeLayout();
            }
            ReleaseMoving();
            ReleaseSizing();
            if (CaptionEditor != null)
            {
                HideFrame(CaptionEditor);
                CaptionEditor.Dispose();
                CaptionEditor = null;
            }
            else
                HideFrame(ProcessedControl);
        }

        public void SetRelativeBounds(ControlDesigner sourceDesigner)
        {
            int dx, dy, dw, dh;
            sourceDesigner.GetBoundsOffset(out dx, out dy, out dw, out dh);
            if (SizingEnabled)
            {
                SetBounds(ProcessedControl, InitialLocation.X - dx, InitialLocation.Y - dy,
                                    InitialSize.Width - dw, InitialSize.Height - dh);
            }
            else if (MovingEnabled)
            {
                MoveControl(ProcessedControl, InitialLocation.X - dx, InitialLocation.Y - dy);
            }
        }
        private void GetBoundsOffset(out int dx, out int dy, out int dw, out int dh)
        {
            dx = InitialLocation.X - ProcessedControl.Left;
            dy = InitialLocation.Y - ProcessedControl.Top;
            dw = InitialSize.Width - ProcessedControl.Width;
            dh = InitialSize.Height - ProcessedControl.Height;
        }


        #endregion

        #region Private methods

        private ITranslationView m_ParentView;
        private ITranslationView GetTranslationView()
        {
            var ctl = ProcessedControl;
            while (ctl != null)
            {
                if (ctl is ITranslationView)
                    return ctl as ITranslationView;
                ctl = ctl.Parent;
            }
            return null;
        }

        private void InitBehavior(Point elemLocation, Size elemSize, string caption)
        {
            //remove sizing flag if contol is autosized
            if ((ProcessedControl is LabelControl && (ProcessedControl as LabelControl).AutoSizeMode != LabelAutoSizeMode.None)
                || (ProcessedControl is Label && (ProcessedControl as Label).AutoSize))
                DesignType = DesignType & (~DesignElement.Sizing);

            InitialText = caption;
            InitialLocation = new Point(ProcessedControl.Location.X, ProcessedControl.Location.Y);
            InitialSize = new Size(ProcessedControl.Size.Width, ProcessedControl.Size.Height);
            InitCaptionEditor(elemLocation, elemSize, caption);
            InitSizing();
            InitMoving();
            if (Visible)
                DrawFrame(CaptionEditor ?? ProcessedControl);
            m_ParentView = GetTranslationView();
        }

        private static void OnControlPaint(object sender, PaintEventArgs e)
        {
            var r = ((Control)sender).ClientRectangle;
            var inner = r;
            inner.Inflate(-SelectionWidth, -SelectionWidth);
            ControlPaint.DrawSelectionFrame(e.Graphics, true, r, inner, Color.White);
        }

        private static void DrawFrame(Control ctl)
        {
            ctl = GetRealControl(ctl);
            ctl.Paint += OnControlPaint;
            ctl.Invalidate();
        }
        private static void HideFrame(Control ctl)
        {
            ctl.Cursor = Cursors.Default;
            ctl = GetRealControl(ctl);
            ctl.Paint -= OnControlPaint;
            ctl.Invalidate();
        }
        private static Control GetRealControl(Control ctl)
        {
            var proxy = ctl as ControlDesignerProxy;
            if (proxy != null)
            {
                if (TranslationToolHelperWinClient.IsLookupControl(proxy.HostControl) &&
                    ReflectionHelper.HasProperty(proxy.HostControl, "PopupEdit", BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    var c = ReflectionHelper.GetProperty(proxy.HostControl, "PopupEdit", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (c != null)
                        return (Control)c;
                }

                return proxy.HostControl;
            }
            return ctl;
        }


        #endregion

        #region public properties/methods

        public Control ProcessedControl { get; set; }
        public Control RealControl { get { return GetRealControl(ProcessedControl); } }
        public bool MovingEnabled { get { return (DesignType & DesignElement.Moving) != 0; } }
        public bool TranslationEnabled { get { return (DesignType & DesignElement.Caption) != 0; } }
        public bool SizingEnabled { get { return (DesignType & DesignElement.Sizing) != 0; } }
        public ControlEdge ResizeEdges { get; private set; }
        public event EventHandler ResizeEvent;
        private static readonly SizeF m_DefaultAutoCaleFactor = new SizeF(1, 1);
        public SizeF AutoScaleFactor
        {
            get
            {
                if (m_ParentView != null)
                    return m_ParentView.StoredAutoScaleFactor;
                return m_DefaultAutoCaleFactor;
            }
        }
        public void RaiseResizeEvent(EventArgs e)
        {
            EventHandler handler = ResizeEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler MoveEvent;
        public void RaiseMoveEvent(EventArgs e)
        {
            var handler = MoveEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public delegate void ControlDesignerEventHandler(object sender, ControlDesignerEventArgs e);
        public event ControlDesignerEventHandler SaveEvent;
        public void RaiseSaveEvent(ControlDesignerEventArgs args)
        {
            if (CaptionEditor != null && Text != InitialText && SaveEvent == null)
            {
                RaiseUndoEvent(new ControlDesignerEventArgs { UndoState = new UndoControlState { Element = (EditedObject as Component) ?? RealControl, Caption = InitialText, Operation = UndoOperation.Text } });
            }
            if (SaveEvent != null) { SaveEvent(this, args); }

        }

        public event ControlDesignerEventHandler UndoEvent;
        public void RaiseUndoEvent(ControlDesignerEventArgs args)
        {
            if (UndoEvent != null) { UndoEvent(this, args); }
        }
        public event ControlDesignerEventHandler CreateUndoStateEvent;
        public void RaiseCreateUndoStateEvent(ControlDesignerEventArgs args)
        {
            if (CreateUndoStateEvent != null) { CreateUndoStateEvent(this, args); }
        }

        public event ControlDesignerEventHandler CancelEvent;
        public void RaiseCancelEvent(ControlDesignerEventArgs args)
        {
            if (CancelEvent != null) { CancelEvent(this, args); }
        }

        public string Text
        {
            get { return CaptionEditor != null ? CaptionEditor.Text : String.Empty; }
        }

        #endregion

        #region Translation support
        private class LookupColumn
        {
            public string ResourseKey { get; set; }
            public string EnglishCaption { get; set; }
            public string Caption { get; set; }
        }
        private bool InitLookupEditor(LookUpEdit lookUp)
        {
            if (lookUp == null) return false;
            if (lookUp.Properties.Columns.Count > 0 && !(lookUp.Properties.Columns[0] is BvLookupColumnInfo))
                return false;
            var colEditor = new GridControl();
            var view = new DevExpress.XtraGrid.Views.Grid.GridView();
            colEditor.MainView = view;
            colEditor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { view });
            view.OptionsBehavior.AutoSelectAllInEditor = false;
            view.OptionsBehavior.Editable = true;
            view.OptionsBehavior.ReadOnly = false;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsCustomization.AllowGroup = false;
            view.OptionsCustomization.AllowQuickHideColumns = false;
            view.OptionsDetail.AllowZoomDetail = false;
            view.OptionsDetail.EnableMasterViewMode = false;
            view.OptionsDetail.ShowDetailTabs = false;
            view.OptionsDetail.SmartDetailExpand = false;
            view.OptionsFilter.AllowColumnMRUFilterList = false;
            view.OptionsFilter.AllowFilterEditor = false;
            view.OptionsFilter.AllowMRUFilterList = false;
            view.OptionsFind.AllowFindPanel = false;
            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsMenu.EnableGroupPanelMenu = false;
            view.OptionsMenu.ShowAutoFilterRowItem = false;
            view.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            view.OptionsMenu.ShowGroupSortSummaryItems = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.OptionsSelection.MultiSelect = false;
            view.OptionsView.ShowDetailButtons = false;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            view.Columns.Add(new GridColumn() { Caption = "English column name", FieldName = "EnglishCaption", Visible = true, VisibleIndex = 0 });
            view.Columns.Add(new GridColumn() { Caption = "Translation", FieldName = "Caption", Visible = true, VisibleIndex = 1 });
            view.Columns[0].OptionsColumn.AllowEdit = false;
            view.Columns[0].OptionsColumn.AllowFocus = false;
            view.Columns[0].OptionsColumn.ReadOnly = true;
            var listDataSource = new BindingList<LookupColumn>();

            foreach (var col in lookUp.Properties.Columns)
            {
                var bvCol = col as BvLookupColumnInfo;
                if (bvCol != null)
                {
                    listDataSource.Add(new LookupColumn() { ResourseKey = bvCol.ResourceKey, EnglishCaption = BvLookupColumnInfo.Messages.GetString(bvCol.ResourceKey, null, Localizer.lngEn), Caption = bvCol.Caption });
                }
            }
            colEditor.DataSource = listDataSource;
            //colEditor.Rows["ResourceKey"].Visible = false;
            //colEditor.Rows["EnglishCaption"].Properties.ReadOnly = true;
            colEditor.Location = lookUp.Location;
            colEditor.Parent = lookUp.Parent;
            colEditor.BringToFront();
            colEditor.Refresh();
            return true;
        }
        private const int MinEditorHeight = 20;
        private bool m_Visible = false;
        public bool Visible
        {
            get { return m_Visible; }
            set
            {
                m_Visible = value;
                if (CaptionEditor != null)
                    CaptionEditor.Visible = m_Visible;
                if (m_Visible)
                    DrawFrame(CaptionEditor ?? ProcessedControl);
                else
                    HideFrame(CaptionEditor ?? ProcessedControl);

            }
        }
        private void InitCaptionEditor(Point elemLocation, Size elemSize, string caption)
        {
            if (!TranslationEnabled) return;
            //Temporary commented
            //if (InitLookupEditor(RealControl as LookUpEdit))
            //    return;
            CaptionEditor = new MemoEdit { Text = caption, Font = ProcessedControl.Font, Padding = new Padding(0), Visible = false };
            CaptionEditor.Properties.ScrollBars = ScrollBars.None;
            ProcessedControl.Parent.SuspendLayout();
            //var isSpecialControl =
            //    (ProcessedControl is TreeList)
            //    || (ProcessedControl is TabControl)
            //    || (ProcessedControl is GridControl)
            //    || (ProcessedControl is GroupControl);
            //CaptionEditor.Parent = isSpecialControl ? ProcessedControl :
            CaptionEditor.Parent = ProcessedControl.Parent;
            //if editor height < MinEditorHeight, cursor is not visible
            //enlarge editor height to make cursor visible
            int y = (elemSize.Width > 0 && elemSize.Height > 0) ? elemLocation.Y : ProcessedControl.Location.Y;
            int height = (elemSize.Width > 0 && elemSize.Height > 0) ? elemSize.Height : ProcessedControl.Size.Height;
            if (height < MinEditorHeight)
            {
                y -= (MinEditorHeight - height) / 2;
                height = MinEditorHeight;
            }

            if (elemSize.Width > 0 && elemSize.Height > 0)
                CaptionEditor.SetBounds(elemLocation.X, y, elemSize.Width, height);
            else
                CaptionEditor.SetBounds(ProcessedControl.Location.X, y,
                                        ProcessedControl.Size.Width, height);
            CaptionEditor.KeyDown += OnCaptionEditorKeyDown;
            CaptionEditor.BringToFront();
            ProcessedControl.Parent.ResumeLayout();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCaptionEditorKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:

                    RaiseCancelEvent(new ControlDesignerEventArgs { ForceEditorClosing = true });
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
                case Keys.Enter:
                    if (!e.Control && !e.Alt && !e.Shift)
                    {
                        ((MemoEdit)sender).Properties.ReadOnly = true;
                        RaiseSaveEvent(new ControlDesignerEventArgs { ForceEditorClosing = true });
                        ((MemoEdit)sender).Properties.ReadOnly = false;
                        e.SuppressKeyPress = true;
                        e.Handled = true;
                    }
                    //else if (e.Control)
                    //{
                    //    ((Control)sender).Text += "\r\n";
                    //}

                    break;
            }
        }

        #endregion

        #region Moving support

        bool m_Dragging;
        Point m_DragStart = Point.Empty;
        private void InitMoving()
        {
            if (MovingEnabled) InitMovingInternal(CaptionEditor ?? ProcessedControl);
        }
        private void ReleaseMoving()
        {
            if (MovingEnabled) ReleaseMovingInternal(CaptionEditor ?? ProcessedControl);
        }

        private void InitMovingInternal(Control ctl)
        {
            ctl.MouseDown += Move_MouseDown;
            ctl.MouseUp += Move_MouseUp;
            ctl.MouseMove += Move_MouseMove;
        }
        private void ReleaseMovingInternal(Control ctl)
        {
            ctl.MouseDown -= Move_MouseDown;
            ctl.MouseUp -= Move_MouseUp;
            ctl.MouseMove -= Move_MouseMove;
        }


        private void Move_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            ControlEdge edge;
            if (IsCursorInsideResizeArea(sender, e, out edge))
                return;
            m_Dragging = true;
            m_DragStart = new Point(e.X, e.Y);
            var ctl = sender as Control;
            if (ctl != null)
            {
                ctl.Capture = true;
                if (StoredUndoState == null)
                {
                    StoredUndoState = new UndoControlState { Element = RealControl, Bounds = ctl.Bounds, Operation = UndoOperation.Position };
                    RaiseCreateUndoStateEvent(new ControlDesignerEventArgs { UndoState = StoredUndoState });
                }
            }
        }

        private void Move_MouseUp(object sender, MouseEventArgs e)
        {
            var ctl = sender as Control;
            if (ctl != null)
            {
                ctl.Capture = false;
                if (m_Dragging && StoredUndoState != null && StoredUndoState.Bounds != ctl.Bounds)
                {
                    RaiseUndoEvent(new ControlDesignerEventArgs { UndoState = StoredUndoState });
                    StoredUndoState = null;
                }
            }
            m_Dragging = false;
        }

        private void Move_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_Resizing && m_Edge != ControlEdge.None)
                return;
            if (m_Dragging)
            {
                var ctl = sender as Control;
                if (ctl != null)
                {
                    MoveControl(ctl, e.X + ctl.Left - m_DragStart.X, e.Y + ctl.Top - m_DragStart.Y);
                    if (ctl != ProcessedControl)
                    {
                        MoveControl(ProcessedControl, ctl.Left, ctl.Top);
                    }
                    RaiseMoveEvent(EventArgs.Empty);
                }
            }
        }
        private void MoveControl(Control ctl, int x, int y)
        {
            ctl.SuspendLayout();
            ctl.Left = Math.Min(Math.Max(0, x), (ctl.Parent.ClientSize.Width - MinSize));
            ctl.Top = Math.Min(Math.Max(0, y), ctl.Parent.ClientSize.Height - MinSize);
            ctl.ResumeLayout();
        }

        private void MoveControlToScreenCoordinates(Control ctl, Point screenPoint)
        {
            ctl.SuspendLayout();
            var point = ctl.PointToClient(screenPoint);
            ctl.Left = Math.Min(Math.Max(0, point.X), (ctl.Parent.ClientSize.Width - MinSize));
            ctl.Top = Math.Min(Math.Max(0, point.Y), ctl.Parent.ClientSize.Height - MinSize);
            ctl.ResumeLayout();
        }
        internal void MoveControl(int x, int y)
        {
            MoveControl(ProcessedControl, x, y);
        }

        internal void MoveControlToScreenCoordinates(Point screenPoint)
        {
            MoveControlToScreenCoordinates(ProcessedControl, screenPoint);
        }
        internal void MoveControlToScreenCoordinates(int x, int y)
        {
            MoveControlToScreenCoordinates(ProcessedControl, new Point(x, y));
        }

        internal Rectangle ScreenRect { get { return ProcessedControl != null && ProcessedControl.Parent != null ? ProcessedControl.Parent.RectangleToScreen(ProcessedControl.Bounds) : new Rectangle(); } }
        internal int Left
        {
            get { return ProcessedControl != null ? ProcessedControl.Left : 0; }
        }
        internal int LeftToScreen
        {
            get { return ProcessedControl != null && ProcessedControl.Parent != null ? ProcessedControl.Parent.PointToScreen(ProcessedControl.Location).X : 0; }
        }

        internal int Top
        {
            get { return ProcessedControl != null ? ProcessedControl.Top : 0; }
        }

        internal int TopToScreen
        {
            get { return ProcessedControl != null && ProcessedControl.Parent != null ? ProcessedControl.Parent.PointToScreen(ProcessedControl.Location).Y : 0; }
        }
        internal int Width
        {
            get { return ProcessedControl != null ? ProcessedControl.Width : 0; }
        }

        internal int Height
        {
            get { return ProcessedControl != null ? ProcessedControl.Height : 0; }
        }

        #endregion

        #region Resizing support

        private ControlEdge m_Edge;
        private bool m_Resizing;
        private bool m_IsEdgeDrawn;
        private const int EdgeWidth = 2;

        private void InitSizing()
        {
            if (SizingEnabled) InitSizingInternal(CaptionEditor ?? ProcessedControl);
        }

        private void ReleaseSizing()
        {
            if (SizingEnabled) ReleaseSizingInternal(CaptionEditor ?? ProcessedControl);
        }

        private void InitSizingInternal(Control ctl)
        {
            ctl.MouseDown += Size_MouseDown;
            ctl.MouseUp += Size_MouseUp;
            ctl.MouseMove += Size_MouseMove;
            ctl.MouseLeave += Size_MouseLeave;
        }
        private void ReleaseSizingInternal(Control ctl)
        {
            ctl.MouseDown -= Size_MouseDown;
            ctl.MouseUp -= Size_MouseUp;
            ctl.MouseMove -= Size_MouseMove;
            ctl.MouseLeave -= Size_MouseLeave;
        }


        private void Size_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
                return;
            ControlEdge edge;
            if (!IsCursorInsideResizeArea(sender, e, out edge))
                return;
            m_Resizing = true;
            var ctl = sender as Control;
            if (ctl != null)
            {
                ctl.Capture = true;
                if (StoredUndoState == null)
                {
                    StoredUndoState = new UndoControlState { Element = RealControl, Bounds = ctl.Bounds, Operation = UndoOperation.Position };
                    RaiseCreateUndoStateEvent(new ControlDesignerEventArgs { UndoState = StoredUndoState });
                }
            }
        }

        private void Size_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var ctl = sender as Control;
                if (ctl != null)
                {
                    if (m_Resizing && StoredUndoState != null && StoredUndoState.Bounds != ctl.Bounds)
                    {
                        RaiseUndoEvent(new ControlDesignerEventArgs { UndoState = StoredUndoState });
                        StoredUndoState = null;
                    }
                }
                m_Resizing = false;
                if (m_Edge != ControlEdge.None && m_Dragging)
                    m_Dragging = false;

            }
        }

        private void Size_MouseMove(object sender, MouseEventArgs e)
        {
            var c = sender as Control;
            if (c == null)
                return;
            if (m_Dragging)
                return;
            if (c is LabelControl && (c as LabelControl).AutoSizeMode != LabelAutoSizeMode.None)
                return;
            if (c is Label && (c as Label).AutoSize)
                return;

            var g = c.CreateGraphics();

            var brush = new SolidBrush(Color.Blue);
            if (m_IsEdgeDrawn)
            {
                c.Refresh();
                m_IsEdgeDrawn = false;
            }
            switch (m_Edge)
            {
                case ControlEdge.TopLeft:
                    g.FillRectangle(brush, 0, 0, EdgeWidth, c.Height);
                    g.FillRectangle(brush, 0, 0, c.Width, EdgeWidth);
                    m_IsEdgeDrawn = true;
                    break;
                case ControlEdge.Left:
                    g.FillRectangle(brush, 0, 0, EdgeWidth, c.Height);
                    m_IsEdgeDrawn = true;
                    break;
                case ControlEdge.Right:
                    g.FillRectangle(brush, c.Width - EdgeWidth, 0, c.Width, c.Height);
                    m_IsEdgeDrawn = true;
                    break;
                case ControlEdge.Top:
                    g.FillRectangle(brush, 0, 0, c.Width, EdgeWidth);
                    m_IsEdgeDrawn = true;
                    break;
                case ControlEdge.Bottom:
                    g.FillRectangle(brush, 0, c.Height - EdgeWidth, c.Width, EdgeWidth);
                    m_IsEdgeDrawn = true;
                    break;
                case ControlEdge.RightBottom:
                    g.FillRectangle(brush, 0, c.Height - EdgeWidth, c.Width, EdgeWidth);
                    g.FillRectangle(brush, c.Width - EdgeWidth, 0, c.Width, c.Height);
                    m_IsEdgeDrawn = true;
                    break;

            }

            if (m_Resizing && m_Edge != ControlEdge.None)
            {
                switch (m_Edge)
                {

                    case ControlEdge.TopLeft:
                        SetBounds(c, c.Left + e.X, c.Top + e.Y, c.Width - e.X, c.Height - e.Y);
                        break;
                    case ControlEdge.RightBottom:
                        SetBounds(c, c.Left, c.Top, c.Width - (c.Width - e.X), c.Height - (c.Height - e.Y));
                        break;
                    case ControlEdge.Left:
                        SetBounds(c, c.Left + e.X, c.Top, c.Width - e.X, c.Height);
                        break;
                    case ControlEdge.Right:
                        SetBounds(c, c.Left, c.Top, c.Width - (c.Width - e.X), c.Height);
                        break;
                    case ControlEdge.Top:
                        SetBounds(c, c.Left, c.Top + e.Y, c.Width, c.Height - e.Y);
                        break;
                    case ControlEdge.Bottom:
                        SetBounds(c, c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y));
                        break;
                }
                if (m_Edge != ControlEdge.None)
                    RaiseResizeEvent(EventArgs.Empty);
                if (c == CaptionEditor)
                {
                    SetBounds(ProcessedControl, c.Left, c.Top, c.Width, c.Height);
                }
            }
            else
            {
                IsCursorInsideResizeArea(sender, e, out m_Edge);
            }
        }

        public void SetBounds(Control ctl, int x, int y, int w, int h)
        {
            ctl.SuspendLayout();
            if (w > ctl.Parent.ClientSize.Width)
                w = ctl.Parent.ClientSize.Width;
            if (h > ctl.Parent.ClientSize.Height)
                h = ctl.Parent.ClientSize.Height;
            ctl.SetBounds(Math.Min(Math.Max(0, x), ctl.Parent.ClientSize.Width - MinSize)
                        , Math.Min(Math.Max(0, y), ctl.Parent.ClientSize.Height - MinSize)
                        , Math.Max(MinSize, w)
                        , Math.Max(MinSize, h));
            ctl.ResumeLayout();
        }

        public void SetWidth(int width)
        {
            SetBounds(ProcessedControl, ProcessedControl.Left, ProcessedControl.Top, width, ProcessedControl.Height);
        }
        public void SetHeight(int height)
        {
            SetBounds(ProcessedControl, ProcessedControl.Left, ProcessedControl.Top, ProcessedControl.Width, height);
        }
        private bool IsCursorInsideResizeArea(object sender, MouseEventArgs e, out ControlEdge edge)
        {
            var c = sender as Control;
            if (c == null)
            {
                edge = ControlEdge.None;
                return false;
            }
            if (e.X <= (EdgeWidth * 4) && e.Y <= (EdgeWidth * 4) && (ResizeEdges & ControlEdge.TopLeft) == ControlEdge.TopLeft) //top left corner
            {
                c.Cursor = Cursors.SizeNWSE;
                edge = ControlEdge.TopLeft;
                return true;
            }
            if (e.X > c.Width - (EdgeWidth * 4) && e.Y > c.Height - (EdgeWidth * 4) && (ResizeEdges & ControlEdge.RightBottom) == ControlEdge.RightBottom) //right bottom corner
            {
                c.Cursor = Cursors.SizeNWSE;
                edge = ControlEdge.RightBottom;
                return true;
            }
            if (e.X <= EdgeWidth && (ResizeEdges & ControlEdge.Left) > 0)//left edge
            {
                c.Cursor = Cursors.VSplit;
                edge = ControlEdge.Left;
                return true;
            }
            if ((e.X > c.Width - (EdgeWidth + 1)) && (ResizeEdges & ControlEdge.Right) > 0)// 'right edge
            {
                c.Cursor = Cursors.VSplit;
                edge = ControlEdge.Right;
                return true;
            }
            if (e.Y <= EdgeWidth && (ResizeEdges & ControlEdge.Top) > 0) // 'top edge
            {
                c.Cursor = Cursors.HSplit;
                edge = ControlEdge.Top;
                return true;
            }
            if ((e.Y > c.Height - (EdgeWidth + 1)) && (ResizeEdges & ControlEdge.Bottom) > 0)//bottom edge
            {
                c.Cursor = Cursors.HSplit;
                edge = ControlEdge.Bottom;
                return true;
            }
            c.Cursor = Cursors.Default;
            edge = ControlEdge.None;
            return false;

        }

        private void Size_MouseLeave(object sender, EventArgs e)
        {
            var c = (Control)sender;
            m_Edge = ControlEdge.None;
            m_IsEdgeDrawn = false;
            c.Refresh();
        }

        #endregion

        /// <summary>
        /// Проставляет нужное текстовое свойство в зависимости от типа контрола
        /// </summary>
        /// <param name="control"></param>
        /// <param name="caption"></param>
        /// <param name="editedObject"> </param>
        public static void SetControlText(Control control, string caption, object editedObject = null)
        {
            var proxy = control as ControlDesignerProxy;
            if (proxy != null)
            {
                SetControlText(proxy.HostControl, caption, editedObject);
                return;
            }
            TranslationToolHelperWinClient.SetComponentText(editedObject ?? control, caption);


        }

        /// <summary>
        /// Возращает контрол в исходное состояние до редактирования
        /// </summary>
        public void Undo()
        {
            SetControlText(ProcessedControl, InitialText);
            ProcessedControl.Location = InitialLocation;
            ProcessedControl.Size = InitialSize;
        }
    }

    public delegate void SaveHandler(object sender, EventArgs args);
    public delegate void ResizeHandler(object sender, EventArgs args);

}
