Imports bv.winclient.BasePanel
Imports bv.common.db
Imports bv.winclient.Core
Imports eidss.model.Core
Imports eidss.model.Resources
Imports eidss.model.Enums

Public Class VetCaseAvianDetail
    Inherits bv.common.win.BaseDetailForm


#Region " Windows Form Designer generated code "
    Public VetCaseDbService As VetCase_DB

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitCustomMandatoryFields()
        VetCaseDbService = New VetCase_DB
        VetCaseDbService.CaseType = CaseType.Avian
        DbService = VetCaseDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoVetCase, AuditTable.tlbCase)
        Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.VetCase

        'Add any initialization after the InitializeComponent() call
        CaseSamplesPanel1.HACode = HACode.Avian
        VetDiagnosisPanel1.CaseKind = CaseType.Avian
        VaccinationPanel1.CaseKind = CaseType.Avian
        FarmTreePanel1.CaseKind = CaseType.Avian
        CaseTestsPanel1.HACode = HACode.Avian
        PensideTestPanel1.HACode = HACode.Avian
        HerdTab.Text = EidssMessages.Get("Flock Epi/Clinical Signs")
        VetStatusPanel1.UseParentDataset = True
        VetCaseRegistrationPanel1.UseParentDataset = True
        VetStatusPanel1.UseParentDataset = True
        VetDiagnosisPanel1.UseParentDataset = True
        FarmPanel.HidePersonalData = True
        FarmTreePanel1.HidePersonalData = True
        RegisterChildObject(FarmPanel, RelatedPostOrder.PostFirst)
        RegisterChildObject(VetCaseRegistrationPanel1, RelatedPostOrder.SkipPost)
        RegisterChildObject(VetStatusPanel1, RelatedPostOrder.SkipPost)
        RegisterChildObject(AvianFarmDetail1, RelatedPostOrder.PostLast)
        RegisterChildObject(FarmTreePanel1, RelatedPostOrder.PostLast)
        RegisterChildObject(Me.AvianFarmProductionControl1, RelatedPostOrder.PostLast)
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
    Friend WithEvents VetStatusPanel1 As eidss.VetStatusPanel
    Friend WithEvents TabContol As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents DemographicsPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents VetCaseRegistrationPanel1 As eidss.VetCaseRegistrationPanel
    Friend WithEvents FarmGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents FarmPanel As eidss.FarmPanel
    Friend WithEvents HerdTab As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents FarmTreePanel1 As eidss.FarmTreePanel
    Friend WithEvents DiagnosesPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents VetDiagnosisPanel1 As eidss.VetDiagnosisPanel
    Friend WithEvents CommentsGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbNotesComment As System.Windows.Forms.Label
    Friend WithEvents txtCaseNotes As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents SamplesPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents CaseSamplesPanel1 As eidss.VetCaseSamplesPanel
    Friend WithEvents LabTestsPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents CaseTestsPanel1 As eidss.CaseTestsPanel
    Friend WithEvents AvianFarmProductionControl1 As eidss.AvianFarmProductionControl
    Friend WithEvents PopUpButton1 As bv.common.win.PopUpButton
    Friend WithEvents cmReports As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents FarmDetailGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PensideTestPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PensideTestPanel1 As eidss.PensideTestPanel
    Friend WithEvents CaseLogTab As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents CaseLog1 As eidss.CaseLog
    Friend WithEvents AvianFarmDetail1 As eidss.AvianFarmDetail
    Friend WithEvents lbTestsConducted As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbTestsConducted As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents VaccinationPanel1 As eidss.VaccinationPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetCaseAvianDetail))
        Me.VetStatusPanel1 = New EIDSS.VetStatusPanel()
        Me.TabContol = New DevExpress.XtraTab.XtraTabControl()
        Me.DemographicsPage = New DevExpress.XtraTab.XtraTabPage()
        Me.VetCaseRegistrationPanel1 = New EIDSS.VetCaseRegistrationPanel()
        Me.FarmGroup = New DevExpress.XtraEditors.GroupControl()
        Me.FarmPanel = New EIDSS.FarmPanel()
        Me.AvianFarmProductionControl1 = New EIDSS.AvianFarmProductionControl()
        Me.FarmDetailGroup = New DevExpress.XtraEditors.GroupControl()
        Me.AvianFarmDetail1 = New EIDSS.AvianFarmDetail()
        Me.HerdTab = New DevExpress.XtraTab.XtraTabPage()
        Me.FarmTreePanel1 = New EIDSS.FarmTreePanel()
        Me.DiagnosesPage = New DevExpress.XtraTab.XtraTabPage()
        Me.VaccinationPanel1 = New EIDSS.VaccinationPanel()
        Me.VetDiagnosisPanel1 = New EIDSS.VetDiagnosisPanel()
        Me.CommentsGroup = New DevExpress.XtraEditors.GroupControl()
        Me.lbNotesComment = New System.Windows.Forms.Label()
        Me.txtCaseNotes = New DevExpress.XtraEditors.MemoEdit()
        Me.SamplesPage = New DevExpress.XtraTab.XtraTabPage()
        Me.CaseSamplesPanel1 = New EIDSS.VetCaseSamplesPanel()
        Me.PensideTestPage = New DevExpress.XtraTab.XtraTabPage()
        Me.PensideTestPanel1 = New EIDSS.PensideTestPanel()
        Me.LabTestsPage = New DevExpress.XtraTab.XtraTabPage()
        Me.lbTestsConducted = New DevExpress.XtraEditors.LabelControl()
        Me.cbTestsConducted = New DevExpress.XtraEditors.LookUpEdit()
        Me.CaseTestsPanel1 = New EIDSS.CaseTestsPanel()
        Me.CaseLogTab = New DevExpress.XtraTab.XtraTabPage()
        Me.CaseLog1 = New EIDSS.CaseLog()
        Me.PopUpButton1 = New bv.common.win.PopUpButton()
        Me.cmReports = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        CType(Me.TabContol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabContol.SuspendLayout()
        Me.DemographicsPage.SuspendLayout()
        CType(Me.FarmGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FarmGroup.SuspendLayout()
        CType(Me.FarmDetailGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FarmDetailGroup.SuspendLayout()
        Me.HerdTab.SuspendLayout()
        Me.DiagnosesPage.SuspendLayout()
        CType(Me.CommentsGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CommentsGroup.SuspendLayout()
        CType(Me.txtCaseNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SamplesPage.SuspendLayout()
        Me.PensideTestPage.SuspendLayout()
        Me.LabTestsPage.SuspendLayout()
        CType(Me.cbTestsConducted.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CaseLogTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Appearance.Font = CType(resources.GetObject("cmdOk.Appearance.Font"), System.Drawing.Font)
        Me.cmdOk.Appearance.Options.UseFont = True
        '
        'VetStatusPanel1
        '
        Me.VetStatusPanel1.Appearance.BackColor = CType(resources.GetObject("VetStatusPanel1.Appearance.BackColor"), System.Drawing.Color)
        Me.VetStatusPanel1.Appearance.Font = CType(resources.GetObject("VetStatusPanel1.Appearance.Font"), System.Drawing.Font)
        Me.VetStatusPanel1.Appearance.Options.UseBackColor = True
        Me.VetStatusPanel1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.VetStatusPanel1, "VetStatusPanel1")
        Me.VetStatusPanel1.FormID = Nothing
        Me.VetStatusPanel1.HelpTopicID = Nothing
        Me.VetStatusPanel1.IsStatusReadOnly = False
        Me.VetStatusPanel1.KeyFieldName = "idfCase"
        Me.VetStatusPanel1.MultiSelect = False
        Me.VetStatusPanel1.Name = "VetStatusPanel1"
        Me.VetStatusPanel1.ObjectName = "VetStatus"
        Me.VetStatusPanel1.TableName = "VetCase"
        Me.VetStatusPanel1.UseParentBackColor = True
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
        Me.TabContol.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.DemographicsPage, Me.HerdTab, Me.DiagnosesPage, Me.SamplesPage, Me.PensideTestPage, Me.LabTestsPage, Me.CaseLogTab})
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
        Me.DemographicsPage.Controls.Add(Me.AvianFarmProductionControl1)
        Me.DemographicsPage.Controls.Add(Me.FarmDetailGroup)
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
        Me.VetCaseRegistrationPanel1.FormID = Nothing
        Me.VetCaseRegistrationPanel1.HelpTopicID = Nothing
        Me.VetCaseRegistrationPanel1.IsStatusReadOnly = False
        Me.VetCaseRegistrationPanel1.KeyFieldName = "idfCase"
        Me.VetCaseRegistrationPanel1.MultiSelect = False
        Me.VetCaseRegistrationPanel1.Name = "VetCaseRegistrationPanel1"
        Me.VetCaseRegistrationPanel1.ObjectName = "VetCaseRegistration"
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
        Me.FarmPanel.FarmKind = 0
        Me.FarmPanel.FormID = Nothing
        Me.FarmPanel.HelpTopicID = Nothing
        Me.FarmPanel.IsStatusReadOnly = False
        Me.FarmPanel.KeyFieldName = "idfFarm"
        Me.FarmPanel.MultiSelect = False
        Me.FarmPanel.Name = "FarmPanel"
        Me.FarmPanel.ObjectName = "Farm"
        Me.FarmPanel.TableName = "Farm"
        Me.FarmPanel.UseParentBackColor = True
        '
        'AvianFarmProductionControl1
        '
        resources.ApplyResources(Me.AvianFarmProductionControl1, "AvianFarmProductionControl1")
        Me.AvianFarmProductionControl1.Appearance.BackColor = CType(resources.GetObject("AvianFarmProductionControl1.Appearance.BackColor"), System.Drawing.Color)
        Me.AvianFarmProductionControl1.Appearance.Options.UseBackColor = True
        Me.AvianFarmProductionControl1.FormID = Nothing
        Me.AvianFarmProductionControl1.HelpTopicID = Nothing
        Me.AvianFarmProductionControl1.IsStatusReadOnly = False
        Me.AvianFarmProductionControl1.KeyFieldName = "idfFarm"
        Me.AvianFarmProductionControl1.MultiSelect = False
        Me.AvianFarmProductionControl1.Name = "AvianFarmProductionControl1"
        Me.AvianFarmProductionControl1.ObjectName = "AvianFarmProduction"
        Me.AvianFarmProductionControl1.TableName = "Farm"
        Me.AvianFarmProductionControl1.UseParentBackColor = True
        '
        'FarmDetailGroup
        '
        Me.FarmDetailGroup.Appearance.BackColor = CType(resources.GetObject("FarmDetailGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.FarmDetailGroup.Appearance.Options.UseBackColor = True
        Me.FarmDetailGroup.Appearance.Options.UseFont = True
        Me.FarmDetailGroup.AppearanceCaption.Options.UseFont = True
        Me.FarmDetailGroup.Controls.Add(Me.AvianFarmDetail1)
        resources.ApplyResources(Me.FarmDetailGroup, "FarmDetailGroup")
        Me.FarmDetailGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.FarmDetailGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.FarmDetailGroup.Name = "FarmDetailGroup"
        Me.FarmDetailGroup.TabStop = True
        '
        'AvianFarmDetail1
        '
        resources.ApplyResources(Me.AvianFarmDetail1, "AvianFarmDetail1")
        Me.AvianFarmDetail1.FormID = Nothing
        Me.AvianFarmDetail1.HelpTopicID = Nothing
        Me.AvianFarmDetail1.IsStatusReadOnly = False
        Me.AvianFarmDetail1.KeyFieldName = "idfFarm"
        Me.AvianFarmDetail1.MultiSelect = False
        Me.AvianFarmDetail1.Name = "AvianFarmDetail1"
        Me.AvianFarmDetail1.ObjectName = Nothing
        Me.AvianFarmDetail1.TableName = "Farm"
        '
        'HerdTab
        '
        Me.HerdTab.Controls.Add(Me.FarmTreePanel1)
        Me.HerdTab.Name = "HerdTab"
        resources.ApplyResources(Me.HerdTab, "HerdTab")
        '
        'FarmTreePanel1
        '
        Me.FarmTreePanel1.Appearance.BackColor = CType(resources.GetObject("FarmTreePanel1.Appearance.BackColor"), System.Drawing.Color)
        Me.FarmTreePanel1.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me.FarmTreePanel1, "FarmTreePanel1")
        Me.FarmTreePanel1.CaseKind = eidss.CaseType.Avian
        Me.FarmTreePanel1.FormID = Nothing
        Me.FarmTreePanel1.HelpTopicID = Nothing
        Me.FarmTreePanel1.HidePersonalData = False
        Me.FarmTreePanel1.IsStatusReadOnly = False
        Me.FarmTreePanel1.KeyFieldName = "idfParty"
        Me.FarmTreePanel1.MultiSelect = False
        Me.FarmTreePanel1.Name = "FarmTreePanel1"
        Me.FarmTreePanel1.ObjectName = "VetFarmTree"
        Me.FarmTreePanel1.SamplesList = Nothing
        Me.FarmTreePanel1.TableName = "VetFarmTree"
        Me.FarmTreePanel1.UseParentBackColor = True
        '
        'DiagnosesPage
        '
        Me.DiagnosesPage.Controls.Add(Me.VaccinationPanel1)
        Me.DiagnosesPage.Controls.Add(Me.VetDiagnosisPanel1)
        Me.DiagnosesPage.Controls.Add(Me.CommentsGroup)
        Me.DiagnosesPage.Name = "DiagnosesPage"
        resources.ApplyResources(Me.DiagnosesPage, "DiagnosesPage")
        '
        'VaccinationPanel1
        '
        resources.ApplyResources(Me.VaccinationPanel1, "VaccinationPanel1")
        Me.VaccinationPanel1.FormID = Nothing
        Me.VaccinationPanel1.HelpTopicID = Nothing
        Me.VaccinationPanel1.IsStatusReadOnly = False
        Me.VaccinationPanel1.KeyFieldName = Nothing
        Me.VaccinationPanel1.MultiSelect = False
        Me.VaccinationPanel1.Name = "VaccinationPanel1"
        Me.VaccinationPanel1.ObjectName = Nothing
        Me.VaccinationPanel1.TableName = Nothing
        '
        'VetDiagnosisPanel1
        '
        Me.VetDiagnosisPanel1.Appearance.BackColor = CType(resources.GetObject("VetDiagnosisPanel1.Appearance.BackColor"), System.Drawing.Color)
        Me.VetDiagnosisPanel1.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me.VetDiagnosisPanel1, "VetDiagnosisPanel1")
        Me.VetDiagnosisPanel1.CaseKind = eidss.CaseType.Avian
        Me.VetDiagnosisPanel1.FormID = Nothing
        Me.VetDiagnosisPanel1.HelpTopicID = Nothing
        Me.VetDiagnosisPanel1.IsStatusReadOnly = False
        Me.VetDiagnosisPanel1.KeyFieldName = "idfCase"
        Me.VetDiagnosisPanel1.MultiSelect = False
        Me.VetDiagnosisPanel1.Name = "VetDiagnosisPanel1"
        Me.VetDiagnosisPanel1.ObjectName = "VetCase"
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
        'SamplesPage
        '
        Me.SamplesPage.Controls.Add(Me.CaseSamplesPanel1)
        Me.SamplesPage.Name = "SamplesPage"
        resources.ApplyResources(Me.SamplesPage, "SamplesPage")
        '
        'CaseSamplesPanel1
        '
        resources.ApplyResources(Me.CaseSamplesPanel1, "CaseSamplesPanel1")
        Me.CaseSamplesPanel1.FormID = Nothing
        Me.CaseSamplesPanel1.HelpTopicID = Nothing
        Me.CaseSamplesPanel1.IsStatusReadOnly = False
        Me.CaseSamplesPanel1.KeyFieldName = "idfMaterial"
        Me.CaseSamplesPanel1.MultiSelect = False
        Me.CaseSamplesPanel1.Name = "CaseSamplesPanel1"
        Me.CaseSamplesPanel1.ObjectName = "CaseSamples"
        Me.CaseSamplesPanel1.ShowNewButton = False
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
        Me.PensideTestPanel1.FormID = Nothing
        Me.PensideTestPanel1.HelpTopicID = Nothing
        Me.PensideTestPanel1.IsStatusReadOnly = False
        Me.PensideTestPanel1.KeyFieldName = Nothing
        Me.PensideTestPanel1.MultiSelect = False
        Me.PensideTestPanel1.Name = "PensideTestPanel1"
        Me.PensideTestPanel1.ObjectName = Nothing
        Me.PensideTestPanel1.TableName = Nothing
        '
        'LabTestsPage
        '
        Me.LabTestsPage.Controls.Add(Me.lbTestsConducted)
        Me.LabTestsPage.Controls.Add(Me.cbTestsConducted)
        Me.LabTestsPage.Controls.Add(Me.CaseTestsPanel1)
        Me.LabTestsPage.Name = "LabTestsPage"
        resources.ApplyResources(Me.LabTestsPage, "LabTestsPage")
        '
        'lbTestsConducted
        '
        resources.ApplyResources(Me.lbTestsConducted, "lbTestsConducted")
        Me.lbTestsConducted.Name = "lbTestsConducted"
        '
        'cbTestsConducted
        '
        resources.ApplyResources(Me.cbTestsConducted, "cbTestsConducted")
        Me.cbTestsConducted.Name = "cbTestsConducted"
        Me.cbTestsConducted.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestsConducted.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'CaseTestsPanel1
        '
        Me.CaseTestsPanel1.Appearance.BackColor = CType(resources.GetObject("CaseTestsPanel1.Appearance.BackColor"), System.Drawing.Color)
        Me.CaseTestsPanel1.Appearance.Font = CType(resources.GetObject("CaseTestsPanel1.Appearance.Font"), System.Drawing.Font)
        Me.CaseTestsPanel1.Appearance.Options.UseBackColor = True
        Me.CaseTestsPanel1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.CaseTestsPanel1, "CaseTestsPanel1")
        Me.CaseTestsPanel1.FormID = Nothing
        Me.CaseTestsPanel1.HelpTopicID = Nothing
        Me.CaseTestsPanel1.IsStatusReadOnly = False
        Me.CaseTestsPanel1.KeyFieldName = Nothing
        Me.CaseTestsPanel1.MultiSelect = False
        Me.CaseTestsPanel1.Name = "CaseTestsPanel1"
        Me.CaseTestsPanel1.ObjectName = "CaseTest"
        Me.CaseTestsPanel1.TableName = Nothing
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
        Me.CaseLog1.FormID = Nothing
        Me.CaseLog1.HelpTopicID = Nothing
        Me.CaseLog1.IsStatusReadOnly = False
        Me.CaseLog1.KeyFieldName = Nothing
        Me.CaseLog1.MultiSelect = False
        Me.CaseLog1.Name = "CaseLog1"
        Me.CaseLog1.ObjectName = Nothing
        Me.CaseLog1.TableName = Nothing
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
        'VetCaseAvianDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("VetCaseAvianDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.PopUpButton1)
        Me.Controls.Add(Me.VetStatusPanel1)
        Me.Controls.Add(Me.TabContol)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "V03"
        Me.HelpTopicID = "VetCaseAvianDetailForm"
        Me.KeyFieldName = "idfCase"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "VetCaseAvianDetail"
        Me.ObjectName = "VetCase"
        Me.Status = bv.common.win.FormStatus.Draft
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
        CType(Me.FarmDetailGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FarmDetailGroup.ResumeLayout(False)
        Me.HerdTab.ResumeLayout(False)
        Me.DiagnosesPage.ResumeLayout(False)
        CType(Me.CommentsGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CommentsGroup.ResumeLayout(False)
        CType(Me.txtCaseNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SamplesPage.ResumeLayout(False)
        Me.PensideTestPage.ResumeLayout(False)
        Me.LabTestsPage.ResumeLayout(False)
        CType(Me.cbTestsConducted.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CaseLogTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Main form interface"

    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        If eidss.model.Core.EidssSiteContext.Instance.IsReadOnlySite Then
            Return
        End If
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Create, "MenuNewVetCaseAvian", 405)
        ma.ShowInToolbar = False
        ma.BigIconIndex = MenuIcons.NewAvianCase
        ma.SmallIconIndex = MenuIconsSmall.AvianCase
        ma.Name = "btnNewAvianCase"
        ma.SelectPermission = PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.VetCase)
        ma = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals, "ToolbarNewVetCaseAvian", 204)
        ma.ShowInToolbar = True
        ma.ShowInMenu = False
        ma.BigIconIndex = MenuIcons.NewAvianCase
        ma.Name = "btnNewToolbarAvianCase"
        ma.Order = 204
        ma.SelectPermission = PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.VetCase)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New VetCaseAvianDetail, Nothing)
        'BaseForm.ShowModal(New VetCaseAvianDetail)
    End Sub
#End Region

#Region "Reports"

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

            EidssSiteContext.ReportFactory.VetAvianInvestigation(id, diagnosisID)
        End If

    End Sub

#End Region

#Region "Flexible Forms"

    Private Function GetFarmDetailTemplate() As String
        Dim err As ErrorMessage = Nothing
        Dim st, stCountry As String

        Try
            stCountry = eidss.model.Core.EidssSiteContext.Instance.CountryID.ToString
            st = VetCaseDbService.GetFFTemplate("ftyFarm Details", stCountry)
        Catch ex As Exception
            err = New ErrorMessage(StandardError.FillDatasetError, ex)
            st = ""
        End Try
        Return st
    End Function

#End Region
    Private Sub InitCustomMandatoryFields()
        MandatoryFieldHelper.SetCustomAddressMandatoryField(FarmPanel.AddressPanel, CustomMandatoryField.VetCase_Farm_Address_Settlement, AddressMandatoryFieldsType.Settlement)
    End Sub

    Protected Overrides Sub DefineBinding()
        FarmPanel.HidePersonalData = Not baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfPersonEnteredBy").Equals(EidssUserContext.User.EmployeeID)
        AddHandler FarmPanel.OnFarmChanging, AddressOf OnFarmChanging
        AddHandler FarmPanel.OnFarmChanged, AddressOf OnFarmChanged
        AddHandler FarmPanel.OnFarmCodeChanged, AddressOf OnFarmCodeChanged
        AddHandler CaseSamplesPanel1.OnSampleChanged, AddressOf OnSampleChanged
        AddHandler CaseSamplesPanel1.OnDeleteSample, AddressOf OnSampleDelete
        AddHandler CaseTestsPanel1.OnTestsCollectionChanged, AddressOf OnTestsCollectionChanged
        AddHandler VetCaseRegistrationPanel1.OnInvestigationDateChanged, AddressOf OnInvestigationDateChanged
        Core.LookupBinder.BindTextEdit(txtCaseNotes, baseDataSet, VetCase_DB.TableVetCase + ".strSummaryNotes")
        Core.LookupBinder.BindBaseLookup(cbTestsConducted, baseDataSet, VetCase_DB.TableVetCase + ".idfsYNTestsConducted", db.BaseReferenceType.rftYesNoValue, False)
        SetControlReadOnly(cbTestsConducted, Not CBool(baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("blnEnableTestsConducted")), False)
        'eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".idfsYNTestsConducted", AddressOf TestConducted_Changed)
        'eventManager.Cascade(VetCase_DB.TableVetCase + ".idfsYNTestsConducted")
        FarmPanel.FarmKind = 2

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

    Public Overrides Function GetChildKey(ByVal child As bv.common.win.IRelatedObject) As Object
        'Dim FFID As FlexibleForm_DB.FlexibeFormObject

        If child Is FarmPanel OrElse child Is AvianFarmProductionControl1 Then
            Return GetKey(VetCase_DB.TableVetCase, "idfFarm")
        End If

        If child Is AvianFarmDetail1 Then
            Return GetKey(VetCase_DB.TableVetCase, "idfFarm")
        End If

        Return GetKey()
    End Function

    Protected Overrides Sub AfterLoad()
        CaseSamplesPanel1.CasePartyList = FarmTreePanel1.SpieciesList
        CaseTestsPanel1.SamplesView = CaseSamplesPanel1.SamplesList
        PensideTestPanel1.SamplesView = CaseSamplesPanel1.SamplesList
        PensideTestPanel1.PartyList = FarmTreePanel1.SpieciesList
        FarmTreePanel1.SamplesList = CaseSamplesPanel1.SamplesList
        VaccinationPanel1.SpeciesList = FarmTreePanel1.SpieciesList
        FarmTreePanel1.CanDeleteRow = AddressOf CanDeleteFarmTreeNode
        If (Me.State And BusinessObjectState.NewObject) <> 0 Then
            If Utils.IsEmpty(FarmPanel.RootFarmID) Then
                FarmPanel.RootFarmID = BaseDbService.NewIntID
            End If
            OnFarmChanged(FarmPanel.RootFarmID)
        End If
        FarmPanel.CaseID = GetKey()
        FarmPanel.FarmKind = 2
        OnInvestigationDateChanged(VetCaseRegistrationPanel1, EventArgs.Empty)

    End Sub

    Private Function CanDeleteFarmTreeNode(ByVal row As DataRow) As Boolean
        Return CaseSamplesPanel1.CanDeleteFarmTreeNode(row) AndAlso PensideTestPanel1.CanDeleteFarmTreeNode(row) AndAlso VaccinationPanel1.CanDeleteFarmTreeNode(row)
    End Function

    Private Sub VetDiagnosisPanel1_DiagnosisChanged() Handles VetDiagnosisPanel1.DiagnosisChanged
        Me.CaseSamplesPanel1.DiagnosisList = VetDiagnosisPanel1.DiagnosisList
        Me.CaseTestsPanel1.DiagnosisList = VetDiagnosisPanel1.DiagnosisList
        Me.CaseTestsPanel1.DiagnosisID = VetDiagnosisPanel1.CurrentDiagnosesID
        Me.FarmTreePanel1.DiagnosisID = VetDiagnosisPanel1.CurrentDiagnosesID
        Me.VetStatusPanel1.SetDisease(VetDiagnosisPanel1.CurrentDiagnosesID, VetDiagnosisPanel1.AllDiagnoses)
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
        'If showDeletePrompt AndAlso MessageForm.Show(EidssMessages.Get("msgConfirmCaseFarmDeleteAvian", "You are going to replace the current farm with the new one. All herds, animals, samples and tests records related with current farm will be assigned to the new farm. Replace the farm?"), EidssMessages.Get("titleDeleteFarm", "Replace Farm"), MessageBoxButtons.YesNo) <> DialogResult.Yes Then
        '    Cancel = True
        '    Return
        'End If
    End Sub
    Public Sub OnFarmChanged(ByVal RootFarmID As Object)
        baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfRootFarm") = RootFarmID
        FarmTreePanel1.ChangeFarm(RootFarmID, FarmPanel.FarmID, Utils.Str(FarmPanel.FarmCode))
        AvianFarmProductionControl1.LoadData(RootFarmID)
        AvianFarmProductionControl1.RootFarmID = RootFarmID
        AvianFarmProductionControl1.baseDataSet.Tables(AvianFarmProduction_DB.TableFarm).Rows(0)("idfFarm") = FarmPanel.FarmID
    End Sub
    Public Sub OnFarmCodeChanged(ByVal newFarmCode As Object)
        Me.FarmTreePanel1.FarmCode = Utils.Str(newFarmCode)
    End Sub
#End Region


    Private Sub VetCaseAvianDetail_OnAfterPost(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnAfterPost
        'AfterLoad()
        If sender Is Me Then
            FarmTreePanel1.FarmCode = FarmPanel.FarmCode
        End If
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

    Private Sub OnSampleDelete(ByVal sender As Object, ByVal e As DataRowEventArgs)
        Dim sampleID As Object = e.Row("idfMaterial")
        e.Cancel = Not PensideTestPanel1.CanDeleteSample(sampleID) OrElse Not CaseTestsPanel1.CanDeleteSample(sampleID)
    End Sub
    Private Sub OnInvestigationDateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsDBNull(VetCaseRegistrationPanel1.InvestigationDate) Then
            Me.VetDiagnosisPanel1.DefaultDiagnosisDate = DateTime.MinValue
        Else
            Me.VetDiagnosisPanel1.DefaultDiagnosisDate = CType(VetCaseRegistrationPanel1.InvestigationDate, DateTime)
        End If
    End Sub
    Public Overrides Sub ShowHelp()
        If TabContol.ContainsFocus Then

            Select Case Me.TabContol.SelectedTabPage.Name
                Case "DemographicsPage"
                    ShowHelp("AvianFarmDetailTab")
                Case "HerdTab"
                    ShowHelp("AvianHerdTab")
                Case "DiagnosesPage"
                    ShowHelp("AvianDiagnosisTab")
                Case "SamplesPage"
                    ShowHelp("AvianSamplesTab")
                Case "LabTestsPage"
                    ShowHelp("AvianLabTestsTab")
                Case "PensideTestPage"
                    ShowHelp("AvianPenSideTestsTab")
                Case "CaseLogTab"
                    'TODO: append help with this tab description and make correct help link
                    MyBase.ShowHelp()
                Case Else
                    MyBase.ShowHelp()
            End Select
        Else
            MyBase.ShowHelp()
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
            TabContol.SelectedTabPage = DiagnosesPage
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
