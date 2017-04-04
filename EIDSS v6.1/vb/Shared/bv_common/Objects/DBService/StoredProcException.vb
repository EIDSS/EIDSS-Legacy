Imports System.Runtime.Serialization

Namespace Objects.DBService
    <Serializable()> _
    Public Class StoredProcException
        Inherits ApplicationException

        Public Sub New()
            ' NOOP
        End Sub
        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
    End Class
End Namespace