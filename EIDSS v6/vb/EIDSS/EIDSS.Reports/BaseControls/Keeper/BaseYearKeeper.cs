using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.Layout;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseYearKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (BaseYearKeeper));

        // For design-time only
        internal BaseYearKeeper()
            : this(typeof (BaseYearReport), new Dictionary<string, string>())
        {
        }

        public BaseYearKeeper(Type reportType)
            : this(reportType, new Dictionary<string, string>())
        {
        }

        public BaseYearKeeper(Type reportType, Dictionary<string, string> parameters)
            : base(parameters)
        {
            Utils.CheckNotNull(reportType, "reportType");
            if (!(typeof (BaseYearReport)).IsAssignableFrom(reportType))
            {
                throw new ApplicationException("Report Type should be child of BaseYearReport");
            }

            ReportType = reportType;
            InitializeComponent();
            LayoutCorrector.SetStyleController(spinEdit, LayoutCorrector.MandatoryStyleController);
            spinEdit.Value = DateTime.Now.Year;
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var report = ((BaseYearReport) CreateReportObject());

            var model = new BaseYearModel(CurrentCulture.ShortName, YearParam, UseArchive);
            report.SetParameters(manager, model);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;

                base.ApplyResources(manager);

                label1.Text = m_Resources.GetString("label1.Text");
                // Note: do not load resources for spinEdit because it reset it's value
                //m_Resources.ApplyResources(spinEdit, "spinEdit");
                //  m_Resources.ApplyResources(this, "$this");
            }
            finally
            {
                IsResourceLoading = false;
            }
        }

        protected int YearParam
        {
            get { return (int) spinEdit.Value; }
        }

        protected virtual void OnBeforeYearChange()
        {
        }

        protected int MaxYear
        {
            get { return (int) spinEdit.Properties.MaxValue; }
            set { spinEdit.Properties.MaxValue = value; }
        }

        protected int MinYear
        {
            get { return (int) spinEdit.Properties.MinValue; }
            set { spinEdit.Properties.MinValue = value; }
        }

        private void spinEdit_EditValueChanged(object sender, EventArgs e)
        {
            OnBeforeYearChange();
        }
    }
}