using System.Collections.Generic;
using System.Windows.Forms;
using bv.model.Model.Core;
using eidss.winclient.Schema;

namespace eidss.winclient.VectorSurveillance
{
    public partial class CopyDialogWindow : BaseDetailPanel_CopyDialogWindowItem
    {
        public CopyDialogWindow()
        {
            InitializeComponent();
        }

        public DialogResult DialogResult { get; private set; }

        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            SetActionFunction(actions, "Ok", (m, o, l) => { DialogResult = DialogResult.OK; return true; });
            SetActionFunction(actions, "Cancel", (m, o, l) => { DialogResult = DialogResult.Cancel; return true; });
        }

        public bool IsNeedSpecificData { get { return cbSpecificData.Checked; } }
        public bool IsNeedSamples { get { return cbSamples.Checked; } }
        public bool IsNeedFieldTests { get { return cbFieldTests.Checked; } }

        private void cbFieldTests_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cbFieldTests.Checked) cbSamples.Checked = true;
        }

        private void cbSamples_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!cbSamples.Checked) cbFieldTests.Checked = false;
        }
    }
}
