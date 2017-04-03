using System;
using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class VectorType2SampleTypeMasterDetail : BaseDetailPanel_VectorType2SampleTypeMaster
    {

        public VectorType2SampleTypeMasterDetail()
        {
            InitializeComponent();
            if (!WinUtils.IsComponentInDesignMode(this))
            {
                matrixDetail.DisplayLayout();
                ((LayoutGroup)matrixDetail.GetLayout()).SearchPanelVisible = false;
                cbVectorType.EditValueChanged += VectorTypeChanged;
            }

        }
        public static void Register(Control parentControl)
        {
            MenuAction category = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960);
            new MenuAction(ShowMe, MenuActionManager.Instance, category,
                           "MenuVectorType2SampleType", 990, false, (int)MenuIconsSmall.ReferenceMatrix)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference),
                ShowInMenu = true
            };
        }

        private static void ShowMe()
        {
            object id = 0;
            BaseFormManager.ShowNormal(new VectorType2SampleTypeMasterDetail(), ref id, null, 800, 600);
        }
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "DeleteSampleType", DeleteSampleType);
        }

        private ActResult DeleteSampleType(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            matrixDetail.PerformAction("Delete");
            return true;
        }
        public override void DefineBinding()
        {
            var vectorType = BusinessObject as VectorType2SampleTypeMaster;
            if (vectorType != null)
            {
                LookupBinder.BindBaseLookup(cbVectorType, vectorType, "VectorType", vectorType.VectorTypeLookup, LookupBinder.AddVectorType);
            }
        }

        protected override void InitChildren()
        {
            matrixDetail.SetDataSource(BusinessObject, ((VectorType2SampleTypeMaster) BusinessObject).VectorType2SampleType);
        }
        private void VectorTypeChanged(object sender, EventArgs e)
        {
            var vectorType = BusinessObject as VectorType2SampleTypeMaster;
            if (vectorType == null) return;
            if (Utils.IsEmpty(cbVectorType.EditValue))
            {
                matrixDetail.idfsVectorType = -1;
                matrixDetail.Grid .GridView .OptionsBehavior .ReadOnly = true;
                matrixDetail.Grid.GridView.OptionsBehavior.Editable = false;
                matrixDetail.Grid.GridView.OptionsView .NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            else
            {
                matrixDetail.idfsVectorType = ((BaseReference) cbVectorType.EditValue).idfsBaseReference;
                matrixDetail.Grid.GridView.OptionsBehavior.ReadOnly = false;
                matrixDetail.Grid.GridView.OptionsBehavior.Editable = true;
                matrixDetail.Grid.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            }
  
        }
    }

}
