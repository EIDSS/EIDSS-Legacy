Namespace Objects
    Public Interface IPermissionObject
        Property Name() As String
        Property Description() As String
        Property [Select]() As Boolean
        Property Insert() As Boolean
        Property Update() As Boolean
        Property [Delete]() As Boolean
        Property Execute() As Boolean
        ReadOnly Property SelectPermissionName() As String
        ReadOnly Property InsertPermissionName() As String
        ReadOnly Property UpdatePermissionName() As String
        ReadOnly Property DeletePermissionName() As String
        ReadOnly Property ExecutePermissionName() As String
        Sub Parse(ByVal permissionString As String)
        Property Type() As PermissionType
    End Interface
End Namespace

