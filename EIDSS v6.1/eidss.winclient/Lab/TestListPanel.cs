using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    public partial class TestListPanel : BaseListPanel_LabTestListItem
    {
        public TestListPanel()
        {
            InitializeComponent();
            EnableMultiEdit = true;
        }

        public static void Register(Control parentControl)
        {
            RegisterItem(180, false, MenuGroup.MenuJournalsLab);
            //Toolbar menu
            RegisterItem(100320, true, MenuGroup.ToolbarLab);
        }

        private static void RegisterItem(int order, bool showInToolbar, MenuGroup group = MenuGroup.None)
        {
            if (!BaseSettings.LabSimplifiedMode)
            {
                new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                               "MenuLabTest", order, showInToolbar, (int) MenuIconsSmall.TestJournal,
                               (int) MenuIcons.TestList)
                    {
                        SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Test),
                        ShowInMenu = !showInToolbar,
                        Group = (int)group
                    };
            }
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (TestListPanel), BaseFormManager.MainForm,
                                       LabTestListItem.CreateInstance());
        }

        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            //BaseFormManager.RefreshList(bo.GetType("LabTestListItem"));
            SetActionFunction(actions, "MakeBatch", MakeBatch);
        }

        private static ActResult MakeBatch(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if ((parameters.Count > 2) && (parameters[0] != null) && (parameters[2] != null))
            {
                var s = (TestListPanel) parameters[2];
                IList<IObject> selectedItems = s.SelectedItems;

                // Validation - no one test have batch
                bool isValidSelection = ValidateSelectedTests(selectedItems);
                if (isValidSelection == false)
                    return false;

                // Validation - all tests have same TestName 
                string testName = GetTypeTests(selectedItems);
                if (testName == "")
                    return false;

                var currentPanel = ((Control) parameters[2]);

                object batch = ClassLoader.LoadClass("BatchDetail");

                object batchId = null;

                FieldInfo settingProperty = batch.GetType().GetField("AddedTests");

                settingProperty.SetValue(batch, selectedItems.ToArray());

                BaseFormManager.ShowModal(batch as IApplicationForm, currentPanel.FindForm(), ref batchId, null,
                                          null);

                BaseFormManager.RefreshList(bo.GetType().Name);
                return true;
            }

            return true;
        }

        private static bool ValidateSelectedTests(IEnumerable<IObject> selectedItems)
        {
            //object key = selectedItems.Select(m => m.GetValue("idfBatchTest"));
            foreach (LabTestListItem test in selectedItems)
            {
                if (test.GetValue("idfBatchTest") != null)
                {
                    MessageForm.Show(EidssMessages.Get("msgTestsHaveBatches",
                                                       "Some tests already assigned to batches"));
                    return false;
                }
                if(!((long)TestStatus.NotStarted).Equals(test.GetValue("idfsTestStatus")))
                {
                    MessageForm.Show(EidssMessages.Get("msgIncorrectTestStatusForBatch",
                                                       "Only tests with Undefined status can be added to a batch"));
                    return false;
                }
            }
            return true;
        }

        private static string GetTypeTests(IList<IObject> selectedItems)
        {
            string testType = selectedItems[0].GetValue("idfsTestName").ToString();
            foreach (LabTestListItem test in selectedItems)
            {
                if (testType != test.GetValue("idfsTestName").ToString())
                {
                    MessageForm.Show(EidssMessages.Get("msgTestsMustBeSame",
                                                       "Only tests of the same type can be added to a batch."));
                    return "";
                }
            }
            return testType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <param name="actionType"></param>
        /// <param name="readOnly"></param>
        public override IApplicationForm Edit(object key, List<object> parameters, ActionTypes actionType, bool readOnly)
        {
            if (key is List<Object>)
            {
                long? testType = null;
                foreach (IObject bo in SelectedItems)
                {
                    if (testType == null)
                        testType = (long)bo.GetValue("idfsTestName");
                    if (!((long)bo.GetValue("idfsTestName")).Equals(testType) ||
                        !((long) TestStatus.NotStarted).Equals(bo.GetValue("idfsTestStatus")))
                    {
                        ErrorForm.ShowMessageDirect(EidssMessages.Get("errInvalidMultiTestSelection"));
                        return null;
                    }
                }
            }
            return base.Edit(key, parameters, actionType, readOnly);
        }
        /*perm!!
        public override void CheckActionPermission(ActionMetaItem action, ref bool showAction)
        {
            switch (action.Name)
            {
                case "MakeBatch":
                    showAction = showAction &&
                                 EidssUserContext.User.HasPermission(
                                     PermissionHelper.UpdatePermission(EIDSSPermissionObject.Test));
                    return;
            }
        }
        */
        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var item = ((LabTestListItem) FocusedItem);
                EidssSiteContext.ReportFactory.LimTestResult(item.idfTesting, item.idfObservation,
                                                             item.idfsTestName ?? 0);
            }
        }
        protected override void HidePersonalData(List<LabTestListItem> list)
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

    }
}