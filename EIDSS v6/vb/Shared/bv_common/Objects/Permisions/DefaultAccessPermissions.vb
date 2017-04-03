Namespace Objects
    Public Class DefaultAccessPermissions
        Implements IAccessPermission

        Public Sub New()
            ' NOOP
        End Sub

        Public Overridable ReadOnly Property CanDelete() As Boolean Implements IAccessPermission.CanDelete
            Get
                Return True
            End Get
        End Property

        Public Overridable ReadOnly Property CanInsert() As Boolean Implements IAccessPermission.CanInsert
            Get
                Return True
            End Get
        End Property

        Public Overridable ReadOnly Property CanSelect() As Boolean Implements IAccessPermission.CanSelect
            Get
                Return True
            End Get
        End Property

        Public Overridable ReadOnly Property CanUpdate() As Boolean Implements IAccessPermission.CanUpdate
            Get
                Return True
            End Get
        End Property


        Public Overridable Function CanDeleteRow(ByVal row As DataRow) As Boolean Implements IAccessPermission.CanDeleteRow
            Return True
        End Function

        Public Overridable Function CanInsertRow(ByVal row As DataRow) As Boolean Implements IAccessPermission.CanInsertRow
            Return True
        End Function

        Public Overridable Function CanUpdateRow(ByVal row As DataRow) As Boolean Implements IAccessPermission.CanUpdateRow
            Return True
        End Function


        Public Overridable ReadOnly Property CanExecute() As Boolean Implements IAccessPermission.CanExecute
            Get

            End Get
        End Property

        Public Overridable Function CanExecuteRow(ByVal row As System.Data.DataRow) As Boolean Implements IAccessPermission.CanExecuteRow
            Return True
        End Function

        Public Overridable Function GetButtonVisibility(ByVal buttonType As DefaultButtonType) As Boolean Implements IAccessPermission.GetButtonVisibility
            Return True
        End Function

        Public Overridable Property DataAccessObjectType() As System.Enum Implements IAccessPermission.DataAccessObjectType
            Get
                Return DefaultPermissionObjectType.None
            End Get
            Set(ByVal value As System.Enum)
            End Set
        End Property
    End Class
End Namespace
