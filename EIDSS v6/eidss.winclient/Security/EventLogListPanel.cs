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
                           "MenuEvent", 1055, false, (int)MenuIconsSmall.EventLog,
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
                throw new TypeMismatchException("parameters[1]", typeof(EventLogListItem));
            }
            var item = ((EventLogListItem)parameters[1]);
            if (Utils.IsEmpty(item.idfsEventTypeID))
            {
                return null;
            }


            long caseType = item.idfsCaseType ?? -1;
            long idfObjectID = item.idfObjectID ?? -1;
            var aEventType = (EventType)(Enum.Parse(typeof(EventType), item.idfsEventTypeID.ToString()));

            if (!ShowEventDetail(key, caseType, idfObjectID, aEventType, item.strInformationString))
                ErrorForm.ShowMessage("msgNoDetails", "msgNoDetails");
            return null;
        }

        public override List<object> GetParamsAction()
        {
            return FocusedItem == null
                       ? null
                       : new List<object> { FocusedItem.Key, FocusedItem, this };
        }

        public override void ShowReport()
        {
            EidssSiteContext.ReportFactory.AdmEventLog();
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(EventLogListPanel), BaseFormManager.MainForm,
                                       EventLogListItem.CreateInstance());
        }

        private static bool ShowEventDetail(object key, long caseType, long idfObjectID, EventType eventType, string infoString)
        {
            string formName = null;
            Dictionary<string, object> startupParams = null;
            switch (eventType)
            {

                case EventType.OutbreakCreatedLocal:
                case EventType.OutbreakCreatedRemote:
                case EventType.OutbreakPrimaryCaseChangedLocal:
                case EventType.OutbreakPrimaryCaseChangedRemote:
                case EventType.OutbreakStatusChangedLocal:
                case EventType.OutbreakStatusChangedRemote:
                case EventType.NewHumanCaseAddedToOutbreakLocal:
                case EventType.NewHumanCaseAddedToOutbreakRemote:
                case EventType.NewVetCaseAddedToOutbreakLocal:
                case EventType.NewVetCaseAddedToOutbreakRemote:
                case EventType.NewVsSessionAddedToOutbreakLocal:
                case EventType.NewVsSessionAddedToOutbreakRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Outbreak)))
                        return false;
                    formName = "OutbreakDetail";
                    break;

                case EventType.HumanCaseClassificationChangedLocal:
                case EventType.HumanCaseClassificationChangedRemote:
                case EventType.HumanCaseCreatedLocal:
                case EventType.HumanCaseCreatedRemote:
                case EventType.HumanCaseDiagnosisChangedLocal:
                case EventType.HumanCaseDiagnosisChangedRemote:
                case EventType.ClosedHumanCaseReopenedLocal:
                case EventType.ClosedHumanCaseReopenedRemote:
                case EventType.HumanTestResultAmendmentLocal:
                case EventType.HumanTestResultAmendmentRemote:
                case EventType.HumanTestResultRegistrationLocal:
                case EventType.HumanTestResultRegistrationRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase)))
                        return false;
                    formName = "HumanCaseDetail";
                    break;

                case EventType.VetCaseClassificationChangedLocal:
                case EventType.VetCaseClassificationChangedRemote:
                case EventType.VetCaseCreatedLocal:
                case EventType.VetCaseCreatedRemote:
                case EventType.VetCaseDiagnosisChangedLocal:
                case EventType.VetCaseDiagnosisChangedRemote:
                case EventType.ClosedVetCaseReopenedLocal:
                case EventType.ClosedVetCaseReopenedRemote:
                case EventType.VetCaseTestResultAmendmentLocal:
                case EventType.VetCaseTestResultAmendmentRemote:
                case EventType.VetCaseTestResultRegistrationLocal:
                case EventType.VetCaseTestResultRegistrationRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase)))
                        return false;
                    if (caseType == (long)CaseTypeEnum.Avian)
                        formName = "VetCaseAvianDetail";
                    else
                        formName = "VetCaseLiveStockDetail";
                    break;

                case EventType.AsCampaignCreatedLocal:
                case EventType.AsCampaignCreatedRemote:
                case EventType.AsCampaignStatusChangedLocal:
                case EventType.AsCampaignStatusChangedRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Campaign)))
                        return false;
                    formName = "AsCampaignDetail";
                    break;
                case EventType.AsSessionCreatedLocal:
                case EventType.AsSessionCreatedRemote:
                case EventType.AsSessionTestResultAmendmentLocal:
                case EventType.AsSessionTestResultAmendmentRemote:
                case EventType.AsSessionTestResultRegistrationLocal:
                case EventType.AsSessionTestResultRegistrationRemote:
                case EventType.ClosedAsSessionReopenedLocal:
                case EventType.ClosedAsSessionReopenedRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.MonitoringSession)))
                        return false;
                    formName = "AsSessionDetail";
                    break;

                case EventType.VsSessionCreatedLocal:
                case EventType.VsSessionCreatedRemote:
                case EventType.VsSessionTestResultAmendmentLocal:
                case EventType.VsSessionTestResultAmendmentRemote:
                case EventType.VsSessionTestResultRegistrationLocal:
                case EventType.VsSessionTestResultRegistrationRemote:
                case EventType.VsSessionFieldTestResultRegistrationLocal:
                case EventType.VsSessionFieldTestResultRegistrationRemote:
                case EventType.VsSessionNewDiagnosisLocal:
                case EventType.VsSessionNewDiagnosisRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VsSession)))
                        return false;
                    formName = "VsSessionDetail";
                    break;
                case EventType.HumanAggregateCaseChangedLocal:
                case EventType.HumanAggregateCaseChangedRemote:
                case EventType.HumanAggregateCaseCreatedLocal:
                case EventType.HumanAggregateCaseCreatedRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase)))
                        return false;
                    formName = "AggregateCaseDetail";
                    break;
                case EventType.VetAggregateCaseChangedLocal:
                case EventType.VetAggregateCaseChangedRemote:
                case EventType.VetAggregateCaseCreatedLocal:
                case EventType.VetAggregateCaseCreatedRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase)))
                        return false;
                    formName = "VetAggregateCaseDetail";
                    break;

                case EventType.VetAggregateActionChangedLocal:
                case EventType.VetAggregateActionChangedRemote:
                case EventType.VetAggregateActionCreatedLocal:
                case EventType.VetAggregateActionCreatedRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase)))
                        return false;
                    formName = "VetAggregateActionDetail";
                    break;

                case EventType.NewSampleTransferInLocal:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Sample)))
                        return false;
                    formName = "SampleTransferDetail";
                    break;

                case EventType.NewSampleTransferIn:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Sample)))
                        return false;
                    formName = "SampleTransferDetail";
                    break;

                case EventType.TestResultForSampleTransferredOut:
                case EventType.TestResultForSampleTransferredIn:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Test)))
                        return false;
                    formName = "LabTestDetail";
                    break;

                case EventType.BssFormLocal:
                case EventType.BssFormRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Test)))
                        return false;
                    formName = "BasicSyndromicSurveillanceItemDetail";
                    break;

                case EventType.BssAggregateFormLocal:
                case EventType.BssAggregateFormRemote:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Test)))
                        return false;
                    formName = "BasicSyndromicSurveillanceAggregateHeaderDetail";
                    break;

                case EventType.AVRLayoutPublishedLocal:
                case EventType.AVRLayoutPublishedRemote:
                case EventType.AVRLayoutShared:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.AVRReport)))
                        return false;
                    formName = "AvrMainForm";
                    break;
                case EventType.AggregateSettingsChanged:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.AggregateSettings)))
                        return false;
                    formName = "AggregateSettingsDetail";
                    break;
                case EventType.SecurityPolicyChanged:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.SecurityPolicy)))
                        return false;
                    formName = "SecurityPolicyDetail";
                    break;
                case EventType.FFDeterminantChanged:
                case EventType.FFUNITemplateChanged:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.FlexibleForm)))
                        return false;
                    formName = "FlexibleFormEditor";
                    startupParams = new Dictionary<string, object> { { "t", idfObjectID } };
                    break;
                case EventType.MatrixChanged:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference)))
                        return false;
                    formName = infoString;
                    break;
                case EventType.ReferenceTableChanged:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference)))
                        return false;
                    if (Utils.IsEmpty(infoString))
                        return false;
                    if (infoString.StartsWith("rft"))
                    {
                        BaseReferenceType refType;
                        if (Enum.TryParse(infoString, false, out refType))
                        {
                            startupParams = new Dictionary<string, object> {{"ReferenceType", refType}};
                        }
                        formName = "ReferenceDetail";
                    }
                    else
                    {
                        var s = infoString.Split(':');
                        formName = s[0];
                        if(s.Length==2)//now only ActionDetail form expects parameters
                            startupParams = new Dictionary<string, object> {{"ReferenceType", s[1]}};

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
                BaseFormManager.ShowNormal(((IApplicationForm)form), ref id, startupParams);
                return true;
            }
            return false;

        }

        private static string GetReferenceEditorName(string infoString)
        {
            if (infoString.StartsWith("rft"))
                return "ReferenceDetail";
            return infoString;
        }

        public static void ShowEventDetail(object key)
        {
            long idfObject;
            EventType eventType;
            string infoString;
            long caseType = EventLogList.GetEventInfo((long)key, out eventType, out idfObject, out infoString);
            ShowEventDetail(key, caseType, idfObject, eventType, infoString);
        }
    }
}