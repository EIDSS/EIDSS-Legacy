Imports bv.common.XmlObjects

Namespace ErrorHandling
    <AttributeUsage(AttributeTargets.Class)> _
    Public Class ServerExceptionAttribute
        Inherits XmlObjectAttribute

        Public Sub New(ByVal name As String)
            MyBase.New("server-exception", name)
        End Sub
    End Class
End Namespace
