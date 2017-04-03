using System;
using System.ComponentModel;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
using bv.winclient.Core;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.Properties;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using eidss.winclient.Reports;
using Localizer = bv.common.Core.Localizer;

namespace eidss.avr.PivotForm
{
    public partial class PivotInfoDetailPanel : BaseAvrDetailPresenterPanel, IPivotInfoDetailView
    {
        private bool m_HandlersAttached;
        private bool m_Changed;

        private bool m_CopyDefaultLayoutName;

        private PivotInfoPresenter m_PivotPresenter;

        #region constructor & disposer

        public PivotInfoDetailPanel()
        {
            try
            {
                InitializeComponent();

                if (IsDesignMode())
                {
                    return;
                }

                m_PivotPresenter = (PivotInfoPresenter) BaseAvrPresenter;

                DefLayoutNameTextEdit.Properties.Mask.MaskType = MaskType.RegEx;
                DefLayoutNameTextEdit.Properties.Mask.EditMask = Resources.PivotForm_PivotForm_LayoutNameEditMask;
                DefLayoutNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;

                if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
                {
                    int delta = Math.Abs(NationalLayoutNameTextEdit.Top - LayoutDescriptionMemo.Top);
                    LayoutDescriptionMemo.Top -= delta;
                    LayoutDescriptionLabel.Top -= delta;
                    LayoutDescriptionMemo.Height += delta;

                    NationalLayoutNameTextEdit.Visible = false;
                    LayoutNationalNameLabel.Visible = false;
                    NationalLayoutNameTextEdit.Tag = null;
                }

                LayoutNationalNameLabel.Text = PivotInfoPresenter.AppendLanguageNameTo(LayoutNationalNameLabel.Text);

                UseArchiveDataCheckEdit.Visible = ArchiveDataHelper.ShowUseArchiveDataCheckbox;
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (m_PivotPresenter != null)
                {
                    if (m_PivotPresenter.SharedPresenter != null)
                    {
                        m_PivotPresenter.SharedPresenter.UnregisterView(this);
                    }
                    m_PivotPresenter.Dispose();
                    m_PivotPresenter = null;
                }

                eventManager.ClearAllReferences();

                if (disposing && (components != null))
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #endregion

        #region Properties

        [Browsable(true)]
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                if (IsDesignMode())
                {
                    return;
                }

                base.ReadOnly = value;
                ShareLayoutCheckEdit.Enabled = !value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long LayoutId
        {
            get
            {
                return ((baseDataSet is LayoutDetailDataSet) && ((LayoutDetailDataSet) baseDataSet).Layout.Count > 0)
                    ? m_PivotPresenter.LayoutId
                    : m_PivotPresenter.SharedPresenter.SharedModel.SelectedLayoutId;
            }
        }

        public string CorrectedLayoutName
        {
            get { return m_PivotPresenter.CorrectedLayoutName; }
        }

        public void SetChanged(bool changed)
        {
            m_Changed = changed;
        }

        public override bool HasChanges()
        {
            return (m_Changed || base.HasChanges());
        }

        public void UpdateQueryRefreshDateTime()
        {
            DataRefreshTextEdit.Text = SharedPresenter.SharedModel.QueryRefreshDateTime.ToString();
        }

        #endregion

        #region Binding of  Controls

        protected override void DefineBinding()
        {
            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.DefineBinding))
            {
                m_CopyDefaultLayoutName = true;

                m_PivotPresenter.BindLayoutDescription(LayoutDescriptionMemo);
                m_PivotPresenter.BindNationalQueryName(NationalQueryNameTextEdit);
                m_PivotPresenter.BindQueryDescription(QueryDescriptionMemo);

                UpdateQueryRefreshDateTime();

                PublishValueLabel.Visible = m_PivotPresenter.ReadOnly;
                UnpublishValueLabel.Visible = !m_PivotPresenter.ReadOnly;

                m_PivotPresenter.BindShareLayout(ShareLayoutCheckEdit);
                m_PivotPresenter.BindUseArchive(UseArchiveDataCheckEdit);
             //   UseArchiveDataCheckEdit.Checked = m_PivotPresenter.SharedPresenter.SharedModel.UseArchiveData;

                m_PivotPresenter.BindDefaultLayoutName(DefLayoutNameTextEdit);
                DefLayoutNameTextEdit.Select();
                if (ModelUserContext.CurrentLanguage != Localizer.lngEn)
                {
                    m_PivotPresenter.BindNationalLayoutName(NationalLayoutNameTextEdit);
                }
                if (!m_HandlersAttached)
                {
                    m_HandlersAttached = true;
                    DefLayoutNameTextEdit.EditValueChanging += DefaultLayoutNameTextEdit_EditValueChanging;
                    DefLayoutNameTextEdit.EditValueChanged += DefaultLayoutNameTextEdit_EditValueChanged;
                }

                m_Changed = false;
            }
        }

        public override bool ValidateData()
        {
            return m_PivotPresenter.ValidateLayoutName() && base.ValidateData();
        }

        #endregion

        #region Handlers

        public void AddCopyPrefixForLayoutNames()
        {
            NationalLayoutNameTextEdit.Text =
                m_PivotPresenter.GetLayoutNameWithPrefix(NationalLayoutNameTextEdit.Text, ModelUserContext.CurrentLanguage);
            DefLayoutNameTextEdit.Text =
                m_PivotPresenter.GetLayoutNameWithPrefix(DefLayoutNameTextEdit.Text, Localizer.lngEn);
        }

        private void ShareLayoutCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (Utils.IsCalledFromUnitTest() ||
                ShareLayoutCheckEdit.Checked ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.Post))
            {
                return;
            }

            if (!ShareLayoutCheckEdit.Checked)
            {
                string msg = EidssMessages.Get("msgPrivateLayout",
                    "Are you sure you want to make layout private? Other users will not see it.");
                bool answer = PivotInfoPresenter.AskQuestion(msg, BvMessages.Get("Confirmation"));
                if (!answer)
                {
                    ShareLayoutCheckEdit.Checked = true;
                }
            }
        }

        private void UseArchiveDataCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding))
            {
                return;
            }
            
                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.RefreshDataWithoutChanges))
                {
                   
                    m_PivotPresenter.SharedPresenter.SharedModel.UseArchiveData = UseArchiveDataCheckEdit.Checked;
                    RaiseSendCommand(new QueryLayoutCommand(sender, QueryLayoutOperation.RefreshQuery));
                }
            
           
        }

        private void DefaultLayoutNameTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            m_CopyDefaultLayoutName = NationalLayoutNameTextEdit.Text == DefLayoutNameTextEdit.Text;
        }

        private void DefaultLayoutNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            ////Workaround to fix resetting of textbox
            m_PivotPresenter.SetDefaultLayoutName(DefLayoutNameTextEdit.Text);
            //
            if (m_CopyDefaultLayoutName && m_PivotPresenter.IsNewObject)
            {
                NationalLayoutNameTextEdit.Text = DefLayoutNameTextEdit.Text;
            }
        }

        private void NationalLayoutNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //Workaround to fix resetting of textbox
            m_PivotPresenter.SetLayoutName(NationalLayoutNameTextEdit.Text);
            //
            if (NationalLayoutNameTextEdit.Text != DefLayoutNameTextEdit.Text)
            {
                m_CopyDefaultLayoutName = false;
            }
        }

        #endregion
    }
}