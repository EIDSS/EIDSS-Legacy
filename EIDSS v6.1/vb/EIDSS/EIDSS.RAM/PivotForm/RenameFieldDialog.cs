using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using eidss.model.Resources;

namespace eidss.avr.PivotForm
{
    public partial class RenameFieldDialog : BvForm
    {
        public RenameFieldDialog()
        {
            InitializeComponent();
            RtlHelper.SetRTL(this, true);
        }

        public RenameFieldDialog(string originalEng, string originalNational, string newEng, string newNat)
        {
            InitializeComponent();

            InitCaptionControls(originalEng, originalNational, newEng, newNat);
            RtlHelper.SetRTL(this, true);
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

            OriginalNationalLabel.Text = PivotDetailPresenter.AppendLanguageNameTo(OriginalNationalLabel.Text);
            NewNationalLabel.Text = PivotDetailPresenter.AppendLanguageNameTo(NewNationalLabel.Text);
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