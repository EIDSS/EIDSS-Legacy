Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums

Public Class AggregateDiagnosticActionMTXDetail
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        AuditObject = New AuditObject(EIDSSAuditObject.daoAggregateMTX, AuditTable.tlbAggrDiagnosticActionMTX)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Reference
        If Not Permissions.CanUpdate Then
            Me.ReadOnly = True
        End If
        Me.m_AggregateMatrixDbService.MatrixKeyField = "idfAggrDiagnosticActionMTX"
        Me.m_AggregateMatrixDbService.SelectProcedure = "spAggregateDiagnosticActionMatrix_SelectDetail"
        Me.m_AggregateMatrixDbService.PostProcedure = "spAggregateDiagnosticActionMatrix_Post"
        Me.m_AggregateMatrixDbService.MatrixEditorName = Me.GetType().Name
        Me.MatrixType = AggregateCaseSection.DiagnosticAction
        Me.MatrixGrid = Me.gcMTX
    End Sub

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuAggregateDiagnosticActionMTXEditor", 963, False, model.Enums.MenuIconsSmall.ReferenceMatrix, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnAggregateDiagnosticActionMTXEditor"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New AggregateDiagnosticActionMTXDetail, Nothing)
        'BaseForm.ShowModal(New AggregateDiagnosticActionMTXDetail)
    End Sub
#End Region

    Public Overrides Function ValidateData() As Boolean
        If MyBase.ValidateData() = False Then
            Return False
        End If
        If baseDataSet.Tables.Contains(AggregateMatrix_DB.TableMatrix) Then
            For Each dr As DataRow In MatrixTable.Rows
                If (dr.RowState = DataRowState.Added Or dr.RowState = DataRowState.Modified) Then
                    If (Utils.IsEmpty(dr("idfsDiagnosis")) OrElse Utils.IsEmpty(dr("idfsSpeciesType"))) OrElse Utils.IsEmpty(dr("idfsDiagnosticAction")) Then
                        MessageForm.Show(EidssMessages.Get("mbIncorrectDiagnosticActionMTXRows", "Some records of Vet Diagnostic Investigation Matrix are not fully defined. Please define or delete undefined records."))
                        MatrixGrid.Select()
                        Return False
                    End If
                    If MatrixTable.Select(GetUniqueFilter(dr)).Length <> 0 Then
                        MessageForm.Show(EidssMessages.Get("mbNotUniqueDiagnosticActionMTXRows", "Some records of Vet Diagnostic Investigation Matrix are not unique. Please change or delete duplicated records."))
                        MatrixGrid.Select()
                        Return False
                    End If
                End If
            Next
        End If
        Return True
    End Function

    Protected Overrides Sub BindView()
        MyBase.BindView()
        Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDiagnosis, LookupTables.VetAggregatedDiagnosis, True, False, , True)
        Core.LookupBinder.BindBaseRepositoryLookup(cbSpecies, db.BaseReferenceType.rftSpeciesList, HACode.None, AddressOf Core.LookupBinder.AddSpecies)
        Core.LookupBinder.BindBaseRepositoryLookup(cbDiagnosticAction, db.BaseReferenceType.rftDiagnosticActionList, True)
        eventManager.AttachDataHandler(AggregateMatrix_DB.TableMatrix + ".idfsDiagnosis", AddressOf Diagnosis_Changed)
    End Sub

    Private Sub gvMTX_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gvMTX.ValidateRow
        Dim r As DataRow = MatrixGridView.GetDataRow(e.RowHandle)
        If (Not r Is Nothing) Then
            If (Utils.IsEmpty(r("idfsDiagnosis")) OrElse Utils.IsEmpty(r("idfsSpeciesType")) OrElse Utils.IsEmpty(r("idfsDiagnosticAction"))) Then
                e.Valid = False
                e.ErrorText = EidssMessages.Get("mbIncorrectDiagnosticActionMTXRow")
            End If
            If e.Valid Then
                If MatrixTable.Select(GetUniqueFilter(r)).Length <> 0 Then
                    e.Valid = False
                    e.ErrorText = EidssMessages.Get("mbNotUniqueDiagnosticActionMTXRow")
                End If
            End If
        End If
    End Sub
    Private Sub Diagnosis_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("strOIECode") = LookupCache.GetLookupValue(e.Value, LookupTables.VetAggregatedDiagnosis.ToString, "strOIECode")
        MatrixGridView.RefreshRow(gvMTX.FocusedRowHandle)
    End Sub
    Private Function GetUniqueFilter(ByVal r As DataRow) As String
        Dim key As Long = -1
        If Not r("idfAggrDiagnosticActionMTX") Is DBNull.Value Then
            key = CLng(r("idfAggrDiagnosticActionMTX"))
        End If
        Return String.Format("idfsSpeciesType={0} and idfsDiagnosis={1} and idfsDiagnosticAction={2} and idfVersion={3} and idfAggrDiagnosticActionMTX<>{4}", r("idfsSpeciesType"), r("idfsDiagnosis"), r("idfsDiagnosticAction"), r("idfVersion"), key)
    End Function
End Class
