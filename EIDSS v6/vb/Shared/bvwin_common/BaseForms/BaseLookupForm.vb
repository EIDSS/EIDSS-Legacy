Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports System.Globalization
Imports bv.winclient.Core
Imports DevExpress.XtraBars.Docking
Imports bv.common.Enums

Public Enum LookupFormLayout
    DropDownList
    Group
End Enum

Public Class BaseLookupForm
    Inherits BaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        AddHandler Me.AfterLoadData, AddressOf AfterLoading
        Visible = True
        Enabled = True
        Me.FormType = BaseFormType.LookupForm
        AddHandler Me.DataBindings.CollectionChanged, AddressOf BindingChanged
    End Sub

    Private Sub DeleteDatasetCopy()
        If Not m_DataSetCopy Is Nothing Then
            DbDisposeHelper.DisposeDataset(m_DataSetCopy)
            m_DataSetCopy = Nothing
        End If

    End Sub
    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            DeleteDatasetCopy()
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
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents commandPanel As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PopupEdit As DevExpress.XtraEditors.PopupContainerEdit
    Friend WithEvents PopupContainer As DevExpress.XtraEditors.PopupContainerControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseLookupForm))
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.commandPanel = New DevExpress.XtraEditors.PanelControl()
        Me.PopupEdit = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.PopupContainer = New DevExpress.XtraEditors.PopupContainerControl()
        CType(Me.commandPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.commandPanel.SuspendLayout()
        CType(Me.PopupEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(BaseLookupForm), resources)
        'Form Is Localizable: True
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        '
        'btnOk
        '
        resources.ApplyResources(Me.btnOk, "btnOk")
        Me.btnOk.Name = "btnOk"
        '
        'commandPanel
        '
        Me.commandPanel.Appearance.BackColor = CType(resources.GetObject("commandPanel.Appearance.BackColor"), System.Drawing.Color)
        Me.commandPanel.Appearance.Options.UseBackColor = True
        Me.commandPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.commandPanel.Controls.Add(Me.btnCancel)
        Me.commandPanel.Controls.Add(Me.btnOk)
        resources.ApplyResources(Me.commandPanel, "commandPanel")
        Me.commandPanel.Name = "commandPanel"
        '
        'PopupEdit
        '
        resources.ApplyResources(Me.PopupEdit, "PopupEdit")
        Me.PopupEdit.Name = "PopupEdit"
        Me.PopupEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("PopupEdit.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.PopupEdit.Properties.PopupControl = Me.PopupContainer
        Me.PopupEdit.Properties.PopupSizeable = False
        '
        'PopupContainer
        '
        resources.ApplyResources(Me.PopupContainer, "PopupContainer")
        Me.PopupContainer.Name = "PopupContainer"
        '
        'BaseLookupForm
        '
        Me.Controls.Add(Me.PopupContainer)
        Me.Controls.Add(Me.PopupEdit)
        Me.Controls.Add(Me.commandPanel)
        resources.ApplyResources(Me, "$this")
        Me.Name = "BaseLookupForm"
        CType(Me.commandPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.commandPanel.ResumeLayout(False)
        CType(Me.PopupEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Protected m_SuppressValidation As Boolean = False
    'Private Sub CreatePopupControls()
    '    Me.PopupEdit = New DevExpress.XtraEditors.PopupContainerEdit
    '    Me.PopupContainer = New DevExpress.XtraEditors.PopupContainerControl
    '    PopupContainer.Tag = Me
    '    '
    '    'PopupEdit
    '    '
    '    Me.PopupEdit.Dock = System.Windows.Forms.DockStyle.Top
    '    Me.PopupEdit.EditValue = ""
    '    Me.PopupEdit.Location = New System.Drawing.Point(0, 0)
    '    Me.PopupEdit.Name = "PopupEdit"
    '    '
    '    'PopupEdit.Properties
    '    '
    '    Me.PopupEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
    '    Me.PopupEdit.Properties.PopupControl = Me.PopupContainer
    '    Me.PopupEdit.Properties.ValidateOnEnterKey = True
    '    Me.PopupEdit.Size = New System.Drawing.Size(464, 22)
    '    Me.PopupEdit.TabIndex = 0
    '    '
    '    'PopupContainer
    '    '
    '    Me.PopupContainer.Location = New System.Drawing.Point(0, 32)
    '    Me.PopupContainer.Name = "PopupContainer"
    '    Me.PopupContainer.Size = New System.Drawing.Size(456, 192)
    '    Me.PopupContainer.TabIndex = 1
    '    Me.PopupContainer.Text = "PopupContainerControl1"
    'End Sub

    Private Sub Popup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PopupEdit.KeyDown
        If (e.KeyCode <> Keys.Tab) Then
            PopupEdit.ShowPopup()
            e.Handled = True
        End If
    End Sub
    Private Sub Control_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            If Not (Not PopupEdit Is Nothing AndAlso sender Is PopupEdit AndAlso PopupEdit.IsPopupOpen) Then
                PopupEdit.ClosePopup()
                e.Handled = True
            End If
            If (e.KeyCode = Keys.Escape) Then
                m_SuppressValidation = True
                PopupEdit.CancelPopup()
                e.Handled = True
            End If
        End If
    End Sub
    Private m_Flashed As Boolean = False
    Private Sub Flash()
        If m_Flashed = True Then Return
        For Each ctl As Control In Me.PopupContainer.Controls
            DataEventManager.SubmitCurrentEdit(ctl)
        Next
        m_Flashed = True
    End Sub
    Public Overridable Sub FixCurrentData()
        If (m_DataSetCopy Is Nothing) Then
            m_DataSetCopy = baseDataSet.Copy
        End If
    End Sub
    Public Overridable Sub CancelChanges()
        If Not m_DataSetCopy Is Nothing Then
            baseDataSet.Clear()
            baseDataSet.Merge(m_DataSetCopy)
            DeleteDatasetCopy()
        End If
    End Sub
    Public Overridable Sub BeforePopup()

    End Sub
    Private m_DataSetCopy As DataSet
    Private Sub Popup__QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PopupEdit.QueryPopUp
        'If ModalChild = True Then
        FixCurrentData()
        BeforePopup()
        m_SuppressValidation = True
    End Sub
    Public Shared ModalChild As Boolean
    Private Sub Popup_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PopupEdit.QueryCloseUp
        Flash()
        If ModalChild = True Then
            m_SuppressValidation = True
        End If
        If Me.ValidateData() = False Then
            e.Cancel = True
        End If
        m_SuppressValidation = True
    End Sub

    Private Sub Popup_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles PopupEdit.CloseUp
        Try
            Flash()
        Finally
            m_Flashed = False
        End Try
        If ModalChild Then Return
        If e.CloseMode = DevExpress.XtraEditors.PopupCloseMode.Cancel OrElse e.CloseMode = DevExpress.XtraEditors.PopupCloseMode.Immediate Then
            CancelChanges()
        Else
            RaiseEvent OnPopup_CloseUp(sender, e)
            SetLink()
        End If
    End Sub
    Public Overrides Function ValidateData() As Boolean
        If m_SuppressValidation Then Return True
        Return MyBase.ValidateData()
    End Function

    Public Event OnPopup_CloseUp As DevExpress.XtraEditors.Controls.CloseUpEventHandler

    Public Overrides Function GetBindingManager(Optional ByVal aTableName As String = Nothing) As BindingManagerBase
        If baseDataSet Is Nothing Then Return Nothing
        If baseDataSet.Tables.Count = 0 Then Return Nothing
        If aTableName Is Nothing OrElse aTableName = "" Then
            aTableName = ObjectName
        End If
        If aTableName Is Nothing OrElse aTableName = "" Then Return Nothing
        If baseDataSet.Tables.Contains(aTableName) Then
            Return BindingContext(baseDataSet.Tables(aTableName))
        Else
            Return Nothing
        End If
    End Function

    Public Overrides Function FillDataset(Optional ByVal ID As Object = Nothing) As Boolean
        If DbService Is Nothing Then Return False
        If IsDesignMode() Then Return False
        Dim c As Boolean = baseDataSet.EnforceConstraints
        baseDataSet.EnforceConstraints = False
        baseDataSet.Clear()
        'baseDataSet.EnforceConstraints = c
        'If ID Is Nothing Then Return False
        Dim ds As DataSet = DbService.LoadDetailData(ID)
        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 AndAlso ds.Tables(0).Rows(0).RowState = DataRowState.Added Then
                Me.State = BusinessObjectState.NewObject Or BusinessObjectState.IntermediateObject
            End If
            'If Not DbService.ID.Equals(m_ID) Then
            '    m_ID = DbService.ID
            '    Dim p As BaseForm = Me.ParentBaseForm
            '    If Me.DataBindings.Count > 0 AndAlso Not p Is Nothing Then
            '        Dim row As DataRow = p.GetCurrentRow(DataBindings(0).BindingMemberInfo.BindingPath)
            '        If Not row Is Nothing Then
            '            row(DataBindings(0).BindingMemberInfo.BindingField) = m_ID
            '        End If
            '    End If
            'End If
            Merge(ds)
            DbDisposeHelper.DisposeDataset(ds)
            Return True
        Else
            Dim err As ErrorMessage = DbService.LastError
            ErrorForm.ShowErrorDirect(err.Text, err.Exception)
            Return False
        End If
    End Function

    Public Overrides Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean
        If UseFormStatus = True AndAlso Status = FormStatus.Demo Then
            Return True
        End If
        If DbService Is Nothing Then Return True
        DataEventManager.Flush()
        If (PostType And PostType.IntermediatePosting) = 0 Then
            If ValidateData() = False Then
                Return False
            End If
        End If
        If DbService Is Nothing Then
            Throw New Exception("Detail form DB service is not defined")
            Return False
        End If
        If DbService.Post(baseDataSet) = False Then '.GetChanges()
            Dim err As ErrorMessage = DbService.LastError
            ErrorForm.ShowErrorDirect(err.Text, err.Exception)
            Return False
        End If
        If (PostType And PostType.IntermediatePosting) <> 0 Then
            m_State = BusinessObjectState.EditObject Or (m_State And BusinessObjectState.IntermediateObject)
            m_WasSaved = True
        End If
        If (PostType And PostType.FinalPosting) <> 0 Then
            m_State = BusinessObjectState.EditObject
            m_WasSaved = False
            m_WasPosted = True
        End If
        Return True
    End Function

    'Private Sub BaseLookupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    SetLayout()
    'End Sub

    Public CanSetLayout As Boolean = True
    Private Sub SetLayout()
        If Not Me.IsHandleCreated Then
            Return
        End If
        If CanSetLayout Then
            If m_Layout = LookupFormLayout.DropDownList Then
                If FindParentForm() Then
                    'Me.CreatePopupControls()
                    If IsDesignMode() = False Then
                        MoveControls(Me, PopupContainer)
                        m_IsLayoutInitialized = True
                    End If
                    If (IsDesignMode() = False) AndAlso (m_PopupEditHeight > 0) Then
                        PopupContainer.Height = m_PopupEditHeight + 16
                    End If
                    Me.PopupEdit.Dock = DockStyle.Top
                    Me.Height = Me.PopupEdit.Height
                    'Me.Controls.Add(Me.PopupEdit)
                    'Me.Controls.Add(Me.PopupContainer)
                    Me.PopupEdit.BringToFront()
                    'AddHandler PopupEdit.KeyDown, AddressOf Popup_KeyDown
                    'AddHandler PopupEdit.SizeChanged, AddressOf PopupEdit_SizeChanged
                    'AddHandler PopupEdit.CloseUp, AddressOf Popup_CloseUp
                    'AddHandler PopupEdit.QueryCloseUp, AddressOf Popup_QueryCloseUp
                    'AddHandler PopupEdit.QueryPopUp, AddressOf Popup__QueryPopUp
                    PopupEdit.Properties.CloseOnOuterMouseClick = False
                    'PopupEdit.Properties.CloseOnLostFocus = False
                    PopupEdit.Properties.ShowPopupCloseButton = False
                    If (IsDesignMode() = False) AndAlso m_CanExpand Then
                        If PopupEditMinWidth > 0 AndAlso PopupEditMinWidth > Width Then
                            PopupContainer.Width = Me.PopupEditMinWidth
                        Else
                            PopupContainer.Width = Me.Width
                        End If
                    End If
                    PopupEdit.Properties.PopupFormWidth = PopupContainer.Width
                    PopupEdit.Properties.PopupFormSize = New System.Drawing.Size(PopupContainer.Width, PopupContainer.Height + commandPanel.Height)
                    PopupEdit.Properties.PopupSizeable = False
                    PopupEdit.Visible = True
                    PopupEdit.TabStop = True
                    commandPanel.Visible = True
                    If (IsDesignMode() = False) Then
                        Dim tag As New TagHelper(Me)
                        If tag.IsMandatory Then
                            PopupEdit.StyleController = MyBase.MandatoryFieldStyleController
                        Else
                            PopupEdit.StyleController = MyBase.PopupEditStyleController
                        End If
                    End If
                Else
                    PopupEdit.Top = -100
                    PopupContainer.Top = -1000
                    commandPanel.Visible = False
                    PopupEdit.TabStop = False
                End If
            Else
                PopupEdit.Dock = DockStyle.None
                PopupEdit.Top = -100
                PopupEdit.TabStop = False
                PopupContainer.Top = -1000
                'If Not PopupContainer Is Nothing Then
                MoveControls(PopupContainer, Me)
                '    PopupContainer.Dispose()
                '    PopupContainer = Nothing
                'End If
                'If Not PopupEdit Is Nothing Then
                '    PopupEdit.Dispose()
                '    PopupEdit = Nothing
                'End If
                commandPanel.Visible = False
                m_IsLayoutInitialized = True
            End If
        End If
    End Sub

    Public Sub Reload()
        If Not Utils.IsEmpty(m_ID) Then
            LoadData(m_ID)
            Me.ResetBinding()
            If m_Layout = LookupFormLayout.DropDownList Then
                If Not PopupEdit Is Nothing Then
                    PopupEdit.Text = DisplayText
                    PopupEdit.ToolTip = PopupEdit.Text
                End If
            End If
        End If
    End Sub
    Private m_ControlHandelrsAssigned As Boolean = False
    Private Sub MoveControls(ByVal sourceParent As Control, ByVal targetParent As Control)

        Dim h As Integer = 0
        Dim w As Integer = 0
        For i As Integer = sourceParent.Controls.Count - 1 To 0 Step -1
            Dim ctl As Control = sourceParent.Controls(i)
            If Not ctl Is PopupEdit AndAlso Not ctl Is PopupContainer Then
                If Not m_ControlHandelrsAssigned Then
                    AssignKeyDownEvent(sourceParent)
                End If
                If Not Controls(0) Is Me.commandPanel AndAlso Controls(0).Top + ctl.Height > h Then
                    h = ctl.Top + ctl.Height
                End If
                If Controls(0).Left + ctl.Width > w Then
                    w = ctl.Left + ctl.Width
                End If
                ctl.Parent = targetParent
            End If
        Next
        m_ControlHandelrsAssigned = True
        If h <> 0 Then targetParent.Height = h + commandPanel.Height
        If w <> 0 Then targetParent.Width = w + 8
    End Sub

    Private Sub AssignKeyDownEvent(ByVal sourceParent As Control)
        AddHandler sourceParent.KeyDown, AddressOf Control_KeyDown
        For Each ctl As Control In sourceParent.Controls
            AssignKeyDownEvent(ctl)
        Next
    End Sub
#Region "Properties"
    Private m_ID As Object = Nothing
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(True)> _
    Public Property ID() As Object
        Get
            If Not Me.GetCurrentRow Is Nothing Then
                m_ID = GetKey()
            End If
            Return m_ID
        End Get
        Set(ByVal Value As Object)
            If Utils.Str(Value) = Utils.Str(Utils.SEARCH_MODE_ID) Then
                m_ID = Value
                Return
            End If
            If IsDesignMode() Or Created = False OrElse (Not Parent Is Nothing AndAlso Parent.Created = False) Then Return
            If Loading Then Return
            'Pass Nothing to create new record in dataset
            If Value Is DBNull.Value Then
                Return
            End If
            If m_ID Is Nothing OrElse m_ID.Equals(Value) = False Then
                m_ID = Value
                If (Utils.Str(Value) <> Utils.Str(Utils.SEARCH_MODE_ID)) AndAlso (Me.ParentObject Is Nothing) Then
                    LoadData(m_ID)
                    'If Me.DataBindings.Count > 0 Then
                    '    Dim row As DataRow = GetCurrentRow(DataBindings(0).BindingMemberInfo.BindingPath)
                    '    If Not row Is Nothing Then
                    '        row(DataBindings(0).BindingMemberInfo.BindingField) = m_ID
                    '    End If
                    'End If
                End If
            End If
        End Set
    End Property

    <Browsable(False)> _
    Public Overridable ReadOnly Property DisplayText() As String
        Get
            Return ""
        End Get
    End Property
    Public Delegate Function SetLookupLink(ByVal ID As Object) As Boolean
    Private m_SetLookupLinkCallback As SetLookupLink
    <Browsable(False)> _
    Public WriteOnly Property SetLookupLinkCallback() As SetLookupLink
        Set(ByVal Value As SetLookupLink)
            m_SetLookupLinkCallback = Value
        End Set
    End Property
    Private m_Layout As LookupFormLayout = LookupFormLayout.DropDownList
    Private m_IsLayoutInitialized As Boolean = False
    <Browsable(True), DefaultValue(LookupFormLayout.DropDownList), Localizable(False)> _
    Public Property LookupLayout() As LookupFormLayout
        Get
            Return m_Layout
        End Get
        Set(ByVal Value As LookupFormLayout)
            If m_Layout <> Value OrElse m_IsLayoutInitialized = False Then
                m_Layout = Value
                SetLayout()
            End If
        End Set
    End Property

    Private m_CanExpand As Boolean = False
    <Browsable(True), DefaultValue(False)> _
    Public Property CanExpand() As Boolean
        Get
            Return m_CanExpand
        End Get
        Set(ByVal Value As Boolean)
            m_CanExpand = Value
            SetLayout()
        End Set
    End Property

    Private m_PopupEditHeight As Integer = 0
    <Browsable(True), DefaultValue(0), Localizable(False)> _
    Public Property PopupEditHeight() As Integer
        Get
            Return m_PopupEditHeight
        End Get
        Set(ByVal Value As Integer)
            m_PopupEditHeight = Value
            SetLayout()
        End Set
    End Property
    Private m_PopupEditMinWidth As Integer = 0
    <Browsable(True), DefaultValue(0), Localizable(False)> _
    Public Property PopupEditMinWidth() As Integer
        Get
            Return m_PopupEditMinWidth
        End Get
        Set(ByVal Value As Integer)
            m_PopupEditMinWidth = Value
            SetLayout()
        End Set
    End Property

#End Region

    Private Sub SetLink()
        If Not (m_SetLookupLinkCallback Is Nothing) Then
            m_SetLookupLinkCallback(ID)
        End If
    End Sub
    Private Function FindParentForm() As Boolean
        Dim ctl As Control = Parent
        If Not designMode Then Return Not Parent Is Nothing
        While Not ctl Is Nothing
            If ctl.GetType.Name = "OverlayControl" Then
                Return False
            End If
            If TypeOf (ctl) Is Control Then
                Return True
            End If
            ctl = ctl.Parent
        End While
        Return False
    End Function

    Protected Function FindParentBaseForm() As BaseForm
        Dim ctl As Control = Parent
        While Not ctl Is Nothing
            If TypeOf (ctl) Is BaseForm Then
                Return CType(ctl, BaseForm)
            End If
            ctl = ctl.Parent
        End While
        Return Nothing
    End Function

    Public Event OnDisplayTextChanged As EventHandler
    Private m_DisplayTextInternal As String = ""
    Private Sub PopupEdit_QueryDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.QueryDisplayTextEventArgs) Handles PopupEdit.QueryDisplayText
        If Closing Then
            Return
        End If
        e.DisplayText = DisplayText
        If m_DisplayTextInternal <> DisplayText Then
            PopupEdit.ToolTip = e.DisplayText
            RaiseEvent OnDisplayTextChanged(Me, EventArgs.Empty)
        End If
        m_DisplayTextInternal = DisplayText
    End Sub

    Public Sub RefreshDisplayText()
        Me.PopupEdit.Refresh()
    End Sub
    Public Sub HidePopup()
        If Me.LookupLayout = LookupFormLayout.Group Then
            Return
        End If
        If Not Me.PopupEdit Is Nothing AndAlso Me.PopupEdit.IsPopupOpen Then
            m_SuppressValidation = True
            Me.PopupEdit.ClosePopup()
        End If
    End Sub
    Public Sub RestorePopup()
        If Me.LookupLayout = LookupFormLayout.Group Then
            Return
        End If
        If Not Me.PopupEdit Is Nothing Then
            Me.PopupEdit.ShowPopup()
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Not Me.PopupEdit Is Nothing AndAlso Me.PopupEdit.IsPopupOpen Then
            m_SuppressValidation = False
            Me.PopupEdit.ClosePopup()
            DeleteDatasetCopy()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not Me.PopupEdit Is Nothing Then
            m_SuppressValidation = True
            Me.CancelChanges()
            Me.PopupEdit.CancelPopup()
        End If
    End Sub

    Private Sub PopupEdit_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PopupEdit.SizeChanged
        If m_Layout = LookupFormLayout.DropDownList AndAlso PopupEdit.Height <> Me.Height AndAlso FindParentForm() AndAlso Parent.Created Then
            Height = PopupEdit.Height
        End If
    End Sub


    Public Sub Bind(ByVal ds As DataSet, ByVal DataMember As String)
        Me.DataBindings.Clear()
        Dim bind As Binding = Me.DataBindings.Add("ID", ds, DataMember, True, DataSourceUpdateMode.OnPropertyChanged)
        If ds.Tables(bind.BindingMemberInfo.BindingPath).Rows.Count = 0 Then
            ID = Nothing
        End If
        Me.PopupEdit.Text = DisplayText
        PopupEdit.ToolTip = PopupEdit.Text
    End Sub

    'Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
    '    MyBase.OnLoad(e)
    '    SetLayout()
    'End Sub
    Public Sub AfterLoading(ByVal sender As Object, ByVal e As EventArgs)
        m_ID = DbService.ID
        If m_Layout = LookupFormLayout.DropDownList Then
            If Not PopupEdit Is Nothing Then
                PopupEdit.Text = DisplayText
                PopupEdit.ToolTip = PopupEdit.Text
            End If
        End If
    End Sub

    Private Sub BaseLookupForm_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        SetLayout()
    End Sub
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            If Me.LookupLayout = LookupFormLayout.DropDownList Then
                Me.Enabled = Not Value
                m_Readonly = Value
            Else
                MyBase.ReadOnly = Value
            End If
        End Set
    End Property
    Private Sub BindingChanged(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
        If e.Action = CollectionChangeAction.Add Then
            Dim binding As Binding = CType(e.Element, Binding)
            If Not binding.DataSource Is Nothing AndAlso binding.PropertyName = "ID" _
                AndAlso Not binding.BindingMemberInfo.BindingMember Is Nothing _
                AndAlso Not binding.BindingManagerBase Is Nothing _
                AndAlso binding.BindingManagerBase.Position >= 0 Then
                m_ID = CType(binding.DataSource, DataSet).Tables(binding.BindingMemberInfo.BindingPath).Rows(binding.BindingManagerBase.Position)(binding.BindingMemberInfo.BindingField)
            End If
        End If
    End Sub
    Public Sub SelectPopupEdit()
        If PopupEdit.Visible Then
            PopupEdit.Select()
        End If
    End Sub
    Public Sub CloseOnOuterMouseClick(ByVal value As Boolean)
        PopupEdit.Properties.CloseOnOuterMouseClick = value
    End Sub
End Class
