using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace eidss.winclient.FlexForms.Controls
{
    public partial class DesignerHost : bv.winclient.Core.BvXtraUserControl
    {
        public DesignerHost()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public void Add(Control ctl)
        {
            ctl.Visible = true;
            Controls.Add(ctl);
            ctl.BringToFront();
        }
    }
}
