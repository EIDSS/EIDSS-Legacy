Imports bv.common.db
Imports System.Data.Common
Imports bv.common
Imports bv.common.Configuration
Imports bv.common.Enums

Public Class EmNotify_DB
    Inherits BaseDbService

    Protected m_GetNotificationAdapter As DbDataAdapter
    Protected m_NtfyCountCommand As IDbCommand
    Protected m_NtfyProcessedCommand As IDbCommand
    Protected m_CreateNotificationCommand As IDbCommand
    Protected m_SiteID As Long
    Protected m_ClientID As String
    Private ReadOnly m_SiteService As EIDSS_SiteService

    Public Sub New(Optional ByVal credentials As ConnectionCredentials = Nothing, Optional ByVal aClientId As String = Nothing)

        If Not credentials Is Nothing Then
            CreateConnection(credentials.SQLServer, credentials.SQLDatabase, credentials.SQLUser, credentials.SQLPassword, credentials.SQLConnectionString)
        End If
        m_SiteService = New EIDSS_SiteService()
        m_SiteService.SiteConnection = Connection
        m_SiteID = m_SiteService.GetRealSiteID()
        If Utils.IsEmpty(aClientId) Then
            m_ClientID = model.Core.EidssUserContext.ClientID
        Else
            m_ClientID = aClientId
        End If
    End Sub

    Public ReadOnly Property IsValid As Boolean
        Get
            Return m_SiteID > 0
        End Get
    End Property
    Private m_InProcess As Boolean = False
    Public Overridable Function GetNotificationsCount() As Integer
        If m_InProcess Then
            Return 0
        End If
        m_InProcess = True
        Try
            m_Error = Nothing
            If m_NtfyCountCommand Is Nothing Then
                m_NtfyCountCommand = CreateSPCommand("spNotification_GetCount")
                AddParam(m_NtfyCountCommand, "@idfsSite", "")
            End If
            SetParam(m_NtfyCountCommand, "@idfsSite", SiteID)
            Dim tempObjCount As Object = ExecScalar(m_NtfyCountCommand, m_NtfyCountCommand.Connection, m_Error)

            If m_Error Is Nothing Then
                Return CType(tempObjCount, Integer)
            Else
                Dbg.Debug("error during GetNotificationsCount call: {0}", m_Error.DetailError)
                Return -1
            End If
        Catch ex As Exception
            Dbg.Debug("error during GetNotificationsCount call: {0}", ex.Message)
            Return -1
        Finally
            m_InProcess = False
        End Try
    End Function

    Public Overridable Function GetNotifications() As DataSet
        m_Error = Nothing
        If m_GetNotificationAdapter Is Nothing Then
            Dim cmd As IDbCommand = CreateSPCommand("spNotification_SelectUnprocessed")
            AddParam(cmd, "@idfsSite", SiteID)
            m_GetNotificationAdapter = CreateAdapter(cmd)
        End If
        Dim retRes As New DataSet
        Try
            SyncLock (m_GetNotificationAdapter.SelectCommand.Connection)
                m_GetNotificationAdapter.Fill(retRes, "Notification")
            End SyncLock
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Trace.WriteLine(Trace.Kind.Error, "GetNotifications", ex)
            Return Nothing
        End Try
        Return retRes
    End Function

    Public Overridable Function CreateNotification(ByVal ntfType As NotificationType, ByVal objectId As Long, _
                                                   ByVal objectType As Long, ByVal ntfyData As String, _
                                                   sourceSiteID As Object, _
                                                   loginSiteID As Object, _
                                                   Optional ByVal targetSiteID As Object = Nothing, _
                                                   Optional ByVal targetSiteType As Object = Nothing, _
                                                   Optional ByVal user As Object = Nothing, _
                                                   Optional ByVal targetUser As Object = Nothing
                                                   ) As Object
        If m_CreateNotificationCommand Is Nothing Then
            m_CreateNotificationCommand = CreateSPCommand("spNotification_Create", Connection)
            StoredProcParamsCache.CreateParameters(m_CreateNotificationCommand)
        End If
        If targetSiteID Is Nothing Then
            targetSiteID = DBNull.Value
        End If
        If targetSiteType Is Nothing Then
            targetSiteType = DBNull.Value
        End If
        SetParam(m_CreateNotificationCommand, "@idfNotification", DBNull.Value)
        If (Not Utils.IsEmpty(sourceSiteID)) Then
            SetParam(m_CreateNotificationCommand, "@idfsSite", sourceSiteID)
        Else
            SetParam(m_CreateNotificationCommand, "@idfsSite", SiteID)
        End If
        If (Not Utils.IsEmpty(loginSiteID)) Then
            SetParam(m_CreateNotificationCommand, "@idfsLoginSite", loginSiteID)
        Else
            SetParam(m_CreateNotificationCommand, "@idfsLoginSite", SiteID)
        End If
        SetParam(m_CreateNotificationCommand, "@idfsNotificationType", ntfType)
        SetParam(m_CreateNotificationCommand, "@idfsTargetSite", targetSiteID)
        SetParam(m_CreateNotificationCommand, "@idfsTargetSiteType", targetSiteType)
        If (Not Utils.IsEmpty(user)) Then
            SetParam(m_CreateNotificationCommand, "@idfUserID", user)
        End If
        If (Not Utils.IsEmpty(targetUser)) Then
            SetParam(m_CreateNotificationCommand, "@idfTargetUserID", targetUser)
        End If
        SetParam(m_CreateNotificationCommand, "@strPayload", Utils.Str(ntfyData))
        If objectId > 0 Then
            SetParam(m_CreateNotificationCommand, "@idfNotificationObject", objectId)
        Else
            SetParam(m_CreateNotificationCommand, "@idfNotificationObject", DBNull.Value)
        End If
        If objectType > 0 Then
            SetParam(m_CreateNotificationCommand, "@idfsNotificationObjectType", objectType)
        Else
            SetParam(m_CreateNotificationCommand, "@idfsNotificationObjectType", DBNull.Value)
        End If
        m_Error = Nothing
        Try
            ExecCommand(m_CreateNotificationCommand, Connection, Nothing, True)
            m_ID = GetParamValue(m_CreateNotificationCommand, "@idfNotification")
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Trace.WriteLine(Trace.Kind.Error, "error during notification creation:", ex)
            Return Nothing
        End Try
        Return m_ID
    End Function

    Public Overridable Function MarkProcessed(ByVal notificationID As Long) As Boolean
        m_Error = Nothing
        If m_NtfyProcessedCommand Is Nothing Then
            m_NtfyProcessedCommand = CreateSPCommand("spNotification_Process")
        End If

        Try
            SetParam(m_NtfyProcessedCommand, "@idfNotification", notificationID)
            ExecCommand(m_NtfyProcessedCommand, m_NtfyProcessedCommand.Connection)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.SqlQueryError, ex)
            Trace.WriteLine(Trace.Kind.Error, "MarkProcessed", ex)
            Return False
        End Try
        Return True
    End Function

    Public Overridable Function SubscribeToAllEvents() As Boolean
        m_Error = Nothing
        Dim subscribeToAllCmd As IDbCommand
        subscribeToAllCmd = CreateSPCommand("spEventLog_SubscribeToAllEvents", Connection)
        AddParam(subscribeToAllCmd, "@idfClientID", ClientID)

        m_Error = ExecCommand(subscribeToAllCmd, subscribeToAllCmd.Connection, Nothing)

        If m_Error Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Property ClientID() As String
        Get
            If m_ClientID Is Nothing Then
                m_ClientID = model.Core.EidssUserContext.ClientID
            End If
            Return m_ClientID
        End Get
        Set(ByVal value As String)
            m_ClientID = value
        End Set
    End Property
    Public Property SiteID() As Long
        Get
            If (m_SiteID <= 0) Then
                m_SiteID = m_SiteService.GetSiteID()
            End If
            Return m_SiteID
        End Get
        Set(ByVal value As Long)
            m_SiteID = value
        End Set
    End Property
    Public Shared Function GetTransferedSampleSite(idfTransferOut As Long) As Object
        Dim cmd As IDbCommand = CreateSPCommand("spGetTargetSiteForTransferOut", ConnectionManager.DefaultInstance.Connection)
        AddParam(cmd, "@idfTransferOut", idfTransferOut)
        Dim errMsg As ErrorMessage = Nothing
        Dim res As Object = ExecScalar(cmd, ConnectionManager.DefaultInstance.Connection, errMsg)
        If res Is Nothing Then
            res = DBNull.Value
        End If
        Return res
    End Function
    Public Shared Function GetTestSampleSite(idfTesting As Long) As Object
        Dim cmd As IDbCommand = CreateSPCommand("spGetTargetSiteForRemoteTestResult", ConnectionManager.DefaultInstance.Connection)
        AddParam(cmd, "@idfTesting", idfTesting)
        Dim errMsg As ErrorMessage = Nothing
        Dim res As Object = ExecScalar(cmd, ConnectionManager.DefaultInstance.Connection, errMsg)
        If res Is Nothing Then
            res = DBNull.Value
        End If
        Return res
    End Function

    Public Shared Function GetParentSite(ByVal idfsSite As Long) As Object
        If idfsSite <= 0 Then Return DBNull.Value
        Dim cmd As IDbCommand = CreateSPCommand("spSite_GetParentSite", ConnectionManager.DefaultInstance.Connection)
        AddParam(cmd, "@SiteID", idfsSite)
        Dim errMsg As ErrorMessage = Nothing
        Dim res As Object = ExecScalar(cmd, ConnectionManager.DefaultInstance.Connection, errMsg)
        If Utils.IsEmpty(res) Then
            Return DBNull.Value
        End If
        Return CLng(res)
    End Function
    Public Shared Function GetChildSite(ByVal idfsSite As Long) As Object
        If idfsSite <= 0 Then Return DBNull.Value
        Dim cmd As IDbCommand = CreateSPCommand("spSite_GetChildSites", ConnectionManager.DefaultInstance.Connection)
        AddParam(cmd, "@SiteID", idfsSite)
        Dim errMsg As ErrorMessage = Nothing
        Dim res As Object = ExecScalar(cmd, ConnectionManager.DefaultInstance.Connection, errMsg)
        If Utils.IsEmpty(res) Then
            Return DBNull.Value
        End If
        Return CLng(res)
    End Function
End Class
