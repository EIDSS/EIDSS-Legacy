using System;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using EIDSS.RAM.Components;
using EIDSS.RAM.QueryBuilder;

namespace EIDSS.RAM.Layout
{
    public partial class FilterForm : XtraForm
    {
        private FilterControlHelper m_FilterControlHelper;

        public FilterForm()
        {
            InitializeComponent();
            m_FilterControlHelper = new FilterControlHelper(filterControl);
            filterControl.Appearance.Options.UseFont = true;
        }

        public FilterForm(RamPivotGrid pivotGrid, CriteriaOperator filterCriteria, long? queryId)
        {
            InitializeComponent();
            m_FilterControlHelper = new FilterControlHelper(filterControl, pivotGrid, true, filterCriteria);
            filterControl.Appearance.Options.UseFont = true;
        }

        public CriteriaOperator FilterCriteria
        {
            get { return filterControl.FilterCriteria; }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!m_FilterControlHelper.Validate())
            {
                DialogResult = DialogResult.None;
            }
        }

        public bool ApplyFilter
        {
            get { return chkApplyFilter.Checked; }
            set { chkApplyFilter.Checked = value; }
        }
    }
}