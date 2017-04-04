using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using eidss.model.Resources;
using ItemCheckEventArgs = DevExpress.XtraEditors.Controls.ItemCheckEventArgs;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class CounterMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (CounterMultiFilter));
        private static readonly string[] m_Counter = {"cbCounter0", "cbCounter1", "cbCounter2", "cbCounter3"};

        private bool m_AjustCounterIndexes;

        public CounterMultiFilter()
        {
            InitializeComponent();
            ItemCheck += CounterFilter_ItemCheck;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caption
        {
            get { return lblcheckedComboBoxName.Text; }
            set { lblcheckedComboBoxName.Text = value; }
        }

        protected override string KeyColumnName
        {
            get { return "key"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override DataView CreateDataSource()
        {
            var table = new DataTable("Table");
            var column = new DataColumn("key", typeof (long));
            table.Columns.Add(column);
            column = new DataColumn("name", typeof (string));
            table.Columns.Add(column);

            for (int index = 0; index < m_Counter.Length; index++)
            {
                string itemName = EidssMessages.Instance.GetString(m_Counter[index]);
                if (String.IsNullOrEmpty(itemName))
                {
                    itemName = m_Counter[index];
                }

                DataRow row = table.NewRow();
                row["key"] = index + 1;
                row["name"] = itemName;
                table.Rows.Add(row);
            }

            table.AcceptChanges();
            var view = new DataView(table) {Sort = "key asc"};

            return view;
        }

        public void SetCounter(int counter)
        {
            var item = GetCheckedListBoxItems().FirstOrDefault(i => i.Value is long && counter == (long) i.Value);
            if (item != null)
            {
                item.CheckState = CheckState.Checked;
            }
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }

        private void CounterFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var listBox = sender as CheckedListBoxControl;
            if (listBox != null && !m_AjustCounterIndexes && e.Index!=0)
            {
                try
                {
                    m_AjustCounterIndexes = true;
                    var indexes = listBox.CheckedIndices.Cast<int>().ToList();
                    foreach (int index in indexes)
                    {
                        if (index != e.Index && index != 0)
                        {
                            listBox.SetItemChecked(index, false);
                        }
                    }
                }
                finally
                {
                    m_AjustCounterIndexes = false;
                }
            }
        }
    }
}