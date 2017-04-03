using System.Collections.Generic;
using bv.model.BLToolkit;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public sealed partial class Journal60BKeeper : BaseIntervalKeeper
    {
        public Journal60BKeeper() : this(new Dictionary<string, string>())
        {
        }

        public Journal60BKeeper(Dictionary<string, string> parameters)
            : base(typeof (Journal60BReport), parameters)
        {
            ReportType = typeof (Journal60BReport);
            InitializeComponent();
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var model = new Hum60BJournalModel(CurrentCulture.ShortName,
                StartDateTruncated, EndDateTruncated, UseArchive);

            if (journal60Filter.EditValueId > 0)
            {
                model.Diagnosis = journal60Filter.EditValueId;
            }

            var report = (Journal60BReport) CreateReportObject();
            report.SetParameters(manager, model);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            journal60Filter.DefineBinding();
        }
    }
}