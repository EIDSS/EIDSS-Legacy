Imports System.ComponentModel
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports bv.winclient.BasePanel
Imports bv.common.Resources

Public Class BasePagedXtraListForm
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
    Friend WithEvents PagedXtraGrid1 As bv.common.win.PagedXtraGrid
    Friend WithEvents cmdSearch1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdNew1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdEdit1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdDelete1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdClose1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdRefresh1 As DevExpress.XtraEditors.SimpleButton
    '<System.Diagnostics.DebuggerStepThrough()> 
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BasePagedXtraListForm))
        Dim DefaultGridStyle1 As bv.common.win.DefaultGridStyle = New bv.common.win.DefaultGridStyle
        Me.cmdSearch1 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdNew1 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdEdit1 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdDelete1 = New DevExpress.XtraEditors.SimpleButton
        Me.PagedXtraGrid1 = New bv.common.win.PagedXtraGrid
        Me.cmdClose1 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdRefresh1 = New DevExpress.XtraEditors.SimpleButton
        CType(Me.PagedXtraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PagedXtraGrid1.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSearch1
        '
        Me.cmdSearch1.AccessibleDescription = Nothing
        Me.cmdSearch1.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdSearch1, "cmdSearch1")
        Me.cmdSearch1.BackgroundImage = Nothing
        Me.cmdSearch1.Image = Global.bv.common.win.My.Resources.Resources.Show_Hide_Search
        Me.cmdSearch1.Name = "cmdSearch1"
        '
        'cmdNew1
        '
        Me.cmdNew1.AccessibleDescription = Nothing
        Me.cmdNew1.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdNew1, "cmdNew1")
        Me.cmdNew1.BackgroundImage = Nothing
        Me.cmdNew1.Image = Global.bv.common.win.My.Resources.Resources.add
        Me.cmdNew1.Name = "cmdNew1"
        '
        'cmdEdit1
        '
        Me.cmdEdit1.AccessibleDescription = Nothing
        Me.cmdEdit1.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdEdit1, "cmdEdit1")
        Me.cmdEdit1.BackgroundImage = Nothing
        Me.cmdEdit1.Image = Global.bv.common.win.My.Resources.Resources.edit
        Me.cmdEdit1.Name = "cmdEdit1"
        '
        'cmdDelete1
        '
        Me.cmdDelete1.AccessibleDescription = Nothing
        Me.cmdDelete1.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdDelete1, "cmdDelete1")
        Me.cmdDelete1.BackgroundImage = Nothing
        Me.cmdDelete1.Image = Global.bv.common.win.My.Resources.Resources.Delete_Remove
        Me.cmdDelete1.Name = "cmdDelete1"
        '
        'PagedXtraGrid1
        '
        Me.PagedXtraGrid1.AccessibleDescription = Nothing
        Me.PagedXtraGrid1.AccessibleName = Nothing
        resources.ApplyResources(Me.PagedXtraGrid1, "PagedXtraGrid1")
        Me.PagedXtraGrid1.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.PagedXtraGrid1.Appearance.Options.UseFont = True
        Me.PagedXtraGrid1.BackgroundImage = Nothing
        Me.PagedXtraGrid1.CurrentPage = 1
        '
        '
        '
        Me.PagedXtraGrid1.Grid.AccessibleDescription = Nothing
        Me.PagedXtraGrid1.Grid.AccessibleName = Nothing
        Me.PagedXtraGrid1.Grid.Anchor = CType(resources.GetObject("PagedXtraGrid1.Grid.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PagedXtraGrid1.Grid.BackgroundImage = Nothing
        Me.PagedXtraGrid1.Grid.BackgroundImageLayout = CType(resources.GetObject("PagedXtraGrid1.Grid.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PagedXtraGrid1.Grid.DataMember = resources.GetString("PagedXtraGrid1.Grid.DataMember")
        Me.PagedXtraGrid1.Grid.Dock = CType(resources.GetObject("PagedXtraGrid1.Grid.Dock"), System.Windows.Forms.DockStyle)
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.AccessibleDescription = Nothing
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.AccessibleName = Nothing
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("PagedXtraGrid1.Grid.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.Anchor = CType(resources.GetObject("PagedXtraGrid1.Grid.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.BackgroundImage = Nothing
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("PagedXtraGrid1.Grid.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.ImeMode = CType(resources.GetObject("PagedXtraGrid1.Grid.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.TextLocation = CType(resources.GetObject("PagedXtraGrid1.Grid.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.ToolTip = resources.GetString("PagedXtraGrid1.Grid.EmbeddedNavigator.ToolTip")
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("PagedXtraGrid1.Grid.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.PagedXtraGrid1.Grid.EmbeddedNavigator.ToolTipTitle = resources.GetString("PagedXtraGrid1.Grid.EmbeddedNavigator.ToolTipTitle")
        Me.PagedXtraGrid1.Grid.Font = Nothing
        Me.PagedXtraGrid1.Grid.ImeMode = CType(resources.GetObject("PagedXtraGrid1.Grid.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PagedXtraGrid1.Grid.Location = CType(resources.GetObject("PagedXtraGrid1.Grid.Location"), System.Drawing.Point)
        Me.PagedXtraGrid1.Grid.MainView = Me.PagedXtraGrid1.MainView
        Me.PagedXtraGrid1.Grid.Name = "m_grid"
        Me.PagedXtraGrid1.Grid.RightToLeft = CType(resources.GetObject("PagedXtraGrid1.Grid.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PagedXtraGrid1.Grid.Size = CType(resources.GetObject("PagedXtraGrid1.Grid.Size"), System.Drawing.Size)
        Me.PagedXtraGrid1.Grid.TabIndex = CType(resources.GetObject("PagedXtraGrid1.Grid.TabIndex"), Integer)
        Me.PagedXtraGrid1.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.PagedXtraGrid1.MainView})
        Me.PagedXtraGrid1.GridStyle = DefaultGridStyle1
        Me.PagedXtraGrid1.Name = "PagedXtraGrid1"
        Me.PagedXtraGrid1.PageCount = 0
        Me.PagedXtraGrid1.PageSize = 50
        Me.PagedXtraGrid1.ReadOnly = True
        Me.PagedXtraGrid1.SearchControl = "bv.common.win.XtraSearchPanel"
        Me.PagedXtraGrid1.SearchPanelDocStyle = System.Windows.Forms.DockStyle.Top
        Me.PagedXtraGrid1.SearchParameters = Nothing
        Me.PagedXtraGrid1.SortCondition = Nothing
        Me.PagedXtraGrid1.StaticFilterCondition = Nothing
        '
        'cmdClose1
        '
        Me.cmdClose1.AccessibleDescription = Nothing
        Me.cmdClose1.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdClose1, "cmdClose1")
        Me.cmdClose1.BackgroundImage = Nothing
        Me.cmdClose1.Image = Global.bv.common.win.My.Resources.Resources.Close
        Me.cmdClose1.Name = "cmdClose1"
        '
        'cmdRefresh1
        '
        Me.cmdRefresh1.AccessibleDescription = Nothing
        Me.cmdRefresh1.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdRefresh1, "cmdRefresh1")
        Me.cmdRefresh1.BackgroundImage = Nothing
        Me.cmdRefresh1.Image = Global.bv.common.win.My.Resources.Resources.refresh
        Me.cmdRefresh1.Name = "cmdRefresh1"
        '
        'BasePagedXtraListForm
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.cmdRefresh1)
        Me.Controls.Add(Me.cmdClose1)
        Me.Controls.Add(Me.PagedXtraGrid1)
        Me.Controls.Add(Me.cmdSearch1)
        Me.Controls.Add(Me.cmdNew1)
        Me.Controls.Add(Me.cmdEdit1)
        Me.Controls.Add(Me.cmdDelete1)
        Me.Name = "BasePagedXtraListForm"
        Me.Sizable = True
        Me.Controls.SetChildIndex(Me.cmdDelete1, 0)
        Me.Controls.SetChildIndex(Me.cmdEdit1, 0)
        Me.Controls.SetChildIndex(Me.cmdNew1, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch1, 0)
        Me.Controls.SetChildIndex(Me.PagedXtraGrid1, 0)
        Me.Controls.SetChildIndex(Me.cmdClose1, 0)
        Me.Controls.SetChildIndex(Me.cmdRefresh1, 0)
        CType(Me.PagedXtraGrid1.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PagedXtraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "BaseFormList overrides methods"
    Public Overrides Function Activate() As System.Windows.Forms.Control
        If (Not m_DataLoaded) Then
            If TypeOf Me Is ISearchable Then
                CType(Me, ISearchable).LoadSearchPanel()
            End If
            LoadData(Nothing)
        End If
        BringToFront()
        Return Me
    End Function

    Protected Overrides Sub InitButtons()
        cmdSearch = cmdSearch1
        cmdSearch.Visible = Me.ShowSearchButton
        cmdEdit = cmdEdit1
        cmdEdit.Visible = Me.ShowEditButton
        cmdNew = cmdNew1
        cmdNew.Visible = Me.ShowNewButton
        cmdDelete = cmdDelete1
        cmdDelete.Visible = Me.ShowDeleteButton
        cmdClose = cmdClose1
        cmdRefresh = cmdRefresh1
        If (Me.State And BusinessObjectState.SelectObject) <> 0 Then
            cmdEdit.Text = BvMessages.Get("btnSelect", "Select")
            cmdEdit1.Image = Global.bv.common.win.My.Resources.Resources.Select2
            cmdEdit.Visible = True
            cmdDelete.Visible = False
            cmdNew.Visible = False
            'ShowSearchButton = True
            'ShowSearch = True
        Else
            cmdNew.Visible = cmdNew.Visible And Not BaseFormManager.ReadOnly
            cmdDelete.Visible = cmdDelete.Visible And Not BaseFormManager.ReadOnly
            If Not EditButtonText Is Nothing AndAlso Me.EditButtonText <> "" Then
                cmdEdit1.Text = EditButtonText
            End If
        End If
        If Not PermissionObject Is Nothing Then
            If Me.Permissions.CanInsert = False Then
                cmdNew.Enabled = False
            End If
            If Me.Permissions.CanDelete = False Then
                cmdDelete.Enabled = False
            End If
            If Me.Permissions.CanUpdate = False AndAlso (Me.State And BusinessObjectState.SelectObject) = 0 Then
                cmdEdit.Text = BvMessages.Get("btnView", "View")
                cmdEdit1.Image = Global.bv.common.win.My.Resources.Resources.View1
            End If
            cmdNew.Visible = cmdNew.Visible AndAlso Permissions.GetButtonVisibility(DefaultButtonType.[New])
            cmdDelete.Visible = cmdDelete.Visible AndAlso Permissions.GetButtonVisibility(DefaultButtonType.Delete)
            cmdEdit.Visible = cmdEdit.Visible AndAlso Permissions.GetButtonVisibility(DefaultButtonType.Edit)
        End If

        If cmdEdit.Visible And cmdEdit.Enabled Then
            cmdEdit.Select()
        ElseIf cmdNew.Visible AndAlso cmdNew.Enabled Then
            cmdNew.Select()
        ElseIf cmdSearch.Visible AndAlso cmdSearch.Enabled Then
            cmdSearch.Select()
        ElseIf cmdDelete.Visible AndAlso cmdDelete.Enabled Then
            cmdDelete.Select()
        Else
            Me.Select()
        End If

    End Sub

    Public Overrides Function GetSelectedRows() As DataRow()
        If Me.PagedXtraGrid1 Is Nothing OrElse Me.PagedXtraGrid1.Grid Is Nothing OrElse Me.PagedXtraGrid1.Grid.MainView Is Nothing Then Return Nothing
        Dim gv As GridView = CType(Me.PagedXtraGrid1.Grid.MainView, GridView)
        If gv Is Nothing Then Return Nothing
        If gv.GetSelectedRows() Is Nothing Then Return Nothing
        Dim selRowsInxexes As Integer() = gv.GetSelectedRows()
        If selRowsInxexes Is Nothing Then Return Nothing
        ' creating an empty list
        Dim Rows(selRowsInxexes.Length - 1) As DataRow
        ' adding selected rows to the list
        Dim I As Integer
        Dim k As Integer = 0
        For I = 0 To selRowsInxexes.Length - 1
            If (selRowsInxexes(I) >= 0) Then
                Rows(k) = (gv.GetDataRow(selRowsInxexes(I)))
                k += 1
            End If
        Next
        If k = 0 Then Return Nothing
        Return Rows
    End Function
    Public Overrides Function GetDataset() As DataSet
        If PagedGrid Is Nothing Then Return Nothing
        'Dim AdditionalFilter As String = ""
        'If BaseSettings.ShowEmptyListOnSearch _
        '    AndAlso (State And BusinessObjectState.SelectObject) = 0 _
        '    AndAlso Me.ShowSearch = True _
        '    AndAlso Utils.IsEmpty(PagedGrid.FilterCondition) _
        '    AndAlso Utils.IsEmpty(PagedGrid.FromCondition) Then

        '    AdditionalFilter = "0 = 1" 'Me.KeyFieldName + " IS NULL "
        'End If
        Dim RecordCount As Integer = 0
        Dim ds As DataSet = Nothing
        If Not DbService Is Nothing Then
            If PagedGrid.SortCondition Is Nothing Then
                PagedGrid.SortCondition = PagedGrid.DefaultSortCondition
            End If
            ds = DbService.GetPagedList(PagedGrid.PageSize, PagedGrid.CurrentPage - 1, PagedGrid.FilterCondition, PagedGrid.FromCondition, PagedGrid.SortCondition, RecordCount) '+ AdditionalFilter
        Else
            Dim params() As Object
            params = New Object() { _
                                    PagedGrid.PageSize, PagedGrid.CurrentPage - 1, PagedGrid.FilterCondition, PagedGrid.FromCondition, PagedGrid.SortCondition, RecordCount}
            Dim o As Object = ClassLoader.LoadClass(ObjectName + "_DB")
            Dim typeArray(5) As Type

            Dim m_listMethod As Reflection.MethodInfo = o.GetType().GetMethod("GetPagedList")
            o = m_listMethod.Invoke(o, params)
            If Not o Is Nothing Then
                ds = CType(o, DataSet)
                RecordCount = CInt(params(5))
            End If

        End If
        If RecordCount < PagedGrid.PageSize Then
            If PagedGrid.CurrentPage > 1 Then
                PagedGrid.CurrentPage = 1
                Return GetDataset()
            End If
            PagedGrid.PageCount = 0
        Else
            PagedGrid.PageCount = (RecordCount + PagedGrid.PageSize - 1) \ PagedGrid.PageSize
        End If
        Return ds
    End Function



#End Region

#Region "Public properies"
    Public Overrides Property MultiSelect() As Boolean
        Get
            Return MyBase.MultiSelect
        End Get
        Set(ByVal Value As Boolean)
            MyBase.MultiSelect = Value
            CType(PagedXtraGrid1.Grid.MainView, GridView).OptionsSelection.MultiSelect = m_MultiSelect
        End Set
    End Property

    Public Overrides ReadOnly Property Grid() As Object
        Get
            If PagedXtraGrid1 Is Nothing Then Return Nothing
            Return PagedXtraGrid1.DataGrid
        End Get
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Localizable(True)> _
    Public ReadOnly Property Columns() As GridColumnCollection
        Get
            If PagedXtraGrid1 Is Nothing Then Return Nothing
            Return PagedXtraGrid1.Columns
        End Get
    End Property

    Private m_ContextMenu As ContextMenu
    Public Property GridContextMenu() As ContextMenu
        Get
            Return m_ContextMenu
        End Get
        Set(ByVal Value As ContextMenu)
            m_ContextMenu = Value
            PagedXtraGrid1.DataGrid.ContextMenu = ContextMenu
        End Set
    End Property

    Public ReadOnly Property DataGrid() As PagedXtraGrid
        Get
            Return Me.PagedXtraGrid1
        End Get

    End Property

#End Region

#Region "Public methods"


#End Region

#Region "Protected methods"
    Public Overrides ReadOnly Property PagedGrid() As BasePagedDataGrid
        Get
            Return Me.PagedXtraGrid1
        End Get
    End Property
    'Private m_Repository As DevExpress.XtraEditors.Repository.PersistentRepository = New DevExpress.XtraEditors.Repository.PersistentRepository
    '<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    'Public Property ExternalRepository() As DevExpress.XtraEditors.Repository.PersistentRepository
    '    Get
    '        Return m_Repository
    '    End Get
    '    Set(ByVal Value As DevExpress.XtraEditors.Repository.PersistentRepository)
    '        'Me.Grid.ExternalRepository = Value
    '        If Not Value Is Nothing Then
    '            For i As Integer = 0 To Value.Items.Count
    '                Dim item As New DevExpress.XtraEditors.Repository.RepositoryItem

    '                m_Repository.Items.Add(Value.Items(i))
    '            Next
    '        End If
    '        'PagedXtraGrid1.Grid.ExternalRepository = m_Repository
    '    End Set
    'End Property
    '<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    'Public Property ExternalRepository() As DevExpress.XtraEditors.Repository.PersistentRepository
    '    Get
    '        Return Nothing 'PagedXtraGrid1.ExternalRepository
    '    End Get
    '    Set(ByVal Value As DevExpress.XtraEditors.Repository.PersistentRepository)
    '        PagedXtraGrid1.ExternalRepository = Value
    '    End Set
    'End Property
    '<DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Localizable(True)> _
    'Public ReadOnly Property RepositoryItems() As DevExpress.XtraEditors.Repository.RepositoryItemCollection
    '    Get
    '        If PagedXtraGrid1 Is Nothing Then Return Nothing
    '        Return PagedXtraGrid1.RepositoryItems
    '    End Get
    'End Property

#End Region

#Region "Private methods"


#End Region

    Protected Overrides Sub ResizeForm()
        If Not Visible Then Return
        If Me.DesignMode Then
            Me.PagedXtraGrid1.Width = Me.Width
            Me.PagedXtraGrid1.Height = Me.Height - Me.PagedXtraGrid1.Top - cmdClose1.Height - 16
        End If
        ArrangeButtons(Me.Height - cmdClose1.Height - 8, "BottomButtons", cmdClose1.Height)
        ArrangeButtons(cmdDelete1.Top, "BottomButtons", cmdDelete1.Height)

    End Sub
    Private Sub BasePagedXtraListForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ResizeForm()
    End Sub

    Protected Overrides Sub DefineBinding()
        MyBase.DefineBinding()
        Dim xgcGrid As DevExpress.XtraGrid.GridControl
        Dim xgvView As DevExpress.XtraGrid.Views.Grid.GridView

        xgcGrid = CType(Me.Grid, DevExpress.XtraGrid.GridControl)
        xgvView = CType(xgcGrid.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
        xgvView.OptionsCustomization.BeginUpdate()
        xgvView.OptionsCustomization.AllowColumnMoving = False
        xgvView.OptionsCustomization.AllowColumnResizing = True
        xgvView.OptionsCustomization.AllowFilter = False
        xgvView.OptionsCustomization.AllowGroup = False
        xgvView.OptionsCustomization.AllowRowSizing = False
        xgvView.OptionsCustomization.AllowSort = True
        xgvView.OptionsCustomization.EndUpdate()

        'For i As Integer = 0 To CType(CType(Grid, DevExpress.XtraGrid.GridControl).MainView, DevExpress.XtraGrid.Views.Grid.GridView).Columns.Count - 1
        '    CType(CType(Grid, DevExpress.XtraGrid.GridControl).MainView, DevExpress.XtraGrid.Views.Grid.GridView).Columns(i).VisibleIndex = i
        'Next

    End Sub

    Protected ReadOnly Property MainView() As DevExpress.XtraGrid.Views.Grid.GridView
        Get
            Return (Me.PagedXtraGrid1.MainGridView)
        End Get
    End Property

    Private Sub BasePagedXtraListForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim firstCol As DevExpress.XtraGrid.Columns.GridColumn
        firstCol = GetFirstVisibleAndSortableColumn()
        If Not firstCol Is Nothing Then
            PagedXtraGrid1.m_Sorting = True
            firstCol.SortIndex = 0
            If Not Utils.IsEmpty(firstCol.FieldName) Then
                PagedXtraGrid1.SortCondition = String.Format("fn_{0}_SelectList.", Me.ObjectName) + firstCol.FieldName
                If firstCol.SortOrder = DevExpress.Data.ColumnSortOrder.Descending Then
                    PagedXtraGrid1.SortCondition += " DESC"
                End If
            Else
                PagedXtraGrid1.SortCondition = Nothing
            End If
            PagedXtraGrid1.m_Sorting = False
            MainView.FocusedRowHandle = 0
        End If
    End Sub

    Protected Overrides Function IsRowClicked(ByVal x As Integer, ByVal y As Integer) As Boolean
        If Not Grid Is Nothing Then
            Dim chi As New GridHitInfo()
            chi = MainView.CalcHitInfo(New System.Drawing.Point(x, y))
            Return chi.InRow
        End If
        Return False
    End Function

    Public Function GetFirstVisibleAndSortableColumn() As DevExpress.XtraGrid.Columns.GridColumn
        Dim firstCol As GridColumn = Nothing
        Dim minVisibleIndex As Integer = 0
        If Not DefaultSortColumn Is Nothing AndAlso DefaultSortColumn.VisibleIndex >= 0 Then
            Return DefaultSortColumn
        End If
        For i As Integer = 0 To Columns.Count - 1
            If (firstCol Is Nothing AndAlso (Columns(i).VisibleIndex < 0 OrElse Columns(i).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False)) Then
                Continue For
            End If
            If (firstCol Is Nothing OrElse _
                 (Columns(i).VisibleIndex < firstCol.VisibleIndex AndAlso Columns(i).VisibleIndex >= 0)) _
                    AndAlso Columns(i).OptionsColumn.AllowSort <> DevExpress.Utils.DefaultBoolean.False _
                 Then
                firstCol = Columns(i)
            End If
        Next
        Return firstCol
    End Function
    'Protected Sub cmdRefresh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh1.Click
    '    If LockHandler() Then
    '        Try
    '            'PagedGrid.CurrentPage = 0
    '            LoadData()
    '        Finally
    '            UnlockHandler()
    '        End Try
    '    End If
    'End Sub
    Public Overrides Sub BaseForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Me.ActiveControl Is Me.PagedXtraGrid1 AndAlso PagedXtraGrid1.ActiveControl Is PagedXtraGrid1.Grid AndAlso Me.MainView.FocusedRowHandle >= 0 Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                e.SuppressKeyPress = True
                MyBase.EditRecord()
                Return
            End If
        End If
        MyBase.BaseForm_KeyDown(sender, e)
    End Sub

    Private m_DefaultSortColumn As GridColumn

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Property DefaultSortColumn() As GridColumn
        Get
            Return m_DefaultSortColumn
        End Get
        Set(ByVal Value As GridColumn)
            m_DefaultSortColumn = Value
        End Set
    End Property
    Protected Overrides Sub TableAdded(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
        If DesignMode Then Exit Sub
        If e.Action = CollectionChangeAction.Add Then
            MainView.Columns.Clear()
            For i As Integer = Columns.Count - 1 To 0 Step -1
                MainView.Columns.Add(Columns(i))
            Next
        End If
        MyBase.TableAdded(sender, e)
    End Sub
End Class
