Imports System.ComponentModel
Imports System.Drawing
Imports System.Data.SqlClient
Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports System.Collections.Generic
Imports bv.common.db

Public Class BaseDetailForm
    Inherits BaseForm

    Enum CancelCloseMode
        CallPost = 0
        Normal = 1
    End Enum
    Enum ClosingMode
        None
        Ok
        Cancel
        Delete
    End Enum

    Public Shared cancelMode As CancelCloseMode = CancelCloseMode.CallPost


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.FormType = BaseFormType.DetailForm
        If Not IsDesignMode() Then
            AddHandler Application.Idle, AddressOf SetDeleteButtonState
            'm_HasIdleHandler = True
        End If
        AddHandler Me.OnAfterPost, AddressOf ClearDeleteButtonStateFlag
        PictureBox1.Properties.ShowMenu = False
        PictureBox1.Properties.AllowFocused = False
    End Sub

    Private Sub ClearDeleteButtonStateFlag(ByVal sender As Object, ByVal e As EventArgs)
        m_DeleteButtonWasDisabled = False
        eventManager.HasChanges = False
    End Sub

    Private m_DeleteButtonWasDisabled As Boolean
    Private Sub SetDeleteButtonState(ByVal sender As Object, ByVal e As EventArgs)
        'If m_DeleteButtonWasDisabled Then
        '    Return
        'End If
        cmdDelete.Enabled = Not DbService Is Nothing AndAlso Not DbService.IsNewObject AndAlso Permissions.CanDelete AndAlso Not eventManager.HasChanges
        m_DeleteButtonWasDisabled = Not cmdDelete.Enabled
    End Sub

    Protected Overrides Sub RemoveIdleHandler()
        MyBase.RemoveIdleHandler()
        Try
            RemoveHandler Application.Idle, AddressOf SetDeleteButtonState
            RemoveHandler Me.OnAfterPost, AddressOf ClearDeleteButtonStateFlag
        Catch ex As Exception
        End Try
    End Sub


    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        RemoveHandler cmdCancel.Click, AddressOf cmdCancel_Click
        RemoveHandler cmdOk.Click, AddressOf cmdOk_Click
        RemoveHandler cmdDelete.Click, AddressOf cmdDelete_Click

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
    Protected Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lbCaption As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbFormID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureBox1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents cmdNew As DevExpress.XtraEditors.SimpleButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseDetailForm))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton
        Me.Panel1 = New DevExpress.XtraEditors.PanelControl
        Me.PictureBox1 = New DevExpress.XtraEditors.PictureEdit
        Me.lbFormID = New DevExpress.XtraEditors.LabelControl
        Me.lbCaption = New DevExpress.XtraEditors.LabelControl
        Me.cmdNew = New DevExpress.XtraEditors.SimpleButton
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton
        Me.cmdDelete = New DevExpress.XtraEditors.SimpleButton
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.Name = "cmdCancel"
        '
        'Panel1
        '
        Me.Panel1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Panel1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.Panel1.Appearance.ForeColor = System.Drawing.Color.White
        Me.Panel1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panel1.Appearance.Options.UseBackColor = True
        Me.Panel1.Appearance.Options.UseForeColor = True
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
        Me.lbFormID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
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
        Me.lbCaption.Appearance.Options.UseTextOptions = True
        Me.lbCaption.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbCaption.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbCaption.Name = "lbCaption"
        Me.lbCaption.Tag = "FixFontSize"
        '
        'cmdNew
        '
        resources.ApplyResources(Me.cmdNew, "cmdNew")
        Me.cmdNew.Image = Global.bv.common.win.My.Resources.Resources.add
        Me.cmdNew.Name = "cmdNew"
        '
        'cmdSave
        '
        resources.ApplyResources(Me.cmdSave, "cmdSave")
        Me.cmdSave.Image = Global.bv.common.win.My.Resources.Resources.Save
        Me.cmdSave.Name = "cmdSave"
        '
        'cmdDelete
        '
        resources.ApplyResources(Me.cmdDelete, "cmdDelete")
        Me.cmdDelete.Image = Global.bv.common.win.My.Resources.Resources.Delete_Remove
        Me.cmdDelete.Name = "cmdDelete"
        '
        'BaseDetailForm
        '
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        resources.ApplyResources(Me, "$this")
        Me.Name = "BaseDetailForm"
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

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
        If DbService Is Nothing Then Return True
        Dim c As Boolean = baseDataSet.EnforceConstraints
        baseDataSet.EnforceConstraints = False
        baseDataSet.Clear()
        'baseDataSet.EnforceConstraints = c
        'If ID Is Nothing Then Return False
        Dim ds As DataSet = DbService.LoadDetailData(ID)
        If Not ds Is Nothing Then
            Merge(ds)
            DbDisposeHelper.DisposeDataset(ds)
            Return True
        ElseIf DbService.GetType().Name = "BaseDbService" Then 'If we use BaseDbService as Db service we assume fake data filling and posting
            Return True
        End If
        Return False
    End Function

    Protected m_PromptResult As DialogResult = DialogResult.Yes
    Protected m_DisableFormDuringPost As Boolean = True
    Protected Overrides Function SavePromptDialog(Optional ByVal DefaultResult As DialogResult = DialogResult.Yes) As DialogResult
        If BaseSettings.ShowSaveDataPrompt AndAlso Not Utils.IsCalledFromUnitTest Then 'AndAlso HasChanges() 
            Dim res As Boolean = False

            If m_ClosingMode = ClosingMode.None Then
                res = WinUtils.ConfirmSave
            ElseIf m_ClosingMode = ClosingMode.Ok Then
                res = WinUtils.ConfirmOk
            ElseIf m_ClosingMode = ClosingMode.Cancel Then
                res = WinUtils.ConfirmCancel(FindForm())
            End If
            If res Then
                Return DialogResult.Yes
            Else
                Return DialogResult.No
            End If
        End If
        Return DefaultResult
    End Function

    Public Overrides Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean
        If Not ForcePost AndAlso ((UseFormStatus = True AndAlso Status = FormStatus.Demo) OrElse [ReadOnly]) Then
            Return True
        End If
        If Not Editable Then Return True
        If DbService Is Nothing Then Return True
        DataEventManager.Flush()
        Dim aHasChanges As Boolean = HasChanges()
        'We assume that if DbService.ID is not initialized, detail form is called for list data editing
        'and we should not save new object if data was not changed.
        If DbService.ID Is Nothing AndAlso Not aHasChanges Then
            Return True
        End If
        'if new detail object is saved we should validate daat suggest saviing even if 
        'object was not changed
        If Not DbService.IsNewObject _
                AndAlso Not ((m_State And BusinessObjectState.IntermediateObject) <> 0) _
                AndAlso Not HasChanges() Then
            Return True
        End If

        If (postType And postType.IntermediatePosting) = 0 Then
            Dim DefaultResult As DialogResult = DialogResult.Yes
            FindForm.BringToFront()
            m_PromptResult = SavePromptDialog(DefaultResult)
            If (m_ClosingMode = ClosingMode.Cancel) Then
                Return m_PromptResult = DialogResult.Yes
            End If
            If m_PromptResult = DialogResult.No Then
                Return False
            End If
            'If m_PromptResult = DialogResult.No Then
            '    Return True
            'End If
            RaiseBeforeValidatingEvent()
            If ValidateData() = False Then
                m_PromptResult = DialogResult.Cancel
                Return False
            Else
                m_PromptResult = DialogResult.Yes
            End If
        End If
        If DbService Is Nothing Then
            Throw New Exception("Detail form DB service is not defined")
        End If

        RaiseBeforePostEvent(Me)
#If DEBUG Then
        Dbg.Assert(IgnoreAudit = True OrElse Not AuditObject Is Nothing, "Audit object for baseform {0} is not defined", Me.GetType().Name)
#End If
        DbService.ClearEvents()
        If Not AuditObject Is Nothing Then
            AuditObject.Key = GetKey()
            Dbg.DbgAssert(Not Utils.IsEmpty(AuditObject.Key), "object key is not defined for object {0}", AuditObject.Name)
            If (m_State And BusinessObjectState.NewObject) <> 0 Then
                AuditObject.EventType = AuditEventType.daeCreate
            Else
                AuditObject.EventType = AuditEventType.daeEdit
            End If
            AddHandler DbService.OnTransactionStarted, AddressOf CreateAuditEvent
            AddHandler DbService.OnTransactionFinished, AddressOf SaveEventLog
            AddHandler DbService.OnTransactionFinished, AddressOf ProcessFiltration
        End If
        If (m_DisableFormDuringPost = True) Then ' Special hint for the form designer
            Enabled = False
        End If
        Try
            If DbService.Post(baseDataSet, postType) = False Then '.GetChanges()
                ErrorForm.ShowError(DbService.LastError)
                Me.Enabled = True
                Return False
            End If
            Me.Enabled = True
            VisitCheckLlists(Me)
            If (postType And postType.IntermediatePosting) <> 0 Then
                m_State = BusinessObjectState.EditObject Or (m_State And BusinessObjectState.IntermediateObject)
                m_WasSaved = True
            End If
            If (postType And postType.FinalPosting) <> 0 Then
                m_State = BusinessObjectState.EditObject
                SaveInitialChanges()
                For Each child As IRelatedObject In m_ChildForms
                    If TypeOf (child) Is BaseForm Then
                        If (CType(child, BaseForm).UseParentDataset) Then
                            Continue For
                        End If
                        CType(child, BaseForm).SaveInitialChanges()
                    End If
                    'If TypeOf (child) Is BaseFlexibleForm Then
                    '    CType(child, BaseFlexibleForm).FFChanged = False
                    'End If
                    'If TypeOf (child) Is FlexGrid Then
                    '    CType(child, FlexGrid).FFChanged = False
                    'End If
                Next
                m_WasSaved = False
                m_WasPosted = True
            End If
            RaiseAfterPostEvent(Me)
            m_RefereshParentForm = True
            RefreshRelatedForms()
            Return True
        Catch ex As Exception
            Throw
        Finally
            If Not AuditObject Is Nothing Then
                RemoveHandler DbService.OnTransactionStarted, AddressOf CreateAuditEvent
                RemoveHandler DbService.OnTransactionFinished, AddressOf SaveEventLog
                RemoveHandler DbService.OnTransactionFinished, AddressOf ProcessFiltration
            End If
            If Not m_ParentBaseForm Is Nothing AndAlso Not m_ParentBaseForm.IsDisposed AndAlso TypeOf Me.m_ParentBaseForm Is BaseListForm Then
                m_ParentBaseForm.LoadData(Nothing)
                CType(m_ParentBaseForm, BaseListForm).LocateRow(GetKey)
                m_RefereshParentForm = False
            End If
            Enabled = True
        End Try
    End Function
    Public Overrides Function GetClientHeight() As Integer
        Return Me.cmdOk.Top - Me.Panel1.Height - 8
    End Function
    <Browsable(True), DefaultValue(False)> _
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            MyBase.ReadOnly = Value
            'Me.cmdOk.Visible = Not Value
            cmdOk.Visible = ShowOkButton
            DefineStandardButtonsState(Value)
            ArrangeButtons(cmdCancel.Top, "BottomButtons")
        End Set
    End Property

    Protected Sub DefineStandardButtonsState(ByVal isReadOnly As Boolean)
        If Not WinUtils.IsComponentInDesignMode(Me) Then
            cmdDelete.Visible = BaseSettings.ShowDeleteButtonOnDetailForm AndAlso ShowDeleteButton AndAlso BaseFormManager.ModalFormCount <= 1 AndAlso Permissions.GetButtonVisibility(DefaultButtonType.Delete)
            cmdNew.Visible = BaseSettings.ShowNewButtonOnDetailForm AndAlso ShowNewButton AndAlso BaseFormManager.ModalFormCount <= 1 AndAlso Permissions.GetButtonVisibility(DefaultButtonType.[New])
            cmdSave.Visible = BaseSettings.ShowSaveButtonOnDetailForm AndAlso ShowSaveButton AndAlso BaseFormManager.ModalFormCount <= 1 AndAlso Not isReadOnly AndAlso Permissions.GetButtonVisibility(DefaultButtonType.Save)
            cmdNew.Enabled = Permissions.CanInsert 'AndAlso (Me.ParentBaseForm Is Nothing OrElse (Not ParentBaseForm.PermissionObject Is Nothing AndAlso ParentBaseForm.PermissionObject.Equals(PermissionObject)))
            'cmdDelete.Enabled = Permissions.CanDelete 'AndAlso (Me.ParentBaseForm Is Nothing OrElse (Not ParentBaseForm.PermissionObject Is Nothing AndAlso ParentBaseForm.PermissionObject.Equals(PermissionObject)))
            cmdSave.Enabled = ((Me.State And BusinessObjectState.EditObject) <> 0 AndAlso Permissions.CanUpdate) OrElse (Me.State And (BusinessObjectState.IntermediateObject Or BusinessObjectState.NewObject)) <> 0 AndAlso Permissions.CanInsert
            cmdCancel.Visible = Not isReadOnly AndAlso ShowCancelButton
        End If

    End Sub

    Private Sub CancelFormClosing()
        If Not ParentForm Is Nothing Then
            If ParentForm.Modal Then
                Me.ParentForm.DialogResult = DialogResult.None
            End If
        End If
        SelectLastFocusedControl()
    End Sub



    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.OkFormClose()
    End Sub

    Protected Sub OkFormClose()
        If LockHandler() Then
            Try
                m_ClosingMode = ClosingMode.Ok
                If (Post()) Then
                    m_ClosingProcessed = True
                    If m_PromptResult = DialogResult.Yes Then
                        DoOk()
                    Else
                        DoClose()
                    End If
                Else
                    CancelFormClosing()
                End If

            Catch ex As Exception
                If Not Me.baseDataSet Is Nothing Then
                    Throw
                End If
            Finally
                UnlockHandler()
            End Try
        End If
    End Sub

    Protected m_DoDeleteAfterNo As Boolean = True

    Protected Overridable Function cmdClose_Click() As Boolean
        m_ClosingMode = ClosingMode.Cancel
        Dim OkToClose As Boolean = True
        If (cancelMode = CancelCloseMode.Normal) Then Return True
        If m_ClosingProcessed = True Then Return True
        If BaseSettings.SaveOnCancel = True _
                    AndAlso (Me.State And BusinessObjectState.IntermediateObject) <> 0 _
                    AndAlso (m_State And BusinessObjectState.NewObject) = 0 _
                    AndAlso Not DbService Is Nothing Then
            Try
                Post()
                If (m_PromptResult = DialogResult.No) AndAlso m_DoDeleteAfterNo Then
                    If Delete(GetKey) = False Then
                        ErrorForm.ShowError(DbService.LastError)
                        Return False
                    End If
                ElseIf m_PromptResult = DialogResult.Cancel Then
                    OkToClose = False
                End If
            Catch ex As Exception
                Trace.WriteLine(ex)
            End Try
        ElseIf BaseSettings.SaveOnCancel = True Then
            If Post() = False Then
                CancelFormClosing()
                Return False
            End If
        End If
        If OkToClose Then
            DoClose()
            m_ClosingProcessed = True
        Else
            CancelFormClosing()
        End If
        Return OkToClose
    End Function

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If LockHandler() Then
            Try
                m_ClosingMode = ClosingMode.Cancel
                If (cancelMode = CancelCloseMode.CallPost) Then
                    cmdClose_Click()
                End If
                If (cancelMode = CancelCloseMode.Normal) Then
                    If Not ParentForm Is Nothing Then
                        If ParentForm.Modal Then
                            Me.ParentForm.DialogResult = DialogResult.None
                        End If
                        DoClose()
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                UnlockHandler()
            End Try
        End If
    End Sub
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If LockHandler() Then
            Try
                m_ClosingMode = ClosingMode.Delete
                Dim res As DialogResult = DeletePromptDialog()
                If res = DialogResult.No Then
                    SelectLastFocusedControl()
                    Return
                End If
                If res = DialogResult.Yes Then
                    Try
                        Dim key As Object = GetKey()
                        If DbService.CanDelete(key) = False Then
                            Dim err As ErrorMessage = DbService.LastError
                            If Not err Is Nothing Then
                                ErrorForm.ShowError(err)
                            Else
                                ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
                            End If
                            Return
                        End If
                        If Delete(key) = False Then
                            ErrorForm.ShowError(DbService.LastError)
                        End If
                        m_RefereshParentForm = True
                        RefreshRelatedForms()
                    Catch ex As Exception
                        ErrorForm.ShowError(ex)
                        Return
                    End Try
                End If
                m_ClosingProcessed = True
                DoClose()
            Catch ex As Exception
                Throw
            Finally
                UnlockHandler()
            End Try
        End If
    End Sub

    Private Sub BaseDetailForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim addSpace As Integer = 0

        If Not Visible Then Return
        Dim mainObjectRow As DataRow = GetCurrentRow()
        If Not WinUtils.IsComponentInDesignMode(Me) Then

            If Not PermissionObject Is Nothing Then
                If Not Me.ReadOnly _
                        AndAlso (Me.Permissions.CanUpdate = False OrElse Me.Permissions.CanUpdateRow(mainObjectRow) = False) _
                        AndAlso Not ((State And BusinessObjectState.NewObject) <> 0 AndAlso Me.Permissions.CanInsert = True) Then
                    If Not TypeOf Me Is BaseDetailList Then
                        Me.ReadOnly = True
                        cmdSave.Enabled = False
                    End If
                    cmdDelete.Enabled = False
                End If
                If Me.Permissions.CanInsert = False Then
                    cmdNew.Enabled = False
                End If
                If Me.Permissions.CanDelete = False OrElse Me.Permissions.CanDeleteRow(mainObjectRow) = False Then
                    cmdDelete.Enabled = False
                End If
            End If
            'ArrangeButton(Me, cmdCancel, Nothing, Me.Height - cmdCancel.Height - 8)
            'ArrangeButton(Me, cmdOk, cmdCancel)
            DefineStandardButtonsState([ReadOnly])
        End If
        ArrangeButtons(Me.cmdCancel.Top, "BottomButtons", cmdCancel.Height, Me.Height - cmdCancel.Height - addSpace - 8)
        ArrangeCaption()
        Panel1.SendToBack()
        If FullScreenMode = False Then
            'This panel is used to restrict client area of the detail form
            'and prevent controls with DockStyle = Full expand to command buttons area
            BottomDockPanel = New TopDockPanel
            BottomDockPanel.Text = ""
            BottomDockPanel.Parent = Me
            BottomDockPanel.Height = cmdOk.Height + 16
            BottomDockPanel.Dock = DockStyle.Bottom
            BottomDockPanel.SendToBack()
        End If
        If Not ParentForm Is Nothing AndAlso Me.FullScreenMode = False Then
            AddHandler ParentForm.Closing, AddressOf FormClosing
        End If
    End Sub

    Private Sub FormClosing(ByVal sender As Object, ByVal e As CancelEventArgs)
        Dim f As Boolean = Me.FormCloseButtonClicked
        If (sender Is BaseFormManager.MainForm) OrElse e.Cancel Then
            Return
        End If
        If Me.Loading Then
            e.Cancel = True
        ElseIf Not Closing Then
            cancelMode = CancelCloseMode.CallPost
            e.Cancel = Not cmdClose_Click()
        End If
        If m_RefereshParentForm Then
            If Not m_ParentBaseForm Is Nothing AndAlso Not m_ParentBaseForm.IsDisposed AndAlso TypeOf Me.m_ParentBaseForm Is BaseListForm Then
                m_ParentBaseForm.LoadData(Nothing)
            End If
        End If
    End Sub
    Private BottomDockPanel As TopDockPanel

    Private Sub BaseDetailForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ResizeForm()
    End Sub
    Protected Overrides Sub ResizeForm()
        Dim addSpace As Integer = 0
        ArrangeButtons(Me.cmdCancel.Top, "BottomButtons", cmdCancel.Height, Me.Height - cmdCancel.Height - addSpace - 8)
    End Sub
    Private Sub ArrangeCaption()
        If LeftIcon Is Nothing Then
            lbCaption.Left = 8
            PictureBox1.Visible = False
        Else
            lbCaption.Left = PictureBox1.Left + PictureBox1.Width + 8
            PictureBox1.Visible = True
        End If
        lbCaption.Width = lbFormID.Left - lbCaption.Left
    End Sub
#Region "Properties"
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

    Dim m_OkButton As Boolean = True
    <DefaultValue(True), Localizable(False)> _
    Public Property ShowOkButton() As Boolean
        Get
            Return m_OkButton
        End Get
        Set(ByVal Value As Boolean)
            m_OkButton = Value
            If Not cmdOk Is Nothing Then
                cmdOk.Visible = Value
            End If
        End Set
    End Property
    Dim m_OkButtonEnabled As Boolean = True
    <DefaultValue(True), Localizable(False)> _
    Public Property EnabledOkButton() As Boolean
        Get
            Return m_OkButtonEnabled
        End Get
        Set(ByVal Value As Boolean)
            m_OkButtonEnabled = Value
            If Not cmdOk Is Nothing Then
                cmdOk.Enabled = Value
            End If
        End Set
    End Property
    Dim m_CancelButton As Boolean = True
    <DefaultValue(True), Localizable(False)> _
    Public Property ShowCancelButton() As Boolean
        Get
            Return m_CancelButton
        End Get
        Set(ByVal Value As Boolean)
            m_CancelButton = Value
            If Not cmdCancel Is Nothing Then
                cmdCancel.Visible = Value
            End If
        End Set
    End Property
    Dim m_DeleteButton As Boolean = True
    <DefaultValue(True), Localizable(False)> _
    Public Property ShowDeleteButton() As Boolean
        Get
            Return m_DeleteButton
        End Get
        Set(ByVal Value As Boolean)
            m_DeleteButton = Value
            If Not cmdDelete Is Nothing Then
                cmdDelete.Visible = Value
            End If
        End Set
    End Property

    Dim m_SaveButton As Boolean = True
    <DefaultValue(True), Localizable(False)> _
    Public Property ShowSaveButton() As Boolean
        Get
            Return m_SaveButton
        End Get
        Set(ByVal Value As Boolean)
            m_SaveButton = Value
            If Not cmdSave Is Nothing Then
                cmdSave.Visible = Value
            End If
        End Set
    End Property

    Dim m_NewButton As Boolean = False
    <DefaultValue(False), Localizable(False)> _
    Public Property ShowNewButton() As Boolean
        Get
            Return m_NewButton
        End Get
        Set(ByVal Value As Boolean)
            m_NewButton = Value
            If Not cmdNew Is Nothing Then
                cmdNew.Visible = Value
            End If
        End Set
    End Property

    <Browsable(True), Localizable(False)> _
    Public Overrides Property FullScreenMode() As Boolean
        Get
            Return MyBase.FullScreenMode
        End Get
        Set(ByVal Value As Boolean)
            Panel1.Visible = Not Value
            cmdOk.Visible = Not Value
            cmdCancel.Visible = Not Value
            m_FullScreenMode = Value
            SetFullscreenMode(Panel1.Height, Panel1.Height + cmdOk.Height + 8)
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides ReadOnly Property AcceptButton() As IButtonControl
        Get
            Return cmdOk
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides ReadOnly Property RejectButton() As IButtonControl
        Get
            Return cmdCancel
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property SaveButton() As Control
        Get
            Return cmdSave
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property DeleteButton() As Control
        Get
            Return cmdDelete
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property NewButton() As Control
        Get
            Return cmdNew
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property OkButton() As Control
        Get
            Return cmdOk
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property CancelButton() As Control
        Get
            Return cmdCancel
        End Get
    End Property

#End Region



    Protected Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If LockHandler() Then
            Try
                m_ClosingMode = ClosingMode.None
                If Post() Then
                    'LoadData(GetKey())
                End If

            Catch ex As Exception
                Throw
            Finally
                UnlockHandler()
            End Try
        End If
        SelectLastFocusedControl()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        If LockHandler() Then
            Try
                If Post() Then
                    If Permissions.CanInsert Then
                        State = BusinessObjectState.NewObject Or BusinessObjectState.IntermediateObject
                        [ReadOnly] = False
                        LoadData(Nothing)
                    End If
                Else
                    SelectLastFocusedControl()
                End If
            Catch ex As Exception
                Throw
            Finally
                UnlockHandler()
            End Try
        End If
    End Sub

    Protected Overrides Sub RefreshLayout()
        MyBase.RefreshLayout()
    End Sub
    Private m_Editable As Boolean = True
    <Browsable(True), Localizable(False), DefaultValue(True)> _
    Public Property Editable() As Boolean
        Get
            Return m_Editable
        End Get
        Set(ByVal value As Boolean)
            m_Editable = value
        End Set
    End Property

    Public Overrides Sub BaseForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            cmdCancel_Click(cmdCancel, EventArgs.Empty)
        Else
            MyBase.BaseForm_KeyDown(sender, e)
        End If
    End Sub
    Protected Overrides Sub RemoveParentFormEvents(ByVal form As Form)
        MyBase.RemoveParentFormEvents(form)

        Try
            RemoveHandler form.Closing, AddressOf FormClosing
        Catch ex As Exception
        End Try
    End Sub
    Protected m_RelatedLists As String()
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property RelatedLists As String()
        Get
            If m_RelatedLists Is Nothing Then
                m_RelatedLists = New String() {ObjectName + "ListItem"}
            End If
            Return m_RelatedLists
        End Get
    End Property

    Protected Sub RefreshRelatedForms()
        If Not RelatedLists Is Nothing Then
            For Each Name As String In m_RelatedLists
                BaseFormManager.RefreshList(Name)
            Next
        End If

    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ForcePost As Boolean = False


End Class
