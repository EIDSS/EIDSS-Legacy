Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core
Imports bv.common.db
Imports bv.common.Diagnostics

Public Class Area_DB
    Inherits BaseDbService

    Protected AreaDetailAdapter As DbDataAdapter

    Public Sub New()
        ObjectName = "Area"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        'Create the table structure that will be used for the data binding in the 
        'related detail form. This table is not filled from database, 
        'the only record is added manually. 
        Dim dt As New DataTable("Area")
        dt.Columns.Add("idfsAreaType", GetType(Long))
        dt.Columns.Add("idfsCountry", GetType(Long))
        dt.Columns.Add("idfsRegion", GetType(Long))
        dt.Columns.Add("idfsRayon", GetType(Long))
        dt.Columns.Add("idfsSettlement", GetType(Long))
        dt.Rows.Add(dt.NewRow)
        dt.Rows(0)("idfsAreaType") = -1 'dummy primary key to avoid errors during daatset merging
        CorrectTable(dt, "Area")
        ds.Tables.Add(dt)
        ds.EnforceConstraints = False
        m_ID = ID
        Return ds
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return True
    End Function
    Public Sub GetAreaInfo(ByVal aArea As Object, ByRef aCountry As Object, ByRef aRegion As Object, ByRef aRayon As Object, ByRef aSettlement As Object, ByRef aType As StatisticAreaType)
        aCountry = DBNull.Value
        aRegion = DBNull.Value
        aRayon = DBNull.Value
        aSettlement = DBNull.Value
        aType = StatisticAreaType.Country
        SyncLock Connection
            If (Connection.State And ConnectionState.Open) = 0 Then
                Connection.Open()
            End If
            Dim cmd As IDbCommand = CreateSPCommand("spStatistic_GetAreaType", Connection)
            AddTypedParam(cmd, "@Area", SqlDbType.BigInt)
            SetParam(cmd, "@Area", aArea)
            Dim Reader As IDataReader = Nothing
            Try
                Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If Reader.Read() Then
                    aCountry = Reader("idfsCountry")
                    aRegion = Reader("idfsRegion")
                    aRayon = Reader("idfsRayon")
                    aSettlement = Reader("idfsSettlement")
                    Dim area As Object = Reader("AreaType")
                    If Not area Is DBNull.Value Then
                        aType = CType(area, StatisticAreaType)
                    End If
                End If
            Catch ex As Exception
                Dbg.Debug("error during area type retrieving: {0}", ex.ToString)
            Finally
                If Not Reader Is Nothing AndAlso Not Reader.IsClosed Then
                    Reader.Close()
                End If
            End Try
        End SyncLock
    End Sub

End Class
