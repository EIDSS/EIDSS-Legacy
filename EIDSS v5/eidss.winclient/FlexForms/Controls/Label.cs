using System.Drawing;
using DevExpress.XtraEditors;

namespace eidss.winclient.FlexForms.Controls
{
    public partial class Label : ParameterHost
    {
        public Label()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public static int MinFontSize
        {
            get { return 8; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int MaxFontSize
        {
            get { return 28; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Size MaxLabelSize
        {
            get { return new Size(1000, 1000); }
        }
    }
}
