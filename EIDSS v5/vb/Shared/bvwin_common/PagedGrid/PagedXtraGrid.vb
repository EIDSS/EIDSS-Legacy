Imports System.ComponentModel
Imports System.Collections.Specialized
Imports System.Runtime.Remoting
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class PagedXtraGrid
    Inherits BasePagedDataGrid

#Region " Private data members "
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        m_Columns = New GridColumnCollection(MainGridView)
        'm_RepositoryItems = New DevExpress.XtraEditors.Repository.RepositoryItemCollection
        'Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository
        'm_grid.ExternalRepository = m_Repository

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
    Friend WithEvents m_grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainGridView As DevExpress.XtraGrid.Views.Grid.GridView

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PagedXtraGrid))
        Me.m_grid = New DevExpress.XtraGrid.GridControl
        Me.MainGridView = New DevExpress.XtraGrid.Views.Grid.GridView
        CType(Me.m_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_grid
        '
        Me.m_grid.AccessibleDescription = Nothing
        Me.m_grid.AccessibleName = Nothing
        resources.ApplyResources(Me.m_grid, "m_grid")
        Me.m_grid.BackgroundImage = Nothing
        Me.m_grid.EmbeddedNavigator.AccessibleDescription = Nothing
        Me.m_grid.EmbeddedNavigator.AccessibleName = Nothing
        Me.m_grid.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("m_grid.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.m_grid.EmbeddedNavigator.Anchor = CType(resources.GetObject("m_grid.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.m_grid.EmbeddedNavigator.BackgroundImage = Nothing
        Me.m_grid.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("m_grid.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.m_grid.EmbeddedNavigator.ImeMode = CType(resources.GetObject("m_grid.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.m_grid.EmbeddedNavigator.TextLocation = CType(resources.GetObject("m_grid.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.m_grid.EmbeddedNavigator.ToolTip = resources.GetString("m_grid.EmbeddedNavigator.ToolTip")
        Me.m_grid.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("m_grid.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.m_grid.EmbeddedNavigator.ToolTipTitle = resources.GetString("m_grid.EmbeddedNavigator.ToolTipTitle")
        Me.m_grid.Font = Nothing
        Me.m_grid.MainView = Me.MainGridView
        Me.m_grid.Name = "m_grid"
        Me.m_grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainGridView})
        '
        'MainGridView
        '
        resources.ApplyResources(Me.MainGridView, "MainGridView")
        Me.MainGridView.GridControl = Me.m_grid
        Me.MainGridView.Name = "MainGridView"
        Me.MainGridView.OptionsView.ShowGroupPanel = False
        '
        'PagedXtraGrid
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.m_grid)
        Me.Font = Nothing
        Me.Name = "PagedXtraGrid"
        Me.SearchControl = "bv.common.win.XtraSearchPanel"
        Me.Controls.SetChildIndex(Me.m_grid, 0)
        CType(Me.m_grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGridView, System.ComponentModel.ISupportInitialize).EndInit()
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
                CType(m_grid.MainView, ColumnView).FocusedRowHandle = I
                Return True
            End If
        Next
        Return False
    End Function
    Public Overloads Overrides Function LocateRow(ByVal key As Object) As Boolean
        If key Is Nothing Then Return False
        If IsReady() Then
            Dim bm As BindingManagerBase = BindingContext(m_sortProxy)
            Dim dv As DataView = CType(m_sortProxy.Target, DataView)
            'Dim row As DataRow = bv.common.db.BaseDbService.FindRow(dv.Table, key)
            If dv.Table.PrimaryKey Is Nothing OrElse dv.Table.PrimaryKey.Length <> 1 Then
                Return False
            End If
            Dim keyName As String = dv.Table.PrimaryKey(0).ColumnName
            Dim i As Integer
            For i = 0 To dv.Count - 1
                If dv(i).Row.RowState <> DataRowState.Detached AndAlso dv(i).Row.RowState <> DataRowState.Deleted AndAlso dv(i)(keyName).Equals(key) Then
                    MainGridView.FocusedRowHandle = i
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public ReadOnly Property MainView() As GridView
        Get
            Return MainGridView
        End Get
    End Property
    Private Sub SetColumnVisible(ByVal colName As String, ByVal visible As Boolean, Optional ByVal visibleWidth As Integer = 50)
        If Not IsReady() Then Return
        Dim baseTableName As String = MainTable.TableName
        Dim col As GridColumn = MainView.Columns.ColumnByFieldName(colName)
        If visible = False Then
            col.VisibleIndex = -1
        ElseIf col.VisibleIndex < 0 Then
            col.VisibleIndex = MainView.VisibleColumns.Count - MainView.Columns.Count + col.AbsoluteIndex
        End If
    End Sub

    Public Overrides Sub UpdateBinding()
        If Not m_initialized Then Return
        If m_BindingUpdating Then Exit Sub
        m_BindingUpdating = True
        Try
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
                m_grid.DataSource = m_sortProxy

                Dim view As DataView = CType(m_sortProxy.Target, DataView)
                'Dim col_style As GridColumn
                'For Each col_style In MainView.Columns
                '    Dim col As DataColumn = view.Table.Columns(col_style.FieldName)
                '    If Not col Is Nothing Then
                '        If col.DataType.Name = "Decimal" AndAlso TypeOf (col_style) Is DataGridTextBoxColumn AndAlso col_style.ColumnEdit.EditFormat.FormatString = "" Then
                '            col_style.ColumnEdit.EditFormat.FormatString = GlobalSettings.DefaultCurrencyFormat
                '        ElseIf col.DataType.Name = "DateTime" AndAlso TypeOf (col_style) Is DataGridTextBoxColumn AndAlso col_style.ColumnEdit.EditFormat.FormatString = "" Then
                '            col_style.ColumnEdit.EditFormat.FormatString = "d"
                '        End If
                '    End If
                'Next

                AddHandler m_sortProxy.SortCommand, AddressOf HandleSortCommand
                AddHandler m_sortProxy.AfterSort, AddressOf AfterSort
                AddHandler BindingContext(m_sortProxy).PositionChanged, AddressOf HandlePositionChange
            End If

        Catch ex As Exception
            Throw
        Finally
            m_BindingUpdating = False
        End Try
    End Sub


    Public Overrides Function GetSelectedRows() As DataRow()
        If Not IsReady() AndAlso MainTable.Rows.Count = 0 Then
            Return Nothing
        End If

        DataEventManager.Flush()
        Dim result As New ArrayList
        Dim I As Integer
        For I = 0 To MainGridView.SelectedRowsCount() - 1
            If (MainGridView.GetSelectedRows()(I) >= 0) Then result.Add(MainGridView.GetDataRow(MainGridView.GetSelectedRows()(I)))
        Next
        Return CType(result.ToArray(GetType(DataRow)), DataRow())
    End Function

#End Region

#Region " Public delegates "
#End Region

#Region " Public properties "
    Private m_Columns As GridColumnCollection
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public ReadOnly Property Columns() As GridColumnCollection
        Get
            Return m_Columns
        End Get
    End Property
    'Private m_Repository As DevExpress.XtraEditors.Repository.PersistentRepository
    '<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    'Public Property ExternalRepository() As DevExpress.XtraEditors.Repository.PersistentRepository
    '    Get
    '        Return m_Repository
    '    End Get
    '    Set(ByVal Value As DevExpress.XtraEditors.Repository.PersistentRepository)
    '        'Me.Grid.ExternalRepository = Value
    '        m_Repository = Value
    '    End Set
    'End Property
    'Private m_RepositoryItems As DevExpress.XtraEditors.Repository.RepositoryItemCollection
    '<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    'Public ReadOnly Property RepositoryItems() As DevExpress.XtraEditors.Repository.RepositoryItemCollection
    '    Get
    '        Return m_RepositoryItems
    '    End Get
    'End Property
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MainGridView.OptionsBehavior.Editable = False
        End Get
        Set(ByVal Value As Boolean)
            MainGridView.OptionsBehavior.Editable = Not Value
        End Set
    End Property

    Public Overrides ReadOnly Property IsEmpty() As Boolean
        Get
            Return MainView.RowCount = 0
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
            Return MainView.DataSource
        End Get
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public ReadOnly Property Grid() As GridControl
        Get
            Return m_grid
        End Get
    End Property

    Public Overrides ReadOnly Property CurrentRow() As DataRow
        Get
            If IsReady() Then
                MainGridView.GetDataRow(MainGridView.FocusedRowHandle)
            End If
            Return Nothing
        End Get
    End Property
    <Browsable(False)> _
    Public Overrides Property DefaultSortCondition() As String
        Get
            If Not m_DefaultSortCondition Is Nothing Then
                Return m_DefaultSortCondition
            End If
            If (TypeOf (Me.Parent) Is BasePagedXtraListForm) Then
                Dim sortColumn As GridColumn = CType(Parent, BasePagedXtraListForm).GetFirstVisibleAndSortableColumn()
                If sortColumn Is Nothing OrElse Utils.IsEmpty(sortColumn.FieldName) Then
                    Return Nothing
                End If
                Dim sortOrder As String = ""
                If sortColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending Then
                    sortOrder = " DESC"
                End If
                If Utils.IsEmpty(CType(Me.Parent, BaseListForm).ObjectName) Then
                    Return sortColumn.FieldName + sortOrder
                Else
                    Return String.Format("fn_{0}_SelectList.", CType(Me.Parent, BaseListForm).ObjectName) + sortColumn.FieldName + sortOrder
                End If
            End If
            Return Nothing
        End Get
        Set(ByVal value As String)
            m_DefaultSortCondition = value
        End Set
    End Property


#End Region

#Region " Private methods "
    Protected Overrides Sub UpdateSearchPanel()
    End Sub
    Protected Overrides Sub InitGrid()
        Dim tableName As String = "DEFAULT"
    End Sub
    Public Overrides Sub EndUpdate()
        m_updating = False
        Me.MainView.ExpandAllGroups()
    End Sub

#End Region


    Private Sub grid_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_grid.Resize
        Me.m_grid.Height = Me.pager.Top - Me.m_grid.Top
        Me.m_grid.Width = Me.Width - Me.m_grid.Left
    End Sub
    Public Overrides Sub PrepareSearchPanelLoading()
        MainGridView.Columns.Clear()
        For i As Integer = m_Columns.Count - 1 To 0 Step -1
            MainGridView.Columns.Add(Columns(i))
        Next
    End Sub

    Private Sub PagedXtraGrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.PersistentRepository1.Items.Clear()
        'For i As Integer = m_RepositoryItems.Count - 1 To 0 Step -1
        '    PersistentRepository1.Items.Add(m_RepositoryItems(i))
        'Next
        grid_Resize(Nothing, EventArgs.Empty)
    End Sub
    Friend m_Sorting As Boolean = False
    Private Sub MainGridView_StartSorting(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainGridView.StartSorting
        If m_Sorting OrElse m_updating Then Exit Sub
        Dim sortColumn As GridColumn = MainGridView.SortedColumns(0)
        If sortColumn Is Nothing Then Exit Sub
        Try
            m_Sorting = True
            'MainGridView.ClearSorting()
            Dim newSortCondition As String = ""
            If IsReady() Then
                For Each sortColumn In MainGridView.SortedColumns
                    Dim order As DevExpress.Data.ColumnSortOrder = sortColumn.SortOrder
                    Dim ascending As Boolean = True
                    If order = DevExpress.Data.ColumnSortOrder.Descending Then
                        ascending = False
                    End If
                    If newSortCondition <> "" Then
                        newSortCondition += ","
                    End If
                    If (TypeOf (Me.Parent) Is BaseListForm) AndAlso Not Utils.IsEmpty(sortColumn.FieldName) Then
                        newSortCondition += String.Format("fn_{0}_SelectList.", CType(Me.Parent, BaseListForm).ObjectName) + sortColumn.FieldName
                    Else
                        newSortCondition += sortColumn.FieldName
                    End If
                    If Not ascending Then
                        newSortCondition &= " DESC"
                    End If
                    sortColumn.SortOrder = order
                Next
                If SortCondition.ToLowerInvariant <> newSortCondition.ToLowerInvariant Then
                    SortCondition = newSortCondition
                    RefreshData()
                End If

            End If
        Finally
            m_Sorting = False
        End Try

    End Sub

End Class

