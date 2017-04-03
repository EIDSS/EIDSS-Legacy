Public Class RootFarmTree

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FarmTreeDbService = New RootFarmTree_DB
        DbService = FarmTreeDbService
        ShowGeneralInfoOnly = True
    End Sub
End Class
