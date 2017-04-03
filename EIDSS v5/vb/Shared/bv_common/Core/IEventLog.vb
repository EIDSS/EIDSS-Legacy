Namespace Core
    Public Interface IEventLog
        Function CreateEvent(ByVal et As [Enum], ByVal ObjectID As Object, Optional ByVal UserID As Object = Nothing, Optional ByVal transaction As IDbTransaction = Nothing) As Object
        Function CreateProcessedEvent(ByVal et As [Enum], ByVal ObjectID As Object, ByVal Processed As Integer, Optional ByVal UserID As Object = Nothing, Optional ByVal transaction As IDbTransaction = Nothing) As Object
        Sub CheckNotificationService(Optional ByVal transaction As IDbTransaction = Nothing)
        Sub StartReplication()
    End Interface

End Namespace
