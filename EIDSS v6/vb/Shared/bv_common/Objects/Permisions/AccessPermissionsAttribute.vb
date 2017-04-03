
Namespace Objects
    <AttributeUsage(AttributeTargets.Class)> _
    Public Class AccessPermissionsAttribute
        Inherits XmlObjects.XmlObjectAttribute
        Public Sub New(ByVal name As String)
            MyBase.New("access-permissions", name)
        End Sub
    End Class
End Namespace
