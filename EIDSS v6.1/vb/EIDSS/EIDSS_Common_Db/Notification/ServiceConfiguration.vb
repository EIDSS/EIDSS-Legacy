Imports bv.common.Configuration
Imports Microsoft.Win32
Imports bv.common
Imports System.Text.RegularExpressions
Public Class ServiceConfiguration


    Protected Const SETTINGSSUBKEY_NAME As String = "SOFTWARE\Black & Veatch\EIDSS\Notification Service"
    Protected Const CONNECTIONSTRING_VALUE_NAME As String = "SqlConnectionString"
    Protected Const POLLRATE_VALUE_NAME As String = "PollRate"
    Protected Const EMRGENCYJOBNAME_VALUE_NAME As String = "EmergencyJobName"
    Protected Const ROUTINEJOBNAME_VALUE_NAME As String = "RoutineJobName"
    Protected Const REFERENCEJOBNAME_VALUE_NAME As String = "ReferenceJobName"
    Protected Const RETRYINTERVAL_VALUE_NAME As String = "RetryInterval"
    Protected Const RESTARTINTERVAL_VALUE_NAME As String = "RestartInterval"
    Protected Const RETRYATTEMPTSCOUNT_VALUE_NAME As String = "RetryAttemptsCount"
    Protected Const FILTRATIONINTERVAL_VALUE_NAME As String = "FiltrationInterval"
    Protected Shared USER_NAME As String = "NtfService"
    Protected Shared USER_PASSWORD As String = "Ntf!)Service"
    Protected m_ConnectionString As String = ""
    Protected m_EmergencyJobName As String = ""
    Protected m_RoutineJobName As String = "EIDSS_"
    Protected m_ReferenceJobName As String = "EIDSS_"
    Protected m_PollRate As Integer = 1000
    Protected m_FiltrationInterval As Integer = 3600000
    Protected m_RetryInterval As Integer = 30000
    Protected m_RestartInterval As Integer = 30000
    Protected m_RetryAttemptsCount As Integer = 4
    Private m_configFileName As String = Nothing
    Private m_ClientID As String = Nothing


    Public Sub New(ByVal configFileName As String)
        m_configFileName = configFileName
        ConfigWriter.Instance.Read(m_configFileName)
    End Sub
    Public Sub New()
        ConfigWriter.Instance.Read(Nothing)
    End Sub

    Public Function GetStrValue(ByVal key As String, Optional ByVal DefValue As String = "") As String
        Dim val As String = ConfigWriter.Instance.GetItem(key)
        If Utils.IsEmpty(val) Then
            Return DefValue
        End If
        Return val
    End Function

    Public Function GetIntValue(ByVal key As String, Optional ByVal DefValue As Integer = 0) As Integer
        Try
            Return CType(ConfigWriter.Instance.GetItem(key), Integer)
        Catch ex As Exception
            Return DefValue
        End Try
    End Function

    Public Overridable Sub ReadConfiguration()
        Try
            m_ConnectionString = GetStrValue(CONNECTIONSTRING_VALUE_NAME)
            m_PollRate = GetIntValue(POLLRATE_VALUE_NAME, 1000)
            m_EmergencyJobName = GetStrValue(EMRGENCYJOBNAME_VALUE_NAME)
            m_RoutineJobName = GetStrValue(ROUTINEJOBNAME_VALUE_NAME)
            m_ReferenceJobName = GetStrValue(REFERENCEJOBNAME_VALUE_NAME)
            m_ClientID = GetStrValue("ClientID")
            m_RetryInterval = GetIntValue(RETRYINTERVAL_VALUE_NAME, 30000)
            m_RetryAttemptsCount = GetIntValue(RETRYATTEMPTSCOUNT_VALUE_NAME)
            m_RestartInterval = GetIntValue(RESTARTINTERVAL_VALUE_NAME, 30000)
            m_FiltrationInterval = GetIntValue(FILTRATIONINTERVAL_VALUE_NAME, 3600000)
        Catch ex As Exception
            Trace.WriteLine(Trace.Kind.Error, "Error during reading notification config file", ex)
        End Try


    End Sub

    Public ReadOnly Property ConnectionString() As String
        Get
            Return (m_ConnectionString)
        End Get
    End Property

    Public Shared ReadOnly Property UserName() As String
        Get
            Return (USER_NAME)
        End Get
    End Property

    Public Shared ReadOnly Property Password() As String
        Get
            Return (USER_PASSWORD)
        End Get
    End Property
    Public ReadOnly Property PollRate() As Integer
        Get
            Return (m_PollRate)
        End Get
    End Property
    Public ReadOnly Property FiltrationInterval() As Integer
        Get
            Return (m_FiltrationInterval)
        End Get
    End Property
    Public ReadOnly Property EmergencyJobName() As String
        Get
            Return m_EmergencyJobName
        End Get
    End Property

    Public ReadOnly Property RoutineJobName() As String
        Get
            Return m_RoutineJobName
        End Get
    End Property
    Public ReadOnly Property ReferenceJobName() As String
        Get
            Return m_ReferenceJobName
        End Get
    End Property

    Public ReadOnly Property RetryInterval() As Integer
        Get
            Return (m_RetryInterval)
        End Get
    End Property

    Public ReadOnly Property RestartInterval() As Integer
        Get
            If m_RestartInterval <= 0 Then
                m_RestartInterval = 30000
            End If
            Return (m_RestartInterval)
        End Get
    End Property
    Public ReadOnly Property RetryAttemptsCount() As Integer
        Get
            Return (m_RetryAttemptsCount)
        End Get
    End Property
    Public ReadOnly Property ClientID() As String
        Get
            If Utils.IsEmpty(m_ClientID) Then
                Return EIDSS.model.Core.EidssUserContext.ClientID
            Else
                Return m_ClientID
            End If
        End Get
    End Property
    'Private Shared UserRegEx As String = "User\sID=(?<UserID>[^;\n]+)"
    'Private Shared Function GetUserID(ByVal ConnectionString As String) As String
    '    Dim regEx As New Regex(UserRegEx)
    '    Dim m As Match = regEx.Match(ConnectionString)
    '    If Not m Is Nothing AndAlso m.Success Then
    '        Return m.Groups("UserID").Value
    '    End If
    '    Dbg.Debug("User ID is not parsed from connection string {0}", ConnectionString)
    '    Return ""
    'End Function

    'Private Shared Function GetUserPassword(ByVal userName As String) As String
    '    Dim res As String = Nothing
    '    If Utils.Str(userName) <> "" Then
    '        res = userName
    '        For i As Integer = userName.Length - 1 To 0 Step -1
    '            res = res + userName.Substring(i, 1)
    '        Next
    '    End If
    '    Return res
    'End Function

End Class
