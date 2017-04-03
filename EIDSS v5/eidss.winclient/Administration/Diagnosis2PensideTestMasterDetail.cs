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
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class Diagnosis2PensideTestMasterDetail : BaseDetailPanel_Diagnosis2PensideTestMaster
    {

        public Diagnosis2PensideTestMasterDetail()
        {
            InitializeComponent();
            if (!WinUtils.IsComponentInDesignMode(this))
            {
                matrixDetail.DisplayLayout();
                ((LayoutGroup)matrixDetail.GetLayout()).SearchPanelVisible = false;
                cbDiagnosis.EditValueChanged += DiagnosisChanged;
            }

        }
        public static void Register(Control parentControl)
        {
            MenuAction category = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960);
            new MenuAction(ShowMe, MenuActionManager.Instance, category,
                           "MenuDiagnosis2PensideTest", 975, false, (int)MenuIconsSmall.ReferenceMatrix)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference),
                ShowInMenu = true
            };
        }

        private static void ShowMe()
        {
            object id = 0;
            BaseFormManager.ShowNormal(new Diagnosis2PensideTestMasterDetail(), ref id, null, 800, 600);
        }
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "DeletePensideTest", DeletePensideTest);
        }

        private ActResult DeletePensideTest(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            matrixDetail.PerformAction("Delete");
            return true;
        }
        public override void DefineBinding()
        {
            var diagnosis = BusinessObject as Diagnosis2PensideTestMaster;
            if (diagnosis != null)
            {
                Core.LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, diagnosis, diagnosis.DiagnosisLookup, "Diagnosis", HACode.Livestock | HACode.Avian);
            }
        }

        protected override void InitChildren()
        {
            matrixDetail.SetDataSource(BusinessObject, ((Diagnosis2PensideTestMaster)BusinessObject).Diagnosis2PensideTest);
        }
        private void DiagnosisChanged(object sender, EventArgs e)
        {
            var diagnosis = BusinessObject as Diagnosis2PensideTestMaster;
            if (diagnosis == null) return;
            if (Utils.IsEmpty(cbDiagnosis.EditValue))
            {
                matrixDetail.idfsDiagnosis = -1;
                matrixDetail.Grid .GridView .OptionsBehavior .ReadOnly = true;
                matrixDetail.Grid.GridView.OptionsBehavior.Editable = false;
                matrixDetail.Grid.GridView.OptionsView .NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            else
            {
                matrixDetail.idfsDiagnosis = ((DiagnosisLookup) cbDiagnosis.EditValue).idfsDiagnosis;
                matrixDetail.Grid.GridView.OptionsBehavior.ReadOnly = false;
                matrixDetail.Grid.GridView.OptionsBehavior.Editable = true;
                matrixDetail.Grid.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;

            }
  
        }
    }

}
