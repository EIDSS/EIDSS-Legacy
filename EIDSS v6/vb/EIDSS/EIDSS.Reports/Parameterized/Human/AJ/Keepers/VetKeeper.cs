using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using eidss.winclient.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class VetKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetKeeper));

        private List<ItemWrapper> m_MonthCollection;

        internal VetKeeper(VetReportType vetReportType)
            : base(new Dictionary<string, string>())
        {
            switch (vetReportType)
            {
                case VetReportType.Case:
                    ReportType = typeof (VetCaseReport);
                    break;
                case VetReportType.FormVet1:
                    ReportType = typeof (FormVet1);
                    break;
                case VetReportType.FormVet1A:
                    ReportType = typeof (FormVet1A);
                    break;
                default:
                    throw new ApplicationException(string.Format("Not supported report type : {0}", vetReportType));
            }
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                LayoutCorrector.SetStyleController(FromYearSpinEdit, LayoutCorrector.MandatoryStyleController);
                LayoutCorrector.SetStyleController(ToYearSpinEdit, LayoutCorrector.MandatoryStyleController);

                FromYearSpinEdit.Value = DateTime.Now.Year;
                ToYearSpinEdit.Value = DateTime.Now.Year;

                BindLookup(FromMonthLookup, MonthCollection, FromMonthLabel.Text);
                FromMonthLookup.EditValue = MonthCollection[DateTime.Now.Month - 1];

                BindLookup(ToMonthLookup, MonthCollection, ToMonthLabel.Text);
                ToMonthLookup.EditValue = MonthCollection[DateTime.Now.Month - 1];
            }
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var model = new VetCasesSurrogateModel(CurrentCulture.ShortName,
                RegionID, RayonID, regionFilter.SelectedText, rayonFilter.SelectedText,
                OrganizationID, organizationFilter.SelectedText,
                FromYearParam, ToYearParam, FromMonthParam, ToMonthParam,
                UseArchive);

            dynamic vetCaseReport = CreateReportObject();
            vetCaseReport.SetParameters(manager, model);
            return (BaseReport) vetCaseReport;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_MonthCollection = null;

                m_HasLoad = false;

                base.ApplyResources(manager);

                //m_Resources.ApplyResources(FromMonthLookup, "FromMonthLookup");
                //m_Resources.ApplyResources(ToMonthLookup, "ToMonthLookup");
                m_Resources.ApplyResources(FromMonthLabel, "FromMonthLabel");
                m_Resources.ApplyResources(ToMonthLabel, "ToMonthLabel");
                m_Resources.ApplyResources(FromYearLabel, "FromYearLabel");
                m_Resources.ApplyResources(ToYearLabel, "ToYearLabel");
                //m_Resources.ApplyResources(FromYearSpinEdit, "FromYearSpinEdit");
                //m_Resources.ApplyResources(ToYearSpinEdit, "ToYearSpinEdit");

                ApplyLookupResources(FromMonthLookup, MonthCollection, FromMonthParam, FromMonthLabel.Text);
                ApplyLookupResources(ToMonthLookup, MonthCollection, ToMonthParam, ToMonthLabel.Text);

                regionFilter.DefineBinding();
                rayonFilter.DefineBinding();
                organizationFilter.DefineBinding();

                if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
                {
                    LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
                }
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
            get { return m_MonthCollection ?? (m_MonthCollection = FilterHelper.GetWinMonthList()); }
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
        }

        private void MonthLookup_EditValueChanged(object sender, EventArgs e)
        {
            CorrectMonthRange();
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
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
                LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
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
            }
        }
    }
}