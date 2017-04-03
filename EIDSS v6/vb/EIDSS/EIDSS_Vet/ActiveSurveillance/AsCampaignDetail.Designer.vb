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
            CType(Me.dtCampaignEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtCampaignEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtCampaignStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AsCampaignDetail), resources)
            'Form Is Localizable: True
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
            resources.ApplyResources(Me.tpCampaign, "tpCampaign")
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
            Me.txtComments.Properties.AccessibleDescription = resources.GetString("txtComments.Properties.AccessibleDescription")
            Me.txtComments.Properties.AccessibleName = resources.GetString("txtComments.Properties.AccessibleName")
            Me.txtComments.Properties.NullValuePrompt = resources.GetString("txtComments.Properties.NullValuePrompt")
            Me.txtComments.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtComments.Properties.NullValuePromptShowForEmptyValue"), Boolean)
            Me.txtComments.UseOptimizedRendering = True
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
            Me.DiseasesGrid.EmbeddedNavigator.AccessibleDescription = resources.GetString("DiseasesGrid.EmbeddedNavigator.AccessibleDescription")
            Me.DiseasesGrid.EmbeddedNavigator.AccessibleName = resources.GetString("DiseasesGrid.EmbeddedNavigator.AccessibleName")
            Me.DiseasesGrid.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("DiseasesGrid.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
            Me.DiseasesGrid.EmbeddedNavigator.Anchor = CType(resources.GetObject("DiseasesGrid.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.DiseasesGrid.EmbeddedNavigator.BackgroundImage = CType(resources.GetObject("DiseasesGrid.EmbeddedNavigator.BackgroundImage"), System.Drawing.Image)
            Me.DiseasesGrid.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("DiseasesGrid.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
            Me.DiseasesGrid.EmbeddedNavigator.ImeMode = CType(resources.GetObject("DiseasesGrid.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
            Me.DiseasesGrid.EmbeddedNavigator.MaximumSize = CType(resources.GetObject("DiseasesGrid.EmbeddedNavigator.MaximumSize"), System.Drawing.Size)
            Me.DiseasesGrid.EmbeddedNavigator.TextLocation = CType(resources.GetObject("DiseasesGrid.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
            Me.DiseasesGrid.EmbeddedNavigator.ToolTip = resources.GetString("DiseasesGrid.EmbeddedNavigator.ToolTip")
            Me.DiseasesGrid.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("DiseasesGrid.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
            Me.DiseasesGrid.EmbeddedNavigator.ToolTipTitle = resources.GetString("DiseasesGrid.EmbeddedNavigator.ToolTipTitle")
            Me.DiseasesGrid.MainView = Me.DiseasesView
            Me.DiseasesGrid.Name = "DiseasesGrid"
            Me.DiseasesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbDiagnosis, Me.cbSpecies, Me.txtPlannedQty})
            Me.DiseasesGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DiseasesView})
            '
            'DiseasesView
            '
            resources.ApplyResources(Me.DiseasesView, "DiseasesView")
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
            Me.txtPlannedQty.Mask.AutoComplete = CType(resources.GetObject("txtPlannedQty.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
            Me.txtPlannedQty.Mask.BeepOnError = CType(resources.GetObject("txtPlannedQty.Mask.BeepOnError"), Boolean)
            Me.txtPlannedQty.Mask.EditMask = resources.GetString("txtPlannedQty.Mask.EditMask")
            Me.txtPlannedQty.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPlannedQty.Mask.IgnoreMaskBlank"), Boolean)
            Me.txtPlannedQty.Mask.MaskType = CType(resources.GetObject("txtPlannedQty.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
            Me.txtPlannedQty.Mask.PlaceHolder = CType(resources.GetObject("txtPlannedQty.Mask.PlaceHolder"), Char)
            Me.txtPlannedQty.Mask.SaveLiteral = CType(resources.GetObject("txtPlannedQty.Mask.SaveLiteral"), Boolean)
            Me.txtPlannedQty.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPlannedQty.Mask.ShowPlaceHolders"), Boolean)
            Me.txtPlannedQty.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtPlannedQty.Mask.UseMaskAsDisplayFormat"), Boolean)
            Me.txtPlannedQty.MaxValue = New Decimal(New Integer() {1000000, 0, 0, 0})
            Me.txtPlannedQty.Name = "txtPlannedQty"
            '
            'txtCampaignAdministrator
            '
            resources.ApplyResources(Me.txtCampaignAdministrator, "txtCampaignAdministrator")
            Me.txtCampaignAdministrator.Name = "txtCampaignAdministrator"
            Me.txtCampaignAdministrator.Properties.AccessibleDescription = resources.GetString("txtCampaignAdministrator.Properties.AccessibleDescription")
            Me.txtCampaignAdministrator.Properties.AccessibleName = resources.GetString("txtCampaignAdministrator.Properties.AccessibleName")
            Me.txtCampaignAdministrator.Properties.AutoHeight = CType(resources.GetObject("txtCampaignAdministrator.Properties.AutoHeight"), Boolean)
            Me.txtCampaignAdministrator.Properties.Mask.AutoComplete = CType(resources.GetObject("txtCampaignAdministrator.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
            Me.txtCampaignAdministrator.Properties.Mask.BeepOnError = CType(resources.GetObject("txtCampaignAdministrator.Properties.Mask.BeepOnError"), Boolean)
            Me.txtCampaignAdministrator.Properties.Mask.EditMask = resources.GetString("txtCampaignAdministrator.Properties.Mask.EditMask")
            Me.txtCampaignAdministrator.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCampaignAdministrator.Properties.Mask.IgnoreMaskBlank"), Boolean)
            Me.txtCampaignAdministrator.Properties.Mask.MaskType = CType(resources.GetObject("txtCampaignAdministrator.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
            Me.txtCampaignAdministrator.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtCampaignAdministrator.Properties.Mask.PlaceHolder"), Char)
            Me.txtCampaignAdministrator.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCampaignAdministrator.Properties.Mask.SaveLiteral"), Boolean)
            Me.txtCampaignAdministrator.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCampaignAdministrator.Properties.Mask.ShowPlaceHolders"), Boolean)
            Me.txtCampaignAdministrator.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtCampaignAdministrator.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
            Me.txtCampaignAdministrator.Properties.NullValuePrompt = resources.GetString("txtCampaignAdministrator.Properties.NullValuePrompt")
            Me.txtCampaignAdministrator.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtCampaignAdministrator.Properties.NullValuePromptShowForEmptyValue"), Boolean)
            Me.txtCampaignAdministrator.Tag = ""
            '
            'lbCampaignAdministrator
            '
            resources.ApplyResources(Me.lbCampaignAdministrator, "lbCampaignAdministrator")
            Me.lbCampaignAdministrator.Appearance.DisabledImage = CType(resources.GetObject("lbCampaignAdministrator.Appearance.DisabledImage"), System.Drawing.Image)
            Me.lbCampaignAdministrator.Appearance.FontSizeDelta = CType(resources.GetObject("lbCampaignAdministrator.Appearance.FontSizeDelta"), Integer)
            Me.lbCampaignAdministrator.Appearance.FontStyleDelta = CType(resources.GetObject("lbCampaignAdministrator.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
            Me.lbCampaignAdministrator.Appearance.GradientMode = CType(resources.GetObject("lbCampaignAdministrator.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
            Me.lbCampaignAdministrator.Appearance.HoverImage = CType(resources.GetObject("lbCampaignAdministrator.Appearance.HoverImage"), System.Drawing.Image)
            Me.lbCampaignAdministrator.Appearance.Image = CType(resources.GetObject("lbCampaignAdministrator.Appearance.Image"), System.Drawing.Image)
            Me.lbCampaignAdministrator.Appearance.PressedImage = CType(resources.GetObject("lbCampaignAdministrator.Appearance.PressedImage"), System.Drawing.Image)
            Me.lbCampaignAdministrator.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.lbCampaignAdministrator.Name = "lbCampaignAdministrator"
            '
            'dtCampaignEndDate
            '
            resources.ApplyResources(Me.dtCampaignEndDate, "dtCampaignEndDate")
            Me.dtCampaignEndDate.Name = "dtCampaignEndDate"
            Me.dtCampaignEndDate.Properties.AccessibleDescription = resources.GetString("dtCampaignEndDate.Properties.AccessibleDescription")
            Me.dtCampaignEndDate.Properties.AccessibleName = resources.GetString("dtCampaignEndDate.Properties.AccessibleName")
            Me.dtCampaignEndDate.Properties.AutoHeight = CType(resources.GetObject("dtCampaignEndDate.Properties.AutoHeight"), Boolean)
            Me.dtCampaignEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtCampaignEndDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtCampaignEndDate.Properties.CalendarTimeProperties.AccessibleDescription")
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtCampaignEndDate.Properties.CalendarTimeProperties.AccessibleName")
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtCampaignEndDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.BeepOnError"), Boolean)
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.EditMask")
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.PlaceHolder"), Char)
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtCampaignEndDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtCampaignEndDate.Properties.CalendarTimeProperties.NullValuePrompt")
            Me.dtCampaignEndDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtCampaignEndDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyVa" & _
            "lue"), Boolean)
            Me.dtCampaignEndDate.Properties.Mask.AutoComplete = CType(resources.GetObject("dtCampaignEndDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
            Me.dtCampaignEndDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtCampaignEndDate.Properties.Mask.BeepOnError"), Boolean)
            Me.dtCampaignEndDate.Properties.Mask.EditMask = resources.GetString("dtCampaignEndDate.Properties.Mask.EditMask")
            Me.dtCampaignEndDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtCampaignEndDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
            Me.dtCampaignEndDate.Properties.Mask.MaskType = CType(resources.GetObject("dtCampaignEndDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
            Me.dtCampaignEndDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtCampaignEndDate.Properties.Mask.PlaceHolder"), Char)
            Me.dtCampaignEndDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtCampaignEndDate.Properties.Mask.SaveLiteral"), Boolean)
            Me.dtCampaignEndDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtCampaignEndDate.Properties.Mask.ShowPlaceHolders"), Boolean)
            Me.dtCampaignEndDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtCampaignEndDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
            Me.dtCampaignEndDate.Properties.NullValuePrompt = resources.GetString("dtCampaignEndDate.Properties.NullValuePrompt")
            Me.dtCampaignEndDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtCampaignEndDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
            '
            'lbCampaignEndDate
            '
            resources.ApplyResources(Me.lbCampaignEndDate, "lbCampaignEndDate")
            Me.lbCampaignEndDate.Appearance.DisabledImage = CType(resources.GetObject("lbCampaignEndDate.Appearance.DisabledImage"), System.Drawing.Image)
            Me.lbCampaignEndDate.Appearance.FontSizeDelta = CType(resources.GetObject("lbCampaignEndDate.Appearance.FontSizeDelta"), Integer)
            Me.lbCampaignEndDate.Appearance.FontStyleDelta = CType(resources.GetObject("lbCampaignEndDate.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
            Me.lbCampaignEndDate.Appearance.GradientMode = CType(resources.GetObject("lbCampaignEndDate.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
            Me.lbCampaignEndDate.Appearance.HoverImage = CType(resources.GetObject("lbCampaignEndDate.Appearance.HoverImage"), System.Drawing.Image)
            Me.lbCampaignEndDate.Appearance.Image = CType(resources.GetObject("lbCampaignEndDate.Appearance.Image"), System.Drawing.Image)
            Me.lbCampaignEndDate.Appearance.PressedImage = CType(resources.GetObject("lbCampaignEndDate.Appearance.PressedImage"), System.Drawing.Image)
            Me.lbCampaignEndDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.lbCampaignEndDate.Name = "lbCampaignEndDate"
            '
            'dtCampaignStartDate
            '
            resources.ApplyResources(Me.dtCampaignStartDate, "dtCampaignStartDate")
            Me.dtCampaignStartDate.Name = "dtCampaignStartDate"
            Me.dtCampaignStartDate.Properties.AccessibleDescription = resources.GetString("dtCampaignStartDate.Properties.AccessibleDescription")
            Me.dtCampaignStartDate.Properties.AccessibleName = resources.GetString("dtCampaignStartDate.Properties.AccessibleName")
            Me.dtCampaignStartDate.Properties.AutoHeight = CType(resources.GetObject("dtCampaignStartDate.Properties.AutoHeight"), Boolean)
            Me.dtCampaignStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtCampaignStartDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtCampaignStartDate.Properties.CalendarTimeProperties.AccessibleDescription")
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtCampaignStartDate.Properties.CalendarTimeProperties.AccessibleName")
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtCampaignStartDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.BeepOnError"), Boolean)
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.EditMask")
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.PlaceHolder"), Char)
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtCampaignStartDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat" & _
            ""), Boolean)
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtCampaignStartDate.Properties.CalendarTimeProperties.NullValuePrompt")
            Me.dtCampaignStartDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtCampaignStartDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmpty" & _
            "Value"), Boolean)
            Me.dtCampaignStartDate.Properties.Mask.AutoComplete = CType(resources.GetObject("dtCampaignStartDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
            Me.dtCampaignStartDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtCampaignStartDate.Properties.Mask.BeepOnError"), Boolean)
            Me.dtCampaignStartDate.Properties.Mask.EditMask = resources.GetString("dtCampaignStartDate.Properties.Mask.EditMask")
            Me.dtCampaignStartDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtCampaignStartDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
            Me.dtCampaignStartDate.Properties.Mask.MaskType = CType(resources.GetObject("dtCampaignStartDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
            Me.dtCampaignStartDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtCampaignStartDate.Properties.Mask.PlaceHolder"), Char)
            Me.dtCampaignStartDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtCampaignStartDate.Properties.Mask.SaveLiteral"), Boolean)
            Me.dtCampaignStartDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtCampaignStartDate.Properties.Mask.ShowPlaceHolders"), Boolean)
            Me.dtCampaignStartDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtCampaignStartDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
            Me.dtCampaignStartDate.Properties.NullValuePrompt = resources.GetString("dtCampaignStartDate.Properties.NullValuePrompt")
            Me.dtCampaignStartDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtCampaignStartDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
            '
            'lbCampaignStartDate
            '
            resources.ApplyResources(Me.lbCampaignStartDate, "lbCampaignStartDate")
            Me.lbCampaignStartDate.Appearance.DisabledImage = CType(resources.GetObject("lbCampaignStartDate.Appearance.DisabledImage"), System.Drawing.Image)
            Me.lbCampaignStartDate.Appearance.FontSizeDelta = CType(resources.GetObject("lbCampaignStartDate.Appearance.FontSizeDelta"), Integer)
            Me.lbCampaignStartDate.Appearance.FontStyleDelta = CType(resources.GetObject("lbCampaignStartDate.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
            Me.lbCampaignStartDate.Appearance.GradientMode = CType(resources.GetObject("lbCampaignStartDate.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
            Me.lbCampaignStartDate.Appearance.HoverImage = CType(resources.GetObject("lbCampaignStartDate.Appearance.HoverImage"), System.Drawing.Image)
            Me.lbCampaignStartDate.Appearance.Image = CType(resources.GetObject("lbCampaignStartDate.Appearance.Image"), System.Drawing.Image)
            Me.lbCampaignStartDate.Appearance.PressedImage = CType(resources.GetObject("lbCampaignStartDate.Appearance.PressedImage"), System.Drawing.Image)
            Me.lbCampaignStartDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.lbCampaignStartDate.Name = "lbCampaignStartDate"
            '
            'txtCampaignID
            '
            resources.ApplyResources(Me.txtCampaignID, "txtCampaignID")
            Me.txtCampaignID.Name = "txtCampaignID"
            Me.txtCampaignID.Properties.AccessibleDescription = resources.GetString("txtCampaignID.Properties.AccessibleDescription")
            Me.txtCampaignID.Properties.AccessibleName = resources.GetString("txtCampaignID.Properties.AccessibleName")
            Me.txtCampaignID.Properties.AutoHeight = CType(resources.GetObject("txtCampaignID.Properties.AutoHeight"), Boolean)
            Me.txtCampaignID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtCampaignID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
            Me.txtCampaignID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtCampaignID.Properties.Mask.BeepOnError"), Boolean)
            Me.txtCampaignID.Properties.Mask.EditMask = resources.GetString("txtCampaignID.Properties.Mask.EditMask")
            Me.txtCampaignID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCampaignID.Properties.Mask.IgnoreMaskBlank"), Boolean)
            Me.txtCampaignID.Properties.Mask.MaskType = CType(resources.GetObject("txtCampaignID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
            Me.txtCampaignID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtCampaignID.Properties.Mask.PlaceHolder"), Char)
            Me.txtCampaignID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCampaignID.Properties.Mask.SaveLiteral"), Boolean)
            Me.txtCampaignID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCampaignID.Properties.Mask.ShowPlaceHolders"), Boolean)
            Me.txtCampaignID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtCampaignID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
            Me.txtCampaignID.Properties.NullValuePrompt = resources.GetString("txtCampaignID.Properties.NullValuePrompt")
            Me.txtCampaignID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtCampaignID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
            Me.txtCampaignID.Tag = "{R}"
            '
            'lbCampaignID
            '
            resources.ApplyResources(Me.lbCampaignID, "lbCampaignID")
            Me.lbCampaignID.Appearance.DisabledImage = CType(resources.GetObject("lbCampaignID.Appearance.DisabledImage"), System.Drawing.Image)
            Me.lbCampaignID.Appearance.FontSizeDelta = CType(resources.GetObject("lbCampaignID.Appearance.FontSizeDelta"), Integer)
            Me.lbCampaignID.Appearance.FontStyleDelta = CType(resources.GetObject("lbCampaignID.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
            Me.lbCampaignID.Appearance.GradientMode = CType(resources.GetObject("lbCampaignID.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
            Me.lbCampaignID.Appearance.HoverImage = CType(resources.GetObject("lbCampaignID.Appearance.HoverImage"), System.Drawing.Image)
            Me.lbCampaignID.Appearance.Image = CType(resources.GetObject("lbCampaignID.Appearance.Image"), System.Drawing.Image)
            Me.lbCampaignID.Appearance.PressedImage = CType(resources.GetObject("lbCampaignID.Appearance.PressedImage"), System.Drawing.Image)
            Me.lbCampaignID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.lbCampaignID.Name = "lbCampaignID"
            '
            'txtCampaignName
            '
            resources.ApplyResources(Me.txtCampaignName, "txtCampaignName")
            Me.txtCampaignName.Name = "txtCampaignName"
            Me.txtCampaignName.Properties.AccessibleDescription = resources.GetString("txtCampaignName.Properties.AccessibleDescription")
            Me.txtCampaignName.Properties.AccessibleName = resources.GetString("txtCampaignName.Properties.AccessibleName")
            Me.txtCampaignName.Properties.AutoHeight = CType(resources.GetObject("txtCampaignName.Properties.AutoHeight"), Boolean)
            Me.txtCampaignName.Properties.Mask.AutoComplete = CType(resources.GetObject("txtCampaignName.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
            Me.txtCampaignName.Properties.Mask.BeepOnError = CType(resources.GetObject("txtCampaignName.Properties.Mask.BeepOnError"), Boolean)
            Me.txtCampaignName.Properties.Mask.EditMask = resources.GetString("txtCampaignName.Properties.Mask.EditMask")
            Me.txtCampaignName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCampaignName.Properties.Mask.IgnoreMaskBlank"), Boolean)
            Me.txtCampaignName.Properties.Mask.MaskType = CType(resources.GetObject("txtCampaignName.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
            Me.txtCampaignName.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtCampaignName.Properties.Mask.PlaceHolder"), Char)
            Me.txtCampaignName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCampaignName.Properties.Mask.SaveLiteral"), Boolean)
            Me.txtCampaignName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCampaignName.Properties.Mask.ShowPlaceHolders"), Boolean)
            Me.txtCampaignName.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtCampaignName.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
            Me.txtCampaignName.Properties.NullValuePrompt = resources.GetString("txtCampaignName.Properties.NullValuePrompt")
            Me.txtCampaignName.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtCampaignName.Properties.NullValuePromptShowForEmptyValue"), Boolean)
            Me.txtCampaignName.Tag = "{M}"
            '
            'lbCampaignName
            '
            resources.ApplyResources(Me.lbCampaignName, "lbCampaignName")
            Me.lbCampaignName.Appearance.DisabledImage = CType(resources.GetObject("lbCampaignName.Appearance.DisabledImage"), System.Drawing.Image)
            Me.lbCampaignName.Appearance.FontSizeDelta = CType(resources.GetObject("lbCampaignName.Appearance.FontSizeDelta"), Integer)
            Me.lbCampaignName.Appearance.FontStyleDelta = CType(resources.GetObject("lbCampaignName.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
            Me.lbCampaignName.Appearance.GradientMode = CType(resources.GetObject("lbCampaignName.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
            Me.lbCampaignName.Appearance.HoverImage = CType(resources.GetObject("lbCampaignName.Appearance.HoverImage"), System.Drawing.Image)
            Me.lbCampaignName.Appearance.Image = CType(resources.GetObject("lbCampaignName.Appearance.Image"), System.Drawing.Image)
            Me.lbCampaignName.Appearance.PressedImage = CType(resources.GetObject("lbCampaignName.Appearance.PressedImage"), System.Drawing.Image)
            Me.lbCampaignName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.lbCampaignName.Name = "lbCampaignName"
            '
            'cbCampaignType
            '
            resources.ApplyResources(Me.cbCampaignType, "cbCampaignType")
            Me.cbCampaignType.Name = "cbCampaignType"
            Me.cbCampaignType.Properties.AccessibleDescription = resources.GetString("cbCampaignType.Properties.AccessibleDescription")
            Me.cbCampaignType.Properties.AccessibleName = resources.GetString("cbCampaignType.Properties.AccessibleName")
            Me.cbCampaignType.Properties.AutoHeight = CType(resources.GetObject("cbCampaignType.Properties.AutoHeight"), Boolean)
            Me.cbCampaignType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCampaignType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbCampaignType.Properties.NullValuePrompt = resources.GetString("cbCampaignType.Properties.NullValuePrompt")
            Me.cbCampaignType.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbCampaignType.Properties.NullValuePromptShowForEmptyValue"), Boolean)
            Me.cbCampaignType.Tag = "{M}"
            '
            'lbCampaignType
            '
            resources.ApplyResources(Me.lbCampaignType, "lbCampaignType")
            Me.lbCampaignType.Appearance.DisabledImage = CType(resources.GetObject("lbCampaignType.Appearance.DisabledImage"), System.Drawing.Image)
            Me.lbCampaignType.Appearance.FontSizeDelta = CType(resources.GetObject("lbCampaignType.Appearance.FontSizeDelta"), Integer)
            Me.lbCampaignType.Appearance.FontStyleDelta = CType(resources.GetObject("lbCampaignType.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
            Me.lbCampaignType.Appearance.GradientMode = CType(resources.GetObject("lbCampaignType.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
            Me.lbCampaignType.Appearance.HoverImage = CType(resources.GetObject("lbCampaignType.Appearance.HoverImage"), System.Drawing.Image)
            Me.lbCampaignType.Appearance.Image = CType(resources.GetObject("lbCampaignType.Appearance.Image"), System.Drawing.Image)
            Me.lbCampaignType.Appearance.PressedImage = CType(resources.GetObject("lbCampaignType.Appearance.PressedImage"), System.Drawing.Image)
            Me.lbCampaignType.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.lbCampaignType.Name = "lbCampaignType"
            '
            'cbCampaignStatus
            '
            resources.ApplyResources(Me.cbCampaignStatus, "cbCampaignStatus")
            Me.cbCampaignStatus.Name = "cbCampaignStatus"
            Me.cbCampaignStatus.Properties.AccessibleDescription = resources.GetString("cbCampaignStatus.Properties.AccessibleDescription")
            Me.cbCampaignStatus.Properties.AccessibleName = resources.GetString("cbCampaignStatus.Properties.AccessibleName")
            Me.cbCampaignStatus.Properties.AutoHeight = CType(resources.GetObject("cbCampaignStatus.Properties.AutoHeight"), Boolean)
            Me.cbCampaignStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCampaignStatus.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbCampaignStatus.Properties.NullValuePrompt = resources.GetString("cbCampaignStatus.Properties.NullValuePrompt")
            Me.cbCampaignStatus.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbCampaignStatus.Properties.NullValuePromptShowForEmptyValue"), Boolean)
            Me.cbCampaignStatus.Tag = "{M}{alwayseditable}"
            '
            'lbCampaignStatus
            '
            resources.ApplyResources(Me.lbCampaignStatus, "lbCampaignStatus")
            Me.lbCampaignStatus.Appearance.DisabledImage = CType(resources.GetObject("lbCampaignStatus.Appearance.DisabledImage"), System.Drawing.Image)
            Me.lbCampaignStatus.Appearance.FontSizeDelta = CType(resources.GetObject("lbCampaignStatus.Appearance.FontSizeDelta"), Integer)
            Me.lbCampaignStatus.Appearance.FontStyleDelta = CType(resources.GetObject("lbCampaignStatus.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
            Me.lbCampaignStatus.Appearance.GradientMode = CType(resources.GetObject("lbCampaignStatus.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
            Me.lbCampaignStatus.Appearance.HoverImage = CType(resources.GetObject("lbCampaignStatus.Appearance.HoverImage"), System.Drawing.Image)
            Me.lbCampaignStatus.Appearance.Image = CType(resources.GetObject("lbCampaignStatus.Appearance.Image"), System.Drawing.Image)
            Me.lbCampaignStatus.Appearance.PressedImage = CType(resources.GetObject("lbCampaignStatus.Appearance.PressedImage"), System.Drawing.Image)
            Me.lbCampaignStatus.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.lbCampaignStatus.Name = "lbCampaignStatus"
            '
            'tpSessions
            '
            resources.ApplyResources(Me.tpSessions, "tpSessions")
            Me.tpSessions.Controls.Add(Me.btnViewDetails)
            Me.tpSessions.Controls.Add(Me.btnNewSession)
            Me.tpSessions.Controls.Add(Me.btnSelectSession)
            Me.tpSessions.Controls.Add(Me.btnRemoveSession)
            Me.tpSessions.Controls.Add(Me.SessionsGrid)
            Me.tpSessions.Name = "tpSessions"
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
            Me.SessionsGrid.Cursor = System.Windows.Forms.Cursors.Default
            Me.SessionsGrid.EmbeddedNavigator.AccessibleDescription = resources.GetString("SessionsGrid.EmbeddedNavigator.AccessibleDescription")
            Me.SessionsGrid.EmbeddedNavigator.AccessibleName = resources.GetString("SessionsGrid.EmbeddedNavigator.AccessibleName")
            Me.SessionsGrid.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("SessionsGrid.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
            Me.SessionsGrid.EmbeddedNavigator.Anchor = CType(resources.GetObject("SessionsGrid.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.SessionsGrid.EmbeddedNavigator.BackgroundImage = CType(resources.GetObject("SessionsGrid.EmbeddedNavigator.BackgroundImage"), System.Drawing.Image)
            Me.SessionsGrid.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("SessionsGrid.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
            Me.SessionsGrid.EmbeddedNavigator.ImeMode = CType(resources.GetObject("SessionsGrid.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
            Me.SessionsGrid.EmbeddedNavigator.MaximumSize = CType(resources.GetObject("SessionsGrid.EmbeddedNavigator.MaximumSize"), System.Drawing.Size)
            Me.SessionsGrid.EmbeddedNavigator.TextLocation = CType(resources.GetObject("SessionsGrid.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
            Me.SessionsGrid.EmbeddedNavigator.ToolTip = resources.GetString("SessionsGrid.EmbeddedNavigator.ToolTip")
            Me.SessionsGrid.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("SessionsGrid.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
            Me.SessionsGrid.EmbeddedNavigator.ToolTipTitle = resources.GetString("SessionsGrid.EmbeddedNavigator.ToolTipTitle")
            Me.SessionsGrid.MainView = Me.SessionsView
            Me.SessionsGrid.Name = "SessionsGrid"
            Me.SessionsGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbRegion})
            Me.SessionsGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SessionsView})
            '
            'SessionsView
            '
            resources.ApplyResources(Me.SessionsView, "SessionsView")
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
            Me.colRegion.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
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
            resources.ApplyResources(Me.tpConclusion, "tpConclusion")
            Me.tpConclusion.Controls.Add(Me.txtConclusion)
            Me.tpConclusion.Name = "tpConclusion"
            '
            'txtConclusion
            '
            resources.ApplyResources(Me.txtConclusion, "txtConclusion")
            Me.txtConclusion.Name = "txtConclusion"
            Me.txtConclusion.Properties.AccessibleDescription = resources.GetString("txtConclusion.Properties.AccessibleDescription")
            Me.txtConclusion.Properties.AccessibleName = resources.GetString("txtConclusion.Properties.AccessibleName")
            Me.txtConclusion.Properties.NullValuePrompt = resources.GetString("txtConclusion.Properties.NullValuePrompt")
            Me.txtConclusion.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtConclusion.Properties.NullValuePromptShowForEmptyValue"), Boolean)
            Me.txtConclusion.UseOptimizedRendering = True
            '
            'btnReport
            '
            resources.ApplyResources(Me.btnReport, "btnReport")
            Me.btnReport.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
            Me.btnReport.ImageIndex = 0
            Me.btnReport.Name = "btnReport"
            Me.btnReport.PopUpMenu = Nothing
            Me.btnReport.Tag = "{Immovable}{AlwaysEditable}"
            '
            'AsCampaignDetail
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.btnReport)
            Me.Controls.Add(Me.tcASCampaign)
            Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
            Me.FormID = "V16"
            Me.HelpTopicID = "VC_V16"
            Me.KeyFieldName = "idfCampaign"
            Me.LeftIcon = Global.eidss.My.Resources.Resources.Active_Surviellance_Campaign__large_
            Me.Name = "AsCampaignDetail"
            Me.ObjectName = "AsCampaign"
            Me.Status = bv.common.win.FormStatus.Draft
            Me.TableName = "AsCampaign"
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
            CType(Me.dtCampaignEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtCampaignEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtCampaignStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
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