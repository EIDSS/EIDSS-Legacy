using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.winclient.Schema;
using eidss.winclient.Helpers;
using eidss.winclient.Core;
using eidss.model.Schema;
using bv.winclient.Core;

namespace eidss.winclient.Administration
{
    public partial class Diagnosis2PensideTestDetail : BaseGroupPanel_Diagnosis2PensideTest
    {
        public Diagnosis2PensideTestDetail()
        {
            InitializeComponent();
            Field2LookupMap = new Dictionary<string, string> { { "idfsPensideTestName", "PensideTestTypeLookup" } };
        }
        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            var column = Grid.GridView.Columns.ColumnByName("idfsPensideTestName");
            if (column != null)
            {
                var lookup = BaseReference.Accessor.Instance(null).rftPensideTestType_SelectList(manager);
                LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), lookup, true);
            }
            Grid.GridView.InitNewRow += InitMatrixRow;
            TopPanelVisible = false;
        }         
        
        private long? m_IdfsDiagnosis;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long? idfsDiagnosis
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
        private void InitMatrixRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var obj = Grid.GridView.GetRow(e.RowHandle);
            if (idfsDiagnosis.HasValue )
                (obj as Diagnosis2PensideTest).idfsDiagnosis = (long)idfsDiagnosis;
        }
    }
}
