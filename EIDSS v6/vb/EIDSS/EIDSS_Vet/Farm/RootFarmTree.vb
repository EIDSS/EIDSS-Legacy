Public Class RootFarmTree

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FarmTreeDbService = New RootFarmTree_DB
        DbService = FarmTreeDbService
        ShowGeneralInfoOnly = True
    End Sub
    Public Overrides Property [ReadOnly] As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(value As Boolean)
            If TypeOf (ParentObject) Is FarmDetail Then
                If (CType(ParentObject, FarmDetail).Permissions.CanUpdate = False) Then
                    MyBase.ReadOnly = False
                    Return
                End If
            End If
            MyBase.ReadOnly = True
        End Set
    End Property


End Class
