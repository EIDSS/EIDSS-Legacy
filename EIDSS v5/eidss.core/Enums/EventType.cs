﻿
namespace eidss.model.Enums
{
    public enum EventType : long
    {
        None = 0,
        ClientUILanguageChanged = 10025001,
        ReferenceTableChanged = 10025002,
        TestResultsReceived = 10025003,
        NotificationServiceIsNotRunning = 10025004,
        CaseDiseaseChange = 10025005,
        CaseDiseaseChangedNotification = 10025006,
        CaseStatusChange = 10025007,
        CaseStatusChangedNotification = 10025008,
        DefaultEventType = 10025009,
        NewHumanCase = 10025010,
        NewReferral = 10025011,
        NewTestRequest = 10025012,
        NewTestResult = 10025013,
        NewVetCase = 10025014,
        NotificationReplicationRequest = 10025015,
        NewOutbreak = 10025016,
        OutbreakNotificationFail = 10025017,
        OutbreakNotificationReceived = 10025018,
        OutbreakNotificationRetrying = 10025019,
        OutbreakNotificationSending = 10025020,
        OutbreakNotificationSucceeded = 10025021,
        ReplicationFailed = 10025022,
        ReplicationRequestedByUser = 10025023,
        ReplicationRetrying = 10025024,
        ReplicationStarted = 10025025,
        ReplicationSucceeded = 10025026,
        ApplicationExit = 10025027,
        EIDSSDBdisconnect = 10025028,
        AVRLayoutUpdate = 10025029,
        SettlementChanged = 10025030,
        HumanCaseNotification = 10025031,
        VetCaseNotification = 10025032,
        StatisticImport = 10025033,
        NewTestAmendment = 10025034,
        TestAmendmentNotification = 10025035,
        ObjectRestoring = 10025036
    }
}