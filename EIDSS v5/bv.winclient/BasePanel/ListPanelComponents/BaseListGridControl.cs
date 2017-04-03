using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.Utils;
using bv.common.Resources;
using bv.model.Model.Core;
using bv.winclient.Core;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace bv.winclient.BasePanel.ListPanelComponents
{
    public partial class BaseListGridControl : UserControl
    {
        private List<GridMetaItem> m_GridMeta;

        public BaseListGridControl()
        {
            InitializeComponent();
        }

        public GridControl GridControl
        {
            get { return m_GridControl; }
        }

        public GridView GridView
        {
            get { return m_GridView; }
        }

        public void ShowTotal(long currentCount)
        {
            m_TotalsLabel.Visible = true;
            m_TotalsLabel.SendToBack();

            string currentTotalString = string.Format(BvMessages.Get("msgNumberOfRecords"), currentCount);
            
            m_TotalsLabel.Text = currentTotalString;
        }


        public void ShowTotal(long currentCount, long? totalCount)
        {
            m_TotalsLabel.Visible = true;
            m_TotalsLabel.SendToBack();

            string currentTotalString = string.Format(BvMessages.Get("msgNumberOfRecords"), currentCount);
            if (totalCount.HasValue)
            {
                currentTotalString = string.Format(BvMessages.Get("msgTotalNumberOfRecords"),
                                                   currentTotalString, totalCount.Value);
            }
            m_TotalsLabel.Text = currentTotalString;
        }
        public static void InitColumns(GridView gridView, List<GridMetaItem> metaItems)
        {
            int index = 0;
            var columns = new List<GridColumn>();
            foreach (var item in metaItems)
            {
                if (item.Visible)
                {
                    columns.Add(CreateColumnFromMeta(item, index));
                    index++;
                }
            }
            gridView.Columns.Clear();
            gridView.Columns.AddRange(columns.ToArray());
        }
        internal List<GridMetaItem> GridMeta
        {
            get { return m_GridMeta; }
            set
            {
                m_GridMeta = value;
                if (m_GridMeta == null)
                {
                    return;
                }
                InitColumns(m_GridView, m_GridMeta);
            }
        }

        private static GridColumn CreateColumnFromMeta(GridMetaItem item, int index)
        {
            var id = item.LabelId;
            var caption = WinClientContext.FieldCaptions != null
                                 ? WinClientContext.FieldCaptions.GetString(id, id)
                                 : id;
            var column = new GridColumn
                             {
                                 Caption = caption,
                                 FieldName = item.Name,
                                 Name = item.Name,
                                 Visible = item.Visible,
                                 VisibleIndex = index
                             };
            if (!String.IsNullOrEmpty(item.Format))
            {
                column.DisplayFormat.FormatString = item.Format;
                column.DisplayFormat.FormatType = FormatType.Custom;
            }
            if (item.DefaultSort.HasValue)
            {
                column.SortOrder = (item.DefaultSort == ListSortDirection.Ascending)
                                       ? ColumnSortOrder.Ascending
                                       : ColumnSortOrder.Descending;
            }
            return column;
        }
    }
}