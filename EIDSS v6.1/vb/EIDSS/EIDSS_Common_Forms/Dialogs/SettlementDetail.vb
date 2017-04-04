Imports bv.winclient.Core
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums

Public Class SettlementDetail
    Inherits BaseDetailForm

    Protected m_SettlementDbSetvice As Settlement_DB
    Protected ID As Object
    Protected m_CountryID As Object
    Protected m_RegionID As Object
    Friend WithEvents bMap As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUniqueCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblElevation As System.Windows.Forms.Label
    Friend WithEvents seElevation As DevExpress.XtraEditors.SpinEdit
    Protected m_RayonID As Object

    Public Sub New(ByVal settlementID As Object, Optional ByVal countryID As Object = Nothing, Optional ByVal regionID As Object = Nothing, Optional ByVal rayonID As Object = Nothing)
        Me.New()
        ID = settlementID
        m_CountryID = countryID
        m_RegionID = regionID
        m_RayonID = rayonID
    End Sub

    Public ReadOnly Property CountryID() As Object
        Get
            Return m_CountryID
        End Get
    End Property

    Public ReadOnly Property RegionID() As Object
        Get
            Return m_RegionID
        End Get
    End Property

    Public ReadOnly Property RayonID() As Object
        Get
            Return m_RayonID
        End Get
    End Property

#Region " Windows Form Designer generated code "



    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_SettlementDbSetvice = New Settlement_DB
        DbService = m_SettlementDbSetvice
        AuditObject = New AuditObject(EIDSSAuditObject.daoSettlement, AuditTable.gisBaseReference)
        Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.GisReference
        'lbNationalName.Text += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage).ToLower + ")"
        LookupTableNames = New String() {"Settlement"}

        If bv.model.Model.Core.ModelUserContext.CurrentLanguage = Localizer.lngEn Then
            lbNationalName.Visible = False
            txtSettlementNameNat.Visible = False
        End If

    End Sub

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbCountry As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbRegion As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbRayon As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblSettlementType As System.Windows.Forms.Label
    Friend WithEvents cbSettlementType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents seLongitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblLongitude As System.Windows.Forms.Label
    Friend WithEvents lblLatitude As System.Windows.Forms.Label
    Friend WithEvents seLatitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtSettlementNameDef As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSettlementNameNat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents grpSettlementName As System.Windows.Forms.GroupBox
    Friend WithEvents lnEnglishName As System.Windows.Forms.Label
    Friend WithEvents lbNationalName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettlementDetail))
        Me.lnEnglishName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSettlementNameDef = New DevExpress.XtraEditors.TextEdit()
        Me.cbCountry = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRegion = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRayon = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblSettlementType = New System.Windows.Forms.Label()
        Me.cbSettlementType = New DevExpress.XtraEditors.LookUpEdit()
        Me.seLongitude = New DevExpress.XtraEditors.SpinEdit()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.lblLatitude = New System.Windows.Forms.Label()
        Me.seLatitude = New DevExpress.XtraEditors.SpinEdit()
        Me.lbNationalName = New System.Windows.Forms.Label()
        Me.txtSettlementNameNat = New DevExpress.XtraEditors.TextEdit()
        Me.grpSettlementName = New System.Windows.Forms.GroupBox()
        Me.bMap = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUniqueCode = New DevExpress.XtraEditors.TextEdit()
        Me.lblElevation = New System.Windows.Forms.Label()
        Me.seElevation = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.txtSettlementNameDef.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSettlementType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seLongitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seLatitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSettlementNameNat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSettlementName.SuspendLayout()
        CType(Me.txtUniqueCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seElevation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(SettlementDetail), resources)
        'Form Is Localizable: True
        '
        'lnEnglishName
        '
        resources.ApplyResources(Me.lnEnglishName, "lnEnglishName")
        Me.lnEnglishName.Name = "lnEnglishName"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtSettlementNameDef
        '
        resources.ApplyResources(Me.txtSettlementNameDef, "txtSettlementNameDef")
        Me.txtSettlementNameDef.Name = "txtSettlementNameDef"
        Me.txtSettlementNameDef.Properties.AccessibleDescription = resources.GetString("txtSettlementNameDef.Properties.AccessibleDescription")
        Me.txtSettlementNameDef.Properties.AccessibleName = resources.GetString("txtSettlementNameDef.Properties.AccessibleName")
        Me.txtSettlementNameDef.Properties.AutoHeight = CType(resources.GetObject("txtSettlementNameDef.Properties.AutoHeight"), Boolean)
        Me.txtSettlementNameDef.Properties.Mask.AutoComplete = CType(resources.GetObject("txtSettlementNameDef.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtSettlementNameDef.Properties.Mask.BeepOnError = CType(resources.GetObject("txtSettlementNameDef.Properties.Mask.BeepOnError"), Boolean)
        Me.txtSettlementNameDef.Properties.Mask.EditMask = resources.GetString("txtSettlementNameDef.Properties.Mask.EditMask")
        Me.txtSettlementNameDef.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSettlementNameDef.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSettlementNameDef.Properties.Mask.MaskType = CType(resources.GetObject("txtSettlementNameDef.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtSettlementNameDef.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtSettlementNameDef.Properties.Mask.PlaceHolder"), Char)
        Me.txtSettlementNameDef.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSettlementNameDef.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSettlementNameDef.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSettlementNameDef.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSettlementNameDef.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtSettlementNameDef.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtSettlementNameDef.Properties.MaxLength = 255
        Me.txtSettlementNameDef.Properties.NullValuePrompt = resources.GetString("txtSettlementNameDef.Properties.NullValuePrompt")
        Me.txtSettlementNameDef.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtSettlementNameDef.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtSettlementNameDef.Tag = "{M}[en]"
        '
        'cbCountry
        '
        resources.ApplyResources(Me.cbCountry, "cbCountry")
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Properties.AccessibleDescription = resources.GetString("cbCountry.Properties.AccessibleDescription")
        Me.cbCountry.Properties.AccessibleName = resources.GetString("cbCountry.Properties.AccessibleName")
        Me.cbCountry.Properties.AutoHeight = CType(resources.GetObject("cbCountry.Properties.AutoHeight"), Boolean)
        Me.cbCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCountry.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbCountry.Properties.Columns"), resources.GetString("cbCountry.Properties.Columns1"))})
        Me.cbCountry.Properties.NullText = resources.GetString("cbCountry.Properties.NullText")
        Me.cbCountry.Properties.NullValuePrompt = resources.GetString("cbCountry.Properties.NullValuePrompt")
        Me.cbCountry.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbCountry.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbCountry.Tag = "{M}"
        '
        'cbRegion
        '
        resources.ApplyResources(Me.cbRegion, "cbRegion")
        Me.cbRegion.Name = "cbRegion"
        Me.cbRegion.Properties.AccessibleDescription = resources.GetString("cbRegion.Properties.AccessibleDescription")
        Me.cbRegion.Properties.AccessibleName = resources.GetString("cbRegion.Properties.AccessibleName")
        Me.cbRegion.Properties.AutoHeight = CType(resources.GetObject("cbRegion.Properties.AutoHeight"), Boolean)
        Me.cbRegion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRegion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRegion.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRegion.Properties.Columns"), resources.GetString("cbRegion.Properties.Columns1"))})
        Me.cbRegion.Properties.NullText = resources.GetString("cbRegion.Properties.NullText")
        Me.cbRegion.Properties.NullValuePrompt = resources.GetString("cbRegion.Properties.NullValuePrompt")
        Me.cbRegion.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbRegion.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbRegion.Tag = "{M}"
        '
        'cbRayon
        '
        resources.ApplyResources(Me.cbRayon, "cbRayon")
        Me.cbRayon.Name = "cbRayon"
        Me.cbRayon.Properties.AccessibleDescription = resources.GetString("cbRayon.Properties.AccessibleDescription")
        Me.cbRayon.Properties.AccessibleName = resources.GetString("cbRayon.Properties.AccessibleName")
        Me.cbRayon.Properties.AutoHeight = CType(resources.GetObject("cbRayon.Properties.AutoHeight"), Boolean)
        Me.cbRayon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRayon.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRayon.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRayon.Properties.Columns"), resources.GetString("cbRayon.Properties.Columns1"))})
        Me.cbRayon.Properties.NullText = resources.GetString("cbRayon.Properties.NullText")
        Me.cbRayon.Properties.NullValuePrompt = resources.GetString("cbRayon.Properties.NullValuePrompt")
        Me.cbRayon.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbRayon.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbRayon.Tag = "{M}"
        '
        'lblSettlementType
        '
        resources.ApplyResources(Me.lblSettlementType, "lblSettlementType")
        Me.lblSettlementType.Name = "lblSettlementType"
        '
        'cbSettlementType
        '
        resources.ApplyResources(Me.cbSettlementType, "cbSettlementType")
        Me.cbSettlementType.Name = "cbSettlementType"
        Me.cbSettlementType.Properties.AccessibleDescription = resources.GetString("cbSettlementType.Properties.AccessibleDescription")
        Me.cbSettlementType.Properties.AccessibleName = resources.GetString("cbSettlementType.Properties.AccessibleName")
        Me.cbSettlementType.Properties.AutoHeight = CType(resources.GetObject("cbSettlementType.Properties.AutoHeight"), Boolean)
        Me.cbSettlementType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSettlementType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSettlementType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSettlementType.Properties.Columns"), resources.GetString("cbSettlementType.Properties.Columns1"))})
        Me.cbSettlementType.Properties.NullText = resources.GetString("cbSettlementType.Properties.NullText")
        Me.cbSettlementType.Properties.NullValuePrompt = resources.GetString("cbSettlementType.Properties.NullValuePrompt")
        Me.cbSettlementType.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbSettlementType.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbSettlementType.Tag = "{M}"
        '
        'seLongitude
        '
        resources.ApplyResources(Me.seLongitude, "seLongitude")
        Me.seLongitude.Name = "seLongitude"
        Me.seLongitude.Properties.AccessibleDescription = resources.GetString("seLongitude.Properties.AccessibleDescription")
        Me.seLongitude.Properties.AccessibleName = resources.GetString("seLongitude.Properties.AccessibleName")
        Me.seLongitude.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.seLongitude.Properties.AutoHeight = CType(resources.GetObject("seLongitude.Properties.AutoHeight"), Boolean)
        Me.seLongitude.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seLongitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLongitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLongitude.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.seLongitude.Properties.Mask.AutoComplete = CType(resources.GetObject("seLongitude.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.seLongitude.Properties.Mask.BeepOnError = CType(resources.GetObject("seLongitude.Properties.Mask.BeepOnError"), Boolean)
        Me.seLongitude.Properties.Mask.EditMask = resources.GetString("seLongitude.Properties.Mask.EditMask")
        Me.seLongitude.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("seLongitude.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.seLongitude.Properties.Mask.MaskType = CType(resources.GetObject("seLongitude.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.seLongitude.Properties.Mask.PlaceHolder = CType(resources.GetObject("seLongitude.Properties.Mask.PlaceHolder"), Char)
        Me.seLongitude.Properties.Mask.SaveLiteral = CType(resources.GetObject("seLongitude.Properties.Mask.SaveLiteral"), Boolean)
        Me.seLongitude.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("seLongitude.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.seLongitude.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seLongitude.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seLongitude.Properties.MaxValue = New Decimal(New Integer() {180, 0, 0, 0})
        Me.seLongitude.Properties.MinValue = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.seLongitude.Properties.NullValuePrompt = resources.GetString("seLongitude.Properties.NullValuePrompt")
        Me.seLongitude.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("seLongitude.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.seLongitude.Tag = "{M}"
        '
        'lblLongitude
        '
        resources.ApplyResources(Me.lblLongitude, "lblLongitude")
        Me.lblLongitude.Name = "lblLongitude"
        '
        'lblLatitude
        '
        resources.ApplyResources(Me.lblLatitude, "lblLatitude")
        Me.lblLatitude.Name = "lblLatitude"
        '
        'seLatitude
        '
        resources.ApplyResources(Me.seLatitude, "seLatitude")
        Me.seLatitude.Name = "seLatitude"
        Me.seLatitude.Properties.AccessibleDescription = resources.GetString("seLatitude.Properties.AccessibleDescription")
        Me.seLatitude.Properties.AccessibleName = resources.GetString("seLatitude.Properties.AccessibleName")
        Me.seLatitude.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.seLatitude.Properties.AutoHeight = CType(resources.GetObject("seLatitude.Properties.AutoHeight"), Boolean)
        Me.seLatitude.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seLatitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLatitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLatitude.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.seLatitude.Properties.Mask.AutoComplete = CType(resources.GetObject("seLatitude.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.seLatitude.Properties.Mask.BeepOnError = CType(resources.GetObject("seLatitude.Properties.Mask.BeepOnError"), Boolean)
        Me.seLatitude.Properties.Mask.EditMask = resources.GetString("seLatitude.Properties.Mask.EditMask")
        Me.seLatitude.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("seLatitude.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.seLatitude.Properties.Mask.MaskType = CType(resources.GetObject("seLatitude.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.seLatitude.Properties.Mask.PlaceHolder = CType(resources.GetObject("seLatitude.Properties.Mask.PlaceHolder"), Char)
        Me.seLatitude.Properties.Mask.SaveLiteral = CType(resources.GetObject("seLatitude.Properties.Mask.SaveLiteral"), Boolean)
        Me.seLatitude.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("seLatitude.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.seLatitude.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seLatitude.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seLatitude.Properties.MaxValue = New Decimal(New Integer() {90, 0, 0, 0})
        Me.seLatitude.Properties.MinValue = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.seLatitude.Properties.NullValuePrompt = resources.GetString("seLatitude.Properties.NullValuePrompt")
        Me.seLatitude.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("seLatitude.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.seLatitude.Tag = "{M}"
        '
        'lbNationalName
        '
        resources.ApplyResources(Me.lbNationalName, "lbNationalName")
        Me.lbNationalName.Name = "lbNationalName"
        '
        'txtSettlementNameNat
        '
        resources.ApplyResources(Me.txtSettlementNameNat, "txtSettlementNameNat")
        Me.txtSettlementNameNat.Name = "txtSettlementNameNat"
        Me.txtSettlementNameNat.Properties.AccessibleDescription = resources.GetString("txtSettlementNameNat.Properties.AccessibleDescription")
        Me.txtSettlementNameNat.Properties.AccessibleName = resources.GetString("txtSettlementNameNat.Properties.AccessibleName")
        Me.txtSettlementNameNat.Properties.AutoHeight = CType(resources.GetObject("txtSettlementNameNat.Properties.AutoHeight"), Boolean)
        Me.txtSettlementNameNat.Properties.Mask.AutoComplete = CType(resources.GetObject("txtSettlementNameNat.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtSettlementNameNat.Properties.Mask.BeepOnError = CType(resources.GetObject("txtSettlementNameNat.Properties.Mask.BeepOnError"), Boolean)
        Me.txtSettlementNameNat.Properties.Mask.EditMask = resources.GetString("txtSettlementNameNat.Properties.Mask.EditMask")
        Me.txtSettlementNameNat.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSettlementNameNat.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSettlementNameNat.Properties.Mask.MaskType = CType(resources.GetObject("txtSettlementNameNat.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtSettlementNameNat.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtSettlementNameNat.Properties.Mask.PlaceHolder"), Char)
        Me.txtSettlementNameNat.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSettlementNameNat.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSettlementNameNat.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSettlementNameNat.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSettlementNameNat.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtSettlementNameNat.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtSettlementNameNat.Properties.MaxLength = 255
        Me.txtSettlementNameNat.Properties.NullValuePrompt = resources.GetString("txtSettlementNameNat.Properties.NullValuePrompt")
        Me.txtSettlementNameNat.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtSettlementNameNat.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'grpSettlementName
        '
        resources.ApplyResources(Me.grpSettlementName, "grpSettlementName")
        Me.grpSettlementName.Controls.Add(Me.txtSettlementNameDef)
        Me.grpSettlementName.Controls.Add(Me.txtSettlementNameNat)
        Me.grpSettlementName.Controls.Add(Me.lbNationalName)
        Me.grpSettlementName.Controls.Add(Me.lnEnglishName)
        Me.grpSettlementName.Name = "grpSettlementName"
        Me.grpSettlementName.TabStop = False
        '
        'bMap
        '
        resources.ApplyResources(Me.bMap, "bMap")
        Me.bMap.Name = "bMap"
        '
        'LabelControl1
        '
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'txtUniqueCode
        '
        resources.ApplyResources(Me.txtUniqueCode, "txtUniqueCode")
        Me.txtUniqueCode.Name = "txtUniqueCode"
        Me.txtUniqueCode.Properties.AccessibleDescription = resources.GetString("txtUniqueCode.Properties.AccessibleDescription")
        Me.txtUniqueCode.Properties.AccessibleName = resources.GetString("txtUniqueCode.Properties.AccessibleName")
        Me.txtUniqueCode.Properties.AutoHeight = CType(resources.GetObject("txtUniqueCode.Properties.AutoHeight"), Boolean)
        Me.txtUniqueCode.Properties.Mask.AutoComplete = CType(resources.GetObject("txtUniqueCode.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtUniqueCode.Properties.Mask.BeepOnError = CType(resources.GetObject("txtUniqueCode.Properties.Mask.BeepOnError"), Boolean)
        Me.txtUniqueCode.Properties.Mask.EditMask = resources.GetString("txtUniqueCode.Properties.Mask.EditMask")
        Me.txtUniqueCode.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtUniqueCode.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtUniqueCode.Properties.Mask.MaskType = CType(resources.GetObject("txtUniqueCode.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtUniqueCode.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtUniqueCode.Properties.Mask.PlaceHolder"), Char)
        Me.txtUniqueCode.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtUniqueCode.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtUniqueCode.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtUniqueCode.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtUniqueCode.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtUniqueCode.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtUniqueCode.Properties.NullValuePrompt = resources.GetString("txtUniqueCode.Properties.NullValuePrompt")
        Me.txtUniqueCode.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtUniqueCode.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lblElevation
        '
        resources.ApplyResources(Me.lblElevation, "lblElevation")
        Me.lblElevation.Name = "lblElevation"
        '
        'seElevation
        '
        resources.ApplyResources(Me.seElevation, "seElevation")
        Me.seElevation.Name = "seElevation"
        Me.seElevation.Properties.AccessibleDescription = resources.GetString("seElevation.Properties.AccessibleDescription")
        Me.seElevation.Properties.AccessibleName = resources.GetString("seElevation.Properties.AccessibleName")
        Me.seElevation.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.seElevation.Properties.AutoHeight = CType(resources.GetObject("seElevation.Properties.AutoHeight"), Boolean)
        Me.seElevation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seElevation.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seElevation.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seElevation.Properties.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.seElevation.Properties.Mask.AutoComplete = CType(resources.GetObject("seElevation.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.seElevation.Properties.Mask.BeepOnError = CType(resources.GetObject("seElevation.Properties.Mask.BeepOnError"), Boolean)
        Me.seElevation.Properties.Mask.EditMask = resources.GetString("seElevation.Properties.Mask.EditMask")
        Me.seElevation.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("seElevation.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.seElevation.Properties.Mask.MaskType = CType(resources.GetObject("seElevation.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.seElevation.Properties.Mask.PlaceHolder = CType(resources.GetObject("seElevation.Properties.Mask.PlaceHolder"), Char)
        Me.seElevation.Properties.Mask.SaveLiteral = CType(resources.GetObject("seElevation.Properties.Mask.SaveLiteral"), Boolean)
        Me.seElevation.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("seElevation.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.seElevation.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seElevation.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seElevation.Properties.MaxValue = New Decimal(New Integer() {11000, 0, 0, 0})
        Me.seElevation.Properties.MinValue = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.seElevation.Properties.NullValuePrompt = resources.GetString("seElevation.Properties.NullValuePrompt")
        Me.seElevation.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("seElevation.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.seElevation.Tag = ""
        '
        'SettlementDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.lblElevation)
        Me.Controls.Add(Me.seElevation)
        Me.Controls.Add(Me.txtUniqueCode)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.bMap)
        Me.Controls.Add(Me.cbCountry)
        Me.Controls.Add(Me.cbRegion)
        Me.Controls.Add(Me.cbRayon)
        Me.Controls.Add(Me.grpSettlementName)
        Me.Controls.Add(Me.cbSettlementType)
        Me.Controls.Add(Me.seLongitude)
        Me.Controls.Add(Me.lblLongitude)
        Me.Controls.Add(Me.lblLatitude)
        Me.Controls.Add(Me.seLatitude)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblSettlementType)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "C05"
        Me.HelpTopicID = "Settlements"
        Me.KeyFieldName = "idfsSettlement"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Settlement_131_2_
        Me.Name = "SettlementDetail"
        Me.ObjectName = "Settlement"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Settlement"
        Me.Controls.SetChildIndex(Me.lblSettlementType, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.seLatitude, 0)
        Me.Controls.SetChildIndex(Me.lblLatitude, 0)
        Me.Controls.SetChildIndex(Me.lblLongitude, 0)
        Me.Controls.SetChildIndex(Me.seLongitude, 0)
        Me.Controls.SetChildIndex(Me.cbSettlementType, 0)
        Me.Controls.SetChildIndex(Me.grpSettlementName, 0)
        Me.Controls.SetChildIndex(Me.cbRayon, 0)
        Me.Controls.SetChildIndex(Me.cbRegion, 0)
        Me.Controls.SetChildIndex(Me.cbCountry, 0)
        Me.Controls.SetChildIndex(Me.bMap, 0)
        Me.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.Controls.SetChildIndex(Me.txtUniqueCode, 0)
        Me.Controls.SetChildIndex(Me.seElevation, 0)
        Me.Controls.SetChildIndex(Me.lblElevation, 0)
        CType(Me.txtSettlementNameDef.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSettlementType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seLongitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seLatitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSettlementNameNat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSettlementName.ResumeLayout(False)
        CType(Me.txtUniqueCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seElevation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private ReadOnly Property CurrentRow() As DataRow
        Get
            Return baseDataSet.Tables("Settlement").Rows(0)
        End Get
    End Property
    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindStandardLookup(cbSettlementType, baseDataSet, "Settlement.idfsSettlementType", LookupTables.SettlementType, False)
        Core.LookupBinder.BindTextEdit(txtSettlementNameDef, baseDataSet, "Settlement.strEnglishName")
        Core.LookupBinder.BindTextEdit(txtSettlementNameNat, baseDataSet, "Settlement.strNationalName")
        Core.LookupBinder.BindTextEdit(txtUniqueCode, baseDataSet, "Settlement.strSettlementCode")

        seLatitude.DataBindings.Add("EditValue", baseDataSet, "Settlement.dblLatitude")
        seLongitude.DataBindings.Add("EditValue", baseDataSet, "Settlement.dblLongitude")
        seElevation.DataBindings.Add("EditValue", baseDataSet, "Settlement.intElevation")


        Dim thRayon As TagHelper = New TagHelper(cbRayon)
        thRayon.Tag = cbRegion
        Dim thRegion As TagHelper = New TagHelper(cbRegion)
        thRegion.Tag = cbCountry

        Core.LookupBinder.BindCountryLookup(cbCountry, baseDataSet, "Settlement.idfsCountry")
        If Not Utils.IsEmpty(m_CountryID) Then
            baseDataSet.Tables("Settlement").Rows(0)("idfsCountry") = m_CountryID
            'cbCountry.Enabled = False
        End If

        Core.LookupBinder.BindRegionLookup(cbRegion, baseDataSet, "Settlement.idfsRegion")
        Core.LookupBinder.FilterRegion(cbRegion, baseDataSet.Tables("Settlement").Rows(0)("idfsCountry"))
        If Not Utils.IsEmpty(m_RegionID) Then
            baseDataSet.Tables("Settlement").Rows(0)("idfsRegion") = m_RegionID
            'cbRegion.Enabled = False
        End If

        Core.LookupBinder.BindRayonLookup(cbRayon, baseDataSet, "Settlement.idfsRayon")
        Core.LookupBinder.FilterRayon(cbRayon, baseDataSet.Tables("Settlement").Rows(0)("idfsRegion"))
        If Not Utils.IsEmpty(m_RayonID) Then
            baseDataSet.Tables("Settlement").Rows(0)("idfsRayon") = m_RayonID
            'cbRayon.Enabled = False
        End If
        eventManager.AttachDataHandler("Settlement.idfsCountry", AddressOf Country_Changed)
        eventManager.AttachDataHandler("Settlement.idfsRegion", AddressOf Region_Changed)
        eventManager.AttachDataHandler("Settlement.idfsRayon", AddressOf Rayon_Changed)
        eventManager.AttachDataHandler("Settlement.strEnglishName", AddressOf EnglishName_Changed)

        'refresh coords of settlement from GIS
        RefreshSettlementCoords()
        bMap.Enabled = model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.GIS))


    End Sub

    Private Sub Country_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        m_CountryID = e.Value
        baseDataSet.Tables("Settlement").Rows(0)("idfsRegion") = DBNull.Value
        baseDataSet.Tables("Settlement").Rows(0).EndEdit()
        eventManager.Cascade("Settlement.idfsRegion")
        Core.LookupBinder.FilterRegion(cbRegion, e.Value)
    End Sub
    Private Sub Region_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        m_RegionID = e.Value
        baseDataSet.Tables("Settlement").Rows(0)("idfsRayon") = DBNull.Value
        baseDataSet.Tables("Settlement").Rows(0).EndEdit()
        eventManager.Cascade("Settlement.idfsRayon")
        Core.LookupBinder.FilterRayon(cbRayon, e.Value)
    End Sub
    Private Sub Rayon_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        m_RayonID = e.Value
    End Sub
    Private Sub EnglishName_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If bv.model.Model.Core.ModelUserContext.CurrentLanguage = Localizer.lngEn Then
            CurrentRow("strNationalName") = e.Value
            CurrentRow.EndEdit()
        End If
    End Sub

    Private Sub RefreshSettlementCoords()
        Dim idfsSettlement As Object = CurrentRow("idfsSettlement")
        If Not (Utils.IsEmpty(idfsSettlement)) Then
            Dim x As Double, y As Double, z As Integer
            If (gis.GisInterface.GetSettlementCoordinates(CType(idfsSettlement, Long), x, y, z)) Then
                CurrentRow("dblLongitude") = x
                CurrentRow("dblLatitude") = y
                CurrentRow("intElevation") = z
                'seLongitude.Text = x.ToString()
                'seLatitude.Text = y.ToString()
            End If
        End If
    End Sub


    Public Overrides Function ValidateData() As Boolean
        If (Not MyBase.ValidateData()) Then
            Return False
        End If
        Dim settlement As String = txtSettlementNameDef.EditValue.ToString
        Dim regEx As Text.RegularExpressions.Regex = New Text.RegularExpressions.Regex("[a-zA-Z-_ 0-9]+")
        If regEx.IsMatch(settlement) = False Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("msgEnglishCharsEnabled", "International name can include only latin letters."))
            Return False
        End If
        Dim res As Integer = Me.m_SettlementDbSetvice.FindDuplicate(GetCurrentRow())
        If res = 1 Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("msgEnSetlementExists", "The settlement with such English name exists already. Please enter other English settlement name"))
            Return False
        End If
        If res = 2 Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("msgNatSettlementExists", "The settlement with such national name exists already. Please enter other national settlement name"))
            Return False
        End If
        If res < 0 Then
            Dim err As ErrorMessage = m_SettlementDbSetvice.LastError
            If Not err Is Nothing Then
                ErrorForm.ShowErrorDirect(err.Text, err.Exception)
            Else
                ErrorForm.ShowWarningDirect(EidssMessages.Get("msgSettlementVaildationError", "The unknown error during settlement validation"))
            End If
            Return False
        End If

        Return True
    End Function

    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        If cbRayon.Properties.Buttons.Count >= 2 Then
            cbRayon.Properties.Buttons(1).Enabled = (Not Utils.IsEmpty(cbCountry.EditValue)) AndAlso _
                                                    (Not Utils.IsEmpty(cbRegion.EditValue))
            Me.txtSettlementNameNat.Enabled = bv.model.Model.Core.ModelUserContext.CurrentLanguage <> Localizer.lngEn
        End If
    End Sub

    ''' <summary>
    ''' Click to "Map..." button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Map_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMap.Click
        Dim x As Decimal, y As Decimal
        Dim idfsCountry As Long, idfsRegion As Long, idfsRayon As Long, idfsSettlement As Long
        If Not (CurrentRow("idfsCountry") Is DBNull.Value) Then idfsCountry = CType(CurrentRow("idfsCountry"), Long)
        If Not (CurrentRow("idfsRegion") Is DBNull.Value) Then idfsRegion = CType(CurrentRow("idfsRegion"), Long)
        If Not (CurrentRow("idfsRayon") Is DBNull.Value) Then idfsRayon = CType(CurrentRow("idfsRayon"), Long)
        If Not (CurrentRow("idfsSettlement") Is DBNull.Value) Then idfsSettlement = CType(CurrentRow("idfsSettlement"), Long)

        gis.GisInterface.SetCaseLocation(idfsCountry, idfsRegion, idfsRayon, idfsSettlement, x, y, AddressOf GetCoordinates)
    End Sub

    Private Sub GetCoordinates(ByVal X As Nullable(Of Double), ByVal Y As Nullable(Of Double))
        If (CurrentRow Is Nothing) Then Return
        CurrentRow.BeginEdit()
        If (X.HasValue) Then
            CurrentRow("dblLongitude") = CType(X, Decimal)
        Else
            CurrentRow("dblLongitude") = 0
        End If
        If (Y.HasValue) Then
            CurrentRow("dblLatitude") = CType(Y, Decimal)
        Else
            CurrentRow("dblLatitude") = 0
        End If
        CurrentRow.EndEdit()
    End Sub

    Private Sub SettlementDetail_OnAfterPost(ByVal sender As Object, ByVal e As EventArgs) Handles Me.OnAfterPost
        If m_SettlementDbSetvice.RefreshCache Then
            gis.Utils.TranslationCache.ClearCache()
        End If
    End Sub
End Class
