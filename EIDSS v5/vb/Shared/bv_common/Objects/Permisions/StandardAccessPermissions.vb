Imports System.Collections.Generic
Imports bv.common.Core
Imports eidss.model.Core

Namespace Objects
    <AccessPermissions("Standard")> _
    Public Class StandardAccessPermissions
        Inherits DefaultAccessPermissions

        Private m_SelectPermission As String = Nothing
        Private m_InsertPermission As String = Nothing
        Private m_UpdatePermission As String = Nothing
        Private m_DeletePermission As String = Nothing
        Private m_ExecutePermission As String = Nothing
        Private m_ReadOnly As Boolean = False
        Private m_DataAccessObjectType As [Enum] = DefaultPermissionObjectType.None

        Public Sub New()
            ' NOOP
        End Sub
        Public Sub New(ByVal Permission As [Enum])
            m_SelectPermission = PermissionHelper.SelectPermission(Permission)
            m_InsertPermission = PermissionHelper.InsertPermission(Permission)
            m_UpdatePermission = PermissionHelper.UpdatePermission(Permission)
            m_DeletePermission = PermissionHelper.DeletePermission(Permission)
            m_ExecutePermission = PermissionHelper.ExecutePermission(Permission)
        End Sub

        Public Sub New(ByVal selectPermission As String)
            m_SelectPermission = selectPermission
            m_InsertPermission = Nothing
            m_UpdatePermission = Nothing
            m_DeletePermission = Nothing
            m_ExecutePermission = Nothing
        End Sub

        Public Sub New(ByVal selectPermission As String, ByVal insertPermission As String, ByVal updatePermission As String, ByVal deletePermission As String, ByVal executePermission As String)
            m_SelectPermission = selectPermission
            m_InsertPermission = insertPermission
            m_UpdatePermission = updatePermission
            m_DeletePermission = deletePermission
            m_ExecutePermission = executePermission
        End Sub
        Private Function HasPermission(ByVal permString As String) As Boolean
            If permString Is Nothing OrElse permString.Trim() = "" Then
                Return False
            End If
            If permString = "Always" Then
                Return True
            End If
            'TODO: GlobalPermissions initialization and using
            Return eidss.model.Core.EidssUserContext.User.HasPermission(permString)
            'Dim dict As IDictionary(Of String, IPermissionObject) = GlobalPermissions.Permissions
            'If dict Is Nothing Then
            '    Return False
            'End If
            'Dim names() As String = permString.Split(New Char() {"|"c})
            'For Each name As String In names
            '    Dim po() As String = name.Split((New Char() {"."c}))
            '    If dict.ContainsKey(po(0)) AndAlso _
            '        (dict(po(0)).InsertPermissionName = name _
            '        OrElse dict(po(0)).SelectPermissionName = name _
            '        OrElse dict(po(0)).UpdatePermissionName = name _
            '        OrElse dict(po(0)).DeletePermissionName = name _
            '        OrElse dict(po(0)).ExecutePermissionName = name _
            '        ) Then
            '        Return True
            '    End If
            'Next
            'Return False
        End Function

        Public Overrides Property DataAccessObjectType() As [Enum]
            Get
                Return m_DataAccessObjectType
            End Get
            Set(ByVal value As [Enum])
                m_DataAccessObjectType = value
            End Set
        End Property

        Public Property [ReadOnly]() As Boolean
            Get
                Return m_ReadOnly
            End Get
            Set(ByVal value As Boolean)
                m_ReadOnly = value
            End Set
        End Property

        Public Property [Select]() As String
            Get
                Return m_SelectPermission
            End Get
            Set(ByVal value As String)
                m_SelectPermission = value
            End Set
        End Property

        Public Property Insert() As String
            Get
                Return m_InsertPermission
            End Get
            Set(ByVal value As String)
                m_InsertPermission = value
            End Set
        End Property

        Public Property Update() As String
            Get
                Return m_UpdatePermission
            End Get
            Set(ByVal value As String)
                m_UpdatePermission = value
            End Set
        End Property

        Public Property Delete() As String
            Get
                Return m_DeletePermission
            End Get
            Set(ByVal value As String)
                m_DeletePermission = value
            End Set
        End Property

        Public Property Execute() As String
            Get
                Return m_ExecutePermission
            End Get
            Set(ByVal value As String)
                m_ExecutePermission = value
            End Set
        End Property

        Public Overrides ReadOnly Property CanSelect() As Boolean
            Get
                Return HasPermission(m_SelectPermission) AndAlso (m_DataAccessObjectType.Equals(DefaultPermissionObjectType.None) OrElse EidssUserContext.User.HasObjectPermission(PermissionHelper.SelectPermission(m_DataAccessObjectType)))
            End Get
        End Property

        Public Overrides ReadOnly Property CanInsert() As Boolean
            Get
                Return Not m_ReadOnly AndAlso (HasPermission(m_InsertPermission) OrElse HasPermission(m_ExecutePermission)) AndAlso (m_DataAccessObjectType.Equals(DefaultPermissionObjectType.None) OrElse EidssUserContext.User.HasObjectPermission(PermissionHelper.InsertPermission(m_DataAccessObjectType)))
            End Get
        End Property

        Public Overrides ReadOnly Property CanUpdate() As Boolean
            Get
                Return Not m_ReadOnly AndAlso (HasPermission(m_UpdatePermission) OrElse HasPermission(m_ExecutePermission)) AndAlso (m_DataAccessObjectType.Equals(DefaultPermissionObjectType.None) OrElse EidssUserContext.User.HasObjectPermission(PermissionHelper.UpdatePermission(m_DataAccessObjectType)))
            End Get
        End Property

        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                Return Not m_ReadOnly AndAlso (HasPermission(m_DeletePermission) OrElse HasPermission(m_ExecutePermission)) AndAlso (m_DataAccessObjectType.Equals(DefaultPermissionObjectType.None) OrElse EidssUserContext.User.HasObjectPermission(PermissionHelper.DeletePermission(m_DataAccessObjectType)))
            End Get
        End Property

        Public Overrides ReadOnly Property CanExecute() As Boolean
            Get
                Return Not m_ReadOnly AndAlso HasPermission(m_ExecutePermission)
            End Get
        End Property

        Public Overrides Function CanDeleteRow(ByVal row As DataRow) As Boolean
            Return Not IsReadOnlyRow(row)
        End Function

        Public Overrides Function CanUpdateRow(ByVal row As DataRow) As Boolean
            Return Not IsReadOnlyRow(row)
        End Function

        Public Overrides Function CanExecuteRow(ByVal row As DataRow) As Boolean
            Return Not IsReadOnlyRow(row)
        End Function

        Public Overrides Function GetButtonVisibility(ByVal buttonType As DefaultButtonType) As Boolean
            Select Case buttonType
                Case DefaultButtonType.[New]
                    Return Not m_ReadOnly AndAlso HasPermission(m_InsertPermission)
                Case DefaultButtonType.Edit
                    Return HasPermission(m_SelectPermission)
                Case DefaultButtonType.Delete
                    Return Not m_ReadOnly AndAlso HasPermission(m_DeletePermission)
                Case DefaultButtonType.Save
                    Return Not m_ReadOnly AndAlso (HasPermission(m_UpdatePermission) OrElse HasPermission(m_InsertPermission))
            End Select
            Return MyBase.GetButtonVisibility(buttonType)
        End Function
        Private Function IsReadOnlyRow(ByVal row As DataRow) As Boolean
            If row Is Nothing Then
                bv.common.Diagnostics.Dbg.Debug("access permissions datarow is not defined")
                Return False
            End If
            If row.Table.Columns.Contains("_ReadOnly") Then
                Dim rowVersion As DataRowVersion = DataRowVersion.Original
                If Not row.HasVersion(rowVersion) Then
                    rowVersion = DataRowVersion.Default
                End If
                Dim readOnlyValue As Object = row("_ReadOnly", rowVersion)
                Return Not IsDBNull(readOnlyValue) AndAlso CType(readOnlyValue, Boolean)
            End If
            Return False
        End Function
    End Class
End Namespace
