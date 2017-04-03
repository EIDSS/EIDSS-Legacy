using System.ComponentModel;
using System.Data;
using bv.common.db.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class HumDiagnosisMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (HumDiagnosisMultiFilter));

        public HumDiagnosisMultiFilter()
        {
            InitializeComponent();
            SetMandatory();
        }

        protected override string KeyColumnName
        {
            get { return "idfsDiagnosis"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override DataView CreateDataSource()
        {
            DataView view = LookupCache.Get(LookupTables.HumanDiagnoses);
            view.RowFilter = "intRowStatus <> 1";
            view.Sort = "name";
            return view;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }
    }
}