Imports System.ComponentModel
Imports bv.common.Resources
Public Class BasePagedListForm
    Inherits BaseListForm
    'Implements ISearchable


#Region " Windows Form Designer generated code "

    Protected WithEvents cmdEdit As Control
    Protected WithEvents cmdDelete As Control
    Protected WithEvents cmdNew As Control
    Protected WithEvents cmdSearch As Control
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        [ReadOnly] = True
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'BasePagedListForm
        '
        Me.Name = "BasePagedListForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "BaseFormList overrides methods"
    Dim FillDsFlag As Boolean = False
    Public Overrides Function FillDataset(Optional ByVal ID As Object = Nothing) As Boolean
        If Status = FormStatus.Demo Then
            Return True
        End If
        If FillDsFlag Then Return True
        If Grid Is Nothing Then
            Throw New Exception("Grid is not defined")
        End If
        FillDsFlag = True
        Dim DataRefreshed As Boolean = False
        CType(Grid, Control).SuspendLayout()
        Me.PagedGrid.BeginUpdate()
        Try
            baseDataSet.Tables.Clear()
            'If baseDataSet.Tables.Contains(ObjectName) Then
            '    'Remove not primary key columns to avoid problems with constrains 
            '    'after adding new columns after using complex search conditions
            '    'included joined tables
            '    Dim t As DataTable = baseDataSet.Tables(ObjectName)
            '    For i As Integer = t.Columns.Count - 1 To 0 Step -1
            '        If t.Columns.CanRemove(t.Columns(i)) Then
            '            t.Columns.Remove(t.Columns(i))
            '        End If
            '    Next
            '    baseDataSet.AcceptChanges()

            '    DataRefreshed = True
            '    baseDataSet.Tables(ObjectName).BeginLoadData()
            'End If
            Dim OldKey As Object = GetKey()
            Dim ds As DataSet = GetDataset()
            If ds Is Nothing OrElse ds.Tables.Count = 0 Then Return False
            If (ds.Tables(ObjectName).PrimaryKey Is Nothing OrElse ds.Tables(ObjectName).PrimaryKey.Length = 0) Then
                If Not KeyFieldName Is Nothing Then
                    ds.Tables(ObjectName).PrimaryKey = New DataColumn() {ds.Tables(ObjectName).Columns(KeyFieldName)}
                Else
                    ds.Tables(ObjectName).PrimaryKey = New DataColumn() {ds.Tables(ObjectName).Columns(0)}
                End If
            End If
            baseDataSet.Merge(ds)
            DbDisposeHelper.DisposeDataset(ds)

            If TypeOf (Grid) Is DataGrid Then
                CType(Grid, DataGrid).TableStyles(0).MappingName = ObjectName
            End If
            baseDataSet.Tables(ObjectName).DefaultView.AllowNew = False
            baseDataSet.Tables(ObjectName).DefaultView.AllowDelete = False
            baseDataSet.Tables(ObjectName).DefaultView.AllowEdit = False
            LocateRow(OldKey)
        Catch ex As System.Reflection.TargetInvocationException
            Throw ex.InnerException
        Catch ex As Exception
            Throw
        Finally
            Try
                If DataRefreshed Then
                    baseDataSet.Tables(ObjectName).EndLoadData()
                End If
            Catch ex As Exception

            End Try
            CType(Grid, Control).ResumeLayout()
            FillDsFlag = False
            Me.PagedGrid.EndUpdate()
        End Try
        Return True
    End Function

    Protected Overrides Sub TableAdded(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
        If DesignMode Then Exit Sub
        If e.Action = CollectionChangeAction.Add And Not PagedGrid Is Nothing Then
            PagedGrid.UpdateBinding()
        End If
    End Sub

    Public Overrides Function GetDataset() As DataSet
        If PagedGrid Is Nothing Then Return Nothing
        Dim RecordCount As Integer = 0
        Dim ds As DataSet = Nothing
        If Not DbService Is Nothing Then
            DbService.SearchParameters = PagedGrid.SearchParameters
            ds = DbService.GetPagedList(PagedGrid.PageSize, PagedGrid.CurrentPage - 1, PagedGrid.FilterCondition, PagedGrid.FromCondition, PagedGrid.SortCondition, RecordCount)
        Else
            Dim params() As Object
            params = New Object() { _
                                    PagedGrid.PageSize, PagedGrid.CurrentPage - 1, PagedGrid.FilterCondition, PagedGrid.FromCondition, PagedGrid.SortCondition, RecordCount}
            Dim o As Object = ClassLoader.LoadClass(ObjectName + "_DB")
            ReflectionHelper.SetProperty(o, "SearchParameters", PagedGrid.SearchParameters)
            Dim typeArray(5) As Type

            Dim m_listMethod As Reflection.MethodInfo = o.GetType().GetMethod("GetPagedList")
            o = m_listMethod.Invoke(o, params)
            If Not o Is Nothing Then
                ds = CType(o, DataSet)
                RecordCount = CInt(params(5))
            End If

        End If
        If RecordCount < PagedGrid.PageSize Then
            PagedGrid.PageCount = 0
        Else
            PagedGrid.PageCount = (RecordCount + PagedGrid.PageSize - 1) \ PagedGrid.PageSize
        End If
        Return ds
    End Function

    Public Overrides Function GetBindingManager(Optional ByVal aTableName As String = Nothing) As BindingManagerBase
        If PagedGrid Is Nothing Then Return Nothing
        If PagedGrid.DataSource Is Nothing Then Return Nothing
        Return PagedGrid.BindingContext(PagedGrid.DataSource)
    End Function

    Public Overrides Function LocateRow(ByVal ID As Object) As Boolean
        If PagedGrid Is Nothing Then Return False
        Return PagedGrid.LocateRow(ID)
    End Function
    Public Overloads Property StartUpParameters() As Generic.Dictionary(Of String, Object)
        Get
            Return MyBase.StartUpParameters
        End Get
        Set(ByVal value As Generic.Dictionary(Of String, Object))
            If Not Value Is Nothing Then
                If Value.ContainsKey("ShowSearch") AndAlso TypeOf (Value("ShowSearch")) Is Boolean = True Then
                    ShowSearch = CType(Value("ShowSearch"), Boolean)
                End If
            End If
            MyBase.StartUpParameters = Value
        End Set
    End Property


#End Region

#Region "Public properies"

    <Browsable(False)> _
    Public Overrides ReadOnly Property Grid() As Object
        Get
            If PagedGrid Is Nothing Then Return Nothing
            Return PagedGrid.DataGrid
        End Get
    End Property

    Public Overrides Property SearchPanelDocStyle() As DockStyle
        Get
            If Not PagedGrid Is Nothing Then Return PagedGrid.SearchPanelDocStyle
        End Get
        Set(ByVal Value As DockStyle)
            If Not PagedGrid Is Nothing Then
                PagedGrid.SearchPanelDocStyle = Value
            End If
        End Set
    End Property

    Dim m_ShowEditButton As Boolean = True
    <DefaultValue(True)> _
    Public Property ShowEditButton() As Boolean
        Get
            Return m_ShowEditButton
        End Get
        Set(ByVal Value As Boolean)
            m_ShowEditButton = Value
            If Not cmdEdit Is Nothing Then
                cmdEdit.Visible = Value
            End If
        End Set
    End Property
    Dim m_ShowDeleteButton As Boolean = True
    <DefaultValue(True)> _
    Public Property ShowDeleteButton() As Boolean
        Get
            Return m_ShowDeleteButton
        End Get
        Set(ByVal Value As Boolean)
            m_ShowDeleteButton = Value
            If Not cmdDelete Is Nothing Then
                cmdDelete.Visible = Value
            End If
        End Set
    End Property

    Dim m_ShowSearchButton As Boolean = True
    <DefaultValue(True)> _
    Public Property ShowSearchButton() As Boolean
        Get
            Return m_ShowSearchButton
        End Get
        Set(ByVal Value As Boolean)
            m_ShowSearchButton = Value
            If Not cmdSearch Is Nothing Then
                cmdSearch.Visible = Value
            End If
        End Set
    End Property

    Dim m_ShowNewButton As Boolean = True
    <DefaultValue(True)> _
    Public Property ShowNewButton() As Boolean
        Get
            Return m_ShowNewButton
        End Get
        Set(ByVal Value As Boolean)
            m_ShowNewButton = Value
            If Not cmdNew Is Nothing Then
                cmdNew.Visible = Value
            End If
        End Set
    End Property
    'Dim m_ShowSearch As Boolean
    <DefaultValue(True)> _
    Public Overrides Property ShowSearch() As Boolean
        Get
            Return m_ShowSearch
            'Return PagedGrid.ShowSearch
        End Get
        Set(ByVal Value As Boolean)
            If PagedGrid Is Nothing Then Return
            If Not cmdSearch Is Nothing Then
                If Value = False Then
                    cmdSearch.Text = BvMessages.Get("bntShowSearch", "Show Search")
                Else
                    cmdSearch.Text = BvMessages.Get("bntHideSearch", "Hide Search")
                End If
            End If
            m_ShowSearch = Value
            PagedGrid.SetShowSearch(Value, False)
        End Set
    End Property

    <Browsable(True)> _
    Public Overrides Property SearchControl() As String
        Get
            If Not PagedGrid Is Nothing Then
                Return PagedGrid.SearchControl
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As String)
            If Not PagedGrid Is Nothing Then
                PagedGrid.SearchControl = Value
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(True)> _
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            m_Readonly = Value
            If Not PagedGrid Is Nothing Then
                PagedGrid.ReadOnly = Value
            End If
        End Set
    End Property

#End Region

#Region "Public methods"


#End Region

#Region "Protected methods"
    Public Overridable ReadOnly Property PagedGrid() As BasePagedDataGrid
        Get
            Return Nothing
        End Get
    End Property
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        If DesignMode Then Exit Sub
        MyBase.OnLoad(e)
        ArrangeTopButtons()
        ArrangeBottomButtons()
    End Sub

#End Region

#Region "Private methods"
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        If PagedGrid Is Nothing Then Return
        ShowSearch = Not ShowSearch
        LoadData(Nothing)
    End Sub

    Protected Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        EditRecord()
    End Sub

    Protected Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        NewRecord()
    End Sub

    Protected Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        DoDelete()
    End Sub

    Sub ArrangeTopButtons()
        Dim ButtonTop As Integer = Panel1.Height + 4
        If Not cmdDelete Is Nothing Then ButtonTop = cmdDelete.Top
        ArrangeButtons(ButtonTop, "TopButtons")
    End Sub
    Sub ArrangeBottomButtons()
        Dim ButtonTop As Integer = Me.Height - 30
        If Not cmdClose Is Nothing Then ButtonTop = cmdClose.Top
        ArrangeButtons(ButtonTop, "BottomButtons")
    End Sub


#End Region



    Private Sub BasePagedListForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowSearch = ShowSearch
    End Sub

    Public Overrides Sub LoadSearchPanel() 'Implements ISearchable.LoadSearchPanel
        If IsDesignMode() Then
            Exit Sub
        End If
        If Not PagedGrid Is Nothing Then
            PagedGrid.LoadSearchPanel()
            PagedGrid.SetShowSearch(ShowSearch, False)
        End If
    End Sub
    Public Overrides Sub EnableSearchPanel()
        If Not PagedGrid Is Nothing AndAlso Not PagedGrid.SearchForm Is Nothing Then
            PagedGrid.Enabled = True
            CType(PagedGrid.SearchForm, Control).Enabled = True
        End If

    End Sub
    Public Overrides ReadOnly Property SearchForm() As ISearchForm
        Get
            If Not PagedGrid Is Nothing Then
                Return PagedGrid.SearchForm
            End If
            Return Nothing
        End Get
    End Property

End Class
