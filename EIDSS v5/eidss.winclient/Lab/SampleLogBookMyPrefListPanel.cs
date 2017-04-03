using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;
using DevExpress.XtraGrid.Views.Grid;
using eidss.model.Resources;
using eidss.model.Core;

namespace eidss.winclient.Lab
{
    public partial class SampleLogBookMyPrefListPanel : BaseListPanel_LabSampleLogBookMyPrefListItem
    {
        public SampleLogBookMyPrefListPanel()
        {
            InitializeComponent();
            this.Grid.GridView.OptionsSelection.MultiSelect = true;
            this.ActionButtonStateChanged += OnActionButtonStateChanged;
        }
        private void OnActionButtonStateChanged(object sender, ActionButtonEventArgs<IObject> e)
        {
            var action = e.Button.Tag as ActionMetaItem;
            if (action!=null)
            {
                if (action.Name=="SelectTest")
                {
                    e.Button.Enabled = e.FocusedItem != null && action.IsEnable(e.FocusedItem, e.FocusedItem.GetPermissions()) && (e.SelectedItems == null || e.SelectedItems.Count <= 1);
                }
            }
        }
        public override string GetDetailFormName(IObject o)
        {
            return "SampleLogBookListPanel";
        }
        /*
        public static void Register(Control parentControl)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuLabSampleLogBook", 1075, false, (int)MenuIconsSmall.LabSampleLogBook,
                           -1)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Sample),
                    ShowInMenu = true
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(SampleLogBookMyPrefListPanel), BaseFormManager.MainForm,
                                       LabSampleLogBookListItem.CreateInstance());
        }
        */

        public override bool Close(FormClosingMode notNeedCallParent)
        {
            if (notNeedCallParent == FormClosingMode.Save)
            {
                base.Close(FormClosingMode.NoSave);
            }
            else
            {
                Control parent = this.Parent;
                while (parent != null)
                {
                    if (parent is IApplicationForm)
                    {
                        (parent as IApplicationForm).Close(FormClosingMode.NoSave);
                        return true;
                    }
                    parent = parent.Parent;
                }
            }
            return true;
        }

        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            SetActionFunction(actions, "SelectTest", SelectTest);
            SetActionFunction(actions, "DeleteTest", DeleteTest);
            SetActionFunction(actions, "EditSample", EditSample);
            SetActionFunction(actions, "EditTest", EditTest);
            SetActionFunction(actions, "MarkForDisposition", MarkForDisposition);
            SetActionFunction(actions, "TransferOut", TransferOut);
            SetActionFunction(actions, "AliquotsDerivatives", AliquotsDerivatives);
            SetActionFunction(actions, "HumanAccessionIn", HumanAccessionIn);
            SetActionFunction(actions, "VetAccessionIn", VetAccessionIn);
            SetActionFunction(actions, "AsAccessionIn", AsAccessionIn);
            SetActionFunction(actions, "VsAccessionIn", VsAccessionIn);
            //SetActionFunction(actions, "AddToPreferences", AddToPreferences);
            SetActionFunction(actions, "RemoveFromPreferences", RemoveFromPreferences);
            SetActionFunction(actions, "GroupAccessionIn", GroupAccessionIn);
        }

        #region IEqualityComparer<IObject> Members
        private class comparerLabSampleLogBookMyPrefListItem : IEqualityComparer<IObject>
        {
            public bool Equals(IObject x, IObject y)
            {
                LabSampleLogBookMyPrefListItem xx = x as LabSampleLogBookMyPrefListItem;
                LabSampleLogBookMyPrefListItem yy = y as LabSampleLogBookMyPrefListItem;
                return xx.idfMaterial == yy.idfMaterial;
            }
            public int GetHashCode(IObject obj)
            {
                return 0;
            }
        }
        #endregion

        private static ActResult SelectTest(DbManagerProxy manager, IObject bo, List<object> parameters)
        {

            var s = parameters[2] as SampleLogBookMyPrefListPanel;
            var focusedItem = s.FocusedItem as LabSampleLogBookMyPrefListItem;

            if (focusedItem.idfsContainerStatus != (long)ContainerStatus.Accessioned)
            {
                ErrorForm.ShowWarningFormat("errInvaliSampleStatusForSelectTest", "The test can not be selected because the sample is in status: {0}", focusedItem.ContainerStatus.name);
                return false;
            }

            var currentPanel = ((Control)parameters[2]);
            object details = ClassLoader.LoadClass("LabTestDetail");
            ReflectionHelper.SetProperty(details,"SampleID", focusedItem.idfMaterial);
            object key = null;
            return BaseFormManager.ShowModal(details as IApplicationForm, currentPanel.FindForm(), ref key, null, null);
        }
        private static ActResult DeleteTest(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            var s = parameters[2] as SampleLogBookMyPrefListPanel;
            var selectedItem = s.FocusedItem as LabSampleLogBookMyPrefListItem;
            if (selectedItem.idfTesting.HasValue)
            {
                var action = LabSampleLogBookMyPrefListItem.Meta.Actions.Where(c => c.ActionType == ActionTypes.Delete).SingleOrDefault();
                if (WinUtils.ConfirmDelete())
                {
                    try
                    {
                        selectedItem.Validation += GridPanelItem_DeleteValidation;
                        action.RunAction(manager, selectedItem);
                    }
                    finally
                    {
                        selectedItem.Validation -= GridPanelItem_DeleteValidation;
                    }
                }
            }
            return true;
        }
        static void GridPanelItem_DeleteValidation(object sender, ValidationEventArgs args)
        {
            // todo: show warning according to object type
            if (args.FieldName == "_on_delete")
                ErrorForm.ShowWarning("msgCantDelete", "Can't delete object");
            else
                ErrorForm.ShowWarning("msgErrorDelete", "Error occurred while deleting object");
        }
        private static ActResult EditSample(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            var s = parameters[2] as SampleLogBookMyPrefListPanel;
            var selectedItem = s.FocusedItem as LabSampleLogBookMyPrefListItem;
            var currentPanel = ((Control)parameters[2]);
            object details = ClassLoader.LoadClass("SampleDetail");
            object key = selectedItem.idfMaterial;
            return BaseFormManager.ShowModal(details as IApplicationForm, currentPanel.FindForm(), ref key, null, null);
        }
        private static ActResult EditTest(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            var s = parameters[2] as SampleLogBookMyPrefListPanel;
            var selectedItems = s.SelectedItems  as IList<IObject> ;
            var focusedItem = s.FocusedItem as LabSampleLogBookMyPrefListItem;
            var currentPanel = ((Control)parameters[2]);
            object key = null;
            if (selectedItems!=null && selectedItems.Count > 1)
            {
                if (!ValidateSelectedTests(selectedItems))
                    return false;
                key = new List<object>();
                foreach (var test in selectedItems)
                {
                    (key as List<object>).Add(test.GetValue("idfTesting"));
                }

            }
            else
                key = focusedItem.idfTesting;
            if (key == null)
            {
                return SelectTest(manager, bo, parameters);
            }
            object details = ClassLoader.LoadClass("LabTestDetail");
            return BaseFormManager.ShowModal(details as IApplicationForm, currentPanel.FindForm(), ref key, null, null);
        }

        private static bool ValidateSelectedTests(IList<IObject> selectedItems)
        {
            var testType = selectedItems[0].GetValue("idfsTestType");
            if (testType == null) testType = 0;
            var testStatus = selectedItems[0].GetValue("idfsTestStatus");
            if (testStatus == null) testType = 0;
            foreach (var test in selectedItems)
            {
                if (!testType.Equals(test.GetValue("idfsTestType")) || !((long)BatchStatusEnum.Undefined).Equals(test.GetValue("idfsTestStatus")))
                {
                    ErrorForm.ShowWarning("errInvalidMultiTestSelection", "Please select samples with the same test name and <Undefined> test status. Only such tests can be edited simultaneously.");
                    return false;
                }

            }
            return true;
        }
        /*
        private static bool AddToPreferences(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (ErrorForm.ShowConfirmationDialog(null, EidssMessages.Get("msgAddToPreferencesPrompt", "Selected records will be added to preferences."), null) == DialogResult.Yes)
            {
                var s = parameters[2] as SampleLogBookMyPrefListPanel;
                var selectedItems = s.SelectedItems.ToList();
                if (manager == null)
                {
                    using (manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        selectedItems.ForEach(c => LabSampleLogBookMyPrefListItem.Accessor.Instance(null).AddToPreferences(manager, c as LabSampleLogBookMyPrefListItem, (c as LabSampleLogBookMyPrefListItem).ID));
                    }
                }
                else
                {
                    selectedItems.ForEach(c => LabSampleLogBookMyPrefListItem.Accessor.Instance(null).AddToPreferences(manager, c as LabSampleLogBookMyPrefListItem, (c as LabSampleLogBookMyPrefListItem).ID));
                }
            }
            return true;
        }
        */

        private ActResult RemoveFromPreferences(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (ErrorForm.ShowConfirmationDialog(null, EidssMessages.Get("msgRemoveFromPreferencesPrompt", "Selected records will be removed from preferences."), null) == DialogResult.Yes)
            {
                var s = parameters[2] as SampleLogBookMyPrefListPanel;
                var selectedItems = s.SelectedItems.ToList();
                if (manager == null)
                {
                    using (manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        selectedItems.ForEach(c => LabSampleLogBookMyPrefListItem.Accessor.Instance(null).RemoveFromPreferences(manager, c as LabSampleLogBookMyPrefListItem, (c as LabSampleLogBookMyPrefListItem).ID));
                    }
                }
                else
                {
                    selectedItems.ForEach(c => LabSampleLogBookMyPrefListItem.Accessor.Instance(null).RemoveFromPreferences(manager, c as LabSampleLogBookMyPrefListItem, (c as LabSampleLogBookMyPrefListItem).ID));
                }
                Refresh();
            }
            return false;
        }


        private static ActResult HumanAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            return AccessionIn(parameters, new object[] { HACode.Human, SessionType.None });
        }

        private static ActResult VetAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            return AccessionIn(parameters, new object[] { HACode.Avian | HACode.Livestock, SessionType.None });
        }

        private static ActResult AsAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            return AccessionIn(parameters, new object[] { HACode.Livestock, SessionType.AsSession });
        }
        private static ActResult VsAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters)
        {

            return AccessionIn(parameters, new object[] { HACode.Vector, SessionType.VsSession });

        }
        private static ActResult GroupAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters)
        {

            //return AccessionIn(parameters, new object[] {HACode.Animal | HACode.Livestock, false});
            var isAccessioned = GroupAccessionIn(parameters, new object[] { HACode.Vector, SessionType.VsSession });
            //BaseFormManager.RefreshList(bo.GetType().Name);
            return isAccessioned;

        }

        private static bool AccessionIn(List<object> actionParameters, object[] invokeParams)
        {
            if (!(actionParameters[2] is Control))
            {
                throw new TypeMismatchException("listPanel", typeof(Control));
            }
            var currentPanel = ((Control)actionParameters[2]);
            object checkIn = ClassLoader.LoadClass("SamplesCheckIn");
            ReflectionHelper.InvokeMethod(checkIn, "Init", invokeParams);
            return BaseFormManager.ShowModal((IApplicationForm)checkIn, currentPanel.FindForm());
        }
        private static bool GroupAccessionIn(List<object> actionParameters, object[] invokeParams)
        {
            if (!(actionParameters[2] is Control))
            {
                throw new TypeMismatchException("listPanel", typeof(Control));
            }
            var currentPanel = ((Control)actionParameters[2]);
            object checkIn = ClassLoader.LoadClass("SamplesGroupCheckIn");
            ReflectionHelper.InvokeMethod(checkIn, "Init", invokeParams);
            return BaseFormManager.ShowModal((IApplicationForm)checkIn, currentPanel.FindForm());
        }

        public class LabSampleLogBookkMyPrefListItemComparator : EqualityComparer<IObject>
        {
            public override bool Equals(IObject x, IObject y)
            {
                return (x as LabSampleLogBookMyPrefListItem).idfContainer.Equals((y as LabSampleLogBookMyPrefListItem).idfContainer);
            }

            public override int GetHashCode(IObject obj)
            {
                return (obj as LabSampleLogBookMyPrefListItem).idfContainer.GetHashCode();
            }
        }

        private static bool CheckSampleAccessionedIn(IEnumerable<IObject> list)
        {
            foreach (var i in list)
            {
                var li = i as LabSampleLogBookListItem;
                if (li.idfsContainerStatus != (long)ContainerStatus.Accessioned)
                {
                    if (li.ContainerStatusLookup.Count == 0)
                    {
                        using (var manager = CreateDbManagerProxy())
                        {
                            li.ReloadLookupItem(manager, "rftContainerStatus");
                        }
                    }
                    ErrorForm.ShowWarningFormat("errInvaliSampleStatus", "The operation cannot be performed because the sample is in status: {0}", li.ContainerStatus.name);
                    return false;
                }
            }
            return true;
        }

        private static ActResult MarkForDisposition(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (parameters[0] != null)
            {
                var s = parameters[2] as SampleLogBookMyPrefListPanel;
                var selectedItems = s.SelectedItems.Distinct(new LabSampleLogBookkMyPrefListItemComparator()).ToList();
                if (!CheckSampleAccessionedIn(selectedItems))
                    return false;

                var currentPanel = ((Control)parameters[2]);
                object key = selectedItems;
                if (key == null)
                    return false;
                object destructionForm = ClassLoader.LoadClass("SampleDestructionDetail");
                ReflectionHelper.InvokeMethod(destructionForm, "SetDestroyMode", new object[] { false });
                if (BaseFormManager.ShowModal(destructionForm as IApplicationForm, currentPanel.FindForm(), ref key, null, null, 900, 600))
                {
                    //BaseFormManager.RefreshList(bo.GetType().Name);
                    //BaseFormManager.RefreshList(bo.GetType("LabTestListItem"));
                    return true;
                }
            }
            return false;
        }

        private static ActResult TransferOut(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (parameters[0] != null)
            {

                if (parameters.Count > 2)
                {

                    var p = parameters[2] as SampleLogBookMyPrefListPanel;
                    var selectedItems = p.SelectedItems.Distinct(new LabSampleLogBookkMyPrefListItemComparator()).ToList();
                    if (!CheckSampleAccessionedIn(selectedItems))
                        return false;

                    var currentPanel = ((Control)parameters[2]);
                    object key = selectedItems;
                    if (key == null)
                        return false;
                    object transfer = ClassLoader.LoadClass("SampleTransferDetail");

                    if (BaseFormManager.ShowModal(transfer as IApplicationForm, currentPanel.FindForm(), ref key, null, null, 900, 600))
                    {
                        //BaseFormManager.RefreshList(bo.GetType().Name);
                        //BaseFormManager.RefreshList(bo.GetType("SampleListItem"));
                        return true;
                    }

                }


            }
            return false;

        }

        private static ActResult AliquotsDerivatives(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (parameters[0] != null)
            {
                if (parameters.Count > 2)
                {
                    var p = parameters[2] as SampleLogBookMyPrefListPanel;
                    var selectedItems = p.SelectedItems.Distinct(new LabSampleLogBookkMyPrefListItemComparator()).ToList();
                    if (!CheckSampleAccessionedIn(selectedItems))
                        return false;

                    object key = selectedItems;
                    if (key == null)
                        return false;

                    object samplevar = ClassLoader.LoadClass("SamplesVariants");

                    var currentPanel = ((Control)parameters[2]);
                    var @params = new Dictionary<string, object>();
                    @params.Add("key", key);
                    BaseFormManager.ShowModal(samplevar as IApplicationForm, currentPanel.FindForm(), ref key, @params, null, 900, 600);
                    //BaseFormManager.RefreshList(bo.GetType().Name);

                    return true;

                }

            }

            return true;
        }

        /*perm!!
        public override void CheckActionPermission(ActionMetaItem action, ref bool showAction)
        {
            IObjectPermissions permissions = BusinessObject.GetPermissions();
            switch (action.Name)
            {
                case "SelectTest":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.Test));
                    return;
                case "AccessionIn":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
                        (EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase))
                        || EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase))
                        || EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.MonitoringSession))
                        || EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VsSession))
                        );
                    return;
                case "HumanAccessionIn":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
                        EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase));
                    return;
                case "VetAccessionIn":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
                        EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase));
                    return;
                case "AsAccessionIn":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
                        EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.MonitoringSession));
                    return;
                case "VsAccessionIn":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
                        EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VsSession));
                    return;
                case "DeleteTest":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(EIDSSPermissionObject.Test));
                    return;
                case "EditSample":
                    if (showAction && (ReadOnly || permissions.IsReadOnlyForEdit))
                    {
                        action.ReadOnly = true;
                        //if (!string.IsNullOrEmpty(action.CaptionIdReadOnly))
                        //    action.CaptionId = action.CaptionIdReadOnly; // "strViewSample_Id";
                        //if (!string.IsNullOrEmpty(action.IconIdReadOnly))
                        //    action.IconId = action.IconIdReadOnly; // "View1";
                    }
                    return;
                case "EditTest":
                    if (showAction && (ReadOnly || permissions.IsReadOnlyForEdit))
                    {
                        action.ReadOnly = true;
                        //if (!string.IsNullOrEmpty(action.CaptionIdReadOnly))
                        //    action.CaptionId = action.CaptionIdReadOnly; // "strViewTest_Id";
                        //if (!string.IsNullOrEmpty(action.IconIdReadOnly))
                        //    action.IconId = action.IconIdReadOnly; // "View1";
                    }
                    return;
                case "MarkForDisposition":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(EIDSSPermissionObject.Sample));
                    return;
                case "TransferOut":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.SampleTransfer));
                    return;
                case "AliquotsDerivatives":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.Sample));
                    return;


            }

        }
        */
    }
}
