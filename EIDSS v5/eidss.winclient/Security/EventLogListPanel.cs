using System;
using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;
using bv.common.Diagnostics;

namespace eidss.winclient.Security
{
    public partial class EventLogListPanel : BaseListPanel_EventLogListItem
    {
        public EventLogListPanel()
        {
            InitializeComponent();
        }

        public static void Register(Control parentControl)
        {
            if (BaseFormManager.ArchiveMode)
                return;
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Security,
                           "MenuEvent", 1055, false, (int) MenuIconsSmall.EventLog,
                           -1)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.EventLog),
                    ShowInMenu = true,
                };
        }

        public override IApplicationForm Edit(object key, List<object> parameters, ActionTypes actionType, bool readOnly)
        {
            if (!(parameters[1] is EventLogListItem))
            {
                throw new TypeMismatchException("parameters[1]", typeof (EventLogListItem));
            }
            var item = ((EventLogListItem) parameters[1]);
            if (Utils.IsEmpty(item.idfsEventTypeID))
            {
                return null;
            }


            long caseType = item.idfsCaseType ?? -1;
            long idfObjectID = item.idfObjectID ?? -1;
            var aEventType = (EventType)(Enum.Parse(typeof(EventType), item.idfsEventTypeID.ToString()));


            if (!ShowEventDetail(key, caseType, idfObjectID, aEventType))
                ErrorForm.ShowMessage("msgNoDetails", "msgNoDetails");
            return null;
        }

        public override List<object> GetParamsAction()
        {
            return FocusedItem == null
                       ? null
                       : new List<object> {FocusedItem.Key, FocusedItem, this};
        }

        public override void ShowReport()
        {
            EidssSiteContext.ReportFactory.AdmEventLog();
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (EventLogListPanel), BaseFormManager.MainForm,
                                       EventLogListItem.CreateInstance());
        }

        private static bool ShowEventDetail(object key, long caseType, long idfObjectID, EventType eventType)
        {
            string formName = null;

            switch (caseType)
            {
                case 1:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Outbreak)))
                        return false;
                    formName = "OutbreakDetail";
                    break;
                case (long)CaseTypeEnum.Human:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase)))
                        return false;
                    formName = "HumanCaseDetail";
                    break;
                case (long)CaseTypeEnum.Avian:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase)))
                        return false;
                    formName = "VetCaseAvianDetail";
                    break;
                case (long)CaseTypeEnum.Livestock:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase)))
                        return false;
                    formName = "VetCaseLiveStockDetail";
                    break;
                default:
                     switch (eventType)
                    {
                        case EventType.NewOutbreak:
                        case EventType.OutbreakNotificationReceived:
                            if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Outbreak)))
                                return false;
                            formName = "OutbreakDetail";
                            break;
                        case EventType.NewTestRequest:
                        case EventType.NewTestResult:
                        case EventType.TestResultsReceived:
                        case EventType.NewTestAmendment:
                        case EventType.TestAmendmentNotification:
                            if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Test)))
                                return false;
                            formName = "LabTestDetail";
                            break;
                    }
                    break;
            }
            if (formName != null)
            {
                object form = ClassLoader.LoadClass(formName);
                Dbg.Assert(form != null, "form {0} is not loaded by reflection", formName);
                object id = idfObjectID;
                if (ReflectionHelper.HasProperty(form, "ReadOnly"))
                    ReflectionHelper.SetProperty(form, "ReadOnly", true);
                BaseFormManager.ShowNormal(((IApplicationForm)form), ref id);
                return true;
            }
            return false;

        }
        public static void ShowEventDetail(object key)
        {
            long idfObject;
            EventType eventType;
            long caseType = EventLogList.GetCaseType((long)key, out eventType, out idfObject);
            ShowEventDetail(key, caseType, idfObject, eventType);
        }
    }
}