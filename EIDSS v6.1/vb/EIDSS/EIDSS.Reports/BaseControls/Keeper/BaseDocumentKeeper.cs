using System;
using System.Collections.Generic;
using EIDSS.Reports.BaseControls.Report;
using bv.common.Core;
using bv.model.BLToolkit;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public sealed partial class BaseDocumentKeeper : BaseReportKeeper
    {
        public BaseDocumentKeeper(Type reportType, Dictionary<string, string> parameters)
            : base(parameters)
        {
            Utils.CheckNotNull(reportType, "reportType");
            if (!(typeof(BaseDocumentReport)).IsAssignableFrom(reportType))
            {
                throw new ApplicationException("Report Type should be child of BaseDocumentReport");
            }

            ReportType = reportType;
            ReloadReportOnLanguageChanged = true;

            InitializeComponent();

            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var report = ((BaseDocumentReport)CreateReportObject());
            report.SetParameters(CurrentCulture.ShortName, m_Parameters, manager, archiveManager);
            return report;
        }
    }
}