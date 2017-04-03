using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.winclient.Core;
using eidss.model.Import;
using eidss.model.Resources;
using System.Threading;

namespace eidss.winclient.Administration
{
    public partial class StatisticAbort : BvForm
    {
        public StatisticAbort()
        {
            InitializeComponent();
        }

        private StatisticHelper m_Helper;
        public StatisticAbort(StatisticHelper helper)
        {
            InitializeComponent();
            m_Helper = helper;
            m_Helper.ImportCompleted += ImportCompeted;
            Thread thread = new Thread(m_Helper.DoImport);
            thread.Start();
            DialogResult = DialogResult.OK;
        }

        private delegate void VoidDelegate();
        private void ImportCompeted(object sender, EventArgs e)
        {
            m_Helper.ImportCompleted -= ImportCompeted;
            if (InvokeRequired)
                BeginInvoke(new VoidDelegate(Close));
            else
                Close();
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            if(WinUtils.ConfirmMessage(EidssMessages.Get("msgAbortImport", "The import of data will be stopped. No data will be imported. Continue?"),
                        EidssMessages.Get("titleAbortImport", "Abort")))
            {
                DialogResult = DialogResult.Abort;
                m_Helper.BreakImport();
            }
        }
    }
}
