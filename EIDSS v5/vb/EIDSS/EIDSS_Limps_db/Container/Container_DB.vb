Imports System.Data
Imports System.Data.Common

Public Class Container_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "Container"
    End Sub

    Public Const TableContainer As String = "Container"
    Public Const TableLocation As String = "Lab_Location"
    Public Const TableFreezerScheme As String = "FreezerFreeLocations"

    Dim ContainerDetail_Adapter As DbDataAdapter
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spContainer_SelectDetail")
            AddParam(cmd, "@idfContainer", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            ContainerDetail_Adapter = CreateAdapter(cmd, True)

            Dim cmd1 As IDbCommand = CreateSPCommand("spRepository_GetSchemeWithFreeLocations")
            AddParam(cmd1, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, m_Error)
            AddParam(cmd1, "@StorageTypeList", "srtFreezer", m_Error)
            If Not m_Error Is Nothing Then Return Nothing
            Dim da As DbDataAdapter = CreateAdapter(cmd1)

            'TODO: check if rftContainerType is not used indeed
            'Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftContainerType, Connection)
            'Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftContainerStatus, Connection)

            da.Fill(ds, TableFreezerScheme)
            ContainerDetail_Adapter.Fill(ds, TableContainer)
            ds.Tables(TableContainer & 1).TableName = TableLocation
            If ID Is Nothing Then
                CreateContainer(ds.Tables(TableContainer), ID)
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Update(ContainerDetail_Adapter, ds, TableContainer, transaction)
            Dim row As DataRow = GetNewLocationRow(ds.Tables(TableLocation))
            If Not row Is Nothing Then
                Dim cmd As IDbCommand = CreateSPCommand("spContainer_PutToRepositiory")
                AddParam(cmd, "@idfContainer", row("idfContainer"))
                AddParam(cmd, "@idfLocationID", row("idfLocationID"))
                AddParam(cmd, "@Result", 0, ParameterDirection.InputOutput)
                ExecCommand(cmd, Connection, transaction)
                Select Case CInt(CType(cmd.Parameters.Item("@Result"), IDataParameter).Value)
                    Case 1
                        m_Error = New EIDSSErrorMessage("errLabLocationIsBusy", "The location selected for this container is busy already. Possibly the location was filled by other user while you perform this operation. Please select other location for this container")
                        Return False
                    Case 2
                        m_Error = New EIDSSErrorMessage("errLabIncorrectLocation", "The location doesn't exist")
                        Return False
                End Select
            End If

            'Add any other posting here if needed
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    Public Function GetContainerLocation(ByVal idfLocation As Object) As String
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spFreezer_GetLocationPath")
            AddParam(cmd, "@idfLocationID", idfLocation)
            AddTypedParam(cmd, "@LocationPath", SqlDbType.NVarChar, 250, ParameterDirection.Output)
            ExecCommand(cmd, Connection)
            If Not CType(cmd.Parameters.Item("@LocationPath"), IDataParameter).Value Is DBNull.Value Then
                Return CType(cmd.Parameters.Item("@LocationPath"), IDataParameter).Value.ToString()
            Else
                Return ""
            End If
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
        End Try
        Return ""
    End Function
    Private Function GetNewLocationRow(ByVal dt As DataTable) As DataRow
        'New location row contains data for the new container location
        'but it has state Added and will cause error during posting because of
        'location record exists in database already
        'This method recreates NweLocation row with correct state and clears
        'old container location if needed
        If dt Is Nothing Then Return Nothing

        Dim NewLocationRow As DataRow = Nothing
        If dt.Rows.Count > 1 Then
            Return dt.Rows(1)
        ElseIf dt.Rows.Count = 1 Then
            If dt.Rows(0).RowState = DataRowState.Added Then
                Return dt.Rows(0)
            End If
        End If
        Return Nothing
    End Function
    Public Shared Sub CreateContainer(ByVal dt As DataTable, ByRef ContainerID As Object)
        If ContainerID Is Nothing Then
            ContainerID = Guid.NewGuid()
        End If
        Dim r As DataRow = dt.NewRow
        r("idfContainer") = ContainerID
        r("idfsSite") = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
        r("datCreationDate") = DateTime.Now
        r("idfsContainer_Type") = "conVial"
        dt.Rows.Add(r)
    End Sub
End Class
