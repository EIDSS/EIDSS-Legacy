using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using eidss.winclient.Schema;
using eidss.winclient.Helpers;
using eidss.winclient.Core;
using eidss.model.Schema;
using bv.winclient.Core;

namespace eidss.winclient.Administration
{
    public partial class VectorSubTypeDetail : BaseGroupPanel_VectorSubType
    {
        public VectorSubTypeDetail()
        {
            InitializeComponent();
        }

        public override void InitGridBehavior(IObject dummyObjectWithLookups)
        {
            var column = Grid.GridView.Columns.ColumnByName("intOrder");
            if (column != null)
                LookupBinder.BindRepositorySpinEdit(column.SetSpinEditor());
            var translationCol = Grid.GridView.Columns.ColumnByName("strTranslatedName");
            if (translationCol != null && ModelUserContext.CurrentLanguage == Localizer.lngEn)
                translationCol.Visible = false;
            Grid.GridView.InitNewRow += IniVectorSubTypeRow;
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
                if (!m_IdfsVectorType.HasValue || m_IdfsVectorType.Value <= 0)
                {
                    Grid.GridView.OptionsBehavior.ReadOnly = true;
                    Grid.GridView.OptionsBehavior.Editable = false;
                    Grid.GridView.OptionsView.NewItemRowPosition =
                        DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                }
                else
                    VisualizePermissions();
            }
        }
        private void IniVectorSubTypeRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var obj = Grid.GridView.GetRow(e.RowHandle);
            if (idfsVectorType.HasValue )
                (obj as VectorSubType).idfsVectorType = (long)idfsVectorType;
        }
    }
}
