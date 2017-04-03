Imports bv.common.XmlObjects

Namespace Objects
    <AttributeUsage(AttributeTargets.Class)> _
    Public Class TableAttribute
        Inherits XmlObjectAttribute

        Public Sub New(ByVal name As String)
            MyBase.New("table", name)
        End Sub
    End Class
End Namespace
