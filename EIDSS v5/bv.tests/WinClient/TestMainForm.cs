using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace bv.tests.WinClient
{
    public partial class TestMainForm : DevExpress.XtraEditors.XtraForm
    {
        public TestMainForm()
        {
            InitializeComponent();
        }
        public BarManager BarManager
        {
            get { return this.barManager1; }
        }
    }
 
}