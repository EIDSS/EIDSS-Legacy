using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.common.Resources;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class HumDiagnosisGroupsDiagnosesMultiFilter : GroupsMultiFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (HumDiagnosisGroupsDiagnosesMultiFilter));

        public HumDiagnosisGroupsDiagnosesMultiFilter()
        {
            InitializeComponent();
            ShowCheckBoxes = true;
        }

        protected override string KeyColumnName
        {
            get { return "idfsDiagnosisOrDiagnosisGroup"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override string ParentColumnName
        {
            get { return "idfsDiagnosisGroup"; }
        }

        protected override string SecondColumnName
        {
            get { return "strIDC10"; }
        }

        protected override string SecondColumnCaption
        {
            get { return EidssMessages.Get("colIDC10"); }
        }

        protected override string CheckedComboBoxName
        {
            get { return m_Resources.GetString("lblcheckedComboBoxName.Text"); }
        }

        protected override DataView CreateDataSource()
        {
            DataView view = LookupCache.Get(LookupTables.DiagnosesAndGroupsHuman);
            if (!view.Table.Rows.Contains(0))
            {
                view.Table.Rows.Add(0, -1, "(" + BvMessages.Get("strSelectAll_Id") + ")", "", "", 2, 0);
            }
            view.RowFilter = "intRowStatus <> 1";
            view.Sort = "blnGroup Desc, name";
            return view;
        }

    }
}