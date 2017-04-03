using System;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using EIDSS;
using bv.winclient.Core;
using eidss.avr.PivotComponents;

namespace eidss.avr.FilterForm
{
    public partial class FilterDialog : BvForm
    {

        public FilterDialog()
        {
            InitializeComponent();
            filterControl.Appearance.Options.UseFont = true;
        }

        public FilterDialog(AvrPivotGrid pivotGrid, CriteriaOperator filterCriteria, HACode objectHACode)
        {
            InitializeComponent();
            filterControl.ObjectHACode = objectHACode;
            filterControl.InitPivotFilter(pivotGrid, true, filterCriteria);
            filterControl.Appearance.Options.UseFont = true;
        }

        public CriteriaOperator FilterCriteria
        {
            get { return filterControl.FilterCriteria; }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!filterControl.Validate())
            {
                DialogResult = DialogResult.None;
            }
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            filterControl.Validate();
        }

    }
}