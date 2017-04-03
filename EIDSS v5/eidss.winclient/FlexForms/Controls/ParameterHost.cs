using System.Windows.Forms;
using DevExpress.XtraEditors;
using eidss.winclient.FlexForms.Helpers;

namespace eidss.winclient.FlexForms.Controls
{
    public partial class ParameterHost : XtraUserControl
    {
        public ParameterHost()
        {
            InitializeComponent();
            //DoubleBuffered = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        public virtual void Add(Control child)
        {
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
    }
}
