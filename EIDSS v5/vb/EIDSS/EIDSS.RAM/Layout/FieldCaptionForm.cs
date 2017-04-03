using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EIDSS.RAM.Presenters;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Resources;

namespace EIDSS.RAM.Layout
{
    public partial class FieldCaptionForm : XtraForm
    {
        public FieldCaptionForm()
        {
            InitializeComponent();
        }

        public FieldCaptionForm(string originalEng, string originalNational, string newEng, string newNat)
        {
            InitializeComponent();

            InitCaptionControls(originalEng, originalNational, newEng, newNat);
        }

        public string NewEnglishCaption
        {
            get { return NewEnglishText.Text; }
        }

        public string NewNationalCaption
        {
            get { return NewNationalText.Text; }
        }

        private void InitCaptionControls(string originalEng, string originalNational, string newEng, string newNat)
        {
            OriginalEnglishText.Text = originalEng;
            OriginalNationalText.Text = originalNational;

            NewEnglishText.Text = newEng;
            NewNationalText.Text = newNat;

            LayoutCorrector.SetStyleController(NewNationalText, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(NewEnglishText, LayoutCorrector.MandatoryStyleController);

            bool isNotEn = (ModelUserContext.CurrentLanguage != Localizer.lngEn);

            OriginalNationalText.Visible = isNotEn;
            NewNationalText.Visible = isNotEn;
            OriginalNationalLabel.Visible = isNotEn;
            NewNationalLabel.Visible = isNotEn;

            OriginalNationalLabel.Text = PivotPresenter.AppendLanguageNameTo(OriginalNationalLabel.Text);
            NewNationalLabel.Text = PivotPresenter.AppendLanguageNameTo(NewNationalLabel.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string messageFormat = EidssMessages.Get("msgAvrMandatoryFieldWarning", "{0} is mandatory");
            if (Utils.IsEmpty(NewEnglishText.Text))
            {
                DialogResult = DialogResult.None;
                MessageForm.Show(string.Format(messageFormat, NewEnglishLabel.Text));
            }
            else if (Utils.IsEmpty(NewNationalText.Text) && ModelUserContext.CurrentLanguage != Localizer.lngEn)
            {
                DialogResult = DialogResult.None;
                MessageForm.Show(string.Format(messageFormat, NewNationalLabel.Text));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }
    }
}