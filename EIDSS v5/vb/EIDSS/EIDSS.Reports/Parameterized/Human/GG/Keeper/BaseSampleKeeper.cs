using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public partial class BaseSampleKeeper : BaseReportKeeper
    {
        private readonly Type m_ReportType;
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (BaseSampleKeeper));

        public BaseSampleKeeper(Type reportType) : this(reportType, new Dictionary<string, string>())
        {
        }

        public BaseSampleKeeper(Type reportType, Dictionary<string, string> parameters)
            : base(parameters)
        {
            Utils.CheckNotNull(reportType, "reportType");

            m_ReportType = reportType;
            if (!(typeof (BaseSampleReport)).IsAssignableFrom(reportType))
            {
                throw new ApplicationException("Report Type should be child of BaseSampleReport");
            }

            InitializeComponent();
            LayoutCorrector.SetStyleController(tbSampleId, LayoutCorrector.MandatoryStyleController);

            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            object reportObject = Activator.CreateInstance(m_ReportType);
            var report = ((BaseSampleReport) reportObject);

            string firstName = string.IsNullOrEmpty(tbFirstName.Text) ? null : tbFirstName.Text;
            string lastName = string.IsNullOrEmpty(tbLastName.Text) ? null : tbLastName.Text;
            var model = new LabSampleModel(CurrentCulture.ShortName, tbSampleId.Text, firstName, lastName, UseArchive);

            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            m_Resources.ApplyResources(lblSampleID, "lblSampleID");
            m_Resources.ApplyResources(lblFirstName, "lblFirstName");
            m_Resources.ApplyResources(lblLastName, "lblLastName");
        }

        private void Filter_Validated(object sender, EventArgs e)
        {
            ReloadReportIfFormLoaded();
        }

        private void Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               ReloadReportIfFormLoaded();
            }
        }

       
    }
}