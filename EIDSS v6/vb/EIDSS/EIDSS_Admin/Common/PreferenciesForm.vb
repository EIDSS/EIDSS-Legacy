Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.Core
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports EIDSS.model.Enums
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

    Class PrinterName
        Dim m_Name As String

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property
    End Class

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'DxControlsHelper.InitFontItems(cbFont)
        'DxControlsHelper.InitFontItems(cbGeorgianFront)
        'LayoutHelper.InitFormLayout(Me)
        LayoutCorrector.ApplySystemFont(Me)
        HelpTopicId = "options"
        Init()
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
    Friend WithEvents chkUseAvrCache As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDefaultRegionInSearch As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintMapInVetReports As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cbDefaultMapProject As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbDefaultMapProject As System.Windows.Forms.Label
    Friend WithEvents chkShowAsterisk As DevExpress.XtraEditors.CheckEdit

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreferenciesForm))
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
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
        Me.chkPrintMapInVetReports = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDefaultRegionInSearch = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUseAvrCache = New DevExpress.XtraEditors.CheckEdit()
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
        CType(Me.chkPrintMapInVetReports.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDefaultRegionInSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseAvrCache.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cbLanguage.Properties.AccessibleDescription = resources.GetString("cbLanguage.Properties.AccessibleDescription")
        Me.cbLanguage.Properties.AccessibleName = resources.GetString("cbLanguage.Properties.AccessibleName")
        Me.cbLanguage.Properties.Appearance.Font = CType(resources.GetObject("cbLanguage.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("cbLanguage.Properties.Appearance.FontSizeDelta"), Integer)
        Me.cbLanguage.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("cbLanguage.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbLanguage.Properties.Appearance.GradientMode = CType(resources.GetObject("cbLanguage.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbLanguage.Properties.Appearance.Image = CType(resources.GetObject("cbLanguage.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbLanguage.Properties.Appearance.Options.UseFont = True
        Me.cbLanguage.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbLanguage.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("cbLanguage.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.cbLanguage.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("cbLanguage.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbLanguage.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbLanguage.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbLanguage.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbLanguage.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbLanguage.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbLanguage.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.AppearanceDropDown.FontSizeDelta = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDown.FontSizeDelta"), Integer)
        Me.cbLanguage.Properties.AppearanceDropDown.FontStyleDelta = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDown.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbLanguage.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbLanguage.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbLanguage.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbLanguage.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.AppearanceDropDownHeader.FontSizeDelta = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDownHeader.FontSizeDelta"), Integer)
        Me.cbLanguage.Properties.AppearanceDropDownHeader.FontStyleDelta = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDownHeader.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbLanguage.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbLanguage.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbLanguage.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbLanguage.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbLanguage.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbLanguage.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("cbLanguage.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.cbLanguage.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("cbLanguage.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbLanguage.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbLanguage.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbLanguage.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbLanguage.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbLanguage.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbLanguage.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbLanguage.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbLanguage.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("cbLanguage.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.cbLanguage.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("cbLanguage.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbLanguage.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbLanguage.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbLanguage.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbLanguage.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbLanguage.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbLanguage.Properties.AutoHeight = CType(resources.GetObject("cbLanguage.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject6, "SerializableAppearanceObject6")
        SerializableAppearanceObject6.Options.UseFont = True
        Me.cbLanguage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLanguage.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbLanguage.Properties.Buttons1"), CType(resources.GetObject("cbLanguage.Properties.Buttons2"), Integer), CType(resources.GetObject("cbLanguage.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbLanguage.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbLanguage.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbLanguage.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbLanguage.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, resources.GetString("cbLanguage.Properties.Buttons8"), CType(resources.GetObject("cbLanguage.Properties.Buttons9"), Object), CType(resources.GetObject("cbLanguage.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbLanguage.Properties.Buttons11"), Boolean))})
        Me.cbLanguage.Properties.NullText = resources.GetString("cbLanguage.Properties.NullText")
        Me.cbLanguage.Properties.NullValuePrompt = resources.GetString("cbLanguage.Properties.NullValuePrompt")
        Me.cbLanguage.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbLanguage.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.cbCountry.Properties.AccessibleDescription = resources.GetString("cbCountry.Properties.AccessibleDescription")
        Me.cbCountry.Properties.AccessibleName = resources.GetString("cbCountry.Properties.AccessibleName")
        Me.cbCountry.Properties.Appearance.Font = CType(resources.GetObject("cbCountry.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("cbCountry.Properties.Appearance.FontSizeDelta"), Integer)
        Me.cbCountry.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("cbCountry.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbCountry.Properties.Appearance.GradientMode = CType(resources.GetObject("cbCountry.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCountry.Properties.Appearance.Image = CType(resources.GetObject("cbCountry.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbCountry.Properties.Appearance.Options.UseFont = True
        Me.cbCountry.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbCountry.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("cbCountry.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.cbCountry.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("cbCountry.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbCountry.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbCountry.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCountry.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbCountry.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbCountry.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbCountry.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.AppearanceDropDown.FontSizeDelta = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDown.FontSizeDelta"), Integer)
        Me.cbCountry.Properties.AppearanceDropDown.FontStyleDelta = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDown.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbCountry.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCountry.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbCountry.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbCountry.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.AppearanceDropDownHeader.FontSizeDelta = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDownHeader.FontSizeDelta"), Integer)
        Me.cbCountry.Properties.AppearanceDropDownHeader.FontStyleDelta = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDownHeader.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbCountry.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCountry.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbCountry.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbCountry.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbCountry.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbCountry.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("cbCountry.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.cbCountry.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("cbCountry.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbCountry.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbCountry.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCountry.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbCountry.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbCountry.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbCountry.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbCountry.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbCountry.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("cbCountry.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.cbCountry.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("cbCountry.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbCountry.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbCountry.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbCountry.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbCountry.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbCountry.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbCountry.Properties.AutoHeight = CType(resources.GetObject("cbCountry.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject1, "SerializableAppearanceObject1")
        SerializableAppearanceObject1.Options.UseFont = True
        Me.cbCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbCountry.Properties.Buttons1"), CType(resources.GetObject("cbCountry.Properties.Buttons2"), Integer), CType(resources.GetObject("cbCountry.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbCountry.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbCountry.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbCountry.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbCountry.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbCountry.Properties.Buttons8"), CType(resources.GetObject("cbCountry.Properties.Buttons9"), Object), CType(resources.GetObject("cbCountry.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbCountry.Properties.Buttons11"), Boolean))})
        Me.cbCountry.Properties.NullText = resources.GetString("cbCountry.Properties.NullText")
        Me.cbCountry.Properties.NullValuePrompt = resources.GetString("cbCountry.Properties.NullValuePrompt")
        Me.cbCountry.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbCountry.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.cbBarcodePrinter.Properties.AccessibleDescription = resources.GetString("cbBarcodePrinter.Properties.AccessibleDescription")
        Me.cbBarcodePrinter.Properties.AccessibleName = resources.GetString("cbBarcodePrinter.Properties.AccessibleName")
        Me.cbBarcodePrinter.Properties.Appearance.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.Appearance.FontSizeDelta"), Integer)
        Me.cbBarcodePrinter.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbBarcodePrinter.Properties.Appearance.GradientMode = CType(resources.GetObject("cbBarcodePrinter.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbBarcodePrinter.Properties.Appearance.Image = CType(resources.GetObject("cbBarcodePrinter.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbBarcodePrinter.Properties.Appearance.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.cbBarcodePrinter.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbBarcodePrinter.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbBarcodePrinter.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbBarcodePrinter.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.AppearanceDropDown.FontSizeDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDown.FontSizeDelta"), Integer)
        Me.cbBarcodePrinter.Properties.AppearanceDropDown.FontStyleDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDown.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbBarcodePrinter.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbBarcodePrinter.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbBarcodePrinter.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.AppearanceDropDownHeader.FontSizeDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDownHeader.FontSizeDelta"), Integer)
        Me.cbBarcodePrinter.Properties.AppearanceDropDownHeader.FontStyleDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDownHeader.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbBarcodePrinter.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbBarcodePrinter.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbBarcodePrinter.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.cbBarcodePrinter.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbBarcodePrinter.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbBarcodePrinter.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbBarcodePrinter.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbBarcodePrinter.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.cbBarcodePrinter.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbBarcodePrinter.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbBarcodePrinter.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbBarcodePrinter.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbBarcodePrinter.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.AutoHeight = CType(resources.GetObject("cbBarcodePrinter.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject2, "SerializableAppearanceObject2")
        SerializableAppearanceObject2.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbBarcodePrinter.Properties.Buttons1"), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons2"), Integer), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("cbBarcodePrinter.Properties.Buttons8"), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons9"), Object), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons11"), Boolean))})
        Me.cbBarcodePrinter.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbBarcodePrinter.Properties.Columns"), resources.GetString("cbBarcodePrinter.Properties.Columns1"))})
        Me.cbBarcodePrinter.Properties.NullText = resources.GetString("cbBarcodePrinter.Properties.NullText")
        Me.cbBarcodePrinter.Properties.NullValuePrompt = resources.GetString("cbBarcodePrinter.Properties.NullValuePrompt")
        Me.cbBarcodePrinter.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbBarcodePrinter.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.cbDocumentPrinter.Properties.AccessibleDescription = resources.GetString("cbDocumentPrinter.Properties.AccessibleDescription")
        Me.cbDocumentPrinter.Properties.AccessibleName = resources.GetString("cbDocumentPrinter.Properties.AccessibleName")
        Me.cbDocumentPrinter.Properties.Appearance.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.Appearance.FontSizeDelta"), Integer)
        Me.cbDocumentPrinter.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDocumentPrinter.Properties.Appearance.GradientMode = CType(resources.GetObject("cbDocumentPrinter.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDocumentPrinter.Properties.Appearance.Image = CType(resources.GetObject("cbDocumentPrinter.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbDocumentPrinter.Properties.Appearance.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.cbDocumentPrinter.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDocumentPrinter.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDocumentPrinter.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbDocumentPrinter.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.AppearanceDropDown.FontSizeDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDown.FontSizeDelta"), Integer)
        Me.cbDocumentPrinter.Properties.AppearanceDropDown.FontStyleDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDown.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDocumentPrinter.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDocumentPrinter.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbDocumentPrinter.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.AppearanceDropDownHeader.FontSizeDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDownHeader.FontSizeDelta"), Integer)
        Me.cbDocumentPrinter.Properties.AppearanceDropDownHeader.FontStyleDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDownHeader.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDocumentPrinter.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDocumentPrinter.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbDocumentPrinter.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.cbDocumentPrinter.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDocumentPrinter.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDocumentPrinter.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbDocumentPrinter.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbDocumentPrinter.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.cbDocumentPrinter.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDocumentPrinter.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDocumentPrinter.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbDocumentPrinter.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbDocumentPrinter.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.AutoHeight = CType(resources.GetObject("cbDocumentPrinter.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject3, "SerializableAppearanceObject3")
        SerializableAppearanceObject3.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbDocumentPrinter.Properties.Buttons1"), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons2"), Integer), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("cbDocumentPrinter.Properties.Buttons8"), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons9"), Object), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons11"), Boolean))})
        Me.cbDocumentPrinter.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbDocumentPrinter.Properties.Columns"), resources.GetString("cbDocumentPrinter.Properties.Columns1"))})
        Me.cbDocumentPrinter.Properties.NullText = resources.GetString("cbDocumentPrinter.Properties.NullText")
        Me.cbDocumentPrinter.Properties.NullValuePrompt = resources.GetString("cbDocumentPrinter.Properties.NullValuePrompt")
        Me.cbDocumentPrinter.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbDocumentPrinter.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'chbShowTextInToolbar
        '
        resources.ApplyResources(Me.chbShowTextInToolbar, "chbShowTextInToolbar")
        Me.chbShowTextInToolbar.Name = "chbShowTextInToolbar"
        Me.chbShowTextInToolbar.Properties.AccessibleDescription = resources.GetString("chbShowTextInToolbar.Properties.AccessibleDescription")
        Me.chbShowTextInToolbar.Properties.AccessibleName = resources.GetString("chbShowTextInToolbar.Properties.AccessibleName")
        Me.chbShowTextInToolbar.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("chbShowTextInToolbar.Properties.Appearance.FontSizeDelta"), Integer)
        Me.chbShowTextInToolbar.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("chbShowTextInToolbar.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chbShowTextInToolbar.Properties.Appearance.GradientMode = CType(resources.GetObject("chbShowTextInToolbar.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chbShowTextInToolbar.Properties.Appearance.Image = CType(resources.GetObject("chbShowTextInToolbar.Properties.Appearance.Image"), System.Drawing.Image)
        Me.chbShowTextInToolbar.Properties.Appearance.Options.UseTextOptions = True
        Me.chbShowTextInToolbar.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowTextInToolbar.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.chbShowTextInToolbar.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chbShowTextInToolbar.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chbShowTextInToolbar.Properties.AppearanceDisabled.Image = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.chbShowTextInToolbar.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chbShowTextInToolbar.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowTextInToolbar.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.chbShowTextInToolbar.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chbShowTextInToolbar.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chbShowTextInToolbar.Properties.AppearanceFocused.Image = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.chbShowTextInToolbar.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chbShowTextInToolbar.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowTextInToolbar.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.chbShowTextInToolbar.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chbShowTextInToolbar.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chbShowTextInToolbar.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("chbShowTextInToolbar.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.chbShowTextInToolbar.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chbShowTextInToolbar.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowTextInToolbar.Properties.AutoHeight = CType(resources.GetObject("chbShowTextInToolbar.Properties.AutoHeight"), Boolean)
        Me.chbShowTextInToolbar.Properties.Caption = resources.GetString("chbShowTextInToolbar.Properties.Caption")
        Me.chbShowTextInToolbar.Properties.DisplayValueChecked = resources.GetString("chbShowTextInToolbar.Properties.DisplayValueChecked")
        Me.chbShowTextInToolbar.Properties.DisplayValueGrayed = resources.GetString("chbShowTextInToolbar.Properties.DisplayValueGrayed")
        Me.chbShowTextInToolbar.Properties.DisplayValueUnchecked = resources.GetString("chbShowTextInToolbar.Properties.DisplayValueUnchecked")
        Me.chbShowTextInToolbar.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkShowEmptyListOnSearch
        '
        resources.ApplyResources(Me.chkShowEmptyListOnSearch, "chkShowEmptyListOnSearch")
        Me.chkShowEmptyListOnSearch.Name = "chkShowEmptyListOnSearch"
        Me.chkShowEmptyListOnSearch.Properties.AccessibleDescription = resources.GetString("chkShowEmptyListOnSearch.Properties.AccessibleDescription")
        Me.chkShowEmptyListOnSearch.Properties.AccessibleName = resources.GetString("chkShowEmptyListOnSearch.Properties.AccessibleName")
        Me.chkShowEmptyListOnSearch.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.Appearance.FontSizeDelta"), Integer)
        Me.chkShowEmptyListOnSearch.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowEmptyListOnSearch.Properties.Appearance.GradientMode = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowEmptyListOnSearch.Properties.Appearance.Image = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.Appearance.Image"), System.Drawing.Image)
        Me.chkShowEmptyListOnSearch.Properties.Appearance.Options.UseTextOptions = True
        Me.chkShowEmptyListOnSearch.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowEmptyListOnSearch.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceDisabled.Image = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkShowEmptyListOnSearch.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowEmptyListOnSearch.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceFocused.Image = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkShowEmptyListOnSearch.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkShowEmptyListOnSearch.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowEmptyListOnSearch.Properties.AutoHeight = CType(resources.GetObject("chkShowEmptyListOnSearch.Properties.AutoHeight"), Boolean)
        Me.chkShowEmptyListOnSearch.Properties.Caption = resources.GetString("chkShowEmptyListOnSearch.Properties.Caption")
        Me.chkShowEmptyListOnSearch.Properties.DisplayValueChecked = resources.GetString("chkShowEmptyListOnSearch.Properties.DisplayValueChecked")
        Me.chkShowEmptyListOnSearch.Properties.DisplayValueGrayed = resources.GetString("chkShowEmptyListOnSearch.Properties.DisplayValueGrayed")
        Me.chkShowEmptyListOnSearch.Properties.DisplayValueUnchecked = resources.GetString("chkShowEmptyListOnSearch.Properties.DisplayValueUnchecked")
        Me.chkShowEmptyListOnSearch.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkShowSaveDataPrompt
        '
        resources.ApplyResources(Me.chkShowSaveDataPrompt, "chkShowSaveDataPrompt")
        Me.chkShowSaveDataPrompt.Name = "chkShowSaveDataPrompt"
        Me.chkShowSaveDataPrompt.Properties.AccessibleDescription = resources.GetString("chkShowSaveDataPrompt.Properties.AccessibleDescription")
        Me.chkShowSaveDataPrompt.Properties.AccessibleName = resources.GetString("chkShowSaveDataPrompt.Properties.AccessibleName")
        Me.chkShowSaveDataPrompt.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.Appearance.FontSizeDelta"), Integer)
        Me.chkShowSaveDataPrompt.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowSaveDataPrompt.Properties.Appearance.GradientMode = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowSaveDataPrompt.Properties.Appearance.Image = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.Appearance.Image"), System.Drawing.Image)
        Me.chkShowSaveDataPrompt.Properties.Appearance.Options.UseTextOptions = True
        Me.chkShowSaveDataPrompt.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowSaveDataPrompt.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.chkShowSaveDataPrompt.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowSaveDataPrompt.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowSaveDataPrompt.Properties.AppearanceDisabled.Image = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.chkShowSaveDataPrompt.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkShowSaveDataPrompt.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowSaveDataPrompt.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.chkShowSaveDataPrompt.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowSaveDataPrompt.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowSaveDataPrompt.Properties.AppearanceFocused.Image = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.chkShowSaveDataPrompt.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkShowSaveDataPrompt.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowSaveDataPrompt.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.chkShowSaveDataPrompt.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowSaveDataPrompt.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowSaveDataPrompt.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.chkShowSaveDataPrompt.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkShowSaveDataPrompt.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowSaveDataPrompt.Properties.AutoHeight = CType(resources.GetObject("chkShowSaveDataPrompt.Properties.AutoHeight"), Boolean)
        Me.chkShowSaveDataPrompt.Properties.Caption = resources.GetString("chkShowSaveDataPrompt.Properties.Caption")
        Me.chkShowSaveDataPrompt.Properties.DisplayValueChecked = resources.GetString("chkShowSaveDataPrompt.Properties.DisplayValueChecked")
        Me.chkShowSaveDataPrompt.Properties.DisplayValueGrayed = resources.GetString("chkShowSaveDataPrompt.Properties.DisplayValueGrayed")
        Me.chkShowSaveDataPrompt.Properties.DisplayValueUnchecked = resources.GetString("chkShowSaveDataPrompt.Properties.DisplayValueUnchecked")
        Me.chkShowSaveDataPrompt.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.chkPrintMapInVetReports)
        Me.GroupBox1.Controls.Add(Me.chkDefaultRegionInSearch)
        Me.GroupBox1.Controls.Add(Me.chkUseAvrCache)
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
        'chkPrintMapInVetReports
        '
        resources.ApplyResources(Me.chkPrintMapInVetReports, "chkPrintMapInVetReports")
        Me.chkPrintMapInVetReports.Name = "chkPrintMapInVetReports"
        Me.chkPrintMapInVetReports.Properties.AccessibleDescription = resources.GetString("chkPrintMapInVetReports.Properties.AccessibleDescription")
        Me.chkPrintMapInVetReports.Properties.AccessibleName = resources.GetString("chkPrintMapInVetReports.Properties.AccessibleName")
        Me.chkPrintMapInVetReports.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("chkPrintMapInVetReports.Properties.Appearance.FontSizeDelta"), Integer)
        Me.chkPrintMapInVetReports.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("chkPrintMapInVetReports.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkPrintMapInVetReports.Properties.Appearance.GradientMode = CType(resources.GetObject("chkPrintMapInVetReports.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkPrintMapInVetReports.Properties.Appearance.Image = CType(resources.GetObject("chkPrintMapInVetReports.Properties.Appearance.Image"), System.Drawing.Image)
        Me.chkPrintMapInVetReports.Properties.Appearance.Options.UseTextOptions = True
        Me.chkPrintMapInVetReports.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkPrintMapInVetReports.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.chkPrintMapInVetReports.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkPrintMapInVetReports.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkPrintMapInVetReports.Properties.AppearanceDisabled.Image = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.chkPrintMapInVetReports.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkPrintMapInVetReports.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkPrintMapInVetReports.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.chkPrintMapInVetReports.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkPrintMapInVetReports.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkPrintMapInVetReports.Properties.AppearanceFocused.Image = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.chkPrintMapInVetReports.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkPrintMapInVetReports.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkPrintMapInVetReports.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.chkPrintMapInVetReports.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkPrintMapInVetReports.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkPrintMapInVetReports.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.chkPrintMapInVetReports.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkPrintMapInVetReports.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkPrintMapInVetReports.Properties.AutoHeight = CType(resources.GetObject("chkPrintMapInVetReports.Properties.AutoHeight"), Boolean)
        Me.chkPrintMapInVetReports.Properties.Caption = resources.GetString("chkPrintMapInVetReports.Properties.Caption")
        Me.chkPrintMapInVetReports.Properties.DisplayValueChecked = resources.GetString("chkPrintMapInVetReports.Properties.DisplayValueChecked")
        Me.chkPrintMapInVetReports.Properties.DisplayValueGrayed = resources.GetString("chkPrintMapInVetReports.Properties.DisplayValueGrayed")
        Me.chkPrintMapInVetReports.Properties.DisplayValueUnchecked = resources.GetString("chkPrintMapInVetReports.Properties.DisplayValueUnchecked")
        Me.chkPrintMapInVetReports.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkDefaultRegionInSearch
        '
        resources.ApplyResources(Me.chkDefaultRegionInSearch, "chkDefaultRegionInSearch")
        Me.chkDefaultRegionInSearch.Name = "chkDefaultRegionInSearch"
        Me.chkDefaultRegionInSearch.Properties.AccessibleDescription = resources.GetString("chkDefaultRegionInSearch.Properties.AccessibleDescription")
        Me.chkDefaultRegionInSearch.Properties.AccessibleName = resources.GetString("chkDefaultRegionInSearch.Properties.AccessibleName")
        Me.chkDefaultRegionInSearch.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.Appearance.FontSizeDelta"), Integer)
        Me.chkDefaultRegionInSearch.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkDefaultRegionInSearch.Properties.Appearance.GradientMode = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkDefaultRegionInSearch.Properties.Appearance.Image = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.Appearance.Image"), System.Drawing.Image)
        Me.chkDefaultRegionInSearch.Properties.Appearance.Options.UseTextOptions = True
        Me.chkDefaultRegionInSearch.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkDefaultRegionInSearch.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.chkDefaultRegionInSearch.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkDefaultRegionInSearch.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkDefaultRegionInSearch.Properties.AppearanceDisabled.Image = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.chkDefaultRegionInSearch.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkDefaultRegionInSearch.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkDefaultRegionInSearch.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.chkDefaultRegionInSearch.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkDefaultRegionInSearch.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkDefaultRegionInSearch.Properties.AppearanceFocused.Image = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.chkDefaultRegionInSearch.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkDefaultRegionInSearch.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkDefaultRegionInSearch.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.chkDefaultRegionInSearch.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkDefaultRegionInSearch.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkDefaultRegionInSearch.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.chkDefaultRegionInSearch.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkDefaultRegionInSearch.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkDefaultRegionInSearch.Properties.AutoHeight = CType(resources.GetObject("chkDefaultRegionInSearch.Properties.AutoHeight"), Boolean)
        Me.chkDefaultRegionInSearch.Properties.Caption = resources.GetString("chkDefaultRegionInSearch.Properties.Caption")
        Me.chkDefaultRegionInSearch.Properties.DisplayValueChecked = resources.GetString("chkDefaultRegionInSearch.Properties.DisplayValueChecked")
        Me.chkDefaultRegionInSearch.Properties.DisplayValueGrayed = resources.GetString("chkDefaultRegionInSearch.Properties.DisplayValueGrayed")
        Me.chkDefaultRegionInSearch.Properties.DisplayValueUnchecked = resources.GetString("chkDefaultRegionInSearch.Properties.DisplayValueUnchecked")
        Me.chkDefaultRegionInSearch.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkUseAvrCache
        '
        resources.ApplyResources(Me.chkUseAvrCache, "chkUseAvrCache")
        Me.chkUseAvrCache.Name = "chkUseAvrCache"
        Me.chkUseAvrCache.Properties.AccessibleDescription = resources.GetString("chkUseAvrCache.Properties.AccessibleDescription")
        Me.chkUseAvrCache.Properties.AccessibleName = resources.GetString("chkUseAvrCache.Properties.AccessibleName")
        Me.chkUseAvrCache.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("chkUseAvrCache.Properties.Appearance.FontSizeDelta"), Integer)
        Me.chkUseAvrCache.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("chkUseAvrCache.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkUseAvrCache.Properties.Appearance.GradientMode = CType(resources.GetObject("chkUseAvrCache.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkUseAvrCache.Properties.Appearance.Image = CType(resources.GetObject("chkUseAvrCache.Properties.Appearance.Image"), System.Drawing.Image)
        Me.chkUseAvrCache.Properties.Appearance.Options.UseTextOptions = True
        Me.chkUseAvrCache.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkUseAvrCache.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.chkUseAvrCache.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkUseAvrCache.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkUseAvrCache.Properties.AppearanceDisabled.Image = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.chkUseAvrCache.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkUseAvrCache.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkUseAvrCache.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.chkUseAvrCache.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkUseAvrCache.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkUseAvrCache.Properties.AppearanceFocused.Image = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.chkUseAvrCache.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkUseAvrCache.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkUseAvrCache.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.chkUseAvrCache.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkUseAvrCache.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkUseAvrCache.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("chkUseAvrCache.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.chkUseAvrCache.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkUseAvrCache.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkUseAvrCache.Properties.AutoHeight = CType(resources.GetObject("chkUseAvrCache.Properties.AutoHeight"), Boolean)
        Me.chkUseAvrCache.Properties.Caption = resources.GetString("chkUseAvrCache.Properties.Caption")
        Me.chkUseAvrCache.Properties.DisplayValueChecked = resources.GetString("chkUseAvrCache.Properties.DisplayValueChecked")
        Me.chkUseAvrCache.Properties.DisplayValueGrayed = resources.GetString("chkUseAvrCache.Properties.DisplayValueGrayed")
        Me.chkUseAvrCache.Properties.DisplayValueUnchecked = resources.GetString("chkUseAvrCache.Properties.DisplayValueUnchecked")
        Me.chkUseAvrCache.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkLabSimplifiedMode
        '
        resources.ApplyResources(Me.chkLabSimplifiedMode, "chkLabSimplifiedMode")
        Me.chkLabSimplifiedMode.Name = "chkLabSimplifiedMode"
        Me.chkLabSimplifiedMode.Properties.AccessibleDescription = resources.GetString("chkLabSimplifiedMode.Properties.AccessibleDescription")
        Me.chkLabSimplifiedMode.Properties.AccessibleName = resources.GetString("chkLabSimplifiedMode.Properties.AccessibleName")
        Me.chkLabSimplifiedMode.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("chkLabSimplifiedMode.Properties.Appearance.FontSizeDelta"), Integer)
        Me.chkLabSimplifiedMode.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("chkLabSimplifiedMode.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkLabSimplifiedMode.Properties.Appearance.GradientMode = CType(resources.GetObject("chkLabSimplifiedMode.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkLabSimplifiedMode.Properties.Appearance.Image = CType(resources.GetObject("chkLabSimplifiedMode.Properties.Appearance.Image"), System.Drawing.Image)
        Me.chkLabSimplifiedMode.Properties.Appearance.Options.UseTextOptions = True
        Me.chkLabSimplifiedMode.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkLabSimplifiedMode.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.chkLabSimplifiedMode.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkLabSimplifiedMode.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkLabSimplifiedMode.Properties.AppearanceDisabled.Image = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.chkLabSimplifiedMode.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkLabSimplifiedMode.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkLabSimplifiedMode.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.chkLabSimplifiedMode.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkLabSimplifiedMode.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkLabSimplifiedMode.Properties.AppearanceFocused.Image = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.chkLabSimplifiedMode.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkLabSimplifiedMode.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkLabSimplifiedMode.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.chkLabSimplifiedMode.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkLabSimplifiedMode.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkLabSimplifiedMode.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.chkLabSimplifiedMode.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkLabSimplifiedMode.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkLabSimplifiedMode.Properties.AutoHeight = CType(resources.GetObject("chkLabSimplifiedMode.Properties.AutoHeight"), Boolean)
        Me.chkLabSimplifiedMode.Properties.Caption = resources.GetString("chkLabSimplifiedMode.Properties.Caption")
        Me.chkLabSimplifiedMode.Properties.DisplayValueChecked = resources.GetString("chkLabSimplifiedMode.Properties.DisplayValueChecked")
        Me.chkLabSimplifiedMode.Properties.DisplayValueGrayed = resources.GetString("chkLabSimplifiedMode.Properties.DisplayValueGrayed")
        Me.chkLabSimplifiedMode.Properties.DisplayValueUnchecked = resources.GetString("chkLabSimplifiedMode.Properties.DisplayValueUnchecked")
        Me.chkLabSimplifiedMode.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkShowAsterisk
        '
        resources.ApplyResources(Me.chkShowAsterisk, "chkShowAsterisk")
        Me.chkShowAsterisk.Name = "chkShowAsterisk"
        Me.chkShowAsterisk.Properties.AccessibleDescription = resources.GetString("chkShowAsterisk.Properties.AccessibleDescription")
        Me.chkShowAsterisk.Properties.AccessibleName = resources.GetString("chkShowAsterisk.Properties.AccessibleName")
        Me.chkShowAsterisk.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("chkShowAsterisk.Properties.Appearance.FontSizeDelta"), Integer)
        Me.chkShowAsterisk.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("chkShowAsterisk.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowAsterisk.Properties.Appearance.GradientMode = CType(resources.GetObject("chkShowAsterisk.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowAsterisk.Properties.Appearance.Image = CType(resources.GetObject("chkShowAsterisk.Properties.Appearance.Image"), System.Drawing.Image)
        Me.chkShowAsterisk.Properties.Appearance.Options.UseTextOptions = True
        Me.chkShowAsterisk.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowAsterisk.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.chkShowAsterisk.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowAsterisk.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowAsterisk.Properties.AppearanceDisabled.Image = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.chkShowAsterisk.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkShowAsterisk.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowAsterisk.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.chkShowAsterisk.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowAsterisk.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowAsterisk.Properties.AppearanceFocused.Image = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.chkShowAsterisk.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkShowAsterisk.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowAsterisk.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.chkShowAsterisk.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowAsterisk.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowAsterisk.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("chkShowAsterisk.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.chkShowAsterisk.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkShowAsterisk.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowAsterisk.Properties.AutoHeight = CType(resources.GetObject("chkShowAsterisk.Properties.AutoHeight"), Boolean)
        Me.chkShowAsterisk.Properties.Caption = resources.GetString("chkShowAsterisk.Properties.Caption")
        Me.chkShowAsterisk.Properties.DisplayValueChecked = resources.GetString("chkShowAsterisk.Properties.DisplayValueChecked")
        Me.chkShowAsterisk.Properties.DisplayValueGrayed = resources.GetString("chkShowAsterisk.Properties.DisplayValueGrayed")
        Me.chkShowAsterisk.Properties.DisplayValueUnchecked = resources.GetString("chkShowAsterisk.Properties.DisplayValueUnchecked")
        Me.chkShowAsterisk.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chbShowBigLayoutWarning
        '
        resources.ApplyResources(Me.chbShowBigLayoutWarning, "chbShowBigLayoutWarning")
        Me.chbShowBigLayoutWarning.Name = "chbShowBigLayoutWarning"
        Me.chbShowBigLayoutWarning.Properties.AccessibleDescription = resources.GetString("chbShowBigLayoutWarning.Properties.AccessibleDescription")
        Me.chbShowBigLayoutWarning.Properties.AccessibleName = resources.GetString("chbShowBigLayoutWarning.Properties.AccessibleName")
        Me.chbShowBigLayoutWarning.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.Appearance.FontSizeDelta"), Integer)
        Me.chbShowBigLayoutWarning.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chbShowBigLayoutWarning.Properties.Appearance.GradientMode = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chbShowBigLayoutWarning.Properties.Appearance.Image = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.Appearance.Image"), System.Drawing.Image)
        Me.chbShowBigLayoutWarning.Properties.Appearance.Options.UseTextOptions = True
        Me.chbShowBigLayoutWarning.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowBigLayoutWarning.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.chbShowBigLayoutWarning.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chbShowBigLayoutWarning.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chbShowBigLayoutWarning.Properties.AppearanceDisabled.Image = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.chbShowBigLayoutWarning.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chbShowBigLayoutWarning.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowBigLayoutWarning.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.chbShowBigLayoutWarning.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chbShowBigLayoutWarning.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chbShowBigLayoutWarning.Properties.AppearanceFocused.Image = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.chbShowBigLayoutWarning.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chbShowBigLayoutWarning.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowBigLayoutWarning.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.chbShowBigLayoutWarning.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chbShowBigLayoutWarning.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chbShowBigLayoutWarning.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.chbShowBigLayoutWarning.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chbShowBigLayoutWarning.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chbShowBigLayoutWarning.Properties.AutoHeight = CType(resources.GetObject("chbShowBigLayoutWarning.Properties.AutoHeight"), Boolean)
        Me.chbShowBigLayoutWarning.Properties.Caption = resources.GetString("chbShowBigLayoutWarning.Properties.Caption")
        Me.chbShowBigLayoutWarning.Properties.DisplayValueChecked = resources.GetString("chbShowBigLayoutWarning.Properties.DisplayValueChecked")
        Me.chbShowBigLayoutWarning.Properties.DisplayValueGrayed = resources.GetString("chbShowBigLayoutWarning.Properties.DisplayValueGrayed")
        Me.chbShowBigLayoutWarning.Properties.DisplayValueUnchecked = resources.GetString("chbShowBigLayoutWarning.Properties.DisplayValueUnchecked")
        Me.chbShowBigLayoutWarning.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'FilterDaysLabel
        '
        resources.ApplyResources(Me.FilterDaysLabel, "FilterDaysLabel")
        Me.FilterDaysLabel.Appearance.DisabledImage = CType(resources.GetObject("FilterDaysLabel.Appearance.DisabledImage"), System.Drawing.Image)
        Me.FilterDaysLabel.Appearance.FontSizeDelta = CType(resources.GetObject("FilterDaysLabel.Appearance.FontSizeDelta"), Integer)
        Me.FilterDaysLabel.Appearance.FontStyleDelta = CType(resources.GetObject("FilterDaysLabel.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.FilterDaysLabel.Appearance.GradientMode = CType(resources.GetObject("FilterDaysLabel.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.FilterDaysLabel.Appearance.HoverImage = CType(resources.GetObject("FilterDaysLabel.Appearance.HoverImage"), System.Drawing.Image)
        Me.FilterDaysLabel.Appearance.Image = CType(resources.GetObject("FilterDaysLabel.Appearance.Image"), System.Drawing.Image)
        Me.FilterDaysLabel.Appearance.PressedImage = CType(resources.GetObject("FilterDaysLabel.Appearance.PressedImage"), System.Drawing.Image)
        Me.FilterDaysLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.FilterDaysLabel.Name = "FilterDaysLabel"
        '
        'FilterDaysSpinEdit
        '
        resources.ApplyResources(Me.FilterDaysSpinEdit, "FilterDaysSpinEdit")
        Me.FilterDaysSpinEdit.Name = "FilterDaysSpinEdit"
        Me.FilterDaysSpinEdit.Properties.AccessibleDescription = resources.GetString("FilterDaysSpinEdit.Properties.AccessibleDescription")
        Me.FilterDaysSpinEdit.Properties.AccessibleName = resources.GetString("FilterDaysSpinEdit.Properties.AccessibleName")
        Me.FilterDaysSpinEdit.Properties.AutoHeight = CType(resources.GetObject("FilterDaysSpinEdit.Properties.AutoHeight"), Boolean)
        Me.FilterDaysSpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FilterDaysSpinEdit.Properties.IsFloatValue = False
        Me.FilterDaysSpinEdit.Properties.Mask.AutoComplete = CType(resources.GetObject("FilterDaysSpinEdit.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.FilterDaysSpinEdit.Properties.Mask.BeepOnError = CType(resources.GetObject("FilterDaysSpinEdit.Properties.Mask.BeepOnError"), Boolean)
        Me.FilterDaysSpinEdit.Properties.Mask.EditMask = resources.GetString("FilterDaysSpinEdit.Properties.Mask.EditMask")
        Me.FilterDaysSpinEdit.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("FilterDaysSpinEdit.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.FilterDaysSpinEdit.Properties.Mask.MaskType = CType(resources.GetObject("FilterDaysSpinEdit.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.FilterDaysSpinEdit.Properties.Mask.PlaceHolder = CType(resources.GetObject("FilterDaysSpinEdit.Properties.Mask.PlaceHolder"), Char)
        Me.FilterDaysSpinEdit.Properties.Mask.SaveLiteral = CType(resources.GetObject("FilterDaysSpinEdit.Properties.Mask.SaveLiteral"), Boolean)
        Me.FilterDaysSpinEdit.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("FilterDaysSpinEdit.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.FilterDaysSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("FilterDaysSpinEdit.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.FilterDaysSpinEdit.Properties.MaxValue = New Decimal(New Integer() {36500, 0, 0, 0})
        Me.FilterDaysSpinEdit.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.FilterDaysSpinEdit.Properties.NullValuePrompt = resources.GetString("FilterDaysSpinEdit.Properties.NullValuePrompt")
        Me.FilterDaysSpinEdit.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("FilterDaysSpinEdit.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'chkShowNavigatorInH02Form
        '
        resources.ApplyResources(Me.chkShowNavigatorInH02Form, "chkShowNavigatorInH02Form")
        Me.chkShowNavigatorInH02Form.Name = "chkShowNavigatorInH02Form"
        Me.chkShowNavigatorInH02Form.Properties.AccessibleDescription = resources.GetString("chkShowNavigatorInH02Form.Properties.AccessibleDescription")
        Me.chkShowNavigatorInH02Form.Properties.AccessibleName = resources.GetString("chkShowNavigatorInH02Form.Properties.AccessibleName")
        Me.chkShowNavigatorInH02Form.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.Appearance.FontSizeDelta"), Integer)
        Me.chkShowNavigatorInH02Form.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowNavigatorInH02Form.Properties.Appearance.GradientMode = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowNavigatorInH02Form.Properties.Appearance.Image = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.Appearance.Image"), System.Drawing.Image)
        Me.chkShowNavigatorInH02Form.Properties.Appearance.Options.UseTextOptions = True
        Me.chkShowNavigatorInH02Form.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowNavigatorInH02Form.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceDisabled.Image = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkShowNavigatorInH02Form.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowNavigatorInH02Form.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceFocused.Image = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkShowNavigatorInH02Form.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkShowNavigatorInH02Form.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkShowNavigatorInH02Form.Properties.AutoHeight = CType(resources.GetObject("chkShowNavigatorInH02Form.Properties.AutoHeight"), Boolean)
        Me.chkShowNavigatorInH02Form.Properties.Caption = resources.GetString("chkShowNavigatorInH02Form.Properties.Caption")
        Me.chkShowNavigatorInH02Form.Properties.DisplayValueChecked = resources.GetString("chkShowNavigatorInH02Form.Properties.DisplayValueChecked")
        Me.chkShowNavigatorInH02Form.Properties.DisplayValueGrayed = resources.GetString("chkShowNavigatorInH02Form.Properties.DisplayValueGrayed")
        Me.chkShowNavigatorInH02Form.Properties.DisplayValueUnchecked = resources.GetString("chkShowNavigatorInH02Form.Properties.DisplayValueUnchecked")
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
        Me.cbDefaultMapProject.Properties.AccessibleDescription = resources.GetString("cbDefaultMapProject.Properties.AccessibleDescription")
        Me.cbDefaultMapProject.Properties.AccessibleName = resources.GetString("cbDefaultMapProject.Properties.AccessibleName")
        Me.cbDefaultMapProject.Properties.Appearance.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.Appearance.FontSizeDelta"), Integer)
        Me.cbDefaultMapProject.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDefaultMapProject.Properties.Appearance.GradientMode = CType(resources.GetObject("cbDefaultMapProject.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDefaultMapProject.Properties.Appearance.Image = CType(resources.GetObject("cbDefaultMapProject.Properties.Appearance.Image"), System.Drawing.Image)
        Me.cbDefaultMapProject.Properties.Appearance.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.cbDefaultMapProject.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDefaultMapProject.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDefaultMapProject.Properties.AppearanceDisabled.Image = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.cbDefaultMapProject.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.AppearanceDropDown.FontSizeDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDown.FontSizeDelta"), Integer)
        Me.cbDefaultMapProject.Properties.AppearanceDropDown.FontStyleDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDown.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDefaultMapProject.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDefaultMapProject.Properties.AppearanceDropDown.Image = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.cbDefaultMapProject.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.AppearanceDropDownHeader.FontSizeDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDownHeader.FontSizeDelta"), Integer)
        Me.cbDefaultMapProject.Properties.AppearanceDropDownHeader.FontStyleDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDownHeader.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDefaultMapProject.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDefaultMapProject.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.cbDefaultMapProject.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.cbDefaultMapProject.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDefaultMapProject.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDefaultMapProject.Properties.AppearanceFocused.Image = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.cbDefaultMapProject.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbDefaultMapProject.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.cbDefaultMapProject.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.cbDefaultMapProject.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbDefaultMapProject.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("cbDefaultMapProject.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.cbDefaultMapProject.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.AutoHeight = CType(resources.GetObject("cbDefaultMapProject.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject4, "SerializableAppearanceObject4")
        SerializableAppearanceObject4.Options.UseFont = True
        Me.cbDefaultMapProject.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbDefaultMapProject.Properties.Buttons1"), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons2"), Integer), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, resources.GetString("cbDefaultMapProject.Properties.Buttons8"), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons9"), Object), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbDefaultMapProject.Properties.Buttons11"), Boolean))})
        Me.cbDefaultMapProject.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbDefaultMapProject.Properties.Columns"), resources.GetString("cbDefaultMapProject.Properties.Columns1"))})
        Me.cbDefaultMapProject.Properties.NullText = resources.GetString("cbDefaultMapProject.Properties.NullText")
        Me.cbDefaultMapProject.Properties.NullValuePrompt = resources.GetString("cbDefaultMapProject.Properties.NullValuePrompt")
        Me.cbDefaultMapProject.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbDefaultMapProject.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.txtEpiInfoPath.Properties.AccessibleDescription = resources.GetString("txtEpiInfoPath.Properties.AccessibleDescription")
        Me.txtEpiInfoPath.Properties.AccessibleName = resources.GetString("txtEpiInfoPath.Properties.AccessibleName")
        Me.txtEpiInfoPath.Properties.AutoHeight = CType(resources.GetObject("txtEpiInfoPath.Properties.AutoHeight"), Boolean)
        Me.txtEpiInfoPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtEpiInfoPath.Properties.Mask.AutoComplete = CType(resources.GetObject("txtEpiInfoPath.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtEpiInfoPath.Properties.Mask.BeepOnError = CType(resources.GetObject("txtEpiInfoPath.Properties.Mask.BeepOnError"), Boolean)
        Me.txtEpiInfoPath.Properties.Mask.EditMask = resources.GetString("txtEpiInfoPath.Properties.Mask.EditMask")
        Me.txtEpiInfoPath.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtEpiInfoPath.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtEpiInfoPath.Properties.Mask.MaskType = CType(resources.GetObject("txtEpiInfoPath.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtEpiInfoPath.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtEpiInfoPath.Properties.Mask.PlaceHolder"), Char)
        Me.txtEpiInfoPath.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtEpiInfoPath.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtEpiInfoPath.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtEpiInfoPath.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtEpiInfoPath.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtEpiInfoPath.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtEpiInfoPath.Properties.NullValuePrompt = resources.GetString("txtEpiInfoPath.Properties.NullValuePrompt")
        Me.txtEpiInfoPath.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtEpiInfoPath.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        CType(Me.chkPrintMapInVetReports.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDefaultRegionInSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseAvrCache.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
        For Each key As String In bv.common.Core.Localizer.SupportedLanguages.Keys
            m_LangArray.Add(New Language(key, bv.common.Core.Localizer.GetLanguageName(key)))
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
        Dim countryCode As String = EidssSiteContext.Instance.CountryHascCode.Substring(0, 2)
        Dim defaultMapPath As String = WinUtils.AppPath() + "\\MapProjects\\Default.map"
        Dim defaultMapName As String = "Default"
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

        Dim printers() As PrinterName = New PrinterName(0) {}
        Try
            printers = New PrinterName(PrinterSettings.InstalledPrinters.Count - 1) {}
            For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1
                printers(i) = New PrinterName
                printers(i).Name = PrinterSettings.InstalledPrinters(i)
            Next
        Catch ex As Exception
            Dbg.Debug(ex.ToString)
        End Try
        cbBarcodePrinter.Properties.DataSource = printers
        cbBarcodePrinter.Properties.DisplayMember = "Name"
        cbBarcodePrinter.Properties.ValueMember = "Name"
        cbBarcodePrinter.EditValue = BaseSettings.BarcodePrinter
        cbDocumentPrinter.Properties.DataSource = printers
        cbDocumentPrinter.Properties.DisplayMember = "Name"
        cbDocumentPrinter.Properties.ValueMember = "Name"
        cbDocumentPrinter.EditValue = BaseSettings.DocumentPrinter

        chbShowTextInToolbar.Checked = BaseSettings.ShowCaptionOnToolbar
        chkShowEmptyListOnSearch.Checked = BaseSettings.ShowEmptyListOnSearch
        chkShowAsterisk.Checked = BaseSettings.ShowAvrAsterisk
        chkUseAvrCache.Checked = BaseSettings.UseAvrCache
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

        UserConfigWriter.Instance.SetItem("ShowCaptionOnToolbar", chbShowTextInToolbar.Checked.ToString())
        UserConfigWriter.Instance.SetItem("ShowEmptyListOnSearch", chkShowEmptyListOnSearch.Checked.ToString())
        UserConfigWriter.Instance.SetItem("ShowAvrAsterisk", chkShowAsterisk.Checked.ToString())
        UserConfigWriter.Instance.SetItem("UseAvrCache", chkUseAvrCache.Checked.ToString())
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
