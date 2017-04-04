Imports EIDSS.model.Enums
Public Enum JobType
    Replication
    Filtration
End Enum

Public Interface IJobProvider
    Function Run(ByVal aJobName As String, rc As ReplicationController) As Integer
    ReadOnly Property IsRunning() As Boolean
    ReadOnly Property LastError() As String
    ReadOnly Property JobName As String
    ReadOnly Property ReplicationController As ReplicationController
    Property Type As JobType
End Interface
