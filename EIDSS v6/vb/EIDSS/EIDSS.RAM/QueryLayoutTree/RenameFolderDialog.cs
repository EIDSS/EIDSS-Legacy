using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using eidss.model.Resources;

namespace eidss.avr.QueryLayoutTree
{
    public partial class RenameFolderDialog : XtraForm
    {
        public RenameFolderDialog()
        {
            InitializeComponent();
        }

        public RenameFolderDialog(string originalEng, string originalNational)
        {
            InitializeComponent();

            InitCaptionControls(originalEng, originalNational);
        }

        public string EnglishName
        {
            get { return EnglishText.Text; }
        }

        public string NationalName
        {
            get { return NationalText.Text; }
        }

        public bool IsEnglish
        {
            get { return (ModelUserContext.CurrentLanguage == Localizer.lngEn); }
        }

        private void InitCaptionControls(string originalEng, string originalNational)
        {
            EnglishText.Text = originalEng;
            NationalText.Text = originalNational;

            NationalText.Enabled = !IsEnglish;

            LayoutCorrector.SetStyleController(NationalText, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(EnglishText, LayoutCorrector.MandatoryStyleController);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string messageFormat = EidssMessages.Get("msgAvrMandatoryFieldWarning", "{0} is mandatory");
            if (Utils.IsEmpty(EnglishText.Text))
            {
                DialogResult = DialogResult.None;
                MessageForm.Show(string.Format(messageFormat, EnglishLabel.Text));
            }
            else if (Utils.IsEmpty(NationalText.Text) && ModelUserContext.CurrentLanguage != Localizer.lngEn)
            {
                DialogResult = DialogResult.None;
                MessageForm.Show(string.Format(messageFormat, NationalLabel.Text));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        private void EnglishText_EditValueChanged(object sender, EventArgs e)
        {
            if (IsEnglish)
            {
                NationalText.Text = EnglishText.Text;
            }
        }

        private void EnglishText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsEnglish)
            {
                NationalText.Text = EnglishText.Text;
            }
        }
    }
}