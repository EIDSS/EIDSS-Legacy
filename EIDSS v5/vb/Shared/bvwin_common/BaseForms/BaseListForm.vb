Imports System.Drawing
Imports System.ComponentModel
Imports bv.winclient.BasePanel
Imports bv.common.db
Imports bv.winclient.Core
Imports bv.common.Resources

Public Class BaseListForm
    Inherits BaseForm
    Implements ISearchable


#Region " Windows Form Designer generated code "
    Friend WithEvents cmdClose As Control
    Friend WithEvents Panel1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lbFormID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCaption As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureBox1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents cmdRefresh As Control
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.FormType = BaseFormType.List
        PictureBox1.Properties.ShowMenu = False
        PictureBox1.Properties.AllowFocused = False
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

    'NOTE The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseListForm))
        Me.Panel1 = New DevExpress.XtraEditors.PanelControl
        Me.PictureBox1 = New DevExpress.XtraEditors.PictureEdit
        Me.lbFormID = New DevExpress.XtraEditors.LabelControl
        Me.lbCaption = New DevExpress.XtraEditors.LabelControl
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Panel1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.Panel1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panel1.Appearance.Options.UseBackColor = True
        Me.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lbFormID)
        Me.Panel1.Controls.Add(Me.lbCaption)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.Panel1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Panel1.Name = "Panel1"
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureBox1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'lbFormID
        '
        Me.lbFormID.AllowHtmlString = True
        resources.ApplyResources(Me.lbFormID, "lbFormID")
        Me.lbFormID.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbFormID.Appearance.ForeColor = System.Drawing.Color.White
        Me.lbFormID.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.lbFormID.Appearance.Options.UseFont = True
        Me.lbFormID.Appearance.Options.UseForeColor = True
        Me.lbFormID.Appearance.Options.UseTextOptions = True
        Me.lbFormID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lbFormID.Name = "lbFormID"
        Me.lbFormID.Tag = "FixFontSize"
        '
        'lbCaption
        '
        Me.lbCaption.AllowHtmlString = True
        resources.ApplyResources(Me.lbCaption, "lbCaption")
        Me.lbCaption.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbCaption.Appearance.ForeColor = System.Drawing.Color.White
        Me.lbCaption.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.lbCaption.Appearance.Options.UseFont = True
        Me.lbCaption.Appearance.Options.UseForeColor = True
        Me.lbCaption.Name = "lbCaption"
        Me.lbCaption.Tag = "FixFontSize"
        '
        'BaseListForm
        '
        Me.Controls.Add(Me.Panel1)
        resources.ApplyResources(Me, "$this")
        Me.Name = "BaseListForm"
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "BaseForm overrides"
    Dim FillDsFlag As Boolean = False
    Public Overrides Function FillDataset(Optional ByVal ID As Object = Nothing) As Boolean
        If FillDsFlag Then Return True
        If Grid Is Nothing Then
            Throw New Exception("Grid is not defined")
        End If
        FillDsFlag = True
        Dim DataRefreshed As Boolean = False
        CType(Grid, Control).SuspendLayout()

        Try
            If baseDataSet.Tables.Contains(ObjectName) Then
                baseDataSet.Tables(ObjectName).BeginLoadData()
                DataRefreshed = True
            End If
            Dim OldKey As Object = GetKey()
            baseDataSet.Clear()
            Dim ds As DataSet = GetDataset()
            If ds Is Nothing Then Return False
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
        Catch ex As Exception
            ErrorForm.ShowError(StandardError.FillDatasetError, ex)
            Return False
        Finally
            If DataRefreshed Then
                baseDataSet.Tables(ObjectName).EndLoadData()
            End If
            CType(Grid, Control).ResumeLayout()
            FillDsFlag = False
        End Try
        Return True
    End Function
    Protected Overridable Sub InitButtons()
    End Sub

    Protected Overrides Sub DefineBinding()
        If DesignMode = True Then Exit Sub
        If Not Grid Is Nothing Then
            RemoveHandler CType(Grid, Control).DoubleClick, AddressOf DataGrid1_DoubleClick
            RemoveHandler CType(Grid, Control).MouseUp, AddressOf DataGrid1_MouseUp
            AddHandler CType(Grid, Control).DoubleClick, AddressOf DataGrid1_DoubleClick
            AddHandler CType(Grid, Control).MouseUp, AddressOf DataGrid1_MouseUp
        End If
        AddHandler baseDataSet.Tables.CollectionChanged, AddressOf TableAdded
        TableAdded(Nothing, New CollectionChangeEventArgs(CollectionChangeAction.Add, baseDataSet.Tables(ObjectName)))
        InitButtons()
        If Not SearchForm Is Nothing AndAlso CType(SearchForm, Object).GetType().Name = "XtraSearchPanel" Then
            SearchForm.Init(Grid)
        End If
    End Sub
    Public Overrides Function GetBindingManager(Optional ByVal aTableName As String = Nothing) As BindingManagerBase
        If Grid Is Nothing Then Return Nothing
        If CType(Grid, DataGrid).DataSource Is Nothing Then Return Nothing
        Return BindingContext(CType(Grid, DataGrid).DataSource)
    End Function


#End Region

#Region "BaseListForm Overridable metods"
    Protected Overridable Sub TableAdded(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
        If e.Action = CollectionChangeAction.Add AndAlso CType(e.Element, DataTable).TableName = ObjectName Then
            CType(Grid, DataGrid).DataSource = baseDataSet.Tables(ObjectName)
        End If

    End Sub

    Public Overridable Function GetDataset() As DataSet
        Return Nothing
    End Function

    Public Overridable Function CreateDetailForm() As BaseForm
        Return Nothing
    End Function
    <Browsable(False)> _
    Public Overridable ReadOnly Property Grid() As Object
        Get
            Return Nothing
        End Get
    End Property
    <Browsable(True), Localizable(False)> _
    Public Property LeftIcon() As Image
        Get
            Return PictureBox1.Image
        End Get
        Set(ByVal Value As Image)
            PictureBox1.Image = Value
        End Set
    End Property

    <Browsable(True), Localizable(True)> _
    Public Overrides Property Caption() As String
        Get
            Return MyBase.Caption
        End Get
        Set(ByVal Value As String)
            MyBase.Caption = Value
            lbCaption.Text = MyBase.Caption
            'If ((BaseForm.ShowFromID = True) AndAlso (Not (FormID Is Nothing)) AndAlso (FormID.Length > 0)) Then
            '    lbCaption.Text = String.Format("{1} ({0})", FormID, MyBase.Caption)
            'Else
            '    lbCaption.Text = MyBase.Caption
            'End If
        End Set
    End Property
    <Browsable(True), Localizable(False)> _
    Public Overrides Property FormID() As String
        Get
            Return m_FormID
        End Get
        Set(ByVal Value As String)
            MyBase.FormID = Value
            If ((BaseForm.ShowFromID = True) AndAlso (Not (FormID Is Nothing)) AndAlso (FormID.Length > 0)) Then
                lbFormID.Text = FormID
            End If

        End Set
    End Property

    Public Overridable Function DeleteRecord(ByVal key As Object) As Boolean
        If key Is Nothing Then
            key = GetKey()
        End If
        If Not BaseForm.FindDetailFormByID(key) Is Nothing Then
            ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
            Return False
        End If
        If DbService.CanDelete(key) = False Then
            Dim err As ErrorMessage = DbService.LastError
            If Not err Is Nothing Then
                ErrorForm.ShowError(err)
            Else
                ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
            End If
            Return False
        End If
        If Delete(key) = False Then
            ErrorForm.ShowError(DbService.LastError)
            Return False
        Else
            'LoadData()
            Return True
        End If
    End Function

    Public Overridable Function LocateRow(ByVal ID As Object) As Boolean
        If Grid Is Nothing OrElse CType(Grid, DataGrid).DataSource Is Nothing Then Return False
        If ID Is Nothing Then Return False
        Dim dt As DataTable
        If TypeOf (CType(Grid, DataGrid).DataSource) Is DataView Then
            dt = CType(CType(Grid, DataGrid).DataSource, DataView).Table
        ElseIf TypeOf (CType(Grid, DataGrid).DataSource) Is DataTable Then
            dt = CType(CType(Grid, DataGrid).DataSource, DataTable)
        Else
            Throw New Exception("Unsupported DataSource Type")
        End If
        Dim row As DataRow = BaseDbService.FindRow(dt, ID)
        Dim i As Integer
        If TypeOf (CType(Grid, DataGrid).DataSource) Is DataView Then
            Dim dv As DataView = CType(CType(Grid, DataGrid).DataSource, DataView)
            For i = 0 To dv.Count - 1
                If row Is dv(i).Row Then
                    CType(Grid, DataGrid).CurrentRowIndex = i
                    Return True
                End If
            Next
        Else
            For i = 0 To dt.Rows.Count - 1
                If row Is dt.Rows(i) Then
                    CType(Grid, DataGrid).CurrentRowIndex = i
                    Return True
                End If
            Next

        End If
    End Function

#End Region

#Region "Public Methods"
    Public Function GetCurrentRowPosition() As Integer
        Dim bm As BindingManagerBase = GetBindingManager()
        If bm Is Nothing Then Return -1
        Return bm.Position
    End Function
#End Region

#Region "Private methods"
    Protected Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        If LockHandler() Then
            Try
                DoClose()
            Finally
                UnlockHandler()
            End Try
        End If
    End Sub

    Protected Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        If LockHandler() Then
            Try
                LoadData(Nothing)
            Finally
                UnlockHandler()
            End Try
        End If
    End Sub
    Protected Overridable Sub EditRecord()
        Dim bf As BaseForm
        Dim r As DataRow
        'If FormsList.IndexOf(Me) >= 0 Then
        '    SetCurrentForm(CType(Me, BaseForm))
        'End If

        If LockHandler() Then
            Try
                If Not Me Is m_CurrentForm Then

                End If
                If (State And BusinessObjectState.SelectObject) <> 0 Then
                    DoOk()
                    Return
                End If
                r = GetCurrentRow()
                If Not r Is Nothing Then
                    bf = CreateDetailForm()
                    If (Not bf Is Nothing) Then
                        BaseFormManager.ShowNormal(bf, GetKey)
                    End If
                End If
            Finally
                UnlockHandler()
            End Try
        End If

    End Sub
    Protected Overridable Sub NewRecord()
        If Not CanCreateObject() Then
            Return
        End If
        Dim bf As BaseForm
        DebugTimer.Start("New record creation is started for {0}", Me.Name)
        If LockHandler() Then
            Try
                DebugTimer.Start("create detail form")
                bf = CreateDetailForm()
                DebugTimer.Stop()
                If (Not bf Is Nothing) Then
                    DebugTimer.Start("Show list detail for {0}", Me.Name)
                    BaseFormManager.ShowNormal(bf, Nothing)
                    DebugTimer.Stop()
                End If
            Finally
                UnlockHandler()
                DebugTimer.Stop()
            End Try
        End If
    End Sub
    Protected Overridable Sub DoDelete()
        If LockHandler() Then
            Try
                If Not CanDeleteObject() Then
                    Return
                End If
                If Me.MultiSelect Then
                    Dim rows() As DataRow = Me.GetSelectedRows
                    If Not rows Is Nothing AndAlso WinUtils.ConfirmDelete Then
                        For Each row As DataRow In rows
                            DeleteRecord(GetRecordKey(row))
                        Next
                    End If
                Else
                    Dim r As DataRow = GetCurrentRow()
                    If Not r Is Nothing Then
                        If WinUtils.ConfirmDelete Then
                            DeleteRecord(GetRecordKey(r))
                        End If
                    End If
                End If
            Finally
                UnlockHandler()
            End Try
        End If
    End Sub

    Protected Overridable Function IsRowClicked(ByVal x As Integer, ByVal y As Integer) As Boolean
        If Not Grid Is Nothing AndAlso TypeOf (Grid) Is DataGrid Then
            Dim hitInfo As System.Windows.Forms.DataGrid.HitTestInfo = CType(Grid, DataGrid).HitTest(x, y)
            Return hitInfo.Row >= 0
        End If
        Return True
    End Function
    Private Sub DataGrid1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsRowClicked(m_LastX, m_LastY) Then
            EditRecord()
        End If
    End Sub

    Private m_LastX As Integer = -1
    Private m_LastY As Integer = -1
    Private Sub DataGrid1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_LastX = e.Location.X
        m_LastY = e.Location.Y
    End Sub

    Private Sub ArrangeCaption()
        If LeftIcon Is Nothing Then
            lbCaption.Left = 8
            PictureBox1.Visible = False
        Else
            lbCaption.Left = PictureBox1.Left + PictureBox1.Width + 8
            PictureBox1.Visible = True
        End If
    End Sub

#End Region
    Protected m_EditButtonText As String = ""
    <Browsable(True), Localizable(True)> _
    Public Overridable Property EditButtonText() As String
        Get
            Return m_EditButtonText
        End Get
        Set(ByVal Value As String)
            m_EditButtonText = Value
        End Set
    End Property

    Private Sub BaseListForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ArrangeCaption()
    End Sub

    '===========================

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overridable ReadOnly Property GridControl() As Control
        Get
            Return (CType(Grid, Control))
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property CloseButton() As Control
        Get
            Return cmdClose
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property RefreshButton() As Control
        Get
            Return cmdRefresh
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overridable ReadOnly Property SearchForm() As ISearchForm
        Get
            If m_SearchControl Is Nothing Then Return Nothing
            Return CType(m_SearchControl, ISearchForm)
        End Get
    End Property
    Dim m_SearchControl As Control
    Dim m_SearchControlName As String = "bv.common.win.XtraSearchPanel"
    <Browsable(True), DefaultValue("bv.common.win.XtraSearchPanel")> _
    Public Overridable Property SearchControl() As String
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

    Dim m_SearchPanelDocStyle As DockStyle
    Public Overridable Property SearchPanelDocStyle() As DockStyle
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
    Protected m_ShowSearch As Boolean = True
    <Browsable(True), DefaultValue(True), Localizable(False)> _
    Public Overridable Property ShowSearch() As Boolean
        Get
            If m_SearchControl Is Nothing Then Return False
            Return m_ShowSearch
        End Get
        Set(ByVal Value As Boolean)
            If DesignMode Then Return
            If m_SearchControl Is Nothing Then Return
            If m_ShowSearch = Value Then Return
            m_ShowSearch = Value
            Dim cond As String = Nothing
            If m_SearchPanelDocStyle = DockStyle.Left Then
                Dim w As Integer = m_SearchControl.Width
                If Value Then
                    GridControl.Left += w
                    GridControl.Width -= w
                    cond = SearchForm.FilterCondition
                Else
                    GridControl.Left -= m_SearchControl.Width
                    GridControl.Width += m_SearchControl.Width
                End If
            Else
                Dim h As Integer = m_SearchControl.Height
                If Value Then
                    GridControl.Top += h
                    GridControl.Height -= h
                Else
                    GridControl.Top -= m_SearchControl.Height
                    GridControl.Height += h
                End If
            End If
            If Value Then
                DbService.ListFilterCondition = SearchForm.FilterCondition
                DbService.SearchParameters = SearchForm.SearchParameters
            Else
                DbService.ListFilterCondition = Nothing
                DbService.SearchParameters = Nothing
            End If
            m_SearchControl.Visible = Value
        End Set
    End Property

    Dim m_SearchOriginalHeight As Integer
    Dim m_SearchOriginalWidth As Integer
    Public Overridable Sub LoadSearchPanel() Implements ISearchable.LoadSearchPanel
        If IsDesignMode() Then
            Exit Sub
        End If
        If Not m_SearchControl Is Nothing AndAlso m_SearchControl.GetType().FullName <> Me.m_SearchControlName Then
            m_SearchControl.Dispose()
            m_SearchControl = Nothing
        End If
        If m_SearchControl Is Nothing AndAlso Utils.Str(m_SearchControlName) <> "" Then
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
            m_SearchControl.Left = GridControl.Left
            m_SearchControl.Top = GridControl.Top
        End If
        If Not m_SearchControl Is Nothing Then
            m_SearchControl.Visible = False
            If m_SearchPanelDocStyle = DockStyle.Left Then
                m_SearchControl.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Bottom
                m_SearchControl.Height = GridControl.Height
                m_SearchControl.Width = m_SearchOriginalWidth
            Else
                m_SearchControl.Height = m_SearchOriginalHeight
                m_SearchControl.Width = GridControl.Width
                m_SearchControl.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            End If
            m_SearchControl.Parent = Me
            AddHandler SearchForm.Search, AddressOf spanel_Search
            AddHandler SearchForm.SearchUsingProcedure, AddressOf spanel_SearchUsingProcedure
            SearchForm.Init(GridControl)
        End If
    End Sub

    Protected Sub spanel_Search(ByVal FilterCondition As String, ByVal FromCondition As String)
        If Not DbService Is Nothing Then
            DbService.ListFilterCondition = FilterCondition
            DbService.ListFromCondition = FromCondition
            LoadData(Nothing)
            If baseDataSet.Tables(0).Rows.Count = 0 AndAlso Utils.Str(FilterCondition) <> "" AndAlso Utils.Str(Config.GetSetting("ShowNoRecordsMessage")).ToLower(Globalization.CultureInfo.InvariantCulture) = "true" Then
                MessageForm.Show(BvMessages.Get("msgNoRecordsFound", "No records is found for current search criteria."))
            End If
        End If
    End Sub
    Protected Sub spanel_SearchUsingProcedure(ByVal SearchParameters As Generic.Dictionary(Of String, Object))
        If Not DbService Is Nothing Then
            DbService.ListFilterCondition = Nothing
            DbService.ListFromCondition = Nothing
            DbService.SearchParameters = SearchParameters
            LoadData(Nothing)

            If baseDataSet.Tables(0).Rows.Count = 0 AndAlso Not IsEmptySearchParameters(SearchParameters) AndAlso Utils.Str(Config.GetSetting("ShowNoRecordsMessage")).ToLower(Globalization.CultureInfo.InvariantCulture) = "true" Then
                MessageForm.Show(BvMessages.Get("msgNoRecordsFound", "No records is found for current search criteria."))
            End If
        End If
    End Sub

    Private Function IsEmptySearchParameters(ByVal searchParameters As Generic.Dictionary(Of String, Object)) As Boolean
        If SearchParameters Is Nothing OrElse SearchParameters.Count = 0 Then
            Return True
        End If
        For Each val As Object In SearchParameters.Values
            If Not Utils.IsEmpty(val) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Overridable Sub EnableSearchPanel() Implements ISearchable.EnableSearchPanel
        If Not m_SearchControl Is Nothing Then
            m_SearchControl.Enabled = True
        End If

    End Sub
End Class
