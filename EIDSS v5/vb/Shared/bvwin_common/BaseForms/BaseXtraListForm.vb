Imports System.ComponentModel
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports bv.winclient.BasePanel
Imports bv.common.Resources
Public Class BaseXtraListForm
    Inherits common.win.BaseListForm
    'Implements ISearchable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_Columns = New GridColumnCollection(MainView)
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdRefresh1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdClose1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSearch1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdNew1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdEdit1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdDelete1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Protected Friend WithEvents XtraGrid As DevExpress.XtraGrid.GridControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseXtraListForm))
        Me.cmdRefresh1 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdClose1 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdSearch1 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdNew1 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdEdit1 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdDelete1 = New DevExpress.XtraEditors.SimpleButton
        Me.XtraGrid = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        CType(Me.XtraGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdRefresh1
        '
        resources.ApplyResources(Me.cmdRefresh1, "cmdRefresh1")
        Me.cmdRefresh1.Image = Global.bv.common.win.My.Resources.Resources.refresh
        Me.cmdRefresh1.Name = "cmdRefresh1"
        '
        'cmdClose1
        '
        resources.ApplyResources(Me.cmdClose1, "cmdClose1")
        Me.cmdClose1.Image = Global.bv.common.win.My.Resources.Resources.Close
        Me.cmdClose1.Name = "cmdClose1"
        '
        'cmdSearch1
        '
        resources.ApplyResources(Me.cmdSearch1, "cmdSearch1")
        Me.cmdSearch1.Image = Global.bv.common.win.My.Resources.Resources.Show_Hide_Search
        Me.cmdSearch1.Name = "cmdSearch1"
        '
        'cmdNew1
        '
        resources.ApplyResources(Me.cmdNew1, "cmdNew1")
        Me.cmdNew1.Image = Global.bv.common.win.My.Resources.Resources.add
        Me.cmdNew1.Name = "cmdNew1"
        '
        'cmdEdit1
        '
        resources.ApplyResources(Me.cmdEdit1, "cmdEdit1")
        Me.cmdEdit1.Image = Global.bv.common.win.My.Resources.Resources.edit
        Me.cmdEdit1.Name = "cmdEdit1"
        '
        'cmdDelete1
        '
        resources.ApplyResources(Me.cmdDelete1, "cmdDelete1")
        Me.cmdDelete1.Image = Global.bv.common.win.My.Resources.Resources.Delete_Remove
        Me.cmdDelete1.Name = "cmdDelete1"
        '
        'XtraGrid
        '
        resources.ApplyResources(Me.XtraGrid, "XtraGrid")
        Me.XtraGrid.MainView = Me.GridView1
        Me.XtraGrid.Name = "XtraGrid"
        Me.XtraGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.XtraGrid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowGroupedColumns = True
        '
        'BaseXtraListForm
        '
        Me.Controls.Add(Me.XtraGrid)
        Me.Controls.Add(Me.cmdRefresh1)
        Me.Controls.Add(Me.cmdClose1)
        Me.Controls.Add(Me.cmdSearch1)
        Me.Controls.Add(Me.cmdNew1)
        Me.Controls.Add(Me.cmdEdit1)
        Me.Controls.Add(Me.cmdDelete1)
        Me.Name = "BaseXtraListForm"
        Me.Controls.SetChildIndex(Me.cmdDelete1, 0)
        Me.Controls.SetChildIndex(Me.cmdEdit1, 0)
        Me.Controls.SetChildIndex(Me.cmdNew1, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch1, 0)
        Me.Controls.SetChildIndex(Me.cmdClose1, 0)
        Me.Controls.SetChildIndex(Me.cmdRefresh1, 0)
        Me.Controls.SetChildIndex(Me.XtraGrid, 0)
        CType(Me.XtraGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "BaseFormList overrides methods"
    Protected Overrides Sub InitButtons()
        cmdSearch1.Visible = Me.ShowSearchButton
        cmdEdit1.Visible = Me.ShowEditButton
        cmdNew1.Visible = Me.ShowNewButton
        cmdDelete1.Visible = Me.ShowDeleteButton
        cmdClose = cmdClose1
        cmdRefresh = cmdRefresh1
        If (Me.State And BusinessObjectState.SelectObject) <> 0 Then
            cmdEdit1.Text = BvMessages.Get("btnSelect", "Select")
            cmdEdit1.Image = Global.bv.common.win.My.Resources.Resources.Select2
            cmdEdit1.Visible = True
            cmdDelete1.Visible = False
            cmdNew1.Visible = False
        Else
            cmdNew1.Visible = cmdNew1.Visible And Not BaseFormManager.ReadOnly
            cmdDelete1.Visible = cmdDelete1.Visible And Not BaseFormManager.ReadOnly
            If Not EditButtonText Is Nothing AndAlso Me.EditButtonText <> "" Then
                cmdEdit1.Text = EditButtonText
            End If
        End If
        If Not PermissionObject Is Nothing Then
            If Me.Permissions.CanInsert = False Then
                cmdNew1.Enabled = False
            End If
            If Me.Permissions.CanDelete = False Then
                cmdDelete1.Enabled = False
            End If
            If Me.Permissions.CanUpdate = False AndAlso (Me.State And BusinessObjectState.SelectObject) = 0 Then
                cmdEdit1.Text = BvMessages.Get("btnView", "View")
                cmdEdit1.Image = Global.bv.common.win.My.Resources.Resources.View1
            End If
            cmdNew1.Visible = cmdNew1.Visible AndAlso Permissions.GetButtonVisibility(DefaultButtonType.[New])
            cmdDelete1.Visible = cmdDelete1.Visible AndAlso Permissions.GetButtonVisibility(DefaultButtonType.Delete)
            cmdEdit1.Visible = cmdEdit1.Visible AndAlso Permissions.GetButtonVisibility(DefaultButtonType.Edit)
        End If
        If cmdEdit1.Visible AndAlso cmdEdit1.Enabled Then
            cmdEdit1.Select()
        ElseIf cmdNew1.Visible AndAlso cmdNew1.Enabled Then
            cmdNew1.Select()
        ElseIf cmdSearch1.Visible AndAlso cmdSearch1.Enabled Then
            cmdSearch1.Select()
        ElseIf cmdDelete1.Visible AndAlso cmdDelete1.Enabled Then
            cmdDelete1.Select()
        Else
            Me.Select()
        End If

    End Sub


    Public Overrides Function GetSelectedRows() As DataRow()
        Dim selRowsInxexes As Integer() = MainView.GetSelectedRows()
        If selRowsInxexes Is Nothing Then Return Nothing
        ' creating an empty list
        Dim Rows(selRowsInxexes.Length - 1) As DataRow
        ' adding selected rows to the list
        Dim I As Integer
        Dim k As Integer = 0
        For I = 0 To selRowsInxexes.Length - 1
            If (selRowsInxexes(I) >= 0) Then
                Rows(k) = (MainView.GetDataRow(selRowsInxexes(I)))
                k += 1
            End If
        Next
        If k = 0 Then Return Nothing
        Return Rows
    End Function
    Public Overrides Function GetDataset() As DataSet
        If Not DbService Is Nothing Then
            Return DbService.GetList()
        End If
        Return Nothing
    End Function
#Region "Public properies"

    <Browsable(False)> _
    Public Overrides ReadOnly Property Grid() As Object
        Get
            If XtraGrid Is Nothing Then Return Nothing
            Return XtraGrid
        End Get
    End Property

    Dim m_EnableEditButton As Boolean = True
    <DefaultValue(True)> _
    Public Property EnableEditButton() As Boolean
        Get
            Return m_EnableEditButton
        End Get
        Set(ByVal Value As Boolean)
            m_EnableEditButton = Value
            cmdEdit1.Enabled = Value
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
            cmdEdit1.Visible = Value
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
            cmdDelete1.Visible = Value
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
            cmdSearch1.Visible = Value
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
            cmdNew1.Visible = Value
        End Set
    End Property
    '<Browsable(False)> _
    'Public ReadOnly Property SearchForm() As ISearchForm
    '    Get
    '        If m_SearchControl Is Nothing Then Return Nothing
    '        Return CType(m_SearchControl, ISearchForm)
    '    End Get
    'End Property
    'Dim m_SearchControl As Control
    'Dim m_SearchControlName As String = "bv.common.win.XtraSearchPanel"
    '<Browsable(True), DefaultValue("bv.common.win.XtraSearchPanel")> _
    'Public Property SearchControl() As String
    '    Get

    '        If Not m_SearchControl Is Nothing Then
    '            Return m_SearchControl.GetType.FullName
    '        Else
    '            Return m_SearchControlName
    '        End If
    '    End Get
    '    Set(ByVal Value As String)
    '        If Not Value Is Nothing AndAlso Not m_SearchControl Is Nothing AndAlso SearchControl = Value Then
    '            Exit Property
    '        End If
    '        m_SearchControlName = Value
    '        If Value Is Nothing OrElse Value.Trim = "" Then
    '            Exit Property
    '        End If
    '        If Value.IndexOf(".") < 0 Then Value = "bv.common.win." + Value
    '        If m_SearchControlName <> Value Then
    '            m_SearchControlName = Value
    '        End If
    '    End Set
    'End Property

    'Dim m_SearchPanelDocStyle As DockStyle
    'Public Property SearchPanelDocStyle() As DockStyle
    '    Get
    '        Return m_SearchPanelDocStyle
    '    End Get
    '    Set(ByVal Value As DockStyle)
    '        If (Value = DockStyle.Left) OrElse (Value = DockStyle.Top) Then
    '            m_SearchPanelDocStyle = Value
    '        Else
    '            m_SearchPanelDocStyle = DockStyle.Top
    '        End If
    '    End Set
    'End Property
    'Private m_ShowSearch As Boolean
    'Public Property ShowSearch() As Boolean
    '    Get
    '        If m_SearchControl Is Nothing Then Return False
    '        Return m_ShowSearch
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        If DesignMode Then Return
    '        If m_SearchControl Is Nothing Then Return
    '        If m_ShowSearch = Value Then Return
    '        m_ShowSearch = Value
    '        Dim cond As String = Nothing
    '        If m_SearchPanelDocStyle = DockStyle.Left Then
    '            Dim w As Integer = m_SearchControl.Width
    '            If Value Then
    '                GridControl.Left += w
    '                GridControl.Width -= w
    '                cond = SearchForm.FilterCondition
    '            Else
    '                GridControl.Left -= m_SearchControl.Width
    '                GridControl.Width += m_SearchControl.Width
    '            End If
    '        Else
    '            Dim h As Integer = m_SearchControl.Height
    '            If Value Then
    '                GridControl.Top += h
    '                GridControl.Height -= h
    '            Else
    '                GridControl.Top -= m_SearchControl.Height
    '                GridControl.Height += h
    '            End If
    '        End If
    '        If Value Then
    '            DbService.ListFilterCondition = SearchForm.FilterCondition
    '        Else
    '            DbService.ListFilterCondition = Nothing
    '        End If
    '        m_SearchControl.Visible = Value
    '    End Set
    'End Property

    <Browsable(True), DefaultValue(True)> _
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            m_Readonly = Value
        End Set
    End Property

    Public Overrides ReadOnly Property GridControl() As Control
        Get
            Return XtraGrid
        End Get
    End Property

    Public Overridable ReadOnly Property MainView() As GridView
        Get
            Return CType(XtraGrid.MainView, GridView)
        End Get
    End Property
    Public Overrides Property MultiSelect() As Boolean
        Get
            Return MyBase.MultiSelect
        End Get
        Set(ByVal Value As Boolean)
            MyBase.MultiSelect = Value
            MainView.OptionsSelection.MultiSelect = m_MultiSelect
        End Set
    End Property


    Private m_Columns As GridColumnCollection
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public ReadOnly Property Columns() As GridColumnCollection
        Get
            Return m_Columns
        End Get
    End Property

    Private m_ContextMenu As ContextMenu
    Public Property GridContextMenu() As ContextMenu
        Get
            Return m_ContextMenu
        End Get
        Set(ByVal Value As ContextMenu)
            m_ContextMenu = Value
            XtraGrid.ContextMenu = ContextMenu
        End Set
    End Property

    <Browsable(True), DefaultValue(True)> _
    Public Property ShowGroupPanel() As Boolean
        Get
            Return Me.MainView.OptionsView.ShowGroupPanel
        End Get
        Set(ByVal value As Boolean)
            Me.MainView.OptionsView.ShowGroupPanel = value
        End Set
    End Property

#End Region

#Region "Protected methods"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        If DesignMode Then Exit Sub
        MyBase.OnLoad(e)
        ArrangeTopButtons()
        ArrangeBottomButtons()
    End Sub

#End Region
#Region "Private methods"
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch1.Click
        ShowSearch = Not ShowSearch
        LoadData(Nothing)
    End Sub

    Protected Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit1.Click
        EditRecord()
    End Sub

    Protected Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew1.Click
        NewRecord()
    End Sub

    Protected Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete1.Click
        DoDelete()
    End Sub

    Sub ArrangeTopButtons()
        Dim ButtonTop As Integer = Panel1.Height + 4
        ButtonTop = cmdDelete1.Top
        ArrangeButtons(ButtonTop, "TopButtons")
    End Sub
    Sub ArrangeBottomButtons()
        Dim ButtonTop As Integer = Me.Height - 30
        ButtonTop = cmdClose1.Top
        ArrangeButtons(ButtonTop, "BottomButtons")
    End Sub

    'Dim m_SearchOriginalHeight As Integer
    'Dim m_SearchOriginalWidth As Integer
    'Public Sub LoadSearchPanel() Implements ISearchable.LoadSearchPanel
    '    If IsDesignMode() Then
    '        Exit Sub
    '    End If
    '    If Not m_SearchControl Is Nothing AndAlso m_SearchControl.GetType().FullName <> Me.m_SearchControlName Then
    '        m_SearchControl.Dispose()
    '        m_SearchControl = Nothing
    '        'Dim ctl As Object = CType(hdl, ObjectHandle).Unwrap()
    '    End If
    '    'Dim ctl As Object = ClassLoader.LoadClass(Value)
    '    If m_SearchControl Is Nothing AndAlso Utils.Str(m_SearchControlName) <> "" Then
    '        Dim ctl As Object
    '        Try
    '            ctl = ClassLoader.LoadClass(m_SearchControlName)
    '        Catch ex As Exception
    '            MessageForm.Show("Type is not defined:" + vbCrLf + ex.Message)
    '            Exit Sub
    '        End Try
    '        If TypeOf (ctl) Is ISearchForm Then
    '        Else
    '            MessageForm.Show("Only class that implements ISearchForm interface can be used here")
    '            Exit Sub
    '        End If
    '        m_SearchControl = CType(ctl, Control)
    '        m_SearchOriginalHeight = m_SearchControl.Height
    '        m_SearchOriginalWidth = GridControl.Width
    '        m_SearchControl.Left = GridControl.Left
    '        m_SearchControl.Top = GridControl.Top
    '    End If
    '    If Not m_SearchControl Is Nothing Then
    '        m_SearchControl.Visible = False
    '        If m_SearchPanelDocStyle = DockStyle.Left Then
    '            m_SearchControl.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Bottom
    '            m_SearchControl.Height = GridControl.Height
    '            m_SearchControl.Width = m_SearchOriginalWidth
    '        Else
    '            m_SearchControl.Height = m_SearchOriginalHeight
    '            m_SearchControl.Width = GridControl.Width
    '            m_SearchControl.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
    '        End If
    '        m_SearchControl.Parent = Me
    '        AddHandler SearchForm.Search, AddressOf spanel_Search
    '        SearchForm.Init(GridControl)
    '    Else
    '        cmdSearch1.Visible = False
    '    End If

    'End Sub

    'Protected Sub spanel_Search(ByVal FilterCondition As String, ByVal FromCondition As String)
    '    If Not DbService Is Nothing Then
    '        DbService.ListFilterCondition = FilterCondition
    '        DbService.ListFromCondition = FromCondition
    '        LoadData()
    '    End If
    'End Sub

#End Region
    Protected Overrides Sub ResizeForm()
        If Not Visible Then Return
        'If Me.DesignMode Then
        XtraGrid.Width = Me.Width - 16
        XtraGrid.Height = Me.Height - XtraGrid.Top - cmdClose1.Height - 16
        'End If
        cmdRefresh1.Top = Me.Height - cmdClose1.Height - 8
        cmdClose1.Top = Me.Height - cmdClose1.Height - 8
        ArrangeButtons(Me.Height - cmdClose1.Height - 8, "BottomButtons", cmdClose1.Height)
        ArrangeButtons(cmdDelete1.Top, "TopButtons", cmdDelete1.Height)

    End Sub

    Private Sub ResizeMe(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ResizeForm()
    End Sub


    Private Sub BasePagedListForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm()
        ShowSearch = m_ShowSearch
    End Sub

    Public Overrides Function GetBindingManager(Optional ByVal aTableName As String = Nothing) As BindingManagerBase
        If XtraGrid.DataSource Is Nothing Then Return Nothing
        Return BindingContext(XtraGrid.DataSource)
    End Function

    Protected Overrides Sub TableAdded(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
        If DesignMode Then Exit Sub
        If e.Action = CollectionChangeAction.Add Then
            MainView.Columns.Clear()
            For i As Integer = m_Columns.Count - 1 To 0 Step -1
                MainView.Columns.Add(Columns(i))
            Next
            XtraGrid.DataSource = CType(e.Element, DataTable)
        End If
    End Sub

    Public Overrides Function LocateRow(ByVal key As Object) As Boolean
        Dim dv As DataView = CType(MainView.DataSource, DataView)
        'Dim row As DataRow = bv.common.db.BaseDbService.FindRow(dv.Table, key)
        If (dv Is Nothing) OrElse (dv.Table.PrimaryKey Is Nothing) OrElse (dv.Table.PrimaryKey.Length <> 1) Then
            Return False
        End If
        Dim keyName As String = dv.Table.PrimaryKey(0).ColumnName
        Dim i As Integer
        For i = 0 To dv.Count - 1
            If dv(i).Row.RowState <> DataRowState.Detached AndAlso dv(i).Row.RowState <> DataRowState.Deleted AndAlso dv(i)(keyName).Equals(key) Then
                MainView.FocusedRowHandle = i
                Return True
            End If
        Next
    End Function
    Protected Overrides Function IsRowClicked(ByVal x As Integer, ByVal y As Integer) As Boolean
        If Not Grid Is Nothing Then
            Dim chi As New GridHitInfo()
            chi = MainView.CalcHitInfo(New System.Drawing.Point(x, y))
            Return chi.InRow
        End If
        Return False
    End Function
#End Region
    Public Overrides Sub BaseForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Me.ActiveControl Is Me.GridControl AndAlso Me.MainView.FocusedRowHandle >= 0 Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                MyBase.EditRecord()
                Return
            End If
        End If
        MyBase.BaseForm_KeyDown(sender, e)
    End Sub

End Class
