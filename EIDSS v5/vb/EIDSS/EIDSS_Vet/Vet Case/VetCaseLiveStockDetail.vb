Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums

Public Class VetCaseLiveStockDetail
    Inherits bv.common.win.BaseDetailForm

#Region " Windows Form Designer generated code "
    Public VetCaseDbService As VetCase_DB

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitCustomMandatoryFields()
        VetCaseDbService = New VetCase_DB
        VetCaseDbService.CaseType = CaseType.Livestock
        DbService = VetCaseDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoVetCase, AuditTable.tlbCase)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.VetCase

        'Add any initialization after the InitializeComponent() call
        CaseSamplesPanel1.HACode = HACode.Livestock
        VetDiagnosisPanel1.CaseKind = CaseType.Livestock
        VaccinationPanel1.CaseKind = CaseType.Livestock
        FarmTreePanel1.CaseKind = CaseType.Livestock
        CaseTestsPanel1.HACode = HACode.Livestock
        PensideTestPanel1.HACode = HACode.Livestock
        HerdTab.Text = EidssMessages.Get("titleHerdEpiClinicalSigns", "Herd Epi/Clinical Signs/Control Measures")
        VetStatusPanel1.UseParentDataset = True
        VetCaseRegistrationPanel1.UseParentDataset = True
        VetControlMeasurePanel1.UseParentDataset = True
        VetStatusPanel1.UseParentDataset = True
        VetDiagnosisPanel1.UseParentDataset = True
        FarmPanel.HidePersonalData = True
        FarmTreePanel1.HidePersonalData = True
        RegisterChildObject(VetControlMeasurePanel1, RelatedPostOrder.PostLast)
        RegisterChildObject(FarmPanel, RelatedPostOrder.PostFirst)
        RegisterChildObject(VetCaseRegistrationPanel1, RelatedPostOrder.SkipPost)
        RegisterChildObject(VetStatusPanel1, RelatedPostOrder.SkipPost)
        RegisterChildObject(FarmTreePanel1, RelatedPostOrder.PostLast)
        RegisterChildObject(VetCaseAnimalsPanel1, RelatedPostOrder.PostLast)
        RegisterChildObject(LivestockFarmProductionControl1, RelatedPostOrder.PostLast)
        RegisterChildObject(CaseSamplesPanel1, RelatedPostOrder.PostLast)
        RegisterChildObject(CaseTestsPanel1, RelatedPostOrder.PostLast)
        RegisterChildObject(VetDiagnosisPanel1, RelatedPostOrder.SkipPost)
        RegisterChildObject(VaccinationPanel1, RelatedPostOrder.PostLast)
        RegisterChildObject(PensideTestPanel1, RelatedPostOrder.PostLast)
        RegisterChildObject(CaseLog1, RelatedPostOrder.PostLast)
        Me.m_RelatedLists = New String() {"VetCaseListItem", "FarmListItem"}
        FarmPanel.InitCustomMandatoryFields()

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
    Friend WithEvents TabContol As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents DemographicsPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents HerdTab As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents DiagnosisPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents AnimalsPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SamplesPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabTestPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents FarmGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents VetCaseRegistrationPanel1 As EIDSS.VetCaseRegistrationPanel
    Friend WithEvents FarmTreePanel1 As EIDSS.FarmTreePanel
    Friend WithEvents VetDiagnosisPanel1 As EIDSS.VetDiagnosisPanel
    Friend WithEvents VetCaseAnimalsPanel1 As EIDSS.VetCaseAnimalsPanel
    Friend WithEvents FarmPanel As EIDSS.FarmPanel
    Friend WithEvents LivestockFarmProductionControl1 As EIDSS.LivestockFarmProductionControl
    Friend WithEvents VetStatusPanel1 As EIDSS.VetStatusPanel
    Friend WithEvents CaseSamplesPanel1 As EIDSS.VetCaseSamplesPanel
    Friend WithEvents CaseTestsPanel1 As EIDSS.CaseTestsPanel
    Friend WithEvents CommentsGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbNotesComment As System.Windows.Forms.Label
    Friend WithEvents txtCaseNotes As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents PopUpButton1 As bv.common.win.PopUpButton
    Friend WithEvents cmReports As System.Windows.Forms.ContextMenu
    Friend WithEvents VaccinationPanel1 As EIDSS.VaccinationPanel
    Friend WithEvents PensideTestPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PensideTestPanel1 As EIDSS.PensideTestPanel
    Friend WithEvents CaseLogTab As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents CaseLog1 As EIDSS.CaseLog
    Friend WithEvents VetControlMeasurePanel1 As EIDSS.VetControlMeasurePanel
    Friend WithEvents cbTestsConducted As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbTestsConducted As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetCaseLiveStockDetail))
        Me.TabContol = New DevExpress.XtraTab.XtraTabControl()
        Me.DemographicsPage = New DevExpress.XtraTab.XtraTabPage()
        Me.VetCaseRegistrationPanel1 = New EIDSS.VetCaseRegistrationPanel()
        Me.FarmGroup = New DevExpress.XtraEditors.GroupControl()
        Me.FarmPanel = New EIDSS.FarmPanel()
        Me.LivestockFarmProductionControl1 = New EIDSS.LivestockFarmProductionControl()
        Me.HerdTab = New DevExpress.XtraTab.XtraTabPage()
        Me.VetControlMeasurePanel1 = New EIDSS.VetControlMeasurePanel()
        Me.FarmTreePanel1 = New EIDSS.FarmTreePanel()
        Me.DiagnosisPage = New DevExpress.XtraTab.XtraTabPage()
        Me.VaccinationPanel1 = New EIDSS.VaccinationPanel()
        Me.VetDiagnosisPanel1 = New EIDSS.VetDiagnosisPanel()
        Me.CommentsGroup = New DevExpress.XtraEditors.GroupControl()
        Me.lbNotesComment = New System.Windows.Forms.Label()
        Me.txtCaseNotes = New DevExpress.XtraEditors.MemoEdit()
        Me.AnimalsPage = New DevExpress.XtraTab.XtraTabPage()
        Me.VetCaseAnimalsPanel1 = New EIDSS.VetCaseAnimalsPanel()
        Me.SamplesPage = New DevExpress.XtraTab.XtraTabPage()
        Me.CaseSamplesPanel1 = New EIDSS.VetCaseSamplesPanel()
        Me.PensideTestPage = New DevExpress.XtraTab.XtraTabPage()
        Me.PensideTestPanel1 = New EIDSS.PensideTestPanel()
        Me.LabTestPage = New DevExpress.XtraTab.XtraTabPage()
        Me.cbTestsConducted = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbTestsConducted = New DevExpress.XtraEditors.LabelControl()
        Me.CaseTestsPanel1 = New EIDSS.CaseTestsPanel()
        Me.CaseLogTab = New DevExpress.XtraTab.XtraTabPage()
        Me.CaseLog1 = New EIDSS.CaseLog()
        Me.VetStatusPanel1 = New EIDSS.VetStatusPanel()
        Me.PopUpButton1 = New bv.common.win.PopUpButton()
        Me.cmReports = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        CType(Me.TabContol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabContol.SuspendLayout()
        Me.DemographicsPage.SuspendLayout()
        CType(Me.FarmGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FarmGroup.SuspendLayout()
        Me.HerdTab.SuspendLayout()
        Me.DiagnosisPage.SuspendLayout()
        CType(Me.CommentsGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CommentsGroup.SuspendLayout()
        CType(Me.txtCaseNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnimalsPage.SuspendLayout()
        Me.SamplesPage.SuspendLayout()
        Me.PensideTestPage.SuspendLayout()
        Me.LabTestPage.SuspendLayout()
        CType(Me.cbTestsConducted.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CaseLogTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabContol
        '
        Me.TabContol.Appearance.Font = CType(resources.GetObject("TabContol.Appearance.Font"), System.Drawing.Font)
        Me.TabContol.Appearance.Options.UseFont = True
        Me.TabContol.AppearancePage.Header.Font = CType(resources.GetObject("TabContol.AppearancePage.Header.Font"), System.Drawing.Font)
        Me.TabContol.AppearancePage.Header.Options.UseFont = True
        resources.ApplyResources(Me.TabContol, "TabContol")
        Me.TabContol.Name = "TabContol"
        Me.TabContol.SelectedTabPage = Me.DemographicsPage
        Me.TabContol.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.DemographicsPage, Me.HerdTab, Me.DiagnosisPage, Me.AnimalsPage, Me.SamplesPage, Me.PensideTestPage, Me.LabTestPage, Me.CaseLogTab})
        '
        'DemographicsPage
        '
        Me.DemographicsPage.Appearance.Header.Font = CType(resources.GetObject("DemographicsPage.Appearance.Header.Font"), System.Drawing.Font)
        Me.DemographicsPage.Appearance.Header.Options.UseFont = True
        Me.DemographicsPage.Appearance.HeaderActive.Font = CType(resources.GetObject("DemographicsPage.Appearance.HeaderActive.Font"), System.Drawing.Font)
        Me.DemographicsPage.Appearance.HeaderActive.Options.UseFont = True
        Me.DemographicsPage.Appearance.HeaderDisabled.Font = CType(resources.GetObject("DemographicsPage.Appearance.HeaderDisabled.Font"), System.Drawing.Font)
        Me.DemographicsPage.Appearance.HeaderDisabled.Options.UseFont = True
        Me.DemographicsPage.Appearance.HeaderHotTracked.Font = CType(resources.GetObject("DemographicsPage.Appearance.HeaderHotTracked.Font"), System.Drawing.Font)
        Me.DemographicsPage.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.DemographicsPage.Appearance.PageClient.Font = CType(resources.GetObject("DemographicsPage.Appearance.PageClient.Font"), System.Drawing.Font)
        Me.DemographicsPage.Appearance.PageClient.Options.UseFont = True
        Me.DemographicsPage.Controls.Add(Me.VetCaseRegistrationPanel1)
        Me.DemographicsPage.Controls.Add(Me.FarmGroup)
        Me.DemographicsPage.Controls.Add(Me.LivestockFarmProductionControl1)
        Me.DemographicsPage.Name = "DemographicsPage"
        resources.ApplyResources(Me.DemographicsPage, "DemographicsPage")
        '
        'VetCaseRegistrationPanel1
        '
        Me.VetCaseRegistrationPanel1.Appearance.BackColor = CType(resources.GetObject("VetCaseRegistrationPanel1.Appearance.BackColor"), System.Drawing.Color)
        Me.VetCaseRegistrationPanel1.Appearance.Font = CType(resources.GetObject("VetCaseRegistrationPanel1.Appearance.Font"), System.Drawing.Font)
        Me.VetCaseRegistrationPanel1.Appearance.Options.UseBackColor = True
        Me.VetCaseRegistrationPanel1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.VetCaseRegistrationPanel1, "VetCaseRegistrationPanel1")
        Me.VetCaseRegistrationPanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.VetCaseRegistrationPanel1.FormID = Nothing
        Me.VetCaseRegistrationPanel1.HelpTopicID = Nothing
        Me.VetCaseRegistrationPanel1.IsStatusReadOnly = False
        Me.VetCaseRegistrationPanel1.KeyFieldName = "idfCase"
        Me.VetCaseRegistrationPanel1.MultiSelect = False
        Me.VetCaseRegistrationPanel1.Name = "VetCaseRegistrationPanel1"
        Me.VetCaseRegistrationPanel1.ObjectName = "VetCaseRegistration"
        Me.VetCaseRegistrationPanel1.Status = bv.common.win.FormStatus.Draft
        Me.VetCaseRegistrationPanel1.TableName = "VetCase"
        Me.VetCaseRegistrationPanel1.UseParentBackColor = True
        '
        'FarmGroup
        '
        Me.FarmGroup.Appearance.BackColor = CType(resources.GetObject("FarmGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.FarmGroup.Appearance.Font = CType(resources.GetObject("FarmGroup.Appearance.Font"), System.Drawing.Font)
        Me.FarmGroup.Appearance.Options.UseBackColor = True
        Me.FarmGroup.Appearance.Options.UseFont = True
        Me.FarmGroup.AppearanceCaption.Font = CType(resources.GetObject("FarmGroup.AppearanceCaption.Font"), System.Drawing.Font)
        Me.FarmGroup.AppearanceCaption.Options.UseFont = True
        Me.FarmGroup.Controls.Add(Me.FarmPanel)
        resources.ApplyResources(Me.FarmGroup, "FarmGroup")
        Me.FarmGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.FarmGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.FarmGroup.Name = "FarmGroup"
        Me.FarmGroup.TabStop = True
        '
        'FarmPanel
        '
        Me.FarmPanel.Appearance.BackColor = CType(resources.GetObject("FarmPanel.Appearance.BackColor"), System.Drawing.Color)
        Me.FarmPanel.Appearance.Font = CType(resources.GetObject("FarmPanel.Appearance.Font"), System.Drawing.Font)
        Me.FarmPanel.Appearance.Options.UseBackColor = True
        Me.FarmPanel.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.FarmPanel, "FarmPanel")
        Me.FarmPanel.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FarmPanel.FarmKind = 0
        Me.FarmPanel.FormID = Nothing
        Me.FarmPanel.HelpTopicID = Nothing
        Me.FarmPanel.IsStatusReadOnly = False
        Me.FarmPanel.KeyFieldName = "idfFarm"
        Me.FarmPanel.MultiSelect = False
        Me.FarmPanel.Name = "FarmPanel"
        Me.FarmPanel.ObjectName = "Farm"
        Me.FarmPanel.Status = bv.common.win.FormStatus.Draft
        Me.FarmPanel.TableName = "Farm"
        Me.FarmPanel.UseParentBackColor = True
        '
        'LivestockFarmProductionControl1
        '
        Me.LivestockFarmProductionControl1.Appearance.BackColor = CType(resources.GetObject("LivestockFarmProductionControl1.Appearance.BackColor"), System.Drawing.Color)
        Me.LivestockFarmProductionControl1.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me.LivestockFarmProductionControl1, "LivestockFarmProductionControl1")
        Me.LivestockFarmProductionControl1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.LivestockFarmProductionControl1.FormID = Nothing
        Me.LivestockFarmProductionControl1.HelpTopicID = Nothing
        Me.LivestockFarmProductionControl1.IsStatusReadOnly = False
        Me.LivestockFarmProductionControl1.KeyFieldName = "idfFarm"
        Me.LivestockFarmProductionControl1.MultiSelect = False
        Me.LivestockFarmProductionControl1.Name = "LivestockFarmProductionControl1"
        Me.LivestockFarmProductionControl1.ObjectName = "LivestockFarmProduction"
        Me.LivestockFarmProductionControl1.Status = bv.common.win.FormStatus.Draft
        Me.LivestockFarmProductionControl1.TableName = "Farm"
        Me.LivestockFarmProductionControl1.UseParentBackColor = True
        '
        'HerdTab
        '
        Me.HerdTab.Controls.Add(Me.VetControlMeasurePanel1)
        Me.HerdTab.Controls.Add(Me.FarmTreePanel1)
        Me.HerdTab.Name = "HerdTab"
        resources.ApplyResources(Me.HerdTab, "HerdTab")
        '
        'VetControlMeasurePanel1
        '
        resources.ApplyResources(Me.VetControlMeasurePanel1, "VetControlMeasurePanel1")
        Me.VetControlMeasurePanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.VetControlMeasurePanel1.FormID = Nothing
        Me.VetControlMeasurePanel1.HelpTopicID = Nothing
        Me.VetControlMeasurePanel1.IsStatusReadOnly = False
        Me.VetControlMeasurePanel1.KeyFieldName = "idfCase"
        Me.VetControlMeasurePanel1.MultiSelect = False
        Me.VetControlMeasurePanel1.Name = "VetControlMeasurePanel1"
        Me.VetControlMeasurePanel1.ObjectName = "VetCase"
        Me.VetControlMeasurePanel1.Status = bv.common.win.FormStatus.Draft
        Me.VetControlMeasurePanel1.TableName = "VetCase"
        '
        'FarmTreePanel1
        '
        Me.FarmTreePanel1.Appearance.BackColor = CType(resources.GetObject("FarmTreePanel1.Appearance.BackColor"), System.Drawing.Color)
        Me.FarmTreePanel1.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me.FarmTreePanel1, "FarmTreePanel1")
        Me.FarmTreePanel1.CaseKind = EIDSS.CaseType.Livestock
        Me.FarmTreePanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FarmTreePanel1.FormID = Nothing
        Me.FarmTreePanel1.HelpTopicID = Nothing
        Me.FarmTreePanel1.HidePersonalData = False
        Me.FarmTreePanel1.IsStatusReadOnly = False
        Me.FarmTreePanel1.KeyFieldName = "idfParty"
        Me.FarmTreePanel1.MultiSelect = False
        Me.FarmTreePanel1.Name = "FarmTreePanel1"
        Me.FarmTreePanel1.ObjectName = "VetFarmTree"
        Me.FarmTreePanel1.SamplesList = Nothing
        Me.FarmTreePanel1.Status = bv.common.win.FormStatus.Draft
        Me.FarmTreePanel1.TableName = "VetFarmTree"
        Me.FarmTreePanel1.UseParentBackColor = True
        '
        'DiagnosisPage
        '
        Me.DiagnosisPage.Controls.Add(Me.VaccinationPanel1)
        Me.DiagnosisPage.Controls.Add(Me.VetDiagnosisPanel1)
        Me.DiagnosisPage.Controls.Add(Me.CommentsGroup)
        Me.DiagnosisPage.Name = "DiagnosisPage"
        resources.ApplyResources(Me.DiagnosisPage, "DiagnosisPage")
        '
        'VaccinationPanel1
        '
        resources.ApplyResources(Me.VaccinationPanel1, "VaccinationPanel1")
        Me.VaccinationPanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.VaccinationPanel1.FormID = Nothing
        Me.VaccinationPanel1.HelpTopicID = Nothing
        Me.VaccinationPanel1.IsStatusReadOnly = False
        Me.VaccinationPanel1.KeyFieldName = Nothing
        Me.VaccinationPanel1.MultiSelect = False
        Me.VaccinationPanel1.Name = "VaccinationPanel1"
        Me.VaccinationPanel1.ObjectName = Nothing
        Me.VaccinationPanel1.Status = bv.common.win.FormStatus.Draft
        Me.VaccinationPanel1.TableName = Nothing
        '
        'VetDiagnosisPanel1
        '
        Me.VetDiagnosisPanel1.Appearance.BackColor = CType(resources.GetObject("VetDiagnosisPanel1.Appearance.BackColor"), System.Drawing.Color)
        Me.VetDiagnosisPanel1.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me.VetDiagnosisPanel1, "VetDiagnosisPanel1")
        Me.VetDiagnosisPanel1.CaseKind = EIDSS.CaseType.Livestock
        Me.VetDiagnosisPanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.VetDiagnosisPanel1.FormID = Nothing
        Me.VetDiagnosisPanel1.HelpTopicID = Nothing
        Me.VetDiagnosisPanel1.IsStatusReadOnly = False
        Me.VetDiagnosisPanel1.KeyFieldName = "idfCase"
        Me.VetDiagnosisPanel1.MultiSelect = False
        Me.VetDiagnosisPanel1.Name = "VetDiagnosisPanel1"
        Me.VetDiagnosisPanel1.ObjectName = "VetCase"
        Me.VetDiagnosisPanel1.Status = bv.common.win.FormStatus.Draft
        Me.VetDiagnosisPanel1.TableName = "VetCase"
        Me.VetDiagnosisPanel1.UseParentBackColor = True
        '
        'CommentsGroup
        '
        Me.CommentsGroup.Appearance.BackColor = CType(resources.GetObject("CommentsGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.CommentsGroup.Appearance.Options.UseBackColor = True
        Me.CommentsGroup.Controls.Add(Me.lbNotesComment)
        Me.CommentsGroup.Controls.Add(Me.txtCaseNotes)
        resources.ApplyResources(Me.CommentsGroup, "CommentsGroup")
        Me.CommentsGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.CommentsGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.CommentsGroup.Name = "CommentsGroup"
        Me.CommentsGroup.TabStop = True
        '
        'lbNotesComment
        '
        resources.ApplyResources(Me.lbNotesComment, "lbNotesComment")
        Me.lbNotesComment.BackColor = System.Drawing.SystemColors.Info
        Me.lbNotesComment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbNotesComment.Name = "lbNotesComment"
        '
        'txtCaseNotes
        '
        resources.ApplyResources(Me.txtCaseNotes, "txtCaseNotes")
        Me.txtCaseNotes.Name = "txtCaseNotes"
        Me.txtCaseNotes.Properties.MaxLength = 2000
        '
        'AnimalsPage
        '
        Me.AnimalsPage.Controls.Add(Me.VetCaseAnimalsPanel1)
        Me.AnimalsPage.Name = "AnimalsPage"
        resources.ApplyResources(Me.AnimalsPage, "AnimalsPage")
        '
        'VetCaseAnimalsPanel1
        '
        Me.VetCaseAnimalsPanel1.Appearance.BackColor = CType(resources.GetObject("VetCaseAnimalsPanel1.Appearance.BackColor"), System.Drawing.Color)
        Me.VetCaseAnimalsPanel1.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me.VetCaseAnimalsPanel1, "VetCaseAnimalsPanel1")
        Me.VetCaseAnimalsPanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.VetCaseAnimalsPanel1.FormID = Nothing
        Me.VetCaseAnimalsPanel1.HelpTopicID = Nothing
        Me.VetCaseAnimalsPanel1.IsStatusReadOnly = False
        Me.VetCaseAnimalsPanel1.KeyFieldName = Nothing
        Me.VetCaseAnimalsPanel1.MultiSelect = False
        Me.VetCaseAnimalsPanel1.Name = "VetCaseAnimalsPanel1"
        Me.VetCaseAnimalsPanel1.ObjectName = Nothing
        Me.VetCaseAnimalsPanel1.Status = bv.common.win.FormStatus.Draft
        Me.VetCaseAnimalsPanel1.TableName = Nothing
        Me.VetCaseAnimalsPanel1.UseParentBackColor = True
        '
        'SamplesPage
        '
        Me.SamplesPage.Controls.Add(Me.CaseSamplesPanel1)
        Me.SamplesPage.Name = "SamplesPage"
        resources.ApplyResources(Me.SamplesPage, "SamplesPage")
        '
        'CaseSamplesPanel1
        '
        resources.ApplyResources(Me.CaseSamplesPanel1, "CaseSamplesPanel1")
        Me.CaseSamplesPanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.CaseSamplesPanel1.FormID = Nothing
        Me.CaseSamplesPanel1.HelpTopicID = Nothing
        Me.CaseSamplesPanel1.IsStatusReadOnly = False
        Me.CaseSamplesPanel1.KeyFieldName = "idfMaterial"
        Me.CaseSamplesPanel1.MultiSelect = False
        Me.CaseSamplesPanel1.Name = "CaseSamplesPanel1"
        Me.CaseSamplesPanel1.ObjectName = "CaseSamples"
        Me.CaseSamplesPanel1.ShowNewButton = False
        Me.CaseSamplesPanel1.Status = bv.common.win.FormStatus.Draft
        Me.CaseSamplesPanel1.TableName = "Material"
        '
        'PensideTestPage
        '
        Me.PensideTestPage.Controls.Add(Me.PensideTestPanel1)
        Me.PensideTestPage.Name = "PensideTestPage"
        resources.ApplyResources(Me.PensideTestPage, "PensideTestPage")
        '
        'PensideTestPanel1
        '
        resources.ApplyResources(Me.PensideTestPanel1, "PensideTestPanel1")
        Me.PensideTestPanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.PensideTestPanel1.FormID = Nothing
        Me.PensideTestPanel1.HelpTopicID = Nothing
        Me.PensideTestPanel1.IsStatusReadOnly = False
        Me.PensideTestPanel1.KeyFieldName = Nothing
        Me.PensideTestPanel1.MultiSelect = False
        Me.PensideTestPanel1.Name = "PensideTestPanel1"
        Me.PensideTestPanel1.ObjectName = Nothing
        Me.PensideTestPanel1.Status = bv.common.win.FormStatus.Draft
        Me.PensideTestPanel1.TableName = Nothing
        '
        'LabTestPage
        '
        Me.LabTestPage.Controls.Add(Me.cbTestsConducted)
        Me.LabTestPage.Controls.Add(Me.lbTestsConducted)
        Me.LabTestPage.Controls.Add(Me.CaseTestsPanel1)
        Me.LabTestPage.Name = "LabTestPage"
        resources.ApplyResources(Me.LabTestPage, "LabTestPage")
        '
        'cbTestsConducted
        '
        resources.ApplyResources(Me.cbTestsConducted, "cbTestsConducted")
        Me.cbTestsConducted.Name = "cbTestsConducted"
        Me.cbTestsConducted.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestsConducted.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbTestsConducted
        '
        resources.ApplyResources(Me.lbTestsConducted, "lbTestsConducted")
        Me.lbTestsConducted.Name = "lbTestsConducted"
        '
        'CaseTestsPanel1
        '
        Me.CaseTestsPanel1.Appearance.BackColor = CType(resources.GetObject("CaseTestsPanel1.Appearance.BackColor"), System.Drawing.Color)
        Me.CaseTestsPanel1.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me.CaseTestsPanel1, "CaseTestsPanel1")
        Me.CaseTestsPanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.CaseTestsPanel1.FormID = Nothing
        Me.CaseTestsPanel1.HelpTopicID = Nothing
        Me.CaseTestsPanel1.IsStatusReadOnly = False
        Me.CaseTestsPanel1.KeyFieldName = "idfActivity"
        Me.CaseTestsPanel1.MultiSelect = False
        Me.CaseTestsPanel1.Name = "CaseTestsPanel1"
        Me.CaseTestsPanel1.ObjectName = "CaseTest"
        Me.CaseTestsPanel1.Status = bv.common.win.FormStatus.Draft
        Me.CaseTestsPanel1.TableName = "Testing"
        Me.CaseTestsPanel1.UseParentBackColor = True
        '
        'CaseLogTab
        '
        Me.CaseLogTab.Controls.Add(Me.CaseLog1)
        Me.CaseLogTab.Name = "CaseLogTab"
        resources.ApplyResources(Me.CaseLogTab, "CaseLogTab")
        '
        'CaseLog1
        '
        resources.ApplyResources(Me.CaseLog1, "CaseLog1")
        Me.CaseLog1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.CaseLog1.FormID = Nothing
        Me.CaseLog1.HelpTopicID = Nothing
        Me.CaseLog1.IsStatusReadOnly = False
        Me.CaseLog1.KeyFieldName = Nothing
        Me.CaseLog1.MultiSelect = False
        Me.CaseLog1.Name = "CaseLog1"
        Me.CaseLog1.ObjectName = Nothing
        Me.CaseLog1.Status = bv.common.win.FormStatus.Draft
        Me.CaseLog1.TableName = Nothing
        '
        'VetStatusPanel1
        '
        Me.VetStatusPanel1.Appearance.BackColor = CType(resources.GetObject("VetStatusPanel1.Appearance.BackColor"), System.Drawing.Color)
        Me.VetStatusPanel1.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me.VetStatusPanel1, "VetStatusPanel1")
        Me.VetStatusPanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.VetStatusPanel1.FormID = Nothing
        Me.VetStatusPanel1.HelpTopicID = Nothing
        Me.VetStatusPanel1.IsStatusReadOnly = False
        Me.VetStatusPanel1.KeyFieldName = "idfCase"
        Me.VetStatusPanel1.MultiSelect = False
        Me.VetStatusPanel1.Name = "VetStatusPanel1"
        Me.VetStatusPanel1.ObjectName = "VetStatus"
        Me.VetStatusPanel1.Status = bv.common.win.FormStatus.Draft
        Me.VetStatusPanel1.TableName = "VetCase"
        Me.VetStatusPanel1.UseParentBackColor = True
        '
        'PopUpButton1
        '
        Me.PopUpButton1.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
        resources.ApplyResources(Me.PopUpButton1, "PopUpButton1")
        Me.PopUpButton1.Name = "PopUpButton1"
        Me.PopUpButton1.PopUpMenu = Me.cmReports
        Me.PopUpButton1.Tag = "{Immovable}{AlwaysEditable}"
        '
        'cmReports
        '
        Me.cmReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'VetCaseLiveStockDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("VetCaseLiveStockDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.PopUpButton1)
        Me.Controls.Add(Me.VetStatusPanel1)
        Me.Controls.Add(Me.TabContol)
        Me.FormID = "V02"
        Me.HelpTopicID = "VetCaseLivestockDetailForm"
        Me.KeyFieldName = "idfCase"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "VetCaseLiveStockDetail"
        Me.ObjectName = "VetCase"
        Me.TableName = "VetCase"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.TabContol, 0)
        Me.Controls.SetChildIndex(Me.VetStatusPanel1, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton1, 0)
        CType(Me.TabContol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabContol.ResumeLayout(False)
        Me.DemographicsPage.ResumeLayout(False)
        CType(Me.FarmGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FarmGroup.ResumeLayout(False)
        Me.HerdTab.ResumeLayout(False)
        Me.DiagnosisPage.ResumeLayout(False)
        CType(Me.CommentsGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CommentsGroup.ResumeLayout(False)
        CType(Me.txtCaseNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnimalsPage.ResumeLayout(False)
        Me.SamplesPage.ResumeLayout(False)
        Me.PensideTestPage.ResumeLayout(False)
        Me.LabTestPage.ResumeLayout(False)
        CType(Me.cbTestsConducted.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CaseLogTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Main form interface"

    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        If EIDSS.model.Core.EidssSiteContext.Instance.IsReadOnlySite Then
            Return
        End If
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Create, "MenuNewVetCaseLivestock", 410)
        ma.ShowInToolbar = False
        ma.BigIconIndex = MenuIcons.NewLivestockCase
        ma.SmallIconIndex = MenuIconsSmall.LivestockCase
        ma.Name = "btnNewLivestockCase"
        ma.SelectPermission = PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.VetCase)
        ma = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals, "ToolbarNewVetCaseLivestock", 205)
        ma.ShowInToolbar = True
        ma.ShowInMenu = False
        ma.BigIconIndex = MenuIcons.NewLivestockCase
        ma.Name = "btnNewToolbarLivestockCase"
        ma.SelectPermission = PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.VetCase)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New VetCaseLiveStockDetail, Nothing)
        'BaseForm.ShowModal(New VetCaseLiveStockDetail)
    End Sub
#End Region

#Region "REPORTS"

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If Post(PostType.FinalPosting) Then
            Dim id As Long = CType(GetKey(), Long)
            Dim row As DataRow = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)
            Dim diagnosisID As Long = -1
            If (Not (TypeOf (row("idfsShowDiagnosis")) Is DBNull)) Then
                diagnosisID = CType(row("idfsShowDiagnosis"), Long)
            End If
            EidssSiteContext.ReportFactory.VetLivestockInvestigation(id, diagnosisID)
        End If

    End Sub

#End Region

    Private Sub InitCustomMandatoryFields()
        MandatoryFieldHelper.SetCustomAddressMandatoryField(FarmPanel.AddressPanel, CustomMandatoryField.VetCase_Farm_Address_Settlement, AddressMandatoryFieldsType.Settlement)
    End Sub


    Protected Overrides Sub DefineBinding()
        FarmPanel.HidePersonalData = Not baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfPersonEnteredBy").Equals(EidssUserContext.User.EmployeeID)
        AddHandler FarmPanel.OnFarmChanging, AddressOf OnFarmChanging
        AddHandler FarmPanel.OnFarmChanged, AddressOf OnFarmChanged
        AddHandler FarmPanel.OnFarmCodeChanged, AddressOf OnFarmCodeChanged
        AddHandler CaseSamplesPanel1.OnDeleteSample, AddressOf OnSampleDelete
        AddHandler CaseSamplesPanel1.OnSampleChanged, AddressOf OnSampleChanged
        AddHandler CaseTestsPanel1.OnTestsCollectionChanged, AddressOf OnTestsCollectionChanged
        AddHandler VetCaseAnimalsPanel1.OnDeleteAnimal, AddressOf OnAnimalDelete
        AddHandler VetCaseAnimalsPanel1.AnimalInfoChanged, AddressOf OnAnimalChanged
        AddHandler VetCaseRegistrationPanel1.OnInvestigationDateChanged, AddressOf OnInvestigationDateChanged
        Core.LookupBinder.BindTextEdit(txtCaseNotes, baseDataSet, VetCase_DB.TableVetCase + ".strSummaryNotes")
        Core.LookupBinder.BindBaseLookup(cbTestsConducted, baseDataSet, VetCase_DB.TableVetCase + ".idfsYNTestsConducted", db.BaseReferenceType.rftYesNoValue, False)
        SetControlReadOnly(cbTestsConducted, Not CBool(baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("blnEnableTestsConducted")), False)
        'eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".idfsYNTestsConducted", AddressOf TestConducted_Changed)
        'eventManager.Cascade(VetCase_DB.TableVetCase + ".idfsYNTestsConducted")
        FarmPanel.FarmKind = 1
    End Sub

    Private Sub OnAnimalChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        CaseSamplesPanel1.UpdatePartyInfo(e.Row("idfAnimal"))
    End Sub

    Private Sub TestConducted_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        'If Not e.Value Is DBNull.Value AndAlso CType(e.Value, YesNoUnknownValues) = YesNoUnknownValues.No Then
        '    CaseTestsPanel1.ReadOnly = True
        'ElseIf CaseTestsPanel1.ReadOnly <> [ReadOnly] Then
        '    CaseTestsPanel1.ReadOnly = [ReadOnly]
        'End If
    End Sub
    Private Sub OnSampleChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Not e.Column Is Nothing AndAlso e.Column.ColumnName = "idfMaterial" Then
            PensideTestPanel1.RefreshTests(e.OldValue, e.Value)
            CaseTestsPanel1.RefreshTests(e.OldValue, e.Value)
        Else
            PensideTestPanel1.RefreshTests(e.Row("idfMaterial"), e.Row("idfMaterial"))
            CaseTestsPanel1.RefreshTests(e.Row("idfMaterial"), e.Row("idfMaterial"))
        End If
    End Sub

    Private Sub OnAnimalDelete(ByVal sender As Object, ByVal e As DataRowEventArgs)
        Dim AnimalID As Object = e.Row("idfAnimal")
        e.Cancel = Not CaseSamplesPanel1.CanDeleteParty(AnimalID) OrElse Not PensideTestPanel1.CanDeleteParty(AnimalID)
    End Sub

    Public Overrides Function GetChildKey(ByVal child As bv.common.win.IRelatedObject) As Object
        If child Is FarmPanel OrElse child Is LivestockFarmProductionControl1 Then
            Return GetKey(VetCase_DB.TableVetCase, "idfFarm")
        End If
        Return GetKey()
    End Function

    Protected Overrides Sub AfterLoad()
        VetCaseAnimalsPanel1.HerdsList = FarmTreePanel1.HerdsList
        'VetCaseAnimalsPanel1.GetHerdSpeciesFilter = AddressOf FarmTreePanel1.GetHerdSpieciesFilter
        VetCaseAnimalsPanel1.SpeciesList = FarmTreePanel1.SpieciesList
        AddHandler VetCaseAnimalsPanel1.AnimalStateChanged, AddressOf AnimalStateChanged
        CaseSamplesPanel1.CasePartyList = New DataView(Me.VetCaseAnimalsPanel1.baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals))
        CaseTestsPanel1.SamplesView = CaseSamplesPanel1.SamplesList
        PensideTestPanel1.SamplesView = CaseSamplesPanel1.SamplesList
        PensideTestPanel1.PartyList = New DataView(Me.VetCaseAnimalsPanel1.baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals))
        FarmTreePanel1.AnimalsList = VetCaseAnimalsPanel1.AnimalsList
        VaccinationPanel1.SpeciesList = FarmTreePanel1.SpieciesList
        ''CaseSamplesPanel1.RefreshRelatedViews()
        'txtCaseNotes.Text = VetCaseRegistrationPanel1.CaseNotes
        FarmTreePanel1.CanDeleteRow = AddressOf CanDeleteFarmTreeNode
        If (Me.State And BusinessObjectState.NewObject) <> 0 Then
            If Utils.IsEmpty(FarmPanel.RootFarmID) Then
                FarmPanel.RootFarmID = BaseDbService.NewIntID
            End If
            OnFarmChanged(FarmPanel.RootFarmID)
        End If
        FarmPanel.CaseID = GetKey()
        FarmPanel.FarmKind = 1
        OnInvestigationDateChanged(VetCaseRegistrationPanel1, EventArgs.Empty)
    End Sub
    Private Function CanDeleteFarmTreeNode(ByVal row As DataRow) As Boolean
        Return VetCaseAnimalsPanel1.CanDeleteFarmTreeNode(row) _
                AndAlso VaccinationPanel1.CanDeleteFarmTreeNode(row)
    End Function

    Private Sub VetDiagnosisPanel1_DiagnosisChanged() Handles VetDiagnosisPanel1.DiagnosisChanged
        Me.CaseSamplesPanel1.DiagnosisList = VetDiagnosisPanel1.DiagnosisList
        Me.CaseTestsPanel1.DiagnosisList = VetDiagnosisPanel1.DiagnosisList
        Me.CaseTestsPanel1.DiagnosisID = VetDiagnosisPanel1.CurrentDiagnosesID
        Me.FarmTreePanel1.DiagnosisID = VetDiagnosisPanel1.CurrentDiagnosesID
        Me.VetStatusPanel1.SetDisease(VetDiagnosisPanel1.CurrentDiagnosesID, VetDiagnosisPanel1.AllDiagnoses)
        Me.VetCaseAnimalsPanel1.DiagnosisID = VetDiagnosisPanel1.CurrentDiagnosesID
        Me.VetControlMeasurePanel1.DiagnosisID = VetDiagnosisPanel1.CurrentDiagnosesID
    End Sub

#Region "Farm Management"
    Public Sub OnFarmChanging(ByVal newFarmId As Object, ByVal oldFarmID As Object, ByRef Cancel As Boolean)
        'Dim showDeletePrompt As Boolean = Me.FarmTreePanel1.HasAnimalGroups OrElse Me.FarmPanel.HasChanges
        ''If Me.CaseSamplesPanel1.HasSamples Then
        ''    showDeletePrompt = True
        ''End If
        ''If Me.CaseTestsPanel1.HasTests Then
        ''    showDeletePrompt = True
        ''End If
        'If showDeletePrompt AndAlso MessageForm.Show(EidssMessages.Get("msgConfirmCaseFarmDeleteLivestock", "You are going to replace the current farm with the new one. All herds, animals, samples and tests records related with current farm will be assigned to the new farm. Replace the farm?"), EidssMessages.Get("titleDeleteFarm", "Replace Farm"), MessageBoxButtons.YesNo) <> DialogResult.Yes Then
        '    Cancel = True
        '    Return
        'End If
    End Sub
    Public Sub OnFarmChanged(ByVal RootFarmID As Object)
        baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfRootFarm") = RootFarmID
        FarmTreePanel1.ChangeFarm(RootFarmID, FarmPanel.FarmID, Utils.Str(FarmPanel.FarmCode))
        LivestockFarmProductionControl1.LoadData(RootFarmID)
        LivestockFarmProductionControl1.RootFarmID = RootFarmID
        LivestockFarmProductionControl1.baseDataSet.Tables(LivestockFarmProduction_DB.TableFarm).Rows(0)("idfFarm") = FarmPanel.FarmID
    End Sub
    Public Sub OnFarmCodeChanged(ByVal newFarmCode As Object)
        Me.FarmTreePanel1.FarmCode = Utils.Str(newFarmCode)
    End Sub
#End Region


    Private Sub VetCaseLiveStockDetail_OnAfterPost(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnAfterPost
        'AfterLoad()
        If sender Is Me Then
            FarmTreePanel1.FarmCode = FarmPanel.FarmCode

        End If
    End Sub

    Private Sub OnSampleDelete(ByVal sender As Object, ByVal e As DataRowEventArgs)
        Dim sampleID As Object = e.Row("idfMaterial")
        e.Cancel = Not PensideTestPanel1.CanDeleteSample(sampleID) OrElse Not CaseTestsPanel1.CanDeleteSample(sampleID)
    End Sub
    Private Sub OnTestsCollectionChanged(ByVal sender As Object, ByVal e As DataRowEventArgs)
        If e.Row.RowState = DataRowState.Added Then
            baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfsYNTestsConducted") = YesNoUnknownValues.Yes
            baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0).EndEdit()
            SetControlReadOnly(cbTestsConducted, True, False)
        ElseIf e.Row.RowState = DataRowState.Deleted OrElse e.Row.RowState = DataRowState.Detached Then
            If Not CaseTestsPanel1.HasCompletedTest Then
                SetControlReadOnly(cbTestsConducted, False, False)
            End If
        End If
    End Sub
    Private Sub OnInvestigationDateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsDBNull(VetCaseRegistrationPanel1.InvestigationDate) Then
            Me.VetDiagnosisPanel1.DefaultDiagnosisDate = DateTime.MinValue
        Else
            Me.VetDiagnosisPanel1.DefaultDiagnosisDate = CType(VetCaseRegistrationPanel1.InvestigationDate, DateTime)
        End If
    End Sub
    Private Sub AnimalStateChanged(ByVal sender As Object, ByVal e As Data.DataRowChangeEventArgs)
        If e.Action = DataRowAction.Delete Then
            CaseSamplesPanel1.DeletePartySamples(e.Row("idfAnimal"))
        End If
    End Sub
    Public Overrides Sub ShowHelp()
        If TabContol.ContainsFocus Then

            Select Case Me.TabContol.SelectedTabPage.Name
                Case "DemographicsPage"
                    ShowHelp("LivestockFarmDetailTab")
                Case "HerdTab"
                    ShowHelp("LivestockHerdTab")
                Case "DiagnosisPage"
                    ShowHelp("LivestockDiagnosisTab")
                Case "AnimalsPage"
                    ShowHelp("LivestockAnimalsTab")
                Case "SamplesPage"
                    ShowHelp("LivestockSamplesTab")
                Case "LabTestPage"
                    ShowHelp("LivestockLabTestsTab")
                Case "LabTestPage"
                    ShowHelp("LivestockLabTestsTab")
                Case "PensideTestPage"
                    ShowHelp("LivestockPenSideTestsTab")
                Case "CaseLogTab"
                    'TODO: append help with this tab description and make correct help link
                    ShowHelp()
                Case Else
                    MyBase.ShowHelp()
            End Select
        Else
            MyBase.ShowHelp()
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If Post(PostType.FinalPosting) Then
            Dim id As Long = CType(GetKey(), Long)
            Dim row As DataRow = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)
            Dim diagnosisID As Long = -1
            If (Not (TypeOf (row("idfsShowDiagnosis")) Is DBNull)) Then
                diagnosisID = CType(row("idfsShowDiagnosis"), Long)
            End If
            EidssSiteContext.ReportFactory.VetLivestockInvestigation(id, diagnosisID)
        End If
    End Sub
    Public Overrides Function ValidateData() As Boolean
        If Not MyBase.ValidateData() Then
            Return False
        End If
        If VetCaseRegistrationPanel1.DateForValidationType = ValidationDateType.None OrElse VetDiagnosisPanel1.DateForValidationType = ValidationDateType.None Then
            Return True
        End If
        Dim errMsgId As String = GetDatesValidationError()
        If Utils.IsEmpty(errMsgId) Then
            Return True
        End If

        If Not VaccinationPanel1.ValidateGridData(False) Then
            TabContol.SelectedTabPage = DiagnosisPage
            VaccinationPanel1.ValidateGridData(True)
            Return False
        End If

        If Not CaseLog1.ValidateGridData(False) Then
            TabContol.SelectedTabPage = CaseLogTab
            CaseLog1.ValidateGridData(True)
            Return False
        End If

        If (WinUtils.CompareDates(VetCaseRegistrationPanel1.ValidationDate, VetDiagnosisPanel1.ValidationDate, errMsgId) = False) Then
            VetCaseRegistrationPanel1.FocusValidationDate()
            Return False
        End If
        Return True
    End Function
    Public Function GetDatesValidationError() As String
        Select Case VetCaseRegistrationPanel1.DateForValidationType
            Case ValidationDateType.AssignedDate
                Select Case VetDiagnosisPanel1.DateForValidationType
                    Case ValidationDateType.TentantiveDiagnosis1
                        Return "datAssignedDate_TentantiveDiagnosisDate_msgId"
                    Case ValidationDateType.TentantiveDiagnosis2
                        Return "datAssignedDate_TentantiveDiagnosis1Date_msgId"
                    Case ValidationDateType.TentantiveDiagnosis3
                        Return "datAssignedDate_TentantiveDiagnosis2Date_msgId"
                End Select
            Case ValidationDateType.ReportedDate
                Select Case VetDiagnosisPanel1.DateForValidationType
                    Case ValidationDateType.TentantiveDiagnosis1
                        Return "datReportedDate_TentantiveDiagnosisDate_msgId"
                    Case ValidationDateType.TentantiveDiagnosis2
                        Return "datReportedDate_TentantiveDiagnosis1Date_msgId"
                    Case ValidationDateType.TentantiveDiagnosis3
                        Return "datReportedDate_TentantiveDiagnosis2Date_msgId"
                End Select
        End Select
        Return Nothing
    End Function

End Class
