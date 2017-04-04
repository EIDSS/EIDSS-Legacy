Imports System.Data
Imports System.Data.Common
Imports bv.common.Diagnostics
Imports bv.common.Enums

Public Class SiteActivationServer_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "SiteActivationServer"
    End Sub


    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spSiteActivationServer_SelectDetail")
            AddParam(cmd, "@SiteID", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            FillDataset(cmd, ds, "SiteActivationServer")
            '****************************
            'Parent/child relation processing is commented until clear requirements on this part

            'CorrectTable(ds.Tables("SiteActivationServer" & 1), "Parent_Site_Relation", "idfsSiteRelation")
            'CorrectTable(ds.Tables("SiteActivationServer" & 2), "Child_Site_Relation", "idfsSiteRelation")
            'ds.Tables("Child_Site_Relation").Columns("idfsRelativeSite").AllowDBNull = True
            'CorrectTable(ds.Tables("SiteActivationServer" & 3), "NotificationTo", "idfsSiteRelation")
            'ds.Tables("NotificationTo").Columns("idfsRelativeSite").AllowDBNull = True
            'CorrectTable(ds.Tables("SiteActivationServer" & 4), "NotificationFrom", "idfsSiteRelation")
            'ds.Tables("NotificationFrom").Columns("idfsParentSite").AllowDBNull = True
            '****************************
            'Process the new object creation
            'It is assumed that if ID is nothing we should return 
            'the dataset containing empty row related with the mai obiect
            If ID Is Nothing Then
                Dim r As DataRow = ds.Tables("SiteActivationServer").NewRow
                r("idfCustomizatonPackage ") = model.Core.EidssSiteContext.Instance.CustomizationPackageID
                ds.EnforceConstraints = False
                ds.Tables("SiteActivationServer").Rows.Add(r)
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spSiteActivationServer_Post", ds.Tables("SiteActivationServer"), Connection, transaction)

            '****************************
            'Parent/child relation processing is commented until clear requirements on this part

            'Dim da As DbDataAdapter
            'da = CreateAdapter(ds.Tables("Parent_Site_Relation"), "Site_Relation", Connection, True, transaction)
            'Update(da, ds, "Parent_Site_Relation", transaction)
            'da = CreateAdapter(ds.Tables("Child_Site_Relation"), "Site_Relation", Connection, True, transaction)
            'Update(da, ds, "Child_Site_Relation", transaction)
            'da = CreateAdapter(ds.Tables("NotificationTo"), "Site_Relation", Connection, True, transaction)
            'Update(da, ds, "NotificationTo", transaction)
            'da = CreateAdapter(ds.Tables("NotificationFrom"), "Site_Relation", Connection, True, transaction)
            'Update(da, ds, "NotificationFrom", transaction)
            'Add any other posting here if needed
            '****************************
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Private Shared Function GetQueryValue(ByVal cmd As IDbCommand, ByVal fieldName As String) As Long
        Dim reader As IDataReader = Nothing
        Dim value As Long
        Try
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If Reader.Read() Then
                value = CLng(reader(fieldName))
            Else
                value = 0
            End If
        Catch ex As Exception
            value = 0
            Dbg.Debug(ex.ToString)
        Finally
            If Not reader Is Nothing AndAlso Not reader.IsClosed Then
                reader.Close()
            End If
        End Try
        Return value
    End Function


    Public Function GetParentSite(ByVal relativeSiteID As Long) As Long
        If relativeSiteID <= 0 Then Return 0
        Dim parentSiteID As Long
        SyncLock Connection
            If (Connection.State And ConnectionState.Open) = 0 Then
                Connection.Open()
            End If
            Dim cmd As IDbCommand = CreateSPCommand("spSite_GetParentSite", Connection)
            AddParam(cmd, "@SiteID", relativeSiteID)
            parentSiteID = GetQueryValue(cmd, "idfsParentSite")
        End SyncLock
        Return parentSiteID
    End Function

    Public Function GetChildSiteList(ByVal parentSiteID As Long) As DataTable
        If parentSiteID <= 0 Then Return Nothing
        Dim dt As DataTable = New DataTable("ChildSiteList")
        Dim cmd As IDbCommand = CreateSPCommand("spSite_GetChildList", Connection)
        dt.BeginLoadData()
        FillTable(cmd, dt)
        dt.EndLoadData()
        If dt.Rows.Count = 0 Then
            dt.Dispose()
            Return Nothing
        End If
        Return dt
    End Function


    'Public Overrides Function BeforePost(ByVal ds As System.Data.DataSet, ByVal PostType As Integer) As Boolean
    '    Dim TableName As String = "Child_Site_Relation"
    '    Dim FieldName As String = "idfsRelative_Site"
    '    For i As Integer = 0 To ds.Tables(TableName).Rows.Count - 1
    '        If (ds.Tables(TableName).Rows(i).RowState <> DataRowState.Deleted) AndAlso _
    '           ((ds.Tables(TableName).Rows(i).Item(FieldName) Is Nothing) OrElse _
    '           (ds.Tables(TableName).Rows(i).Item(FieldName) Is DBNull.Value)) Then
    '            ds.Tables(TableName).Rows(i).Delete()
    '        End If
    '    Next
    '    ds.Tables(TableName).Columns("idfsSite_Type").ReadOnly = True
    '    ds.Tables(TableName).Columns("Office_Name").ReadOnly = True
    '    ds.Tables(TableName).Columns("Office_Abbreviation").ReadOnly = True
    '    TableName = "NotificationTo"
    '    FieldName = "idfsRelative_Site"
    '    For i As Integer = 0 To ds.Tables(TableName).Rows.Count - 1
    '        If (ds.Tables(TableName).Rows(i).RowState <> DataRowState.Deleted) AndAlso _
    '           ((ds.Tables(TableName).Rows(i).Item(FieldName) Is Nothing) OrElse _
    '           (ds.Tables(TableName).Rows(i).Item(FieldName) Is DBNull.Value)) Then
    '            ds.Tables(TableName).Rows(i).Delete()
    '        End If
    '    Next
    '    ds.Tables(TableName).Columns("idfsSite_Type").ReadOnly = True
    '    ds.Tables(TableName).Columns("Office_Name").ReadOnly = True
    '    ds.Tables(TableName).Columns("Office_Abbreviation").ReadOnly = True
    '    TableName = "NotificationFrom"
    '    FieldName = "idfsParent_Site"
    '    For i As Integer = 0 To ds.Tables(TableName).Rows.Count - 1
    '        If (ds.Tables(TableName).Rows(i).RowState <> DataRowState.Deleted) AndAlso _
    '           ((ds.Tables(TableName).Rows(i).Item(FieldName) Is Nothing) OrElse _
    '           (ds.Tables(TableName).Rows(i).Item(FieldName) Is DBNull.Value)) Then
    '            ds.Tables(TableName).Rows(i).Delete()
    '        End If
    '    Next
    '    ds.Tables(TableName).Columns("idfsSite_Type").ReadOnly = True
    '    ds.Tables(TableName).Columns("Office_Name").ReadOnly = True
    '    ds.Tables(TableName).Columns("Office_Abbreviation").ReadOnly = True
    '    Return True
    'End Function
End Class
