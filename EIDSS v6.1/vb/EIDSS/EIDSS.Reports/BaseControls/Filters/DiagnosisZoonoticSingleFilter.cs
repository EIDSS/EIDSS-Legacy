using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class DiagnosisZoonoticSingleFilter : HumSingleDiagnosisFilter
    {
        public DiagnosisZoonoticSingleFilter()
        {
            InitializeComponent();
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }

            DataView dataSource = LookupCache.Get(LookupTables.HumanVetDiagnoses);

            AdditionalFilter = "blnZoonotic=1";
            dataSource.RowFilter = string.IsNullOrEmpty(AdditionalFilter)
                ? "intRowStatus <> 1"
                : string.Format("(intRowStatus <> 1) AND({0})", AdditionalFilter);
            dataSource.Sort = ValueColumnName;
            return dataSource;
        }
    }
}