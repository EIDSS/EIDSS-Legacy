using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using bv.common.Core;
using bv.winclient.Layout;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ItemCheckEventArgs = DevExpress.XtraEditors.Controls.ItemCheckEventArgs;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class BaseMultilineFilter : BaseFilter
    {
        /// <summary>
        ///     Fires when lookup edit value is going to be changed
        /// </summary>
        public event EventHandler<ChangingEventArgs> ValueChanging;

        /// <summary>
        ///     Fires immediately after lookup edit value has been changed
        /// </summary>
        public event EventHandler<MultiFilterEventArgs> ValueChanged;

        /// <summary>
        ///     Fires when lookup item check state is going to be changed
        /// </summary>
        public event EventHandler<ItemCheckingEventArgs> ItemChecking;

        /// <summary>
        ///     Fires immediately after lookup item check state has been changed
        /// </summary>
        public event EventHandler<ItemCheckEventArgs> ItemCheck;

        private bool m_IsSubscribed;

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

         [Browsable(false)]
         [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectAllItemVisible
        {
            get { return checkedComboBox.Properties.SelectAllItemVisible; }
            set {  checkedComboBox.Properties.SelectAllItemVisible = value; }
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

        private void checkedComboBox_EditValueChanging(object sender, ChangingEventArgs e)
        {
            ValueChanging.SafeRaise(sender, e);

            if (e.Cancel)
            {
                RefreshEditValue();
            }
        }

        private void checkedComboBox_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            if (!m_IsSubscribed && popupControl != null)
            {
                var listBox = FindListBox(popupControl.PopupWindow);
                if (listBox != null)
                {
                    listBox.ItemChecking += checkedComboBox_ItemChecking;
                    listBox.ItemCheck += checkedComboBox_ItemCheck;
                    m_IsSubscribed = true;
                }
            }
        }

        private void checkedComboBox_ItemChecking(object sender, ItemCheckingEventArgs e)
        {
            ItemChecking.SafeRaise(sender, e);
        }

        private void checkedComboBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ItemCheck.SafeRaise(sender, e);
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

            var args = new MultiFilterEventArgs(dictionary);
            ValueChanged.SafeRaise(sender, args);
        }

        private CheckedListBoxControl FindListBox(Control parent)
        {
            if (parent != null)
            {
                foreach (Control child in parent.Controls)
                {
                    var listBox = child as CheckedListBoxControl;
                    if (listBox != null)
                    {
                        return listBox;
                    }
                    listBox = FindListBox(child);
                    if (listBox != null)
                    {
                        return listBox;
                    }
                }
            }
            return null;
        }
    }
}