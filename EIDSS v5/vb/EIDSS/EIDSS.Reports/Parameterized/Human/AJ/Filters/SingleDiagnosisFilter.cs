using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using EIDSS.Reports.BaseControls.Filters;
using bv.winclient.Core;

namespace EIDSS.Reports.Parameterized.Human.AJ.Filters
{
    public partial class SingleDiagnosisFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (SingleDiagnosisFilter));

        public SingleDiagnosisFilter()
        {
            InitializeComponent();
        }

        protected override string KeyColumnName
        {
            get { return "idfsDiagnosis"; }
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

            DataView dataSource = LookupCache.Get(LookupTables.HumanDiagnoses);
          dataSource.RowFilter = "intRowStatus <> 1";
            return dataSource;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            m_Resources.ApplyResources(lblLookupName, "lblLookupName");
            m_Resources.ApplyResources(this, "$this");
        }
    }
}