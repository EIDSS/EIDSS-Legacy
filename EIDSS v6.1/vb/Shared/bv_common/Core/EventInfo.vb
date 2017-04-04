Namespace Core
    Public Class EventInfo
        Public Processed As Integer
        Public ID As Object
        Public [Type] As [Enum]
        Public StartReplication As Boolean
        Public Sub New(ByVal aType As [Enum], ByVal aID As Object, ByVal aProcessed As Integer, aStartReplication As Boolean)
            [Type] = aType
            ID = aID
            Processed = aProcessed
            StartReplication = aStartReplication
        End Sub
    End Class
End Namespace



