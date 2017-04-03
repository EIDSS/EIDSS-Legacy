using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Schema;
using System.Data;
using System.Linq;
using eidss.model.Core;


namespace eidss.winclient.Lab
{
    public partial class SampleListPanel : BaseListPanel_LabSampleListItem
    {
        private ContextMenu m_ReportMenu;
        private MenuItem m_sampleDestructionReportIem;
        public SampleListPanel()
        {
            InitializeComponent();

            m_ReportMenu = new ContextMenu();
            var sampleReportIem = new MenuItem(EidssMessages.Get("rptSampleReport"));
            sampleReportIem.Click += ShowSampleReport;
            m_sampleDestructionReportIem = new MenuItem(EidssMessages.Get("rptSampleDestructionReport"));
            m_sampleDestructionReportIem.Click += ShowSampleDestructionReport;
            m_ReportMenu.MenuItems.Add(sampleReportIem);
            m_ReportMenu.MenuItems.Add(m_sampleDestructionReportIem);
        }

        private void ShowSampleDestructionReport(object sender, EventArgs e)
        {
            if (FocusedItem != null)
            {
                var item = ((LabSampleListItem)FocusedItem);
                EidssSiteContext.ReportFactory.LimSampleDestruction(new []{item.idfMaterial});
            }
        }

        private void ShowSampleReport(object sender, EventArgs e)
        {
            if (FocusedItem != null)
            {
                var item = ((LabSampleListItem)FocusedItem);
                EidssSiteContext.ReportFactory.LimSample(item.idfMaterial);
            }
        }

        public override string GetDetailFormName(IObject o)
        {
            return "SampleDetail";
        }

        public static void Register(Control parentControl)
        {
            RegisterItem(165, false, false,MenuGroup.MenuJournalsLab);
            //Toolbar menu
            RegisterItem(100310, true, false, MenuGroup.ToolbarLab);
        }

        private static void RegisterItem(int order, bool showInToolbar, bool beginGroup, MenuGroup group = MenuGroup.None)
        {
            if (!BaseSettings.LabSimplifiedMode)
            {
                new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                               "MenuSample", order, showInToolbar, (int) MenuIconsSmall.SampleJournal,
                               (int) MenuIcons.SampleList)
                    {
                        SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Sample),
                        BeginGroup = beginGroup,
                        ShowInMenu = !showInToolbar,
                        Group = (int)group
                    };
            }
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(SampleListPanel), BaseFormManager.MainForm,
                                       LabSampleListItem.CreateInstance());
        }

        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var item = ((LabSampleListItem)FocusedItem);
                m_sampleDestructionReportIem.Visible = item.idfsSampleStatus == (long) SampleStatus.RoutineDestruction ||
                                                       item.idfsSampleStatus == (long) SampleStatus.Destroyed;
            }
            else
            {
                m_sampleDestructionReportIem.Visible = false;
            }
            var menu = new PopupMenuWrapper(m_ReportMenu);
            {
                menu.ShowPopup(MousePosition);
            }
            //if (FocusedItem != null)
            //{
            //    var item = ((LabSampleListItem)FocusedItem);
            //    EidssSiteContext.ReportFactory.LimContainerDetails(item.idfMaterial);
            //}
        }
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "SelectTest", SelectTest);
            SetActionFunction(actions, "MarkForDisposition", MarkForDisposition);
            SetActionFunction(actions, "TransferOut", TransferOut);
            SetActionFunction(actions, "AliquotsDerivatives", AliquotsDerivatives);
            SetActionFunction(actions, "HumanAccessionIn", HumanAccessionIn);
            SetActionFunction(actions, "VetAccessionIn", VetAccessionIn);
            SetActionFunction(actions, "AsAccessionIn", AsAccessionIn);
            SetActionFunction(actions, "VsAccessionIn", VsAccessionIn);
            SetActionFunction(actions, "GroupAccessionIn", GroupAccessionIn);
            SetActionFunction(actions, "DeleteSample", DeleteSample);

        }

        private ActResult DeleteSample(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            return parameters[0] != null && WinUtils.ConfirmDelete();
        }

        private static ActResult SelectTest(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (parameters[0] != null)
            {
                var s = parameters[2] as SampleListPanel;
                var selectedItems = s.SelectedItems;

                var currentPanel = ((Control)parameters[2]);

                object selectTestForm = ClassLoader.LoadClass("AssignTestsList");

                object key = selectedItems;

                BaseFormManager.ShowModal(selectTestForm as IApplicationForm, currentPanel.FindForm(), ref key, null, null, 900, 600);
                //BaseFormManager.RefreshList(bo.GetType().Name);
                //BaseFormManager.RefreshList(bo.GetType("LabTestListItem"));

                return true;
            }

            return false;
        }

        private static ActResult MarkForDisposition(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (parameters[0] != null)
            {
                var s = parameters[2] as SampleListPanel;
                if (s == null)
                    return false;
                var selectedItems = s.SelectedItems;
                if (selectedItems==null || selectedItems.Count == 0)
                    return false;

                var currentPanel = ((Control)parameters[2]);
                object key = selectedItems;
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

                    var p = parameters[2] as SampleListPanel;//bv.winclient.BasePanel.BaseGridPanel<eidss.model.Schema.LabSampleListItem>;
                    //var key = p.SelectedItems;
                    var selectedItems = p.SelectedItems;

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
                    var p = parameters[2] as bv.winclient.BasePanel.BaseGridPanel<eidss.model.Schema.LabSampleListItem>;
                    object key = p.SelectedItems;

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

        private static ActResult HumanAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            var isAccessioned = AccessionIn(parameters, new object[] { HACode.Human, SessionType.None });
            //BaseFormManager.RefreshList(bo.GetType().Name);
            return isAccessioned;
        }

        private static ActResult VetAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            var isAccessioned = AccessionIn(parameters, new object[] { HACode.Avian | HACode.Livestock, SessionType.None });
            //BaseFormManager.RefreshList(bo.GetType().Name);
            return isAccessioned;
        }

        private static ActResult AsAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters)
        {

            //return AccessionIn(parameters, new object[] {HACode.Animal | HACode.Livestock, false});
            var isAccessioned = AccessionIn(parameters, new object[] { HACode.Livestock, SessionType.AsSession });
            //BaseFormManager.RefreshList(bo.GetType().Name);
            return isAccessioned;

        }

        private static ActResult VsAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters)
        {

            //return AccessionIn(parameters, new object[] {HACode.Animal | HACode.Livestock, false});
            var isAccessioned = AccessionIn(parameters, new object[] { HACode.Vector, SessionType.VsSession });
            //BaseFormManager.RefreshList(bo.GetType().Name);
            return isAccessioned;

        }

        private static ActResult GroupAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters)
        {

            //return AccessionIn(parameters, new object[] {HACode.Animal | HACode.Livestock, false});
            var isAccessioned = GroupAccessionIn(parameters, new object[] { HACode.Vector, SessionType.VsSession });
           // BaseFormManager.RefreshList(bo.GetType().Name);
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

            BaseFormManager.ShowModal((IApplicationForm)checkIn, currentPanel.FindForm());

            return true;
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
            BaseFormManager.ShowModal((IApplicationForm)checkIn, currentPanel.FindForm());

            return true;
        }

        private void Reflect()
        {

            //var allow = false
            //if (!(cbStatus.EditValue Is Nothing)) And (cbStatus.EditValue.ToString = Condition.ToString) 
            //allow = true
            //this. Me.btnAliquots.Enabled = Me.CreateRight And allow
            //Me.btnDestroy.Enabled = Me.DeleteRight And allow
            //Me.btnAssignTest.Enabled = Me.TestRight And allow
            //Me.btnTransfer.Enabled = Me.TransferRight And allow
        }
        protected override void HidePersonalData(List<LabSampleListItem> list)
        {
            bool hideFarmOwner =
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details) ||
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement);
            bool hidePatient =
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName);

            if (hideFarmOwner || hidePatient)
            {
                foreach (var item in list)
                {

                    if (hideFarmOwner && (((long)CaseTypeEnum.Avian).Equals(item.idfsCaseType) ||
                            ((long)CaseTypeEnum.Livestock).Equals(item.idfsCaseType)))
                        item.HumanName = "*";
                    if (hidePatient && ((long)CaseTypeEnum.Human).Equals(item.idfsCaseType))
                        item.HumanName = "*";
                }
            }
        }

        //private static bool AliquotsDerivatives(List<object> actionParameters, object[] invokeParams)
        //{
        //    if (!(actionParameters[2] is Control))
        //    {
        //        throw new TypeMismatchException("listPanel", typeof(Control));
        //    }
        //    var currentPanel = ((Control)actionParameters[2]);
        //    object checkIn = ClassLoader.LoadClass("SamplesCheckIn");
        //    ReflectionHelper.InvokeMethod(checkIn, "Init", invokeParams);
        //    BaseFormManager.ShowModal((IApplicationForm)checkIn, currentPanel.FindForm());
        //    return true;
        //}
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
                    showAction = showAction && 
                        EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
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
