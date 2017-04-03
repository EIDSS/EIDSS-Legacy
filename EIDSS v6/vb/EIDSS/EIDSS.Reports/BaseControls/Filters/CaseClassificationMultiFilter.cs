using System.ComponentModel;
using System.Data;
using bv.common.db;
using bv.common.db.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class CaseClassificationMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (CaseClassificationMultiFilter));
        private int m_HaCode;

        public CaseClassificationMultiFilter() : this((int) HACode.Human)
        {
        }

        public CaseClassificationMultiFilter(int haCode)
        {
            InitializeComponent();
            SetMandatory();
            m_HaCode = haCode;
        }

        protected override string KeyColumnName
        {
            get { return "idfsReference"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override DataView CreateDataSource()
        {
            DataView view = LookupCache.Get(BaseReferenceType.rftCaseClassification, m_HaCode);
            if (!view.Table.Rows.Contains(0))
            {
                var emptyRow = view.AddNew();
                emptyRow["idfsReference"] = 0;
                emptyRow["name"] = "<no classification>";
                emptyRow["intOrder"] = 0;
                emptyRow["intRowStatus"] = 0;
                emptyRow.EndEdit();
            }
            view.RowFilter = "intRowStatus <> 1";
            view.Sort = "intOrder";
            return view;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int intHACode { get { return m_HaCode; } set { m_HaCode = value; } }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }
    }
}