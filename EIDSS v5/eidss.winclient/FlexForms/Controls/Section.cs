using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace eidss.winclient.FlexForms.Controls
{
    public partial class Section : ParameterHost
    {
        internal LabelControl LabelControlCaption { get; set; }
        internal LabelControl LabelControl { get; set; }
        internal SplitterControl Splitter { get; set; }

        public Section()
        {
            InitializeComponent();

            //убираем splitter (для показа не нужен)
            Splitter.Visible = false;
        }

        /// <summary>
        /// Добавляем секцию или параметр
        /// </summary>
        /// <param name="child"></param>
        public override void Add(Control child)
        {
            TopControl().Controls.Add(child);
        }

        /// <summary>
        /// Выставляет заголовок секции
        /// </summary>
        public string Caption
        {
            get { return LabelControlCaption.Text; }
            set { LabelControlCaption.Text = value; }
        }

        /// <summary>
        /// Ссылка на родительскую секцию
        /// </summary>
        public Section ParentSection { get; set; }

        /// <summary>
        /// Выставляет высоту заголовка секции
        /// </summary>
        public int CaptionHeight
        {
            get { return LabelControlCaption.Height; }
            set { LabelControlCaption.Height = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control TopControl()
        {
            return LabelControl;
        }
    }
}
