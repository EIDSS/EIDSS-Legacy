using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using bv.common.Core;
using bv.common.db.Core;
using bv.model.Model.Core;
using eidss.model.Core.CultureInfo;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class HumStandardDiagnosisAzSortMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (HumStandardDiagnosisAzSortMultiFilter));
        private const string OrderColumnName = "intOrder";
        private const string RowStatusFilter = "intRowStatus <> 1";

        public HumStandardDiagnosisAzSortMultiFilter()
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

        protected override DataView CreateDataSource()
        {
            return ModelUserContext.CurrentLanguage == Localizer.lngAzLat
                ? CreateAzDataSource()
                : CreateNonAzDataSource();
        }

        private DataView CreateAzDataSource()
        {
            DataView azView = LookupCache.Get(LookupTables.HumanStandardDiagnosis);

            azView.RowFilter = RowStatusFilter;
            azView.Sort = ValueColumnName;
            return azView;
        }

        private DataView CreateNonAzDataSource()
        {
            var diagnosisIdList = new List<long>();
            using (new CultureInfoTransaction(new CultureInfo("az-Latn-AZ")))
            {
                DataView azView = LookupCache.Get(LookupTables.HumanStandardDiagnosis);
                azView.RowFilter = RowStatusFilter;
                azView.Sort = ValueColumnName;
                foreach (DataRowView row in azView)
                {
                    diagnosisIdList.Add((long) row[KeyColumnName]);
                }
            }

            DataView currentCultureView = LookupCache.Get(LookupTables.HumanStandardDiagnosis);
            currentCultureView.RowFilter = RowStatusFilter;

            DataTable resultTable = currentCultureView.ToTable(false, KeyColumnName, ValueColumnName);
            resultTable.Columns.Add(new DataColumn(OrderColumnName, typeof (int)));
            foreach (DataRow row in resultTable.Rows)
            {
                int order = diagnosisIdList.IndexOf((long) row[KeyColumnName]);
                row[OrderColumnName] = order;
            }

            var resultView = new DataView(resultTable) {Sort = OrderColumnName};
            return resultView;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }
    }
}