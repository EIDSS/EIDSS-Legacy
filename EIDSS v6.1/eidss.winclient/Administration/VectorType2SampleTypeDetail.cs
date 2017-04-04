using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.winclient.Schema;
using eidss.winclient.Helpers;
using eidss.winclient.Core;
using eidss.model.Schema;
using bv.winclient.Core;

namespace eidss.winclient.Administration
{
    public partial class VectorType2SampleTypeDetail : BaseGroupPanel_VectorType2SampleType
    {
        public VectorType2SampleTypeDetail()
        {
            InitializeComponent();
            Field2LookupMap = new Dictionary<string, string> { { "idfsSampleType", "SampleTypeLookup" } };
        }
        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            var column = Grid.GridView.Columns.ColumnByName("idfsSampleType");
            if (column != null)
            {
                var lookup = BaseReference.Accessor.Instance(null).rftSampleType_SelectList(manager);
                LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), lookup, LookupBinder.AddSampleType);
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
                (obj as VectorType2SampleType).idfsVectorType = (long)idfsVectorType;
        }
    }
}
