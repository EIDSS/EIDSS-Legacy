Imports System.Threading
Imports bv.common.Configuration
Imports EIDSS.model.Core

Public Enum NotificationMode
    NoWait
    WaitReplaySync
    WaitReplayAsync
End Enum
Public Class NotificationManager
    Shared timer As System.Threading.Timer
    Shared NotificationRequestsQueue As New ArrayList
    Protected m_DBService As EmNotify_DB
    Private m_ReplicationClient As ForcedReplicationClient
    Private m_credentials As ConnectionCredentials
    Private m_Config As ServiceConfiguration

    Public Sub New(Optional ByVal credentials As ConnectionCredentials = Nothing, Optional ByVal config As ServiceConfiguration = Nothing)

        If credentials Is Nothing Then
            m_credentials = New ConnectionCredentials()
        Else
            m_credentials = credentials
        End If
        If config Is Nothing Then
            config = New ServiceConfiguration()
        End If
        m_Config = config
        m_DBService = New EmNotify_DB(m_credentials, m_Config.ClientID)
        m_ReplicationClient = New ForcedReplicationClient(m_credentials, m_Config.ClientID)
        m_ReplicationClient.RoutineJobName = m_Config.RoutineJobName
        m_ReplicationClient.IsNotificationService = True
    End Sub

    Public ReadOnly Property IsValid As Boolean
        Get
            Return Not m_DBService Is Nothing AndAlso m_DBService.IsValid
        End Get
    End Property
    Public Function CreateNotification(ByVal aType As NotificationType, ByVal data As Object, diagnosisId As Object, idfsSite As Object, Optional idfUser As Object = Nothing) As Object
        Dim id As Object = Nothing
        Dim sourceObjectId As Object = Nothing
        Dim targetSiteID As Object = Nothing
        Select Case aType
            Case NotificationType.HumanCase, _
                 NotificationType.HumanCaseDiagnosisChange, _
                 NotificationType.HumanCaseClassificationChange, _
                 NotificationType.HumanCaseTestResultRegistration, _
                 NotificationType.HumanCaseTestResultAmendment, _
                 NotificationType.HumanCaseReopened, _
                 NotificationType.Outbreak, _
                 NotificationType.OutbreakNewHumanCaseAddition, _
                 NotificationType.OutbreakNewVetCaseAddition, _
                 NotificationType.OutbreakNewVsSessionAddition, _
                 NotificationType.OutbreakStatusChange, _
                 NotificationType.OutbreakPrimaryCaseChange, _
                 NotificationType.VetCase, _
                 NotificationType.VetCaseDiagnosisChange, _
                 NotificationType.VetCaseClassificationChange, _
                 NotificationType.VetCaseFieldTestResultRegistration, _
                 NotificationType.VetCaseTestResultRegistration, _
                 NotificationType.VetCaseTestResultAmendment, _
                 NotificationType.VetCaseReopened, _
                 NotificationType.VsSession, _
                 NotificationType.VsSessionDiagnosisDetection, _
                 NotificationType.VsSessionFieldTestResultRegistration, _
                 NotificationType.VsSessionTestResultRegistration, _
                 NotificationType.VsSessionTestResultAmendment, _
                 NotificationType.AsCampaign, _
                 NotificationType.AsSession, _
                 NotificationType.AsCampaignStatusChange, _
                 NotificationType.AsSessionReopened, _
                 NotificationType.AsSessionTestResultRegistration, _
                 NotificationType.AsSessionTestResultAmendment, _
                 NotificationType.HumanAggregateCase, _
                 NotificationType.HumanAggregateCaseChange, _
                 NotificationType.VetAggregateCase, _
                 NotificationType.VetAggregateCaseChange, _
                 NotificationType.VetAggregateAction, _
                 NotificationType.VetAggregateActionChange, _
                 NotificationType.BssForm, _
                 NotificationType.BssAggregateForm
                sourceObjectId = CType(data, Long)
                Dim payLoadData As String = Nothing
                If (Not Utils.IsEmpty(diagnosisId)) Then
                    payLoadData = diagnosisId.ToString()
                End If
                id = m_DBService.CreateNotification(aType, CType(data, Long), 0, payLoadData, idfsSite)
            Case NotificationType.NewSampleTransferIn
                sourceObjectId = CType(data, Long)
                targetSiteID = EmNotify_DB.GetTransferedSampleSite(CLng(sourceObjectId))
                id = m_DBService.CreateNotification(aType, CType(data, Long), 0, Nothing, idfsSite, targetSiteID)
            Case NotificationType.TestResultForSampleTransferredOut
                sourceObjectId = CType(data, Long)
                targetSiteID = EmNotify_DB.GetTestSampleSite(CLng(sourceObjectId))
                id = m_DBService.CreateNotification(aType, CType(data, Long), 0, Nothing, idfsSite, targetSiteID)
            Case NotificationType.AVRLayoutPublish, _
                 NotificationType.AVRLayoutUnpublished, _
                 NotificationType.AVRLayoutFolderPublished, _
                 NotificationType.AVRLayoutFolderUnpublished, _
                 NotificationType.AVRQueryPublished, _
                 NotificationType.AVRQueryUnpublished
                sourceObjectId = GetPublisedObjectId(aType, CType(data, Long))
                If (CLng(sourceObjectId) > 0) Then
                    id = m_DBService.CreateNotification(aType, CLng(sourceObjectId), 0, Nothing, idfsSite)
                End If
            Case NotificationType.SettlementChanged, _
                NotificationType.AggregateSettingsChange, _
                NotificationType.SecurityPolicyChange, _
                NotificationType.FFTemplateChange, _
                NotificationType.FFTemplateDeterminantChange
                id = m_DBService.CreateNotification(aType, CType(data, Long), 0, Nothing, idfsSite)
            Case NotificationType.ReferenceTableChanged, _
                 NotificationType.RaiseReferenceCacheChange, _
                 NotificationType.MatrixChange
                id = m_DBService.CreateNotification(aType, 0, 0, data.ToString, idfsSite)
            Case NotificationType.StartForcedReplication
                targetSiteID = EmNotify_DB.GetParentSite(CLng(idfsSite))
                If (EidssSiteContext.Instance.SiteType <> model.Enums.SiteType.CDR AndAlso Utils.IsEmpty(targetSiteID)) Then
                    Dbg.Debug("{0} site {1} have no parent site", EidssSiteContext.Instance.SiteType, idfsSite)
                End If
                If Not Utils.IsEmpty(targetSiteID) Then 'if there is no parent site, do not create event - CDR case
                    id = m_DBService.CreateNotification(aType, CLng(idfsSite), 0, Nothing, idfsSite, targetSiteID, , idfUser)
                End If

        End Select

        Return id
    End Function

    Public Shared Function GetPublisedObjectId(aType As NotificationType, ByVal localId As Long) As Long
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spAsGetGlobalIdFromLocalId", ConnectionManager.DefaultInstance.Connection)
        BaseDbService.AddParam(cmd, "@notificationType", CLng(aType))
        BaseDbService.AddParam(cmd, "@localId", localId)
        Dim errMsg As ErrorMessage = Nothing
        Dim globalId As Object = BaseDbService.ExecScalar(cmd, cmd.Connection, errMsg)
        If Utils.IsEmpty(globalId) Then
            Dbg.Debug("can't find global id for notification type {0} and local id {1}", aType.ToString(), localId)
        End If
        Return Utils.ToLong(globalId)
    End Function
End Class
