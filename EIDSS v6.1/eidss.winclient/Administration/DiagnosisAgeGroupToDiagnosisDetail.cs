using System;
using System.Collections.Generic;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class DiagnosisAgeGroupToDiagnosisDetail : BaseGroupPanel_DiagnosisAgeGroupToDiagnosis
    {
        public DiagnosisAgeGroupToDiagnosisDetail()
        {
            InitializeComponent();
            Field2LookupMap = new Dictionary<string, string> { { "idfsDiagnosisAgeGroup", "StatisticalAgeGroupLookup" } };
        }
        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            var column = Grid.GridView.Columns.ColumnByName("idfsDiagnosisAgeGroup");
            if (column != null)
            {
                var lookup = DiagnosisAgeGroupLookup.Accessor.Instance(null).SelectLookupList(manager);
                LookupBinder.BindRepositoryLookup(column.SetLookupEditor(), lookup);
            }
            Grid.GridView.InitNewRow += InitMatrixRow;
            TopPanelVisible = false;
        }        
        private long? m_IdfsDiagnosis;

        /// <summary>
        /// 
        /// </summary>
        public long? IdfsDiagnosis
        {
            get { return m_IdfsDiagnosis; }
            set
            {
                m_IdfsDiagnosis = value;
                Refresh(DataSource,
                    m_IdfsDiagnosis.HasValue
                    ? String.Format("idfsDiagnosis={0}", m_IdfsDiagnosis)
                    : "idfsDiagnosis=-1");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitMatrixRow(object sender, InitNewRowEventArgs e)
        {
            var obj = Grid.GridView.GetRow(e.RowHandle);
            if (IdfsDiagnosis.HasValue)
                ((DiagnosisAgeGroupToDiagnosis)obj).idfsDiagnosis = IdfsDiagnosis.Value;

        }
        

    }
}
