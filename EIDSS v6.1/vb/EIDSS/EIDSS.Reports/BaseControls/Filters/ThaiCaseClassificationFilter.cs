using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class ThaiCaseClassificationFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ThaiCaseClassificationFilter));

        public ThaiCaseClassificationFilter()
        {
            InitializeComponent();
        }

        protected override string KeyColumnName
        {
            get { return "idfsCaseClassification"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override string LookupCaption
        {
            get { return EidssMessages.Get("tabTitleCaseClassification", "Case Classification"); }
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }

            DataView view = LookupCache.Get(LookupTables.ThaiCaseClassification);
            view.RowFilter = @"blnIsHuman = 1 and (blnInitialHumanCaseClassification = 1 or blnFinalHumanCaseClassification = 1)";
            view.Sort = "name";
            return view;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }
    }
}