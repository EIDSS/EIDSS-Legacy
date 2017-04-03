using System;
using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Filters
{
    public partial class DataQualityDiseaseFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (DataQualityDiseaseFilter));

        public DataQualityDiseaseFilter()
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
            DataView view = LookupCache.Get(LookupTables.HumanStandardDiagnosis);
            view.RowFilter = "intRowStatus <> 1";
            view.Sort = "name";
            return view;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            m_Resources.ApplyResources(lblcheckedComboBoxName, "lblcheckedComboBoxName");
            m_Resources.ApplyResources(this, "$this");
        }
    }
}