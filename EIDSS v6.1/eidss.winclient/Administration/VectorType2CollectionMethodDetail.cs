using System;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class VectorType2CollectionMethodDetail : BaseGroupPanel_VectorType2CollectionMethod
    {
        public VectorType2CollectionMethodDetail()
        {
            InitializeComponent();
        }

        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            var matrix = dummyObjectWithLookups as VectorType2CollectionMethod;
            if (matrix == null)
                return;
            var column = Grid.GridView.Columns.ColumnByName("idfsCollectionMethod");
            if (column != null)
                LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), matrix.CollectionMethodLookup, true);
            Grid.GridView.InitNewRow += InitMatrixRow;
            TopPanelVisible = false;
        }

        private long? m_IdfsVectorType;

        /// <summary>
        /// 
        /// </summary>
        public long? idfsVectorType
        {
            get { return m_IdfsVectorType; }
            set
            {
                m_IdfsVectorType = value;
                Refresh(DataSource,
                    m_IdfsVectorType.HasValue
                    ? String.Format("idfsVectorType={0}", m_IdfsVectorType)
                    : "idfsVectorType=-1");
            }
        }
        private void InitMatrixRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var obj = Grid.GridView.GetRow(e.RowHandle);
            if (idfsVectorType.HasValue)
                ((VectorType2CollectionMethod)obj).idfsVectorType = (long)idfsVectorType;
        }
    }
}
