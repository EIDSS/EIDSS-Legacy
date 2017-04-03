Public Interface IJobProvider
    Function Run(ByVal jobName As String, rc As ReplicationController) As Integer
    ReadOnly Property IsRunning() As Boolean
    ReadOnly Property LastError() As String
    ReadOnly Property JobName As String
    ReadOnly Property ReplicationController As ReplicationController
End Interface
