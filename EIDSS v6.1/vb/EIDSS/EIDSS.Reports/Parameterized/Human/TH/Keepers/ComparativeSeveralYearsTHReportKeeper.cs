using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using eidss.model.Reports.TH;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.TH.Reports;

namespace EIDSS.Reports.Parameterized.Human.TH.Keepers 
{
    public sealed partial class ComparativeSeveralYearsTHReportKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ComparativeSeveralYearsTHReportKeeper));
        private int m_YearFrom;
        private int m_YearTo;
        private bool m_IsThaiCulture;
        private string[] m_Diagnoses;
        private List<ItemWrapper> m_CounterCollection;

        public ComparativeSeveralYearsTHReportKeeper()
            : base(new Dictionary<string, string>())
        {
            ReportType = typeof (ComparativeSeveralYearsTHReport);
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                SetMandatory();

                DistrictFilter.DistrictVisibility = DistrictFilter.Visibility.ParentDistrictsOnly;

                m_YearFrom = DateTime.Now.Year - 1;
                m_YearTo = DateTime.Now.Year;
                ApplyYearResources();

                CounterLookUp.EditValue = CounterCollection[0];
                LayoutCorrector.SetStyleController(CounterLookUp, LayoutCorrector.MandatoryStyleController);
            }

            m_HasLoad = true;
        }

        #region Properties

        private int DeltaYear
        {
            get { return m_IsThaiCulture ? 543 : 0; }
        }

        private long? ProvinceIdParam
        {
            get { return ProvinceFilter.RegionId > 0 ? (long?) ProvinceFilter.RegionId : null; }
        }

        private long? DistrictIdParam
        {
            get { return DistrictFilter.DistrictId > 0 ? (long?) DistrictFilter.DistrictId : null; }
        }

        [Browsable(false)]
        private int CounterParam
        {
            get
            {
                return (CounterLookUp.EditValue == null)
                    ? -1
                    : ((ItemWrapper)CounterLookUp.EditValue).Number;
            }
        }

        private  List<ItemWrapper> CounterCollection
        {
            get { return m_CounterCollection ?? (m_CounterCollection = FilterHelper.GetWinCounterThaiList()); }
        }

        #endregion

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }
            var model = new ComparativeSeveralYearsTHSurrogateModel(CurrentCulture.ShortName,
                m_YearFrom, m_YearTo,
                m_Diagnoses,CounterParam,
                ProvinceIdParam, DistrictIdParam,
                ProvinceFilter.SelectedText, DistrictFilter.SelectedText,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);
            var reportTh = (ComparativeSeveralYearsTHReport) CreateReportObject();
            reportTh.SetParameters( model,manager,archiveManager);
            return reportTh;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                base.ApplyResources(manager);

                m_Resources.ApplyResources(FromLabel, "FromLabel");
                m_Resources.ApplyResources(ToLabel, "ToLabel");

                ApplyYearResources();

                DiagnosesFilter.DefineBinding();

                ProvinceFilter.DefineBinding();
                DistrictFilter.DefineBinding();
                ProvinceFilter.Caption = m_Resources.GetString("ProvinceLabel.Text");
                ApplyLookupResources(CounterLookUp, CounterCollection, CounterParam, CounterLabel.Text);

                if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
                {
                    LocationHelper.SetDefaultFilters(manager, ContextKeeper, ProvinceFilter, DistrictFilter);
                }
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        private void ApplyYearResources()
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                m_IsThaiCulture = ModelUserContext.CurrentLanguage == Localizer.lngThai;

                YearFromSpinEdit.Properties.MaxValue = DeltaYear + DateTime.Now.Year - 1;
                YearFromSpinEdit.Properties.MinValue = m_IsThaiCulture ? 2550 : 2000;
                YearFromSpinEdit.Value = m_YearFrom + DeltaYear;

                YearToSpinEdit.Properties.MaxValue = DeltaYear + DateTime.Now.Year;
                YearToSpinEdit.Properties.MinValue = m_IsThaiCulture ? 2551 : 2001;
                YearToSpinEdit.Value = m_YearTo + DeltaYear;
            }
        }

        private void SetMandatory()
        {
            LayoutCorrector.SetStyleController(YearFromSpinEdit, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(YearToSpinEdit, LayoutCorrector.MandatoryStyleController);
        }

        private void diagnosisFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_Diagnoses = e.KeyArray;
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(ProvinceFilter, DistrictFilter, e);
            }
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RayonFilterValueChanged(ProvinceFilter, DistrictFilter, e);
            }
        }

        private void seYear1_EditValueChanged(object sender, EventArgs e)
        {
            CorrectYearRange();
        }

        private void seYear2_EditValueChanged(object sender, EventArgs e)
        {
            CorrectYearRange();
        }

        private void CorrectYearRange()
        {
            if (!ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                if (YearToSpinEdit.Value <= YearFromSpinEdit.Value)
                {
                    if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
                    {
                        ErrorForm.ShowWarning("msgComparativeReportTHCorrectYear",
                            @"The Year selected in the ""To"" filter shall be greater than the Year selected in the ""From"" filter");
                    }
                    YearFromSpinEdit.Value = m_YearFrom + DeltaYear;
                    YearToSpinEdit.Value = m_YearTo + DeltaYear;
                }
                m_YearFrom = (int) YearFromSpinEdit.Value - DeltaYear;
                m_YearTo = (int) YearToSpinEdit.Value - DeltaYear;
            }
        }
    }
}