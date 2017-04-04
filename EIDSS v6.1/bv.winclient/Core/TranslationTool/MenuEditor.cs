using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraVerticalGrid.Rows;
using bv.common.Core;

namespace bv.winclient.Core.TranslationTool
{
    public partial class MenuEditor : BvForm
    {
        public MenuEditor()
        {
            InitializeComponent();
        }
        public DialogResult EditMenu(BarItemLinkCollection menuItemLinks)
        {
            if(menuItemLinks == null || menuItemLinks.Count ==0)
                return DialogResult.Cancel;
            InitVericalGrid(menuItemLinks);
            return ShowDialog();
        }
        public List<ControlDesignerEventArgs> GetChanges()
        {
            var changes = new List<ControlDesignerEventArgs>();
            foreach (CategoryRow cRow in menuEditoGrid.Rows)
            {
                foreach (EditorRow eRow in cRow.ChildRows)
                {
                    var link = eRow.Tag as BarItemLink;
                    if (link != null && !Utils.IsEmpty(eRow.Properties.Value) && !link.Item.Caption.Equals(eRow.Properties.Value))
                    {
                        var state = new UndoControlState { Element = link.Item, Caption = link.Item.Caption, Operation = UndoOperation.Text };
                        link.Item.Caption = eRow.Properties.Value.ToString();
                        changes.Add(new ControlDesignerEventArgs { UndoState = state });
                    }
                }
            }
            return changes;
        }


        private void InitVericalGrid(BarItemLinkCollection menuItemLinks)
        {
            menuEditoGrid.CloseEditor();
            menuEditoGrid.Rows.Clear();
            var cRow = new CategoryRow("Menu items");
            menuEditoGrid.OptionsView.AutoScaleBands = true;
            foreach (BarItemLink link in menuItemLinks)
            {
                if (link.Item.Tag == menuItemLinks)
                    continue;
                var eRow = new EditorRow();
                var a = link.Item.Tag as MenuAction;
                string caption;
                if (a != null && a.ItemsStorage != null)
                    caption = a.ItemsStorage.GetString(a.ResourceKey, null, Localizer.lngEn);
                else
                    caption = link.Caption;
                eRow.Properties.Caption = caption;
                eRow.Properties.Value = link.Caption;
                eRow.Tag = link;
                cRow.ChildRows.Add(eRow);
                
            }
            menuEditoGrid.Rows.Add(cRow);
        }

    }
}
