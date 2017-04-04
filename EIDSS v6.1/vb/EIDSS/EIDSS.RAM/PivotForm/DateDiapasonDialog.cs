using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using eidss.model.Resources;

namespace eidss.avr.PivotForm
{
    public partial class DateDiapasonDialog : BvForm
    {
        public DateDiapasonDialog()
        {
            InitializeComponent();
        }

        public DateDiapasonDialog(DateTime? dateFrom, DateTime? dateTo)
        {
            InitializeComponent();

            if (dateFrom.HasValue)
            {
                DateFrom = dateFrom.Value;
            }
            if (dateTo.HasValue)
            {
                DateTo = dateTo.Value;
            }

            LayoutCorrector.SetStyleController(DateFromEdit, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(DateToEdit, LayoutCorrector.MandatoryStyleController);
        }

        public DateTime DateFrom
        {
            get { return DateFromEdit.DateTime; }
            private set { DateFromEdit.DateTime = value; }
        }

        public DateTime DateTo
        {
            get { return DateToEdit.DateTime; }
            private set { DateToEdit.DateTime = value; }
        }

        private void DateFromTo_EditValueChanged(object sender, EventArgs e)
        {
            if (DateFrom > DateTime.MinValue && DateTo > DateTime.MinValue)
            {
                if (DateTo < DateFrom)
                {
                    DateTo = DateFrom;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Utils.IsEmpty(DateFromEdit.Text) || Utils.IsEmpty(DateToEdit.Text))
            {
                DialogResult = DialogResult.None;
                string message = EidssMessages.Get("msgAvrDateMandatoryFieldWarning",
                    "Date From and Date To are mandatory fields.");
                MessageForm.Show(message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }
    }
}