Imports EIDSS.model.Enums

Public Class VetCaseRegistrationPanel
    Inherits bv.common.win.BaseDetailPanel

#Region " Windows Form Designer generated code "
    Public VetRegistrationDbService As VetCase_DB

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        VetRegistrationDbService = New VetCase_DB
        DbService = VetRegistrationDbService
        InitCustomMandatoryFields()
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
    Friend WithEvents InvestigatedByGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dtInvestigationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbInvestigationDate As System.Windows.Forms.Label
    Friend WithEvents cbInvestigatedBy As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EnteredByGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dtEnteredDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSite As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ReportedByGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dtReportDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbReportedBy As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAssignedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbAssignedDate As System.Windows.Forms.Label
    Friend WithEvents txtEnteredBy As DevExpress.XtraEditors.LookUpEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetCaseRegistrationPanel))
        Me.InvestigatedByGroup = New DevExpress.XtraEditors.GroupControl()
        Me.txtAssignedDate = New DevExpress.XtraEditors.DateEdit()
        Me.lbAssignedDate = New System.Windows.Forms.Label()
        Me.dtInvestigationDate = New DevExpress.XtraEditors.DateEdit()
        Me.lbInvestigationDate = New System.Windows.Forms.Label()
        Me.cbInvestigatedBy = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.EnteredByGroup = New DevExpress.XtraEditors.GroupControl()
        Me.txtEnteredBy = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtEnteredDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSite = New DevExpress.XtraEditors.LookUpEdit()
        Me.ReportedByGroup = New DevExpress.XtraEditors.GroupControl()
        Me.dtReportDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbReportedBy = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.InvestigatedByGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InvestigatedByGroup.SuspendLayout()
        CType(Me.txtAssignedDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAssignedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtInvestigationDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtInvestigationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbInvestigatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnteredByGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EnteredByGroup.SuspendLayout()
        CType(Me.txtEnteredBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEnteredDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEnteredDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportedByGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ReportedByGroup.SuspendLayout()
        CType(Me.dtReportDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtReportDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbReportedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(VetCaseRegistrationPanel), resources)
        'Form Is Localizable: True
        '
        'InvestigatedByGroup
        '
        resources.ApplyResources(Me.InvestigatedByGroup, "InvestigatedByGroup")
        Me.InvestigatedByGroup.Appearance.BackColor = CType(resources.GetObject("InvestigatedByGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.InvestigatedByGroup.Appearance.GradientMode = CType(resources.GetObject("InvestigatedByGroup.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.InvestigatedByGroup.Appearance.Image = CType(resources.GetObject("InvestigatedByGroup.Appearance.Image"), System.Drawing.Image)
        Me.InvestigatedByGroup.Appearance.Options.UseBackColor = True
        Me.InvestigatedByGroup.AppearanceCaption.GradientMode = CType(resources.GetObject("InvestigatedByGroup.AppearanceCaption.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.InvestigatedByGroup.AppearanceCaption.Image = CType(resources.GetObject("InvestigatedByGroup.AppearanceCaption.Image"), System.Drawing.Image)
        Me.InvestigatedByGroup.AppearanceCaption.Options.UseFont = True
        Me.InvestigatedByGroup.Controls.Add(Me.txtAssignedDate)
        Me.InvestigatedByGroup.Controls.Add(Me.lbAssignedDate)
        Me.InvestigatedByGroup.Controls.Add(Me.dtInvestigationDate)
        Me.InvestigatedByGroup.Controls.Add(Me.lbInvestigationDate)
        Me.InvestigatedByGroup.Controls.Add(Me.cbInvestigatedBy)
        Me.InvestigatedByGroup.Controls.Add(Me.Label6)
        Me.InvestigatedByGroup.Name = "InvestigatedByGroup"
        '
        'txtAssignedDate
        '
        resources.ApplyResources(Me.txtAssignedDate, "txtAssignedDate")
        Me.txtAssignedDate.Name = "txtAssignedDate"
        Me.txtAssignedDate.Properties.AccessibleDescription = resources.GetString("txtAssignedDate.Properties.AccessibleDescription")
        Me.txtAssignedDate.Properties.AccessibleName = resources.GetString("txtAssignedDate.Properties.AccessibleName")
        Me.txtAssignedDate.Properties.AutoHeight = CType(resources.GetObject("txtAssignedDate.Properties.AutoHeight"), Boolean)
        Me.txtAssignedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtAssignedDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtAssignedDate.Properties.Mask.AutoComplete = CType(resources.GetObject("txtAssignedDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtAssignedDate.Properties.Mask.BeepOnError = CType(resources.GetObject("txtAssignedDate.Properties.Mask.BeepOnError"), Boolean)
        Me.txtAssignedDate.Properties.Mask.EditMask = resources.GetString("txtAssignedDate.Properties.Mask.EditMask")
        Me.txtAssignedDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtAssignedDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtAssignedDate.Properties.Mask.MaskType = CType(resources.GetObject("txtAssignedDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtAssignedDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtAssignedDate.Properties.Mask.PlaceHolder"), Char)
        Me.txtAssignedDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtAssignedDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtAssignedDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtAssignedDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtAssignedDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtAssignedDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtAssignedDate.Properties.NullValuePrompt = resources.GetString("txtAssignedDate.Properties.NullValuePrompt")
        Me.txtAssignedDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtAssignedDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtAssignedDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("txtAssignedDate.Properties.VistaTimeProperties.AccessibleDescription")
        Me.txtAssignedDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("txtAssignedDate.Properties.VistaTimeProperties.AccessibleName")
        Me.txtAssignedDate.Properties.VistaTimeProperties.AutoHeight = CType(resources.GetObject("txtAssignedDate.Properties.VistaTimeProperties.AutoHeight"), Boolean)
        Me.txtAssignedDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtAssignedDate.Properties.VistaTimeProperties.Mask.AutoComplete = CType(resources.GetObject("txtAssignedDate.Properties.VistaTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtAssignedDate.Properties.VistaTimeProperties.Mask.BeepOnError = CType(resources.GetObject("txtAssignedDate.Properties.VistaTimeProperties.Mask.BeepOnError"), Boolean)
        Me.txtAssignedDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("txtAssignedDate.Properties.VistaTimeProperties.Mask.EditMask")
        Me.txtAssignedDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtAssignedDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtAssignedDate.Properties.VistaTimeProperties.Mask.MaskType = CType(resources.GetObject("txtAssignedDate.Properties.VistaTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtAssignedDate.Properties.VistaTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("txtAssignedDate.Properties.VistaTimeProperties.Mask.PlaceHolder"), Char)
        Me.txtAssignedDate.Properties.VistaTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("txtAssignedDate.Properties.VistaTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.txtAssignedDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtAssignedDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtAssignedDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtAssignedDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtAssignedDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("txtAssignedDate.Properties.VistaTimeProperties.NullValuePrompt")
        Me.txtAssignedDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtAssignedDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtAssignedDate.Tag = ""
        '
        'lbAssignedDate
        '
        resources.ApplyResources(Me.lbAssignedDate, "lbAssignedDate")
        Me.lbAssignedDate.Name = "lbAssignedDate"
        '
        'dtInvestigationDate
        '
        resources.ApplyResources(Me.dtInvestigationDate, "dtInvestigationDate")
        Me.dtInvestigationDate.Name = "dtInvestigationDate"
        Me.dtInvestigationDate.Properties.AccessibleDescription = resources.GetString("dtInvestigationDate.Properties.AccessibleDescription")
        Me.dtInvestigationDate.Properties.AccessibleName = resources.GetString("dtInvestigationDate.Properties.AccessibleName")
        Me.dtInvestigationDate.Properties.AutoHeight = CType(resources.GetObject("dtInvestigationDate.Properties.AutoHeight"), Boolean)
        Me.dtInvestigationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtInvestigationDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtInvestigationDate.Properties.Mask.AutoComplete = CType(resources.GetObject("dtInvestigationDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtInvestigationDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtInvestigationDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtInvestigationDate.Properties.Mask.EditMask = resources.GetString("dtInvestigationDate.Properties.Mask.EditMask")
        Me.dtInvestigationDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtInvestigationDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtInvestigationDate.Properties.Mask.MaskType = CType(resources.GetObject("dtInvestigationDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtInvestigationDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtInvestigationDate.Properties.Mask.PlaceHolder"), Char)
        Me.dtInvestigationDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtInvestigationDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtInvestigationDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtInvestigationDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtInvestigationDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtInvestigationDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtInvestigationDate.Properties.NullValuePrompt = resources.GetString("dtInvestigationDate.Properties.NullValuePrompt")
        Me.dtInvestigationDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtInvestigationDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtInvestigationDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtInvestigationDate.Properties.VistaTimeProperties.AccessibleDescription")
        Me.dtInvestigationDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtInvestigationDate.Properties.VistaTimeProperties.AccessibleName")
        Me.dtInvestigationDate.Properties.VistaTimeProperties.AutoHeight = CType(resources.GetObject("dtInvestigationDate.Properties.VistaTimeProperties.AutoHeight"), Boolean)
        Me.dtInvestigationDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtInvestigationDate.Properties.VistaTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtInvestigationDate.Properties.VistaTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtInvestigationDate.Properties.VistaTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtInvestigationDate.Properties.VistaTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtInvestigationDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtInvestigationDate.Properties.VistaTimeProperties.Mask.EditMask")
        Me.dtInvestigationDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtInvestigationDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtInvestigationDate.Properties.VistaTimeProperties.Mask.MaskType = CType(resources.GetObject("dtInvestigationDate.Properties.VistaTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtInvestigationDate.Properties.VistaTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtInvestigationDate.Properties.VistaTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtInvestigationDate.Properties.VistaTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtInvestigationDate.Properties.VistaTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtInvestigationDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtInvestigationDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtInvestigationDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtInvestigationDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtInvestigationDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtInvestigationDate.Properties.VistaTimeProperties.NullValuePrompt")
        Me.dtInvestigationDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtInvestigationDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyVal" & _
        "ue"), Boolean)
        Me.dtInvestigationDate.Tag = ""
        '
        'lbInvestigationDate
        '
        resources.ApplyResources(Me.lbInvestigationDate, "lbInvestigationDate")
        Me.lbInvestigationDate.Name = "lbInvestigationDate"
        '
        'cbInvestigatedBy
        '
        resources.ApplyResources(Me.cbInvestigatedBy, "cbInvestigatedBy")
        Me.cbInvestigatedBy.Name = "cbInvestigatedBy"
        Me.cbInvestigatedBy.Properties.AccessibleDescription = resources.GetString("cbInvestigatedBy.Properties.AccessibleDescription")
        Me.cbInvestigatedBy.Properties.AccessibleName = resources.GetString("cbInvestigatedBy.Properties.AccessibleName")
        Me.cbInvestigatedBy.Properties.AutoHeight = CType(resources.GetObject("cbInvestigatedBy.Properties.AutoHeight"), Boolean)
        Me.cbInvestigatedBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbInvestigatedBy.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbInvestigatedBy.Properties.NullText = resources.GetString("cbInvestigatedBy.Properties.NullText")
        Me.cbInvestigatedBy.Properties.NullValuePrompt = resources.GetString("cbInvestigatedBy.Properties.NullValuePrompt")
        Me.cbInvestigatedBy.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbInvestigatedBy.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbInvestigatedBy.Tag = ""
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'EnteredByGroup
        '
        resources.ApplyResources(Me.EnteredByGroup, "EnteredByGroup")
        Me.EnteredByGroup.Appearance.BackColor = CType(resources.GetObject("EnteredByGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.EnteredByGroup.Appearance.GradientMode = CType(resources.GetObject("EnteredByGroup.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.EnteredByGroup.Appearance.Image = CType(resources.GetObject("EnteredByGroup.Appearance.Image"), System.Drawing.Image)
        Me.EnteredByGroup.Appearance.Options.UseBackColor = True
        Me.EnteredByGroup.AppearanceCaption.GradientMode = CType(resources.GetObject("EnteredByGroup.AppearanceCaption.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.EnteredByGroup.AppearanceCaption.Image = CType(resources.GetObject("EnteredByGroup.AppearanceCaption.Image"), System.Drawing.Image)
        Me.EnteredByGroup.AppearanceCaption.Options.UseFont = True
        Me.EnteredByGroup.Controls.Add(Me.txtEnteredBy)
        Me.EnteredByGroup.Controls.Add(Me.dtEnteredDate)
        Me.EnteredByGroup.Controls.Add(Me.Label3)
        Me.EnteredByGroup.Controls.Add(Me.Label5)
        Me.EnteredByGroup.Controls.Add(Me.Label4)
        Me.EnteredByGroup.Controls.Add(Me.txtSite)
        Me.EnteredByGroup.Name = "EnteredByGroup"
        '
        'txtEnteredBy
        '
        resources.ApplyResources(Me.txtEnteredBy, "txtEnteredBy")
        Me.txtEnteredBy.Name = "txtEnteredBy"
        Me.txtEnteredBy.Properties.AccessibleDescription = resources.GetString("txtEnteredBy.Properties.AccessibleDescription")
        Me.txtEnteredBy.Properties.AccessibleName = resources.GetString("txtEnteredBy.Properties.AccessibleName")
        Me.txtEnteredBy.Properties.AutoHeight = CType(resources.GetObject("txtEnteredBy.Properties.AutoHeight"), Boolean)
        Me.txtEnteredBy.Properties.NullText = resources.GetString("txtEnteredBy.Properties.NullText")
        Me.txtEnteredBy.Properties.NullValuePrompt = resources.GetString("txtEnteredBy.Properties.NullValuePrompt")
        Me.txtEnteredBy.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtEnteredBy.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtEnteredBy.Tag = "{R}"
        '
        'dtEnteredDate
        '
        resources.ApplyResources(Me.dtEnteredDate, "dtEnteredDate")
        Me.dtEnteredDate.Name = "dtEnteredDate"
        Me.dtEnteredDate.Properties.AccessibleDescription = resources.GetString("dtEnteredDate.Properties.AccessibleDescription")
        Me.dtEnteredDate.Properties.AccessibleName = resources.GetString("dtEnteredDate.Properties.AccessibleName")
        Me.dtEnteredDate.Properties.AutoHeight = CType(resources.GetObject("dtEnteredDate.Properties.AutoHeight"), Boolean)
        Me.dtEnteredDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtEnteredDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtEnteredDate.Properties.DisplayFormat.FormatString = "g"
        Me.dtEnteredDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtEnteredDate.Properties.EditFormat.FormatString = "g"
        Me.dtEnteredDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtEnteredDate.Properties.Mask.AutoComplete = CType(resources.GetObject("dtEnteredDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtEnteredDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtEnteredDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtEnteredDate.Properties.Mask.EditMask = resources.GetString("dtEnteredDate.Properties.Mask.EditMask")
        Me.dtEnteredDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtEnteredDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtEnteredDate.Properties.Mask.MaskType = CType(resources.GetObject("dtEnteredDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtEnteredDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtEnteredDate.Properties.Mask.PlaceHolder"), Char)
        Me.dtEnteredDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtEnteredDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtEnteredDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtEnteredDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtEnteredDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtEnteredDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtEnteredDate.Properties.NullValuePrompt = resources.GetString("dtEnteredDate.Properties.NullValuePrompt")
        Me.dtEnteredDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtEnteredDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtEnteredDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtEnteredDate.Properties.VistaTimeProperties.AccessibleDescription")
        Me.dtEnteredDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtEnteredDate.Properties.VistaTimeProperties.AccessibleName")
        Me.dtEnteredDate.Properties.VistaTimeProperties.AutoHeight = CType(resources.GetObject("dtEnteredDate.Properties.VistaTimeProperties.AutoHeight"), Boolean)
        Me.dtEnteredDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtEnteredDate.Properties.VistaTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtEnteredDate.Properties.VistaTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtEnteredDate.Properties.VistaTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtEnteredDate.Properties.VistaTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtEnteredDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtEnteredDate.Properties.VistaTimeProperties.Mask.EditMask")
        Me.dtEnteredDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtEnteredDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtEnteredDate.Properties.VistaTimeProperties.Mask.MaskType = CType(resources.GetObject("dtEnteredDate.Properties.VistaTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtEnteredDate.Properties.VistaTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtEnteredDate.Properties.VistaTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtEnteredDate.Properties.VistaTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtEnteredDate.Properties.VistaTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtEnteredDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtEnteredDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtEnteredDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtEnteredDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtEnteredDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtEnteredDate.Properties.VistaTimeProperties.NullValuePrompt")
        Me.dtEnteredDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtEnteredDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtEnteredDate.Tag = "{R}"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtSite
        '
        resources.ApplyResources(Me.txtSite, "txtSite")
        Me.txtSite.Name = "txtSite"
        Me.txtSite.Properties.AccessibleDescription = resources.GetString("txtSite.Properties.AccessibleDescription")
        Me.txtSite.Properties.AccessibleName = resources.GetString("txtSite.Properties.AccessibleName")
        Me.txtSite.Properties.AutoHeight = CType(resources.GetObject("txtSite.Properties.AutoHeight"), Boolean)
        Me.txtSite.Properties.NullText = resources.GetString("txtSite.Properties.NullText")
        Me.txtSite.Properties.NullValuePrompt = resources.GetString("txtSite.Properties.NullValuePrompt")
        Me.txtSite.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtSite.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtSite.Tag = "{R}"
        '
        'ReportedByGroup
        '
        resources.ApplyResources(Me.ReportedByGroup, "ReportedByGroup")
        Me.ReportedByGroup.Appearance.BackColor = CType(resources.GetObject("ReportedByGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.ReportedByGroup.Appearance.GradientMode = CType(resources.GetObject("ReportedByGroup.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.ReportedByGroup.Appearance.Image = CType(resources.GetObject("ReportedByGroup.Appearance.Image"), System.Drawing.Image)
        Me.ReportedByGroup.Appearance.Options.UseBackColor = True
        Me.ReportedByGroup.AppearanceCaption.GradientMode = CType(resources.GetObject("ReportedByGroup.AppearanceCaption.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.ReportedByGroup.AppearanceCaption.Image = CType(resources.GetObject("ReportedByGroup.AppearanceCaption.Image"), System.Drawing.Image)
        Me.ReportedByGroup.AppearanceCaption.Options.UseFont = True
        Me.ReportedByGroup.Controls.Add(Me.dtReportDate)
        Me.ReportedByGroup.Controls.Add(Me.Label1)
        Me.ReportedByGroup.Controls.Add(Me.cbReportedBy)
        Me.ReportedByGroup.Controls.Add(Me.Label2)
        Me.ReportedByGroup.Name = "ReportedByGroup"
        '
        'dtReportDate
        '
        resources.ApplyResources(Me.dtReportDate, "dtReportDate")
        Me.dtReportDate.Name = "dtReportDate"
        Me.dtReportDate.Properties.AccessibleDescription = resources.GetString("dtReportDate.Properties.AccessibleDescription")
        Me.dtReportDate.Properties.AccessibleName = resources.GetString("dtReportDate.Properties.AccessibleName")
        Me.dtReportDate.Properties.AutoHeight = CType(resources.GetObject("dtReportDate.Properties.AutoHeight"), Boolean)
        Me.dtReportDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtReportDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtReportDate.Properties.Mask.AutoComplete = CType(resources.GetObject("dtReportDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtReportDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtReportDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtReportDate.Properties.Mask.EditMask = resources.GetString("dtReportDate.Properties.Mask.EditMask")
        Me.dtReportDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtReportDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtReportDate.Properties.Mask.MaskType = CType(resources.GetObject("dtReportDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtReportDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtReportDate.Properties.Mask.PlaceHolder"), Char)
        Me.dtReportDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtReportDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtReportDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtReportDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtReportDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtReportDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtReportDate.Properties.NullValuePrompt = resources.GetString("dtReportDate.Properties.NullValuePrompt")
        Me.dtReportDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtReportDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtReportDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtReportDate.Properties.VistaTimeProperties.AccessibleDescription")
        Me.dtReportDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtReportDate.Properties.VistaTimeProperties.AccessibleName")
        Me.dtReportDate.Properties.VistaTimeProperties.AutoHeight = CType(resources.GetObject("dtReportDate.Properties.VistaTimeProperties.AutoHeight"), Boolean)
        Me.dtReportDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtReportDate.Properties.VistaTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtReportDate.Properties.VistaTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtReportDate.Properties.VistaTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtReportDate.Properties.VistaTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtReportDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtReportDate.Properties.VistaTimeProperties.Mask.EditMask")
        Me.dtReportDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtReportDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtReportDate.Properties.VistaTimeProperties.Mask.MaskType = CType(resources.GetObject("dtReportDate.Properties.VistaTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtReportDate.Properties.VistaTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtReportDate.Properties.VistaTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtReportDate.Properties.VistaTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtReportDate.Properties.VistaTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtReportDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtReportDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtReportDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtReportDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtReportDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtReportDate.Properties.VistaTimeProperties.NullValuePrompt")
        Me.dtReportDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtReportDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtReportDate.Tag = ""
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cbReportedBy
        '
        resources.ApplyResources(Me.cbReportedBy, "cbReportedBy")
        Me.cbReportedBy.Name = "cbReportedBy"
        Me.cbReportedBy.Properties.AccessibleDescription = resources.GetString("cbReportedBy.Properties.AccessibleDescription")
        Me.cbReportedBy.Properties.AccessibleName = resources.GetString("cbReportedBy.Properties.AccessibleName")
        Me.cbReportedBy.Properties.AutoHeight = CType(resources.GetObject("cbReportedBy.Properties.AutoHeight"), Boolean)
        Me.cbReportedBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReportedBy.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbReportedBy.Properties.NullText = resources.GetString("cbReportedBy.Properties.NullText")
        Me.cbReportedBy.Properties.NullValuePrompt = resources.GetString("cbReportedBy.Properties.NullValuePrompt")
        Me.cbReportedBy.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbReportedBy.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbReportedBy.Tag = ""
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'VetCaseRegistrationPanel
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.ReportedByGroup)
        Me.Controls.Add(Me.InvestigatedByGroup)
        Me.Controls.Add(Me.EnteredByGroup)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.KeyFieldName = "idfCase"
        Me.Name = "VetCaseRegistrationPanel"
        Me.ObjectName = "VetCaseRegistration"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "VetCase"
        CType(Me.InvestigatedByGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InvestigatedByGroup.ResumeLayout(False)
        CType(Me.txtAssignedDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAssignedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtInvestigationDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtInvestigationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbInvestigatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnteredByGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EnteredByGroup.ResumeLayout(False)
        CType(Me.txtEnteredBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEnteredDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEnteredDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportedByGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ReportedByGroup.ResumeLayout(False)
        CType(Me.dtReportDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtReportDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbReportedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Event OnInvestigationDateChanged As EventHandler
    Private Sub InitCustomMandatoryFields()
        MandatoryFieldHelper.SetCustomMandatoryField(cbReportedBy, CustomMandatoryField.VetCase_PersonReportedBy)
    End Sub

    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindDateEdit(dtEnteredDate, baseDataSet, VetCase_DB.TableVetCase + ".datEnteredDate")
        Core.LookupBinder.BindDateEdit(dtReportDate, baseDataSet, VetCase_DB.TableVetCase + ".datReportDate")
        Core.LookupBinder.BindDateEdit(dtInvestigationDate, baseDataSet, VetCase_DB.TableVetCase + ".datInvestigationDate")
        Core.LookupBinder.BindDateEdit(txtAssignedDate, baseDataSet, VetCase_DB.TableVetCase + ".datAssignedDate")
        Core.LookupBinder.BindSiteLookup(txtSite, baseDataSet, VetCase_DB.TableVetCase + ".idfsSite")
        Core.LookupBinder.BindPersonLookup(txtEnteredBy, baseDataSet, VetCase_DB.TableVetCase + ".idfPersonEnteredBy")
        Core.LookupBinder.BindPersonLookup(cbReportedBy, baseDataSet, VetCase_DB.TableVetCase + ".idfPersonReportedBy")
        Core.LookupBinder.BindPersonLookup(cbInvestigatedBy, baseDataSet, VetCase_DB.TableVetCase + ".idfPersonInvestigatedBy")
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".datInvestigationDate", AddressOf InvestigationDateChanged_Changed)

    End Sub
    Private Sub InvestigationDateChanged_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        RaiseEvent OnInvestigationDateChanged(Me, EventArgs.Empty)
    End Sub

    Private Function GetField(ByVal fieldName As String) As Object
        If IsDesignMode() Then Return Nothing
        If Not baseDataSet.Tables(VetCase_DB.TableVetCase) Is Nothing _
            AndAlso baseDataSet.Tables(VetCase_DB.TableVetCase).Rows.Count > 0 Then
            Return baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)(fieldName)
        End If
        Return Nothing
    End Function

    Private Function SetField(ByVal fieldName As String, ByVal value As Object) As Object
        If IsDesignMode() OrElse Not Created Then Return Nothing
        If Not baseDataSet.Tables(VetCase_DB.TableVetCase) Is Nothing _
            AndAlso baseDataSet.Tables(VetCase_DB.TableVetCase).Rows.Count > 0 Then
            baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)(fieldName) = value
            Return value
        End If
        Return DBNull.Value
    End Function


    Public ReadOnly Property InvestigationDate() As Object
        Get
            Return GetField("datInvestigationDate")
        End Get
    End Property


    'Public Overrides Function ValidateData() As Boolean
    '    Dim row As DataRow = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)
    '    If Not bv.winclient.Core.WinUtils.CompareDates(row("datInvestigationDate"), DateTime.Today, "datInvestigationDate_CurrentDate_msgId") Then
    '        dtInvestigationDate.Focus()
    '        Return False
    '    End If
    '    If Not bv.winclient.Core.WinUtils.CompareDates(row("datReportDate"), DateTime.Today, "datReportDate_CurrentDate_msgId") Then
    '        dtReportDate.Focus()
    '        Return False
    '    End If
    '    If Not bv.winclient.Core.WinUtils.CompareDates(row("datAssignedDate"), DateTime.Today, "datAssignedDate_CurrentDate_msgId") Then
    '        txtAssignedDate.Focus()
    '        Return False
    '    End If
    '    If Not bv.winclient.Core.WinUtils.CompareDates(row("datReportDate"), row("datAssignedDate"), "datAssignedDate_VetCaseDatesRule_msgId") Then
    '        txtAssignedDate.Focus()
    '        Return False
    '    End If
    '    If Not MyBase.ValidateData() Then
    '        Return False
    '    End If

    '    Return True
    'End Function
    '<System.ComponentModel.Browsable(False), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property ValidationDate As Object
        Get
            If (baseDataSet.Tables(VetCase_DB.TableVetCase).Rows.Count = 0) Then
                Return DBNull.Value
            End If
            Dim row As DataRow = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)

            If Not row("datAssignedDate") Is DBNull.Value Then
                Return row("datAssignedDate")
            End If
            If Not row("datReportDate") Is DBNull.Value Then
                Return row("datReportDate")
            End If
            Return DBNull.Value
        End Get
    End Property
    <System.ComponentModel.Browsable(False), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property DateForValidationType As ValidationDateType
        Get
            If (baseDataSet.Tables(VetCase_DB.TableVetCase).Rows.Count = 0) Then
                Return ValidationDateType.None
            End If
            Dim row As DataRow = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)

            If Not row("datAssignedDate") Is DBNull.Value Then
                Return ValidationDateType.AssignedDate
            End If
            If Not row("datReportDate") Is DBNull.Value Then
                Return ValidationDateType.ReportedDate
            End If
            Return ValidationDateType.None
        End Get
    End Property

    Sub FocusValidationDate()
        If (baseDataSet.Tables(VetCase_DB.TableVetCase).Rows.Count = 0) Then
            Return
        End If
        Dim row As DataRow = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)

        If Not row("datReportDate") Is Nothing Then
            dtReportDate.Focus()
        End If
        If Not row("datAssignedDate") Is Nothing Then
            txtAssignedDate.Focus()
        End If
    End Sub

End Class
