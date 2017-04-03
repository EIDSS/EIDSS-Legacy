Imports DevExpress.XtraEditors.Controls
Imports bv.winclient.Core
Imports bv.winclient.Localization
Imports bv.common.Resources
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports eidss.model.Resources

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
        eidss.Core.LookupBinder.BindPersonRepositoryLookup(cbEnteredBy, False, HACode.Livestock Or HACode.Avian)
        Dim logStatusView As DataView = LookupCache.Get(BaseReferenceType.rftVetCaseLogStatus)
        For Each row As DataRowView In logStatusView
            rgStatus.Items.Add(New RadioGroupItem(row("idfsReference"), row("Name").ToString))
        Next
        UpdateButtons()

    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Public Function ValidateGridData(ByVal showError As Boolean) As Boolean
        For i As Integer = 0 To CaseLogView.DataRowCount - 1
            'If Me.CaseLogView.FocusedRowHandle >= 0 Then
            If Not IsRowValid(i, showError) Then
                If showError Then CaseLogGrid.Select()
                Return False
            End If
            'End If
        Next
        Return True
    End Function

    Private Function IsRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
        If index = -1 Then index = CaseLogView.FocusedRowHandle
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
        If CType(row("datCaseLogDate"), DateTime).Date > DateTime.Today Then
            If showError Then
                msg += String.Format(EidssMessages.Get("ErrUnstrictChainDate"), CaseLogView.Columns("datCaseLogDate").Caption, CType(row("datCaseLogDate"), Date), BvMessages.Get("CurrentDate"), DateTime.Today) + vbCrLf
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

    Private Sub CaseLogView_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles CaseLogView.CellValueChanged
        UpdateButtons(True)
    End Sub
    Private Sub logStatusView_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles CaseLogView.FocusedRowChanged
        If Loading OrElse m_Updating Then Return
        m_Updating = True
        Try
            If e.PrevFocusedRowHandle >= 0 AndAlso IsRowValid(e.PrevFocusedRowHandle) = False Then
                CaseLogView.FocusedRowHandle = e.PrevFocusedRowHandle
                Return
            End If
        Finally
            UpdateButtons()
            m_Updating = False
        End Try
    End Sub
    Private Sub CaseLogView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles CaseLogView.InitNewRow
        Dim row As DataRow = CaseLogView.GetDataRow(e.RowHandle)
        CaseLogDbService.InitRow(row)
    End Sub

    Public Sub UpdateButtons(Optional showError As Boolean = False)
        Dim rowSelected As Boolean = CaseLogView.FocusedRowHandle <> GridControl.NewItemRowHandle AndAlso Not CaseLogView.GetFocusedDataRow() Is Nothing
        cmdDeleteTest.Enabled = Not [ReadOnly] AndAlso rowSelected
        CaseLogView.OptionsBehavior.Editable = Not [ReadOnly]
        EnableRowAdding((Not [ReadOnly] AndAlso IsRowValid(, showError)))
    End Sub

    Public Sub EnableRowAdding(enable As Boolean)
        If (CaseLogView.FocusedRowHandle = GridControl.NewItemRowHandle) Then
            Return
        End If
        If (Not enable) Then
            CaseLogView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Else
            CaseLogView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
        End If
    End Sub
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            MyBase.ReadOnly = Value
            UpdateButtons()
        End Set
    End Property

End Class
