Public Class HumanCaseDiagnosisChangeReason
    Inherits BaseDetailForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        Me.DbService = New HumanCaseDiagnosisChangeReason_DB
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HumanCaseDiagnosisChangeReason))
        Me.lblReason = New DevExpress.XtraEditors.LabelControl()
        Me.cbReason = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.cbReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        '
        'lblReason
        '
        resources.ApplyResources(Me.lblReason, "lblReason")
        Me.lblReason.Name = "lblReason"
        '
        'cbReason
        '
        resources.ApplyResources(Me.cbReason, "cbReason")
        Me.cbReason.Name = "cbReason"
        Me.cbReason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReason.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbReason.Properties.NullText = resources.GetString("cbReason.Properties.NullText")
        Me.cbReason.Tag = "{M}"
        '
        'HumanCaseDiagnosisChangeReason
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.cbReason)
        Me.Controls.Add(Me.lblReason)
        Me.FormID = "H12"
        Me.HelpTopicID = "human_case_form"
        Me.MinHeight = 240
        Me.MinWidth = 320
        Me.Name = "HumanCaseDiagnosisChangeReason"
        Me.ObjectName = "HumanCase"
        Me.ShowDeleteButton = False
        Me.ShowSaveButton = False
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.lblReason, 0)
        Me.Controls.SetChildIndex(Me.cbReason, 0)
        CType(Me.cbReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblReason As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbReason As DevExpress.XtraEditors.LookUpEdit

#End Region

#Region "Properties"

    Private ReadOnly Property IsSearchMode() As Boolean
        Get
            Return (Not Me.DbService Is Nothing) AndAlso _
                   (Utils.Str(Me.DbService.ID) = Utils.Str(Utils.SEARCH_MODE_ID))
        End Get
    End Property

    Private m_Reason As Object
    Public ReadOnly Property Reason() As Object
        Get
            Return m_Reason
        End Get
    End Property

    Public ReadOnly Property ReasonText() As Object
        Get
            Return cbReason.Text
        End Get
    End Property

#End Region

#Region "Overrides"

    Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
        If IsSearchMode() Then Return Utils.SEARCH_MODE_ID
        If Me.DbService Is Nothing Then Return Nothing
        Return Me.DbService.ID
    End Function

    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindBaseLookup(cbReason, Nothing, Nothing, BaseReferenceType.rftChangeDiagnosisReason, True)
        OkButton.Enabled = False
        cbReason.Select()
    End Sub

    Public Overrides Function Post(Optional ByVal postType As bv.common.PostType = bv.common.PostType.FinalPosting) As Boolean
        If IsSearchMode() Then Return True
        m_PromptResult = DialogResult.OK
        If (postType And postType.IntermediatePosting) = 0 Then
            'If m_ClosingMode = ClosingMode.Ok Then
            m_PromptResult = DialogResult.Yes
            Return True
            'End If
        End If
        Return False
    End Function

    Protected Overrides Function cmdClose_Click() As Boolean
        m_ClosingMode = ClosingMode.Cancel
        Dim OkToClose As Boolean = True

        If (cancelMode = CancelCloseMode.Normal) Then Return True
        If m_ClosingProcessed = True Then Return True

        Post()
        DoClose()
        m_ClosingProcessed = True

        Return OkToClose
    End Function
#End Region

#Region "Handlers"

    Private Sub memReason_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbReason.EditValueChanged
        m_Reason = cbReason.EditValue
        OkButton.Enabled = Not Utils.IsEmpty(cbReason.EditValue)
    End Sub

#End Region

End Class
