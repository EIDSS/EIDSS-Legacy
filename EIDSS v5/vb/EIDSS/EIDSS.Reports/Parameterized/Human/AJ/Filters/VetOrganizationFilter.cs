using System;
using System.ComponentModel;
using System.Data;
using EIDSS.Reports.BaseControls.Filters;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Human.AJ.Filters
{
    public partial class VetOrganizationFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetOrganizationFilter));

        public VetOrganizationFilter()
        {
            InitializeComponent();
            ReportType = VetReportType.Case;
        }

        [Browsable(true)]
        [DefaultValue(VetReportType.Case)]
        public VetReportType ReportType { get; set; }

        protected override string KeyColumnName
        {
            get { return "idfInstitution"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override string LookupCaption
        {
            get { return lblLookupName.Text; }
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }

            DataView dataSource = LookupCache.Get(LookupTables.RepVetOrganization);
            if (dataSource == null)
            {
                throw new ApplicationException("Vet Organization Lookup is not filled");
            }
            dataSource.RowFilter = string.Format("intRowStatus <> 1 AND strReportType like '%{0}%'", (long) ReportType);
            return dataSource;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            m_Resources.ApplyResources(lblLookupName, "lblLookupName");
            m_Resources.ApplyResources(lblLabName, "lblLabName");
            if (ReportType == VetReportType.Lab)
            {
                lblLookupName.Text = lblLabName.Text;
            }
            m_Resources.ApplyResources(this, "$this");
        }
    }
}