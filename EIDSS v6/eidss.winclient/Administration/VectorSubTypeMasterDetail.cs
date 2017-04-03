using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class VectorSubTypeMasterDetail : BaseDetailPanel_VectorSubTypeMaster
    {

        public VectorSubTypeMasterDetail()
        {
            InitializeComponent();
            if (!WinUtils.IsComponentInDesignMode(this))
            {
                vectorSubTypeDetail1.DisplayLayout();
                ((LayoutGroup)vectorSubTypeDetail1.GetLayout()).SearchPanelVisible = false;
                cbVectorType.EditValueChanged += VectorTypeChanged;
            }

        }
        public static void Register(Control parentControl)
        {
            MenuAction category = MenuActionManager.Instance.FindAction("MenuReferencies", MenuActionManager.Instance.System, 950);
            new MenuAction(ShowMe, MenuActionManager.Instance, category,
                           "MenuVectorSubTypeEditor", 934, false, (int)MenuIconsSmall.References)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference),
                ShowInMenu = true
            };
        }

        private static void ShowMe()
        {
            object id = 0;
            BaseFormManager.ShowNormal(new VectorSubTypeMasterDetail(), ref id, null, 800, 600);
        }
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "DeleteVectorSubType", DeleteVectorSubType);
        }

        private ActResult DeleteVectorSubType(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            vectorSubTypeDetail1.PerformAction("Delete");
            return true;
        }
        public override void DefineBinding()
        {
            var vectorType = BusinessObject as VectorSubTypeMaster;
            if (vectorType != null)
            {
                LookupBinder.BindBaseLookup(cbVectorType, vectorType, "VectorType", vectorType.VectorTypeLookup, LookupBinder.AddVectorType);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object Key
        {
            get { return vectorSubTypeDetail1.Key; }
        }

        protected override void InitChildren()
        {
            vectorSubTypeDetail1.SetDataSource(BusinessObject, ((VectorSubTypeMaster) BusinessObject).VectorSubType);
        }
        private void VectorTypeChanged(object sender, EventArgs e)
        {
            var vectorType = BusinessObject as VectorSubTypeMaster;
            if (vectorType == null) return;
            if (Utils.IsEmpty(cbVectorType.EditValue))
                vectorSubTypeDetail1.idfsVectorType = -1;
            else
                vectorSubTypeDetail1.idfsVectorType = ((BaseReference) cbVectorType.EditValue).idfsBaseReference;

        }

    }

}
