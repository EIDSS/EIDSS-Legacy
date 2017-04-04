
Imports bv.winclient.Core
Imports DevExpress.XtraGrid.Views.Base
Imports EIDSS.model.Enums
Imports DevExpress.XtraGrid.Views.Grid

Public Class AssignTestsList

    Private CaseDiagnosisView As DataView = Nothing

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        colAssignedDiagnosis.ColumnEdit = cbCaseDiagnosis

        AuditObject = New AuditObject(EIDSSAuditObject.daoTest, AuditTable.tlbTesting)
        Dim perm As String = PermissionHelper.InsertPermission(model.Enums.EIDSSPermissionObject.Test)
        Permissions = New StandardAccessPermissions(perm, perm, perm, perm, perm)

        DbService = New AssignTests_DB

    End Sub



    Protected Overrides Sub DefineBinding()
        MyBase.DefineBinding()
        CaseDiagnosisView = New DataView(baseDataSet.Tables("Cases"))
        Core.LookupBinder.BindBaseGridRepositoryLookup(cbCaseDiagnosisEditor, db.BaseReferenceType.rftDiagnosis, HACode)
        cbCaseDiagnosisEditor.DataSource = CaseDiagnosisView
        AddHandler cbCaseDiagnosisEditor.View.CustomDrawCell, AddressOf DrawVetCaseFinalDiagnosis
        If (HACode And HACode.Vector) <> 0 Then
            Core.LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, baseDataSet, LookupTables.StandardDiagnosis, Nothing, , True)
        Else
            Core.LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, baseDataSet, LookupTables.HumanVetDiagnoses, Nothing, , True)
        End If
        TestGrid.DataSource = baseDataSet.Tables("Test")

        AssignedGrid.DataSource = baseDataSet.Tables("Assigned")

        Core.LookupBinder.BindBaseRepositoryLookup(cbTestType, db.BaseReferenceType.rftTestCategory, HACode, False)
        Core.LookupBinder.BindBaseRepositoryLookup(cbTestType2, db.BaseReferenceType.rftTestCategory, HACode, False)
        ContainerGrid.DataSource = baseDataSet.Tables("Containers")
        Core.LookupBinder.BindBaseGridRepositoryLookup(cbCaseDiagnosis, db.BaseReferenceType.rftDiagnosis, HACode.All)
        AddHandler ContainerGridView.CustomDrawCell, AddressOf ContainerGridView_CustomDrawCell

    End Sub

    Private Sub ContainerGridView_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs)
        If e.Column Is colDiagnosis Then
            Dim row As DataRow = CType(sender, GridView).GetDataRow(e.RowHandle)
            Dim finalDiagnosisRow As DataRow() = CaseDiagnosisView.Table.Select(String.Format("idfCase={0} and blnFinalDiagnosis = 1", row("idfCase")))
            If finalDiagnosisRow.Length = 1 AndAlso finalDiagnosisRow(0)("idfsDiagnosis").Equals(row("idfsDiagnosis")) Then
                e.Appearance.Font = WinClientContext.CurrentBoldFont
            End If
        End If
    End Sub

    Private Sub DrawVetCaseFinalDiagnosis(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs)
        Dim row As DataRow = CType(sender, GridView).GetDataRow(e.RowHandle)
        If True.Equals(row("blnFinalDiagnosis")) Then
            e.Appearance.Font = WinClientContext.CurrentBoldFont
        End If
    End Sub

    Private Sub cbDiagnosis_EditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbDiagnosis.EditValueChanged

        If Utils.IsEmpty(cbDiagnosis.EditValue) Then
            TestGrid.DataSource = baseDataSet.Tables("Test")
        Else
            Dim view As DataView = New DataView(baseDataSet.Tables("DiseaseTest"))
            view.RowFilter = "idfsDiagnosis='" + cbDiagnosis.EditValue.ToString + "'"
            TestGrid.DataSource = view
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdAdd.Click
        Dim assigned As DataTable = baseDataSet.Tables("Assigned")
        If assigned Is Nothing Then Exit Sub
        Dim rows As Integer() = TestGridView.GetSelectedRows()
        For Each row As Integer In rows
            Dim data As DataRow = TestGridView.GetDataRow(row)
            For Each sample As DataRow In baseDataSet.Tables("Containers").Rows
                If Utils.IsEmpty(sample("idfsDiagnosis")) Then Continue For
                Dim test As DataRow = assigned.NewRow
                test("idfsTestName") = data("idfsReference")
                test("idfsTestCategory") = data("idfsTestCategory")
                test("TestName") = data("TestName")
                test("idfMaterial") = sample("idfMaterial")
                test("strBarcode") = sample("strBarcode")
                test("idfCase") = sample("idfCase")
                test("idfMonitoringSession") = sample("idfMonitoringSession")
                test("idfsDiagnosis") = sample("idfsDiagnosis")
                Try
                    assigned.Rows.Add(test)
                Catch ex As ConstraintException
                End Try
            Next
        Next
    End Sub

    Public Property HACode() As HACode
        Get
            Return CType(DbService, AssignTests_DB).Code
        End Get
        Set(ByVal value As HACode)
            CType(DbService, AssignTests_DB).Code = value
        End Set
    End Property

    Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRemove.Click
        AssignedGridView.DeleteSelectedRows()
    End Sub

    Private Sub TestGrid_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TestGrid.DoubleClick
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
        CaseDiagnosisView.RowFilter = String.Format("idfCase={0} and (idfsSpeciesType=0 {1})", exp, speciesTypeFilter)

        e.RepositoryItem = cbCaseDiagnosisEditor
    End Sub

    Private Sub AssignedGridView_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AssignedGridView.ShowingEditor
        Dim rowHandle As Integer = AssignedGridView.FocusedRowHandle
        If rowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then Exit Sub
        Dim row As DataRow = AssignedGridView.GetDataRow(rowHandle)
        e.Cancel = Not (row.RowState = DataRowState.Added)
    End Sub
End Class
