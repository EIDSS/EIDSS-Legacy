using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseSampleKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (BaseSampleKeeper));
        private readonly SampleReportModelType m_ModelType;

        public BaseSampleKeeper(Type reportType, SampleReportModelType modelType)
            : this(reportType, new Dictionary<string, string>())
        {
            m_ModelType = modelType;
            if (m_ModelType != SampleReportModelType.HumanLabSampleModel)
            {
                tbFirstName.Hide();
                lblFirstName.Hide();
                tbLastName.Hide();
                lblLastName.Hide();
            }
        }

        public BaseSampleKeeper(Type reportType, Dictionary<string, string> parameters)
            : base(parameters)
        {
            Utils.CheckNotNull(reportType, "reportType");
            if (!(typeof (BaseSampleReport)).IsAssignableFrom(reportType))
            {
                throw new ApplicationException("Report Type should be child of BaseSampleReport");
            }

            ReportType = reportType;

            InitializeComponent();
            LayoutCorrector.SetStyleController(tbSampleId, LayoutCorrector.MandatoryStyleController);

            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var report = ((BaseSampleReport) CreateReportObject());

            switch (m_ModelType)
            {
                case SampleReportModelType.HumanLabSampleModel:
                    string firstName = string.IsNullOrEmpty(tbFirstName.Text) ? null : tbFirstName.Text;
                    string lastName = string.IsNullOrEmpty(tbLastName.Text) ? null : tbLastName.Text;
                    var humLabModel = new HumanLabSampleModel(CurrentCulture.ShortName, tbSampleId.Text, firstName, lastName, UseArchive);

                    report.SetParameters(humLabModel, manager, archiveManager);
                    break;
                case SampleReportModelType.VetLabSampleModel:
                    var sampleModel = new VetLabSampleModel(CurrentCulture.ShortName, tbSampleId.Text, UseArchive);

                    report.SetParameters(sampleModel, manager, archiveManager);
                    break;
            }
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            m_Resources.ApplyResources(lblCaseID, "lblCaseID");
            m_Resources.ApplyResources(lblSampleID, "lblSampleID");
            m_Resources.ApplyResources(lblFirstName, "lblFirstName");
            m_Resources.ApplyResources(lblLastName, "lblLastName");
        }
    }
}