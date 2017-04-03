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
        LoadData()
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
    Friend WithEvents chkShowSaveDataPrompt As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowEmptyListOnSearch As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chbShowTextInToolbar As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowNavigatorInH02Form As System.Windows.Forms.CheckBox
    Friend WithEvents FilterDaysLabel As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FilterDaysSpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents chbShowBigLayoutWarning As System.Windows.Forms.CheckBox
    Friend WithEvents chkLabSimplifiedMode As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEpiInfoPath As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents chkShowAsterisk As System.Windows.Forms.CheckBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreferenciesForm))
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
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
        Me.chbShowTextInToolbar = New System.Windows.Forms.CheckBox()
        Me.chkShowEmptyListOnSearch = New System.Windows.Forms.CheckBox()
        Me.chkShowSaveDataPrompt = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkLabSimplifiedMode = New System.Windows.Forms.CheckBox()
        Me.chkShowAsterisk = New System.Windows.Forms.CheckBox()
        Me.chbShowBigLayoutWarning = New System.Windows.Forms.CheckBox()
        Me.FilterDaysLabel = New DevExpress.XtraEditors.LabelControl()
        Me.FilterDaysSpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.chkShowNavigatorInH02Form = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEpiInfoPath = New DevExpress.XtraEditors.ButtonEdit()
        CType(Me.cbLanguage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbBarcodePrinter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDocumentPrinter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.FilterDaysSpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        resources.ApplyResources(SerializableAppearanceObject5, "SerializableAppearanceObject5")
        SerializableAppearanceObject5.Options.UseFont = True
        Me.cbLanguage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLanguage.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbLanguage.Properties.Buttons1"), CType(resources.GetObject("cbLanguage.Properties.Buttons2"), Integer), CType(resources.GetObject("cbLanguage.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbLanguage.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbLanguage.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbLanguage.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbLanguage.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, resources.GetString("cbLanguage.Properties.Buttons8"), CType(resources.GetObject("cbLanguage.Properties.Buttons9"), Object), CType(resources.GetObject("cbLanguage.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbLanguage.Properties.Buttons11"), Boolean))})
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
        resources.ApplyResources(SerializableAppearanceObject1, "SerializableAppearanceObject1")
        SerializableAppearanceObject1.Options.UseFont = True
        Me.cbCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbCountry.Properties.Buttons1"), CType(resources.GetObject("cbCountry.Properties.Buttons2"), Integer), CType(resources.GetObject("cbCountry.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbCountry.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbCountry.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbCountry.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbCountry.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbCountry.Properties.Buttons8"), CType(resources.GetObject("cbCountry.Properties.Buttons9"), Object), CType(resources.GetObject("cbCountry.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbCountry.Properties.Buttons11"), Boolean))})
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
        SerializableAppearanceObject2.Options.UseFont = True
        Me.cbBarcodePrinter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbBarcodePrinter.Properties.Buttons1"), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons2"), Integer), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("cbBarcodePrinter.Properties.Buttons8"), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons9"), Object), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbBarcodePrinter.Properties.Buttons11"), Boolean))})
        Me.cbBarcodePrinter.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbBarcodePrinter.Properties.Columns"), resources.GetString("cbBarcodePrinter.Properties.Columns1"))})
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
        SerializableAppearanceObject3.Options.UseFont = True
        Me.cbDocumentPrinter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbDocumentPrinter.Properties.Buttons1"), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons2"), Integer), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("cbDocumentPrinter.Properties.Buttons8"), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons9"), Object), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbDocumentPrinter.Properties.Buttons11"), Boolean))})
        Me.cbDocumentPrinter.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbDocumentPrinter.Properties.Columns"), resources.GetString("cbDocumentPrinter.Properties.Columns1"))})
        Me.cbDocumentPrinter.Properties.NullText = resources.GetString("cbDocumentPrinter.Properties.NullText")
        '
        'chbShowTextInToolbar
        '
        resources.ApplyResources(Me.chbShowTextInToolbar, "chbShowTextInToolbar")
        Me.chbShowTextInToolbar.Name = "chbShowTextInToolbar"
        '
        'chkShowEmptyListOnSearch
        '
        resources.ApplyResources(Me.chkShowEmptyListOnSearch, "chkShowEmptyListOnSearch")
        Me.chkShowEmptyListOnSearch.Name = "chkShowEmptyListOnSearch"
        '
        'chkShowSaveDataPrompt
        '
        resources.ApplyResources(Me.chkShowSaveDataPrompt, "chkShowSaveDataPrompt")
        Me.chkShowSaveDataPrompt.Name = "chkShowSaveDataPrompt"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkLabSimplifiedMode)
        Me.GroupBox1.Controls.Add(Me.chkShowAsterisk)
        Me.GroupBox1.Controls.Add(Me.chbShowBigLayoutWarning)
        Me.GroupBox1.Controls.Add(Me.FilterDaysLabel)
        Me.GroupBox1.Controls.Add(Me.FilterDaysSpinEdit)
        Me.GroupBox1.Controls.Add(Me.chkShowSaveDataPrompt)
        Me.GroupBox1.Controls.Add(Me.chbShowTextInToolbar)
        Me.GroupBox1.Controls.Add(Me.chkShowNavigatorInH02Form)
        Me.GroupBox1.Controls.Add(Me.chkShowEmptyListOnSearch)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'chkLabSimplifiedMode
        '
        resources.ApplyResources(Me.chkLabSimplifiedMode, "chkLabSimplifiedMode")
        Me.chkLabSimplifiedMode.Name = "chkLabSimplifiedMode"
        '
        'chkShowAsterisk
        '
        resources.ApplyResources(Me.chkShowAsterisk, "chkShowAsterisk")
        Me.chkShowAsterisk.Name = "chkShowAsterisk"
        '
        'chbShowBigLayoutWarning
        '
        resources.ApplyResources(Me.chbShowBigLayoutWarning, "chbShowBigLayoutWarning")
        Me.chbShowBigLayoutWarning.Name = "chbShowBigLayoutWarning"
        '
        'FilterDaysLabel
        '
        Me.FilterDaysLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.FilterDaysLabel, "FilterDaysLabel")
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
        '
        'GroupBox2
        '
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
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtEpiInfoPath
        '
        resources.ApplyResources(Me.txtEpiInfoPath, "txtEpiInfoPath")
        Me.txtEpiInfoPath.Name = "txtEpiInfoPath"
        Me.txtEpiInfoPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'PreferenciesForm
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "PreferenciesForm"
        CType(Me.cbLanguage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbBarcodePrinter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDocumentPrinter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.FilterDaysSpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
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
        frm.ShowDialog()
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

    Sub LoadData()
        FillLanguages()
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
        chkShowSaveDataPrompt.Checked = BaseSettings.ShowSaveDataPrompt
        chkShowNavigatorInH02Form.Checked = BaseSettings.ShowNavigatorInH02Form
        chbShowBigLayoutWarning.Checked = BaseSettings.ShowBigLayoutWarning
        chkLabSimplifiedMode.Checked = BaseSettings.LabSimplifiedMode
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

        UserConfigWriter.Instance.SetItem("ShowCaptionOnToolbar", chbShowTextInToolbar.Checked.ToString())
        UserConfigWriter.Instance.SetItem("ShowEmptyListOnSearch", chkShowEmptyListOnSearch.Checked.ToString())
        UserConfigWriter.Instance.SetItem("ShowAvrAsterisk", chkShowAsterisk.Checked.ToString())

        UserConfigWriter.Instance.SetItem("ShowSaveDataPrompt", chkShowSaveDataPrompt.Checked.ToString())
        UserConfigWriter.Instance.SetItem("ShowNavigatorInH02Form", chkShowNavigatorInH02Form.Checked.ToString())
        UserConfigWriter.Instance.SetItem("ShowBigLayoutWarning", chbShowBigLayoutWarning.Checked.ToString())
        UserConfigWriter.Instance.SetItem("DefaultDateFilter", CType(FilterDaysSpinEdit.Value, Integer).ToString())

        UserConfigWriter.Instance.SetItem("LabSimplifiedMode", chkLabSimplifiedMode.Checked.ToString())


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
