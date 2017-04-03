Imports bv.common.db.Core
Imports bv.common.Diagnostics
Imports bv.common
Imports Microsoft.SqlServer.Management
Imports Microsoft.SqlServer.Management.Smo.Agent
Imports Microsoft.SqlServer.Management.Smo

Imports System.Data.SqlClient
Imports bv.common.Core

Public Class SqlClentAgentJobProvider
    Implements IJobProvider
    Private m_Server As Server
    Private m_ServerName As String
    Private m_UserName As String
    Private m_Password As String
    Private m_Job As Job


    Public Sub New(ByVal serverName As String, ByVal UserName As String, ByVal Password As String)
        m_ServerName = serverName
        m_UserName = UserName
        m_Password = Password
        TryInit()
    End Sub
    Private Sub ResetServerConnection()
        Try
            Dim builder As New SqlConnectionStringBuilder()
            builder.DataSource = m_ServerName
            builder.InitialCatalog = "master"
            builder.UserID = m_UserName
            builder.Password = m_Password
            Dim sqlConn As New System.Data.SqlClient.SqlConnection(builder.ConnectionString)
            sqlConn.Open()
            Dim mainConnection As New Microsoft.SqlServer.Management.Common.ServerConnection(sqlConn)
            m_Server = New Smo.Server(mainConnection)
            m_LastError = ""
        Catch ex As Exception
            Dbg.Debug("Can't initialize SMO server {0}:", m_ServerName)
            Dbg.Debug(ex.ToString)
            m_Server = Nothing
            m_LastError = String.Format("Can't initialize SMO server {0}:", m_ServerName)
        End Try
    End Sub
    Private Sub TryInit()
        If m_Server Is Nothing Then
            ResetServerConnection()
        Else
            Try
                m_Server.Refresh()
            Catch ex As Exception
                ResetServerConnection()
            End Try
        End If

    End Sub
    Public ReadOnly Property IsRunning() As Boolean Implements IJobProvider.IsRunning
        Get
            Try

                If m_Job Is Nothing Then
                    Return False
                End If
                If (m_Job.CurrentRunRetryAttempt < 1) Then
                    m_Job.Refresh()
                    If (m_LastStartTime <> m_Job.LastRunDate) Then
                        Return False
                    End If
                    Return True
                End If
            Catch ex As Exception
                Dbg.Debug("error during job state checking: {0}", ex)
            End Try
            Return False
        End Get
    End Property
    Private m_LastError As String = ""
    Public ReadOnly Property LastError() As String Implements IJobProvider.LastError
        Get
            If Not Utils.IsEmpty(m_LastError) Then
                Return m_LastError
            End If
            Dim result As DataTable
            If m_Job Is Nothing Then
                Return Nothing
            End If
            result = m_Job.EnumHistory()
            If (Not result Is Nothing) Then
                Dim status As JobOutcome
                Dim jobName As String
                Dim jobMessage As String
                While (result.Rows.Count = 0)
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3))
                End While
                For nIndex As Integer = 0 To result.Rows.Count - 1
                    Dbg.Debug("Job history row {0}", nIndex)
                    For i As Integer = 0 To result.Columns.Count - 1
                        Dbg.Debug("{0} - {1}: {2}", i, result.Columns(i).ColumnName, result.Rows(nIndex)(i))
                    Next

                    ' Job name
                    jobName = result.Rows(nIndex)("JobName").ToString
                    ' Message
                    jobMessage = result.Rows(nIndex)("Message").ToString
                    ' Status
                    status = CType(result.Rows(nIndex)("RunStatus"), JobOutcome)
                    If status = JobOutcome.Succeeded Then
                        Return Nothing
                    End If
                    ' Make message
                    If (status = JobOutcome.Failed OrElse status = 2) Then
                        Trace.WriteLine(Trace.Kind.Warning, "job {0} is failed. {1} {2}", jobName, jobMessage, status.ToString())
                        Return jobMessage
                    End If
                Next
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property JobName() As String Implements IJobProvider.JobName
        Get
            Return m_JobName
        End Get
    End Property

    Private m_LastStartTime As DateTime
    Private m_JobName As String = ""
    Private m_ReplicationController As ReplicationController
    Public ReadOnly Property ReplicationController As ReplicationController Implements IJobProvider.ReplicationController
        Get
            Return m_ReplicationController
        End Get
    End Property

    Public Function Run(ByVal jobName As String, rc As ReplicationController) As Integer Implements IJobProvider.Run
        m_JobName = jobName
        m_ReplicationController = rc
        TryInit()
        If m_Server Is Nothing Then
            Return 1
        End If

        If Utils.IsEmpty(jobName) Then
            Dbg.Debug("Job is not defined for server {0}", m_ServerName)
            m_LastError = String.Format("Job is not defined for server {0}", m_ServerName)
            Return 1
        End If
        m_Job = Nothing
        Try
            For Each job As Smo.Agent.Job In m_Server.JobServer.Jobs
                If job.Name = jobName Then
                    m_Job = job
                    Exit For
                End If
            Next
            If m_Job Is Nothing Then
                Trace.WriteLine(Trace.Kind.Error, "EIDSS_Ntfy: Job " + jobName + " is not found. on server " + m_ServerName)
                m_LastError = String.Format("Job [" + jobName + "] is not found on server " + m_ServerName)
                Return 1
            End If
            m_LastError = ""
            m_Job.Refresh()
            For j As Integer = 0 To m_Job.JobSteps.Count - 1
                Dim [step] As Smo.Agent.JobStep = m_Job.JobSteps.Item(j)
                [step].RetryAttempts = 1
            Next
            'Don't start job until previous job is not finished
            Dim errorCount As Integer = 0
            While JobExecutionStatus.Idle = m_Job.CurrentRunStatus
                m_LastStartTime = m_Job.LastRunDate
                Try
                    m_Job.Start()
                    Exit While
                Catch ex As Exception
                    Dbg.Debug("job {0} is failed. Source {1}. HiperLink: {2}. {3}", m_Job.Name, ex.Source, ex.HelpLink, ex.Message)
                    If Not ex.InnerException Is Nothing Then
                        Dbg.Debug("job {0} is failed. Inner exception", m_Job.Name, ex.InnerException.ToString)
                    End If
                    errorCount += 1
                    If errorCount > 100 Then
                        Throw
                    End If
                End Try
                System.Threading.Thread.Sleep(100)
                m_Job.Refresh()
            End While
            Return 0
        Catch Except As Exception
            Trace.WriteLine(Trace.Kind.Error, "EIDSS_Ntfy: Job starting" + jobName + " is failed.", Except)
            m_LastError = String.Format("Job starting {0} is failed. {1}", jobName, Except)
            Return 2
        End Try

    End Function
End Class
