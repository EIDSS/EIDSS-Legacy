Public Class AvianFarmDetail
    Dim FarmDbService As AvianFarmDetail_DB

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FarmDbService = New AvianFarmDetail_DB
        DbService = FarmDbService

    End Sub
    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindTextEdit(txtBuildingsQty, baseDataSet, "Farm.intBuidings")
        txtBirdsPerBuilding.DataBindings.Add("EditValue", baseDataSet, "Farm.intBirdsPerBuilding")

    End Sub
End Class
