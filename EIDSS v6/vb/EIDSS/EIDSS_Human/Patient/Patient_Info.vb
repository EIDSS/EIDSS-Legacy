Imports bv.winclient.BasePanel
Imports bv.model.Model.Core
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports System.Collections.Generic
Imports eidss.model.Enums
Imports bv.winclient.Core
Imports eidss.winclient.Human
Imports bv.winclient.Core.TranslationTool

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
    Friend WithEvents txtLastName As DevExpress.XtraEditors.ButtonEdit
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
    Friend WithEvents CurrentResidence_AddressLookup As EIDSS.AddressLookup
    Friend WithEvents lbPersonalIdType As System.Windows.Forms.Label
    Friend WithEvents cbPersonalIdType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtPersonalID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbPersonalID As System.Windows.Forms.Label
    Friend WithEvents cbAgeUnits As DevExpress.XtraEditors.LookUpEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Patient_Info))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim TagHelper1 As bv.common.win.TagHelper = New bv.common.win.TagHelper()
        Dim TagHelper2 As bv.common.win.TagHelper = New bv.common.win.TagHelper()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtFirstName = New DevExpress.XtraEditors.TextEdit()
        Me.txtLastName = New DevExpress.XtraEditors.ButtonEdit()
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
        Me.Employer_AddressLookup = New eidss.AddressLookup()
        Me.CurrentResidence_AddressLookup = New eidss.AddressLookup()
        Me.lbPersonalIdType = New System.Windows.Forms.Label()
        Me.cbPersonalIdType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtPersonalID = New DevExpress.XtraEditors.TextEdit()
        Me.lbPersonalID = New System.Windows.Forms.Label()
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLastName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDOB.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDOB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbPersonSex.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSecondName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbNationality.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmployerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhoneNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAgeUnits.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbPersonalIdType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPersonalID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(Patient_Info), resources)
        'Form Is Localizable: True
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
        Me.txtFirstName.Properties.Appearance.Font = CType(resources.GetObject("txtFirstName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtFirstName.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtFirstName.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtFirstName.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtFirstName.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtFirstName.Properties.Appearance.GradientMode = CType(resources.GetObject("txtFirstName.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFirstName.Properties.Appearance.Image = CType(resources.GetObject("txtFirstName.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtFirstName.Properties.Appearance.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtFirstName.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtFirstName.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtFirstName.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtFirstName.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtFirstName.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtFirstName.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtFirstName.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFirstName.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtFirstName.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtFirstName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtFirstName.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtFirstName.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtFirstName.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtFirstName.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtFirstName.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtFirstName.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtFirstName.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFirstName.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtFirstName.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtFirstName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtFirstName.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtFirstName.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtFirstName.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtFirstName.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtFirstName.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
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
        Me.txtLastName.Properties.Appearance.Font = CType(resources.GetObject("txtLastName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtLastName.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtLastName.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtLastName.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtLastName.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtLastName.Properties.Appearance.GradientMode = CType(resources.GetObject("txtLastName.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtLastName.Properties.Appearance.Image = CType(resources.GetObject("txtLastName.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtLastName.Properties.Appearance.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtLastName.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtLastName.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtLastName.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtLastName.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtLastName.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtLastName.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtLastName.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtLastName.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtLastName.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtLastName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtLastName.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtLastName.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtLastName.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtLastName.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtLastName.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtLastName.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtLastName.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtLastName.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtLastName.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtLastName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtLastName.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtLastName.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtLastName.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtLastName.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtLastName.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtLastName.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtLastName.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtLastName.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtLastName.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtLastName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtLastName.Properties.AutoHeight = CType(resources.GetObject("txtLastName.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject1, "SerializableAppearanceObject1")
        SerializableAppearanceObject1.Options.UseFont = True
        resources.ApplyResources(SerializableAppearanceObject2, "SerializableAppearanceObject2")
        SerializableAppearanceObject2.Options.UseFont = True
        Me.txtLastName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtLastName.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtLastName.Properties.Buttons1"), CType(resources.GetObject("txtLastName.Properties.Buttons2"), Integer), CType(resources.GetObject("txtLastName.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtLastName.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtLastName.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtLastName.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), Global.eidss.My.Resources.Resources.Browse5, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("txtLastName.Properties.Buttons7"), CType(resources.GetObject("txtLastName.Properties.Buttons8"), Object), CType(resources.GetObject("txtLastName.Properties.Buttons9"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtLastName.Properties.Buttons10"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtLastName.Properties.Buttons11"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtLastName.Properties.Buttons12"), CType(resources.GetObject("txtLastName.Properties.Buttons13"), Integer), CType(resources.GetObject("txtLastName.Properties.Buttons14"), Boolean), CType(resources.GetObject("txtLastName.Properties.Buttons15"), Boolean), CType(resources.GetObject("txtLastName.Properties.Buttons16"), Boolean), CType(resources.GetObject("txtLastName.Properties.Buttons17"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtLastName.Properties.Buttons18"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("txtLastName.Properties.Buttons19"), resources.GetString("txtLastName.Properties.Buttons20"), CType(resources.GetObject("txtLastName.Properties.Buttons21"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtLastName.Properties.Buttons22"), Boolean))})
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
        Me.dtpDOB.Properties.Appearance.Font = CType(resources.GetObject("dtpDOB.Properties.Appearance.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.Appearance.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.Appearance.GradientMode = CType(resources.GetObject("dtpDOB.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.Appearance.Image = CType(resources.GetObject("dtpDOB.Properties.Appearance.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.Appearance.Options.UseFont = True
        Me.dtpDOB.Properties.AppearanceDisabled.Font = CType(resources.GetObject("dtpDOB.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("dtpDOB.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.AppearanceDisabled.Image = CType(resources.GetObject("dtpDOB.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtpDOB.Properties.AppearanceDropDown.Font = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.AppearanceDropDown.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDown.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.AppearanceDropDown.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDown.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.AppearanceDropDown.Image = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtpDOB.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.AppearanceDropDownHeader.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHeader.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.AppearanceDropDownHeader.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHeader.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtpDOB.Properties.AppearanceDropDownHeaderHighlight.Font = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHeaderHighlight.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.AppearanceDropDownHeaderHighlight.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHeaderHighlight.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.AppearanceDropDownHeaderHighlight.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHeaderHighlight.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.AppearanceDropDownHeaderHighlight.GradientMode = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHeaderHighlight.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.AppearanceDropDownHeaderHighlight.Image = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHeaderHighlight.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtpDOB.Properties.AppearanceDropDownHighlight.Font = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHighlight.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.AppearanceDropDownHighlight.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHighlight.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.AppearanceDropDownHighlight.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHighlight.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.AppearanceDropDownHighlight.GradientMode = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHighlight.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.AppearanceDropDownHighlight.Image = CType(resources.GetObject("dtpDOB.Properties.AppearanceDropDownHighlight.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtpDOB.Properties.AppearanceFocused.Font = CType(resources.GetObject("dtpDOB.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("dtpDOB.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.AppearanceFocused.Image = CType(resources.GetObject("dtpDOB.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtpDOB.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("dtpDOB.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("dtpDOB.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("dtpDOB.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtpDOB.Properties.AppearanceWeekNumber.Font = CType(resources.GetObject("dtpDOB.Properties.AppearanceWeekNumber.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.AppearanceWeekNumber.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceWeekNumber.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.AppearanceWeekNumber.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.AppearanceWeekNumber.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.AppearanceWeekNumber.GradientMode = CType(resources.GetObject("dtpDOB.Properties.AppearanceWeekNumber.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.AppearanceWeekNumber.Image = CType(resources.GetObject("dtpDOB.Properties.AppearanceWeekNumber.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtpDOB.Properties.AutoHeight = CType(resources.GetObject("dtpDOB.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject3, "SerializableAppearanceObject3")
        SerializableAppearanceObject3.Options.UseFont = True
        Me.dtpDOB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtpDOB.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtpDOB.Properties.Buttons1"), CType(resources.GetObject("dtpDOB.Properties.Buttons2"), Integer), CType(resources.GetObject("dtpDOB.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtpDOB.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtpDOB.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtpDOB.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtpDOB.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("dtpDOB.Properties.Buttons8"), CType(resources.GetObject("dtpDOB.Properties.Buttons9"), Object), CType(resources.GetObject("dtpDOB.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtpDOB.Properties.Buttons11"), Boolean))})
        Me.dtpDOB.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtpDOB.Properties.CalendarTimeProperties.AccessibleDescription")
        Me.dtpDOB.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtpDOB.Properties.CalendarTimeProperties.AccessibleName")
        Me.dtpDOB.Properties.CalendarTimeProperties.Appearance.Font = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Appearance.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.CalendarTimeProperties.Appearance.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Appearance.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.CalendarTimeProperties.Appearance.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.CalendarTimeProperties.Appearance.GradientMode = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.CalendarTimeProperties.Appearance.Image = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Appearance.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.Font = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.GradientMode = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.Image = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.Font = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.GradientMode = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.Image = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.Font = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.Image = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.dtpDOB.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtpDOB.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        Me.dtpDOB.Properties.CalendarTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtpDOB.Properties.CalendarTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtpDOB.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtpDOB.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtpDOB.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtpDOB.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtpDOB.Properties.CalendarTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtpDOB.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtpDOB.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtpDOB.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtpDOB.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtpDOB.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtpDOB.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtpDOB.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.cbPersonSex.Properties.Appearance.Font = CType(resources.GetObject("cbPersonSex.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbPersonSex.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("cbPersonSex.Properties.Appearance.FontSizeDelta"), Integer)
        Me.cbPersonSex.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("cbPersonSex.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonSex.Properties.Appearance.GradientMode = CType(resources.GetObject("cbPersonSex.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonSex.Properties.Appearance.Image = CType(resources.GetObject("cbPersonSex.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbPersonSex.Properties.Appearance.Options.UseFont = True
        Me.cbPersonSex.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbPersonSex.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.cbPersonSex.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonSex.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonSex.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbPersonSex.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbPersonSex.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbPersonSex.Properties.AppearanceDropDown.FontSizeDelta = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDropDown.FontSizeDelta"), Integer)
        Me.cbPersonSex.Properties.AppearanceDropDown.FontStyleDelta = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDropDown.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonSex.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonSex.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbPersonSex.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbPersonSex.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbPersonSex.Properties.AppearanceDropDownHeader.FontSizeDelta = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDropDownHeader.FontSizeDelta"), Integer)
        Me.cbPersonSex.Properties.AppearanceDropDownHeader.FontStyleDelta = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDropDownHeader.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonSex.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonSex.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbPersonSex.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbPersonSex.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbPersonSex.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbPersonSex.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbPersonSex.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("cbPersonSex.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.cbPersonSex.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("cbPersonSex.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonSex.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbPersonSex.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonSex.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbPersonSex.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbPersonSex.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbPersonSex.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbPersonSex.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbPersonSex.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("cbPersonSex.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.cbPersonSex.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("cbPersonSex.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonSex.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbPersonSex.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonSex.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbPersonSex.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbPersonSex.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbPersonSex.Properties.AutoHeight = CType(resources.GetObject("cbPersonSex.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject4, "SerializableAppearanceObject4")
        SerializableAppearanceObject4.Options.UseFont = True
        Me.cbPersonSex.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbPersonSex.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbPersonSex.Properties.Buttons1"), CType(resources.GetObject("cbPersonSex.Properties.Buttons2"), Integer), CType(resources.GetObject("cbPersonSex.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbPersonSex.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbPersonSex.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbPersonSex.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbPersonSex.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, resources.GetString("cbPersonSex.Properties.Buttons8"), CType(resources.GetObject("cbPersonSex.Properties.Buttons9"), Object), CType(resources.GetObject("cbPersonSex.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbPersonSex.Properties.Buttons11"), Boolean))})
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
        Me.txtSecondName.Properties.Appearance.Font = CType(resources.GetObject("txtSecondName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtSecondName.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtSecondName.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtSecondName.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtSecondName.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtSecondName.Properties.Appearance.GradientMode = CType(resources.GetObject("txtSecondName.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSecondName.Properties.Appearance.Image = CType(resources.GetObject("txtSecondName.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtSecondName.Properties.Appearance.Options.UseFont = True
        Me.txtSecondName.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtSecondName.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtSecondName.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtSecondName.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtSecondName.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtSecondName.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtSecondName.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtSecondName.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSecondName.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtSecondName.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtSecondName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtSecondName.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtSecondName.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtSecondName.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtSecondName.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtSecondName.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtSecondName.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtSecondName.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtSecondName.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSecondName.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtSecondName.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtSecondName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtSecondName.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtSecondName.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtSecondName.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtSecondName.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtSecondName.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtSecondName.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
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
        Me.cbNationality.Properties.Appearance.Font = CType(resources.GetObject("cbNationality.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbNationality.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("cbNationality.Properties.Appearance.FontSizeDelta"), Integer)
        Me.cbNationality.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("cbNationality.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbNationality.Properties.Appearance.GradientMode = CType(resources.GetObject("cbNationality.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.Appearance.Image = CType(resources.GetObject("cbNationality.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.Appearance.Options.UseFont = True
        Me.cbNationality.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbNationality.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbNationality.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("cbNationality.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.cbNationality.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("cbNationality.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbNationality.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbNationality.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbNationality.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbNationality.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbNationality.Properties.AppearanceDropDown.FontSizeDelta = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDown.FontSizeDelta"), Integer)
        Me.cbNationality.Properties.AppearanceDropDown.FontStyleDelta = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDown.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbNationality.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbNationality.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbNationality.Properties.AppearanceDropDownHeader.FontSizeDelta = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDownHeader.FontSizeDelta"), Integer)
        Me.cbNationality.Properties.AppearanceDropDownHeader.FontStyleDelta = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDownHeader.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbNationality.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbNationality.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbNationality.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbNationality.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbNationality.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("cbNationality.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.cbNationality.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("cbNationality.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbNationality.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbNationality.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbNationality.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbNationality.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbNationality.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbNationality.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("cbNationality.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.cbNationality.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("cbNationality.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbNationality.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbNationality.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbNationality.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbNationality.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbNationality.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbNationality.Properties.AutoHeight = CType(resources.GetObject("cbNationality.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject5, "SerializableAppearanceObject5")
        SerializableAppearanceObject5.Options.UseFont = True
        Me.cbNationality.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbNationality.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbNationality.Properties.Buttons1"), CType(resources.GetObject("cbNationality.Properties.Buttons2"), Integer), CType(resources.GetObject("cbNationality.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbNationality.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbNationality.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbNationality.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbNationality.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, resources.GetString("cbNationality.Properties.Buttons8"), CType(resources.GetObject("cbNationality.Properties.Buttons9"), Object), CType(resources.GetObject("cbNationality.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbNationality.Properties.Buttons11"), Boolean))})
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
        Me.txtEmployerName.Properties.Appearance.Font = CType(resources.GetObject("txtEmployerName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtEmployerName.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtEmployerName.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtEmployerName.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtEmployerName.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtEmployerName.Properties.Appearance.GradientMode = CType(resources.GetObject("txtEmployerName.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtEmployerName.Properties.Appearance.Image = CType(resources.GetObject("txtEmployerName.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtEmployerName.Properties.Appearance.Options.UseFont = True
        Me.txtEmployerName.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtEmployerName.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtEmployerName.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtEmployerName.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtEmployerName.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtEmployerName.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtEmployerName.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtEmployerName.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtEmployerName.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtEmployerName.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtEmployerName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtEmployerName.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtEmployerName.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtEmployerName.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtEmployerName.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtEmployerName.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtEmployerName.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtEmployerName.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtEmployerName.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtEmployerName.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtEmployerName.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtEmployerName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtEmployerName.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtEmployerName.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtEmployerName.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtEmployerName.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtEmployerName.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtEmployerName.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
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
        Me.txtPhoneNumber.Properties.Appearance.Font = CType(resources.GetObject("txtPhoneNumber.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtPhoneNumber.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtPhoneNumber.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtPhoneNumber.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtPhoneNumber.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtPhoneNumber.Properties.Appearance.GradientMode = CType(resources.GetObject("txtPhoneNumber.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPhoneNumber.Properties.Appearance.Image = CType(resources.GetObject("txtPhoneNumber.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtPhoneNumber.Properties.Appearance.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtPhoneNumber.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtPhoneNumber.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtPhoneNumber.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPhoneNumber.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtPhoneNumber.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtPhoneNumber.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtPhoneNumber.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtPhoneNumber.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPhoneNumber.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtPhoneNumber.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtPhoneNumber.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtPhoneNumber.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtPhoneNumber.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
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
        Me.txtAge.Properties.Appearance.Font = CType(resources.GetObject("txtAge.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtAge.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtAge.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtAge.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtAge.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtAge.Properties.Appearance.GradientMode = CType(resources.GetObject("txtAge.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtAge.Properties.Appearance.Image = CType(resources.GetObject("txtAge.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtAge.Properties.Appearance.Options.UseFont = True
        Me.txtAge.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtAge.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtAge.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtAge.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtAge.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtAge.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtAge.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtAge.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtAge.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtAge.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtAge.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtAge.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtAge.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtAge.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtAge.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtAge.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtAge.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtAge.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtAge.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtAge.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtAge.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtAge.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtAge.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtAge.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtAge.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtAge.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtAge.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtAge.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtAge.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtAge.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtAge.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtAge.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtAge.Properties.AppearanceReadOnly.Options.UseFont = True
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
        Me.cbAgeUnits.Properties.Appearance.Font = CType(resources.GetObject("cbAgeUnits.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbAgeUnits.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("cbAgeUnits.Properties.Appearance.FontSizeDelta"), Integer)
        Me.cbAgeUnits.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("cbAgeUnits.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbAgeUnits.Properties.Appearance.GradientMode = CType(resources.GetObject("cbAgeUnits.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbAgeUnits.Properties.Appearance.Image = CType(resources.GetObject("cbAgeUnits.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbAgeUnits.Properties.Appearance.Options.UseFont = True
        Me.cbAgeUnits.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbAgeUnits.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.cbAgeUnits.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbAgeUnits.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbAgeUnits.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbAgeUnits.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbAgeUnits.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbAgeUnits.Properties.AppearanceDropDown.FontSizeDelta = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDropDown.FontSizeDelta"), Integer)
        Me.cbAgeUnits.Properties.AppearanceDropDown.FontStyleDelta = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDropDown.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbAgeUnits.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbAgeUnits.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbAgeUnits.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbAgeUnits.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbAgeUnits.Properties.AppearanceDropDownHeader.FontSizeDelta = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDropDownHeader.FontSizeDelta"), Integer)
        Me.cbAgeUnits.Properties.AppearanceDropDownHeader.FontStyleDelta = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDropDownHeader.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbAgeUnits.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbAgeUnits.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbAgeUnits.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbAgeUnits.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbAgeUnits.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.cbAgeUnits.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbAgeUnits.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbAgeUnits.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbAgeUnits.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbAgeUnits.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbAgeUnits.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.cbAgeUnits.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbAgeUnits.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbAgeUnits.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbAgeUnits.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbAgeUnits.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbAgeUnits.Properties.AutoHeight = CType(resources.GetObject("cbAgeUnits.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject6, "SerializableAppearanceObject6")
        SerializableAppearanceObject6.Options.UseFont = True
        Me.cbAgeUnits.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAgeUnits.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbAgeUnits.Properties.Buttons1"), CType(resources.GetObject("cbAgeUnits.Properties.Buttons2"), Integer), CType(resources.GetObject("cbAgeUnits.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbAgeUnits.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbAgeUnits.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbAgeUnits.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbAgeUnits.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, resources.GetString("cbAgeUnits.Properties.Buttons8"), CType(resources.GetObject("cbAgeUnits.Properties.Buttons9"), Object), CType(resources.GetObject("cbAgeUnits.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbAgeUnits.Properties.Buttons11"), Boolean))})
        Me.cbAgeUnits.Properties.NullText = resources.GetString("cbAgeUnits.Properties.NullText")
        Me.cbAgeUnits.Properties.NullValuePrompt = resources.GetString("cbAgeUnits.Properties.NullValuePrompt")
        Me.cbAgeUnits.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbAgeUnits.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'Employer_AddressLookup
        '
        resources.ApplyResources(Me.Employer_AddressLookup, "Employer_AddressLookup")
        Me.Employer_AddressLookup.Appearance.BackColor = CType(resources.GetObject("Employer_AddressLookup.Appearance.BackColor"), System.Drawing.Color)
        Me.Employer_AddressLookup.Appearance.Font = CType(resources.GetObject("Employer_AddressLookup.Appearance.Font"), System.Drawing.Font)
        Me.Employer_AddressLookup.Appearance.FontSizeDelta = CType(resources.GetObject("Employer_AddressLookup.Appearance.FontSizeDelta"), Integer)
        Me.Employer_AddressLookup.Appearance.FontStyleDelta = CType(resources.GetObject("Employer_AddressLookup.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.Employer_AddressLookup.Appearance.GradientMode = CType(resources.GetObject("Employer_AddressLookup.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.Employer_AddressLookup.Appearance.Image = CType(resources.GetObject("Employer_AddressLookup.Appearance.Image"), System.Drawing.Image)
        Me.Employer_AddressLookup.Appearance.Options.UseBackColor = True
        Me.Employer_AddressLookup.Appearance.Options.UseFont = True
        Me.Employer_AddressLookup.CanExpand = True
        Me.Employer_AddressLookup.FormID = Nothing
        Me.Employer_AddressLookup.HelpTopicID = Nothing
        Me.Employer_AddressLookup.KeyFieldName = "idfGeoLocation"
        Me.Employer_AddressLookup.MultiSelect = False
        Me.Employer_AddressLookup.Name = "Employer_AddressLookup"
        Me.Employer_AddressLookup.ObjectName = "Address"
        Me.Employer_AddressLookup.PopupEditHeight = 200
        Me.Employer_AddressLookup.PopupEditMinWidth = 400
        Me.Employer_AddressLookup.Sizable = True
        Me.Employer_AddressLookup.TableName = "Address"
        TagHelper1.Binder = Nothing
        TagHelper1.ClonedView = Nothing
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
        TagHelper1.QueryPopupHandler = Nothing
        TagHelper1.StringTag = ""
        TagHelper2.Binder = Nothing
        TagHelper2.ClonedView = Nothing
        TagHelper2.ControlLanguage = ""
        TagHelper2.Datasource = Nothing
        TagHelper2.HACodeName = Nothing
        TagHelper2.IntTag = -1
        TagHelper2.IsBarcode = False
        TagHelper2.IsKeyField = False
        TagHelper2.IsMandatory = False
        TagHelper2.IsReadOnly = False
        TagHelper2.LookupTableName = Nothing
        TagHelper2.MandatoryFieldName = Nothing
        TagHelper2.QueryPopupHandler = Nothing
        TagHelper2.StringTag = ""
        TagHelper2.Tag = Nothing
        TagHelper1.Tag = TagHelper2
        Me.Employer_AddressLookup.Tag = TagHelper1
        '
        'CurrentResidence_AddressLookup
        '
        resources.ApplyResources(Me.CurrentResidence_AddressLookup, "CurrentResidence_AddressLookup")
        Me.CurrentResidence_AddressLookup.Appearance.BackColor = CType(resources.GetObject("CurrentResidence_AddressLookup.Appearance.BackColor"), System.Drawing.Color)
        Me.CurrentResidence_AddressLookup.Appearance.Font = CType(resources.GetObject("CurrentResidence_AddressLookup.Appearance.Font"), System.Drawing.Font)
        Me.CurrentResidence_AddressLookup.Appearance.FontSizeDelta = CType(resources.GetObject("CurrentResidence_AddressLookup.Appearance.FontSizeDelta"), Integer)
        Me.CurrentResidence_AddressLookup.Appearance.FontStyleDelta = CType(resources.GetObject("CurrentResidence_AddressLookup.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.CurrentResidence_AddressLookup.Appearance.GradientMode = CType(resources.GetObject("CurrentResidence_AddressLookup.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.CurrentResidence_AddressLookup.Appearance.Image = CType(resources.GetObject("CurrentResidence_AddressLookup.Appearance.Image"), System.Drawing.Image)
        Me.CurrentResidence_AddressLookup.Appearance.Options.UseBackColor = True
        Me.CurrentResidence_AddressLookup.Appearance.Options.UseFont = True
        Me.CurrentResidence_AddressLookup.CanExpand = True
        Me.CurrentResidence_AddressLookup.ColumnCount = 3
        Me.CurrentResidence_AddressLookup.FormID = Nothing
        Me.CurrentResidence_AddressLookup.HelpTopicID = Nothing
        Me.CurrentResidence_AddressLookup.KeyFieldName = "idfGeoLocation"
        Me.CurrentResidence_AddressLookup.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.CurrentResidence_AddressLookup.MultiSelect = False
        Me.CurrentResidence_AddressLookup.Name = "CurrentResidence_AddressLookup"
        Me.CurrentResidence_AddressLookup.ObjectName = "Address"
        Me.CurrentResidence_AddressLookup.PopupEditHeight = 200
        Me.CurrentResidence_AddressLookup.PopupEditMinWidth = 400
        Me.CurrentResidence_AddressLookup.ShowContry = False
        Me.CurrentResidence_AddressLookup.ShowCoordinates = True
        Me.CurrentResidence_AddressLookup.Sizable = True
        Me.CurrentResidence_AddressLookup.TableName = "Address"
        Me.CurrentResidence_AddressLookup.UseParentBackColor = True
        '
        'lbPersonalIdType
        '
        resources.ApplyResources(Me.lbPersonalIdType, "lbPersonalIdType")
        Me.lbPersonalIdType.Name = "lbPersonalIdType"
        '
        'cbPersonalIdType
        '
        resources.ApplyResources(Me.cbPersonalIdType, "cbPersonalIdType")
        Me.cbPersonalIdType.Name = "cbPersonalIdType"
        Me.cbPersonalIdType.Properties.AccessibleDescription = resources.GetString("cbPersonalIdType.Properties.AccessibleDescription")
        Me.cbPersonalIdType.Properties.AccessibleName = resources.GetString("cbPersonalIdType.Properties.AccessibleName")
        Me.cbPersonalIdType.Properties.Appearance.Font = CType(resources.GetObject("cbPersonalIdType.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbPersonalIdType.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("cbPersonalIdType.Properties.Appearance.FontSizeDelta"), Integer)
        Me.cbPersonalIdType.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("cbPersonalIdType.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonalIdType.Properties.Appearance.GradientMode = CType(resources.GetObject("cbPersonalIdType.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonalIdType.Properties.Appearance.Image = CType(resources.GetObject("cbPersonalIdType.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbPersonalIdType.Properties.Appearance.Options.UseFont = True
        Me.cbPersonalIdType.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbPersonalIdType.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.cbPersonalIdType.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonalIdType.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonalIdType.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbPersonalIdType.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbPersonalIdType.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbPersonalIdType.Properties.AppearanceDropDown.FontSizeDelta = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDropDown.FontSizeDelta"), Integer)
        Me.cbPersonalIdType.Properties.AppearanceDropDown.FontStyleDelta = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDropDown.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonalIdType.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonalIdType.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbPersonalIdType.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbPersonalIdType.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbPersonalIdType.Properties.AppearanceDropDownHeader.FontSizeDelta = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDropDownHeader.FontSizeDelta"), Integer)
        Me.cbPersonalIdType.Properties.AppearanceDropDownHeader.FontStyleDelta = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDropDownHeader.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonalIdType.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonalIdType.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbPersonalIdType.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbPersonalIdType.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbPersonalIdType.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.cbPersonalIdType.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonalIdType.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonalIdType.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbPersonalIdType.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbPersonalIdType.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbPersonalIdType.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.cbPersonalIdType.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbPersonalIdType.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbPersonalIdType.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbPersonalIdType.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbPersonalIdType.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbPersonalIdType.Properties.AutoHeight = CType(resources.GetObject("cbPersonalIdType.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject7, "SerializableAppearanceObject7")
        SerializableAppearanceObject7.Options.UseFont = True
        Me.cbPersonalIdType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbPersonalIdType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbPersonalIdType.Properties.Buttons1"), CType(resources.GetObject("cbPersonalIdType.Properties.Buttons2"), Integer), CType(resources.GetObject("cbPersonalIdType.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbPersonalIdType.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbPersonalIdType.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbPersonalIdType.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbPersonalIdType.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject7, resources.GetString("cbPersonalIdType.Properties.Buttons8"), CType(resources.GetObject("cbPersonalIdType.Properties.Buttons9"), Object), CType(resources.GetObject("cbPersonalIdType.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbPersonalIdType.Properties.Buttons11"), Boolean))})
        Me.cbPersonalIdType.Properties.NullText = resources.GetString("cbPersonalIdType.Properties.NullText")
        Me.cbPersonalIdType.Properties.NullValuePrompt = resources.GetString("cbPersonalIdType.Properties.NullValuePrompt")
        Me.cbPersonalIdType.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbPersonalIdType.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'txtPersonalID
        '
        resources.ApplyResources(Me.txtPersonalID, "txtPersonalID")
        Me.txtPersonalID.Name = "txtPersonalID"
        Me.txtPersonalID.Properties.AccessibleDescription = resources.GetString("txtPersonalID.Properties.AccessibleDescription")
        Me.txtPersonalID.Properties.AccessibleName = resources.GetString("txtPersonalID.Properties.AccessibleName")
        Me.txtPersonalID.Properties.Appearance.Font = CType(resources.GetObject("txtPersonalID.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtPersonalID.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtPersonalID.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtPersonalID.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtPersonalID.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtPersonalID.Properties.Appearance.GradientMode = CType(resources.GetObject("txtPersonalID.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPersonalID.Properties.Appearance.Image = CType(resources.GetObject("txtPersonalID.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtPersonalID.Properties.Appearance.Options.UseFont = True
        Me.txtPersonalID.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtPersonalID.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtPersonalID.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtPersonalID.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtPersonalID.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtPersonalID.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtPersonalID.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtPersonalID.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPersonalID.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtPersonalID.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtPersonalID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPersonalID.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtPersonalID.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtPersonalID.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtPersonalID.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtPersonalID.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtPersonalID.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtPersonalID.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtPersonalID.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPersonalID.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtPersonalID.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtPersonalID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPersonalID.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtPersonalID.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtPersonalID.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtPersonalID.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtPersonalID.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtPersonalID.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtPersonalID.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtPersonalID.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtPersonalID.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtPersonalID.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtPersonalID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPersonalID.Properties.AutoHeight = CType(resources.GetObject("txtPersonalID.Properties.AutoHeight"), Boolean)
        Me.txtPersonalID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtPersonalID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtPersonalID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtPersonalID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtPersonalID.Properties.Mask.EditMask = resources.GetString("txtPersonalID.Properties.Mask.EditMask")
        Me.txtPersonalID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPersonalID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPersonalID.Properties.Mask.MaskType = CType(resources.GetObject("txtPersonalID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtPersonalID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtPersonalID.Properties.Mask.PlaceHolder"), Char)
        Me.txtPersonalID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPersonalID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPersonalID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPersonalID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPersonalID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtPersonalID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtPersonalID.Properties.NullValuePrompt = resources.GetString("txtPersonalID.Properties.NullValuePrompt")
        Me.txtPersonalID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtPersonalID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lbPersonalID
        '
        resources.ApplyResources(Me.lbPersonalID, "lbPersonalID")
        Me.lbPersonalID.Name = "lbPersonalID"
        '
        'Patient_Info
        '
        resources.ApplyResources(Me, "$this")
        Me.Appearance.Font = CType(resources.GetObject("Patient_Info.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.FontSizeDelta = CType(resources.GetObject("Patient_Info.Appearance.FontSizeDelta"), Integer)
        Me.Appearance.FontStyleDelta = CType(resources.GetObject("Patient_Info.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.Appearance.GradientMode = CType(resources.GetObject("Patient_Info.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.Appearance.Image = CType(resources.GetObject("Patient_Info.Appearance.Image"), System.Drawing.Image)
        Me.Appearance.Options.UseFont = True
        Me.Controls.Add(Me.txtPersonalID)
        Me.Controls.Add(Me.lbPersonalID)
        Me.Controls.Add(Me.lbPersonalIdType)
        Me.Controls.Add(Me.cbPersonalIdType)
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
        CType(Me.dtpDOB.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDOB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbPersonSex.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSecondName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbNationality.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmployerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhoneNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAgeUnits.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbPersonalIdType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPersonalID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Event OnFieldInfoChanged As EventHandler
    Public Event OnClearRootLink As EventHandler
    Public Event OnRootLinkChanged As EventHandler

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

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
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
            AddHandler cbPersonalIdType.EditValueChanged, AddressOf ctrl_TextChanged
            AddHandler txtPersonalID.EditValueChanged, AddressOf ctrl_TextChanged


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
                txtLastName.Properties.Buttons(0).Visible = Not (IsSearchMode OrElse IsRootPatient)
                txtLastName.Properties.Buttons(1).Visible = Not (IsSearchMode OrElse IsRootPatient)
                Core.LookupBinder.BindPersonalDataTextEdit(txtSecondName, baseDataSet, Patient_DB.tlbHuman + ".strSecondName", group, IgnorePersonalData, PersonalDataString)
                Core.LookupBinder.BindPersonalDataTextEdit(txtPersonalID, baseDataSet, Patient_DB.tlbHuman + ".strPersonID", group, IgnorePersonalData, PersonalDataString)
                Core.LookupBinder.BindPersonalDataBaseLookup(cbPersonalIdType, baseDataSet, Patient_DB.tlbHuman + ".idfsPersonIDType", db.BaseReferenceType.rftPersonIDType, False, False, group, IgnorePersonalData, PersonalDataString)
                If (IsSearchMode) Then
                    cbPersonalIdType.Properties.DataSource = LookupCache.InsertEmptyLine(CType(cbPersonalIdType.Properties.DataSource, LookupCacheDataView))
                End If
                eventManager.AttachDataHandler(Patient_DB.tlbHuman + ".idfsPersonIDType", AddressOf PersonIdTypeChanged)
                eventManager.Cascade(Patient_DB.tlbHuman + ".idfsPersonIDType")
                m_HidePatientName = (txtLastName.DataBindings.Count = 0)


                If HidePersonalData Then
                    group = PersonalDataGroup.Human_PersonAge
                End If
                Core.LookupBinder.BindPersonalDataDateEdit(dtpDOB, baseDataSet, Patient_DB.tlbHuman + ".datDateofBirth", group, IgnorePersonalData, PersonalDataString)
                Core.LookupBinder.BindHumanAgeUnits(cbAgeUnits, baseDataSet, Nothing, group, IgnorePersonalData, PersonalDataString)
                m_HidePatientAge = (dtpDOB.DataBindings.Count = 0)
                If HidePersonalData Then
                    group = PersonalDataGroup.Human_PersonSex
                End If
                eventManager.AttachDataHandler(Patient_DB.tlbHuman + ".datDateofBirth", AddressOf DateOfBirthChanged)
                Core.LookupBinder.BindPersonalDataBaseLookup(cbPersonSex, baseDataSet, Patient_DB.tlbHuman + ".idfsHumanGender", db.BaseReferenceType.rftHumanGender, False, True, group, IgnorePersonalData, PersonalDataString)
                m_HidePatientSex = (cbPersonSex.DataBindings.Count = 0)

                If HidePersonalData Then
                    groups = New PersonalDataGroup() {PersonalDataGroup.Human_Employer_Details, PersonalDataGroup.Human_Employer_Settlement}

                End If
                'Core.LookupBinder.BindBaseLookup(cbAgeUnits, baseDataSet, Nothing, db.BaseReferenceType.rftHumanAgeType, False)


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

                Core.LookupBinder.BindBaseLookup(cbNationality, baseDataSet, Patient_DB.tlbHuman + ".idfsNationality", db.BaseReferenceType.rftNationality, Not IsSearchMode)

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

    Private Sub DateOfBirthChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        ctrl_TextChanged(dtpDOB, New EventArgs())
        Dim humanCase As HumanCaseDetail = FindParentHumanCase()
        If (Not humanCase Is Nothing) Then
            humanCase.UpdateDOBandAge()
        End If
    End Sub

    Private Sub PersonIdTypeChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If IsSearchMode() Then Return
        Dim personalIdTypeDefined As Boolean = Not Utils.IsEmpty(e.Value) AndAlso CLng(e.Value) > 0 AndAlso CLng(e.Value) <> CLng(PersonalIDType.Unknown)
        Dim rdonly As Boolean = [ReadOnly] OrElse Not personalIdTypeDefined
        ApplyControlState(txtPersonalID, ControlState.Normal)
        SetControlReadOnly(txtPersonalID, rdonly, False)
        If Not rdonly Then
            SetMandatory(txtPersonalID)
        Else
            If Not personalIdTypeDefined Then
                e.Row("strPersonID") = DBNull.Value
                e.Row.EndEdit()
            End If
        End If

    End Sub
    Private Sub SetMandatory(ctl As BaseControl)
        If (TypeOf (ctl.Tag) Is TagHelper) Then
            CType(ctl.Tag, TagHelper).IsMandatory = True
            SetControlReadOnly(ctl, False, False)
        Else
            ctl.Tag = "{M}"
        End If
        SetControlMandatoryState(ctl)
    End Sub
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property IsRootPatient() As Boolean

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property PatientRow As DataRow
        Get
            If baseDataSet.Tables.Contains(Patient_DB.tlbHuman) AndAlso baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0 Then
                Return baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)
            End If
            Return Nothing
        End Get
    End Property
    Public Sub CopyInfoFromRootObject(ByVal aRootHumanID As Object)
        If Utils.IsEmpty(aRootHumanID) Then Return
        Dim row As DataRow = PatientRow
        If row Is Nothing Then Return
        If Utils.Str(RootID) = Utils.Str(aRootHumanID) Then

        End If

        Dim idfHuman As Object = row("idfHuman")
        Dim idfCurrentResidenceAddress As Object = row("idfCurrentResidenceAddress")
        Dim idfEmployerAddress As Object = row("idfEmployerAddress")
        Dim idfCase As Object = row("idfCase")

        LoadData(aRootHumanID)

        row = PatientRow
        row("idfHuman") = idfHuman
        row("idfCurrentResidenceAddress") = idfCurrentResidenceAddress
        row("idfEmployerAddress") = idfEmployerAddress
        RootID = aRootHumanID
        CaseID = idfCase
        row.AcceptChanges()
        row.SetModified()
        If (Not CurrentResidence_AddressLookup.AddressRow Is Nothing) Then
            CurrentResidence_AddressLookup.AddressRow("idfGeoLocation") = idfCurrentResidenceAddress
        End If
        If (Not Employer_AddressLookup.AddressRow Is Nothing) Then
            Employer_AddressLookup.AddressRow("idfGeoLocation") = idfEmployerAddress
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
            Dim row As DataRow = PatientRow
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
            Dim row As DataRow = PatientRow
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

    Public Overrides Function Post(Optional ByVal postType As bv.common.Enums.PostType = bv.common.Enums.PostType.FinalPosting) As Boolean
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

    Public Sub CurrentResidence_AddressLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CurrentResidence_AddressLookup.Load
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

    'Private Sub dtpDOB_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDOB.EditValueChanged
    '    If Not m_BindingDefined Then Return
    '    ctrl_TextChanged(sender, e)
    '    If (Not Parent Is Nothing) AndAlso _
    '           (Not Parent.Parent Is Nothing) AndAlso _
    '           (Not Parent.Parent.Parent Is Nothing) AndAlso _
    '           (Not Parent.Parent.Parent.Parent Is Nothing) AndAlso _
    '           (TypeOf (Parent.Parent.Parent.Parent) Is HumanCaseDetail) Then
    '        DataEventManager.SubmitCurrentEdit(dtpDOB)
    '        CType(Parent.Parent.Parent.Parent, HumanCaseDetail).UpdateDOBandAge()
    '    End If
    'End Sub

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

    Public ReadOnly Property GetPersonID() As String
        Get
            If (m_HidePatientName) Then
                Return "*"
            End If
            If (Not baseDataSet Is Nothing) AndAlso _
               (baseDataSet.Tables.Contains(Patient_DB.tlbHuman) = True) AndAlso _
               (baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0) Then
                Return Utils.Str(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("strPersonID"))
            End If
            Return ""
        End Get
    End Property
    Public ReadOnly Property GetPersonIDType() As String
        Get
            If (Not baseDataSet Is Nothing) AndAlso _
               (baseDataSet.Tables.Contains(Patient_DB.tlbHuman) = True) AndAlso _
               (baseDataSet.Tables(Patient_DB.tlbHuman).Rows.Count > 0) Then
                Return LookupCache.GetLookupValue(baseDataSet.Tables(Patient_DB.tlbHuman).Rows(0)("idfsPersonIDType"), BaseReferenceType.rftPersonIDType, "name")
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


    Private Sub txtLastName_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtLastName.ButtonClick
        If e.Button.Kind = ButtonPredefines.Glyph Then
            SelectPatient()
        ElseIf e.Button.Kind = ButtonPredefines.Delete Then
            DeletePatient()
        End If
    End Sub
    Private Sub SelectPatient()
        Dim filter As New FilterParams()
        filter.Add("strLastName", "like", txtLastName.Text)
        filter.Add("idfsRegion", "=", -1L)
        Dim patientList As IBaseListPanel = New PatientListPanel

        patientList.InitialSearchFilter = filter
        Dim r As IObject = BaseFormManager.ShowForSelection(patientList, FindForm, , 1024, 800)
        If Not r Is Nothing Then
            Dim row As DataRow = PatientRow
            If row Is Nothing Then Return
            Dim idfRegistrationAddress As Object = row("idfRegistrationAddress")


            CopyInfoFromRootObject(r.Key)
            row = PatientRow
            Dim humanCase As HumanCaseDetail = FindParentHumanCase()
            If humanCase Is Nothing Then
                Return
            End If
            If Not Utils.IsEmpty(humanCase.lpPermanentAddress.ID) Then
                idfRegistrationAddress = humanCase.lpPermanentAddress.ID
            End If
            humanCase.UpdateDOBandAge()
            If row Is Nothing OrElse row("idfRegistrationAddress") Is DBNull.Value Then
                humanCase.lpPermanentAddress.Clear()
            Else
                humanCase.lpPermanentAddress.LoadData(row("idfRegistrationAddress"))
            End If
            If Utils.IsEmpty(idfRegistrationAddress) Then
                idfRegistrationAddress = BaseDbService.NewIntID()
            End If
            If (Not humanCase.lpPermanentAddress.AddressRow Is Nothing) Then
                humanCase.lpPermanentAddress.AddressRow("idfGeoLocation") = idfRegistrationAddress
            End If
            row("idfRegistrationAddress") = idfRegistrationAddress
            Core.LookupBinder.BindPersonalDataSpinEdit(txtAge, humanCase.baseDataSet, HumanCase_DB.tlbHumanCase + ".intPatientAge", PersonalDataGroup.Human_PersonAge, IgnorePersonalData, 0, 0, False, 1, PersonalDataString)
            Core.LookupBinder.BindHumanAgeUnits(cbAgeUnits, humanCase.baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsHumanAgeType", PersonalDataGroup.Human_PersonAge, IgnorePersonalData, PersonalDataString)
            Dim humanCaseRow As DataRow = humanCase.baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)
            humanCaseRow("idfsOccupationType") = row("idfsOccupationType")
            humanCaseRow("strRegistrationPhone") = row("strRegistrationPhone")
            humanCaseRow("idfRegistrationAddress") = idfRegistrationAddress
            humanCaseRow("strWorkPhone") = row("strWorkPhone")
            humanCaseRow.EndEdit()
        End If
    End Sub

    Private Function FindParentHumanCase() As HumanCaseDetail
        Dim ctl As Control = Parent
        While Not ctl Is Nothing
            If TypeOf ctl Is HumanCaseDetail Then
                Return CType(ctl, HumanCaseDetail)
            End If
            ctl = ctl.Parent
        End While
        Return Nothing
    End Function
    Private Sub DeletePatient()
        If Not WinUtils.ConfirmLookupClear() Then
            Return
        End If
        RemovePatientRootLink()
    End Sub

    Private Sub RemovePatientRootLink()
        Dim row As DataRow = PatientRow
        If PatientRow Is Nothing Then
            Return
        End If
        row.Table.BeginLoadData()
        RootID = BaseDbService.NewIntID
        row("intPatientAgeFromCase") = DBNull.Value
        row("idfsHumanAgeTypeFromCase") = DBNull.Value
        row("idfsOccupationType") = DBNull.Value
        row("idfsNationality") = DBNull.Value
        row("idfsHumanGender") = DBNull.Value
        row("datDateofBirth") = DBNull.Value
        row("strLastName") = DBNull.Value
        row("strSecondName") = DBNull.Value
        row("strFirstName") = DBNull.Value
        row("strRegistrationPhone") = DBNull.Value
        row("strEmployerName") = DBNull.Value
        row("strHomePhone") = DBNull.Value
        row("strWorkPhone") = DBNull.Value
        row("idfsPersonIDType") = DBNull.Value
        row("strPersonID") = DBNull.Value
        row.EndEdit()
        eventManager.Cascade(Patient_DB.tlbHuman + ".datDateofBirth")
        row.Table.EndLoadData()
        CurrentResidence_AddressLookup.Clear()
        Employer_AddressLookup.Clear()
        Dim humanCase As HumanCaseDetail = FindParentHumanCase()
        If humanCase Is Nothing Then
            Return
        End If

        Dim humanCaseRow As DataRow = humanCase.baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)
        humanCaseRow("idfsOccupationType") = DBNull.Value
        humanCaseRow("strRegistrationPhone") = DBNull.Value
        humanCaseRow("strWorkPhone") = DBNull.Value
        humanCaseRow("intPatientAge") = DBNull.Value
        humanCaseRow("idfsHumanAgeType") = DBNull.Value
        humanCaseRow.EndEdit()
        Core.LookupBinder.BindPersonalDataSpinEdit(txtAge, humanCase.baseDataSet, HumanCase_DB.tlbHumanCase + ".intPatientAge", PersonalDataGroup.Human_PersonAge, IgnorePersonalData, 0, 0, False, 1, PersonalDataString)
        Core.LookupBinder.BindHumanAgeUnits(cbAgeUnits, humanCase.baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsHumanAgeType", PersonalDataGroup.Human_PersonAge, IgnorePersonalData, PersonalDataString)

        RaiseEvent OnClearRootLink(Me, EventArgs.Empty)
    End Sub
    Public Overrides Sub ControlBoundChange(sender As Object, args As EventArgs)
        Dim designer As ControlDesigner = CType(sender, ControlDesigner)
        If (Not designer Is Nothing AndAlso Not designer.ProcessedControl Is Nothing) Then
            If designer.ProcessedControl Is lblPhoneNumber OrElse _
                designer.ProcessedControl Is lblFirstName OrElse _
                designer.ProcessedControl Is lblPatronymic OrElse _
                designer.ProcessedControl Is txtLastName OrElse _
                designer.ProcessedControl Is txtFirstName OrElse _
                designer.ProcessedControl Is txtSecondName Then
                CurrentResidence_AddressLookup_Load(CurrentResidence_AddressLookup, EventArgs.Empty)
            End If
        End If
    End Sub
End Class

