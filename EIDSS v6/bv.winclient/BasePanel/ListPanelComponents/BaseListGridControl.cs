using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Utils;
using bv.common.Resources;
using bv.common.Resources.TranslationTool;
using bv.model.Model.Core;
using bv.winclient.Core;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using bv.winclient.Core.TranslationTool;

namespace bv.winclient.BasePanel.ListPanelComponents
{
    public partial class BaseListGridControl : BvXtraUserControl
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
                if (item.Visible && item.UseInWin)
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
        public override void ApplyResources(string cultureCode)
        {
            ResourcesList.Clear();
            foreach (GridColumn col in GridView.Columns)
            {
                string captionId = GetKeyForComponent(col, DesignElement.Caption);
                var resValue = CommonResourcesCache.Get("EidssFields", cultureCode, captionId, GetViewNameForSplittedResources());
                string propName = TranslationToolHelper.GetPropertyName(col.Name, TranslationToolHelper.CaptionPropName);
                if (resValue != null && resValue.Value is string)
                {
                    if (!ResourcesList.ContainsKey(propName))
                        ResourcesList.Add(propName, resValue);
                    col.Caption = resValue.Value.ToString();
                }
                else
                {
                    if (!ResourcesList.ContainsKey(propName))
                        ResourcesList.Add(propName, new ResourceValue
                            {
                            Value = col.Caption,
                            //RawValue = col.Caption,
                            //SourceFileName = string.Format("EidssFields.{0}.resx", cultureCode),
                            EnglishText = WinClientContext.FieldCaptions.GetString(captionId, null, common.Core.Localizer.lngEn),
                            SourceKey = captionId,
                            ResourceName = CommonResource.EidssFields.ToString()
                        });
                }

            }

        }
        public override bool SaveChanges(Dictionary<object, DesignElement> changes, string cultureCode)
        {
            bool res = TranslationToolHelperWinClient.SaveViewChanges(this, CommonResource.EidssFields.ToString(), changes, cultureCode, false);
            return res;
        }
        public override string GetKeyForComponent(Component component, DesignElement designType)
        {
            var col = component as GridColumn;
            if (col != null)
            {
                var metaItem = GridMeta.Find(i => i.Name == col.FieldName);
                if (metaItem != null)
                    return metaItem.LabelId ?? metaItem.Name;
                return col.FieldName;
            }
            return base.GetKeyForComponent(component, designType);
        }
        public override string GetResourceNameForComponent(Component component, DesignElement designType)
        {
            var key = GetKeyForComponent(component, designType);
            if (!string.IsNullOrEmpty(ResourceSplitter.Read(GetViewNameForSplittedResources(), key)))
                return string.Empty;
            return CommonResource.EidssFields.ToString();
        }
        public override string GetViewNameForSplittedResources()
        {
            return string.Format("{0}.{1}", Parent.GetType().Name, GetType().Name);
        }
        public override string GetViewNameForResourceUsage()
        {
            var basePanel = Parent as IBasePanel;
            if (basePanel != null)
            {
                if (basePanel.RootPanel == basePanel)
                    return GetType().Name;
                return string.Format("{0}.{1}", basePanel.GetType().Name, GetType().Name);
            }
            return GetType().Name;
        }

    }
}