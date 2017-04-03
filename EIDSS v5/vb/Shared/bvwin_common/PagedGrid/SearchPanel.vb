Imports System.Text.RegularExpressions

Public Class SearchPanel
    Inherits BaseSearchPanel
    Private m_TableName As String = Nothing
    Private m_IsNumeric As New Hashtable
    Private m_grid As DataGrid

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'ApplicationLayout.ApplyGroupLayout(Me)
        cbSearchKind.SelectedIndex = 3
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
    Friend WithEvents tbSearchText As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cbSearchKind As System.Windows.Forms.ComboBox
    Friend WithEvents cbFields As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SearchPanel))
        Me.tbSearchText = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.cbSearchKind = New System.Windows.Forms.ComboBox
        Me.cbFields = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'tbSearchText
        '
        Me.tbSearchText.AccessibleDescription = resources.GetString("tbSearchText.AccessibleDescription")
        Me.tbSearchText.AccessibleName = resources.GetString("tbSearchText.AccessibleName")
        Me.tbSearchText.Anchor = CType(resources.GetObject("tbSearchText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbSearchText.AutoSize = CType(resources.GetObject("tbSearchText.AutoSize"), Boolean)
        Me.tbSearchText.BackgroundImage = CType(resources.GetObject("tbSearchText.BackgroundImage"), System.Drawing.Image)
        Me.tbSearchText.Dock = CType(resources.GetObject("tbSearchText.Dock"), System.Windows.Forms.DockStyle)
        Me.tbSearchText.Enabled = CType(resources.GetObject("tbSearchText.Enabled"), Boolean)
        Me.tbSearchText.Font = CType(resources.GetObject("tbSearchText.Font"), System.Drawing.Font)
        Me.tbSearchText.ImeMode = CType(resources.GetObject("tbSearchText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbSearchText.Location = CType(resources.GetObject("tbSearchText.Location"), System.Drawing.Point)
        Me.tbSearchText.MaxLength = CType(resources.GetObject("tbSearchText.MaxLength"), Integer)
        Me.tbSearchText.Multiline = CType(resources.GetObject("tbSearchText.Multiline"), Boolean)
        Me.tbSearchText.Name = "tbSearchText"
        Me.tbSearchText.PasswordChar = CType(resources.GetObject("tbSearchText.PasswordChar"), Char)
        Me.tbSearchText.RightToLeft = CType(resources.GetObject("tbSearchText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbSearchText.ScrollBars = CType(resources.GetObject("tbSearchText.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbSearchText.Size = CType(resources.GetObject("tbSearchText.Size"), System.Drawing.Size)
        Me.tbSearchText.TabIndex = CType(resources.GetObject("tbSearchText.TabIndex"), Integer)
        Me.tbSearchText.Text = resources.GetString("tbSearchText.Text")
        Me.tbSearchText.TextAlign = CType(resources.GetObject("tbSearchText.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbSearchText.Visible = CType(resources.GetObject("tbSearchText.Visible"), Boolean)
        Me.tbSearchText.WordWrap = CType(resources.GetObject("tbSearchText.WordWrap"), Boolean)
        '
        'btnSearch
        '
        Me.btnSearch.AccessibleDescription = resources.GetString("btnSearch.AccessibleDescription")
        Me.btnSearch.AccessibleName = resources.GetString("btnSearch.AccessibleName")
        Me.btnSearch.Anchor = CType(resources.GetObject("btnSearch.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.Dock = CType(resources.GetObject("btnSearch.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSearch.Enabled = CType(resources.GetObject("btnSearch.Enabled"), Boolean)
        Me.btnSearch.FlatStyle = CType(resources.GetObject("btnSearch.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSearch.Font = CType(resources.GetObject("btnSearch.Font"), System.Drawing.Font)
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = CType(resources.GetObject("btnSearch.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSearch.ImageIndex = CType(resources.GetObject("btnSearch.ImageIndex"), Integer)
        Me.btnSearch.ImeMode = CType(resources.GetObject("btnSearch.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSearch.Location = CType(resources.GetObject("btnSearch.Location"), System.Drawing.Point)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.RightToLeft = CType(resources.GetObject("btnSearch.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSearch.Size = CType(resources.GetObject("btnSearch.Size"), System.Drawing.Size)
        Me.btnSearch.TabIndex = CType(resources.GetObject("btnSearch.TabIndex"), Integer)
        Me.btnSearch.Tag = "Button"
        Me.btnSearch.Text = resources.GetString("btnSearch.Text")
        Me.btnSearch.TextAlign = CType(resources.GetObject("btnSearch.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSearch.Visible = CType(resources.GetObject("btnSearch.Visible"), Boolean)
        '
        'cbSearchKind
        '
        Me.cbSearchKind.AccessibleDescription = resources.GetString("cbSearchKind.AccessibleDescription")
        Me.cbSearchKind.AccessibleName = resources.GetString("cbSearchKind.AccessibleName")
        Me.cbSearchKind.Anchor = CType(resources.GetObject("cbSearchKind.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cbSearchKind.BackgroundImage = CType(resources.GetObject("cbSearchKind.BackgroundImage"), System.Drawing.Image)
        Me.cbSearchKind.Dock = CType(resources.GetObject("cbSearchKind.Dock"), System.Windows.Forms.DockStyle)
        Me.cbSearchKind.Enabled = CType(resources.GetObject("cbSearchKind.Enabled"), Boolean)
        Me.cbSearchKind.Font = CType(resources.GetObject("cbSearchKind.Font"), System.Drawing.Font)
        Me.cbSearchKind.ImeMode = CType(resources.GetObject("cbSearchKind.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cbSearchKind.IntegralHeight = CType(resources.GetObject("cbSearchKind.IntegralHeight"), Boolean)
        Me.cbSearchKind.ItemHeight = CType(resources.GetObject("cbSearchKind.ItemHeight"), Integer)
        Me.cbSearchKind.Items.AddRange(New Object() {resources.GetString("cbSearchKind.Items"), resources.GetString("cbSearchKind.Items1"), resources.GetString("cbSearchKind.Items2"), resources.GetString("cbSearchKind.Items3")})
        Me.cbSearchKind.Location = CType(resources.GetObject("cbSearchKind.Location"), System.Drawing.Point)
        Me.cbSearchKind.MaxDropDownItems = CType(resources.GetObject("cbSearchKind.MaxDropDownItems"), Integer)
        Me.cbSearchKind.MaxLength = CType(resources.GetObject("cbSearchKind.MaxLength"), Integer)
        Me.cbSearchKind.Name = "cbSearchKind"
        Me.cbSearchKind.RightToLeft = CType(resources.GetObject("cbSearchKind.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cbSearchKind.Size = CType(resources.GetObject("cbSearchKind.Size"), System.Drawing.Size)
        Me.cbSearchKind.TabIndex = CType(resources.GetObject("cbSearchKind.TabIndex"), Integer)
        Me.cbSearchKind.Text = resources.GetString("cbSearchKind.Text")
        Me.cbSearchKind.Visible = CType(resources.GetObject("cbSearchKind.Visible"), Boolean)
        '
        'cbFields
        '
        Me.cbFields.AccessibleDescription = resources.GetString("cbFields.AccessibleDescription")
        Me.cbFields.AccessibleName = resources.GetString("cbFields.AccessibleName")
        Me.cbFields.Anchor = CType(resources.GetObject("cbFields.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cbFields.BackgroundImage = CType(resources.GetObject("cbFields.BackgroundImage"), System.Drawing.Image)
        Me.cbFields.Dock = CType(resources.GetObject("cbFields.Dock"), System.Windows.Forms.DockStyle)
        Me.cbFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFields.Enabled = CType(resources.GetObject("cbFields.Enabled"), Boolean)
        Me.cbFields.Font = CType(resources.GetObject("cbFields.Font"), System.Drawing.Font)
        Me.cbFields.ImeMode = CType(resources.GetObject("cbFields.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cbFields.IntegralHeight = CType(resources.GetObject("cbFields.IntegralHeight"), Boolean)
        Me.cbFields.ItemHeight = CType(resources.GetObject("cbFields.ItemHeight"), Integer)
        Me.cbFields.Location = CType(resources.GetObject("cbFields.Location"), System.Drawing.Point)
        Me.cbFields.MaxDropDownItems = CType(resources.GetObject("cbFields.MaxDropDownItems"), Integer)
        Me.cbFields.MaxLength = CType(resources.GetObject("cbFields.MaxLength"), Integer)
        Me.cbFields.Name = "cbFields"
        Me.cbFields.RightToLeft = CType(resources.GetObject("cbFields.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cbFields.Size = CType(resources.GetObject("cbFields.Size"), System.Drawing.Size)
        Me.cbFields.TabIndex = CType(resources.GetObject("cbFields.TabIndex"), Integer)
        Me.cbFields.Text = resources.GetString("cbFields.Text")
        Me.cbFields.Visible = CType(resources.GetObject("cbFields.Visible"), Boolean)
        '
        'SearchPanel
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.Controls.Add(Me.cbFields)
        Me.Controls.Add(Me.cbSearchKind)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.tbSearchText)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.Name = "SearchPanel"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overrides Sub Init(ByVal grid As Object)
        m_grid = CType(grid, DataGrid)
        Reset()
    End Sub
    Sub Reset()
        Dim style As DataGridTableStyle = Nothing
        If Not m_grid Is Nothing AndAlso m_grid.TableStyles.Count > 0 Then
            style = m_grid.TableStyles(0)
        End If
        If Not style Is Nothing Then
            cbFields.DataSource = style.GridColumnStyles
            cbFields.DisplayMember = "HeaderText"
            cbFields.ValueMember = "MappingName"
            If cbFields.Items.Count > 0 Then
                cbFields.SelectedIndex = 0
            End If
            m_TableName = style.MappingName
            Dim t As DataTable
            If TypeOf style.DataGrid.DataSource Is DataView Then
                t = CType(style.DataGrid.DataSource, DataView).Table()
            ElseIf TypeOf style.DataGrid.DataSource Is DataTable Then
                t = CType(style.DataGrid.DataSource, DataTable)
            ElseIf TypeOf style.DataGrid.DataSource Is SortProxy Then
                t = CType(CType(style.DataGrid.DataSource, SortProxy).Target, DataView).Table
            Else
                Throw New Exception("Unsupported DataGrid Datasource Type")
            End If
            For Each colStyle As DataGridColumnStyle In style.GridColumnStyles
                Dim col As DataColumn = t.Columns(colStyle.MappingName)
                m_IsNumeric(colStyle.MappingName) = Not (col.DataType Is GetType(DateTime) OrElse col.DataType Is GetType(String))
            Next
        End If

    End Sub
    Public Overrides ReadOnly Property FilterCondition() As String
        Get
            If Not IsValid Or FieldName Is Nothing Then Return Nothing
            Dim text As String = SearchText.Trim()
            If text = "" Then Return Nothing
            Dim kind As String = SearchKind.ToUpper(Globalization.CultureInfo.InvariantCulture)
            Dim format As String = "{0} {1} '{2}'"

            If IsNumeric And kind <> "LIKE" Then
                format = "{0} {1} {2}"
            Else
                If kind = "LIKE" Then
                    format = "CAST({0} AS NVARCHAR(256)) {1} '%{2}%'"
                End If
                text = text.Replace("'", "''").Replace("%", "[%]")
            End If
            Return String.Format(format, FieldName, kind, text)
        End Get
    End Property

    Public ReadOnly Property IsNumeric() As Boolean
        Get
            Return CType(m_IsNumeric(FieldName), Boolean)
        End Get
    End Property

    Public ReadOnly Property FieldName() As String
        Get
            If cbFields.Items.Count = 0 Then
                Reset()
            End If
            If Not cbFields.SelectedValue Is Nothing Then
                Return CType(cbFields.SelectedValue, String)
            End If
            Return ""
        End Get
    End Property

    Public Property SearchKind() As String
        Get
            Return CType(cbSearchKind.SelectedItem, String)
        End Get
        Set(ByVal Value As String)
            cbSearchKind.SelectedItem = Value
        End Set
    End Property

    'Public Property SearchTitle() As String
    '    Get
    '        Return lbTitle.Text
    '    End Get
    '    Set(ByVal Value As String)
    '        lbTitle.Text = Value
    '    End Set
    'End Property

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

    Private Sub cbSearchKind_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSearchKind.SelectedIndexChanged
        If SearchText.Trim() <> "" Then
            NewSearch()
        End If
    End Sub

End Class
