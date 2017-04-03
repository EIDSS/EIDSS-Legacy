Imports System.ComponentModel
Imports System.Collections.Specialized
Imports System.Runtime.Remoting


Public Class PagedDataGrid
    Inherits BasePagedDataGrid

#Region " Private data members "
    Private m_gridTableStyle As New DataGridTableStyle
    Private m_ColumnResizer As GridColumnResizer
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not m_sortProxy Is Nothing Then
                m_sortProxy.Target = Nothing
                m_sortProxy = Nothing
            End If
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
    Friend WithEvents m_grid As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PagedDataGrid))
        Me.m_grid = New System.Windows.Forms.DataGrid
        CType(Me.m_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_grid
        '
        Me.m_grid.AccessibleDescription = resources.GetString("m_grid.AccessibleDescription")
        Me.m_grid.AccessibleName = resources.GetString("m_grid.AccessibleName")
        Me.m_grid.Anchor = CType(resources.GetObject("m_grid.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.m_grid.BackgroundImage = CType(resources.GetObject("m_grid.BackgroundImage"), System.Drawing.Image)
        Me.m_grid.CaptionFont = CType(resources.GetObject("m_grid.CaptionFont"), System.Drawing.Font)
        Me.m_grid.CaptionText = resources.GetString("m_grid.CaptionText")
        Me.m_grid.DataMember = ""
        Me.m_grid.Dock = CType(resources.GetObject("m_grid.Dock"), System.Windows.Forms.DockStyle)
        Me.m_grid.Enabled = CType(resources.GetObject("m_grid.Enabled"), Boolean)
        Me.m_grid.Font = CType(resources.GetObject("m_grid.Font"), System.Drawing.Font)
        Me.m_grid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.m_grid.ImeMode = CType(resources.GetObject("m_grid.ImeMode"), System.Windows.Forms.ImeMode)
        Me.m_grid.Location = CType(resources.GetObject("m_grid.Location"), System.Drawing.Point)
        Me.m_grid.Name = "m_grid"
        Me.m_grid.RightToLeft = CType(resources.GetObject("m_grid.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.m_grid.Size = CType(resources.GetObject("m_grid.Size"), System.Drawing.Size)
        Me.m_grid.TabIndex = CType(resources.GetObject("m_grid.TabIndex"), Integer)
        Me.m_grid.Visible = CType(resources.GetObject("m_grid.Visible"), Boolean)
        '
        'PagedDataGrid
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.Controls.Add(Me.m_grid)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.Name = "PagedDataGrid"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
        Me.Controls.SetChildIndex(Me.m_grid, 0)
        CType(Me.m_grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Public methods "
    Public Overloads Overrides Function LocateRow(ByVal field As String, ByVal value As Object) As Boolean
        If Not IsReady() Then Return False
        Dim valueNull As Boolean = IsDBNull(value)
        Dim I As Integer
        For I = 0 To MainTable.Rows.Count - 1
            Dim rowView As DataRowView = CType(m_sortProxy(I), DataRowView)
            Dim curValue As Object = rowView(field)
            If (valueNull AndAlso IsDBNull(curValue)) OrElse _
                (Not valueNull AndAlso Not IsDBNull(curValue) _
                 AndAlso curValue.ToString() = value.ToString) Then
                m_grid.CurrentRowIndex = I
                Return True
            End If
        Next
        Return False
    End Function
    Public Overloads Overrides Function LocateRow(ByVal key As Object) As Boolean
        If key Is Nothing Then Return Nothing
        If IsReady() Then
            Dim bm As BindingManagerBase = BindingContext(m_sortProxy)
            Dim dv As DataView = CType(m_sortProxy.Target, DataView)
            Dim row As DataRow = bv.common.db.BaseDbService.FindRow(dv.Table, key)
            Dim i As Integer
            For i = 0 To dv.Count - 1
                If row Is dv(i).Row Then
                    m_grid.CurrentRowIndex = i
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    'Private Sub SetColumnVisible(ByVal col As String, ByVal visible As Boolean, Optional ByVal visibleWidth As Integer = 50)
    '    If Not IsReady() Then Return
    '    Dim baseTableName As String = MainTable.TableName
    '    Dim colStyle As DataGridColumnStyle = m_grid.TableStyles(baseTableName).GridColumnStyles(col)
    '    If colStyle Is Nothing Then Return
    '    If visible Then
    '        If m_colWidths.Contains(col) AndAlso CInt(m_colWidths(col)) > 0 Then
    '            colStyle.Width = CInt(m_colWidths(col))
    '        Else
    '            colStyle.Width = visibleWidth
    '        End If
    '    Else
    '        m_colWidths(col) = colStyle.Width
    '        colStyle.Width = 0
    '    End If
    'End Sub

    Public Overrides Sub UpdateBinding()
        If Not m_initialized Then Return
        If m_BindingUpdating Then Exit Sub
        m_BindingUpdating = True
        Dim dv As DataView = Provider.GetDataView()
        If Not m_sortProxy Is Nothing Then
            If m_sortProxy.Target Is dv Then Return
            m_grid.DataSource = Nothing
            m_sortProxy = Nothing
            Application.DoEvents()
        End If

        If Not dv Is Nothing Then
            m_sortProxy = New SortProxy
            m_sortProxy.Target = dv
            m_grid.TableStyles(0).MappingName = MainTable.TableName
            m_grid.DataSource = m_sortProxy

            Dim view As DataView = CType(m_sortProxy.Target, DataView)
            Dim col_style As DataGridColumnStyle
            For Each col_style In m_grid.TableStyles(0).GridColumnStyles
                Dim col As DataColumn = view.Table.Columns(col_style.MappingName)
                If Not col Is Nothing Then
                    If col.DataType.Name = "Decimal" AndAlso TypeOf (col_style) Is DataGridTextBoxColumn AndAlso CType(col_style, DataGridTextBoxColumn).Format = "" Then
                        CType(col_style, DataGridTextBoxColumn).Format = "n"
                    ElseIf col.DataType.Name = "DateTime" AndAlso TypeOf (col_style) Is DataGridTextBoxColumn AndAlso CType(col_style, DataGridTextBoxColumn).Format = "" Then
                        CType(col_style, DataGridTextBoxColumn).Format = "d"
                    End If
                End If
            Next

            AddHandler m_sortProxy.SortCommand, AddressOf HandleSortCommand
            AddHandler m_sortProxy.AfterSort, AddressOf AfterSort
            AddHandler BindingContext(m_sortProxy).PositionChanged, AddressOf HandlePositionChange
            m_ColumnResizer.Grid = Me.m_grid
        End If
        m_BindingUpdating = False
    End Sub


    Public Overrides Function GetSelectedRows() As DataRow()
        If Not IsReady() AndAlso MainTable.Rows.Count = 0 Then
            Return Nothing
        End If

        DataEventManager.Flush()
        Dim result As New ArrayList
        Dim I As Integer
        Dim HasSelection As Boolean = False
        For I = 0 To MainTable.Rows.Count - 1
            If m_grid.IsSelected(I) Then
                HasSelection = True
                Exit For
            End If
        Next
        For I = 0 To MainTable.Rows.Count - 1
            If (HasSelection AndAlso m_grid.IsSelected(I)) OrElse m_grid.CurrentRowIndex = I Then
                result.Add(CType(m_sortProxy(I), DataRowView).Row)
            End If
            m_grid.UnSelect(I)
        Next

        Return CType(result.ToArray(GetType(DataRow)), DataRow())
    End Function



#End Region

#Region " Public properties "
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public ReadOnly Property GridColumnStyles() As GridColumnStylesCollection
        Get
            Return m_gridTableStyle.GridColumnStyles
        End Get
    End Property


    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return m_grid.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            m_grid.ReadOnly = Value
        End Set
    End Property

    Public Overrides ReadOnly Property IsEmpty() As Boolean
        Get
            Return m_grid.VisibleRowCount = 0
        End Get
    End Property
    Public Overrides ReadOnly Property DataGrid() As Control
        Get
            Return m_grid
        End Get
    End Property
    <Browsable(True)> _
    Public Overrides ReadOnly Property DataSource() As Object
        Get
            Return m_grid.DataSource
        End Get
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public ReadOnly Property Grid() As DataGrid
        Get
            Return m_grid
        End Get
    End Property

#End Region

#Region " Private methods "
    Protected Overrides Sub InitGrid()
        Dim tableName As String = "DEFAULT"
        'If Not m_sortProxy.Target Is Nothing Then
        '    tableName = MainTable.TableName
        'End If
        m_gridTableStyle.DataGrid = m_grid
        m_gridTableStyle.MappingName = tableName
        m_grid.TableStyles.Add(m_gridTableStyle)
        If Not m_style Is Nothing Then
            m_style.ApplyStyle(m_grid)
            m_style.ApplyTableStyle(m_grid.TableStyles(tableName))
        End If
        m_ColumnResizer = New GridColumnResizer(m_grid)
    End Sub


#End Region


End Class
