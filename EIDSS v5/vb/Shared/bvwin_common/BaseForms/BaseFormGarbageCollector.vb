Imports System.Collections.Generic
Public Class BaseFormGarbageCollector
    Private Shared m_FormsToDispose As Queue(Of BaseForm)
    Private Shared m_LastMarkTime As Long
    Private Const DisposingDelay As Long = 100000000 'disposing delay in tics (1 tick = 1E10-7 sec)
    Public Shared Sub MarkForDisposing(ByVal form As BaseForm)
        If BaseSettings.ForceFormsDisposing = False Then
            Return
        End If
        If m_FormsToDispose Is Nothing Then
            m_FormsToDispose = New Queue(Of BaseForm)
            AddHandler Application.Idle, AddressOf DisposeUnusedForms
        End If
        SyncLock m_FormsToDispose
            m_FormsToDispose.Enqueue(form)
            m_LastMarkTime = DateTime.Now.Ticks()
        End SyncLock
    End Sub

    Private Shared Sub DisposeUnusedForms(ByVal sender As Object, ByVal e As EventArgs)
        If DateTime.Now.Ticks - m_LastMarkTime > DisposingDelay Then
            SyncLock m_FormsToDispose
                While m_FormsToDispose.Count > 0
                    Dim form As BaseForm = m_FormsToDispose.Dequeue()
                    If Not form.ParentForm Is Nothing Then
                        form.ParentForm.Dispose()
                    Else
                        form.Dispose()
                    End If
                End While
            End SyncLock
        End If
    End Sub

    Public Shared Sub DeInit()
        RemoveHandler Application.Idle, AddressOf DisposeUnusedForms
        m_FormsToDispose.Clear()
    End Sub

End Class
