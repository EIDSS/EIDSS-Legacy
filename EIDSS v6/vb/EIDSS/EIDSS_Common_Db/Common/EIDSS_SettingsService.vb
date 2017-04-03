Imports System.Data.Common
Imports bv.common
Public Class EIDSS_SettingsService
    Inherits BaseDbService
    Sub New()
        ObjectName = "Settings"
    End Sub

    Dim m_Dataset As New DataSet
    Function GetSettingsRow(ByVal name As String, Optional ByVal CreateRow As Boolean = False, Optional ByVal cn As IDbConnection = Nothing) As DataRow
        Try
            If cn Is Nothing Then cn = Connection
            Dim cmd As IDbCommand = CreateSPCommand("spLocalSiteOptions_SelectDetail", cn)
            Dim da As DbDataAdapter = CreateAdapter(cmd)
            Using ds As New DataSet()
                da.Fill(ds, ObjectName)
                m_Dataset.Merge(ds)
                DbDisposeHelper.ClearDataset(ds)
            End Using
            If Not m_Dataset Is Nothing AndAlso m_Dataset.Tables.Count > 0 Then
                Dim row As DataRow = m_Dataset.Tables(0).Rows.Find(name)
                If row Is Nothing And CreateRow Then
                    row = m_Dataset.Tables(0).NewRow
                    row("strName") = name
                    m_Dataset.Tables(0).Rows.Add(row)
                End If
                Return row
            End If
        Catch ex As Exception
            Trace.WriteLine(Trace.Kind.Error, "error during local site options reading:", ex)
            Throw
        End Try
        Return Nothing
    End Function
    Default Public Property Item(ByVal name As String, Optional ByVal cn As IDbConnection = Nothing) As String
        Get
            Dim row As DataRow = GetSettingsRow(name, False, cn)
            If Not row Is Nothing AndAlso Not row("strValue") Is DBNull.Value Then Return row("strValue").ToString()
            Return ""
        End Get
        Set(ByVal Value As String)
            Dim row As DataRow = GetSettingsRow(name, True)
            If Not row Is Nothing Then
                row.BeginEdit()
                row("strValue") = Value
                row.EndEdit()
                Save()
            End If
        End Set
    End Property

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal postType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        Dim da As DbDataAdapter = BaseDbService.CreateAdapter(GetSelectListSql(), transaction.Connection, True, transaction)
        Update(da, ds, ObjectName, transaction)
        Return True
    End Function

    Public Sub Save()
        Post(m_Dataset, 1)
    End Sub

    Protected Overrides Sub Finalize()
        DbDisposeHelper.DisposeDataset(m_Dataset)
        MyBase.Finalize()
    End Sub
End Class
