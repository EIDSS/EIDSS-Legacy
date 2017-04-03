using System.ComponentModel;
using System.Windows.Forms;
using bv.winclient.BasePanel;
using bv.winclient.Core;

namespace EIDSS.Reports.BaseControls.Form
{
    internal partial class ReportForm : BvForm, IReportForm
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ReportForm));

        public ReportForm()
        {
            InitializeComponent();
        }

        public void ShowReport(Control reportKeeper)
        {
            reportKeeper.Dock = DockStyle.Fill;
            Controls.Add(reportKeeper);
            if (Application.OpenForms.Count == 0)
            {
                ShowDialog();
            }
            else
            {
                object id = null;
                BaseFormManager.ShowNormal(this, ref id);
            }
        }

        public void ApplyResources()
        {
            Text = m_Resources.GetString("$this.Text");
        }

        public override bool IsSingleTone
        {
            get { return false; }
        }
    }
}