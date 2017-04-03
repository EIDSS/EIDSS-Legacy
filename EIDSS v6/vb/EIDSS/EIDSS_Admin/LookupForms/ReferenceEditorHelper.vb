Imports System.Text
Imports bv.model.Model.Core
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Mask
Imports bv.winclient.Localization
Imports bv.winclient.Core
Imports EIDSS.model.Resources
Imports bv.common.Resources

Public Class ReferenceEditorHelper
    Private Shared m_EnglishValueEditor As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private m_Grid As DevExpress.XtraGrid.GridControl
    Private m_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Private m_MandatoryFields As String() = Nothing
    Private m_UniqueFields As String() = Nothing
    Private m_BaseForm As BaseForm
    Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl, translationCol As GridColumn, ByVal mandatoryFields As String, ByVal uniqueFields As String)
        m_Grid = grid
        m_GridView = CType(m_Grid.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not translationCol Is Nothing AndAlso Not WinUtils.IsComponentInDesignMode(grid) Then
            If ModelUserContext.CurrentLanguage = Localizer.lngEn Then
                translationCol.Visible = False
            End If
        End If
        AddHandler m_GridView.KeyDown, AddressOf GridView_KeyDown
        AddHandler m_GridView.ShownEditor, AddressOf GridView_ShownEditor
        AddHandler m_GridView.ShowingEditor, AddressOf GridView_ShowingEditor
        If Not String.IsNullOrEmpty(mandatoryFields) Then
            m_MandatoryFields = mandatoryFields.Split(","c)
        End If
        If Not String.IsNullOrEmpty(uniqueFields) Then
            m_UniqueFields = uniqueFields.Split(","c)
        End If
        Dim parent As Control = m_Grid.Parent
        While Not parent Is Nothing
            If TypeOf parent Is BaseForm Then
                m_BaseForm = CType(parent, BaseForm)
                Exit While
            End If
            parent = parent.Parent
        End While
        Dim view As DataView = CType(m_Grid.DataSource, DataView)

        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
                                                EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            'view.AllowEdit = False
            m_CanEdit = False
        Else
            'View.AllowEdit = True
            m_CanEdit = True
        End If

    End Sub

    Public Sub DeleteRow()
        Dim r As DataRow = m_BaseForm.GetCurrentRow(ReferenceTable)
        If Not r Is Nothing AndAlso WinUtils.ConfirmDelete AndAlso CanDeleteRow(r) Then
            r.Delete()
        End If

    End Sub
    Public Shared ReadOnly Property EnglishValueEditor() As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Get
            If m_EnglishValueEditor Is Nothing Then
                m_EnglishValueEditor = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
                DxControlsHelper.SetEnglishEditorMask(m_EnglishValueEditor.Mask)
            End If
            Return m_EnglishValueEditor
        End Get
    End Property
    Private Shared m_IDValueEditor As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Public Shared ReadOnly Property IDValueEditor() As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Get
            If m_IDValueEditor Is Nothing Then
                m_IDValueEditor = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
                m_IDValueEditor.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
                m_IDValueEditor.Mask.EditMask = "[a-zA-Z0-9\_]*"
                m_IDValueEditor.Mask.BeepOnError = True
            End If
            Return m_IDValueEditor
        End Get
    End Property
    Public Shared Sub BeforePost(ByVal sender As Object, ByVal e As EventArgs)
        Dim bf As BaseForm = CType(sender, BaseForm)
        For Each table As DataTable In bf.baseDataSet.Tables
            Dim pkFieldName As String = table.PrimaryKey(0).ColumnName
            For Each row As DataRow In table.Rows
                If row.RowState = DataRowState.Added Then
                    If row(pkFieldName) Is DBNull.Value OrElse CLng(row(pkFieldName)) < 0 Then
                        row(pkFieldName) = BaseDbService.NewIntID()
                    End If
                End If
            Next
        Next
    End Sub
    Private Function IsColumnVisible(fieldName As String) As Boolean
        Dim col As GridColumn = m_GridView.Columns.ColumnByFieldName(fieldName)
        Return Not col Is Nothing AndAlso col.Visible
    End Function
    Public Sub ValidateRow(ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs)
        Dim res As Boolean = True
        Dim ErrText As String = ""
        If Not m_MandatoryFields Is Nothing Then
            For Each field As String In m_MandatoryFields
                If IsColumnVisible(field) AndAlso Utils.IsEmpty(m_GridView.GetRowCellValue(e.RowHandle, field)) Then
                    ErrText = String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), m_GridView.Columns(field).Caption)
                    m_GridView.FocusedColumn = m_GridView.Columns(field)
                    m_GridView.ShowEditor()
                    res = False
                End If
            Next
        End If
        If res AndAlso Not m_GridView.Columns.ColumnByFieldName("intOrder") Is Nothing AndAlso _
            Not Utils.IsEmpty(m_GridView.GetRowCellValue(e.RowHandle, "intOrder")) Then
            Dim intOrder As Integer
            If Integer.TryParse(Utils.Str(m_GridView.GetRowCellValue(e.RowHandle, "intOrder")), intOrder) = False Then
                ErrText = EidssMessages.Get("mbWrongOrder", "Order must be numeric. Please correct Order of current Base Reference.")
                m_GridView.FocusedColumn = m_GridView.Columns("intOrder")
                m_GridView.ShowEditor()
                res = False
            End If
        End If
        If res AndAlso Not m_UniqueFields Is Nothing Then
            For Each field As String In m_UniqueFields
                If Not IsColumnVisible(field) Then
                    Continue For
                End If
                Dim duplicate As String
                'If m_GridView.IsNewItemRow(m_GridView.FocusedRowHandle) Then
                duplicate = FindDuplicate(m_GridView.GetDataRow(m_GridView.FocusedRowHandle), CType(m_Grid.DataSource, DataTable), field, Utils.Str(m_GridView.GetRowCellValue(e.RowHandle, field)))
                'Else
                'duplicate = FindDuplicate(CType(m_Grid.DataSource, DataTable), field, Nothing)
                'End If
                If Not duplicate Is Nothing Then
                    ErrText = String.Format(EidssMessages.Get("ErrUniqueness1"), m_GridView.Columns(field), duplicate)
                    m_GridView.FocusedColumn = m_GridView.Columns(field)
                    m_GridView.ShowEditor()
                    res = False
                    Exit For
                End If
            Next
        End If
        e.ErrorText = ErrText
        e.Valid = res
    End Sub
    Public Function BindView(ByVal ds As DataSet, ByVal UseFilter As Boolean) As DataView
        If ds.Tables.Contains(ReferenceTable) Then
            Dim RefView As DataView = ds.Tables(ReferenceTable).DefaultView
            m_Grid.DataSource = ds.Tables(ReferenceTable) 'RefView
            If UseFilter Then
                RefView.RowFilter = String.Format("{0} = {1}", MasterKeyField, -1)
            End If
            Return RefView
        End If
        Return Nothing
    End Function
    Private m_CanEdit As Boolean
    Public Sub RefType_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        Dim view As DataView = CType(sender, DataTable).DataSet.Tables(ReferenceTable).DefaultView
        If Not Utils.IsEmpty(e.Value) Then
            view.RowFilter = String.Format("{0} = {1}", MasterKeyField, e.Value)
        Else
            view.RowFilter = String.Format("{0} = {1}", MasterKeyField, -1)
        End If
        Dim RestrictionFlag As BaseReferenceKind = BaseReferenceKind.None
        If view.Table.DataSet.Tables.Contains("ReferenceType") AndAlso view.Table.DataSet.Tables("ReferenceType").Columns.Contains("intStandard") Then
            Dim refTypeRow As DataRow = view.Table.DataSet.Tables("ReferenceType").Rows.Find(e.Value)
            If Not refTypeRow Is Nothing AndAlso Not refTypeRow("intStandard") Is DBNull.Value Then
                RestrictionFlag = CType(refTypeRow("intStandard"), BaseReferenceKind)
            End If
        End If

        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
                                                EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            view.AllowEdit = False
            m_CanEdit = False
        Else
            view.AllowEdit = True
            m_CanEdit = True
        End If
        If EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
                                                EIDSS.model.Enums.EIDSSPermissionObject.Reference)) _
                                                AndAlso Not Utils.IsEmpty(e.Value) _
                                                AndAlso CLng(e.Value) > 0 _
                                                AndAlso (RestrictionFlag And BaseReferenceKind.DisableCreation) = 0 Then
            m_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            view.AllowNew = True
            view.AllowEdit = True
        Else
            m_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            view.AllowNew = False
        End If
        If EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                                EIDSS.model.Enums.EIDSSPermissionObject.Reference)) _
                                                AndAlso (RestrictionFlag And BaseReferenceKind.DisableDeleting) = 0 Then
            view.AllowDelete = True
        Else
            view.AllowDelete = False
        End If
        If view.Table.Columns.Contains("intOrder") Then
            view.Table.Columns("intOrder").DefaultValue = 0
        End If
        view.Table.Columns(MasterKeyField).DefaultValue = e.Value
    End Sub
    Private Sub GridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            m_GridView.FocusedColumn = m_GridView.Columns(0) 'we aasume that first column is column with english reference value
            m_GridView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
            m_GridView.ShowEditor()
            e.Handled = True
        End If
    End Sub

    Private Sub GridView_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not m_GridView.ActiveEditor Is Nothing Then
            If m_GridView.Columns.Count > 1 AndAlso m_GridView.FocusedColumn Is m_GridView.Columns(1) Then 'we aasume that first column is column with national reference value
                SystemLanguages.SwitchInputLanguage(bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            Else
                SystemLanguages.SwitchInputLanguage(Localizer.lngEn)
            End If
        End If
    End Sub
    Private Sub GridView_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim row As DataRow = m_GridView.GetFocusedDataRow()
        If Not m_CanEdit Then
            If m_GridView.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso Not row Is Nothing AndAlso row.RowState <> DataRowState.Added Then
                e.Cancel = True
            End If
        ElseIf Not row Is Nothing Then
            If row.Table.Columns.Contains("blnSystem") AndAlso row("blnSystem").Equals(True) AndAlso m_GridView.FocusedColumn.FieldName <> "name" Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Function FindDuplicate(ByVal curRow As DataRow, ByVal table As DataTable, ByVal fieldName As String, ByVal value As String) As String
        If Utils.Str(value) <> "" Then
            Dim Filter As String
            If Not curRow Is Nothing AndAlso Not curRow(KeyField) Is DBNull.Value Then
                Filter = String.Format("{0} = '{1}' and {2} <> {3}", fieldName, SqlParser.GetSafeSqlString(value), KeyField, curRow(KeyField))
            Else
                Filter = String.Format("{0} = '{1}'", fieldName, value)
            End If
            If Not curRow Is Nothing AndAlso curRow.Table.Columns.Contains("idfsUsingType") AndAlso Not curRow("idfsUsingType") Is DBNull.Value Then
                Filter += String.Format(" and idfsUsingType = {0} ", curRow("idfsUsingType"))
            End If
            If Not curRow Is Nothing AndAlso curRow.Table.Columns.Contains(MasterKeyField) AndAlso Not curRow(MasterKeyField) Is DBNull.Value Then
                Filter += String.Format("  and {0} = {1} ", MasterKeyField, curRow(MasterKeyField))
            End If
            Dim displayValue As String = m_GridView.GetFocusedRowCellDisplayText(fieldName)
            If table.Select(Filter).Length > 0 Then
                Return Utils.Str(displayValue)
            Else
                Return Nothing
            End If
        End If
        'Dim Rows() As DataRow
        'If table.DataSet.Tables.Contains("MasterReferenceType") Then
        '    Rows = table.Select(String.Format("idfsReferenceType = {0} ", table.DataSet.Tables("MasterReferenceType").Rows(0)("idfsReferenceType")))
        'Else
        '    Rows = table.Select("")
        'End If
        'For Each row As DataRow In Rows
        '    Dim Filter As String = String.Format("{0} = '{1}' and idfsBaseReference <> {2}", fieldName, row(fieldName), row("idfsBaseReference"))
        '    If table.DataSet.Tables.Contains("MasterReferenceType") Then
        '        Filter += String.Format(" and idfsReferenceType = {0} ", table.DataSet.Tables("MasterReferenceType").Rows(0)("idfsReferenceType"))
        '    End If
        '    If Utils.Str(row(fieldName)) <> "" _
        '        AndAlso table.Select(Filter).Length > 0 Then
        '        Return Utils.Str(row(fieldName))
        '    End If
        'Next
        Return Nothing
    End Function

    Public Function FindDuplicate(ByVal fieldName As String) As Integer
        Dim Rows() As DataRow
        Dim table As DataTable = CType(m_GridView.DataSource, DataView).Table
        If table.DataSet.Tables.Contains(MasterTable) Then
            Rows = table.Select(String.Format("{0} = {1} ", MasterKeyField, table.DataSet.Tables(MasterTable).Rows(0)(MasterKeyField)))
        Else
            Rows = table.Select("")
        End If
        For i As Integer = 0 To m_GridView.RowCount - 1
            Dim row As DataRow = m_GridView.GetDataRow(i)
            If Not row Is Nothing Then
                Dim Filter As String = String.Format("{0} = '{1}' and {2} <> {3}", fieldName, SqlParser.GetSafeSqlString(Utils.Str(row(fieldName))), KeyField, row(KeyField))
                If table.DataSet.Tables.Contains(MasterTable) Then
                    Filter += String.Format(" and {0} = {1} ", MasterKeyField, table.DataSet.Tables(MasterTable).Rows(0)(MasterKeyField))
                End If
                If row.Table.Columns.Contains("idfsUsingType") AndAlso Not row("idfsUsingType") Is DBNull.Value Then
                    Filter += String.Format(" and idfsUsingType = {0} ", row("idfsUsingType"))
                End If
                Try
                    If Utils.Str(row(fieldName)) <> "" _
                        AndAlso table.Select(Filter).Length > 0 Then
                        Return i
                    End If
                Catch ex As Exception
                    Dbg.Debug("incorrect filter:<{0}>", Filter)
                End Try
            End If
        Next
        Return -1
    End Function
    Public Function FindDuplicates() As Boolean
        If Not m_UniqueFields Is Nothing Then
            For Each field As String In m_UniqueFields
                Dim duplicateHandle As Integer
                duplicateHandle = FindDuplicate(field)
                If duplicateHandle >= 0 Then
                    ErrorForm.ShowWarningFormat("ErrUniqueness1", m_GridView.Columns(field).Caption, Utils.Str(m_GridView.GetRowCellValue(duplicateHandle, field)))
                    m_GridView.FocusedColumn = m_GridView.Columns(field)
                    m_GridView.FocusedRowHandle = duplicateHandle
                    m_GridView.ShowEditor()
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Dim m_ReferenceTable As String = "BaseReference"
    Public Property ReferenceTable() As String
        Get
            Return m_ReferenceTable
        End Get
        Set(ByVal Value As String)
            m_ReferenceTable = Value
        End Set
    End Property

    Dim m_KeyField As String = "idfsBaseReference"
    Public Property KeyField() As String
        Get
            Return m_KeyField
        End Get
        Set(ByVal Value As String)
            m_KeyField = Value
        End Set
    End Property

    Dim m_MasterTable As String = "MasterReferenceType"
    Public Property MasterTable() As String
        Get
            Return m_MasterTable
        End Get
        Set(ByVal Value As String)
            m_MasterTable = Value
        End Set
    End Property

    Dim m_MasterKeyField As String = "idfsReferenceType"
    Public Property MasterKeyField() As String
        Get
            Return m_MasterKeyField
        End Get
        Set(ByVal Value As String)
            m_MasterKeyField = Value
        End Set
    End Property

    Private m_CanDeleteProc As String

    Public Property CanDeleteProc() As String
        Get
            Return m_CanDeleteProc
        End Get
        Set(ByVal Value As String)
            m_CanDeleteProc = Value
        End Set
    End Property

    Public Function CanDeleteRow(ByVal row As DataRow, Optional ByVal message As String = Nothing) As Boolean
        If (row.Table.Columns.Contains("blnSystem") AndAlso row("blnSystem").Equals(True)) Then
            ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
            Return False
        End If

        If String.IsNullOrEmpty(m_CanDeleteProc) Then
            Return True
        End If
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand(m_CanDeleteProc, ConnectionManager.DefaultInstance.Connection)
        StoredProcParamsCache.CreateParameters(cmd)
        BaseDbService.SetParam(cmd, "@id", row(m_KeyField))
        Dim err As ErrorMessage = BaseDbService.ExecCommand(cmd, cmd.Connection, Nothing)
        If err Is Nothing Then
            If CType(BaseDbService.GetParamValue(cmd, "@Result"), Boolean) = False Then
                If message Is Nothing Then
                    Return WinUtils.ConfirmMessage(BvMessages.Get("msgConfirmReferenceDeleting"))
                Else
                    Return WinUtils.ConfirmMessage(message)
                End If
            End If
        Else
            ErrorForm.ShowErrorDirect(err.Text)
            Return False
        End If
        Return True
    End Function
End Class
