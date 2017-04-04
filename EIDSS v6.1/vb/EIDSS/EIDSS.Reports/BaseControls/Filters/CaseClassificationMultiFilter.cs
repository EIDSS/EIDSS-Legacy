using System.ComponentModel;
using System.Data;
using bv.common.db;
using bv.common.db.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class CaseClassificationMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (CaseClassificationMultiFilter));

        public CaseClassificationMultiFilter() : this((int) HACode.Human)
        {
        }

        public CaseClassificationMultiFilter(int haCode)
        {
            InitializeComponent();
            SetMandatory();
            intHACode = haCode;
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
            DataView view = LookupCache.Get(BaseReferenceType.rftCaseClassification, intHACode);
            if (!view.Table.Rows.Contains(0))
            {
                DataRowView emptyRow = view.AddNew();
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int intHACode { get; set; }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }
    }
}