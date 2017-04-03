Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Resources

Public Class AggregateSanitaryActionMTXDetail

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuAggregateSanitaryActionMTXEditor", 965, False, model.Enums.MenuIconsSmall.ReferenceMatrix, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnAggregateSanitaryActionMTXEditor"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New AggregateSanitaryActionMTXDetail, Nothing)
        'BaseForm.ShowModal(New AggregateProphylacticActionMTXDetail)
    End Sub
#End Region

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoAggregateMTX, AuditTable.tlbAggrDiagnosticActionMTX)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Reference
        If Not Permissions.CanUpdate Then
            Me.ReadOnly = True
        End If
        Me.m_AggregateMatrixDbService.MatrixKeyField = "idfSanitaryActionMTX"
        Me.m_AggregateMatrixDbService.SelectProcedure = "spAggregateSanitaryActionMatrix_SelectDetail"
        Me.m_AggregateMatrixDbService.PostProcedure = "spAggregateSanitaryActionMatrix_Post"
        Me.MatrixType = AggregateCaseSection.SanitaryAction
        Me.MatrixGrid = Me.gcMTX
    End Sub
    Public Overrides Function ValidateData() As Boolean
        If MyBase.ValidateData() = False Then
            Return False
        End If
        If baseDataSet.Tables.Contains(AggregateMatrix_DB.TableMatrix) Then
            For Each dr As DataRow In MatrixTable.Rows
                If (dr.RowState = DataRowState.Added Or dr.RowState = DataRowState.Modified) Then
                    If (Utils.IsEmpty(dr("idfsSanitaryAction"))) Then
                        MessageForm.Show(EidssMessages.Get("mbIncorrectSanitaryActionRow", "Some records of Sanitary Action Matrix are not fully defined. Please define or delete undefined records."))
                        MatrixGrid.Select()
                        Return False
                    End If
                    If MatrixTable.Select(GetUniqueFilter(dr)).Length <> 0 Then
                        MessageForm.Show(EidssMessages.Get("mbNotUniqueSanitaryActionMatrixRows", "Some records of Sanitary Aggregate Matrix are not unique. Please change or delete duplicated records."))
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
        Core.LookupBinder.BindActionBaseRepositoryLookup(cbSanitaryAction, LookupTables.VetSanitaryAction, HACode.Avian Or HACode.Livestock, "colSanitaryActionName", , "colSanitaryActionCode", , , False, True, True)
        eventManager.AttachDataHandler(AggregateMatrix_DB.TableMatrix + ".idfsSanitaryAction", AddressOf Action_Changed)
    End Sub

    Private Sub gvMTX_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gvMTX.ValidateRow
        Dim r As DataRow = MatrixGridView.GetDataRow(e.RowHandle)
        If (Not r Is Nothing) Then
            If MatrixTable.Select(GetUniqueFilter(r)).Length <> 0 Then
                e.Valid = False
                e.ErrorText = EidssMessages.Get("mbNotUniqueSanitaryActionMatrixRow", "Current record of Sanitary Action Matrix is not unique. Please change or delete it.")
            End If
        End If
    End Sub
    Private Sub Action_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("strActionCode") = LookupCache.GetLookupValue(e.Value, LookupTables.VetSanitaryAction.ToString, "strActionCode")
        MatrixGridView.RefreshRow(MatrixGridView.FocusedRowHandle)
    End Sub
    Private Function GetUniqueFilter(ByVal r As DataRow) As String
        Dim key As Long = -1
        If Not r("idfSanitaryActionMTX") Is DBNull.Value Then
            key = CLng(r("idfSanitaryActionMTX"))
        End If
        Return String.Format("idfsSanitaryAction={0} and idfVersion={1} and idfSanitaryActionMTX<>{2}", r("idfsSanitaryAction"), r("idfVersion"), key)
    End Function
    Protected Overrides Sub Version_Changed(ByVal sender As Object, ByVal e As bv.common.win.DataFieldChangeEventArgs)
        MyBase.Version_Changed(sender, e)
        If VersionTable.Rows(0)("blnIsActive") Is DBNull.Value OrElse CBool(VersionTable.Rows(0)("blnIsActive")) = False Then
            CType(cbSanitaryAction.DataSource, DataView).RowFilter = "intRowStatus <> 1"
        Else
            CType(cbSanitaryAction.DataSource, DataView).RowFilter = ""
        End If
    End Sub

End Class
