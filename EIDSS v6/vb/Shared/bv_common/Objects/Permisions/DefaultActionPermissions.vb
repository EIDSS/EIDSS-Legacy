Namespace Objects
    Public Class DefaultActionPermissions
        Implements IAccessPermission

        Public Sub New()
            ' NOOP
        End Sub

        Public Overridable ReadOnly Property CanDelete() As Boolean Implements IAccessPermission.CanDelete
            Get
                Return False
            End Get
        End Property

        Public Overridable ReadOnly Property CanInsert() As Boolean Implements IAccessPermission.CanInsert
            Get
                Return False
            End Get
        End Property

        Public Overridable ReadOnly Property CanSelect() As Boolean Implements IAccessPermission.CanSelect
            Get
                Return False
            End Get
        End Property

        Public Overridable ReadOnly Property CanUpdate() As Boolean Implements IAccessPermission.CanUpdate
            Get
                Return False
            End Get
        End Property


        Public Overridable Function CanDeleteRow(ByVal row As DataRow) As Boolean Implements IAccessPermission.CanDeleteRow
            Return False
        End Function

        Public Overridable Function CanInsertRow(ByVal row As DataRow) As Boolean Implements IAccessPermission.CanInsertRow
            Return False
        End Function

        Public Overridable Function CanUpdateRow(ByVal row As DataRow) As Boolean Implements IAccessPermission.CanUpdateRow
            Return False
        End Function

        Public Overridable ReadOnly Property CanExecute() As Boolean Implements IAccessPermission.CanExecute
            Get
                Return True
            End Get
        End Property

        Public Overridable Function CanExecuteRow(ByVal row As System.Data.DataRow) As Boolean Implements IAccessPermission.CanExecuteRow
            Return True
        End Function

        Public Property DataAccessObjectType() As System.Enum Implements IAccessPermission.DataAccessObjectType
            Get
                Throw New NotImplementedException()
            End Get
            Set(ByVal value As System.Enum)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Function GetButtonVisibility(ByVal buttonType As DefaultButtonType) As Boolean Implements IAccessPermission.GetButtonVisibility

        End Function
    End Class
End Namespace
