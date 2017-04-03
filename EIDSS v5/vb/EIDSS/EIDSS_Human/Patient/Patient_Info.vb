Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports System.Collections.Generic
Imports eidss.model.Enums
Imports bv.winclient.Core

Public Class Patient_Info
    Inherits BaseDetailPanel

    Dim PatientDbService As Patient_DB


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        DebugTimer.Start("Patient Info Constructor")
        InitializeComponent()
        PatientDbService = New Patient_DB

        DbService = PatientDbService
        LookupTableNames = New String() {"Human"}
        'Add any initialization after the InitializeComponent() call
        RegisterChildObject(CurrentResidence_AddressLookup, RelatedPostOrder.PostFirst)
        RegisterChildObject(Employer_AddressLookup, RelatedPostOrder.PostFirst)
        PersonalDataString = "*"
        DebugTimer.Stop()
    End Sub

    <Browsable(False), DefaultValue(PersonalDataGroup.None), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property IgnorePersonalData As Boolean

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents txtFirstName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLastName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents dtpDOB As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cbPersonSex As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtSecondName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbNationality As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtEmployerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPhoneNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblEmployer_Address As System.Windows.Forms.Label
    Friend WithEvents lblResidence As System.Windows.Forms.Label
    Friend WithEvents lblNationality As System.Windows.Forms.Label
    Friend WithEvents lblEmployerName As System.Windows.Forms.Label
    Friend WithEvents lblPhoneNumber As System.Windows.Forms.Label
    Friend WithEvents Employer_AddressLookup As eidss.AddressLookup
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents lblPatronymic As System.Windows.Forms.Label
    Friend WithEvents lblPatientName As System.Windows.Forms.Label
    Friend WithEvents lblPersonSex As System.Windows.Forms.Label
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents txtAge As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents CurrentResidence_AddressLookup As eidss.AddressLookup
    Friend WithEvents cbAgeUnits As DevExpress.XtraEditors.LookUpEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Patient_Info))
        Dim TagHelper1 As bv.common.win.TagHelper = New bv.common.win.TagHelper()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtFirstName = New DevExpress.XtraEditors.TextEdit()
        Me.txtLastName = New DevExpress.XtraEditors.TextEdit()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblPatronymic = New System.Windows.Forms.Label()
        Me.dtpDOB = New DevExpress.XtraEditors.DateEdit()
        Me.lblPersonSex = New System.Windows.Forms.Label()
        Me.cbPersonSex = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtSecondName = New DevExpress.XtraEditors.TextEdit()
        Me.lblNationality = New System.Windows.Forms.Label()
        Me.cbNationality = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployer_Address = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer()
        Me.lblPatientName = New System.Windows.Forms.Label()
        Me.txtEmployerName = New DevExpress.XtraEditors.TextEdit()
        Me.lblEmployerName = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New DevExpress.XtraEditors.TextEdit()
        Me.lblPhoneNumber = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblResidence = New System.Windows.Forms.Label()
        Me.txtAge = New DevExpress.XtraEditors.SpinEdit()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.cbAgeUnits = New DevExpress.XtraEditors.LookUpEdit()
        Me.Employer_AddressLookup = New EIDSS.AddressLookup()
        Me.CurrentResidence_AddressLookup = New EIDSS.AddressLookup()
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLastName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDOB.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDOB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbPersonSex.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSecondName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbNationality.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmployerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhoneNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAgeUnits.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFirstName
        '
        resources.ApplyResources(Me.lblFirstName, "lblFirstName")
        Me.lblFirstName.Name = "lblFirstName"
        '
        'txtFirstName
        '
        resources.ApplyResources(Me.txtFirstName, "txtFirstName")
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Properties.AccessibleDescription = resources.GetString("txtFirstName.Properties.AccessibleDescription")
        Me.txtFirstName.Properties.AccessibleName = resources.GetString("txtFirstName.Properties.AccessibleName")
        Me.txtFirstName.Properties.Appearance.GradientMode = CType(resources.GetObject("txtFirstName.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFirstName.Properties.Appearance.Image = CType(resources.GetObject("txtFirstName.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtFirstName.Properties.Appearance.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtFirstName.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFirstName.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtFirstName.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtFirstName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtFirstName.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFirstName.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtFirstName.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtFirstName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtFirstName.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFirstName.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtFirstName.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtFirstName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtFirstName.Properties.AutoHeight = CType(resources.GetObject("txtFirstName.Properties.AutoHeight"), Boolean)
        Me.txtFirstName.Properties.Mask.AutoComplete = CType(resources.GetObject("txtFirstName.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtFirstName.Properties.Mask.BeepOnError = CType(resources.GetObject("txtFirstName.Properties.Mask.BeepOnError"), Boolean)
        Me.txtFirstName.Properties.Mask.EditMask = resources.GetString("txtFirstName.Properties.Mask.EditMask")
        Me.txtFirstName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtFirstName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtFirstName.Properties.Mask.MaskType = CType(resources.GetObject("txtFirstName.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtFirstName.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtFirstName.Properties.Mask.PlaceHolder"), Char)
        Me.txtFirstName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtFirstName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtFirstName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtFirstName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtFirstName.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtFirstName.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtFirstName.Properties.NullValuePrompt = resources.GetString("txtFirstName.Properties.NullValuePrompt")
        Me.txtFirstName.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtFirstName.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'txtLastName
        '
        resources.ApplyResources(Me.txtLastName, "txtLastName")
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Properties.AccessibleDescription = resources.GetString("txtLastName.Properties.AccessibleDescription")
        Me.txtLastName.Properties.AccessibleName = resources.GetString("txtLastName.Properties.AccessibleName")
        Me.txtLastName.Properties.Appearance.GradientMode = CType(resources.GetObject("txtLastName.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtLastName.Properties.Appearance.Image = CType(resources.GetObject("txtLastName.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtLastName.Properties.Appearance.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtLastName.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtLastName.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtLastName.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtLastName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtLastName.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtLastName.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtLastName.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtLastName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtLastName.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtLastName.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtLastName.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtLastName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtLastName.Properties.AutoHeight = CType(resources.GetObject("txtLastName.Properties.AutoHeight"), Boolean)
        Me.txtLastName.Properties.Mask.AutoComplete = CType(resources.GetObject("txtLastName.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtLastName.Properties.Mask.BeepOnError = CType(resources.GetObject("txtLastName.Properties.Mask.BeepOnError"), Boolean)
        Me.txtLastName.Properties.Mask.EditMask = resources.GetString("txtLastName.Properties.Mask.EditMask")
        Me.txtLastName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtLastName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtLastName.Properties.Mask.MaskType = CType(resources.GetObject("txtLastName.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtLastName.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtLastName.Properties.Mask.PlaceHolder"), Char)
        Me.txtLastName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtLastName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtLastName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtLastName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtLastName.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtLastName.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtLastName.Properties.NullValuePrompt = resources.GetString("txtLastName.Properties.NullValuePrompt")
        Me.txtLastName.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtLastName.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtLastName.Tag = "{M}"
        '
        'lblLastName
        '
        resources.ApplyResources(Me.lblLastName, "lblLastName")
        Me.lblLastName.Name = "lblLastName"
        '
        'lblPatronymic
        '
        resources.ApplyResources(Me.lblPatronymic, "lblPatronymic")
        Me.lblPatronymic.Name = "lblPatronymic"
        '
        'dtpDOB
        '
        resources.ApplyResources(Me.dtpDOB, "dtpDOB")
        Me.dtpDOB.Name = "dtpDOB"
        Me.dtpDOB.Properties.AccessibleDescription = resources.GetString("dtpDOB.Properties.AccessibleDescription")
        Me.dtpDOB.Properties.AccessibleName = resources.GetString("dtpDOB.Properties.AccessibleName")
        Me.dtpDOB.Properties.AutoHeight = CType(resources.GetObject("dtpDOB.Properties.AutoHeight"), Boolean)
        Me.dtpDOB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtpDOB.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtpDOB.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.dtpDOB.Properties.Mask.AutoComplete = CType(resources.GetObject("dtpDOB.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtpDOB.Properties.Mask.BeepOnError = CType(resources.GetObject("dtpDOB.Properties.Mask.BeepOnError"), Boolean)
        Me.dtpDOB.Properties.Mask.EditMask = resources.GetString("dtpDOB.Properties.Mask.EditMask")
        Me.dtpDOB.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtpDOB.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtpDOB.Properties.Mask.MaskType = CType(resources.GetObject("dtpDOB.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtpDOB.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtpDOB.Properties.Mask.PlaceHolder"), Char)
        Me.dtpDOB.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtpDOB.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtpDOB.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtpDOB.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtpDOB.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtpDOB.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtpDOB.Properties.NullValuePrompt = resources.GetString("dtpDOB.Properties.NullValuePrompt")
        Me.dtpDOB.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtpDOB.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtpDOB.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtpDOB.Properties.VistaTimeProperties.AccessibleDescription")
        Me.dtpDOB.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtpDOB.Properties.VistaTimeProperties.AccessibleName")
        Me.dtpDOB.Properties.VistaTimeProperties.Appearance.GradientMode = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.VistaTimeProperties.Appearance.Image = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.Appearance.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.VistaTimeProperties.Appearance.Options.UseFont = True
        Me.dtpDOB.Properties.VistaTimeProperties.AppearanceDisabled.GradientMode = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.VistaTimeProperties.AppearanceDisabled.Image = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.VistaTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtpDOB.Properties.VistaTimeProperties.AppearanceFocused.GradientMode = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.VistaTimeProperties.AppearanceFocused.Image = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.VistaTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtpDOB.Properties.VistaTimeProperties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.VistaTimeProperties.AppearanceReadOnly.Image = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.VistaTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtpDOB.Properties.VistaTimeProperties.AutoHeight = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.AutoHeight"), Boolean)
        Me.dtpDOB.Properties.VistaTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtpDOB.Properties.VistaTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtpDOB.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtpDOB.Properties.VistaTimeProperties.Mask.EditMask")
        Me.dtpDOB.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtpDOB.Properties.VistaTimeProperties.Mask.MaskType = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtpDOB.Properties.VistaTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtpDOB.Properties.VistaTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtpDOB.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtpDOB.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtpDOB.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtpDOB.Properties.VistaTimeProperties.NullValuePrompt")
        Me.dtpDOB.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtpDOB.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lblPersonSex
        '
        resources.ApplyResources(Me.lblPersonSex, "lblPersonSex")
        Me.lblPersonSex.Name = "lblPersonSex"
        '
        'cbPersonSex
        '
        resources.ApplyResources(Me.cbPersonSex, "cbPersonSex")
        Me.cbPersonSex.Name = "cbPersonSex"
        Me.cbPersonSex.Properties.AccessibleDescription = resources.GetString("cbPersonSex.Properties.AccessibleDescription")
        Me.cbPersonSex.Properties.AccessibleName = resources.GetString("cbPersonSex.Properties.AccessibleName")
        Me.cbPersonSex.Properties.AutoHeight = CType(resources.GetObject("cbPersonSex.Properties.AutoHeight"), Boolean)
        Me.cbPersonSex.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbPersonSex.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbPersonSex.Properties.NullText = resources.GetString("cbPersonSex.Properties.NullText")
        Me.cbPersonSex.Properties.NullValuePrompt = resources.GetString("cbPersonSex.Properties.NullValuePrompt")
        Me.cbPersonSex.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbPersonSex.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'txtSecondName
        '
        resources.ApplyResources(Me.txtSecondName, "txtSecondName")
        Me.txtSecondName.Name = "txtSecondName"
        Me.txtSecondName.Properties.AccessibleDescription = resources.GetString("txtSecondName.Properties.AccessibleDescription")
        Me.txtSecondName.Properties.AccessibleName = resources.GetString("txtSecondName.Properties.AccessibleName")
        Me.txtSecondName.Properties.Appearance.GradientMode = CType(resources.GetObject("txtSecondName.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSecondName.Properties.Appearance.Image = CType(resources.GetObject("txtSecondName.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtSecondName.Properties.Appearance.Options.UseFont = True
        Me.txtSecondName.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtSecondName.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSecondName.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtSecondName.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtSecondName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtSecondName.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtSecondName.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSecondName.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtSecondName.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtSecondName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtSecondName.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtSecondName.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSecondName.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtSecondName.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtSecondName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtSecondName.Properties.AutoHeight = CType(resources.GetObject("txtSecondName.Properties.AutoHeight"), Boolean)
        Me.txtSecondName.Properties.Mask.AutoComplete = CType(resources.GetObject("txtSecondName.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtSecondName.Properties.Mask.BeepOnError = CType(resources.GetObject("txtSecondName.Properties.Mask.BeepOnError"), Boolean)
        Me.txtSecondName.Properties.Mask.EditMask = resources.GetString("txtSecondName.Properties.Mask.EditMask")
        Me.txtSecondName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSecondName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSecondName.Properties.Mask.MaskType = CType(resources.GetObject("txtSecondName.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtSecondName.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtSecondName.Properties.Mask.PlaceHolder"), Char)
        Me.txtSecondName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSecondName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSecondName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSecondName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSecondName.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtSecondName.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtSecondName.Properties.NullValuePrompt = resources.GetString("txtSecondName.Properties.NullValuePrompt")
        Me.txtSecondName.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtSecondName.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lblNationality
        '
        resources.ApplyResources(Me.lblNationality, "lblNationality")
        Me.lblNationality.Name = "lblNationality"
        '
        'cbNationality
        '
        resources.ApplyResources(Me.cbNationality, "cbNationality")
        Me.cbNationality.Name = "cbNationality"
        Me.cbNationality.Properties.AccessibleDescription = resources.GetString("cbNationality.Properties.AccessibleDescription")
        Me.cbNationality.Properties.AccessibleName = resources.GetString("cbNationality.Properties.AccessibleName")
        Me.cbNationality.Properties.Appearance.GradientMode = CType(resources.GetObject("cbNationality.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.Appearance.Image = CType(resources.GetObject("cbNationality.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.Appearance.Options.UseFont = True
        Me.cbNationality.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbNationality.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbNationality.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbNationality.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbNationality.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbNationality.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbNationality.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbNationality.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbNationality.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbNationality.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbNationality.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbNationality.Properties.AutoHeight = CType(resources.GetObject("cbNationality.Properties.AutoHeight"), Boolean)
        Me.cbNationality.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbNationality.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbNationality.Properties.NullText = resources.GetString("cbNationality.Properties.NullText")
        Me.cbNationality.Properties.NullValuePrompt = resources.GetString("cbNationality.Properties.NullValuePrompt")
        Me.cbNationality.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbNationality.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lblEmployer_Address
        '
        resources.ApplyResources(Me.lblEmployer_Address, "lblEmployer_Address")
        Me.lblEmployer_Address.Name = "lblEmployer_Address"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'lblPatientName
        '
        resources.ApplyResources(Me.lblPatientName, "lblPatientName")
        Me.lblPatientName.Name = "lblPatientName"
        '
        'txtEmployerName
        '
        resources.ApplyResources(Me.txtEmployerName, "txtEmployerName")
        Me.txtEmployerName.Name = "txtEmployerName"
        Me.txtEmployerName.Properties.AccessibleDescription = resources.GetString("txtEmployerName.Properties.AccessibleDescription")
        Me.txtEmployerName.Properties.AccessibleName = resources.GetString("txtEmployerName.Properties.AccessibleName")
        Me.txtEmployerName.Properties.Appearance.GradientMode = CType(resources.GetObject("txtEmployerName.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtEmployerName.Properties.Appearance.Image = CType(resources.GetObject("txtEmployerName.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtEmployerName.Properties.Appearance.Options.UseFont = True
        Me.txtEmployerName.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtEmployerName.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtEmployerName.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtEmployerName.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtEmployerName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtEmployerName.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtEmployerName.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtEmployerName.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtEmployerName.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtEmployerName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtEmployerName.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtEmployerName.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtEmployerName.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtEmployerName.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtEmployerName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtEmployerName.Properties.AutoHeight = CType(resources.GetObject("txtEmployerName.Properties.AutoHeight"), Boolean)
        Me.txtEmployerName.Properties.Mask.AutoComplete = CType(resources.GetObject("txtEmployerName.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtEmployerName.Properties.Mask.BeepOnError = CType(resources.GetObject("txtEmployerName.Properties.Mask.BeepOnError"), Boolean)
        Me.txtEmployerName.Properties.Mask.EditMask = resources.GetString("txtEmployerName.Properties.Mask.EditMask")
        Me.txtEmployerName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtEmployerName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtEmployerName.Properties.Mask.MaskType = CType(resources.GetObject("txtEmployerName.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtEmployerName.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtEmployerName.Properties.Mask.PlaceHolder"), Char)
        Me.txtEmployerName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtEmployerName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtEmployerName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtEmployerName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtEmployerName.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtEmployerName.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtEmployerName.Properties.NullValuePrompt = resources.GetString("txtEmployerName.Properties.NullValuePrompt")
        Me.txtEmployerName.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtEmployerName.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lblEmployerName
        '
        resources.ApplyResources(Me.lblEmployerName, "lblEmployerName")
        Me.lblEmployerName.Name = "lblEmployerName"
        '
        'txtPhoneNumber
        '
        resources.ApplyResources(Me.txtPhoneNumber, "txtPhoneNumber")
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Properties.AccessibleDescription = resources.GetString("txtPhoneNumber.Properties.AccessibleDescription")
        Me.txtPhoneNumber.Properties.AccessibleName = resources.GetString("txtPhoneNumber.Properties.AccessibleName")
        Me.txtPhoneNumber.Properties.Appearance.GradientMode = CType(resources.GetObject("txtPhoneNumber.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPhoneNumber.Properties.Appearance.Image = CType(resources.GetObject("txtPhoneNumber.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtPhoneNumber.Properties.Appearance.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPhoneNumber.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtPhoneNumber.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPhoneNumber.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtPhoneNumber.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPhoneNumber.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtPhoneNumber.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AutoHeight = CType(resources.GetObject("txtPhoneNumber.Properties.AutoHeight"), Boolean)
        Me.txtPhoneNumber.Properties.Mask.AutoComplete = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtPhoneNumber.Properties.Mask.BeepOnError = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.BeepOnError"), Boolean)
        Me.txtPhoneNumber.Properties.Mask.EditMask = resources.GetString("txtPhoneNumber.Properties.Mask.EditMask")
        Me.txtPhoneNumber.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPhoneNumber.Properties.Mask.MaskType = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtPhoneNumber.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.PlaceHolder"), Char)
        Me.txtPhoneNumber.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPhoneNumber.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPhoneNumber.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtPhoneNumber.Properties.NullValuePrompt = resources.GetString("txtPhoneNumber.Properties.NullValuePrompt")
        Me.txtPhoneNumber.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtPhoneNumber.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lblPhoneNumber
        '
        resources.ApplyResources(Me.lblPhoneNumber, "lblPhoneNumber")
        Me.lblPhoneNumber.Name = "lblPhoneNumber"
        '
        'lblDOB
        '
        resources.ApplyResources(Me.lblDOB, "lblDOB")
        Me.lblDOB.Name = "lblDOB"
        '
        'lblResidence
        '
        resources.ApplyResources(Me.lblResidence, "lblResidence")
        Me.lblResidence.Name = "lblResidence"
        '
        'txtAge
        '
        resources.ApplyResources(Me.txtAge, "txtAge")
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Properties.AccessibleDescription = resources.GetString("txtAge.Properties.AccessibleDescription")
        Me.txtAge.Properties.AccessibleName = resources.GetString("txtAge.Properties.AccessibleName")
        Me.txtAge.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtAge.Properties.AutoHeight = CType(resources.GetObject("txtAge.Properties.AutoHeight"), Boolean)
        Me.txtAge.Properties.IsFloatValue = False
        Me.txtAge.Properties.Mask.AutoComplete = CType(resources.GetObject("txtAge.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtAge.Properties.Mask.BeepOnError = CType(resources.GetObject("txtAge.Properties.Mask.BeepOnError"), Boolean)
        Me.txtAge.Properties.Mask.EditMask = resources.GetString("txtAge.Properties.Mask.EditMask")
        Me.txtAge.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtAge.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtAge.Properties.Mask.MaskType = CType(resources.GetObject("txtAge.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtAge.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtAge.Properties.Mask.PlaceHolder"), Char)
        Me.txtAge.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtAge.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtAge.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtAge.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtAge.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtAge.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtAge.Properties.NullValuePrompt = resources.GetString("txtAge.Properties.NullValuePrompt")
        Me.txtAge.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtAge.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lblAge
        '
        resources.ApplyResources(Me.lblAge, "lblAge")
        Me.lblAge.Name = "lblAge"
        '
        'cbAgeUnits
        '
        resources.ApplyResources(Me.cbAgeUnits, "cbAgeUnits")
        Me.cbAgeUnits.Name = "cbAgeUnits"
        Me.cbAgeUnits.Properties.AccessibleDescription = resources.GetString("cbAgeUnits.Properties.AccessibleDescription")
        Me.cbAgeUnits.Properties.AccessibleName = resources.GetString("cbAgeUnits.Properties.AccessibleName")
        Me.cbAgeUnits.Properties.AutoHeight = CType(resources.GetObject("cbAgeUnits.Properties.AutoHeight"), Boolean)
        Me.cbAgeUnits.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAgeUnits.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbAgeUnits.Properties.NullText = resources.GetString("cbAgeUnits.Properties.NullText")
        Me.cbAgeUnits.Properties.NullValuePrompt = resources.GetString("cbAgeUnits.Properties.NullValuePrompt")
        Me.cbAgeUnits.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbAgeUnits.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'Employer_AddressLookup
        '
        resources.ApplyResources(Me.Employer_AddressLookup, "Employer_AddressLookup")
        Me.Employer_AddressLookup.Appearance.BackColor = CType(resources.GetObject("Employer_AddressLookup.Appearance.BackColor"), System.Drawing.Color)
        Me.Employer_AddressLookup.Appearance.GradientMode = CType(resources.GetObject("Employer_AddressLookup.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.Employer_AddressLookup.Appearance.Image = CType(resources.GetObject("Employer_AddressLookup.Appearance.Image"), System.Drawing.Image)
        Me.Employer_AddressLookup.Appearance.Options.UseBackColor = True
        Me.Employer_AddressLookup.Appearance.Options.UseFont = True
        Me.Employer_AddressLookup.CanExpand = True
        Me.Employer_AddressLookup.FormID = Nothing
        Me.Employer_AddressLookup.HelpTopicID = Nothing
        Me.Employer_AddressLookup.IsStatusReadOnly = False
        Me.Employer_AddressLookup.KeyFieldName = "idfGeoLocation"
        Me.Employer_AddressLookup.MultiSelect = False
        Me.Employer_AddressLookup.Name = "Employer_AddressLookup"
        Me.Employer_AddressLookup.ObjectName = "Address"
        Me.Employer_AddressLookup.PopupEditHeight = 200
        Me.Employer_AddressLookup.ShowResidenceType = False
        Me.Employer_AddressLookup.Sizable = True
        Me.Employer_AddressLookup.TableName = "Address"
        TagHelper1.Binder = Nothing
        TagHelper1.ControlLanguage = ""
        TagHelper1.Datasource = Nothing
        TagHelper1.HACodeName = Nothing
        TagHelper1.IntTag = -1
        TagHelper1.IsBarcode = False
        TagHelper1.IsKeyField = False
        TagHelper1.IsMandatory = False
        TagHelper1.IsReadOnly = False
        TagHelper1.LookupTableName = Nothing
        TagHelper1.MandatoryFieldName = Nothing
        TagHelper1.StringTag = ""
        TagHelper1.Tag = Nothing
        Me.Employer_AddressLookup.Tag = TagHelper1
        '
        'CurrentResidence_AddressLookup
        '
        resources.ApplyResources(Me.CurrentResidence_AddressLookup, "CurrentResidence_AddressLookup")
        Me.CurrentResidence_AddressLookup.Appearance.BackColor = CType(resources.GetObject("CurrentResidence_AddressLookup.Appearance.BackColor"), System.Drawing.Color)
        Me.CurrentResidence_AddressLookup.Appearance.GradientMode = CType(resources.GetObject("CurrentResidence_AddressLookup.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.CurrentResidence_AddressLookup.Appearance.Image = CType(resources.GetObject("CurrentResidence_AddressLookup.Appearance.Image"), System.Drawing.Image)
        Me.CurrentResidence_AddressLookup.Appearance.Options.UseBackColor = True
        Me.CurrentResidence_AddressLookup.Appearance.Options.UseFont = True
        Me.CurrentResidence_AddressLookup.CanExpand = True
        Me.CurrentResidence_AddressLookup.ColumnCount = 3
        Me.CurrentResidence_AddressLookup.FormID = Nothing
        Me.CurrentResidence_AddressLookup.HelpTopicID = Nothing
        Me.CurrentResidence_AddressLookup.IsStatusReadOnly = False
        Me.CurrentResidence_AddressLookup.KeyFieldName = "idfGeoLocation"
        Me.CurrentResidence_AddressLookup.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.CurrentResidence_AddressLookup.MultiSelect = False
        Me.CurrentResidence_AddressLookup.Name = "CurrentResidence_AddressLookup"
        Me.CurrentResidence_AddressLookup.ObjectName = "Address"
        Me.CurrentResidence_AddressLookup.PopupEditHeight = 200
        Me.CurrentResidence_AddressLookup.ShowContry = False
        Me.CurrentResidence_AddressLookup.ShowCoordinates = True
        Me.CurrentResidence_AddressLookup.ShowResidenceType = False
        Me.CurrentResidence_AddressLookup.Sizable = True
        Me.CurrentResidence_AddressLookup.TableName = "Address"
        Me.CurrentResidence_AddressLookup.UseParentBackColor = True
        '
        'Patient_Info
        '
        resources.ApplyResources(Me, "$this")
        Me.Appearance.GradientMode = CType(resources.GetObject("Patient_Info.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.Appearance.Image = CType(resources.GetObject("Patient_Info.Appearance.Image"), System.Drawing.Image)
        Me.Appearance.Options.UseFont = True
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.lblResidence)
        Me.Controls.Add(Me.cbNationality)
        Me.Controls.Add(Me.lblNationality)
        Me.Controls.Add(Me.txtPhoneNumber)
        Me.Controls.Add(Me.lblPhoneNumber)
        Me.Controls.Add(Me.CurrentResidence_AddressLookup)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.cbAgeUnits)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lblPatronymic)
        Me.Controls.Add(Me.dtpDOB)
        Me.Controls.Add(Me.lblPersonSex)
        Me.Controls.Add(Me.cbPersonSex)
        Me.Controls.Add(Me.txtSecondName)
        Me.Controls.Add(Me.txtEmployerName)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.lblDOB)
        Me.Controls.Add(Me.lblEmployer_Address)
        Me.Controls.Add(Me.lblEmployerName)
        Me.Controls.Add(Me.Employer_AddressLookup)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.lblPatientName)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "Patient_Info"
        Me.ObjectName = "Patient"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "tlbHuman"
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLastName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDOB.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDOB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbPersonSex.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSecondName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbNationality.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmployerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhoneNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAgeUnits.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Event OnFieldInfoChanged As EventHandler

    Private Sub ctrl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent OnFieldInfoChanged(sender, e)
    End Sub

    Private ReadOnly Property IsSearchMode() As Boolean
        Get
            Return (Not Me.PatientDbService Is Nothing) AndAlso _
                   (Utils.SEARCH_MODE_ID.Equals(Me.PatientDbService.ID))
        End Get
    End Property

    Private m_PatientInfoCreated As Boolean = False
    Public ReadOnly Property PatientInfoCreated() As Boolean
        Get
            Return m_PatientInfoCreated
        End Get
    End Property

    Public Overrides Function GetChildKey(ByVal child As bv.common.win.IRelatedObject) As Object
        If IsSearchMode() Then Return Utils.SEARCH_MODE_ID

        If (child Is CurrentResidence_AddressLookup) Then
            Return GetKey(Patient_DB.tlbHuman, "idfCurrentResidenceAddress")
        ElseIf (child Is Employer_AddressLookup) Then
            Return GetKey(Patient_DB.tlbHuman, "idfEmployerAddress")
        End If

        Return GetKey(Patient_DB.tlbHuman, "idfHuman")
    End Function
    <Browsable(False), DefaultValue(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property HidePersonalData As Boolean
    <Browsable(False), DefaultValue("*"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property PersonalDataString As String
    Private m_HidePatientName As Boolean
    Private m_HidePatientAge As Boolean
    Private m_HidePatientSex As Boolean
    Private m_HidePatientAddress As Boolean
    Private m_HideEmployee As Boolean
    Protected Overrides Sub DefineBinding()
        Try
            '' '' ''If Not BindPatientInSearchMode() Then
            AddHandler txtPhoneNumber.EditValueChanged, AddressOf ctrl_TextChanged
            AddHandler cbNationality.EditValueChanged, AddressOf ctrl_TextChanged
            AddHandler cbPersonSex.EditValueChanged, AddressOf ctrl_TextChanged
            AddHandler txtEmployerName.EditValueChanged, AddressOf ctrl_TextChanged
            AddHandler CurrentResidence_AddressLookup.AddressChanged, AddressOf ctrl_TextChanged
            AddHandler Employer_AddressLookup.AddressChanged, AddressOf ctrl_TextChanged


            CurrentResidence_AddressLookup.DataBindings.Clear()
            Employer_AddressLookup.DataBindings.Clear()

            If baseDataSet.Tables.Contains(Patient_DB.tlbHuman) AndAlso _
               baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0 Then


                Dim group As PersonalDataGroup = PersonalDataGroup.None
                Dim groups As PersonalDataGroup() = New PersonalDataGroup() {}
                If HidePersonalData Then
                    group = PersonalDataGroup.Human_PersonName
                End If
                Core.LookupBinder.BindPersonalDataTextEdit(txtFirstName, baseDataSet, Patient_DB.tlbHuman + ".strFirstName", group, IgnorePersonalData, PersonalDataString)
                Core.LookupBinder.BindPersonalDataTextEdit(txtLastName, baseDataSet, Patient_DB.tlbHuman + ".strLastName", group, IgnorePersonalData, PersonalDataString)
                Core.LookupBinder.BindPersonalDataTextEdit(txtSecondName, baseDataSet, Patient_DB.tlbHuman + ".strSecondName", group, IgnorePersonalData, PersonalDataString)
                m_HidePatientName = (txtLastName.DataBindings.Count = 0)
                If HidePersonalData Then
                    group = PersonalDataGroup.Human_PersonAge
                End If
                Core.LookupBinder.BindPersonalDataDateEdit(dtpDOB, baseDataSet, Patient_DB.tlbHuman + ".datDateofBirth", group, IgnorePersonalData, PersonalDataString)
                Core.LookupBinder.BindPersonalDataBaseLookup(cbAgeUnits, baseDataSet, Nothing, db.BaseReferenceType.rftHumanAgeType, HACode.Human, False, group, IgnorePersonalData, PersonalDataString)
                m_HidePatientAge = (dtpDOB.DataBindings.Count = 0)
                If HidePersonalData Then
                    group = PersonalDataGroup.Human_PersonSex
                End If
                Core.LookupBinder.BindPersonalDataBaseLookup(cbPersonSex, baseDataSet, Patient_DB.tlbHuman + ".idfsHumanGender", db.BaseReferenceType.rftHumanGender, False, True, group, IgnorePersonalData, PersonalDataString)
                m_HidePatientSex = (cbPersonSex.DataBindings.Count = 0)

                If HidePersonalData Then
                    groups = New PersonalDataGroup() {PersonalDataGroup.Human_Employer_Details, PersonalDataGroup.Human_Employer_Settlement}

                End If
                Core.LookupBinder.BindBaseLookup(cbAgeUnits, baseDataSet, Nothing, db.BaseReferenceType.rftHumanAgeType, False)
                For Each btn As DevExpress.XtraEditors.Controls.EditorButton In cbAgeUnits.Properties.Buttons
                    If btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then
                        btn.Visible = False
                        Exit For
                    End If
                Next

                Core.LookupBinder.BindPersonalDataTextEdit(txtEmployerName, baseDataSet, Patient_DB.tlbHuman + ".strEmployerName", groups, IgnorePersonalData, PersonalDataString)
                m_HideEmployee = (txtEmployerName.DataBindings.Count = 0)
                Employer_AddressLookup.DataBindings.Add("ID", baseDataSet, Patient_DB.tlbHuman + ".idfEmployerAddress")
                Employer_AddressLookup.PersonalDataString = PersonalDataString
                Employer_AddressLookup.PersonalDataTypes = groups
                Employer_AddressLookup.IgnorePersonalData = IgnorePersonalData

                Core.LookupBinder.BindBaseLookup(cbPersonSex, baseDataSet, Patient_DB.tlbHuman + ".idfsHumanGender", db.BaseReferenceType.rftHumanGender, False)
                Core.LookupBinder.BindBaseLookup(cbNationality, baseDataSet, Patient_DB.tlbHuman + ".idfsNationality", db.BaseReferenceType.rftNationality)
                Core.LookupBinder.BindBaseLookup(cbNationality, baseDataSet, Patient_DB.tlbHuman + ".idfsNationality", db.BaseReferenceType.rftNationality)

                If HidePersonalData Then
                    groups = New PersonalDataGroup() {PersonalDataGroup.Human_CurrentResidence_Coordinates, PersonalDataGroup.Human_CurrentResidence_Details, PersonalDataGroup.Human_CurrentResidence_Settlement}
                End If
                CurrentResidence_AddressLookup.PersonalDataString = PersonalDataString
                CurrentResidence_AddressLookup.IgnorePersonalData = IgnorePersonalData
                CurrentResidence_AddressLookup.DataBindings.Add("ID", baseDataSet, Patient_DB.tlbHuman + ".idfCurrentResidenceAddress")
                CurrentResidence_AddressLookup.PersonalDataTypes = groups
                Core.LookupBinder.BindPersonalDataTextEdit(txtPhoneNumber, baseDataSet, Patient_DB.tlbHuman + ".strHomePhone", New PersonalDataGroup() {PersonalDataGroup.Human_CurrentResidence_Details, PersonalDataGroup.Human_CurrentResidence_Settlement}, IgnorePersonalData, PersonalDataString)
                m_HidePatientAddress = (txtEmployerName.DataBindings.Count = 0)


                m_RootID = baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("idfRootHuman")
                m_CaseID = baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("idfCase")

                Dim params As Dictionary(Of String, Object) = StartUpParameters
                If (Not params Is Nothing) AndAlso (params.ContainsKey("ReadOnly")) AndAlso (TypeOf (params("ReadOnly")) Is Boolean) AndAlso (Me.ReadOnly <> CBool(params("ReadOnly"))) Then
                    Me.ReadOnly = CBool(params("ReadOnly"))
                End If

                m_PatientInfoCreated = True
            End If
            '' '' ''End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub CopyInfoFromRootObject(ByVal aRootHumanID As Object)
        If Utils.IsEmpty(aRootHumanID) Then Return
        Dim row As DataRow = GetCurrentRow(Patient_DB.tlbHuman)
        If row Is Nothing Then Return
        If Utils.Str(RootID) = Utils.Str(aRootHumanID) Then

        End If

        Dim idfHuman As Object = row("idfHuman")
        Dim idfCurrentResidenceAddress As Object = row("idfCurrentResidenceAddress")
        Dim idfEmployerAddress As Object = row("idfEmployerAddress")
        Dim idfRootHuman As Object = row("idfRootHuman")
        Dim idfCase As Object = row("idfCase")

        LoadData(aRootHumanID)

        row = GetCurrentRow(Patient_DB.tlbHuman)
        row("idfHuman") = idfHuman
        row("idfCurrentResidenceAddress") = idfCurrentResidenceAddress
        row("idfEmployerAddress") = idfEmployerAddress
        RootID = aRootHumanID
        CaseID = idfCase
        row.AcceptChanges()
        row.SetModified()
        If (Not CurrentResidence_AddressLookup.baseDataSet Is Nothing) AndAlso _
           (CurrentResidence_AddressLookup.baseDataSet.Tables.Contains("Address") = True) AndAlso _
           (CurrentResidence_AddressLookup.baseDataSet.Tables("Address").Rows.Count > 0) Then
            CurrentResidence_AddressLookup.baseDataSet.Tables("Address").Rows(0)("idfGeoLocation") = _
                idfCurrentResidenceAddress
        End If
        If (Not Employer_AddressLookup.baseDataSet Is Nothing) AndAlso _
           (Employer_AddressLookup.baseDataSet.Tables.Contains("Address") = True) AndAlso _
           (Employer_AddressLookup.baseDataSet.Tables("Address").Rows.Count > 0) Then
            Employer_AddressLookup.baseDataSet.Tables("Address").Rows(0)("idfGeoLocation") = _
                idfEmployerAddress
        End If
    End Sub

    Private m_RootID As Object
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Property RootID() As Object
        Get
            Return m_RootID
        End Get
        Set(ByVal Value As Object)
            m_RootID = Value
            Dim row As DataRow = GetCurrentRow(Patient_DB.tlbHuman)
            If Not row Is Nothing Then
                row("idfRootHuman") = Value
            End If
        End Set
    End Property

    Private m_CaseID As Object
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Property CaseID() As Object
        Get
            Return m_CaseID
        End Get
        Set(ByVal Value As Object)
            m_CaseID = Value
            Dim row As DataRow = GetCurrentRow(Patient_DB.tlbHuman)
            If Not row Is Nothing Then
                row("idfCase") = Value
            End If
        End Set
    End Property

    Private Sub Patient_Info_OnBeforePost(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnBeforePost
        If CurrentResidence_AddressLookup.HasChanges() Then
            PatientDbService.HasCurrentResidenceChanged = True
        End If
    End Sub

    Public Overrides Function Post(Optional ByVal postType As bv.common.PostType = bv.common.PostType.FinalPosting) As Boolean
        If IsSearchMode() Then Return True
        Return MyBase.Post
    End Function

    Public Sub UpdateNotReadOnlyControlView()
        If Not IsSearchMode() Then
            For Each btn As DevExpress.XtraEditors.Controls.EditorButton In cbAgeUnits.Properties.Buttons
                If btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then
                    btn.Visible = False
                    Exit For
                End If
            Next
        End If
    End Sub

#Region "Ctrl Events"

    Private Sub CurrentResidence_AddressLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CurrentResidence_AddressLookup.Load
        Dim LabelColLeft As New ArrayList(3)
        LabelColLeft.Add(lblPhoneNumber.Left)
        LabelColLeft.Add(lblFirstName.Left)
        LabelColLeft.Add(lblPatronymic.Left)

        Dim LabelColWidth As New ArrayList(3)
        LabelColWidth.Add(lblPhoneNumber.Width)
        LabelColWidth.Add(lblFirstName.Width)
        LabelColWidth.Add(lblPatronymic.Width)

        Dim CtrlColLeft As New ArrayList(3)
        CtrlColLeft.Add(txtLastName.Left)
        CtrlColLeft.Add(txtFirstName.Left)
        CtrlColLeft.Add(txtSecondName.Left)

        Dim CtrlColWidth As New ArrayList(3)
        CtrlColWidth.Add(txtLastName.Width)
        CtrlColWidth.Add(txtFirstName.Width)
        CtrlColWidth.Add(txtSecondName.Width)

        Dim lpHeight As Integer = 80
        CurrentResidence_AddressLookup.UpdateView(Me.Width, lpHeight, LabelColLeft, LabelColWidth, CtrlColLeft, CtrlColWidth, System.Drawing.ContentAlignment.MiddleLeft)
    End Sub

    Private Sub dtpDOB_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDOB.EditValueChanged
        If Not m_BindingDefined Then Return
        ctrl_TextChanged(sender, e)
        If (Not Parent Is Nothing) AndAlso _
               (Not Parent.Parent Is Nothing) AndAlso _
               (Not Parent.Parent.Parent Is Nothing) AndAlso _
               (Not Parent.Parent.Parent.Parent Is Nothing) AndAlso _
               (TypeOf (Parent.Parent.Parent.Parent) Is HumanCaseDetail) Then
            DataEventManager.SubmitCurrentEdit(dtpDOB)
            CType(Parent.Parent.Parent.Parent, HumanCaseDetail).UpdateDOBandAge()
        End If
    End Sub

#End Region

#Region "Field Value Properties"
    Public ReadOnly Property GetLastName() As String
        Get
            If (m_HidePatientName) Then
                Return "*"
            End If
            If (Not baseDataSet Is Nothing) AndAlso _
               (baseDataSet.Tables.Contains(Patient_DB.tlbHuman) = True) AndAlso _
               (baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0) Then
                Return Utils.Str(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("strLastName"))
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property GetFirstName() As String
        Get
            If (m_HidePatientName) Then
                Return "*"
            End If
            If (Not baseDataSet Is Nothing) AndAlso _
               (baseDataSet.Tables.Contains(Patient_DB.tlbHuman) = True) AndAlso _
               (baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0) Then
                Return Utils.Str(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("strFirstName"))
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property GetSecondName() As String
        Get
            If (m_HidePatientName) Then
                Return "*"
            End If
            If (Not baseDataSet Is Nothing) AndAlso _
               (baseDataSet.Tables.Contains(Patient_DB.tlbHuman) = True) AndAlso _
               (baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0) Then
                Return Utils.Str(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("strSecondName"))
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property GetDOB() As String
        Get
            If (m_HidePatientAge) Then
                Return "*"
            End If
            If (Not baseDataSet Is Nothing) AndAlso _
               (baseDataSet.Tables.Contains(Patient_DB.tlbHuman) = True) AndAlso _
               (baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0) AndAlso _
               (Not Utils.IsEmpty(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("datDateofBirth"))) Then
                Dim strFormat As String = "d"
                If (Not dtpDOB Is Nothing) Then
                    strFormat = dtpDOB.Properties.EditFormat.FormatString
                End If
                Return CDate(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("datDateofBirth")).ToString(strFormat)
            End If
            Return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
        End Get
    End Property

    Public ReadOnly Property GetPersonSex() As String
        Get
            If (m_HidePatientSex) Then
                Return "*"
            End If
            If (Not baseDataSet Is Nothing) AndAlso _
               (baseDataSet.Tables.Contains(Patient_DB.tlbHuman) = True) AndAlso _
               (baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0) AndAlso _
               (Not Utils.IsEmpty(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("idfsHumanGender"))) Then
                Return LookupCache.GetLookupValue( _
                            baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("idfsHumanGender"), _
                            db.BaseReferenceType.rftHumanGender, "Name")
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property GetNationality() As String
        Get
            If (Not baseDataSet Is Nothing) AndAlso _
               (baseDataSet.Tables.Contains(Patient_DB.tlbHuman) = True) AndAlso _
               (baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0) AndAlso _
               (Not Utils.IsEmpty(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("idfsNationality"))) Then
                Return LookupCache.GetLookupValue( _
                            baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("idfsNationality"), _
                            db.BaseReferenceType.rftNationality, "Name")
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property GetPhoneNumber() As String
        Get

            If (m_HidePatientAddress) Then
                Return "*"
            End If
            If (Not baseDataSet Is Nothing) AndAlso _
                (baseDataSet.Tables.Contains(Patient_DB.tlbHuman) = True) AndAlso _
                (baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0) Then
                Return Utils.Str(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("strHomePhone"))
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property GetEmployerName() As String
        Get
            If m_HideEmployee Then
                Return "*"
            End If
            If (Not baseDataSet Is Nothing) AndAlso _
               (baseDataSet.Tables.Contains(Patient_DB.tlbHuman) = True) AndAlso _
               (baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0) Then
                Return Utils.Str(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("strEmployerName"))
            End If
            Return ""
        End Get
    End Property

#End Region

    Public Property MaxAge As Integer
    Private Sub txtAge_Leave(sender As System.Object, e As EventArgs) Handles txtAge.Leave
        If (Not m_BindingDefined) OrElse IsSearchMode() Then
            Return
        End If
        InitMaxAge()
        If (Utils.IsEmpty(txtAge.EditValue)) Then
            Return
        End If
        If Not Utils.IsEmpty(cbAgeUnits.EditValue) Then
            If (CInt(txtAge.EditValue) > MaxAge) Then
                ErrorForm.ShowWarning("mbAgeShallNotExceed", "The value of field Age shall not exceed 31 days, or 60 months, or 200 years.")
            ElseIf (CInt(txtAge.EditValue) < 1) Then
                txtAge.EditValue = 1
            End If
        End If
    End Sub
    Private Sub InitMaxAge()
        If MaxAge = 0 AndAlso (Not cbAgeUnits.EditValue Is Nothing) Then
            If cbAgeUnits.EditValue.Equals(CLng(HumanAgeTypeEnum.Years)) Then
                MaxAge = 200
            ElseIf cbAgeUnits.EditValue.Equals(CLng(HumanAgeTypeEnum.Month)) Then
                MaxAge = 60
            ElseIf cbAgeUnits.EditValue.Equals(CLng(HumanAgeTypeEnum.Days)) Then
                MaxAge = 31
            End If
        End If
    End Sub


End Class

