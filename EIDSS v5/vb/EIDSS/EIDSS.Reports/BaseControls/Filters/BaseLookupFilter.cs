using System;
using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using bv.common.Core;
using bv.winclient.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class BaseLookupFilter : BaseFilter
    {
        /// <summary>
        ///   Fires immediately after lookup edit value has been changed
        /// </summary>
        public event EventHandler<SingleFilterEventArgs> ValueChanged;

        private bool m_IsClear;

        public BaseLookupFilter()
        {
            InitializeComponent();
//            if (WinUtils.IsComponentInDesignMode(this))
//                return;
//            DefineBinding();
        }

        /// <summary>
        ///   Returns Editor Value. If Value is null, returns -1;
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long EditValueId
        {
            get
            {
                long id;
                return long.TryParse(Utils.Str(LookUp.EditValue), out id) ? id : -1;
            }
            set { LookUp.EditValue = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object EditValue
        {
            get { return LookUp.EditValue; }
            set { LookUp.EditValue = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ItemIndex
        {
            get { return LookUp.ItemIndex; }
            set { LookUp.ItemIndex = value; }
        }

        public int Count
        {
            get { return DataSource.Count; }
        }

        public string SelectedText
        {
            get { return LookUp.Text; }
        }

        /// <summary>
        ///   Caption of the Lookup Control
        /// </summary>
        [Browsable(false)]
        protected virtual string LookupCaption
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return string.Empty;
                }
                throw new InvalidOperationException("Property  should be overrided in child class.");
            }
        }

        /// <summary>
        ///   Set Filter Mandatory
        /// </summary>
        public void SetMandatory()
        {
            SetLookupMandatory(LookUp);
        }

        public override void DefineBinding()
        {
            LookUp.SuspendLayout();
            LookUp.Properties.Columns.Clear();
            LookUp.Properties.Columns.Add(new LookUpColumnInfo(ValueColumnName,
                                                               LookupCaption,
                                                               200, FormatType.None, "", true, HorzAlignment.Near));
            LookUp.Properties.PopupWidth = LookUp.Width;

            object oldValue = LookUp.EditValue;
            string oldFilter = DataSource.RowFilter;
            ResetDataSource();
            LookUp.Properties.DataSource = DataSource;
            DataSource.RowFilter = oldFilter;

            LookUp.Properties.DisplayMember = ValueColumnName;
            LookUp.Properties.ValueMember = KeyColumnName;

            LookUp.EditValue = oldValue;
            ApplyResources();
            LookUp.ResumeLayout();
        }

        private void LookupEditValueChanged(object sender, EventArgs e)
        {
            string value = Utils.Str(LookUp.GetColumnValue(ValueColumnName));
            EventHandler<SingleFilterEventArgs> tmpHandler = ValueChanged;
            if (tmpHandler != null)
            {
                tmpHandler(sender, new SingleFilterEventArgs(EditValueId, value, m_IsClear));
            }
        }

        private void LookUp_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind != ButtonPredefines.Delete)
            {
                return;
            }
            m_IsClear = true;

            string filter = DataSource.RowFilter;
            LookUp.EditValue = null;
            DataSource.RowFilter = filter;

            m_IsClear = false;
        }
    }
}