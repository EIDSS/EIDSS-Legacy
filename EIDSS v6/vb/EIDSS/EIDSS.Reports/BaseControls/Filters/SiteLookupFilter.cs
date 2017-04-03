using System;
using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class SiteLookupFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (SiteLookupFilter));

        public SiteLookupFilter()
        {
            InitializeComponent();
        }

        protected override string KeyColumnName
        {
            get { return "idfsSite"; }
        }

        protected override string ValueColumnName
        {
            get { return "strSiteName"; }
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

            DataView dataSource = LookupCache.Get(LookupTables.Site);
            if (dataSource == null)
            {
                throw new ApplicationException("Site Lookup is not filled");
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