Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.Core
Imports DevExpress.XtraEditors.Controls
Imports eidss.model.Enums
Imports eidss.model.Resources
Imports DevExpress.Utils
Imports System.Drawing.Printing
Imports bv.winclient.Layout
Imports eidss.winclient.Lab
Imports System.Collections.Generic
Imports System.IO

<CLSCompliant(False)> _
Public Class PreferenciesForm
    Inherits BvForm


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Workaround of devexpress bug. Heigh if check boxes is reset to default value by some reason.
        chbShowBigLayoutWarning.Height = 28
        chbShowTextInToolbar.Height = 28

        chkDefaultRegionInSearch.Height = 28
        chkLabSimplifiedMode.Height = 28
        chkPrintMapInVetReports.Height = 28
        chkShowAsterisk.Height = 28
        chkShowEmptyListOnSearch.Height = 28
        chkShowNavigatorInH02Form.Height = 28
        chkShowSaveDataPrompt.Height = 28

        If (WinUtils.IsComponentInDesignMode(Me)) Then
            Return
        End If
        LayoutCorrector.ApplySystemFont(Me)
        HelpTopicId = "options"
        Init()
        RtlHelper.SetRTL(Me.GroupBox2)
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbLanguage As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbCountry As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbCountry As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbBarcodePrinter As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbDocumentPrinter As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents chkShowSaveDataPrompt As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkShowEmptyListOnSearch As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chbShowTextInToolbar As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkShowNavigatorInH02Form As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents FilterDaysLabel As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FilterDaysSpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents chbShowBigLayoutWarning As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLabSimplifiedMode As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEpiInfoPath As DevExpress.XtraEditors.ButtonEdit

    Friend WithEvents chkDefaultRegionInSearch As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintMapInVetReports As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cbDefaultMapProject As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbDefaultMapProject As System.Windows.Forms.Label
    Friend WithEvents chkShowWarningForFinalCaseClassification As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkFilterSamples As DevExpress.XtraEditors.CheckEdit

    Friend WithEvents chkShowAsterisk As DevExpress.XtraEditors.CheckEdit

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreferenciesForm))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbLanguage = New DevExpress.XtraEditors.LookUpEdit()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cbCountry = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbCountry = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbBarcodePrinter = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbDocumentPrinter = New DevExpress.XtraEditors.LookUpEdit()
        Me.chbShowTextInToolbar = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowEmptyListOnSearch = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowSaveDataPrompt = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkShowWarningForFinalCaseClassification = New DevExpress.XtraEditors.CheckEdit()
        Me.chkFilterSamples = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintMapInVetReports = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDefaultRegionInSearch = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLabSimplifiedMode = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowAsterisk = New DevExpress.XtraEditors.CheckEdit()
        Me.chbShowBigLayoutWarning = New DevExpress.XtraEditors.CheckEdit()
        Me.FilterDaysLabel = New DevExpress.XtraEditors.LabelControl()
        Me.FilterDaysSpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.chkShowNavigatorInH02Form = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbDefaultMapProject = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbDefaultMapProject = New System.Windows.Forms.Label()
        Me.txtEpiInfoPath = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.cbLanguage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbBarcodePrinter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDocumentPrinter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chbShowTextInToolbar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowEmptyListOnSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowSaveDataPrompt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.chkShowWarningForFinalCaseClassification.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFilterSamples.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintMapInVetReports.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDefaultRegionInSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLabSimplifiedMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowAsterisk.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chbShowBigLayoutWarning.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilterDaysSpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowNavigatorInH02Form.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cbDefaultMapProject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEpiInfoPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cbLanguage
        '
        resources.ApplyResources(Me.cbLanguage, "cbLanguage")
        Me.cbLanguage.Name = "cbLanguage"
        Me.cbLanguage.Properties.Appearance.Font = CType(resources.GetObject("cbLanguage.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.Appearance.Options.UseFont = True
        Me.cbLanguage.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbLanguage.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbLanguage.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbLanguage.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbLanguage.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbLanguage.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbLanguage.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbLanguage.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseFont = True
        Me.cbLanguage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLanguage.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbLanguage.Properties.Buttons1"), CType(resources.GetObject("cbLanguage.Properties.Buttons2"), Integer), CType(resources.GetObject("cbLanguage.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbLanguage.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbLanguage.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbLanguage.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbLanguage.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbLanguage.Properties.Buttons8"), CType(resources.GetObject("cbLanguage.Properties.Buttons9"), Object), CType(resources.GetObject("cbLanguage.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbLanguage.Properties.Buttons11"), Boolean))})
        Me.cbLanguage.Properties.NullText = resources.GetString("cbLanguage.Properties.NullText")
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'cbCountry
        '
        resources.ApplyResources(Me.cbCountry, "cbCountry")
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Properties.Appearance.Font = CType(resources.GetObject("cbCountry.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.Appearance.Options.UseFont = True
        Me.cbCountry.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbCountry.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbCountry.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbCountry.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbCountry.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbCountry.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbCountry.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbCountry.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject2.Options.UseFont = True
        Me.cbCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbCountry.Properties.Buttons1"), CType(resources.GetObject("cbCountry.Properties.Buttons2"), Integer), CType(resources.GetObject("cbCountry.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbCountry.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbCountry.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbCountry.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbCountry.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("cbCountry.Properties.Buttons8"), CType(resources.GetObject("cbCountry.Properties.Buttons9"), Object), CType(resources.GetObject("cbCountry.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbCountry.Properties.Buttons11"), Boolean))})
        Me.cbCountry.Properties.NullText = resources.GetString("cbCountry.Properties.NullText")
        '
        'lbCountry
        '
        resources.ApplyResources(Me.lbCountry, "lbCountry")
        Me.lbCountry.Name = "lbCountry"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'cbBarcodePrinter
        '
        resources.ApplyResources(Me.cbBarcodePrinter, "cbBarcodePrinter")
        Me.cbBarcodePrinter.Name = "cbBarcodePrinter"
        Me.cbBarcodePrinter.Properties.Appearance.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.Appearance.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject3.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbBarcodePrinter.Properties.Buttons1"), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons2"), Integer), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("cbBarcodePrinter.Properties.Buttons8"), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons9"), Object), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons11"), Boolean))})
        Me.cbBarcodePrinter.Properties.NullText = resources.GetString("cbBarcodePrinter.Properties.NullText")
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'cbDocumentPrinter
        '
        resources.ApplyResources(Me.cbDocumentPrinter, "cbDocumentPrinter")
        Me.cbDocumentPrinter.Name = "cbDocumentPrinter"
        Me.cbDocumentPrinter.Properties.Appearance.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.Appearance.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject4.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbDocumentPrinter.Properties.Buttons1"), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons2"), Integer), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, resources.GetString("cbDocumentPrinter.Properties.Buttons8"), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons9"), Object), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons11"), Boolean))})
        Me.cbDocumentPrinter.Properties.NullText = resources.GetString("cbDocumentPrinter.Properties.NullText")
        '
        'chbShowTextInToolbar
        '
        resources.ApplyResources(Me.chbShowTextInToolbar, "chbShowTextInToolbar")
        Me.chbShowTextInToolbar.Name = "chbShowTextInToolbar"
        Me.chbShowTextInToolbar.Properties.Appearance.Options.UseTextOptions = True
        Me.chbShowTextInToolbar.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.chbShowTextInToolbar.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowTextInToolbar.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chbShowTextInToolbar.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowTextInToolbar.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chbShowTextInToolbar.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowTextInToolbar.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chbShowTextInToolbar.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowTextInToolbar.Properties.AutoHeight = CType(resources.GetObject("chbShowTextInToolbar.Properties.AutoHeight"), Boolean)
        Me.chbShowTextInToolbar.Properties.Caption = resources.GetString("chbShowTextInToolbar.Properties.Caption")
        Me.chbShowTextInToolbar.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkShowEmptyListOnSearch
        '
        resources.ApplyResources(Me.chkShowEmptyListOnSearch, "chkShowEmptyListOnSearch")
        Me.chkShowEmptyListOnSearch.Name = "chkShowEmptyListOnSearch"
        Me.chkShowEmptyListOnSearch.Properties.Appearance.Options.UseTextOptions = True
        Me.chkShowEmptyListOnSearch.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowEmptyListOnSearch.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkShowEmptyListOnSearch.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowEmptyListOnSearch.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkShowEmptyListOnSearch.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowEmptyListOnSearch.Properties.AutoHeight = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AutoHeight"), Boolean)
        Me.chkShowEmptyListOnSearch.Properties.Caption = resources.GetString("chkShowEmptyListOnSearch.Properties.Caption")
        Me.chkShowEmptyListOnSearch.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkShowSaveDataPrompt
        '
        resources.ApplyResources(Me.chkShowSaveDataPrompt, "chkShowSaveDataPrompt")
        Me.chkShowSaveDataPrompt.Name = "chkShowSaveDataPrompt"
        Me.chkShowSaveDataPrompt.Properties.Appearance.Options.UseTextOptions = True
        Me.chkShowSaveDataPrompt.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.chkShowSaveDataPrompt.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowSaveDataPrompt.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkShowSaveDataPrompt.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowSaveDataPrompt.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkShowSaveDataPrompt.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowSaveDataPrompt.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkShowSaveDataPrompt.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowSaveDataPrompt.Properties.AutoHeight = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AutoHeight"), Boolean)
        Me.chkShowSaveDataPrompt.Properties.Caption = resources.GetString("chkShowSaveDataPrompt.Properties.Caption")
        Me.chkShowSaveDataPrompt.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.chkShowWarningForFinalCaseClassification)
        Me.GroupBox1.Controls.Add(Me.chkFilterSamples)
        Me.GroupBox1.Controls.Add(Me.chkPrintMapInVetReports)
        Me.GroupBox1.Controls.Add(Me.chkDefaultRegionInSearch)
        Me.GroupBox1.Controls.Add(Me.chkLabSimplifiedMode)
        Me.GroupBox1.Controls.Add(Me.chkShowAsterisk)
        Me.GroupBox1.Controls.Add(Me.chbShowBigLayoutWarning)
        Me.GroupBox1.Controls.Add(Me.FilterDaysLabel)
        Me.GroupBox1.Controls.Add(Me.FilterDaysSpinEdit)
        Me.GroupBox1.Controls.Add(Me.chkShowSaveDataPrompt)
        Me.GroupBox1.Controls.Add(Me.chbShowTextInToolbar)
        Me.GroupBox1.Controls.Add(Me.chkShowNavigatorInH02Form)
        Me.GroupBox1.Controls.Add(Me.chkShowEmptyListOnSearch)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'chkShowWarningForFinalCaseClassification
        '
        resources.ApplyResources(Me.chkShowWarningForFinalCaseClassification, "chkShowWarningForFinalCaseClassification")
        Me.chkShowWarningForFinalCaseClassification.Name = "chkShowWarningForFinalCaseClassification"
        Me.chkShowWarningForFinalCaseClassification.Properties.Appearance.Options.UseTextOptions = True
        Me.chkShowWarningForFinalCaseClassification.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.chkShowWarningForFinalCaseClassification.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowWarningForFinalCaseClassification.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkShowWarningForFinalCaseClassification.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowWarningForFinalCaseClassification.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkShowWarningForFinalCaseClassification.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowWarningForFinalCaseClassification.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkShowWarningForFinalCaseClassification.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowWarningForFinalCaseClassification.Properties.AutoHeight = CType(resources.GetObject("chkShowWarningForFinalCaseClassification.Properties.AutoHeight"), Boolean)
        Me.chkShowWarningForFinalCaseClassification.Properties.Caption = resources.GetString("chkShowWarningForFinalCaseClassification.Properties.Caption")
        Me.chkShowWarningForFinalCaseClassification.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkFilterSamples
        '
        resources.ApplyResources(Me.chkFilterSamples, "chkFilterSamples")
        Me.chkFilterSamples.Name = "chkFilterSamples"
        Me.chkFilterSamples.Properties.Appearance.Options.UseTextOptions = True
        Me.chkFilterSamples.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.chkFilterSamples.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkFilterSamples.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkFilterSamples.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkFilterSamples.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkFilterSamples.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkFilterSamples.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkFilterSamples.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkFilterSamples.Properties.AutoHeight = CType(resources.GetObject("chkFilterSamples.Properties.AutoHeight"), Boolean)
        Me.chkFilterSamples.Properties.Caption = resources.GetString("chkFilterSamples.Properties.Caption")
        Me.chkFilterSamples.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkPrintMapInVetReports
        '
        resources.ApplyResources(Me.chkPrintMapInVetReports, "chkPrintMapInVetReports")
        Me.chkPrintMapInVetReports.Name = "chkPrintMapInVetReports"
        Me.chkPrintMapInVetReports.Properties.Appearance.Options.UseTextOptions = True
        Me.chkPrintMapInVetReports.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.chkPrintMapInVetReports.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkPrintMapInVetReports.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkPrintMapInVetReports.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkPrintMapInVetReports.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkPrintMapInVetReports.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkPrintMapInVetReports.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkPrintMapInVetReports.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkPrintMapInVetReports.Properties.AutoHeight = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AutoHeight"), Boolean)
        Me.chkPrintMapInVetReports.Properties.Caption = resources.GetString("chkPrintMapInVetReports.Properties.Caption")
        Me.chkPrintMapInVetReports.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkDefaultRegionInSearch
        '
        resources.ApplyResources(Me.chkDefaultRegionInSearch, "chkDefaultRegionInSearch")
        Me.chkDefaultRegionInSearch.Name = "chkDefaultRegionInSearch"
        Me.chkDefaultRegionInSearch.Properties.Appearance.Options.UseTextOptions = True
        Me.chkDefaultRegionInSearch.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.chkDefaultRegionInSearch.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkDefaultRegionInSearch.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkDefaultRegionInSearch.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkDefaultRegionInSearch.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkDefaultRegionInSearch.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkDefaultRegionInSearch.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkDefaultRegionInSearch.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkDefaultRegionInSearch.Properties.AutoHeight = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AutoHeight"), Boolean)
        Me.chkDefaultRegionInSearch.Properties.Caption = resources.GetString("chkDefaultRegionInSearch.Properties.Caption")
        Me.chkDefaultRegionInSearch.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkLabSimplifiedMode
        '
        resources.ApplyResources(Me.chkLabSimplifiedMode, "chkLabSimplifiedMode")
        Me.chkLabSimplifiedMode.Name = "chkLabSimplifiedMode"
        Me.chkLabSimplifiedMode.Properties.Appearance.Options.UseTextOptions = True
        Me.chkLabSimplifiedMode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.chkLabSimplifiedMode.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkLabSimplifiedMode.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkLabSimplifiedMode.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkLabSimplifiedMode.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkLabSimplifiedMode.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkLabSimplifiedMode.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkLabSimplifiedMode.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkLabSimplifiedMode.Properties.AutoHeight = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AutoHeight"), Boolean)
        Me.chkLabSimplifiedMode.Properties.Caption = resources.GetString("chkLabSimplifiedMode.Properties.Caption")
        Me.chkLabSimplifiedMode.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkShowAsterisk
        '
        resources.ApplyResources(Me.chkShowAsterisk, "chkShowAsterisk")
        Me.chkShowAsterisk.Name = "chkShowAsterisk"
        Me.chkShowAsterisk.Properties.Appearance.Options.UseTextOptions = True
        Me.chkShowAsterisk.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.chkShowAsterisk.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowAsterisk.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkShowAsterisk.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowAsterisk.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkShowAsterisk.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowAsterisk.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkShowAsterisk.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowAsterisk.Properties.AutoHeight = CType(resources.GetObject("chkShowAsterisk.Properties.AutoHeight"), Boolean)
        Me.chkShowAsterisk.Properties.Caption = resources.GetString("chkShowAsterisk.Properties.Caption")
        Me.chkShowAsterisk.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chbShowBigLayoutWarning
        '
        resources.ApplyResources(Me.chbShowBigLayoutWarning, "chbShowBigLayoutWarning")
        Me.chbShowBigLayoutWarning.Name = "chbShowBigLayoutWarning"
        Me.chbShowBigLayoutWarning.Properties.Appearance.Options.UseTextOptions = True
        Me.chbShowBigLayoutWarning.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.chbShowBigLayoutWarning.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowBigLayoutWarning.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chbShowBigLayoutWarning.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowBigLayoutWarning.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chbShowBigLayoutWarning.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowBigLayoutWarning.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chbShowBigLayoutWarning.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowBigLayoutWarning.Properties.AutoHeight = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AutoHeight"), Boolean)
        Me.chbShowBigLayoutWarning.Properties.Caption = resources.GetString("chbShowBigLayoutWarning.Properties.Caption")
        Me.chbShowBigLayoutWarning.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'FilterDaysLabel
        '
        resources.ApplyResources(Me.FilterDaysLabel, "FilterDaysLabel")
        Me.FilterDaysLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.FilterDaysLabel.Name = "FilterDaysLabel"
        '
        'FilterDaysSpinEdit
        '
        resources.ApplyResources(Me.FilterDaysSpinEdit, "FilterDaysSpinEdit")
        Me.FilterDaysSpinEdit.Name = "FilterDaysSpinEdit"
        Me.FilterDaysSpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FilterDaysSpinEdit.Properties.IsFloatValue = False
        Me.FilterDaysSpinEdit.Properties.Mask.EditMask = resources.GetString("FilterDaysSpinEdit.Properties.Mask.EditMask")
        Me.FilterDaysSpinEdit.Properties.MaxValue = New Decimal(New Integer() {36500, 0, 0, 0})
        Me.FilterDaysSpinEdit.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkShowNavigatorInH02Form
        '
        resources.ApplyResources(Me.chkShowNavigatorInH02Form, "chkShowNavigatorInH02Form")
        Me.chkShowNavigatorInH02Form.Name = "chkShowNavigatorInH02Form"
        Me.chkShowNavigatorInH02Form.Properties.Appearance.Options.UseTextOptions = True
        Me.chkShowNavigatorInH02Form.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.chkShowNavigatorInH02Form.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowNavigatorInH02Form.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkShowNavigatorInH02Form.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowNavigatorInH02Form.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkShowNavigatorInH02Form.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowNavigatorInH02Form.Properties.AutoHeight = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AutoHeight"), Boolean)
        Me.chkShowNavigatorInH02Form.Properties.Caption = resources.GetString("chkShowNavigatorInH02Form.Properties.Caption")
        Me.chkShowNavigatorInH02Form.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.cbDefaultMapProject)
        Me.GroupBox2.Controls.Add(Me.lbDefaultMapProject)
        Me.GroupBox2.Controls.Add(Me.txtEpiInfoPath)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbLanguage)
        Me.GroupBox2.Controls.Add(Me.cbCountry)
        Me.GroupBox2.Controls.Add(Me.cbBarcodePrinter)
        Me.GroupBox2.Controls.Add(Me.cbDocumentPrinter)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lbCountry)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'cbDefaultMapProject
        '
        resources.ApplyResources(Me.cbDefaultMapProject, "cbDefaultMapProject")
        Me.cbDefaultMapProject.Name = "cbDefaultMapProject"
        Me.cbDefaultMapProject.Properties.Appearance.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.Appearance.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(SerializableAppearanceObject5, "SerializableAppearanceObject5")
        SerializableAppearanceObject5.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbDefaultMapProject.Properties.Buttons1"), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons2"), Integer), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, resources.GetString("cbDefaultMapProject.Properties.Buttons8"), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons9"), Object), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons11"), Boolean))})
        Me.cbDefaultMapProject.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbDefaultMapProject.Properties.Columns"), resources.GetString("cbDefaultMapProject.Properties.Columns1"))})
        Me.cbDefaultMapProject.Properties.NullText = resources.GetString("cbDefaultMapProject.Properties.NullText")
        '
        'lbDefaultMapProject
        '
        resources.ApplyResources(Me.lbDefaultMapProject, "lbDefaultMapProject")
        Me.lbDefaultMapProject.Name = "lbDefaultMapProject"
        '
        'txtEpiInfoPath
        '
        resources.ApplyResources(Me.txtEpiInfoPath, "txtEpiInfoPath")
        Me.txtEpiInfoPath.Name = "txtEpiInfoPath"
        Me.txtEpiInfoPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'PreferenciesForm
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpTopicId = "System_Preferences"
        Me.Name = "PreferenciesForm"
        CType(Me.cbLanguage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbBarcodePrinter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDocumentPrinter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chbShowTextInToolbar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowEmptyListOnSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowSaveDataPrompt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.chkShowWarningForFinalCaseClassification.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFilterSamples.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintMapInVetReports.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDefaultRegionInSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLabSimplifiedMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowAsterisk.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chbShowBigLayoutWarning.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilterDaysSpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowNavigatorInH02Form.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.cbDefaultMapProject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEpiInfoPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Main form interface"

    Public Shared Sub Register(ByVal parentControl As Control)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance,
                                              MenuActionManager.Instance.System, "MenuOptions", 905, False,
                                              MenuIconsSmall.Options, -1)
        ma.Name = "btnPreferencies"
        ma.BeginGroup = True
    End Sub

    Public Shared Sub ShowMe()
        Dim frm As PreferenciesForm = New PreferenciesForm
        BaseFormManager.ShowModal(frm, BaseFormManager.MainForm)
        If _
            frm.MainFromReloadNeeded AndAlso Not BaseFormManager.MainForm Is Nothing And
            TypeOf (BaseFormManager.MainForm) Is IMainForm Then
            CType(BaseFormManager.MainForm, IMainForm).RefreshLayout()
        End If
    End Sub

#End Region

    Class Language
        Dim m_ID As String

        Public Property ID() As String
            Get
                Return m_ID
            End Get
            Set(ByVal value As String)
                m_ID = value
            End Set
        End Property

        Dim m_Name As String

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Public Sub New(ByVal aID As String, ByVal aName As String)
            ID = aID
            Name = aName
        End Sub
    End Class

    ReadOnly m_LangArray As New ArrayList

    Sub FillLanguages()
        For Each k As String In bv.common.Core.Localizer.SupportedLanguages.Keys
            m_LangArray.Add(New Language(k, bv.common.Core.Localizer.GetMenuLanguageName(k)))
        Next
        cbLanguage.Properties.Columns.Clear()
        cbLanguage.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                          New LookUpColumnInfo("Name",
                                                                                               EidssMessages.Get(
                                                                                                   "LanguageName",
                                                                                                   "Language Name"), 100,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                               )
        cbLanguage.Properties.DataSource = m_LangArray
        cbLanguage.Properties.DisplayMember = "Name"
        cbLanguage.Properties.ValueMember = "ID"
        cbLanguage.Properties.PopupWidth = cbLanguage.Width
        cbLanguage.EditValue = BaseSettings.DefaultLanguage
    End Sub
    Private ReadOnly m_MapProjects As New List(Of KeyValuePair(Of String, String))

    Private Sub FillMapProjectsList()
        'Dim countryCode As String = EidssSiteContext.Instance.CountryHascCode.Substring(0, 2)
        Dim defaultMapPath As String = WinUtils.AppPath() + "\\MapProjects\\Default.map"
        Const defaultMapName As String = "Default"
        'EidssMessages.GetForCurrentLang("strDefault", "Default")
        Dim customMapFolder As String = Directory.GetParent(Application.CommonAppDataPath).FullName + "\\CustomMapProjects\\"

        m_MapProjects.Add(New KeyValuePair(Of String, String)(defaultMapPath, defaultMapName))

        Dim directoryInfo As DirectoryInfo = New DirectoryInfo(customMapFolder)

        For Each fileInfo As FileInfo In directoryInfo.GetFiles("*.map")
            If (fileInfo.FullName <> "") Then
                Dim customMapProject As String = gis.GisInterface.GetMapName(fileInfo.FullName)
                If customMapProject <> "" Then
                    m_MapProjects.Add(New KeyValuePair(Of String, String)(fileInfo.FullName, customMapProject))
                End If
            End If
        Next

        cbDefaultMapProject.Properties.DataSource = m_MapProjects
        cbDefaultMapProject.Properties.DisplayMember = "Value"
        cbDefaultMapProject.Properties.ValueMember = "Key"
        cbDefaultMapProject.Properties.PopupWidth = cbDefaultMapProject.Width

        Dim lastSavedPath As Object = IIf(Utils.IsEmpty(BaseSettings.DefaultMapProject), defaultMapPath, BaseSettings.DefaultMapProject)
        'Dim lastSavedMap As String = gis.GisInterface.GetMapName(CType(lastSavedPath, String))

        cbDefaultMapProject.EditValue = lastSavedPath
    End Sub
    Sub Init()
        FillLanguages()
        FillMapProjectsList()
        LookupBinder.BindCountryLookup(cbCountry, Nothing, "")
        cbCountry.EditValue = EidssSiteContext.Instance.CountryID

        LookupBinder.LoadInstalledPrinters()
        LookupBinder.BindPrintersLookup(cbBarcodePrinter, BaseSettings.BarcodePrinter)
        LookupBinder.BindPrintersLookup(cbDocumentPrinter, BaseSettings.DocumentPrinter)

        chbShowTextInToolbar.Checked = BaseSettings.ShowCaptionOnToolbar
        chkShowEmptyListOnSearch.Checked = BaseSettings.ShowEmptyListOnSearch
        chkShowAsterisk.Checked = BaseSettings.ShowAvrAsterisk

        chkFilterSamples.Checked = BaseSettings.FilterSamplesByDiagnosis
        chkShowWarningForFinalCaseClassification.Checked = BaseSettings.ShowWarningForFinalCaseClassification

        chkPrintMapInVetReports.Checked = BaseSettings.PrintMapInVetReports
        chkShowSaveDataPrompt.Checked = BaseSettings.ShowSaveDataPrompt
        chkShowNavigatorInH02Form.Checked = BaseSettings.ShowNavigatorInH02Form
        chbShowBigLayoutWarning.Checked = BaseSettings.ShowBigLayoutWarning
        chkLabSimplifiedMode.Checked = BaseSettings.LabSimplifiedMode
        chkDefaultRegionInSearch.Checked = BaseSettings.DefaultRegionInSearch
        FilterDaysSpinEdit.Value = BaseSettings.DefaultDateFilter
        txtEpiInfoPath.Text = BaseSettings.EpiInfoPath

    End Sub

    Private Sub cbLanguage_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbLanguage.EditValueChanged
    End Sub

    Private m_MainFromReloadNeeded As Boolean = False

    Public ReadOnly Property MainFromReloadNeeded() As Boolean
        Get
            Return m_MainFromReloadNeeded
        End Get
    End Property

    Private Sub cmdOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdOk.Click

        UserConfigWriter.Instance.SetItem("DefaultLanguage", cbLanguage.EditValue.ToString)
        If Not cbCountry.EditValue Is Nothing AndAlso Not cbCountry.EditValue Is DBNull.Value Then
            AppConfigWriter.Instance.SetItem("Country", cbCountry.EditValue.ToString())
        End If
        If Not Utils.IsEmpty(cbBarcodePrinter.EditValue) Then
            AppConfigWriter.Instance.SetItem("BarcodePrinter", cbBarcodePrinter.EditValue.ToString())
        End If
        If Not Utils.IsEmpty(cbDocumentPrinter.EditValue) Then
            AppConfigWriter.Instance.SetItem("DocumentPrinter", cbDocumentPrinter.EditValue.ToString())
        End If


        AppConfigWriter.Instance.SetItem("EpiInfoPath", txtEpiInfoPath.Text)

        AppConfigWriter.Instance.SetItem("DefaultMapProject", Utils.Str(cbDefaultMapProject.EditValue))
        AppConfigWriter.Instance.SetItem("FilterSamplesByDiagnosis", chkFilterSamples.Checked.ToString())
        AppConfigWriter.Instance.SetItem("ShowWarningForFinalCaseClassification", chkShowWarningForFinalCaseClassification.Checked.ToString())

        UserConfigWriter.Instance.SetItem("ShowCaptionOnToolbar", chbShowTextInToolbar.Checked.ToString())
        UserConfigWriter.Instance.SetItem("ShowEmptyListOnSearch", chkShowEmptyListOnSearch.Checked.ToString())
        UserConfigWriter.Instance.SetItem("ShowAvrAsterisk", chkShowAsterisk.Checked.ToString())

        UserConfigWriter.Instance.SetItem("PrintMapInVetReports", chkPrintMapInVetReports.Checked.ToString())

        UserConfigWriter.Instance.SetItem("ShowSaveDataPrompt", chkShowSaveDataPrompt.Checked.ToString())
        UserConfigWriter.Instance.SetItem("ShowNavigatorInH02Form", chkShowNavigatorInH02Form.Checked.ToString())
        UserConfigWriter.Instance.SetItem("ShowBigLayoutWarning", chbShowBigLayoutWarning.Checked.ToString())
        UserConfigWriter.Instance.SetItem("DefaultDateFilter", CType(FilterDaysSpinEdit.Value, Integer).ToString())

        UserConfigWriter.Instance.SetItem("LabSimplifiedMode", chkLabSimplifiedMode.Checked.ToString())
        UserConfigWriter.Instance.SetItem("DefaultRegionInSearch", chkDefaultRegionInSearch.Checked.ToString())


        If BaseSettings.ShowCaptionOnToolbar <> chbShowTextInToolbar.Checked OrElse _
            BaseSettings.LabSimplifiedMode <> chkLabSimplifiedMode.Checked Then
            If (BaseSettings.LabSimplifiedMode <> chkLabSimplifiedMode.Checked) AndAlso chkLabSimplifiedMode.Checked Then
                CloseForm(GetType(SampleListPanel))
                CloseForm(GetType(BatchListPanel))
                CloseForm(GetType(TestListPanel))
            End If
            m_MainFromReloadNeeded = True
        End If

        UserConfigWriter.Instance.Save()
        AppConfigWriter.Instance.Save()
        SecurityLog.WriteToEventLogDB(CLng(EidssUserContext.User.ID), SecurityAuditEvent.ProtecteDataUpdate, True,
                                      Nothing, "EIDSS configuration file was changed", Nothing,
                                      SecurityAuditProcessType.Eidss)
        Config.ReloadSettings()
    End Sub

    Private Sub CloseForm(formType As Type)
        Dim frm As IApplicationForm
        Do
            frm = BaseFormManager.FindFormByType(formType)
            If Not frm Is Nothing Then
                BaseFormManager.Close(frm)
            Else
                Exit Do
            End If
        Loop

    End Sub
    Private Sub txtSQLServer_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbCountry.EditValueChanged, cbDocumentPrinter.EditValueChanged, cbBarcodePrinter.EditValueChanged
    End Sub


    Private Sub txtEpiInfoPath_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtEpiInfoPath.ButtonClick
        Dim fileDialog As New OpenFileDialog()
        fileDialog.FileName = txtEpiInfoPath.Text
        If fileDialog.ShowDialog(FindForm()) = DialogResult.OK Then
            txtEpiInfoPath.Text = fileDialog.FileName
        End If
    End Sub
End Class
