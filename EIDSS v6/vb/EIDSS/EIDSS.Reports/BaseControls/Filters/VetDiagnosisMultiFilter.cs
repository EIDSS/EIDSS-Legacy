using System.ComponentModel;
using System.Data;
using bv.common.db.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class VetDiagnosisMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetDiagnosisMultiFilter));

        public VetDiagnosisMultiFilter()
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
            DataView view;
            if (intHACode == (int)HACode.Avian)
                view = LookupCache.Get(LookupTables.AvianStandardDiagnosis);
            else if (intHACode == (int)HACode.Livestock)
                view = LookupCache.Get(LookupTables.LivestockStandardDiagnosis);
            else
                view = LookupCache.Get(LookupTables.VetStandardDiagnosis);
            view.RowFilter = "intRowStatus <> 1";
            view.Sort = "name";
            return view;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int intHACode { get; set; }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }
    }
}