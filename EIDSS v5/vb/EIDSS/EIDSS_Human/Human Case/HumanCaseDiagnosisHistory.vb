Public Class HumanCaseDiagnosisHistory
    Inherits BaseDetailForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        Me.DbService = New HumanCaseDiagnosisHistory_DB
        InitializeComponent()
    End Sub

    Friend WithEvents gcolPreviousDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolChangedDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolReason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbReason As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolPersonName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolChangedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolChangeDiagnosisHistoryID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gvChangeDiagnosisHistory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcChangeDiagnosisHistory As DevExpress.XtraGrid.GridControl
    Friend WithEvents gcolOrganization As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblHistory As DevExpress.XtraEditors.LabelControl

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HumanCaseDiagnosisHistory))
        Me.lblHistory = New DevExpress.XtraEditors.LabelControl()
        Me.gcChangeDiagnosisHistory = New DevExpress.XtraGrid.GridControl()
        Me.gvChangeDiagnosisHistory = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolChangeDiagnosisHistoryID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolChangedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolOrganization = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolPersonName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolPreviousDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolChangedDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolReason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbReason = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.gcChangeDiagnosisHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvChangeDiagnosisHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbReason, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHistory
        '
        resources.ApplyResources(Me.lblHistory, "lblHistory")
        Me.lblHistory.Name = "lblHistory"
        '
        'gcChangeDiagnosisHistory
        '
        resources.ApplyResources(Me.gcChangeDiagnosisHistory, "gcChangeDiagnosisHistory")
        Me.gcChangeDiagnosisHistory.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gcChangeDiagnosisHistory.MainView = Me.gvChangeDiagnosisHistory
        Me.gcChangeDiagnosisHistory.Name = "gcChangeDiagnosisHistory"
        Me.gcChangeDiagnosisHistory.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbReason})
        Me.gcChangeDiagnosisHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvChangeDiagnosisHistory})
        '
        'gvChangeDiagnosisHistory
        '
        Me.gvChangeDiagnosisHistory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolChangeDiagnosisHistoryID, Me.gcolChangedDate, Me.gcolOrganization, Me.gcolPersonName, Me.gcolPreviousDiagnosis, Me.gcolChangedDiagnosis, Me.gcolReason})
        Me.gvChangeDiagnosisHistory.GridControl = Me.gcChangeDiagnosisHistory
        resources.ApplyResources(Me.gvChangeDiagnosisHistory, "gvChangeDiagnosisHistory")
        Me.gvChangeDiagnosisHistory.Name = "gvChangeDiagnosisHistory"
        Me.gvChangeDiagnosisHistory.OptionsCustomization.AllowGroup = False
        Me.gvChangeDiagnosisHistory.OptionsView.ShowGroupPanel = False
        '
        'gcolChangeDiagnosisHistoryID
        '
        resources.ApplyResources(Me.gcolChangeDiagnosisHistoryID, "gcolChangeDiagnosisHistoryID")
        Me.gcolChangeDiagnosisHistoryID.FieldName = "idfChangeDiagnosisHistory"
        Me.gcolChangeDiagnosisHistoryID.Name = "gcolChangeDiagnosisHistoryID"
        '
        'gcolChangedDate
        '
        resources.ApplyResources(Me.gcolChangedDate, "gcolChangedDate")
        Me.gcolChangedDate.DisplayFormat.FormatString = "g"
        Me.gcolChangedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gcolChangedDate.FieldName = "datChangedDate"
        Me.gcolChangedDate.Name = "gcolChangedDate"
        '
        'gcolOrganization
        '
        resources.ApplyResources(Me.gcolOrganization, "gcolOrganization")
        Me.gcolOrganization.FieldName = "Organization"
        Me.gcolOrganization.Name = "gcolOrganization"
        '
        'gcolPersonName
        '
        resources.ApplyResources(Me.gcolPersonName, "gcolPersonName")
        Me.gcolPersonName.FieldName = "PersonName"
        Me.gcolPersonName.Name = "gcolPersonName"
        '
        'gcolPreviousDiagnosis
        '
        resources.ApplyResources(Me.gcolPreviousDiagnosis, "gcolPreviousDiagnosis")
        Me.gcolPreviousDiagnosis.FieldName = "PreviousDiagnosisName"
        Me.gcolPreviousDiagnosis.Name = "gcolPreviousDiagnosis"
        '
        'gcolChangedDiagnosis
        '
        resources.ApplyResources(Me.gcolChangedDiagnosis, "gcolChangedDiagnosis")
        Me.gcolChangedDiagnosis.FieldName = "CurrentDiagnosisName"
        Me.gcolChangedDiagnosis.Name = "gcolChangedDiagnosis"
        '
        'gcolReason
        '
        resources.ApplyResources(Me.gcolReason, "gcolReason")
        Me.gcolReason.FieldName = "strReason"
        Me.gcolReason.Name = "gcolReason"
        '
        'cbReason
        '
        Me.cbReason.Name = "cbReason"
        '
        'HumanCaseDiagnosisHistory
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.gcChangeDiagnosisHistory)
        Me.Controls.Add(Me.lblHistory)
        Me.FormID = "H14"
        Me.HelpTopicID = "human_case_form"
        Me.MinHeight = 200
        Me.MinWidth = 400
        Me.Name = "HumanCaseDiagnosisHistory"
        Me.ObjectName = "HumanCase"
        Me.ShowCancelButton = False
        Me.ShowDeleteButton = False
        Me.ShowSaveButton = False
        Me.Sizable = True
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.lblHistory, 0)
        Me.Controls.SetChildIndex(Me.gcChangeDiagnosisHistory, 0)
        CType(Me.gcChangeDiagnosisHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvChangeDiagnosisHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbReason, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Overrides"

    Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
        If Me.DbService Is Nothing Then Return Nothing
        Return Me.DbService.ID
    End Function

    Private m_ChangeDiagnosisHistoryView As DataView = Nothing

    Protected Overrides Sub DefineBinding()
        'Add last not saved diagnosis change if it is necessary
        If (Not Me.StartUpParameters Is Nothing) AndAlso _
           (Me.StartUpParameters.ContainsKey("idfChangeDiagnosisHistory")) AndAlso _
           (Me.StartUpParameters.ContainsKey("idfHumanCase")) AndAlso _
           (Me.StartUpParameters.ContainsKey("idfUserID")) AndAlso _
           (Me.StartUpParameters.ContainsKey("idfsPreviousDiagnosis")) AndAlso _
           (Me.StartUpParameters.ContainsKey("idfsCurrentDiagnosis")) AndAlso _
           (Me.StartUpParameters.ContainsKey("datChangedDate")) AndAlso _
           (Me.StartUpParameters.ContainsKey("idfsChangeDiagnosisReason")) AndAlso _
           (Me.StartUpParameters.ContainsKey("idfPerson")) AndAlso _
           (Me.StartUpParameters.ContainsKey("PersonName")) AndAlso _
           (Me.StartUpParameters.ContainsKey("Organization")) AndAlso _
           (Me.StartUpParameters.ContainsKey("PreviousDiagnosisName")) AndAlso _
           (Me.StartUpParameters.ContainsKey("CurrentDiagnosisName")) AndAlso _
           (Not Me.DbService Is Nothing) Then
            If baseDataSet.Tables(HumanCase_DB.tlbChangeDiagnosisHistory).Rows.Find(Me.StartUpParameters("idfChangeDiagnosisHistory")) Is Nothing Then
                Dim rNotSavedChange As DataRow = baseDataSet.Tables(HumanCase_DB.tlbChangeDiagnosisHistory).NewRow()
                rNotSavedChange("idfChangeDiagnosisHistory") = Me.StartUpParameters("idfChangeDiagnosisHistory")
                rNotSavedChange("idfHumanCase") = Me.StartUpParameters("idfHumanCase")
                rNotSavedChange("idfUserID") = Me.StartUpParameters("idfUserID")
                rNotSavedChange("idfsPreviousDiagnosis") = Me.StartUpParameters("idfsPreviousDiagnosis")
                rNotSavedChange("idfsCurrentDiagnosis") = Me.StartUpParameters("idfsCurrentDiagnosis")
                rNotSavedChange("datChangedDate") = Me.StartUpParameters("datChangedDate")
                rNotSavedChange("idfsChangeDiagnosisReason") = Me.StartUpParameters("idfsChangeDiagnosisReason")
                rNotSavedChange("strReason") = Me.StartUpParameters("strReason")
                rNotSavedChange("idfPerson") = Me.StartUpParameters("idfPerson")
                rNotSavedChange("PersonName") = Me.StartUpParameters("PersonName")
                rNotSavedChange("Organization") = Me.StartUpParameters("Organization")
                rNotSavedChange("PreviousDiagnosisName") = Me.StartUpParameters("PreviousDiagnosisName")
                rNotSavedChange("CurrentDiagnosisName") = Me.StartUpParameters("CurrentDiagnosisName")
                baseDataSet.Tables(HumanCase_DB.tlbChangeDiagnosisHistory).Rows.Add(rNotSavedChange)
            End If
            Me.StartUpParameters = Nothing
        End If

        'Bind gcChangeDiagnosisHistory
        m_ChangeDiagnosisHistoryView = New DataView(baseDataSet.Tables(HumanCase_DB.tlbChangeDiagnosisHistory), "", "datChangedDate", DataViewRowState.CurrentRows)
        gcChangeDiagnosisHistory.DataSource = m_ChangeDiagnosisHistoryView
        m_ChangeDiagnosisHistoryView = baseDataSet.Tables(HumanCase_DB.tlbChangeDiagnosisHistory).DefaultView
        Me.gcolChangedDate.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        Core.LookupBinder.BindBaseRepositoryLookup(cbReason, BaseReferenceType.rftChangeDiagnosisReason)

        'Turn on read-only mode
        Me.ReadOnly = True
    End Sub

    Public Overrides Function Post(Optional ByVal postType As bv.common.PostType = bv.common.PostType.FinalPosting) As Boolean
        Return True
    End Function

#End Region


End Class
