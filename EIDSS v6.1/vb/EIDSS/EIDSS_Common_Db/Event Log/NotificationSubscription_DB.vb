Imports System.Data
Imports bv.common.Enums

Public Class NotificationSubscription_DB
    Inherits BaseDbService

    Public Const TableEventSubscription As String = "EventSubScription"
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spNotificationSubscription_SelectDetail")
            AddParam(cmd, "@ClientID", model.Core.EidssUserContext.ClientID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            FillDataset(cmd, ds, TableEventSubscription)
            ds.Tables(TableEventSubscription).Columns("Subscription").ReadOnly = False
            ds.AcceptChanges()
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try

    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            For Each row As DataRow In ds.Tables(TableEventSubscription).Rows
                If row.RowState = DataRowState.Modified AndAlso row.HasVersion(DataRowVersion.Original) AndAlso row("Subscription").Equals(row("Subscription", DataRowVersion.Original)) Then
                    row.AcceptChanges()
                End If
            Next
            ExecPostProcedure("spNotificationSubscription_Post", ds.Tables(TableEventSubscription), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True

    End Function
End Class
