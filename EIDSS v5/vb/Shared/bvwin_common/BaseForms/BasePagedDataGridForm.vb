Imports System.ComponentModel
Public Class BasePagedDataGridForm
    Inherits BasePagedListForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub
    'Form overrides dispose to clean up the component list.
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

    'NOTE The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PagedDataGrid1 As bv.common.win.PagedDataGrid
    Friend WithEvents cmdSearch1 As System.Windows.Forms.Button
    Friend WithEvents cmdDelete1 As System.Windows.Forms.Button
    Friend WithEvents cmdEdit1 As System.Windows.Forms.Button
    Friend WithEvents cmdNew1 As System.Windows.Forms.Button
    '<System.Diagnostics.DebuggerStepThrough()> 
    Friend WithEvents cmdRefresh1 As System.Windows.Forms.Button
    Friend WithEvents cmdClose1 As System.Windows.Forms.Button
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BasePagedDataGridForm))
        Me.cmdDelete1 = New System.Windows.Forms.Button
        Me.cmdEdit1 = New System.Windows.Forms.Button
        Me.cmdNew1 = New System.Windows.Forms.Button
        Me.PagedDataGrid1 = New bv.common.win.PagedDataGrid
        Me.cmdSearch1 = New System.Windows.Forms.Button
        Me.cmdRefresh1 = New System.Windows.Forms.Button
        Me.cmdClose1 = New System.Windows.Forms.Button
        CType(Me.PagedDataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PagedDataGrid1.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdDelete1
        '
        Me.cmdDelete1.AccessibleDescription = resources.GetString("cmdDelete1.AccessibleDescription")
        Me.cmdDelete1.AccessibleName = resources.GetString("cmdDelete1.AccessibleName")
        Me.cmdDelete1.Anchor = CType(resources.GetObject("cmdDelete1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete1.BackgroundImage = CType(resources.GetObject("cmdDelete1.BackgroundImage"), System.Drawing.Image)
        Me.cmdDelete1.Dock = CType(resources.GetObject("cmdDelete1.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdDelete1.Enabled = CType(resources.GetObject("cmdDelete1.Enabled"), Boolean)
        Me.cmdDelete1.FlatStyle = CType(resources.GetObject("cmdDelete1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdDelete1.Font = CType(resources.GetObject("cmdDelete1.Font"), System.Drawing.Font)
        Me.cmdDelete1.Image = CType(resources.GetObject("cmdDelete1.Image"), System.Drawing.Image)
        Me.cmdDelete1.ImageAlign = CType(resources.GetObject("cmdDelete1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdDelete1.ImageIndex = CType(resources.GetObject("cmdDelete1.ImageIndex"), Integer)
        Me.cmdDelete1.ImeMode = CType(resources.GetObject("cmdDelete1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdDelete1.Location = CType(resources.GetObject("cmdDelete1.Location"), System.Drawing.Point)
        Me.cmdDelete1.Name = "cmdDelete1"
        Me.cmdDelete1.RightToLeft = CType(resources.GetObject("cmdDelete1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdDelete1.Size = CType(resources.GetObject("cmdDelete1.Size"), System.Drawing.Size)
        Me.cmdDelete1.TabIndex = CType(resources.GetObject("cmdDelete1.TabIndex"), Integer)
        Me.cmdDelete1.Text = resources.GetString("cmdDelete1.Text")
        Me.cmdDelete1.TextAlign = CType(resources.GetObject("cmdDelete1.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdDelete1.Visible = CType(resources.GetObject("cmdDelete1.Visible"), Boolean)
        '
        'cmdEdit1
        '
        Me.cmdEdit1.AccessibleDescription = resources.GetString("cmdEdit1.AccessibleDescription")
        Me.cmdEdit1.AccessibleName = resources.GetString("cmdEdit1.AccessibleName")
        Me.cmdEdit1.Anchor = CType(resources.GetObject("cmdEdit1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit1.BackgroundImage = CType(resources.GetObject("cmdEdit1.BackgroundImage"), System.Drawing.Image)
        Me.cmdEdit1.Dock = CType(resources.GetObject("cmdEdit1.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdEdit1.Enabled = CType(resources.GetObject("cmdEdit1.Enabled"), Boolean)
        Me.cmdEdit1.FlatStyle = CType(resources.GetObject("cmdEdit1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdEdit1.Font = CType(resources.GetObject("cmdEdit1.Font"), System.Drawing.Font)
        Me.cmdEdit1.Image = CType(resources.GetObject("cmdEdit1.Image"), System.Drawing.Image)
        Me.cmdEdit1.ImageAlign = CType(resources.GetObject("cmdEdit1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdEdit1.ImageIndex = CType(resources.GetObject("cmdEdit1.ImageIndex"), Integer)
        Me.cmdEdit1.ImeMode = CType(resources.GetObject("cmdEdit1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdEdit1.Location = CType(resources.GetObject("cmdEdit1.Location"), System.Drawing.Point)
        Me.cmdEdit1.Name = "cmdEdit1"
        Me.cmdEdit1.RightToLeft = CType(resources.GetObject("cmdEdit1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdEdit1.Size = CType(resources.GetObject("cmdEdit1.Size"), System.Drawing.Size)
        Me.cmdEdit1.TabIndex = CType(resources.GetObject("cmdEdit1.TabIndex"), Integer)
        Me.cmdEdit1.Text = resources.GetString("cmdEdit1.Text")
        Me.cmdEdit1.TextAlign = CType(resources.GetObject("cmdEdit1.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdEdit1.Visible = CType(resources.GetObject("cmdEdit1.Visible"), Boolean)
        '
        'cmdNew1
        '
        Me.cmdNew1.AccessibleDescription = resources.GetString("cmdNew1.AccessibleDescription")
        Me.cmdNew1.AccessibleName = resources.GetString("cmdNew1.AccessibleName")
        Me.cmdNew1.Anchor = CType(resources.GetObject("cmdNew1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdNew1.BackgroundImage = CType(resources.GetObject("cmdNew1.BackgroundImage"), System.Drawing.Image)
        Me.cmdNew1.Dock = CType(resources.GetObject("cmdNew1.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdNew1.Enabled = CType(resources.GetObject("cmdNew1.Enabled"), Boolean)
        Me.cmdNew1.FlatStyle = CType(resources.GetObject("cmdNew1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdNew1.Font = CType(resources.GetObject("cmdNew1.Font"), System.Drawing.Font)
        Me.cmdNew1.Image = CType(resources.GetObject("cmdNew1.Image"), System.Drawing.Image)
        Me.cmdNew1.ImageAlign = CType(resources.GetObject("cmdNew1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdNew1.ImageIndex = CType(resources.GetObject("cmdNew1.ImageIndex"), Integer)
        Me.cmdNew1.ImeMode = CType(resources.GetObject("cmdNew1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdNew1.Location = CType(resources.GetObject("cmdNew1.Location"), System.Drawing.Point)
        Me.cmdNew1.Name = "cmdNew1"
        Me.cmdNew1.RightToLeft = CType(resources.GetObject("cmdNew1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdNew1.Size = CType(resources.GetObject("cmdNew1.Size"), System.Drawing.Size)
        Me.cmdNew1.TabIndex = CType(resources.GetObject("cmdNew1.TabIndex"), Integer)
        Me.cmdNew1.Text = resources.GetString("cmdNew1.Text")
        Me.cmdNew1.TextAlign = CType(resources.GetObject("cmdNew1.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdNew1.Visible = CType(resources.GetObject("cmdNew1.Visible"), Boolean)
        '
        'PagedDataGrid1
        '
        Me.PagedDataGrid1.AccessibleDescription = resources.GetString("PagedDataGrid1.AccessibleDescription")
        Me.PagedDataGrid1.AccessibleName = resources.GetString("PagedDataGrid1.AccessibleName")
        Me.PagedDataGrid1.Anchor = CType(resources.GetObject("PagedDataGrid1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PagedDataGrid1.AutoScroll = CType(resources.GetObject("PagedDataGrid1.AutoScroll"), Boolean)
        Me.PagedDataGrid1.AutoScrollMargin = CType(resources.GetObject("PagedDataGrid1.AutoScrollMargin"), System.Drawing.Size)
        Me.PagedDataGrid1.AutoScrollMinSize = CType(resources.GetObject("PagedDataGrid1.AutoScrollMinSize"), System.Drawing.Size)
        Me.PagedDataGrid1.BackgroundImage = CType(resources.GetObject("PagedDataGrid1.BackgroundImage"), System.Drawing.Image)
        Me.PagedDataGrid1.Controls.Add(Me.PagedDataGrid1.Grid)
        Me.PagedDataGrid1.CurrentPage = 1
        Me.PagedDataGrid1.Dock = CType(resources.GetObject("PagedDataGrid1.Dock"), System.Windows.Forms.DockStyle)
        Me.PagedDataGrid1.Enabled = CType(resources.GetObject("PagedDataGrid1.Enabled"), Boolean)
        Me.PagedDataGrid1.Font = CType(resources.GetObject("PagedDataGrid1.Font"), System.Drawing.Font)
        '
        'PagedDataGrid1.Grid
        '
        Me.PagedDataGrid1.Grid.AccessibleDescription = resources.GetString("PagedDataGrid1.Grid.AccessibleDescription")
        Me.PagedDataGrid1.Grid.AccessibleName = resources.GetString("PagedDataGrid1.Grid.AccessibleName")
        Me.PagedDataGrid1.Grid.Anchor = CType(resources.GetObject("PagedDataGrid1.Grid.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PagedDataGrid1.Grid.BackgroundImage = CType(resources.GetObject("PagedDataGrid1.Grid.BackgroundImage"), System.Drawing.Image)
        Me.PagedDataGrid1.Grid.CaptionBackColor = System.Drawing.Color.Gainsboro
        Me.PagedDataGrid1.Grid.CaptionFont = CType(resources.GetObject("PagedDataGrid1.Grid.CaptionFont"), System.Drawing.Font)
        Me.PagedDataGrid1.Grid.CaptionText = resources.GetString("PagedDataGrid1.Grid.CaptionText")
        Me.PagedDataGrid1.Grid.CaptionVisible = False
        Me.PagedDataGrid1.Grid.DataMember = ""
        Me.PagedDataGrid1.Grid.Dock = CType(resources.GetObject("PagedDataGrid1.Grid.Dock"), System.Windows.Forms.DockStyle)
        Me.PagedDataGrid1.Grid.Enabled = CType(resources.GetObject("PagedDataGrid1.Grid.Enabled"), Boolean)
        Me.PagedDataGrid1.Grid.Font = CType(resources.GetObject("PagedDataGrid1.Grid.Font"), System.Drawing.Font)
        Me.PagedDataGrid1.Grid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.PagedDataGrid1.Grid.ImeMode = CType(resources.GetObject("PagedDataGrid1.Grid.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PagedDataGrid1.Grid.Location = CType(resources.GetObject("PagedDataGrid1.Grid.Location"), System.Drawing.Point)
        Me.PagedDataGrid1.Grid.Name = "m_grid"
        Me.PagedDataGrid1.Grid.ReadOnly = True
        Me.PagedDataGrid1.Grid.RightToLeft = CType(resources.GetObject("PagedDataGrid1.Grid.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PagedDataGrid1.Grid.Size = CType(resources.GetObject("PagedDataGrid1.Grid.Size"), System.Drawing.Size)
        Me.PagedDataGrid1.Grid.TabIndex = CType(resources.GetObject("PagedDataGrid1.Grid.TabIndex"), Integer)
        Me.PagedDataGrid1.Grid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {CType(resources.GetObject("PagedDataGrid1.Grid.TableStyles"), System.Windows.Forms.DataGridTableStyle)})
        Me.PagedDataGrid1.Grid.Visible = CType(resources.GetObject("PagedDataGrid1.Grid.Visible"), Boolean)
        Me.PagedDataGrid1.ImeMode = CType(resources.GetObject("PagedDataGrid1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PagedDataGrid1.Location = CType(resources.GetObject("PagedDataGrid1.Location"), System.Drawing.Point)
        Me.PagedDataGrid1.Name = "PagedDataGrid1"
        Me.PagedDataGrid1.PageCount = 0
        Me.PagedDataGrid1.PageSize = 3
        Me.PagedDataGrid1.ReadOnly = True
        Me.PagedDataGrid1.RightToLeft = CType(resources.GetObject("PagedDataGrid1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PagedDataGrid1.SearchControl = "bv.common.win.SearchPanel"
        Me.PagedDataGrid1.SearchPanelDocStyle = System.Windows.Forms.DockStyle.Top
        Me.PagedDataGrid1.Size = CType(resources.GetObject("PagedDataGrid1.Size"), System.Drawing.Size)
        Me.PagedDataGrid1.SortCondition = Nothing
        Me.PagedDataGrid1.StaticFilterCondition = Nothing
        Me.PagedDataGrid1.TabIndex = CType(resources.GetObject("PagedDataGrid1.TabIndex"), Integer)
        Me.PagedDataGrid1.Visible = CType(resources.GetObject("PagedDataGrid1.Visible"), Boolean)
        '
        'cmdSearch1
        '
        Me.cmdSearch1.AccessibleDescription = resources.GetString("cmdSearch1.AccessibleDescription")
        Me.cmdSearch1.AccessibleName = resources.GetString("cmdSearch1.AccessibleName")
        Me.cmdSearch1.Anchor = CType(resources.GetObject("cmdSearch1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch1.BackgroundImage = CType(resources.GetObject("cmdSearch1.BackgroundImage"), System.Drawing.Image)
        Me.cmdSearch1.Dock = CType(resources.GetObject("cmdSearch1.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdSearch1.Enabled = CType(resources.GetObject("cmdSearch1.Enabled"), Boolean)
        Me.cmdSearch1.FlatStyle = CType(resources.GetObject("cmdSearch1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdSearch1.Font = CType(resources.GetObject("cmdSearch1.Font"), System.Drawing.Font)
        Me.cmdSearch1.Image = CType(resources.GetObject("cmdSearch1.Image"), System.Drawing.Image)
        Me.cmdSearch1.ImageAlign = CType(resources.GetObject("cmdSearch1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdSearch1.ImageIndex = CType(resources.GetObject("cmdSearch1.ImageIndex"), Integer)
        Me.cmdSearch1.ImeMode = CType(resources.GetObject("cmdSearch1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdSearch1.Location = CType(resources.GetObject("cmdSearch1.Location"), System.Drawing.Point)
        Me.cmdSearch1.Name = "cmdSearch1"
        Me.cmdSearch1.RightToLeft = CType(resources.GetObject("cmdSearch1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdSearch1.Size = CType(resources.GetObject("cmdSearch1.Size"), System.Drawing.Size)
        Me.cmdSearch1.TabIndex = CType(resources.GetObject("cmdSearch1.TabIndex"), Integer)
        Me.cmdSearch1.Text = resources.GetString("cmdSearch1.Text")
        Me.cmdSearch1.TextAlign = CType(resources.GetObject("cmdSearch1.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdSearch1.Visible = CType(resources.GetObject("cmdSearch1.Visible"), Boolean)
        '
        'cmdRefresh1
        '
        Me.cmdRefresh1.AccessibleDescription = resources.GetString("cmdRefresh1.AccessibleDescription")
        Me.cmdRefresh1.AccessibleName = resources.GetString("cmdRefresh1.AccessibleName")
        Me.cmdRefresh1.Anchor = CType(resources.GetObject("cmdRefresh1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh1.BackgroundImage = CType(resources.GetObject("cmdRefresh1.BackgroundImage"), System.Drawing.Image)
        Me.cmdRefresh1.Dock = CType(resources.GetObject("cmdRefresh1.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdRefresh1.Enabled = CType(resources.GetObject("cmdRefresh1.Enabled"), Boolean)
        Me.cmdRefresh1.FlatStyle = CType(resources.GetObject("cmdRefresh1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdRefresh1.Font = CType(resources.GetObject("cmdRefresh1.Font"), System.Drawing.Font)
        Me.cmdRefresh1.Image = CType(resources.GetObject("cmdRefresh1.Image"), System.Drawing.Image)
        Me.cmdRefresh1.ImageAlign = CType(resources.GetObject("cmdRefresh1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdRefresh1.ImageIndex = CType(resources.GetObject("cmdRefresh1.ImageIndex"), Integer)
        Me.cmdRefresh1.ImeMode = CType(resources.GetObject("cmdRefresh1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdRefresh1.Location = CType(resources.GetObject("cmdRefresh1.Location"), System.Drawing.Point)
        Me.cmdRefresh1.Name = "cmdRefresh1"
        Me.cmdRefresh1.RightToLeft = CType(resources.GetObject("cmdRefresh1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdRefresh1.Size = CType(resources.GetObject("cmdRefresh1.Size"), System.Drawing.Size)
        Me.cmdRefresh1.TabIndex = CType(resources.GetObject("cmdRefresh1.TabIndex"), Integer)
        Me.cmdRefresh1.Text = resources.GetString("cmdRefresh1.Text")
        Me.cmdRefresh1.TextAlign = CType(resources.GetObject("cmdRefresh1.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdRefresh1.Visible = CType(resources.GetObject("cmdRefresh1.Visible"), Boolean)
        '
        'cmdClose1
        '
        Me.cmdClose1.AccessibleDescription = resources.GetString("cmdClose1.AccessibleDescription")
        Me.cmdClose1.AccessibleName = resources.GetString("cmdClose1.AccessibleName")
        Me.cmdClose1.Anchor = CType(resources.GetObject("cmdClose1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdClose1.BackgroundImage = CType(resources.GetObject("cmdClose1.BackgroundImage"), System.Drawing.Image)
        Me.cmdClose1.Dock = CType(resources.GetObject("cmdClose1.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdClose1.Enabled = CType(resources.GetObject("cmdClose1.Enabled"), Boolean)
        Me.cmdClose1.FlatStyle = CType(resources.GetObject("cmdClose1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdClose1.Font = CType(resources.GetObject("cmdClose1.Font"), System.Drawing.Font)
        Me.cmdClose1.Image = CType(resources.GetObject("cmdClose1.Image"), System.Drawing.Image)
        Me.cmdClose1.ImageAlign = CType(resources.GetObject("cmdClose1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdClose1.ImageIndex = CType(resources.GetObject("cmdClose1.ImageIndex"), Integer)
        Me.cmdClose1.ImeMode = CType(resources.GetObject("cmdClose1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdClose1.Location = CType(resources.GetObject("cmdClose1.Location"), System.Drawing.Point)
        Me.cmdClose1.Name = "cmdClose1"
        Me.cmdClose1.RightToLeft = CType(resources.GetObject("cmdClose1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdClose1.Size = CType(resources.GetObject("cmdClose1.Size"), System.Drawing.Size)
        Me.cmdClose1.TabIndex = CType(resources.GetObject("cmdClose1.TabIndex"), Integer)
        Me.cmdClose1.Text = resources.GetString("cmdClose1.Text")
        Me.cmdClose1.TextAlign = CType(resources.GetObject("cmdClose1.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdClose1.Visible = CType(resources.GetObject("cmdClose1.Visible"), Boolean)
        '
        'BasePagedDataGridForm
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.Caption = resources.GetString("$this.Caption")
        Me.Controls.Add(Me.cmdRefresh1)
        Me.Controls.Add(Me.cmdClose1)
        Me.Controls.Add(Me.cmdSearch1)
        Me.Controls.Add(Me.PagedDataGrid1)
        Me.Controls.Add(Me.cmdNew1)
        Me.Controls.Add(Me.cmdEdit1)
        Me.Controls.Add(Me.cmdDelete1)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.Name = "BasePagedDataGridForm"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
        Me.Controls.SetChildIndex(Me.cmdDelete1, 0)
        Me.Controls.SetChildIndex(Me.cmdEdit1, 0)
        Me.Controls.SetChildIndex(Me.cmdNew1, 0)
        Me.Controls.SetChildIndex(Me.PagedDataGrid1, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch1, 0)
        Me.Controls.SetChildIndex(Me.cmdClose1, 0)
        Me.Controls.SetChildIndex(Me.cmdRefresh1, 0)
        CType(Me.PagedDataGrid1.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PagedDataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "BaseFormList overrides methods"
    Protected Overrides Sub InitButtons()
        cmdSearch = cmdSearch1
        If ShowSearch = False Then
            cmdSearch.Text = "Show Search"
        Else
            cmdSearch.Text = "Hide Search"
        End If

        cmdEdit = cmdEdit1
        cmdNew = cmdNew1
        cmdDelete = cmdDelete1
        cmdSearch = cmdSearch1
        cmdClose = cmdClose1
        cmdRefresh = cmdRefresh1
    End Sub

    'Protected Overrides Sub TableAdded(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
    '    If e.Action = CollectionChangeAction.Add Then
    '        PagedGrid.UpdateBinding()
    '    End If
    'End Sub

    'Public Overrides Function GetDataset() As DataSet
    '    Dim RecordCount As Integer
    '    Dim ds As DataSet
    '    Dim params() As Object
    '    params = New Object() { _
    '                            PagedGrid.PageSize, PagedGrid.CurrentPage - 1, PagedGrid.FilterCondition, Nothing, PagedGrid.SortCondition, RecordCount}
    '    Dim o As Object = ClassLoader.LoadClass(TableName + "_DB")
    '    Dim typeArray(5) As Type

    '    Dim m_listMethod As Reflection.MethodInfo = o.GetType().GetMethod("GetPagedList")
    '    o = m_listMethod.Invoke(o, params)
    '    If Not o Is Nothing Then
    '        ds = CType(o, DataSet)
    '        RecordCount = CInt(params(5))
    '        If RecordCount < PagedGrid.PageSize Then
    '            PagedGrid.PageCount = 0
    '        Else
    '            PagedGrid.PageCount = (RecordCount + PagedGrid.PageSize - 1) \ PagedGrid.PageSize
    '        End If
    '        Return ds
    '    End If
    '    Return Nothing
    'End Function

    'Public Overrides Function GetBindingManager() As BindingManagerBase
    '    If PagedGrid Is Nothing Then Return Nothing
    '    If PagedGrid.Grid.DataSource Is Nothing Then Return Nothing
    '    Return PagedGrid.BindingContext(PagedGrid.Grid.DataSource)
    'End Function

    'Public Overrides Function LocateRow(ByVal ID As Object) As Boolean
    '    If PagedGrid Is Nothing Then Return False
    '    Return PagedGrid.LocateRow(ID)
    'End Function


#End Region

#Region "Public properies"

    Public Overrides ReadOnly Property Grid() As Object
        Get
            If PagedDataGrid1 Is Nothing Then Return Nothing
            Return PagedDataGrid1.DataGrid
        End Get
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Localizable(True)> _
    Public ReadOnly Property GridColumnStyles() As GridColumnStylesCollection
        Get
            If PagedDataGrid1 Is Nothing Then Return Nothing
            Return PagedDataGrid1.GridColumnStyles
        End Get
    End Property


#End Region

#Region "Public methods"


#End Region

#Region "Protected methods"
    Public Overrides ReadOnly Property PagedGrid() As BasePagedDataGrid
        Get
            Return Me.PagedDataGrid1
        End Get
    End Property

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        ArrangeTopButtons()
    End Sub

#End Region

#Region "Private methods"


#End Region



End Class
