using System;
using System.ComponentModel;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.KZ
{
    public sealed partial class InfectiousParasiticKZKeeper : BaseDateKeeper
    {
        private static readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (InfectiousParasiticKZKeeper));
        private bool m_SetMonthEndEqualToMonth;

        public InfectiousParasiticKZKeeper() : base(typeof (FormN1Report))
        {
            ReportType = typeof (InfectiousParasiticKZReport);
            InitializeComponent();
            SetCurrentStartMonth();
            m_HasLoad = true;
        }

        [Browsable(false)]
        private long? RegionIdParam
        {
            get { return regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null; }
        }

        [Browsable(false)]
        private long? RayonIdParam
        {
            get { return rayonFilter.RayonId > 0 ? (long?) rayonFilter.RayonId : null; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var model = new InfectiousParasiticKZSurrogateModel(CurrentCulture.ShortName,
                YearParam, StartMonthParam, EndMonthParam,
                RegionIdParam, RayonIdParam, regionFilter.SelectedText, rayonFilter.SelectedText,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            var report = (InfectiousParasiticKZReport) CreateReportObject();
            report.SetParameters( model,manager,archiveManager);
            return report;
        }

        protected override void cbMonth_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete && sender is LookUpEdit)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    if (sender == StartMonth)
                    {
                        StartMonth.EditValue = null;
                        EndMonth.EditValue = null;
                        EndMonth.Enabled = false;
                    }
                    if (sender == EndMonth)
                    {
                        EndMonth.EditValue = null;
                    }
                }
            }
        }

        protected override void cbMonth_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (Utils.IsEmpty(e.OldValue) && MonthEndFollowsMonth)
            {
                m_SetMonthEndEqualToMonth = true;
            }
        }

        protected override void cbMonth_EditValueChanged(object sender, EventArgs e)
        {
            if (m_SetMonthEndEqualToMonth)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    EndMonth.EditValue = StartMonth.EditValue;
                }
                m_SetMonthEndEqualToMonth = false;
            }
            CorrectMonthRange();

            EndMonth.Enabled = true;
        }

        protected override void cbMonthEnd_EditValueChanged(object sender, EventArgs e)
        {
            CorrectMonthRange();
        }

        private void CorrectMonthRange()
        {
            if ((EndMonth.EditValue != null) && (StartMonth.EditValue != null))
            {
                var startMonth = ((ItemWrapper) (StartMonth.EditValue));
                var endMonth = ((ItemWrapper) (EndMonth.EditValue));
                if (endMonth.Number < startMonth.Number)
                {
                    using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                    {
                        EndMonth.EditValue = StartMonth.EditValue;
                    }
                }
            }
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
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            CountryLabel.Text = m_Resources.GetString("CountryLabel.Text");
            CountryTextBox.Text = m_Resources.GetString("CountryTextBox.Text");

            regionFilter.DefineBinding();
            rayonFilter.DefineBinding();

            if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
            {
                LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
            }
        }
    }
}