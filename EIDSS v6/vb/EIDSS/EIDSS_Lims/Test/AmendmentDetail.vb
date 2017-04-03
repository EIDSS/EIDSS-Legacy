Imports bv.winclient.Core
Imports EIDSS.model.Resources

Public Class AmendmentDetail

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DbService = New BaseDbService
    End Sub
    Protected Overrides Sub DefineBinding()
    End Sub
    Public Property TestType As Long = -1
    Public Property OldTestResult As Long
    Private m_AmendmentRow As DataRow
    Public Property AmendmentRow As DataRow
        Get
            Return m_AmendmentRow
        End Get
        Set(value As DataRow)
            m_AmendmentRow = value
            If Not (m_AmendmentRow Is Nothing) Then
                txtReasonForChange.EditValue = Utils.Str(m_AmendmentRow("strReason"))
                cbNewTestResult.EditValue = m_AmendmentRow("idfsNewTestResult")
            End If
        End Set
    End Property

    Public Overrides Function ValidateData() As Boolean
        If Not MyBase.ValidateData() Then
            Return False
        End If
        If txtReasonForChange.Text.Length < 6 Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("errReasonForChangeIsTooShort", "Reason for changing the test result must contain at least 6 symbols."))
            Return False
        End If
        DbService.IgnoreChanges = True
        Return True
    End Function
    Public Overrides Function HasChanges() As Boolean
        If m_AmendmentRow Is Nothing Then
            Return True
        End If
        Return Not Utils.Str(m_AmendmentRow("strReason")).Equals(txtReasonForChange.EditValue) _
        OrElse Not m_AmendmentRow("idfsNewTestResult").Equals(cbNewTestResult.EditValue)
    End Function

    Private Sub AmendmentDetail_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not bv.winclient.Core.WinUtils.IsComponentInDesignMode(Me) Then
            Core.LookupBinder.BindTestResultLookup(cbNewTestResult, Nothing, Nothing, String.Format("idfsTestName = {0} and idfsReference<>{1}", TestType, OldTestResult))
        End If
    End Sub
End Class
