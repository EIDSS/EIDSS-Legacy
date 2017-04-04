using System;
using System.Collections.Generic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class Diagnosis2DiagnosisGroupDetail : BaseGroupPanel_Diagnosis2DiagnosisGroup
    {
        /// <summary>
        /// 
        /// </summary>
        public Diagnosis2DiagnosisGroupDetail()
        {
            InitializeComponent();
            Field2LookupMap = new Dictionary<string, string> {{"idfsDiagnosis", "DiagnosisLookup"}};
        }

        //public override object GetRowLookupForColumn(string columnName, IObject obj)
        //{
        //    if (columnName == "idfsDiagnosis")
        //    {
        //        return ((Diagnosis2DiagnosisGroup)obj).DiagnosisLookup;
        //    }
        //    return null;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dummyObjectWithLookups"></param>
        /// <param name="manager"></param>
        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            var column = Grid.GridView.Columns.ColumnByName("idfsDiagnosis");
            if (column != null)
            {
                var diagnosisLookup = DiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager);
                LookupBinder.BindDiagnosisRepositoryLookup(column.SetLookupEditor(), diagnosisLookup, HACode.All, "name", false, true, true);
            }

            Grid.GridView.InitNewRow += InitMatrixRow;
            TopPanelVisible = false;
        }

        private long? m_IdfsDiagnosisGroup;

        /// <summary>
        /// 
        /// </summary>
        public long? idfsDiagnosisGroup
        {
            get { return m_IdfsDiagnosisGroup; }
            set
            {
                m_IdfsDiagnosisGroup = value;
                Refresh(DataSource,
                    m_IdfsDiagnosisGroup.HasValue
                    ? String.Format("idfsDiagnosisGroup={0}", m_IdfsDiagnosisGroup)
                    : "idfsDiagnosisGroup=-1");
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
            if (idfsDiagnosisGroup.HasValue)
                ((Diagnosis2DiagnosisGroup)obj).idfsDiagnosisGroup = idfsDiagnosisGroup.Value;
        }
    }
}
