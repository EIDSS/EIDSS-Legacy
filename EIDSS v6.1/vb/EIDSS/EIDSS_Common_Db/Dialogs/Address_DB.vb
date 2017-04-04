Imports System.Data
Imports System.Data.Common
Imports bv.common.Enums


Public Class Address_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "Address"
    End Sub


    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet

        Dim ds As New DataSet

        Try
            Dim cmd As IDbCommand
            cmd = CreateSPCommand("spAddress_SelectDetail")
            AddParam(cmd, "@idfAddress", ID)
            AddParam(cmd, "@LangID", model.Core.EidssUserContext.CurrentLanguage)

            FillDataset(cmd, ds, "Address")
            CorrectTable(ds.Tables(0), "Address")
            ClearColumnsAttibutes(ds)

            ds.EnforceConstraints = False
            If Utils.IsEmpty(ID) Then
                ID = NewIntID()
            End If
            ds.Tables("Address").Columns("blnForeignAddress").DefaultValue = False
            If (ds.Tables("Address").Rows.Count = 0) Then
                Dim r As DataRow = ds.Tables("Address").NewRow()
                r("idfGeoLocation") = ID
                ds.Tables("Address").Rows.Add(r)
                m_IsNewObject = True
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If (Not Utils.IsEmpty(ID)) AndAlso (ID.Equals(Utils.SEARCH_MODE_ID)) Then Return True
        If ds Is Nothing OrElse ds.Tables.Count = 0 Then Return True
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spAddress_Post", Connection, transaction)
            StoredProcParamsCache.CreateParameters(cmd)
            BindParamsToColumns(cmd, ds.Tables("Address"))
            SetParam(cmd, "@blnGeoLocationShared", IsSharedAddress)
            Dim da As DbDataAdapter = CreateAdapter(cmd, False)
            da.ContinueUpdateOnError = False
            CType(da, IDbDataAdapter).InsertCommand = cmd
            CType(da, IDbDataAdapter).UpdateCommand = cmd
            Update(da, ds, "Address", transaction)
            'cmd.ExecuteNonQuery()
            If Not ds.Tables("Address").Rows(0)("strStreetName") Is DBNull.Value Then
                LookupCache.NotifyChange("Street", transaction)
            End If
            If Not ds.Tables("Address").Rows(0)("strPostCode") Is DBNull.Value Then
                LookupCache.NotifyChange("PostalCode", transaction)
            End If
        Catch ex As Exception
            If transaction Is Nothing OrElse transaction.Connection Is Nothing Then
                m_Error = New ErrorMessage(StandardError.PostError, ex)
                Return False
            Else
                Return True
            End If
        End Try
        Return True
    End Function
    Private m_IsSharedAddress As Boolean = False
    Public Property IsSharedAddress As Boolean
        Get
            Return m_IsSharedAddress
        End Get
        Set(value As Boolean)
            m_IsSharedAddress = value
        End Set
    End Property

End Class
