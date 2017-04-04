using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class NameOfInvestigationOrMeasureAZFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (NameOfInvestigationOrMeasureAZFilter));

        public NameOfInvestigationOrMeasureAZFilter()
        {
            InitializeComponent();
        }


        protected override string KeyColumnName
        {
            get { return "idfsReference"; }
        }

        protected override string ValueColumnName
        {
            get { return "strName"; }
        }

        protected override string LookupCaption
        {
            get { return m_Resources.GetString("lblLookupName.Text"); }
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }

            var dataSource = LookupCache.Get(LookupTables.NameOfInvestigationOrMeasure);
            dataSource.Sort = "intOrder, strName";
            return dataSource;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }
    }
}