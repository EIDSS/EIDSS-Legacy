Namespace Objects
    Public Interface IAccessPermission
        ReadOnly Property CanSelect() As Boolean
        ReadOnly Property CanInsert() As Boolean
        ReadOnly Property CanUpdate() As Boolean
        ReadOnly Property CanDelete() As Boolean
        ReadOnly Property CanExecute() As Boolean
        Property DataAccessObjectType() As [Enum]
        Function CanInsertRow(ByVal row As DataRow) As Boolean
        Function CanUpdateRow(ByVal row As DataRow) As Boolean
        Function CanDeleteRow(ByVal row As DataRow) As Boolean
        Function CanExecuteRow(ByVal row As DataRow) As Boolean
        Function GetButtonVisibility(ByVal buttonType As DefaultButtonType) As Boolean
    End Interface
End Namespace
