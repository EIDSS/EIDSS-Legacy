Imports bv.common.Configuration

Namespace Core
    Public Class DbDisposeHelper
        Public Shared Sub DisposeDataset(ByRef ds As DataSet)
            If BaseSettings.ForceFormsDisposing = False Then
                Return
            End If
            If Not ds Is Nothing Then
                ClearDataset(ds)
                ds.Dispose()
                ds = Nothing
            End If
        End Sub

        Public Shared Sub ClearDataset(ByRef ds As DataSet)
            If Not ds Is Nothing Then
                'SyncLock ds.Tables
                '    For Each t As DataTable In ds.Tables
                '        t.Clear()
                '    Next
                'End SyncLock
                Try
                    ds.Reset()
                    ds.Clear()
                Catch ex As Exception
                    Dbg.Debug("error during dataset clearing: {0}", ex.ToString)
                End Try
            End If
        End Sub

        Public Shared Sub DisposeTable(ByRef dt As DataTable, Optional ByVal forceDispose As Boolean = False)
            If forceDispose = False AndAlso BaseSettings.ForceFormsDisposing = False Then
                Return
            End If
            If Not dt Is Nothing Then

                dt.Clear()
                dt.Columns.Clear()
                dt.AcceptChanges()
                dt.Dispose()
                dt = Nothing
            End If
        End Sub
    End Class

End Namespace
