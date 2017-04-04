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
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class VectorTypeReferenceMasterDetail : BaseDetailPanel_VectorTypeReferenceMaster, IMasterDetail
    {
        public VectorTypeReferenceMasterDetail()
        {
            InitializeComponent();
            if (!WinUtils.IsComponentInDesignMode(this))
            {
                vectorTypeReferenceDetail1.DisplayLayout();
                ((LayoutGroup)vectorTypeReferenceDetail1.GetLayout()).SearchPanelVisible = false;
            }
        }
        public static void Register(Control parentControl)
        {
            MenuAction category = MenuActionManager.Instance.FindAction("MenuReferencies", MenuActionManager.Instance.System, 950);
            new MenuAction(ShowMe, MenuActionManager.Instance, category,
                           "MenuVectorTypeEditor", 933, false, (int)MenuIconsSmall.References)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference),
                ShowInMenu = true
            };
        }

        private static void ShowMe()
        {
            object id = 0;
            BaseFormManager.ShowNormal(new VectorTypeReferenceMasterDetail(), ref id, null, 800, 600);
        }
        public bool ShowModal(Control owner = null)
        {
            object id = 0;
            return BaseFormManager.ShowModal(this, owner, ref id, null, null, 800, 600);
        }

        protected override void InitChildren()
        {
            vectorTypeReferenceDetail1.SetDataSource(BusinessObject, ((VectorTypeReferenceMaster) BusinessObject).VectorTypes);
        }
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "DeleteVector", DeleteVector);
        }
        private ActResult DeleteVector(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            vectorTypeReferenceDetail1.PerformAction("Delete");
            return true;
        }
        //[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public override object Key
        //{
        //    get { return vectorTypeReferenceDetail1.Key; }
        //}

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IBasePanel Child
        {
            get { return vectorTypeReferenceDetail1; }
        }
    }
}
