using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using bv.winclient.Layout;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class BaseMultilineFilter : BaseFilter
    {
        /// <summary>
        ///     Fires immediately after lookup edit value has been changed
        /// </summary>
        public event EventHandler<MultiFilterEventArgs> ValueChanged;

        private MatrixType m_MatrixType = MatrixType.None;

        public BaseMultilineFilter()
        {
            InitializeComponent();
//            if (WinUtils.IsComponentInDesignMode(this))
//                return;
            //DefineBinding();
        }

        protected override string KeyColumnName
        {
            get { return "idfsReference"; }
        }

        protected override string ValueColumnName
        {
            get { return "strName"; }
        }

        [Browsable(true)]
        public MatrixType Matrix
        {
            get { return m_MatrixType; }
            set { m_MatrixType = value; }
        }

        /// <summary>
        ///     Set Filter Mandatory
        /// </summary>
        public void SetMandatory()
        {
            LayoutCorrector.SetStyleController(checkedComboBox, LayoutCorrector.MandatoryStyleController);
        }

        /// <summary>
        ///     Bind Datasouce to the Lookup Control and Customize Filter
        /// </summary>
        public override void DefineBinding()
        {
            checkedComboBox.SuspendLayout();
            checkedComboBox.Properties.BeginUpdate();

            ResetDataSource();

            checkedComboBox.Properties.DataSource = DataSource;
            checkedComboBox.Properties.DisplayMember = ValueColumnName;
            checkedComboBox.Properties.ValueMember = KeyColumnName;

            ApplyResources();

            IEnumerable<CheckedListBoxItem> items = checkedComboBox.Properties.Items.Cast<CheckedListBoxItem>();
            Dictionary<long, CheckState> checkState = items.ToDictionary(item => (long) item.Value, item => item.CheckState);
            checkedComboBox.RefreshEditValue();

            foreach (KeyValuePair<long, CheckState> state in checkState)
            {
                items = checkedComboBox.Properties.Items.Cast<CheckedListBoxItem>();
                CheckedListBoxItem foundItem = items.FirstOrDefault(item => (long) item.Value == state.Key);
                if (foundItem != null)
                {
                    foundItem.CheckState = state.Value;
                }
            }

            checkedComboBox.Properties.EndUpdate();
            checkedComboBox.ResumeLayout();
            checkedComboBox_EditValueChanged(this, EventArgs.Empty);
        }

        private void checkedComboBox_EditValueChanged(object sender, EventArgs e)
        {
            IDictionary<long, string> dictionary = new Dictionary<long, string>();

            foreach (CheckedListBoxItem item in checkedComboBox.Properties.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    dictionary.Add((long) item.Value, item.Description);
                }
            }

            EventHandler<MultiFilterEventArgs> tmpHandler = ValueChanged;
            if (tmpHandler != null)
            {
                var args = new MultiFilterEventArgs(dictionary);
                tmpHandler(sender, args);
            }
        }
    }
}