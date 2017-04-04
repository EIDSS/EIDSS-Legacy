Imports System.Data
Imports bv.common.Enums

Public Class ExactLocation_Db
    Inherits BaseDbService


    Public Sub New()
        ObjectName = "ExactLocation"
    End Sub


    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet

        Dim ds As New DataSet

        Try
            Dim cmd As IDbCommand = CreateSPCommand("spGeoLocation_SelectDetail")
            AddParam(cmd, "@idfGeoLocation", ID)
            AddParam(cmd, "@LangID", model.Core.EidssUserContext.CurrentLanguage)

            FillDataset(cmd, ds, "GeoLocation")
            CorrectTable(ds.Tables(0), "GeoLocation")
            ClearColumnsAttibutes(ds)

            If Utils.IsEmpty(ID) Then
                ID = NewIntID()
            End If

            ds.EnforceConstraints = False

            If (ds.Tables("GeoLocation").Rows.Count = 0) Then
                Dim r1 As DataRow = ds.Tables("GeoLocation").NewRow()
                r1("idfGeoLocation") = ID
                r1("idfsGeoLocationType") = GeoLocationType.ExactPoint
                ds.Tables("GeoLocation").Rows.Add(r1)
                m_IsNewObject = True
            Else
                m_IsNewObject = False
            End If

            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        If ds.Tables("GeoLocation").Rows.Count = 0 Then
            Return True
        End If
        Try
            ExecPostProcedure("spGeoLocation_Post", ds.Tables("GeoLocation"), Connection, transaction, , , , , True)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
