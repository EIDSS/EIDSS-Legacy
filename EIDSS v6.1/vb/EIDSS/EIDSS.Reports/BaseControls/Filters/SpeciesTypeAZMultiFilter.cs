using System;
using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class SpeciesTypeAZMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (SpeciesTypeAZMultiFilter));

        public SpeciesTypeAZMultiFilter()
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public eidss.model.Enums.HACode Code { get; set; }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }
       
            DataView view = LookupCache.Get(LookupTables.SpeciesTypeAZ);
            if (view == null)
            {
                throw new ApplicationException("Species type Lookup is not filled");
            }
            int animalCode = (int) (Code & eidss.model.Enums.HACode.LivestockAvian);
            var filteredRows = view.Table.AsEnumerable().Where(r => r["intHACode"] is int && ((int) r["intHACode"] & animalCode) > 0);
            var filteredTable = view.Table.Clone();
            foreach (var row in filteredRows)
            {
                var newRow = filteredTable.NewRow();
                newRow[KeyColumnName] = row[KeyColumnName];
                newRow[ValueColumnName] = row[ValueColumnName];
                newRow["intHACode"] = row["intHACode"];
                newRow["intRowStatus"] = row["intRowStatus"];
                newRow["intOrder"] = row["intOrder"];
                filteredTable.Rows.Add(newRow);
            }

//            view = view.Table.AsEnumerable().Where(
//    r =>
//        (!(r["intRowStatus"] is int) || (int)r["intRowStatus"] != 1) &&
//        (r["intHACode"] is int && ((int)r["intHACode"] & animalCode) > 0))
//        .AsDataView();

            view = filteredTable.DefaultView;
            view.RowFilter = "intRowStatus <> 1";
            view.Sort = "intOrder, name";

            return view;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }
    }
}