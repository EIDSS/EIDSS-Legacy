
Imports bv.common.Enums

Public Class BatchSelectTestResult
    Inherits BaseDetailForm


    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        DbService = New BaseDbService
    End Sub


    Public Overrides Function Post(Optional postType As PostType = PostType.FinalPosting) As Boolean
        Return True
    End Function
    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As EventArgs)
        OkButton.Enabled = Not Utils.IsEmpty(LookUpTestResult.Text)
    End Sub

    Private Sub BatchSelectTestResult_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim testType As Object = StartUpParameters("idfsTestName")
        Dim filter As String = String.Format("idfsTestName = {0}", testType)
        Core.LookupBinder.BindTestResultLookup(LookUpTestResult, Nothing, Nothing, filter)

    End Sub
End Class