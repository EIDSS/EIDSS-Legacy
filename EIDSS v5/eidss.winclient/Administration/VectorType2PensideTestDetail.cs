using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eidss.winclient.Schema;
using eidss.winclient.Helpers;
using eidss.winclient.Core;
using eidss.model.Schema;
using bv.winclient.Core;

namespace eidss.winclient.Administration
{
    public partial class VectorType2PensideTestDetail : BaseGroupPanel_VectorType2PensideTest
    {
        public VectorType2PensideTestDetail()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }

            var acc = VectorType2PensideTest.Accessor.Instance(null);

            using (var manager = CreateDbManagerProxy())
            {
                var matrix = acc.CreateNewT(manager, null);

                var column = Grid.GridView.Columns.ColumnByName("idfsPensideTestType");
                if (column != null)
                    LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), matrix.PensideTestLookup);

            }
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
            if (idfsVectorType.HasValue )
                (obj as VectorType2PensideTest).idfsVectorType = (long)idfsVectorType;
        }
    }
}
