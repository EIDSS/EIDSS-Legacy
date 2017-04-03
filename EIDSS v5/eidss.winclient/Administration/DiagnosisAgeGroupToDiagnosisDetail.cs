using System;
using DevExpress.XtraGrid.Views.Grid;
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
            if (WinUtils.IsComponentInDesignMode(this)) return;
            
            Grid.GridView.InitNewRow += InitMatrixRow;
            TopPanelVisible = false;

            var dagd = BusinessObject as DiagnosisAgeGroupToDiagnosis;
            if (dagd == null) return;

            var acc = DiagnosisAgeGroupToDiagnosis.Accessor.Instance(null);

            using (var manager = CreateDbManagerProxy())
            {
                var matrix = acc.CreateNewT(manager, null);

                var column = Grid.GridView.Columns.ColumnByName("idfsDiagnosisAgeGroup");
                if (column != null)
                    LookupBinder.BindDiagnosisAgeGroupLookup(column.SetLookupEditor(), dagd, "idfsDiagnosisAgeGroup", matrix.DiagnosisAgeGroupLookup);
            }
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
