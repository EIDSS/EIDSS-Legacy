Imports System.Text.RegularExpressions
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections.Generic
Imports bv.winclient.Localization

Public Class XtraSearchPanel
    Inherits BaseSearchPanel
    Private m_TableName As String = Nothing
    Private m_IsNumeric As New Hashtable
    Private m_grid As GridControl
    Private m_Type As Type
    Class SearchColumn
        Public Sub New(ByVal aCaption As String, ByVal aFieldName As String, Optional ByVal aLanguage As String = "")
            m_Caption = aCaption
            m_FieldName = aFieldName
            m_Language = aLanguage
        End Sub
        Dim m_Caption As String
        Public Property Caption() As String
            Get
                Return m_Caption
            End Get
            Set(ByVal Value As String)
                m_Caption = Value
            End Set
        End Property
        Dim m_FieldName As String
        Public Property FieldName() As String
            Get
                Return m_FieldName
            End Get
            Set(ByVal Value As String)
                m_FieldName = Value
            End Set
        End Property
        Dim m_Language As String
        Public Property Language() As String
            Get
                Return m_Language
            End Get
            Set(ByVal Value As String)
                m_Language = Value
            End Set
        End Property
    End Class

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'ApplicationLayout.ApplyGroupLayout(Me)
        'cbSearchKind.SelectedIndex = 3
        cbSearchKind.Properties.ValueMember = "Operator"
        cbSearchKind.Properties.DisplayMember = "Name"
        cbSearchKind.Properties.PopupFormMinSize = New System.Drawing.Size(cbSearchKind.Width, 50)
        cbSearchKind.Properties.PopupWidth = cbSearchKind.Width

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tbSearchText As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbSearchKind As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbFields As DevExpress.XtraEditors.LookUpEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraSearchPanel))
        Me.tbSearchText = New DevExpress.XtraEditors.TextEdit
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton
        Me.cbSearchKind = New DevExpress.XtraEditors.LookUpEdit
        Me.cbFields = New DevExpress.XtraEditors.LookUpEdit
        CType(Me.tbSearchText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSearchKind.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbFields.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbSearchText
        '
        resources.ApplyResources(Me.tbSearchText, "tbSearchText")
        Me.tbSearchText.Name = "tbSearchText"
        '
        'btnSearch
        '
        resources.ApplyResources(Me.btnSearch, "btnSearch")
        Me.btnSearch.Image = Global.bv.common.win.My.Resources.Resources.Search
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Tag = "Button"
        '
        'cbSearchKind
        '
        resources.ApplyResources(Me.cbSearchKind, "cbSearchKind")
        Me.cbSearchKind.Name = "cbSearchKind"
        Me.cbSearchKind.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSearchKind.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSearchKind.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSearchKind.Properties.Columns"), CType(resources.GetObject("cbSearchKind.Properties.Columns1"), Integer), resources.GetString("cbSearchKind.Properties.Columns2"))})
        Me.cbSearchKind.Properties.DropDownRows = 5
        Me.cbSearchKind.Properties.NullText = resources.GetString("cbSearchKind.Properties.NullText")
        Me.cbSearchKind.Properties.PopupWidth = 64
        Me.cbSearchKind.Properties.ShowFooter = False
        Me.cbSearchKind.Properties.ShowHeader = False
        Me.cbSearchKind.Properties.ShowLines = False
        '
        'cbFields
        '
        resources.ApplyResources(Me.cbFields, "cbFields")
        Me.cbFields.Name = "cbFields"
        Me.cbFields.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbFields.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbFields.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbFields.Properties.Columns"), resources.GetString("cbFields.Properties.Columns1"))})
        Me.cbFields.Properties.NullText = resources.GetString("cbFields.Properties.NullText")
        Me.cbFields.Properties.ShowFooter = False
        Me.cbFields.Properties.ShowHeader = False
        Me.cbFields.Properties.ShowLines = False
        '
        'XtraSearchPanel
        '
        Me.Controls.Add(Me.cbFields)
        Me.Controls.Add(Me.cbSearchKind)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.tbSearchText)
        Me.Name = "XtraSearchPanel"
        resources.ApplyResources(Me, "$this")
        CType(Me.tbSearchText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSearchKind.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbFields.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overrides Sub Init(ByVal grid As Object)
        m_grid = CType(grid, GridControl)
        Reset()
    End Sub
    Private Shared ControlLanguageRegExp As New System.Text.RegularExpressions.Regex("\[(?<lng>.*)\]", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    Sub Reset()
        If m_grid Is Nothing Then
            Exit Sub
        End If
        If Not m_grid.MainView Is Nothing Then
            Dim columns As ArrayList = New ArrayList
            For i As Integer = CType(m_grid.MainView, ColumnView).Columns.Count - 1 To 0 Step -1
                Dim col As DevExpress.XtraGrid.Columns.GridColumn = CType(m_grid.MainView, ColumnView).Columns(i)
                If col.Visible AndAlso col.VisibleIndex >= 0 Then
                    Dim m_ControlLanguage As String = ""
                    If Not col.Tag Is Nothing Then
                        Dim m As System.Text.RegularExpressions.Match = ControlLanguageRegExp.Match(col.Tag.ToString)
                        If m.Success Then
                            m_ControlLanguage = m.Result("${lng}")
                        End If
                    End If
                    columns.Add(New SearchColumn(col.Caption, col.FieldName, m_ControlLanguage))
                End If
            Next
            cbFields.Properties.DataSource = columns 'CType(m_grid.MainView, ColumnView).Columns
            cbFields.Properties.DisplayMember = "Caption"
            cbFields.Properties.ValueMember = "FieldName"
            If CType(m_grid.MainView, ColumnView).Columns.Count > 0 Then
                cbFields.EditValue = CType(columns(0), SearchColumn).FieldName
            End If
            Dim t As DataTable = GetDataTable()
            If t Is Nothing Then Exit Sub
            m_TableName = t.TableName
            For Each column As SearchColumn In columns
                Dim col As DataColumn = t.Columns(column.FieldName)
                If Not col Is Nothing Then
                    m_IsNumeric(column.FieldName) = Not (col.DataType Is GetType(DateTime) OrElse col.DataType Is GetType(String))
                End If
            Next
            cbFields_EditValueChanged(cbFields, EventArgs.Empty)
        End If

    End Sub

    Private Function GetDataTable() As DataTable
        If m_grid.DataSource Is Nothing Then Return Nothing
        If TypeOf m_grid.DataSource Is DataView Then
            Return CType(m_grid.DataSource, DataView).Table()
        ElseIf TypeOf m_grid.DataSource Is DataTable Then
            Return CType(m_grid.DataSource, DataTable)
        ElseIf TypeOf m_grid.DataSource Is SortProxy Then
            Return CType(CType(m_grid.DataSource, SortProxy).Target, DataView).Table
        Else
            Throw New Exception("Unsupported DataGrid Datasource Type")
        End If
        Return Nothing
    End Function

    Private Function FormatSearchCriteria() As String
        Dim t As DataTable = GetDataTable()
        If t Is Nothing Then Return Nothing
        Dim whereCondition As String = ""
        AddWhereCondition(SearchText, FieldName, t.Columns(FieldName).DataType, FieldCaption, SearchKind.ToString, whereCondition)
        Return whereCondition
    End Function
    Public Overrides ReadOnly Property FilterCondition() As String
        Get
            If Not IsValid OrElse Utils.IsEmpty(FieldName) Then Return Nothing
            Return FormatSearchCriteria()
        End Get
    End Property

    Public ReadOnly Property IsNumeric() As Boolean
        Get
            Return CType(m_IsNumeric(FieldName), Boolean)
        End Get
    End Property

    Public ReadOnly Property FieldName() As String
        Get
            If cbFields.EditValue Is Nothing Then
                Reset()
            End If
            If Not cbFields.EditValue Is Nothing Then
                Return CType(cbFields.EditValue, String)
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property FieldCaption() As String
        Get
            If cbFields.EditValue Is Nothing Then
                Reset()
            End If
            If Not cbFields.EditValue Is Nothing Then
                Return cbFields.Text
            End If
            Return ""
        End Get
    End Property

    Public Property SearchKind() As String
        Get
            Return Utils.Str(cbSearchKind.EditValue)
        End Get
        Set(ByVal Value As String)
            cbSearchKind.EditValue = Value
        End Set
    End Property


    Public Property SearchText() As String
        Get
            Return tbSearchText.Text
        End Get
        Set(ByVal Value As String)
            tbSearchText.Text = Value
        End Set
    End Property

    Public ReadOnly Property IsValid() As Boolean
        Get
            Dim text As String = SearchText.Trim()
            If IsNumeric Then
                Return text = "" OrElse Regex.IsMatch(text, "^((\d+)?(\.\d+)?|(\d+\.))$")
            Else
                Return True
            End If
        End Get
    End Property


    Private Sub NewSearch()
        If Not IsValid Then
            ErrorForm.ShowWarning("errInvalidSearchCriteria", "Invalid search criteria.")
        Else
            DoSearch()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        NewSearch()
    End Sub

    Private Sub tbSearchText_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSearchText.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
            NewSearch()
        End If
    End Sub

    'Private Sub cbSearchKind_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSearchKind.SelectedIndexChanged
    '    If SearchText.Trim() <> "" Then
    '        NewSearch()
    '    End If
    'End Sub

    Private Sub cbFields_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFields.EditValueChanged
        SearchText = ""
        Dim columns As ArrayList = CType(cbFields.Properties.DataSource, ArrayList)
        For Each column As SearchColumn In columns
            If column.FieldName = Utils.Str(cbFields.EditValue) Then
                If column.Language <> "" Then
                    SystemLanguages.SwitchInputLanguage(column.Language)
                Else
                    SystemLanguages.SwitchInputLanguage(bv.model.Model.Core.ModelUserContext.CurrentLanguage)
                End If
                Dim t As DataTable = GetDataTable()
                If Not t Is Nothing Then
                    Dim col As DataColumn = t.Columns(column.FieldName)
                    SetOperationKindList(col.DataType)
                End If
            End If
        Next

    End Sub

    Private Sub SetOperationKindList(ByVal aType As Type)
        Select Case aType.Name
            Case "DateTime"
                cbSearchKind.Properties.DataSource = GetOperatorsList(SearchOpertorKind.Date)
                cbSearchKind.EditValue = ">"
            Case "Boolean"
                cbSearchKind.Properties.DataSource = GetOperatorsList(SearchOpertorKind.Bool)
                cbSearchKind.EditValue = "="
            Case "String"
                cbSearchKind.Properties.DataSource = GetOperatorsList(SearchOpertorKind.String)
                cbSearchKind.EditValue = "Like"
            Case Else
                cbSearchKind.Properties.DataSource = GetOperatorsList(SearchOpertorKind.Numeric)
                cbSearchKind.EditValue = ">"
        End Select
        cbSearchKind.Properties.DropDownRows = CType(cbSearchKind.Properties.DataSource, List(Of SearchOperatorItem)).Count

    End Sub
    Private Sub cbSearchKind_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSearchKind.EditValueChanged
        If SearchText.Trim() <> "" Then
            NewSearch()
        End If
    End Sub
End Class
