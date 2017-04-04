Imports System.Runtime.Serialization

Namespace Core
    <Serializable()> _
    Public Class UserErrorException
        Inherits ApplicationException

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
    End Class
End Namespace
