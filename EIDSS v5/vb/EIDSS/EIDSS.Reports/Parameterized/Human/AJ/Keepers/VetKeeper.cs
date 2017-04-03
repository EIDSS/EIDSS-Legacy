using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.OperationContext;
using EIDSS.Reports.Parameterized.Filters;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using bv.model.BLToolkit;
using bv.winclient.Layout;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class VetKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetKeeper));

        private List<ItemWrapper> m_MonthCollection;

        internal VetKeeper()
            : base(new Dictionary<string, string>())
        {
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                LayoutCorrector.SetStyleController(FromYearSpinEdit, LayoutCorrector.MandatoryStyleController);
                LayoutCorrector.SetStyleController(ToYearSpinEdit, LayoutCorrector.MandatoryStyleController);

                BindLookup(FromMonthLookup, MonthCollection, FromMonthLabel.Text);
                FromMonthLookup.EditValue = MonthCollection[DateTime.Now.Month - 1];
                BindLookup(ToMonthLookup, MonthCollection, ToMonthLabel.Text);
                ToMonthLookup.EditValue = MonthCollection[DateTime.Now.Month - 1];
            }
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFirstLoading))
            {
                FiltersHelper.SetDefaultFiltes(manager, ContextKeeper, regionFilter, rayonFilter);
            }

            var report = new VetCaseReport();
            var model = new VetCasesSurrogateModel(CurrentCulture.ShortName,
                                                   RegionID, RayonID, regionFilter.SelectedText, rayonFilter.SelectedText,
                                                   OrganizationID, organizationFilter.SelectedText,
                                                   FromYearParam, ToYearParam, FromMonthParam, ToMonthParam,
                                                   UseArchive);
            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            try
            {
                IsResourceLoading = true;
                m_MonthCollection = null;

                m_HasLoad = false;

                base.ApplyResources();

                m_Resources.ApplyResources(FromMonthLookup, "FromMonthLookup");
                m_Resources.ApplyResources(ToMonthLookup, "ToMonthLookup");
                // Note: do not load resources for spinEdit because it reset it's value
                //m_Resources.ApplyResources(FromYearSpinEdit, "FromYearSpinEdit");
                //m_Resources.ApplyResources(ToYearSpinEdit, "ToYearSpinEdit");
                m_Resources.ApplyResources(FromMonthLabel, "FromMonthLabel");
                m_Resources.ApplyResources(ToMonthLabel, "ToMonthLabel");
                m_Resources.ApplyResources(FromYearLabel, "FromYearLabel");
                m_Resources.ApplyResources(ToYearLabel, "ToYearLabel");

                ApplyLookupResources(FromMonthLookup, MonthCollection, FromMonthParam, FromMonthLabel.Text);
                ApplyLookupResources(ToMonthLookup, MonthCollection, ToMonthParam, ToMonthLabel.Text);

                regionFilter.DefineBinding();
                rayonFilter.DefineBinding();
                organizationFilter.DefineBinding();
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        #region Properties

        [Browsable(false)]
        protected long? RegionID
        {
            get { return regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null; }
        }

        [Browsable(false)]
        protected long? RayonID
        {
            get { return rayonFilter.RayonId > 0 ? (long?) rayonFilter.RayonId : null; }
        }

        [Browsable(false)]
        protected long? OrganizationID
        {
            get { return organizationFilter.EditValueId > 0 ? (long?) organizationFilter.EditValueId : null; }
        }

        [Browsable(false)]
        protected int FromYearParam
        {
            get { return (int) FromYearSpinEdit.Value; }
        }

        [Browsable(false)]
        protected int ToYearParam
        {
            get { return (int) ToYearSpinEdit.Value; }
        }

        [Browsable(false)]
        protected int? FromMonthParam
        {
            get
            {
                return (FromMonthLookup.EditValue == null)
                           ? (int?) null
                           : ((ItemWrapper) FromMonthLookup.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected int? ToMonthParam
        {
            get
            {
                return (ToMonthLookup.EditValue == null)
                           ? (int?) null
                           : ((ItemWrapper) ToMonthLookup.EditValue).Number;
            }
        }

        private List<ItemWrapper> MonthCollection
        {
            get { return m_MonthCollection ?? (m_MonthCollection = BaseDateKeeper.CreateMonthCollection()); }
        }

        #endregion

        private void CorrectYearRange()
        {
            if (ToYearParam < FromYearParam)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    ToYearSpinEdit.EditValue = FromYearSpinEdit.EditValue;
                }
            }
        }

        private void CorrectMonthRange()
        {
            if (FromYearParam == ToYearParam &&
                ToMonthParam.HasValue && FromMonthParam.HasValue &&
                ToMonthParam.Value < FromMonthParam.Value)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    ToMonthLookup.EditValue = FromMonthLookup.EditValue;
                }
            }
        }

        private void YearSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            CorrectYearRange();
            CorrectMonthRange();
            ReloadReportIfFormLoaded(sender as Control);
        }

        private void MonthLookup_EditValueChanged(object sender, EventArgs e)
        {
            CorrectMonthRange();
            ReloadReportIfFormLoaded(sender as Control);
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                FiltersHelper.RegionFilterValueChanged(this, regionFilter, rayonFilter, e);
            }
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                FiltersHelper.RayonFilterValueChanged(this, regionFilter, rayonFilter, e);
            }
        }

        private void MonthLookup_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete && sender is LookUpEdit)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    FromMonthLookup.EditValue = null;
                    ToMonthLookup.EditValue = null;
                }
                ReloadReportIfFormLoaded((LookUpEdit) sender);
            }
        }

        private void organizationFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            ReloadReportIfFormLoaded(sender as Control);
        }
    }
}