Namespace Core
    Public Class EventInfo
        Public Processed As Integer
        Public ID As Object
        Public [Type] As [Enum]
        Public Sub New(ByVal aType As [Enum], ByVal aID As Object, ByVal aProcessed As Integer)
            [Type] = aType
            ID = aID
            Processed = aProcessed
        End Sub
    End Class
End Namespace



