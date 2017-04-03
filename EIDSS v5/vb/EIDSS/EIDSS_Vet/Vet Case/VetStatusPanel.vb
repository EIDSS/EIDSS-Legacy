Imports EIDSS.Enums
Imports bv.winclient.Core
Imports System.Collections.Generic
Imports EIDSS.model.Resources
Imports bv.winclient.BasePanel
Imports EIDSS.winclient.Outbreaks
Imports bv.model.Model.Core
Imports EIDSS.ActiveSurveillance
Imports bv.common.Resources
Imports bv.winclient.Localization
Imports EIDSS.model.Enums

Public Class VetStatusPanel
    Inherits BaseDetailPanel
    Dim VetStatusDbService As VetCase_DB

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitCustomMandatoryFields()
        VetStatusDbService = New VetCase_DB
        DbService = VetStatusDbService
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
    Friend WithEvents GeneralGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbOutBreak As System.Windows.Forms.Label
    Friend WithEvents lbCaseID As System.Windows.Forms.Label
    Friend WithEvents lbFieldAccessionID As System.Windows.Forms.Label
    Friend WithEvents txtCaseID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbCaseClassification As System.Windows.Forms.Label
    Friend WithEvents lkpCaseClassification As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtFieldAccessionID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbDiseaseName As System.Windows.Forms.Label
    Friend WithEvents txtDiseaseName As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lbCaseStatus As System.Windows.Forms.Label
    Friend WithEvents cbCaseStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtSessionID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lbSessionID As System.Windows.Forms.Label
    Friend WithEvents lbReportType As System.Windows.Forms.Label
    Friend WithEvents cbReportType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtOutbreakID As DevExpress.XtraEditors.ButtonEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetStatusPanel))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.txtDiseaseName = New DevExpress.XtraEditors.ButtonEdit()
        Me.GeneralGroup = New DevExpress.XtraEditors.GroupControl()
        Me.lbReportType = New System.Windows.Forms.Label()
        Me.cbReportType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtSessionID = New DevExpress.XtraEditors.ButtonEdit()
        Me.lbSessionID = New System.Windows.Forms.Label()
        Me.txtOutbreakID = New DevExpress.XtraEditors.ButtonEdit()
        Me.cbCaseStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbOutBreak = New System.Windows.Forms.Label()
        Me.lbCaseID = New System.Windows.Forms.Label()
        Me.lbFieldAccessionID = New System.Windows.Forms.Label()
        Me.txtCaseID = New DevExpress.XtraEditors.TextEdit()
        Me.lbCaseClassification = New System.Windows.Forms.Label()
        Me.lkpCaseClassification = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtFieldAccessionID = New DevExpress.XtraEditors.TextEdit()
        Me.lbDiseaseName = New System.Windows.Forms.Label()
        Me.lbCaseStatus = New System.Windows.Forms.Label()
        CType(Me.txtDiseaseName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GeneralGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GeneralGroup.SuspendLayout()
        CType(Me.cbReportType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSessionID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutbreakID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCaseStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkpCaseClassification.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFieldAccessionID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDiseaseName
        '
        resources.ApplyResources(Me.txtDiseaseName, "txtDiseaseName")
        Me.txtDiseaseName.Name = "txtDiseaseName"
        Me.txtDiseaseName.Properties.AccessibleDescription = resources.GetString("txtDiseaseName.Properties.AccessibleDescription")
        Me.txtDiseaseName.Properties.AccessibleName = resources.GetString("txtDiseaseName.Properties.AccessibleName")
        Me.txtDiseaseName.Properties.Appearance.GradientMode = CType(resources.GetObject("txtDiseaseName.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtDiseaseName.Properties.Appearance.Image = CType(resources.GetObject("txtDiseaseName.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtDiseaseName.Properties.Appearance.Options.UseFont = True
        Me.txtDiseaseName.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtDiseaseName.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtDiseaseName.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtDiseaseName.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtDiseaseName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtDiseaseName.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtDiseaseName.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtDiseaseName.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtDiseaseName.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtDiseaseName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtDiseaseName.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtDiseaseName.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtDiseaseName.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtDiseaseName.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtDiseaseName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtDiseaseName.Properties.AutoHeight = CType(resources.GetObject("txtDiseaseName.Properties.AutoHeight"), Boolean)
        Me.txtDiseaseName.Properties.Mask.AutoComplete = CType(resources.GetObject("txtDiseaseName.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtDiseaseName.Properties.Mask.BeepOnError = CType(resources.GetObject("txtDiseaseName.Properties.Mask.BeepOnError"), Boolean)
        Me.txtDiseaseName.Properties.Mask.EditMask = resources.GetString("txtDiseaseName.Properties.Mask.EditMask")
        Me.txtDiseaseName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtDiseaseName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtDiseaseName.Properties.Mask.MaskType = CType(resources.GetObject("txtDiseaseName.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtDiseaseName.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtDiseaseName.Properties.Mask.PlaceHolder"), Char)
        Me.txtDiseaseName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtDiseaseName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtDiseaseName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtDiseaseName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtDiseaseName.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtDiseaseName.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtDiseaseName.Properties.NullValuePrompt = resources.GetString("txtDiseaseName.Properties.NullValuePrompt")
        Me.txtDiseaseName.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtDiseaseName.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtDiseaseName.Properties.ReadOnly = True
        Me.txtDiseaseName.Tag = "{R}"
        '
        'GeneralGroup
        '
        resources.ApplyResources(Me.GeneralGroup, "GeneralGroup")
        Me.GeneralGroup.Appearance.BackColor = CType(resources.GetObject("GeneralGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.GeneralGroup.Appearance.BorderColor = CType(resources.GetObject("GeneralGroup.Appearance.BorderColor"), System.Drawing.Color)
        Me.GeneralGroup.Appearance.GradientMode = CType(resources.GetObject("GeneralGroup.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.GeneralGroup.Appearance.Image = CType(resources.GetObject("GeneralGroup.Appearance.Image"), System.Drawing.Image)
        Me.GeneralGroup.Appearance.Options.UseBackColor = True
        Me.GeneralGroup.Appearance.Options.UseBorderColor = True
        Me.GeneralGroup.Appearance.Options.UseFont = True
        Me.GeneralGroup.AppearanceCaption.GradientMode = CType(resources.GetObject("GeneralGroup.AppearanceCaption.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.GeneralGroup.AppearanceCaption.Image = CType(resources.GetObject("GeneralGroup.AppearanceCaption.Image"), System.Drawing.Image)
        Me.GeneralGroup.AppearanceCaption.Options.UseFont = True
        Me.GeneralGroup.Controls.Add(Me.cbReportType)
        Me.GeneralGroup.Controls.Add(Me.txtSessionID)
        Me.GeneralGroup.Controls.Add(Me.lbSessionID)
        Me.GeneralGroup.Controls.Add(Me.txtOutbreakID)
        Me.GeneralGroup.Controls.Add(Me.cbCaseStatus)
        Me.GeneralGroup.Controls.Add(Me.lbOutBreak)
        Me.GeneralGroup.Controls.Add(Me.txtCaseID)
        Me.GeneralGroup.Controls.Add(Me.lbCaseClassification)
        Me.GeneralGroup.Controls.Add(Me.lkpCaseClassification)
        Me.GeneralGroup.Controls.Add(Me.txtDiseaseName)
        Me.GeneralGroup.Controls.Add(Me.txtFieldAccessionID)
        Me.GeneralGroup.Controls.Add(Me.lbDiseaseName)
        Me.GeneralGroup.Controls.Add(Me.lbCaseStatus)
        Me.GeneralGroup.Controls.Add(Me.lbCaseID)
        Me.GeneralGroup.Controls.Add(Me.lbFieldAccessionID)
        Me.GeneralGroup.Controls.Add(Me.lbReportType)
        Me.GeneralGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.GeneralGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GeneralGroup.Name = "GeneralGroup"
        Me.GeneralGroup.TabStop = True
        '
        'lbReportType
        '
        resources.ApplyResources(Me.lbReportType, "lbReportType")
        Me.lbReportType.Name = "lbReportType"
        '
        'cbReportType
        '
        resources.ApplyResources(Me.cbReportType, "cbReportType")
        Me.cbReportType.Name = "cbReportType"
        Me.cbReportType.Properties.AccessibleDescription = resources.GetString("cbReportType.Properties.AccessibleDescription")
        Me.cbReportType.Properties.AccessibleName = resources.GetString("cbReportType.Properties.AccessibleName")
        Me.cbReportType.Properties.Appearance.GradientMode = CType(resources.GetObject("cbReportType.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbReportType.Properties.Appearance.Image = CType(resources.GetObject("cbReportType.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbReportType.Properties.Appearance.Options.UseFont = True
        Me.cbReportType.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbReportType.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbReportType.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbReportType.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbReportType.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbReportType.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbReportType.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbReportType.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbReportType.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbReportType.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbReportType.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbReportType.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbReportType.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbReportType.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbReportType.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbReportType.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbReportType.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbReportType.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbReportType.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbReportType.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbReportType.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbReportType.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbReportType.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbReportType.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbReportType.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbReportType.Properties.AutoHeight = CType(resources.GetObject("cbReportType.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject1, "SerializableAppearanceObject1")
        SerializableAppearanceObject1.Options.UseFont = True
        Me.cbReportType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReportType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbReportType.Properties.Buttons1"), CType(resources.GetObject("cbReportType.Properties.Buttons2"), Integer), CType(resources.GetObject("cbReportType.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbReportType.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbReportType.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbReportType.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbReportType.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbReportType.Properties.Buttons8"), CType(resources.GetObject("cbReportType.Properties.Buttons9"), Object), CType(resources.GetObject("cbReportType.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbReportType.Properties.Buttons11"), Boolean))})
        Me.cbReportType.Properties.NullText = resources.GetString("cbReportType.Properties.NullText")
        Me.cbReportType.Properties.NullValuePrompt = resources.GetString("cbReportType.Properties.NullValuePrompt")
        Me.cbReportType.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbReportType.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbReportType.Tag = "{M}"
        '
        'txtSessionID
        '
        resources.ApplyResources(Me.txtSessionID, "txtSessionID")
        Me.txtSessionID.Name = "txtSessionID"
        Me.txtSessionID.Properties.AccessibleDescription = resources.GetString("txtSessionID.Properties.AccessibleDescription")
        Me.txtSessionID.Properties.AccessibleName = resources.GetString("txtSessionID.Properties.AccessibleName")
        Me.txtSessionID.Properties.Appearance.GradientMode = CType(resources.GetObject("txtSessionID.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSessionID.Properties.Appearance.Image = CType(resources.GetObject("txtSessionID.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtSessionID.Properties.Appearance.Options.UseFont = True
        Me.txtSessionID.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtSessionID.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSessionID.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtSessionID.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtSessionID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtSessionID.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtSessionID.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSessionID.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtSessionID.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtSessionID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtSessionID.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtSessionID.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSessionID.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtSessionID.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtSessionID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtSessionID.Properties.AutoHeight = CType(resources.GetObject("txtSessionID.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject2, "SerializableAppearanceObject2")
        SerializableAppearanceObject2.Options.UseFont = True
        Me.txtSessionID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtSessionID.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtSessionID.Properties.Buttons1"), CType(resources.GetObject("txtSessionID.Properties.Buttons2"), Integer), CType(resources.GetObject("txtSessionID.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtSessionID.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtSessionID.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtSessionID.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtSessionID.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("txtSessionID.Properties.Buttons8"), CType(resources.GetObject("txtSessionID.Properties.Buttons9"), Object), CType(resources.GetObject("txtSessionID.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtSessionID.Properties.Buttons11"), Boolean))})
        Me.txtSessionID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtSessionID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtSessionID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtSessionID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtSessionID.Properties.Mask.EditMask = resources.GetString("txtSessionID.Properties.Mask.EditMask")
        Me.txtSessionID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSessionID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSessionID.Properties.Mask.MaskType = CType(resources.GetObject("txtSessionID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtSessionID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtSessionID.Properties.Mask.PlaceHolder"), Char)
        Me.txtSessionID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSessionID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSessionID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSessionID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSessionID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtSessionID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtSessionID.Properties.NullValuePrompt = resources.GetString("txtSessionID.Properties.NullValuePrompt")
        Me.txtSessionID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtSessionID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtSessionID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lbSessionID
        '
        resources.ApplyResources(Me.lbSessionID, "lbSessionID")
        Me.lbSessionID.Name = "lbSessionID"
        '
        'txtOutbreakID
        '
        resources.ApplyResources(Me.txtOutbreakID, "txtOutbreakID")
        Me.txtOutbreakID.Name = "txtOutbreakID"
        Me.txtOutbreakID.Properties.AccessibleDescription = resources.GetString("txtOutbreakID.Properties.AccessibleDescription")
        Me.txtOutbreakID.Properties.AccessibleName = resources.GetString("txtOutbreakID.Properties.AccessibleName")
        Me.txtOutbreakID.Properties.Appearance.GradientMode = CType(resources.GetObject("txtOutbreakID.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtOutbreakID.Properties.Appearance.Image = CType(resources.GetObject("txtOutbreakID.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtOutbreakID.Properties.Appearance.Options.UseFont = True
        Me.txtOutbreakID.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtOutbreakID.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtOutbreakID.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtOutbreakID.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtOutbreakID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtOutbreakID.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtOutbreakID.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtOutbreakID.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtOutbreakID.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtOutbreakID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtOutbreakID.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtOutbreakID.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtOutbreakID.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtOutbreakID.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtOutbreakID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtOutbreakID.Properties.AutoHeight = CType(resources.GetObject("txtOutbreakID.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject3, "SerializableAppearanceObject3")
        SerializableAppearanceObject3.Options.UseFont = True
        resources.ApplyResources(SerializableAppearanceObject4, "SerializableAppearanceObject4")
        SerializableAppearanceObject4.Options.UseFont = True
        resources.ApplyResources(SerializableAppearanceObject5, "SerializableAppearanceObject5")
        SerializableAppearanceObject5.Options.UseFont = True
        Me.txtOutbreakID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtOutbreakID.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtOutbreakID.Properties.Buttons1"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons2"), Integer), CType(resources.GetObject("txtOutbreakID.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), Global.EIDSS.My.Resources.Resources.Browse5, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("txtOutbreakID.Properties.Buttons7"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons8"), Object), CType(resources.GetObject("txtOutbreakID.Properties.Buttons9"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtOutbreakID.Properties.Buttons10"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtOutbreakID.Properties.Buttons11"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtOutbreakID.Properties.Buttons12"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons13"), Integer), CType(resources.GetObject("txtOutbreakID.Properties.Buttons14"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons15"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons16"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons17"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtOutbreakID.Properties.Buttons18"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, resources.GetString("txtOutbreakID.Properties.Buttons19"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons20"), Object), CType(resources.GetObject("txtOutbreakID.Properties.Buttons21"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtOutbreakID.Properties.Buttons22"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtOutbreakID.Properties.Buttons23"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtOutbreakID.Properties.Buttons24"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons25"), Integer), CType(resources.GetObject("txtOutbreakID.Properties.Buttons26"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons27"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons28"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons29"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtOutbreakID.Properties.Buttons30"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, resources.GetString("txtOutbreakID.Properties.Buttons31"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons32"), Object), CType(resources.GetObject("txtOutbreakID.Properties.Buttons33"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtOutbreakID.Properties.Buttons34"), Boolean))})
        Me.txtOutbreakID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtOutbreakID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtOutbreakID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtOutbreakID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtOutbreakID.Properties.Mask.EditMask = resources.GetString("txtOutbreakID.Properties.Mask.EditMask")
        Me.txtOutbreakID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtOutbreakID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtOutbreakID.Properties.Mask.MaskType = CType(resources.GetObject("txtOutbreakID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtOutbreakID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtOutbreakID.Properties.Mask.PlaceHolder"), Char)
        Me.txtOutbreakID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtOutbreakID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtOutbreakID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtOutbreakID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtOutbreakID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtOutbreakID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtOutbreakID.Properties.NullValuePrompt = resources.GetString("txtOutbreakID.Properties.NullValuePrompt")
        Me.txtOutbreakID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtOutbreakID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtOutbreakID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cbCaseStatus
        '
        resources.ApplyResources(Me.cbCaseStatus, "cbCaseStatus")
        Me.cbCaseStatus.Name = "cbCaseStatus"
        Me.cbCaseStatus.Properties.AccessibleDescription = resources.GetString("cbCaseStatus.Properties.AccessibleDescription")
        Me.cbCaseStatus.Properties.AccessibleName = resources.GetString("cbCaseStatus.Properties.AccessibleName")
        Me.cbCaseStatus.Properties.Appearance.GradientMode = CType(resources.GetObject("cbCaseStatus.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCaseStatus.Properties.Appearance.Image = CType(resources.GetObject("cbCaseStatus.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbCaseStatus.Properties.Appearance.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbCaseStatus.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCaseStatus.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbCaseStatus.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbCaseStatus.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbCaseStatus.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCaseStatus.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbCaseStatus.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbCaseStatus.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbCaseStatus.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCaseStatus.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbCaseStatus.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbCaseStatus.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbCaseStatus.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCaseStatus.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbCaseStatus.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbCaseStatus.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbCaseStatus.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCaseStatus.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbCaseStatus.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbCaseStatus.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbCaseStatus.Properties.AutoHeight = CType(resources.GetObject("cbCaseStatus.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject6, "SerializableAppearanceObject6")
        SerializableAppearanceObject6.Options.UseFont = True
        Me.cbCaseStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCaseStatus.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbCaseStatus.Properties.Buttons1"), CType(resources.GetObject("cbCaseStatus.Properties.Buttons2"), Integer), CType(resources.GetObject("cbCaseStatus.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbCaseStatus.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbCaseStatus.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbCaseStatus.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbCaseStatus.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, resources.GetString("cbCaseStatus.Properties.Buttons8"), CType(resources.GetObject("cbCaseStatus.Properties.Buttons9"), Object), CType(resources.GetObject("cbCaseStatus.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbCaseStatus.Properties.Buttons11"), Boolean))})
        Me.cbCaseStatus.Properties.NullText = resources.GetString("cbCaseStatus.Properties.NullText")
        Me.cbCaseStatus.Properties.NullValuePrompt = resources.GetString("cbCaseStatus.Properties.NullValuePrompt")
        Me.cbCaseStatus.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbCaseStatus.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbCaseStatus.Tag = "{statuscontrol}{M}"
        '
        'lbOutBreak
        '
        resources.ApplyResources(Me.lbOutBreak, "lbOutBreak")
        Me.lbOutBreak.Name = "lbOutBreak"
        '
        'lbCaseID
        '
        resources.ApplyResources(Me.lbCaseID, "lbCaseID")
        Me.lbCaseID.Name = "lbCaseID"
        '
        'lbFieldAccessionID
        '
        resources.ApplyResources(Me.lbFieldAccessionID, "lbFieldAccessionID")
        Me.lbFieldAccessionID.Name = "lbFieldAccessionID"
        '
        'txtCaseID
        '
        resources.ApplyResources(Me.txtCaseID, "txtCaseID")
        Me.txtCaseID.Name = "txtCaseID"
        Me.txtCaseID.Properties.AccessibleDescription = resources.GetString("txtCaseID.Properties.AccessibleDescription")
        Me.txtCaseID.Properties.AccessibleName = resources.GetString("txtCaseID.Properties.AccessibleName")
        Me.txtCaseID.Properties.Appearance.GradientMode = CType(resources.GetObject("txtCaseID.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCaseID.Properties.Appearance.Image = CType(resources.GetObject("txtCaseID.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtCaseID.Properties.Appearance.Options.UseFont = True
        Me.txtCaseID.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtCaseID.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCaseID.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtCaseID.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtCaseID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCaseID.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtCaseID.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCaseID.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtCaseID.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtCaseID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtCaseID.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtCaseID.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCaseID.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtCaseID.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtCaseID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtCaseID.Properties.AutoHeight = CType(resources.GetObject("txtCaseID.Properties.AutoHeight"), Boolean)
        Me.txtCaseID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtCaseID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtCaseID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtCaseID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtCaseID.Properties.Mask.EditMask = resources.GetString("txtCaseID.Properties.Mask.EditMask")
        Me.txtCaseID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseID.Properties.Mask.MaskType = CType(resources.GetObject("txtCaseID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtCaseID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtCaseID.Properties.Mask.PlaceHolder"), Char)
        Me.txtCaseID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtCaseID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtCaseID.Properties.NullValuePrompt = resources.GetString("txtCaseID.Properties.NullValuePrompt")
        Me.txtCaseID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtCaseID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtCaseID.Tag = "{K}[en]"
        '
        'lbCaseClassification
        '
        resources.ApplyResources(Me.lbCaseClassification, "lbCaseClassification")
        Me.lbCaseClassification.Name = "lbCaseClassification"
        '
        'lkpCaseClassification
        '
        resources.ApplyResources(Me.lkpCaseClassification, "lkpCaseClassification")
        Me.lkpCaseClassification.Name = "lkpCaseClassification"
        Me.lkpCaseClassification.Properties.AccessibleDescription = resources.GetString("lkpCaseClassification.Properties.AccessibleDescription")
        Me.lkpCaseClassification.Properties.AccessibleName = resources.GetString("lkpCaseClassification.Properties.AccessibleName")
        Me.lkpCaseClassification.Properties.Appearance.GradientMode = CType(resources.GetObject("lkpCaseClassification.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.lkpCaseClassification.Properties.Appearance.Image = CType(resources.GetObject("lkpCaseClassification.Properties.Appearance.Image"), System.Drawing.Image)
        Me.lkpCaseClassification.Properties.Appearance.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("lkpCaseClassification.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.lkpCaseClassification.Properties.AppearanceDisabled.Image = CType(resources.GetObject("lkpCaseClassification.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.lkpCaseClassification.Properties.AppearanceDisabled.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("lkpCaseClassification.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.lkpCaseClassification.Properties.AppearanceDropDown.Image = CType(resources.GetObject("lkpCaseClassification.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.lkpCaseClassification.Properties.AppearanceDropDown.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("lkpCaseClassification.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.lkpCaseClassification.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("lkpCaseClassification.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.lkpCaseClassification.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("lkpCaseClassification.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.lkpCaseClassification.Properties.AppearanceFocused.Image = CType(resources.GetObject("lkpCaseClassification.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.lkpCaseClassification.Properties.AppearanceFocused.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("lkpCaseClassification.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.lkpCaseClassification.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("lkpCaseClassification.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.lkpCaseClassification.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AutoHeight = CType(resources.GetObject("lkpCaseClassification.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject7, "SerializableAppearanceObject7")
        SerializableAppearanceObject7.Options.UseFont = True
        Me.lkpCaseClassification.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lkpCaseClassification.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("lkpCaseClassification.Properties.Buttons1"), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons2"), Integer), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons3"), Boolean), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons4"), Boolean), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons5"), Boolean), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject7, resources.GetString("lkpCaseClassification.Properties.Buttons8"), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons9"), Object), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons11"), Boolean))})
        Me.lkpCaseClassification.Properties.NullText = resources.GetString("lkpCaseClassification.Properties.NullText")
        Me.lkpCaseClassification.Properties.NullValuePrompt = resources.GetString("lkpCaseClassification.Properties.NullValuePrompt")
        Me.lkpCaseClassification.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("lkpCaseClassification.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'txtFieldAccessionID
        '
        resources.ApplyResources(Me.txtFieldAccessionID, "txtFieldAccessionID")
        Me.txtFieldAccessionID.Name = "txtFieldAccessionID"
        Me.txtFieldAccessionID.Properties.AccessibleDescription = resources.GetString("txtFieldAccessionID.Properties.AccessibleDescription")
        Me.txtFieldAccessionID.Properties.AccessibleName = resources.GetString("txtFieldAccessionID.Properties.AccessibleName")
        Me.txtFieldAccessionID.Properties.Appearance.GradientMode = CType(resources.GetObject("txtFieldAccessionID.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFieldAccessionID.Properties.Appearance.Image = CType(resources.GetObject("txtFieldAccessionID.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtFieldAccessionID.Properties.Appearance.Options.UseFont = True
        Me.txtFieldAccessionID.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtFieldAccessionID.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFieldAccessionID.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtFieldAccessionID.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtFieldAccessionID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFieldAccessionID.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtFieldAccessionID.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFieldAccessionID.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtFieldAccessionID.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtFieldAccessionID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFieldAccessionID.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtFieldAccessionID.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtFieldAccessionID.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtFieldAccessionID.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtFieldAccessionID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtFieldAccessionID.Properties.AutoHeight = CType(resources.GetObject("txtFieldAccessionID.Properties.AutoHeight"), Boolean)
        Me.txtFieldAccessionID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtFieldAccessionID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtFieldAccessionID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtFieldAccessionID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtFieldAccessionID.Properties.Mask.EditMask = resources.GetString("txtFieldAccessionID.Properties.Mask.EditMask")
        Me.txtFieldAccessionID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtFieldAccessionID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtFieldAccessionID.Properties.Mask.MaskType = CType(resources.GetObject("txtFieldAccessionID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtFieldAccessionID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtFieldAccessionID.Properties.Mask.PlaceHolder"), Char)
        Me.txtFieldAccessionID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtFieldAccessionID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtFieldAccessionID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtFieldAccessionID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtFieldAccessionID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtFieldAccessionID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtFieldAccessionID.Properties.NullValuePrompt = resources.GetString("txtFieldAccessionID.Properties.NullValuePrompt")
        Me.txtFieldAccessionID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtFieldAccessionID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lbDiseaseName
        '
        resources.ApplyResources(Me.lbDiseaseName, "lbDiseaseName")
        Me.lbDiseaseName.Name = "lbDiseaseName"
        '
        'lbCaseStatus
        '
        resources.ApplyResources(Me.lbCaseStatus, "lbCaseStatus")
        Me.lbCaseStatus.Name = "lbCaseStatus"
        '
        'VetStatusPanel
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.GeneralGroup)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.HelpTopicID = "VetStatusPanel"
        Me.KeyFieldName = "idfCase"
        Me.Name = "VetStatusPanel"
        Me.ObjectName = "VetStatus"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "VetCase"
        CType(Me.txtDiseaseName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GeneralGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GeneralGroup.ResumeLayout(False)
        CType(Me.cbReportType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSessionID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOutbreakID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCaseStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkpCaseClassification.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFieldAccessionID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InitCustomMandatoryFields()
        MandatoryFieldHelper.SetCustomMandatoryField(cbCaseStatus, CustomMandatoryField.VetCase_CaseClassification)
    End Sub

    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindTextEdit(txtCaseID, baseDataSet, VetCase_DB.TableVetCase + ".strCaseID")
        Core.LookupBinder.BindTextEdit(txtFieldAccessionID, baseDataSet, VetCase_DB.TableVetCase + ".strFieldAccessionID")
        Core.LookupBinder.BindTextEdit(txtOutbreakID, baseDataSet, VetCase_DB.TableVetCase + ".strOutbreakID")
        Core.LookupBinder.BindTextEdit(txtSessionID, baseDataSet, VetCase_DB.TableVetCase + ".strMonitoringSessionID")
        Core.LookupBinder.BindBaseLookup(lkpCaseClassification, baseDataSet, VetCase_DB.TableVetCase + ".idfsCaseStatus", db.BaseReferenceType.rftCaseStatus, HACode.Avian Or HACode.Livestock, False)
        'Core.LookupBinder.SetInitialCaseClassificationFilter(lkpCaseClassification)
        Core.LookupBinder.BindBaseLookup(cbCaseStatus, baseDataSet, VetCase_DB.TableVetCase + ".idfsCaseProgressStatus", db.BaseReferenceType.rftCaseProgressStatus, False, False)
        Core.LookupBinder.BindBaseLookup(cbReportType, baseDataSet, VetCase_DB.TableVetCase + ".idfsCaseReportType", db.BaseReferenceType.rftCaseReportType, False, False)
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".idfsCaseProgressStatus", AddressOf CaseStatusChanged)
        If baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfsCaseProgressStatus").Equals(CLng(CaseStatus.Closed)) Then
            If Not ParentObject.[ReadOnly] Then
                IsStatusReadOnly = True
                ParentObject.[ReadOnly] = True
            End If
        End If
        If baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfsCaseType").Equals(CLng(CaseType.Avian)) Then
            txtSessionID.Visible = False
            lbSessionID.Visible = False
        End If
        SetReportTypeReadOnly()
    End Sub

    Private Sub SetReportTypeReadOnly()
        If Not Utils.IsEmpty(baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strMonitoringSessionID")) AndAlso Not Utils.IsEmpty(baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfsCaseReportType")) Then
            SetControlReadOnly(cbReportType, True, False)
        End If
    End Sub

    Private Sub CaseStatusChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If e.Value.Equals(CLng(CaseStatus.InProgress)) Then
            If ParentObject.[ReadOnly] Then
                IsStatusReadOnly = False
                ParentObject.[ReadOnly] = False
            End If
        End If
    End Sub

    Public Sub SetDisease(ByVal idfsDisease As Long, ByVal diseaseNames As String)
        txtDiseaseName.Text = diseaseNames
        txtDiseaseName.ToolTip = diseaseNames
        Dim row As DataRow = GetCurrentRow()
        If Not row Is Nothing Then
            If idfsDisease = -1 Then
                row("idfsShowDiagnosis") = DBNull.Value
            Else
                row("idfsShowDiagnosis") = idfsDisease
            End If
        End If
    End Sub


    Private Sub cbOutbreakID_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtOutbreakID.ButtonClick
        If (e Is Nothing) Then Return
        If (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) Then
            'Glyph (Search) Button Shows Outbreak Search

            Dim outbreakForm As New OutbreakListPanel
            Dim r As IObject = BaseFormManager.ShowForSelection(outbreakForm, FindForm, , 1024, 800)
            If Not r Is Nothing Then
                baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfOutbreak") = r.Key
                baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strOutbreakID") = r.GetValue("strOutbreakID")
                baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0).EndEdit()
            End If

        ElseIf (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then
            ''Ellipsis Button Creates New Outbreak

            Dim outbreakID As Object = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfOutbreak")
            If outbreakID Is DBNull.Value Then
                outbreakID = Nothing
                If Not model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(model.Enums.EIDSSPermissionObject.Outbreak)) Then
                    MessageForm.Show(BvMessages.Get("msgNoInsertPermission", "You have no rights to create this object"))
                    Return
                End If
            ElseIf Not model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(model.Enums.EIDSSPermissionObject.Outbreak)) Then
                MessageForm.Show(BvMessages.Get("msgNoSelectPermission", "You have no rights to view this form"))
                Return
            End If

            Dim dlgOutbreakDetail As OutbreakDetail = New OutbreakDetail
            Dim hTable As New Dictionary(Of String, Object)()
            hTable.Add("CanAddViewRemove", False)
            If (BaseFormManager.ShowModal(dlgOutbreakDetail, FindForm, outbreakID, Nothing, hTable) = True) _
                AndAlso (Not Utils.IsEmpty(dlgOutbreakDetail.GetKey("Outbreak", "strOutbreakID"))) Then
                baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfOutbreak") = dlgOutbreakDetail.GetKey()
                baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strOutbreakID") = dlgOutbreakDetail.GetKey("Outbreak", "strOutbreakID")
                'baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0).EndEdit()
            ElseIf Not outbreakID Is Nothing AndAlso (dlgOutbreakDetail.DbService.ID Is Nothing) Then
                'This is the case when Outbreak was deleted from outbreak detail form
                baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfOutbreak") = DBNull.Value
                baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strOutbreakID") = DBNull.Value
                'baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0).EndEdit()
            End If
        ElseIf (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) Then
            If Not baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfOutbreak") Is DBNull.Value Then
                If WinUtils.ConfirmMessage(EidssMessages.Get("msgRemoveCaseFromOutbreak", "Remove case from outbreak?"), EidssMessages.Get("msgRemoveConfirmation", "Remove confirnmation?")) Then
                    baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfOutbreak") = DBNull.Value
                    baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strOutbreakID") = DBNull.Value
                End If
            End If
            'baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0).EndEdit()
        End If
    End Sub

    Private Sub VetStatusPanel_OnAfterPost(ByVal sender As Object, ByVal e As EventArgs) Handles Me.OnAfterPost
        If baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfsCaseProgressStatus").Equals(CLng(CaseStatus.Closed)) Then
            If Not ParentObject.[ReadOnly] Then
                IsStatusReadOnly = True
                ParentObject.[ReadOnly] = True
            End If
        End If
    End Sub
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.[ReadOnly]
        End Get
        Set(ByVal value As Boolean)
            MyBase.[ReadOnly] = value
            If Not value Then
                SetReportTypeReadOnly()
            End If
            txtOutbreakID.EnableButtons(Not value)
        End Set
    End Property

    Private Sub txtSessionID_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtSessionID.ButtonClick
        If (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then


            Dim sessionID As Object = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfParentMonitoringSession")
            If sessionID Is DBNull.Value Then
                Return
            End If
            Dim sessionForm As AsSessionDetail = New AsSessionDetail
            BaseFormManager.ShowNormal(sessionForm, sessionID, Nothing, Nothing)
        End If
    End Sub

End Class
