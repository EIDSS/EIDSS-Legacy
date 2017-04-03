using System.Drawing;
using System.Reflection;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;

namespace EIDSS.RAM.QueryBuilder
{
    public class PivotFilterControl : FilterControl
    {
        protected override void ShowElementMenu(ElementType type)
        {
            //// cant add if there are no visible filter items 
            //if (GetVisibleFilterItemsCount() == 0 && type == ElementType.NodeAdd)
            //{
            //    return;
            //}

            // restrict the group element from showing because we currently are only handling a single AND grouping
            // also restrict if there are no filter columns but not if the element type is remove 
            if (type != ElementType.Group && (FilterColumns.Count != 0 || type == ElementType.NodeRemove))
            {
                base.ShowElementMenu(type);
            }
            if (type == ElementType.Group)
            {
                foreach (DXMenuItem item in FilterViewInfo.GroupMenu.Items)
                {
                    if (item.Tag != null)
                    {
                        if ((GroupType) item.Tag == GroupType.NotOr || (GroupType) item.Tag == GroupType.NotAnd)
                        {
                            item.Visible = false;
                        }
                    }
                    MethodInfo mi = item.GetType().GetMethod("OnClick", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (mi != null && mi.Name == "OnAddGroup")
                    {
                        item.Visible = false;
                    }
                }
                ShowGroupMenu();
            }
        }

        private void ShowGroupMenu()
        {
            //if (!ShowGroupCommandsIcon) ClearGroupMenu();
            if (FocusedItem == null)
            {
                return;
            }
            var p = new Point(FocusedItem.ItemBounds.X, FocusedItem.Bottom);
            MenuManagerHelper.ShowMenu(FilterViewInfo.GroupMenu, LookAndFeel, MenuManager, this, p);
        }

        protected internal void ClearGroupMenu()
        {
            ClearNodeActionMenu();
            if (FilterViewInfo.GroupMenu == null)
            {
                return;
            }
            FilterViewInfo.GroupMenu.Dispose();
        }

        protected internal void ClearNodeActionMenu()
        {
            if (FilterViewInfo.NodeActionMenu == null)
            {
                return;
            }
            FilterViewInfo.NodeActionMenu.Dispose();
        }

        internal FilterLabelInfoTextViewInfo FocusedItem
        {
            get
            {
                if (FocusInfo.Node == null)
                {
                    return null;
                }
                for (int i = 0; i < FocusInfo.Node.LabelInfo.ViewInfo.Count; i++)
                {
                    var element = (FilterLabelInfoTextViewInfo)FocusInfo.Node.LabelInfo.ViewInfo[i];

                    var nodeElement = element.InfoText.Tag as NodeEditableElement;
                    if (nodeElement != null && nodeElement.CreateFocusInfo() == FocusInfo)
                    {
                        return element;
                    }
                }
                return null;
            }
        }
    }
}