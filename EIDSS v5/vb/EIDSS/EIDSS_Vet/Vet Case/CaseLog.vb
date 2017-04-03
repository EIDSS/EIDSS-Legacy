Imports DevExpress.XtraEditors.Controls
Imports bv.winclient.Core
Imports bv.winclient.Localization
Imports bv.common.Resources

Public Class CaseLog
    Dim CaseLogDbService As CaseLog_DB

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CaseLogDbService = New CaseLog_DB
        DbService = CaseLogDbService

    End Sub

    Protected Overrides Sub DefineBinding()
        CaseLogGrid.DataSource = baseDataSet.Tables(CaseLog_DB.TableCaseLog)
        EIDSS.Core.LookupBinder.BindPersonRepositoryLookup(cbEnteredBy, False)
        Dim logStatusView As DataView = LookupCache.Get(BaseReferenceType.rftVetCaseLogStatus)
        For Each row As DataRowView In logStatusView
            rgStatus.Items.Add(New RadioGroupItem(row("idfsReference"), row("Name").ToString))
        Next
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        If Not IsRowValid(, True) Then
            Return
        End If

        Dim row As DataRow = CaseLogDbService.AddLogRecord(baseDataSet)
        DxControlsHelper.SetRowHandleForDataRow(CaseLogView, row, "idfVetCaseLog")
        CaseLogView.FocusedColumn = colActionRequired
        CaseLogGrid.Select()
        Application.DoEvents()
        CaseLogView.ShowEditor()

    End Sub
    Private Sub cmdDeleteTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteTest.Click
        Dim Row As DataRow = CaseLogView.GetDataRow(CaseLogView.FocusedRowHandle)
        If Row Is Nothing Then Return
        If WinUtils.ConfirmDelete Then
            Row.Delete()
        End If
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Return ValidateGridData(True)
    End Function

    Public Function ValidateGridData(ByVal ShowError As Boolean) As Boolean
        If Me.CaseLogView.FocusedRowHandle >= 0 Then
            If Not IsRowValid(CaseLogView.FocusedRowHandle, ShowError) Then
                If ShowError Then CaseLogGrid.Select()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function IsRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
        If index = -1 Then index = CaseLogView.FocusedRowHandle
        If index < 0 Then Return True
        Dim row As DataRow = CaseLogView.GetDataRow(index)

        If row Is Nothing Then Return True
        Dim msg As String = ""
        If row("datCaseLogDate") Is DBNull.Value Then
            If showError Then
                msg += String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), CaseLogView.Columns("datCaseLogDate").Caption) + vbCrLf
                ErrorForm.ShowWarningDirect(msg)
                CaseLogView.FocusedColumn = colDate
                CaseLogView.FocusedRowHandle = index
            End If
            Return False
        End If
        If row("idfPerson") Is DBNull.Value Then
            If showError Then
                msg += String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), CaseLogView.Columns("idfPerson").Caption) + vbCrLf
                ErrorForm.ShowWarningDirect(msg)
                CaseLogView.FocusedColumn = colEnteredBy
                CaseLogView.FocusedRowHandle = index
            End If
            Return False
        End If

        Return True
    End Function
    Dim m_Updating As Boolean
    Private Sub logStatusView_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles CaseLogView.FocusedRowChanged
        If Loading OrElse m_Updating Then Return
        m_Updating = True
        Try
            If e.PrevFocusedRowHandle >= 0 AndAlso IsRowValid(e.PrevFocusedRowHandle) = False Then
                CaseLogView.FocusedRowHandle = e.PrevFocusedRowHandle
                Return
            End If
        Finally
            m_Updating = False
        End Try
    End Sub
End Class
