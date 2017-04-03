
Public Class AssignTestsList

    Private CaseDiagnosisView As DataView = Nothing

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.colAssignedDiagnosis.ColumnEdit = Me.cbCaseDiagnosis

        Me.AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoTest, AuditTable.tlbTesting)
        Dim perm As String = PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.Test)
        Me.Permissions = New StandardAccessPermissions(perm, perm, perm, perm, perm)

        Me.DbService = New AssignTests_DB

    End Sub


 
    Protected Overrides Sub DefineBinding()
        MyBase.DefineBinding()
        If (HACode And HACode.Vector) <> 0 Then
            Core.LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, baseDataSet, LookupTables.StandardDiagnosis, Nothing, , True)
        Else
            Core.LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, baseDataSet, LookupTables.HumanVetDiagnoses, Nothing, , True)
        End If
        Me.TestGrid.DataSource = Me.baseDataSet.Tables("Test")

        Me.AssignedGrid.DataSource = Me.baseDataSet.Tables("Assigned")

        Core.LookupBinder.BindBaseRepositoryLookup(cbTestType, BaseReferenceType.rftTestForDiseaseType, HACode, False)
        Core.LookupBinder.BindBaseRepositoryLookup(cbTestType2, BaseReferenceType.rftTestForDiseaseType, HACode, False)
        Me.ContainerGrid.DataSource = Me.baseDataSet.Tables("Containers")
        Core.LookupBinder.BindBaseRepositoryLookup(Me.cbCaseDiagnosis, BaseReferenceType.rftDiagnosis, EIDSS.HACode.All, False)
        CaseDiagnosisView = New DataView(Me.baseDataSet.Tables("Cases"))
        Me.cbCaseDiagnosisEditor.DataSource = CaseDiagnosisView

    End Sub

    Private Sub cbDiagnosis_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDiagnosis.EditValueChanged

        If Utils.IsEmpty(Me.cbDiagnosis.EditValue) Then
            Me.TestGrid.DataSource = Me.baseDataSet.Tables("Test")
        Else
            Dim view As DataView = New DataView(Me.baseDataSet.Tables("DiseaseTest"))
            view.RowFilter = "idfsDiagnosis='" + Me.cbDiagnosis.EditValue.ToString + "'"
            Me.TestGrid.DataSource = view
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim assigned As DataTable = Me.baseDataSet.Tables("Assigned")
        If assigned Is Nothing Then Exit Sub
        Dim rows As Integer() = Me.TestGridView.GetSelectedRows()
        For Each row As Integer In rows
            Dim data As DataRow = Me.TestGridView.GetDataRow(row)
            For Each sample As DataRow In Me.baseDataSet.Tables("Containers").Rows
                If Utils.IsEmpty(sample("idfsDiagnosis")) Then Continue For
                Dim test As DataRow = assigned.NewRow
                test("idfsTestType") = data("idfsReference")
                test("idfsTestForDiseaseType") = data("idfsTestForDiseaseType")
                test("TestName") = data("TestName")
                test("idfContainer") = sample("idfContainer")
                test("strBarcode") = sample("strBarcode")
                test("idfCase") = sample("idfCase")
                test("idfMonitoringSession") = sample("idfMonitoringSession")
                test("idfsDiagnosis") = sample("idfsDiagnosis")
                Try
                    assigned.Rows.Add(test)
                Catch ex As System.Data.ConstraintException
                End Try
            Next
        Next
    End Sub

    Public Property HACode() As HACode
        Get
            Return CType(Me.DbService, AssignTests_DB).Code
        End Get
        Set(ByVal value As HACode)
            CType(Me.DbService, AssignTests_DB).Code = value
        End Set
    End Property

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        Me.AssignedGridView.DeleteSelectedRows()
    End Sub

    Private Sub TestGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestGrid.DoubleClick
        cmdAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub ContainerGridView_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles ContainerGridView.CustomRowCellEditForEditing, AssignedGridView.CustomRowCellEditForEditing
        If e.Column.FieldName <> "idfsDiagnosis" Then Exit Sub
        Dim row As DataRow = e.Column.View.GetDataRow(e.RowHandle)
        Dim exp As String = Utils.Str(row("idfCase")) + Utils.Str(row("idfMonitoringSession"))
        Dim speciesTypeFilter As String = ""
        If Not row("idfMonitoringSession") Is DBNull.Value AndAlso Not row("idfsSpeciesType") Is DBNull.Value Then
            speciesTypeFilter = String.Format("or idfsSpeciesType={0}", CLng(row("idfsSpeciesType")))
        End If
        If Utils.IsEmpty(exp) Then
            If Not Utils.IsEmpty(row("idfVectorSurveillanceSession")) Then
                exp = "0" 'all vector diagnosis 
            Else
                exp = "-1" 'empty list
            End If
        End If
        Me.CaseDiagnosisView.RowFilter = String.Format("idfCase={0} and (idfsSpeciesType=0 {1})", exp, speciesTypeFilter)

        e.RepositoryItem = Me.cbCaseDiagnosisEditor
    End Sub

    Private Sub AssignedGridView_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AssignedGridView.ShowingEditor
        Dim handle As Integer = AssignedGridView.FocusedRowHandle
        If handle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then Exit Sub
        Dim row As DataRow = AssignedGridView.GetDataRow(handle)
        e.Cancel = Not (row.RowState = DataRowState.Added)
    End Sub
End Class
