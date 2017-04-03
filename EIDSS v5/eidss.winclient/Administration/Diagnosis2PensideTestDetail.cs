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
    public partial class Diagnosis2PensideTestDetail : BaseGroupPanel_Diagnosis2PensideTest
    {
        public Diagnosis2PensideTestDetail()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }

            var acc = Diagnosis2PensideTest.Accessor.Instance(null);

            using (var manager = CreateDbManagerProxy())
            {
                var matrix = acc.CreateNewT(manager, null);

                var column = Grid.GridView.Columns.ColumnByName("idfsPensideTestType");
                if (column != null)
                    LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), matrix.PensideTestTypeLookup);

            }
            Grid.GridView.InitNewRow += InitMatrixRow;
            TopPanelVisible = false;
        }
        private long? m_IdfsDiagnosis;

        /// <summary>
        /// 
        /// </summary>
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
