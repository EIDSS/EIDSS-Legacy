using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bv.winclient.Layout;
using DevExpress.XtraEditors.Controls;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class BaseMultilineFilter : BaseFilter
    {
        /// <summary>
        ///     Fires immediately after lookup edit value has been changed
        /// </summary>
        public event EventHandler<MultiFilterEventArgs> ValueChanged;

        public BaseMultilineFilter()
        {
            InitializeComponent();
        }

        protected override string KeyColumnName
        {
            get { return "idfsReference"; }
        }

        protected override string ValueColumnName
        {
            get { return "strName"; }
        }

        public object EditValue
        {
            get { return checkedComboBox.EditValue; }
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

            IEnumerable<CheckedListBoxItem> items = GetCheckedListBoxItems();
            Dictionary<long, CheckState> checkState = items.ToDictionary(item => (long) item.Value, item => item.CheckState);
            checkedComboBox.RefreshEditValue();

            foreach (KeyValuePair<long, CheckState> state in checkState)
            {
                List<CheckedListBoxItem> checkedListBoxItems = GetCheckedListBoxItems().ToList();
                items = checkedListBoxItems;
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

        protected void RefreshEditValue()
        {
            checkedComboBox.RefreshEditValue();
        }

        protected IEnumerable<CheckedListBoxItem> GetCheckedListBoxItems()
        {
            return checkedComboBox.Properties.Items.Cast<CheckedListBoxItem>();
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