using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.model.Avr;
using eidss.model.Avr.Tree;
using eidss.model.Resources;

namespace eidss.avr.QueryLayoutTree
{
    public partial class RenameFolderDialog : BvForm
    {
        private readonly bool m_IsNewObject;
        private readonly AvrTreeSelectedElementEventArgs m_SelectedElement;

        public RenameFolderDialog()
        {
            InitializeComponent();
        }

        public RenameFolderDialog
            (string originalEng, string originalNational, AvrTreeSelectedElementEventArgs e, bool isReadOnly, bool isNewObject = false)
        {
            Utils.CheckNotNull(e, "e");

            m_SelectedElement = e;
            m_IsNewObject = isNewObject;

            InitializeComponent();
            InitCaptionControls(originalEng, originalNational, isReadOnly);
           
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

        private void InitCaptionControls(string originalEng, string originalNational, bool isReadOnly)
        {
            EnglishText.Text = originalEng;
            NationalText.Text = originalNational;

            EnglishText.Enabled = !isReadOnly;
            NationalText.Enabled = !isReadOnly && !IsEnglish;

            LayoutCorrector.SetStyleController(NationalText, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(EnglishText, LayoutCorrector.MandatoryStyleController);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string messageFormat = EidssMessages.Get("msgAvrMandatoryFieldWarning", "{0} is mandatory");
            bool isNational = ModelUserContext.CurrentLanguage != Localizer.lngEn;
            if (Utils.IsEmpty(EnglishText.Text))
            {
                DialogResult = DialogResult.None;
                MessageForm.Show(string.Format(messageFormat, EnglishLabel.Text));
            }
            else if (Utils.IsEmpty(NationalText.Text) && isNational)
            {
                DialogResult = DialogResult.None;
                MessageForm.Show(string.Format(messageFormat, NationalLabel.Text));
            }
            else
            {
                var folder = new AvrTreeElement(m_SelectedElement.ElementId ?? -1, null, null,
                    AvrTreeElementType.Folder,
                    m_SelectedElement.QueryId,
                    EnglishName,
                    NationalName, string.Empty, false);

                string message = AvrQueryLayoutTreeDbHelper.ValidateElementName(folder, m_IsNewObject);
                if (!string.IsNullOrEmpty(message))
                {
                    DialogResult = DialogResult.None;
                    MessageForm.Show(message);
                }
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