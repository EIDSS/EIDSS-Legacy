using System;
using System.ComponentModel;
using System.Data;
using bv.common.db;
using bv.common.db.Core;
using bv.winclient.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class CaseReportTypeLookupFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (CaseReportTypeLookupFilter));

        public CaseReportTypeLookupFilter()
        {
            InitializeComponent();
        }

        protected override string KeyColumnName
        {
            get { return "idfsReference"; }
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

            DataView dataSource = LookupCache.Get(BaseReferenceType.rftCaseReportType);
            if (dataSource == null)
            {
                throw new ApplicationException("Vet Case Type Lookup is not filled");
            }
            return dataSource;

        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }
    }
}