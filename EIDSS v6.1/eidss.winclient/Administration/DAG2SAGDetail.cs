using System;
using System.Collections.Generic;
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
    public partial class DAG2SAGDetail : BaseGroupPanel_DiagnosisAgeGroup2StatisticalAgeGroup
    {
        public DAG2SAGDetail()
        {
            InitializeComponent();
            Field2LookupMap = new Dictionary<string, string> { { "idfsStatisticalAgeGroup", "StatisticalAgeGroupLookup" } };
        }
        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            var column = Grid.GridView.Columns.ColumnByName("idfsStatisticalAgeGroup");
            if (column != null)
            {
                var lookup = BaseReference.Accessor.Instance(null).rftStatisticalAgeGroup_SelectList(manager);
                LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), lookup, true);
            }
            Grid.GridView.InitNewRow += InitMatrixRow;
            TopPanelVisible = false;
        }          
        private long? m_IdfsDiagnosisAgeGroup;

        /// <summary>
        /// 
        /// </summary>
        public long? IdfsDiagnosisAgeGroup
        {
            get { return m_IdfsDiagnosisAgeGroup; }
            set
            {
                m_IdfsDiagnosisAgeGroup = value;
                Refresh(DataSource,
                    m_IdfsDiagnosisAgeGroup.HasValue
                    ? String.Format("idfsDiagnosisAgeGroup={0}", m_IdfsDiagnosisAgeGroup)
                    : "idfsDiagnosisAgeGroup=-1");
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
            if (IdfsDiagnosisAgeGroup.HasValue)
                ((DiagnosisAgeGroup2StatisticalAgeGroup)obj).idfsDiagnosisAgeGroup = IdfsDiagnosisAgeGroup.Value;
        }
        

    }
}
