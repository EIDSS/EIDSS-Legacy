Imports System.ComponentModel
Imports System.Collections.Specialized
Imports System.Runtime.Remoting
Imports bv.common.Resources
Imports bv.winclient.Core


Public Class BasePagedDataGrid
    Inherits DevExpress.XtraEditors.XtraUserControl
    Implements ISupportInitialize

#Region " Private data members "
    Protected m_style As IGridStyle = New DefaultGridStyle
    Protected m_batchInitialize As Boolean = False
    Protected m_initialized As Boolean = False
    Protected m_ownPageChange As Boolean = False
    Protected m_provider As IGridDataProvider = Nothing
    Protected m_sortProxy As SortProxy = Nothing
    Protected m_sortBy As String = Nothing
    Protected m_colWidths As New HybridDictionary
    Protected m_filterCondition As String = ""
    Protected m_staticFilterCondition As String = ""
    Protected m_updating As Boolean
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
    Friend WithEvents pager As PagerPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BasePagedDataGrid))
        Me.pager = New bv.common.win.PagerPanel
        CType(Me.pager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pager
        '
        Me.pager.CurrentPage = 1
        resources.ApplyResources(Me.pager, "pager")
        Me.pager.Name = "pager"
        Me.pager.PageCount = 0
        Me.pager.PageSize = 10
        Me.pager.VisiblePages = 10
        '
        'BasePagedDataGrid
        '
        Me.Controls.Add(Me.pager)
        Me.Name = "BasePagedDataGrid"
        resources.ApplyResources(Me, "$this")
        CType(Me.pager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Public methods "
    Public Overridable Function LocateRow(ByVal field As String, ByVal value As Object) As Boolean
        Return False
    End Function
    Public Overridable Function LocateRow(ByVal key As Object) As Boolean
        Return False
    End Function

    'Private Sub SetColumnVisible(ByVal col As String, ByVal visible As Boolean, Optional ByVal visibleWidth As Integer = 50)
    '    If Not IsReady() Then Return
    '    Dim baseTableName As String = MainTable.TableName
    '    Dim colStyle As DataGridColumnStyle = grid.TableStyles(baseTableName).GridColumnStyles(col)
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

    Protected m_BindingUpdating As Boolean = False
    Public Overridable Sub UpdateBinding()
    End Sub
    Public Sub BeginUpdate()
        m_updating = True
    End Sub
    Public Overridable Sub EndUpdate()
        m_updating = False
    End Sub


    Public Sub BeginInit() Implements System.ComponentModel.ISupportInitialize.BeginInit
        m_batchInitialize = True
    End Sub

    Public Sub EndInit() Implements System.ComponentModel.ISupportInitialize.EndInit
        Init(True)
    End Sub

    Public Overridable Function GetSelectedRows() As DataRow()
        Return Nothing
    End Function

    Public Function ApplyToSelectedRows(ByVal handler As RowHandler, Optional ByVal cookie As Object = Nothing) As Integer
        Dim rows() As DataRow = GetSelectedRows()
        If Not rows Is Nothing Then
            Dim row As DataRow
            For Each row In rows
                handler(row, cookie)
            Next
            RefreshData()
            Return rows.Length
        End If
        Return 0
    End Function


    Public Sub RefreshData()
        If Not m_initialized Then Return
        m_ownPageChange = True
        Dim oldEnabled As Boolean = Enabled
        Try
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            CurrentPage = 1
            Enabled = False
            Provider.Refresh()
            UpdateBinding()
        Catch ex As Exception
            ErrorForm.ShowError(ex)
        Finally
            m_ownPageChange = False
            Enabled = oldEnabled
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region " Public delegates "
    ' RowHandler is used to perform some operation on selected rows.
    ' It should return True to continue, False to interrupt the loop
    ' over selected rows.
    Public Delegate Function RowHandler(ByVal row As DataRow, ByVal cookie As Object) As Boolean
    'Public Delegate Function WSHandler(ByVal primaryKey As String) As String
#End Region

#Region " Public properties "
    <Browsable(False)> _
    Public Property CurrentPage() As Integer
        Get
            Return pager.CurrentPage
        End Get
        Set(ByVal Value As Integer)
            pager.CurrentPage = Value
        End Set
    End Property

    <Browsable(True), DefaultValue(10)> _
    Public Property PageCount() As Integer
        Get
            Return pager.PageCount
        End Get
        Set(ByVal Value As Integer)
            pager.PageCount = Value
        End Set
    End Property
    <Browsable(True), DefaultValue(10)> _
    Public Property PageSize() As Integer
        Get
            Return pager.PageSize
        End Get
        Set(ByVal Value As Integer)
            pager.PageSize = Value
        End Set
    End Property
    <Browsable(True)> _
    Public Property SortCondition() As String
        Get
            Return m_sortBy
        End Get
        Set(ByVal Value As String)
            If (Value <> m_sortBy) Then CurrentPage = 1
            m_sortBy = Value
        End Set
    End Property
    Private m_SearchParameters As Generic.Dictionary(Of String, Object)
    <Browsable(True)> _
    Public Property SearchParameters() As Generic.Dictionary(Of String, Object)
        Get
            Return m_SearchParameters
        End Get
        Set(ByVal Value As Generic.Dictionary(Of String, Object))
            m_SearchParameters = Value
        End Set
    End Property

    <Browsable(True)> _
    Public ReadOnly Property FilterCondition() As String
        Get
            If SearchForm Is Nothing Then
                Return m_staticFilterCondition
            End If
            If ShowSearch = False AndAlso (Not Utils.IsEmpty(SearchForm.FilterCondition) _
                            OrElse Not Utils.IsEmpty(SearchForm.FromCondition) _
                            OrElse BaseSettings.ShowEmptyListOnSearch) Then
                Return m_staticFilterCondition
            End If
            m_filterCondition = m_staticFilterCondition
            If Not Utils.IsEmpty(m_staticFilterCondition) Then
                If Utils.IsEmpty(SearchForm.FilterCondition) Then
                    m_filterCondition = m_staticFilterCondition
                Else
                    m_filterCondition = String.Format("({0}) And ({1})", m_staticFilterCondition, SearchForm.FilterCondition)
                End If
            Else
                m_filterCondition = SearchForm.FilterCondition
            End If
            Return m_filterCondition
        End Get
        'Set(ByVal Value As String)
        '    m_filterCondition = Value
        'End Set
    End Property
    Dim m_FromCondition As String = ""
    <Browsable(True)> _
    Public ReadOnly Property FromCondition() As String
        Get
            If SearchForm Is Nothing Then
                Return Nothing
            End If

            If ShowSearch = False AndAlso (Not Utils.IsEmpty(SearchForm.FilterCondition) _
                            OrElse Not Utils.IsEmpty(SearchForm.FromCondition) _
                            OrElse BaseSettings.ShowEmptyListOnSearch) Then
                Return Nothing
            End If
            Return SearchForm.FromCondition
        End Get
        'Set(ByVal Value As String)
        '    m_FromCondition = Value
        'End Set
    End Property

    <Browsable(True)> _
    Public Property StaticFilterCondition() As String
        Get
            Return m_staticFilterCondition
        End Get
        Set(ByVal Value As String)
            m_staticFilterCondition = Value
            '    If IsReady() Then
            '        If Not m_SearchControl Is Nothing AndAlso m_SearchControl.Visible Then
            '            SetFilterCondition(SearchForm.FilterCondition, FromCondition, Nothing, False)
            '        Else
            '            SetFilterCondition(Nothing, FromCondition, Nothing, False)
            '        End If
            '    End If
        End Set
    End Property
    <Browsable(False)> _
    Public ReadOnly Property SearchForm() As ISearchForm
        Get
            'If Utils.IsEmpty(m_SearchControlName) Then Return Nothing
            'If m_SearchControl Is Nothing Then
            '    LoadSearchPanel()
            'End If
            If Not m_SearchControl Is Nothing Then
                Return CType(m_SearchControl, ISearchForm)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Dim m_SearchControl As Control
    Dim m_SearchControlName As String
    <Browsable(True)> _
    Public Property SearchControl() As String
        Get

            If Not m_SearchControl Is Nothing Then
                Return m_SearchControl.GetType.FullName
            Else
                Return m_SearchControlName
            End If
        End Get
        Set(ByVal Value As String)
            If Not Value Is Nothing AndAlso Not m_SearchControl Is Nothing AndAlso SearchControl = Value Then
                Return
            End If
            m_SearchControlName = Value
            If Value Is Nothing OrElse Value.Trim = "" Then
                Return
            End If
            If Value.IndexOf(".") < 0 Then Value = "bv.common.win." + Value
            If m_SearchControlName <> Value Then
                m_SearchControlName = Value
            End If
        End Set
    End Property
    Public ReadOnly Property MainTable() As DataTable
        Get
            If m_sortProxy Is Nothing OrElse m_sortProxy Is Nothing Then
                Return Nothing
            Else
                Return CType(m_sortProxy.Target, DataView).Table
            End If
        End Get
    End Property

    <Browsable(True)> _
    Public Overridable Property [ReadOnly]() As Boolean
        Get
            Return True
        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property

    <Browsable(False)> _
    Public Overridable ReadOnly Property IsEmpty() As Boolean
        Get
            Return True
        End Get
    End Property

    <Browsable(False)> _
    Public Overridable ReadOnly Property DataGrid() As Control
        Get
            Return Nothing
        End Get
    End Property

    <Browsable(True)> _
    Public Overridable ReadOnly Property DataSource() As Object
        Get
            Return Nothing
        End Get
    End Property

    <Browsable(False)> _
    Public Overridable ReadOnly Property CurrentRow() As DataRow
        Get
            If IsReady() Then
                Dim bm As BindingManagerBase = BindingContext(m_sortProxy)
                If bm.Position >= 0 Then
                    Return CType(bm.Current, DataRowView).Row
                End If
            End If
            Return Nothing
        End Get
    End Property


    <Browsable(False)> _
    Public Property GridStyle() As IGridStyle
        Get
            Return m_style
        End Get
        Set(ByVal Value As IGridStyle)
            m_style = Value
        End Set
    End Property
    Dim m_SearchPanelDocStyle As DockStyle
    Public Property SearchPanelDocStyle() As DockStyle
        Get
            Return m_SearchPanelDocStyle
        End Get
        Set(ByVal Value As DockStyle)
            If (Value = DockStyle.Left) OrElse (Value = DockStyle.Top) Then
                m_SearchPanelDocStyle = Value
            Else
                m_SearchPanelDocStyle = DockStyle.Top
            End If
        End Set
    End Property
    Private m_ShowSearch As Boolean
    Public ReadOnly Property ShowSearch() As Boolean
        Get
            If m_SearchControl Is Nothing Then Return False
            Return m_ShowSearch
        End Get
    End Property
    Public Sub SetShowSearch(ByVal value As Boolean, ByVal needRefreshData As Boolean)
        If DesignMode Then Return
        If m_SearchControl Is Nothing Then Return
        If m_ShowSearch = value Then
            Return
        End If
        If DataGrid Is Nothing Then Return
        m_ShowSearch = value
        If m_SearchPanelDocStyle = DockStyle.Left Then
            Dim w As Integer = m_SearchControl.Width
            If value Then
                DataGrid.Left += w
                DataGrid.Width -= w
                m_SearchControl.Height = Me.DataGrid.Height
                'cond = SearchForm.FilterCondition
                UpdateSearchPanel()
            Else
                DataGrid.Left -= m_SearchControl.Width
                DataGrid.Width += m_SearchControl.Width
            End If
        Else
            Dim h As Integer = m_SearchControl.Height
            If value Then
                DataGrid.Top += h
                DataGrid.Height -= h
                'cond = SearchForm.FilterCondition
                UpdateSearchPanel()
            Else
                DataGrid.Top -= m_SearchControl.Height
                DataGrid.Height += h
            End If
        End If
        m_SearchControl.Visible = value
        If needRefreshData Then
            RefreshData()
        End If

    End Sub

    <DefaultValue(CType(Nothing, String))> _
    Public Property Provider() As IGridDataProvider
        Get
            If m_provider Is Nothing AndAlso Not DesignMode Then
                m_provider = New DefaultGridDataProvider(Me)
            End If
            Return m_provider
        End Get
        Set(ByVal Value As IGridDataProvider)
            If Not m_provider Is Nothing AndAlso Not DesignMode Then
                Throw New SystemException("Changing Grid Data Provider currently not supported")
            End If
            m_provider = Value
            m_provider.SetGrid(Me)
            If m_initialized Then
                RefreshData()
            End If
        End Set
    End Property
    Protected m_DefaultSortCondition As String
    <Browsable(False)> _
    Public Overridable Property DefaultSortCondition() As String
        Get
            Return m_DefaultSortCondition
        End Get
        Set(ByVal value As String)
            m_DefaultSortCondition = value
        End Set
    End Property

#End Region

#Region " Private methods "
    Protected Sub HandleSortCommand(ByVal sortBy As String, ByVal ascending As Boolean)
        If IsReady() Then
            If (TypeOf (Me.Parent) Is BaseListForm) AndAlso Not Utils.IsEmpty(sortBy) Then
                SortCondition = String.Format("fn_{0}_SelectList.", CType(Me.Parent, BaseListForm).ObjectName) + sortBy
            Else
                SortCondition = sortBy
            End If
            If Not ascending Then
                SortCondition &= " DESC"
            End If
            RefreshData()
            Provider.UpdateDetails()
        End If
    End Sub
    Protected Sub AfterSort(ByVal sender As Object, ByVal e As System.EventArgs) Handles pager.PageChanged
        If IsReady() Then
            Provider.UpdateDetails()
        End If
    End Sub

    Protected Sub HandlePageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pager.PageChanged
        If IsReady() AndAlso Not m_ownPageChange Then
            CurrentPage = pager.CurrentPage()
            Provider.Refresh()
            UpdateBinding()
        End If
    End Sub

    Protected Sub HandlePositionChange(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsReady() Then
            Provider.UpdateDetails()
        End If
    End Sub

    Protected Overridable Sub InitGrid()
        Dim tableName As String = "DEFAULT"
    End Sub

    Private Function Init(Optional ByVal atEndInit As Boolean = False) As Boolean
        ' check whether initialization is necessary
        If m_initialized OrElse DesignMode OrElse (m_batchInitialize AndAlso Not atEndInit) Then
            Return m_initialized
        End If
        SortCondition = Nothing
        InitGrid()
        UpdateBinding()
        m_initialized = True
        UpdateSearchPanel()
    End Function

    Private Sub PagedGrid_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Init()
    End Sub

    Protected Overridable Sub UpdateSearchPanel()
    End Sub

    Protected Sub grid_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UpdateSearchPanel()
    End Sub

    Protected Sub spanel_Search(ByVal FilterCondition As String, ByVal FromCondition As String)
        If m_sortProxy Is Nothing Then
            UpdateBinding()
        End If
        'SetFilterCondition(FilterCondition, FromCondition, Nothing)
        RefreshData()
        If ((Provider.GetDataView Is Nothing) OrElse (Provider.GetDataView.Count = 0)) AndAlso (Utils.Str(FilterCondition) <> "" OrElse Utils.Str(FromCondition) <> "") AndAlso Utils.Str(Config.GetSetting("ShowNoRecordsMessage")).ToLower(Globalization.CultureInfo.InvariantCulture) = "true" Then
            MessageForm.Show(BvMessages.Get("msgNoRecordsFound", "No records is found for current search criteria."))
        End If

    End Sub
    Protected Sub spanel_SearchUsingProcedure(ByVal SearchParameters As Generic.Dictionary(Of String, Object))
        If m_sortProxy Is Nothing Then
            UpdateBinding()
        End If
        'SetFilterCondition(Nothing, Nothing, SearchParameters)
        RefreshData()
        If ((Provider.GetDataView Is Nothing) OrElse (Provider.GetDataView.Count = 0)) AndAlso (Utils.Str(FilterCondition) <> "" OrElse Utils.Str(FromCondition) <> "") AndAlso Utils.Str(Config.GetSetting("ShowNoRecordsMessage")).ToLower(Globalization.CultureInfo.InvariantCulture) = "true" Then
            MessageForm.Show(BvMessages.Get("msgNoRecordsFound", "No records is found for current search criteria."))
        End If

    End Sub

    'Protected Sub SetFilterCondition(ByVal cond As String, ByVal aFromCondition As String, ByVal aSearchParameters As Generic.Dictionary(Of String, Object), Optional ByVal needRefresh As Boolean = True)
    '    If IsReady() Then
    '        If Not m_staticFilterCondition Is Nothing AndAlso m_staticFilterCondition.Trim() <> "" Then
    '            If cond Is Nothing OrElse cond.Trim() = "" Then
    '                FilterCondition = m_staticFilterCondition
    '            Else
    '                FilterCondition = String.Format("({0}) And ({1})", m_staticFilterCondition, cond)
    '            End If
    '        Else
    '            FilterCondition = cond
    '        End If
    '        FromCondition = aFromCondition
    '        SearchParameters = aSearchParameters
    '        If needRefresh Then
    '            RefreshData()
    '        End If
    '    End If
    'End Sub


    Protected Function IsReady() As Boolean
        Return m_initialized AndAlso Not m_sortProxy Is Nothing
    End Function
#End Region

    Protected Function IsDesignMode() As Boolean
        If DesignMode Then Return True
        Dim ctl As Control = Parent
        While Not ctl Is Nothing
            If ctl.GetType.Name = "OverlayControl" Then
                Return True
            End If
            If TypeOf ctl Is Form Then Return False
            ctl = ctl.Parent
        End While
        Return False
    End Function

    Dim m_SearchOriginalHeight As Integer
    Dim m_SearchOriginalWidth As Integer
    Public Sub LoadSearchPanel()
        If IsDesignMode() Then
            Exit Sub
        End If
        If Not m_SearchControl Is Nothing AndAlso m_SearchControl.GetType().FullName <> Me.m_SearchControlName Then
            m_SearchControl.Dispose()
            m_SearchControl = Nothing
            'Dim ctl As Object = CType(hdl, ObjectHandle).Unwrap()
        End If
        'Dim ctl As Object = ClassLoader.LoadClass(Value)
        If m_SearchControl Is Nothing Then
            Dim ctl As Object
            Try
                ctl = ClassLoader.LoadClass(m_SearchControlName)
            Catch ex As Exception
                MessageForm.Show("Type is not defined:" + vbCrLf + ex.Message)
                Exit Sub
            End Try
            If TypeOf (ctl) Is ISearchForm Then
            Else
                MessageForm.Show("Only class that implements ISearchForm interface can be used here")
                Exit Sub
            End If
            m_SearchControl = CType(ctl, Control)
            m_SearchOriginalHeight = m_SearchControl.Height
            m_SearchOriginalWidth = m_SearchControl.Width
        End If
        If Not m_SearchControl Is Nothing Then
            m_SearchControl.Visible = False
            If m_SearchPanelDocStyle = DockStyle.Left Then
                m_SearchControl.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Bottom
                m_SearchControl.Height = Me.Height
                m_SearchControl.Width = m_SearchOriginalWidth
            Else
                m_SearchControl.Height = m_SearchOriginalHeight
                m_SearchControl.Width = Me.Width
                m_SearchControl.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            End If
            m_SearchControl.Parent = Me
            AddHandler SearchForm.Search, AddressOf spanel_Search
            AddHandler SearchForm.SearchUsingProcedure, AddressOf spanel_SearchUsingProcedure
            PrepareSearchPanelLoading()
            Try 'Mike: I Inserted this try catch here because the line below was commented and I don't remember why
                SearchForm.Init(DataGrid) 'this line is needed here to intialize search parameters passed from parent form before doing search
            Catch e As Exception

            End Try
        End If
    End Sub
    Public Overridable Sub PrepareSearchPanelLoading()

    End Sub
End Class

Public Interface IGridDataProvider
    Function GetDataView() As DataView
    Sub Refresh()
    Sub UpdateDetails()
    Sub SetGrid(ByVal grid As BasePagedDataGrid)
End Interface

Public Interface IGridStyle
    Sub ApplyStyle(ByVal grid As DataGrid)
    Sub ApplyTableStyle(ByVal style As DataGridTableStyle)
End Interface
