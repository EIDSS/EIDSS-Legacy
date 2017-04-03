using System.Collections.Generic;
using System.ComponentModel;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public sealed partial class Journal60BKeeper : BaseIntervalKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (Journal60BKeeper));

        public Journal60BKeeper() : this(new Dictionary<string, string>())
        {
        }

        public Journal60BKeeper(Dictionary<string, string> parameters)
            : base(typeof (Journal60BReport), parameters)
        {
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

            var report = new Journal60BReport();
            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            journal60Filter.DefineBinding();
            m_Resources.ApplyResources(journal60Filter, "journal60Filter");
        }

        private void journal60Filter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            ReloadReportIfFormLoaded(journal60Filter);
        }
    }
}