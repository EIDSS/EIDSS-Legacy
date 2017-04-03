Imports System.ComponentModel
Imports bv.winclient.Core
Imports EIDSS.model.Core
Imports EIDSS.Dialogs
Imports System.Collections.Generic
Imports bv.winclient.BasePanel
Imports bv.common.Enums

Public Class LocationLookup
    Inherits BaseLookupForm
    ReadOnly LocationDbService As Location_DB
    Friend WithEvents lbLocSettlement As System.Windows.Forms.Label
    Friend WithEvents cbLocSettlement As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents seRelLongitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents seRelLatitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lbRelLongitude As System.Windows.Forms.Label
    Friend WithEvents lbRelLatitude As System.Windows.Forms.Label
    Friend WithEvents pnForeignAddress As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents cbCountry As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbForeignAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As DevExpress.XtraEditors.MemoEdit

    Public m_ID As String = Nothing
#Region " Windows Form Designer generated code "


    Public Sub New()
        MyBase.New()
        Try

            'This call is required by the Windows Form Designer.
            InitializeComponent()
            'Add any initialization after the InitializeComponent() call
            If WinUtils.IsComponentInDesignMode(Me) Then
                Return
            End If
            LocationDbService = New Location_DB
            DbService = LocationDbService
            ForcedGeolocationType = GeoLocationType.Default
            Me.btnMAP.Enabled = True
        Catch ex As Exception
            bv.winclient.Core.MessageForm.Show(ex.ToString())
            If Not ex.InnerException Is Nothing Then
                bv.winclient.Core.MessageForm.Show(ex.InnerException.ToString())
            End If
        End Try
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
    Friend WithEvents RelativeLocationGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents lblRayon As System.Windows.Forms.Label
    Friend WithEvents lblSettlment As System.Windows.Forms.Label
    Friend WithEvents cbRegion As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbRayon As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbSettlement As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbLocationType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents seLongitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblLocDescription As System.Windows.Forms.Label
    Friend WithEvents lblLongitude As System.Windows.Forms.Label
    Friend WithEvents lblLatitude As System.Windows.Forms.Label
    Friend WithEvents txtLocDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents seLatitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblLocationType As System.Windows.Forms.Label
    Friend WithEvents seDistance As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblDistance As System.Windows.Forms.Label
    Friend WithEvents seDirection As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbGroundType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnMAP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnExactLocation As DevExpress.XtraEditors.GroupControl
    Friend WithEvents pnRelativeLocation As DevExpress.XtraEditors.GroupControl
    'Friend WithEvents pnAddress As bv.common.win.GroupPanel
    Friend WithEvents txtRelativeDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ExactLocationGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbLocRegion As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbLocRayon As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LocationLookup))
        Me.RelativeLocationGroupBox = New System.Windows.Forms.GroupBox()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.lblRayon = New System.Windows.Forms.Label()
        Me.lblSettlment = New System.Windows.Forms.Label()
        Me.cbRegion = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRayon = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbSettlement = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbLocationType = New DevExpress.XtraEditors.LookUpEdit()
        Me.seLongitude = New DevExpress.XtraEditors.SpinEdit()
        Me.lblLocDescription = New System.Windows.Forms.Label()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.lblLatitude = New System.Windows.Forms.Label()
        Me.txtLocDescription = New DevExpress.XtraEditors.TextEdit()
        Me.seLatitude = New DevExpress.XtraEditors.SpinEdit()
        Me.lblLocationType = New System.Windows.Forms.Label()
        Me.seDistance = New DevExpress.XtraEditors.SpinEdit()
        Me.lblDistance = New System.Windows.Forms.Label()
        Me.seDirection = New DevExpress.XtraEditors.SpinEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbGroundType = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnMAP = New DevExpress.XtraEditors.SimpleButton()
        Me.pnExactLocation = New DevExpress.XtraEditors.GroupControl()
        Me.ExactLocationGroupBox = New System.Windows.Forms.GroupBox()
        Me.lbLocSettlement = New System.Windows.Forms.Label()
        Me.cbLocSettlement = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbLocRegion = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbLocRayon = New DevExpress.XtraEditors.LookUpEdit()
        Me.pnRelativeLocation = New DevExpress.XtraEditors.GroupControl()
        Me.seRelLongitude = New DevExpress.XtraEditors.SpinEdit()
        Me.seRelLatitude = New DevExpress.XtraEditors.SpinEdit()
        Me.lbRelLongitude = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRelativeDescription = New DevExpress.XtraEditors.TextEdit()
        Me.lbRelLatitude = New System.Windows.Forms.Label()
        Me.pnForeignAddress = New DevExpress.XtraEditors.GroupControl()
        Me.txtAddress = New DevExpress.XtraEditors.MemoEdit()
        Me.lbForeignAddress = New System.Windows.Forms.Label()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.cbCountry = New DevExpress.XtraEditors.LookUpEdit()
        Me.RelativeLocationGroupBox.SuspendLayout()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSettlement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbLocationType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seLongitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seLatitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seDistance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seDirection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbGroundType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnExactLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnExactLocation.SuspendLayout()
        Me.ExactLocationGroupBox.SuspendLayout()
        CType(Me.cbLocSettlement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbLocRegion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbLocRayon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnRelativeLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnRelativeLocation.SuspendLayout()
        CType(Me.seRelLongitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seRelLatitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRelativeDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnForeignAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnForeignAddress.SuspendLayout()
        CType(Me.txtAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(LocationLookup), resources)
        'Form Is Localizable: True
        '
        'RelativeLocationGroupBox
        '
        resources.ApplyResources(Me.RelativeLocationGroupBox, "RelativeLocationGroupBox")
        Me.RelativeLocationGroupBox.Controls.Add(Me.lblRegion)
        Me.RelativeLocationGroupBox.Controls.Add(Me.lblRayon)
        Me.RelativeLocationGroupBox.Controls.Add(Me.lblSettlment)
        Me.RelativeLocationGroupBox.Controls.Add(Me.cbRegion)
        Me.RelativeLocationGroupBox.Controls.Add(Me.cbRayon)
        Me.RelativeLocationGroupBox.Controls.Add(Me.cbSettlement)
        Me.RelativeLocationGroupBox.Name = "RelativeLocationGroupBox"
        Me.RelativeLocationGroupBox.TabStop = False
        '
        'lblRegion
        '
        resources.ApplyResources(Me.lblRegion, "lblRegion")
        Me.lblRegion.Name = "lblRegion"
        '
        'lblRayon
        '
        resources.ApplyResources(Me.lblRayon, "lblRayon")
        Me.lblRayon.Name = "lblRayon"
        '
        'lblSettlment
        '
        resources.ApplyResources(Me.lblSettlment, "lblSettlment")
        Me.lblSettlment.Name = "lblSettlment"
        '
        'cbRegion
        '
        resources.ApplyResources(Me.cbRegion, "cbRegion")
        Me.cbRegion.Name = "cbRegion"
        Me.cbRegion.Properties.AccessibleDescription = resources.GetString("cbRegion.Properties.AccessibleDescription")
        Me.cbRegion.Properties.AccessibleName = resources.GetString("cbRegion.Properties.AccessibleName")
        Me.cbRegion.Properties.AutoHeight = CType(resources.GetObject("cbRegion.Properties.AutoHeight"), Boolean)
        Me.cbRegion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRegion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRegion.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRegion.Properties.Columns"), resources.GetString("cbRegion.Properties.Columns1"), CType(resources.GetObject("cbRegion.Properties.Columns2"), Integer), CType(resources.GetObject("cbRegion.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbRegion.Properties.Columns4"), CType(resources.GetObject("cbRegion.Properties.Columns5"), Boolean), CType(resources.GetObject("cbRegion.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
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
        Me.cbRayon.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRayon.Properties.Columns"), resources.GetString("cbRayon.Properties.Columns1"), CType(resources.GetObject("cbRayon.Properties.Columns2"), Integer), CType(resources.GetObject("cbRayon.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbRayon.Properties.Columns4"), CType(resources.GetObject("cbRayon.Properties.Columns5"), Boolean), CType(resources.GetObject("cbRayon.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbRayon.Properties.NullText = resources.GetString("cbRayon.Properties.NullText")
        Me.cbRayon.Properties.NullValuePrompt = resources.GetString("cbRayon.Properties.NullValuePrompt")
        Me.cbRayon.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbRayon.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbRayon.Tag = "{M}"
        '
        'cbSettlement
        '
        resources.ApplyResources(Me.cbSettlement, "cbSettlement")
        Me.cbSettlement.Name = "cbSettlement"
        Me.cbSettlement.Properties.AccessibleDescription = resources.GetString("cbSettlement.Properties.AccessibleDescription")
        Me.cbSettlement.Properties.AccessibleName = resources.GetString("cbSettlement.Properties.AccessibleName")
        Me.cbSettlement.Properties.AutoHeight = CType(resources.GetObject("cbSettlement.Properties.AutoHeight"), Boolean)
        Me.cbSettlement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSettlement.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSettlement.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSettlement.Properties.Columns"), resources.GetString("cbSettlement.Properties.Columns1"), CType(resources.GetObject("cbSettlement.Properties.Columns2"), Integer), CType(resources.GetObject("cbSettlement.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbSettlement.Properties.Columns4"), CType(resources.GetObject("cbSettlement.Properties.Columns5"), Boolean), CType(resources.GetObject("cbSettlement.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbSettlement.Properties.NullText = resources.GetString("cbSettlement.Properties.NullText")
        Me.cbSettlement.Properties.NullValuePrompt = resources.GetString("cbSettlement.Properties.NullValuePrompt")
        Me.cbSettlement.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbSettlement.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbSettlement.Tag = "{M}"
        '
        'cbLocationType
        '
        resources.ApplyResources(Me.cbLocationType, "cbLocationType")
        Me.cbLocationType.Name = "cbLocationType"
        Me.cbLocationType.Properties.AccessibleDescription = resources.GetString("cbLocationType.Properties.AccessibleDescription")
        Me.cbLocationType.Properties.AccessibleName = resources.GetString("cbLocationType.Properties.AccessibleName")
        Me.cbLocationType.Properties.AutoHeight = CType(resources.GetObject("cbLocationType.Properties.AutoHeight"), Boolean)
        Me.cbLocationType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLocationType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbLocationType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbLocationType.Properties.Columns"), resources.GetString("cbLocationType.Properties.Columns1"))})
        Me.cbLocationType.Properties.NullText = resources.GetString("cbLocationType.Properties.NullText")
        Me.cbLocationType.Properties.NullValuePrompt = resources.GetString("cbLocationType.Properties.NullValuePrompt")
        Me.cbLocationType.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbLocationType.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbLocationType.Tag = "{M}"
        '
        'seLongitude
        '
        resources.ApplyResources(Me.seLongitude, "seLongitude")
        Me.seLongitude.Name = "seLongitude"
        Me.seLongitude.Properties.AccessibleDescription = resources.GetString("seLongitude.Properties.AccessibleDescription")
        Me.seLongitude.Properties.AccessibleName = resources.GetString("seLongitude.Properties.AccessibleName")
        Me.seLongitude.Properties.AutoHeight = CType(resources.GetObject("seLongitude.Properties.AutoHeight"), Boolean)
        Me.seLongitude.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seLongitude.Properties.DisplayFormat.FormatString = "f5"
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
        Me.seLongitude.Properties.ValidateOnEnterKey = True
        '
        'lblLocDescription
        '
        resources.ApplyResources(Me.lblLocDescription, "lblLocDescription")
        Me.lblLocDescription.Name = "lblLocDescription"
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
        'txtLocDescription
        '
        resources.ApplyResources(Me.txtLocDescription, "txtLocDescription")
        Me.txtLocDescription.Name = "txtLocDescription"
        Me.txtLocDescription.Properties.AccessibleDescription = resources.GetString("txtLocDescription.Properties.AccessibleDescription")
        Me.txtLocDescription.Properties.AccessibleName = resources.GetString("txtLocDescription.Properties.AccessibleName")
        Me.txtLocDescription.Properties.AutoHeight = CType(resources.GetObject("txtLocDescription.Properties.AutoHeight"), Boolean)
        Me.txtLocDescription.Properties.Mask.AutoComplete = CType(resources.GetObject("txtLocDescription.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtLocDescription.Properties.Mask.BeepOnError = CType(resources.GetObject("txtLocDescription.Properties.Mask.BeepOnError"), Boolean)
        Me.txtLocDescription.Properties.Mask.EditMask = resources.GetString("txtLocDescription.Properties.Mask.EditMask")
        Me.txtLocDescription.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtLocDescription.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtLocDescription.Properties.Mask.MaskType = CType(resources.GetObject("txtLocDescription.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtLocDescription.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtLocDescription.Properties.Mask.PlaceHolder"), Char)
        Me.txtLocDescription.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtLocDescription.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtLocDescription.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtLocDescription.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtLocDescription.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtLocDescription.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtLocDescription.Properties.MaxLength = 255
        Me.txtLocDescription.Properties.NullValuePrompt = resources.GetString("txtLocDescription.Properties.NullValuePrompt")
        Me.txtLocDescription.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtLocDescription.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'seLatitude
        '
        resources.ApplyResources(Me.seLatitude, "seLatitude")
        Me.seLatitude.Name = "seLatitude"
        Me.seLatitude.Properties.AccessibleDescription = resources.GetString("seLatitude.Properties.AccessibleDescription")
        Me.seLatitude.Properties.AccessibleName = resources.GetString("seLatitude.Properties.AccessibleName")
        Me.seLatitude.Properties.AutoHeight = CType(resources.GetObject("seLatitude.Properties.AutoHeight"), Boolean)
        Me.seLatitude.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seLatitude.Properties.DisplayFormat.FormatString = "f5"
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
        Me.seLatitude.Properties.MaxValue = New Decimal(New Integer() {89, 0, 0, 0})
        Me.seLatitude.Properties.MinValue = New Decimal(New Integer() {89, 0, 0, -2147483648})
        Me.seLatitude.Properties.NullValuePrompt = resources.GetString("seLatitude.Properties.NullValuePrompt")
        Me.seLatitude.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("seLatitude.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lblLocationType
        '
        resources.ApplyResources(Me.lblLocationType, "lblLocationType")
        Me.lblLocationType.Name = "lblLocationType"
        '
        'seDistance
        '
        resources.ApplyResources(Me.seDistance, "seDistance")
        Me.seDistance.Name = "seDistance"
        Me.seDistance.Properties.AccessibleDescription = resources.GetString("seDistance.Properties.AccessibleDescription")
        Me.seDistance.Properties.AccessibleName = resources.GetString("seDistance.Properties.AccessibleName")
        Me.seDistance.Properties.AutoHeight = CType(resources.GetObject("seDistance.Properties.AutoHeight"), Boolean)
        Me.seDistance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seDistance.Properties.DisplayFormat.FormatString = "f2"
        Me.seDistance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seDistance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seDistance.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.seDistance.Properties.Mask.AutoComplete = CType(resources.GetObject("seDistance.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.seDistance.Properties.Mask.BeepOnError = CType(resources.GetObject("seDistance.Properties.Mask.BeepOnError"), Boolean)
        Me.seDistance.Properties.Mask.EditMask = resources.GetString("seDistance.Properties.Mask.EditMask")
        Me.seDistance.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("seDistance.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.seDistance.Properties.Mask.MaskType = CType(resources.GetObject("seDistance.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.seDistance.Properties.Mask.PlaceHolder = CType(resources.GetObject("seDistance.Properties.Mask.PlaceHolder"), Char)
        Me.seDistance.Properties.Mask.SaveLiteral = CType(resources.GetObject("seDistance.Properties.Mask.SaveLiteral"), Boolean)
        Me.seDistance.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("seDistance.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.seDistance.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seDistance.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seDistance.Properties.MaxValue = New Decimal(New Integer() {500, 0, 0, 0})
        Me.seDistance.Properties.NullValuePrompt = resources.GetString("seDistance.Properties.NullValuePrompt")
        Me.seDistance.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("seDistance.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lblDistance
        '
        resources.ApplyResources(Me.lblDistance, "lblDistance")
        Me.lblDistance.Name = "lblDistance"
        '
        'seDirection
        '
        resources.ApplyResources(Me.seDirection, "seDirection")
        Me.seDirection.Name = "seDirection"
        Me.seDirection.Properties.AccessibleDescription = resources.GetString("seDirection.Properties.AccessibleDescription")
        Me.seDirection.Properties.AccessibleName = resources.GetString("seDirection.Properties.AccessibleName")
        Me.seDirection.Properties.AutoHeight = CType(resources.GetObject("seDirection.Properties.AutoHeight"), Boolean)
        Me.seDirection.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seDirection.Properties.DisplayFormat.FormatString = "f2"
        Me.seDirection.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seDirection.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seDirection.Properties.Mask.AutoComplete = CType(resources.GetObject("seDirection.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.seDirection.Properties.Mask.BeepOnError = CType(resources.GetObject("seDirection.Properties.Mask.BeepOnError"), Boolean)
        Me.seDirection.Properties.Mask.EditMask = resources.GetString("seDirection.Properties.Mask.EditMask")
        Me.seDirection.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("seDirection.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.seDirection.Properties.Mask.MaskType = CType(resources.GetObject("seDirection.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.seDirection.Properties.Mask.PlaceHolder = CType(resources.GetObject("seDirection.Properties.Mask.PlaceHolder"), Char)
        Me.seDirection.Properties.Mask.SaveLiteral = CType(resources.GetObject("seDirection.Properties.Mask.SaveLiteral"), Boolean)
        Me.seDirection.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("seDirection.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.seDirection.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seDirection.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seDirection.Properties.MaxValue = New Decimal(New Integer() {360, 0, 0, 0})
        Me.seDirection.Properties.NullValuePrompt = resources.GetString("seDirection.Properties.NullValuePrompt")
        Me.seDirection.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("seDirection.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cbGroundType
        '
        resources.ApplyResources(Me.cbGroundType, "cbGroundType")
        Me.cbGroundType.Name = "cbGroundType"
        Me.cbGroundType.Properties.AccessibleDescription = resources.GetString("cbGroundType.Properties.AccessibleDescription")
        Me.cbGroundType.Properties.AccessibleName = resources.GetString("cbGroundType.Properties.AccessibleName")
        Me.cbGroundType.Properties.AutoHeight = CType(resources.GetObject("cbGroundType.Properties.AutoHeight"), Boolean)
        Me.cbGroundType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbGroundType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbGroundType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbGroundType.Properties.Columns"), resources.GetString("cbGroundType.Properties.Columns1"), CType(resources.GetObject("cbGroundType.Properties.Columns2"), Integer), CType(resources.GetObject("cbGroundType.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbGroundType.Properties.Columns4"), CType(resources.GetObject("cbGroundType.Properties.Columns5"), Boolean), CType(resources.GetObject("cbGroundType.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbGroundType.Properties.NullText = resources.GetString("cbGroundType.Properties.NullText")
        Me.cbGroundType.Properties.NullValuePrompt = resources.GetString("cbGroundType.Properties.NullValuePrompt")
        Me.cbGroundType.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbGroundType.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbGroundType.Tag = ""
        '
        'btnMAP
        '
        resources.ApplyResources(Me.btnMAP, "btnMAP")
        Me.btnMAP.Name = "btnMAP"
        '
        'pnExactLocation
        '
        resources.ApplyResources(Me.pnExactLocation, "pnExactLocation")
        Me.pnExactLocation.Controls.Add(Me.lblLocDescription)
        Me.pnExactLocation.Controls.Add(Me.ExactLocationGroupBox)
        Me.pnExactLocation.Controls.Add(Me.btnMAP)
        Me.pnExactLocation.Controls.Add(Me.seLongitude)
        Me.pnExactLocation.Controls.Add(Me.txtLocDescription)
        Me.pnExactLocation.Controls.Add(Me.seLatitude)
        Me.pnExactLocation.Controls.Add(Me.lblLatitude)
        Me.pnExactLocation.Controls.Add(Me.lblLongitude)
        Me.pnExactLocation.Name = "pnExactLocation"
        Me.pnExactLocation.TabStop = True
        '
        'ExactLocationGroupBox
        '
        resources.ApplyResources(Me.ExactLocationGroupBox, "ExactLocationGroupBox")
        Me.ExactLocationGroupBox.Controls.Add(Me.lbLocSettlement)
        Me.ExactLocationGroupBox.Controls.Add(Me.cbLocSettlement)
        Me.ExactLocationGroupBox.Controls.Add(Me.Label7)
        Me.ExactLocationGroupBox.Controls.Add(Me.Label8)
        Me.ExactLocationGroupBox.Controls.Add(Me.cbLocRegion)
        Me.ExactLocationGroupBox.Controls.Add(Me.cbLocRayon)
        Me.ExactLocationGroupBox.Name = "ExactLocationGroupBox"
        Me.ExactLocationGroupBox.TabStop = False
        '
        'lbLocSettlement
        '
        resources.ApplyResources(Me.lbLocSettlement, "lbLocSettlement")
        Me.lbLocSettlement.Name = "lbLocSettlement"
        '
        'cbLocSettlement
        '
        resources.ApplyResources(Me.cbLocSettlement, "cbLocSettlement")
        Me.cbLocSettlement.Name = "cbLocSettlement"
        Me.cbLocSettlement.Properties.AccessibleDescription = resources.GetString("cbLocSettlement.Properties.AccessibleDescription")
        Me.cbLocSettlement.Properties.AccessibleName = resources.GetString("cbLocSettlement.Properties.AccessibleName")
        Me.cbLocSettlement.Properties.AutoHeight = CType(resources.GetObject("cbLocSettlement.Properties.AutoHeight"), Boolean)
        Me.cbLocSettlement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLocSettlement.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbLocSettlement.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbLocSettlement.Properties.Columns"), resources.GetString("cbLocSettlement.Properties.Columns1"), CType(resources.GetObject("cbLocSettlement.Properties.Columns2"), Integer), CType(resources.GetObject("cbLocSettlement.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbLocSettlement.Properties.Columns4"), CType(resources.GetObject("cbLocSettlement.Properties.Columns5"), Boolean), CType(resources.GetObject("cbLocSettlement.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbLocSettlement.Properties.NullText = resources.GetString("cbLocSettlement.Properties.NullText")
        Me.cbLocSettlement.Properties.NullValuePrompt = resources.GetString("cbLocSettlement.Properties.NullValuePrompt")
        Me.cbLocSettlement.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbLocSettlement.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbLocSettlement.Tag = ""
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'cbLocRegion
        '
        resources.ApplyResources(Me.cbLocRegion, "cbLocRegion")
        Me.cbLocRegion.Name = "cbLocRegion"
        Me.cbLocRegion.Properties.AccessibleDescription = resources.GetString("cbLocRegion.Properties.AccessibleDescription")
        Me.cbLocRegion.Properties.AccessibleName = resources.GetString("cbLocRegion.Properties.AccessibleName")
        Me.cbLocRegion.Properties.AutoHeight = CType(resources.GetObject("cbLocRegion.Properties.AutoHeight"), Boolean)
        Me.cbLocRegion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLocRegion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbLocRegion.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbLocRegion.Properties.Columns"), resources.GetString("cbLocRegion.Properties.Columns1"), CType(resources.GetObject("cbLocRegion.Properties.Columns2"), Integer), CType(resources.GetObject("cbLocRegion.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbLocRegion.Properties.Columns4"), CType(resources.GetObject("cbLocRegion.Properties.Columns5"), Boolean), CType(resources.GetObject("cbLocRegion.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbLocRegion.Properties.NullText = resources.GetString("cbLocRegion.Properties.NullText")
        Me.cbLocRegion.Properties.NullValuePrompt = resources.GetString("cbLocRegion.Properties.NullValuePrompt")
        Me.cbLocRegion.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbLocRegion.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbLocRegion.Tag = "{M}"
        '
        'cbLocRayon
        '
        resources.ApplyResources(Me.cbLocRayon, "cbLocRayon")
        Me.cbLocRayon.Name = "cbLocRayon"
        Me.cbLocRayon.Properties.AccessibleDescription = resources.GetString("cbLocRayon.Properties.AccessibleDescription")
        Me.cbLocRayon.Properties.AccessibleName = resources.GetString("cbLocRayon.Properties.AccessibleName")
        Me.cbLocRayon.Properties.AutoHeight = CType(resources.GetObject("cbLocRayon.Properties.AutoHeight"), Boolean)
        Me.cbLocRayon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLocRayon.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbLocRayon.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbLocRayon.Properties.Columns"), resources.GetString("cbLocRayon.Properties.Columns1"), CType(resources.GetObject("cbLocRayon.Properties.Columns2"), Integer), CType(resources.GetObject("cbLocRayon.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbLocRayon.Properties.Columns4"), CType(resources.GetObject("cbLocRayon.Properties.Columns5"), Boolean), CType(resources.GetObject("cbLocRayon.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbLocRayon.Properties.NullText = resources.GetString("cbLocRayon.Properties.NullText")
        Me.cbLocRayon.Properties.NullValuePrompt = resources.GetString("cbLocRayon.Properties.NullValuePrompt")
        Me.cbLocRayon.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbLocRayon.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbLocRayon.Tag = "{M}"
        '
        'pnRelativeLocation
        '
        resources.ApplyResources(Me.pnRelativeLocation, "pnRelativeLocation")
        Me.pnRelativeLocation.Controls.Add(Me.seRelLongitude)
        Me.pnRelativeLocation.Controls.Add(Me.seRelLatitude)
        Me.pnRelativeLocation.Controls.Add(Me.lbRelLongitude)
        Me.pnRelativeLocation.Controls.Add(Me.Label5)
        Me.pnRelativeLocation.Controls.Add(Me.RelativeLocationGroupBox)
        Me.pnRelativeLocation.Controls.Add(Me.txtRelativeDescription)
        Me.pnRelativeLocation.Controls.Add(Me.seDirection)
        Me.pnRelativeLocation.Controls.Add(Me.seDistance)
        Me.pnRelativeLocation.Controls.Add(Me.cbGroundType)
        Me.pnRelativeLocation.Controls.Add(Me.Label2)
        Me.pnRelativeLocation.Controls.Add(Me.Label1)
        Me.pnRelativeLocation.Controls.Add(Me.lbRelLatitude)
        Me.pnRelativeLocation.Controls.Add(Me.lblDistance)
        Me.pnRelativeLocation.Name = "pnRelativeLocation"
        Me.pnRelativeLocation.TabStop = True
        '
        'seRelLongitude
        '
        resources.ApplyResources(Me.seRelLongitude, "seRelLongitude")
        Me.seRelLongitude.Name = "seRelLongitude"
        Me.seRelLongitude.Properties.AccessibleDescription = resources.GetString("seRelLongitude.Properties.AccessibleDescription")
        Me.seRelLongitude.Properties.AccessibleName = resources.GetString("seRelLongitude.Properties.AccessibleName")
        Me.seRelLongitude.Properties.AutoHeight = CType(resources.GetObject("seRelLongitude.Properties.AutoHeight"), Boolean)
        Me.seRelLongitude.Properties.DisplayFormat.FormatString = "f5"
        Me.seRelLongitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seRelLongitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seRelLongitude.Properties.Mask.AutoComplete = CType(resources.GetObject("seRelLongitude.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.seRelLongitude.Properties.Mask.BeepOnError = CType(resources.GetObject("seRelLongitude.Properties.Mask.BeepOnError"), Boolean)
        Me.seRelLongitude.Properties.Mask.EditMask = resources.GetString("seRelLongitude.Properties.Mask.EditMask")
        Me.seRelLongitude.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("seRelLongitude.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.seRelLongitude.Properties.Mask.MaskType = CType(resources.GetObject("seRelLongitude.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.seRelLongitude.Properties.Mask.PlaceHolder = CType(resources.GetObject("seRelLongitude.Properties.Mask.PlaceHolder"), Char)
        Me.seRelLongitude.Properties.Mask.SaveLiteral = CType(resources.GetObject("seRelLongitude.Properties.Mask.SaveLiteral"), Boolean)
        Me.seRelLongitude.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("seRelLongitude.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.seRelLongitude.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seRelLongitude.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seRelLongitude.Properties.NullValuePrompt = resources.GetString("seRelLongitude.Properties.NullValuePrompt")
        Me.seRelLongitude.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("seRelLongitude.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.seRelLongitude.Properties.ValidateOnEnterKey = True
        '
        'seRelLatitude
        '
        resources.ApplyResources(Me.seRelLatitude, "seRelLatitude")
        Me.seRelLatitude.Name = "seRelLatitude"
        Me.seRelLatitude.Properties.AccessibleDescription = resources.GetString("seRelLatitude.Properties.AccessibleDescription")
        Me.seRelLatitude.Properties.AccessibleName = resources.GetString("seRelLatitude.Properties.AccessibleName")
        Me.seRelLatitude.Properties.AutoHeight = CType(resources.GetObject("seRelLatitude.Properties.AutoHeight"), Boolean)
        Me.seRelLatitude.Properties.DisplayFormat.FormatString = "f5"
        Me.seRelLatitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seRelLatitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seRelLatitude.Properties.Mask.AutoComplete = CType(resources.GetObject("seRelLatitude.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.seRelLatitude.Properties.Mask.BeepOnError = CType(resources.GetObject("seRelLatitude.Properties.Mask.BeepOnError"), Boolean)
        Me.seRelLatitude.Properties.Mask.EditMask = resources.GetString("seRelLatitude.Properties.Mask.EditMask")
        Me.seRelLatitude.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("seRelLatitude.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.seRelLatitude.Properties.Mask.MaskType = CType(resources.GetObject("seRelLatitude.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.seRelLatitude.Properties.Mask.PlaceHolder = CType(resources.GetObject("seRelLatitude.Properties.Mask.PlaceHolder"), Char)
        Me.seRelLatitude.Properties.Mask.SaveLiteral = CType(resources.GetObject("seRelLatitude.Properties.Mask.SaveLiteral"), Boolean)
        Me.seRelLatitude.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("seRelLatitude.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.seRelLatitude.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seRelLatitude.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seRelLatitude.Properties.NullValuePrompt = resources.GetString("seRelLatitude.Properties.NullValuePrompt")
        Me.seRelLatitude.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("seRelLatitude.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lbRelLongitude
        '
        resources.ApplyResources(Me.lbRelLongitude, "lbRelLongitude")
        Me.lbRelLongitude.Name = "lbRelLongitude"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtRelativeDescription
        '
        resources.ApplyResources(Me.txtRelativeDescription, "txtRelativeDescription")
        Me.txtRelativeDescription.Name = "txtRelativeDescription"
        Me.txtRelativeDescription.Properties.AccessibleDescription = resources.GetString("txtRelativeDescription.Properties.AccessibleDescription")
        Me.txtRelativeDescription.Properties.AccessibleName = resources.GetString("txtRelativeDescription.Properties.AccessibleName")
        Me.txtRelativeDescription.Properties.AutoHeight = CType(resources.GetObject("txtRelativeDescription.Properties.AutoHeight"), Boolean)
        Me.txtRelativeDescription.Properties.Mask.AutoComplete = CType(resources.GetObject("txtRelativeDescription.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtRelativeDescription.Properties.Mask.BeepOnError = CType(resources.GetObject("txtRelativeDescription.Properties.Mask.BeepOnError"), Boolean)
        Me.txtRelativeDescription.Properties.Mask.EditMask = resources.GetString("txtRelativeDescription.Properties.Mask.EditMask")
        Me.txtRelativeDescription.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtRelativeDescription.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtRelativeDescription.Properties.Mask.MaskType = CType(resources.GetObject("txtRelativeDescription.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtRelativeDescription.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtRelativeDescription.Properties.Mask.PlaceHolder"), Char)
        Me.txtRelativeDescription.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtRelativeDescription.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtRelativeDescription.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtRelativeDescription.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtRelativeDescription.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtRelativeDescription.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtRelativeDescription.Properties.MaxLength = 255
        Me.txtRelativeDescription.Properties.NullValuePrompt = resources.GetString("txtRelativeDescription.Properties.NullValuePrompt")
        Me.txtRelativeDescription.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtRelativeDescription.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'lbRelLatitude
        '
        resources.ApplyResources(Me.lbRelLatitude, "lbRelLatitude")
        Me.lbRelLatitude.Name = "lbRelLatitude"
        '
        'pnForeignAddress
        '
        resources.ApplyResources(Me.pnForeignAddress, "pnForeignAddress")
        Me.pnForeignAddress.Controls.Add(Me.txtAddress)
        Me.pnForeignAddress.Controls.Add(Me.lbForeignAddress)
        Me.pnForeignAddress.Controls.Add(Me.lblCountry)
        Me.pnForeignAddress.Controls.Add(Me.cbCountry)
        Me.pnForeignAddress.Name = "pnForeignAddress"
        Me.pnForeignAddress.TabStop = True
        '
        'txtAddress
        '
        resources.ApplyResources(Me.txtAddress, "txtAddress")
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Properties.AccessibleDescription = resources.GetString("txtAddress.Properties.AccessibleDescription")
        Me.txtAddress.Properties.AccessibleName = resources.GetString("txtAddress.Properties.AccessibleName")
        Me.txtAddress.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtAddress.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtAddress.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtAddress.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtAddress.Properties.Appearance.GradientMode = CType(resources.GetObject("txtAddress.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtAddress.Properties.Appearance.Image = CType(resources.GetObject("txtAddress.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtAddress.Properties.Appearance.Options.UseFont = True
        Me.txtAddress.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtAddress.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtAddress.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtAddress.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtAddress.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtAddress.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtAddress.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtAddress.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtAddress.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtAddress.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtAddress.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtAddress.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtAddress.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtAddress.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtAddress.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtAddress.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtAddress.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtAddress.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtAddress.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtAddress.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtAddress.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtAddress.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtAddress.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtAddress.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtAddress.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtAddress.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtAddress.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtAddress.Properties.MaxLength = 200
        Me.txtAddress.Properties.NullValuePrompt = resources.GetString("txtAddress.Properties.NullValuePrompt")
        Me.txtAddress.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtAddress.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtAddress.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAddress.UseOptimizedRendering = True
        '
        'lbForeignAddress
        '
        resources.ApplyResources(Me.lbForeignAddress, "lbForeignAddress")
        Me.lbForeignAddress.Name = "lbForeignAddress"
        '
        'lblCountry
        '
        resources.ApplyResources(Me.lblCountry, "lblCountry")
        Me.lblCountry.Name = "lblCountry"
        '
        'cbCountry
        '
        resources.ApplyResources(Me.cbCountry, "cbCountry")
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Properties.AccessibleDescription = resources.GetString("cbCountry.Properties.AccessibleDescription")
        Me.cbCountry.Properties.AccessibleName = resources.GetString("cbCountry.Properties.AccessibleName")
        Me.cbCountry.Properties.AutoHeight = CType(resources.GetObject("cbCountry.Properties.AutoHeight"), Boolean)
        Me.cbCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCountry.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbCountry.Properties.Columns"), resources.GetString("cbCountry.Properties.Columns1"), CType(resources.GetObject("cbCountry.Properties.Columns2"), Integer), CType(resources.GetObject("cbCountry.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbCountry.Properties.Columns4"), CType(resources.GetObject("cbCountry.Properties.Columns5"), Boolean), CType(resources.GetObject("cbCountry.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbCountry.Properties.NullText = resources.GetString("cbCountry.Properties.NullText")
        Me.cbCountry.Properties.NullValuePrompt = resources.GetString("cbCountry.Properties.NullValuePrompt")
        Me.cbCountry.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbCountry.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbCountry.Tag = "{M}"
        '
        'LocationLookup
        '
        resources.ApplyResources(Me, "$this")
        Me.Appearance.BackColor = CType(resources.GetObject("LocationLookup.Appearance.BackColor"), System.Drawing.Color)
        Me.Appearance.FontSizeDelta = CType(resources.GetObject("LocationLookup.Appearance.FontSizeDelta"), Integer)
        Me.Appearance.FontStyleDelta = CType(resources.GetObject("LocationLookup.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.Appearance.GradientMode = CType(resources.GetObject("LocationLookup.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.Appearance.Image = CType(resources.GetObject("LocationLookup.Appearance.Image"), System.Drawing.Image)
        Me.Appearance.Options.UseBackColor = True
        Me.Controls.Add(Me.cbLocationType)
        Me.Controls.Add(Me.lblLocationType)
        Me.Controls.Add(Me.pnExactLocation)
        Me.Controls.Add(Me.pnRelativeLocation)
        Me.Controls.Add(Me.pnForeignAddress)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.LookupLayout = bv.common.win.LookupFormLayout.DropDownList
        Me.Name = "LocationLookup"
        Me.PopupEditMinWidth = 423
        Me.Status = bv.common.win.FormStatus.Draft
        Me.Controls.SetChildIndex(Me.pnForeignAddress, 0)
        Me.Controls.SetChildIndex(Me.pnRelativeLocation, 0)
        Me.Controls.SetChildIndex(Me.pnExactLocation, 0)
        Me.Controls.SetChildIndex(Me.lblLocationType, 0)
        Me.Controls.SetChildIndex(Me.cbLocationType, 0)
        Me.RelativeLocationGroupBox.ResumeLayout(False)
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSettlement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbLocationType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seLongitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seLatitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seDistance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seDirection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbGroundType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnExactLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnExactLocation.ResumeLayout(False)
        Me.ExactLocationGroupBox.ResumeLayout(False)
        CType(Me.cbLocSettlement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbLocRegion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbLocRayon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnRelativeLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnRelativeLocation.ResumeLayout(False)
        CType(Me.seRelLongitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seRelLatitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRelativeDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnForeignAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnForeignAddress.ResumeLayout(False)
        CType(Me.txtAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overrides Function FillDataset(Optional ByVal aID As Object = Nothing) As Boolean
        If (Not StartUpParameters Is Nothing) AndAlso (StartUpParameters.ContainsKey("DataSet")) AndAlso _
           (TypeOf (StartUpParameters("DataSet")) Is DataSet) AndAlso _
           (Not CType(StartUpParameters("DataSet"), DataSet) Is Nothing) Then
            baseDataSet = New DataSet()
            baseDataSet.EnforceConstraints = False
            baseDataSet.Merge(CType(StartUpParameters("DataSet"), DataSet))
        Else
            Return MyBase.FillDataset(aID)
        End If
        Return True
    End Function

    Public Overrides Sub BeforePopup()
        UpdateInterface()
    End Sub

    Dim m_OkToChangeGeoLocation As Boolean = True

    Protected Overrides Sub AfterLoad()
        MyBase.AfterLoad()
        btnMAP.Enabled = model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(model.Enums.EIDSSPermissionObject.GIS))

        If (Not StartUpParameters Is Nothing) AndAlso _
           (Not LocationDbService Is Nothing) AndAlso LocationDbService.IsNewLocation Then
            Dim params As Dictionary(Of String, Object) = StartUpParameters
            If params.ContainsKey("Country") AndAlso Utils.Str(params("Country")) <> "" Then
                LocationRow("idfsCountry") = params("Country")
                eventManager.Cascade("GeoLocation.idfsCountry")
            End If
            If params.ContainsKey("Region") AndAlso Utils.Str(params("Region")) <> "" Then
                LocationRow("idfsRegion") = params("Region")
                eventManager.Cascade("GeoLocation.idfsRegion")
            End If
            If params.ContainsKey("Rayon") AndAlso Utils.Str(params("Rayon")) <> "" Then
                LocationRow("idfsRayon") = params("Rayon")
                eventManager.Cascade("GeoLocation.idfsRayon")
            End If
        End If
    End Sub

    Protected Overrides Sub DefineBinding()
        m_OkToChangeGeoLocation = True
        If IsDesignMode() Then Return
        m_BindingInProcess = True
        Try
            If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
                ID = Nothing 'Load data for the new record
            End If
            eventManager.RemoveDataHandler("GeoLocation.idfsGeoLocationType")
            eventManager.RemoveDataHandler("GeoLocation.dblLongitude")
            eventManager.RemoveDataHandler("GeoLocation.dblLatitude")
            eventManager.RemoveDataHandler("GeoLocation.dblAccuracy")
            eventManager.RemoveDataHandler("GeoLocation.idfsCountry")
            eventManager.RemoveDataHandler("GeoLocation.idfsRegion")
            eventManager.RemoveDataHandler("GeoLocation.idfsRayon")
            eventManager.RemoveDataHandler("GeoLocation.idfsGroundType")
            If (ForcedGeolocationType <> GeoLocationType.Default) Then
                LocationRow("idfsGeoLocationType") = ForcedGeolocationType
            End If
            Core.LookupBinder.BindBaseLookup(cbLocationType, baseDataSet, "GeoLocation.idfsGeoLocationType", BaseReferenceType.rftGeoLocType, False, False)
            CType(cbLocationType.Properties.DataSource, DataView).RowFilter = String.Format("idfsReference<>{0}", CLng(GeoLocationType.Default))
            Core.LookupBinder.BindRegionLookup(cbLocRegion, baseDataSet, "GeoLocation.idfsRegion")
            Core.LookupBinder.BindRayonLookup(cbLocRayon, baseDataSet, "GeoLocation.idfsRayon")
            Core.LookupBinder.BindSettlementLookup(cbLocSettlement, baseDataSet, "GeoLocation.idfsSettlement")


            'Exact Location Binding
            Core.LookupBinder.BindSpinEdit(seLongitude, baseDataSet, "GeoLocation.dblLongitude", -180, +180, True)
            Core.LookupBinder.BindSpinEdit(seLatitude, baseDataSet, "GeoLocation.dblLatitude", -89, +89, True)
            Core.LookupBinder.BindSpinEdit(seRelLongitude, baseDataSet, "GeoLocation.dblRelLongitude", -180, +180, True)
            Core.LookupBinder.BindSpinEdit(seRelLatitude, baseDataSet, "GeoLocation.dblRelLatitude", -89, +89, True)
            Core.LookupBinder.BindSpinEdit(seDistance, baseDataSet, "GeoLocation.dblDistance", 0, 1000, True)
            Core.LookupBinder.BindSpinEdit(seDirection, baseDataSet, "GeoLocation.dblAlignment", 0, 360, True)

            Core.LookupBinder.BindBaseLookup(cbGroundType, baseDataSet, "GeoLocation.idfsGroundType", BaseReferenceType.rftGroundType, False, True)
            Core.LookupBinder.BindRegionLookup(cbRegion, baseDataSet, "GeoLocation.idfsRegion")
            Core.LookupBinder.BindRayonLookup(cbRayon, baseDataSet, "GeoLocation.idfsRayon")
            Core.LookupBinder.BindSettlementLookup(cbSettlement, baseDataSet, "GeoLocation.idfsSettlement")
            Core.LookupBinder.BindTextEdit(txtLocDescription, baseDataSet, "GeoLocation.strDescription")
            Core.LookupBinder.BindTextEdit(txtRelativeDescription, baseDataSet, "GeoLocation.strDescription")

            'Foreign Address Binding
            Core.LookupBinder.BindCountryLookup(cbCountry, baseDataSet, "GeoLocation.idfsCountry")
            Core.LookupBinder.BindTextEdit(txtAddress, baseDataSet, "GeoLocation.strForeignAddress")

            'AddressLookup1.DataBindings.Add("ID", baseDataSet, "GeoLocation.idfGeoLocation")


            'Dim thRayon As TagHelper = New TagHelper(cbRayon)
            'thRayon.Tag = cbRegion
            'Dim thRegion As TagHelper = New TagHelper(cbRegion)
            'thRegion.Tag = cbCountry

            'Dim thLocRayon As TagHelper = New TagHelper(cbLocRayon)
            'thLocRayon.Tag = cbLocRegion
            'Dim thLocRegion As TagHelper = New TagHelper(cbLocRegion)
            'thLocRegion.Tag = cbLocCountry

            SetAddressVisibility()
            m_BindingInProcess = False
            'UpdateInterface(True)
            eventManager.AttachDataHandler("GeoLocation.idfsGeoLocationType", AddressOf LocationType_Changed)
            eventManager.AttachDataHandler("GeoLocation.idfsCountry", AddressOf Country_Changed)
            eventManager.AttachDataHandler("GeoLocation.idfsRegion", AddressOf Region_Changed)
            eventManager.AttachDataHandler("GeoLocation.idfsRayon", AddressOf Rayon_Changed)
            eventManager.AttachDataHandler("GeoLocation.dblLongitude", AddressOf GeoLocation_Changed)
            eventManager.AttachDataHandler("GeoLocation.dblLatitude", AddressOf GeoLocation_Changed)
            eventManager.AttachDataHandler("GeoLocation.dblDistance", AddressOf GeoLocation_Changed)
            eventManager.AttachDataHandler("GeoLocation.dblAlignment", AddressOf GeoLocation_Changed)
            eventManager.AttachDataHandler("GeoLocation.idfsGroundType", AddressOf GeoLocation_Changed)
            eventManager.AttachDataHandler("GeoLocation.idfsSettlement", AddressOf Settlement_Changed)
            eventManager.AttachDataHandler("GeoLocation.strDescription", AddressOf GeoLocation_Changed)
            eventManager.AttachDataHandler("GeoLocation.dblDistance", AddressOf CalcRelCoordinates)
            eventManager.AttachDataHandler("GeoLocation.dblAlignment", AddressOf CalcRelCoordinates)

            If LocationRow("idfsCountry") Is DBNull.Value Then
                LocationRow("idfsCountry") = model.Core.EidssSiteContext.Instance.CountryID
            End If

            If (Not StartUpParameters Is Nothing) AndAlso _
                    (Not LocationDbService Is Nothing) AndAlso LocationDbService.IsNewLocation Then
                If StartUpParameters.ContainsKey("Country") Then
                    LocationRow("idfsCountry") = StartUpParameters("Country")
                    StartUpParameters.Remove("Country")
                End If
                If StartUpParameters.ContainsKey("Region") Then
                    LocationRow("idfsRegion") = StartUpParameters("Region")
                    StartUpParameters.Remove("Region")
                End If
                If StartUpParameters.ContainsKey("Rayon") Then
                    LocationRow("idfsRayon") = StartUpParameters("Rayon")
                    StartUpParameters.Remove("Rayon")
                End If
                If StartUpParameters.ContainsKey("Settlement") Then
                    LocationRow("idfsSettlement") = StartUpParameters("Settlement")
                    If Not LocationRow("idfsSettlement") Is DBNull.Value Then
                        eventManager.Cascade("GeoLocation.idfsSettlement")
                    End If
                    StartUpParameters.Remove("Settlement")
                End If
                StartUpParameters = Nothing
            End If
            UpdateInterface()
        Catch ex As Exception
            Throw
        Finally
            m_BindingInProcess = False
            If (State And BusinessObjectState.NewObject) = 0 Then
                m_GeoLocationChanged = False
            Else
                m_GeoLocationChanged = True
            End If
        End Try
    End Sub

    Private m_UseMandatoryFields As Boolean = True
    <Browsable(False), DefaultValue(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property UseMandatoryFields() As Boolean
        Get
            Return m_UseMandatoryFields
        End Get
        Set(value As Boolean)
            m_UseMandatoryFields = value
            If m_UseMandatoryFields Then
                cbRegion.Tag = "{M}"
                ApplyControlState(cbRegion, ControlState.Mandatory)
                cbRayon.Tag = "{M}"
                ApplyControlState(cbRayon, ControlState.Mandatory)
                cbSettlement.Tag = "{M}"
                ApplyControlState(cbSettlement, ControlState.Mandatory)
                cbLocationType.Tag = "{M}"
                ApplyControlState(cbLocationType, ControlState.Mandatory)
                cbLocRayon.Tag = "{M}"
                ApplyControlState(cbLocRayon, ControlState.Mandatory)
                cbLocRegion.Tag = "{M}"
                ApplyControlState(cbLocRegion, ControlState.Mandatory)
                cbCountry.Tag = "{M}"
                ApplyControlState(cbCountry, ControlState.Mandatory)
            Else
                cbRegion.Tag = Nothing
                ApplyControlState(cbRegion, ControlState.Normal)
                cbRayon.Tag = Nothing
                ApplyControlState(cbRayon, ControlState.Normal)
                cbSettlement.Tag = Nothing
                ApplyControlState(cbSettlement, ControlState.Normal)
                cbLocationType.Tag = Nothing
                ApplyControlState(cbLocationType, ControlState.Normal)
                cbLocRayon.Tag = Nothing
                ApplyControlState(cbLocRayon, ControlState.Normal)
                cbLocRegion.Tag = Nothing
                ApplyControlState(cbLocRegion, ControlState.Normal)
                cbCountry.Tag = Nothing
                ApplyControlState(cbCountry, ControlState.Normal)
            End If
        End Set
    End Property

    Private Sub ClearCalculatedCoordinates()
        LocationRow("dblRelLongitude") = DBNull.Value
        LocationRow("dblRelLatitude") = DBNull.Value
        LocationRow.EndEdit()
        m_GeoLocationChanged = True
    End Sub

    Private Sub CalcRelCoordinates(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If e.Row.RowState = DataRowState.Detached OrElse e.Row.RowState = DataRowState.Deleted Then
            ClearCalculatedCoordinates()
            Return
        End If
        If e.Row("dblDistance") Is DBNull.Value OrElse e.Row("dblAlignment") Is DBNull.Value OrElse e.Row("idfsSettlement") Is DBNull.Value Then
            ClearCalculatedCoordinates()
            Return
        End If
        Dim longitude As Double
        Dim latitude As Double
        If gis.GisInterface.GetRelativeCoordinates(CLng(e.Row("idfsSettlement")), CLng(e.Row("dblAlignment")), CLng(e.Row("dblDistance")), longitude, latitude) Then
            LocationRow("dblRelLongitude") = longitude
            LocationRow("dblRelLatitude") = latitude
            LocationRow.EndEdit()
        End If
        m_GeoLocationChanged = True
    End Sub

    Private Sub Settlement_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If e.Row("idfsSettlement") Is DBNull.Value Then
            eventManager.Cascade("GeoLocation.dblAlignment")
            Return
        End If
        Dim longitude As Double
        Dim latitude As Double
        If gis.GisInterface.GetSettlementCoordinates(CLng(e.Row("idfsSettlement")), longitude, latitude) Then
            LocationRow("dblLongitude") = longitude
            LocationRow("dblLatitude") = latitude
            LocationRow.EndEdit()
        End If
        If LocationType = GeoLocationType.RelativePoint Then
            eventManager.Cascade("GeoLocation.dblAlignment")
        End If
        m_GeoLocationChanged = True

    End Sub

    Private Sub GeoLocation_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If m_OkToChangeGeoLocation Then
            m_GeoLocationChanged = True
        Else
            m_OkToChangeGeoLocation = True
        End If

    End Sub

    Public Overrides Function ValidateData() As Boolean
        If m_SuppressValidation OrElse LocationRow Is Nothing OrElse LocationRow.RowState = DataRowState.Detached OrElse LocationRow.RowState = DataRowState.Deleted Then Return True
        If Utils.IsEmpty(cbLocationType.EditValue) Then Return True
        If LocationType = GeoLocationType.Address Then
            Return True 'Return AddressLookup1.ValidateData()
        ElseIf LocationType = GeoLocationType.ExactPoint Then
            If Not ValidateMandatoryFields(pnExactLocation) Then
                Return False
            End If
            Return LocationHelper.ValidateLocationCoordinates(seLatitude.EditValue, seLongitude.EditValue)
        ElseIf LocationType = GeoLocationType.RelativePoint Then
            Return ValidateMandatoryFields(pnRelativeLocation)
        End If
        Return True
    End Function


    Dim m_SavedGeoLocationChanged As Boolean = False
    Public Overrides Sub FixCurrentData()
        m_SavedGeoLocationChanged = m_GeoLocationChanged
        MyBase.FixCurrentData()
    End Sub
    Public Overrides Sub CancelChanges()
        m_GeoLocationChanged = m_SavedGeoLocationChanged
        MyBase.CancelChanges()
    End Sub
    Private Sub Country_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Not Loading Then LocationRow("idfsCountry") = e.Value
        Dim currentCountryID As Object = IIf(e.Value Is DBNull.Value, -1, e.Value)
        Dim currentRegionID As Object = LocationRow("idfsRegion")
        If Not currentRegionID Is DBNull.Value AndAlso _
            CType(cbRegion.Properties.DataSource, DataView).Table.Select("idfsCountry = " + Utils.Str(currentCountryID) + " and idfsRegion = " + Utils.Str(currentRegionID)).Length = 0 Then
            LocationRow("idfsRegion") = DBNull.Value
            LocationRow.EndEdit()
            eventManager.Cascade("GeoLocation.idfsRegion")
        End If
        m_GeoLocationChanged = True
    End Sub
    Private Sub Region_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        LocationRow("idfsRegion") = e.Value
        If Not Utils.IsEmpty(e.Value) Then
        End If
        Dim oldRayon As Object = LocationRow("idfsRayon")
        LocationRow("idfsRayon") = DBNull.Value
        eventManager.Cascade("GeoLocation.idfsRayon")
        Core.LookupBinder.FilterRayon(cbLocRayon, e.Value)
        Core.LookupBinder.FilterRayon(cbRayon, e.Value)
        CType(cbRayon.Properties.DataSource, DataView).Sort = "idfsRayon"
        If (Not oldRayon Is DBNull.Value AndAlso CType(cbRayon.Properties.DataSource, DataView).Find(oldRayon) >= 0) Then
            LocationRow("idfsRayon") = oldRayon
        End If
        m_GeoLocationChanged = True
    End Sub
    Private Sub Rayon_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        LocationRow("idfsRayon") = e.Value
        Dim currenrRayonID As Object = -1
        If Not Utils.IsEmpty(LocationRow("idfsRayon")) Then
            currenrRayonID = LocationRow("idfsRayon")
        End If
        LocationRow("idfsSettlement") = DBNull.Value
        LocationRow.EndEdit()
        Core.LookupBinder.FilterSettlement(cbSettlement, currenrRayonID)
        Core.LookupBinder.FilterSettlement(cbLocSettlement, currenrRayonID)
        m_GeoLocationChanged = True
    End Sub

    Private m_BindingInProcess As Boolean = False
    Private m_Updating As Boolean = False

    Private Sub cbSettlement_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cbSettlement.ButtonClick, cbLocSettlement.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus Then
            Dim settlementId As Object = Nothing
            Dim dlgSettlement As BaseForm = New SettlementDetail(settlementId, LocationCountry, LocationRegion, LocationRayon)
            HidePopup()
            ModalChild = True
            If BaseFormManager.ShowModal(dlgSettlement, FindForm, settlementId, Nothing, Nothing) Then
                Dim newID As Object = dlgSettlement.GetKey()
                cbSettlement.EditValue = newID
                LocationRow("idfsSettlement") = newID
            End If
            RestorePopup()
            ModalChild = False
        End If
    End Sub

    Private Sub LocationType_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If IsDesignMode() Then Return
        UpdateInterface()
        If m_OkToChangeGeoLocation Then
            m_GeoLocationChanged = True
        Else
            m_OkToChangeGeoLocation = True
        End If
    End Sub
    Private Sub SwitchBinding(ByVal ctlSource As Control, ByVal ctlTarget As Control, ByVal fieldName As String)
        ctlSource.DataBindings.Clear()
        ctlTarget.DataBindings.Clear()
        ctlTarget.DataBindings.Add("EditValue", baseDataSet, fieldName, False, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Private Sub UpdateInterface()
        If IsDesignMode() Then Return
        If m_BindingInProcess = True OrElse m_Updating Then Return
        m_Updating = True
        If LocationType <> GeoLocationType.Address AndAlso Not LocationRow Is Nothing AndAlso Not LocationRow("idfsCountry").Equals(EidssSiteContext.Instance.CountryID) Then
            LocationRow("idfsCountry") = EidssSiteContext.Instance.CountryID
            eventManager.Cascade("GeoLocation.idfsCountry")
            LocationRow.EndEdit()
        End If
        Select Case LocationType

            Case GeoLocationType.ExactPoint

                pnExactLocation.Visible = True
                pnRelativeLocation.Visible = False
                pnForeignAddress.Visible = False
                SwitchBinding(cbRegion, cbLocRegion, "GeoLocation.idfsRegion")
                SwitchBinding(cbRayon, cbLocRayon, "GeoLocation.idfsRayon")
                SwitchBinding(cbSettlement, cbLocSettlement, "GeoLocation.idfsSettlement")
                SwitchBinding(txtRelativeDescription, txtLocDescription, "GeoLocation.strDescription")
                Core.LookupBinder.FilterRegion(cbLocRegion, LocationRow("idfsCountry"))
                Core.LookupBinder.FilterRayon(cbLocRayon, LocationRow("idfsRegion"))
                Core.LookupBinder.FilterSettlement(cbLocSettlement, LocationRow("idfsRayon"))

            Case GeoLocationType.RelativePoint
                pnExactLocation.Visible = False
                pnRelativeLocation.Visible = True
                pnForeignAddress.Visible = False
                SwitchBinding(cbLocRegion, cbRegion, "GeoLocation.idfsRegion")
                SwitchBinding(cbLocRayon, cbRayon, "GeoLocation.idfsRayon")
                SwitchBinding(cbLocSettlement, cbSettlement, "GeoLocation.idfsSettlement")
                SwitchBinding(txtLocDescription, txtRelativeDescription, "GeoLocation.strDescription")
                Core.LookupBinder.FilterRegion(cbRegion, LocationRow("idfsCountry"))
                Core.LookupBinder.FilterRayon(cbRayon, LocationRow("idfsRegion"))
                Core.LookupBinder.FilterSettlement(cbSettlement, LocationRow("idfsRayon"))
            Case GeoLocationType.Address
                If Not LocationRow Is Nothing AndAlso LocationRow("idfsCountry").Equals(EidssSiteContext.Instance.CountryID) Then
                    LocationRow("idfsCountry") = DBNull.Value
                    eventManager.Cascade("GeoLocation.idfsCountry")
                    LocationRow.EndEdit()
                End If
                pnExactLocation.Visible = False
                pnRelativeLocation.Visible = False
                pnForeignAddress.Visible = True

            Case Else
                pnExactLocation.Visible = False
                pnRelativeLocation.Visible = False
                pnForeignAddress.Visible = False
        End Select
        m_Updating = False
    End Sub


    Private m_LocationHelper As LocationHelper
    Private ReadOnly Property LocationHelper As LocationHelper
        Get
            If (m_LocationHelper Is Nothing) Then
                m_LocationHelper = New LocationHelper(baseDataSet.Tables("GeoLocation"), eventManager, Me.cbLocationType)
            End If
            Return m_LocationHelper
        End Get
    End Property
    Private Sub btnMAP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMAP.Click
        ModalChild = True
        HidePopup()
        Try

            LocationHelper.SetCaseLocation(seLongitude.Value, seLatitude.Value)
            LocationHelper.ValidateLocationCoordinates(seLatitude.EditValue, seLongitude.EditValue)
        Catch ex As Exception
            ErrorForm.ShowError(ex)
        Finally
            RestorePopup()
            ModalChild = False
        End Try
    End Sub

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(GeoLocationType.ExactPoint)> _
    Public Property DefaultLocationType As GeoLocationType
        Get
            Return LocationDbService.DefaultLocationType
        End Get
        Set(value As GeoLocationType)
            LocationDbService.DefaultLocationType = value
        End Set
    End Property


    Public ReadOnly Property LocationType() As GeoLocationType
        Get
            If LocationRow("idfsGeoLocationType") Is DBNull.Value Then
                LocationRow("idfsGeoLocationType") = CLng(DefaultLocationType)
                UpdateInterface()
            End If
            Return CType(LocationRow("idfsGeoLocationType"), GeoLocationType)
        End Get
    End Property
    Public Function LocationDisplayText() As String
        If baseDataSet.Tables.Contains("GeoLocation") = False OrElse baseDataSet.Tables("GeoLocation").Rows.Count = 0 Then
            Return ""
        End If
        Select Case LocationType
            'Case GeoLocationType.Address
            '    Return AddressLookup1.DisplayText
            Case GeoLocationType.ExactPoint
                If baseDataSet.Tables("GeoLocation").Rows.Count > 0 Then
                    Dim row As DataRow = LocationRow
                    Return EIDSS_DbUtils.GetExactLocaionString(Utils.Dbl(row("dblLatitude")), _
                        Utils.Dbl(row("dblLongitude")), _
                        LookupCache.GetLookupValue(row("idfsCountry"), LookupTables.Country, "strCountryName"), _
                        LookupCache.GetLookupValue(row("idfsRegion"), LookupTables.Region, "strRegionName"), _
                        LookupCache.GetLookupValue(row("idfsRayon"), LookupTables.Rayon, "strRayonName"), _
                        LookupCache.GetLookupValue(row("idfsSettlement"), LookupTables.Settlement, "strSettlementType"), _
                        LookupCache.GetLookupValue(row("idfsSettlement"), LookupTables.Settlement, "strSettlementName"))

                End If
            Case GeoLocationType.RelativePoint
                If baseDataSet.Tables("GeoLocation").Rows.Count > 0 Then
                    Dim row As DataRow = LocationRow
                    Return EIDSS_DbUtils.GetRelatedLocaionString(Utils.Dbl(row("dblDistance")), _
                        Utils.Dbl(row("dblAlignment")), _
                        LookupCache.GetLookupValue(row("idfsGroundType"), BaseReferenceType.rftGroundType, "Name"), _
                        LookupCache.GetLookupValue(row("idfsCountry"), LookupTables.Country, "strCountryName"), _
                        LookupCache.GetLookupValue(row("idfsRegion"), LookupTables.Region, "strRegionName"), _
                        LookupCache.GetLookupValue(row("idfsRayon"), LookupTables.Rayon, "strRayonName"), _
                        LookupCache.GetLookupValue(row("idfsSettlement"), LookupTables.Settlement, "strSettlementType"), _
                        LookupCache.GetLookupValue(row("idfsSettlement"), LookupTables.Settlement, "strSettlementName"))
                End If
            Case GeoLocationType.Address
                If baseDataSet.Tables("GeoLocation").Rows.Count > 0 Then
                    Dim row As DataRow = LocationRow
                    Return EIDSS_DbUtils.GetAddressString(LookupCache.GetLookupValue(row("idfsCountry"), LookupTables.Country, "strCountryName"), _
                        "", _
                        "", _
                        "", _
                        "", _
                        "", _
                        "", _
                        "", _
                        "", _
                        "",
                        True,
                        Utils.Str(row("strForeignAddress"))
                        )
                End If

        End Select
        Return ""
    End Function
    Public Overrides ReadOnly Property DisplayText() As String
        Get
            If IsDesignMode() OrElse Created = False OrElse Closing Then Return ""
            If m_BindingDefined = False Then Return ""
            If baseDataSet.Tables.Contains("GeoLocation") = False OrElse baseDataSet.Tables("GeoLocation").Rows.Count = 0 Then
                Return ""
            End If
            Return LocationDisplayText()
        End Get
    End Property


    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        If TypeOf (child) Is AddressLookup Then
            Return GetKey("GeoLocation", "idfGeoLocation")
        Else
            Return MyBase.GetChildKey(child)
        End If

    End Function

    Private m_GeoLocationChanged As Boolean = False
    Public Property IsLocationChanged() As Boolean
        Get
            Return m_GeoLocationChanged
        End Get
        Set(ByVal value As Boolean)
            m_GeoLocationChanged = value
        End Set
    End Property

    Public Overrides Function HasChanges() As Boolean
        'If AddressLookup1.HasChanges Then Return True
        Return m_GeoLocationChanged
    End Function
    Private m_ShowAddress As Boolean = True
    <Browsable(True), DefaultValue(True)> _
    Public Property ShowAddress() As Boolean
        Get
            Return m_ShowAddress
        End Get
        Set(ByVal Value As Boolean)
            m_ShowAddress = Value
            SetAddressVisibility()
        End Set
    End Property
    Private m_ShowRelativePoint As Boolean = True

    <Browsable(True), DefaultValue(True)> _
    Public Property ShowRelativePoint() As Boolean
        Get
            Return m_ShowRelativePoint
        End Get
        Set(ByVal value As Boolean)
            m_ShowRelativePoint = value
            SetAddressVisibility()
        End Set
    End Property
    Private Sub SetAddressVisibility()
        If Not cbLocationType.Properties.DataSource Is Nothing Then
            Dim filter As String = String.Format("idfsReference<>{0}", CLng(GeoLocationType.Default))
            If Not m_ShowAddress Then
                filter += String.Format(" and idfsReference<>{0}", CLng(GeoLocationType.Address))
            End If
            If Not m_ShowRelativePoint Then
                filter += String.Format(" and idfsReference<>{0}", CLng(GeoLocationType.RelativePoint))
            End If
            CType(cbLocationType.Properties.DataSource, DataView).RowFilter = filter
        End If
    End Sub

    Public Overrides Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean
        If (Not StartUpParameters Is Nothing) AndAlso (StartUpParameters.ContainsKey("IsSearchMode")) AndAlso _
           (TypeOf (StartUpParameters("IsSearchMode")) Is Boolean) AndAlso _
           CBool(StartUpParameters("IsSearchMode")) Then Return True
        If MyBase.Post(postType) Then
            m_GeoLocationChanged = False
            Return True
        End If
        Return False
    End Function



    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property LocationCountry() As Object
        Get
            Return LocationRow("idfsCountry")
        End Get
        Set(ByVal value As Object)
            LocationRow("idfsCountry") = value
        End Set
    End Property

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property LocationRegion() As Object
        Get
            Return LocationRow("idfsRegion")
        End Get
        Set(ByVal value As Object)
            LocationRow("idfsRegion") = value
        End Set
    End Property
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property LocationRayon() As Object
        Get
            Return LocationRow("idfsRayon")
        End Get
        Set(ByVal value As Object)
            LocationRow("idfsRayon") = value
        End Set
    End Property
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property LocationSettlement() As Object
        Get
            Return LocationRow("idfsSettlement")
        End Get
        Set(ByVal value As Object)
            LocationRow("idfsSettlement") = value
        End Set
    End Property
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property LocationRow() As DataRow
        Get
            Return baseDataSet.Tables("GeoLocation").Rows(0)
        End Get
    End Property

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ForcedGeolocationType() As GeoLocationType

    Private Sub LocationLookup_OnAfterPost(ByVal sender As Object, ByVal e As EventArgs) Handles Me.OnAfterPost
        m_GeoLocationChanged = False
    End Sub
End Class
