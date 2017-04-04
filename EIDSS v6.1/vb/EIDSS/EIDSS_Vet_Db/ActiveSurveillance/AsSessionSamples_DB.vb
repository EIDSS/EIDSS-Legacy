Public Class AsSessionSamples_DB
    Inherits CaseSamples_Db

    Public Overrides Sub LinkSample(row As DataRow, parentID As Object)
        row("idfMonitoringSession") = parentID
    End Sub

End Class
