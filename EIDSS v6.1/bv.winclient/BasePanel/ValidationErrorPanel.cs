using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.common.Resources;
using bv.winclient.Core;

namespace bv.winclient.BasePanel
{
    public partial class ValidationErrorPanel : BvXtraUserControl
    {
        public ValidationErrorPanel()
        {
            InitializeComponent();
            lbErrorText.Text = BvMessages.Get("msgInvalidObject");
        }
        public static ValidationErrorPanel Show(Control parent)
        {
            var panel = new ValidationErrorPanel
                {
                    Parent = parent,
                    Dock = DockStyle.Fill
                };
            panel.Visible = true;
            panel.BringToFront();
            return panel;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }
        

    }

}
