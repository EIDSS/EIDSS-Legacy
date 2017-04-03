using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers;

namespace EIDSS.FlexibleForms.DesignerHosting
{
    public partial class ParameterHost : XtraUserControl
    {
        private bool m_Designer = true;
        public bool Active { get; set; }

        /// <summary>
        /// Метод удаления данного компонента
        /// </summary>
        public virtual void Delete()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        internal DbService MainDbService { get; set; }

        /// <summary>
        /// Метод удаления данного компонента
        /// </summary>
        /// <param name="deleteLinkedData">Удалить связанные данные в таблице</param>
        public virtual void Delete(bool deleteLinkedData)
        {

        }

        /// <summary>
        /// Происходит ли сейчас загрузка/инициализация компонента
        /// </summary>
        public bool NowLoading { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal FFRender ParentRender { get; set; }

        /// <summary>
        /// Выставляет размеры контейнеру, куда помещён ParameterHost, а так же всем родительским контейнерам выше по иерархии.
        /// </summary>
        /// <param name="parameterHost"></param>
        private static void SetBestSize(Control parameterHost)
        {
            //функционал не применим к объекту, который положен прямо на хост-контрол 
            //и не имеет родителя
            var parentParameterHost = GetParentParameterHost(parameterHost);
            if (parentParameterHost == null) return;
            //проверяем, чтобы контрол влезал в родителя.
            //если не влезает, то увеличим родителя (и всех его родителей)
            if (parentParameterHost.Width < parameterHost.Left + parameterHost.Width)
                parentParameterHost.Width = parameterHost.Left + parameterHost.Width;
            if (parentParameterHost.Height < parameterHost.Top + parameterHost.Height)
                parentParameterHost.Height = parameterHost.Top + parameterHost.Height;
            //проверим и родителя
            SetBestSize(parentParameterHost);
        }

        /// <summary>
        /// Выставляет размеры контейнеру, куда помещён ParameterHost, а так же всем родительским контейнерам выше по иерархии.
        /// </summary>
        public void SetBestSize()
        {
            SetBestSize(this);
        }

        /// <summary>
        /// Для указанного контрола находит и возвращает ближайший родительский ParameterHost.
        /// Если не находит такового, то возвращает null.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static ParameterHost GetParentParameterHost(Control control)
        {
            ParameterHost result = null;
            if (control.Parent is ParameterHost)
                result = (ParameterHost)control.Parent;
            else if (control.Parent != null)
                result = GetParentParameterHost(control.Parent);

            return result;
        }

        /// <summary>
        /// Для указанного контрола находит и возвращает ближайший родительский DesignerHost.
        /// Если не находит такового, то возвращает null.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static DesignerHost GetParentDesignerHost(Control control)
        {
            DesignerHost result = null;
            if (control.Parent is DesignerHost)
                result = (DesignerHost)control.Parent;
            else if (control.Parent != null)
                result = GetParentDesignerHost(control.Parent);

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        public ParameterHost()
        {
            InitializeComponent();
            //TopLevel = false;
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            DoubleBuffered = true;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        /// <summary>
        /// Находится ли компонент в режиме редактирования
        /// </summary>
        public virtual bool IsDesignMode
        {
            set
            {
                m_Designer = value;
                Invalidate();
                if (OnDesignModeChanged != null) OnDesignModeChanged();
            }
            get { return m_Designer; }
        }

        /// <summary>
        /// Делегат для определения изменения свойства IsDesignMode
        /// </summary>
        public delegate void DesignModeChangedHandler();

        /// <summary>
        /// Событие в ответ на изменение свойства IsDesignMode
        /// </summary>
        public event DesignModeChangedHandler OnDesignModeChanged;

        /// <summary>
        /// 
        /// </summary>
        public virtual void DoResize()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        public virtual void Add(Control child)
        {
            var ph = child as ParameterHost;
            if (ph != null) ph.IsDesignMode = IsDesignMode;
            Controls.Add(child);
        }

        /// <summary>
        /// Возвращает верхний контрол
        /// </summary>
        /// <returns></returns>
        public virtual Control TopControl()
        {
            return this; 
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0084 && m_Designer) //WM_NCHITTEST
            {
                Point p = PointToClient(new Point(m.LParam.ToInt32()));
                m.Result = new IntPtr(GetHitTest(this, p));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int GetHitTest(Control ctl, Point p)
        {
            const int shift = 3;
            Size s = ctl.Size;
            if (p.X <= shift)
            {
                if (p.Y <= shift) return 13; //HTTOPLEFT
                if (p.Y >= s.Height - shift) return 16; //HTBOTTOMLEFT
                if (p.Y > shift) return 10; //HTLEFT
            }
            if (p.X >= s.Width - shift)
            {
                if (p.Y <= shift) return 14; //HTTOPRIGHT
                if (p.Y >= s.Height - shift) return 17; //HTBOTTOMRIGHT
                if (p.Y > shift) return 11; //HTRIGHT
            }
            if (p.Y <= shift) return 12; //HTTOP
            if (p.Y >= s.Height - shift) return 15; //HTBOTTOM
            return 1; //HTCLIENT
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnParameterHostPaint(object sender, PaintEventArgs e)
        {
            if (!m_Designer) return;
            Rectangle r = ClientRectangle;
            if (Active)
            {
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
            else
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, r);
                //Rectangle inner = r;
                //inner.Inflate(-3, -3);
                //ControlPaint.DrawSelectionFrame(e.Graphics, false, r, inner, Color.White);
            }
        }

        /// <summary>
        /// Возвращает настоящую Top-координату контрола
        /// </summary>
        public int TopReal
        {
            get
            {
                var result = Top;
                var parentPH = GetParentParameterHost(this);
                if (parentPH != null)
                {
                    result = Top;// -parentPH.DisplayRectangle.Top;
                }
                else
                {
                    DesignerHost designerHost = GetParentDesignerHost(this);
                    
                    result = Top;
                    if (designerHost != null) result = Top - (designerHost.DisplayRectangle.Top - designerHost.DisplayRectangleTopStart);  
                }

                if (result < 0) result = 0;

                return result;
            }
        }

        /// <summary>
        /// Возвращает настоящую Left-координату контрола
        /// </summary>
        public int LeftReal
        {
            get
            {
                int result = Left;
                ParameterHost parentPH = GetParentParameterHost(this);
                if (parentPH != null)
                {
                    result = Left;// -parentPH.DisplayRectangle.Left;
                }
                else
                {
                    DesignerHost designerHost = GetParentDesignerHost(this);
                    if (designerHost != null) result = Left - designerHost.DisplayRectangle.Left;
                }
                if (result < 0) result = 0;

                return result;
            }
        }

/*
        private void ParameterHost_Move(object sender, EventArgs e)
        {
            Control parent=this.Parent;
            while (parent != null)
            {
                if(parent is IDesignerObject)
                {
                    ((IDesignerObject)parent).DoResize();

                    //((ParameterHost)parent).OnResize(e);
                
                    //Section section = (parent as Section);
                    //if (section != null) 
                    //    section.SectionSizeChanged(null, null);
                    break;
                }
                parent = parent.Parent;
            }
        }
*/

        internal virtual bool IsManagedControl(Control ctl)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selected"></param>
        internal virtual void ShowSelected(bool selected)
        {
            Active=selected;
            if (Active && (OnSelect != null)) OnSelect(this);
            if (!Active && (OnUnSelect != null)) OnUnSelect(this);
            Invalidate();
        }

        /// <summary>
        /// Делегат для обработки события выбора компонента
        /// </summary>
        public delegate void SelectHandler(ParameterHost parameterHost);

        /// <summary>
        /// Событие, когда выбран компонент
        /// </summary>
        public event SelectHandler OnSelect;

        /// <summary>
        /// Событие, когда компонент перестаёт быть выбранным
        /// </summary>
        public event SelectHandler OnUnSelect;

        /// <summary>
        /// 
        /// </summary>
        public class Comparer : IComparer<ParameterHost>
        {
            public int Compare(ParameterHost x, ParameterHost y)
            {
                var result = x.TopReal - y.TopReal;
                if (result == 0) result = x.LeftReal - y.LeftReal;
                return result;
            }
        }
    }
}