Namespace Objects
    Public Class ActionPermission
        Inherits BasePermissionObject
        Public Sub New(ByVal permObject As [Enum])
            MyBase.New(PermissionType.ActionPermission, permObject, False, False, False, False, True)
        End Sub
    End Class
End Namespace

