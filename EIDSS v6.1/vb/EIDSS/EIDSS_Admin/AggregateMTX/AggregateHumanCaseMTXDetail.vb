Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums

Public Class AggregateHumanCaseMTXDetail
#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuAggregateHumanCaseMTXEditor", 960, False, model.Enums.MenuIconsSmall.ReferenceMatrix, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnAggregateHumanCaseMTXEditor"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New AggregateHumanCaseMTXDetail, Nothing)
        'BaseForm.ShowModal(New AggregateProphylacticActionMTXDetail)
    End Sub
#End Region
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

        Me.m_AggregateMatrixDbService.MatrixKeyField = "idfHumanCaseMtx"
        Me.m_AggregateMatrixDbService.SelectProcedure = "spAggregateHumanCaseMatrix_SelectDetail"
        Me.m_AggregateMatrixDbService.PostProcedure = "spAggregateHumanCaseMatrix_Post"
        Me.m_AggregateMatrixDbService.MatrixEditorName = Me.GetType().Name
        Me.MatrixType = AggregateCaseSection.HumanCase
        Me.MatrixGrid = Me.gcMTX
    End Sub
    Public Overrides Function ValidateData() As Boolean
        If MyBase.ValidateData() = False Then
            Return False
        End If
        If baseDataSet.Tables.Contains(AggregateMatrix_DB.TableMatrix) Then
            For Each dr As DataRow In MatrixTable.Rows
                If (dr.RowState = DataRowState.Added Or dr.RowState = DataRowState.Modified) Then
                    If (Utils.IsEmpty(dr("idfsDiagnosis"))) Then
                        MessageForm.Show(EidssMessages.Get("mbIncorrectHumanCaseMatrixRow", "Some records of Human Aggregate Case Matrix are not fully defined. Please define or delete undefined records."))
                        MatrixGrid.Select()
                        Return False
                    End If
                    If MatrixTable.Select(GetUniqueFilter(dr)).Length <> 0 Then
                        MessageForm.Show(EidssMessages.Get("mbNotUniqueHumanCaseMatrixRows", "Some records of Human Aggregate Case Matrix are not unique. Please change or delete duplicated records."))
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
        Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDiagnosis, LookupTables.HumanAggregatedDiagnosis, True, False, , True)
        eventManager.AttachDataHandler(AggregateMatrix_DB.TableMatrix + ".idfsDiagnosis", AddressOf Diagnosis_Changed)
    End Sub

    Private Sub gvMTX_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gvMTX.ValidateRow
        Dim r As DataRow = MatrixGridView.GetDataRow(e.RowHandle)
        If (Not r Is Nothing) Then
            If MatrixTable.Select(GetUniqueFilter(r)).Length <> 0 Then
                e.Valid = False
                e.ErrorText = EidssMessages.Get("mbNotUniqueHumanCaseMatrixRow", "Current record of Human Aggregate Case Matrix is not unique. Please change or delete it.")
            End If
        End If
    End Sub
    Private Sub Diagnosis_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("strIDC10") = LookupCache.GetLookupValue(e.Value, LookupTables.HumanAggregatedDiagnosis.ToString, "strIDC10")
        MatrixGridView.RefreshRow(MatrixGridView.FocusedRowHandle)
    End Sub
    Private Function GetUniqueFilter(ByVal r As DataRow) As String
        Dim key As Long = -1
        If Not r("idfHumanCaseMtx") Is DBNull.Value Then
            key = CLng(r("idfHumanCaseMtx"))
        End If
        Return String.Format("idfsDiagnosis={0} and idfVersion={1} and idfHumanCaseMtx<>{2}", r("idfsDiagnosis"), r("idfVersion"), key)
    End Function

End Class
