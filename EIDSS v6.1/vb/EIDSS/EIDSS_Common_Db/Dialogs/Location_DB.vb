Imports System.Data
Imports System.Data.Common
Imports bv.common.Enums


Public Class Location_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "Location"
        DefaultLocationType = GeoLocationType.ExactPoint
    End Sub

    Dim m_IsNewLocation as boolean

    Public ReadOnly Property IsNewLocation() As Boolean
        Get
            Return m_IsNewLocation
        End Get
    End Property
    Public Property DefaultLocationType As GeoLocationType

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet

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
            ds.Tables("GeoLocation").Columns("dblRelLongitude").ReadOnly = False
            ds.Tables("GeoLocation").Columns("dblRelLatitude").ReadOnly = False
            If (ds.Tables("GeoLocation").Rows.Count = 0) Then
                Dim r1 As DataRow = ds.Tables("GeoLocation").NewRow()
                r1("idfGeoLocation") = ID
                r1("idfsGeoLocationType") = DefaultLocationType
                ds.Tables("GeoLocation").Rows.Add(r1)
                m_IsNewObject = True
            Else
                m_IsNewObject = False
            End If
            If ds.Tables("GeoLocation").Rows(0)("idfsCountry") Is DBNull.Value Then
                m_IsNewLocation = True
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    'Private Function GetAddressDBService() As BaseDbService
    '    Return FindLinkedServiceByType(GetType(Address_DB))
    'End Function
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        If ds.Tables("GeoLocation").Rows.Count = 0 Then
            Return True
        End If
        If Utils.IsEmpty(ds.Tables("GeoLocation").Rows(0)("idfsGeoLocationType")) Then
            Return True
        End If
        Try
            'Select Case ds.Tables("GeoLocation").Rows(0)("idfsGeoLocationType").ToString
            '    Case "lctAddress"
            '        Dim addressService As BaseDbService = GetAddressDBService()
            '        If Not addressService Is Nothing Then
            '            If PostRelatedDetail(addressService, PostType, transaction) = False Then
            '                Return False
            '            End If
            '        End If
            '    Case Else
            '        ExecPostProcedure("spGeoLocation_Post", ds.Tables("GeoLocation"), Connection, transaction)
            'End Select
            If IsNewObject AndAlso ds.Tables("GeoLocation").Rows(0).RowState = DataRowState.Unchanged Then
                ds.Tables("GeoLocation").Rows(0).SetAdded()
            End If
            ExecPostProcedure("spGeoLocation_Post", ds.Tables("GeoLocation"), Connection, transaction, , , , , True)


        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    'Public Overrides Function BeforePost(ByVal ds As System.Data.DataSet, ByVal PostType As Integer) As Boolean
    '    If Not ds Is Nothing AndAlso ds.Tables("GeoLocation").Rows(0)("idfsGeoLocationType") Is DBNull.Value Then
    '        Dim addressService As BaseDbService = GetAddressDBService()
    '        If Not addressService Is Nothing Then
    '            If RaiseChildPostEvents(addressService, PostType, 0) = False Then
    '                Return False
    '            End If
    '        End If
    '    End If
    '    Return MyBase.BeforePost(ds, PostType)
    'End Function
End Class
