Imports bv.common.Diagnostics
Imports EIDSS.model.Enums
Imports TaskScheduler
Imports bv.common.Core
Imports Microsoft.Win32.TaskScheduler

Public Class TaskProvider
    Implements IJobProvider
    Dim m_Task As Task
    Public Sub New()
        Type = JobType.Replication
    End Sub
    Public ReadOnly Property IsRunning() As Boolean Implements IJobProvider.IsRunning
        Get
            If m_Task Is Nothing Then
                Return False
            End If
            Try
                Dbg.Debug("m_Task.State: {0}", m_Task.State)
                Return m_Task.State = TaskState.Running
            Catch ex As Exception
                Dbg.Debug("error in Task.IsRunning: {0}", ex.ToString)
                If Not LastError Is Nothing Then
                    m_LastError = ex.ToString
                End If
                Return False
            End Try
        End Get
    End Property
    Private m_LastError As String
    Public ReadOnly Property LastError() As String Implements IJobProvider.LastError
        Get
            If Not Utils.IsEmpty(m_LastError) Then
                Return m_LastError
            End If
            If m_Task Is Nothing Then
                Return Nothing
            End If
            Dim err As Integer
            Try
                err = m_Task.LastTaskResult
            Catch ex As Exception
                Dbg.Debug("error in Task.GetLastError: {0}", ex.ToString)
                Return Nothing
            End Try
            Select Case err
                Case 0
                    Return Nothing
                Case Else
                    Return err.ToString
            End Select
        End Get
    End Property

    Public ReadOnly Property JobName() As String Implements IJobProvider.JobName
        Get
            Return m_JobName
        End Get
    End Property


    Private m_JobName As String = ""
    Private m_ReplicationController As ReplicationController
    Public ReadOnly Property ReplicationController As ReplicationController Implements IJobProvider.ReplicationController
        Get
            Return m_ReplicationController
        End Get
    End Property

    Public Property Type() As JobType Implements IJobProvider.Type


    Public Function Run(ByVal aJobName As String, rc As ReplicationController) As Integer Implements IJobProvider.Run
        Try
            m_ReplicationController = rc
            m_LastError = ""
            m_Task = TaskWrapper.Find(aJobName)
            m_JobName = aJobName
            If (m_Task Is Nothing) Then
                Dbg.Debug("Task for job {0} is not found.", aJobName)
            End If

        Catch ex As Exception
            Dbg.Debug("error in Task.Create for job {0}: {1}", aJobName, ex.ToString)
            If Not LastError Is Nothing Then
                m_LastError = ex.ToString
            End If
            Return 1
        End Try
        Try
            m_Task.Run()
        Catch ex As Exception
            Dbg.Debug("error in Task.Run for job {0}: {1}", aJobName, ex.ToString)
            If Not LastError Is Nothing Then
                m_LastError = ex.ToString
            End If
            Return 2
        End Try
        Return 0
    End Function
End Class
