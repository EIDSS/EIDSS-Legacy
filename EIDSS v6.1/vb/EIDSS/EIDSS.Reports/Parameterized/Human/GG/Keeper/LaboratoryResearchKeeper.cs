using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public partial class LaboratoryResearchKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (LaboratoryResearchKeeper));
        private List<ItemWrapper> m_ReportSourceCollection;
        private List<ItemWrapper> m_ReportConditionCollection;

        public LaboratoryResearchKeeper()
        {
            ReportType = typeof (LaboratoryResearchReport);
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                LayoutCorrector.SetStyleController(ReportSourceLookUp, LayoutCorrector.MandatoryStyleController);
                LayoutCorrector.SetStyleController(RegistrationNumberTextEdit, LayoutCorrector.MandatoryStyleController);
                LayoutCorrector.SetStyleController(ResultRecipientTextEdit, LayoutCorrector.MandatoryStyleController);
                BindLookup(ReportSourceLookUp, ReportSourceCollection, ReportSourceLabel.Text);
                BindLookup(ReportConditionLookUp, ReportConditionCollection, ReportConditionLabel.Text);
                WinUtils.RemoveClearButton(ReportConditionLookUp);
                ReportSourceLookUp_EditValueChanged(this, EventArgs.Empty);
            }
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            string caseId = IsCaseSelected ? CaseIdTextEdit.Text : null;
            string sessionId = IsSessionSelected ? SessionIdTextEdit.Text : null;

            var model = new VetLaboratoryResearchResultModel(CurrentCulture.ShortName,
                caseId,
                sessionId,
                RegistrationNumberTextEdit.Text,
                ReportConditionLookUp.Text,
                ResultRecipientTextEdit.Text,
                UseArchive);
            var report = (LaboratoryResearchReport) CreateReportObject();
            report.SetParameters( model,manager,archiveManager);

            return report;
        }

        [Browsable(false)]
        protected List<ItemWrapper> ReportSourceCollection
        {
            get { return m_ReportSourceCollection ?? (m_ReportSourceCollection = FilterHelper.GetWinReportSourceList()); }
        }

        [Browsable(false)]
        protected List<ItemWrapper> ReportConditionCollection
        {
            get { return m_ReportConditionCollection ?? (m_ReportConditionCollection = FilterHelper.GetWinReportConditionList()); }
        }

        [Browsable(false)]
        protected int? ReportSourceParam
        {
            get
            {
                return (ReportSourceLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) ReportSourceLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected int? ReportConditionParam
        {
            get
            {
                return (ReportConditionLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) ReportConditionLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        private bool IsCaseSelected
        {
            get { return ReportSourceParam == 1; }
        }

        [Browsable(false)]
        private bool IsSessionSelected
        {
            get { return ReportSourceParam == 2; }
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            m_Resources.ApplyResources(ReportSourceLabel, "ReportSourceLabel");
            m_Resources.ApplyResources(CaseIdLabel, "CaseIdLabel");
            m_Resources.ApplyResources(SessionIdLabel, "SessionIdLabel");
            m_Resources.ApplyResources(RegistrationNumberLabel, "RegistrationNumberLabel");
            m_Resources.ApplyResources(ResultRecipientLabel, "ResultRecipientLabel");

            m_Resources.ApplyResources(ReportSourceLookUp, "ReportSourceLookUp");
            ApplyLookupResources(ReportSourceLookUp, ReportSourceCollection, ReportSourceParam, ReportSourceLabel.Text);
            ApplyLookupResources(ReportConditionLookUp, ReportConditionCollection, ReportConditionParam, ReportConditionLabel.Text);
        }

        private void ReportSourceLookUp_EditValueChanged(object sender, EventArgs e)
        {
            CaseIdLabel.Enabled = IsCaseSelected;
            CaseIdTextEdit.Enabled = IsCaseSelected;
            LayoutCorrector.SetStyleController(CaseIdTextEdit,
                IsCaseSelected ? LayoutCorrector.MandatoryStyleController : LayoutCorrector.ReadOnlyStyleController);

            SessionIdLabel.Enabled = IsSessionSelected;
            SessionIdTextEdit.Enabled = IsSessionSelected;
            LayoutCorrector.SetStyleController(SessionIdTextEdit,
                IsSessionSelected ? LayoutCorrector.MandatoryStyleController : LayoutCorrector.ReadOnlyStyleController);
        }
    }
}