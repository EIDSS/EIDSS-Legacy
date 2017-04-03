
using System;

namespace eidss.model.Enums
{
    //Suffics Local means that event is created on current site and shall be raised during object saving
    //After this Notification service will raise correspondent notification event
    //Suffics Remote means that notification event come from other site and event shall be raised by notification service. 
    // Events marked with //local comment are raised by applications
    // Events marked with //remote comment are raised by notification service as response to received notification

    public enum EventType : long
    {
        None = 0,
        ClientUILanguageChanged = 10025001, //local
        SettlementChanged = 10025030,//local 
        HumanCaseCreatedLocal = 10025037,//local
        HumanCaseCreatedRemote = 10025038,//remote
        HumanCaseDiagnosisChangedLocal = 10025039,//local
        HumanCaseDiagnosisChangedRemote = 10025040,//remote
        HumanCaseClassificationChangedLocal = 10025041,//local
        HumanCaseClassificationChangedRemote = 10025042,//remote
        HumanTestResultRegistrationLocal = 10025043,//local
        HumanTestResultRegistrationRemote = 10025044,//remote
        HumanTestResultAmendmentLocal = 10025045,//local
        HumanTestResultAmendmentRemote = 10025046,//remote
        ClosedHumanCaseReopenedLocal = 10025047,//local
        ClosedHumanCaseReopenedRemote = 10025048,//remote
        OutbreakCreatedLocal = 10025049,//local
        OutbreakCreatedRemote = 10025050,//remote
        NewHumanCaseAddedToOutbreakLocal = 10025051,//local
        NewHumanCaseAddedToOutbreakRemote = 10025052,//remote
        NewVetCaseAddedToOutbreakLocal = 10025053,//local
        NewVetCaseAddedToOutbreakRemote = 10025054,//remote
        NewVsSessionAddedToOutbreakLocal = 10025055,//local
        NewVsSessionAddedToOutbreakRemote = 10025056,
        OutbreakStatusChangedLocal = 10025057,//local
        OutbreakStatusChangedRemote = 10025058,//remote
        OutbreakPrimaryCaseChangedLocal = 10025059,//local
        OutbreakPrimaryCaseChangedRemote = 10025060,//remote
        VetCaseCreatedLocal = 10025061,//local
        VetCaseCreatedRemote = 10025062,//remote
        VetCaseDiagnosisChangedLocal = 10025063,//local
        VetCaseDiagnosisChangedRemote = 10025064,//remote
        VetCaseClassificationChangedLocal = 10025065,//local
        VetCaseClassificationChangedRemote = 10025066,//remote
        VetCaseFieldTestResultRegistrationLocal = 10025067,//local
        VetCaseFieldTestResultRegistrationRemote = 10025068,//remote
        VetCaseTestResultRegistrationLocal = 10025069,//local
        VetCaseTestResultRegistrationRemote = 10025070,//remote
        VetCaseTestResultAmendmentLocal = 10025071,//local
        VetCaseTestResultAmendmentRemote = 10025072,
        ClosedVetCaseReopenedLocal = 10025073,//local
        ClosedVetCaseReopenedRemote = 10025074,//remote
        VsSessionCreatedLocal = 10025075,//local
        VsSessionCreatedRemote = 10025076,//remote
        VsSessionNewDiagnosisLocal = 10025077,//local
        VsSessionNewDiagnosisRemote = 10025078,//remote
        VsSessionFieldTestResultRegistrationLocal = 10025079,//local
        VsSessionFieldTestResultRegistrationRemote = 10025080,//remote
        VsSessionTestResultRegistrationLocal = 10025081,//local
        VsSessionTestResultRegistrationRemote = 10025082,//remote
        VsSessionTestResultAmendmentLocal = 10025083,//local
        VsSessionTestResultAmendmentRemote = 10025084,//remote
        AsCampaignCreatedLocal = 10025085,//local
        AsCampaignCreatedRemote = 10025086,//remote
        AsSessionCreatedLocal = 10025087,//local
        AsSessionCreatedRemote = 10025088,//remote
        AsCampaignStatusChangedLocal = 10025089,//local
        AsCampaignStatusChangedRemote = 10025090,//remote
        ClosedAsSessionReopenedLocal = 10025091,//local
        ClosedAsSessionReopenedRemote = 10025092,//remote
        AsSessionTestResultRegistrationLocal = 10025093,//local
        AsSessionTestResultRegistrationRemote = 10025094,
        AsSessionTestResultAmendmentLocal = 10025095,//local
        AsSessionTestResultAmendmentRemote = 10025096,//remote
        HumanAggregateCaseCreatedLocal = 10025097,//local
        HumanAggregateCaseCreatedRemote = 10025098,//remote
        HumanAggregateCaseChangedLocal = 10025099,//local
        HumanAggregateCaseChangedRemote = 10025100,//remote
        VetAggregateCaseCreatedLocal = 10025101,//local
        VetAggregateCaseCreatedRemote = 10025102,//remote
        VetAggregateCaseChangedLocal = 10025103,//local
        VetAggregateCaseChangedRemote = 10025104,//remote
        VetAggregateActionCreatedLocal = 10025105,//local
        VetAggregateActionCreatedRemote = 10025106,//remote
        VetAggregateActionChangedLocal = 10025107,//local
        VetAggregateActionChangedRemote = 10025108,//remote
        ReplicationRequestedByUser = 10025109,//local
        ReplicationStarted = 10025110,//local
        ReplicationFailed = 10025111,//local
        ReplicationRetrying = 10025112,//local
        ReplicationSucceeded = 10025113,//local
        NotificationServiceIsNotRunning = 10025114,//local
        AVRLayoutPublishedLocal = 10025115,//local
        AVRLayoutPublishedRemote = 10025116,//remote
        AVRLayoutShared = 10025117,//local
        AggregateSettingsChanged = 10025118,//local //remote
        SecurityPolicyChanged = 10025119,//local //remote
        FFUNITemplateChanged = 10025120,//local //remote
        FFDeterminantChanged = 10025121,//local //remote
        ReferenceTableChanged = 10025122,//local //remote
        MatrixChanged = 10025123,//local //remote
        RaiseReferenceCacheChange = 10025124,//local //remote
        NewSampleTransferIn = 10025125,//remote
        TestResultForSampleTransferredOut = 10025126, //remote event for TestResultForSampleTransferredIn
        BssFormLocal = 10025127,//local
        BssFormRemote = 10025128,//remote
        BssAggregateFormLocal = 10025129,//local
        BssAggregateFormRemote = 10025130,//remote
        NewSampleTransferInLocal = 10025131,//local
        AVRLayoutUnpublishedLocal = 10025132,//local
        AVRLayoutUnpublishedRemote = 10025133,//remote
        AVRLayoutFolderPublishedLocal = 10025134,//local
        AVRLayoutFolderPublishedRemote = 10025135,//remote
        AVRLayoutFolderUnpublishedLocal = 10025136,//local
        AVRLayoutFolderUnpublishedRemote = 10025137,//remote
        AVRQueryPublishedLocal = 10025138,//local
        AVRQueryPublishedRemote = 10025139,//remote
        AVRQueryUnpublishedLocal = 10025140,//local
        AVRQueryUnpublishedRemote = 10025141,//remote
        TestResultForSampleTransferredIn = 10025142, //local event for TestResultForSampleTransferredOut
        ForcedReplicationConfirmed = 10025143, //remote
        ForcedReplicationExpired = 10025144 //remote
    }
    //After adding new event recheck that function fnEventLog_GetObjectType and procedure spEventLog_EventForObjectExists
    //process this event type correctly, in other case event will not be created
}