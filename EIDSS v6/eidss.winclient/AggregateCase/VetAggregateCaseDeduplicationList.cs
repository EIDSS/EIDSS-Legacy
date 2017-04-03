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
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;

namespace eidss.winclient.AggregateCase
{
    public partial class VetAggregateCaseDeduplicationList : eidss.winclient.Schema.BaseListPanel_VetAggregateCaseDeduplicationListItem
    {
        public VetAggregateCaseDeduplicationList()
        {
            InitializeComponent();
            var filter = new FilterParams();
            filter.Add("idfAggrCase", "=", -1L);
            StaticFilter = filter;
            AfterLayoutCreated += LayoutCreated;
        }
        public static void Register(Control parentControl)
        {
            RegisterItem(330, false);
        }

        private static void RegisterItem(int order, bool showInToolbar)
        {
            if (EidssSiteContext.Instance.CustomizationPackageID == (long)CustomizationPackage.Azerbaijan)
                return;
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Search,
                           "MenuVetAggregateCaseDeduplicationList", order, showInToolbar, (int)MenuIconsSmall.VetAggregateDeduplication)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToVetAggregateCase),
                ShowInMenu = !showInToolbar
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(VetAggregateCaseDeduplicationList), BaseFormManager.MainForm,
                                       VetAggregateCaseDeduplicationListItem.CreateInstance());
        }

        public override string GetDetailFormName(IObject o)
        {
            return "VetAggregateCaseDetail";
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
