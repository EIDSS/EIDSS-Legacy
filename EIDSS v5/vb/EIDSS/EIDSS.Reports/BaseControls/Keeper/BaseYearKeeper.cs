using System;
using System.Collections.Generic;
using System.ComponentModel;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using bv.winclient.Layout;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseYearKeeper : BaseReportKeeper
    {
        private readonly Type m_ReportType;
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
            m_ReportType = reportType;
            if (!(typeof (BaseYearReport)).IsAssignableFrom(reportType))
            {
                throw new ApplicationException("Report Type should be child of BaseYearReport");
            }

            InitializeComponent();
            LayoutCorrector.SetStyleController(spinEdit, LayoutCorrector.MandatoryStyleController);
            spinEdit.Value = DateTime.Now.Year;
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            object reportObject = Activator.CreateInstance(m_ReportType);
            var report = ((BaseYearReport) reportObject);

            var model = new BaseYearModel(CurrentCulture.ShortName, GetYearParam, UseArchive);
            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            try
            {
                IsResourceLoading = true;

                base.ApplyResources();

                m_Resources.ApplyResources(label1, "label1");
                // Note: do not load resources for spinEdit because it reset it's value
                //m_Resources.ApplyResources(spinEdit, "spinEdit");
                //  m_Resources.ApplyResources(this, "$this");
            }
            finally
            {
                IsResourceLoading = false;
            }
        }

        protected int GetYearParam
        {
            get { return (int) spinEdit.Value; }
        }

        private void spinEdit_EditValueChanged(object sender, EventArgs e)
        {
            ReloadReportIfFormLoaded(spinEdit);
        }
    }
}