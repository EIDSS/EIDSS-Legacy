Imports bv.common.Core
Imports bv.common.Objects
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Threading
Imports bv.model.Model.Core
Imports bv.common.Configuration

Namespace Core
    Public Class LookupCacheListener
        Private Shared m_Timer As System.Threading.Timer = Nothing
        Private Shared m_TimerInterval As Long = 1000
        Private Shared m_AsyncConnectionManager As ConnectionManager
        Public Shared Sub Listen()
            If m_Timer Is Nothing Then
                m_Timer = New System.Threading.Timer(AddressOf WorkerProc, Nothing, Timeout.Infinite, Timeout.Infinite)
            End If
            m_Timer.Change(0, Timeout.Infinite)
        End Sub
        Public Shared Sub [Stop]()
            'SyncLock m_Timer
            If Not m_Timer Is Nothing Then
                m_Timer.Change(Timeout.Infinite, Timeout.Infinite)
            End If
            'm_Timer.Dispose()
            'm_Timer = Nothing
            'End SyncLock
        End Sub
        Public Shared Sub CleanUp()
            GetModifiedLookupTables()
        End Sub
        Private Shared Sub WorkerProc(ByVal state As Object)
            If m_Timer Is Nothing Then
                Exit Sub
            End If
            'SyncLock m_Timer
            m_Timer.Change(Timeout.Infinite, Timeout.Infinite)
            Try
                Using dt As DataTable = GetModifiedLookupTables()
                    If Not dt Is Nothing Then
                        For Each row As DataRow In dt.Rows
                            LookupCache.Refresh(row("strInformationString").ToString)
                        Next
                    End If
                End Using
            Catch ex As Exception
                Dbg.Debug("error during lookup cache refreshing: {0}", ex.ToString)
            Finally
                If Not m_Timer Is Nothing Then
                    m_Timer.Change(m_TimerInterval, Timeout.Infinite)
                End If
            End Try
            'End SyncLock
        End Sub

        Private Shared Function GetModifiedLookupTables() As DataTable
            If BaseSettings.SuppressGettingModifiedLookupTables Or LookupCache.LookupTables.Count = 0 Then
                Return Nothing
            End If
            Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spLookupTables_GetModified", AsyncConnectionManager.Connection, Nothing)
            BaseDbService.AddParam(cmd, "@ClientID", ModelUserContext.ClientID)
            Dim dt As New DataTable
            SyncLock cmd.Connection
                Dim err As ErrorMessage = BaseDbService.FillTable(cmd, dt)
                If Not err Is Nothing Then
                    Dbg.Debug("error during receiving modified lookup tables: {0}", err.Exception.ToString)
                End If
                If dt.Rows.Count > 0 Then
                    Dbg.Debug("{0} lookup tables was modified", dt.Rows.Count)
                End If
            End SyncLock
            Return dt
        End Function

        Private Shared ReadOnly Property AsyncConnectionManager() As ConnectionManager
            Get
                If m_AsyncConnectionManager Is Nothing Then
                    m_AsyncConnectionManager = ConnectionManager.CreateNew(True)
                End If
                Return m_AsyncConnectionManager
            End Get
        End Property

    End Class
End Namespace
