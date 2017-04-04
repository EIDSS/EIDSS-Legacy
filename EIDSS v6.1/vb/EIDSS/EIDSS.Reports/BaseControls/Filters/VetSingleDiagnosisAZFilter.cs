using System;
using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class VetSingleDiagnosisAZFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetSingleDiagnosisAZFilter));

        public VetSingleDiagnosisAZFilter()
        {
            InitializeComponent();
            SurveillanceType = VetSummarySurveillanceType.ActiveSurveillanceIndex;
        }

        protected override string KeyColumnName
        {
            get { return "idfsDiagnosis"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override string LookupCaption
        {
            get { return lblLookupName.Text; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VetSummarySurveillanceType SurveillanceType { get; set; }

        [Browsable(false)]
        public eidss.model.Enums.HACode Code
        {
            get
            {
                if (EditValueId > 0)
                {
                    foreach (DataRowView row in DataSource)
                    {
                        if (row[KeyColumnName] is long && (long)row[KeyColumnName] == EditValueId)
                        {
                            var code = row["intHACode"];
                            if (code is int)
                            {
                                var intCode = (eidss.model.Enums.HACode)((int)code);
                                return intCode & eidss.model.Enums.HACode.LivestockAvian;
                            }
                        }
                    }
                }
                return eidss.model.Enums.HACode.None;
            }
        }

        protected override DataView CreateDataSource()
        {
            var view = CreateEmptyView();
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return view;
            }

            switch (SurveillanceType)
            {
                case VetSummarySurveillanceType.ActiveSurveillanceIndex:
                    view = LookupCache.Get(LookupTables.LivestockStandardDiagnosis);
                    break;
                case VetSummarySurveillanceType.PassiveSurveillanceIndex:
                    view = LookupCache.Get(LookupTables.VetStandardDiagnosis);
                    break;
                case VetSummarySurveillanceType.AggregateActionsIndex:
                    view = LookupCache.Get(LookupTables.VetAggregatedDiagnosis);
                    break;
            }
            if (view == null)
            {
                throw new ApplicationException("Diagnosis lookup is not filled");
            }

            view.Sort = ValueColumnName;
            view.RowFilter = "intRowStatus <> 1";
            return view;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }

        private DataView CreateEmptyView()
        {
            DataTable table = new DataTable();
            table.Columns.Add(KeyColumnName, typeof (long));
            table.Columns.Add(ValueColumnName, typeof (string));
            table.Columns.Add("intRowStatus", typeof (string));
            return table.DefaultView;
        }
    }
}