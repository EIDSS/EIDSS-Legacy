using System;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using eidss.winclient.Schema;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VectorLabTestListPanel : BaseGroupPanel_VectorLabTest
    {
        public VectorLabTestListPanel()
        {
            InitializeComponent();

            EditByDoubleClick = false;
            //таблица не редактируется
            Grid.GridView.OptionsBehavior.Editable = false;
            Grid.GridView.OptionsBehavior.ReadOnly = true;

            //группировать по полю strTestName
            var column = Grid.GridView.Columns.ColumnByName("strTestName");
            if (column != null)
            {
                Grid.GridView.GroupCount = 1;
                Grid.GridView.SortInfo.AddRange(new[] { new GridColumnSortInfo(column, ColumnSortOrder.Ascending) });
                Grid.GridView.OptionsView.ShowGroupPanel = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshDataset()
        {
            var format = String.Empty;

            if (idfsVectorType.HasValue)
            {
                format = String.Format("idfsVectorType={0}", idfsVectorType);
            }

            Refresh(DataSource, format);
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
                RefreshDataset();
            }
        }
    }
}
