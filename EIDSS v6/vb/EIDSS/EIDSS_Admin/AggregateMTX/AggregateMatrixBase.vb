Imports System.ComponentModel
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports bv.winclient.Core
Imports EIDSS.model.Resources

Public Class AggregateMatrixBase
    Friend WithEvents m_MatrixDataView As DataView
    Protected m_AggregateMatrixDbService As AggregateMatrix_DB

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_AggregateMatrixDbService = New AggregateMatrix_DB
        DbService = m_AggregateMatrixDbService

    End Sub

    Protected Overrides Sub DefineBinding()
        m_DoDeleteAfterNo = False
        BindView()
        Core.LookupBinder.BindTextEdit(txtVersionName, baseDataSet, AggregateMatrix_DB.TableCurrentVersion + ".MatrixName")
        Core.LookupBinder.BindDateEdit(dtVersionDate, baseDataSet, AggregateMatrix_DB.TableCurrentVersion + ".datStartDate")

        Core.LookupBinder.BindAggregateMatrixVersionLookup(cbSelectVersion, baseDataSet, AggregateMatrix_DB.TableCurrentVersion + ".idfVersion", MatrixType, False)
        cbSelectVersion.Properties.DataSource = VersionListView
        'VersionListView.Sort = "idfVersion"
        eventManager.AttachDataHandler(AggregateMatrix_DB.TableCurrentVersion + ".MatrixName", AddressOf VersionDescription_Changed)
        eventManager.AttachDataHandler(AggregateMatrix_DB.TableCurrentVersion + ".datStartDate", AddressOf VersionDescription_Changed)
        eventManager.AttachDataHandler(AggregateMatrix_DB.TableCurrentVersion + ".idfVersion", AddressOf Version_Changed)
        eventManager.Cascade(AggregateMatrix_DB.TableCurrentVersion + ".idfVersion")
    End Sub

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Protected ReadOnly Property MatrixTable() As DataTable
        Get
            Return baseDataSet.Tables(AggregateMatrix_DB.TableMatrix)
        End Get
    End Property

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Protected ReadOnly Property VersionListTable() As DataTable
        Get
            Return baseDataSet.Tables(AggregateMatrix_DB.TableVersionsList)
        End Get
    End Property

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Protected ReadOnly Property VersionListView() As DataView
        Get
            Return VersionListTable.DefaultView
        End Get
    End Property

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Protected ReadOnly Property VersionTable() As DataTable
        Get
            Return baseDataSet.Tables(AggregateMatrix_DB.TableCurrentVersion)
        End Get
    End Property

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Protected ReadOnly Property CurrentVersion() As Long
        Get
            If (VersionTable.Rows.Count > 0) Then
                Return CLng(VersionTable.Rows(0)("idfVersion"))
            Else
                Return -1
            End If
        End Get
    End Property

    Dim m_MatrixGrid As GridControl
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property MatrixGrid() As GridControl
        Get
            Return m_MatrixGrid
        End Get
        Set(ByVal value As GridControl)
            m_MatrixGrid = value
        End Set
    End Property

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property MatrixGridView() As GridView
        Get
            If MatrixGrid Is Nothing Then
                Return Nothing
            End If
            Return CType(m_MatrixGrid.MainView, GridView)
        End Get
    End Property
    Dim m_MatrixType As AggregateCaseSection

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property MatrixType() As AggregateCaseSection
        Get
            Return m_MatrixType
        End Get
        Set(ByVal value As AggregateCaseSection)
            m_MatrixType = value
            If Not m_AggregateMatrixDbService Is Nothing Then
                m_AggregateMatrixDbService.MatrixType = value
            End If
        End Set
    End Property

    Protected Overridable Sub BindView()
        If baseDataSet.Tables.Contains(AggregateMatrix_DB.TableMatrix) Then
            If m_MatrixDataView Is Nothing Then
                m_MatrixDataView = MatrixTable.DefaultView
                m_MatrixDataView.Sort = "intNumRow"
                AddHandler MatrixTable.TableNewRow, AddressOf OnMatrixRowAdded
                MatrixGrid.DataSource = MatrixTable
            End If
        End If
    End Sub

    Private Sub OnMatrixRowAdded(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        If m_MatrixDataView.Count = 0 Then
            e.Row("intNumRow") = 0
        Else
            Dim row As DataRowView = m_MatrixDataView(m_MatrixDataView.Count - 1)
            If row("intNumRow") Is DBNull.Value Then
                e.Row("intNumRow") = m_MatrixDataView.Count
            Else
                e.Row("intNumRow") = CInt(row("intNumRow")) + 1
            End If
        End If

    End Sub

    '    Private Sub OnMatrixRowAdded1(ByVal sender As Object, ByVal e As ListChangedEventArgs)
    '        If e.ListChangedType = ListChangedType.ItemAdded Then
    '
    '            If e.NewIndex = 0 Then
    '                MatrixTable.Columns("intNumRow").DefaultValue = 0
    '                'MatrixDataView(e.NewIndex)("idfNumRow") = 0
    '            Else
    '                Dim row As DataRowView = m_MatrixDataView(e.NewIndex - 1)
    '                If row("idfNumRow") Is DBNull.Value Then
    '                    'MatrixDataView(e.NewIndex)("idfNumRow") = MatrixDataView.Count
    '                Else
    '                    MatrixTable.Columns("intNumRow").DefaultValue = CInt(row("idfNumRow")) + 1
    '
    '                    'MatrixDataView(e.NewIndex)("idfNumRow") = CInt(row("idfNumRow")) + 1
    '                End If
    '            End If
    '        End If
    '    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim row As DataRow = GetCurrentRow(AggregateMatrix_DB.TableMatrix)
        If Not row Is Nothing AndAlso WinUtils.ConfirmDelete Then
            row.Delete()
        End If
    End Sub

    Private Sub DisplayCurrentVersionMatrix()
        If Not m_MatrixDataView Is Nothing Then
            MatrixGrid.DataSource = Nothing
            MatrixTable.Columns("idfVersion").DefaultValue = CurrentVersion
            MatrixGrid.DataSource = MatrixTable
            m_MatrixDataView.RowFilter = String.Format("idfVersion = {0}", CurrentVersion)
        End If
    End Sub


    Protected Overridable Sub Version_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim row As DataRowView = FindVersionRow(e.Value)
        If Not row Is Nothing Then
            VersionTable.Rows(0)("MatrixName") = row("MatrixName")
            VersionTable.Rows(0)("datStartDate") = row("datStartDate")
            VersionTable.Rows(0)("blnIsActive") = row("blnIsActive")
            VersionTable.Rows(0)("blnIsDefault") = row("blnIsDefault")
            VersionTable.Rows(0).EndEdit()
        End If
        SetEditMode()
        DisplayCurrentVersionMatrix()
    End Sub

    Private Sub VersionDescription_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim row As DataRowView = FindVersionRow(CurrentVersion)
        If Not row Is Nothing Then
            If e.Column.ColumnName <> "datStartDate" OrElse row("blnIsActive").Equals(True) Then
                row(e.Column.ColumnName) = e.Value
                row.EndEdit()
            End If
        End If
    End Sub

    Private Sub btnDeleteVersion_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnDeleteVersion.Click
        'Last version can't be deleted
        If VersionListView.Count < 2 Then
            Return
        End If
        If Not WinUtils.ConfirmDelete Then
            Return
        End If
        While m_MatrixDataView.Count > 0
            m_MatrixDataView(0).Delete()
        End While
        Dim row As DataRowView = FindVersionRow(CurrentVersion)
        If Not row Is Nothing Then
            row.Delete()
        End If
        VersionTable.Rows(0)("idfVersion") = VersionListView(0)("idfVersion")
        eventManager.Cascade(AggregateMatrix_DB.TableCurrentVersion + ".idfVersion")
    End Sub

    Private Sub btnNewVersion_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNewVersion.Click
        If Not ValidateData() Then
            Return
        End If
        If VersionListView.Table.Select("blnIsActive<>1").Length > 0 Then
            ErrorForm.ShowMessageDirect(EidssMessages.Get("msgOnlyOneNonActiveMatrixEnabled", "You can have only one inactive matrix. Please activate currently inactive matrix before creating the new one."))
            Return
        End If
        m_AggregateMatrixDbService.CreateNewMatrixVersion(baseDataSet, CurrentVersion)
    End Sub

    Private Sub btnActivateVersion_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnActivateVersion.Click
        If m_MatrixDataView.Count = 0 Then
            ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCantActivateEmptyMatrix", "Empty matrix can't be activated."))
            Return
        End If
        VersionTable.Rows(0)("blnIsActive") = 1
        VersionTable.Rows(0)("blnIsDefault") = 1
        For Each row As DataRowView In VersionListView
            If row("idfVersion").Equals(CurrentVersion) Then
                row("blnIsActive") = 1
                row("blnIsDefault") = 1
                If VersionTable.Rows(0)("datStartDate") Is DBNull.Value Then
                    row("datStartDate") = DateTime.Now
                    VersionTable.Rows(0)("datStartDate") = row("datStartDate")
                Else
                    row("datStartDate") = VersionTable.Rows(0)("datStartDate")
                End If
            Else
                row("blnIsDefault") = 0
                If row("blnIsActive") Is DBNull.Value Then
                    row("blnIsActive") = 0
                End If
            End If
            row("intState") = CInt(IIf(row("blnIsActive").Equals(True), 1, 0)) + CInt(IIf(row("blnIsDefault").Equals(True), 1, 0))
            row.EndEdit()
        Next
        SetEditMode()
    End Sub
    Private Function FindVersionRow(ByVal version As Object) As DataRowView
        For Each row As DataRowView In VersionListView
            If row("idfVersion").Equals(version) Then
                Return row
            End If
        Next
        Return Nothing
    End Function
    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As EventArgs)
        If VersionTable Is Nothing Then
            btnActivateVersion.Enabled = False
            btnDown.Enabled = False
            btnUp.Enabled = False
            Return
        End If
        btnActivateVersion.Enabled = Not [ReadOnly] AndAlso VersionTable.Rows.Count > 0 AndAlso CInt(VersionTable.Rows(0)("blnIsActive")) = 0
        btnDown.Enabled = Not [ReadOnly] AndAlso MatrixGridView.FocusedRowHandle >= 0 AndAlso MatrixGridView.FocusedRowHandle < MatrixGridView.RowCount - 1
        btnUp.Enabled = Not [ReadOnly] AndAlso MatrixGridView.FocusedRowHandle > 0
    End Sub

    Private Sub SetEditMode()
        Dim isVersionActive As Boolean = CType(VersionTable.Rows(0)("blnIsActive"), Boolean)
        m_MatrixDataView.AllowNew = model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(model.Enums.EIDSSPermissionObject.Reference)) AndAlso Not isVersionActive
        If m_MatrixDataView.AllowNew Then
            MatrixGridView.OptionsView.NewItemRowPosition = Views.Grid.NewItemRowPosition.Top
        Else
            MatrixGridView.OptionsView.NewItemRowPosition = Views.Grid.NewItemRowPosition.None
        End If

        m_MatrixDataView.AllowEdit = model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(model.Enums.EIDSSPermissionObject.Reference)) AndAlso Not isVersionActive

        m_MatrixDataView.AllowDelete = model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(model.Enums.EIDSSPermissionObject.Reference)) AndAlso Not isVersionActive
        btnDeleteVersion.Enabled = m_MatrixDataView.AllowDelete
        btnDelete.Enabled = m_MatrixDataView.AllowDelete
    End Sub


    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnUp.Click
        Dim rowHandle As Integer = MatrixGridView.FocusedRowHandle
        If rowHandle <= 0 Then
            Return
        End If
        Dim row As DataRow = MatrixGridView.GetDataRow(rowHandle)
        Dim prevRow As DataRow = MatrixGridView.GetDataRow(rowHandle - 1)
        row("intNumRow") = rowHandle - 1
        prevRow("intNumRow") = rowHandle
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnDown.Click
        Dim rowHandle As Integer = MatrixGridView.FocusedRowHandle
        If rowHandle >= MatrixGridView.RowCount - 1 Then
            Return
        End If
        Dim row As DataRow = MatrixGridView.GetDataRow(rowHandle)
        Dim nextRow As DataRow = MatrixGridView.GetDataRow(rowHandle + 1)
        row("intNumRow") = rowHandle + 1
        nextRow("intNumRow") = rowHandle
    End Sub
    Public Overrides Function ValidateData() As Boolean
        If Not MyBase.ValidateData() Then
            Return False
        End If
        If VersionListTable.Select(String.Format("MatrixName = '{0}' and idfVersion<>{1}", Utils.Str(VersionTable.Rows(0)("MatrixName")).Replace("'", "''"), CurrentVersion)).Length > 0 Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("ErrDuplicateMatrixVersionName", "Matrix version with such name exists already. Please enter unique matrix version name"))
            txtVersionName.Select()
            Return False
        End If
        Return True
    End Function
    Public Overrides Function HasChanges() As Boolean
        'we add this check on the case when error during dataloading occur. Without this
        'the form will give an error during form closing
        If baseDataSet.Tables.Contains(AggregateMatrix_DB.TableVersionsList) Then
            Return Not baseDataSet.Tables(AggregateMatrix_DB.TableVersionsList).GetChanges() Is Nothing _
                    OrElse Not baseDataSet.Tables(AggregateMatrix_DB.TableMatrix).GetChanges() Is Nothing
        End If
    End Function

End Class
