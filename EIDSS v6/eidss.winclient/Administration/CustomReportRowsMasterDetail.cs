using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class CustomReportRowsMasterDetail : BaseDetailPanel_CustomReportRowsMaster, IMasterDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomReportRowsMasterDetail()
        {
            InitializeComponent();
            if (!WinUtils.IsComponentInDesignMode(this))
            {
                matrixDetail.DisplayLayout();
                ((LayoutGroup)matrixDetail.GetLayout()).SearchPanelVisible = false;
                leCustomReportType.EditValueChanged += FilterChanged;
            }
        }

        void FilterChanged(object sender, System.EventArgs e)
        {
            var bo = BusinessObject as CustomReportRowsMaster;
            if (bo == null) return;

            if (Utils.IsEmpty(leCustomReportType.EditValue))
            {
                matrixDetail.IdfsSummaryReportType = -1;
                matrixDetail.Grid.GridView.OptionsBehavior.ReadOnly = true;
                matrixDetail.Grid.GridView.OptionsBehavior.Editable = false;
                matrixDetail.Grid.GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
                matrixDetail.IdfsSummaryReportType = ((BaseReference)leCustomReportType.EditValue).idfsBaseReference;
                matrixDetail.Grid.GridView.OptionsBehavior.ReadOnly = false;
                matrixDetail.Grid.GridView.OptionsBehavior.Editable = true;
                matrixDetail.Grid.GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            var category = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960);
            new MenuAction(ShowMe, MenuActionManager.Instance, category,
                           "MenuCustomReportRows", 997, false, (int)MenuIconsSmall.ReferenceMatrix)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference),
                ShowInMenu = true
            };
        }

        /// <summary>
        /// 
        /// </summary>
        private static void ShowMe()
        {
            object id = null;
            BaseFormManager.ShowNormal(new CustomReportRowsMasterDetail(), ref id, null, 800, 600);
        }

        public bool ShowModal(Control owner = null)
        {
            object id = null;
            return BaseFormManager.ShowModal(this, owner, ref id, null, null, 800, 600);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "DeleteItem", DeleteItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult DeleteItem(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            matrixDetail.PerformAction("Delete");
            return true;
        }

        protected override void InitChildren()
        {
            matrixDetail.SetDataSource(BusinessObject, ((CustomReportRowsMaster)BusinessObject).CustomReportRows);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IBasePanel Child
        {
            get { return matrixDetail; }
        }

        public override void DefineBinding()
        {
            var master = BusinessObject as CustomReportRowsMaster;
            if (master != null)
            {
                Core.LookupBinder.BindBaseLookup(leCustomReportType, master, "SummaryReportType", master.SummaryReportTypeLookup, false);
            }
        }
    }

}
