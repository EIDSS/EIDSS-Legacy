Namespace ActiveSurveillance
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AsCampaignDetail
        Inherits bv.common.win.BaseDetailForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsCampaignDetail))
            Me.tcASCampaign = New DevExpress.XtraTab.XtraTabControl()
            Me.tpCampaign = New DevExpress.XtraTab.XtraTabPage()
            Me.grpComments = New DevExpress.XtraEditors.GroupControl()
            Me.txtComments = New DevExpress.XtraEditors.MemoEdit()
            Me.grpDiseaseList = New DevExpress.XtraEditors.GroupControl()
            Me.btnDown = New DevExpress.XtraEditors.SimpleButton()
            Me.btnUp = New DevExpress.XtraEditors.SimpleButton()
            Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
            Me.DiseasesGrid = New DevExpress.XtraGrid.GridControl()
            Me.DiseasesView = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbDiagnosis = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.colSpecies = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbSpecies = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.colPlannedQty = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.txtPlannedQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
            Me.txtCampaignAdministrator = New DevExpress.XtraEditors.TextEdit()
            Me.lbCampaignAdministrator = New DevExpress.XtraEditors.LabelControl()
            Me.dtCampaignEndDate = New DevExpress.XtraEditors.DateEdit()
            Me.lbCampaignEndDate = New DevExpress.XtraEditors.LabelControl()
            Me.dtCampaignStartDate = New DevExpress.XtraEditors.DateEdit()
            Me.lbCampaignStartDate = New DevExpress.XtraEditors.LabelControl()
            Me.txtCampaignID = New DevExpress.XtraEditors.TextEdit()
            Me.lbCampaignID = New DevExpress.XtraEditors.LabelControl()
            Me.txtCampaignName = New DevExpress.XtraEditors.TextEdit()
            Me.lbCampaignName = New DevExpress.XtraEditors.LabelControl()
            Me.cbCampaignType = New DevExpress.XtraEditors.LookUpEdit()
            Me.lbCampaignType = New DevExpress.XtraEditors.LabelControl()
            Me.cbCampaignStatus = New DevExpress.XtraEditors.LookUpEdit()
            Me.lbCampaignStatus = New DevExpress.XtraEditors.LabelControl()
            Me.tpSessions = New DevExpress.XtraTab.XtraTabPage()
            Me.btnViewDetails = New DevExpress.XtraEditors.SimpleButton()
            Me.btnNewSession = New DevExpress.XtraEditors.SimpleButton()
            Me.btnSelectSession = New DevExpress.XtraEditors.SimpleButton()
            Me.btnRemoveSession = New DevExpress.XtraEditors.SimpleButton()
            Me.SessionsGrid = New DevExpress.XtraGrid.GridControl()
            Me.SessionsView = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colSessionID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colRegion = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colRayon = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colSettlement = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colDisease = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colStartDate = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colEndDate = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colStatus = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbRegion = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.tpConclusion = New DevExpress.XtraTab.XtraTabPage()
            Me.txtConclusion = New DevExpress.XtraEditors.MemoEdit()
            Me.btnReport = New bv.common.win.PopUpButton()
            CType(Me.tcASCampaign, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tcASCampaign.SuspendLayout()
            Me.tpCampaign.SuspendLayout()
            CType(Me.grpComments, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpComments.SuspendLayout()
            CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grpDiseaseList, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpDiseaseList.SuspendLayout()
            CType(Me.DiseasesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DiseasesView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtPlannedQty, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtCampaignAdministrator.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtCampaignEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtCampaignEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtCampaignStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtCampaignStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtCampaignID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtCampaignName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbCampaignType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbCampaignStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpSessions.SuspendLayout()
            CType(Me.SessionsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SessionsView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbRegion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpConclusion.SuspendLayout()
            CType(Me.txtConclusion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tcASCampaign
            '
            resources.ApplyResources(Me.tcASCampaign, "tcASCampaign")
            Me.tcASCampaign.Name = "tcASCampaign"
            Me.tcASCampaign.SelectedTabPage = Me.tpCampaign
            Me.tcASCampaign.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tpCampaign, Me.tpSessions, Me.tpConclusion})
            '
            'tpCampaign
            '
            Me.tpCampaign.Controls.Add(Me.grpComments)
            Me.tpCampaign.Controls.Add(Me.grpDiseaseList)
            Me.tpCampaign.Controls.Add(Me.txtCampaignAdministrator)
            Me.tpCampaign.Controls.Add(Me.lbCampaignAdministrator)
            Me.tpCampaign.Controls.Add(Me.dtCampaignEndDate)
            Me.tpCampaign.Controls.Add(Me.lbCampaignEndDate)
            Me.tpCampaign.Controls.Add(Me.dtCampaignStartDate)
            Me.tpCampaign.Controls.Add(Me.lbCampaignStartDate)
            Me.tpCampaign.Controls.Add(Me.txtCampaignID)
            Me.tpCampaign.Controls.Add(Me.lbCampaignID)
            Me.tpCampaign.Controls.Add(Me.txtCampaignName)
            Me.tpCampaign.Controls.Add(Me.lbCampaignName)
            Me.tpCampaign.Controls.Add(Me.cbCampaignType)
            Me.tpCampaign.Controls.Add(Me.lbCampaignType)
            Me.tpCampaign.Controls.Add(Me.cbCampaignStatus)
            Me.tpCampaign.Controls.Add(Me.lbCampaignStatus)
            Me.tpCampaign.Name = "tpCampaign"
            resources.ApplyResources(Me.tpCampaign, "tpCampaign")
            '
            'grpComments
            '
            resources.ApplyResources(Me.grpComments, "grpComments")
            Me.grpComments.Controls.Add(Me.txtComments)
            Me.grpComments.Name = "grpComments"
            '
            'txtComments
            '
            resources.ApplyResources(Me.txtComments, "txtComments")
            Me.txtComments.Name = "txtComments"
            '
            'grpDiseaseList
            '
            resources.ApplyResources(Me.grpDiseaseList, "grpDiseaseList")
            Me.grpDiseaseList.Controls.Add(Me.btnDown)
            Me.grpDiseaseList.Controls.Add(Me.btnUp)
            Me.grpDiseaseList.Controls.Add(Me.btnDelete)
            Me.grpDiseaseList.Controls.Add(Me.DiseasesGrid)
            Me.grpDiseaseList.Name = "grpDiseaseList"
            '
            'btnDown
            '
            resources.ApplyResources(Me.btnDown, "btnDown")
            Me.btnDown.Image = Global.eidss.My.Resources.Resources.doun
            Me.btnDown.Name = "btnDown"
            '
            'btnUp
            '
            resources.ApplyResources(Me.btnUp, "btnUp")
            Me.btnUp.Image = Global.eidss.My.Resources.Resources.up
            Me.btnUp.Name = "btnUp"
            '
            'btnDelete
            '
            resources.ApplyResources(Me.btnDelete, "btnDelete")
            Me.btnDelete.Image = Global.eidss.My.Resources.Resources.Delete_Remove
            Me.btnDelete.Name = "btnDelete"
            '
            'DiseasesGrid
            '
            resources.ApplyResources(Me.DiseasesGrid, "DiseasesGrid")
            Me.DiseasesGrid.MainView = Me.DiseasesView
            Me.DiseasesGrid.Name = "DiseasesGrid"
            Me.DiseasesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbDiagnosis, Me.cbSpecies, Me.txtPlannedQty})
            Me.DiseasesGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DiseasesView})
            '
            'DiseasesView
            '
            Me.DiseasesView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDiagnosis, Me.colSpecies, Me.colPlannedQty})
            Me.DiseasesView.GridControl = Me.DiseasesGrid
            Me.DiseasesView.Name = "DiseasesView"
            Me.DiseasesView.OptionsNavigation.EnterMoveNextColumn = True
            Me.DiseasesView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DiseasesView.OptionsView.ShowGroupPanel = False
            '
            'colDiagnosis
            '
            resources.ApplyResources(Me.colDiagnosis, "colDiagnosis")
            Me.colDiagnosis.ColumnEdit = Me.cbDiagnosis
            Me.colDiagnosis.FieldName = "idfsDiagnosis"
            Me.colDiagnosis.Name = "colDiagnosis"
            '
            'cbDiagnosis
            '
            resources.ApplyResources(Me.cbDiagnosis, "cbDiagnosis")
            Me.cbDiagnosis.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosis.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbDiagnosis.Name = "cbDiagnosis"
            '
            'colSpecies
            '
            resources.ApplyResources(Me.colSpecies, "colSpecies")
            Me.colSpecies.ColumnEdit = Me.cbSpecies
            Me.colSpecies.FieldName = "idfsSpeciesType"
            Me.colSpecies.Name = "colSpecies"
            '
            'cbSpecies
            '
            resources.ApplyResources(Me.cbSpecies, "cbSpecies")
            Me.cbSpecies.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSpecies.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbSpecies.Name = "cbSpecies"
            '
            'colPlannedQty
            '
            resources.ApplyResources(Me.colPlannedQty, "colPlannedQty")
            Me.colPlannedQty.ColumnEdit = Me.txtPlannedQty
            Me.colPlannedQty.FieldName = "intPlannedNumber"
            Me.colPlannedQty.Name = "colPlannedQty"
            '
            'txtPlannedQty
            '
            resources.ApplyResources(Me.txtPlannedQty, "txtPlannedQty")
            Me.txtPlannedQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.txtPlannedQty.IsFloatValue = False
            Me.txtPlannedQty.Mask.EditMask = resources.GetString("txtPlannedQty.Mask.EditMask")
            Me.txtPlannedQty.MaxValue = New Decimal(New Integer() {1000000, 0, 0, 0})
            Me.txtPlannedQty.Name = "txtPlannedQty"
            '
            'txtCampaignAdministrator
            '
            resources.ApplyResources(Me.txtCampaignAdministrator, "txtCampaignAdministrator")
            Me.txtCampaignAdministrator.Name = "txtCampaignAdministrator"
            Me.txtCampaignAdministrator.Tag = ""
            '
            'lbCampaignAdministrator
            '
            Me.lbCampaignAdministrator.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            resources.ApplyResources(Me.lbCampaignAdministrator, "lbCampaignAdministrator")
            Me.lbCampaignAdministrator.Name = "lbCampaignAdministrator"
            '
            'dtCampaignEndDate
            '
            resources.ApplyResources(Me.dtCampaignEndDate, "dtCampaignEndDate")
            Me.dtCampaignEndDate.Name = "dtCampaignEndDate"
            Me.dtCampaignEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtCampaignEndDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.dtCampaignEndDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            '
            'lbCampaignEndDate
            '
            Me.lbCampaignEndDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            resources.ApplyResources(Me.lbCampaignEndDate, "lbCampaignEndDate")
            Me.lbCampaignEndDate.Name = "lbCampaignEndDate"
            '
            'dtCampaignStartDate
            '
            resources.ApplyResources(Me.dtCampaignStartDate, "dtCampaignStartDate")
            Me.dtCampaignStartDate.Name = "dtCampaignStartDate"
            Me.dtCampaignStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtCampaignStartDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.dtCampaignStartDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            '
            'lbCampaignStartDate
            '
            Me.lbCampaignStartDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            resources.ApplyResources(Me.lbCampaignStartDate, "lbCampaignStartDate")
            Me.lbCampaignStartDate.Name = "lbCampaignStartDate"
            '
            'txtCampaignID
            '
            resources.ApplyResources(Me.txtCampaignID, "txtCampaignID")
            Me.txtCampaignID.Name = "txtCampaignID"
            Me.txtCampaignID.Tag = "{R}"
            '
            'lbCampaignID
            '
            Me.lbCampaignID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            resources.ApplyResources(Me.lbCampaignID, "lbCampaignID")
            Me.lbCampaignID.Name = "lbCampaignID"
            '
            'txtCampaignName
            '
            resources.ApplyResources(Me.txtCampaignName, "txtCampaignName")
            Me.txtCampaignName.Name = "txtCampaignName"
            Me.txtCampaignName.Tag = "{M}"
            '
            'lbCampaignName
            '
            Me.lbCampaignName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            resources.ApplyResources(Me.lbCampaignName, "lbCampaignName")
            Me.lbCampaignName.Name = "lbCampaignName"
            '
            'cbCampaignType
            '
            resources.ApplyResources(Me.cbCampaignType, "cbCampaignType")
            Me.cbCampaignType.Name = "cbCampaignType"
            Me.cbCampaignType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCampaignType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbCampaignType.Tag = "{M}"
            '
            'lbCampaignType
            '
            Me.lbCampaignType.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            resources.ApplyResources(Me.lbCampaignType, "lbCampaignType")
            Me.lbCampaignType.Name = "lbCampaignType"
            '
            'cbCampaignStatus
            '
            resources.ApplyResources(Me.cbCampaignStatus, "cbCampaignStatus")
            Me.cbCampaignStatus.Name = "cbCampaignStatus"
            Me.cbCampaignStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCampaignStatus.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbCampaignStatus.Tag = "{M}{alwayseditable}"
            '
            'lbCampaignStatus
            '
            Me.lbCampaignStatus.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            resources.ApplyResources(Me.lbCampaignStatus, "lbCampaignStatus")
            Me.lbCampaignStatus.Name = "lbCampaignStatus"
            '
            'tpSessions
            '
            Me.tpSessions.Controls.Add(Me.btnViewDetails)
            Me.tpSessions.Controls.Add(Me.btnNewSession)
            Me.tpSessions.Controls.Add(Me.btnSelectSession)
            Me.tpSessions.Controls.Add(Me.btnRemoveSession)
            Me.tpSessions.Controls.Add(Me.SessionsGrid)
            Me.tpSessions.Name = "tpSessions"
            resources.ApplyResources(Me.tpSessions, "tpSessions")
            '
            'btnViewDetails
            '
            resources.ApplyResources(Me.btnViewDetails, "btnViewDetails")
            Me.btnViewDetails.Image = Global.eidss.My.Resources.Resources.View1
            Me.btnViewDetails.Name = "btnViewDetails"
            '
            'btnNewSession
            '
            resources.ApplyResources(Me.btnNewSession, "btnNewSession")
            Me.btnNewSession.Image = Global.eidss.My.Resources.Resources.add
            Me.btnNewSession.Name = "btnNewSession"
            '
            'btnSelectSession
            '
            resources.ApplyResources(Me.btnSelectSession, "btnSelectSession")
            Me.btnSelectSession.Image = Global.eidss.My.Resources.Resources.Select2
            Me.btnSelectSession.Name = "btnSelectSession"
            '
            'btnRemoveSession
            '
            resources.ApplyResources(Me.btnRemoveSession, "btnRemoveSession")
            Me.btnRemoveSession.Image = Global.eidss.My.Resources.Resources.Delete_Remove
            Me.btnRemoveSession.Name = "btnRemoveSession"
            '
            'SessionsGrid
            '
            resources.ApplyResources(Me.SessionsGrid, "SessionsGrid")
            Me.SessionsGrid.MainView = Me.SessionsView
            Me.SessionsGrid.Name = "SessionsGrid"
            Me.SessionsGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbRegion})
            Me.SessionsGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SessionsView})
            '
            'SessionsView
            '
            Me.SessionsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSessionID, Me.colRegion, Me.colRayon, Me.colSettlement, Me.colDisease, Me.colStartDate, Me.colEndDate, Me.colStatus})
            Me.SessionsView.GridControl = Me.SessionsGrid
            Me.SessionsView.Name = "SessionsView"
            Me.SessionsView.OptionsBehavior.Editable = False
            Me.SessionsView.OptionsNavigation.EnterMoveNextColumn = True
            Me.SessionsView.OptionsView.ShowGroupPanel = False
            '
            'colSessionID
            '
            resources.ApplyResources(Me.colSessionID, "colSessionID")
            Me.colSessionID.FieldName = "strMonitoringSessionID"
            Me.colSessionID.Name = "colSessionID"
            '
            'colRegion
            '
            resources.ApplyResources(Me.colRegion, "colRegion")
            Me.colRegion.FieldName = "strRegion"
            Me.colRegion.Name = "colRegion"
            '
            'colRayon
            '
            resources.ApplyResources(Me.colRayon, "colRayon")
            Me.colRayon.FieldName = "strRayon"
            Me.colRayon.Name = "colRayon"
            '
            'colSettlement
            '
            resources.ApplyResources(Me.colSettlement, "colSettlement")
            Me.colSettlement.FieldName = "strSettlement"
            Me.colSettlement.Name = "colSettlement"
            '
            'colDisease
            '
            resources.ApplyResources(Me.colDisease, "colDisease")
            Me.colDisease.FieldName = "strDisease"
            Me.colDisease.Name = "colDisease"
            '
            'colStartDate
            '
            resources.ApplyResources(Me.colStartDate, "colStartDate")
            Me.colStartDate.FieldName = "datStartDate"
            Me.colStartDate.Name = "colStartDate"
            '
            'colEndDate
            '
            resources.ApplyResources(Me.colEndDate, "colEndDate")
            Me.colEndDate.FieldName = "datEndDate"
            Me.colEndDate.Name = "colEndDate"
            '
            'colStatus
            '
            resources.ApplyResources(Me.colStatus, "colStatus")
            Me.colStatus.FieldName = "strStatus"
            Me.colStatus.Name = "colStatus"
            '
            'cbRegion
            '
            resources.ApplyResources(Me.cbRegion, "cbRegion")
            Me.cbRegion.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRegion.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbRegion.Name = "cbRegion"
            '
            'tpConclusion
            '
            Me.tpConclusion.Controls.Add(Me.txtConclusion)
            Me.tpConclusion.Name = "tpConclusion"
            resources.ApplyResources(Me.tpConclusion, "tpConclusion")
            '
            'txtConclusion
            '
            resources.ApplyResources(Me.txtConclusion, "txtConclusion")
            Me.txtConclusion.Name = "txtConclusion"
            '
            'btnReport
            '
            Me.btnReport.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
            resources.ApplyResources(Me.btnReport, "btnReport")
            Me.btnReport.Name = "btnReport"
            Me.btnReport.PopUpMenu = Nothing
            Me.btnReport.Tag = "{Immovable}{AlwaysEditable}"
            '
            'AsCampaignDetail
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.btnReport)
            Me.Controls.Add(Me.tcASCampaign)
            Me.FormID = "V16"
            Me.HelpTopicID = "AS_campaign_form"
            Me.KeyFieldName = "idfCampaign"
            Me.LeftIcon = Global.eidss.My.Resources.Resources.Active_Surviellance_Campaign__large_
            Me.Name = "AsCampaignDetail"
            Me.ObjectName = "AsCampaign"
            Me.TableName = "AsCampaign"
            Me.Controls.SetChildIndex(Me.cmdOk, 0)
            Me.Controls.SetChildIndex(Me.tcASCampaign, 0)
            Me.Controls.SetChildIndex(Me.btnReport, 0)
            CType(Me.tcASCampaign, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tcASCampaign.ResumeLayout(False)
            Me.tpCampaign.ResumeLayout(False)
            CType(Me.grpComments, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpComments.ResumeLayout(False)
            CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grpDiseaseList, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpDiseaseList.ResumeLayout(False)
            CType(Me.DiseasesGrid, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DiseasesView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtPlannedQty, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtCampaignAdministrator.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtCampaignEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtCampaignEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtCampaignStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtCampaignStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtCampaignID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtCampaignName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbCampaignType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbCampaignStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpSessions.ResumeLayout(False)
            CType(Me.SessionsGrid, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SessionsView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbRegion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpConclusion.ResumeLayout(False)
            CType(Me.txtConclusion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents tcASCampaign As DevExpress.XtraTab.XtraTabControl
        Friend WithEvents tpSessions As DevExpress.XtraTab.XtraTabPage
        Friend WithEvents tpCampaign As DevExpress.XtraTab.XtraTabPage
        Friend WithEvents tpConclusion As DevExpress.XtraTab.XtraTabPage
        Friend WithEvents grpComments As DevExpress.XtraEditors.GroupControl
        Friend WithEvents grpDiseaseList As DevExpress.XtraEditors.GroupControl
        Friend WithEvents btnDown As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnUp As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents DiseasesGrid As DevExpress.XtraGrid.GridControl
        Friend WithEvents DiseasesView As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents txtCampaignAdministrator As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lbCampaignAdministrator As DevExpress.XtraEditors.LabelControl
        Friend WithEvents cbCampaignStatus As DevExpress.XtraEditors.LookUpEdit
        Friend WithEvents lbCampaignStatus As DevExpress.XtraEditors.LabelControl
        Friend WithEvents dtCampaignEndDate As DevExpress.XtraEditors.DateEdit
        Friend WithEvents lbCampaignEndDate As DevExpress.XtraEditors.LabelControl
        Friend WithEvents dtCampaignStartDate As DevExpress.XtraEditors.DateEdit
        Friend WithEvents lbCampaignStartDate As DevExpress.XtraEditors.LabelControl
        Friend WithEvents cbCampaignType As DevExpress.XtraEditors.LookUpEdit
        Friend WithEvents lbCampaignType As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtCampaignName As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lbCampaignName As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtCampaignID As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lbCampaignID As DevExpress.XtraEditors.LabelControl
        Friend WithEvents SessionsGrid As DevExpress.XtraGrid.GridControl
        Friend WithEvents SessionsView As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents txtComments As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents txtConclusion As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents colDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colSessionID As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colRegion As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbRegion As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colRayon As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colSettlement As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colDisease As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colStartDate As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colStatus As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents btnReport As bv.common.win.PopUpButton
        Friend WithEvents colSpecies As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbSpecies As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colPlannedQty As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents txtPlannedQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Friend WithEvents colEndDate As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents btnViewDetails As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnNewSession As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnSelectSession As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnRemoveSession As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace