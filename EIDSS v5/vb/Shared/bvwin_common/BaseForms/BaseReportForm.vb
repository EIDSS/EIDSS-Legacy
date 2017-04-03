Imports System.ComponentModel
Imports System.Linq
Imports bv.winclient.BasePanel

Namespace BaseForms

    Public Class BaseReportForm
        Inherits BaseForm

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()
            DbService = New bv.common.db.BaseDbService
            'Add any initialization after the InitializeComponent() call
            Me.FormType = BaseFormType.ReportForm
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            eventManager.ClearAllReferences()

            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager =
                    New System.ComponentModel.ComponentResourceManager(GetType(BaseReportForm))
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton
            Me.SuspendLayout()
            '
            'btnClose
            '
            resources.ApplyResources(Me.btnClose, "btnClose")
            Me.btnClose.Image = Global.bv.common.win.My.Resources.Resources.Close
            Me.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight
            Me.btnClose.Name = "btnClose"
            '
            'BaseReportForm
            '
            Me.Controls.Add(Me.btnClose)
            resources.ApplyResources(Me, "$this")
            Me.Name = "BaseReportForm"
            Me.ResumeLayout(False)
        End Sub

#End Region


#Region "Data Methods"

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

        Public Overrides Function FillDataset(Optional ByVal id As Object = Nothing) As Boolean
            If DbService Is Nothing Then Return True
            baseDataSet.EnforceConstraints = False
            baseDataSet.Clear()
            Dim ds As DataSet = DbService.LoadDetailData(id)
            If Not ds Is Nothing Then
                Merge(ds)
                DbDisposeHelper.DisposeDataset(ds)
                Return True
            Else
                Dim errorMessage As ErrorMessage
                errorMessage = DbService.LastError
                ErrorForm.ShowError(errorMessage)
                Return False
            End If
        End Function

        Public Overrides Function HasChanges() As Boolean
            If m_WasSaved Then Return True
            Return m_ChildForms.Any(Function(child) child.HasChanges())
        End Function


        Protected m_PromptResult As DialogResult = DialogResult.Yes
        Protected m_DisableFormDuringPost As Boolean = True

        Public Overrides Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean
            If UseFormStatus = True AndAlso Status = FormStatus.Demo OrElse [ReadOnly] Then
                Return True
            End If
            If DbService Is Nothing Then Return True
            DataEventManager.Flush()
            Dim aHasChanges As Boolean = HasChanges()
            'We assume that if DbService.ID is not initialized, detail form is called for list data editing
            'and we should not save new object if data was not changed.
            If Not aHasChanges Then
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
                Dim defaultResult As DialogResult = DialogResult.Yes
                If m_ClosingMode <> BaseDetailForm.ClosingMode.Ok Then
                    defaultResult = DialogResult.No
                End If
                Dim form As Form = FindForm()
                If Not (form Is Nothing) Then
                    form.BringToFront()
                End If

                m_PromptResult = SavePromptDialog(defaultResult)
                If m_PromptResult = DialogResult.Cancel Then
                    Return False
                End If
                If m_PromptResult = DialogResult.No Then
                    Return True
                End If
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
            If (m_DisableFormDuringPost = True) Then ' Special hint for the form designer
                Enabled = False
            End If

            DbService.ClearEvents()
            Try
                Dim childForPost As BaseDetailPanel = GetChildForPost()
                If (Not childForPost Is Nothing) Then
                    If (Not childForPost.Post(postType)) Then
                        ErrorForm.ShowError(DbService.LastError)
                        Enabled = True
                        Return False
                    End If
                End If
                Enabled = True
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
                            CType(child, BaseForm).SaveInitialChanges()
                        End If
                    Next
                    m_WasSaved = False
                    m_WasPosted = True
                End If
                RaiseAfterPostEvent(Me)
                Return True
            Catch ex As Exception
                Throw
            End Try
        End Function


        Protected Overridable Function GetChildForPost() As BaseRamDetailPanel
            Throw New NotImplementedException("method should be overriden")
        End Function

#End Region

#Region "Close Methods"

        Protected m_DoDeleteAfterNo As Boolean = True
        'Protected m_ClosingMode As BaseDetailForm.ClosingMode
        Protected Overridable Function cmdClose_Click() As Boolean
            m_ClosingMode = BaseDetailForm.ClosingMode.Cancel
            Dim okToClose As Boolean = True

            If (BaseDetailForm.cancelMode = BaseDetailForm.CancelCloseMode.Normal) Then Return True
            If m_ClosingProcessed = True Then Return True
            If (State And BusinessObjectState.IntermediateObject) <> 0 _
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
                        okToClose = False
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
            If okToClose Then

                DoClose()
                m_ClosingProcessed = True
            Else
                CancelFormClosing()
            End If
            Return okToClose
        End Function


        Private Sub FormClosing(ByVal sender As Object, ByVal e As CancelEventArgs)
            If Loading Then
                e.Cancel = True
            Else
                ' Note: Commented by Ivan bacause of double Posting
                '                BaseDetailForm.cancelMode = BaseDetailForm.CancelCloseMode.CallPost
                '                e.Cancel = Not cmdClose_Click()
            End If
        End Sub

        Private Sub CancelFormClosing()
            If Not ParentForm Is Nothing Then
                If BaseFormManager.ModalFormCount > 0 Then
                    ParentForm.DialogResult = DialogResult.None
                End If
            End If
            SelectLastFocusedControl()
        End Sub

#End Region

#Region "Private Local Methods"

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
            cmdClose_Click()
        End Sub

        Private Sub BaseReportForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            If Not Visible Then Return

            Dim mainObjectRow As DataRow = GetCurrentRow()
            If Not PermissionObject Is Nothing Then
                If _
                    Not Me.ReadOnly AndAlso
                    (Permissions.CanUpdate = False OrElse Permissions.CanUpdateRow(mainObjectRow) = False) Then
                    Me.ReadOnly = True
                End If
            End If

            ResizeForm()
            If Not ParentForm Is Nothing AndAlso FullScreenMode = False Then
                AddHandler ParentForm.Closing, AddressOf FormClosing
            End If
        End Sub


        Private Sub BaseReportForm_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
            ResizeForm()
        End Sub

#End Region

#Region "Properties"

        Dim m_CloseButton As Boolean = True

        <DefaultValue(True), Localizable(False)>
        Public Property ShowCloseButton() As Boolean
            Get
                Return m_CloseButton
            End Get
            Set(ByVal value As Boolean)
                m_CloseButton = value
                If Not btnClose Is Nothing Then
                    btnClose.Visible = value
                End If
            End Set
        End Property

        <Browsable(True), DefaultValue(False)>
        Public Overrides Property [ReadOnly]() As Boolean
            Get
                Return MyBase.ReadOnly
            End Get
            Set(ByVal value As Boolean)
                MyBase.ReadOnly = value
                btnClose.Visible = True
                ArrangeButtons(btnClose.Top, "BottomButtons")
            End Set
        End Property

        Protected Overrides Sub ResizeForm()
            ArrangeButtons(btnClose.Top, "BottomButtons", btnClose.Height, Height - btnClose.Height - 8)
        End Sub

        Public Overrides Sub BaseForm_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.KeyCode = Keys.Escape Then
                btnClose_Click(btnClose, EventArgs.Empty)
            Else
                MyBase.BaseForm_KeyDown(sender, e)
            End If
        End Sub

#End Region

        Protected Overrides Sub RemoveParentFormEvents(ByVal form As Form)
            MyBase.RemoveParentFormEvents(form)

            Try
                RemoveHandler form.Closing, AddressOf FormClosing
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace