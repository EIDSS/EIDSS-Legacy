using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Enums;
using eidss.model.Schema;

namespace eidss.winclient.AggregateCase
{
    public partial class VetAggregateActionDeduplicationList : eidss.winclient.Schema.BaseListPanel_VetAggregateActionDeduplicationListItem
    {
        public VetAggregateActionDeduplicationList()
        {
            InitializeComponent();
            var filter = new FilterParams();
            filter.Add("idfAggrCase", "=", -1L);
            StaticFilter = filter;
            AfterLayoutCreated += LayoutCreated;
        }
        public static void Register(Control parentControl)
        {
            RegisterItem(340, false);
        }

        private static void RegisterItem(int order, bool showInToolbar)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Search,
                           "MenuVetAggregateActionDeduplicationList", order, showInToolbar, (int)MenuIconsSmall.VetAggregateActionDeduplication)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToVetAggregateAction),
                ShowInMenu = !showInToolbar
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(VetAggregateActionDeduplicationList), BaseFormManager.MainForm,
                                       VetAggregateActionDeduplicationListItem.CreateInstance());
        }

        public override string GetDetailFormName(IObject o)
        {
            return "VetAggregateActionDetail";
        }
        private void LayoutCreated()
        {
            ILayout layout = GetLayout();
            layout.SearchPanelVisible = false;
            Grid.GridView.Columns["intDuplicateGroup"].Group();
        }
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "FindDuplicates", FindDuplicates);
        }

        private ActResult FindDuplicates(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            StaticFilter = null;
            Refresh();
            if (Grid.GridView.RowCount == 0)
                ErrorForm.ShowWarning("msgDuplicatesNotFound");
            Grid.GridView.ExpandAllGroups();
            return true;
        }
    }
}
