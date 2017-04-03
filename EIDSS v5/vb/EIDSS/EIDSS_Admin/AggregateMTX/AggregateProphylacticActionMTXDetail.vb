Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Resources

Public Class AggregateProphylacticActionMTXDetail
    Inherits AggregateMatrixBase
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoAggregateMTX, AuditTable.tlbAggrProphylacticActionMTX)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Reference
        If Not Permissions.CanUpdate Then
            Me.ReadOnly = True
        End If
        Me.m_AggregateMatrixDbService.MatrixKeyField = "idfAggrProphylacticActionMTX"
        Me.m_AggregateMatrixDbService.SelectProcedure = "spAggregateProphylacticActionMatrix_SelectDetail"
        Me.m_AggregateMatrixDbService.PostProcedure = "spAggregateProphylacticActionMatrix_Post"
        Me.MatrixType = AggregateCaseSection.ProphylacticAction
        Me.MatrixGrid = Me.gcMTX

    End Sub


#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuAggregateProphylacticActionMTXEditor", 964, False, model.Enums.MenuIconsSmall.ReferenceMatrix, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnAggregateProphylacticActionMTXEditor"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New AggregateProphylacticActionMTXDetail, Nothing)
        'BaseForm.ShowModal(New AggregateProphylacticActionMTXDetail)
    End Sub
#End Region


    Public Overrides Function ValidateData() As Boolean
        If MyBase.ValidateData() = False Then
            Return False
        End If
        If baseDataSet.Tables.Contains(AggregateMatrix_DB.TableMatrix) Then
            For Each dr As DataRow In MatrixTable.Rows
                If (dr.RowState = DataRowState.Added Or dr.RowState = DataRowState.Modified) Then
                    If (Utils.IsEmpty(dr("idfsDiagnosis")) OrElse Utils.IsEmpty(dr("idfsSpeciesType"))) OrElse Utils.IsEmpty(dr("idfsProphilacticAction")) Then
                        MessageForm.Show(EidssMessages.Get("mbIncorrectProphylacticActionMTXRows", "Some records of Vet Prophylactic Measure Matrix are not fully defined. Please define or delete undefined records."))
                        MatrixGrid.Select()
                        Return False
                    End If
                    If MatrixTable.Select(GetUniqueFilter(dr)).Length <> 0 Then
                        MessageForm.Show(EidssMessages.Get("mbNotUniqueProphylacticActionMTXRows", "Some records of Vet Prophylactic Measure Matrix are not unique. Please change or delete duplicated records."))
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
        Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDiagnosis, LookupTables.VetAggregatedDiagnosis, True, False)
        Core.LookupBinder.BindBaseRepositoryLookup(cbSpecies, BaseReferenceType.rftSpeciesList, HACode.None, AddressOf Core.LookupBinder.AddSpecies)
        Core.LookupBinder.BindActionBaseRepositoryLookup(cbProphylacticAction, LookupTables.VetProphilacticAction, HACode.Avian Or HACode.Livestock, , , , , , False, True, True)
        eventManager.AttachDataHandler(AggregateMatrix_DB.TableMatrix + ".idfsDiagnosis", AddressOf Diagnosis_Changed)
        eventManager.AttachDataHandler(AggregateMatrix_DB.TableMatrix + ".idfsProphilacticAction", AddressOf Action_Changed)
    End Sub

    Private Sub gvMTX_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gvMTX.ValidateRow
        Dim r As DataRow = gvMTX.GetDataRow(e.RowHandle)
        If (Not r Is Nothing) Then
            If (Utils.IsEmpty(r("idfsDiagnosis")) OrElse Utils.IsEmpty(r("idfsSpeciesType")) OrElse Utils.IsEmpty(r("idfsProphilacticAction"))) Then
                e.Valid = False
                e.ErrorText = EidssMessages.Get("mbIncorrectProphylacticActionMTXRow")
            End If
            If e.Valid Then
                If MatrixTable.Select(GetUniqueFilter(r)).Length <> 0 Then
                    e.Valid = False
                    e.ErrorText = EidssMessages.Get("mbNotUniqueProphylacticActionMTXRow")
                End If
            End If
        End If
    End Sub
    Private Sub Diagnosis_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("strOIECode") = LookupCache.GetLookupValue(e.Value, LookupTables.VetAggregatedDiagnosis.ToString, "strOIECode")
        gvMTX.RefreshRow(gvMTX.FocusedRowHandle)
    End Sub
    Private Function GetUniqueFilter(ByVal r As DataRow) As String
        Dim key As Long = -1
        If Not r("idfAggrProphylacticActionMTX") Is DBNull.Value Then
            key = CLng(r("idfAggrProphylacticActionMTX"))
        End If
        Return String.Format("idfsSpeciesType={0} and idfsDiagnosis={1} and idfsProphilacticAction={2} and idfVersion={3} and idfAggrProphylacticActionMTX<>{4}", r("idfsSpeciesType"), r("idfsDiagnosis"), r("idfsProphilacticAction"), r("idfVersion"), key)
    End Function

    Private Sub Action_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("strActionCode") = LookupCache.GetLookupValue(e.Value, LookupTables.VetProphilacticAction.ToString, "strActionCode")
        gvMTX.RefreshRow(gvMTX.FocusedRowHandle)
    End Sub
    Protected Overrides Sub Version_Changed(ByVal sender As Object, ByVal e As bv.common.win.DataFieldChangeEventArgs)
        MyBase.Version_Changed(sender, e)
        If VersionTable.Rows(0)("blnIsActive") Is DBNull.Value OrElse CBool(VersionTable.Rows(0)("blnIsActive")) = False Then
            CType(cbProphylacticAction.DataSource, DataView).RowFilter = "intRowStatus <> 1"
        Else
            CType(cbProphylacticAction.DataSource, DataView).RowFilter = ""
        End If
    End Sub
End Class
