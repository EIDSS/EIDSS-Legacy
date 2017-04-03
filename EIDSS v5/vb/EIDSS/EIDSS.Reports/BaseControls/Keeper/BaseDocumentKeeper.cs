using System;
using System.Collections.Generic;
using EIDSS.Reports.BaseControls.Report;
using bv.common.Core;
using bv.model.BLToolkit;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public sealed partial class BaseDocumentKeeper : BaseReportKeeper
    {
        private readonly Type m_ReportType;

        public BaseDocumentKeeper(Type reportType, Dictionary<string, string> parameters)
            : base(parameters)
        {
            Utils.CheckNotNull(reportType, "reportType");

            m_ReportType = reportType;
            if (!(typeof (BaseDocumentReport)).IsAssignableFrom(reportType))
            {
                throw new ApplicationException("Report Type should be child of BaseDocumentReport");
            }

            InitializeComponent();

            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            object reportObject = Activator.CreateInstance(m_ReportType);
            var report = ((BaseDocumentReport) reportObject);
            report.SetParameters(manager, CurrentCulture.ShortName, m_Parameters);
            return report;
        }
    }
}